using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MyPlayer
{
	/// <summary>
	/// Form1에 대한 요약 설명입니다.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.ImageList imlButton;
		internal System.Windows.Forms.Timer tmTimer;
		internal System.Windows.Forms.NotifyIcon NotifyIcon;
		internal System.Windows.Forms.ContextMenu popMenu;
		internal System.Windows.Forms.MenuItem mnuShow;
		internal System.Windows.Forms.MenuItem mnuSep1;
		internal System.Windows.Forms.MenuItem mnuExit;
		internal System.Windows.Forms.PictureBox picList;
		internal System.Windows.Forms.Label lblTime;
		internal System.Windows.Forms.Label lblTitle;
		internal System.Windows.Forms.PictureBox picEject;
		internal System.Windows.Forms.PictureBox picEnd;
		internal System.Windows.Forms.PictureBox picStop;
		internal System.Windows.Forms.PictureBox picPause;
		internal System.Windows.Forms.PictureBox picPlay;
		internal System.Windows.Forms.PictureBox picStart;
		internal System.Windows.Forms.Label lblPlayState;
		internal System.Windows.Forms.PictureBox picPlayState;
		private AxMSComctlLib.AxSlider playSliderBar;
		private AxMediaPlayer.AxMediaPlayer mpPlayer;
		private AxMSComctlLib.AxSlider volumeSliderBar;
		private System.ComponentModel.IContainer components;


		const int SECOND = 1000;		//타이머 간격
		const int BUTTON_BUNDLE = 3;    //버튼의 묶음(버튼은 각각 UP/DOWN/DISABLE 3개의 묶음을 갖고 있다)

		int m_nMinutes; //음악 시간의 분을 나타낸다.
		int m_nSeconds; //음악 시간의 초를 나타낸다.

		//플레이어의 상태를 저장한다.
		int m_nPlayState;
		MyPlayer.frmList frmPlayList = new MyPlayer.frmList();
		
		public Point m_ptFrmList = new Point();
		public Size m_szForm = new Size();
		
		public bool m_bShowPlayList;

		enum PLAY_STATE 
		{
			PS_START = 0,	//'시작 위치
			PS_PLAY,		//연주
			PS_PAUSE,		//일시정지
			PS_STOP,		//멈춤
			PS_END,			//끝 위치
			PS_EJECT		//파일 열기
		};
		
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
			this.imlButton = new System.Windows.Forms.ImageList(this.components);
			this.tmTimer = new System.Windows.Forms.Timer(this.components);
			this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.popMenu = new System.Windows.Forms.ContextMenu();
			this.mnuShow = new System.Windows.Forms.MenuItem();
			this.mnuSep1 = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.picList = new System.Windows.Forms.PictureBox();
			this.lblTime = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.picEject = new System.Windows.Forms.PictureBox();
			this.picEnd = new System.Windows.Forms.PictureBox();
			this.picStop = new System.Windows.Forms.PictureBox();
			this.picPause = new System.Windows.Forms.PictureBox();
			this.picPlay = new System.Windows.Forms.PictureBox();
			this.picStart = new System.Windows.Forms.PictureBox();
			this.lblPlayState = new System.Windows.Forms.Label();
			this.picPlayState = new System.Windows.Forms.PictureBox();
			this.playSliderBar = new AxMSComctlLib.AxSlider();
			this.mpPlayer = new AxMediaPlayer.AxMediaPlayer();
			this.volumeSliderBar = new AxMSComctlLib.AxSlider();
			((System.ComponentModel.ISupportInitialize)(this.playSliderBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mpPlayer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.volumeSliderBar)).BeginInit();
			this.SuspendLayout();
			// 
			// imlButton
			// 
			this.imlButton.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imlButton.ImageSize = new System.Drawing.Size(21, 17);
			this.imlButton.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlButton.ImageStream")));
			this.imlButton.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tmTimer
			// 
			this.tmTimer.Interval = 1000;
			this.tmTimer.Tick += new System.EventHandler(this.tmTimer_Tick);
			// 
			// NotifyIcon
			// 
			this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
			this.NotifyIcon.Text = "MyPlayer";
			this.NotifyIcon.Visible = true;
			// 
			// popMenu
			// 
			this.popMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuShow,
																					this.mnuSep1,
																					this.mnuExit});
			// 
			// mnuShow
			// 
			this.mnuShow.Index = 0;
			this.mnuShow.Text = "보이기";
			this.mnuShow.Click += new System.EventHandler(this.mnuShow_Click);
			// 
			// mnuSep1
			// 
			this.mnuSep1.Index = 1;
			this.mnuSep1.Text = "-";
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 2;
			this.mnuExit.Text = "종료";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// picList
			// 
			this.picList.Image = ((System.Drawing.Bitmap)(resources.GetObject("picList.Image")));
			this.picList.Location = new System.Drawing.Point(206, 80);
			this.picList.Name = "picList";
			this.picList.Size = new System.Drawing.Size(22, 17);
			this.picList.TabIndex = 29;
			this.picList.TabStop = false;
			this.picList.Click += new System.EventHandler(this.picList_Click);
			this.picList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picList_MouseUp);
			this.picList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picList_MouseDown);
			// 
			// lblTime
			// 
			this.lblTime.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(153)), ((System.Byte)(204)));
			this.lblTime.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.lblTime.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lblTime.Location = new System.Drawing.Point(16, 32);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(92, 20);
			this.lblTime.TabIndex = 28;
			this.lblTime.Text = "Label1";
			this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTitle
			// 
			this.lblTitle.BackColor = System.Drawing.Color.White;
			this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(153)), ((System.Byte)(204)));
			this.lblTitle.Location = new System.Drawing.Point(-4, 4);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(252, 22);
			this.lblTitle.TabIndex = 27;
			this.lblTitle.Text = "Title";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// picEject
			// 
			this.picEject.Image = ((System.Drawing.Bitmap)(resources.GetObject("picEject.Image")));
			this.picEject.Location = new System.Drawing.Point(146, 80);
			this.picEject.Name = "picEject";
			this.picEject.Size = new System.Drawing.Size(22, 17);
			this.picEject.TabIndex = 26;
			this.picEject.TabStop = false;
			this.picEject.Click += new System.EventHandler(this.picEject_Click);
			this.picEject.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picEject_MouseUp);
			this.picEject.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picEject_MouseDown);
			// 
			// picEnd
			// 
			this.picEnd.Image = ((System.Drawing.Bitmap)(resources.GetObject("picEnd.Image")));
			this.picEnd.Location = new System.Drawing.Point(108, 80);
			this.picEnd.Name = "picEnd";
			this.picEnd.Size = new System.Drawing.Size(22, 17);
			this.picEnd.TabIndex = 25;
			this.picEnd.TabStop = false;
			this.picEnd.Click += new System.EventHandler(this.picEnd_Click);
			this.picEnd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picEnd_MouseUp);
			this.picEnd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picEnd_MouseDown);
			// 
			// picStop
			// 
			this.picStop.Image = ((System.Drawing.Bitmap)(resources.GetObject("picStop.Image")));
			this.picStop.Location = new System.Drawing.Point(84, 80);
			this.picStop.Name = "picStop";
			this.picStop.Size = new System.Drawing.Size(22, 17);
			this.picStop.TabIndex = 24;
			this.picStop.TabStop = false;
			this.picStop.Click += new System.EventHandler(this.picStop_Click);
			this.picStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picStop_MouseUp);
			this.picStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picStop_MouseDown);
			// 
			// picPause
			// 
			this.picPause.Image = ((System.Drawing.Bitmap)(resources.GetObject("picPause.Image")));
			this.picPause.Location = new System.Drawing.Point(60, 80);
			this.picPause.Name = "picPause";
			this.picPause.Size = new System.Drawing.Size(22, 17);
			this.picPause.TabIndex = 23;
			this.picPause.TabStop = false;
			this.picPause.Click += new System.EventHandler(this.picPause_Click);
			this.picPause.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picPause_MouseUp);
			this.picPause.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPause_MouseDown);
			// 
			// picPlay
			// 
			this.picPlay.Image = ((System.Drawing.Bitmap)(resources.GetObject("picPlay.Image")));
			this.picPlay.Location = new System.Drawing.Point(36, 80);
			this.picPlay.Name = "picPlay";
			this.picPlay.Size = new System.Drawing.Size(22, 17);
			this.picPlay.TabIndex = 22;
			this.picPlay.TabStop = false;
			this.picPlay.Click += new System.EventHandler(this.picPlay_Click);
			this.picPlay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picPlay_MouseUp);
			this.picPlay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPlay_MouseDown);
			// 
			// picStart
			// 
			this.picStart.Image = ((System.Drawing.Bitmap)(resources.GetObject("picStart.Image")));
			this.picStart.Location = new System.Drawing.Point(12, 80);
			this.picStart.Name = "picStart";
			this.picStart.Size = new System.Drawing.Size(22, 17);
			this.picStart.TabIndex = 21;
			this.picStart.TabStop = false;
			this.picStart.Tag = "";
			this.picStart.Click += new System.EventHandler(this.picStart_Click);
			this.picStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picStart_MouseUp);
			this.picStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picStart_MouseDown);
			// 
			// lblPlayState
			// 
			this.lblPlayState.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(153)), ((System.Byte)(204)));
			this.lblPlayState.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lblPlayState.Location = new System.Drawing.Point(128, 32);
			this.lblPlayState.Name = "lblPlayState";
			this.lblPlayState.Size = new System.Drawing.Size(90, 20);
			this.lblPlayState.TabIndex = 20;
			this.lblPlayState.Text = "Label1";
			this.lblPlayState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// picPlayState
			// 
			this.picPlayState.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(153)), ((System.Byte)(204)));
			this.picPlayState.Location = new System.Drawing.Point(6, 28);
			this.picPlayState.Name = "picPlayState";
			this.picPlayState.Size = new System.Drawing.Size(230, 26);
			this.picPlayState.TabIndex = 19;
			this.picPlayState.TabStop = false;
			// 
			// playSliderBar
			// 
			this.playSliderBar.Location = new System.Drawing.Point(6, 54);
			this.playSliderBar.Name = "playSliderBar";
			this.playSliderBar.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("playSliderBar.OcxState")));
			this.playSliderBar.Size = new System.Drawing.Size(172, 16);
			this.playSliderBar.TabIndex = 30;
			this.playSliderBar.TabStop = false;
			this.playSliderBar.Scroll += new System.EventHandler(this.playSliderBar_Scroll);
			// 
			// mpPlayer
			// 
			this.mpPlayer.Location = new System.Drawing.Point(178, 8);
			this.mpPlayer.Name = "mpPlayer";
			this.mpPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mpPlayer.OcxState")));
			this.mpPlayer.Size = new System.Drawing.Size(120, 24);
			this.mpPlayer.TabIndex = 31;
			this.mpPlayer.Visible = false;
			// 
			// volumeSliderBar
			// 
			this.volumeSliderBar.Location = new System.Drawing.Point(190, 54);
			this.volumeSliderBar.Name = "volumeSliderBar";
			this.volumeSliderBar.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("volumeSliderBar.OcxState")));
			this.volumeSliderBar.Size = new System.Drawing.Size(46, 16);
			this.volumeSliderBar.TabIndex = 32;
			this.volumeSliderBar.TabStop = false;
			this.volumeSliderBar.Scroll += new System.EventHandler(this.volumeSliderBar_Scroll);
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(244, 101);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.volumeSliderBar,
																		  this.mpPlayer,
																		  this.playSliderBar,
																		  this.picList,
																		  this.lblTime,
																		  this.lblTitle,
																		  this.picEject,
																		  this.picEnd,
																		  this.picStop,
																		  this.picPause,
																		  this.picPlay,
																		  this.picStart,
																		  this.lblPlayState,
																		  this.picPlayState});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.Text = "MyPlayer";
			this.Resize += new System.EventHandler(this.frmMain_Resize);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.LocationChanged += new System.EventHandler(this.frmMain_LocationChanged);
			((System.ComponentModel.ISupportInitialize)(this.playSliderBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mpPlayer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.volumeSliderBar)).EndInit();
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

		private void frmMain_Load(object sender, System.EventArgs e)
		{
			InitData();  //데이터 초기화
		}

		//-------------------------------------------------------------------
		//함수 : InitData
		//인자 : None
		//설명 : 데이터 초기화
		//-------------------------------------------------------------------
		private void InitData()
		{
			//트레이 아이콘 정보 설정
			this.NotifyIcon.ContextMenu = this.popMenu;  //트레이 메뉴
			this.NotifyIcon.Text = "My MP3 Player";    //트레이 팁

			lblTitle.Text = "";

			//시간 변수 초기화
			m_nMinutes = 0;
			m_nSeconds = 0;

			//Timer
			tmTimer.Enabled = false;

			//미디어 플레이어의 디스플레이모드를 프레임 단위가 아닌 시간 단위로 설정한다.
			mpPlayer.DisplayMode = MediaPlayer.MPDisplayModeConstants.mpTime;

			//자동 되감기는 설정하지 않는다.
			mpPlayer.AutoRewind = false;

			//플레이어 시간 설정
			SetPlayTime();

			//플레이어 상태 설정
			setPlayState((int)PLAY_STATE.PS_START);

			//아직 파일이 열리지 않았으므로 버튼을 비활성화 시킨다.
			//단 EJECT 버튼은 음악 파일을 열기위해 언제나 활성화 상태이다.
			EnableButton(false);

			//연주 슬라이더바 범위지정
			playSliderBar.Min = 0;
			playSliderBar.Max = 100;

			//볼륨 슬라이더바 범위지정
			volumeSliderBar.Min = 0;
			volumeSliderBar.Max = 100;
			volumeSliderBar.Value = 80;

			//볼륨은 0 ~ -10000까지의 값을 갖으며, 0 이 제일 높은 볼륨을 나타낸다.
			mpPlayer.Volume = (80 * 100) - 10000;

			//frmList가 보이지 않고 있음을 설정
			m_bShowPlayList = false;
			//frmList의 넓이를 frmMain의 넓이에 맞추기 위해 크기 저장
			m_szForm = this.Size;
			//frmList에서 frmMain의 Public을 다루기 위해 frmMain을 지정해 둔다.
			frmPlayList.SetParent(this);

		}

		//-------------------------------------------------------------------
		//함수 : SetPlayTime
		//인자 : 
		//설명 : 플레이어의 시간 설정
		//-------------------------------------------------------------------
		private void SetPlayTime()
		{
			//현재의 시간을 계산
			CheckTime();

			//플레이어의 시간 설정
			lblTime.Text = String.Format(m_nMinutes.ToString(), "00:") + String.Format(m_nSeconds.ToString(), "00");

		}


		//-------------------------------------------------------------------
		//함수 : CheckTime
		//인자 : None
		//설명 : 플레이어의 시간을 체크한다.
		//-------------------------------------------------------------------
		private void CheckTime()
		{
			double dbTime;
			int nTime;

			//현 위치의 시간을 얻는다.
			dbTime = mpPlayer.CurrentPosition;

			if(dbTime < 0) 
				dbTime = 0.0;

			//즉 반올림이 일어나는 것을 막습니다.
			nTime = (int)(dbTime);

			//시간을 설정한다. 
			m_nSeconds = nTime % 60;
			m_nMinutes = (int)(nTime / 60);

		}

		
		//-------------------------------------------------------------------
		//함수 : setPlayState
		//인자 : nState - 상태
		//설명 : 플레이어의 상태를 Label에 나타낸다.
		//-------------------------------------------------------------------
		private void setPlayState(int nState)
		{
			switch(nState)
			{
				case (int)PLAY_STATE.PS_START:
					lblPlayState.Text = "READY";
					break;
				case (int)PLAY_STATE.PS_PLAY:
					lblPlayState.Text = "PLAY";
					break;
				case (int)PLAY_STATE.PS_PAUSE:
					lblPlayState.Text = "PAUSE";
					break;
				case (int)PLAY_STATE.PS_STOP:
					lblPlayState.Text = "STOP";
					break;
				case (int)PLAY_STATE.PS_END:
					lblPlayState.Text = "END";
					break;
				case (int)PLAY_STATE.PS_EJECT:
					lblPlayState.Text = "EJECT";
					break;
			}
	
	
		}

		
	    //-------------------------------------------------------------------
		//함수 : EnableButton
		//인자 : bEnable - 활성(true)/비활성(false)
		//설명 : 플레이어 버튼의 활성화/비활성화
		//-------------------------------------------------------------------
		private void EnableButton(bool bEnable)
		{
			if(bEnable)   //활성화 이미지
			{
				picStart.Image = imlButton.Images[(int)PLAY_STATE.PS_START * BUTTON_BUNDLE];
				picPlay.Image = imlButton.Images[(int)PLAY_STATE.PS_PLAY * BUTTON_BUNDLE];
				picPause.Image = imlButton.Images[(int)PLAY_STATE.PS_PAUSE * BUTTON_BUNDLE];
				picStop.Image = imlButton.Images[(int)PLAY_STATE.PS_STOP * BUTTON_BUNDLE];
				picEnd.Image = imlButton.Images[(int)PLAY_STATE.PS_END * BUTTON_BUNDLE];
			}
			else                    //비활성화 이미지
			{
				picStart.Image = imlButton.Images[(int)PLAY_STATE.PS_START * BUTTON_BUNDLE + 2];
				picPlay.Image = imlButton.Images[(int)PLAY_STATE.PS_PLAY * BUTTON_BUNDLE + 2];
				picPause.Image = imlButton.Images[(int)PLAY_STATE.PS_PAUSE * BUTTON_BUNDLE + 2];
				picStop.Image = imlButton.Images[(int)PLAY_STATE.PS_STOP * BUTTON_BUNDLE + 2];
				picEnd.Image = imlButton.Images[(int)PLAY_STATE.PS_END * BUTTON_BUNDLE + 2];
			}

			picStart.Enabled = bEnable;
			picPlay.Enabled = bEnable;
			picPause.Enabled = bEnable;
			picStop.Enabled = bEnable;
			picEnd.Enabled = bEnable;

		}


		//-------------------------------------------------------------------
		//함수 : GetTitle
		//인자 : strPath - 파일의 전체경로
		//설명 : 파일의 이름만 얻는다.
		//-------------------------------------------------------------------
		private String GetTitle(String strPath)
		{
			int nLen;
			int nFind;
			String strTitle;

			nLen = strPath.Length;
			nFind = strPath.LastIndexOf("\\");
			strTitle = strPath.Substring(nFind + 2);
			strTitle = strTitle.Substring(1, strTitle.Length - 4);

			return strTitle;
		}


		//-------------------------------------------------------------------
		//함수 : GetPlayTime
		//인자 : None
		//설명 : 파일의 전체 연주시간을 얻는다.
		//-------------------------------------------------------------------
		private String GetPlayTime()
		{
			//플레이어의 시간 설정
			String strTime;
			
			mpPlayer.CurrentPosition = mpPlayer.Duration;
			CheckTime();

			strTime = String.Format(m_nMinutes.ToString(), "00:") + String.Format(m_nSeconds.ToString(), "00");

			return strTime;

		}


		//-------------------------------------------------------------------
		//함수 : PlayMusic
		//인자 : strPath - 파일의 전체 경로
		//설명 : 파일 연주
		//-------------------------------------------------------------------
		public void PlayMusic(String strPath)
		{
			mpPlayer.Stop();
			mpPlayer.FileName = strPath;
			m_nMinutes = 0;
			m_nSeconds = 0;

			//Title
			lblTitle.Text = GetTitle(strPath);

			setPlayState((int)PLAY_STATE.PS_START);
			SetPlayTime();

			EnableButton(true);

			//SliderBar의 범위지정
			playSliderBar.Min = 0;
			playSliderBar.Max = (int)mpPlayer.SelectionEnd;
			playSliderBar.Value = 0;

			tmTimer.Enabled = true;
			tmTimer.Interval = SECOND;
			mpPlayer.Play();

			setPlayState((int)PLAY_STATE.PS_PLAY);
		}


		// 이벤트 함수 시작 ///////////////////////

		// 타이머
		private void tmTimer_Tick(object sender, System.EventArgs e)
		{
			//분과 초를 표시한다.
			SetPlayTime();

			playSliderBar.Value = (int)mpPlayer.CurrentPosition;

			//한곡의 연주가 끝났다
			if(mpPlayer.CurrentPosition >= mpPlayer.Duration)
			{
				//연주리스트에 연주할 다음 곡이 있는 확인한다.
				if(frmPlayList.IsNextItem())
				{
					String strPath;
					int nIndex;

					//현재 연주한 리스트 아이템 인덱스에 +1을 하여 다음 인덱스를 얻는다
					nIndex = frmPlayList.GetPlayIndex() + 1;
					frmPlayList.SetPlayIndex(nIndex);

					//인덱스를 가지고 frmList의 컬렉션에 저장해둔 경로 값을 얻는다.
					//연주할 파일의 경로를 얻는다.
					strPath = frmPlayList.GetItemPath(nIndex);

					if(!strPath.Equals(""))
						PlayMusic(strPath);
				}
				else
				{
					//연주리스트에 있는 파일들을 전부 연주했다면 초기화
					setPlayState((int)PLAY_STATE.PS_START);
					tmTimer.Enabled = false;
					mpPlayer.Stop();
					mpPlayer.CurrentPosition = 0;
					playSliderBar.Value = 0;

					//시간 초기화
					m_nMinutes = 0;
					m_nSeconds = 0;

					SetPlayTime();

				}

			}

		}

		// 맨 앞으로
		private void picStart_Click(object sender, System.EventArgs e)
		{
		    if( mpPlayer.PlayState == MediaPlayer.MPPlayStateConstants.mpPlaying)
			    mpPlayer.Stop();
        

			setPlayState((int)PLAY_STATE.PS_START);
			//Timer Disable
			tmTimer.Enabled = false;
			//파일의 처음으로 이동
			mpPlayer.CurrentPosition = 0;

			SetPlayTime();
		}

		// 음악 연주 시작
		private void picPlay_Click(object sender, System.EventArgs e)
		{
			if( m_nPlayState == (int)PLAY_STATE.PS_END )
			{
				m_nMinutes = 0;
				m_nSeconds = 0;
			}
			else if( m_nPlayState == (int)PLAY_STATE.PS_STOP )
			{
				m_nMinutes = 0;
				m_nSeconds = 0;
			}
        

			if(!mpPlayer.FileName.Equals(""))
			{
				//타이머(초기화)
				tmTimer.Enabled = true;
				tmTimer.Interval = SECOND;

				setPlayState((int)PLAY_STATE.PS_PLAY);
				//연주 시작
				mpPlayer.Play();

			}
		}

		// 일시중지
		private void picPause_Click(object sender, System.EventArgs e)
		{
			//음악이 연주중인지 확인, 만약 연주중이라면 음악을 정지시킨다.
			if( mpPlayer.PlayState == MediaPlayer.MPPlayStateConstants.mpPlaying )
			{
				setPlayState((int)PLAY_STATE.PS_PAUSE);
				mpPlayer.Pause();
				tmTimer.Enabled = false;

			}
		}

		// 현재 연주 중지
		private void picStop_Click(object sender, System.EventArgs e)
		{
			//음악을 정지시키고 처음으로 이동시킨다.
			setPlayState((int)PLAY_STATE.PS_STOP);
			tmTimer.Enabled = false;
			mpPlayer.Stop();
			mpPlayer.CurrentPosition = 0;
			playSliderBar.Value = 0;

			//시간 초기화
			m_nMinutes = 0;
			m_nSeconds = 0;

			SetPlayTime();
		}

		// 맨 뒤로
		private void picEnd_Click(object sender, System.EventArgs e)
		{
			mpPlayer.Stop();
			tmTimer.Enabled = false;
			//음악 파일의 마지막으로 이동
			mpPlayer.CurrentPosition = mpPlayer.SelectionEnd;

			setPlayState((int)PLAY_STATE.PS_END);

			SetPlayTime();
		}

		// 파일 열기
		private void picEject_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog OpenDlg = new OpenFileDialog();

			OpenDlg.Filter = "mp3 files (*.mp3)|*.mp3";
			OpenDlg.FilterIndex = 0;
			OpenDlg.RestoreDirectory = true;
			OpenDlg.Multiselect = true;
			OpenDlg.Title = "MP3 Files 선택";

			if( OpenDlg.ShowDialog() == DialogResult.OK )
			{

				System.Windows.Forms.Application.DoEvents();

				mpPlayer.Stop();
				//frmList 초기화
				frmPlayList.Init();

				String strTitle, strTime, strPath;

				foreach(String strTmp in OpenDlg.FileNames)
				{
					strPath = strTmp;

					mpPlayer.FileName = strPath;
					mpPlayer.Stop();

					strTime = GetPlayTime();         //전체 연주 시간
					strTitle = GetTitle(strPath);    //파일명

					//frmList의 리스트뷰에 재생할 파일 목록 정보를 삽입한다.
					frmPlayList.AddListItem(strTitle, strTime, strPath);

				}

				//첫번째 곡의 정보를 미디어플레이어에 입력
				
				strPath = frmPlayList.GetItemPath(1);

				//경로가 공백이 아니라면 첫번째 곡의 연주를 시작한다.
				if(!strPath.Equals(""))
				{
					frmPlayList.SetPlayIndex(0);

					PlayMusic(strPath);
				}
				else
					MessageBox.Show(strPath + " 파일 오픈에 실패 했습니다.");
            
			}
		}
		
		// 리스트보기 클릭
		private void picList_Click(object sender, System.EventArgs e)
		{
			if(!m_bShowPlayList)           //frmList가 Show되지 않았다면
			{
				m_ptFrmList.X = this.Location.X;
				m_ptFrmList.Y = this.Location.Y + this.Height;

				frmPlayList.ShowWindow();	//frmList를 열기 위해 호출
				m_bShowPlayList = true;
			}
			else	//frmList가 Show 되어 있다면
			{
				frmPlayList.Hide();
				m_bShowPlayList = false;

			}

		}

		// 메뉴 : 플레이어 보이기
		private void mnuShow_Click(object sender, System.EventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;

			if(m_bShowPlayList)
			{
				m_ptFrmList.X = this.Location.X;
				m_ptFrmList.Y = this.Location.Y + this.Height;

				frmPlayList.ShowWindow(); //frmList를 열기 위해 호출
			}
        
		}

		// 메뉴 : 종료
		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		// 폼 위치 변경시 발생
		// 플레이어 이동 시, 연주 리스트도 따라 이동한다.
		private void frmMain_LocationChanged(object sender, System.EventArgs e)
		{
			//frmList 폼이 보인다면 frmMain 폼의 아래에 위치 시켜 같이 움직이도록 한다.
			if( m_bShowPlayList)
			{
				frmPlayList.Left = this.Left;
				frmPlayList.Top =	this.Top + this.Height;
			}
		
		}

		// 폼 크기 변화시 발생
		// Minimize 버튼을 선택했을 때. 폼을 숨긴다.
		private void frmMain_Resize(object sender, System.EventArgs e)
		{
			//폼이 최소화면 폼을 숨긴다.
			if(this.WindowState == FormWindowState.Minimized)
				this.Hide();
		}


		// 슬라이더바 스크롤 이벤트
		private void playSliderBar_Scroll(object sender, System.EventArgs e)
		{
			mpPlayer.Stop();
			setPlayState((int)PLAY_STATE.PS_STOP);
			tmTimer.Enabled = false;

			//이동된 슬라이더의 위치를 재생 위치로 둔다.
			mpPlayer.CurrentPosition = (double)(playSliderBar.Value);
			//이동되었으므로 시간을 재설정한다.
			SetPlayTime();

			//다시 재생
			tmTimer.Enabled = true;
			mpPlayer.Play();
			setPlayState((int)PLAY_STATE.PS_PLAY);
		}

		
		private void volumeSliderBar_Scroll(object sender, System.EventArgs e)
		{
			// 볼륨
			mpPlayer.Volume = (volumeSliderBar.Value * 100) - 10000;
		}


		// 여기서부터는 마우스 버튼 Down/Up 에 대한 이미지 설정 ////////////////

		private void picStart_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			picStart.Image = imlButton.Images[(int)PLAY_STATE.PS_START * 3 + 1];
		}

		private void picStart_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			picStart.Image = imlButton.Images[(int)PLAY_STATE.PS_START * 3 ];
		}

		private void picPlay_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			picPlay.Image = imlButton.Images[(int)PLAY_STATE.PS_PLAY * 3 + 1];	
		}

		private void picPlay_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			picPlay.Image = imlButton.Images[(int)PLAY_STATE.PS_PLAY * 3];	
		}
		
		private void picPause_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			picPause.Image = imlButton.Images[(int)PLAY_STATE.PS_PAUSE * 3 + 1];
		}

		private void picPause_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			picPause.Image = imlButton.Images[(int)PLAY_STATE.PS_PAUSE * 3];
		}

		private void picStop_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			picStop.Image = imlButton.Images[(int)PLAY_STATE.PS_STOP * 3 + 1];
		}

		private void picStop_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			picStop.Image = imlButton.Images[(int)PLAY_STATE.PS_STOP * 3];
		}

		private void picEnd_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			picEnd.Image = imlButton.Images[(int)PLAY_STATE.PS_END * 3 + 1];
		}

		private void picEnd_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			picEnd.Image = imlButton.Images[(int)PLAY_STATE.PS_END * 3];
		}

		private void picEject_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{	
			picEject.Image = imlButton.Images[(int)PLAY_STATE.PS_EJECT * 3 + 1];
		}

		private void picEject_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			picEject.Image = imlButton.Images[(int)PLAY_STATE.PS_EJECT * 3];
		}

		private void picList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			picList.Image = imlButton.Images[6 * 3 + 1];
		}

		private void picList_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			picList.Image = imlButton.Images[6 * 3];
		}
		
	}
}
