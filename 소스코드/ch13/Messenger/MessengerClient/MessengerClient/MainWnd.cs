using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;  // 레지스트리 값 읽어오기
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Collections;


namespace MessengerClient
{
    delegate void notify_popup(); // 공지창 출력
    delegate void add_msg();      // 디버깅 문자열 출력
    delegate void tree_view();    // 친구 목록 출력(tree_Friend)
    delegate void tree_friend(int x, int y); 

    public partial class MainWnd : Form
    {
        #region 멤버 변수

        /// <summary>
        /// 친구 정보 저장 테이블
        /// </summary>
        private DataTable tbl_Friend = null;

        /// <summary>
        /// 그룹 정보 저장 테이블
        /// </summary>
        private DataTable tbl_Group = null;

        /// <summary>
        /// 메신저 클라이언트 옵션 설정 테이블
        /// </summary>
        private DataTable tbl_Option = null;

        /// <summary>
        /// 받은 파일 저장 경로
        /// </summary>
        private static string Path_File = null;
        /// <summary>
        /// 채팅 문자열 암호화 설정
        /// </summary>
        private static bool chat_crypto = false;

        /// <summary>
        /// 서버 연결 소켓
        /// </summary>
        private Network net = null;

        /// <summary>
        /// 채팅 서버 소켓 연결
        /// </summary>
        private ChatServer cserver = null;

        /// <summary>
        /// 파일 전송 서버 소켓 
        /// </summary>
        private FileServer fserver = null;

        /// <summary>
        /// 채팅/파일 클라이언트 접속 관리 (사용자 아이디와 윈도우 창 저장)
        /// </summary>
        public static ArrayList MEMBER = new ArrayList();


        /// <summary>
        /// 채팅 서버 스레드
        /// </summary>
        private Thread server_th = null;

        /// <summary>
        /// 파일 서버 스레드
        /// </summary>
        private Thread file_server_th = null;


        /// <summary>
        /// 클라이언트 아이피
        /// </summary>
        private string my_ip = null;

        /// <summary>
        /// 로그인 아이디
        /// </summary>
        public static string MYID = null;

        /// <summary>
        /// 레지스트리 경로
        /// </summary> 
        private string strRegkey = "Software\\MagicSoft\\Messenger";

        /// <summary>
        /// 화면에 출력될 문자열 스타일 
        /// '0' : 사용자 아이디
        /// '1' : 사용자 이름
        /// '2' : 사용자 별칭
        /// </summary>
        private char display_option = '0';

        /// <summary>
        /// 친구 관리 대화상자
        /// </summary>
        private FriendWnd friendWnd = null;

        /// <summary>
        /// 친구 그룹 관리 대화상자
        /// </summary>
        private GroupWnd groupWnd = null;

        /// <summary>
        /// 로그인 아이디
        /// </summary>
        private string strMyID = "";
        /// <summary>
        /// 로그인 패스워드
        /// </summary>
        private string strMyPWD = "";
        /// <summary>
        /// 메신저 서버 아이피
        /// </summary>
        private string strServerIP = "";
        /// <summary>
        /// 디버깅 창에 출력되는 문자열
        /// </summary>
        private string strAddMsg = null;

        /// <summary>
        /// 공지창 클래스
        /// </summary>
        private NotifyWnd notifywnd = null;
        /// <summary>
        /// 공지창 제목
        /// </summary>
        private string strTitle = null;
        /// <summary>
        /// 공지창 내용
        /// </summary>
        private string strContent = null;

        /// <summary>
        /// 친구 그룹 아이디
        /// </summary>
        private string strGroupID = null;
        /// <summary>
        /// 친구 그룹 이름
        /// </summary>
        private string strGroupName = null;
        /// <summary>
        /// 친구 상태 표시
        /// </summary>
        private byte friendState;
        /// <summary>
        /// 친구 아이피 주소
        /// </summary>
        private string strIP = null;

        /// <summary>
        /// 트리뷰에 추가할 사용자 아이디
        /// </summary>
        private string strUserID = null;
        /// <summary>
        /// 트리뷰에 추가할 사용자 이름
        /// </summary>
        private string strName = null;
        /// <summary>
        /// 트리뷰에 추가할 별칭 
        /// </summary>
        private string strNickName = null;
        /// <summary>
        /// 트리뷰에 추가할 전자메일 주소
        /// </summary>
        private string strEmail = null;

        /// <summary>
        /// 트리뷰에 출력할 아이콘 저장
        /// </summary>
        private ImageList treeviewImageList = null;

        /// <summary>
        /// 트리뷰 화면에 출력될 문자열
        /// </summary>
        private string strString = null;

        #endregion

        #region 생성자
        /// <summary>
        /// 생성자
        /// </summary>
        public MainWnd()
        {
            InitializeComponent();

            // 네트워크 클래스 객체 생성
            this.net = new Network(this);
            this.my_ip = this.net.GetMyIP();

            // 데이터 테이블 생성
            this.Init_DataTable();

            // 옵션 데이터 불러오기
            this.Load_DataTable();

            if (Convert.ToBoolean(this.tbl_Option.Rows[0]["login_auto"].ToString().Trim()))
            {   // 자동 로그인 활성화
                this.txt_ID.Text = this.tbl_Option.Rows[0]["login_id"].ToString();
                this.txt_Pwd.Text = this.tbl_Option.Rows[0]["login_pwd"].ToString();
            }

            // 공지창 관련            
            this.notifywnd = new NotifyWnd(new Bitmap(GetType(), "Image_BackgroundImage.bmp"), new Bitmap(GetType(), "Image_CloseImage.bmp"));
            this.notifywnd.TitleClick += new EventHandler(TitleClick);     // 공지창에서 제목 클릭할때
            this.notifywnd.ContentClick += new EventHandler(ContentClick); // 공지창에서 내용 클릭할때
            this.notifywnd.CloseClick += new EventHandler(CloseClick);     // 공지창에서 종료버튼 클릭할때

            // 메뉴처리
            this.menuItem_Logout.Enabled = false;   // 로그아웃

            // 트리뷰에 출력할 이미지
            this.treeviewImageList = new ImageList();

            this.treeviewImageList.Images.Add(new Bitmap(GetType(), "Image_group.bmp"), Color.White);
            this.treeviewImageList.Images.Add(new Bitmap(GetType(), "Image_online.bmp"), Color.White);
            this.treeviewImageList.Images.Add(new Bitmap(GetType(), "Image_offline.bmp"), Color.White);
            this.treeviewImageList.Images.Add(new Bitmap(GetType(), "Image_tel.bmp"), Color.White);
            this.treeviewImageList.Images.Add(new Bitmap(GetType(), "Image_meal.bmp"), Color.White);
            this.treeviewImageList.Images.Add(new Bitmap(GetType(), "Image_etc.bmp"), Color.White);
            this.treeviewImageList.Images.Add(new Bitmap(GetType(), "Image_leave.bmp"), Color.White);
            this.treeviewImageList.Images.Add(new Bitmap(GetType(), "Image_return.bmp"), Color.White);


            this.tree_Friend.ImageList = this.treeviewImageList;
            this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picture_Logo.SizeMode = PictureBoxSizeMode.AutoSize;
            this.picture_Logo.Image = new Bitmap(GetType(), "Image_logo.gif");
            
        }

