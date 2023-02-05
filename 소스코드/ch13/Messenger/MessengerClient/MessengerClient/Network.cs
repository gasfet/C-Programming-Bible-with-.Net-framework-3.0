using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Collections;
using System.Data;

namespace MessengerClient
{
    /// <summary>
    /// 채팅 서버와 통신하는 NetWork 클래스	
    /// </summary>
    public class Network
    {
        #region 멤버 변수/생성자

        private MainWnd wnd = null;      // 로그인 창

        private Socket client = null;
        private Thread th = null;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="wnd">채팅 창</param>
        public Network(MainWnd wnd)
        {
            this.wnd = wnd;
        }

        #endregion

        #region 멤버 변수

        /// <summary>
        /// 메신저 서버와 연결 시도
        /// </summary>
        /// <param name="ip">연결할 서버 아이피</param>
        /// <returns>연결 유무</returns>
        public bool Connect(string ip)
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 7007);  // 채팅 메인 서버 접속
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                client.Connect(ipep);

                this.wnd.Add_MSG(ip + "서버에 접속 성공...");

                th = new Thread(new ThreadStart(Receive));
                th.Start();

                return true;
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
                return false;
            }
        }


        /// <summary>
        /// 메신저 서버 연결 종료...
        /// </summary>   
        public void DisConnect()
        {
            try
            {
                if (client != null)
                {
                    if (client.Connected)
                        client.Close();

                    if (th.IsAlive)
                        th.Abort();
                }

                this.wnd.Add_MSG("서버 연결 종료!");
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }


        /// <summary>
        /// 접속된 상대방 데이터 수신
        /// </summary>  
        public void Receive()
        {
            try
            {
                while (client != null && client.Connected)
                {
                    byte[] data = this.ReceiveData();
                    string msg = Encoding.Default.GetString(data);
                    string[] token = msg.Split('\a');

                    switch (Convert.ToByte(token[0].Trim()))
                    {
                        case (byte)MSG.STOC_MESSAGE_LOGIN_OK: // 아이디 중복조회 결과 사용가능
                            this.LoginOK(token[1].Trim());    // 로그인 처리							
                            //System.Windows.Forms.MessageBox.Show("로그인 성공!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_LOGIN_FAIL:  //아이디 중복조회 결과 사용불가
                            System.Windows.Forms.MessageBox.Show("아이디/비밀번호 틀림!");
                            this.DisConnect();
                            break;

                        case (byte)MSG.STOC_MESSAGE_BROADCAST:  // 서버 방송 메시지 수신
                            this.wnd.NotifyPopup(token[1].Trim(), token[2].Trim());
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_LOGIN:  // 친구 로그인 정보 수신
                            string title = token[1].Trim() + "님 로그인";
                            string content = "친구분이 " + DateTime.Now.ToShortTimeString() + "에 로그인 하셨습니다.!";
                            this.wnd.NotifyPopup(title, content);
                            this.UpdateData(token[1].Trim(), token[2].Trim()); // 친구정보 업데이트
                            this.wnd.Update_TreeFriend(token[1].Trim(), (byte)ClientStates.online); // 온라인으로 표시
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_LOGOUT: // 친구 로그아웃 정보 수신
                            this.wnd.Update_TreeFriend(token[1].Trim(), (byte)ClientStates.offline); // 온라인으로 표시                           
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_STATES: // 친구 접속 상태 변화
                            // 친구 아이디 : token[1]
                            // 친구 현재 상태 : token[2]
                            this.wnd.Update_TreeFriend(token[1].Trim(), Convert.ToByte(token[2].Trim()));
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_SEARCH_OK:// 사용자 검색 성공
                            this.wnd.FRIENDWND.FriendUserOK();
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_SEARCH_FAIL: // 사용자 검색 실패
                            this.wnd.FRIENDWND.FriendUserFail();
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_ADD_OK:      // 친구 추가 성공
                            this.wnd.TREE_FRIEND.Nodes.Clear();
                            this.wnd.TBL_FRIEND.Rows.Clear();
                            this.wnd.TBL_GROUP.Rows.Clear();
                            this.LoginOK(token[1].Trim());              // 친구 추가 성공
                            this.wnd.FRIENDWND.FriendWndMessage("친구 추가 성공!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_ADD_FAIL:     // 친구 추가 실패
                            this.wnd.FRIENDWND.FriendWndMessage("친구 추가 실패!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_MODIFY_OK:      // 친구 정보 변경 성공
                            this.wnd.TREE_FRIEND.Nodes.Clear();
                            this.wnd.TBL_FRIEND.Rows.Clear();
                            this.wnd.TBL_GROUP.Rows.Clear();
                            this.LoginOK(token[1].Trim());                 // 친구 정보 변경 성공
                            this.wnd.FRIENDWND.FriendWndMessage("친구 정보 변경 성공!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_MODIFY_FAIL:     // 친구 정보 변경 실패
                            this.wnd.FRIENDWND.FriendWndMessage("친구 정보 변경 실패!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_REMOVE_OK:      // 친구 정보 삭제 성공
                            this.wnd.TREE_FRIEND.Nodes.Clear();
                            this.wnd.TBL_FRIEND.Rows.Clear();
                            this.wnd.TBL_GROUP.Rows.Clear();
                            this.LoginOK(token[1].Trim());                 // 친구 정보 삭제 성공
                            this.wnd.FRIENDWND.FriendWndMessage("친구 정보 삭제 성공!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_REMOVE_FAIL:     // 친구 정보 삭제 실패
                            this.wnd.FRIENDWND.FriendWndMessage("친구 정보 삭제 실패!");
                            break;

                        /// 그룹 처리							
                        case (byte)MSG.STOC_MESSAGE_GROUP_ADD_OK:
                            this.wnd.TREE_FRIEND.Nodes.Clear();
                            this.wnd.TBL_FRIEND.Rows.Clear();
                            this.wnd.TBL_GROUP.Rows.Clear();
                            this.LoginOK(token[1].Trim());                 // 그룹 정보 추가 성공
                            this.wnd.GROUPWND.GroupWndMessage("그룹 정보 추가 성공!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_GROUP_ADD_FAIL:
                            this.wnd.GROUPWND.GroupWndMessage("그룹 정보 추가 실패!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_GROUP_MODIFY_OK:
                            this.wnd.TREE_FRIEND.Nodes.Clear();
                            this.wnd.TBL_FRIEND.Rows.Clear();
                            this.wnd.TBL_GROUP.Rows.Clear();
                            this.LoginOK(token[1].Trim());                 // 그룹 정보 변경 성공
                            this.wnd.GROUPWND.GroupWndMessage("그룹 정보 변경 성공!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_GROUP_MODIFY_FAIL:
                            this.wnd.GROUPWND.GroupWndMessage("친구 정보 변경 실패!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_GROUP_REMOVE_OK:
                            this.wnd.TREE_FRIEND.Nodes.Clear();
                            this.wnd.TBL_FRIEND.Rows.Clear();
                            this.wnd.TBL_GROUP.Rows.Clear();
                            this.LoginOK(token[1].Trim());                 // 그룹 정보 삭제 성공
                            this.wnd.GROUPWND.GroupWndMessage("그룹 정보 삭제 성공!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_GROUP_REMOVE_FAIL:
                            this.wnd.GROUPWND.GroupWndMessage("그룹 정보 삭제 실패!");
                            break;

                    }

                }
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }


        /// <summary>
        /// 사용자 아이피 갱신
        /// </summary>
        /// <param name="id">사용자 아이디</param>
        /// <param name="ip">사용자 아이피</param>
        private void UpdateData(string id, string ip)
        {
            try
            {
                DataRow[] rows = this.wnd.TBL_FRIEND.Select("id='" + id.Trim() + "'");
                if (rows.Length > 0)
                {
                    int i = 0;
                    for (i = 0; i < this.wnd.TBL_FRIEND.Rows.Count; i++)
                    {
                        if ((this.wnd.TBL_FRIEND.Rows[i]["id"] == rows[0]["id"]))
                        {
                            break;
                        }
                    }

                    DataRow temp = this.wnd.TBL_FRIEND.Rows[i];
                    temp.BeginEdit();
                    temp["ip"] = ip.Trim();
                    temp["state"] = (byte)ClientStates.online;
                    temp.EndEdit();
                }
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG("친구 아이피 주소 갱신 실패 : " + ex.Message);
            }
        }

        /// <summary>
        /// 접속한 상대방에 데이터 전송
        /// </summary>
        /// <param name="msg">전송할 문자열</param>
        public void Send(string msg)
        {
            try
            {
                if (client.Connected)
                {
                    byte[] data = Encoding.Default.GetBytes(msg);
                    this.SendData(data);
                }
                else
                {
                    this.wnd.Add_MSG("메시지 전송 실패!");
                }
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }


        /// <summary>
        /// 데이터 전송
        /// </summary>
        /// <param name="data">전송할 데이터</param>
        private void SendData(byte[] data)
        {
            try
            {
                int total = 0;
                int size = data.Length;
                int left_data = size;
                int send_data = 0;

                // 전송할 실제 데이터의 크기 전달
                byte[] data_size = new byte[4];
                data_size = BitConverter.GetBytes(size);
                send_data = this.client.Send(data_size);

                // 실제 데이터 전송
                while (total < size)
                {
                    send_data = this.client.Send(data, total, left_data, SocketFlags.None);
                    total += send_data;
                    left_data -= send_data;
                }
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }


        /// <summary>
        /// 데이터 수신
        /// </summary>		
        /// <returns>수신한 데이터 배열</returns>
        private byte[] ReceiveData()
        {
            try
            {
                int total = 0;
                int size = 0;
                int left_data = 0;
                int recv_data = 0;

                // 수신할 데이터 크기 알아내기   
                byte[] data_size = new byte[4];
                recv_data = this.client.Receive(data_size, 0, 4, SocketFlags.None);
                size = BitConverter.ToInt32(data_size, 0);
                left_data = size;

                byte[] data = new byte[size];
                // 서버에서 전송한 실제 데이터 수신
                while (total < size)
                {
                    recv_data = this.client.Receive(data, total, left_data, 0);
                    if (recv_data == 0) break;
                    total += recv_data;
                    left_data -= recv_data;
                }
                return data;
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 자신의 아이피 번호 알아내기
        /// </summary>
        /// <returns></returns>
        public string GetMyIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string myip = host.AddressList[0].ToString();
            return myip;
        }

        /// <summary>
        /// 로그인 성공했을 경우 처리할 내용
        /// 트리뷰 그리기
        /// </summary>
        /// <param name="msg">그룹이름 + # + 그룹 아이디, 사용자 아이디, 사용자 아이피, ...</param>
        private void LoginOK(string msg)
        {
            try
            {
                string[] token = msg.Split('#');

                /// 그룹 이름값 추출하기
                if (token[0].Trim() != "NOT_GROUPNAME")  // 그룹 이름이 있다면
                {
                    string[] group_name = token[0].Split('@');

                    for (int i = 0; i < group_name.Length - 1; i += 2)
                    {
                        DataRow row = this.wnd.TBL_GROUP.NewRow();
                        row["group_name"] = group_name[i];
                        row["group_id"] = Convert.ToInt32(group_name[i + 1].Trim());
                        this.wnd.TBL_GROUP.Rows.Add(row);
                    }

                }

                this.wnd.Add_treeGroupName();   // 친구 그룹 목록 출력하기

                this.wnd.Refresh_TreeFriend();  // 트리뷰 갱신하기

                /// 상세정보 추출하기
                if (token[1].Trim() != "NOT_FRIEND")  // 친구 정보가 있다면
                {
                    string[] temp = token[1].Split('$');  //그룹아이디+상태+아이피+아이디+이름+별칭+전자메일

                    for (int i = 0; i < temp.Length - 1; i += 7)
                    {
                        this.wnd.Add_treeFriend(temp[i], temp[i + 1], temp[i + 2], temp[i + 3], temp[i + 4], temp[i + 5], temp[i + 6]);

                        DataRow row = this.wnd.TBL_FRIEND.NewRow();
                        row["id"] = temp[i + 3];
                        row["name"] = temp[i + 4];
                        row["nickname"] = temp[i + 5];
                        row["email"] = temp[i + 6];
                        row["ip"] = temp[i + 2];
                        row["state"] = Convert.ToByte(temp[i + 1].Trim());
                        row["group_id"] = temp[i];
                        this.wnd.TBL_FRIEND.Rows.Add(row);

                    }
                }
                else   // 친구 정보가 없다면
                {
                    this.wnd.Add_treeFriend(null, null, null, null, null, null, null);
                }

            }

            catch (Exception ex)
            {
                this.wnd.Add_MSG("로그인 처리 에러 : " + ex.Message);
            }

        }

        #endregion

    }
}
