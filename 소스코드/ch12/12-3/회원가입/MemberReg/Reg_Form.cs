using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace MemberReg
{
	/// <summary>
	/// ȸ�� ���� Ŭ����
	/// </summary>
	public class Reg_Form : System.Windows.Forms.Form 
	{   
		public MainWnd wnd = null;

		public ZipcodeWnd zipcodewnd = null;  // �����ȣ �˻�â

		// ���̵� �ߺ� �˻縦 �ߴ��� �˷��ִ� �÷���
		public bool id_ok = false ; 	

		// ���� ������ �ּ�
		private string ip = null;
		
		private RegNetwork net = null;
		private System.Windows.Forms.Label lbl_ID;
		private System.Windows.Forms.Label lbl_Pwd;
		private System.Windows.Forms.Label lbl_Pwd_Ok;
		private System.Windows.Forms.Label lbl_Name;
		private System.Windows.Forms.Label lbl_Jumin;
		private System.Windows.Forms.Label lbl_Tel;
		private System.Windows.Forms.TextBox txt_ID;
		private System.Windows.Forms.Label lbl_Email;
		private System.Windows.Forms.Label lbl_Dash1;
		private System.Windows.Forms.Button btn_ID;
		private System.Windows.Forms.TextBox txt_Pwd;
		private System.Windows.Forms.TextBox txt_Pwd_Ok;
		private System.Windows.Forms.TextBox txt_Name;
		private System.Windows.Forms.TextBox txt_Ssn1;
		private System.Windows.Forms.TextBox txt_Ssn2;
		private System.Windows.Forms.TextBox txt_Tel;
		private System.Windows.Forms.TextBox txt_Email;
		private System.Windows.Forms.TextBox txt_Intro;
		private System.Windows.Forms.Label lbl_Zip;
		private System.Windows.Forms.TextBox txt_Zip2;
		private System.Windows.Forms.Label lbl_Dash2;
		private System.Windows.Forms.TextBox txt_Zip1;
		private System.Windows.Forms.Button btn_Zip;
		private System.Windows.Forms.TextBox txt_Addr1;
		private System.Windows.Forms.Label lbl_Addr;
		private System.Windows.Forms.TextBox txt_Addr2;
		private System.Windows.Forms.Label lbl_Intro;
		private System.Windows.Forms.Button btn_Reg;
		private System.Windows.Forms.Button btn_Re;
		private System.Windows.Forms.Label lbl_Example;
		private System.Windows.Forms.Label lbl_addr2;
		private System.Windows.Forms.Label lbl_NickName;
		private System.Windows.Forms.TextBox txt_NickName;
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Reg_Form(MainWnd wnd, string ip) 
		{	
			InitializeComponent();

			this.wnd = wnd;
			this.ip = ip ;  // ������ ���� ������
			this.net = new RegNetwork(this);

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

		#region Windows Form Designer generated code
		/// <summary>
		/// �����̳� ������ �ʿ��� �޼����Դϴ�.
		/// �� �޼����� ������ �ڵ� ������� �������� ���ʽÿ�.
		/// </summary>
		private void InitializeComponent() 
		{
			this.lbl_ID = new System.Windows.Forms.Label();
			this.lbl_Pwd = new System.Windows.Forms.Label();
			this.lbl_Pwd_Ok = new System.Windows.Forms.Label();
			this.lbl_Name = new System.Windows.Forms.Label();
			this.lbl_Jumin = new System.Windows.Forms.Label();
			this.lbl_Tel = new System.Windows.Forms.Label();
			this.txt_ID = new System.Windows.Forms.TextBox();
			this.lbl_Email = new System.Windows.Forms.Label();
			this.lbl_Dash1 = new System.Windows.Forms.Label();
			this.btn_ID = new System.Windows.Forms.Button();
			this.txt_Pwd = new System.Windows.Forms.TextBox();
			this.txt_Pwd_Ok = new System.Windows.Forms.TextBox();
			this.txt_Name = new System.Windows.Forms.TextBox();
			this.txt_Ssn1 = new System.Windows.Forms.TextBox();
			this.txt_Ssn2 = new System.Windows.Forms.TextBox();
			this.txt_Tel = new System.Windows.Forms.TextBox();
			this.txt_Email = new System.Windows.Forms.TextBox();
			this.txt_Intro = new System.Windows.Forms.TextBox();
			this.lbl_Zip = new System.Windows.Forms.Label();
			this.txt_Zip2 = new System.Windows.Forms.TextBox();
			this.lbl_Dash2 = new System.Windows.Forms.Label();
			this.txt_Zip1 = new System.Windows.Forms.TextBox();
			this.btn_Zip = new System.Windows.Forms.Button();
			this.txt_Addr1 = new System.Windows.Forms.TextBox();
			this.lbl_Addr = new System.Windows.Forms.Label();
			this.txt_Addr2 = new System.Windows.Forms.TextBox();
			this.lbl_Intro = new System.Windows.Forms.Label();
			this.btn_Reg = new System.Windows.Forms.Button();
			this.btn_Re = new System.Windows.Forms.Button();
			this.lbl_Example = new System.Windows.Forms.Label();
			this.lbl_addr2 = new System.Windows.Forms.Label();
			this.lbl_NickName = new System.Windows.Forms.Label();
			this.txt_NickName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lbl_ID
			// 
			this.lbl_ID.Location = new System.Drawing.Point(16, 32);
			this.lbl_ID.Name = "lbl_ID";
			this.lbl_ID.Size = new System.Drawing.Size(80, 16);
			this.lbl_ID.TabIndex = 0;
			this.lbl_ID.Text = "���̵�";
			// 
			// lbl_Pwd
			// 
			this.lbl_Pwd.Location = new System.Drawing.Point(16, 72);
			this.lbl_Pwd.Name = "lbl_Pwd";
			this.lbl_Pwd.Size = new System.Drawing.Size(80, 16);
			this.lbl_Pwd.TabIndex = 1;
			this.lbl_Pwd.Text = "��й�ȣ";
			// 
			// lbl_Pwd_Ok
			// 
			this.lbl_Pwd_Ok.Location = new System.Drawing.Point(216, 72);
			this.lbl_Pwd_Ok.Name = "lbl_Pwd_Ok";
			this.lbl_Pwd_Ok.Size = new System.Drawing.Size(88, 16);
			this.lbl_Pwd_Ok.TabIndex = 2;
			this.lbl_Pwd_Ok.Text = "��й�ȣ Ȯ��";
			// 
			// lbl_Name
			// 
			this.lbl_Name.Location = new System.Drawing.Point(16, 104);
			this.lbl_Name.Name = "lbl_Name";
			this.lbl_Name.Size = new System.Drawing.Size(80, 16);
			this.lbl_Name.TabIndex = 3;
			this.lbl_Name.Text = "�̸�";
			// 
			// lbl_Jumin
			// 
			this.lbl_Jumin.Location = new System.Drawing.Point(16, 136);
			this.lbl_Jumin.Name = "lbl_Jumin";
			this.lbl_Jumin.Size = new System.Drawing.Size(64, 16);
			this.lbl_Jumin.TabIndex = 4;
			this.lbl_Jumin.Text = "�ֹ� ��ȣ";
			// 
			// lbl_Tel
			// 
			this.lbl_Tel.Location = new System.Drawing.Point(16, 168);
			this.lbl_Tel.Name = "lbl_Tel";
			this.lbl_Tel.Size = new System.Drawing.Size(80, 16);
			this.lbl_Tel.TabIndex = 5;
			this.lbl_Tel.Text = "��ȭ��ȣ";
			// 
			// txt_ID
			// 
			this.txt_ID.Location = new System.Drawing.Point(104, 24);
			this.txt_ID.Name = "txt_ID";
			this.txt_ID.Size = new System.Drawing.Size(120, 21);
			this.txt_ID.TabIndex = 0;
			this.txt_ID.Text = "";
			// 
			// lbl_Email
			// 
			this.lbl_Email.Location = new System.Drawing.Point(16, 200);
			this.lbl_Email.Name = "lbl_Email";
			this.lbl_Email.Size = new System.Drawing.Size(80, 16);
			this.lbl_Email.TabIndex = 7;
			this.lbl_Email.Text = "E-�����ּ�";
			// 
			// lbl_Dash1
			// 
			this.lbl_Dash1.Location = new System.Drawing.Point(208, 144);
			this.lbl_Dash1.Name = "lbl_Dash1";
			this.lbl_Dash1.Size = new System.Drawing.Size(20, 16);
			this.lbl_Dash1.TabIndex = 8;
			this.lbl_Dash1.Text = "-";
			// 
			// btn_ID
			// 
			this.btn_ID.Location = new System.Drawing.Point(248, 24);
			this.btn_ID.Name = "btn_ID";
			this.btn_ID.Size = new System.Drawing.Size(136, 23);
			this.btn_ID.TabIndex = 1;
			this.btn_ID.Text = "���̵� �ߺ� �˻�";
			this.btn_ID.Click += new System.EventHandler(this.btn_ID_Click);
			// 
			// txt_Pwd
			// 
			this.txt_Pwd.Location = new System.Drawing.Point(104, 64);
			this.txt_Pwd.Name = "txt_Pwd";
			this.txt_Pwd.PasswordChar = '*';
			this.txt_Pwd.Size = new System.Drawing.Size(104, 21);
			this.txt_Pwd.TabIndex = 2;
			this.txt_Pwd.Text = "";
			// 
			// txt_Pwd_Ok
			// 
			this.txt_Pwd_Ok.Location = new System.Drawing.Point(320, 64);
			this.txt_Pwd_Ok.Name = "txt_Pwd_Ok";
			this.txt_Pwd_Ok.PasswordChar = '*';
			this.txt_Pwd_Ok.TabIndex = 3;
			this.txt_Pwd_Ok.Text = "";
			// 
			// txt_Name
			// 
			this.txt_Name.ImeMode = System.Windows.Forms.ImeMode.Hangul;
			this.txt_Name.Location = new System.Drawing.Point(104, 96);
			this.txt_Name.Name = "txt_Name";
			this.txt_Name.Size = new System.Drawing.Size(104, 21);
			this.txt_Name.TabIndex = 4;
			this.txt_Name.Text = "";
			// 
			// txt_Ssn1
			// 
			this.txt_Ssn1.Location = new System.Drawing.Point(104, 136);
			this.txt_Ssn1.Name = "txt_Ssn1";
			this.txt_Ssn1.TabIndex = 6;
			this.txt_Ssn1.Text = "";
			// 
			// txt_Ssn2
			// 
			this.txt_Ssn2.Location = new System.Drawing.Point(232, 136);
			this.txt_Ssn2.Name = "txt_Ssn2";
			this.txt_Ssn2.Size = new System.Drawing.Size(136, 21);
			this.txt_Ssn2.TabIndex = 7;
			this.txt_Ssn2.Text = "";
			// 
			// txt_Tel
			// 
			this.txt_Tel.Location = new System.Drawing.Point(104, 168);
			this.txt_Tel.Name = "txt_Tel";
			this.txt_Tel.Size = new System.Drawing.Size(152, 21);
			this.txt_Tel.TabIndex = 8;
			this.txt_Tel.Text = "";
			// 
			// txt_Email
			// 
			this.txt_Email.ImeMode = System.Windows.Forms.ImeMode.Alpha;
			this.txt_Email.Location = new System.Drawing.Point(104, 200);
			this.txt_Email.Name = "txt_Email";
			this.txt_Email.Size = new System.Drawing.Size(296, 21);
			this.txt_Email.TabIndex = 9;
			this.txt_Email.Text = "";
			// 
			// txt_Intro
			// 
			this.txt_Intro.ImeMode = System.Windows.Forms.ImeMode.Hangul;
			this.txt_Intro.Location = new System.Drawing.Point(104, 312);
			this.txt_Intro.Multiline = true;
			this.txt_Intro.Name = "txt_Intro";
			this.txt_Intro.Size = new System.Drawing.Size(304, 64);
			this.txt_Intro.TabIndex = 12;
			this.txt_Intro.Text = "";
			// 
			// lbl_Zip
			// 
			this.lbl_Zip.Location = new System.Drawing.Point(16, 232);
			this.lbl_Zip.Name = "lbl_Zip";
			this.lbl_Zip.Size = new System.Drawing.Size(80, 16);
			this.lbl_Zip.TabIndex = 26;
			this.lbl_Zip.Text = "�����ȣ";
			// 
			// txt_Zip2
			// 
			this.txt_Zip2.Location = new System.Drawing.Point(192, 228);
			this.txt_Zip2.Name = "txt_Zip2";
			this.txt_Zip2.ReadOnly = true;
			this.txt_Zip2.Size = new System.Drawing.Size(56, 21);
			this.txt_Zip2.TabIndex = 28;
			this.txt_Zip2.Text = "";
			// 
			// lbl_Dash2
			// 
			this.lbl_Dash2.Location = new System.Drawing.Point(168, 236);
			this.lbl_Dash2.Name = "lbl_Dash2";
			this.lbl_Dash2.Size = new System.Drawing.Size(20, 16);
			this.lbl_Dash2.TabIndex = 29;
			this.lbl_Dash2.Text = "-";
			// 
			// txt_Zip1
			// 
			this.txt_Zip1.Location = new System.Drawing.Point(104, 228);
			this.txt_Zip1.Name = "txt_Zip1";
			this.txt_Zip1.ReadOnly = true;
			this.txt_Zip1.Size = new System.Drawing.Size(56, 21);
			this.txt_Zip1.TabIndex = 9;
			this.txt_Zip1.Text = "";
			// 
			// btn_Zip
			// 
			this.btn_Zip.Location = new System.Drawing.Point(280, 228);
			this.btn_Zip.Name = "btn_Zip";
			this.btn_Zip.Size = new System.Drawing.Size(96, 23);
			this.btn_Zip.TabIndex = 10;
			this.btn_Zip.Text = "�����ȣ ã��";
			this.btn_Zip.Click += new System.EventHandler(this.btn_Zip_Click);
			// 
			// txt_Addr1
			// 
			this.txt_Addr1.Location = new System.Drawing.Point(104, 256);
			this.txt_Addr1.Name = "txt_Addr1";
			this.txt_Addr1.ReadOnly = true;
			this.txt_Addr1.Size = new System.Drawing.Size(296, 21);
			this.txt_Addr1.TabIndex = 31;
			this.txt_Addr1.Text = "";
			// 
			// lbl_Addr
			// 
			this.lbl_Addr.Location = new System.Drawing.Point(16, 256);
			this.lbl_Addr.Name = "lbl_Addr";
			this.lbl_Addr.Size = new System.Drawing.Size(80, 16);
			this.lbl_Addr.TabIndex = 32;
			this.lbl_Addr.Text = "�ּ�";
			// 
			// txt_Addr2
			// 
			this.txt_Addr2.ImeMode = System.Windows.Forms.ImeMode.Hangul;
			this.txt_Addr2.Location = new System.Drawing.Point(104, 280);
			this.txt_Addr2.Name = "txt_Addr2";
			this.txt_Addr2.Size = new System.Drawing.Size(296, 21);
			this.txt_Addr2.TabIndex = 11;
			this.txt_Addr2.Text = "";
			// 
			// lbl_Intro
			// 
			this.lbl_Intro.Location = new System.Drawing.Point(16, 312);
			this.lbl_Intro.Name = "lbl_Intro";
			this.lbl_Intro.Size = new System.Drawing.Size(80, 16);
			this.lbl_Intro.TabIndex = 34;
			this.lbl_Intro.Text = "�ڱ�Ұ�";
			// 
			// btn_Reg
			// 
			this.btn_Reg.Location = new System.Drawing.Point(40, 384);
			this.btn_Reg.Name = "btn_Reg";
			this.btn_Reg.Size = new System.Drawing.Size(160, 24);
			this.btn_Reg.TabIndex = 13;
			this.btn_Reg.Text = "ȸ�� ����";
			this.btn_Reg.Click += new System.EventHandler(this.btn_reg_Click);
			// 
			// btn_Re
			// 
			this.btn_Re.Location = new System.Drawing.Point(224, 384);
			this.btn_Re.Name = "btn_Re";
			this.btn_Re.Size = new System.Drawing.Size(176, 23);
			this.btn_Re.TabIndex = 14;
			this.btn_Re.Text = "�ٽ� ����";
			this.btn_Re.Click += new System.EventHandler(this.btn_re_Click);
			// 
			// lbl_Example
			// 
			this.lbl_Example.Location = new System.Drawing.Point(264, 176);
			this.lbl_Example.Name = "lbl_Example";
			this.lbl_Example.Size = new System.Drawing.Size(160, 16);
			this.lbl_Example.TabIndex = 37;
			this.lbl_Example.Text = "��) 02-123-1234";
			// 
			// lbl_addr2
			// 
			this.lbl_addr2.Location = new System.Drawing.Point(16, 280);
			this.lbl_addr2.Name = "lbl_addr2";
			this.lbl_addr2.Size = new System.Drawing.Size(80, 16);
			this.lbl_addr2.TabIndex = 38;
			this.lbl_addr2.Text = "���ּ�";
			// 
			// lbl_NickName
			// 
			this.lbl_NickName.Location = new System.Drawing.Point(224, 104);
			this.lbl_NickName.Name = "lbl_NickName";
			this.lbl_NickName.Size = new System.Drawing.Size(32, 16);
			this.lbl_NickName.TabIndex = 39;
			this.lbl_NickName.Text = "��Ī";
			// 
			// txt_NickName
			// 
			this.txt_NickName.Location = new System.Drawing.Point(272, 96);
			this.txt_NickName.Name = "txt_NickName";
			this.txt_NickName.Size = new System.Drawing.Size(152, 21);
			this.txt_NickName.TabIndex = 5;
			this.txt_NickName.Text = "";
			// 
			// Reg_Form
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(440, 413);
			this.Controls.Add(this.txt_NickName);
			this.Controls.Add(this.lbl_NickName);
			this.Controls.Add(this.lbl_addr2);
			this.Controls.Add(this.lbl_Example);
			this.Controls.Add(this.btn_Re);
			this.Controls.Add(this.btn_Reg);
			this.Controls.Add(this.lbl_Intro);
			this.Controls.Add(this.txt_Addr2);
			this.Controls.Add(this.lbl_Addr);
			this.Controls.Add(this.txt_Addr1);
			this.Controls.Add(this.btn_Zip);
			this.Controls.Add(this.txt_Zip2);
			this.Controls.Add(this.lbl_Dash2);
			this.Controls.Add(this.txt_Zip1);
			this.Controls.Add(this.lbl_Zip);
			this.Controls.Add(this.txt_Intro);
			this.Controls.Add(this.txt_Email);
			this.Controls.Add(this.txt_Tel);
			this.Controls.Add(this.txt_Ssn2);
			this.Controls.Add(this.txt_Ssn1);
			this.Controls.Add(this.txt_Name);
			this.Controls.Add(this.txt_Pwd_Ok);
			this.Controls.Add(this.txt_Pwd);
			this.Controls.Add(this.btn_ID);
			this.Controls.Add(this.lbl_Dash1);
			this.Controls.Add(this.lbl_Email);
			this.Controls.Add(this.txt_ID);
			this.Controls.Add(this.lbl_Tel);
			this.Controls.Add(this.lbl_Jumin);
			this.Controls.Add(this.lbl_Name);
			this.Controls.Add(this.lbl_Pwd_Ok);
			this.Controls.Add(this.lbl_Pwd);
			this.Controls.Add(this.lbl_ID);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Reg_Form";
			this.Text = "�޽��� ȸ�� ����";
			this.Closed += new System.EventHandler(this.Reg_Form_Closed);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		///  ���̵� �ߺ� �˻� ��ư Ŭ�� �̺�Ʈ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>		
		private void btn_ID_Click(object sender, System.EventArgs e) 
		{
			// ���̵� ��������
			string txt = txt_ID.Text.Trim();
			if( txt == "") 
			{
				MessageBox.Show(" ���̵� �Է��ϼ��� " );
				txt_ID.Focus();
				return ;
			}

			// ���̵� �ߺ� �˻�䱸 �޽��� �ۼ�
			string message = "CTOS_MESSAGE_REGISTER_IDSEARCH\a"+ txt ; 
			// �޽��� ������ ���ڿ� ����
			this.net.Connect(this.ip);
			this.net.Send( message );	
		}

        
		/// <summary>
		/// ���̵� �ߺ��Ǿ����� ó���� �޼���
		/// </summary>
		public void IDCheckOK() 
		{
			// ���̵� �ߺ��Ǹ� �ʱ�ȭ
			txt_ID.Text = "" ; 
			txt_ID.Focus();
		}

		/// <summary>
		/// ȸ�� ���� ��ư Ŭ�� �̺�Ʈ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_reg_Click(object sender, System.EventArgs e) 
		{
			// ȸ�� ���� ���� �޼��� ȣ��
			if(! Authentication()) return ; // ���� ���н� ��ȯ			

			// ȸ�� ���� ���� ���ڿ� �ʱ�ȭ
			string msg = null ;

			msg += "CTOS_MESSAGE_REGISTER_REQUEST\a" ;         // ȸ�� ���� ��û �޽���
			msg += txt_ID.Text.Trim() + "#" ;                  // ���̵�
			msg += txt_Pwd.Text.Trim() + "#" ;                 // ��ȣ
			msg += txt_Name.Text.Trim() + "#" ;                // �̸�
			msg += txt_NickName.Text.Trim() +"#"             ; // ��Ī
			msg +=  txt_Ssn1.Text.Trim() + "-" + txt_Ssn2.Text.Trim() + "#" ;   // �ֹ� ��ȣ
			msg +=  txt_Tel.Text.Trim() + "#" ;                // ��ȭ��ȣ
			msg +=  txt_Email.Text.Trim() + "#" ;              // �̸��� �ּ� 
			msg +=  txt_Zip1.Text.Trim() + "-" + txt_Zip2.Text.Trim() + " " ;   // �����ȣ
			msg +=  txt_Addr1.Text.Trim() + " " + txt_Addr2.Text.Trim() + "#" ; // �ּ�
			msg +=  txt_Intro.Text.Trim() ;                    // �ڱ�Ұ�

			// �޽��� ������ ���ڿ� ����
			this.net.Connect(this.ip);
			this.net.Send( msg ) ;			
		}

		
		/// <summary>
		/// �ٽ� ���� ��ư Ŭ�� �̺�Ʈ 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>	
		private void btn_re_Click(object sender, System.EventArgs e) 
		{
			// ȭ�鿡 �پ� �ִ�  ��Ʈ���� ���� ��ŭ ȣ��
			for( int i = 0; i<Controls.Count ; i++)
				if(Controls[i] is TextBox)  // TextBox ��Ʈ���̸�
					((TextBox)Controls[i]).Text = "" ; // ���ڿ� �ʱ�ȭ
		}
		
		/// <summary>
		/// ���� ��ȣ ã�� ��ư Ŭ�� �̺�Ʈ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Zip_Click(object sender, System.EventArgs e) 
		{	
			this.zipcodewnd = new ZipcodeWnd(this.net, this.ip);
			this.zipcodewnd.ShowDialog();		
             
			string addr = this.zipcodewnd.Addr ;

			this.zipcodewnd.Close();
			
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

		
		private void Reg_Form_Closed(object sender, System.EventArgs e)
		{
			this.net.DisConnect();
		}

	}
}

