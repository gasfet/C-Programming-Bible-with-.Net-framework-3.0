using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace MessengerClient
{

    /// <summary>
    /// ChatNetWork 클래스
    /// 이모티콘 전송 기능 추가
    /// </summary>
    public class ChatNetwork
    {
        #region 멤버 변수/속성

        /// <summary>
        /// 채팅 창
        /// </summary>
        private ChatWnd wnd = null;

        /// <summary>
        /// 채팅 상대방 연결 회선
        /// </summary>
        private Socket client = null;

        private Thread th = null;

        private string user_id = null; // 채팅하는 상대방 아이디

        private string client_ip = null;

        public ChatWnd CHATWND
        {
            get
            {
                return this.wnd;
            }
        }

        public string USERID
        {
            get
            {
                return this.user_id;
            }
        }

        public string ClientIP
        {
            get
            {
                return this.client_ip;
            }
        }

        #endregion

        #region 생성자
        /// <summary>
        /// 채팅 클라이언트 생성자
        /// </summary>
        /// <param name="client">채팅 소켓</param>
        /// <param name="user_id">사용자 아이디</param>
        /// <param name="client_ip">소켓 아이피 주소</param>
        /// <param name="flag">채팅을 요청한 사람(나 or 상대방)</param>			
        public ChatNetwork(Socket client, string user_id, string client_ip, bool flag)
        {
            this.client = client;
            this.user_id = user_id;
            this.client_ip = client_ip;

            this.wnd = new ChatWnd(this, flag);

            this.th = new Thread(new ThreadStart(Receive));
            this.th.Start();
        }


        #endregion

        #region 메서드

        /// <summary>
        /// 채팅 재 연결
        /// </summary>
        /// <param name="client"></param>
        public void ReConnect(Socket client)
        {
            try
            {
                this.client.Close();

                this.th.Join();

                this.client = client;

                this.wnd.ReConnect();

                if (!this.th.IsAlive)
                {
                    this.th = new Thread(new ThreadStart(Receive));
                    this.th.Start();

                }

            }
            catch
            {

            }

        }

        /// <summary>
        /// 채팅 창 띄위기
        /// </summary>
        public void Show()
        {
            this.wnd.ShowDialog();
            this.wnd.Activate();
        }

        /// <summary>
        /// 채팅창 활성화
        /// </summary>
        public void Activate()
        {
            this.wnd.Activate();
        }


        /// <summary>
        /// 채팅 서버와 연결 시도
        /// </summary>
        /// <param name="ip">연결할 서버 아이피</param>
        /// <returns>연결 유무</returns>
        public bool Connect(string ip, string port)
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), Convert.ToInt32(port));
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                client.Connect(ipep);

                this.wnd.Add_MSG(ip + "서버에 접속 성공...");

                this.client_ip = ip;

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
        /// 채팅 서버 연결 종료...
        /// </summary>   
        public void DisConnect()
        {
            try
            {
                if (client != null)
                {
                    if (client.Connected)
                    {
                        this.client.Shutdown(SocketShutdown.Send);
                        client.Close();
                    }

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

                    switch (Convert.ToByte(token[0].Trim()))
                    {
                        case (byte)MSG.CTOC_CHAT_NEWTEXT_INFO:
                            this.wnd.Add_Status("[" + this.user_id + "] 님이 메시지를 입력합니다.");
                            break;

                        case (byte)MSG.CTOC_CHAT_MESSAGE_INFO:
                            if (token[1].Trim() == "1") // 암호화
                            {
                                CryptoAPI crypt = new CryptoAPI();
                                msg = crypt.Decryptor(this.ReceiveData());
                            }
                            else
                            {
                                msg = Encoding.Default.GetString(this.ReceiveData());
                            }
                            this.wnd.Add_MSG("[" + this.user_id + "] 님의 말");
                            this.wnd.Add_RichData(msg);
                            this.wnd.Add_Status("마지막 메시지:" + DateTime.Now.ToString());
                            break;
                    }

                }
                this.wnd.Error();
            }
            catch
            {
                this.wnd.Error();
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
        /// 접속한 상대방에 데이터 전송
        /// </summary>
        /// <param name="msg">전송할 문자열</param>
        public void Send(byte[] msg)
        {
            this.SendData(msg);
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


        #endregion


    }
}


