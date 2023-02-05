using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Diagnostics;

namespace MemberReg
{
	/// <summary>
	/// Form1�� ���� ��� �����Դϴ�.
	/// </summary>
	public class MainWnd : System.Windows.Forms.Form
	{
		private Network net = null;
		
		private string  my_ip = null;

		private System.Windows.Forms.TextBox txt_Info;
		private System.Windows.Forms.TextBox txt_IP;
		private System.Windows.Forms.Label lbl_Info;
		private System.Windows.Forms.Button btn_Reg;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lbl_Server;
		private System.Windows.Forms.TextBox txt_ID;
		private System.Windows.Forms.Label lbl_Pwd;
		private System.Windows.Forms.TextBox txt_Pwd;
		private System.Windows.Forms.Button btn_Login;
		private System.Windows.Forms.Label lbl_ID;
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainWnd()
		{			
			InitializeComponent();

			// ��Ʈ��ũ Ŭ���� ��ü ����
			this.net = new Network(this);				

			my_ip = net.Get_MyIP();			
		}

		/// <summary>
		/// ��� ���� ��� ���ҽ��� �����մϴ�.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.txt_Info = new System.Windows.Forms.TextBox();
			this.txt_IP = new System.Windows.Forms.TextBox();
			this.lbl_Info = new System.Windows.Forms.Label();
			this.btn_Reg = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbl_Pwd = new System.Windows.Forms.Label();
			this.txt_Pwd = new System.Windows.Forms.TextBox();
			this.txt_ID = new System.Windows.Forms.TextBox();
			this.btn_Login = new System.Windows.Forms.Button();
			this.lbl_Server = new System.Windows.Forms.Label();
			this.lbl_ID = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txt_Info
			// 
			this.txt_Info.Location = new System.Drawing.Point(8, 208);
			this.txt_Info.Multiline = true;
			this.txt_Info.Name = "txt_Info";
			this.txt_Info.ReadOnly = true;
			this.txt_Info.Size = new System.Drawing.Size(272, 128);
			this.txt_Info.TabIndex = 2;
			this.txt_Info.Text = "";
			// 
			// txt_IP
			// 
			this.txt_IP.Location = new System.Drawing.Point(104, 24);
			this.txt_IP.Name = "txt_IP";
			this.txt_IP.Size = new System.Drawing.Size(144, 21);
			this.txt_IP.TabIndex = 3;
			this.txt_IP.Text = "192.168.0.2";
			// 
			// lbl_Info
			// 
			this.lbl_Info.Location = new System.Drawing.Point(16, 176);
			this.lbl_Info.Name = "lbl_Info";
			this.lbl_Info.Size = new System.Drawing.Size(112, 23);
			this.lbl_Info.TabIndex = 4;
			this.lbl_Info.Text = "����� ���� â";
			// 
			// btn_Reg
			// 
			this.btn_Reg.Location = new System.Drawing.Point(136, 168);
			this.btn_Reg.Name = "btn_Reg";
			this.btn_Reg.Size = new System.Drawing.Size(136, 32);
			this.btn_Reg.TabIndex = 1;
			this.btn_Reg.Text = "ȸ�� ����";
			this.btn_Reg.Click += new System.EventHandler(this.btn_Reg_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lbl_Pwd);
			this.groupBox1.Controls.Add(this.txt_Pwd);
			this.groupBox1.Controls.Add(this.txt_ID);
			this.groupBox1.Controls.Add(this.btn_Login);
			this.groupBox1.Controls.Add(this.lbl_Server);
			this.groupBox1.Controls.Add(this.txt_IP);
			this.groupBox1.Controls.Add(this.lbl_ID);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(264, 152);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "���� ����";
			// 
			// lbl_Pwd
			// 
			this.lbl_Pwd.Location = new System.Drawing.Point(16, 94);
			this.lbl_Pwd.Name = "lbl_Pwd";
			this.lbl_Pwd.Size = new System.Drawing.Size(72, 16);
			this.lbl_Pwd.TabIndex = 8;
			this.lbl_Pwd.Text = "��й�ȣ :";
			// 
			// txt_Pwd
			// 
			this.txt_Pwd.Location = new System.Drawing.Point(104, 93);
			this.txt_Pwd.Name = "txt_Pwd";
			this.txt_Pwd.PasswordChar = '*';
			this.txt_Pwd.Size = new System.Drawing.Size(144, 21);
			this.txt_Pwd.TabIndex = 2;
			this.txt_Pwd.Text = "";
			// 
			// txt_ID
			// 
			this.txt_ID.Location = new System.Drawing.Point(104, 64);
			this.txt_ID.Name = "txt_ID";
			this.txt_ID.Size = new System.Drawing.Size(144, 21);
			this.txt_ID.TabIndex = 1;
			this.txt_ID.Text = "";
			// 
			// btn_Login
			// 
			this.btn_Login.Location = new System.Drawing.Point(16, 120);
			this.btn_Login.Name = "btn_Login";
			this.btn_Login.Size = new System.Drawing.Size(232, 23);
			this.btn_Login.TabIndex = 3;
			this.btn_Login.Text = "�α���";
			this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
			// 
			// lbl_Server
			// 
			this.lbl_Server.Location = new System.Drawing.Point(16, 26);
			this.lbl_Server.Name = "lbl_Server";
			this.lbl_Server.Size = new System.Drawing.Size(72, 16);
			this.lbl_Server.TabIndex = 4;
			this.lbl_Server.Text = "���� ������";
			// 
			// lbl_ID
			// 
			this.lbl_ID.Location = new System.Drawing.Point(16, 70);
			this.lbl_ID.Name = "lbl_ID";
			this.lbl_ID.Size = new System.Drawing.Size(72, 16);
			this.lbl_ID.TabIndex = 7;
			this.lbl_ID.Text = "���̵� :";
			// 
			// MainWnd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(288, 349);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btn_Reg);
			this.Controls.Add(this.lbl_Info);
			this.Controls.Add(this.txt_Info);
			this.Name = "MainWnd";
			this.Text = "ȸ�� ���� Ŭ���̾�Ʈ 1.0";
			this.Closed += new System.EventHandler(this.MainChat_Closed);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �ش� ���� ���α׷��� �� �������Դϴ�.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainWnd());
		}

		
		/// <summary>
		/// �޽��� �߰�
		/// </summary>
		/// <param name="msg">�޽���</param>		
		public void Add_MSG(string msg)
		{
			this.txt_Info.AppendText(msg+"\r\n");
			this.txt_Info.ScrollToCaret();	
		}
	
		
		
		private void MainChat_Closed(object sender, System.EventArgs e)
		{
			if(this.net != null)
			  this.net.DisConnect();
		}

		private void btn_Reg_Click(object sender, System.EventArgs e)
		{
			string ip = txt_IP.Text.Trim();			
			if(ip == "")
			{
				MessageBox.Show("������ ��ȣ�� �Է��ϼ���!");
				return ;			
			}

			Reg_Form dlg = new Reg_Form(this, ip); // ȸ�� ����â ����
			dlg.ShowDialog();
			
		}

		private void btn_Login_Click(object sender, System.EventArgs e)
		{
			string ip = txt_IP.Text.Trim();			
			string id = txt_ID.Text.Trim();
			string pwd = txt_Pwd.Text.Trim();

			if(ip == "")
			{
				MessageBox.Show("������ ��ȣ�� �Է��ϼ���!", "�����޽���");
				return ;			
			}
			if(id == "")
			{
				MessageBox.Show("���̵� �Է��ϼ���!", "�����޽���");
				return ;			
			}
			if(pwd == "")
			{
				MessageBox.Show("��й�ȣ�� �Է��ϼ���!", "�����޽���");
				return ;			
			}

			this.net.Connect(ip);   // ���� ����
            
			string msg = "CTOS_MESSAGE_LOGIN_REQUEST\a";
			msg += id + "\a";       // ȸ�� ���̵�
			msg += pwd + "\a";      // ȸ�� ��й�ȣ

			this.net.Send(msg);
		}

		

			

	}
}