        #endregion

        #region 멤버 속성

        /// <summary>
        /// 그룹 이름 저장 속성 테이블
        /// </summary>
        public DataTable TBL_GROUP
        {
            set
            {
                this.tbl_Group = value;
            }
            get
            {
                return this.tbl_Group;
            }
        }

        /// <summary>
        /// 친구 정보 저장 속성 테이블
        /// </summary>
        public DataTable TBL_FRIEND
        {
            set
            {
                this.tbl_Friend = value;
            }
            get
            {
                return this.tbl_Friend;
            }
        }

        /// <summary>
        /// 친구 관리 폼
        /// </summary>
        public FriendWnd FRIENDWND
        {
            get
            {
                return this.friendWnd;
            }
        }

        /// <summary>
        /// 그룹 관리 폼
        /// </summary>
        public GroupWnd GROUPWND
        {
            get
            {
                return this.groupWnd;
            }
        }

        /// <summary>
        /// 친구 정보 저장 테이블
        /// </summary>
        public TreeView TREE_FRIEND
        {
            get
            {
                return this.tree_Friend;
            }
        }

        /// <summary>
        /// 받은 파일 저장 경로
        /// </summary>
        public static string PATH_FILE
        {
            set
            {
                MainWnd.Path_File = value;
            }
            get
            {
                return MainWnd.Path_File;
            }
        }

        /// <summary>
        /// 채팅 문자열 암호화
        /// </summary>
        public static bool CHAT_Crypto
        {
            set
            {
                MainWnd.chat_crypto = value;
            }
            get
            {
                return MainWnd.chat_crypto;
            }
        }

        #endregion


        #region 레지스트리 처리/ 메모리 테이블 초기화

        /// <summary>
        /// 레지스트리에 옵션 값 기록하기
        /// </summary>
        private void Save_Registry()
        {
            try
            {
                // 레지스트리에 값 기록하기
                RegistryKey regkey = Registry.CurrentUser.OpenSubKey(this.strRegkey, true);

                if (regkey == null)
                {
                    // 레지스트리를 새롭게 만듬
                    regkey = Registry.CurrentUser.CreateSubKey(strRegkey);
                }

                regkey.SetValue("login_auto", Convert.ToBoolean(this.tbl_Option.Rows[0]["login_auto"].ToString())); // 자동로그인 옵션
                regkey.SetValue("login_id", this.tbl_Option.Rows[0]["login_id"].ToString());   // 로그인 아이디
                regkey.SetValue("login_pwd", this.tbl_Option.Rows[0]["login_pwd"].ToString());  // 로그인 비밀번호
                regkey.SetValue("path_file", this.tbl_Option.Rows[0]["path_file"].ToString());   // 로그인 아이디			
                regkey.SetValue("notify_show", Convert.ToInt32(this.tbl_Option.Rows[0]["notify_show"].ToString().Trim()));   // 공지창 출력 시간
                regkey.SetValue("notify_stay", Convert.ToInt32(this.tbl_Option.Rows[0]["notify_stay"].ToString().Trim()));   // 공지창 지속 시간
                regkey.SetValue("notify_hide", Convert.ToInt32(this.tbl_Option.Rows[0]["notify_hide"].ToString().Trim()));   // 공지창 소멸 시간		   
                regkey.SetValue("option_style", Convert.ToBoolean(this.tbl_Option.Rows[0]["option_style"].ToString()));       // 저장 스타일(XML 백업기능)
                regkey.SetValue("cryptograph", Convert.ToBoolean(this.tbl_Option.Rows[0]["cryptograph"].ToString()));        // 채팅 문자열 암호화 전송 기능

                regkey.Close(); // 레지스트리 닫기


                // 만약 XML 파일 저장 옵션이 켜져 있다면
                if (Convert.ToBoolean(this.tbl_Option.Rows[0]["option_style"].ToString()))
                {
                    DataSet ds = new DataSet("TBL_Option");
                    ds.Tables.Add(this.tbl_Option);

                    ds.WriteXml("MSNOption.xml");
                }
            }
            catch (Exception ex)
            {
                this.Add_MSG("레지스터 저장 에러 : " + ex.Message);
            }
        }

