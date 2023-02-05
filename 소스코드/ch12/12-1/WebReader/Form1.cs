
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


using System.Net;
using System.Text;
using System.IO;


namespace WebReader
{
	/// <summary>
	/// Form1에 대한 요약 설명입니다.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{		
		private System.Windows.Forms.Button btn_read;
		private System.Windows.Forms.TextBox txt_url;
		private System.Windows.Forms.TextBox txt_result;
		private System.Windows.Forms.Label label1;
		
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
			this.btn_read = new System.Windows.Forms.Button();
			this.txt_url = new System.Windows.Forms.TextBox();
			this.txt_result = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btn_read
			// 
			this.btn_read.Location = new System.Drawing.Point(288, 304);
			this.btn_read.Name = "btn_read";
			this.btn_read.Size = new System.Drawing.Size(120, 24);
			this.btn_read.TabIndex = 5;
			this.btn_read.Text = "읽어오기";
			this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
			// 
			// txt_url
			// 
			this.txt_url.Location = new System.Drawing.Point(8, 304);
			this.txt_url.Name = "txt_url";
			this.txt_url.Size = new System.Drawing.Size(280, 21);
			this.txt_url.TabIndex = 4;
			this.txt_url.Text = "http://www.yahoo.com/index.html";
			// 
			// txt_result
			// 
			this.txt_result.Location = new System.Drawing.Point(8, 40);
			this.txt_result.Multiline = true;
			this.txt_result.Name = "txt_result";
			this.txt_result.Size = new System.Drawing.Size(400, 248);
			this.txt_result.TabIndex = 6;
			this.txt_result.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("휴먼매직체", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label1.Location = new System.Drawing.Point(24, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(352, 32);
			this.label1.TabIndex = 8;
			this.label1.Text = "웹 페이지 가져오기 ver 1.0";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(416, 349);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.btn_read,
																		  this.txt_url,
																		  this.txt_result});
			this.ForeColor = System.Drawing.Color.Peru;
			this.Name = "Form1";
			this.Text = "Form1";
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

		private void btn_read_Click(object sender, System.EventArgs e)
		{
			WebRequest request = WebRequest.Create( txt_url.Text.Trim());

			WebResponse response = request.GetResponse();
			Stream stream = response.GetResponseStream();
			 
			// 스트림에서 데이터 읽기
			StreamReader read = new StreamReader(stream);

			StringBuilder str_data = new StringBuilder();

			while((read.ReadLine()) != null )
			{
			  str_data.Append( read.ReadLine() + "\r\n");	
			}
			// 스트림 닫기
			read.Close();

			txt_result.Text = str_data.ToString() ;
		
		}

	
	}
}
