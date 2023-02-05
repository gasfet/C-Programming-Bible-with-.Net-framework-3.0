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
        #region 멤버 변수

        // 메신저 클라이언트 메인화면  
        public MainWnd wnd = null;

        // 우편번호 검색창
        public ZipcodeWnd zipcodewnd = null;

        // 아이디 중복 검사를 했는지 알려주는 플래그
        public bool id_ok = false;

        // 서버 아이피 주소
        private string ip = null;

        // 메신저 서버와 회원 가입 통신 		
        private RegNetwork net = null;

        #endregion

        #region 생성자
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="wnd"></param>
        /// <param name="ip"></param>
        public RegForm(MainWnd wnd, string ip)
        {
            InitializeComponent();

            this.wnd = wnd;
            this.ip = ip;  // 접속할 서버 아이피
            this.net = new RegNetwork(this);

        }
        #endregion

        /// <summary>
        /// 아이디가 중복되었을때 처리할 메서드
        /// </summary>
        public void IDCheckOK()
        {
            // 아이디가 중복되면 초기화
            txt_ID.Text = "";
            txt_ID.Focus();
        }

        /// <summary>
        ///  아이디 중복 검사 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>		
        private void btn_ID_Click(object sender, EventArgs e)
        {
            // 아이디값 가져오기
            string txt = txt_ID.Text.Trim();
            if (txt == "")
            {
                MessageBox.Show(" 아이디를 입력하세요 ");
                txt_ID.Focus();
                return;
            }

            // 아이디 중복 검사요구 메시지 작성
            string message = (byte)MSG.CTOS_MESSAGE_REGISTER_IDSEARCH + "\a" + txt;
            // 메신저 서버에 문자열 전송
            this.net.Connect(this.ip);
            this.net.Send(message);	
        }

        /// <summary>
        /// 우편 번호 찾기 버튼 클릭 이벤트
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
        /// 회원 가입 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Reg_Click(object sender, EventArgs e)
        {
            // 회원 가입 인증 메서드 호출
            if (!Authentication()) return; // 인증 실패시 반환			

            // 회원 정보 저장 문자열 초기화
            string msg = null;

            msg += (byte)MSG.CTOS_MESSAGE_REGISTER_REQUEST + "\a";         // 회원 가입 요청 메시지
            msg += txt_ID.Text.Trim() + "#";                  // 아이디
            msg += txt_Pwd.Text.Trim() + "#";                 // 암호
            msg += txt_Name.Text.Trim() + "#";                // 이름
            msg += txt_NickName.Text.Trim() + "#"; // 별칭
            msg += txt_Ssn1.Text.Trim() + "-" + txt_Ssn2.Text.Trim() + "#";   // 주민 번호
            msg += txt_Tel.Text.Trim() + "#";                // 전화번호
            msg += txt_Email.Text.Trim() + "#";              // 이메일 주소 
            msg += txt_Zip1.Text.Trim() + "-" + txt_Zip2.Text.Trim() + "#";   // 우편번호
            msg += txt_Addr1.Text.Trim() + " " + txt_Addr2.Text.Trim() + "#"; // 주소
            msg += txt_Intro.Text.Trim();                    // 자기소개

            // 메신저 서버에 문자열 전송
            this.net.Connect(this.ip);
            this.net.Send(msg);			
        }

        /// <summary>
        /// 다시 쓰기 버튼 클릭 이벤트 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>	
        private void btn_Re_Click(object sender, EventArgs e)
        {
            // 화면에 붙어 있는  컨트롤의 개수 만큼 호출
            for (int i = 0; i < Controls.Count; i++)
                if (Controls[i] is TextBox)  // TextBox 컨트롤이면
                    ((TextBox)Controls[i]).Text = ""; // 문자열 초기화
        }

        /// <summary>
        /// 창이 닫히면 네트워크 연결 끊기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.net.DisConnect();
        }


        ///////////////////////////////////////// 
        /// 회원 가입 인증 메서드
        ////////////////////////////////////////   

        /// <summary>
        ///  숫자와 영문 입력 체크 메서드
        /// </summary>
        /// <param name="str">체크할 문자열</param>
        /// <returns></returns>
        private bool A_or_D(string str)
        {
            // 소문자로 만들기
            string lower_str = str.ToLower();
            // a~z , 0< ? < 9 안에 포함되었는지 검사
            foreach (char ch in lower_str)
            {
                if (((ch < 'a') || (ch > 'z')) && ((ch < '0') || (ch > '9')))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 전화 번호 입력 체크 메서드
        /// </summary>
        /// <param name="str">체크할 전화번호</param>
        /// <returns></returns>
        private bool Tel_Check(string str)
        {
            // 분석할 문자열을 소문자로 만듬
            string lower_str = str.ToLower();
            // 전화번호는 - 와 0~9 사이 값이 같이 입력되어야 함.
            foreach (char ch in lower_str)
            {
                if ((ch != '-') && ((ch < '0') || (ch > '9')))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 숫자 입력 확인
        /// </summary>
        /// <param name="str">분석할 문자열</param>
        /// <returns></returns>
        private bool Digit_Check(string str)
        {
            // 소문자로 변환
            string lower_str = str.ToLower();
            // 0~9 숫자 인지 확인
            foreach (char ch in lower_str)
            {
                if ((ch < '0') || (ch > '9'))
                    return true;
            }
            return false;
        }

        /// <summary>
        ///  E 메일 주소 유효성 검사 메서드
        /// </summary>
        /// <param name="str">검사할 문자열</param>
        /// <returns></returns>
        private bool Email_Check(string str)
        {
            byte stock = 0;
            // 전자 우편 주소는 @ 와 . 이 포함되어 있어야함.
            foreach (char ch in str)
            {
                if (ch == '@' || ch == '.') stock++;
            }
            if (stock >= 2) return true;
            return false;
        }

        /// <summary>
        /// 주민번호 유효성 검사 메서드
        /// </summary>
        /// <param name="str">검사할 주민번호</param>
        /// <returns></returns>
        private bool Check_Digit(string str)
        {

            if (Digit_Check(str)) return false; // 숫자만 입력했는지 체크
            if (str.Length != 13) return false; // 주민 번호는 13자리 수
            int sum = 0;   // 유효성 계산
            int temp = 0;
            // 주민 번호를 배열에 저장
            int[] num = new int[13];
            // 가중치 값 저장
            int[] digit = { 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5 };

            // 입력된 문자를 숫자로!
            for (int i = 0; i < 13; i++)
            {
                num[i] = Int32.Parse(str[i] + "");
            }

            // 주민 번호 유효성 검사
            for (int i = 0; i < 12; i++)
            {
                sum += digit[i] * num[i];
            }
            // 유효성 검증
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
        /// 회원 가입 인증 메서드
        /// </summary>
        /// <returns></returns> 
        private bool Authentication()
        {
            // 에러 문자열 저장
            string ErrorMessage = "";
            // 아이디 체크
            if (txt_ID.Text.Trim() == "")
                ErrorMessage += "- 아이디를 입력하세요.!\n\n";
            else if (txt_ID.Text.Length < 5 || txt_ID.Text.Length > 16)
                ErrorMessage += "- 아이디는 5자 이상 16자 이하 입니다.\n\n";
            else if (!A_or_D(txt_ID.Text.Trim()))    // 영문과 숫자 체크함수 			
                ErrorMessage += "- 아이디는 영문이나 숫자로 입력하셔야 합니다.\n\n";

            // 아이디 중복 검사 유무
            if (!id_ok)
                ErrorMessage += " *** 아이디 중복 검사를 하세요 ! *** \n\n";

            // 암호 체크
            if (txt_Pwd.Text.Length < 5 || txt_ID.Text.Length > 16)
                ErrorMessage += "- 암호는 5자 이상 16자 이하 입니다.\n\n";
            else if (!A_or_D(txt_Pwd.Text.Trim()))
                ErrorMessage += "- 암호는 숫자 또는 문자를 입력해야 합니다.!\n\n";
            else if (!txt_Pwd.Text.Equals(txt_Pwd_Ok.Text.Trim()))
                ErrorMessage += "- 암호가 일치하지 않습니다.\n\n";

            // 이름 체크
            if (txt_Name.Text.Trim() == "")
                ErrorMessage += "- 이름을 입력하세요!\n\n";

            // 별칭 체크
            if (txt_NickName.Text.Trim() == "")
                ErrorMessage += "- 별칭을 입력해주세요!\n\n";
            else if (txt_NickName.Text.Length > 100)
                ErrorMessage += "- 별칭은 100글자안에서 입력해주세요.\n\n";


            // 주민 번호 체크
            if (!Check_Digit(txt_Ssn1.Text.Trim() + txt_Ssn2.Text.Trim()))
                ErrorMessage += "- 주민등록번호를 정확히 입력하세요.\n\n";

            // 전화 번호 체크
            if (txt_Tel.Text.Trim() == "")
                ErrorMessage += "- 전화 번호를 입력하세요.!\n\n";
            else if (Tel_Check(txt_Tel.Text.Trim()))
                ErrorMessage += "- 전화번호에는 숫자와 '-'만 사용할 수 있습니다.\n\n";

            // E - mail 주소 체크
            if (txt_Email.Text.Trim() == "")
                ErrorMessage += "- E-메일 주소를 입력하세요.!\n\n";
            else if (!Email_Check(txt_Email.Text.Trim()))
                ErrorMessage += "- E-메일 주소를 정확히 입력하세요.!\n\n";

            // 우편 번호 체크
            if (txt_Zip1.Text.Trim() + txt_Zip2.Text.Trim() == "")
                ErrorMessage += "- 우편번호를 입력하세요.\n\n";
            else if (Digit_Check(txt_Zip1.Text.Trim() + txt_Zip2.Text.Trim()))
                ErrorMessage += "- 우편번호에는 숫자만 입력할 수 있습니다.\n\n";

            // 주소 입력 체크
            if (txt_Addr1.Text.Trim() == "" && txt_Addr2.Text.Trim() == "")
                ErrorMessage += "- 주소를 입력하세요.\n\n";

            // 에러 문자열 체크
            if (ErrorMessage != "")
            {
                MessageBox.Show(ErrorMessage, "등록 에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

    }
}