        /// <summary>
        /// tbl_Friend, tbl_Group, tbl_Option 테이블 생성
        /// </summary>
        private void Init_DataTable()
        {
            // 친구 테이블 만들기(친구 아이디, 친구이름, 친구 별칭, 친구 전자메일주소
            this.tbl_Friend = new DataTable("TBL_Friend");

            DataColumn column = new DataColumn("id", Type.GetType("System.String"));
            column.AllowDBNull = false;
            column.Unique = true;
            column.MaxLength = 30;
            this.tbl_Friend.Columns.Add(column);   // 친구 아이디

            column = new DataColumn("name", Type.GetType("System.String"));
            column.AllowDBNull = false;
            column.MaxLength = 50;
            this.tbl_Friend.Columns.Add(column);   // 친구 이름

            column = new DataColumn("nickname", Type.GetType("System.String"));
            column.MaxLength = 50;
            this.tbl_Friend.Columns.Add(column);   // 친구 별칭

            column = new DataColumn("email", Type.GetType("System.String"));
            column.MaxLength = 50;
            this.tbl_Friend.Columns.Add(column);   // 친구 전자메일 주소

            column = new DataColumn("ip", Type.GetType("System.String"));
            column.AllowDBNull = false;
            column.MaxLength = 15;
            this.tbl_Friend.Columns.Add(column);   // 친구 아이피 주소

            column = new DataColumn("state", Type.GetType("System.Byte"));
            this.tbl_Friend.Columns.Add(column);   // 친구 현재 상태

            column = new DataColumn("group_id", Type.GetType("System.String"));
            column.MaxLength = 60;
            this.tbl_Friend.Columns.Add(column);   // 친구가 포함된 그룹 아이디

            DataColumn[] pk = new DataColumn[1];
            pk[0] = tbl_Friend.Columns["id"];  // 친구 테이블의 기본키를 id로 설정
            this.tbl_Friend.PrimaryKey = pk;


            // 그룹 이름 저장 테이블
            this.tbl_Group = new DataTable("TBL_Group");

            column = new DataColumn("group_id", Type.GetType("System.Int32"));
            column.AllowDBNull = false;
            this.tbl_Group.Columns.Add(column);          // 친구 그룹 이름 아이디

            column = new DataColumn("group_name", Type.GetType("System.String"));
            column.MaxLength = 60;
            this.tbl_Group.Columns.Add(column);         // 친구 그룹 이름 저장


            // 메신저 환경 설정 테이블
            this.tbl_Option = new DataTable("TBL_Option");

            column = new DataColumn("login_auto", Type.GetType("System.Boolean"));
            column.DefaultValue = false;
            this.tbl_Option.Columns.Add(column);         // 자동 로그인 옵션

            column = new DataColumn("login_id", Type.GetType("System.String"));
            column.MaxLength = 30;
            this.tbl_Option.Columns.Add(column);         //  로그인 아이디

            column = new DataColumn("login_pwd", Type.GetType("System.String"));
            column.MaxLength = 30;
            this.tbl_Option.Columns.Add(column);         //  로그인 비밀번호

            column = new DataColumn("path_file", Type.GetType("System.String"));
            column.MaxLength = 500;
            this.tbl_Option.Columns.Add(column);         //  다운로드 파일 저장 경로

            column = new DataColumn("notify_show", Type.GetType("System.Int32"));
            column.DefaultValue = 500;
            this.tbl_Option.Columns.Add(column);         //  공지창 출력 시간

            column = new DataColumn("notify_stay", Type.GetType("System.Int32"));
            column.DefaultValue = 3000;
            this.tbl_Option.Columns.Add(column);         //  공지창 지속 시간

            column = new DataColumn("notify_hide", Type.GetType("System.Int32"));
            column.DefaultValue = 500;
            this.tbl_Option.Columns.Add(column);         //  공지창 소멸 시간

            column = new DataColumn("option_style", Type.GetType("System.Boolean"));
            column.DefaultValue = false;                 // 기본 값 레지스트리 저장 
            this.tbl_Option.Columns.Add(column);         // 자동 로그인 옵션

            column = new DataColumn("cryptograph", Type.GetType("System.Boolean"));
            column.DefaultValue = false;                 // 암호화 전송 꺼짐
            this.tbl_Option.Columns.Add(column);         // 채팅 문자열 암호화 전송 기능              


        }


        /// <summary>
        /// 테이블 값 설정하기
        /// tbl_Option 테이블 값 채우기
        /// </summary>
        private void Load_DataTable()
        {
            try
            {

                DataRow row = this.tbl_Option.NewRow();

                // 레지스트리에서 공유,다운로드 디렉토리 값 읽어오기
                RegistryKey regkey = Registry.CurrentUser.OpenSubKey(strRegkey);

                // 레지스트리 값이 있다면
                if (regkey != null)
                {
                    if (Convert.ToBoolean(regkey.GetValue("option_style").ToString().Trim())) // XML 저장을 지원한다면
                    {
                        DataSet ds = new DataSet("TBL_Option");
                        ds.ReadXml("MSNOption.xml");
                        this.tbl_Option = ds.Tables["TBL_Option"].Copy();

                        MainWnd.Path_File = ds.Tables["TBL_Option"].Rows[0]["path_file"].ToString().Trim();
                        MainWnd.CHAT_Crypto = Convert.ToBoolean(ds.Tables["TBL_OPtion"].Rows[0]["cryptograph"].ToString().Trim());

                        ds.Dispose();
                        return;
                    }
                    else
                    {
                        row["login_auto"] = Convert.ToBoolean(regkey.GetValue("login_auto").ToString().Trim());  // 자동 로그인
                        row["login_id"] = (string)regkey.GetValue("login_id");  // 로그인 아이디
                        row["login_pwd"] = (string)regkey.GetValue("login_pwd"); // 로그인 비밀번호
                        row["path_file"] = (string)regkey.GetValue("path_file"); // 다운로드 파일 저장 경로

                        MainWnd.Path_File = (string)regkey.GetValue("path_file");

                        row["notify_show"] = (int)regkey.GetValue("notify_show"); // 공지창 출력 시간
                        row["notify_stay"] = (int)regkey.GetValue("notify_stay"); // 공지창 지속 시간
                        row["notify_hide"] = (int)regkey.GetValue("notify_hide"); // 공지창 소멸 시간
                        row["option_style"] = Convert.ToBoolean(regkey.GetValue("option_style").ToString().Trim()); // XML 파일 백업
                        row["cryptograph"] = Convert.ToBoolean(regkey.GetValue("cryptograph").ToString().Trim());// 암호화

                        MainWnd.CHAT_Crypto = Convert.ToBoolean(regkey.GetValue("cryptograph").ToString().Trim());
                    }

                    regkey.Close();  // 레지스트리 키 닫기
                }
                else
                {
                    row["login_auto"] = false;   // 자동 로그인 비활성화
                    row["login_id"] = "";
                    row["login_pwd"] = "";
                    row["path_file"] = @"c:\";

                    MainWnd.Path_File = @"c:\";

                    row["notify_show"] = 500;
                    row["notify_stay"] = 3000;
                    row["notify_hide"] = 500;
                    row["option_style"] = false; // XML 파일 백업 비활성화
                    row["cryptograph"] = false; // 암호화 비활성화

                    MainWnd.CHAT_Crypto = false;

                }

                this.tbl_Option.Rows.Add(row);
            }
            catch (Exception ex)
            {
                this.Add_MSG("레지스터 값 읽어오기 에러 : " + ex.Message);
            }


        }

