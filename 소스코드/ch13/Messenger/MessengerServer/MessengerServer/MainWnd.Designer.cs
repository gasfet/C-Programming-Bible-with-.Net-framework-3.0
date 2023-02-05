namespace MessengerServer
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
            this.lbl_Content = new System.Windows.Forms.Label();
            this.btn_SqlWriter = new System.Windows.Forms.Button();
            this.btn_SqlReader = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.tab_Current_Info = new System.Windows.Forms.TabPage();
            this.txt_Broadcast_Title = new System.Windows.Forms.TextBox();
            this.lst_Connect = new System.Windows.Forms.ListView();
            this.btn_BroadcastAll = new System.Windows.Forms.Button();
            this.txt_Broadcast_Content = new System.Windows.Forms.TextBox();
            this.btn_Broadcast = new System.Windows.Forms.Button();
            this.btn_ConnectHistorySave = new System.Windows.Forms.Button();
            this.btn_DisConnectAll = new System.Windows.Forms.Button();
            this.btn_DisConnect = new System.Windows.Forms.Button();
            this.btn_ConnectRefresh = new System.Windows.Forms.Button();
            this.txt_SelectMemberInfo = new System.Windows.Forms.TextBox();
            this.btn_XMLReader = new System.Windows.Forms.Button();
            this.btn_DeleteMember = new System.Windows.Forms.Button();
            this.btn_EditMember = new System.Windows.Forms.Button();
            this.btn_InsertMember = new System.Windows.Forms.Button();
            this.btn_XMLWriter = new System.Windows.Forms.Button();
            this.grb_DataReadWrite = new System.Windows.Forms.GroupBox();
            this.tab_Debug_Info = new System.Windows.Forms.TabPage();
            this.txt_Info = new System.Windows.Forms.TextBox();
            this.txt_DBname = new System.Windows.Forms.TextBox();
            this.lbl_ServerPWD = new System.Windows.Forms.Label();
            this.txt_PWD = new System.Windows.Forms.TextBox();
            this.lbl_ServerID = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.lbl_ServerIP = new System.Windows.Forms.Label();
            this.tab_Server = new System.Windows.Forms.TabPage();
            this.chk_XML = new System.Windows.Forms.CheckBox();
            this.grb_ServerInfo = new System.Windows.Forms.GroupBox();
            this.lbl_ServerDB = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.lst_Member = new System.Windows.Forms.ListView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab_Friend = new System.Windows.Forms.TabPage();
            this.btn_Group = new System.Windows.Forms.Button();
            this.btn_Friend = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lst_Group = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lst_Friend = new System.Windows.Forms.ListView();
            this.tab_Member_Info = new System.Windows.Forms.TabPage();
            this.grb_DataManager = new System.Windows.Forms.GroupBox();
            this.tab_Current_Info.SuspendLayout();
            this.grb_DataReadWrite.SuspendLayout();
            this.tab_Debug_Info.SuspendLayout();
            this.tab_Server.SuspendLayout();
            this.grb_ServerInfo.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tab_Friend.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tab_Member_Info.SuspendLayout();
            this.grb_DataManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Content
            // 
            this.lbl_Content.Location = new System.Drawing.Point(8, 272);
            this.lbl_Content.Name = "lbl_Content";
            this.lbl_Content.Size = new System.Drawing.Size(40, 16);
            this.lbl_Content.TabIndex = 13;
            this.lbl_Content.Text = "내용 :";
            // 
            // btn_SqlWriter
            // 
            this.btn_SqlWriter.Location = new System.Drawing.Point(16, 56);
            this.btn_SqlWriter.Name = "btn_SqlWriter";
            this.btn_SqlWriter.Size = new System.Drawing.Size(136, 23);
            this.btn_SqlWriter.TabIndex = 1;
            this.btn_SqlWriter.Text = "SQL에 정보 저장하기";
            this.btn_SqlWriter.Click += new System.EventHandler(this.btn_SqlWriter_Click);
            // 
            // btn_SqlReader
            // 
            this.btn_SqlReader.Location = new System.Drawing.Point(16, 24);
            this.btn_SqlReader.Name = "btn_SqlReader";
            this.btn_SqlReader.Size = new System.Drawing.Size(136, 23);
            this.btn_SqlReader.TabIndex = 0;
            this.btn_SqlReader.Text = "SQL 정보 읽어오기";
            this.btn_SqlReader.Click += new System.EventHandler(this.btn_SqlReader_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.Location = new System.Drawing.Point(8, 243);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(40, 16);
            this.lbl_Title.TabIndex = 12;
            this.lbl_Title.Text = "제목 :";
            // 
            // tab_Current_Info
            // 
            this.tab_Current_Info.Controls.Add(this.lbl_Content);
            this.tab_Current_Info.Controls.Add(this.lbl_Title);
            this.tab_Current_Info.Controls.Add(this.txt_Broadcast_Title);
            this.tab_Current_Info.Controls.Add(this.lst_Connect);
            this.tab_Current_Info.Controls.Add(this.btn_BroadcastAll);
            this.tab_Current_Info.Controls.Add(this.txt_Broadcast_Content);
            this.tab_Current_Info.Controls.Add(this.btn_Broadcast);
            this.tab_Current_Info.Controls.Add(this.btn_ConnectHistorySave);
            this.tab_Current_Info.Controls.Add(this.btn_DisConnectAll);
            this.tab_Current_Info.Controls.Add(this.btn_DisConnect);
            this.tab_Current_Info.Controls.Add(this.btn_ConnectRefresh);
            this.tab_Current_Info.Controls.Add(this.txt_SelectMemberInfo);
            this.tab_Current_Info.Location = new System.Drawing.Point(4, 21);
            this.tab_Current_Info.Name = "tab_Current_Info";
            this.tab_Current_Info.Size = new System.Drawing.Size(408, 351);
            this.tab_Current_Info.TabIndex = 1;
            this.tab_Current_Info.Text = "현재 접속한 회원";
            this.tab_Current_Info.Visible = false;
            // 
            // txt_Broadcast_Title
            // 
            this.txt_Broadcast_Title.Location = new System.Drawing.Point(56, 240);
            this.txt_Broadcast_Title.Name = "txt_Broadcast_Title";
            this.txt_Broadcast_Title.Size = new System.Drawing.Size(248, 21);
            this.txt_Broadcast_Title.TabIndex = 11;
            // 
            // lst_Connect
            // 
            this.lst_Connect.Location = new System.Drawing.Point(8, 8);
            this.lst_Connect.Name = "lst_Connect";
            this.lst_Connect.Size = new System.Drawing.Size(392, 144);
            this.lst_Connect.TabIndex = 10;
            this.lst_Connect.UseCompatibleStateImageBehavior = false;
            this.lst_Connect.Click += new System.EventHandler(this.lst_Connect_Click);
            // 
            // btn_BroadcastAll
            // 
            this.btn_BroadcastAll.Location = new System.Drawing.Point(312, 280);
            this.btn_BroadcastAll.Name = "btn_BroadcastAll";
            this.btn_BroadcastAll.Size = new System.Drawing.Size(88, 32);
            this.btn_BroadcastAll.TabIndex = 9;
            this.btn_BroadcastAll.Text = "전체 방송";
            this.btn_BroadcastAll.Click += new System.EventHandler(this.btn_BroadcastAll_Click);
            // 
            // txt_Broadcast_Content
            // 
            this.txt_Broadcast_Content.Location = new System.Drawing.Point(56, 264);
            this.txt_Broadcast_Content.Multiline = true;
            this.txt_Broadcast_Content.Name = "txt_Broadcast_Content";
            this.txt_Broadcast_Content.Size = new System.Drawing.Size(248, 48);
            this.txt_Broadcast_Content.TabIndex = 8;
            // 
            // btn_Broadcast
            // 
            this.btn_Broadcast.Location = new System.Drawing.Point(312, 240);
            this.btn_Broadcast.Name = "btn_Broadcast";
            this.btn_Broadcast.Size = new System.Drawing.Size(88, 32);
            this.btn_Broadcast.TabIndex = 7;
            this.btn_Broadcast.Text = "방송";
            this.btn_Broadcast.Click += new System.EventHandler(this.btn_Broadcast_Click);
            // 
            // btn_ConnectHistorySave
            // 
            this.btn_ConnectHistorySave.Location = new System.Drawing.Point(296, 320);
            this.btn_ConnectHistorySave.Name = "btn_ConnectHistorySave";
            this.btn_ConnectHistorySave.Size = new System.Drawing.Size(104, 23);
            this.btn_ConnectHistorySave.TabIndex = 6;
            this.btn_ConnectHistorySave.Text = "접속 기록 저장";
            this.btn_ConnectHistorySave.Click += new System.EventHandler(this.btn_ConnectHistorySave_Click);
            // 
            // btn_DisConnectAll
            // 
            this.btn_DisConnectAll.Location = new System.Drawing.Point(192, 320);
            this.btn_DisConnectAll.Name = "btn_DisConnectAll";
            this.btn_DisConnectAll.Size = new System.Drawing.Size(96, 23);
            this.btn_DisConnectAll.TabIndex = 5;
            this.btn_DisConnectAll.Text = "모든 연결 끊기";
            this.btn_DisConnectAll.Click += new System.EventHandler(this.btn_DisConnectAll_Click);
            // 
            // btn_DisConnect
            // 
            this.btn_DisConnect.Location = new System.Drawing.Point(96, 320);
            this.btn_DisConnect.Name = "btn_DisConnect";
            this.btn_DisConnect.Size = new System.Drawing.Size(88, 23);
            this.btn_DisConnect.TabIndex = 4;
            this.btn_DisConnect.Text = "연결 끊기";
            this.btn_DisConnect.Click += new System.EventHandler(this.btn_DisConnect_Click);
            // 
            // btn_ConnectRefresh
            // 
            this.btn_ConnectRefresh.Location = new System.Drawing.Point(8, 320);
            this.btn_ConnectRefresh.Name = "btn_ConnectRefresh";
            this.btn_ConnectRefresh.Size = new System.Drawing.Size(80, 23);
            this.btn_ConnectRefresh.TabIndex = 3;
            this.btn_ConnectRefresh.Text = "새로고침";
            this.btn_ConnectRefresh.Click += new System.EventHandler(this.btn_ConnectRefresh_Click);
            // 
            // txt_SelectMemberInfo
            // 
            this.txt_SelectMemberInfo.Location = new System.Drawing.Point(8, 160);
            this.txt_SelectMemberInfo.Multiline = true;
            this.txt_SelectMemberInfo.Name = "txt_SelectMemberInfo";
            this.txt_SelectMemberInfo.ReadOnly = true;
            this.txt_SelectMemberInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_SelectMemberInfo.Size = new System.Drawing.Size(392, 72);
            this.txt_SelectMemberInfo.TabIndex = 2;
            this.txt_SelectMemberInfo.Text = "선택회원 상세 정보";
            // 
            // btn_XMLReader
            // 
            this.btn_XMLReader.Location = new System.Drawing.Point(16, 88);
            this.btn_XMLReader.Name = "btn_XMLReader";
            this.btn_XMLReader.Size = new System.Drawing.Size(136, 23);
            this.btn_XMLReader.TabIndex = 2;
            this.btn_XMLReader.Text = "XML 정보 읽어오기";
            this.btn_XMLReader.Click += new System.EventHandler(this.btn_XMLReader_Click);
            // 
            // btn_DeleteMember
            // 
            this.btn_DeleteMember.Location = new System.Drawing.Point(16, 112);
            this.btn_DeleteMember.Name = "btn_DeleteMember";
            this.btn_DeleteMember.Size = new System.Drawing.Size(184, 32);
            this.btn_DeleteMember.TabIndex = 2;
            this.btn_DeleteMember.Text = "선택한 회원 정보 삭제하기";
            this.btn_DeleteMember.Click += new System.EventHandler(this.btn_DeleteMember_Click);
            // 
            // btn_EditMember
            // 
            this.btn_EditMember.Location = new System.Drawing.Point(16, 69);
            this.btn_EditMember.Name = "btn_EditMember";
            this.btn_EditMember.Size = new System.Drawing.Size(184, 32);
            this.btn_EditMember.TabIndex = 1;
            this.btn_EditMember.Text = "선택한 회원 정보 수정하기";
            this.btn_EditMember.Click += new System.EventHandler(this.btn_EditMember_Click);
            // 
            // btn_InsertMember
            // 
            this.btn_InsertMember.Location = new System.Drawing.Point(16, 24);
            this.btn_InsertMember.Name = "btn_InsertMember";
            this.btn_InsertMember.Size = new System.Drawing.Size(184, 32);
            this.btn_InsertMember.TabIndex = 0;
            this.btn_InsertMember.Text = "신규 회원 정보 입력하기";
            this.btn_InsertMember.Click += new System.EventHandler(this.btn_InsertMember_Click);
            // 
            // btn_XMLWriter
            // 
            this.btn_XMLWriter.Location = new System.Drawing.Point(16, 120);
            this.btn_XMLWriter.Name = "btn_XMLWriter";
            this.btn_XMLWriter.Size = new System.Drawing.Size(136, 23);
            this.btn_XMLWriter.TabIndex = 3;
            this.btn_XMLWriter.Text = "XML에 정보 저장하기";
            this.btn_XMLWriter.Click += new System.EventHandler(this.btn_XMLWriter_Click);
            // 
            // grb_DataReadWrite
            // 
            this.grb_DataReadWrite.Controls.Add(this.btn_XMLWriter);
            this.grb_DataReadWrite.Controls.Add(this.btn_XMLReader);
            this.grb_DataReadWrite.Controls.Add(this.btn_SqlWriter);
            this.grb_DataReadWrite.Controls.Add(this.btn_SqlReader);
            this.grb_DataReadWrite.Location = new System.Drawing.Point(8, 192);
            this.grb_DataReadWrite.Name = "grb_DataReadWrite";
            this.grb_DataReadWrite.Size = new System.Drawing.Size(168, 152);
            this.grb_DataReadWrite.TabIndex = 1;
            this.grb_DataReadWrite.TabStop = false;
            this.grb_DataReadWrite.Text = "데이터 읽기/쓰기";
            // 
            // tab_Debug_Info
            // 
            this.tab_Debug_Info.Controls.Add(this.txt_Info);
            this.tab_Debug_Info.Location = new System.Drawing.Point(4, 21);
            this.tab_Debug_Info.Name = "tab_Debug_Info";
            this.tab_Debug_Info.Size = new System.Drawing.Size(408, 351);
            this.tab_Debug_Info.TabIndex = 2;
            this.tab_Debug_Info.Text = "디버깅 정보";
            this.tab_Debug_Info.Visible = false;
            // 
            // txt_Info
            // 
            this.txt_Info.Location = new System.Drawing.Point(8, 8);
            this.txt_Info.Multiline = true;
            this.txt_Info.Name = "txt_Info";
            this.txt_Info.ReadOnly = true;
            this.txt_Info.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Info.Size = new System.Drawing.Size(392, 336);
            this.txt_Info.TabIndex = 0;
            // 
            // txt_DBname
            // 
            this.txt_DBname.Location = new System.Drawing.Point(160, 128);
            this.txt_DBname.Name = "txt_DBname";
            this.txt_DBname.Size = new System.Drawing.Size(192, 21);
            this.txt_DBname.TabIndex = 6;
            this.txt_DBname.Text = "Messenger";
            // 
            // lbl_ServerPWD
            // 
            this.lbl_ServerPWD.Location = new System.Drawing.Point(9, 96);
            this.lbl_ServerPWD.Name = "lbl_ServerPWD";
            this.lbl_ServerPWD.Size = new System.Drawing.Size(120, 23);
            this.lbl_ServerPWD.TabIndex = 5;
            this.lbl_ServerPWD.Text = "SQL 서버 계정 암호";
            // 
            // txt_PWD
            // 
            this.txt_PWD.Location = new System.Drawing.Point(160, 96);
            this.txt_PWD.Name = "txt_PWD";
            this.txt_PWD.PasswordChar = '*';
            this.txt_PWD.Size = new System.Drawing.Size(192, 21);
            this.txt_PWD.TabIndex = 4;
            this.txt_PWD.Text = "1234";
            // 
            // lbl_ServerID
            // 
            this.lbl_ServerID.Location = new System.Drawing.Point(9, 64);
            this.lbl_ServerID.Name = "lbl_ServerID";
            this.lbl_ServerID.Size = new System.Drawing.Size(100, 23);
            this.lbl_ServerID.TabIndex = 3;
            this.lbl_ServerID.Text = "SQL 서버 아이디";
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(160, 64);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(192, 21);
            this.txt_ID.TabIndex = 2;
            this.txt_ID.Text = "mydb";
            // 
            // lbl_ServerIP
            // 
            this.lbl_ServerIP.Location = new System.Drawing.Point(9, 32);
            this.lbl_ServerIP.Name = "lbl_ServerIP";
            this.lbl_ServerIP.Size = new System.Drawing.Size(100, 23);
            this.lbl_ServerIP.TabIndex = 1;
            this.lbl_ServerIP.Text = "SQL 서버 아이피";
            // 
            // tab_Server
            // 
            this.tab_Server.Controls.Add(this.chk_XML);
            this.tab_Server.Controls.Add(this.grb_ServerInfo);
            this.tab_Server.Controls.Add(this.btn_Start);
            this.tab_Server.Location = new System.Drawing.Point(4, 21);
            this.tab_Server.Name = "tab_Server";
            this.tab_Server.Size = new System.Drawing.Size(408, 351);
            this.tab_Server.TabIndex = 3;
            this.tab_Server.Text = "서버 정보";
            // 
            // chk_XML
            // 
            this.chk_XML.Location = new System.Drawing.Point(24, 320);
            this.chk_XML.Name = "chk_XML";
            this.chk_XML.Size = new System.Drawing.Size(368, 24);
            this.chk_XML.TabIndex = 2;
            this.chk_XML.Text = "XML 파일에서 데이터 읽어오기(SQL 데이터베이스 사용 안함)";
            // 
            // grb_ServerInfo
            // 
            this.grb_ServerInfo.Controls.Add(this.lbl_ServerDB);
            this.grb_ServerInfo.Controls.Add(this.txt_DBname);
            this.grb_ServerInfo.Controls.Add(this.lbl_ServerPWD);
            this.grb_ServerInfo.Controls.Add(this.txt_PWD);
            this.grb_ServerInfo.Controls.Add(this.lbl_ServerID);
            this.grb_ServerInfo.Controls.Add(this.txt_ID);
            this.grb_ServerInfo.Controls.Add(this.lbl_ServerIP);
            this.grb_ServerInfo.Controls.Add(this.txt_IP);
            this.grb_ServerInfo.Location = new System.Drawing.Point(24, 144);
            this.grb_ServerInfo.Name = "grb_ServerInfo";
            this.grb_ServerInfo.Size = new System.Drawing.Size(360, 168);
            this.grb_ServerInfo.TabIndex = 1;
            this.grb_ServerInfo.TabStop = false;
            this.grb_ServerInfo.Text = "서버 환경 설정";
            // 
            // lbl_ServerDB
            // 
            this.lbl_ServerDB.Location = new System.Drawing.Point(8, 128);
            this.lbl_ServerDB.Name = "lbl_ServerDB";
            this.lbl_ServerDB.Size = new System.Drawing.Size(136, 23);
            this.lbl_ServerDB.TabIndex = 7;
            this.lbl_ServerDB.Text = "SQL 서버 데이터베이스";
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(160, 32);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(192, 21);
            this.txt_IP.TabIndex = 0;
            this.txt_IP.Text = ".\\sqlexpress";
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(16, 16);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(376, 120);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "서버 시작";
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // lst_Member
            // 
            this.lst_Member.Location = new System.Drawing.Point(8, 8);
            this.lst_Member.Name = "lst_Member";
            this.lst_Member.Size = new System.Drawing.Size(392, 176);
            this.lst_Member.TabIndex = 3;
            this.lst_Member.UseCompatibleStateImageBehavior = false;
            this.lst_Member.DoubleClick += new System.EventHandler(this.lst_Member_DoubleClick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tab_Server);
            this.tabControl.Controls.Add(this.tab_Friend);
            this.tabControl.Controls.Add(this.tab_Member_Info);
            this.tabControl.Controls.Add(this.tab_Current_Info);
            this.tabControl.Controls.Add(this.tab_Debug_Info);
            this.tabControl.Location = new System.Drawing.Point(7, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(416, 376);
            this.tabControl.TabIndex = 2;
            // 
            // tab_Friend
            // 
            this.tab_Friend.Controls.Add(this.btn_Group);
            this.tab_Friend.Controls.Add(this.btn_Friend);
            this.tab_Friend.Controls.Add(this.groupBox2);
            this.tab_Friend.Controls.Add(this.groupBox1);
            this.tab_Friend.Location = new System.Drawing.Point(4, 21);
            this.tab_Friend.Name = "tab_Friend";
            this.tab_Friend.Size = new System.Drawing.Size(408, 351);
            this.tab_Friend.TabIndex = 4;
            this.tab_Friend.Text = "친구/그룹관리";
            // 
            // btn_Group
            // 
            this.btn_Group.Location = new System.Drawing.Point(224, 320);
            this.btn_Group.Name = "btn_Group";
            this.btn_Group.Size = new System.Drawing.Size(160, 23);
            this.btn_Group.TabIndex = 3;
            this.btn_Group.Text = "그룹관리";
            this.btn_Group.Click += new System.EventHandler(this.btn_Group_Click);
            // 
            // btn_Friend
            // 
            this.btn_Friend.Location = new System.Drawing.Point(24, 320);
            this.btn_Friend.Name = "btn_Friend";
            this.btn_Friend.Size = new System.Drawing.Size(168, 23);
            this.btn_Friend.TabIndex = 2;
            this.btn_Friend.Text = "친구관리";
            this.btn_Friend.Click += new System.EventHandler(this.btn_Friend_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lst_Group);
            this.groupBox2.Location = new System.Drawing.Point(8, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 144);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "그룹관리";
            // 
            // lst_Group
            // 
            this.lst_Group.Location = new System.Drawing.Point(8, 16);
            this.lst_Group.Name = "lst_Group";
            this.lst_Group.Size = new System.Drawing.Size(376, 120);
            this.lst_Group.TabIndex = 0;
            this.lst_Group.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lst_Friend);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "친구 관리";
            // 
            // lst_Friend
            // 
            this.lst_Friend.Location = new System.Drawing.Point(8, 16);
            this.lst_Friend.Name = "lst_Friend";
            this.lst_Friend.Size = new System.Drawing.Size(376, 128);
            this.lst_Friend.TabIndex = 0;
            this.lst_Friend.UseCompatibleStateImageBehavior = false;
            // 
            // tab_Member_Info
            // 
            this.tab_Member_Info.Controls.Add(this.lst_Member);
            this.tab_Member_Info.Controls.Add(this.grb_DataManager);
            this.tab_Member_Info.Controls.Add(this.grb_DataReadWrite);
            this.tab_Member_Info.Location = new System.Drawing.Point(4, 21);
            this.tab_Member_Info.Name = "tab_Member_Info";
            this.tab_Member_Info.Size = new System.Drawing.Size(408, 351);
            this.tab_Member_Info.TabIndex = 0;
            this.tab_Member_Info.Text = "회원 정보관리";
            this.tab_Member_Info.Visible = false;
            // 
            // grb_DataManager
            // 
            this.grb_DataManager.Controls.Add(this.btn_DeleteMember);
            this.grb_DataManager.Controls.Add(this.btn_EditMember);
            this.grb_DataManager.Controls.Add(this.btn_InsertMember);
            this.grb_DataManager.Location = new System.Drawing.Point(184, 192);
            this.grb_DataManager.Name = "grb_DataManager";
            this.grb_DataManager.Size = new System.Drawing.Size(216, 152);
            this.grb_DataManager.TabIndex = 2;
            this.grb_DataManager.TabStop = false;
            this.grb_DataManager.Text = "데이터 관리하기";
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 387);
            this.Controls.Add(this.tabControl);
            this.Name = "MainWnd";
            this.Text = "메신저 서버 ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWnd_FormClosed);
            this.tab_Current_Info.ResumeLayout(false);
            this.tab_Current_Info.PerformLayout();
            this.grb_DataReadWrite.ResumeLayout(false);
            this.tab_Debug_Info.ResumeLayout(false);
            this.tab_Debug_Info.PerformLayout();
            this.tab_Server.ResumeLayout(false);
            this.grb_ServerInfo.ResumeLayout(false);
            this.grb_ServerInfo.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tab_Friend.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tab_Member_Info.ResumeLayout(false);
            this.grb_DataManager.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Content;
        private System.Windows.Forms.Button btn_SqlWriter;
        private System.Windows.Forms.Button btn_SqlReader;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.TabPage tab_Current_Info;
        private System.Windows.Forms.TextBox txt_Broadcast_Title;
        private System.Windows.Forms.ListView lst_Connect;
        private System.Windows.Forms.Button btn_BroadcastAll;
        private System.Windows.Forms.TextBox txt_Broadcast_Content;
        private System.Windows.Forms.Button btn_Broadcast;
        private System.Windows.Forms.Button btn_ConnectHistorySave;
        private System.Windows.Forms.Button btn_DisConnectAll;
        private System.Windows.Forms.Button btn_DisConnect;
        private System.Windows.Forms.Button btn_ConnectRefresh;
        private System.Windows.Forms.TextBox txt_SelectMemberInfo;
        private System.Windows.Forms.Button btn_XMLReader;
        private System.Windows.Forms.Button btn_DeleteMember;
        private System.Windows.Forms.Button btn_EditMember;
        private System.Windows.Forms.Button btn_InsertMember;
        private System.Windows.Forms.Button btn_XMLWriter;
        private System.Windows.Forms.GroupBox grb_DataReadWrite;
        private System.Windows.Forms.TabPage tab_Debug_Info;
        private System.Windows.Forms.TextBox txt_Info;
        private System.Windows.Forms.TextBox txt_DBname;
        private System.Windows.Forms.Label lbl_ServerPWD;
        private System.Windows.Forms.TextBox txt_PWD;
        private System.Windows.Forms.Label lbl_ServerID;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.Label lbl_ServerIP;
        private System.Windows.Forms.TabPage tab_Server;
        private System.Windows.Forms.CheckBox chk_XML;
        private System.Windows.Forms.GroupBox grb_ServerInfo;
        private System.Windows.Forms.Label lbl_ServerDB;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.ListView lst_Member;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tab_Friend;
        private System.Windows.Forms.Button btn_Group;
        private System.Windows.Forms.Button btn_Friend;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lst_Group;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lst_Friend;
        private System.Windows.Forms.TabPage tab_Member_Info;
        private System.Windows.Forms.GroupBox grb_DataManager;
    }
}

