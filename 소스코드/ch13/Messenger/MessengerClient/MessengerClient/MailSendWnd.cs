using System;
using System.Drawing;
using System.Windows.Forms;

using System.Net.Mail;   // ���� ���� ��������
using System.Text;       // ���ڿ� ó��

namespace MessengerClient
{
    public partial class MailSendWnd : Form
    {
        #region ������
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="strName">�޴� ��� �̸�</param>
        /// <param name="strEmail">�޴� ��� ���� �ּ�</param>
        public MailSendWnd(string strName, string strEmail)
        {
            InitializeComponent();

            this.txt_Subject.Text = "[" + strName + "]�� �ȳ��ϼ���!";
            this.txt_To.Text = strEmail;
            // ���� �������̿� ��Ŀ�� ����          
            this.txt_From.Focus();

        }

        #endregion 

        #region ��� �޼���
        /// <summary>
        /// ���� ���� �ּ� ��ȿ�� �˻�
        /// </summary>
        /// <param name="str">�˻��� �̸��� �ּ�</param>
        /// <returns></returns>
        private bool EmailCheck(string str)
        {
            // @ �� . �� 2���̻� ���ԵǾ� �־���մϴ�.
            byte stock = 0;

            foreach (char ch in str)
            {
                if (ch == '@' || ch == '.') stock++;
            }
            if (stock == 2) return true;
            return false;
        }


        /// <summary>
        /// ���� �߼��� ���� ���� �ּ�, ����, ���� �Է� ����
        /// </summary>
        /// <returns></returns> 
        private bool Authentication()
        {
            string ErrorMessage = "";

            // E - mail �ּ� üũ
            if (txt_To.Text == "")
                ErrorMessage += "- �޴� ��� E-���� �ּҸ� �Է��ϼ���.!\n\n";
            else if (!EmailCheck(txt_To.Text))
                ErrorMessage += "- ������ ��� E-���� �ּҸ� ��Ȯ�� �Է��ϼ���.!\n\n";

            // E - mail �ּ� üũ
            if (txt_From.Text == "")
                ErrorMessage += "- ������ ��� E-���� �ּҸ� �Է��ϼ���.!\n\n";
            else if (!EmailCheck(txt_From.Text))
                ErrorMessage += "- ������ ��� E-���� �ּҸ� ��Ȯ�� �Է��ϼ���.!\n\n";

            // ���� �Է� üũ
            if (txt_Subject.Text == "")
                ErrorMessage += "- ������ �Է��ϼ���.\n\n";

            // ���� �Է� üũ
            if (txt_Body.Text == "")
                ErrorMessage += "- ������ �Է��ϼ���.\n\n";

            // �����޽����� ���� ���
            if (ErrorMessage != "")
            {
                MessageBox.Show(ErrorMessage, "���� ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        #endregion
        
        #region �̺�Ʈ
        /// <summary>
        /// ���� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Send_Click(object sender, EventArgs e)
        {
            // ȸ�� ���� ���� ó��
            if (!Authentication()) return;

            // �޴� ��� �ּ�
            MailAddress from = new MailAddress(txt_From.Text);
            // ������ ��� �ּ�
            MailAddress to = new MailAddress(txt_To.Text);

            // ���� ���� �޽����� ������ �ִ� Ŭ���� ����
            MailMessage mail = new MailMessage(from, to);

            // ���� ���� ����
            mail.Subject = txt_Subject.Text;
            // ���� ���� ����
            mail.Body = txt_Body.Text;
            // ���� ���ڵ� �Ӽ� ���� 
            mail.BodyEncoding = Encoding.Default;

            // ���� �߼�
            try
            {
                if (this.txt_Attach_Path.Text.Trim() != "")
                {
                    Attachment attach = new Attachment(this.txt_Attach_Path.Text.Trim());
                    mail.Attachments.Add(attach);
                }

                SmtpClient client = new SmtpClient();
                client.Send(mail);

                MessageBox.Show("������ ���������� ���½��ϴ�.!");
                this.btn_Reset_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("���� ���� ����!:" + ex.StackTrace);
            }		

        }

        /// <summary>
        /// ���� �ٽþ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            // ȭ�鿡 �ִ� TextBox �� �ʱ�ȭ 
            this.txt_To.Text = "";
            this.txt_From.Text = "";
            this.txt_Subject.Text = "";
            this.txt_Body.Text = "";
            this.txt_Attach_Path.Text = "";

            this.txt_To.Focus();
        }

        /// <summary>
        /// ÷������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AttachPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = @"c:\";
            dlg.Title = "÷���� ������ �����ϼ���.";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_Attach_Path.Text = dlg.FileName;
            }
        }

        #endregion




    }
}