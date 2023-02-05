using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MDIViewer
{
	/// <summary>
	/// Form1에 대한 요약 설명입니다.
	/// </summary>
	public class frmMDI : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.MainMenu mnuMainMenu;
		internal System.Windows.Forms.MenuItem mnuFile;
		internal System.Windows.Forms.MenuItem mnuOpen;
		internal System.Windows.Forms.MenuItem MenuItem5;
		internal System.Windows.Forms.MenuItem mnuExit;
		internal System.Windows.Forms.MenuItem mnuWindow;
		internal System.Windows.Forms.MenuItem mnuHorizntal;
		internal System.Windows.Forms.MenuItem mnuVertical;
		internal System.Windows.Forms.MenuItem mnuCascade;
		internal System.Windows.Forms.MenuItem mnuIcon;
		internal System.Windows.Forms.Panel panTab;
		internal System.Windows.Forms.TabControl tabCtrl;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMDI()
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
			this.mnuMainMenu = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuOpen = new System.Windows.Forms.MenuItem();
			this.MenuItem5 = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.mnuWindow = new System.Windows.Forms.MenuItem();
			this.mnuHorizntal = new System.Windows.Forms.MenuItem();
			this.mnuVertical = new System.Windows.Forms.MenuItem();
			this.mnuCascade = new System.Windows.Forms.MenuItem();
			this.mnuIcon = new System.Windows.Forms.MenuItem();
			this.panTab = new System.Windows.Forms.Panel();
			this.tabCtrl = new System.Windows.Forms.TabControl();
			this.panTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMainMenu
			// 
			this.mnuMainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.mnuFile,
																						this.mnuWindow});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuOpen,
																					this.MenuItem5,
																					this.mnuExit});
			this.mnuFile.Text = "파일";
			// 
			// mnuOpen
			// 
			this.mnuOpen.Index = 0;
			this.mnuOpen.Text = "열기";
			this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
			// 
			// MenuItem5
			// 
			this.MenuItem5.Index = 1;
			this.MenuItem5.Text = "-";
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 2;
			this.mnuExit.Text = "종료";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// mnuWindow
			// 
			this.mnuWindow.Index = 1;
			this.mnuWindow.MdiList = true;
			this.mnuWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuHorizntal,
																					  this.mnuVertical,
																					  this.mnuCascade,
																					  this.mnuIcon});
			this.mnuWindow.Text = "창";
			// 
			// mnuHorizntal
			// 
			this.mnuHorizntal.Index = 0;
			this.mnuHorizntal.Text = "수평바둑판식으로";
			this.mnuHorizntal.Click += new System.EventHandler(this.mnuHorizntal_Click);
			// 
			// mnuVertical
			// 
			this.mnuVertical.Index = 1;
			this.mnuVertical.Text = "수직바둑판식으로";
			this.mnuVertical.Click += new System.EventHandler(this.mnuVertical_Click);
			// 
			// mnuCascade
			// 
			this.mnuCascade.Index = 2;
			this.mnuCascade.Text = "계단식으로";
			this.mnuCascade.Click += new System.EventHandler(this.mnuCascade_Click);
			// 
			// mnuIcon
			// 
			this.mnuIcon.Index = 3;
			this.mnuIcon.Text = "아이콘정렬";
			this.mnuIcon.Click += new System.EventHandler(this.mnuIcon_Click);
			// 
			// panTab
			// 
			this.panTab.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.tabCtrl});
			this.panTab.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panTab.Location = new System.Drawing.Point(0, 377);
			this.panTab.Name = "panTab";
			this.panTab.Size = new System.Drawing.Size(520, 24);
			this.panTab.TabIndex = 2;
			// 
			// tabCtrl
			// 
			this.tabCtrl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabCtrl.Name = "tabCtrl";
			this.tabCtrl.SelectedIndex = 0;
			this.tabCtrl.Size = new System.Drawing.Size(520, 24);
			this.tabCtrl.TabIndex = 0;
			this.tabCtrl.SelectedIndexChanged += new System.EventHandler(this.tabCtrl_SelectedIndexChanged);
			// 
			// frmMDI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(520, 401);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panTab});
			this.IsMdiContainer = true;
			this.Menu = this.mnuMainMenu;
			this.Name = "frmMDI";
			this.Text = "MDIPlayer";
			this.MdiChildActivate += new System.EventHandler(this.frmMDI_MdiChildActivate);
			this.Load += new System.EventHandler(this.frmMDI_Load);
			this.panTab.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMDI());
		}


		
		//사용자 정의 함수
    
    
		// 파일의 이름만 얻는다.
		private String GetTitle(String strPath)
		{
			int nLen, nFind;
			String strTitle;

			nLen = strPath.Length;
			nFind = strPath.LastIndexOf("\\");
			strTitle = strPath.Substring(nFind + 2);
			strTitle = strTitle.Substring(1, strTitle.Length - 4);

			return strTitle;

		}


    
		// 이미 열려있는 파일인지 확인한다.
		private bool IsExitFileName(String strPath)
		{
			bool bExist;

			bExist = false;
			foreach(Form frmTemp in this.MdiChildren)    
			{

				if(frmTemp.Text.Equals(strPath)) 
				{
					bExist = true;
					break;
				}

			}

			return bExist;

		}


    
		// 자식 폼이 닫힐 때 호출되어 TabPage를 제거한다.
		public void RemoveTabItem(String strText)
		{
			int nIndex;
			String strTitle;

			//현재 닫히는 폼과 연계된 TabPage를 찾아 제거한다.
			for(nIndex = 0 ; nIndex < tabCtrl.TabPages.Count ; nIndex++)
			{
				strTitle = tabCtrl.TabPages[nIndex].Text;

				if(strText.Equals(strTitle)) 
				{
					tabCtrl.TabPages.RemoveAt(nIndex);
					break;
				}

			}

		}

		/////////////// 이벤트 함수 /////////////////////////
		
		// 폼 로드
		private void frmMDI_Load(object sender, System.EventArgs e)
		{
			tabCtrl.Alignment = TabAlignment.Bottom;
		}

		// 자식 폼이 활성화/닫힐 시에 호출된다.
		private void frmMDI_MdiChildActivate(object sender, System.EventArgs e)
		{
			//활성화된 자식 폼을 얻는다.
			Form ActiveChild  = this.ActiveMdiChild;
			String strTitle;              //폼의 Tag 값을 나타낸다.
			int nIndex = 0;

			if (ActiveChild != null)
			{            
				if(ActiveChild.Tag != null)
				{
					//폼의 Tag 값을 얻는다.
					strTitle = ActiveChild.Tag.ToString();

					//Tab 선택
					String strTemp;
					int nCnt, i;

					nCnt = tabCtrl.TabCount; 

					//탭컨트롤에서 폼의 Tag 값과 같은 탭 Text를 갖고 있는 것을 찾아 선택해준다.
					for(i=0 ; i<nCnt ; i++)
					{
						strTemp = tabCtrl.TabPages[nIndex].Text;

						if(strTitle.Equals(strTemp))
						{
							tabCtrl.SelectedIndex = nIndex;
							break;
						}

						nIndex += 1;
					}

				}

			}

		}

		// 탭 컨트롤 선택 변경시 연계된 폼을 활성화한다.
		private void tabCtrl_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//만약 탭페이지가 없다면 return
			if(tabCtrl.TabCount <= 0) 
				return;
        

			String strName;
			int nSelected;

			nSelected = tabCtrl.SelectedIndex;

				//선택된 탭 TEXT를 얻는다.
				strName = tabCtrl.TabPages[nSelected].Text;

			//탭 아이템의 Text와 같은 값을 갖고 있는 폼의 Tag를 찾아 폼을 활성화한다.

			

			foreach(Form frmTemp in this.MdiChildren)    
			{
		
				if(frmTemp.Tag.ToString().Equals(strName))
				{
					frmTemp.Activate();
					break;
				}

			}
		}
		
	
		// 열기
		private void mnuOpen_Click(object sender, System.EventArgs e)
		{
		        
			OpenFileDialog OpenFileDlg = new OpenFileDialog();

			//파일 오픈
			OpenFileDlg.Filter = "Multimedia files (*.mpg;*.avi;*.asf;*.dat;*.mp3)|*.mpg;*.avi;*.asf;*.dat;*.mp3";

			OpenFileDlg.FilterIndex = 0;
			OpenFileDlg.RestoreDirectory = true;
			OpenFileDlg.Multiselect = true;
			OpenFileDlg.Title = "Multimedia Files 선택";

			if(OpenFileDlg.ShowDialog() == DialogResult.OK) 
			{
				String strTitle;

				foreach(String strPath in OpenFileDlg.FileNames)    
				{

					System.Windows.Forms.Application.DoEvents();

					//이미 열려진 파일이라면 폼을 생성하지 않는다. 이는 제일 쉬운 방법인 폼 Tag의 값만을 비교한다.
					//전체 경로를 지정하여 비교하는 방법도 있을 수 있다. 이때는 탭의 Text는 파일 이름만을 나타내고 Tag를 이용하여 경로를 지정한다.
					if(IsExitFileName(strPath) == false) 
					{
						strTitle = GetTitle(strPath);    //파일명

						//자식 폼 생성
						frmChild frmPlayer = new frmChild();

                     
						frmPlayer.MdiParent = this;                 //부모를 지정
						frmPlayer.mpPlayer.FileName = strPath;    //재생할 경로 설정
						frmPlayer.Text = strPath;   //폼의 타이틀바 
						frmPlayer.Tag = strTitle;                 //TabPage와 연계할 값 지정
						frmPlayer.Show();
                    

						//TabPage 생성
						TabPage tabPage = new TabPage();
						tabPage.Text = strTitle;             //폼과 연계할 값 지정

						//TabControl에 추가
						tabCtrl.TabPages.Add(tabPage);
					}

				}

			}

			//다시 그리기
			this.Refresh();


		}

		// 종료
		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			//자식 폼
			foreach(Form frmTemp in this.MdiChildren)    
			{
				frmTemp.Dispose();
			}

			//TabPage
			int nIndex;

			//현재 닫히는 폼과 연계된 TabPage를 찾아 제거한다.
			for(nIndex = 0 ; nIndex < tabCtrl.TabPages.Count ; nIndex++)
				tabCtrl.TabPages[nIndex].Dispose();


			//TabControl
			tabCtrl.Dispose();

			//부모 폼
			this.Dispose();
		}

		// 수평바둑판식
		private void mnuHorizntal_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileHorizontal);

		}

		// 수직바둑판식
		private void mnuVertical_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileVertical);

		}

		// 계단식
		private void mnuCascade_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}

		// 아이콘 정렬
		private void mnuIcon_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.ArrangeIcons);
		}

	}
}
