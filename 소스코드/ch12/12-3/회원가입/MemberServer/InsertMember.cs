using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;

namespace MemberServer
{
	/// <summary>
	/// InsertMember에 대한 요약 설명입니다.
	/// </summary>
	public class InsertMember : System.Windows.Forms.Form
	{

        private DataSet ds = null;
        private bool id_ok = false;
		private System.Windows.Forms.Label lbl_jumin;
		private System.Windows.Forms.Label lbl_NickName;
		private System.Windows.Forms.TextBox txt_Name;
		private System.Windows.Forms.TextBox txt_Pwd_Ok;
		private System.Windows.Forms.TextBox txt_Pwd;
		private System.Windows.Forms.TextBox txt_ID;
		private System.Windows.Forms.Label lbl_Name;
		private System.Windows.Forms.Label lbl_Pwd_Ok;
		private System.Windows.Forms.Label lbl_Pwd;
		private System.Windows.Forms.Label lbl_ID;
		private System.Windows.Forms.Label lbl_Addr2;
		private System.Windows.Forms.Label lbl_Example;
		private System.Windows.Forms.Button btn_Re;
		private System.Windows.Forms.Button btn_Reg;
		private System.Windows.Forms.Label lbl_Intro;
		private System.Windows.Forms.TextBox txt_Addr2;
		private System.Windows.Forms.Label lbl_Addr;
		private System.Windows.Forms.TextBox txt_Addr1;
		private System.Windows.Forms.Button btn_Zip;
		private System.Windows.Forms.TextBox txt_Zip2;
		private System.Windows.Forms.Label lbl_Dash2;
		private System.Windows.Forms.TextBox txt_Zip1;
		private System.Windows.Forms.Label lbl_Zip;
		private System.Windows.Forms.TextBox txt_Intro;
		private System.Windows.Forms.TextBox txt_Email;
		private System.Windows.Forms.TextBox txt_Tel;
		private System.Windows.Forms.TextBox txt_Ssn2;
		private System.Windows.Forms.TextBox txt_Ssn1;
		private System.Windows.Forms.Label lbl_Dash1;
		private System.Windows.Forms.Label lbl_Email;
		private System.Windows.Forms.Label lbl_Tel;
		private System.Windows.Forms.Button btn_Close;
		private System.Windows.Forms.TextBox txt_NickName;
		private System.Windows.Forms.Button btn_ID;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public InsertMember(DataSet ds)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			this.ds = ds;
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
			this.lbl_NickName = new System.Windows.Forms.Label();
			this.lbl_Addr2 = new System.Windows.Forms.Label();
			this.lbl_Example = new System.Windows.Forms.Label();
			this.btn_Re = new System.Windows.Forms.Button();
			this.btn_Reg = new System.Windows.Forms.Button();
			this.lbl_Intro = new System.Windows.Forms.Label();
			this.txt_Addr2 = new System.Windows.Forms.TextBox();
			this.lbl_Addr = new System.Windows.Forms.Label();
			this.txt_Addr1 = new System.Windows.Forms.TextBox();
			this.btn_Zip = new System.Windows.Forms.Button();
			this.txt_Zip2 = new System.Windows.Forms.TextBox();
			this.lbl_Dash2 = new System.Windows.Forms.Label();
			this.txt_Zip1 = new System.Windows.Forms.TextBox();
			this.lbl_Zip = new System.Windows.Forms.Label();
			this.txt_Intro = new System.Windows.Forms.TextBox();
			this.txt_Email = new System.Windows.Forms.TextBox();
			this.txt_Tel = new System.Windows.Forms.TextBox();
			this.txt_Ssn2 = new System.Windows.Forms.TextBox();
			this.txt_Ssn1 = new System.Windows.Forms.TextBox();
			this.txt_Name = new System.Windows.Forms.TextBox();
			this.txt_Pwd_Ok = new System.Windows.Forms.TextBox();
			this.txt_Pwd = new System.Windows.Forms.TextBox();
			this.btn_ID = new System.Windows.Forms.Button();
			this.lbl_Dash1 = new System.Windows.Forms.Label();
			this.lbl_Email = new System.Windows.Forms.Label();
			this.txt_ID = new System.Windows.Forms.TextBox();
			this.lbl_Tel = new System.Windows.Forms.Label();
			this.lbl_jumin = new System.Windows.Forms.Label();
			this.lbl_Name = new System.Windows.Forms.Label();
			this.lbl_Pwd_Ok = new System.Windows.Forms.Label();
			this.lbl_Pwd = new System.Windows.Forms.Label();
			this.lbl_ID = new System.Windows.Forms.Label();
			this.btn_Close = new System.Windows.Forms.Button();
			this.txt_NickName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lbl_NickName
			// 
			this.lbl_NickName.Location = new System.Drawing.Point(224, 81);
			this.lbl_NickName.Name = "lbl_NickName";
			this.lbl_NickName.Size = new System.Drawing.Size(32, 16);
			this.lbl_NickName.TabIndex = 72;
			this.lbl_NickName.Text = "별칭";
			// 
			// lbl_Addr2
			// 
			this.lbl_Addr2.Location = new System.Drawing.Point(16, 264);
			this.lbl_Addr2.Name = "lbl_Addr2";
			this.lbl_Addr2.Size = new System.Drawing.Size(80, 16);
			this.lbl_Addr2.TabIndex = 71;
			this.lbl_Addr2.Text = "상세주소";
			// 
			// lbl_Example
			// 
			this.lbl_Example.Location = new System.Drawing.Point(264, 160);
			this.lbl_Example.Name = "lbl_Example";
			this.lbl_Example.Size = new System.Drawing.Size(160, 16);
			this.lbl_Example.TabIndex = 70;
			this.lbl_Example.Text = "예) 02-123-1234";
			// 
			// btn_Re
			// 
			this.btn_Re.Location = new System.Drawing.Point(154, 368);
			this.btn_Re.Name = "btn_Re";
			this.btn_Re.Size = new System.Drawing.Size(128, 23);
			this.btn_Re.TabIndex = 14;
			this.btn_Re.Text = "다시 쓰기";
			this.btn_Re.Click += new System.EventHandler(this.btn_Re_Click);
			// 
			// btn_Reg
			// 
			this.btn_Reg.Location = new System.Drawing.Point(8, 368);
			this.btn_Reg.Name = "btn_Reg";
			this.btn_Reg.Size = new System.Drawing.Size(128, 24);
			this.btn_Reg.TabIndex = 13;
			this.btn_Reg.Text = "회원 추가";
			this.btn_Reg.Click += new System.EventHandler(this.btn_Reg_Click);
			// 
			// lbl_Intro
			// 
			this.lbl_Intro.Location = new System.Drawing.Point(16, 296);
			this.lbl_Intro.Name = "lbl_Intro";
			this.lbl_Intro.Size = new System.Drawing.Size(80, 16);
			this.lbl_Intro.TabIndex = 69;
			this.lbl_Intro.Text = "자기소개";
			// 
			// txt_Addr2
			// 
			this.txt_Addr2.ImeMode = System.Windows.Forms.ImeMode.Hangul;
			this.txt_Addr2.Location = new System.Drawing.Point(104, 264);
			this.txt_Addr2.Name = "txt_Addr2";
			this.txt_Addr2.Size = new System.Drawing.Size(296, 21);
			this.txt_Addr2.TabIndex = 11;
			this.txt_Addr2.Text = "";
			// 
			// lbl_Addr
			// 
			this.lbl_Addr.Location = new System.Drawing.Point(16, 240);
			this.lbl_Addr.Name = "lbl_Addr";
			this.lbl_Addr.Size = new System.Drawing.Size(80, 16);
			this.lbl_Addr.TabIndex = 68;
			this.lbl_Addr.Text = "주소";
			// 
			// txt_Addr1
			// 
			this.txt_Addr1.Location = new System.Drawing.Point(104, 240);
			this.txt_Addr1.Name = "txt_Addr1";
			this.txt_Addr1.ReadOnly = true;
			this.txt_Addr1.Size = new System.Drawing.Size(296, 21);
			this.txt_Addr1.TabIndex = 67;
			this.txt_Addr1.Text = "";
			// 
			// btn_Zip
			// 
			this.btn_Zip.Location = new System.Drawing.Point(280, 212);
			this.btn_Zip.Name = "btn_Zip";
			this.btn_Zip.Size = new System.Drawing.Size(96, 23);
			this.btn_Zip.TabIndex = 10;
			this.btn_Zip.Text = "우편번호 찾기";
			this.btn_Zip.Click += new System.EventHandler(this.btn_Zip_Click);
			// 
			// txt_Zip2
			// 
			this.txt_Zip2.Location = new System.Drawing.Point(192, 212);
			this.txt_Zip2.Name = "txt_Zip2";
			this.txt_Zip2.ReadOnly = true;
			this.txt_Zip2.Size = new System.Drawing.Size(56, 21);
			this.txt_Zip2.TabIndex = 65;
			this.txt_Zip2.Text = "";
			// 
			// lbl_Dash2
			// 
			this.lbl_Dash2.Location = new System.Drawing.Point(170, 216);
			this.lbl_Dash2.Name = "lbl_Dash2";
			this.lbl_Dash2.Size = new System.Drawing.Size(8, 16);
			this.lbl_Dash2.TabIndex = 66;
			this.lbl_Dash2.Text = "-";			
			// 
			// txt_Zip1
			// 
			this.txt_Zip1.Location = new System.Drawing.Point(104, 212);
			this.txt_Zip1.Name = "txt_Zip1";
			this.txt_Zip1.ReadOnly = true;
			this.txt_Zip1.Size = new System.Drawing.Size(56, 21);
			this.txt_Zip1.TabIndex = 57;
			this.txt_Zip1.Text = "";
			// 
			// lbl_Zip
			// 
			this.lbl_Zip.Location = new System.Drawing.Point(16, 216);
			this.lbl_Zip.Name = "lbl_Zip";
			this.lbl_Zip.Size = new System.Drawing.Size(80, 16);
			this.lbl_Zip.TabIndex = 64;
			this.lbl_Zip.Text = "우편번호";
			// 
			// txt_Intro
			// 
			this.txt_Intro.ImeMode = System.Windows.Forms.ImeMode.Hangul;
			this.txt_Intro.Location = new System.Drawing.Point(104, 296);
			this.txt_Intro.Multiline = true;
			this.txt_Intro.Name = "txt_Intro";
			this.txt_Intro.Size = new System.Drawing.Size(304, 64);
			this.txt_Intro.TabIndex = 12;
			this.txt_Intro.Text = "";
			// 
			// txt_Email
			// 
			this.txt_Email.ImeMode = System.Windows.Forms.ImeMode.Alpha;
			this.txt_Email.Location = new System.Drawing.Point(104, 184);
			this.txt_Email.Name = "txt_Email";
			this.txt_Email.Size = new System.Drawing.Size(296, 21);
			this.txt_Email.TabIndex = 9;
			this.txt_Email.Text = "";
			// 
			// txt_Tel
			// 
			this.txt_Tel.Location = new System.Drawing.Point(104, 152);
			this.txt_Tel.Name = "txt_Tel";
			this.txt_Tel.Size = new System.Drawing.Size(152, 21);
			this.txt_Tel.TabIndex = 8;
			this.txt_Tel.Text = "";
			// 
			// txt_Ssn2
			// 
			this.txt_Ssn2.Location = new System.Drawing.Point(232, 120);
			this.txt_Ssn2.Name = "txt_Ssn2";
			this.txt_Ssn2.Size = new System.Drawing.Size(136, 21);
			this.txt_Ssn2.TabIndex = 7;
			this.txt_Ssn2.Text = "";
			// 
			// txt_Ssn1
			// 
			this.txt_Ssn1.Location = new System.Drawing.Point(104, 120);
			this.txt_Ssn1.Name = "txt_Ssn1";
			this.txt_Ssn1.TabIndex = 6;
			this.txt_Ssn1.Text = "";
			// 
			// txt_Name
			// 
			this.txt_Name.ImeMode = System.Windows.Forms.ImeMode.Hangul;
			this.txt_Name.Location = new System.Drawing.Point(104, 80);
			this.txt_Name.Name = "txt_Name";
			this.txt_Name.Size = new System.Drawing.Size(104, 21);
			this.txt_Name.TabIndex = 4;
			this.txt_Name.Text = "";
			// 
			// txt_Pwd_Ok
			// 
			this.txt_Pwd_Ok.Location = new System.Drawing.Point(320, 48);
			this.txt_Pwd_Ok.Name = "txt_Pwd_Ok";
			this.txt_Pwd_Ok.PasswordChar = '*';
			this.txt_Pwd_Ok.TabIndex = 3;
			this.txt_Pwd_Ok.Text = "";
			// 
			// txt_Pwd
			// 
			this.txt_Pwd.Location = new System.Drawing.Point(104, 48);
			this.txt_Pwd.Name = "txt_Pwd";
			this.txt_Pwd.PasswordChar = '*';
			this.txt_Pwd.Size = new System.Drawing.Size(104, 21);
			this.txt_Pwd.TabIndex = 2;
			this.txt_Pwd.Text = "";
			// 
			// btn_ID
			// 
			this.btn_ID.Location = new System.Drawing.Point(248, 8);
			this.btn_ID.Name = "btn_ID";
			this.btn_ID.Size = new System.Drawing.Size(136, 23);
			this.btn_ID.TabIndex = 1;
			this.btn_ID.Text = "아이디 중복 검사";
			this.btn_ID.Click += new System.EventHandler(this.btn_ID_Click);
			// 
			// lbl_Dash1
			// 
			this.lbl_Dash1.Location = new System.Drawing.Point(214, 125);
			this.lbl_Dash1.Name = "lbl_Dash1";
			this.lbl_Dash1.Size = new System.Drawing.Size(8, 16);
			this.lbl_Dash1.TabIndex = 56;
			this.lbl_Dash1.Text = "-";
			// 
			// lbl_Email
			// 
			this.lbl_Email.Location = new System.Drawing.Point(16, 184);
			this.lbl_Email.Name = "lbl_Email";
			this.lbl_Email.Size = new System.Drawing.Size(80, 16);
			this.lbl_Email.TabIndex = 54;
			this.lbl_Email.Text = "E-메일주소";
			// 
			// txt_ID
			// 
			this.txt_ID.Location = new System.Drawing.Point(104, 8);
			this.txt_ID.Name = "txt_ID";
			this.txt_ID.Size = new System.Drawing.Size(120, 21);
			this.txt_ID.TabIndex = 0;
			this.txt_ID.Text = "";
			// 
			// lbl_Tel
			// 
			this.lbl_Tel.Location = new System.Drawing.Point(16, 152);
			this.lbl_Tel.Name = "lbl_Tel";
			this.lbl_Tel.Size = new System.Drawing.Size(80, 16);
			this.lbl_Tel.TabIndex = 50;
			this.lbl_Tel.Text = "전화번호";
			// 
			// lbl_jumin
			// 
			this.lbl_jumin.Location = new System.Drawing.Point(16, 120);
			this.lbl_jumin.Name = "lbl_jumin";
			this.lbl_jumin.Size = new System.Drawing.Size(64, 16);
			this.lbl_jumin.TabIndex = 49;
			this.lbl_jumin.Text = "주민 번호";
			// 
			// lbl_Name
			// 
			this.lbl_Name.Location = new System.Drawing.Point(16, 88);
			this.lbl_Name.Name = "lbl_Name";
			this.lbl_Name.Size = new System.Drawing.Size(80, 16);
			this.lbl_Name.TabIndex = 47;
			this.lbl_Name.Text = "이름";
			// 
			// lbl_Pwd_Ok
			// 
			this.lbl_Pwd_Ok.Location = new System.Drawing.Point(216, 56);
			this.lbl_Pwd_Ok.Name = "lbl_Pwd_Ok";
			this.lbl_Pwd_Ok.Size = new System.Drawing.Size(88, 16);
			this.lbl_Pwd_Ok.TabIndex = 45;
			this.lbl_Pwd_Ok.Text = "비밀번호 확인";
			// 
			// lbl_Pwd
			// 
			this.lbl_Pwd.Location = new System.Drawing.Point(16, 56);
			this.lbl_Pwd.Name = "lbl_Pwd";
			this.lbl_Pwd.Size = new System.Drawing.Size(80, 16);
			this.lbl_Pwd.TabIndex = 42;
			this.lbl_Pwd.Text = "비밀번호";
			// 
			// lbl_ID
			// 
			this.lbl_ID.Location = new System.Drawing.Point(16, 16);
			this.lbl_ID.Name = "lbl_ID";
			this.lbl_ID.Size = new System.Drawing.Size(80, 16);
			this.lbl_ID.TabIndex = 40;
			this.lbl_ID.Text = "아이디";
			// 
			// btn_Close
			// 
			this.btn_Close.Location = new System.Drawing.Point(304, 368);
			this.btn_Close.Name = "btn_Close";
			this.btn_Close.Size = new System.Drawing.Size(128, 23);
			this.btn_Close.TabIndex = 15;
			this.btn_Close.Text = "창 닫기";
			this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
			// 
			// txt_NickName
			// 
			this.txt_NickName.Location = new System.Drawing.Point(264, 81);
			this.txt_NickName.Name = "txt_NickName";
			this.txt_NickName.Size = new System.Drawing.Size(160, 21);
			this.txt_NickName.TabIndex = 5;
			this.txt_NickName.Text = "";
			// 
			// InsertMember
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(440, 405);
			this.Controls.Add(this.txt_NickName);
			this.Controls.Add(this.txt_Addr2);
			this.Controls.Add(this.txt_Addr1);
			this.Controls.Add(this.txt_Zip2);
			this.Controls.Add(this.txt_Zip1);
			this.Controls.Add(this.txt_Intro);
			this.Controls.Add(this.txt_Email);
			this.Controls.Add(this.txt_Tel);
			this.Controls.Add(this.txt_Ssn2);
			this.Controls.Add(this.txt_Ssn1);
			this.Controls.Add(this.txt_Name);
			this.Controls.Add(this.txt_Pwd_Ok);
			this.Controls.Add(this.txt_Pwd);
			this.Controls.Add(this.txt_ID);
			this.Controls.Add(this.btn_Close);
			this.Controls.Add(this.lbl_NickName);
			this.Controls.Add(this.lbl_Addr2);
			this.Controls.Add(this.lbl_Example);
			this.Controls.Add(this.btn_Re);
			this.Controls.Add(this.btn_Reg);
			this.Controls.Add(this.lbl_Intro);
			this.Controls.Add(this.lbl_Addr);
			this.Controls.Add(this.btn_Zip);
			this.Controls.Add(this.lbl_Dash2);
			this.Controls.Add(this.lbl_Zip);
			this.Controls.Add(this.btn_ID);
			this.Controls.Add(this.lbl_Dash1);
			this.Controls.Add(this.lbl_Email);
			this.Controls.Add(this.lbl_Tel);
			this.Controls.Add(this.lbl_jumin);
			this.Controls.Add(this.lbl_Name);
			this.Controls.Add(this.lbl_Pwd_Ok);
			this.Controls.Add(this.lbl_Pwd);
			this.Controls.Add(this.lbl_ID);
			this.Name = "InsertMember";
			this.Text = "신규회원 정보 입력하기";
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
		/// 주민번호 유효성 검사 메서드
		/// </summary>
		/// <param name="str">검사할 주민번호</param>
		/// <returns></returns>
		private bool Check_Digit( string str) 
		{	
			
			if(Digit_Check( str )) return false ; // 숫자만 입력했는지 체크
			if( str.Length != 13 ) return false ; // 주민 번호는 13자리 수
			int sum = 0 ;   // 유효성 계산
			int temp = 0 ;
			// 주민 번호를 배열에 저장
			int [] num = new int[13] ;          
			// 가중치 값 저장
			int [] digit = {2,3,4,5,6,7,8,9,2,3,4,5} ;
            
			// 입력된 문자를 숫자로!
			for( int i = 0 ; i< 13 ; i++) 
			{
				num[i] = Int32.Parse(str[i]+"") ;  
			}

			// 주민 번호 유효성 검사
			for(int i=0; i<12; i++) 
			{
				sum += digit[i] * num[i];
			}
			// 유효성 검증
			temp = sum%11 ;
			
			int check_digit_num1 = temp;
			int check_digit_num2 = num[12];

			if(check_digit_num1 == 0) 
			{
				if(check_digit_num2 == 1)
					return true;
				else
					return false;
			}
			else if(check_digit_num1 == 1) 
			{
				if(check_digit_num2 == 0)
					return true;
				else
					return false;
			}
			else if((11-check_digit_num1) == check_digit_num2) return true;
			else return false;
		}

