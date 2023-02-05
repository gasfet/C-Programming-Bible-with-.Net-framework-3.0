using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;   // ver 2.0&3.0 �߰� �κ�

namespace MainChat
{
    public class Network
    {
        MainWnd wnd = null;	         // ä�� â ��ü ���� 	 
        Thread th = null;                      // ������ ó��
        private TcpListener server = null;    // ä�� ���� 
        private TcpClient client = null;     // ä�� Ŭ���̾�Ʈ
        private NetworkStream stream = null;  // ��Ʈ��ũ ��Ʈ�� ��ü
        private StreamReader reader = null;   // ��Ʈ�� �б�
        private StreamWriter writer = null;    // ��Ʈ�� ����		

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
            {	// ä�� ���� ��Ʈ ��ȣ�� 7000������ �����ϰ�		
                server = new TcpListener(IPAddress.Any, 7000);
                server.Start();  // ä�� ������ ����...
                this.wnd.Add_MSG("ä�� ���� ����...");
                client = server.AcceptTcpClient(); // ä�� Ŭ���̾�Ʈ�� �����ϸ�
                stream = client.GetStream();  // ����� Ŭ���̾�Ʈ ��Ʈ�� ��������
                reader = new StreamReader(stream); // �б� ��Ʈ�� ����
                writer = new StreamWriter(stream);  // ���� ��Ʈ�� ����

                th = new Thread(new ThreadStart(Receive)); // ���� ������
                th.Start();
            }
            catch (Exception ex)  // ä�� ���� ó������ ���ܰ� �߻��� ���
            {
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
			       if(reader != null)    reader.Close();  // �б� ��Ʈ�� ����
			       if(writer != null)    writer.Close();   // ���� ��Ʈ�� ����
			       if(stream != null)    stream.Close();  // ��Ʈ�� ����
			       if(client != null)    client.Close();       // Ŭ���̾�Ʈ ���� ����			
                   if((th != null)&&(th.IsAlive))  th.Abort();   // ������ ����		
                    server.Stop();  // TcpListener ���� ����
			}
			catch(Exception ex)
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
            {    // ä�� ���� ������ �ּҿ� ��Ʈ ��ȣ ����
                client = new TcpClient(ip, 7000);
                this.wnd.Add_MSG(ip + "������ ���� ����...");
                // ä�� ���� ���ῡ �����ϸ� ����� ��Ʈ��ũ ��Ʈ�� ����
                stream = client.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);

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
        /// ä�� ������ ���� ����
        /// </summary>
        public void Disconnect()
        {
            try
            {
                if (client != null)  // ä�� ������ ����Ǿ� �ִٸ�
                {
                    if (reader != null) reader.Close();  // �б� ��Ʈ�� ����
                    if (writer != null) writer.Close();  // ���� ��Ʈ�� ����
                    if (stream != null) stream.Close(); // ��Ʈ�� ����		 
                    client.Close();     // ä�� ������ ���� ����					
                    if(th.IsAlive)  th.Abort();           // ���� ������ ����
                }
                this.wnd.Add_MSG("���� ����");
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
            string msg = null;
            try
            {
                do
                {
                    msg = reader.ReadLine();  // ���ڿ� �о����
                    this.wnd.Add_MSG("[" + "����" + "] " + msg);  // ���ڿ� ���
                } while (msg != null);
            }
            catch (Exception ex)
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
                writer.WriteLine(msg);  // ����� ���濡�� ���ڿ� ����
                writer.Flush();
            }
            catch (Exception ex)
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

