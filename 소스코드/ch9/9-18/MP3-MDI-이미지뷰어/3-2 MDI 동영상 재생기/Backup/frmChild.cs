using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MDIViewer
{
	/// <summary>
	/// frmChild에 대한 요약 설명입니다.
	/// </summary>
	public class frmChild : System.Windows.Forms.Form
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public AxMediaPlayer.AxMediaPlayer mpPlayer;

		MDIViewer.frmMDI frmParent;
		public frmChild()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmChild));
			this.mpPlayer = new AxMediaPlayer.AxMediaPlayer();
			((System.ComponentModel.ISupportInitialize)(this.mpPlayer)).BeginInit();
			this.SuspendLayout();
			// 
			// mpPlayer
			// 
			this.mpPlayer.Name = "mpPlayer";
			this.mpPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mpPlayer.OcxState")));
			this.mpPlayer.Size = new System.Drawing.Size(286, 272);
			this.mpPlayer.TabIndex = 0;
			// 
			// frmChild
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(288, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.mpPlayer});
			this.Name = "frmChild";
			this.Text = "frmChild";
			this.Resize += new System.EventHandler(this.frmChild_Resize);
			this.Load += new System.EventHandler(this.frmChild_Load);
			this.Closed += new System.EventHandler(this.frmChild_Closed);
			((System.ComponentModel.ISupportInitialize)(this.mpPlayer)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		// 폼 로드
		private void frmChild_Load(object sender, System.EventArgs e)
		{
			
			mpPlayer.AutoStart = false;
			mpPlayer.Stop();
			mpPlayer.CurrentPosition = 0;
		}

		// 폼 종료
		private void frmChild_Closed(object sender, System.EventArgs e)
		{
			frmParent = (MDIViewer.frmMDI)this.MdiParent;
			frmParent.RemoveTabItem(this.Tag.ToString());
		}

		// 폼 크기 변경
		private void frmChild_Resize(object sender, System.EventArgs e)
		{
		
			mpPlayer.Top = 0;
			mpPlayer.Left = 0;
			mpPlayer.Width = this.Width - 10;
			mpPlayer.Height = this.Height - 30;
		}
	}
}