		/// <summary>
		/// 회원 가입 인증 메서드
		/// </summary>
		/// <returns></returns> 
		private bool  Authentication() 
		{
			// 에러 문자열 저장
			string ErrorMessage = "" ;     	    
			// 아이디 체크
			if(txt_ID.Text.Trim()  == "") 
				ErrorMessage += "- 아이디를 입력하세요.!\n\n";
			else if( txt_ID.Text.Length < 5 || txt_ID.Text.Length >16) 
				ErrorMessage += "- 아이디는 5자 이상 16자 이하 입니다.\n\n";
			else if( !A_or_D(txt_ID.Text.Trim()))    // 영문과 숫자 체크함수 			
				ErrorMessage += "- 아이디는 영문이나 숫자로 입력하셔야 합니다.\n\n";
			
			// 아이디 중복 검사 유무
			if( !id_ok ) 
				ErrorMessage += " *** 아이디 중복 검사를 하세요 ! *** \n\n" ;

			// 암호 체크
			if( txt_Pwd.Text.Length < 5 || txt_ID.Text.Length >16 )
				ErrorMessage += "- 암호는 5자 이상 16자 이하 입니다.\n\n" ;
			else if( !A_or_D(txt_Pwd.Text.Trim()))
				ErrorMessage += "- 암호는 숫자 또는 문자를 입력해야 합니다.!\n\n" ;
			else if( !txt_Pwd.Text.Equals( txt_Pwd_Ok.Text.Trim()))
				ErrorMessage += "- 암호가 일치하지 않습니다.\n\n" ;
			
			// 이름 체크
			if( txt_Name.Text.Trim() == "" ) 
				ErrorMessage += "- 이름을 입력하세요!\n\n"; 

			// 별칭 체크
			if( txt_NickName.Text.Trim() == "")
				ErrorMessage += "- 별칭을 입력해주세요!\n\n" ;
			else if( txt_NickName.Text.Length > 100)
				ErrorMessage += "- 별칭은 100글자안에서 입력해주세요.\n\n" ;

			
			// 주민 번호 체크
			if(!Check_Digit(txt_Ssn1.Text.Trim()+txt_Ssn2.Text.Trim()))
				ErrorMessage += "- 주민등록번호를 정확히 입력하세요.\n\n";
			
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
			if(txt_Addr1.Text.Trim() == "" && txt_Addr2.Text.Trim() == "") 
				ErrorMessage += "- 주소를 입력하세요.\n\n";
			
			// 에러 문자열 체크
			if( ErrorMessage != "") 
			{
				MessageBox.Show(ErrorMessage, "등록 에러", MessageBoxButtons.OK, MessageBoxIcon.Error   );
				return false ;
			}
			
			return true ;
		}

