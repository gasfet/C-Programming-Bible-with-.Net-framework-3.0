using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Collections;


namespace MessengerClient
{
    /// <summary>
    /// ChatServer : ä�� ����
    /// </summary>
    public class ChatServer
    {
        #region ��� ����/������

        private MainWnd wnd = null;
        private Socket server = null;
        private Thread th = null;

        /// <summary>
        /// ä�� ���� ��Ʈ
        /// </summary>
        private int port = 2500;

        /// <summary>
        /// ChatServer ������ 1
        /// </summary>
        /// <param name="wnd">ä�� Ŭ���̾�Ʈ ���� ��</param>
        public ChatServer(MainWnd wnd)
        {
            this.wnd = wnd;
        }

        /// <summary>
        /// ChatServer ������ 2
        /// </summary>
        /// <param name="wnd">ä�� Ŭ���̾�Ʈ ���� ��</param>
        /// <param name="port">ä�ü��� ��Ʈ ��ȣ ����</param>
        public ChatServer(MainWnd wnd, int port)
        {
            this.wnd = wnd;
            this.port = port;
        }

        #endregion


        #region ��� �޼���

        /// <summary>
        /// ä�� ���� ����
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
                this.wnd.Add_MSG("ä�� ���� ���� ����:" + ex.Message);
            }
        }

        /// <summary>
        /// ä�� ���� ����
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
        /// ä�� Ŭ���̾�Ʈ ���� ó��
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
                    this.wnd.Add_MSG(ip.Address + " ä�� Ŭ���̾�Ʈ ����...");

                    if (client.Connected)
                    {
                        byte[] data_size = new byte[4];
                        client.Receive(data_size, 0, 4, SocketFlags.None);
                        int size = BitConverter.ToInt32(data_size, 0);
                        byte[] data = new byte[size];
                        client.Receive(data, 0, size, SocketFlags.None);
                        string user_id = Encoding.Default.GetString(data);

                        // ip ���� ����ִ��� �����ϴ� �κ� ó��
                        // �׸��� chatnetwork�� ��ä�� �迭�� ����

                        int index = this.Analysis(user_id);


                        if (index != -1)   // �̹� ���ӵ� ���¶��
                        {
                            ChatNetwork newchat = (ChatNetwork)MainWnd.MEMBER[index];

                            newchat.ReConnect(client);
                            newchat.CHATWND.FT = new FileClient(newchat.CHATWND, ip.Address.ToString().Trim());

                            newchat.Activate();
                            this.wnd.Add_MSG("�̹� ������ ����!");
                        }
                        else                // ó�� ������ �����						
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
        /// ä��â�� �̹� ���ִ��� �˻��ϴ� ��ƾ
        /// </summary>
        /// <param name="user">�˻��� ����� ���̵�</param>
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
