using System;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;


namespace MultiChatServer
{
    /// <summary>
    /// Server에 대한 요약 설명입니다.
    /// </summary>

    class Server
    {
        MainWnd wnd = null;
        int port = 7007;

        Socket server = null;
        Thread th = null;

        ClientGroup cgroup = null;


        public Server(MainWnd wnd, int port)
        {
            this.wnd = wnd;
            this.port = port;
        }


        public void ServerStart()
        {
            try
            {
                cgroup = new ClientGroup(); // ClientGroup  생성자 호출

                th = new Thread(new ThreadStart(AcceptClient));
                th.IsBackground = true;
                th.Start();
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        public void ServerStop()
        {
            try
            {
                cgroup.Dispose(); // ClientGroup 소멸자 호출

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
                        Client obj = new Client(client, this.wnd);
                        cgroup.AddMember(obj);// 서버 그룹에 데이터 추가
                        this.wnd.Add_listView(obj.Client_IP, DateTime.Now.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }


        public bool BroadCast(string msg)
        {
            return cgroup.BroadCast(msg);
        }

        public bool BroadCast(string msg, string ips)
        {
            return cgroup.BroadCast(msg, ips);
        }

        public void DeleteClient(string ip)
        {
            cgroup.DeleteMember(ip);
        }

    }
}
