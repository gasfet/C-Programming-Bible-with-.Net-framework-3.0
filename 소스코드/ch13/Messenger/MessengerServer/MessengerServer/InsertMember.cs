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
        #region 멤버 변수

        private DataSet ds = null;
        private bool id_ok = false;
        private string dsn = null;

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
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

        #region 멤버 메서드

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
            if (Digit_Check(str)) return false;  // 숫자 입력 확인
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

        /// <summary>
        /// 화면에 있는 컨트롤 문자열 초기화
        /// </summary>
        private void InitControl()
        {
            // 화면에 붙어 있는  컨트롤의 개수 만큼 호출
            for (int i = 0; i < Controls.Count; i++)
                if (Controls[i] is TextBox)  // TextBox 컨트롤이면
                    ((TextBox)Controls[i]).Text = ""; // 문자열 초기화
        }

        #endregion

        #region 이벤트
        /// <summary>
        /// 아이디 중복 검사 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ID_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_ID.Text.Length == 0)
                {
                    MessageBox.Show("아이디를 입력하세요!");
                    return;
                }

                string filter = "user_id = '" + txt_ID.Text.Trim() + "'";

                DataRow[] row = ds.Tables["TBL_Member"].Select(filter);

                if (row.Length > 0)
                    this.id_ok = false;
                else
                    this.id_ok = true;

                string str = id_ok ? "아이디 사용가능!" : "이미 가입된 아이디!";

                MessageBox.Show(str, "아이디 중복 검사 결과");
            }
            catch 
            {
                MessageBox.Show("데이터셋 오류 발생", "오류!");
            }
        }

        /// <summary>
        /// 우편번호 찾기 클릭 이벤트
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
        /// 회원 추가 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Reg_Click(object sender, EventArgs e)
        {
            try
            {
                // 회원 가입 인증 메서드 호출
                if (!Authentication()) return; // 인증 실패시 반환			
                // 회원 정보 기록			
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

                MessageBox.Show("회원 추가 성공!", "결과 확인");

                this.InitControl(); // 화면에 있는 데이터 지움

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 다시쓰기 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Re_Click(object sender, EventArgs e)
        {
            this.InitControl();
        }

        /// <summary>
        /// 창 닫기 클릭 이벤트
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