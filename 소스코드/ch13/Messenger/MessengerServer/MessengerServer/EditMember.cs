using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MessengerServer
{
    public partial class EditMember : Form
    {
        #region ��� ����

        private DataSet ds = null;    // �޸� �����ͺ��̽� 
        private int index = 0;        // �޸� �����ͺ��̽����� ȸ�� ������ ������ �ε���   
        private string dsn = null;    // SQL ���� dsn ��

        #endregion

        #region ������
        /// <summary>
        /// ȸ�� ���� ���� ������ ������
        /// </summary>
        /// <param name="ds">�޸� �����ͺ��̽�</param>
        /// <param name="index">������ ������ �ε���</param>
        /// <param name="dsn">SQL ���� dsn��</param>
        public EditMember(DataSet ds, int index, string dsn)
        {
            InitializeComponent();

            this.ds = ds;
            this.index = index;
            this.dsn = dsn;

            InitDialog();
        }
        #endregion

        #region ��� �޼���

        ///////////////////////////////////////// 
        /// ȸ�� ���� ���� �޼���
        ////////////////////////////////////////   

        /// <summary>
        ///  ���ڿ� ���� �Է� üũ �޼���
        /// </summary>
        /// <param name="str">üũ�� ���ڿ�</param>
        /// <returns></returns>
        private bool A_or_D(string str)
        {
            // �ҹ��ڷ� �����
            string lower_str = str.ToLower();
            // a~z , 0< ? < 9 �ȿ� ���ԵǾ����� �˻�
            foreach (char ch in lower_str)
            {
                if (((ch < 'a') || (ch > 'z')) && ((ch < '0') || (ch > '9')))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// ��ȭ ��ȣ �Է� üũ �޼���
        /// </summary>
        /// <param name="str">üũ�� ��ȭ��ȣ</param>
        /// <returns></returns>
        private bool Tel_Check(string str)
        {
            if (Digit_Check(str)) return false;  // ���� �Է� Ȯ��
            // �м��� ���ڿ��� �ҹ��ڷ� ����
            string lower_str = str.ToLower();
            // ��ȭ��ȣ�� - �� 0~9 ���� ���� ���� �ԷµǾ�� ��.
            foreach (char ch in lower_str)
            {
                if ((ch != '-') && ((ch < '0') || (ch > '9')))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// ���� �Է� Ȯ��
        /// </summary>
        /// <param name="str">�м��� ���ڿ�</param>
        /// <returns></returns>
        private bool Digit_Check(string str)
        {
            // �ҹ��ڷ� ��ȯ
            string lower_str = str.ToLower();
            // 0~9 ���� ���� Ȯ��
            foreach (char ch in lower_str)
            {
                if ((ch < '0') || (ch > '9'))
                    return true;
            }
            return false;
        }

        /// <summary>
        ///  E ���� �ּ� ��ȿ�� �˻� �޼���
        /// </summary>
        /// <param name="str">�˻��� ���ڿ�</param>
        /// <returns></returns>
        private bool Email_Check(string str)
        {
            byte stock = 0;
            // ���� ���� �ּҴ� @ �� . �� ���ԵǾ� �־����.
            foreach (char ch in str)
            {
                if (ch == '@' || ch == '.') stock++;
            }
            if (stock >= 2) return true;
            return false;
        }

        /// <summary>
        /// ȸ�� ���� ���� �޼���
        /// </summary>
        /// <returns></returns> 
        private bool Authentication()
        {
            // ���� ���ڿ� ����
            string ErrorMessage = "";
            // ��ȣ üũ
            if (txt_Pwd.Text.Length < 5 || txt_ID.Text.Length > 16)
                ErrorMessage += "- ��ȣ�� 5�� �̻� 16�� ���� �Դϴ�.\n\n";
            else if (!A_or_D(txt_Pwd.Text.Trim()))
                ErrorMessage += "- ��ȣ�� ���� �Ǵ� ���ڸ� �Է��ؾ� �մϴ�.!\n\n";

            // ��Ī üũ
            if (txt_NickName.Text.Trim() == "")
                ErrorMessage += "- ��Ī�� �Է����ּ���!\n\n";
            else if (txt_NickName.Text.Length > 100)
                ErrorMessage += "- ��Ī�� 100���ھȿ��� �Է����ּ���.\n\n";

            // ��ȭ ��ȣ üũ
            if (txt_Tel.Text.Trim() == "")
                ErrorMessage += "- ��ȭ ��ȣ�� �Է��ϼ���.!\n\n";
            else if (Tel_Check(txt_Tel.Text.Trim()))
                ErrorMessage += "- ��ȭ��ȣ���� ���ڿ� '-'�� ����� �� �ֽ��ϴ�.\n\n";

            // E - mail �ּ� üũ
            if (txt_Email.Text.Trim() == "")
                ErrorMessage += "- E-���� �ּҸ� �Է��ϼ���.!\n\n";
            else if (!Email_Check(txt_Email.Text.Trim()))
                ErrorMessage += "- E-���� �ּҸ� ��Ȯ�� �Է��ϼ���.!\n\n";

            // ���� ��ȣ üũ
            if (txt_Zip1.Text.Trim() + txt_Zip2.Text.Trim() == "")
                ErrorMessage += "- �����ȣ�� �Է��ϼ���.\n\n";
            else if (Digit_Check(txt_Zip1.Text.Trim() + txt_Zip2.Text.Trim()))
                ErrorMessage += "- �����ȣ���� ���ڸ� �Է��� �� �ֽ��ϴ�.\n\n";

            // �ּ� �Է� üũ
            if (txt_Addr.Text.Trim() == "")
                ErrorMessage += "- �ּҸ� �Է��ϼ���.\n\n";

            // ���� ���ڿ� üũ
            if (ErrorMessage != "")
            {
                MessageBox.Show(ErrorMessage, "��� ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        /// <summary>
        /// ��ȭ���� �ʱ�ȭ
        /// </summary>
        private void InitDialog()
        {
            try
            {
                // �����ͼ¿��� �ప ��������
                DataRow dr = ds.Tables["TBL_Member"].Rows[this.index];

                txt_ID.Text = dr["user_id"].ToString();
                txt_Pwd.Text = dr["pwd"].ToString();
                txt_Name.Text = dr["name"].ToString();
                txt_NickName.Text = dr["nickname"].ToString();
                txt_Tel.Text = dr["tel"].ToString();
                txt_Email.Text = dr["email"].ToString();

                string[] token = dr["zipcode"].ToString().Split('-');
                txt_Zip1.Text = token[0];
                txt_Zip2.Text = token[1];

                txt_Addr.Text = dr["address"].ToString();
                txt_Intro.Text = dr["intro"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        #region �̺�Ʈ

        /// <summary>
        /// �����ȣ ã��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Zip_Click(object sender, EventArgs e)
        {
            ZipcodeWnd dlg = new ZipcodeWnd(this.dsn);
            dlg.ShowDialog();

            string addr = dlg.Addr;

            dlg.Close();

            if (addr != null)
            {
                string[] token = addr.Split('#');

                string[] zip = token[0].Split('-');

                txt_Zip1.Text = zip[0];
                txt_Zip2.Text = zip[1];
                txt_Addr.Text = token[1];

                txt_Addr.Focus();
            }
        }

        /// <summary>
        /// ȸ�� ���� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                // ȸ�� ���� ���� �޼��� ȣ��
                if (!Authentication()) return; // ���� ���н� ��ȯ	

                DataRow row = ds.Tables["TBL_Member"].Rows[this.index];
                row.BeginEdit();
                row["pwd"] = txt_ID.Text.Trim();
                row["nickname"] = txt_NickName.Text.Trim();
                row["tel"] = txt_Tel.Text.Trim();
                row["email"] = txt_Email.Text.Trim();
                row["zipcode"] = txt_Zip1.Text + "-" + txt_Zip2.Text;
                row["address"] = txt_Addr.Text.Trim();
                row["intro"] = txt_Intro.Text.Trim();
                row.EndEdit();

                MessageBox.Show("ȸ�� ���� ���� ����!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// â�ݱ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

#endregion

    }
}