        #endregion

        #region Invoke 관련 메서드

        /// <summary>
        /// 디버깅창에 메시지 출력
        /// </summary>
        /// <param name="msg">출력할 메시지</param>		
        public void Add_MSG(string msg)
        {
            this.strAddMsg = msg;
            add_msg addmsg = new add_msg(AddMSG);
            this.Invoke(addmsg);
        }

        /// <summary>
        /// 디버깅 창 인보크 메서드
        /// </summary>
        private void AddMSG()
        {
            lock (this.txt_Info)
            {
                this.txt_Info.AppendText(this.strAddMsg + "\r\n");
                this.txt_Info.ScrollToCaret();
            }
        }


        /// <summary>
        /// 공지창 출력 설정
        /// </summary>
        /// <param name="strTitle">제목</param>
        /// <param name="strContent">내용</param>
        public void NotifyPopup(string strTitle, string strContent)
        {
            this.strTitle = strTitle;
            this.strContent = strContent;

            notify_popup notify = new notify_popup(NotifyWndShow);
            this.Invoke(notify);

        }

        /// <summary>
        /// 공지창 Invoke
        /// </summary>
        public void NotifyWndShow()
        {
            int nShowTime = Convert.ToInt32(this.tbl_Option.Rows[0]["notify_show"].ToString().Trim());
            int nStayTime = Convert.ToInt32(this.tbl_Option.Rows[0]["notify_stay"].ToString().Trim());
            int nHideTime = Convert.ToInt32(this.tbl_Option.Rows[0]["notify_hide"].ToString().Trim());

            this.notifywnd.Show(this.strTitle, this.strContent, nShowTime, nStayTime, nHideTime);
        }

        /// <summary>
        ///  친구 목록 트리뷰에 값 추가
        /// </summary>
        /// <param name="strGroupID">그룹 아이디</param>
        /// <param name="friendState">친구 상태</param>
        /// <param name="strIP">친구 아이피</param>
        /// <param name="strUserID">사용자 아이디</param>
        /// <param name="strName">사용자 이름</param>
        /// <param name="strNickName">사용자 별칭</param>
        /// <param name="strEmail">사용자 전자메일 주소</param>
        public void Add_treeFriend(string strGroupID, string friendState, string strIP, string strUserID, string strName, string strNickName, string strEmail)
        {
            if ((strGroupID == null) && (friendState == null) && (strIP == null))
            {
                this.Add_MSG("친구 정보가 없습니다. 친구를 등록하세요!");
                return;
            }

            this.strGroupID = strGroupID;
            this.friendState = Convert.ToByte(friendState.Trim());
            this.strIP = strIP;
            this.strUserID = strUserID;
            this.strName = strName;
            this.strNickName = strNickName;
            this.strEmail = strEmail;

            this.CheckDisplayString();

            tree_view tree = new tree_view(TreeFriendADD);    // 친구 목록 출력(tree_Friend)
            this.Invoke(tree);

        }

        /// <summary>
        /// 친구 목록 트리뷰에 값 추가 Invoke
        /// </summary>
        public void TreeFriendADD()
        {
            int i = 0;
            int j = 0;

            if (this.tbl_Group.Rows.Count > 0)
            {
                for (j = 0; j < this.tbl_Group.Rows.Count; j++)
                {
                    if (this.tbl_Group.Rows[j]["group_id"].ToString().Trim() == this.strGroupID)
                    {
                        TreeNode tn = null;
                        if (this.friendState == (byte)ClientStates.online)
                        {
                            tn = new TreeNode(this.strString, 1, 1);
                        }
                        else if (this.friendState == (byte)ClientStates.offline)
                        {
                            tn = new TreeNode(this.strString, 2, 2);
                        }
                        else if (this.friendState == (byte)ClientStates.tel)
                        {
                            tn = new TreeNode(this.strString, 3, 3);
                        }
                        else if (this.friendState == (byte)ClientStates.meal)
                        {
                            tn = new TreeNode(this.strString, 4, 4);
                        }
                        else if (this.friendState == (byte)ClientStates.etc)
                        {
                            tn = new TreeNode(this.strString, 5, 5);
                        }
                        else if (this.friendState == (byte)ClientStates.leave)
                        {
                            tn = new TreeNode(this.strString, 6, 6);
                        }
                        else if (this.friendState == (byte)ClientStates.retun)
                        {
                            tn = new TreeNode(this.strString, 7, 7);
                        }

                        this.tree_Friend.Nodes[i].Nodes.Add(tn);
                    }
                    i++;
                }
            }
            else   // 그룹 이름이 하나도 없다면
            {
                TreeNode tn = null;
                if (this.friendState == (byte)ClientStates.online)
                {
                    tn = new TreeNode(this.strString, 1, 1);
                }
                else if (this.friendState == (byte)ClientStates.offline)
                {
                    tn = new TreeNode(this.strString, 2, 2);
                }
                else if (this.friendState == (byte)ClientStates.tel)
                {
                    tn = new TreeNode(this.strString, 3, 3);
                }
                else if (this.friendState == (byte)ClientStates.meal)
                {
                    tn = new TreeNode(this.strString, 4, 4);
                }
                else if (this.friendState == (byte)ClientStates.etc)
                {
                    tn = new TreeNode(this.strString, 5, 5);
                }
                else if (this.friendState == (byte)ClientStates.leave)
                {
                    tn = new TreeNode(this.strString, 6, 6);
                }
                else if (this.friendState == (byte)ClientStates.retun)
                {
                    tn = new TreeNode(this.strString, 7, 7);
                }

                this.tree_Friend.Nodes[0].Nodes.Add(tn);
            }
        }

