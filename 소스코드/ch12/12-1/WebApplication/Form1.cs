using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WebApplication
{
	/// <summary>
	/// Form1에 대한 요약 설명입니다.
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
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
		}

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
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
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
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
			this.btn_back.Text = "뒤로";
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
			this.btn_home.Text = "홈";
			this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
			// 
			// btn_forward
			// 
			this.btn_forward.Location = new System.Drawing.Point(152, 232);
			this.btn_forward.Name = "btn_forward";
			this.btn_forward.Size = new System.Drawing.Size(64, 23);
			this.btn_forward.TabIndex = 4;
			this.btn_forward.Text = "앞으로";
			this.btn_forward.Click += new System.EventHandler(this.btn_forward_Click);
			// 
			// btn_search
			// 
			this.btn_search.Location = new System.Drawing.Point(336, 262);
			this.btn_search.Name = "btn_search";
			this.btn_search.TabIndex = 5;
			this.btn_search.Text = "이동";
			this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
			// 
			// btn_stop
			// 
			this.btn_stop.Location = new System.Drawing.Point(248, 232);
			this.btn_stop.Name = "btn_stop";
			this.btn_stop.Size = new System.Drawing.Size(72, 23);
			this.btn_stop.TabIndex = 6;
			this.btn_stop.Text = "정지";
			this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
			// 
			// btn_refresh
			// 
			this.btn_refresh.Location = new System.Drawing.Point(336, 232);
			this.btn_refresh.Name = "btn_refresh";
			this.btn_refresh.TabIndex = 7;
			this.btn_refresh.Text = "새로고침";
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
			this.Text = "웹과 애플리케이션 연동";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.axWebBrowser1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.Navigate();  // 사용자 정의 메서드
		}

		private void btn_search_Click(object sender, System.EventArgs e)
		{
		    this.Navigate(); // 사용자 정의 메서드
		}

		private void Navigate()
		{
			object o = null;
			axWebBrowser1.Navigate(txt_url.Text.Trim(), ref o, ref o, ref o, ref o); 
			this.Text = txt_url.Text.Trim();
		}

		private void btn_back_Click(object sender, System.EventArgs e)
		{
		   axWebBrowser1.GoBack();	// 뒤로
		}

		private void btn_home_Click(object sender, System.EventArgs e)
		{
			axWebBrowser1.GoHome(); // 홈으로
		}

		private void btn_forward_Click(object sender, System.EventArgs e)
		{
			axWebBrowser1.GoForward(); // 앞으로
		}

		private void btn_stop_Click(object sender, System.EventArgs e)
		{
			axWebBrowser1.Stop(); // 정지
		}

		private void btn_refresh_Click(object sender, System.EventArgs e)
		{
			axWebBrowser1.Refresh(); // 새로고침
		}
	}
}
