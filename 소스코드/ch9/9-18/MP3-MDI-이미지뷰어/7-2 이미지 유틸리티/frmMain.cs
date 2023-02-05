using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ImgConv
{
	/// <summary>
	/// Form1�� ���� ��� �����Դϴ�.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.StatusBarPanel panFilePath;
		internal System.Windows.Forms.ToolBarButton toolEmboss;
		internal System.Windows.Forms.ToolBarButton toolDiffuse;
		internal System.Windows.Forms.MenuItem memu90;
		internal System.Windows.Forms.OpenFileDialog openDlg;
		internal System.Windows.Forms.ImageList imglstTool;
		internal System.Windows.Forms.ToolBarButton toolOrg;
		internal System.Windows.Forms.ToolBarButton toolRotation;
		internal System.Windows.Forms.ContextMenu ContextMenu1;
		internal System.Windows.Forms.MenuItem memu180;
		internal System.Windows.Forms.MenuItem memu270;
		internal System.Windows.Forms.MenuItem MenuItem1;
		internal System.Windows.Forms.MenuItem memuX;
		internal System.Windows.Forms.ToolBarButton ToolBarButton1;
		internal System.Windows.Forms.ToolBarButton toolBack;
		internal System.Windows.Forms.SaveFileDialog saveDlg;
		internal System.Windows.Forms.ToolBarButton toolSave;
		internal System.Windows.Forms.StatusBar stsImg;
		internal System.Windows.Forms.ToolBarButton ToolBarButton2;
		internal System.Windows.Forms.ToolBarButton toolOpen;
		internal System.Windows.Forms.ToolBar ToolBar1;
		internal System.Windows.Forms.ToolBarButton toolSmooth;
		internal System.Windows.Forms.ToolBarButton toolSharp;
		internal System.Windows.Forms.ToolBarButton toolSolarize;
		private System.ComponentModel.IContainer components;
		internal System.Windows.Forms.PictureBox picTmp;
		internal System.Windows.Forms.PictureBox picMain;

		String m_strPath; //�׸� ��ü ���

		//����ȭ�� ���� API
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern bool SystemParametersInfo(int nAction, int nParam, string pvParam, int fWinini);

		public const int SPI_SETDESKWALLPAPER = 20;
		public const int SPIF_SENDCHANGE = 2;
		
		public frmMain()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.panFilePath = new System.Windows.Forms.StatusBarPanel();
			this.toolEmboss = new System.Windows.Forms.ToolBarButton();
			this.toolDiffuse = new System.Windows.Forms.ToolBarButton();
			this.memu90 = new System.Windows.Forms.MenuItem();
			this.openDlg = new System.Windows.Forms.OpenFileDialog();
			this.imglstTool = new System.Windows.Forms.ImageList(this.components);
			this.toolOrg = new System.Windows.Forms.ToolBarButton();
			this.toolRotation = new System.Windows.Forms.ToolBarButton();
			this.ContextMenu1 = new System.Windows.Forms.ContextMenu();
			this.memu180 = new System.Windows.Forms.MenuItem();
			this.memu270 = new System.Windows.Forms.MenuItem();
			this.MenuItem1 = new System.Windows.Forms.MenuItem();
			this.memuX = new System.Windows.Forms.MenuItem();
			this.ToolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBack = new System.Windows.Forms.ToolBarButton();
			this.saveDlg = new System.Windows.Forms.SaveFileDialog();
			this.toolSave = new System.Windows.Forms.ToolBarButton();
			this.stsImg = new System.Windows.Forms.StatusBar();
			this.ToolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.toolOpen = new System.Windows.Forms.ToolBarButton();
			this.ToolBar1 = new System.Windows.Forms.ToolBar();
			this.toolSmooth = new System.Windows.Forms.ToolBarButton();
			this.toolSharp = new System.Windows.Forms.ToolBarButton();
			this.toolSolarize = new System.Windows.Forms.ToolBarButton();
			this.picTmp = new System.Windows.Forms.PictureBox();
			this.picMain = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.panFilePath)).BeginInit();
			this.SuspendLayout();
			// 
			// panFilePath
			// 
			this.panFilePath.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.panFilePath.Text = "���ϰ�� : ";
			this.panFilePath.Width = 616;
			// 
			// toolEmboss
			// 
			this.toolEmboss.ImageIndex = 7;
			this.toolEmboss.Text = "�簢ȿ��";
			// 
			// toolDiffuse
			// 
			this.toolDiffuse.ImageIndex = 8;
			this.toolDiffuse.Text = "ȸȭȿ��";
			// 
			// memu90
			// 
			this.memu90.Index = 0;
			this.memu90.Text = "90�� ȸ��";
			this.memu90.Click += new System.EventHandler(this.memu90_Click);
			// 
			// openDlg
			// 
			this.openDlg.Filter = "��� �̹��� ����(*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.ico;*.emf;*.wmf)|*.bmp;*.gif;*.jpg;*.j" +
				"peg;*.png;*.ico;*.emf;*.wmf";
			// 
			// imglstTool
			// 
			this.imglstTool.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imglstTool.ImageSize = new System.Drawing.Size(16, 16);
			this.imglstTool.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstTool.ImageStream")));
			this.imglstTool.TransparentColor = System.Drawing.Color.White;
			// 
			// toolOrg
			// 
			this.toolOrg.ImageIndex = 2;
			this.toolOrg.Text = "����";
			// 
			// toolRotation
			// 
			this.toolRotation.DropDownMenu = this.ContextMenu1;
			this.toolRotation.ImageIndex = 4;
			this.toolRotation.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.toolRotation.Text = "ȸ��";
			// 
			// ContextMenu1
			// 
			this.ContextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.memu90,
																						 this.memu180,
																						 this.memu270,
																						 this.MenuItem1,
																						 this.memuX});
			// 
			// memu180
			// 
			this.memu180.Index = 1;
			this.memu180.Text = "180�� ȸ��";
			this.memu180.Click += new System.EventHandler(this.memu180_Click);
			// 
			// memu270
			// 
			this.memu270.Index = 2;
			this.memu270.Text = "270�� ȸ��";
			this.memu270.Click += new System.EventHandler(this.memu270_Click);
			// 
			// MenuItem1
			// 
			this.MenuItem1.Index = 3;
			this.MenuItem1.Text = "-";
			// 
			// memuX
			// 
			this.memuX.Index = 4;
			this.memuX.Text = "���� ������";
			this.memuX.Click += new System.EventHandler(this.memuX_Click);
			// 
			// ToolBarButton1
			// 
			this.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBack
			// 
			this.toolBack.ImageIndex = 3;
			this.toolBack.Text = "���׸�";
			// 
			// saveDlg
			// 
			this.saveDlg.FileName = "doc1";
			this.saveDlg.Filter = "��Ʈ��(*.bmp)|*.bmp|Windows Ȯ�� ��Ÿ����(*.emf)|*.emf|Exif Exchangeable Image File(*.exif" +
				")|*.exif|GIF(*.gif)|*.gif|JPEG(*.jpg;*,jpeg)|*.jpg|PNG(png.*)|png.*|TIFF(tiff.*)" +
				"|tiff.*|WMF(wmf.*)|wmf.*";
			// 
			// toolSave
			// 
			this.toolSave.ImageIndex = 1;
			this.toolSave.Text = "����";
			// 
			// stsImg
			// 
			this.stsImg.Location = new System.Drawing.Point(0, 359);
			this.stsImg.Name = "stsImg";
			this.stsImg.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																					  this.panFilePath});
			this.stsImg.ShowPanels = true;
			this.stsImg.Size = new System.Drawing.Size(632, 22);
			this.stsImg.TabIndex = 5;
			this.stsImg.Text = "StatusBar1";
			// 
			// ToolBarButton2
			// 
			this.ToolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolOpen
			// 
			this.toolOpen.ImageIndex = 0;
			this.toolOpen.Text = "����";
			// 
			// ToolBar1
			// 
			this.ToolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolOpen,
																						this.toolSave,
																						this.ToolBarButton2,
																						this.toolOrg,
																						this.toolBack,
																						this.ToolBarButton1,
																						this.toolRotation,
																						this.toolSmooth,
																						this.toolSharp,
																						this.toolEmboss,
																						this.toolDiffuse,
																						this.toolSolarize});
			this.ToolBar1.ButtonSize = new System.Drawing.Size(60, 35);
			this.ToolBar1.DropDownArrows = true;
			this.ToolBar1.ImageList = this.imglstTool;
			this.ToolBar1.Name = "ToolBar1";
			this.ToolBar1.ShowToolTips = true;
			this.ToolBar1.Size = new System.Drawing.Size(632, 38);
			this.ToolBar1.TabIndex = 4;
			this.ToolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.ToolBar1_ButtonClick);
			// 
			// toolSmooth
			// 
			this.toolSmooth.ImageIndex = 5;
			this.toolSmooth.Text = "�ε巴��";
			// 
			// toolSharp
			// 
			this.toolSharp.ImageIndex = 6;
			this.toolSharp.Text = "��ī�Ӱ�";
			// 
			// toolSolarize
			// 
			this.toolSolarize.ImageIndex = 9;
			this.toolSolarize.Text = "����ȿ��";
			// 
			// picTmp
			// 
			this.picTmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picTmp.Location = new System.Drawing.Point(24, 152);
			this.picTmp.Name = "picTmp";
			this.picTmp.Size = new System.Drawing.Size(104, 40);
			this.picTmp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picTmp.TabIndex = 8;
			this.picTmp.TabStop = false;
			this.picTmp.Visible = false;
			// 
			// picMain
			// 
			this.picMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picMain.Location = new System.Drawing.Point(8, 48);
			this.picMain.Name = "picMain";
			this.picMain.Size = new System.Drawing.Size(104, 64);
			this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picMain.TabIndex = 9;
			this.picMain.TabStop = false;
			this.picMain.Visible = false;
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(632, 381);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.picMain,
																		  this.picTmp,
																		  this.stsImg,
																		  this.ToolBar1});
			this.Name = "frmMain";
			this.Text = "�̹��� ��ȯ��";
			((System.ComponentModel.ISupportInitialize)(this.panFilePath)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �ش� ���� ���α׷��� �� �������Դϴ�.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		
		// �̹����� ũ�⿡ ���� �� ũ�⸦ ����
		private void ResizeForm()
		{
			int nHeight, nWidth;

			// ���̿� �ʺ� ���
			nHeight = ToolBar1.Height + picMain.Height + stsImg.Height + 40;
			nWidth = picMain.Width + 20;

			// ���� ���̺��� �׸��� ���̰� Ŭ ��� 
			if (this.Height < nHeight) 
				this.Height = nHeight;
        

			// ���� �ʺ񺸴� �׸��� �ʺ� Ŭ ��� 
			if (this.Width < nWidth) 
				this.Width = nWidth;
        

			// ��Ʈ���� ���� �߰����� �Ѵ�.
			picMain.Left = (int)((this.Width / 2) - (picMain.Width / 2));
		}

		// ���� Ŭ��
		private void ToolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == toolOpen)  // ����
			{
				openDlg.ShowDialog();
				m_strPath = openDlg.FileName;

				if (m_strPath != "") 
				{
					try
					{
						picMain.Image = new Bitmap(m_strPath);
						picMain.Visible = true;
					}
					catch
					{
						picMain.Image = null;
						picMain.Visible = false;
					}

					ResizeForm(); // �̹����� ũ�⿡ ���� �� ũ�⸦ ����
				}

				stsImg.Panels[0].Text = "���ϰ�� : " + m_strPath;
			}
			else if (e.Button == toolSave)  // ����
			{
				if (picMain.Image == null)  
					return;

				String strPath;
				String strFile, strDir;
				int nIndex;

				// ������ ���ϸ��� �и��Ѵ�. ������� C:\temp\test.txt���
				// strDir = C:\temp   strFile = test.txt�� �ȴ�.
				strDir = m_strPath.Substring(0, m_strPath.LastIndexOf("\\"));
				strFile = m_strPath.Substring(m_strPath.LastIndexOf("\\"), m_strPath.Length - m_strPath.LastIndexOf("\\"));
				strFile = strFile.Remove(0, 1);
				saveDlg.InitialDirectory = strDir; // ������ ������ ������ ������ �����Ѵ�.
				saveDlg.FileName = strFile; // ���� ���� �̸��� �����Ѵ�.

				if (saveDlg.ShowDialog() != DialogResult.OK)
					return;

				strPath = openDlg.FileName;

				if (strPath != "")  // ������ ���Ϳ� ���� �׸����� ������ ����
				{

					nIndex = saveDlg.FilterIndex;

					if (nIndex == 1)  // bmp
						picMain.Image.Save(strPath, System.Drawing.Imaging.ImageFormat.Bmp);
					else if (nIndex == 2)  //emf
						picMain.Image.Save(strPath, System.Drawing.Imaging.ImageFormat.Emf);
					else if (nIndex == 3)  //exif
						picMain.Image.Save(strPath, System.Drawing.Imaging.ImageFormat.Exif);
					else if (nIndex == 4)  //gif
						picMain.Image.Save(strPath, System.Drawing.Imaging.ImageFormat.Gif);
					else if (nIndex == 5)  //jpg
						picMain.Image.Save(strPath, System.Drawing.Imaging.ImageFormat.Jpeg);
					else if (nIndex == 6)  //png
						picMain.Image.Save(strPath, System.Drawing.Imaging.ImageFormat.Png);
					else if (nIndex == 7)  //tiff
						picMain.Image.Save(strPath, System.Drawing.Imaging.ImageFormat.Tiff);
					else //wmf
						picMain.Image.Save(strPath, System.Drawing.Imaging.ImageFormat.Wmf);
                
				}
			}
			else if (e.Button == toolOrg)  // ����
			{
				if (picMain.Image == null)
					return;

				if (m_strPath != "") 
				{
					try
					{
						picMain.Image = new Bitmap(m_strPath);
						picMain.Visible = true;
					}
					catch
					{
						picMain.Image = null;
						picMain.Visible = false;
					}

					ResizeForm(); // �̹����� ũ�⿡ ���� �� ũ�⸦ ����
				}
			}
			else if (e.Button == toolBack)  // ���׸�
			{
				if (picMain.Image == null)
					return;

				// C:\back.bmp�� ����
				picMain.Image.Save("C:\\back.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
				// ������ �̹����� ���׸�����
				SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, "C:\\back", SPIF_SENDCHANGE);
			}
			else // ��Ÿ �̹��� ���μ���
			{
				if (picMain.Image == null)
					return;

				frmProcess frmPro;

				frmPro = new frmProcess();

				frmPro.Text = e.Button.Text; // ���� �ؽ�Ʈ�� ��ư �ؽ�Ʈ�� �Ѵ�.
				frmPro.Init(this);
				frmPro.ShowDialog();
				frmPro.Dispose();
			}
		}

		// 90�� ȸ��
		private void memu90_Click(object sender, System.EventArgs e)
		{
			if (picMain.Image == null)
				return;


			// �ӽ� �׸��� �����Ѵ�.
			picTmp.Image = picMain.Image;
			// �׸��� ȸ���Ѵ�.
			picTmp.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
			//�����׸��� ǥ���Ѵ�.
			picMain.Image = picTmp.Image;
			ResizeForm();
		}

		// 180�� ȸ��
		private void memu180_Click(object sender, System.EventArgs e)
		{
			if (picMain.Image == null)
				return;


			// �ӽ� �׸��� �����Ѵ�.
			picTmp.Image = picMain.Image;
			// �׸��� ȸ���Ѵ�.
			picTmp.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
			//�����׸��� ǥ���Ѵ�.
			picMain.Image = picTmp.Image;
			ResizeForm();
		}

		// 270�� ȸ��
		private void memu270_Click(object sender, System.EventArgs e)
		{
			if (picMain.Image == null)
				return;


			// �ӽ� �׸��� �����Ѵ�.
			picTmp.Image = picMain.Image;
			// �׸��� ȸ���Ѵ�.
			picTmp.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
			//�����׸��� ǥ���Ѵ�.
			picMain.Image = picTmp.Image;
			ResizeForm();
		}

		// ���� ������
		private void memuX_Click(object sender, System.EventArgs e)
		{
			if (picMain.Image == null)
				return;


			// �ӽ� �׸��� �����Ѵ�.
			picTmp.Image = picMain.Image;
			// �׸��� ȸ���Ѵ�.
			picTmp.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
			//�����׸��� ǥ���Ѵ�.
			picMain.Image = picTmp.Image;
			ResizeForm();
		}
		
	}
}
