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
	/// InsertMember�� ���� ��� �����Դϴ�.
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
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public InsertMember(DataSet ds)
		{
			//
			// Windows Form �����̳� ������ �ʿ��մϴ�.
			//
			InitializeComponent();

			this.ds = ds;
		}

		/// <summary>
		/// ��� ���� ��� ���ҽ��� �����մϴ�.
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

		#region Windows Form �����̳ʿ��� ������ �ڵ�
		/// <summary>
		/// �����̳� ������ �ʿ��� �޼����Դϴ�.
		/// �� �޼����� ������ �ڵ� ������� �������� ���ʽÿ�.
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
			this.lbl_NickName.Text = "��Ī";
			// 
			// lbl_Addr2
			// 
			this.lbl_Addr2.Location = new System.Drawing.Point(16, 264);
			this.lbl_Addr2.Name = "lbl_Addr2";
			this.lbl_Addr2.Size = new System.Drawing.Size(80, 16);
			this.lbl_Addr2.TabIndex = 71;
			this.lbl_Addr2.Text = "���ּ�";
			// 
			// lbl_Example
			// 
			this.lbl_Example.Location = new System.Drawing.Point(264, 160);
			this.lbl_Example.Name = "lbl_Example";
			this.lbl_Example.Size = new System.Drawing.Size(160, 16);
			this.lbl_Example.TabIndex = 70;
			this.lbl_Example.Text = "��) 02-123-1234";
			// 
			// btn_Re
			// 
			this.btn_Re.Location = new System.Drawing.Point(154, 368);
			this.btn_Re.Name = "btn_Re";
			this.btn_Re.Size = new System.Drawing.Size(128, 23);
			this.btn_Re.TabIndex = 14;
			this.btn_Re.Text = "�ٽ� ����";
			this.btn_Re.Click += new System.EventHandler(this.btn_Re_Click);
			// 
			// btn_Reg
			// 
			this.btn_Reg.Location = new System.Drawing.Point(8, 368);
			this.btn_Reg.Name = "btn_Reg";
			this.btn_Reg.Size = new System.Drawing.Size(128, 24);
			this.btn_Reg.TabIndex = 13;
			this.btn_Reg.Text = "ȸ�� �߰�";
			this.btn_Reg.Click += new System.EventHandler(this.btn_Reg_Click);
			// 
			// lbl_Intro
			// 
			this.lbl_Intro.Location = new System.Drawing.Point(16, 296);
			this.lbl_Intro.Name = "lbl_Intro";
			this.lbl_Intro.Size = new System.Drawing.Size(80, 16);
			this.lbl_Intro.TabIndex = 69;
			this.lbl_Intro.Text = "�ڱ�Ұ�";
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
			this.lbl_Addr.Text = "�ּ�";
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
			this.btn_Zip.Text = "�����ȣ ã��";
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
			this.lbl_Zip.Text = "�����ȣ";
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
			this.btn_ID.Text = "���̵� �ߺ� �˻�";
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
			this.lbl_Email.Text = "E-�����ּ�";
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
			this.lbl_Tel.Text = "��ȭ��ȣ";
			// 
			// lbl_jumin
			// 
			this.lbl_jumin.Location = new System.Drawing.Point(16, 120);
			this.lbl_jumin.Name = "lbl_jumin";
			this.lbl_jumin.Size = new System.Drawing.Size(64, 16);
			this.lbl_jumin.TabIndex = 49;
			this.lbl_jumin.Text = "�ֹ� ��ȣ";
			// 
			// lbl_Name
			// 
			this.lbl_Name.Location = new System.Drawing.Point(16, 88);
			this.lbl_Name.Name = "lbl_Name";
			this.lbl_Name.Size = new System.Drawing.Size(80, 16);
			this.lbl_Name.TabIndex = 47;
			this.lbl_Name.Text = "�̸�";
			// 
			// lbl_Pwd_Ok
			// 
			this.lbl_Pwd_Ok.Location = new System.Drawing.Point(216, 56);
			this.lbl_Pwd_Ok.Name = "lbl_Pwd_Ok";
			this.lbl_Pwd_Ok.Size = new System.Drawing.Size(88, 16);
			this.lbl_Pwd_Ok.TabIndex = 45;
			this.lbl_Pwd_Ok.Text = "��й�ȣ Ȯ��";
			// 
			// lbl_Pwd
			// 
			this.lbl_Pwd.Location = new System.Drawing.Point(16, 56);
			this.lbl_Pwd.Name = "lbl_Pwd";
			this.lbl_Pwd.Size = new System.Drawing.Size(80, 16);
			this.lbl_Pwd.TabIndex = 42;
			this.lbl_Pwd.Text = "��й�ȣ";
			// 
			// lbl_ID
			// 
			this.lbl_ID.Location = new System.Drawing.Point(16, 16);
			this.lbl_ID.Name = "lbl_ID";
			this.lbl_ID.Size = new System.Drawing.Size(80, 16);
			this.lbl_ID.TabIndex = 40;
			this.lbl_ID.Text = "���̵�";
			// 
			// btn_Close
			// 
			this.btn_Close.Location = new System.Drawing.Point(304, 368);
			this.btn_Close.Name = "btn_Close";
			this.btn_Close.Size = new System.Drawing.Size(128, 23);
			this.btn_Close.TabIndex = 15;
			this.btn_Close.Text = "â �ݱ�";
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
			this.Text = "�ű�ȸ�� ���� �Է��ϱ�";
			this.ResumeLayout(false);

		}
		#endregion

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
			foreach(char ch in lower_str) 
			{				
				if(((ch < 'a') || (ch > 'z')) && ((ch < '0') ||(ch > '9')))
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
			if(Digit_Check( str )) return false ;  // ���� �Է� Ȯ��
			// �м��� ���ڿ��� �ҹ��ڷ� ����
			string lower_str = str.ToLower();
			// ��ȭ��ȣ�� - �� 0~9 ���� ���� ���� �ԷµǾ�� ��.
			foreach(char ch in lower_str) 
			{				
				if( ( ch !='-' ) && ((ch < '0') || (ch > '9')))
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
			foreach(char ch in lower_str) 
			{
				if((ch < '0') || (ch > '9'))
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
			byte stock = 0 ;
			// ���� ���� �ּҴ� @ �� . �� ���ԵǾ� �־����.
			foreach(char ch in str) 
			{				
				if( ch == '@' || ch == '.' ) stock++ ;
			}
			if( stock >= 2 ) return true ;
			return false ;
		}

		/// <summary>
		/// �ֹι�ȣ ��ȿ�� �˻� �޼���
		/// </summary>
		/// <param name="str">�˻��� �ֹι�ȣ</param>
		/// <returns></returns>
		private bool Check_Digit( string str) 
		{	
			
			if(Digit_Check( str )) return false ; // ���ڸ� �Է��ߴ��� üũ
			if( str.Length != 13 ) return false ; // �ֹ� ��ȣ�� 13�ڸ� ��
			int sum = 0 ;   // ��ȿ�� ���
			int temp = 0 ;
			// �ֹ� ��ȣ�� �迭�� ����
			int [] num = new int[13] ;          
			// ����ġ �� ����
			int [] digit = {2,3,4,5,6,7,8,9,2,3,4,5} ;
            
			// �Էµ� ���ڸ� ���ڷ�!
			for( int i = 0 ; i< 13 ; i++) 
			{
				num[i] = Int32.Parse(str[i]+"") ;  
			}

			// �ֹ� ��ȣ ��ȿ�� �˻�
			for(int i=0; i<12; i++) 
			{
				sum += digit[i] * num[i];
			}
			// ��ȿ�� ����
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
		/// ȸ�� ���� ���� �޼���
		/// </summary>
		/// <returns></returns> 
		private bool  Authentication() 
		{
			// ���� ���ڿ� ����
			string ErrorMessage = "" ;     	    
			// ���̵� üũ
			if(txt_ID.Text.Trim()  == "") 
				ErrorMessage += "- ���̵� �Է��ϼ���.!\n\n";
			else if( txt_ID.Text.Length < 5 || txt_ID.Text.Length >16) 
				ErrorMessage += "- ���̵�� 5�� �̻� 16�� ���� �Դϴ�.\n\n";
			else if( !A_or_D(txt_ID.Text.Trim()))    // ������ ���� üũ�Լ� 			
				ErrorMessage += "- ���̵�� �����̳� ���ڷ� �Է��ϼž� �մϴ�.\n\n";
			
			// ���̵� �ߺ� �˻� ����
			if( !id_ok ) 
				ErrorMessage += " *** ���̵� �ߺ� �˻縦 �ϼ��� ! *** \n\n" ;

			// ��ȣ üũ
			if( txt_Pwd.Text.Length < 5 || txt_ID.Text.Length >16 )
				ErrorMessage += "- ��ȣ�� 5�� �̻� 16�� ���� �Դϴ�.\n\n" ;
			else if( !A_or_D(txt_Pwd.Text.Trim()))
				ErrorMessage += "- ��ȣ�� ���� �Ǵ� ���ڸ� �Է��ؾ� �մϴ�.!\n\n" ;
			else if( !txt_Pwd.Text.Equals( txt_Pwd_Ok.Text.Trim()))
				ErrorMessage += "- ��ȣ�� ��ġ���� �ʽ��ϴ�.\n\n" ;
			
			// �̸� üũ
			if( txt_Name.Text.Trim() == "" ) 
				ErrorMessage += "- �̸��� �Է��ϼ���!\n\n"; 

			// ��Ī üũ
			if( txt_NickName.Text.Trim() == "")
				ErrorMessage += "- ��Ī�� �Է����ּ���!\n\n" ;
			else if( txt_NickName.Text.Length > 100)
				ErrorMessage += "- ��Ī�� 100���ھȿ��� �Է����ּ���.\n\n" ;

			
			// �ֹ� ��ȣ üũ
			if(!Check_Digit(txt_Ssn1.Text.Trim()+txt_Ssn2.Text.Trim()))
				ErrorMessage += "- �ֹε�Ϲ�ȣ�� ��Ȯ�� �Է��ϼ���.\n\n";
			
			// ��ȭ ��ȣ üũ
			if(txt_Tel.Text.Trim() == "")
				ErrorMessage += "- ��ȭ ��ȣ�� �Է��ϼ���.!\n\n";
			else if(Tel_Check(txt_Tel.Text.Trim()))
				ErrorMessage += "- ��ȭ��ȣ���� ���ڿ� '-'�� ����� �� �ֽ��ϴ�.\n\n";

			// E - mail �ּ� üũ
			if(txt_Email.Text.Trim() == "")
				ErrorMessage += "- E-���� �ּҸ� �Է��ϼ���.!\n\n";
			else if(!Email_Check(txt_Email.Text.Trim()))
				ErrorMessage += "- E-���� �ּҸ� ��Ȯ�� �Է��ϼ���.!\n\n";  

			// ���� ��ȣ üũ
			if(txt_Zip1.Text.Trim()+txt_Zip2.Text.Trim()  == "")
				ErrorMessage += "- �����ȣ�� �Է��ϼ���.\n\n";
			else if(Digit_Check(txt_Zip1.Text.Trim()+txt_Zip2.Text.Trim()))
				ErrorMessage += "- �����ȣ���� ���ڸ� �Է��� �� �ֽ��ϴ�.\n\n"  ;
			
			// �ּ� �Է� üũ
			if(txt_Addr1.Text.Trim() == "" && txt_Addr2.Text.Trim() == "") 
				ErrorMessage += "- �ּҸ� �Է��ϼ���.\n\n";
			
			// ���� ���ڿ� üũ
			if( ErrorMessage != "") 
			{
				MessageBox.Show(ErrorMessage, "��� ����", MessageBoxButtons.OK, MessageBoxIcon.Error   );
				return false ;
			}
			
			return true ;
		}

		private void InitControl()
		{
			// ȭ�鿡 �پ� �ִ�  ��Ʈ���� ���� ��ŭ ȣ��
			for( int i = 0; i<Controls.Count ; i++)
				if(Controls[i] is TextBox)  // TextBox ��Ʈ���̸�
					((TextBox)Controls[i]).Text = "" ; // ���ڿ� �ʱ�ȭ
		}

		private void btn_Re_Click(object sender, System.EventArgs e)
		{
			this.InitControl();
		}

		private void btn_Reg_Click(object sender, System.EventArgs e)
		{
			try
			{			
				// ȸ�� ���� ���� �޼��� ȣ��
				if(! Authentication()) return ; // ���� ���н� ��ȯ			
				// ȸ�� ���� ���			
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

				MessageBox.Show("ȸ�� �߰� ����");
				this.InitControl(); // ȭ�鿡 �ִ� ������ ����

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
				MessageBox.Show("���̵� �Է��ϼ���!");
				return;
			}

			string filter = "id = '"+ txt_ID.Text.Trim() + "'";			

			DataRow [] row = ds.Tables["Member"].Select(filter);

			if( row.Length > 0 )
				this.id_ok = false;				
			else
				this.id_ok = true;

			string str = id_ok ? "���̵� ��밡��!" : "�̹� ���Ե� ���̵�!" ;

			MessageBox.Show(str, "���̵� �ߺ� �˻� ���");
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
