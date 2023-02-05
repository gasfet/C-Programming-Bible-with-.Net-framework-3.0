using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ImgConv
{
	/// <summary>
	/// Form1에 대한 요약 설명입니다.
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

		String m_strPath; //그림 전체 경로

		//바탕화면 설정 API
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern bool SystemParametersInfo(int nAction, int nParam, string pvParam, int fWinini);

		public const int SPI_SETDESKWALLPAPER = 20;
		public const int SPIF_SENDCHANGE = 2;
		
		public frmMain()
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
			this.panFilePath.Text = "파일경로 : ";
			this.panFilePath.Width = 616;
			// 
			// toolEmboss
			// 
			this.toolEmboss.ImageIndex = 7;
			this.toolEmboss.Text = "양각효과";
			// 
			// toolDiffuse
			// 
			this.toolDiffuse.ImageIndex = 8;
			this.toolDiffuse.Text = "회화효과";
			// 
			// memu90
			// 
			this.memu90.Index = 0;
			this.memu90.Text = "90도 회전";
			this.memu90.Click += new System.EventHandler(this.memu90_Click);
			// 
			// openDlg
			// 
			this.openDlg.Filter = "모든 이미지 파일(*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.ico;*.emf;*.wmf)|*.bmp;*.gif;*.jpg;*.j" +
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
			this.toolOrg.Text = "원본";
			// 
			// toolRotation
			// 
			this.toolRotation.DropDownMenu = this.ContextMenu1;
			this.toolRotation.ImageIndex = 4;
			this.toolRotation.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.toolRotation.Text = "회전";
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
			this.memu180.Text = "180도 회전";
			this.memu180.Click += new System.EventHandler(this.memu180_Click);
			// 
			// memu270
			// 
			this.memu270.Index = 2;
			this.memu270.Text = "270도 회전";
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
			this.memuX.Text = "상하 뒤집기";
			this.memuX.Click += new System.EventHandler(this.memuX_Click);
			// 
			// ToolBarButton1
			// 
			this.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBack
			// 
			this.toolBack.ImageIndex = 3;
			this.toolBack.Text = "배경그림";
			// 
			// saveDlg
			// 
			this.saveDlg.FileName = "doc1";
			this.saveDlg.Filter = "비트맵(*.bmp)|*.bmp|Windows 확장 메타파일(*.emf)|*.emf|Exif Exchangeable Image File(*.exif" +
				")|*.exif|GIF(*.gif)|*.gif|JPEG(*.jpg;*,jpeg)|*.jpg|PNG(png.*)|png.*|TIFF(tiff.*)" +
				"|tiff.*|WMF(wmf.*)|wmf.*";
			// 
			// toolSave
			// 
			this.toolSave.ImageIndex = 1;
			this.toolSave.Text = "저장";
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
			this.toolOpen.Text = "열기";
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
			this.toolSmooth.Text = "부드럽게";
			// 
			// toolSharp
			// 
			this.toolSharp.ImageIndex = 6;
			this.toolSharp.Text = "날카롭게";
			// 
			// toolSolarize
			// 
			this.toolSolarize.ImageIndex = 9;
			this.toolSolarize.Text = "사진효과";
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
			this.Text = "이미지 변환기";
			((System.ComponentModel.ISupportInitialize)(this.panFilePath)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		
		// 이미지의 크기에 맞춰 폼 크기를 변경
		private void ResizeForm()
		{
			int nHeight, nWidth;

			// 높이와 너비 계산
			nHeight = ToolBar1.Height + picMain.Height + stsImg.Height + 40;
			nWidth = picMain.Width + 20;

			// 폼의 높이보다 그림의 높이가 클 경우 
			if (this.Height < nHeight) 
				this.Height = nHeight;
        

			// 폼의 너비보다 그림의 너비가 클 경우 
			if (this.Width < nWidth) 
				this.Width = nWidth;
        

			// 컨트롤을 폼의 중간으로 한다.
			picMain.Left = (int)((this.Width / 2) - (picMain.Width / 2));
		}

		// 툴바 클릭
		private void ToolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == toolOpen)  // 열기
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

					ResizeForm(); // 이미지의 크기에 맞춰 폼 크기를 변경
				}

				stsImg.Panels[0].Text = "파일경로 : " + m_strPath;
			}
			else if (e.Button == toolSave)  // 저장
			{
				if (picMain.Image == null)  
					return;

				String strPath;
				String strFile, strDir;
				int nIndex;

				// 폴더와 파일명을 분리한다. 예를들어 C:\temp\test.txt라면
				// strDir = C:\temp   strFile = test.txt가 된다.
				strDir = m_strPath.Substring(0, m_strPath.LastIndexOf("\\"));
				strFile = m_strPath.Substring(m_strPath.LastIndexOf("\\"), m_strPath.Length - m_strPath.LastIndexOf("\\"));
				strFile = strFile.Remove(0, 1);
				saveDlg.InitialDirectory = strDir; // 파일의 폴더를 오픈할 폴더로 설정한다.
				saveDlg.FileName = strFile; // 최초 파일 이름을 설정한다.

				if (saveDlg.ShowDialog() != DialogResult.OK)
					return;

				strPath = openDlg.FileName;

				if (strPath != "")  // 선택한 필터에 따라 그림포멧 종류를 결정
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
			else if (e.Button == toolOrg)  // 원본
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

					ResizeForm(); // 이미지의 크기에 맞춰 폼 크기를 변경
				}
			}
			else if (e.Button == toolBack)  // 배경그림
			{
				if (picMain.Image == null)
					return;

				// C:\back.bmp로 저장
				picMain.Image.Save("C:\\back.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
				// 저장한 이미지를 배경그림으로
				SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, "C:\\back", SPIF_SENDCHANGE);
			}
			else // 기타 이미지 프로세싱
			{
				if (picMain.Image == null)
					return;

				frmProcess frmPro;

				frmPro = new frmProcess();

				frmPro.Text = e.Button.Text; // 폼의 텍스트를 버튼 텍스트로 한다.
				frmPro.Init(this);
				frmPro.ShowDialog();
				frmPro.Dispose();
			}
		}

		// 90도 회전
		private void memu90_Click(object sender, System.EventArgs e)
		{
			if (picMain.Image == null)
				return;


			// 임시 그림을 저장한다.
			picTmp.Image = picMain.Image;
			// 그림을 회전한다.
			picTmp.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
			//원본그림을 표시한다.
			picMain.Image = picTmp.Image;
			ResizeForm();
		}

		// 180도 회전
		private void memu180_Click(object sender, System.EventArgs e)
		{
			if (picMain.Image == null)
				return;


			// 임시 그림을 저장한다.
			picTmp.Image = picMain.Image;
			// 그림을 회전한다.
			picTmp.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
			//원본그림을 표시한다.
			picMain.Image = picTmp.Image;
			ResizeForm();
		}

		// 270도 회전
		private void memu270_Click(object sender, System.EventArgs e)
		{
			if (picMain.Image == null)
				return;


			// 임시 그림을 저장한다.
			picTmp.Image = picMain.Image;
			// 그림을 회전한다.
			picTmp.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
			//원본그림을 표시한다.
			picMain.Image = picTmp.Image;
			ResizeForm();
		}

		// 상하 뒤집기
		private void memuX_Click(object sender, System.EventArgs e)
		{
			if (picMain.Image == null)
				return;


			// 임시 그림을 저장한다.
			picTmp.Image = picMain.Image;
			// 그림을 회전한다.
			picTmp.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
			//원본그림을 표시한다.
			picMain.Image = picTmp.Image;
			ResizeForm();
		}
		
	}
}
