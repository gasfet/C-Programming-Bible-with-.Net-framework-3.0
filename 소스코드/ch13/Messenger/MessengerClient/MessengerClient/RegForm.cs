using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MessengerClient
{
    public partial class RegForm : Form
    {
        #region ��� ����

        // �޽��� Ŭ���̾�Ʈ ����ȭ��  
        public MainWnd wnd = null;

        // �����ȣ �˻�â
        public ZipcodeWnd zipcodewnd = null;

        // ���̵� �ߺ� �˻縦 �ߴ��� �˷��ִ� �÷���
        public bool id_ok = false;

        // ���� ������ �ּ�
        private string ip = null;

        // �޽��� ������ ȸ�� ���� ��� 		
        private RegNetwork net = null;

        #endregion

        #region ������
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="wnd"></param>
        /// <param name="ip"></param>
        public RegForm(MainWnd wnd, string ip)
        {
            InitializeComponent();

            this.wnd = wnd;
            this.ip = ip;  // ������ ���� ������
            this.net = new RegNetwork(this);

        }
        #endregion

        /// <summary>
        /// ���̵� �ߺ��Ǿ����� ó���� �޼���
        /// </summary>
        public void IDCheckOK()
        {
            // ���̵� �ߺ��Ǹ� �ʱ�ȭ
            txt_ID.Text = "";
            txt_ID.Focus();
        }

        /// <summary>
        ///  ���̵� �ߺ� �˻� ��ư Ŭ�� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>		
        private void btn_ID_Click(object sender, EventArgs e)
        {
            // ���̵� ��������
            string txt = txt_ID.Text.Trim();
            if (txt == "")
            {
                MessageBox.Show(" ���̵� �Է��ϼ��� ");
                txt_ID.Focus();
                return;
            }

            // ���̵� �ߺ� �˻�䱸 �޽��� �ۼ�
            string message = (byte)MSG.CTOS_MESSAGE_REGISTER_IDSEARCH + "\a" + txt;
            // �޽��� ������ ���ڿ� ����
            this.net.Connect(this.ip);
            this.net.Send(message);	
        }

        /// <summary>
        /// ���� ��ȣ ã�� ��ư Ŭ�� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Zip_Click(object sender, EventArgs e)
        {
            this.zipcodewnd = new ZipcodeWnd(this.net, this.ip);
            this.zipcodewnd.ShowDialog();

            string addr = this.zipcodewnd.Addr;

            this.zipcodewnd.Close();

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
        /// ȸ�� ���� ��ư Ŭ�� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Reg_Click(object sender, EventArgs e)
        {
            // ȸ�� ���� ���� �޼��� ȣ��
            if (!Authentication()) return; // ���� ���н� ��ȯ			

            // ȸ�� ���� ���� ���ڿ� �ʱ�ȭ
            string msg = null;

            msg += (byte)MSG.CTOS_MESSAGE_REGISTER_REQUEST + "\a";         // ȸ�� ���� ��û �޽���
            msg += txt_ID.Text.Trim() + "#";                  // ���̵�
            msg += txt_Pwd.Text.Trim() + "#";                 // ��ȣ
            msg += txt_Name.Text.Trim() + "#";                // �̸�
            msg += txt_NickName.Text.Trim() + "#"; // ��Ī
            msg += txt_Ssn1.Text.Trim() + "-" + txt_Ssn2.Text.Trim() + "#";   // �ֹ� ��ȣ
            msg += txt_Tel.Text.Trim() + "#";                // ��ȭ��ȣ
            msg += txt_Email.Text.Trim() + "#";              // �̸��� �ּ� 
            msg += txt_Zip1.Text.Trim() + "-" + txt_Zip2.Text.Trim() + "#";   // �����ȣ
            msg += txt_Addr1.Text.Trim() + " " + txt_Addr2.Text.Trim() + "#"; // �ּ�
            msg += txt_Intro.Text.Trim();                    // �ڱ�Ұ�

            // �޽��� ������ ���ڿ� ����
            this.net.Connect(this.ip);
            this.net.Send(msg);			
        }

        /// <summary>
        /// �ٽ� ���� ��ư Ŭ�� �̺�Ʈ 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>	
        private void btn_Re_Click(object sender, EventArgs e)
        {
            // ȭ�鿡 �پ� �ִ�  ��Ʈ���� ���� ��ŭ ȣ��
            for (int i = 0; i < Controls.Count; i++)
                if (Controls[i] is TextBox)  // TextBox ��Ʈ���̸�
                    ((TextBox)Controls[i]).Text = ""; // ���ڿ� �ʱ�ȭ
        }

        /// <summary>
        /// â�� ������ ��Ʈ��ũ ���� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.net.DisConnect();
        }


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

    }
}