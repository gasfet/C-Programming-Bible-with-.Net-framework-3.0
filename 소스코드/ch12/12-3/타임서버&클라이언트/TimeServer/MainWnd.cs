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
	/// Form1에 대한 요약 설명입니다.
	/// </summary>
	public class MainWnd : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btn_server;
		private System.Windows.Forms.TextBox txt_info;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainWnd()
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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
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
			this.btn_server.Text = "서버시작";
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
			this.Text = "타임서버";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
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
