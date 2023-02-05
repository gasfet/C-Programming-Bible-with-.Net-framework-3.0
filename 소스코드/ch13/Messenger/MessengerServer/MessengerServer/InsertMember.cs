using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace MessengerServer
{
    public partial class InsertMember : Form
    {
        #region ��� ����

        private DataSet ds = null;
        private bool id_ok = false;
        private string dsn = null;

        #endregion

        #region ������

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="dsn"></param>
        public InsertMember(DataSet ds, string dsn)
        {

            InitializeComponent();

            this.ds = ds;
            this.dsn = dsn;
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
        /// �ֹι�ȣ ��ȿ�� �˻� �޼���
        /// </summary>
        /// <param name="str">�˻��� �ֹι�ȣ</param>
        /// <returns></returns>
        private bool Check_Digit(string str)
        {

            if (Digit_Check(str)) return false; // ���ڸ� �Է��ߴ��� üũ
            if (str.Length != 13) return false; // �ֹ� ��ȣ�� 13�ڸ� ��
            int sum = 0;   // ��ȿ�� ���
            int temp = 0;
            // �ֹ� ��ȣ�� �迭�� ����
            int[] num = new int[13];
            // ����ġ �� ����
            int[] digit = { 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5 };

            // �Էµ� ���ڸ� ���ڷ�!
            for (int i = 0; i < 13; i++)
            {
                num[i] = Int32.Parse(str[i] + "");
            }

            // �ֹ� ��ȣ ��ȿ�� �˻�
            for (int i = 0; i < 12; i++)
            {
                sum += digit[i] * num[i];
            }
            // ��ȿ�� ����
            temp = sum % 11;

            int check_digit_num1 = temp;
            int check_digit_num2 = num[12];

            if (check_digit_num1 == 0)
            {
                if (check_digit_num2 == 1)
                    return true;
                else
                    return false;
            }
            else if (check_digit_num1 == 1)
            {
                if (check_digit_num2 == 0)
                    return true;
                else
                    return false;
            }
            else if ((11 - check_digit_num1) == check_digit_num2) return true;
            else return false;
        }

        /// <summary>
        /// ȸ�� ���� ���� �޼���
        /// </summary>
        /// <returns></returns> 
        private bool Authentication()
        {
            // ���� ���ڿ� ����
            string ErrorMessage = "";
            // ���̵� üũ
            if (txt_ID.Text.Trim() == "")
                ErrorMessage += "- ���̵� �Է��ϼ���.!\n\n";
            else if (txt_ID.Text.Length < 5 || txt_ID.Text.Length > 16)
                ErrorMessage += "- ���̵�� 5�� �̻� 16�� ���� �Դϴ�.\n\n";
            else if (!A_or_D(txt_ID.Text.Trim()))    // ������ ���� üũ�Լ� 			
                ErrorMessage += "- ���̵�� �����̳� ���ڷ� �Է��ϼž� �մϴ�.\n\n";

            // ���̵� �ߺ� �˻� ����
            if (!id_ok)
                ErrorMessage += " *** ���̵� �ߺ� �˻縦 �ϼ��� ! *** \n\n";

            // ��ȣ üũ
            if (txt_Pwd.Text.Length < 5 || txt_ID.Text.Length > 16)
                ErrorMessage += "- ��ȣ�� 5�� �̻� 16�� ���� �Դϴ�.\n\n";
            else if (!A_or_D(txt_Pwd.Text.Trim()))
                ErrorMessage += "- ��ȣ�� ���� �Ǵ� ���ڸ� �Է��ؾ� �մϴ�.!\n\n";
            else if (!txt_Pwd.Text.Equals(txt_Pwd_Ok.Text.Trim()))
                ErrorMessage += "- ��ȣ�� ��ġ���� �ʽ��ϴ�.\n\n";

            // �̸� üũ
            if (txt_Name.Text.Trim() == "")
                ErrorMessage += "- �̸��� �Է��ϼ���!\n\n";

            // ��Ī üũ
            if (txt_NickName.Text.Trim() == "")
                ErrorMessage += "- ��Ī�� �Է����ּ���!\n\n";
            else if (txt_NickName.Text.Length > 100)
                ErrorMessage += "- ��Ī�� 100���ھȿ��� �Է����ּ���.\n\n";


            // �ֹ� ��ȣ üũ
            if (!Check_Digit(txt_Ssn1.Text.Trim() + txt_Ssn2.Text.Trim()))
                ErrorMessage += "- �ֹε�Ϲ�ȣ�� ��Ȯ�� �Է��ϼ���.\n\n";

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
            if (txt_Addr1.Text.Trim() == "" && txt_Addr2.Text.Trim() == "")
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
        /// ȭ�鿡 �ִ� ��Ʈ�� ���ڿ� �ʱ�ȭ
        /// </summary>
        private void InitControl()
        {
            // ȭ�鿡 �پ� �ִ�  ��Ʈ���� ���� ��ŭ ȣ��
            for (int i = 0; i < Controls.Count; i++)
                if (Controls[i] is TextBox)  // TextBox ��Ʈ���̸�
                    ((TextBox)Controls[i]).Text = ""; // ���ڿ� �ʱ�ȭ
        }

        #endregion

        #region �̺�Ʈ
        /// <summary>
        /// ���̵� �ߺ� �˻� ��ư Ŭ�� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ID_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_ID.Text.Length == 0)
                {
                    MessageBox.Show("���̵� �Է��ϼ���!");
                    return;
                }

                string filter = "user_id = '" + txt_ID.Text.Trim() + "'";

                DataRow[] row = ds.Tables["TBL_Member"].Select(filter);

                if (row.Length > 0)
                    this.id_ok = false;
                else
                    this.id_ok = true;

                string str = id_ok ? "���̵� ��밡��!" : "�̹� ���Ե� ���̵�!";

                MessageBox.Show(str, "���̵� �ߺ� �˻� ���");
            }
            catch 
            {
                MessageBox.Show("�����ͼ� ���� �߻�", "����!");
            }
        }

        /// <summary>
        /// �����ȣ ã�� Ŭ�� �̺�Ʈ
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
                txt_Addr1.Text = token[1];

                txt_Addr2.Focus();
            }
        }

        /// <summary>
        /// ȸ�� �߰� Ŭ�� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Reg_Click(object sender, EventArgs e)
        {
            try
            {
                // ȸ�� ���� ���� �޼��� ȣ��
                if (!Authentication()) return; // ���� ���н� ��ȯ			
                // ȸ�� ���� ���			
                DataRow row = ds.Tables["TBL_Member"].NewRow();

                row["user_id"] = txt_ID.Text.Trim();
                row["pwd"] = txt_Pwd.Text.Trim();
                row["name"] = txt_Name.Text.Trim();
                row["nickname"] = txt_NickName.Text.Trim();
                row["ssn"] = txt_Ssn1.Text.Trim() + "-" + txt_Ssn2.Text.Trim();
                row["tel"] = txt_Tel.Text.Trim();
                row["email"] = txt_Email.Text.Trim();
                row["zipcode"] = txt_Zip1.Text.Trim() + "-" + txt_Zip2.Text.Trim();
                row["address"] = txt_Addr1.Text.Trim() + " " + txt_Addr2.Text.Trim();
                row["intro"] = txt_Intro.Text.Trim();

                ds.Tables["TBL_Member"].Rows.Add(row);

                MessageBox.Show("ȸ�� �߰� ����!", "��� Ȯ��");

                this.InitControl(); // ȭ�鿡 �ִ� ������ ����

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// �ٽþ��� Ŭ�� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Re_Click(object sender, EventArgs e)
        {
            this.InitControl();
        }

        /// <summary>
        /// â �ݱ� Ŭ�� �̺�Ʈ
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