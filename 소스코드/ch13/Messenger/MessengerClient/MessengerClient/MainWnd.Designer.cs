namespace MessengerClient
{
    partial class MainWnd
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            /// Registry에 옵션 값 저장하기
            this.Save_Registry();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWnd));
            this.menuItem_Quit = new System.Windows.Forms.MenuItem();
            this.menuItem_Logout = new System.Windows.Forms.MenuItem();
            this.menuItem_State_Return = new System.Windows.Forms.MenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Login = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Info = new System.Windows.Forms.TextBox();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.btn_Register = new System.Windows.Forms.Button();
            this.menu_MainWnd_Manage = new System.Windows.Forms.MenuItem();
            this.menuItem_Group = new System.Windows.Forms.MenuItem();
            this.menuItem_Friend = new System.Windows.Forms.MenuItem();
            this.menuItem_MSN = new System.Windows.Forms.MenuItem();
            this.menuItem_MSN_Chat = new System.Windows.Forms.MenuItem();
            this.menuItem_MSN_Mail = new System.Windows.Forms.MenuItem();
            this.menuItem_Option = new System.Windows.Forms.MenuItem();
            this.menuItem_State_Leave = new System.Windows.Forms.MenuItem();
            this.menuItem_State_Offline = new System.Windows.Forms.MenuItem();
            this.menuItem_State_Online = new System.Windows.Forms.MenuItem();
            this.menuItem_State = new System.Windows.Forms.MenuItem();
            this.menuItem_State_Tel = new System.Windows.Forms.MenuItem();
            this.menuItem_State_Meal = new System.Windows.Forms.MenuItem();
            this.menuItem_State_Etc = new System.Windows.Forms.MenuItem();
            this.menuItem_tray_login = new System.Windows.Forms.MenuItem();
            this.contextMenu = new System.Windows.Forms.ContextMenu();
            this.menuItem_tray_logout = new System.Windows.Forms.MenuItem();
            this.menuItem_tray_quit = new System.Windows.Forms.MenuItem();
            this.menuItem_tray_about = new System.Windows.Forms.MenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuItem_Help = new System.Windows.Forms.MenuItem();
            this.menu_MainWnd_Help = new System.Windows.Forms.MenuItem();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.tree_Friend = new System.Windows.Forms.TreeView();
            this.lbl_Pwd = new System.Windows.Forms.Label();
            this.txt_Pwd = new System.Windows.Forms.TextBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_Server = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel_ListCenter = new System.Windows.Forms.Panel();
            this.panel_ListTop = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lbl_DisplayOption = new System.Windows.Forms.Label();
            this.panel_ListBottom = new System.Windows.Forms.Panel();
            this.lbl_Copyrighter = new System.Windows.Forms.Label();
            this.picture_Logo = new System.Windows.Forms.PictureBox();
            this.menuItem_Login = new System.Windows.Forms.MenuItem();
            this.menu_MainWnd_File = new System.Windows.Forms.MenuItem();
            this.memu_MainWnd = new System.Windows.Forms.MainMenu(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel_ListCenter.SuspendLayout();
            this.panel_ListTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel_ListBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuItem_Quit
            // 
            this.menuItem_Quit.Index = 3;
            this.menuItem_Quit.Text = "프로그램 종료";
            this.menuItem_Quit.Click += new System.EventHandler(this.menuItem_Quit_Click);
            // 
            // menuItem_Logout
            // 
            this.menuItem_Logout.Index = 2;
            this.menuItem_Logout.Text = "로그아웃";
            this.menuItem_Logout.Click += new System.EventHandler(this.menuItem_Logout_Click);
            // 
            // menuItem_State_Return
            // 
            this.menuItem_State_Return.Index = 6;
            this.menuItem_State_Return.Text = "곧 돌아오겠음";
            this.menuItem_State_Return.Click += new System.EventHandler(this.menuItem_State_Return_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Login);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 43);
            this.panel2.TabIndex = 10;
            // 
            // btn_Login
            // 
            this.btn_Login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Login.Location = new System.Drawing.Point(0, 0);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(270, 43);
            this.btn_Login.TabIndex = 0;
            this.btn_Login.Text = "로그인";
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_Info);
            this.panel1.Controls.Add(this.lbl_Info);
            this.panel1.Controls.Add(this.btn_Register);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 171);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 192);
            this.panel1.TabIndex = 9;
            // 
            // txt_Info
            // 
            this.txt_Info.Location = new System.Drawing.Point(8, 40);
            this.txt_Info.Multiline = true;
            this.txt_Info.Name = "txt_Info";
            this.txt_Info.ReadOnly = true;
            this.txt_Info.Size = new System.Drawing.Size(256, 144);
            this.txt_Info.TabIndex = 7;
            // 
            // lbl_Info
            // 
            this.lbl_Info.Location = new System.Drawing.Point(8, 12);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(96, 16);
            this.lbl_Info.TabIndex = 8;
            this.lbl_Info.Text = "디버깅 정보 창";
            // 
            // btn_Register
            // 
            this.btn_Register.Location = new System.Drawing.Point(120, 8);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Size = new System.Drawing.Size(144, 24);
            this.btn_Register.TabIndex = 0;
            this.btn_Register.Text = "회원 가입";
            this.btn_Register.Click += new System.EventHandler(this.btn_Register_Click);
            // 
            // menu_MainWnd_Manage
            // 
            this.menu_MainWnd_Manage.Index = 1;
            this.menu_MainWnd_Manage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_Group,
            this.menuItem_Friend,
            this.menuItem_MSN,
            this.menuItem_Option});
            this.menu_MainWnd_Manage.Text = "환경설정";
            // 
            // menuItem_Group
            // 
            this.menuItem_Group.Index = 0;
            this.menuItem_Group.Text = "그룹관리";
            this.menuItem_Group.Click += new System.EventHandler(this.menuItem_Group_Click);
            // 
            // menuItem_Friend
            // 
            this.menuItem_Friend.Index = 1;
            this.menuItem_Friend.Text = "친구관리";
            this.menuItem_Friend.Click += new System.EventHandler(this.menuItem_Friend_Click);
            // 
            // menuItem_MSN
            // 
            this.menuItem_MSN.Index = 2;
            this.menuItem_MSN.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_MSN_Chat,
            this.menuItem_MSN_Mail});
            this.menuItem_MSN.Text = "메신저 기능";
            // 
            // menuItem_MSN_Chat
            // 
            this.menuItem_MSN_Chat.Index = 0;
            this.menuItem_MSN_Chat.Text = "인스턴스 메신저";
            this.menuItem_MSN_Chat.Click += new System.EventHandler(this.menuItem_MSN_Chat_Click);
            // 
            // menuItem_MSN_Mail
            // 
            this.menuItem_MSN_Mail.Index = 1;
            this.menuItem_MSN_Mail.Text = "메일 보내기";
            this.menuItem_MSN_Mail.Click += new System.EventHandler(this.menuItem_MSN_Mail_Click);
            // 
            // menuItem_Option
            // 
            this.menuItem_Option.Index = 3;
            this.menuItem_Option.Text = "메신저 옵션 ";
            this.menuItem_Option.Click += new System.EventHandler(this.menuItem_Option_Click);
            // 
            // menuItem_State_Leave
            // 
            this.menuItem_State_Leave.Index = 5;
            this.menuItem_State_Leave.Text = "자리비움";
            this.menuItem_State_Leave.Click += new System.EventHandler(this.menuItem_State_Leave_Click);
            // 
            // menuItem_State_Offline
            // 
            this.menuItem_State_Offline.Index = 1;
            this.menuItem_State_Offline.Text = "오프라인";
            this.menuItem_State_Offline.Click += new System.EventHandler(this.menuItem_State_Offline_Click);
            // 
            // menuItem_State_Online
            // 
            this.menuItem_State_Online.Index = 0;
            this.menuItem_State_Online.Text = "온라인";
            this.menuItem_State_Online.Click += new System.EventHandler(this.menuItem_State_Online_Click);
            // 
            // menuItem_State
            // 
            this.menuItem_State.Index = 1;
            this.menuItem_State.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_State_Online,
            this.menuItem_State_Offline,
            this.menuItem_State_Tel,
            this.menuItem_State_Meal,
            this.menuItem_State_Etc,
            this.menuItem_State_Leave,
            this.menuItem_State_Return});
            this.menuItem_State.Text = "내 상태 변경";
            // 
            // menuItem_State_Tel
            // 
            this.menuItem_State_Tel.Index = 2;
            this.menuItem_State_Tel.Text = "전화 통화중";
            this.menuItem_State_Tel.Click += new System.EventHandler(this.menuItem_State_Tel_Click);
            // 
            // menuItem_State_Meal
            // 
            this.menuItem_State_Meal.Index = 3;
            this.menuItem_State_Meal.Text = "식사중";
            this.menuItem_State_Meal.Click += new System.EventHandler(this.menuItem_State_Meal_Click);
            // 
            // menuItem_State_Etc
            // 
            this.menuItem_State_Etc.Index = 4;
            this.menuItem_State_Etc.Text = "다른 용무중";
            this.menuItem_State_Etc.Click += new System.EventHandler(this.menuItem_State_Etc_Click);
            // 
            // menuItem_tray_login
            // 
            this.menuItem_tray_login.Index = 0;
            this.menuItem_tray_login.Text = "로그인";
            this.menuItem_tray_login.Click += new System.EventHandler(this.menuItem_tray_login_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_tray_login,
            this.menuItem_tray_logout,
            this.menuItem_tray_quit,
            this.menuItem_tray_about});
            // 
            // menuItem_tray_logout
            // 
            this.menuItem_tray_logout.Index = 1;
            this.menuItem_tray_logout.Text = "로그아웃";
            this.menuItem_tray_logout.Click += new System.EventHandler(this.menuItem_tray_logout_Click);
            // 
            // menuItem_tray_quit
            // 
            this.menuItem_tray_quit.Index = 2;
            this.menuItem_tray_quit.Text = "프로그램종료";
            this.menuItem_tray_quit.Click += new System.EventHandler(this.menuItem_tray_quit_Click);
            // 
            // menuItem_tray_about
            // 
            this.menuItem_tray_about.Index = 3;
            this.menuItem_tray_about.Text = "이프로그램은";
            this.menuItem_tray_about.Click += new System.EventHandler(this.menuItem_tray_about_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenu = this.contextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Magic 메신저 1.1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // menuItem_Help
            // 
            this.menuItem_Help.Index = 0;
            this.menuItem_Help.Text = "이 프로그램은...";
            this.menuItem_Help.Click += new System.EventHandler(this.menuItem_Help_Click);
            // 
            // menu_MainWnd_Help
            // 
            this.menu_MainWnd_Help.Index = 2;
            this.menu_MainWnd_Help.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_Help});
            this.menu_MainWnd_Help.Text = "도움말";
            // 
            // lbl_ID
            // 
            this.lbl_ID.Location = new System.Drawing.Point(16, 67);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(72, 16);
            this.lbl_ID.TabIndex = 7;
            this.lbl_ID.Text = "아이디 :";
            // 
            // tree_Friend
            // 
            this.tree_Friend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_Friend.Location = new System.Drawing.Point(0, 0);
            this.tree_Friend.Name = "tree_Friend";
            this.tree_Friend.Size = new System.Drawing.Size(256, 240);
            this.tree_Friend.TabIndex = 9;
            this.tree_Friend.DoubleClick += new System.EventHandler(this.tree_Friend_DoubleClick);
            this.tree_Friend.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tree_Friend_MouseDown);
            // 
            // lbl_Pwd
            // 
            this.lbl_Pwd.Location = new System.Drawing.Point(16, 91);
            this.lbl_Pwd.Name = "lbl_Pwd";
            this.lbl_Pwd.Size = new System.Drawing.Size(72, 16);
            this.lbl_Pwd.TabIndex = 8;
            this.lbl_Pwd.Text = "비밀번호 :";
            // 
            // txt_Pwd
            // 
            this.txt_Pwd.Location = new System.Drawing.Point(104, 93);
            this.txt_Pwd.Name = "txt_Pwd";
            this.txt_Pwd.PasswordChar = '*';
            this.txt_Pwd.Size = new System.Drawing.Size(120, 21);
            this.txt_Pwd.TabIndex = 1;
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(104, 64);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(120, 21);
            this.txt_ID.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_Pwd);
            this.groupBox1.Controls.Add(this.txt_Pwd);
            this.groupBox1.Controls.Add(this.txt_ID);
            this.groupBox1.Controls.Add(this.lbl_Server);
            this.groupBox1.Controls.Add(this.txt_IP);
            this.groupBox1.Controls.Add(this.lbl_ID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 128);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "서버 접속";
            // 
            // lbl_Server
            // 
            this.lbl_Server.Location = new System.Drawing.Point(16, 26);
            this.lbl_Server.Name = "lbl_Server";
            this.lbl_Server.Size = new System.Drawing.Size(72, 16);
            this.lbl_Server.TabIndex = 4;
            this.lbl_Server.Text = "서버 아이피";
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(104, 24);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(120, 21);
            this.txt_IP.TabIndex = 2;
            this.txt_IP.Text = "192.168.10.100";
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(296, 371);
            this.tabControl.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabPage1.Location = new System.Drawing.Point(22, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(270, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "로그인";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel_ListCenter);
            this.tabPage2.Controls.Add(this.panel_ListTop);
            this.tabPage2.Controls.Add(this.panel_ListBottom);
            this.tabPage2.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabPage2.Location = new System.Drawing.Point(22, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(270, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "메신저 친구 목록";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel_ListCenter
            // 
            this.panel_ListCenter.Controls.Add(this.tree_Friend);
            this.panel_ListCenter.Location = new System.Drawing.Point(8, 40);
            this.panel_ListCenter.Name = "panel_ListCenter";
            this.panel_ListCenter.Size = new System.Drawing.Size(256, 240);
            this.panel_ListCenter.TabIndex = 12;
            // 
            // panel_ListTop
            // 
            this.panel_ListTop.Controls.Add(this.pictureBox);
            this.panel_ListTop.Controls.Add(this.lbl_DisplayOption);
            this.panel_ListTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_ListTop.Location = new System.Drawing.Point(0, 0);
            this.panel_ListTop.Name = "panel_ListTop";
            this.panel_ListTop.Size = new System.Drawing.Size(270, 40);
            this.panel_ListTop.TabIndex = 11;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(24, 8);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(24, 24);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // lbl_DisplayOption
            // 
            this.lbl_DisplayOption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DisplayOption.Location = new System.Drawing.Point(80, 8);
            this.lbl_DisplayOption.Name = "lbl_DisplayOption";
            this.lbl_DisplayOption.Size = new System.Drawing.Size(184, 16);
            this.lbl_DisplayOption.TabIndex = 0;
            this.lbl_DisplayOption.Text = "디스플레이 옵션: 아이디로 표시";
            this.lbl_DisplayOption.Click += new System.EventHandler(this.lbl_DisplayOption_Click);
            // 
            // panel_ListBottom
            // 
            this.panel_ListBottom.Controls.Add(this.lbl_Copyrighter);
            this.panel_ListBottom.Controls.Add(this.picture_Logo);
            this.panel_ListBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_ListBottom.Location = new System.Drawing.Point(0, 275);
            this.panel_ListBottom.Name = "panel_ListBottom";
            this.panel_ListBottom.Size = new System.Drawing.Size(270, 88);
            this.panel_ListBottom.TabIndex = 10;
            // 
            // lbl_Copyrighter
            // 
            this.lbl_Copyrighter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Copyrighter.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Copyrighter.Location = new System.Drawing.Point(144, 32);
            this.lbl_Copyrighter.Name = "lbl_Copyrighter";
            this.lbl_Copyrighter.Size = new System.Drawing.Size(104, 24);
            this.lbl_Copyrighter.TabIndex = 1;
            this.lbl_Copyrighter.Text = "Choi Jae Kyu";
            // 
            // picture_Logo
            // 
            this.picture_Logo.Location = new System.Drawing.Point(8, 30);
            this.picture_Logo.Name = "picture_Logo";
            this.picture_Logo.Size = new System.Drawing.Size(100, 50);
            this.picture_Logo.TabIndex = 0;
            this.picture_Logo.TabStop = false;
            // 
            // menuItem_Login
            // 
            this.menuItem_Login.Index = 0;
            this.menuItem_Login.Text = "로그인";
            this.menuItem_Login.Click += new System.EventHandler(this.menuItem_Login_Click);
            // 
            // menu_MainWnd_File
            // 
            this.menu_MainWnd_File.Index = 0;
            this.menu_MainWnd_File.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_Login,
            this.menuItem_State,
            this.menuItem_Logout,
            this.menuItem_Quit});
            this.menu_MainWnd_File.Text = "파일";
            // 
            // memu_MainWnd
            // 
            this.memu_MainWnd.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menu_MainWnd_File,
            this.menu_MainWnd_Manage,
            this.menu_MainWnd_Help});
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 371);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Menu = this.memu_MainWnd;
            this.Name = "MainWnd";
            this.Text = "메신저 1.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWnd_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel_ListCenter.ResumeLayout(false);
            this.panel_ListTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel_ListBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItem_Quit;
        private System.Windows.Forms.MenuItem menuItem_Logout;
        private System.Windows.Forms.MenuItem menuItem_State_Return;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_Info;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.Button btn_Register;
        private System.Windows.Forms.MenuItem menu_MainWnd_Manage;
        private System.Windows.Forms.MenuItem menuItem_Group;
        private System.Windows.Forms.MenuItem menuItem_Friend;
        private System.Windows.Forms.MenuItem menuItem_MSN;
        private System.Windows.Forms.MenuItem menuItem_MSN_Chat;
        private System.Windows.Forms.MenuItem menuItem_MSN_Mail;
        private System.Windows.Forms.MenuItem menuItem_Option;
        private System.Windows.Forms.MenuItem menuItem_State_Leave;
        private System.Windows.Forms.MenuItem menuItem_State_Offline;
        private System.Windows.Forms.MenuItem menuItem_State_Online;
        private System.Windows.Forms.MenuItem menuItem_State;
        private System.Windows.Forms.MenuItem menuItem_State_Tel;
        private System.Windows.Forms.MenuItem menuItem_State_Meal;
        private System.Windows.Forms.MenuItem menuItem_State_Etc;
        private System.Windows.Forms.MenuItem menuItem_tray_login;
        private System.Windows.Forms.ContextMenu contextMenu;
        private System.Windows.Forms.MenuItem menuItem_tray_logout;
        private System.Windows.Forms.MenuItem menuItem_tray_quit;
        private System.Windows.Forms.MenuItem menuItem_tray_about;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.MenuItem menuItem_Help;
        private System.Windows.Forms.MenuItem menu_MainWnd_Help;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.TreeView tree_Friend;
        private System.Windows.Forms.Label lbl_Pwd;
        private System.Windows.Forms.TextBox txt_Pwd;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_Server;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel_ListCenter;
        private System.Windows.Forms.Panel panel_ListTop;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lbl_DisplayOption;
        private System.Windows.Forms.Panel panel_ListBottom;
        private System.Windows.Forms.Label lbl_Copyrighter;
        private System.Windows.Forms.PictureBox picture_Logo;
        private System.Windows.Forms.MenuItem menuItem_Login;
        private System.Windows.Forms.MenuItem menu_MainWnd_File;
        private System.Windows.Forms.MainMenu memu_MainWnd;
    }
}

