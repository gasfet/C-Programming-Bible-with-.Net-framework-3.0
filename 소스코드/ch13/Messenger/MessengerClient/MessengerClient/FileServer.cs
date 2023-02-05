using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Text;

namespace MessengerClient
{
    /// <summary>
    /// FileTransfer에 대한 요약 설명입니다.
    /// </summary>
    public class FileServer
    {

        #region 멤버 변수/생성자

        private MainWnd wnd = null;

        private Socket server = null;

        private int port = 2700;

        private Thread th = null;


        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="wnd"></param>
        public FileServer(MainWnd wnd)
        {
            this.wnd = wnd;
        }

        public FileServer(MainWnd wnd, int port)
        {
            this.wnd = wnd;
            this.port = port;
        }

        #endregion

        #region 멤버 메서드

        /// <summary>
        /// 파일 서버 시작
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
                this.wnd.Add_MSG("파일 서버 접속 에러:" + ex.Message);
            }
        }

        /// <summary>
        /// 파일 서버 종료
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
        /// 파일 프로그램 시작
        /// </summary>
        public void AcceptClient()
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, this.port);
                this.server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.server.Bind(ipep);
                this.server.Listen(10);
                this.wnd.Add_MSG("파일 서버 시작...");

                while (true)
                {
                    Socket client = this.server.Accept();
                    IPEndPoint ip = (IPEndPoint)client.RemoteEndPoint;
                    this.wnd.Add_MSG(ip.Address + " 파일 클라이언트 접속...");

                    if (client.Connected)
                    {
                        int index = this.Analysis(ip.Address.ToString().Trim());

                        if (index != -1)   // 이미 접속된 상태라면
                        {
                            ChatNetwork newchat = (ChatNetwork)MainWnd.MEMBER[index];
                            FileClient fclient = new FileClient(newchat.CHATWND, client);
                            newchat.CHATWND.FT = fclient;
                            newchat.Activate();
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
        /// 채팅창 정보 가져오기
        /// </summary>		
        /// <returns></returns>
        private int Analysis(string client_ip)
        {
            int index = 0;

            if (MainWnd.MEMBER.Count > 0)
            {
                foreach (ChatNetwork obj in MainWnd.MEMBER)
                {
                    if (obj.ClientIP == client_ip)
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
