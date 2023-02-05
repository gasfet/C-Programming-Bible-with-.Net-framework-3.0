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
        // 아이디 중복 검사를 했는지 알려주는 플래그
        public bool ID_OK = false;
        private MainWnd client = null;

        /// <summary>
        /// RegisterWnd 클래스 생성자
        /// </summary>
        /// <param name="client"></param>
        public RegisterWnd(MainWnd client)
        {
            InitializeComponent();
            this.client = client;
        }

        /// <summary>
        ///  아이디 중복 검사 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_id_Click(object sender, System.EventArgs e)
        {
            string txt = txt_id.Text.Trim();
            if (txt == "")
            {
                MessageBox.Show(" 아이디를 입력하세요 ");
                txt_id.Focus();
                return;
            }
            Id_Check(txt); // 아이디 중복 체크 메서드 호출
        }

        /// <summary>
        /// 회원 가입 버튼을 클릭할때 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_register_Click(object sender, System.EventArgs e)
        {
            if (!Authentication()) return;   // 회원 가입 인증 메서드 호출
            // 서버에 전송할 메시지
            string message = null;

            message += "C_REQ_MEMBER#";
            message += txt_id.Text + "#";   // 아이디
            message += txt_pwd.Text + "#";   // 암호
            message += txt_email.Text + "#"; // 이메일 주소 

            client.Send(message);  // 서버에 메시지 전송

            this.Close();   // 현재 창 닫기		
        }

        /// <summary>
        /// 다시 쓰기 버튼 클릭 할때 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reset_Click(object sender, System.EventArgs e)
        {
            // 화면에 붙어 있는  컨트롤의 갯수
            for (int i = 0; i < Controls.Count; i++)
                if (Controls[i] is TextBox)
                    ((TextBox)Controls[i]).Text = ""; // TextBox 안에 내용 초기화
            txt_id.Focus();		  // 아이디 입력하는 부분에 초점을 맞춤
        }


        //*** 사용자 정의 함수 부분 ***//

        /// <summary>		
        /// 아이디 중복 체크 메서드		
        /// </summary>
        /// <param name="id"></param>
        private void Id_Check(string id)
        {
            string message = "C_REQ_MEMBERID_CHECK#" + id; // 아이디 중복 요구

            client.Send(message);  // 서버에 메시지 전송			
        }

        /// <summary>
        /// 숫자와 영문 입력 체크 메서드
        /// </summary>
        /// <param name="str">체크할 문자열</param>
        /// <returns></returns>
        private bool A_or_D(string str)
        {
            string lower_str = str.ToLower(); // 소문자로 변경
            foreach (char ch in lower_str)   // a ~ z 또는 0~9 인지 체크			
            {
                if (((ch < 'a') || (ch > 'z')) && ((ch < '0') || (ch > '9')))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// E 메일 주소 유효성 검사 메서드
        /// </summary>
        /// <param name="str">전자 메일 주소</param>
        /// <returns></returns>
        private bool Email_Check(string str)
        {
            // 전자 우편은 @ 와 . 기호가 최소 2번 이상 나옴
            byte stock = 0;

            foreach (char ch in str)
            {
                if (ch == '@' || ch == '.') stock++;
            }
            if (stock == 2) return true; // 2번이상 만조하면 제대로 입력한 것임
            return false;
        }


        /// <summary>
        ///  회원 가입 인증 메서드
        /// </summary>
        /// <returns></returns>
        private bool Authentication()
        {
            string ErrorMessage = "";

            // 아이디 체크
            if (txt_id.Text == "")
                ErrorMessage += "- 아이디를 입력하세요.!\n\n";
            else if (txt_id.Text.Length < 5 || txt_id.Text.Length > 16)
                ErrorMessage += "- 아이디는 5자 이상 16자 이하 입니다.\n\n";
            else if (!A_or_D(txt_id.Text))    // 영문과 숫자 체크함수 
                ErrorMessage += "- 아이디는 영문이나 숫자로 입력하셔야 합니다.\n\n";

            // 아이디 중복 검사 유무
            if (!ID_OK)
                ErrorMessage += " *** 아이디 중복 검사를 하세요 ! *** \n\n";

            // 암호 체크
            if (txt_pwd.Text.Length < 5 || txt_id.Text.Length > 16)
                ErrorMessage += "- 암호는 5자 이상 16자 이하 입니다.\n\n";
            else if (!A_or_D(txt_pwd.Text))
                ErrorMessage += "- 암호는 숫자 또는 문자를 입력해야 합니다.!\n\n";
            else if (!txt_pwd.Text.Equals(txt_pwd_ok.Text))
                ErrorMessage += "- 암호가 일치하지 않습니다.\n\n";


            // E - mail 주소 체크
            if (txt_email.Text == "")
                ErrorMessage += "- E-메일 주소를 입력하세요.!\n\n";
            else if (!Email_Check(txt_email.Text))
                ErrorMessage += "- E-메일 주소를 정확히 입력하세요.!\n\n";

            if (ErrorMessage != "")
            {
                MessageBox.Show(ErrorMessage, "등록 에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


    }
}