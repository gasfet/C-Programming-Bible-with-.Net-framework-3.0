using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;

namespace MemberServer
{
	/// <summary>
	/// EditMember�� ���� ��� �����Դϴ�.
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
		/// �ʼ� �����̳� �����Դϴ�.
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
			this.btn_Close.Text = "â �ݱ�";
			this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
			// 
			// lbl_NickName
			// 
			this.lbl_NickName.Location = new System.Drawing.Point(24, 88);
			this.lbl_NickName.Name = "lbl_NickName";
			this.lbl_NickName.Size = new System.Drawing.Size(32, 16);
			this.lbl_NickName.TabIndex = 106;
			this.lbl_NickName.Text = "��Ī";
			// 
			// lbl_Example
			// 
			this.lbl_Example.Location = new System.Drawing.Point(272, 128);
			this.lbl_Example.Name = "lbl_Example";
			this.lbl_Example.Size = new System.Drawing.Size(160, 16);
			this.lbl_Example.TabIndex = 104;
			this.lbl_Example.Text = "��) 02-123-1234";
			// 
			// btn_Edit
			// 
			this.btn_Edit.Location = new System.Drawing.Point(16, 328);
			this.btn_Edit.Name = "btn_Edit";
			this.btn_Edit.Size = new System.Drawing.Size(200, 24);
			this.btn_Edit.TabIndex = 8;
			this.btn_Edit.Text = "ȸ�� ���� ����";
			this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
			// 
			// lbl_Intro
			// 
			this.lbl_Intro.Location = new System.Drawing.Point(24, 248);
			this.lbl_Intro.Name = "lbl_Intro";
			this.lbl_Intro.Size = new System.Drawing.Size(80, 16);
			this.lbl_Intro.TabIndex = 103;
			this.lbl_Intro.Text = "�ڱ�Ұ�";
			// 
			// lbl_Addr
			// 
			this.lbl_Addr.Location = new System.Drawing.Point(24, 211);
			this.lbl_Addr.Name = "lbl_Addr";
			this.lbl_Addr.Size = new System.Drawing.Size(80, 16);
			this.lbl_Addr.TabIndex = 102;
			this.lbl_Addr.Text = "�ּ�";
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
			this.lbl_Email.Text = "E-�����ּ�";
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
			this.lbl_Tel.Text = "��ȭ��ȣ";
			// 
			// lbl_Pwd
			// 
			this.lbl_Pwd.Location = new System.Drawing.Point(24, 64);
			this.lbl_Pwd.Name = "lbl_Pwd";
			this.lbl_Pwd.Size = new System.Drawing.Size(80, 16);
			this.lbl_Pwd.TabIndex = 77;
			this.lbl_Pwd.Text = "��й�ȣ";
			// 
			// lbl_ID
			// 
			this.lbl_ID.Location = new System.Drawing.Point(24, 21);
			this.lbl_ID.Name = "lbl_ID";
			this.lbl_ID.Size = new System.Drawing.Size(80, 16);
			this.lbl_ID.TabIndex = 75;
			this.lbl_ID.Text = "���̵�";
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
			this.lbl_Name.Text = "�̸�";
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
			this.btn_Zip.Text = "�����ȣ ã��";
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
			this.lbl_Zip.Text = "�����ȣ";
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
			this.Text = "ȸ�� ���� ����";
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
		/// ȸ�� ���� ���� �޼���
		/// </summary>
		/// <returns></returns> 
		private bool  Authentication() 
		{
			// ���� ���ڿ� ����
			string ErrorMessage = "" ;     	    
			// ��ȣ üũ
			if( txt_Pwd.Text.Length < 5 || txt_ID.Text.Length >16 )
				ErrorMessage += "- ��ȣ�� 5�� �̻� 16�� ���� �Դϴ�.\n\n" ;
			else if( !A_or_D(txt_Pwd.Text.Trim()))
				ErrorMessage += "- ��ȣ�� ���� �Ǵ� ���ڸ� �Է��ؾ� �մϴ�.!\n\n" ;
			
			// ��Ī üũ
			if( txt_NickName.Text.Trim() == "")
				ErrorMessage += "- ��Ī�� �Է����ּ���!\n\n" ;
			else if( txt_NickName.Text.Length > 100)
				ErrorMessage += "- ��Ī�� 100���ھȿ��� �Է����ּ���.\n\n" ;

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
			if(txt_Addr.Text.Trim() == "") 
				ErrorMessage += "- �ּҸ� �Է��ϼ���.\n\n";
			
			// ���� ���ڿ� üũ
			if( ErrorMessage != "") 
			{
				MessageBox.Show(ErrorMessage, "��� ����", MessageBoxButtons.OK, MessageBoxIcon.Error   );
				return false ;
			}
			
			return true ;
		}


		private void InitDialog()
		{
			try
			{			
				DataRow dr = ds.Tables["Member"].Rows[this.index];   // �����ͼ¿��� �ప ��������

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
				// ȸ�� ���� ���� �޼��� ȣ��
				if(! Authentication()) return ; // ���� ���н� ��ȯ	

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

				MessageBox.Show("ȸ�� ���� ���� ����!");
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
