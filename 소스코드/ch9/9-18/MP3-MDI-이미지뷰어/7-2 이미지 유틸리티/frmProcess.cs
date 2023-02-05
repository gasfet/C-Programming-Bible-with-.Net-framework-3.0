using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ImgConv
{
	/// <summary>
	/// frmProcess에 대한 요약 설명입니다.
	/// </summary>
	public class frmProcess : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Timer Timer1;
		internal System.Windows.Forms.ProgressBar pro;
		internal System.Windows.Forms.Label lblStatus;
		private System.ComponentModel.IContainer components;

		public frmProcess()
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
				if(components != null)
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
			this.components = new System.ComponentModel.Container();
			this.Timer1 = new System.Windows.Forms.Timer(this.components);
			this.pro = new System.Windows.Forms.ProgressBar();
			this.lblStatus = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Timer1
			// 
			this.Timer1.Interval = 1000;
			this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// pro
			// 
			this.pro.Location = new System.Drawing.Point(24, 72);
			this.pro.Name = "pro";
			this.pro.Size = new System.Drawing.Size(280, 16);
			this.pro.Step = 1;
			this.pro.TabIndex = 3;
			// 
			// lblStatus
			// 
			this.lblStatus.Location = new System.Drawing.Point(24, 16);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(280, 23);
			this.lblStatus.TabIndex = 2;
			this.lblStatus.Text = "상태 : ";
			// 
			// frmProcess
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(320, 109);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblStatus,
																		  this.pro});
			this.MaximizeBox = false;
			this.Name = "frmProcess";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "frmProcess";
			this.Load += new System.EventHandler(this.frmProcess_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private frmMain m_frmParent;

		public void Init(frmMain frmParent)
		{
			m_frmParent = frmParent;
		}

		// 부드럽게 하기
		private void Smooth()
		{
			Bitmap bit;
			int x, y;
			int k, h;
			int A, R, G, B;

			// 원본 비트맵을 얻는다.
			bit = new Bitmap(m_frmParent.picMain.Image);

			//프로그래스를 초기화 한다.
			pro.Minimum = 1;
			pro.Maximum = (bit.Width - 2) * (bit.Height - 2);
			// 프로세싱을 한다.
			for(x = 1 ; x <= bit.Width - 2 ; x++)
			{
				for(y = 1 ; y <= bit.Height - 2 ; y++)
				{
					//중심과 인접한 8개의 값을 얻는다.
					A = 0;
					R = 0;
					G = 0;
					B = 0;
					for(k = x - 1 ; k <= x + 1 ; k++)
					{
						for(h = y - 1 ; h <= y + 1 ; h++)
						{
							A += bit.GetPixel(k, h).A;
							R += bit.GetPixel(k, h).R;
							G += bit.GetPixel(k, h).G;
							B += bit.GetPixel(k, h).B;
						}
					}

					// 평균값을 구한다. 
					A = (int)(A / 9);
					R = (int)(R / 9);
					G = (int)(G / 9);
					B = (int)(B / 9);

					// 평균 값으로 다시 색을 정한다.
					bit.SetPixel(x, y, Color.FromArgb(A, R, G, B));

					Application.DoEvents();
					pro.PerformStep();
				}
			}
			m_frmParent.picMain.Image = Image.FromHbitmap(bit.GetHbitmap());
			bit.Dispose();
		}

		// 날카롭게 하기
		private void Sharp()
		{
			Bitmap bit;
			int x, y;
			int A, R, G, B;

			// 원본 비트맵을 얻는다.
			bit = new Bitmap(m_frmParent.picMain.Image);

			//프로그래스를 초기화 한다.
			pro.Minimum = 1;
			pro.Maximum = (bit.Width - 1) * (bit.Height - 1);


			// 프로세싱을 한다.
			for(x = 1 ; x <= bit.Width - 1 ; x++)
			{
				for(y = 1 ; y <= bit.Height - 1 ; y++)
				{
					A = bit.GetPixel(x, y).A;

					R = (int)((int)(bit.GetPixel(x, y).R) + 0.5 * ((int)(bit.GetPixel(x, y).R) - (int)(bit.GetPixel(x - 1, y - 1).R)));
					G = (int)((int)(bit.GetPixel(x, y).G) + 0.5 * ((int)(bit.GetPixel(x, y).G) - (int)(bit.GetPixel(x - 1, y - 1).G)));
					B = (int)((int)(bit.GetPixel(x, y).B) + 0.5 * ((int)(bit.GetPixel(x, y).B) - (int)(bit.GetPixel(x - 1, y - 1).B)));

					if(R > 255)
						R = 255;
					if(R < 0)
						R = 0;
					if(G > 255)
						G = 255;
					if(G < 0)
						G = 0;
					if(B > 255)
						B = 255;
					if(B < 0)
						B = 0;

					bit.SetPixel(x, y, Color.FromArgb(A, R, G, B));

					Application.DoEvents();
					pro.PerformStep();
				}
			}
			m_frmParent.picMain.Image = Image.FromHbitmap(bit.GetHbitmap());
			bit.Dispose();
		}

		//양각효과
		private void Embossing()
		{
			Bitmap bit;
			int x, y;
			int A, R, G, B;
        
			// 원본 비트맵을 얻는다.
			bit = new Bitmap(m_frmParent.picMain.Image);

			//프로그래스를 초기화 한다.
			pro.Minimum = 0;
			pro.Maximum = (bit.Width - 2) * (bit.Height - 2);

			// 프로세싱을 한다.
			for(x = 0 ; x <= bit.Width - 2 ; x++)
			{
				for(y = 0 ; y <= bit.Height - 2 ; y++)
				{
					A = bit.GetPixel(x, y).A;
					R = Math.Abs((int)(bit.GetPixel(x, y).R) - (int)(bit.GetPixel(x + 1, y + 1).R) + 128);
					G = Math.Abs((int)(bit.GetPixel(x, y).G) - (int)(bit.GetPixel(x + 1, y + 1).G) + 128);
					B = Math.Abs((int)(bit.GetPixel(x, y).B) - (int)(bit.GetPixel(x + 1, y + 1).B) + 128);

					if (R > 255)
						R = 255;
					if (G > 255)
						G = 255;
					if (B > 255)
						B = 255;

					bit.SetPixel(x, y, Color.FromArgb(A, R, G, B));

					Application.DoEvents();
					pro.PerformStep();
				}
			}
			m_frmParent.picMain.Image = Image.FromHbitmap(bit.GetHbitmap());
			bit.Dispose();
		}

		// 회화효과
		private void Diffuse()
		{
			Bitmap bit;
			int x, y;
			int A, R, G, B;
			int xRnd, yRnd;
			Random rnd = new Random();

			// 원본 비트맵을 얻는다.
			bit = new Bitmap(m_frmParent.picMain.Image);

			//프로그래스를 초기화 한다.
			pro.Minimum = 2;
			pro.Maximum = (bit.Width - 3) * (bit.Height - 3);

			// 프로세싱을 한다.
			for(x = 2 ; x <= bit.Width - 3 ; x++)
			{
				for(y = 2 ; y <= bit.Height - 3 ; y++)
				{
					A = bit.GetPixel(x, y).A;

					xRnd = rnd.Next(-2, 2);
					yRnd = rnd.Next(-2, 2);

					R = bit.GetPixel(x + xRnd, y + yRnd).R;
					G = bit.GetPixel(x + xRnd, y + yRnd).G;
					B = bit.GetPixel(x + xRnd, y + yRnd).B;

					bit.SetPixel(x, y, Color.FromArgb(A, R, G, B));

					Application.DoEvents();
					pro.PerformStep();
				}
			}
			m_frmParent.picMain.Image = Image.FromHbitmap(bit.GetHbitmap());
			bit.Dispose();
		}

		// 사진효과
		private void Solarize()
		{
			Bitmap bit;
			int x, y;
			int A, R, G, B;

			// 원본 비트맵을 얻는다.
			bit = new Bitmap(m_frmParent.picMain.Image);

			//프로그래스를 초기화 한다.
			pro.Minimum = 0;
			pro.Maximum = (bit.Width - 1) * (bit.Height - 1);

			// 프로세싱을 한다.
			for(x = 0 ; x <= bit.Width - 1 ; x++)
			{
				for(y = 0 ; y <= bit.Height - 1 ; y++)
				{
					A = bit.GetPixel(x, y).A;
					R = bit.GetPixel(x, y).R;
					G = bit.GetPixel(x, y).G;
					B = bit.GetPixel(x, y).B;

					// 128 보다 작은 경우 보색을 구한다.
					if ((R < 128) || (R > 255))
						R = 255 - R;
					if ((G < 128) || (G > 255))
						G = 255 - G;
					if ((B < 128) || (B > 255))
						B = 255 - B;

					bit.SetPixel(x, y, Color.FromArgb(A, R, G, B));

					Application.DoEvents();
					pro.PerformStep();
				}
			}
			m_frmParent.picMain.Image = Image.FromHbitmap(bit.GetHbitmap());
			bit.Dispose();
		}

		// 폼 로드
		private void frmProcess_Load(object sender, System.EventArgs e)
		{
			Timer1.Enabled = true;
		}

		private void Timer1_Tick(object sender, System.EventArgs e)
		{
			Timer1.Enabled = false;

			if (this.Text == "부드럽게") 
			{
				lblStatus.Text = "상태 : 이미지를 부드럽게 하는 중 입니다.";
				Smooth();
			}
			else if (this.Text == "날카롭게") 
			{
				lblStatus.Text = "상태 : 이미지를 날카롭게 하는 중 입니다.";
				Sharp();
			}
			else if (this.Text == "양각효과") 
			{
				lblStatus.Text = "상태 : 이미지에 양각효과를 적용 하는 중 입니다.";
				Embossing();
			}
			else if (this.Text == "회화효과") 
			{
				lblStatus.Text = "상태 : 이미지에 회화효과를 적용 하는 중 입니다.";
				Diffuse();
			}
			else //사진효과
			{
				lblStatus.Text = "상태 : 이미지에 사진효과를 적용 하는 중 입니다.";
				Solarize();
			}
			this.Close();
		}
		
	}
}

