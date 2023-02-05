using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MyPlayer
{
	/// <summary>
	/// Form1�� ���� ��� �����Դϴ�.
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


		const int SECOND = 1000;		//Ÿ�̸� ����
		const int BUTTON_BUNDLE = 3;    //��ư�� ����(��ư�� ���� UP/DOWN/DISABLE 3���� ������ ���� �ִ�)

		int m_nMinutes; //���� �ð��� ���� ��Ÿ����.
		int m_nSeconds; //���� �ð��� �ʸ� ��Ÿ����.

		//�÷��̾��� ���¸� �����Ѵ�.
		int m_nPlayState;
		MyPlayer.frmList frmPlayList = new MyPlayer.frmList();
		
		public Point m_ptFrmList = new Point();
		public Size m_szForm = new Size();
		
		public bool m_bShowPlayList;

		enum PLAY_STATE 
		{
			PS_START = 0,	//'���� ��ġ
			PS_PLAY,		//����
			PS_PAUSE,		//�Ͻ�����
			PS_STOP,		//����
			PS_END,			//�� ��ġ
			PS_EJECT		//���� ����
		};
		
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
			this.mnuShow.Text = "���̱�";
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
			this.mnuExit.Text = "����";
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
			this.lblTime.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
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
		/// �ش� ���� ���α׷��� �� �������Դϴ�.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		private void frmMain_Load(object sender, System.EventArgs e)
		{
			InitData();  //������ �ʱ�ȭ
		}

		//-------------------------------------------------------------------
		//�Լ� : InitData
		//���� : None
		//���� : ������ �ʱ�ȭ
		//-------------------------------------------------------------------
		private void InitData()
		{
			//Ʈ���� ������ ���� ����
			this.NotifyIcon.ContextMenu = this.popMenu;  //Ʈ���� �޴�
			this.NotifyIcon.Text = "My MP3 Player";    //Ʈ���� ��

			lblTitle.Text = "";

			//�ð� ���� �ʱ�ȭ
			m_nMinutes = 0;
			m_nSeconds = 0;

			//Timer
			tmTimer.Enabled = false;

			//�̵�� �÷��̾��� ���÷��̸�带 ������ ������ �ƴ� �ð� ������ �����Ѵ�.
			mpPlayer.DisplayMode = MediaPlayer.MPDisplayModeConstants.mpTime;

			//�ڵ� �ǰ���� �������� �ʴ´�.
			mpPlayer.AutoRewind = false;

			//�÷��̾� �ð� ����
			SetPlayTime();

			//�÷��̾� ���� ����
			setPlayState((int)PLAY_STATE.PS_START);

			//���� ������ ������ �ʾ����Ƿ� ��ư�� ��Ȱ��ȭ ��Ų��.
			//�� EJECT ��ư�� ���� ������ �������� ������ Ȱ��ȭ �����̴�.
			EnableButton(false);

			//���� �����̴��� ��������
			playSliderBar.Min = 0;
			playSliderBar.Max = 100;

			//���� �����̴��� ��������
			volumeSliderBar.Min = 0;
			volumeSliderBar.Max = 100;
			volumeSliderBar.Value = 80;

			//������ 0 ~ -10000������ ���� ������, 0 �� ���� ���� ������ ��Ÿ����.
			mpPlayer.Volume = (80 * 100) - 10000;

			//frmList�� ������ �ʰ� ������ ����
			m_bShowPlayList = false;
			//frmList�� ���̸� frmMain�� ���̿� ���߱� ���� ũ�� ����
			m_szForm = this.Size;
			//frmList���� frmMain�� Public�� �ٷ�� ���� frmMain�� ������ �д�.
			frmPlayList.SetParent(this);

		}

		//-------------------------------------------------------------------
		//�Լ� : SetPlayTime
		//���� : 
		//���� : �÷��̾��� �ð� ����
		//-------------------------------------------------------------------
		private void SetPlayTime()
		{
			//������ �ð��� ���
			CheckTime();

			//�÷��̾��� �ð� ����
			lblTime.Text = String.Format(m_nMinutes.ToString(), "00:") + String.Format(m_nSeconds.ToString(), "00");

		}


		//-------------------------------------------------------------------
		//�Լ� : CheckTime
		//���� : None
		//���� : �÷��̾��� �ð��� üũ�Ѵ�.
		//-------------------------------------------------------------------
		private void CheckTime()
		{
			double dbTime;
			int nTime;

			//�� ��ġ�� �ð��� ��´�.
			dbTime = mpPlayer.CurrentPosition;

			if(dbTime < 0) 
				dbTime = 0.0;

			//�� �ݿø��� �Ͼ�� ���� �����ϴ�.
			nTime = (int)(dbTime);

			//�ð��� �����Ѵ�. 
			m_nSeconds = nTime % 60;
			m_nMinutes = (int)(nTime / 60);

		}

		
		//-------------------------------------------------------------------
		//�Լ� : setPlayState
		//���� : nState - ����
		//���� : �÷��̾��� ���¸� Label�� ��Ÿ����.
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
		//�Լ� : EnableButton
		//���� : bEnable - Ȱ��(true)/��Ȱ��(false)
		//���� : �÷��̾� ��ư�� Ȱ��ȭ/��Ȱ��ȭ
		//-------------------------------------------------------------------
		private void EnableButton(bool bEnable)
		{
			if(bEnable)   //Ȱ��ȭ �̹���
			{
				picStart.Image = imlButton.Images[(int)PLAY_STATE.PS_START * BUTTON_BUNDLE];
				picPlay.Image = imlButton.Images[(int)PLAY_STATE.PS_PLAY * BUTTON_BUNDLE];
				picPause.Image = imlButton.Images[(int)PLAY_STATE.PS_PAUSE * BUTTON_BUNDLE];
				picStop.Image = imlButton.Images[(int)PLAY_STATE.PS_STOP * BUTTON_BUNDLE];
				picEnd.Image = imlButton.Images[(int)PLAY_STATE.PS_END * BUTTON_BUNDLE];
			}
			else                    //��Ȱ��ȭ �̹���
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
		//�Լ� : GetTitle
		//���� : strPath - ������ ��ü���
		//���� : ������ �̸��� ��´�.
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
		//�Լ� : GetPlayTime
		//���� : None
		//���� : ������ ��ü ���ֽð��� ��´�.
		//-------------------------------------------------------------------
		private String GetPlayTime()
		{
			//�÷��̾��� �ð� ����
			String strTime;
			
			mpPlayer.CurrentPosition = mpPlayer.Duration;
			CheckTime();

			strTime = String.Format(m_nMinutes.ToString(), "00:") + String.Format(m_nSeconds.ToString(), "00");

			return strTime;

		}


		//-------------------------------------------------------------------
		//�Լ� : PlayMusic
		//���� : strPath - ������ ��ü ���
		//���� : ���� ����
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

			//SliderBar�� ��������
			playSliderBar.Min = 0;
			playSliderBar.Max = (int)mpPlayer.SelectionEnd;
			playSliderBar.Value = 0;

			tmTimer.Enabled = true;
			tmTimer.Interval = SECOND;
			mpPlayer.Play();

			setPlayState((int)PLAY_STATE.PS_PLAY);
		}


		// �̺�Ʈ �Լ� ���� ///////////////////////

		// Ÿ�̸�
		private void tmTimer_Tick(object sender, System.EventArgs e)
		{
			//�а� �ʸ� ǥ���Ѵ�.
			SetPlayTime();

			playSliderBar.Value = (int)mpPlayer.CurrentPosition;

			//�Ѱ��� ���ְ� ������
			if(mpPlayer.CurrentPosition >= mpPlayer.Duration)
			{
				//���ָ���Ʈ�� ������ ���� ���� �ִ� Ȯ���Ѵ�.
				if(frmPlayList.IsNextItem())
				{
					String strPath;
					int nIndex;

					//���� ������ ����Ʈ ������ �ε����� +1�� �Ͽ� ���� �ε����� ��´�
					nIndex = frmPlayList.GetPlayIndex() + 1;
					frmPlayList.SetPlayIndex(nIndex);

					//�ε����� ������ frmList�� �÷��ǿ� �����ص� ��� ���� ��´�.
					//������ ������ ��θ� ��´�.
					strPath = frmPlayList.GetItemPath(nIndex);

					if(!strPath.Equals(""))
						PlayMusic(strPath);
				}
				else
				{
					//���ָ���Ʈ�� �ִ� ���ϵ��� ���� �����ߴٸ� �ʱ�ȭ
					setPlayState((int)PLAY_STATE.PS_START);
					tmTimer.Enabled = false;
					mpPlayer.Stop();
					mpPlayer.CurrentPosition = 0;
					playSliderBar.Value = 0;

					//�ð� �ʱ�ȭ
					m_nMinutes = 0;
					m_nSeconds = 0;

					SetPlayTime();

				}

			}

		}

		// �� ������
		private void picStart_Click(object sender, System.EventArgs e)
		{
		    if( mpPlayer.PlayState == MediaPlayer.MPPlayStateConstants.mpPlaying)
			    mpPlayer.Stop();
        

			setPlayState((int)PLAY_STATE.PS_START);
			//Timer Disable
			tmTimer.Enabled = false;
			//������ ó������ �̵�
			mpPlayer.CurrentPosition = 0;

			SetPlayTime();
		}

		// ���� ���� ����
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
				//Ÿ�̸�(�ʱ�ȭ)
				tmTimer.Enabled = true;
				tmTimer.Interval = SECOND;

				setPlayState((int)PLAY_STATE.PS_PLAY);
				//���� ����
				mpPlayer.Play();

			}
		}

		// �Ͻ�����
		private void picPause_Click(object sender, System.EventArgs e)
		{
			//������ ���������� Ȯ��, ���� �������̶�� ������ ������Ų��.
			if( mpPlayer.PlayState == MediaPlayer.MPPlayStateConstants.mpPlaying )
			{
				setPlayState((int)PLAY_STATE.PS_PAUSE);
				mpPlayer.Pause();
				tmTimer.Enabled = false;

			}
		}

		// ���� ���� ����
		private void picStop_Click(object sender, System.EventArgs e)
		{
			//������ ������Ű�� ó������ �̵���Ų��.
			setPlayState((int)PLAY_STATE.PS_STOP);
			tmTimer.Enabled = false;
			mpPlayer.Stop();
			mpPlayer.CurrentPosition = 0;
			playSliderBar.Value = 0;

			//�ð� �ʱ�ȭ
			m_nMinutes = 0;
			m_nSeconds = 0;

			SetPlayTime();
		}

		// �� �ڷ�
		private void picEnd_Click(object sender, System.EventArgs e)
		{
			mpPlayer.Stop();
			tmTimer.Enabled = false;
			//���� ������ ���������� �̵�
			mpPlayer.CurrentPosition = mpPlayer.SelectionEnd;

			setPlayState((int)PLAY_STATE.PS_END);

			SetPlayTime();
		}

		// ���� ����
		private void picEject_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog OpenDlg = new OpenFileDialog();

			OpenDlg.Filter = "mp3 files (*.mp3)|*.mp3";
			OpenDlg.FilterIndex = 0;
			OpenDlg.RestoreDirectory = true;
			OpenDlg.Multiselect = true;
			OpenDlg.Title = "MP3 Files ����";

			if( OpenDlg.ShowDialog() == DialogResult.OK )
			{

				System.Windows.Forms.Application.DoEvents();

				mpPlayer.Stop();
				//frmList �ʱ�ȭ
				frmPlayList.Init();

				String strTitle, strTime, strPath;

				foreach(String strTmp in OpenDlg.FileNames)
				{
					strPath = strTmp;

					mpPlayer.FileName = strPath;
					mpPlayer.Stop();

					strTime = GetPlayTime();         //��ü ���� �ð�
					strTitle = GetTitle(strPath);    //���ϸ�

					//frmList�� ����Ʈ�信 ����� ���� ��� ������ �����Ѵ�.
					frmPlayList.AddListItem(strTitle, strTime, strPath);

				}

				//ù��° ���� ������ �̵���÷��̾ �Է�
				
				strPath = frmPlayList.GetItemPath(1);

				//��ΰ� ������ �ƴ϶�� ù��° ���� ���ָ� �����Ѵ�.
				if(!strPath.Equals(""))
				{
					frmPlayList.SetPlayIndex(0);

					PlayMusic(strPath);
				}
				else
					MessageBox.Show(strPath + " ���� ���¿� ���� �߽��ϴ�.");
            
			}
		}
		
		// ����Ʈ���� Ŭ��
		private void picList_Click(object sender, System.EventArgs e)
		{
			if(!m_bShowPlayList)           //frmList�� Show���� �ʾҴٸ�
			{
				m_ptFrmList.X = this.Location.X;
				m_ptFrmList.Y = this.Location.Y + this.Height;

				frmPlayList.ShowWindow();	//frmList�� ���� ���� ȣ��
				m_bShowPlayList = true;
			}
			else	//frmList�� Show �Ǿ� �ִٸ�
			{
				frmPlayList.Hide();
				m_bShowPlayList = false;

			}

		}

		// �޴� : �÷��̾� ���̱�
		private void mnuShow_Click(object sender, System.EventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;

			if(m_bShowPlayList)
			{
				m_ptFrmList.X = this.Location.X;
				m_ptFrmList.Y = this.Location.Y + this.Height;

				frmPlayList.ShowWindow(); //frmList�� ���� ���� ȣ��
			}
        
		}

		// �޴� : ����
		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		// �� ��ġ ����� �߻�
		// �÷��̾� �̵� ��, ���� ����Ʈ�� ���� �̵��Ѵ�.
		private void frmMain_LocationChanged(object sender, System.EventArgs e)
		{
			//frmList ���� ���δٸ� frmMain ���� �Ʒ��� ��ġ ���� ���� �����̵��� �Ѵ�.
			if( m_bShowPlayList)
			{
				frmPlayList.Left = this.Left;
				frmPlayList.Top =	this.Top + this.Height;
			}
		
		}

		// �� ũ�� ��ȭ�� �߻�
		// Minimize ��ư�� �������� ��. ���� �����.
		private void frmMain_Resize(object sender, System.EventArgs e)
		{
			//���� �ּ�ȭ�� ���� �����.
			if(this.WindowState == FormWindowState.Minimized)
				this.Hide();
		}


		// �����̴��� ��ũ�� �̺�Ʈ
		private void playSliderBar_Scroll(object sender, System.EventArgs e)
		{
			mpPlayer.Stop();
			setPlayState((int)PLAY_STATE.PS_STOP);
			tmTimer.Enabled = false;

			//�̵��� �����̴��� ��ġ�� ��� ��ġ�� �д�.
			mpPlayer.CurrentPosition = (double)(playSliderBar.Value);
			//�̵��Ǿ����Ƿ� �ð��� �缳���Ѵ�.
			SetPlayTime();

			//�ٽ� ���
			tmTimer.Enabled = true;
			mpPlayer.Play();
			setPlayState((int)PLAY_STATE.PS_PLAY);
		}

		
		private void volumeSliderBar_Scroll(object sender, System.EventArgs e)
		{
			// ����
			mpPlayer.Volume = (volumeSliderBar.Value * 100) - 10000;
		}


		// ���⼭���ʹ� ���콺 ��ư Down/Up �� ���� �̹��� ���� ////////////////

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
