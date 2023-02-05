using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace MessengerServer
{

    // 클라이언트가 로그인된 전체 사용자에게 메시지 방송	
    public delegate void Send_Message(object sender);
    public delegate void Close_Message(object sender);

    /// <summary>
    /// 서버에 접속한 클라이언트 모듈
    /// </summary>
    public class Client
    {

        #region 멤버 변수

        public event Send_Message Send_All;
        public event Close_Message Close_MSG;
        public Msg_Queue msg_queue = null;

        private Socket client = null;
        private MainWnd wnd = null;
        /// <summary>
        /// 사용자 아이디
        /// </summary>
        private string user_id = null;
        /// <summary>
        /// 사용자 아이피
        /// </summary>
        private string client_ip = null;
        /// <summary>
        /// 접속 시간
        /// </summary>
        private DateTime connecttime;

        private Thread th = null;

        /// <summary>
        /// 클라이언트 접속 상태
        /// </summary>
        private byte clientstate;

        #endregion


        #region 멤버 속성

        /// <summary>
        /// 클라이언트 접속 유무 확인
        /// </summary>
        public bool Connect
        {
            get
            {
                return this.client.Connected;
            }
        }

        /// <summary>
        /// 클라이언트 아이피
        /// </summary>
        public string Client_IP
        {
            get
            {
                return this.client_ip;
            }
        }

        /// <summary>
        /// 사용자 아이디
        /// </summary>
        public string User_ID
        {
            get
            {
                return this.user_id;
            }
        }

        /// <summary>
        /// 접속 시간
        /// </summary>
        public DateTime ConnectTime
        {
            get
            {
                return this.connecttime;
            }
        }

        /// <summary>
        /// 클라이언트 상태
        /// </summary>
        public byte ClientState
        {
            set
            {
                this.clientstate = value;
            }
            get
            {
                return this.clientstate;
            }
        }

        #endregion


        #region 멤버 생성자/소멸자

        /// <summary>
        /// 클라이언트 생성자
        /// </summary>
        /// <param name="wnd">디버깅 정보 표시</param>
        /// <param name="client">소켓</param>
        /// <param name="user_id">사용자 아이디</param>
        public Client(MainWnd wnd, Socket client, string user_id)
        {
            this.client = client;
            this.wnd = wnd;
            this.user_id = user_id;

            IPEndPoint ip = (IPEndPoint)this.client.RemoteEndPoint;
            this.client_ip = ip.Address.ToString();

            this.connecttime = DateTime.Now;

            this.clientstate = (byte)ClientStates.online;   // 처음 접속하면 온라인 상태

            try
            {
                th = new Thread(new ThreadStart(Receive));
                th.IsBackground = true;
                th.Start();
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 클라이언트 접속 종료
        /// </summary>
        public void Dispose()
        {
            try
            {
                this.client.Close();

                if (this.th.IsAlive)
                    th.Abort();
            }
            catch
            {
            }
        }

        #endregion


        #region 멤버 메서드

        /// <summary>
        /// 클라이언트 메시지 수신
        /// </summary>
        public void Receive()
        {
            string message = null;
            string ips = null;

            try
            {
                while (client != null && client.Connected)
                {
                    byte[] data = this.ReceiveData();
                    string msg = Encoding.Default.GetString(data);
                    if (msg != null)
                    {
                        string[] token = msg.Split('\a');
                        switch (Convert.ToByte(token[0].Trim()))
                        {
                            case (byte)MSG.CTOS_MESSAGE_LOGOUT_REQUEST:  // 로그 아웃 요청
                                this.msg_queue.Enqueue(token[1].Trim());
                                try
                                {
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_LOGOUT + "\a" + this.user_id.ToString(); // 친구들에게 로그아웃 알림
                                    ips = this.wnd.ConnectMyFriendToNotify(this.user_id.Trim());  // 로그인된 친구 ip 목록 가져오기
                                    this.wnd.BroadCast(message, ips);// 친구들에게 로그아웃 정보 전송

                                    Close_MSG(this);                  // 서버 연결 차단
                                }
                                finally
                                {
                                    this.wnd.ConnectRefresh();
                                    this.wnd.Add_MSG(token[1] + "님이 로그아웃했습니다.");
                                }

                                break;

                            case (byte)MSG.CTOS_MESSAGE_MY_STATES:      // 내 상태 변경 
                                this.clientstate = Convert.ToByte(token[1].Trim());
                                this.wnd.ConnectRefresh();

                                message = (byte)MSG.STOC_MESSAGE_FRIEND_STATES + "\a";
                                message += this.user_id.ToString() + "\a" + (byte)this.clientstate; // 친구 로그인 알림 메시지 
                                ips = this.wnd.ConnectMyFriendToNotify(this.user_id.Trim());  // 로그인된 친구 ip 목록 가져오기

                                this.wnd.BroadCast(message, ips);// 친구들에게 내 정보 전송
                                break;

                            ///// 친구 관리 기능
                            case (byte)MSG.CTOS_MESSAGE_FRIEND_SEARCH:	  // 친구 아이디 검색(친구 추가용)						   
                                if (this.wnd.FriendSearch(token[1].Trim()))
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_SEARCH_OK + "\a";// 검색 성공
                                else
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_SEARCH_FAIL + "\a";// 검색 실패
                                this.Send(message);
                                break;

                            case (byte)MSG.CTOS_MESSAGE_FRIEND_ADD:  // 친구 추가하기
                                if (this.wnd.FriendAdd(token[1].Trim(), token[2].Trim(), token[3].Trim()))
                                {
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_ADD_OK + "\a";// 친구 추가 성공
                                    message += this.wnd.MyGroupInfo(this.User_ID.Trim()) + "#";
                                    message += this.wnd.MyFriendInfo(this.User_ID.Trim());
                                }
                                else
                                {
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_ADD_FAIL + "\a";// 친구 추가 실패
                                }
                                this.Send(message);
                                break;

                            case (byte)MSG.CTOS_MESSAGE_FRIEND_MODIFY:  // 친구 정보 변경하기
                                if (this.wnd.FriendModify(token[1].Trim(), token[2].Trim(), token[3].Trim()))
                                {
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_MODIFY_OK + "\a";// 친구 정보 변경 성공
                                    message += this.wnd.MyGroupInfo(this.User_ID.Trim()) + "#";
                                    message += this.wnd.MyFriendInfo(this.User_ID.Trim());
                                }
                                else
                                {
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_MODIFY_FAIL + "\a";// 친구 정보 변경 실패
                                }
                                this.Send(message);
                                break;

                            case (byte)MSG.CTOS_MESSAGE_FRIEND_REMOVE:  // 친구 정보 삭제하기
                                if (this.wnd.FriendRemove(token[1].Trim(), token[2].Trim(), token[3].Trim()))
                                {
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_REMOVE_OK + "\a";// 친구 정보 삭제 성공
                                    message += this.wnd.MyGroupInfo(this.User_ID.Trim()) + "#";
                                    message += this.wnd.MyFriendInfo(this.User_ID.Trim());
                                }
                                else
                                {
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_REMOVE_FAIL + "\a";// 친구 정보 삭제 실패
                                }
                                this.Send(message);
                                break;

                            /// 그룹 설정							   
                            case (byte)MSG.CTOS_MESSAGE_GROUP_ADD:    // 사용자 그룹 추가하기
                                if (this.wnd.GroupAdd(token[1].Trim(), token[2].Trim())) // 사용자 아이디, 그룹이름
                                {
                                    message = (byte)MSG.STOC_MESSAGE_GROUP_ADD_OK + "\a";// 그룹 정보 삭제 성공
                                    message += this.wnd.MyGroupInfo(this.User_ID.Trim()) + "#";
                                    message += this.wnd.MyFriendInfo(this.User_ID.Trim());
                                }
                                else
                                {
                                    message = (byte)MSG.STOC_MESSAGE_GROUP_ADD_FAIL + "\a";// 그룹 정보 삭제 실패
                                }
                                this.Send(message);
                                break;

                            case (byte)MSG.CTOS_MESSAGE_GROUP_MODIFY:    // 사용자 그룹 정보 변경하기
                                if (this.wnd.GroupModify(token[1].Trim(), token[2].Trim(), token[3].Trim())) // 사용자 아이디, 그룹아이디, 그룹이름
                                {
                                    message = (byte)MSG.STOC_MESSAGE_GROUP_MODIFY_OK + "\a";// 그룹 정보 삭제 성공
                                    message += this.wnd.MyGroupInfo(this.User_ID.Trim()) + "#";
                                    message += this.wnd.MyFriendInfo(this.User_ID.Trim());
                                }
                                else
                                {
                                    message = (byte)MSG.STOC_MESSAGE_GROUP_MODIFY_FAIL + "\a";// 그룹 정보 삭제 실패
                                }
                                this.Send(message);
                                break;

                            case (byte)MSG.CTOS_MESSAGE_GROUP_REMOVE:    // 사용자 그룹 정보 삭제하기
                                if (this.wnd.GroupRemove(token[1].Trim(), token[2].Trim(), token[3].Trim())) // 사용자 아이디, 그룹아이디, 그룹이름
                                {
                                    message = (byte)MSG.STOC_MESSAGE_GROUP_REMOVE_OK + "\a";// 그룹 정보 삭제 성공
                                    message += this.wnd.MyGroupInfo(this.User_ID.Trim()) + "#";
                                    message += this.wnd.MyFriendInfo(this.User_ID.Trim());
                                }
                                else
                                {
                                    message = (byte)MSG.STOC_MESSAGE_GROUP_REMOVE_FAIL + "\a";// 그룹 정보 삭제 실패
                                }
                                this.Send(message);
                                break;

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
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

        #endregion
    }
}