        /// <summary>
        /// 그룹 이름 추가
        /// </summary>
        public void Add_treeGroupName()
        {
            try
            {               
                tree_view tree = new tree_view(TreeFriendGroupNameADD);    // 친구 목록 출력(tree_Friend)
                if (this.tbl_Group.Rows.Count > 0)
                {
                    for (int i = 0; i < this.tbl_Group.Rows.Count; i++)
                    {
                        this.strGroupName = this.tbl_Group.Rows[i]["group_name"].ToString().Trim();
                        this.Invoke(tree);
                    }
                }
                else  // 친구 그룹이 하나도 없다면
                {
                    this.strGroupName = "그룹없음...";
                    this.Invoke(tree);
                }
            }
            catch { }

        }


        /// <summary>
        /// 친구 목록 트리뷰에 값 추가 Invoke
        /// </summary>
        public void TreeFriendGroupNameADD()
        {
            this.tree_Friend.Nodes.Add(this.strGroupName);
        }


        /// <summary>
        /// 친구 목록 트리뷰 갱신하기
        /// </summary>
        public void Refresh_TreeFriend()
        {
            tree_view tree = new tree_view(TreeFriendRefresh);    // 친구 목록 출력(tree_Friend)
            this.Invoke(tree);
        }

        /// <summary>
        /// 친구 목록 트리뷰 갱신하기 Invoke
        /// </summary>
        public void TreeFriendRefresh()
        {
            this.tree_Friend.Refresh();
        }

        /// <summary>
        /// 트리뷰 갱신(친구 상태)
        /// </summary>
        /// <param name="strUserID">친구 아이디</param>
        /// <param name="friendState">친구 상태</param>
        public void Update_TreeFriend(string strUserID, byte friendState)
        {
            this.strUserID = strUserID;
            this.friendState = friendState;

            tree_view tree = new tree_view(TreeFriendUpdae);    // 친구 목록 출력(tree_Friend)
            this.Invoke(tree);
        }

        /// <summary>
        /// Update_TreeFriend Invoke
        /// </summary>
        public void TreeFriendUpdae()
        {
            int i, j;

            for (i = 0; i < this.tree_Friend.Nodes.Count; i++)
            {
                for (j = 0; j < this.tree_Friend.Nodes[i].Nodes.Count; j++)
                {
                    if (this.strUserID == this.tree_Friend.Nodes[i].Nodes[j].Text)
                    {
                        // 그룹 이미지가 이미지 리스트에 첫번째로 있기 때문에 friendState 에 1을 더해줌
                        this.tree_Friend.Nodes[i].Nodes[j].ImageIndex = this.friendState + 1;
                        this.tree_Friend.Nodes[i].Nodes[j].SelectedImageIndex = this.friendState + 1;
                    }

                }
            }
            this.tree_Friend.Refresh();
        }

        #endregion

        #region  공지창 이벤트 처리

        /// <summary>
        /// 창 닫기 이미지를 누르면 발생하는 이벤트
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void CloseClick(object obj, EventArgs ea)
        {
            MessageBox.Show("공지창을 닫습니다.!");
        }

        /// <summary>
        /// 제목을 클릭하면 발생하는 이벤트
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void TitleClick(object obj, EventArgs ea)
        {
            MessageBox.Show(((NotifyWnd)obj).TitleText, "제목 누름!");
        }

        /// <summary>
        /// 내용을 클릭하면 발생하는 이벤트
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void ContentClick(object obj, EventArgs ea)
        {
            MessageBox.Show(((NotifyWnd)obj).ContentText, "내용 누름!");
        }

        #endregion

        #region 멤버 메서드

        /// <summary>
        /// 친구에게 채팅 요청( 채팅 창 띄우기...)
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="ip"></param>
        private void ConnectFriend(string user_id, string ip)
        {
            try
            {
                // 소켓 클라이언트 시작 ( 채팅 포트는 2500번 )
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 2500);
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(ipep);

                //서버에 접속이 되면
                if (client.Connected)
                {
                    byte[] data = Encoding.Default.GetBytes(MainWnd.MYID);
                    byte[] data_size = new byte[4];
                    data_size = BitConverter.GetBytes(data.Length);
                    client.Send(data_size);
                    client.Send(data, 0, data.Length, SocketFlags.None);

                    // 채팅창을 띄운다.(쓰레드 이용)
                    ChatNetwork newchat = new ChatNetwork(client, user_id, ipep.Address.ToString().Trim(), false);
                    MainWnd.MEMBER.Add(newchat);
                    Thread th = new Thread(new ThreadStart(newchat.Show));
                    th.IsBackground = true;
                    th.Start();
                }

            }
            catch (Exception ex)
            {
                this.Add_MSG("채팅 접속 : " + ex.Message);
            }
        }

        /// <summary>
        /// user_id 사용자에게 채팅 시도함
        /// </summary>
        /// <param name="user_id"></param>
        private void SelectFriend(string user_id)
        {
            try
            {
                DataRow[] row = this.tbl_Friend.Select("id='" + user_id + "'");

                if (row.Length > 0)
                {   // 상대방이 오프라인만 아니라면
                    if (Convert.ToByte(row[0]["state"].ToString().Trim()) != (byte)ClientStates.offline)
                    {
                        // 채팅창 띄우기
                        // 상대방 아이피 번호 -> row[0]["ip"]   ==> 구현하기 바람..						
                        this.ConnectFriend(user_id, row[0]["ip"].ToString().Trim()); // ~님과의 대화

                    }
                }
            }
            catch (Exception ex)
            {
                this.Add_MSG("채팅 상대 선택 에러 : " + ex.Message);
            }
        }

        /// <summary>
        /// 이름/아이디/별칭 표시 갱신
        /// </summary>
        private void TreeFriendRedraw()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    tree_view d = new tree_view(TreeFriendRedraw);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    this.tree_Friend.Nodes.Clear();   // 트리뷰 초기화

                    this.Add_treeGroupName();         // 그룹명 출력

                    DataRow[] rows = this.tbl_Friend.Select();

                    foreach (DataRow row in rows)
                    {
                        this.Add_treeFriend(row["group_id"].ToString().Trim(), row["state"].ToString().Trim(),
                                            row["ip"].ToString().Trim(), row["id"].ToString().Trim(),
                                            row["name"].ToString().Trim(), row["nickname"].ToString().Trim(),
                                            row["email"].ToString().Trim());
                    }

