using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Threading;

namespace TimeServer
{
	/// <summary>
	/// Form1�� ���� ��� �����Դϴ�.
	/// </summary>
	public class MainWnd : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btn_server;
		private System.Windows.Forms.TextBox txt_info;
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

		#region Windows Form �����̳ʿ��� ������ �ڵ�
		/// <summary>
		/// �����̳� ������ �ʿ��� �޼����Դϴ�.
		/// �� �޼����� ������ �ڵ� ������� �������� ���ʽÿ�.
		/// </summary>
		private void InitializeComponent()
		{
			this.btn_server = new System.Windows.Forms.Button();
			this.txt_info = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btn_server
			// 
			this.btn_server.Location = new System.Drawing.Point(16, 16);
			this.btn_server.Name = "btn_server";
			this.btn_server.Size = new System.Drawing.Size(264, 23);
			this.btn_server.TabIndex = 0;
			this.btn_server.Text = "��������";
			this.btn_server.Click += new System.EventHandler(this.btn_server_Click);
			// 
			// txt_info
			// 
			this.txt_info.Location = new System.Drawing.Point(16, 56);
			this.txt_info.Multiline = true;
			this.txt_info.Name = "txt_info";
			this.txt_info.Size = new System.Drawing.Size(264, 200);
			this.txt_info.TabIndex = 1;
			this.txt_info.Text = "";
			// 
			// MainWnd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.txt_info);
			this.Controls.Add(this.btn_server);
			this.Name = "MainWnd";
			this.Text = "Ÿ�Ӽ���";
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

		public void Add_MSG(string msg)
		{
			txt_info.AppendText(msg + "\r\n");
			txt_info.set
		}

		private void btn_server_Click(object sender, System.EventArgs e)
		{
		
		}

		
	}
}
