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
        #region 멤버 변수

        private DataSet ds = null;    // 메모리 데이터베이스 
        private int index = 0;        // 메모리 데이터베이스에서 회원 정보를 수정할 인덱스   
        private string dsn = null;    // SQL 서버 dsn 문

        #endregion

        #region 생성자
        /// <summary>
        /// 회원 정보 수정 윈도우 생성자
        /// </summary>
        /// <param name="ds">메모리 데이터베이스</param>
        /// <param name="index">편집할 데이터 인덱스</param>
        /// <param name="dsn">SQL 서버 dsn문</param>
        public EditMember(DataSet ds, int index, string dsn)
        {
            InitializeComponent();

            this.ds = ds;
            this.index = index;
            this.dsn = dsn;

            InitDialog();
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
        /// 회원 가입 인증 메서드
        /// </summary>
        /// <returns></returns> 
        private bool Authentication()
        {
            // 에러 문자열 저장
            string ErrorMessage = "";
            // 암호 체크
            if (txt_Pwd.Text.Length < 5 || txt_ID.Text.Length > 16)
                ErrorMessage += "- 암호는 5자 이상 16자 이하 입니다.\n\n";
            else if (!A_or_D(txt_Pwd.Text.Trim()))
                ErrorMessage += "- 암호는 숫자 또는 문자를 입력해야 합니다.!\n\n";

            // 별칭 체크
            if (txt_NickName.Text.Trim() == "")
                ErrorMessage += "- 별칭을 입력해주세요!\n\n";
            else if (txt_NickName.Text.Length > 100)
                ErrorMessage += "- 별칭은 100글자안에서 입력해주세요.\n\n";

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
            if (txt_Addr.Text.Trim() == "")
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
        /// 대화상자 초기화
        /// </summary>
        private void InitDialog()
        {
            try
            {
                // 데이터셋에서 행값 가져오기
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

        #region 이벤트

        /// <summary>
        /// 우편번호 찾기
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
        /// 회원 정보 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                // 회원 가입 인증 메서드 호출
                if (!Authentication()) return; // 인증 실패시 반환	

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

                MessageBox.Show("회원 정보 갱신 성공!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 창닫기
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