using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Collections;


namespace MessengerClient
{
    /// <summary>
    /// ChatServer : 채팅 서버
    /// </summary>
    public class ChatServer
    {
        #region 멤버 변수/생성자

        private MainWnd wnd = null;
        private Socket server = null;
        private Thread th = null;

        /// <summary>
        /// 채팅 서버 포트
        /// </summary>
        private int port = 2500;

        /// <summary>
        /// ChatServer 생성자 1
        /// </summary>
        /// <param name="wnd">채팅 클라이언트 메인 폼</param>
        public ChatServer(MainWnd wnd)
        {
            this.wnd = wnd;
        }

        /// <summary>
        /// ChatServer 생성자 2
        /// </summary>
        /// <param name="wnd">채팅 클라이언트 메인 폼</param>
        /// <param name="port">채팅서버 포트 번호 설정</param>
        public ChatServer(MainWnd wnd, int port)
        {
            this.wnd = wnd;
            this.port = port;
        }

        #endregion


        #region 멤버 메서드

        /// <summary>
        /// 채팅 서버 시작
        /// </summary>
        public void ServerStart()
        {
            try
            {
                this.th = new Thread(new ThreadStart(AcceptClient));
                this.th.Start();
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG("채팅 서버 접속 에러:" + ex.Message);
            }
        }

        /// <summary>
        /// 채팅 서버 종료
        /// </summary>
        public void ServerStop()
        {
            try
            {
                if (this.th.IsAlive)
                {
                    this.th.Abort();
                }
                this.server.Close();
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }


        /// <summary>
        /// 채팅 클라이언트 접속 처리
        /// </summary>
        public void AcceptClient()
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, this.port);
                this.server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.server.Bind(ipep);
                this.server.Listen(20);

                while (true)
                {
                    Socket client = this.server.Accept();
                    IPEndPoint ip = (IPEndPoint)client.RemoteEndPoint;
                    this.wnd.Add_MSG(ip.Address + " 채팅 클라이언트 접속...");

                    if (client.Connected)
                    {
                        byte[] data_size = new byte[4];
                        client.Receive(data_size, 0, 4, SocketFlags.None);
                        int size = BitConverter.ToInt32(data_size, 0);
                        byte[] data = new byte[size];
                        client.Receive(data, 0, size, SocketFlags.None);
                        string user_id = Encoding.Default.GetString(data);

                        // ip 값이 들어있는지 조사하는 부분 처리
                        // 그리고 chatnetwork를 통채로 배열에 저장

                        int index = this.Analysis(user_id);


                        if (index != -1)   // 이미 접속된 상태라면
                        {
                            ChatNetwork newchat = (ChatNetwork)MainWnd.MEMBER[index];

                            newchat.ReConnect(client);
                            newchat.CHATWND.FT = new FileClient(newchat.CHATWND, ip.Address.ToString().Trim());

                            newchat.Activate();
                            this.wnd.Add_MSG("이미 접속한 상태!");
                        }
                        else                // 처음 접속한 경우라면						
                        {
                            ChatNetwork newchat = new ChatNetwork(client, user_id.Trim(), ip.Address.ToString().Trim(), true);
                            MainWnd.MEMBER.Add(newchat);

                            Thread chat_th = new Thread(new ThreadStart(newchat.Show));
                            chat_th.Start();

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
        /// 채팅창이 이미 떠있는지 검사하는 루틴
        /// </summary>
        /// <param name="user">검사할 사용자 아이디</param>
        /// <returns></returns>
        private int Analysis(string user)
        {
            int index = 0;

            if (MainWnd.MEMBER.Count > 0)
            {
                foreach (ChatNetwork obj in MainWnd.MEMBER)
                {
                    if (obj.USERID == user)
                    {
                        return index;
                    }
                    index++;
                }
                return -1; // 일치하는 값이 없을때
            }
            else
            {
                return -1; // 접속 기록이 없다면..
            }
        }

        #endregion

    }
}
