using System;
using System.Drawing;
using System.Windows.Forms;

using System.Net.Mail;   // 전자 메일 프로토콜
using System.Text;       // 문자열 처리

namespace SMTP_Exam
{
    public partial class MainWnd : Form
    {
        public MainWnd()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 전자 우편 주소 유효성 검사
        /// </summary>
        /// <param name="str">검사할 이메일 주소</param>
        /// <returns></returns>
        private bool EmailCheck(string str)
        {
            // @ 와 . 이 2개이상 포함되어 있어야합니다.
            byte stock = 0;

            foreach (char ch in str)
            {
                if (ch == '@' || ch == '.') stock++;
            }
            if (stock == 2) return true;
            return false;
        }


        /// <summary>
        /// 메일 발송을 위한 메일 주소, 제목, 내용 입력 인증
        /// </summary>
        /// <returns></returns> 
        private bool Authentication()
        {
            string ErrorMessage = "";

            // E - mail 주소 체크
            if (txt_To.Text == "")
                ErrorMessage += "- 받는 사람 E-메일 주소를 입력하세요.!\n\n";
            else if (!EmailCheck(txt_To.Text))
                ErrorMessage += "- 보내는 사람 E-메일 주소를 정확히 입력하세요.!\n\n";

            // E - mail 주소 체크
            if (txt_From.Text == "")
                ErrorMessage += "- 보내는 사람 E-메일 주소를 입력하세요.!\n\n";
            else if (!EmailCheck(txt_From.Text))
                ErrorMessage += "- 보내는 사람 E-메일 주소를 정확히 입력하세요.!\n\n";

            // 제목 입력 체크
            if (txt_Subject.Text == "")
                ErrorMessage += "- 제목을 입력하세요.\n\n";

            // 내용 입력 체크
            if (txt_Body.Text == "")
                ErrorMessage += "- 내용을 입력하세요.\n\n";

            // 에러메시지가 있을 경우
            if (ErrorMessage != "")
            {
                MessageBox.Show(ErrorMessage, "기입 에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            // 회원 가입 인증 처리
            if (!Authentication()) return;

            // 받는 사람 주소
            MailAddress from = new MailAddress(txt_From.Text);
            // 보내는 사람 주소
            MailAddress to = new MailAddress(txt_To.Text);

            // 전자 메일 메시지를 보낼수 있는 클래스 생성
            MailMessage mail = new MailMessage(from, to);

            // 메일 제목 지정
            mail.Subject = txt_Subject.Text;
            // 메일 내용 지정
            mail.Body = txt_Body.Text;
            // 메일 인코딩 속성 지정 
            mail.BodyEncoding = Encoding.Default;

            // 메일 발송
            try
            {
                if (this.txt_Attach_Path.Text.Trim() != "")
                {
                    Attachment attach = new Attachment(this.txt_Attach_Path.Text.Trim());
                    mail.Attachments.Add(attach);
                }

                SmtpClient client = new SmtpClient();
                client.Send(mail);

                MessageBox.Show("메일을 성공적으로 보냈습니다.!");
                this.btn_Reset_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("메일 전송 실패!:" + ex.StackTrace);
            }		

        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            // 화면에 있는 TextBox 를 초기화 
            this.txt_To.Text = "";
            this.txt_From.Text = "";
            this.txt_Subject.Text = "";
            this.txt_Body.Text = "";
            this.txt_Attach_Path.Text = "";

            this.txt_To.Focus();
        }

        private void btn_AttachPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = @"c:\";
            dlg.Title = "첨부할 파일을 선택하세요.";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_Attach_Path.Text = dlg.FileName;
            }
        }
    }
}