		private void InitControl()
		{
			// 화면에 붙어 있는  컨트롤의 개수 만큼 호출
			for( int i = 0; i<Controls.Count ; i++)
				if(Controls[i] is TextBox)  // TextBox 컨트롤이면
					((TextBox)Controls[i]).Text = "" ; // 문자열 초기화
		}

		private void btn_Re_Click(object sender, System.EventArgs e)
		{
			this.InitControl();
		}

		private void btn_Reg_Click(object sender, System.EventArgs e)
		{
			try
			{			
				// 회원 가입 인증 메서드 호출
				if(! Authentication()) return ; // 인증 실패시 반환			
				// 회원 정보 기록			
				DataRow row = ds.Tables["Member"].NewRow();
          
				row["id"] = txt_ID.Text.Trim();
				row["pwd"] = txt_Pwd.Text.Trim();
				row["name"] = txt_Name.Text.Trim();
				row["nickname"] = txt_NickName.Text.Trim();
				row["ssn"] = txt_Ssn1.Text.Trim() + "-" + txt_Ssn2.Text.Trim();
				row["tel"] = txt_Tel.Text.Trim();
				row["email"] = txt_Email.Text.Trim();
				row["zipcode"] = txt_Zip1.Text.Trim() + "-" + txt_Zip2.Text.Trim();
				row["address"] = txt_Addr1.Text.Trim() + " " + txt_Addr2.Text.Trim();
				row["intro"] = txt_Intro.Text.Trim();

				ds.Tables["Member"].Rows.Add(row);						

				MessageBox.Show("회원 추가 성공");
				this.InitControl(); // 화면에 있는 데이터 지움

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

		private void btn_ID_Click(object sender, System.EventArgs e)
		{
			if(txt_ID.Text.Length == 0) 
			{
				MessageBox.Show("아이디를 입력하세요!");
				return;
			}

			string filter = "id = '"+ txt_ID.Text.Trim() + "'";			

			DataRow [] row = ds.Tables["Member"].Select(filter);

			if( row.Length > 0 )
				this.id_ok = false;				
			else
				this.id_ok = true;

			string str = id_ok ? "아이디 사용가능!" : "이미 가입된 아이디!" ;

			MessageBox.Show(str, "아이디 중복 검사 결과");
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
				txt_Addr1.Text = token[1];		 

				txt_Addr2.Focus();
			}
          
		}

		

	}
}
