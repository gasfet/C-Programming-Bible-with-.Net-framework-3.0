
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
	/// Form1�� ���� ��� �����Դϴ�.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{		
		private System.Windows.Forms.Button btn_read;
		private System.Windows.Forms.TextBox txt_url;
		private System.Windows.Forms.TextBox txt_result;
		private System.Windows.Forms.Label label1;
		
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
			this.btn_read.Text = "�о����";
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
			this.label1.Font = new System.Drawing.Font("�޸ո���ü", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.label1.Location = new System.Drawing.Point(24, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(352, 32);
			this.label1.TabIndex = 8;
			this.label1.Text = "�� ������ �������� ver 1.0";
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
		/// �ش� ���� ���α׷��� �� �������Դϴ�.
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
			 
			// ��Ʈ������ ������ �б�
			StreamReader read = new StreamReader(stream);

			StringBuilder str_data = new StringBuilder();

			while((read.ReadLine()) != null )
			{
			  str_data.Append( read.ReadLine() + "\r\n");	
			}
			// ��Ʈ�� �ݱ�
			read.Close();

			txt_result.Text = str_data.ToString() ;
		
		}

	
	}
}
