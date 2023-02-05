using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


using System.Net ;
using System.Net.Sockets ;
using System.IO ;
using System.Threading ;

namespace TimeServer
{
	/// <summary>
	/// Form1에 대한 요약 설명입니다.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{

        public NetworkStream stream ; // 네트워크 스트림
        
		public const int port = 7007 ; // 타임 서버 포트

		TcpListener listener = null ; // TCP리스너

		StreamWriter write = null ;  // 쓰기 스트림

		Thread th = null ;           // 스레드 

		private System.Windows.Forms.Button btn_start;
		private System.Windows.Forms.Button btn_stop;
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
			this.btn_start = new System.Windows.Forms.Button();
			this.btn_stop = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_start
			// 
			this.btn_start.Location = new System.Drawing.Point(72, 24);
			this.btn_start.Name = "btn_start";
			this.btn_start.Size = new System.Drawing.Size(168, 40);
			this.btn_start.TabIndex = 0;
			this.btn_start.Text = "타임 서버 시작";
			this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
			// 
			// btn_stop
			// 
			this.btn_stop.Enabled = false;
			this.btn_stop.Location = new System.Drawing.Point(72, 88);
			this.btn_stop.Name = "btn_stop";
			this.btn_stop.Size = new System.Drawing.Size(168, 40);
			this.btn_stop.TabIndex = 1;
			this.btn_stop.Text = "타임 서버 종료";
			this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(304, 157);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btn_stop,
																		  this.btn_start});
			this.Name = "Form1";
			this.Text = "타임 서버";
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


		void Accept()
		{
			try
			{
				listener = new TcpListener(port);
				listener.Start();
			}
			catch(Exception ex)
			{
				MessageBox.Show("에러메시지 :"+ ex.StackTrace);
			}
			
			btn_start.Enabled = false ;
			btn_stop.Enabled = true ;

			Socket client = listener.AcceptSocket();
			
			if(client.Connected)
			{
				stream = new NetworkStream(client);
				write = new StreamWriter(stream);
				write.WriteLine(DateTime.Now); // 현재 시간 전송
				write.Flush();
			}
		}

		void Stop()
		{
			try
			{
				listener.Stop();
			}
			catch(Exception ex)
			{
				MessageBox.Show("에러메시지 :"+ ex.StackTrace);
			}
			btn_stop.Enabled = false ;
			btn_start.Enabled = true ;
		}
		

		private void btn_start_Click(object sender, System.EventArgs e)
		{
			th = new Thread(new ThreadStart(Accept));
			th.Start();

		}

		private void btn_stop_Click(object sender, System.EventArgs e)
		{
			this.Stop();   // 리스너 종료
			try
			{
				th.Abort(); // 스레드 종료
			}
			catch
			{
			}
		}
	}
}
