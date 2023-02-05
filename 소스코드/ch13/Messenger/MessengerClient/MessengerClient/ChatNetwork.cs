using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace MessengerClient
{

    /// <summary>
    /// ChatNetWork Ŭ����
    /// �̸�Ƽ�� ���� ��� �߰�
    /// </summary>
    public class ChatNetwork
    {
        #region ��� ����/�Ӽ�

        /// <summary>
        /// ä�� â
        /// </summary>
        private ChatWnd wnd = null;

        /// <summary>
        /// ä�� ���� ���� ȸ��
        /// </summary>
        private Socket client = null;

        private Thread th = null;

        private string user_id = null; // ä���ϴ� ���� ���̵�

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

        #region ������
        /// <summary>
        /// ä�� Ŭ���̾�Ʈ ������
        /// </summary>
        /// <param name="client">ä�� ����</param>
        /// <param name="user_id">����� ���̵�</param>
        /// <param name="client_ip">���� ������ �ּ�</param>
        /// <param name="flag">ä���� ��û�� ���(�� or ����)</param>			
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

        #region �޼���

        /// <summary>
        /// ä�� �� ����
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
        /// ä�� â ������
        /// </summary>
        public void Show()
        {
            this.wnd.ShowDialog();
            this.wnd.Activate();
        }

        /// <summary>
        /// ä��â Ȱ��ȭ
        /// </summary>
        public void Activate()
        {
            this.wnd.Activate();
        }


        /// <summary>
        /// ä�� ������ ���� �õ�
        /// </summary>
        /// <param name="ip">������ ���� ������</param>
        /// <returns>���� ����</returns>
        public bool Connect(string ip, string port)
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), Convert.ToInt32(port));
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                client.Connect(ipep);

                this.wnd.Add_MSG(ip + "������ ���� ����...");

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
        /// ä�� ���� ���� ����...
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

                    switch (Convert.ToByte(token[0].Trim()))
                    {
                        case (byte)MSG.CTOC_CHAT_NEWTEXT_INFO:
                            this.wnd.Add_Status("[" + this.user_id + "] ���� �޽����� �Է��մϴ�.");
                            break;

                        case (byte)MSG.CTOC_CHAT_MESSAGE_INFO:
                            if (token[1].Trim() == "1") // ��ȣȭ
                            {
                                CryptoAPI crypt = new CryptoAPI();
                                msg = crypt.Decryptor(this.ReceiveData());
                            }
                            else
                            {
                                msg = Encoding.Default.GetString(this.ReceiveData());
                            }
                            this.wnd.Add_MSG("[" + this.user_id + "] ���� ��");
                            this.wnd.Add_RichData(msg);
                            this.wnd.Add_Status("������ �޽���:" + DateTime.Now.ToString());
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
        /// ������ ���濡 ������ ����
        /// </summary>
        /// <param name="msg">������ ���ڿ�</param>
        public void Send(byte[] msg)
        {
            this.SendData(msg);
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


        #endregion


    }
}