                    this.tree_Friend.ExpandAll();
                }                
            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
            }
        }


        /// <summary>
        /// 화면에 출력될 문자 형태 지정
        /// </summary>
        private void CheckDisplayString()
        {
            switch (this.display_option)
            {
                case '0':
                    this.strString = this.strUserID;
                    break;

                case '1':
                    this.strString = this.strName;
                    break;

                case '2':
                    this.strString = this.strNickName;
                    break;
            }
        }

        /// <summary>
        /// 메신저 서버에 내 상태 정보 전송
        /// </summary>
        /// <param name="state"></param>
        private void MyStateInfoSend(ClientStates state)
        {

            string msg = (byte)MSG.CTOS_MESSAGE_MY_STATES + "\a" + (byte)state;

            this.net.Send(msg);
        }

        /// <summary>
        /// 로그인 시도
        /// </summary>
        private bool Login()
        {
            try
            {
                MainWnd.MEMBER.Clear();

                this.strServerIP = txt_IP.Text.Trim();
                this.strMyID = txt_ID.Text.Trim();
                this.strMyPWD = txt_Pwd.Text.Trim();

                if (this.strServerIP.Length == 0)
                {
                    MessageBox.Show("아이피 번호를 입력하세요!", "에러메시지");
                    return false;
                }
                if (this.strMyID.Length == 0)
                {
                    MessageBox.Show("아이디를 입력하세요!", "에러메시지");
                    return false;
                }
                if (this.strMyPWD.Length == 0)
                {
                    MessageBox.Show("비밀번호를 입력하세요!", "에러메시지");
                    return false;
                }

                if (this.net.Connect(this.strServerIP)) // 서버 연결
                {
                    string msg = (byte)MSG.CTOS_MESSAGE_LOGIN_REQUEST + "\a";
                    msg += this.strMyID + "\a";       // 회원 아이디
                    msg += this.strMyPWD + "\a";      // 회원 비밀번호


                    this.net.Send(msg);

                    // 채팅 서버 2500번 시작
                    this.cserver = new ChatServer(this);
                    this.server_th = new Thread(new ThreadStart(this.cserver.ServerStart));
                    server_th.Start();

                    this.fserver = new FileServer(this);
                    // 파일 서버 2700번 시작
                    this.file_server_th = new Thread(new ThreadStart(this.fserver.ServerStart));
                    this.file_server_th.Start();

                    return true;  // 로그인 성공
                }
                else
                {
                    return false; // 로그인 실패
                }
            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
                return false;
            }

        }


        /// <summary>
        /// 로그아웃
        /// </summary>
        private bool Logout()
        {
            try
            {
                LogoutProcess();
            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
                return false;
            }
            return true;
        }

        private void LogoutProcess()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    add_msg d = new add_msg(LogoutProcess);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    string msg = (byte)MSG.CTOS_MESSAGE_LOGOUT_REQUEST + "\a" + this.strMyID;
                    this.net.Send(msg);
                    // 서버쪽에서 연결을 끊기때문에 Disconnect() 할 필요 없음!				
                    this.tree_Friend.Nodes.Clear();
                    this.tbl_Group.Rows.Clear();     // 그룹 이름 초기화
                    this.tbl_Friend.Rows.Clear();    // 친구 목록 초기화

                    try
                    {
                        // 채팅 서버 종료
                        this.cserver.ServerStop();

                        if (server_th.IsAlive)
                            server_th.Abort();
                    }
                    finally
                    {
                        // 파일 서버 종료
                        this.fserver.ServerStop();

                        if (file_server_th.IsAlive)
                            file_server_th.Abort();
                    }
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// 프로그램 종료
        /// </summary>
        private void QuitProgram()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    add_msg d = new add_msg(QuitProgram);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    if (this.btn_Login.Text != "로그인")
                        this.Logout();
                }
            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
            }
            finally
            {
                this.Dispose();
            }
        }

        #endregion

        /// <summary>
        /// 로그인 메뉴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Login_Click(object sender, EventArgs e)
        {
            try
            {
                this.Show();
                this.Activate();

                if (btn_Login.Text == "로그인")
                {
                    this.Login();
                    this.menuItem_Logout.Enabled = true;
                    this.menuItem_Login.Enabled = false;
                    this.btn_Login.Text = "로그아웃";
                }
            }
            catch { }
        }

        /// <summary>
        /// 로그아웃 메뉴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Logout_Click(object sender, EventArgs e)
        {
            try
            {
                this.Show();
                this.Activate();

                if (btn_Login.Text == "로그아웃")
                {
                    this.Logout();
                    this.menuItem_Logout.Enabled = false;
                    this.menuItem_Login.Enabled = true;
                    this.btn_Login.Text = "로그인";
                }
            }
            catch { }
        }

        /// <summary>
        /// 프로그램 종료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Quit_Click(object sender, EventArgs e)
        {
            try
            {
                this.QuitProgram();
            }
            catch { }
        }


        /// <summary>
        /// 내 상태를 온라인으로 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_State_Online_Click(object sender, EventArgs e)
        {
            try
            {
                this.MyStateInfoSend(ClientStates.online);
            }
            catch { }
        }

        /// <summary>
        /// 내 상태를 오프라인으로 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_State_Offline_Click(object sender, EventArgs e)
        {
            try
            {
                this.MyStateInfoSend(ClientStates.offline);
            }
            catch { }
        }

        /// <summary>
        /// 내 상태를 통화중으로 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>		
        private void menuItem_State_Tel_Click(object sender, EventArgs e)
        {
            try
            {
                this.MyStateInfoSend(ClientStates.tel);
            }
            catch { }
        }

        /// <summary>
        /// 내 상태를 식사중으로 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_State_Meal_Click(object sender, EventArgs e)
        {
            try
            {
                this.MyStateInfoSend(ClientStates.meal);
            }
            catch { }
        }

 		/// <summary>
		/// 내 상태를 다른 용무중으로 설정
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>	
        private void menuItem_State_Etc_Click(object sender, EventArgs e)
        {
            try
            {
                this.MyStateInfoSend(ClientStates.etc);
            }
            catch { }
        }

        /// <summary>
        /// 내 상태를 자리 비움으로 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_State_Leave_Click(object sender, EventArgs e)
        {
            try
            {
                this.MyStateInfoSend(ClientStates.leave);
            }
            catch { }
        }

        /// <summary>
        /// 내 상태를 곧 돌아오겠음으로 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_State_Return_Click(object sender, EventArgs e)
        {
            try
            {
                this.MyStateInfoSend(ClientStates.retun);
            }
            catch { }
        }

        /// <summary>
        /// 그룹 정보
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Group_Click(object sender, EventArgs e)
        {
            // 그룹 정보를 갖어온다
            // 그룹 정보를 변경한 후
            // 그 정보를 서버단에 전송한다.
            try
            {
                this.groupWnd = new GroupWnd(this.net, MainWnd.MYID, this.TBL_GROUP);
                this.groupWnd.ShowDialog();
            }
            catch { }
        }

        /// <summary>
        /// 친구 정보
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Friend_Click(object sender, EventArgs e)
        {
            try
            {
                this.friendWnd = new FriendWnd(this.net, MainWnd.MYID, this.tbl_Friend, this.tbl_Group);
                this.friendWnd.ShowDialog();
            }
            catch { }
        }

        /// <summary>
        /// 인스턴스 메신저
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_MSN_Chat_Click(object sender, EventArgs e)
        {
            try
            {
                this.tree_Friend_DoubleClick(sender, e);
            }
            catch { }
        }

        /// <summary>
        /// 메일 보내기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_MSN_Mail_Click(object sender, EventArgs e)
        {
            try
            {
                MailSendWnd dlg = new MailSendWnd("", "");
                dlg.ShowDialog();
            }
            catch { }
        }

        /// <summary>
        /// 메신저 옵션
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Option_Click(object sender, EventArgs e)
        {
            try
            {
                OptionWnd dlg = new OptionWnd(this.tbl_Option);
                dlg.ShowDialog();
            }
            catch { }
        }

        /// <summary>
        /// 이 프로그램은...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Help_Click(object sender, EventArgs e)
        {
            try
            {
                AboutWnd dlg = new AboutWnd();
                dlg.ShowDialog();
            }
            catch { }
        }

        /// <summary>
        /// 트레이 아이콘 더블클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Show();
                this.Activate();
            }
            catch { }
        }

        /// <summary>
        /// 트레이 로그인 메뉴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_tray_login_Click(object sender, EventArgs e)
        {
            try
            {
                this.Show();
                this.Activate();
                menuItem_Login_Click(sender, e);
            }
            catch { }
        }

        /// <summary>
        /// 트레이 로그아웃 메뉴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_tray_logout_Click(object sender, EventArgs e)
        {
            try
            {
                this.Show();
                this.Activate();
                menuItem_Logout_Click(sender, e);
            }
            catch { }
        }

        /// <summary>
        /// 트레이 프로그램 종료 메뉴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_tray_quit_Click(object sender, EventArgs e)
        {
            try
            {
                menuItem_Quit_Click(sender, e);
            }
            catch { }
        }

        /// <summary>
        /// 트레이 이프로그램은 메뉴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_tray_about_Click(object sender, EventArgs e)
        {
            try
            {
                menuItem_Help_Click(sender, e);
            }
            catch { }
        }

        /// <summary>
        /// 로그인 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (btn_Login.Text == "로그인")
            {
                if (this.Login())
                {
                    this.menuItem_Logout.Enabled = true;
                    this.menuItem_Login.Enabled = false;
                    this.btn_Login.Text = "로그아웃";
                    this.pictureBox.Image = this.treeviewImageList.Images[1];
                    MainWnd.MYID = this.txt_ID.Text;
                }
            }
            else
            {
                if (this.Logout())
                {
                    this.menuItem_Logout.Enabled = false;
                    this.menuItem_Login.Enabled = true;
                    this.btn_Login.Text = "로그인";
                }
            }
        }

        /// <summary>
        /// 회원 가입 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Register_Click(object sender, EventArgs e)
        {
            string ip = txt_IP.Text.Trim();
            if (ip == "")
            {
                MessageBox.Show("아이피 번호를 입력하세요!");
                return;
            }

            RegForm dlg = new RegForm(this, ip); // 회원 가입창 띄우기
            dlg.ShowDialog();
        }

        /// <summary>
        /// 내 상태 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Click(object sender, EventArgs e)
        {
            EventHandler eh = new EventHandler(ContextMenuClick);
            MenuItem[] item = { new MenuItem("온라인", eh),
     							new MenuItem("오프라인", eh),
 							    new MenuItem("전화 통화중", eh),
 							    new MenuItem("식사중", eh),
							    new MenuItem("다른 용무중", eh),
							    new MenuItem("자리 비움", eh),
								new MenuItem("곧 돌아오겠음", eh)
           };

            ContextMenu cm = new ContextMenu(item);
            cm.Show(this.pictureBox, new Point(this.pictureBox.Left + 10, this.pictureBox.Top - 10));
        }

        /// <summary>
        /// 내 상태 변환 팝업 메뉴
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        private void ContextMenuClick(object obj, EventArgs ea)
        {
            int index = 0;
            ClientStates mystate = ClientStates.online;
            switch (((MenuItem)obj).Text)
            {
                case "온라인":
                    index = 1;
                    mystate = ClientStates.online;
                    break;
                case "오프라인":
                    index = 2;
                    mystate = ClientStates.offline;
                    break;
                case "전화 통화중":
                    index = 3;
                    mystate = ClientStates.tel;
                    break;
                case "식사중":
                    index = 4;
                    mystate = ClientStates.meal;
                    break;
                case "다른 용무중":
                    index = 5;
                    mystate = ClientStates.etc;
                    break;
                case "자리 비움":
                    index = 6;
                    mystate = ClientStates.leave;
                    break;
                case "곧 돌아오겠음":
                    index = 7;
                    mystate = ClientStates.retun;
                    break;
            }
            this.pictureBox.Image = this.treeviewImageList.Images[index];
            this.MyStateInfoSend(mystate);
        }

        /// <summary>
        /// 화면 출력 문자형태(이름, 아이디, 별칭) 선택 팝업창
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_DisplayOption_Click(object sender, EventArgs e)
        {
            EventHandler eh = new EventHandler(DisplayOptionMenuClick);
            MenuItem[] item = {   new MenuItem("아이디로 표시", eh),
								   new MenuItem("이름으로 표시", eh),
								   new MenuItem("별칭으로 표시", eh)
							   };

            ContextMenu cm = new ContextMenu(item);
            cm.Show(this.lbl_DisplayOption, new Point(this.lbl_DisplayOption.Left + 10, this.lbl_DisplayOption.Top - 10));
        }

        /// <summary>
        /// 화면 출력 문자열 설정 이벤트
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        private void DisplayOptionMenuClick(object obj, EventArgs ea)
        {
            switch (((MenuItem)obj).Text)
            {
                case "아이디로 표시":
                    this.display_option = '0';
                    break;
                case "이름으로 표시":
                    this.display_option = '1';
                    break;
                case "별칭으로 표시":
                    this.display_option = '2';
                    break;
            }

            this.lbl_DisplayOption.Text = "디스플레이 옵션: " + ((MenuItem)obj).Text;

            this.TreeFriendRedraw();    // 트리뷰 다시 그리기( 출력되는 문자열 형태 바꿈 )
            
        }

        /// <summary>
        /// 트리뷰에서 친구를 선택한 후 더블클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tree_Friend_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TreeFriendDoublClick();
            }
            catch (Exception ex)
            {
                this.Add_MSG("트리뷰 더블클릭 에러 : " + ex.Message);
            }
        }


        private void TreeFriendDoublClick()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    add_msg d = new add_msg(TreeFriendDoublClick);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    int group_id = 0;
                    string sql = null;
                    string user_id = null;

                    // 현재 선택한 부모 인덱스 반환
                    int i = this.tree_Friend.SelectedNode.Parent.Index;
                    // 현재 선택한 노드의 인덱스 번호 반환
                    int j = this.tree_Friend.SelectedNode.Index;

                    string data = this.tree_Friend.Nodes[i].Nodes[j].Text;

                    string group_name = this.tree_Friend.Nodes[i].Text;

                    if (this.display_option == '0') // 출력된 문자열이 아이디일 경우
                    {
                        user_id = data;
                    }
                    else
                    {

                        DataRow[] row = this.tbl_Group.Select("group_name='" + group_name + "'");

                        if (row.Length > 0)
                        {
                            group_id = Convert.ToInt32(row[0]["group_id"].ToString().Trim());
                        }

                        if (this.display_option == '1')
                        {
                            sql = "name='" + data + "' and group_id=" + group_id;
                        }
                        else if (this.display_option == '2')
                        {
                            sql = "nickname='" + data + "' and group_id=" + group_id;
                        }

                        row = this.tbl_Friend.Select(sql);

                        if (row.Length > 0)
                        {
                            user_id = row[0]["id"].ToString().Trim();
                        }
                    }

                    this.SelectFriend(user_id); // 친구 선택
                }
            }
            catch { }
        }


        /// <summary>
        /// 트리뷰에서 마우스 다운
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tree_Friend_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                try
                {
                    TreeFriendMouseDown(e.X, e.Y);
                }
                catch (Exception ex)
                {
                    this.Add_MSG("트리뷰 팝업메뉴 에러 : " + ex.Message);
                }
            }
        }


        private void TreeFriendMouseDown(int x, int y)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    tree_friend d = new tree_friend(TreeFriendMouseDown);
                    this.Invoke(d, new object[] {x, y});
                }
                else
                {
                    int group_id = 0;
                    string sql = null;
                    string user_id = null;

                    // 현재 선택한 부모 인덱스 반환
                    int i = this.tree_Friend.SelectedNode.Parent.Index;
                    // 현재 선택한 노드의 인덱스 번호 반환
                    int j = this.tree_Friend.SelectedNode.Index;

                    string data = this.tree_Friend.Nodes[i].Nodes[j].Text;

                    string group_name = this.tree_Friend.Nodes[i].Text;

                    if (this.display_option == '0') // 출력된 문자열이 아이디일 경우
                    {
                        user_id = data;
                    }
                    else
                    {

                        DataRow[] row = this.tbl_Group.Select("group_name='" + group_name + "'");

                        if (row.Length > 0)
                        {
                            group_id = Convert.ToInt32(row[0]["group_id"].ToString().Trim());
                        }

                        if (this.display_option == '1')
                        {
                            sql = "name='" + data + "' and group_id=" + group_id;
                        }
                        else if (this.display_option == '2')
                        {
                            sql = "nickname='" + data + "' and group_id=" + group_id;
                        }

                        row = this.tbl_Friend.Select(sql);

                        if (row.Length > 0)
                        {
                            user_id = row[0]["id"].ToString().Trim();
                        }
                    }

                    DataRow[] temp = this.tbl_Friend.Select("id='" + user_id + "'");

                    this.strUserID = user_id;
                    this.strIP = temp[0]["ip"].ToString().Trim();
                    this.strEmail = temp[0]["email"].ToString().Trim();
                    this.strName = temp[0]["name"].ToString().Trim();
                    this.strNickName = temp[0]["nickname"].ToString().Trim();


                    /// 팝업 메뉴 띄우기

                    EventHandler eh = new EventHandler(TreeViewPopupMenuClick);
                    MenuItem[] item = {   new MenuItem("인스턴스 메신저", eh),
										   new MenuItem("메일 보내기", eh)										   
									   };

                    ContextMenu cm = new ContextMenu(item);
                    cm.Show(this.tree_Friend, new Point(x + 5, y + 5));
                }
            }
            catch { }
        }

        /// <summary>
        /// 트리뷰 팝업 메뉴 출력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>
        private void TreeViewPopupMenuClick(object sender, EventArgs ea)
        {
            switch (((MenuItem)sender).Text)
            {
                case "인스턴스 메신저":
                    this.tree_Friend_DoubleClick(sender, ea);
                    break;
                case "메일 보내기":
                    MailSendWnd dlg = new MailSendWnd(this.strName, this.strEmail);
                    dlg.ShowDialog();
                    break;
            }
        }

        private void MainWnd_FormClosing(object sender, FormClosingEventArgs e)
        {   // Client 폼 닫기 취소
            e.Cancel = true;
            //작업 표시줄에서 안보이게 만들기
            this.ShowInTaskbar = false;
            // 폼 숨기기
            this.Hide();		
        }


    }
}