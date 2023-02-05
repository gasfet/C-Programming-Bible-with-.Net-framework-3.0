using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ImgViewer
{
	/// <summary>
	/// Form1에 대한 요약 설명입니다.
	/// </summary>
	public class frmViewer : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.ImageList imglstTmp;
		internal System.Windows.Forms.ToolTip tipPath;
		internal System.Windows.Forms.ColumnHeader ColumnHeader1;
		internal System.Windows.Forms.Panel Panel1;
		internal System.Windows.Forms.Panel Panel4;
		internal System.Windows.Forms.ListView lstDir;
		internal System.Windows.Forms.Label lblPath;
		internal System.Windows.Forms.Panel Panel3;
		internal System.Windows.Forms.PictureBox picSelect;
		private System.Windows.Forms.Splitter splitter1;
		internal System.Windows.Forms.Panel Panel2;
		private System.ComponentModel.IContainer components;

		// 전역변수 선언
		int m_nCnt;
		int m_nSelLabel;

		public frmViewer()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmViewer));
			this.imglstTmp = new System.Windows.Forms.ImageList(this.components);
			this.tipPath = new System.Windows.Forms.ToolTip(this.components);
			this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.Panel4 = new System.Windows.Forms.Panel();
			this.lstDir = new System.Windows.Forms.ListView();
			this.lblPath = new System.Windows.Forms.Label();
			this.Panel3 = new System.Windows.Forms.Panel();
			this.picSelect = new System.Windows.Forms.PictureBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.Panel2 = new System.Windows.Forms.Panel();
			this.Panel1.SuspendLayout();
			this.Panel4.SuspendLayout();
			this.Panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// imglstTmp
			// 
			this.imglstTmp.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imglstTmp.ImageSize = new System.Drawing.Size(16, 16);
			this.imglstTmp.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstTmp.ImageStream")));
			this.imglstTmp.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// ColumnHeader1
			// 
			this.ColumnHeader1.Text = "드라이브 및 폴더";
			this.ColumnHeader1.Width = 200;
			// 
			// Panel1
			// 
			this.Panel1.AutoScroll = true;
			this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.Panel4,
																				 this.Panel3});
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(200, 477);
			this.Panel1.TabIndex = 3;
			// 
			// Panel4
			// 
			this.Panel4.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lstDir,
																				 this.lblPath});
			this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel4.Name = "Panel4";
			this.Panel4.Size = new System.Drawing.Size(196, 321);
			this.Panel4.TabIndex = 1;
			// 
			// lstDir
			// 
			this.lstDir.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					 this.ColumnHeader1});
			this.lstDir.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstDir.Location = new System.Drawing.Point(0, 14);
			this.lstDir.MultiSelect = false;
			this.lstDir.Name = "lstDir";
			this.lstDir.Size = new System.Drawing.Size(196, 307);
			this.lstDir.SmallImageList = this.imglstTmp;
			this.lstDir.TabIndex = 1;
			this.lstDir.View = System.Windows.Forms.View.Details;
			this.lstDir.DoubleClick += new System.EventHandler(this.lstDir_DoubleClick);
			// 
			// lblPath
			// 
			this.lblPath.AutoSize = true;
			this.lblPath.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(43, 14);
			this.lblPath.TabIndex = 0;
			this.lblPath.Text = "Label1";
			this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Panel3
			// 
			this.Panel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.picSelect});
			this.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Panel3.Location = new System.Drawing.Point(0, 321);
			this.Panel3.Name = "Panel3";
			this.Panel3.Size = new System.Drawing.Size(196, 152);
			this.Panel3.TabIndex = 0;
			// 
			// picSelect
			// 
			this.picSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.picSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picSelect.Location = new System.Drawing.Point(5, 8);
			this.picSelect.Name = "picSelect";
			this.picSelect.Size = new System.Drawing.Size(184, 136);
			this.picSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picSelect.TabIndex = 0;
			this.picSelect.TabStop = false;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(200, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 477);
			this.splitter1.TabIndex = 4;
			this.splitter1.TabStop = false;
			// 
			// Panel2
			// 
			this.Panel2.AutoScroll = true;
			this.Panel2.AutoScrollMinSize = new System.Drawing.Size(180, 180);
			this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel2.Location = new System.Drawing.Point(203, 0);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(437, 477);
			this.Panel2.TabIndex = 5;
			this.Panel2.Resize += new System.EventHandler(this.Panel2_Resize);
			// 
			// frmViewer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(640, 477);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Panel2,
																		  this.splitter1,
																		  this.Panel1});
			this.Name = "frmViewer";
			this.Text = "이미지 뷰어";
			this.Load += new System.EventHandler(this.frmViewer_Load);
			this.Panel1.ResumeLayout(false);
			this.Panel4.ResumeLayout(false);
			this.Panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmViewer());
		}

		private void frmViewer_Load(object sender, System.EventArgs e)
		{
			SetFolder("C:\\");
			lblPath.Text = "C:";
			SetImgFile("C:\\");
			m_nSelLabel = -1;

			// 툴팁 연결
			tipPath.SetToolTip(lblPath, lblPath.Text);
		}

		// 드라이브 목록 얻어서 콤보박스에 입력
		// 반환값 : 드라이브 갯수
		private int SetDrive()
		{
			String[] strDrives;
			String strTmp;

			// Up 항목을 추가한다.
			lstDir.Items.Add("..", 0);

			// 드라이브 목록을 얻는다. 
			strDrives = System.IO.Directory.GetLogicalDrives();

			// 얻이진 드라이브 목록을 리스트뷰에 입력한다.
			foreach (string str in strDrives) 
			{
				strTmp = str.Remove(2, 1);
				lstDir.Items.Add(strTmp, 1);
			}
        
			return lstDir.Items.Count; 
		}

		// 하위 폴더를 화면에 출력한다.
		// 반환값 : 성공, 실패
		private bool SetFolder(String strParentPath)
		{
			System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(strParentPath);

			// 리스트뷰의 아이템을 모두 삭제한후
			lstDir.Items.Clear();

			// 드라이브 정보를 보여준다.
			m_nCnt = SetDrive();
			lblPath.Text = "";
			
			try
			{

				foreach (System.IO.DirectoryInfo dirInfoCurDir in dirInfo.GetDirectories("*")) 
				{
					lstDir.Items.Add(dirInfoCurDir.Name.ToString(), 2);
				}
				lblPath.Text = strParentPath.Remove(strParentPath.Length - 1, 1);
			}
			catch
			{
				MessageBox.Show("접근에 실패했습니다.");
				return false;
			}
		
			return true;
		}

		// 그림파일의 유무를 확장자로 찾는다.
		// 반환값 : true, false
		private bool IsImgFile(String strExi)
		{
			//BMP WMF, EMF, ICO, JPG, Gif, PNG
			String strTmp;
			strTmp = strExi.ToUpper();
			if (strTmp.IndexOf(".BMP") != -1)
				return true;
			else if (strTmp.IndexOf(".WMF") != -1) 
				return true;
			else if (strTmp.IndexOf(".EMF") != -1) 
				return true;
			else if (strTmp.IndexOf(".ICO") != -1) 
				return true;
			else if (strTmp.IndexOf(".JPG") != -1) 
				return true;
			else if (strTmp.IndexOf(".GIF") != -1) 
				return true;
			else if (strTmp.IndexOf(".PNG") != -1) 
				return true;
			else
				return false;
		}

		// 그림 파일을 찾아서 보여준다.
		private void SetImgFile(String strParentPath)
		{
			
			System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(strParentPath);
			int nCnt;
						
			Panel2.Controls.Clear();
			nCnt = 0;
	
			try
			{
				foreach (System.IO.FileInfo fileInfo in dirInfo.GetFiles("*.*")) 
				{
					if (IsImgFile(fileInfo.Extension))
					{
						MakePicCtrl(nCnt, fileInfo.FullName);
						nCnt += 1;
						MakeLblCtrl(nCnt, fileInfo.Name);
						nCnt += 1;
						Application.DoEvents();
					}
				}
				lblPath.Text = strParentPath.Remove(strParentPath.Length  - 1, 1);
			}
			catch
			{
			}
		}
	
		// 픽처박스 컨트롤을 생성한다.
		private void MakePicCtrl(int nIndex, String strFilePath)
		{
			PictureBox pic = new PictureBox();
			Point pos;

			pic.Name = "pic" + nIndex.ToString(); // 이름
			pic.SizeMode = PictureBoxSizeMode.StretchImage;
			pic.Tag = nIndex.ToString(); // tag에 컨트롤의 인덱스를 저장
			pic.Size = new Size(80, 80); //크기

			GetPos(nIndex, out pos);

			pic.Location = pos;
			pic.BorderStyle = BorderStyle.FixedSingle;
			Panel2.Controls.Add(pic); // 패널에 추가
						
			try
			{
				pic.Image = System.Drawing.Bitmap.FromFile(strFilePath); // 그림 보여주기
			}
			catch
			{
				pic.Image = null;
			}
			
			// 클릭/더블클릭 이벤트와 연결한다.
			pic.Click += new System.EventHandler(Ctrl_Click);
			pic.DoubleClick += new System.EventHandler(Ctrl_DoubleClick);
		}


		// 라벨 컨트롤을 생성한다.
		private void MakeLblCtrl(int nIndex, String strFileName)
		{
			Label lbl = new Label();
			Point pos;

			lbl.Name = "lbl" + nIndex.ToString(); // 이름
			lbl.Tag = nIndex.ToString();
			lbl.Size = new Size(80, 20); //크기
			lbl.TextAlign = ContentAlignment.MiddleLeft;

			GetPos(nIndex, out pos);

			lbl.Location = pos;
			lbl.BorderStyle = BorderStyle.FixedSingle;
			Panel2.Controls.Add(lbl); // 패널에 추가
			lbl.Text = strFileName; // 그림 이름 보여주기
			lbl.BackColor = Color.GreenYellow;

			// 클릭/더블클릭 이벤트와 연결한다.
			lbl.Click += new System.EventHandler(Ctrl_Click);
			lbl.DoubleClick += new System.EventHandler(Ctrl_DoubleClick);
		}

		private void GetPos(int nIndex, out Point pos)
		{
			pos = new Point();
			Size sizePan = new Size(Panel2.Width, Panel2.Height);
			int nXCnt;
			int i;

			if((nIndex % 2) == 0)// 픽처박스컨트롤일 경우
			{
				nXCnt = (int)(sizePan.Width / 85);

				i = (int)(nIndex / 2) % nXCnt;
				pos.X = (i * 80) + (5 * i) + 5;

				i = (int)((nIndex / 2) / nXCnt);
				pos.Y = (i * 80) + (35 * i) + 5;
			}
			else // 라벨 컨트롤일 경우
			{
				nXCnt = (int)(sizePan.Width / 85);

				i = (int)(nIndex / 2) % nXCnt;
				pos.X = (i * 80) + (5 * i) + 5;

				i = (int)((nIndex / 2) / nXCnt);
				pos.Y = (i * 80) + (35 * i) + 5 + 82;
			}
		}

		
		// 컨트롤 인덱스에 따른 위치를 결정한다.
		// 패널 크기에 맞춰 픽처박스 컨트롤의 위치를 재지정 한다.
		private void MovePicCtrl()
		{
			int i=0;
			Point pos;

			Control.ControlCollection myCtrl = Panel2.Controls;

			foreach(Control ctl in myCtrl)    
			{
				GetPos(i, out pos);
				ctl.Location = pos;
				i++;
			}

		}

		// 필요한 컨트롤을 얻는다.
		private Control GetCtrl(String strCtrlName, int nTag)
		{
			Control.ControlCollection myCtrl = Panel2.Controls;

			foreach(Control ctl in myCtrl)    
			{
				// 컨트롤 종류가 일치하고
				if(ctl.GetType().Name.IndexOf(strCtrlName) != -1)
				{
					// 태그가 일치하면
					if(Convert.ToInt32(ctl.Tag.ToString()) == nTag)
						return ctl;
				}
			}

			return null;

		}

		// 동적생성 컨트롤의 클릭/더블클릭 이벤트
		private void Ctrl_Click(object sender, System.EventArgs e)
		{
			PictureBox pic;
			Label lbl;

			if(sender.GetType().Name.IndexOf("PictureBox") != -1) // 클릭한 컨트롤이 픽처박스일 경우
			{
				pic = (System.Windows.Forms.PictureBox)sender;

				// 라벨 컨트롤을 얻는다.
				lbl = (System.Windows.Forms.Label)GetCtrl("Label", Convert.ToInt32(pic.Tag) + 1);
			}
			else // 클릭한 컨트롤이 라벨일 경우
			{
				lbl = (System.Windows.Forms.Label)sender;

				// 픽처박스 컨트롤을 얻는다.
				pic = (System.Windows.Forms.PictureBox)GetCtrl("PictureBox", Convert.ToInt32(lbl.Tag) - 1);
			}
            

			// 클릭한 픽처박스의 내용을 picSelect에 보여준다.
			picSelect.Image = pic.Image;

			// 선택한 라벨 컨트롤의 색을 노란색으로 한다.
			lbl.BackColor = Color.Yellow;

        	//이전에 선택한 라벨 컨트롤의 색을 GreenYellow로 한다.
			if (m_nSelLabel != -1 && m_nSelLabel != Convert.ToInt32(lbl.Tag)) 
				GetCtrl("Label", m_nSelLabel).BackColor = Color.GreenYellow;

			m_nSelLabel = Convert.ToInt32(lbl.Tag);
		}
		
		private void Ctrl_DoubleClick(object sender, System.EventArgs e)
		{
			PictureBox pic;
			Label lbl;

			if(sender.GetType().Name.IndexOf("PictureBox") != -1) // 클릭한 컨트롤이 픽처박스일 경우
			{
				pic = (System.Windows.Forms.PictureBox)sender;

				// 라벨 컨트롤을 얻는다.
				lbl = (System.Windows.Forms.Label)GetCtrl("Label", Convert.ToInt32(pic.Tag) + 1);
			}
			else // 클릭한 컨트롤이 라벨일 경우
			{
				lbl = (System.Windows.Forms.Label)sender;
			}


			// 폼을 생성한다.
			ImgViewer.frmSelect dlg = new ImgViewer.frmSelect();
			Size sizePic = new Size();

			// 폼의 캡션을 그림의 전체 경로로 한다.
			dlg.Text = "그림 선택 - " + lblPath.Text + "\\" + lbl.Text;
			// 선택한 그림을 picSel에 보여준다.
			dlg.picSel.Image = System.Drawing.Bitmap.FromFile(lblPath.Text + "\\" + lbl.Text);

			// 폼의 크기를 적당히 조절한다.
			sizePic = dlg.picSel.Size;
			sizePic.Height += 30;
			sizePic.Width += 15;

			dlg.Size = sizePic;
			dlg.picSel.Location = new Point(5, 5);

			// 폼을 모달 형태로 보여준다.
			dlg.ShowDialog();
		}

		private void Panel2_Resize(object sender, System.EventArgs e)
		{
			MovePicCtrl();
		}

		// 리스트뷰 더블클릭
		// 폴더/드라이브 변경 처리
		private void lstDir_DoubleClick(object sender, System.EventArgs e)
		{
			int nSel;
			String strSelText;
			String strTmp;

			// 선택된 항목의 텍스트와 인덱스를 얻는다.
			nSel = lstDir.SelectedItems[0].Index;
			strSelText = lstDir.SelectedItems[0].SubItems[0].Text;
        
	        m_nSelLabel = -1;
		    picSelect.Image = null;

			if (nSel == 0) // 위로 
			{
				int nStart;

				nStart = lblPath.Text.LastIndexOf("\\");
				if (nStart == -1) 
					return;
            
				strTmp = lblPath.Text.Remove(nStart, lblPath.Text.Length  - nStart) + "\\";
			}
			else if(m_nCnt > nSel) // 드라이브 클릭
				strTmp = strSelText + "\\";
			else    
				strTmp = lblPath.Text + "\\" + strSelText + "\\";
        

			// 하위 폴더들을 보여준다.
			if (SetFolder(strTmp)) 
				SetImgFile(strTmp);
			

			// 툴팁 연결
			tipPath.SetToolTip(lblPath, lblPath.Text);
		}

	}
}
