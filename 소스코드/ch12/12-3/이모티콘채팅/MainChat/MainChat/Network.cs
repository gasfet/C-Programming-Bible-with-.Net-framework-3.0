using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace MainChat
{
    /// <summary>
    /// NetWork Ŭ������
    /// 1:1 ä�� ����� �߰��� �����Դϴ�.	
    /// �̸�Ƽ�� �߰�
    /// </summary>
    public class Network
    {
        MainWnd wnd = null;
        Socket server = null;
        Socket client = null;
        Thread th = null;

        string client_ip = null;

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="wnd">ä�� â</param>
        public Network(MainWnd wnd)
        {
            this.wnd = wnd;
        }

        /// <summary>
        /// ���� ���α׷� ����
        /// </summary>
        public void ServerStart()
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 7000);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(ipep);
                server.Listen(10);
                this.wnd.Add_MSG("ä�� ���� ����...");

                this.client = server.Accept();

                IPEndPoint ip = (IPEndPoint)this.client.RemoteEndPoint;
                this.wnd.Add_MSG(ip.Address + "����...");

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
        /// ���� ���α׷� ����
        /// </summary>
        public void ServerStop()
        {
            try
            {
                if (client != null)
                {
                    if (client.Connected)
                    {
                        client.Close();  // Ŭ���̾�Ʈ ���� ����				

                        if (th.IsAlive)
                            th.Abort();      // ������ ����
                    }
                }

                server.Close();
                this.wnd.Add_MSG("ä�� ���� ����...");

            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// ä�� ������ ���� �õ�
        /// </summary>
        /// <param name="ip">������ ���� ������</param>
        /// <returns>���� ����</returns>
        public bool Connect(string ip)
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 7000);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                client.Connect(ipep);

                this.wnd.Add_MSG(ip + "������ ���� ����...");

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
        /// ä�� ���� ���� ����...
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

                this.wnd.Add_MSG("ä�� ���� ���� ����!");
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }


        /// <summary>
        /// ���ӵ� ���� ������ ����
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
                            this.wnd.Add_Status("[" + client_ip + "] ���� �޽����� �Է��մϴ�.");
                            break;

                        case "CTOC_CHAT_MESSAGE_INFO":
                            int index = msg.IndexOf('\a');
                            msg = msg.Substring(index + 1, msg.Length - index - 1);
                            this.wnd.Add_MSG("[" + client_ip + "] ���� ��");
                            this.wnd.Add_RichData(msg);
                            this.wnd.Add_Status("������ �޽���:" + DateTime.Now.ToString());
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
        /// ������ ���濡 ������ ����
        /// </summary>
        /// <param name="msg">������ ���ڿ�</param>
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
                    this.wnd.Add_MSG("�޽��� ���� ����!");
                }
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }


        /// <summary>
        /// ������ ����
        /// </summary>
        /// <param name="data">������ ������</param>
        private void SendData(byte[] data)
        {
            try
            {
                int total = 0;
                int size = data.Length;
                int left_data = size;
                int send_data = 0;

                // ������ ���� �������� ũ�� ����
                byte[] data_size = new byte[4];
                data_size = BitConverter.GetBytes(size);
                send_data = this.client.Send(data_size);

                // ���� ������ ����
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
        /// ������ ����
        /// </summary>		
        /// <returns>������ ������ �迭</returns>
        private byte[] ReceiveData()
        {
            try
            {
                int total = 0;
                int size = 0;
                int left_data = 0;
                int recv_data = 0;

                // ������ ������ ũ�� �˾Ƴ���   
                byte[] data_size = new byte[4];
                recv_data = this.client.Receive(data_size, 0, 4, SocketFlags.None);
                size = BitConverter.ToInt32(data_size, 0);
                left_data = size;

                byte[] data = new byte[size];
                // �������� ������ ���� ������ ����
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
        /// �ڽ��� ������ �˾Ƴ���
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
