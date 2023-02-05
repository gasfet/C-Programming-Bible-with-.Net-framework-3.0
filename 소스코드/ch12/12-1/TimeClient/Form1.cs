using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Net ;
using System.Net.Sockets ;
using System.IO ;

namespace TimeClient
{
	/// <summary>
	/// Form1�� ���� ��� �����Դϴ�.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txt_server;
		private System.Windows.Forms.Button btn_connect;
		private System.Windows.Forms.TextBox txt_time;
		private System.Windows.Forms.Label label2;
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
			this.txt_server = new System.Windows.Forms.TextBox();
			this.btn_connect = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_time = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txt_server
			// 
			this.txt_server.Location = new System.Drawing.Point(56, 152);
			this.txt_server.Name = "txt_server";
			this.txt_server.Size = new System.Drawing.Size(184, 21);
			this.txt_server.TabIndex = 0;
			this.txt_server.Text = "localhost";
			// 
			// btn_connect
			// 
			this.btn_connect.Location = new System.Drawing.Point(56, 184);
			this.btn_connect.Name = "btn_connect";
			this.btn_connect.Size = new System.Drawing.Size(192, 48);
			this.btn_connect.TabIndex = 1;
			this.btn_connect.Text = "����";
			this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(208, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "���� �ð� :";
			// 
			// txt_time
			// 
			this.txt_time.Location = new System.Drawing.Point(48, 64);
			this.txt_time.Name = "txt_time";
			this.txt_time.Size = new System.Drawing.Size(200, 21);
			this.txt_time.TabIndex = 3;
			this.txt_time.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(42, 125);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(208, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Ÿ�� ���� ������ :";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label2,
																		  this.txt_time,
																		  this.label1,
																		  this.btn_connect,
																		  this.txt_server});
			this.Name = "Form1";
			this.Text = "Ÿ�� Ŭ���̾�Ʈ";
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

		private void btn_connect_Click(object sender, System.EventArgs e)
		{
		  TcpClient client = new TcpClient(txt_server.Text.Trim(), 7007);
          NetworkStream stream = client.GetStream();
          StreamReader read = new StreamReader(stream);          
          DateTime data = DateTime.Parse(read.ReadLine());
          txt_time.Text = data.ToLongTimeString().ToString();
		}
	}
}
