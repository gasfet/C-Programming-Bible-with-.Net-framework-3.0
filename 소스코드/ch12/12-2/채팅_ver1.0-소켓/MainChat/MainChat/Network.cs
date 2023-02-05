using System;
using System.Net;           // ��Ʈ��ũ ó��
using System.Net.Sockets;   // ���� ó��
using System.Threading;     // ������ ó��
using System.Text;          // ���ڿ� ó��

namespace MainChat
{
    public class Network
    {
        MainWnd wnd = null;         // ä�� â �ν��Ͻ� ����
        Socket server = null;         // ä�� ������ ����� ����
        Socket client = null;          // ä�� Ŭ���̾�Ʈ�� ����� ����(���ӿ�)
        Thread th = null;             // ������ ó�� 
        string client_ip = null;        // ä�� ������ ������ ��ǻ�� ������ �ּ� ����

        /// <summary>
        /// Network Ŭ���� ������
        /// </summary>
        /// <param name="wnd">ä�� â �ν��Ͻ�</param>
        public Network(MainWnd wnd)
        {
            this.wnd = wnd;
        }

        /// <summary>
        /// ä�� ���� ����
        /// </summary>
        public void ServerStart()
        {
            try
            {	// ���� ��Ʈ ��ȣ�� 7000������ �����մϴ�.		
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 7000);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                                                        ProtocolType.Tcp);
                server.Bind(ipep);   // ������ ��Ʈ ��ȣ�� ���ε� �մϴ�.
                server.Listen(10);   // Ŭ���̾�Ʈ ������ ����մϴ�.
                this.wnd.Add_MSG("ä�� ���� ����...");

