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
	/// Form1에 대한 요약 설명입니다.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txt_server;
		private System.Windows.Forms.Button btn_connect;
		private System.Windows.Forms.TextBox txt_time;
		private System.Windows.Forms.Label label2;
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
			this.btn_connect.Text = "접속";
			this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(208, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "현재 시간 :";
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
			this.label2.Text = "타임 서버 아이피 :";
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
			this.Text = "타임 클라이언트";
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
