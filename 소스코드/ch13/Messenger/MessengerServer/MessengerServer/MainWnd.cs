using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace MessengerServer
{

    delegate void add_msg();          // 디버깅 정보 출력 
    delegate void add_insert_member();
    delegate void add_insert_friend();
    delegate void add_insert_group();
    delegate void add_insert_connect();

    public partial class MainWnd : Form
    {
        #region  멤버 변수

        private Server server = null;

        // 추가 코드		
        public DataSet ds = null;   // 메모리 데이터베이스        		

        private SqlDataAdapter adapter_member = null;	 // 회원 관리 
        private SqlDataAdapter adapter_friend = null;    // 친구 목록 관리
        private SqlDataAdapter adapter_group = null;    // 그룹 이름 관리
        private SqlDataAdapter adapter_connect = null;   // 현재 접속한 사용자 관리

        private SqlConnection conn = null;
        private string dsn = null;                        // SQL 서버 연결 dsn문

        private string strAddMsg = null;                  // 디버깅 문자열

        // TBL_Member 테이블 관련
        private string strUserID = null;               // 회원 아이디 
        private string strPwd = null;               // 회원 비밀번호
        private string strName = null;               // 회원 이름
        private string strNickname = null;               // 회원 별칭
        private string strSsn = null;               // 회원 주민번호
        private string strTel = null;               // 회원 전화번호
        private string strEmail = null;               // 회원 전자우편
        private string strZipcode = null;               // 회원 우편번호
        private string strAddress = null;               // 회원 주소
        private string strIntro = null;               // 회원 자기소개

        // TBL_Friend/TBL_Group 테이블 관련
        private string strUser_id = null;
        private string strFriend_id = null;
        private string strGroup_id = null;
        private string strGroup_name = null;

        // TBL_Connect 테이블 관련
        private string strConn_UserID = null;
        private string strIP = null;
        private string strState = null;
        private string strEnterTime = null;
        
        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        public MainWnd()
        {
            InitializeComponent();
        }

        #endregion

        #region  리스트뷰 초기화 메서드

        private void InitListView_Member()
        {
            this.lst_Member.Clear();
            this.lst_Member.View = View.Details;
            this.lst_Member.LabelEdit = false;
            this.lst_Member.GridLines = true;
            this.lst_Member.FullRowSelect = true;

            this.lst_Member.Columns.Add("아이디", 70, HorizontalAlignment.Left);
            this.lst_Member.Columns.Add("비밀번호", 70, HorizontalAlignment.Left);
            this.lst_Member.Columns.Add("이 름", 70, HorizontalAlignment.Left);
            this.lst_Member.Columns.Add("별 칭", 100, HorizontalAlignment.Left);
            this.lst_Member.Columns.Add("주민번호", 70, HorizontalAlignment.Left);
            this.lst_Member.Columns.Add("전화번호", 70, HorizontalAlignment.Left);
            this.lst_Member.Columns.Add("전자우편", 100, HorizontalAlignment.Left);
            this.lst_Member.Columns.Add("우편번호", 60, HorizontalAlignment.Left);
            this.lst_Member.Columns.Add("주 소", 150, HorizontalAlignment.Left);
            this.lst_Member.Columns.Add("자기소개", 1500, HorizontalAlignment.Left);
        }

        private void InitListView_Friend()
        {
            this.lst_Friend.Clear();
            this.lst_Friend.View = View.Details;
            this.lst_Friend.LabelEdit = false;
            this.lst_Friend.GridLines = true;
            this.lst_Friend.FullRowSelect = true;

            this.lst_Friend.Columns.Add("사용자 아이디", 150, HorizontalAlignment.Left);
            this.lst_Friend.Columns.Add("친  구 아이디", 150, HorizontalAlignment.Left);
            this.lst_Friend.Columns.Add("그룹 아이디", 100, HorizontalAlignment.Left);
        }

        private void InitListView_Group()
        {
            this.lst_Group.Clear();
            this.lst_Group.View = View.Details;
            this.lst_Group.LabelEdit = false;
            this.lst_Group.GridLines = true;
            this.lst_Group.FullRowSelect = true;

            this.lst_Group.Columns.Add("그룹 아이디", 100, HorizontalAlignment.Left);
            this.lst_Group.Columns.Add("그룹 이름", 200, HorizontalAlignment.Left);
            this.lst_Group.Columns.Add("사용자 아이디", 150, HorizontalAlignment.Left);
        }

        private void InitListView_Connect()
        {
            this.lst_Connect.Clear();
            this.lst_Connect.View = View.Details;
            this.lst_Connect.LabelEdit = false;
            this.lst_Connect.GridLines = true;
            this.lst_Connect.FullRowSelect = true;
            this.lst_Connect.CheckBoxes = true;

            this.lst_Connect.Columns.Add("사용자 아이디", 150, HorizontalAlignment.Left);
            this.lst_Connect.Columns.Add("접속 아이피", 150, HorizontalAlignment.Left);
            this.lst_Connect.Columns.Add("현재 상태", 150, HorizontalAlignment.Left);
            this.lst_Connect.Columns.Add("접속 시간", 250, HorizontalAlignment.Left);
        }

        #endregion

        #region 인보크 함수들

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
        /// Member 정보 추가 
        /// </summary>
        /// <param name="user_id">아이디</param>
        /// <param name="pwd">비밀번호</param>
        /// <param name="name">이름</param>
        /// <param name="nickname">별칭</param>
        /// <param name="ssn">주민번호</param>
        /// <param name="tel">전화번호</param>
        /// <param name="email">전자메일</param>
        /// <param name="zipcode">우편번호</param>
        /// <param name="address">주소</param>
        /// <param name="intro">자기소개</param>
        public void Add_lstView_Member(string user_id, string pwd, string name, string nickname, string ssn, string tel, string email, string zipcode, string address, string intro)
        {
            this.strUserID = user_id;
            this.strPwd = pwd;
            this.strName = name;
            this.strNickname = nickname;
            this.strSsn = ssn;
            this.strTel = tel;
            this.strEmail = email;
            this.strZipcode = zipcode;
            this.strAddress = address;
            this.strIntro = intro;

            add_insert_member add = new add_insert_member(AddMember);
            this.Invoke(add);

        }

        /// <summary>
        ///  Member 추가 Invoke
        /// </summary>
        private void AddMember()
        {
            ListViewItem item = new ListViewItem(this.strUserID);
            item.SubItems.Add(this.strPwd);
            item.SubItems.Add(this.strName);
            item.SubItems.Add(this.strNickname);
            item.SubItems.Add(this.strSsn);
            item.SubItems.Add(this.strTel);
            item.SubItems.Add(this.strEmail);
            item.SubItems.Add(this.strZipcode);
            item.SubItems.Add(this.strAddress);
            item.SubItems.Add(this.strIntro);

            this.lst_Member.Items.Add(item);
        }


        /// <summary>
        /// Friend 정보 추가
        /// </summary>
        /// <param name="user_id">사용자 아이디</param>
        /// <param name="friend_id">친구 아이디</param>
        /// <param name="group_id">그룹 아이디 번호</param>
        public void Add_lstView_Friend(string user_id, string friend_id, string group_id)
        {
            this.strUser_id = user_id;
            this.strFriend_id = friend_id;
            this.strGroup_id = group_id;

            add_insert_friend add = new add_insert_friend(AddFriend);
            this.Invoke(add);

        }

        /// <summary>
        ///  Friend 추가 Invoke
        /// </summary>
        private void AddFriend()
        {
            ListViewItem item = new ListViewItem(this.strUser_id);
            item.SubItems.Add(this.strFriend_id);
            item.SubItems.Add(this.strGroup_id);

            this.lst_Friend.Items.Add(item);
        }


        /// <summary>
        /// Group 정보 추가
        /// </summary>
        /// <param name="group_id">그룹 아이디</param>
        /// <param name="group_name">그룹 이름</param>
        /// <param name="user_id">사용자 아이디</param>  
        public void Add_lstView_Group(string group_id, string group_name, string user_id)
        {
            this.strGroup_id = group_id;
            this.strGroup_name = group_name;
            this.strUser_id = user_id;

            add_insert_group add = new add_insert_group(AddGroup);
            this.Invoke(add);

        }

        /// <summary>
        ///  Group 추가 Invoke
        /// </summary>
        private void AddGroup()
        {
            ListViewItem item = new ListViewItem(this.strGroup_id);
            item.SubItems.Add(this.strGroup_name);
            item.SubItems.Add(this.strUser_id);

            this.lst_Group.Items.Add(item);
        }



        /// <summary>
        /// Connect 정보 추가
        /// </summary>
        /// <param name="user_id">사용자 아이디</param>
        /// <param name="ip">접속 아이피</param>
        /// <param name="state">현재 상태</param>
        /// <param name="entertime">접속 시간</param>
        public void Add_lstView_Connect(string user_id, string ip, string state, string entertime)
        {
            this.strConn_UserID = user_id;
            this.strIP = ip;
            this.strState = state;
            this.strEnterTime = entertime;

            add_insert_connect add = new add_insert_connect(AddConnect);
            this.Invoke(add);

        }

        /// <summary>
        ///  Connect 추가 Invoke
        /// </summary>
        private void AddConnect()
        {
            ListViewItem item = new ListViewItem(this.strConn_UserID);
            item.SubItems.Add(this.strIP);
            item.SubItems.Add(this.strState);
            item.SubItems.Add(this.strEnterTime);

            this.lst_Connect.Items.Add(item);
        }




        #endregion

        #region 리스트뷰 갱신

        /// <summary>
        /// lst_Member 갱신
        /// </summary>
        public bool ListViewMemberDataBind()
        {
            try
            {
                this.InitListView_Member();
                DataRow[] rows = this.ds.Tables["TBL_Member"].Select();

                foreach (DataRow row in rows)
                {
                    this.Add_lstView_Member(row["user_id"].ToString(), row["pwd"].ToString(), row["name"].ToString(),
                                            row["nickname"].ToString(), row["ssn"].ToString(), row["tel"].ToString(),
                                            row["tel"].ToString(), row["zipcode"].ToString(), row["address"].ToString(),
                                            row["intro"].ToString());
                }
            }
            catch 
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// lst_Friend 갱신
        /// </summary>
        public void ListViewFriendDataBind()
        {
            try
            {
                this.InitListView_Friend();
                DataRow[] rows = this.ds.Tables["TBL_Friend"].Select();

                foreach (DataRow row in rows)
                {
                    this.Add_lstView_Friend(row["user_id"].ToString(), row["friend_id"].ToString(),
                                            row["group_id"].ToString()
                        );
                }
            }
            catch { }
        }


        /// <summary>
        /// lst_Group 갱신
        /// </summary>
        public void ListViewGroupDataBind()
        {
            try
            {
                this.InitListView_Group();
                DataRow[] rows = this.ds.Tables["TBL_Group"].Select();

                foreach (DataRow row in rows)
                {
                    this.Add_lstView_Group(row["group_id"].ToString(), row["group_name"].ToString(),
                                            row["user_id"].ToString()
                        );
                }
            }
            catch { }
        }


        /// <summary>
        /// lst_Connect 갱신
        /// </summary>
        public void ListViewConnectDataBind()
        {
            try
            {
                this.InitListView_Connect();
                DataRow[] rows = this.ds.Tables["TBL_Connect"].Select();

                string state = null;

                foreach (DataRow row in rows)
                {

                    switch (Convert.ToInt32(row["state"].ToString()))
                    {
                        case (byte)ClientStates.etc:
                            state = "다른 용무중";
                            break;
                        case (byte)ClientStates.leave:
                            state = "자리 비움";
                            break;
                        case (byte)ClientStates.meal:
                            state = "식사중";
                            break;
                        case (byte)ClientStates.offline:
                            state = "오프라인";
                            break;
                        case (byte)ClientStates.online:
                            state = "온라인";
                            break;
                        case (byte)ClientStates.retun:
                            state = "곧 돌아오겠음";
                            break;
                        case (byte)ClientStates.tel:
                            state = "통화중";
                            break;
                    }

                    this.Add_lstView_Connect(row["user_id"].ToString(), row["ip"].ToString(),
                                             state, row["entertime"].ToString()
                        );
                }
            }
            catch { }
        }



        #endregion

        #region  멤버 메서드

        /// <summary>
        /// 접속한 특정 ip 컴퓨터에게 msg 문자열 전송
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ips"></param>
        public void BroadCast(string msg, string ips)
        {
            this.server.BroadCast(msg, ips);
        }

        /// <summary>
        /// 현재 접속한 친구들에게 내 상태 알림
        /// 1. 현재 TBL_Connect 테이블에 접속한 친구 알아냄
        /// 2. 친구들 아이피 목록 얻어오기
        /// </summary>
        /// <param name="user_id"> 사용자 아이디 </param>
        /// <returns></returns>
        public string ConnectMyFriendToNotify(string user_id)
        {
            try
            {
                string ips = "";
                DataRow[] rows1 = this.ds.Tables["TBL_Friend"].Select("user_id='" + user_id + "'");

                foreach (DataRow row in rows1)
                {
                    DataRow[] rows2 = this.ds.Tables["TBL_Connect"].Select("user_id='" + row["friend_id"].ToString() + "'");
                    if (rows2.Length > 0) // 로그인되어 있다면
                    {
                        ips += rows2[0]["ip"].ToString().Trim() + ";";
                    }
                }

                return ips;
            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// TBL_Group 테이블에서 사용자의 그룹 정보 전달
        /// 그룹이름@그룹아이디@그룹이름@그룹아이디...
        /// </summary>
        /// <param name="user_id">사용자 아이디</param>
        /// <returns></returns>
        public string MyGroupInfo(string user_id)
        {
            string msg = "";

            try
            {
                DataRow[] rows = this.ds.Tables["TBL_Group"].Select("user_id='" + user_id + "'");

                if (rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        msg += row["group_name"].ToString().Trim() + "@" + row["group_id"].ToString().Trim() + "@";
                    }

                    return msg;
                }
                else
                {
                    return "NOT_GROUPNAME";   // 검색된 그룹 이름이 하나도 없다면 
                }

            }
            catch (Exception ex)
            {
                this.Add_MSG("MyGroupInfo 메서드 에러 : " + ex.Message);
                return "NOT_GROUPNAME";   // 검색된 그룹 이름이 하나도 없다면 
            }
        }

        /// <summary>
        /// 친구 정보 
        /// </summary>
        /// <returns></returns>
        public string MyFriendInfo(string user_id)
        {
            string msg = "";

            try
            {
                DataRow[] rows = this.ds.Tables["TBL_Friend"].Select("user_id='" + user_id + "'");


                if (rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        DataRow[] mem = this.ds.Tables["TBL_Member"].Select("user_id='" + row["friend_id"].ToString().Trim() + "'");
                        DataRow[] conn = this.ds.Tables["TBL_Connect"].Select("user_id='" + row["friend_id"].ToString().Trim() + "'");

                        if (conn.Length > 0)
                        {
                            msg += row["group_id"].ToString().Trim() + "$" + conn[0]["state"].ToString().Trim() + "$";
                            msg += conn[0]["ip"].ToString().Trim() + "$" + row["friend_id"].ToString().Trim() + "$";
                            msg += mem[0]["name"].ToString().Trim() + "$" + mem[0]["nickname"].ToString().Trim() + "$";
                            msg += mem[0]["email"].ToString().Trim() + "$";
                        }
                        else
                        {
                            msg += row["group_id"].ToString().Trim() + "$" + (byte)ClientStates.offline + "$";
                            msg += "000.000.000.000" + "$" + row["friend_id"].ToString().Trim() + "$";
                            msg += mem[0]["name"].ToString().Trim() + "$" + mem[0]["nickname"].ToString().Trim() + "$";
                            msg += mem[0]["email"].ToString().Trim() + "$";
                        }


                    }

                    return msg;
                }
                else
                {
                    return "NOT_FRIEND";   // 검색된 그룹 이름이 하나도 없다면 
                }

            }
            catch (Exception ex)
            {
                this.Add_MSG("MyFriendInfo 메서드 에러 : " + ex.Message);
                return "NOT_FRIEND";   // 검색된 그룹 이름이 하나도 없다면 
            }
        }


        /// <summary>
        /// 회원 아이디와 비밀번호 체크
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="user_pwd"></param>
        /// <returns></returns>
        public bool MemberCheck(string user_id, string user_pwd)
        {
            DataRow[] row = ds.Tables["TBL_Member"].Select("user_id='" + user_id + "'");

            if ((row.Length > 0) && (row[0]["pwd"].ToString() == user_pwd))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        /// <summary>
        /// 회원 추가하기
        /// </summary>
        /// <param name="data"></param>
        public bool InsertMember(string data)
        {
            try
            {
                string[] token = data.Split('#');

                DataRow row = ds.Tables["TBL_Member"].NewRow();

                row["user_id"] = token[0];
                row["pwd"] = token[1];
                row["name"] = token[2];
                row["nickname"] = token[3];
                row["ssn"] = token[4];
                row["tel"] = token[5];
                row["email"] = token[6];
                row["zipcode"] = token[7];
                row["address"] = token[8];
                row["intro"] = token[9];

                ds.Tables["TBL_Member"].Rows.Add(row);

                //this.DataGridBound();

                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 아이디 사용 가능 조회
        /// </summary>
        /// <param name="user_id">조회할 아이디</param>
        /// <returns>아이디 사용 유무</returns>
        public bool SearchID(string user_id)
        {
            DataRow[] row = ds.Tables["TBL_Member"].Select("user_id='" + user_id + "'");
            if (row.Length > 0) // 아이디가 이미 있음
                return true;
            else                // 아이디가 없음 
                return false;
        }

        /// <summary>
        /// 우편번호 데이터 불러오기
        /// </summary>
        public string ZipcodeLoad(string addr)
        {
            string return_value = null; // 우편번호#주소@우편번호#주소...

            System.Xml.XmlTextReader xmlTextReader = null;

            try
            {
                if (this.dsn == "XML")  // XML 파일에서 값 검색하기
                {
                    int index = 0;

                    xmlTextReader = new System.Xml.XmlTextReader("ZipcodeData.xml");
                    System.Xml.XPath.XPathDocument doc = new System.Xml.XPath.XPathDocument(xmlTextReader);

                    System.Xml.XPath.XPathNavigator nav = doc.CreateNavigator();

                    nav.MoveToRoot();             // 루트 노드
                    nav.MoveToFirstChild();       // NewDataSet 노드
                    nav.MoveToFirstChild();       // Table 노드

                    do
                    {
                        nav.MoveToFirstChild();
                        do
                        {
                            for (index = 0; index < 4; index++)
                            {
                                nav.MoveToNext();        // addr3 주소로 이동
                            }

                            if (nav.Value.IndexOf(addr) != -1) // 주소 검색 결과가 있으면
                            {
                                for (index = 0; index < 3; index++) nav.MoveToPrevious();

                                return_value += nav.Value.Trim() + "#";  // 우편번호
                                nav.MoveToNext();
                                return_value += nav.Value.Trim() + " ";  // addr1
                                nav.MoveToNext();
                                return_value += nav.Value.Trim() + " ";  // addr2
                                nav.MoveToNext();
                                return_value += nav.Value.Trim() + " ";  // addr3
                                nav.MoveToNext();
                                if (nav.Value.Trim().Length > 0)           // no_start, no_end
                                {
                                    return_value += nav.Value.Trim() + "~";
                                    nav.MoveToNext();
                                    return_value += nav.Value.Trim() + " ";
                                    nav.MoveToNext();
                                }
                                else
                                {
                                    nav.MoveToNext();
                                    nav.MoveToNext();
                                }

                                if (nav.Value.Trim().Length > 0)           // addr4
                                {
                                    return_value += nav.Value.Trim();
                                }

                                return_value += "#";
                            }
                            else
                            {
                                for (index = 0; index < 3; index++) nav.MoveToNext();
                            }

                        } while (nav.MoveToNext());
                        nav.MoveToParent();
                    } while (nav.MoveToNext());
                }
                else                    // SQL에서 값 검색하기
                {
                    string sql = "select * from TBL_Zipcode where addr3 like '%" + addr + "%'";

                    SqlCommand cmd = new SqlCommand(sql, this.conn);
                    cmd.CommandType = CommandType.Text;
                    this.conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        return_value += reader["zipcode"].ToString() + "#";
                        return_value += reader["addr1"].ToString() + " " + reader["addr2"].ToString() + " ";
                        return_value += reader["addr3"].ToString() + " ";
                        if (reader["no_start"].ToString().Trim().Length > 0)
                            return_value += reader["no_start"].ToString() + "~" + reader["no_end"].ToString() + " ";
                        if (reader["addr4"].ToString().Trim().Length > 0)
                            return_value += reader["addr4"].ToString();
                        return_value += "#";
                    }

                    this.conn.Close();
                }

            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
            }
            finally
            {
                if (xmlTextReader != null)
                    xmlTextReader.Close();
            }


            return return_value;
        }


        /// <summary>
        /// SQL 데이터베이스 연결
        /// </summary>
        private void OpenSqlConnection()
        {
            try
            {
                dsn = "server=" + txt_IP.Text;
                dsn += ";uid=" + txt_ID.Text;
                dsn += ";pwd=" + txt_PWD.Text;
                dsn += ";database=" + txt_DBname.Text + ";";

                this.conn = new SqlConnection(dsn);


                this.adapter_member = new SqlDataAdapter();  // 회원 가입/관리
                this.adapter_friend = new SqlDataAdapter();  // 친구 관리
                this.adapter_group = new SqlDataAdapter();  // 그룹 관리
                this.adapter_connect = new SqlDataAdapter(); // 현재 접속한 회원 관리


                // 회원 가입/관리
                string select_member_sql = "select * from TBL_Member";
                string insert_member_sql = "insert into TBL_Member values(@user_id, @pwd, @name, @nickname, @ssn, @tel, @email, @zipcode, @address, @intro)";
                string update_member_sql = "update TBL_Member set pwd=@pwd, nickname=@nickname, tel=@tel, email=@email, zipcode=@zipcode, address=@address, intro=@intro where user_id=@user_id";
                string delete_member_sql = "delete from TBL_Member where user_id=@user_id";
                // 친구 관리
                string select_friend_sql = "select * from TBL_Friend";
                string insert_friend_sql = "insert into TBL_Friend values(@user_id, @friend_id, @group_id)";
                string update_friend_sql = "update TBL_Friend set group_id=@group_id where user_id=@user_id and friend_id=@friend_id";
                string delete_friend_sql = "delete from TBL_Friend where friend_id=@friend_id and user_id=@user_id";
                // 그룹 관리
                string select_group_sql = "select * from TBL_Group";
                string insert_group_sql = "insert into TBL_Group values(@group_id, @group_name, @user_id)";
                string update_group_sql = "update TBL_Group set group_name=@group_name where group_id=@group_id";
                string delete_group_sql = "delete from TBL_Group where group_id=@group_id AND user_id=@user_id";
                // 현재 접속한 회원 관리
                string select_connect_sql = "select * from TBL_Connect";
                string insert_connect_sql = "insert into TBL_Connect values(@user_id, @ip, @state, @entertime)";
                string update_connect_sql = "update TBL_Connect set state=@state where user_id=@user_id";
                string delete_connect_sql = "delete TBL_Connect where user_id=@user_id";


                /// TBL_Member 테이블 설정
                // SelectCommand 프로퍼티
                this.adapter_member.SelectCommand = new SqlCommand(select_member_sql, conn);
                // InsertCommand 프로퍼티
                this.adapter_member.InsertCommand = new SqlCommand(insert_member_sql, conn);
                this.adapter_member.InsertCommand.Parameters.Add("@user_id", SqlDbType.VarChar, 30, "user_id");
                this.adapter_member.InsertCommand.Parameters.Add("@pwd", SqlDbType.VarChar, 30, "pwd");
                this.adapter_member.InsertCommand.Parameters.Add("@name", SqlDbType.VarChar, 50, "name");
                this.adapter_member.InsertCommand.Parameters.Add("@nickname", SqlDbType.VarChar, 50, "nickname");
                this.adapter_member.InsertCommand.Parameters.Add("@ssn", SqlDbType.Char, 14, "ssn");
                this.adapter_member.InsertCommand.Parameters.Add("@tel", SqlDbType.Char, 15, "tel");
                this.adapter_member.InsertCommand.Parameters.Add("@email", SqlDbType.VarChar, 50, "email");
                this.adapter_member.InsertCommand.Parameters.Add("@zipcode", SqlDbType.Char, 7, "zipcode");
                this.adapter_member.InsertCommand.Parameters.Add("@address", SqlDbType.VarChar, 100, "address");
                this.adapter_member.InsertCommand.Parameters.Add("@intro", SqlDbType.Text, 0, "intro");
                // UpdateCommand 프로퍼티
                this.adapter_member.UpdateCommand = new SqlCommand(update_member_sql, conn);
                this.adapter_member.UpdateCommand.Parameters.Add("@pwd", SqlDbType.VarChar, 30, "pwd");
                this.adapter_member.UpdateCommand.Parameters.Add("@nickname", SqlDbType.VarChar, 50, "nickname");
                this.adapter_member.UpdateCommand.Parameters.Add("@tel", SqlDbType.Char, 15, "tel");
                this.adapter_member.UpdateCommand.Parameters.Add("@email", SqlDbType.VarChar, 50, "email");
                this.adapter_member.UpdateCommand.Parameters.Add("@zipcode", SqlDbType.Char, 7, "zipcode");
                this.adapter_member.UpdateCommand.Parameters.Add("@address", SqlDbType.VarChar, 100, "address");
                this.adapter_member.UpdateCommand.Parameters.Add("@intro", SqlDbType.Text, 0, "intro");
                SqlParameter param_member_update = this.adapter_member.UpdateCommand.Parameters.Add("@user_id", SqlDbType.VarChar, 30, "user_id");
                param_member_update.SourceVersion = DataRowVersion.Original;
                // Delete 프로퍼티
                this.adapter_member.DeleteCommand = new SqlCommand(delete_member_sql, conn);
                SqlParameter param_member_delete = adapter_member.DeleteCommand.Parameters.Add("@user_id", SqlDbType.VarChar, 30, "user_id");
                param_member_delete.SourceVersion = DataRowVersion.Original;


                /// TBL_Friend 테이블 설정
                // SelectCommand 프로퍼티
                this.adapter_friend.SelectCommand = new SqlCommand(select_friend_sql, conn);
                // InsertCommand 프로퍼티
                this.adapter_friend.InsertCommand = new SqlCommand(insert_friend_sql, conn);
                this.adapter_friend.InsertCommand.Parameters.Add("@user_id", SqlDbType.VarChar, 30, "user_id");
                this.adapter_friend.InsertCommand.Parameters.Add("@friend_id", SqlDbType.VarChar, 30, "friend_id");
                this.adapter_friend.InsertCommand.Parameters.Add("@group_id", SqlDbType.Int, 0, "group_id");
                // UpdateCommand 프로퍼티
                this.adapter_friend.UpdateCommand = new SqlCommand(update_friend_sql, conn);
                this.adapter_friend.UpdateCommand.Parameters.Add("@friend_id", SqlDbType.VarChar, 30, "friend_id");
                this.adapter_friend.UpdateCommand.Parameters.Add("@group_id", SqlDbType.Int, 0, "group_id");
                SqlParameter param_friend_update = this.adapter_friend.UpdateCommand.Parameters.Add("@user_id", SqlDbType.VarChar, 30, "user_id");
                param_friend_update.SourceVersion = DataRowVersion.Original;
                // Delete 프로퍼티
                this.adapter_friend.DeleteCommand = new SqlCommand(delete_friend_sql, conn);
                SqlParameter param_friend_delete = this.adapter_friend.DeleteCommand.Parameters.Add("@user_id", SqlDbType.VarChar, 30, "user_id");
                param_friend_delete.SourceVersion = DataRowVersion.Original;
                param_friend_delete = this.adapter_friend.DeleteCommand.Parameters.Add("@friend_id", SqlDbType.VarChar, 30, "friend_id");
                param_friend_delete.SourceVersion = DataRowVersion.Original;


                /// TBL_Group 테이블 설정
                // SelectCommand 프로퍼티
                this.adapter_group.SelectCommand = new SqlCommand(select_group_sql, conn);
                // InsertCommand 프로퍼티
                this.adapter_group.InsertCommand = new SqlCommand(insert_group_sql, conn);
                this.adapter_group.InsertCommand.Parameters.Add("@group_id", SqlDbType.Int, 0, "group_id");
                this.adapter_group.InsertCommand.Parameters.Add("@group_name", SqlDbType.VarChar, 60, "group_name");
                this.adapter_group.InsertCommand.Parameters.Add("@user_id", SqlDbType.VarChar, 30, "user_id");
                // UpdateCommand 프로퍼티
                this.adapter_group.UpdateCommand = new SqlCommand(update_group_sql, conn);
                this.adapter_group.UpdateCommand.Parameters.Add("@group_name", SqlDbType.VarChar, 60, "group_name");
                SqlParameter param_group_update = this.adapter_group.UpdateCommand.Parameters.Add("@group_id", SqlDbType.Int, 0, "group_id");
                param_group_update.SourceVersion = DataRowVersion.Original;
                // Delete 프로퍼티
                this.adapter_group.DeleteCommand = new SqlCommand(delete_group_sql, conn);
                this.adapter_group.DeleteCommand.Parameters.Add("@user_id", SqlDbType.VarChar, 30, "user_id");
                SqlParameter param_group_delete = this.adapter_group.DeleteCommand.Parameters.Add("@group_id", SqlDbType.Int, 0, "group_id");
                param_group_delete.SourceVersion = DataRowVersion.Original;

                /// TBL_Connect 테이블 설정
                // SelectCommand 프로퍼티
                this.adapter_connect.SelectCommand = new SqlCommand(select_connect_sql, conn);
                // InsertCommand 프로퍼티
                this.adapter_connect.InsertCommand = new SqlCommand(insert_connect_sql, conn);
                this.adapter_connect.InsertCommand.Parameters.Add("@user_id", SqlDbType.VarChar, 30, "user_id");
                this.adapter_connect.InsertCommand.Parameters.Add("@ip", SqlDbType.Char, 15, "ip");
                this.adapter_connect.InsertCommand.Parameters.Add("@state", SqlDbType.Char, 1, "state");
                this.adapter_connect.InsertCommand.Parameters.Add("@entertime", SqlDbType.DateTime, 0, "entertime");
                // UpdateCommand 프로퍼티
                this.adapter_connect.UpdateCommand = new SqlCommand(update_connect_sql, conn);
                this.adapter_connect.UpdateCommand.Parameters.Add("@state", SqlDbType.Char, 1, "state");
                SqlParameter param_connect_update = this.adapter_connect.UpdateCommand.Parameters.Add("@user_id", SqlDbType.VarChar, 30, "user_id");
                param_connect_update.SourceVersion = DataRowVersion.Original;
                // Delete 프로퍼티
                this.adapter_connect.DeleteCommand = new SqlCommand(delete_connect_sql, conn);
                SqlParameter param_connect_delete = this.adapter_group.DeleteCommand.Parameters.Add("@user_id", SqlDbType.VarChar, 30, "user_id");
                param_connect_delete.SourceVersion = DataRowVersion.Original;


                // 메모리 데이터베이스 활성화
                this.adapter_member.Fill(this.ds, "TBL_Member");
                this.adapter_friend.Fill(this.ds, "TBL_Friend");
                this.adapter_group.Fill(this.ds, "TBL_Group");
                this.adapter_connect.Fill(this.ds, "TBL_Connect");

            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// XML 파일에서 정보 읽기
        /// </summary>
        private bool ReadXMLData()
        {
            try
            {
                ds.ReadXmlSchema("MessengerSchema.xsd");

                ds.Tables["TBL_Member"].Rows.Clear();
                ds.Tables["TBL_Friend"].Rows.Clear();
                ds.Tables["TBL_Group"].Rows.Clear();
                ds.Tables["TBL_Connect"].Rows.Clear();

                ds.ReadXml("MessengerData.xml");

            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
                return false;   // XML 파일 읽기 실패
            }
            return true;        // XML 파일 읽기 성공
        }

        /// <summary>
        /// 회원 접속 기록 갱신
        /// </summary>
        /// <param name="user_id">사용자 아이디</param>
        /// <param name="ip">접속한 아이피 주소</param>
        /// <param name="state">사용자 현재 상태</param>
        /// <returns> 새로 로그인한 것인지/ 기존 로그인 정보가 있는 것인지 확인</returns>
        public bool ConnectMember(string user_id, string ip, char state)
        {
            bool return_value = false;

            try
            {
                // state : 0 오프라인, 1 온라인, 2, 자리비움, 3, 식사중, 4.통화중, 5 다른 용무중
                DataRow[] rows = ds.Tables["TBL_Connect"].Select("user_id='" + user_id + "'");
                if (rows.Length > 0)   // 접속 기록이 이미 있다면 -> 업데이트
                {
                    rows[0].BeginEdit();

                    rows[0]["user_id"] = user_id;
                    rows[0]["ip"] = ip;
                    rows[0]["state"] = state;
                    rows[0]["entertime"] = DateTime.Now.ToString();

                    rows[0].EndEdit();

                    return_value = true;     // 기존 로그인 정보 있음(재 로그인)
                }
                else                 // 접속 기록이 없다면 -> 정보 추가
                {
                    DataRow row = ds.Tables["TBL_Connect"].NewRow();

                    row["user_id"] = user_id.Trim();
                    row["ip"] = ip.Trim();
                    row["state"] = state;
                    row["entertime"] = DateTime.Now.ToString();

                    ds.Tables["TBL_Connect"].Rows.Add(row);

                    return_value = false;   // 새로 로그인 했음...
                }
            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
                return_value = false;
            }

            return return_value;

        }


        /// <summary>
        ///  회원 정보 수정
        /// </summary>
        private void EditMember()
        {
            int index = 0;

            foreach (ListViewItem item in this.lst_Member.SelectedItems)
            {
                index = this.lst_Member.Items.IndexOf(item);
            }

            EditMember dlg = new EditMember(this.ds, index, this.dsn);
            dlg.ShowDialog();

            this.ListViewMemberDataBind();

            this.Add_MSG("회원 정보를 성공적으로 수정했습니다.");
        }


        /// <summary>
        /// 현재 접속한 클라이언트 정보 갱신
        /// </summary>
        public void ConnectRefresh()
        {
            try
            {
                // 구현해야하는 기능
                // ClientGroup의 멤버 정보를 갱신
                // 갱신할 주요 대상은 현재 메모리데이터베이스 TBL_Connect와 연동시킴
                this.ds.Tables["TBL_Connect"].Rows.Clear();

                foreach (Client obj in this.server.ClientGroup.Member)
                {
                    if (obj != null)
                    {
                        DataRow row = this.ds.Tables["TBL_Connect"].NewRow();

                        row["user_id"] = obj.User_ID;
                        row["ip"] = obj.Client_IP;
                        row["state"] = (byte)obj.ClientState + "";
                        row["entertime"] = obj.ConnectTime;

                        this.ds.Tables["TBL_Connect"].Rows.Add(row);
                    }
                }

                this.ListViewConnectDataBind();

            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 친구 추가할때 친구 정보 검색
        /// </summary>
        /// <param name="user_id">검색할 친구 아이디</param>
        /// <returns></returns>
        public bool FriendSearch(string user_id)
        {
            try
            {
                DataRow[] rows = ds.Tables["TBL_Member"].Select("user_id='" + user_id + "'");
                if (rows.Length > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                this.Add_MSG("친구 검색 에러 :" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 친구 추가하기
        /// </summary>
        /// <param name="user_id">사용자 아이디</param>
        /// <param name="friend_id">친구 아이디</param>
        /// <param name="group_id">그룹 아이디</param>
        /// <returns>성공 유무</returns>
        public bool FriendAdd(string user_id, string friend_id, string group_id)
        {
            try
            {
                DataRow row = this.ds.Tables["TBL_Friend"].NewRow();
                row["user_id"] = user_id;
                row["friend_id"] = friend_id;
                row["group_id"] = Convert.ToInt32(group_id.Trim());
                this.ds.Tables["TBL_Friend"].Rows.Add(row);

                this.ListViewFriendDataBind();

                return true;

            }
            catch (Exception ex)
            {
                this.Add_MSG("사용자 친구 추가 에러 :" + ex.Message);
                return false;
            }

        }

        /// <summary>
        /// 친구 정보 변경하기
        /// </summary>
        /// <param name="user_id">사용자 아이디</param>
        /// <param name="friend_id">친구 아이디</param>
        /// <param name="group_id">그룹 아이디</param>
        /// <returns>성공 유무</returns>
        public bool FriendModify(string user_id, string friend_id, string group_id)
        {
            try
            {
                string sql = "user_id='" + user_id + "' And friend_id='" + friend_id + "'";

                DataRow[] rows = this.ds.Tables["TBL_Friend"].Select(sql); // 검색한 결과 

                DataTable user = this.ds.Tables["TBL_Friend"].Copy();

                if (rows.Length > 0)
                {
                    int i = 0;
                    for (i = 0; i < user.Rows.Count; i++)
                    {
                        if ((user.Rows[i]["user_id"] == rows[0]["user_id"]) && (user.Rows[i]["friend_id"] == rows[0]["friend_id"]))
                        {
                            break;
                        }
                    }

                    DataRow temp = this.ds.Tables["TBL_Friend"].Rows[i];
                    temp.BeginEdit();
                    temp["group_id"] = group_id;
                    temp.EndEdit();

                    this.ListViewFriendDataBind();

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                this.Add_MSG("사용자 친구 정보 변경 에러 :" + ex.Message);
                return false;
            }

        }

        /// <summary>
        /// 친구 정복 삭제하기
        /// </summary>
        /// <param name="user_id">사용자 아이디</param>
        /// <param name="friend_id">친구 아이디</param>
        /// <param name="group_id">그룹 아이디</param>
        /// <returns>성공 유무</returns>
        public bool FriendRemove(string user_id, string friend_id, string group_id)
        {
            try
            {
                DataRow[] rows = this.ds.Tables["TBL_Friend"].Select("user_id='" + user_id + "' and friend_id='" + friend_id + "' and group_id=" + group_id);
                rows[0].Delete();

                this.ListViewFriendDataBind();

                return true;
            }
            catch (Exception ex)
            {
                this.Add_MSG("사용자 친구 삭제 에러 :" + ex.Message);
                return false;
            }

        }


        /// <summary>
        /// 사용자 그룹 추가하기
        /// </summary>
        /// <param name="user_id">사용자 아이디</param>
        /// <param name="group_name">그룹 이름</param>
        /// /// <returns>성공 유무</returns>
        public bool GroupAdd(string user_id, string group_name)
        {
            try
            {
                DataRow[] rows = this.ds.Tables["TBL_Group"].Select("group_name='" + group_name + "' AND user_id='" + user_id + "'");

                if (rows.Length > 0) // 그룹 이름과 사용자 정보가 이미 있다면..
                {
                    return false;
                }
                else
                {
                    int index = this.ds.Tables["TBL_Group"].Rows.Count - 1;
                    string count = null;
                    if (index < 0)
                    {
                        count = "0";
                    }
                    else
                    {
                        count = this.ds.Tables["TBL_Group"].Rows[index]["group_id"].ToString().Trim();
                    }

                    DataRow row = this.ds.Tables["TBL_Group"].NewRow();
                    row["group_id"] = Convert.ToInt32(count) + 1;
                    row["group_name"] = group_name;
                    row["user_id"] = user_id;
                    this.ds.Tables["TBL_Group"].Rows.Add(row);

                    this.ListViewGroupDataBind();

                    return true;

                }

            }
            catch (Exception ex)
            {
                this.Add_MSG("사용자 그룹 추가 에러 :" + ex.Message);
                return false;
            }

        }

        /// <summary>
        /// 사용자 그룹 변경하기
        /// </summary>
        /// <param name="user_id">사용자 아이디</param>
        /// <param name="group_id">그룹 아이디</param>
        /// <param name="group_name">그룹 이름</param>
        /// /// <returns>성공 유무</returns>
        public bool GroupModify(string user_id, string group_id, string group_name)
        {
            try
            {
                string sql = "user_id='" + user_id + "' And group_id=" + group_id;

                DataRow[] rows = this.ds.Tables["TBL_Group"].Select(sql); // 검색한 결과 

                DataTable user = this.ds.Tables["TBL_Group"].Copy();

                if (rows.Length > 0)
                {
                    int i = 0;
                    for (i = 0; i < user.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(user.Rows[i]["group_id"].ToString().Trim()) == Convert.ToInt32(rows[0]["group_id"].ToString().Trim()))
                        {
                            break;
                        }
                    }

                    DataRow temp = this.ds.Tables["TBL_Group"].Rows[i];
                    temp.BeginEdit();
                    temp["group_name"] = group_name;
                    temp.EndEdit();

                    this.ListViewGroupDataBind();

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                this.Add_MSG("사용자 그룹 변경 에러 :" + ex.Message);
                return false;
            }

        }

        /// <summary>
        /// 사용자 그룹 삭제하기
        /// </summary>
        /// <param name="user_id">사용자 아이디</param>
        /// <param name="group_id">그룹 아이디</param>
        /// <param name="group_name">그룹 이름</param>
        /// /// <returns>성공 유무</returns>
        public bool GroupRemove(string user_id, string group_id, string group_name)
        {
            try
            {
                string sql = "user_id='" + user_id + "' And group_id=" + group_id + " And group_name='" + group_name + "'";

                DataRow[] rows = this.ds.Tables["TBL_Group"].Select(sql); // 검색한 결과 

                DataTable user = this.ds.Tables["TBL_Group"].Copy();

                if (rows.Length > 0)
                {
                    int i = 0;
                    for (i = 0; i < user.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(user.Rows[i]["group_id"].ToString().Trim()) == Convert.ToInt32(rows[0]["group_id"].ToString().Trim()))
                        {
                            break;
                        }
                    }

                    DataRow temp = this.ds.Tables["TBL_Group"].Rows[i];
                    temp.Delete();

                    this.ListViewGroupDataBind();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                this.Add_MSG("사용자 그룹 삭제 에러 :" + ex.Message);
                return false;
            }
        }


        #endregion

        #region 이벤트
        /// <summary>
        /// 메신저 서버 시작 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_Start.Text == "서버 시작")
                {
                    server = new Server(this, 7007);// 포트 번호 7007번 사용
                    server.ServerStart();            // 메신저 서버 시작                

                    this.ds = new DataSet();

                    if (!chk_XML.Checked)    // SQL 서버에서 값 읽어오기
                    {
                        this.OpenSqlConnection();
                    }
                    else                      // XML 파일에서 값 읽어오기
                    {
                        this.ReadXMLData();
                        this.btn_SqlReader.Enabled = false;
                        this.btn_SqlWriter.Enabled = false;
                        this.dsn = "XML";
                    }

                    // ListView 와 메모리 데이터베이스 연동
                    if(this.ListViewMemberDataBind())
                    {
                        this.Add_MSG("서버 시작되었음...");
                        btn_Start.BackColor = Color.Red;
                        btn_Start.Text = "서버 종료";
                    }

                    this.ListViewFriendDataBind();
                    this.ListViewGroupDataBind();
                    this.ListViewConnectDataBind();
                    
                }
                else // 메신저 서버 종료 ( 서버소켓 중지, 데이터 저장 )
                {    
                    if (!chk_XML.Checked)    // SQL 서버에 값 저장하기
                    {
                        this.adapter_member.Update(ds, "TBL_Member");
                        this.adapter_friend.Update(ds, "TBL_Friend");
                        this.adapter_group.Update(ds, "TBL_Group");
                        this.conn.Close();
                        this.Add_MSG("SQL 서버에 값 저장 완료...");
                    }
                    else                      // XML 파일에 값 저장하기
                    {
                        ds.WriteXmlSchema("MessengerSchema.xsd");
                        ds.WriteXml("MessengerData.xml");
                        this.Add_MSG("XML 파일에 값 저장 완료...");
                    }
                    this.Add_MSG("서버가 종료되었음...");

                    server.ServerStop();
                    btn_Start.Text = "서버 시작";
                    btn_Start.BackColor = this.BackColor;
                }
            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 친구/그룹관리 - 친구관리 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Friend_Click(object sender, EventArgs e)
        {
            FriendManager dlg = new FriendManager(this.ds);
            dlg.ShowDialog();

            this.ListViewFriendDataBind();
        }

        /// <summary>
        /// 친구/그룹관리 - 그룹관리 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Group_Click(object sender, EventArgs e)
        {
            GroupManager dlg = new GroupManager(this.ds);
            dlg.ShowDialog();

            this.ListViewGroupDataBind();
        }

        /// <summary>
        /// 회원 정보관리 - 리스트뷰 더블클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lst_Member_DoubleClick(object sender, EventArgs e)
        {
            this.EditMember();
        }

        /// <summary>
        /// 회원 정보관리 - SQL 정보 읽어오기 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SqlReader_Click(object sender, EventArgs e)
        {
            try
            {
                this.ds.Tables["TBL_Member"].Rows.Clear();
                this.ds.Tables["TBL_Friend"].Rows.Clear();
                this.ds.Tables["TBL_Group"].Rows.Clear();

                this.adapter_member.Fill(ds, "TBL_Member");
                this.adapter_friend.Fill(ds, "TBL_Friend");
                this.adapter_group.Fill(ds, "TBL_Group");

                this.ListViewMemberDataBind();
                this.ListViewFriendDataBind();
                this.ListViewGroupDataBind();

                this.Add_MSG("SQL서버에서 데이터를 성공적으로 읽어 왔습니다.");
            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 회원 정보관리 - SQL 정보 저장하기 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SqlWriter_Click(object sender, EventArgs e)
        {
            try
            {
                this.adapter_member.Update(ds, "TBL_Member");
                this.adapter_group.Update(ds, "TBL_Group");
                this.adapter_friend.Update(ds, "TBL_Friend");

                this.Add_MSG("SQL서버 데이터를 성공적으로 갱신했습니다.");
            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 회원 정보관리 - XML 정보 읽어오기 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_XMLReader_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ReadXMLData())
                {
                    this.ListViewMemberDataBind();
                    this.ListViewFriendDataBind();
                    this.ListViewGroupDataBind();

                    this.Add_MSG(" XML 파일에서 데이터를 성공적으로 읽어 왔습니다.");
                }
                else
                {
                    this.ds = null;  // XML 정보 읽기 실패
                }
            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 회원 정보관리 - XML에 정보 저장하기 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_XMLWriter_Click(object sender, EventArgs e)
        {
            try
            {
                ds.WriteXmlSchema("MessengerSchema.xsd");
                ds.WriteXml("MessengerData.xml");

                this.Add_MSG("데이터를 XML 파일 형태로 성공적으로 출력했습니다.");
            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 회원 정보관리 - 신규 회원 정보 입력하기 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_InsertMember_Click(object sender, EventArgs e)
        {
            InsertMember dlg = new InsertMember(this.ds, this.dsn);
            dlg.ShowDialog();

            this.ListViewMemberDataBind();

            this.Add_MSG("회원을 성공적으로 추가했습니다.");
        }

        /// <summary>
        /// 회원 정보관리 - 선택한 회원 정보 수정하기 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_EditMember_Click(object sender, EventArgs e)
        {
            this.EditMember();
        }

        /// <summary>
        /// 회원 정보관리 - 선택한 회원 정보 삭제하기 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DeleteMember_Click(object sender, EventArgs e)
        {
            try
            {
                int index = 0;

                foreach (ListViewItem item in this.lst_Member.SelectedItems)
                {
                    index = this.lst_Member.Items.IndexOf(item);
                }

                DataRow row = ds.Tables["TBL_Member"].Rows[index];

                string str = row["user_id"].ToString() + " 를 삭제 하시겠습니까?";

                if (MessageBox.Show(str, "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    row.Delete();
                    this.ListViewMemberDataBind();
                }

            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 현재 접속한 회원 - 접속자 리스트뷰 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lst_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                int index = 0;

                foreach (ListViewItem item in this.lst_Connect.SelectedItems)
                {
                    index = this.lst_Connect.Items.IndexOf(item);
                }

                DataRow row = ds.Tables["TBL_Connect"].Rows[index];

                DataRow[] rows = ds.Tables["TBL_Member"].Select("user_id='" + row["user_id"].ToString() + "'");

                string info = rows[0]["user_id"].ToString() + "님의 상세정보 \r\n";
                info += " 이름 :" + rows[0]["name"].ToString() + " 별칭 :" + rows[0]["nickname"].ToString();
                info += "\r\n 전화번호 :" + rows[0]["tel"].ToString() + " 메일주소 :" + rows[0]["email"].ToString();
                info += "\r\n 우편번호 :" + rows[0]["zipcode"].ToString() + " 주소 :" + rows[0]["address"].ToString();
                info += "\r\n 자기소개 :" + rows[0]["intro"].ToString();

                this.txt_SelectMemberInfo.Text = info;
            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 현재 접속한 회원 - 방송 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Broadcast_Click(object sender, EventArgs e)
        {
            // 지정한 클라이언트에게 메시지 전송
            // 방송 메시지는 POP 윈도우 창으로 메시지 전송
            try
            {
                if (this.txt_Broadcast_Title.Text.Length == 0 || this.txt_Broadcast_Content.Text.Length == 0)
                {
                    MessageBox.Show("공지 제목과 내용을 입력해 주세요!", "에러 발생");
                    return;
                }

                int index = 0;
                string ips = "";
                string msg = (byte)MSG.STOC_MESSAGE_BROADCAST + "\a";
                msg += this.txt_Broadcast_Title.Text.Trim() + "\a";
                msg += this.txt_Broadcast_Content.Text.Trim();

                foreach (ListViewItem item in lst_Connect.CheckedItems)
                {
                    index = this.lst_Connect.Items.IndexOf(item);
                    DataRow row = this.ds.Tables["TBL_Connect"].Rows[index];
                    ips += row["ip"].ToString().Trim() + ";";
                }

                if (ips.Length == 0)
                {
                    MessageBox.Show("메시지를 전송할 클라이언트를 선택해 주세요!", "에러메시지");
                    return;
                }

                this.server.ClientGroup.BroadCast(msg, ips);
                this.Add_MSG(ips + " 아이피 컴퓨터에 메시지를 전송했습니다");
            }
            catch (Exception ex)
            {
                this.Add_MSG("선택 방송 에러 :" + ex.Message);
            }

        }

        /// <summary>
        /// 현재 접속한 회원 - 전체 방송 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_BroadcastAll_Click(object sender, EventArgs e)
        {
            // 현재 로그인된 모든 클라이언트에게 방송 메시지 전송
            if (this.txt_Broadcast_Title.Text.Length == 0 || this.txt_Broadcast_Content.Text.Length == 0)
            {
                MessageBox.Show("공지 제목과 내용을 입력해 주세요!", "에러 발생");
                return;
            }

            if (this.lst_Connect.Items.Count == 0)
            {
                MessageBox.Show("메시지를 전송할 클라이언트가 하나도 없습니다.!", "에러 발생");
                return;
            }
            string msg = (byte)MSG.STOC_MESSAGE_BROADCAST + "\a";
            msg += this.txt_Broadcast_Title.Text.Trim() + "\a";
            msg += this.txt_Broadcast_Content.Text.Trim();

            this.server.BroadCast(msg);
            this.Add_MSG("모든 클라이언트 컴퓨터에 메시지를 전송했습니다");
        }

        /// <summary>
        /// 현재 접속한 회원 - 새로고침 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConnectRefresh_Click(object sender, EventArgs e)
        {
            this.ConnectRefresh();			
        }

        /// <summary>
        /// 현재 접속한 회원 - 연결 끊기 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DisConnect_Click(object sender, EventArgs e)
        {
            // 선택한 회원 강제 로그아웃처리
            // 1. ClientGroup 에서 제거 -> 클라이언트에게 강제종료 메시지 전송
            // 2. 메모리데이터베이스에서 제거
            try
            {
                int index = 0;

                foreach (ListViewItem item in lst_Connect.CheckedItems)
                {
                    index = this.lst_Connect.Items.IndexOf(item);
                    DataRow row = this.ds.Tables["TBL_Connect"].Rows[index];
                    this.server.ClientGroup.DeleteMember(row["user_id"].ToString().Trim());
                    row.Delete();

                    this.Add_MSG(row["user_id"].ToString() + " 사용자를 강제 로그아웃 시켰습니다.");
                }
            }
            catch (Exception ex)
            {
                this.Add_MSG("강제 로그아웃 처리 에러 :" + ex.Message);
            }

        }

        /// <summary>
        /// 현재 접속한 회원 - 모든 연결 끊기 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DisConnectAll_Click(object sender, EventArgs e)
        {
            // 모든 회원 로그아웃 처리
            // 1. CleintGroup 에서 제거 -> 클라이언트들에게 강제 종료 메시지 전송
            // 2. 메모리 데이터베이스에서 클라이언트 정보를 제거
            try
            {
                this.ds.Tables["TBL_Connect"].Rows.Clear();
                this.ListViewConnectDataBind();

                this.server.ClientGroup.DeleteAllMember();

                this.Add_MSG("현재 접속한 모든 사용자를 강제 로그아웃 시켰습니다.");
            }
            catch (Exception ex)
            {
                this.Add_MSG("모든 사용자 강제 로그아웃 처리 에러 :" + ex.Message);
            }
        }

        /// <summary>
        /// 현재 접속한 회원 - 접속 기록 저장 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConnectHistorySave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dsn == "XML")
                {
                    ds.WriteXmlSchema("MessengerSchema.xsd");
                    ds.WriteXml("MessengerData.xml");
                }
                else
                {
                    this.adapter_connect.Update(ds, "TBL_Connect");
                }

                this.Add_MSG("접속 기록을 업데이트 했습니다.");
            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
            }
        }

        private void MainWnd_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (btn_Start.Text == "서버 종료")
                {
                    server.ServerStop();
                    btn_Start.Text = "서버 시작";
                    btn_Start.BackColor = this.BackColor;
                    if (!chk_XML.Checked)    // SQL 서버에 값 저장하기
                    {
                        this.adapter_member.Update(ds, "TBL_Member");
                        this.adapter_friend.Update(ds, "TBL_Friend");
                        this.adapter_group.Update(ds, "TBL_Group");
                        this.conn.Close();
                    }
                    else                      // XML 파일에 값 저장하기
                    {
                        ds.WriteXmlSchema("MessengerSchema.xsd");
                        ds.WriteXml("MessengerData.xml");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion 

       
    }
}