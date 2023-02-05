using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;

namespace MemberServer
{
	/// <summary>
	/// EditMember에 대한 요약 설명입니다.
	/// </summary>
	public class EditMember : System.Windows.Forms.Form
	{
		private DataSet ds = null;
        private int index = 0;

		private System.Windows.Forms.TextBox txt_NickName;
		private System.Windows.Forms.Button btn_Close;
		private System.Windows.Forms.Label lbl_NickName;
		private System.Windows.Forms.Label lbl_Example;
		private System.Windows.Forms.Button btn_Edit;
		private System.Windows.Forms.Label lbl_Intro;
		private System.Windows.Forms.Label lbl_Addr;
		private System.Windows.Forms.TextBox txt_Intro;
		private System.Windows.Forms.TextBox txt_Email;
		private System.Windows.Forms.TextBox txt_Tel;
		private System.Windows.Forms.TextBox txt_Pwd;
		private System.Windows.Forms.Label lbl_Email;
		private System.Windows.Forms.TextBox txt_ID;
		private System.Windows.Forms.Label lbl_Tel;
		private System.Windows.Forms.Label lbl_Pwd;
		private System.Windows.Forms.Label lbl_ID;
		private System.Windows.Forms.TextBox txt_Name;
		private System.Windows.Forms.Label lbl_Name;
		private System.Windows.Forms.TextBox txt_Addr;
		private System.Windows.Forms.TextBox txt_Zip2;
		private System.Windows.Forms.TextBox txt_Zip1;
		private System.Windows.Forms.Button btn_Zip;
		private System.Windows.Forms.Label lbl_Dash2;
		private System.Windows.Forms.Label lbl_Zip;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditMember(DataSet ds, int index)
		{
			InitializeComponent();

			this.ds = ds;
			this.index = index;

			InitDialog();
		}

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.txt_NickName = new System.Windows.Forms.TextBox();
			this.btn_Close = new System.Windows.Forms.Button();
			this.lbl_NickName = new System.Windows.Forms.Label();
			this.lbl_Example = new System.Windows.Forms.Label();
			this.btn_Edit = new System.Windows.Forms.Button();
			this.lbl_Intro = new System.Windows.Forms.Label();
			this.lbl_Addr = new System.Windows.Forms.Label();
			this.txt_Addr = new System.Windows.Forms.TextBox();
			this.txt_Intro = new System.Windows.Forms.TextBox();
			this.txt_Email = new System.Windows.Forms.TextBox();
			this.txt_Tel = new System.Windows.Forms.TextBox();
			this.txt_Pwd = new System.Windows.Forms.TextBox();
			this.lbl_Email = new System.Windows.Forms.Label();
			this.txt_ID = new System.Windows.Forms.TextBox();
			this.lbl_Tel = new System.Windows.Forms.Label();
			this.lbl_Pwd = new System.Windows.Forms.Label();
			this.lbl_ID = new System.Windows.Forms.Label();
			this.txt_Name = new System.Windows.Forms.TextBox();
			this.lbl_Name = new System.Windows.Forms.Label();
			this.txt_Zip2 = new System.Windows.Forms.TextBox();
			this.txt_Zip1 = new System.Windows.Forms.TextBox();
			this.btn_Zip = new System.Windows.Forms.Button();
			this.lbl_Dash2 = new System.Windows.Forms.Label();
			this.lbl_Zip = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txt_NickName
			// 
			this.txt_NickName.Location = new System.Drawing.Point(112, 88);
			this.txt_NickName.Name = "txt_NickName";
			this.txt_NickName.Size = new System.Drawing.Size(152, 21);
			this.txt_NickName.TabIndex = 2;
			this.txt_NickName.Text = "";
			// 
			// btn_Close
			// 
			this.btn_Close.Location = new System.Drawing.Point(240, 328);
			this.btn_Close.Name = "btn_Close";
			this.btn_Close.Size = new System.Drawing.Size(200, 23);
			this.btn_Close.TabIndex = 9;
			this.btn_Close.Text = "창 닫기";
			this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
			// 
			// lbl_NickName
			// 
			this.lbl_NickName.Location = new System.Drawing.Point(24, 88);
			this.lbl_NickName.Name = "lbl_NickName";
			this.lbl_NickName.Size = new System.Drawing.Size(32, 16);
			this.lbl_NickName.TabIndex = 106;
			this.lbl_NickName.Text = "별칭";
			// 
			// lbl_Example
			// 
			this.lbl_Example.Location = new System.Drawing.Point(272, 128);
			this.lbl_Example.Name = "lbl_Example";
			this.lbl_Example.Size = new System.Drawing.Size(160, 16);
			this.lbl_Example.TabIndex = 104;
			this.lbl_Example.Text = "예) 02-123-1234";
			// 
			// btn_Edit
			// 
			this.btn_Edit.Location = new System.Drawing.Point(16, 328);
			this.btn_Edit.Name = "btn_Edit";
			this.btn_Edit.Size = new System.Drawing.Size(200, 24);
			this.btn_Edit.TabIndex = 8;
			this.btn_Edit.Text = "회원 정보 변경";
			this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
			// 
			// lbl_Intro
			// 
			this.lbl_Intro.Location = new System.Drawing.Point(24, 248);
			this.lbl_Intro.Name = "lbl_Intro";
			this.lbl_Intro.Size = new System.Drawing.Size(80, 16);
			this.lbl_Intro.TabIndex = 103;
			this.lbl_Intro.Text = "자기소개";
			// 
			// lbl_Addr
			// 
			this.lbl_Addr.Location = new System.Drawing.Point(24, 211);
			this.lbl_Addr.Name = "lbl_Addr";
			this.lbl_Addr.Size = new System.Drawing.Size(80, 16);
			this.lbl_Addr.TabIndex = 102;
			this.lbl_Addr.Text = "주소";
			// 
			// txt_Addr
			// 
			this.txt_Addr.Location = new System.Drawing.Point(112, 208);
			this.txt_Addr.Name = "txt_Addr";
			this.txt_Addr.Size = new System.Drawing.Size(328, 21);
			this.txt_Addr.TabIndex = 6;
			this.txt_Addr.Text = "";
			// 
			// txt_Intro
			// 
			this.txt_Intro.ImeMode = System.Windows.Forms.ImeMode.Hangul;
			this.txt_Intro.Location = new System.Drawing.Point(112, 248);
			this.txt_Intro.Multiline = true;
			this.txt_Intro.Name = "txt_Intro";
			this.txt_Intro.Size = new System.Drawing.Size(328, 64);
			this.txt_Intro.TabIndex = 7;
			this.txt_Intro.Text = "";
			// 
			// txt_Email
			// 
			this.txt_Email.ImeMode = System.Windows.Forms.ImeMode.Alpha;
			this.txt_Email.Location = new System.Drawing.Point(112, 152);
			this.txt_Email.Name = "txt_Email";
			this.txt_Email.Size = new System.Drawing.Size(328, 21);
			this.txt_Email.TabIndex = 4;
			this.txt_Email.Text = "";
			// 
			// txt_Tel
			// 
			this.txt_Tel.Location = new System.Drawing.Point(112, 120);
			this.txt_Tel.Name = "txt_Tel";
			this.txt_Tel.Size = new System.Drawing.Size(152, 21);
			this.txt_Tel.TabIndex = 3;
			this.txt_Tel.Text = "";
			// 
			// txt_Pwd
			// 
			this.txt_Pwd.Location = new System.Drawing.Point(112, 56);
			this.txt_Pwd.Name = "txt_Pwd";
			this.txt_Pwd.PasswordChar = '*';
			this.txt_Pwd.Size = new System.Drawing.Size(104, 21);
			this.txt_Pwd.TabIndex = 0;
			this.txt_Pwd.Text = "";
			// 
			// lbl_Email
			// 
			this.lbl_Email.Location = new System.Drawing.Point(24, 152);
			this.lbl_Email.Name = "lbl_Email";
			this.lbl_Email.Size = new System.Drawing.Size(80, 16);
			this.lbl_Email.TabIndex = 88;
			this.lbl_Email.Text = "E-메일주소";
			// 
			// txt_ID
			// 
			this.txt_ID.Location = new System.Drawing.Point(112, 16);
			this.txt_ID.Name = "txt_ID";
			this.txt_ID.ReadOnly = true;
			this.txt_ID.Size = new System.Drawing.Size(120, 21);
			this.txt_ID.TabIndex = 76;
			this.txt_ID.Text = "";
			// 
			// lbl_Tel
			// 
			this.lbl_Tel.Location = new System.Drawing.Point(24, 120);
			this.lbl_Tel.Name = "lbl_Tel";
			this.lbl_Tel.Size = new System.Drawing.Size(80, 16);
			this.lbl_Tel.TabIndex = 85;
			this.lbl_Tel.Text = "전화번호";
			// 
			// lbl_Pwd
			// 
			this.lbl_Pwd.Location = new System.Drawing.Point(24, 64);
			this.lbl_Pwd.Name = "lbl_Pwd";
			this.lbl_Pwd.Size = new System.Drawing.Size(80, 16);
			this.lbl_Pwd.TabIndex = 77;
			this.lbl_Pwd.Text = "비밀번호";
			// 
			// lbl_ID
			// 
			this.lbl_ID.Location = new System.Drawing.Point(24, 21);
			this.lbl_ID.Name = "lbl_ID";
			this.lbl_ID.Size = new System.Drawing.Size(80, 16);
			this.lbl_ID.TabIndex = 75;
			this.lbl_ID.Text = "아이디";
			// 
			// txt_Name
			// 
			this.txt_Name.ImeMode = System.Windows.Forms.ImeMode.Hangul;
			this.txt_Name.Location = new System.Drawing.Point(312, 16);
			this.txt_Name.Name = "txt_Name";
			this.txt_Name.ReadOnly = true;
			this.txt_Name.Size = new System.Drawing.Size(120, 21);
			this.txt_Name.TabIndex = 83;
			this.txt_Name.Text = "";
			// 
			// lbl_Name
			// 
			this.lbl_Name.Location = new System.Drawing.Point(272, 20);
			this.lbl_Name.Name = "lbl_Name";
			this.lbl_Name.Size = new System.Drawing.Size(32, 16);
			this.lbl_Name.TabIndex = 82;
			this.lbl_Name.Text = "이름";
			// 
			// txt_Zip2
			// 
			this.txt_Zip2.Location = new System.Drawing.Point(200, 180);
			this.txt_Zip2.Name = "txt_Zip2";
			this.txt_Zip2.ReadOnly = true;
			this.txt_Zip2.Size = new System.Drawing.Size(56, 21);
			this.txt_Zip2.TabIndex = 112;
			this.txt_Zip2.Text = "";
			// 
			// txt_Zip1
			// 
			this.txt_Zip1.Location = new System.Drawing.Point(112, 180);
			this.txt_Zip1.Name = "txt_Zip1";
			this.txt_Zip1.ReadOnly = true;
			this.txt_Zip1.Size = new System.Drawing.Size(56, 21);
			this.txt_Zip1.TabIndex = 110;
			this.txt_Zip1.Text = "";
			// 
			// btn_Zip
			// 
			this.btn_Zip.Location = new System.Drawing.Point(288, 180);
			this.btn_Zip.Name = "btn_Zip";
			this.btn_Zip.Size = new System.Drawing.Size(96, 23);
			this.btn_Zip.TabIndex = 5;
			this.btn_Zip.Text = "우편번호 찾기";
			this.btn_Zip.Click += new System.EventHandler(this.btn_Zip_Click);
			// 
			// lbl_Dash2
			// 
			this.lbl_Dash2.Location = new System.Drawing.Point(176, 188);
			this.lbl_Dash2.Name = "lbl_Dash2";
			this.lbl_Dash2.Size = new System.Drawing.Size(8, 16);
			this.lbl_Dash2.TabIndex = 113;
			this.lbl_Dash2.Text = "-";
			// 
			// lbl_Zip
			// 
			this.lbl_Zip.Location = new System.Drawing.Point(24, 188);
			this.lbl_Zip.Name = "lbl_Zip";
			this.lbl_Zip.Size = new System.Drawing.Size(80, 16);
			this.lbl_Zip.TabIndex = 111;
			this.lbl_Zip.Text = "우편번호";
			// 
			// EditMember
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(456, 365);
			this.Controls.Add(this.txt_Zip2);
			this.Controls.Add(this.txt_Zip1);
			this.Controls.Add(this.txt_NickName);
			this.Controls.Add(this.txt_Addr);
			this.Controls.Add(this.txt_Intro);
			this.Controls.Add(this.txt_Email);
			this.Controls.Add(this.txt_Tel);
			this.Controls.Add(this.txt_Name);
			this.Controls.Add(this.txt_Pwd);
			this.Controls.Add(this.txt_ID);
			this.Controls.Add(this.btn_Zip);
			this.Controls.Add(this.lbl_Dash2);
			this.Controls.Add(this.lbl_Zip);
			this.Controls.Add(this.btn_Close);
			this.Controls.Add(this.lbl_NickName);
			this.Controls.Add(this.lbl_Example);
			this.Controls.Add(this.btn_Edit);
			this.Controls.Add(this.lbl_Intro);
			this.Controls.Add(this.lbl_Addr);
			this.Controls.Add(this.lbl_Email);
			this.Controls.Add(this.lbl_Tel);
			this.Controls.Add(this.lbl_Name);
			this.Controls.Add(this.lbl_Pwd);
			this.Controls.Add(this.lbl_ID);
			this.Name = "EditMember";
			this.Text = "회원 정보 수정";
			this.ResumeLayout(false);

		}
		#endregion


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
			foreach(char ch in lower_str) 
			{				
				if(((ch < 'a') || (ch > 'z')) && ((ch < '0') ||(ch > '9')))
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
			if(Digit_Check( str )) return false ;  // 숫자 입력 확인
			// 분석할 문자열을 소문자로 만듬
			string lower_str = str.ToLower();
			// 전화번호는 - 와 0~9 사이 값이 같이 입력되어야 함.
			foreach(char ch in lower_str) 
			{				
				if( ( ch !='-' ) && ((ch < '0') || (ch > '9')))
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
			foreach(char ch in lower_str) 
			{
				if((ch < '0') || (ch > '9'))
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
			byte stock = 0 ;
			// 전자 우편 주소는 @ 와 . 이 포함되어 있어야함.
			foreach(char ch in str) 
			{				
				if( ch == '@' || ch == '.' ) stock++ ;
			}
			if( stock >= 2 ) return true ;
			return false ;
		}
		
		/// <summary>
		/// 회원 가입 인증 메서드
		/// </summary>
		/// <returns></returns> 
		private bool  Authentication() 
		{
			// 에러 문자열 저장
			string ErrorMessage = "" ;     	    
			// 암호 체크
			if( txt_Pwd.Text.Length < 5 || txt_ID.Text.Length >16 )
				ErrorMessage += "- 암호는 5자 이상 16자 이하 입니다.\n\n" ;
			else if( !A_or_D(txt_Pwd.Text.Trim()))
				ErrorMessage += "- 암호는 숫자 또는 문자를 입력해야 합니다.!\n\n" ;
			
			// 별칭 체크
			if( txt_NickName.Text.Trim() == "")
				ErrorMessage += "- 별칭을 입력해주세요!\n\n" ;
			else if( txt_NickName.Text.Length > 100)
				ErrorMessage += "- 별칭은 100글자안에서 입력해주세요.\n\n" ;

			// 전화 번호 체크
			if(txt_Tel.Text.Trim() == "")
				ErrorMessage += "- 전화 번호를 입력하세요.!\n\n";
			else if(Tel_Check(txt_Tel.Text.Trim()))
				ErrorMessage += "- 전화번호에는 숫자와 '-'만 사용할 수 있습니다.\n\n";

			// E - mail 주소 체크
			if(txt_Email.Text.Trim() == "")
				ErrorMessage += "- E-메일 주소를 입력하세요.!\n\n";
			else if(!Email_Check(txt_Email.Text.Trim()))
				ErrorMessage += "- E-메일 주소를 정확히 입력하세요.!\n\n";  

			// 우편 번호 체크
			if(txt_Zip1.Text.Trim()+txt_Zip2.Text.Trim()  == "")
				ErrorMessage += "- 우편번호를 입력하세요.\n\n";
			else if(Digit_Check(txt_Zip1.Text.Trim()+txt_Zip2.Text.Trim()))
				ErrorMessage += "- 우편번호에는 숫자만 입력할 수 있습니다.\n\n"  ;
			
			// 주소 입력 체크
			if(txt_Addr.Text.Trim() == "") 
				ErrorMessage += "- 주소를 입력하세요.\n\n";
			
			// 에러 문자열 체크
			if( ErrorMessage != "") 
			{
				MessageBox.Show(ErrorMessage, "등록 에러", MessageBoxButtons.OK, MessageBoxIcon.Error   );
				return false ;
			}
			
			return true ;
		}


		private void InitDialog()
		{
			try
			{			
				DataRow dr = ds.Tables["Member"].Rows[this.index];   // 데이터셋에서 행값 가져오기

				txt_ID.Text = dr["id"].ToString();
				txt_Pwd.Text = dr["pwd"].ToString();
				txt_Name.Text = dr["name"].ToString();
				txt_NickName.Text = dr["nickname"].ToString();			
				txt_Tel.Text = dr["tel"].ToString();
				txt_Email.Text = dr["email"].ToString();
			
				string [] token = dr["zipcode"].ToString().Split('-');
				txt_Zip1.Text = token[0];
				txt_Zip2.Text = token[1];
			
				txt_Addr.Text = dr["address"].ToString();
				txt_Intro.Text = dr["intro"].ToString();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btn_Zip_Click(object sender, System.EventArgs e)
		{
			ZipcodeWnd dlg = new ZipcodeWnd();
			dlg.ShowDialog();		
             
			string addr = dlg.Addr ;

			dlg.Close();
			
			if( addr != null )
			{             
				string [] token = addr.Split('#');

				string [] zip = token[0].Split('-');
			 
				txt_Zip1.Text = zip[0];
				txt_Zip2.Text = zip[1];
				txt_Addr.Text = token[1];		 

				txt_Addr.Focus();
			}
		}

		private void btn_Edit_Click(object sender, System.EventArgs e)
		{
			try
			{			
				// 회원 가입 인증 메서드 호출
				if(! Authentication()) return ; // 인증 실패시 반환	

				DataRow row = ds.Tables["Member"].Rows[this.index];
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
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btn_Close_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
