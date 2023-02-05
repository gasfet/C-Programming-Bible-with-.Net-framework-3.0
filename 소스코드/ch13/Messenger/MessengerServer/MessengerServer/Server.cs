
using System;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;

using System.Text;

namespace MessengerServer
{
    /// <summary>
    /// Server에 대한 요약 설명입니다.
    /// </summary>

    class Server
    {

        #region 멤버 변수/속성

        private MainWnd wnd = null;
        private int port = 7007;

        private Socket server = null;
        private Thread th = null;

        private ClientGroup cgroup = null;

        public ClientGroup ClientGroup
        {
            get
            {
                return cgroup;
            }
        }

        #endregion

        #region 생성자

        /// <summary>
        /// 메신저 서버 생성자
        /// </summary>
        /// <param name="wnd"></param>
        /// <param name="port"></param> 
        public Server(MainWnd wnd, int port)
        {
            this.wnd = wnd;
            this.port = port;
        }

        #endregion

        #region 멤버 메서드

        /// <summary>
        /// 메신저 서버 시작
        /// </summary>
        public void ServerStart()
        {
            try
            {
                cgroup = new ClientGroup(); // 클라이언트 그룹 생성자 호출

                th = new Thread(new ThreadStart(AcceptClient));
                th.IsBackground = true;
                th.Start();
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 메신저 서버 종료
        /// </summary>
        public void ServerStop()
        {
            try
            {
                cgroup.Dispose(); // 클라이언트 그룹 소멸자 호출

                if (th.IsAlive)
                {
                    th.Abort();
                }
                server.Close();
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }


        /// <summary>
        /// 메신저 클라이언트 접속 처리
        /// </summary>
        public void AcceptClient()
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, this.port);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(ipep);
                server.Listen(20);

                while (true)
                {
                    Socket client = server.Accept();
                    IPEndPoint ip = (IPEndPoint)client.RemoteEndPoint;
                    this.wnd.Add_MSG(ip.Address + "접속...");

                    if (client.Connected)
                    {
                        this.ClientConnect(client);  // 접속처리 (1, 로그인, 2. 회원가입)
                    }

                }

            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 메시지 방송
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns> 
        public bool BroadCast(string msg)
        {
            return cgroup.BroadCast(msg);
        }

        /// <summary>
        /// 메시지 방송
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ips"></param>
        /// <returns></returns>
        public bool BroadCast(string msg, string ips)
        {
            return cgroup.BroadCast(msg, ips);
        }

        /// <summary>
        /// 클라이언트 그룹에서 특정 아이피 클라이언트 제거
        /// </summary>
        /// <param name="ip"></param>
        public void DeleteClient(string ip)
        {
            cgroup.DeleteMember(ip);
        }

        /// <summary>
        /// 데이터 전송
        /// </summary>
        /// <param name="data">전송할 데이터</param>
        private void SendData(byte[] data, Socket client)
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
                send_data = client.Send(data_size);

                // 실제 데이터 전송
                while (total < size)
                {
                    send_data = client.Send(data, total, left_data, SocketFlags.None);
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
        private byte[] ReceiveData(Socket client)
        {
            try
            {
                int total = 0;
                int size = 0;
                int left_data = 0;
                int recv_data = 0;

                // 수신할 데이터 크기 알아내기   
                byte[] data_size = new byte[4];
                recv_data = client.Receive(data_size, 0, 4, SocketFlags.None);
                size = BitConverter.ToInt32(data_size, 0);
                left_data = size;

                byte[] data = new byte[size];
                // 서버에서 전송한 실제 데이터 수신
                while (total < size)
                {
                    recv_data = client.Receive(data, total, left_data, SocketFlags.None);
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
        /// 로그인 처리 함수
        /// </summary>
        /// <param name="user_id">사용자 아이디</param>
        /// <param name="user_pwd">사용자 비밀번호</param>
        /// <returns>로그인 성공유무</returns>
        private bool LoginProcess(string user_id, string user_pwd)
        {
            return this.wnd.MemberCheck(user_id, user_pwd);
        }


        /// <summary>
        /// 회원 가입
        /// </summary>
        /// <param name="member_info">회원가입정보</param>
        private bool RegisterMember(string member_info)
        {
            return this.wnd.InsertMember(member_info);
        }

        /// <summary>
        /// 사용자 아이디 조회
        /// </summary>
        /// <param name="user_id">아이디 조회</param>
        private bool SearchID(string user_id)
        {
            return this.wnd.SearchID(user_id.Trim());
        }

        /// <summary>
        /// 우편번호 결과 반환
        /// </summary>
        /// <param name="addr">조회할 주소(동이름)</param>
        /// <param name="client">접속 소켓</param>
        private void ZipcodeInfo(string addr, Socket client)
        {
            string msg = null;

            msg += this.wnd.ZipcodeLoad(addr);

            if (msg != "") // 검색한 우편주소 있을 경우
                msg = (byte)MSG.STOC_MESSAGE_REGISTER_ZIPCODEDATA + "\a" + msg;
            else           // 검색한 우편주소 없을 경우
                msg = (byte)MSG.STOC_MESSAGE_REGISTER_ZIPCODERR + "\a";

            byte[] data = Encoding.Default.GetBytes(msg);
            this.SendData(data, client); // 우편번호 결과 반환
        }

        /// <summary>
        /// 클라이언트 접속 처리
        /// 1. 로그인 처리
        /// 2. 회원 가입 처리
        /// </summary>
        /// <param name="client"></param>
        private void ClientConnect(Socket client)
        {
            byte[] data = this.ReceiveData(client);
            string msg = Encoding.Default.GetString(data);

            string[] token = msg.Split('\a');   // 클라이언트가 보낸 데이터 분석

            switch (Convert.ToByte(token[0].Trim()))
            {
                ///로그인 처리
                case (byte)MSG.CTOS_MESSAGE_LOGIN_REQUEST: // 메시지+아이디+비밀번호					
                    if (LoginProcess(token[1].Trim(), token[2].Trim()))   // 로그인 처리(token[1]-아이디,token[2]-비밀번호
                    {
                        Client obj = new Client(this.wnd, client, token[1].Trim()); // 클라이언트 그룹에 추가

                        IPEndPoint ip = (IPEndPoint)client.RemoteEndPoint;
                        if (this.wnd.ConnectMember(token[1].Trim(), ip.Address.ToString(), '0'))  // 클라이언트 접속 로그 갱신
                        {
                            // 기존 로그인 정보가 있을 경우 -> 기존 연결 없얘고 추가
                            cgroup.DeleteMember(token[1].Trim());
                        }

                        cgroup.AddMember(obj);  // 멤버 추가						

                        string message = this.wnd.MyGroupInfo(token[1].Trim()) + "#" + this.wnd.MyFriendInfo(token[1].Trim());

                        message = ((byte)MSG.STOC_MESSAGE_LOGIN_OK).ToString() + "\a" + message;

                        data = Encoding.Default.GetBytes(message); // 로그인 성공 메시지 전송	

                        message = (byte)MSG.STOC_MESSAGE_FRIEND_LOGIN + "\a" + token[1].ToString(); // 친구 로그인 알림 메시지 
                        message += "\a" + ip.Address.ToString();

                        string ips = this.wnd.ConnectMyFriendToNotify(token[1].Trim());  // 로그인된 친구 ip 목록 가져오기

                        this.cgroup.BroadCast(message, ips);  // 친구들에게 로그인 사실 알림

                        this.wnd.Add_MSG(token[1].Trim() + "님이 로그인 했습니다.");

                        this.wnd.ListViewConnectDataBind();   // 현재 접속 정보 수정
                    }
                    else                                                            // 로그인 실패
                    {
                        data = Encoding.Default.GetBytes(((byte)MSG.STOC_MESSAGE_LOGIN_FAIL).ToString() + "\a");
                    }
                    this.SendData(data, client);

                    break;


                /// 회원 가입 처리
                case (byte)MSG.CTOS_MESSAGE_REGISTER_REQUEST:   // 회원 가입 처리 + 회원가입정보
                    if (RegisterMember(token[1].Trim())) // 회원 가입 성공
                    {
                        data = Encoding.Default.GetBytes(((byte)MSG.STOC_MESSAGE_REGISTER_OK).ToString() + "\a");

                        this.wnd.ListViewMemberDataBind();  // 회원 정보 수정
                    }
                    else                               // 회원 가입 실패
                    {
                        data = Encoding.Default.GetBytes(((byte)MSG.STOC_MESSAGE_REGISTER_FAIL).ToString() + "\a");
                    }
                    this.SendData(data, client);
                    break;

                /// 회원 아이디 등록 조회
                case (byte)MSG.CTOS_MESSAGE_REGISTER_IDSEARCH:  // 아이디 사용 조회 + 아이디
                    if (!SearchID(token[1].Trim()))      // 아이디 사용 가능
                    {
                        data = Encoding.Default.GetBytes(((byte)MSG.STOC_MESSAGE_REGISTER_IDYES).ToString() + "\a");
                    }
                    else                                // 아이디 사용 불가
                    {
                        data = Encoding.Default.GetBytes(((byte)MSG.STOC_MESSAGE_REGISTER_IDNO).ToString() + "\a");
                    }
                    this.SendData(data, client);
                    break;

                /// 우편번호 조회
                case (byte)MSG.CTOS_MESSAGE_REGISTER_ZIPCODE:   // 우편번호 조회 + 조회할 문자열(동이름)
                    ZipcodeInfo(token[1].Trim(), client);       // 우편번호 결과 전송
                    break;
            }

        }

        #endregion

    }
}
