using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;   // ver 2.0 �߰��κ� 

namespace MainChat
{
    public class Network
    {
        MainWnd wnd = null;    // ä�� â
        Socket server = null;    // ä�� ������ ���Ǵ� ����
        Socket client = null;     // ä�� Ŭ���̾�Ʈ�� ���Ǵ� ����
        Thread th = null;        // Receive �޼��� ������ ó��
        string client_ip = null;   // ������ �ּ� ����

        /* ver 2.0 �߰��� �κ� */
        NetworkStream stream = null;  // ��Ʈ��ũ ��Ʈ��
        StreamReader reader = null;   // �б� ��Ʈ��
        StreamWriter writer = null;    // ���� ��Ʈ��     

        /// <summary>
        /// Network Ŭ���� ������
        /// </summary>
        /// <param name="wnd">ä�� â �ν��Ͻ�</param>
        public Network(MainWnd wnd)
        {
            this.wnd = wnd;
        }

        /// <summary>
        /// ä�� ���� ���α׷� ����
        /// </summary>
        public void ServerStart()
        {
            try
            {	// ä�� ���� ���α׷� ����		
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 7000);
                server = new Socket(AddressFamily.InterNetwork,
                                                        SocketType.Stream, ProtocolType.Tcp);
                server.Bind(ipep);   // ä�� ���� ���ε�
                server.Listen(10);   // ä�� ���� ����
                this.wnd.Add_MSG("ä�� ���� ����...");
                this.client = server.Accept();  // ä�� Ŭ���̾�Ʈ�� �����ϸ� 
                // ������ ������ �ּҸ� �˾Ƴ� txt_info �� ���
                IPEndPoint ip = (IPEndPoint)this.client.RemoteEndPoint;
                this.wnd.Add_MSG(ip.Address + "����...");
                // ����� ������ �ּ� ���
                this.client_ip = ip.Address.ToString();
                /// Ver 2.0 �� �߰��� �κ�
                stream = new NetworkStream(this.client);
                reader = new StreamReader(stream);       // �߰��� ����
                writer = new StreamWriter(stream);

                th = new Thread(new ThreadStart(Receive));  // ������ ���� ���ڿ� ����
                th.Start();
            }
            catch (Exception ex)  // ä�� ���� ���� �� ���ܰ� �߻��ϸ� 
            {    // txt_info ��ü�� ���� �޽��� ���
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// ä�� ���� ���α׷� ����
        /// </summary>
        public void ServerStop()
        {
            try
            {
                 if(reader != null)
                     reader.Close(); // StreamReader ����  
                 if(writer != null)
                     writer.Close();  // StreamWriter ����
                 if(stream != null) 
                     stream.Close(); // NetworkStream ����   
                 if(client != null)
                     client.Close();  // Ŭ���̾�Ʈ ���� ����				                 
                if ((th != null)&&(th.IsAlive)) // Receive �޼��� 
                     th.Abort();   // ������ ����
                                   
                 server.Close();   // ���� ���� ����
            }
            catch (Exception ex) // ���� �޽��� ó��
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// ä�� ������ ���� �õ�
        /// </summary>
        /// <param name="ip">������ ���� ������ �ּ�</param>
        /// <returns>���� ����</returns>
        public bool Connect(string ip)
        {
            try
            {       // ä�� ���� ������ �ּҿ� ��Ʈ ��ȣ ����
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 7000);
                this.client = new Socket(AddressFamily.InterNetwork,
                                                   SocketType.Stream, ProtocolType.Tcp);

                this.client.Connect(ipep);  // ä�� ������ ���� �õ�
                this.wnd.Add_MSG(ip + "������ ���� ����...");
                this.client_ip = ip;        // ä�� ���� ������ �ּ� ����

                /// �߰��� �κ� 
                stream = new NetworkStream(this.client);
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);

                th = new Thread(new ThreadStart(Receive)); // ������ ����
                th.Start();

                return true;
            }
            catch (Exception ex)  // ���� ó��
            {
                this.wnd.Add_MSG(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// ä�� ���� ���� ����
        /// </summary>
        public void Disconnect()
        {
            try
            {
                if (client != null)
                {
                    if (client.Connected)   // ä�� ������ ����Ǿ� �ִٸ�
                    {
                        reader.Close();  // StreamReader �ݱ� 
                        writer.Close();  // StreamWriter �ݱ� 
                        stream.Close(); // NetworkStream �ݱ� 
                        client.Close();  // ä�� ������ ���� ����

                        if (th.IsAlive)
                            th.Abort();      // ������ ����
                    }
                }
                this.wnd.Add_MSG("ä�� ���� ���� ����!");
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// ����� ������ ���� ������ �����ϱ�
        /// </summary>  
        public void Receive()
        {
            try
            {
                while (client.Connected)
                {   /// ����� �κ� 
                    string msg = reader.ReadLine();  // ���δ����� ���ڿ� �о����
                    this.wnd.Add_MSG("[" + client_ip + "] " + msg);
                }
            }
            catch (Exception ex)  // ���� ó��
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// ����� ���濡�� ������ �����ϱ�
        /// </summary>
        /// <param name="msg">������ ���ڿ�</param>
        public void Send(string msg)
        {
            try
            {
                if (client.Connected)  // ����� ������ �Ǿ� �ִٸ�
                {   // ����� �κ� //
                    writer.WriteLine(msg);   // ���ڿ� �޽��� ����
                    writer.Flush();
                }
                else   // ����� ����Ǿ� ���� �ʴٸ�
                {
                    this.wnd.Add_MSG("�޽��� ���� ����!");
                }
            }
            catch (Exception ex)  // ���ڿ� ���� �� ���ܰ� �߻��ϸ�
            {
                this.wnd.Add_MSG(ex.Message);
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
