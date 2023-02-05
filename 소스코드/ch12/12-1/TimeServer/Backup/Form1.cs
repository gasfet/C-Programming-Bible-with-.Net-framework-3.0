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
	/// Form1�� ���� ��� �����Դϴ�.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{

        public NetworkStream stream ; // ��Ʈ��ũ ��Ʈ��
        
		public const int port = 7007 ; // Ÿ�� ���� ��Ʈ

		TcpListener listener = null ; // TCP������

		StreamWriter write = null ;  // ���� ��Ʈ��

		Thread th = null ;           // ������ 

		private System.Windows.Forms.Button btn_start;
		private System.Windows.Forms.Button btn_stop;
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
			this.btn_start.Text = "Ÿ�� ���� ����";
			this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
			// 
			// btn_stop
			// 
			this.btn_stop.Enabled = false;
			this.btn_stop.Location = new System.Drawing.Point(72, 88);
			this.btn_stop.Name = "btn_stop";
			this.btn_stop.Size = new System.Drawing.Size(168, 40);
			this.btn_stop.TabIndex = 1;
			this.btn_stop.Text = "Ÿ�� ���� ����";
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
			this.Text = "Ÿ�� ����";
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


		void Accept()
		{
			try
			{
				listener = new TcpListener(port);
				listener.Start();
			}
			catch(Exception ex)
			{
				MessageBox.Show("�����޽��� :"+ ex.StackTrace);
			}
			
			btn_start.Enabled = false ;
			btn_stop.Enabled = true ;

			Socket client = listener.AcceptSocket();
			
			if(client.Connected)
			{
				stream = new NetworkStream(client);
				write = new StreamWriter(stream);
				write.WriteLine(DateTime.Now); // ���� �ð� ����
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
				MessageBox.Show("�����޽��� :"+ ex.StackTrace);
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
			this.Stop();   // ������ ����
			try
			{
				th.Abort(); // ������ ����
			}
			catch
			{
			}
		}
	}
}
