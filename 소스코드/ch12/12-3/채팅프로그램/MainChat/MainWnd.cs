using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Threading;

namespace MainChat
{
	/// <summary>
	/// Form1�� ���� ��� �����Դϴ�.
	/// </summary>
	public class MainWnd : System.Windows.Forms.Form
	{

		private Network net = null;
		private Thread  server_th = null;
		private string  my_ip = null;
		private bool    newtxtsend = false;		

		public Font chat_font = new Font("����ü",10); // ä�� �⺻ �۲� ����
		public Color chat_color = Color.Black  ;       // ä�� �۲� ����

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btn_Font;
		private System.Windows.Forms.Button btn_Server;
		private System.Windows.Forms.TextBox txt_Input;
		private System.Windows.Forms.Label lbl_Ip;
		private System.Windows.Forms.Button btn_Connect;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.RichTextBox txt_Info;
		private System.Windows.Forms.TextBox txt_IP;
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainWnd()
		{
			//
			// Windows Form �����̳� ������ �ʿ��մϴ�.
			//
			InitializeComponent();

			net   = new Network(this);
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
			this.btn_Server = new System.Windows.Forms.Button();
			this.txt_Input = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbl_Ip = new System.Windows.Forms.Label();
			this.txt_IP = new System.Windows.Forms.TextBox();
			this.btn_Connect = new System.Windows.Forms.Button();
			this.btn_Font = new System.Windows.Forms.Button();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.txt_Info = new System.Windows.Forms.RichTextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_Server
			// 
			this.btn_Server.Location = new System.Drawing.Point(24, 24);
			this.btn_Server.Name = "btn_Server";
			this.btn_Server.Size = new System.Drawing.Size(103, 28);
			this.btn_Server.TabIndex = 21;
			this.btn_Server.Text = "���� ����";
			this.btn_Server.Click += new System.EventHandler(this.btn_server_Click);
			// 
			// txt_Input
			// 
			this.txt_Input.ImeMode = System.Windows.Forms.ImeMode.Hangul;
			this.txt_Input.Location = new System.Drawing.Point(8, 304);
			this.txt_Input.Name = "txt_Input";
			this.txt_Input.Size = new System.Drawing.Size(232, 21);
			this.txt_Input.TabIndex = 23;
			this.txt_Input.Text = "";
			this.txt_Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_input_KeyDown);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lbl_Ip);
			this.groupBox1.Controls.Add(this.txt_IP);
			this.groupBox1.Controls.Add(this.btn_Connect);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 80);
			this.groupBox1.TabIndex = 22;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "�ɼ�";
			// 
			// lbl_Ip
			// 
			this.lbl_Ip.Location = new System.Drawing.Point(16, 56);
			this.lbl_Ip.Name = "lbl_Ip";
			this.lbl_Ip.Size = new System.Drawing.Size(72, 16);
			this.lbl_Ip.TabIndex = 15;
			this.lbl_Ip.Text = "����������";
			// 
			// txt_IP
			// 
			this.txt_IP.Location = new System.Drawing.Point(88, 56);
			this.txt_IP.Name = "txt_IP";
			this.txt_IP.Size = new System.Drawing.Size(136, 21);
			this.txt_IP.TabIndex = 14;
			this.txt_IP.Text = "192.168.0.2";
			// 
			// btn_Connect
			// 
			this.btn_Connect.Location = new System.Drawing.Point(120, 16);
			this.btn_Connect.Name = "btn_Connect";
			this.btn_Connect.Size = new System.Drawing.Size(104, 28);
			this.btn_Connect.TabIndex = 13;
			this.btn_Connect.Text = "���� ����";
			this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
			// 
			// btn_Font
			// 
			this.btn_Font.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btn_Font.Location = new System.Drawing.Point(8, 272);
			this.btn_Font.Name = "btn_Font";
			this.btn_Font.Size = new System.Drawing.Size(232, 25);
			this.btn_Font.TabIndex = 25;
			this.btn_Font.Text = "��Ʈ";
			this.btn_Font.Click += new System.EventHandler(this.btn_Font_Click);
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 335);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(248, 22);
			this.statusBar.TabIndex = 26;
			// 
			// txt_Info
			// 
			this.txt_Info.Location = new System.Drawing.Point(8, 96);
			this.txt_Info.Name = "txt_Info";
			this.txt_Info.Size = new System.Drawing.Size(232, 168);
			this.txt_Info.TabIndex = 27;
			this.txt_Info.Text = "";
			// 
			// MainWnd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(248, 357);
			this.Controls.Add(this.txt_Info);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.btn_Font);
			this.Controls.Add(this.btn_Server);
			this.Controls.Add(this.txt_Input);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainWnd";
			this.Text = "�޽��� ��Ģ 1:1 ä��";
			this.Closed += new System.EventHandler(this.MainWnd_Closed);
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


		public void SetTextInfo(string msg)
		{
            string [] token = msg.Split('/');
          
			string font = token[0];
			float  size = float.Parse(token[1]) ;
			string font_styles = token[2].Trim();

			// �۲� ��Ÿ�� ����
			FontStyle style = FontStyle.Regular ;

			string [] token2 = font_styles.Split(',');
			
			foreach (string font_style in token2)
			{
				// '|'�������� �����Ͽ� ����
				switch(font_style.Trim()) 
				{
					case "Bold":
						style |= FontStyle.Bold ;
						break;
					case "Italic":
						style |= FontStyle.Italic ; 
						break;
					case "Regular":
						style |= FontStyle.Regular;
						break;
					case "Strikeout":
						style |= FontStyle.Strikeout ;
						break;
					case "Underline":
						style |= FontStyle.Underline ;
						break;
				}
			}
			
			// �۲� ����
			this.txt_Info.SelectionFont = new Font(font, size, style);  			  
		}
		

		public void SetTextColor(string msg)
		{
           string [] token = msg.Split('/');
		   byte red = Convert.ToByte(token[0]);
		   byte green = Convert.ToByte(token[1]);
		   byte blue = Convert.ToByte(token[2]);

		   txt_Info.SelectionColor = Color.FromArgb(red, green, blue);
		}
		/// <summary>
		/// ���ڿ� ���� ���
		/// </summary>
		/// <param name="msg">���ڿ�</param>
		public void Add_MSG(string msg)
		{
			this.txt_Info.AppendText(msg+"\r\n");
			this.txt_Info.ScrollToCaret();	
			this.txt_Input.Focus();
		}
        
		/// <summary>
		/// ���¹ٿ� �޽��� ���
		/// </summary>
		/// <param name="msg"></param>
		public void  Add_Status(string msg)
		{
			this.statusBar.Text = msg;
		}


		private void btn_server_Click(object sender, System.EventArgs e)
		{
			try
			{			
				if ( btn_Server.Text == "���� ����" )
				{
					server_th = new Thread(new ThreadStart(this.net.ServerStart));
					server_th.Start();	

					btn_Server.Text = "���� ����";
				}
				else
				{   					
					this.net.ServerStop();

					if(server_th.IsAlive) 
						server_th.Abort();	
				
					btn_Server.Text = "���� ����"; 
				}
			}
			catch(Exception ex)
			{
				this.Add_MSG(ex.Message);
			}
		}

		private void btn_Connect_Click(object sender, System.EventArgs e)
		{
			if(btn_Connect.Text == "���� ����")
			{
				string ip = txt_IP.Text.Trim();			
				if(ip == "")
				{
					MessageBox.Show("������ ��ȣ�� �Է��ϼ���!");
					return ;
				}

				if(!this.net.Connect(ip))
				{
					MessageBox.Show("���� ������ ��ȣ�� Ʋ���ų�\r\n ������ �۵������� �ʽ��ϴ�.");
				}
				else 
				{
					btn_Connect.Text = "������...";   // ������ �����ϸ�...
				}
			}
			else
			{
				this.net.DisConnect();
				btn_Connect.Text = "���� ����";
			}
		}

		private void txt_input_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			// ����Ű�� ������ ���ڿ� �޽��� ����
			if( e.KeyCode == Keys.Enter )
			{
				string chat_msg = txt_Input.Text.Trim();

				string msg = "CTOC_CHAT_MESSAGE_INFO\a" ;
				
				msg += "CTOC_CHAT_MESSAGE_FONT#" 
					  + chat_font.Name + "/" + chat_font.Size + "/" 
					  + chat_font.Style.ToString();

				msg += "#CTOC_CHAT_MESSAGE_COLOR#"
					   + chat_color.R + "/" + chat_color.G + "/" + chat_color.B ;

				msg += "#CTOC_CHAT_MESSAGE_TEXT#"
					   + chat_msg;

				this.net.Send(msg);


				this.txt_Info.SelectionFont = this.chat_font;
				this.txt_Info.SelectionColor = this.chat_color;

				this.Add_MSG("[" + my_ip + "] " + chat_msg);				
				this.newtxtsend = false;
				txt_Input.Text = "";
				txt_Input.Focus();
			}
			else  // �� ���ڿ� �Է� ��ȣ �����ϴ� �κ�
			{
				if (newtxtsend == false) 
				{	
					// ���ο� ���ڿ� ��ȣ ����
					this.net.Send("CTOC_CHAT_NEWTEXT_INFO\a");                       
					newtxtsend = true;					               
				}
			}
		}

		private void MainWnd_Closed(object sender, System.EventArgs e)
		{
			try
			{
				if(btn_Connect.Text == "������...")
				{
					this.net.DisConnect();				
				} 
           
				this.net.ServerStop();

				if((server_th != null) && (server_th.IsAlive)) 
					server_th.Abort();			
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}			
		}

		private void btn_Font_Click(object sender, System.EventArgs e)
		{
			
			FontDialog dlg = new FontDialog();
			dlg.ShowColor = true ;              // �� ����
			
			dlg.Font = this.chat_font;
			dlg.Color = this.chat_color;


			if(dlg.ShowDialog() == DialogResult.OK)
			{				
                this.txt_Input.Font = dlg.Font;
                this.txt_Input.ForeColor = dlg.Color;
				this.chat_font = dlg.Font;
				this.chat_color = dlg.Color;
			}
		}

	}
}
