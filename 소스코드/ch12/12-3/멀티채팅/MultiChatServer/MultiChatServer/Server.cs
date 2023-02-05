using System;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;


namespace MultiChatServer
{
    /// <summary>
    /// Server�� ���� ��� �����Դϴ�.
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
                cgroup = new ClientGroup(); // ClientGroup  ������ ȣ��

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
                cgroup.Dispose(); // ClientGroup �Ҹ��� ȣ��

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
                    this.wnd.Add_MSG(ip.Address + "����...");

                    if (client.Connected)
                    {
                        Client obj = new Client(client, this.wnd);
                        cgroup.AddMember(obj);// ���� �׷쿡 ������ �߰�
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
