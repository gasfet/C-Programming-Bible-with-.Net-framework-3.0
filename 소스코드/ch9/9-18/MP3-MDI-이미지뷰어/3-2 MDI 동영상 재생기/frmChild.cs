using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MDIViewer
{
	/// <summary>
	/// frmChild�� ���� ��� �����Դϴ�.
	/// </summary>
	public class frmChild : System.Windows.Forms.Form
	{
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public AxMediaPlayer.AxMediaPlayer mpPlayer;

		MDIViewer.frmMDI frmParent;
		public frmChild()
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

		// �� �ε�
		private void frmChild_Load(object sender, System.EventArgs e)
		{
			
			mpPlayer.AutoStart = false;
			mpPlayer.Stop();
			mpPlayer.CurrentPosition = 0;
		}

		// �� ����
		private void frmChild_Closed(object sender, System.EventArgs e)
		{
			frmParent = (MDIViewer.frmMDI)this.MdiParent;
			frmParent.RemoveTabItem(this.Tag.ToString());
		}

		// �� ũ�� ����
		private void frmChild_Resize(object sender, System.EventArgs e)
		{
		
			mpPlayer.Top = 0;
			mpPlayer.Left = 0;
			mpPlayer.Width = this.Width - 10;
			mpPlayer.Height = this.Height - 30;
		}
	}
}
