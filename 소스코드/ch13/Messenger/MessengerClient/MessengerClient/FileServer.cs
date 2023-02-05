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
    /// FileTransfer�� ���� ��� �����Դϴ�.
    /// </summary>
    public class FileServer
    {

        #region ��� ����/������

        private MainWnd wnd = null;

        private Socket server = null;

        private int port = 2700;

        private Thread th = null;


        /// <summary>
        /// ������
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

        #region ��� �޼���

        /// <summary>
        /// ���� ���� ����
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
                this.wnd.Add_MSG("���� ���� ���� ����:" + ex.Message);
            }
        }

        /// <summary>
        /// ���� ���� ����
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
        /// ���� ���α׷� ����
        /// </summary>
        public void AcceptClient()
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, this.port);
                this.server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.server.Bind(ipep);
                this.server.Listen(10);
                this.wnd.Add_MSG("���� ���� ����...");

                while (true)
                {
                    Socket client = this.server.Accept();
                    IPEndPoint ip = (IPEndPoint)client.RemoteEndPoint;
                    this.wnd.Add_MSG(ip.Address + " ���� Ŭ���̾�Ʈ ����...");

                    if (client.Connected)
                    {
                        int index = this.Analysis(ip.Address.ToString().Trim());

                        if (index != -1)   // �̹� ���ӵ� ���¶��
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
        /// ä��â ���� ��������
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
                return -1; // ��ġ�ϴ� ���� ������
            }
            else
            {
                return -1; // ���� ����� ���ٸ�..
            }
        }

        #endregion

    }
}
