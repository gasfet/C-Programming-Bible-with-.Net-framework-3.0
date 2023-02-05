
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Net ;
using System.Net.Sockets ;
using System.Text ;
using System.IO ;

namespace WebInfo
{
	/// <summary>
	/// Form1�� ���� ��� �����Դϴ�.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txt_addr;
		private System.Windows.Forms.Button btn_check;
		private System.Windows.Forms.TextBox txt_info;
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows Form �����̳� ������ �ʿ��մϴ�.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent�� ȣ���� ���� ������ �ڵ带 �߰��մϴ�.
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// �����̳� ������ �ʿ��� �޼����Դϴ�.
		/// �� �޼����� ������ �ڵ� ������� �������� ���ʽÿ�.
		/// </summary>
		private void InitializeComponent()
		{
			this.txt_addr = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_check = new System.Windows.Forms.Button();
			this.txt_info = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txt_addr
			// 
			this.txt_addr.Location = new System.Drawing.Point(48, 56);
			this.txt_addr.Name = "txt_addr";
			this.txt_addr.Size = new System.Drawing.Size(208, 21);
			this.txt_addr.TabIndex = 0;
			this.txt_addr.Text = "www.magicsoft.pe.kr";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(48, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "�˻��� �� ����Ʈ";
			// 
			// btn_check
			// 
			this.btn_check.Location = new System.Drawing.Point(48, 88);
			this.btn_check.Name = "btn_check";
			this.btn_check.Size = new System.Drawing.Size(208, 23);
			this.btn_check.TabIndex = 2;
			this.btn_check.Text = "�˻�";
			this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
			// 
			// txt_info
			// 
			this.txt_info.Location = new System.Drawing.Point(40, 128);
			this.txt_info.Multiline = true;
			this.txt_info.Name = "txt_info";
			this.txt_info.Size = new System.Drawing.Size(216, 224);
			this.txt_info.TabIndex = 3;
			this.txt_info.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(288, 373);
			this.Controls.Add(this.txt_info);
			this.Controls.Add(this.btn_check);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txt_addr);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �ش� ���� ���α׷��� �� �������Դϴ�.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		
		private void btn_check_Click(object sender, System.EventArgs e)
		{
		
			TcpClient client = new TcpClient();
			try
			{
				client.Connect( txt_addr.Text.Trim() , 80); // ������ ����
			}
			catch
			{
				MessageBox.Show(" ������ ���� �� �� �����ϴ�.");
			}

			Stream stream = client.GetStream();
             
			string msg = "GET /index.html HTTP/1.0\r\n\n" ;			

			Byte [] byteSend = Encoding.Default.GetBytes(msg.ToCharArray());

			stream.Write(byteSend, 0, byteSend.Length );

			stream.Flush();

            
			byte []  response = new byte[256];
			int size = stream.Read( response, 0 , response.Length);
						

			txt_info.AppendText (" ���� ����Ʈ �� : "+ size +" Byte \r\n");
			txt_info.AppendText ("�������� ������ �޽��� --->\r\n\r\n ");
			txt_info.AppendText ( Encoding.Default.GetString( response));

		}
	}
}
