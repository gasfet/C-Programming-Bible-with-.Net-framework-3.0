using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ImgViewer
{
	/// <summary>
	/// frmSelect에 대한 요약 설명입니다.
	/// </summary>
	public class frmSelect : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.PictureBox picSel;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSelect()
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
            this.picSel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSel)).BeginInit();
            this.SuspendLayout();
            // 
            // picSel
            // 
            this.picSel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picSel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSel.Location = new System.Drawing.Point(0, 0);
            this.picSel.Name = "picSel";
            this.picSel.Size = new System.Drawing.Size(292, 273);
            this.picSel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSel.TabIndex = 1;
            this.picSel.TabStop = false;
            this.picSel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSel_MouseDown);
            // 
            // frmSelect
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.picSel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSelect";
            this.Load += new System.EventHandler(this.frmSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmSelect_Load(object sender, System.EventArgs e)
		{
			picSel.SizeMode = PictureBoxSizeMode.StretchImage;
		}

		
		private void picSel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Size sizePic = new Size();
			Size sizeMe = new  Size();

			sizePic = picSel.Size; 
			sizeMe = this.Size;
        
			if (e.Button == MouseButtons.Left) // 왼쪽버튼 누른경우 확대
			{
				sizePic.Height += 15;
				sizePic.Width += 15;
				picSel.Size = sizePic;

				sizeMe.Height += 15;
				sizeMe.Width += 15;
				this.Size = sizeMe;
			}
			else if(e.Button == MouseButtons.Right) // 오른쪽버튼 누른경우 축소
			{
				sizePic.Height -= 15;
				sizePic.Width -= 15;
				picSel.Size = sizePic;

				sizeMe.Height -= 15;
				sizeMe.Width -= 15;
				this.Size = sizeMe;
			}
		}
	}
}