                this.client = server.Accept();  // Ŭ���̾�Ʈ�� ���ӵǸ� 
                // ������ Ŭ���̾�Ʈ ������ �ּҸ� ����մϴ�.
                IPEndPoint ip = (IPEndPoint)this.client.RemoteEndPoint;
                this.wnd.Add_MSG(ip.Address + "����...");
                // client_ip ������ ������ Ŭ���̾�Ʈ ������ �ּҸ� ����մϴ�.
                this.client_ip = ip.Address.ToString();
                // Receive �޼��带 ������� ����ϰ� �����մϴ�.
                th = new Thread(new ThreadStart(Receive));
                th.Start();
            }
            catch (Exception ex)
            {         // ä�� �������� ���ܰ� �߻��ϸ� 
                this.wnd.Add_MSG(ex.Message);  // ���� �޽����� txt_info �� ����մϴ�.
            }
        }

        /// <summary>
        /// ä�� ���� ���α׷� ����
        /// </summary>
        public void ServerStop()
        {
            try
            {
                if (client != null)    // Ŭ���̾�Ʈ�� ���ӵ� ���¶��
                {
                    if (client.Connected)
                        client.Close();  // Ŭ���̾�Ʈ ���� ����		
                }

                server.Close();  // ä�� ���� ������ �ݽ��ϴ�.

                if ((th != null) && (th.IsAlive))   // Receive �޼��� �����尡 �������̶��
                {
                    th.Abort();     // �����带 �����մϴ�.
                }
            }
            catch (Exception ex)   // ���� �޽��� ���
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ä�� ������ ���� �õ�(Ŭ���̾�Ʈ ��)
        /// </summary>
        /// <param name="ip">������ ���� ������ �ּ�</param>
        /// <returns>���� ����</returns>
        public bool Connect(string ip)
        {
            try
            {    // ������ ä�� ���� ������ �ּҿ� ��Ʈ ��ȣ�� �����մϴ�.
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 7000);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                                                 ProtocolType.Tcp);
                client.Connect(ipep);   // ä�� ������ ������ �õ��մϴ�.
                this.wnd.Add_MSG(ip + "������ ���� ����...");
                this.client_ip = ip;   // ä�� ������ ������ �ּҸ� �����մϴ�.
                th = new Thread(new ThreadStart(Receive));  // ä�� ���ڿ� ���� �����带 
                th.Start();                                      // �����ϰ� �����带 �����մϴ�.

                return true;             // ä�� ���� ���ӿ� �����ϸ� true ���� ��ȯ�մϴ�.
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);  // ä�� ���� ���ӿ� �����ϸ� ���� �޽�����
                return false;                     // ����ϰ� false ���� ��ȯ�մϴ�.
            }
        }

        /// <summary>
        /// ä�� ���� ���� ����... (Ŭ���̾�Ʈ ��)
        /// </summary>   
        public void Disconnect()
        {
            try
            {
                if (client != null)   // ä�� ������ ����Ǿ� �ִٸ�
                {
                    if (client.Connected)
                        client.Close();  // ä�� �������� ������ �����ϴ�.

                    if (th.IsAlive)
                        th.Abort();   // Receive �޼��� �����带 �����մϴ�.
                }
                this.wnd.Add_MSG("ä�� ���� ���� ����!");
            }
            catch (Exception ex)
            {   // ä�� ���� ���� ������ ������ ����� ���ܰ� �߻��ϸ� 
                this.wnd.Add_MSG(ex.Message);  // txt_info�� ���� �޽��� ���
            }
        }


        /// <summary>
        /// ���ӵ� ���� ������ ���� (Ŭ���̾�Ʈ/���� ����)
        /// </summary>  
        public void Receive()
        {
            try
            {    // ����� ����Ǿ��ٸ�
                while (client != null && client.Connected)
                {     // ReceiveData �޼��带 ����� ����Ʈ ������ �����͸� �о�ɴϴ�.
                    byte[] data = this.ReceiveData();
                    this.wnd.Add_MSG("[" + client_ip + "] " + Encoding.Default.GetString(data));                   		   // �о���� �����͸� ���ڿ��� ������ txt_info �� ����մϴ�.
                }
            }
            catch (Exception ex)  // ������ ������ �����͸� �д� ���� ���ܰ� �߻��ϸ�
            {    // txt_info�� ���� �޽����� ����մϴ�.
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
                if (client.Connected) // ����� ����Ǿ� ������
                {       // ���ڿ��� ����Ʈ �迭 ���·� �����մϴ�.
                    byte[] data = Encoding.Default.GetBytes(msg);
                    this.SendData(data);  // ����Ʈ �迭�� ���濡 �����մϴ�.
                }
                else
                {   // ����� ����Ǿ� ���� �ʴٸ�
                    this.wnd.Add_MSG("�޽��� ���� ����!");
                }
            }
            catch (Exception ex)  // �޽��� ������ ���ܰ� �߻��ϸ� 
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// ���濡�� ����Ʈ �迭 �����ϱ�
        /// </summary>
        /// <param name="data">������ ����Ʈ �迭</param>
        private void SendData(byte[] data)
        {
            try
            {
                int total = 0;            // ���۵� �� ũ��
                int size = data.Length;  // ������ ����Ʈ �迭�� ũ��
                int left_data = size;    // ���� ������ ��
                int send_data = 0;       // ���۵� ������ ũ��

                // ������ ���� �������� ũ�� ����
                byte[] data_size = new byte[4];   // �������·� ������ ũ�� ����
                data_size = BitConverter.GetBytes(size);
                send_data = this.client.Send(data_size);

                // ���� ������ ����
                while (total < size)
                {  // ���濡�� ������ �����ϱ� 
                    send_data = this.client.Send(data, total, left_data, SocketFlags.None);
                    total += send_data;
                    left_data -= send_data;
                }
            }
            catch (Exception ex)
            {   // ������ ������ ���ܰ� �߻��ϸ� ���� �޽��� ���
                this.wnd.Add_MSG(ex.Message);
            }
        }


        /// <summary>
        /// ������ ���� ������ �����ϱ�
        /// </summary>		
        /// <returns>������ �������� ����Ʈ �迭</returns>
        private byte[] ReceiveData()
        {
            try
            {
                int total = 0;        // ���ŵ� ������ �ѷ�
                int size = 0;        // ������ ������ ũ��
                int left_data = 0;   // ���� ������ ũ��
                int recv_data = 0;  // ������ ������ ũ��

                // ������ ������ ũ�� �˾Ƴ���   
                byte[] data_size = new byte[4];
                recv_data = this.client.Receive(data_size, 0, 4, SocketFlags.None);
                size = BitConverter.ToInt32(data_size, 0);
                left_data = size;

                byte[] data = new byte[size];  // ����Ʈ �迭 ����
                // �������� ������ ���� ������ ����
                while (total < size)
                {  // ������ ������ �����͸� �о��
                    recv_data = this.client.Receive(data, total, left_data, 0);
                    if (recv_data == 0) break;
                    total += recv_data;
                    left_data -= recv_data;
                }
                return data;
            }
            catch (Exception ex)
            {   // ������ ������ ���ܰ� �߻��ϸ� ���� �޽��� ���
                this.wnd.Add_MSG(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// �� ������ �ּ� �˾Ƴ���
        /// </summary>
        /// <returns>������ �ּ�</returns>
        public string Get_MyIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string myip = host.AddressList[0].ToString();
            return myip;
        }
    }
}
