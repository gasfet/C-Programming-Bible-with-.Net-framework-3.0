using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WebApplication
{
	/// <summary>
	/// Form1�� ���� ��� �����Դϴ�.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private AxSHDocVw.AxWebBrowser axWebBrowser1;
		private System.Windows.Forms.Button btn_back;
		private System.Windows.Forms.TextBox txt_url;
		private System.Windows.Forms.Button btn_home;
		private System.Windows.Forms.Button btn_forward;
		private System.Windows.Forms.Button btn_search;
		private System.Windows.Forms.Button btn_stop;
		private System.Windows.Forms.Button btn_refresh;
		private System.Windows.Forms.MainMenu mainMenu1;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.axWebBrowser1 = new AxSHDocVw.AxWebBrowser();
			this.btn_back = new System.Windows.Forms.Button();
			this.txt_url = new System.Windows.Forms.TextBox();
			this.btn_home = new System.Windows.Forms.Button();
			this.btn_forward = new System.Windows.Forms.Button();
			this.btn_search = new System.Windows.Forms.Button();
			this.btn_stop = new System.Windows.Forms.Button();
			this.btn_refresh = new System.Windows.Forms.Button();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			((System.ComponentModel.ISupportInitialize)(this.axWebBrowser1)).BeginInit();
			this.SuspendLayout();
			// 
			// axWebBrowser1
			// 
			this.axWebBrowser1.Enabled = true;
			this.axWebBrowser1.Location = new System.Drawing.Point(8, 16);
			this.axWebBrowser1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWebBrowser1.OcxState")));
			this.axWebBrowser1.Size = new System.Drawing.Size(392, 208);
			this.axWebBrowser1.TabIndex = 0;
			// 
			// btn_back
			// 
			this.btn_back.Location = new System.Drawing.Point(8, 232);
			this.btn_back.Name = "btn_back";
			this.btn_back.Size = new System.Drawing.Size(72, 23);
			this.btn_back.TabIndex = 1;
			this.btn_back.Text = "�ڷ�";
			this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
			// 
			// txt_url
			// 
			this.txt_url.Location = new System.Drawing.Point(8, 261);
			this.txt_url.Name = "txt_url";
			this.txt_url.Size = new System.Drawing.Size(320, 21);
			this.txt_url.TabIndex = 2;
			this.txt_url.Text = "www.youngjin.com";
			// 
			// btn_home
			// 
			this.btn_home.Location = new System.Drawing.Point(88, 232);
			this.btn_home.Name = "btn_home";
			this.btn_home.Size = new System.Drawing.Size(56, 23);
			this.btn_home.TabIndex = 3;
			this.btn_home.Text = "Ȩ";
			this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
			// 
			// btn_forward
			// 
			this.btn_forward.Location = new System.Drawing.Point(152, 232);
			this.btn_forward.Name = "btn_forward";
			this.btn_forward.Size = new System.Drawing.Size(64, 23);
			this.btn_forward.TabIndex = 4;
			this.btn_forward.Text = "������";
			this.btn_forward.Click += new System.EventHandler(this.btn_forward_Click);
			// 
			// btn_search
			// 
			this.btn_search.Location = new System.Drawing.Point(336, 262);
			this.btn_search.Name = "btn_search";
			this.btn_search.TabIndex = 5;
			this.btn_search.Text = "�̵�";
			this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
			// 
			// btn_stop
			// 
			this.btn_stop.Location = new System.Drawing.Point(248, 232);
			this.btn_stop.Name = "btn_stop";
			this.btn_stop.Size = new System.Drawing.Size(72, 23);
			this.btn_stop.TabIndex = 6;
			this.btn_stop.Text = "����";
			this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
			// 
			// btn_refresh
			// 
			this.btn_refresh.Location = new System.Drawing.Point(336, 232);
			this.btn_refresh.Name = "btn_refresh";
			this.btn_refresh.TabIndex = 7;
			this.btn_refresh.Text = "���ΰ�ħ";
			this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(416, 285);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btn_refresh,
																		  this.btn_stop,
																		  this.btn_search,
																		  this.btn_forward,
																		  this.btn_home,
																		  this.txt_url,
																		  this.btn_back,
																		  this.axWebBrowser1});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "���� ���ø����̼� ����";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.axWebBrowser1)).EndInit();
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.Navigate();  // ����� ���� �޼���
		}

		private void btn_search_Click(object sender, System.EventArgs e)
		{
		    this.Navigate(); // ����� ���� �޼���
		}

		private void Navigate()
		{
			object o = null;
			axWebBrowser1.Navigate(txt_url.Text.Trim(), ref o, ref o, ref o, ref o); 
			this.Text = txt_url.Text.Trim();
		}

		private void btn_back_Click(object sender, System.EventArgs e)
		{
		   axWebBrowser1.GoBack();	// �ڷ�
		}

		private void btn_home_Click(object sender, System.EventArgs e)
		{
			axWebBrowser1.GoHome(); // Ȩ����
		}

		private void btn_forward_Click(object sender, System.EventArgs e)
		{
			axWebBrowser1.GoForward(); // ������
		}

		private void btn_stop_Click(object sender, System.EventArgs e)
		{
			axWebBrowser1.Stop(); // ����
		}

		private void btn_refresh_Click(object sender, System.EventArgs e)
		{
			axWebBrowser1.Refresh(); // ���ΰ�ħ
		}
	}
}
