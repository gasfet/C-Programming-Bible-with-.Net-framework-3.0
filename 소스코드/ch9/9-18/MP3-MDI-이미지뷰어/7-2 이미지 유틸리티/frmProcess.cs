using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ImgConv
{
	/// <summary>
	/// frmProcess�� ���� ��� �����Դϴ�.
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
				if(components != null)
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
			this.lblStatus.Text = "���� : ";
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

		// �ε巴�� �ϱ�
		private void Smooth()
		{
			Bitmap bit;
			int x, y;
			int k, h;
			int A, R, G, B;

			// ���� ��Ʈ���� ��´�.
			bit = new Bitmap(m_frmParent.picMain.Image);

			//���α׷����� �ʱ�ȭ �Ѵ�.
			pro.Minimum = 1;
			pro.Maximum = (bit.Width - 2) * (bit.Height - 2);
			// ���μ����� �Ѵ�.
			for(x = 1 ; x <= bit.Width - 2 ; x++)
			{
				for(y = 1 ; y <= bit.Height - 2 ; y++)
				{
					//�߽ɰ� ������ 8���� ���� ��´�.
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

					// ��հ��� ���Ѵ�. 
					A = (int)(A / 9);
					R = (int)(R / 9);
					G = (int)(G / 9);
					B = (int)(B / 9);

					// ��� ������ �ٽ� ���� ���Ѵ�.
					bit.SetPixel(x, y, Color.FromArgb(A, R, G, B));

					Application.DoEvents();
					pro.PerformStep();
				}
			}
			m_frmParent.picMain.Image = Image.FromHbitmap(bit.GetHbitmap());
			bit.Dispose();
		}

		// ��ī�Ӱ� �ϱ�
		private void Sharp()
		{
			Bitmap bit;
			int x, y;
			int A, R, G, B;

			// ���� ��Ʈ���� ��´�.
			bit = new Bitmap(m_frmParent.picMain.Image);

			//���α׷����� �ʱ�ȭ �Ѵ�.
			pro.Minimum = 1;
			pro.Maximum = (bit.Width - 1) * (bit.Height - 1);


			// ���μ����� �Ѵ�.
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

		//�簢ȿ��
		private void Embossing()
		{
			Bitmap bit;
			int x, y;
			int A, R, G, B;
        
			// ���� ��Ʈ���� ��´�.
			bit = new Bitmap(m_frmParent.picMain.Image);

			//���α׷����� �ʱ�ȭ �Ѵ�.
			pro.Minimum = 0;
			pro.Maximum = (bit.Width - 2) * (bit.Height - 2);

			// ���μ����� �Ѵ�.
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

		// ȸȭȿ��
		private void Diffuse()
		{
			Bitmap bit;
			int x, y;
			int A, R, G, B;
			int xRnd, yRnd;
			Random rnd = new Random();

			// ���� ��Ʈ���� ��´�.
			bit = new Bitmap(m_frmParent.picMain.Image);

			//���α׷����� �ʱ�ȭ �Ѵ�.
			pro.Minimum = 2;
			pro.Maximum = (bit.Width - 3) * (bit.Height - 3);

			// ���μ����� �Ѵ�.
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

		// ����ȿ��
		private void Solarize()
		{
			Bitmap bit;
			int x, y;
			int A, R, G, B;

			// ���� ��Ʈ���� ��´�.
			bit = new Bitmap(m_frmParent.picMain.Image);

			//���α׷����� �ʱ�ȭ �Ѵ�.
			pro.Minimum = 0;
			pro.Maximum = (bit.Width - 1) * (bit.Height - 1);

			// ���μ����� �Ѵ�.
			for(x = 0 ; x <= bit.Width - 1 ; x++)
			{
				for(y = 0 ; y <= bit.Height - 1 ; y++)
				{
					A = bit.GetPixel(x, y).A;
					R = bit.GetPixel(x, y).R;
					G = bit.GetPixel(x, y).G;
					B = bit.GetPixel(x, y).B;

					// 128 ���� ���� ��� ������ ���Ѵ�.
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

		// �� �ε�
		private void frmProcess_Load(object sender, System.EventArgs e)
		{
			Timer1.Enabled = true;
		}

		private void Timer1_Tick(object sender, System.EventArgs e)
		{
			Timer1.Enabled = false;

			if (this.Text == "�ε巴��") 
			{
				lblStatus.Text = "���� : �̹����� �ε巴�� �ϴ� �� �Դϴ�.";
				Smooth();
			}
			else if (this.Text == "��ī�Ӱ�") 
			{
				lblStatus.Text = "���� : �̹����� ��ī�Ӱ� �ϴ� �� �Դϴ�.";
				Sharp();
			}
			else if (this.Text == "�簢ȿ��") 
			{
				lblStatus.Text = "���� : �̹����� �簢ȿ���� ���� �ϴ� �� �Դϴ�.";
				Embossing();
			}
			else if (this.Text == "ȸȭȿ��") 
			{
				lblStatus.Text = "���� : �̹����� ȸȭȿ���� ���� �ϴ� �� �Դϴ�.";
				Diffuse();
			}
			else //����ȿ��
			{
				lblStatus.Text = "���� : �̹����� ����ȿ���� ���� �ϴ� �� �Դϴ�.";
				Solarize();
			}
			this.Close();
		}
		
	}
}

