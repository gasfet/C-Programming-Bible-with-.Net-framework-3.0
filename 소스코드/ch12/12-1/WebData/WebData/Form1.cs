using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.IO;
using System.Net;

namespace WebData
{
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txt_URL;
		private System.Windows.Forms.Button btn_GetData;
		private System.Windows.Forms.TextBox txt_Header;
		private System.Windows.Forms.TextBox txt_HTML;
		private System.Windows.Forms.Label lbl_URL;
		private System.Windows.Forms.Label lbl_Header;
		private System.Windows.Forms.Label lbl_HTML;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();
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
			this.lbl_URL = new System.Windows.Forms.Label();
			this.txt_URL = new System.Windows.Forms.TextBox();
			this.btn_GetData = new System.Windows.Forms.Button();
			this.txt_Header = new System.Windows.Forms.TextBox();
			this.txt_HTML = new System.Windows.Forms.TextBox();
			this.lbl_Header = new System.Windows.Forms.Label();
			this.lbl_HTML = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbl_URL
			// 
			this.lbl_URL.Location = new System.Drawing.Point(16, 24);
			this.lbl_URL.Name = "lbl_URL";
			this.lbl_URL.Size = new System.Drawing.Size(48, 23);
			this.lbl_URL.TabIndex = 0;
			this.lbl_URL.Text = "URL :";
			// 
			// txt_URL
			// 
			this.txt_URL.Location = new System.Drawing.Point(72, 24);
			this.txt_URL.Name = "txt_URL";
			this.txt_URL.Size = new System.Drawing.Size(256, 21);
			this.txt_URL.TabIndex = 1;
			this.txt_URL.Text = "";
			// 
			// btn_GetData
			// 
			this.btn_GetData.Location = new System.Drawing.Point(336, 24);
			this.btn_GetData.Name = "btn_GetData";
			this.btn_GetData.Size = new System.Drawing.Size(80, 23);
			this.btn_GetData.TabIndex = 2;
			this.btn_GetData.Text = "읽어오기";
			this.btn_GetData.Click += new System.EventHandler(this.btn_GetData_Click);
			// 
			// txt_Header
			// 
			this.txt_Header.Location = new System.Drawing.Point(24, 81);
			this.txt_Header.Multiline = true;
			this.txt_Header.Name = "txt_Header";
			this.txt_Header.Size = new System.Drawing.Size(392, 88);
			this.txt_Header.TabIndex = 3;
			this.txt_Header.Text = "";
			// 
			// txt_HTML
			// 
			this.txt_HTML.Location = new System.Drawing.Point(24, 200);
			this.txt_HTML.Multiline = true;
			this.txt_HTML.Name = "txt_HTML";
			this.txt_HTML.Size = new System.Drawing.Size(392, 120);
			this.txt_HTML.TabIndex = 4;
			this.txt_HTML.Text = "";
			// 
			// lbl_Header
			// 
			this.lbl_Header.Location = new System.Drawing.Point(24, 63);
			this.lbl_Header.Name = "lbl_Header";
			this.lbl_Header.Size = new System.Drawing.Size(104, 16);
			this.lbl_Header.TabIndex = 5;
			this.lbl_Header.Text = "HTTP 헤더 정보 :";
			// 
			// lbl_HTML
			// 
			this.lbl_HTML.Location = new System.Drawing.Point(27, 179);
			this.lbl_HTML.Name = "lbl_HTML";
			this.lbl_HTML.Size = new System.Drawing.Size(104, 16);
			this.lbl_HTML.TabIndex = 6;
			this.lbl_HTML.Text = "HTML :";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(432, 342);
			this.Controls.Add(this.lbl_HTML);
			this.Controls.Add(this.lbl_Header);
			this.Controls.Add(this.txt_HTML);
			this.Controls.Add(this.txt_Header);
			this.Controls.Add(this.btn_GetData);
			this.Controls.Add(this.txt_URL);
			this.Controls.Add(this.lbl_URL);
			this.Name = "Form1";
			this.Text = "웹 페이지 가져오기";
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

		private void btn_GetData_Click(object sender, System.EventArgs e)
		{
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(this.txt_URL.Text.Trim());
			HttpWebResponse hwrp = (HttpWebResponse)hwr.GetResponse();
			WebHeaderCollection whc = hwrp.Headers;

			string header = null, html = null;

			for(int i = 0 ; i < whc.Count; i++)
			{
               header += whc.GetKey(i) + " = " + whc.GetKey(i) + "\r\n";         
			}

			Stream strm = hwrp.GetResponseStream();
			StreamReader sr = new StreamReader(strm);

			while(sr.Peek() > -1)
			{
              html += sr.ReadLine() + "\r\n";
			}

			this.txt_Header.Text = header;
			this.txt_HTML.Text   = html;

			sr.Close();
			strm.Close();
		}
	}
}
