using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace MainChat
{
    /// <summary>
    /// NetWork 클래스는
    /// 1:1 채팅 기능이 추가된 버전입니다.	
    /// 이모티콘 추가
    /// </summary>
    public class Network
    {
        MainWnd wnd = null;
        Socket server = null;
        Socket client = null;
        Thread th = null;

        string client_ip = null;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="wnd">채팅 창</param>
        public Network(MainWnd wnd)
        {
            this.wnd = wnd;
        }

        /// <summary>
        /// 서버 프로그램 시작
        /// </summary>
        public void ServerStart()
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 7000);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(ipep);
                server.Listen(10);
                this.wnd.Add_MSG("채팅 서버 시작...");

                this.client = server.Accept();

                IPEndPoint ip = (IPEndPoint)this.client.RemoteEndPoint;
                this.wnd.Add_MSG(ip.Address + "접속...");

                this.client_ip = ip.Address.ToString();

                th = new Thread(new ThreadStart(Receive));
                th.Start();
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 서버 프로그램 중지
        /// </summary>
        public void ServerStop()
        {
            try
            {
                if (client != null)
                {
                    if (client.Connected)
                    {
                        client.Close();  // 클라이언트 접속 끊음				

                        if (th.IsAlive)
                            th.Abort();      // 스레드 종료
                    }
                }

                server.Close();
                this.wnd.Add_MSG("채팅 서버 종료...");

            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 채팅 서버와 연결 시도
        /// </summary>
        /// <param name="ip">연결할 서버 아이피</param>
        /// <returns>연결 유무</returns>
        public bool Connect(string ip)
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 7000);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                client.Connect(ipep);

                this.wnd.Add_MSG(ip + "서버에 접속 성공...");

                this.client_ip = ip;

                th = new Thread(new ThreadStart(Receive));
                th.IsBackground = true;
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
        /// 채팅 서버 연결 종료...
        /// </summary>   
        public void Disconnect()
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

                this.wnd.Add_MSG("채팅 서버 연결 종료!");
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

                    switch (token[0])
                    {
                        case "CTOC_CHAT_NEWTEXT_INFO":
                            this.wnd.Add_Status("[" + client_ip + "] 님이 메시지를 입력합니다.");
                            break;

                        case "CTOC_CHAT_MESSAGE_INFO":
                            int index = msg.IndexOf('\a');
                            msg = msg.Substring(index + 1, msg.Length - index - 1);
                            this.wnd.Add_MSG("[" + client_ip + "] 님의 말");
                            this.wnd.Add_RichData(msg);
                            this.wnd.Add_Status("마지막 메시지:" + DateTime.Now.ToString());
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
                    recv_data = this.client.Receive(data, total, left_data, SocketFlags.None);
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
        /// 자신의 아이피 알아내기
        /// </summary>
        /// <returns></returns>
        public string Get_MyIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string myip = host.AddressList[0].ToString();
            return myip;
        }

    }
}
