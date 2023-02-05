using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace P2PClient
{
    public partial class RegisterWnd : Form
    {
        // ���̵� �ߺ� �˻縦 �ߴ��� �˷��ִ� �÷���
        public bool ID_OK = false;
        private MainWnd client = null;

        /// <summary>
        /// RegisterWnd Ŭ���� ������
        /// </summary>
        /// <param name="client"></param>
        public RegisterWnd(MainWnd client)
        {
            InitializeComponent();
            this.client = client;
        }

        /// <summary>
        ///  ���̵� �ߺ� �˻� ��ư Ŭ�� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_id_Click(object sender, System.EventArgs e)
        {
            string txt = txt_id.Text.Trim();
            if (txt == "")
            {
                MessageBox.Show(" ���̵� �Է��ϼ��� ");
                txt_id.Focus();
                return;
            }
            Id_Check(txt); // ���̵� �ߺ� üũ �޼��� ȣ��
        }

        /// <summary>
        /// ȸ�� ���� ��ư�� Ŭ���Ҷ� �߻��ϴ� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_register_Click(object sender, System.EventArgs e)
        {
            if (!Authentication()) return;   // ȸ�� ���� ���� �޼��� ȣ��
            // ������ ������ �޽���
            string message = null;

            message += "C_REQ_MEMBER#";
            message += txt_id.Text + "#";   // ���̵�
            message += txt_pwd.Text + "#";   // ��ȣ
            message += txt_email.Text + "#"; // �̸��� �ּ� 

            client.Send(message);  // ������ �޽��� ����

            this.Close();   // ���� â �ݱ�		
        }

        /// <summary>
        /// �ٽ� ���� ��ư Ŭ�� �Ҷ� �߻��ϴ� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reset_Click(object sender, System.EventArgs e)
        {
            // ȭ�鿡 �پ� �ִ�  ��Ʈ���� ����
            for (int i = 0; i < Controls.Count; i++)
                if (Controls[i] is TextBox)
                    ((TextBox)Controls[i]).Text = ""; // TextBox �ȿ� ���� �ʱ�ȭ
            txt_id.Focus();		  // ���̵� �Է��ϴ� �κп� ������ ����
        }


        //*** ����� ���� �Լ� �κ� ***//

        /// <summary>		
        /// ���̵� �ߺ� üũ �޼���		
        /// </summary>
        /// <param name="id"></param>
        private void Id_Check(string id)
        {
            string message = "C_REQ_MEMBERID_CHECK#" + id; // ���̵� �ߺ� �䱸

            client.Send(message);  // ������ �޽��� ����			
        }

        /// <summary>
        /// ���ڿ� ���� �Է� üũ �޼���
        /// </summary>
        /// <param name="str">üũ�� ���ڿ�</param>
        /// <returns></returns>
        private bool A_or_D(string str)
        {
            string lower_str = str.ToLower(); // �ҹ��ڷ� ����
            foreach (char ch in lower_str)   // a ~ z �Ǵ� 0~9 ���� üũ			
            {
                if (((ch < 'a') || (ch > 'z')) && ((ch < '0') || (ch > '9')))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// E ���� �ּ� ��ȿ�� �˻� �޼���
        /// </summary>
        /// <param name="str">���� ���� �ּ�</param>
        /// <returns></returns>
        private bool Email_Check(string str)
        {
            // ���� ������ @ �� . ��ȣ�� �ּ� 2�� �̻� ����
            byte stock = 0;

            foreach (char ch in str)
            {
                if (ch == '@' || ch == '.') stock++;
            }
            if (stock == 2) return true; // 2���̻� �����ϸ� ����� �Է��� ����
            return false;
        }


        /// <summary>
        ///  ȸ�� ���� ���� �޼���
        /// </summary>
        /// <returns></returns>
        private bool Authentication()
        {
            string ErrorMessage = "";

            // ���̵� üũ
            if (txt_id.Text == "")
                ErrorMessage += "- ���̵� �Է��ϼ���.!\n\n";
            else if (txt_id.Text.Length < 5 || txt_id.Text.Length > 16)
                ErrorMessage += "- ���̵�� 5�� �̻� 16�� ���� �Դϴ�.\n\n";
            else if (!A_or_D(txt_id.Text))    // ������ ���� üũ�Լ� 
                ErrorMessage += "- ���̵�� �����̳� ���ڷ� �Է��ϼž� �մϴ�.\n\n";

            // ���̵� �ߺ� �˻� ����
            if (!ID_OK)
                ErrorMessage += " *** ���̵� �ߺ� �˻縦 �ϼ��� ! *** \n\n";

            // ��ȣ üũ
            if (txt_pwd.Text.Length < 5 || txt_id.Text.Length > 16)
                ErrorMessage += "- ��ȣ�� 5�� �̻� 16�� ���� �Դϴ�.\n\n";
            else if (!A_or_D(txt_pwd.Text))
                ErrorMessage += "- ��ȣ�� ���� �Ǵ� ���ڸ� �Է��ؾ� �մϴ�.!\n\n";
            else if (!txt_pwd.Text.Equals(txt_pwd_ok.Text))
                ErrorMessage += "- ��ȣ�� ��ġ���� �ʽ��ϴ�.\n\n";


            // E - mail �ּ� üũ
            if (txt_email.Text == "")
                ErrorMessage += "- E-���� �ּҸ� �Է��ϼ���.!\n\n";
            else if (!Email_Check(txt_email.Text))
                ErrorMessage += "- E-���� �ּҸ� ��Ȯ�� �Է��ϼ���.!\n\n";

            if (ErrorMessage != "")
            {
                MessageBox.Show(ErrorMessage, "��� ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


    }
}