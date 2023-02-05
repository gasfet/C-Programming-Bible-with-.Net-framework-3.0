using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace MessengerClient
{
    public class RegNetwork
    {

        #region ��� ����/������

        RegForm wnd = null;      // ȸ�� ������

        Socket client = null;
        Thread th = null;

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="wnd">ȸ�� ������ �ν��Ͻ�</param>
        public RegNetwork(RegForm wnd)
        {
            this.wnd = wnd;
        }

        #endregion


        #region ��� �޼���

        /// <summary>
        /// �޽��� ������ ���� �õ�
        /// </summary>
        /// <param name="ip">������ ���� ������</param>
        /// <returns>���� ����</returns>
        public bool Connect(string ip)
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 7007);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                client.Connect(ipep);

                th = new Thread(new ThreadStart(Receive));
                th.Start();

                return true;
            }
            catch (Exception ex)
            {
                this.wnd.wnd.Add_MSG(ex.Message);
                return false;
            }
        }


        /// <summary>
        /// �޽��� ���� ���� ����...
        /// </summary>   
        public void DisConnect()
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

                this.wnd.wnd.Add_MSG("���� ���� ����!");
            }
            catch (Exception ex)
            {
                this.wnd.wnd.Add_MSG(ex.Message);
            }
        }


        /// <summary>
        /// �޽��� ������ �����ϴ� ������ ����
        /// </summary>  
        public void Receive()
        {
            try
            {
                byte[] data = this.ReceiveData();
                string msg = Encoding.Default.GetString(data);
                string[] token = msg.Split('\a');

                switch (Convert.ToInt32(token[0].Trim()))
                {
                    case (int)MSG.STOC_MESSAGE_REGISTER_OK:   // ȸ�� ���� ����  
                        System.Windows.Forms.MessageBox.Show("ȸ�� ���� ����! \r\n ���� �α��� ���ּ���!");
                        this.wnd.Close();  // ȸ�� ����â �ݱ�
                        break;

                    case (int)MSG.STOC_MESSAGE_REGISTER_FAIL: // ȸ�� ���� ���� 
                        System.Windows.Forms.MessageBox.Show("ȸ�� ���� ����!");
                        this.wnd.Close();  // ȸ�� ����â �ݱ�
                        break;

                    case (int)MSG.STOC_MESSAGE_REGISTER_IDYES: //���̵� �ߺ���ȸ ��� ��밡��
                        System.Windows.Forms.MessageBox.Show("���̵� ��밡��!");
                        this.wnd.id_ok = true;
                        break;

                    case (int)MSG.STOC_MESSAGE_REGISTER_IDNO:  //���̵� �ߺ���ȸ ��� ���Ұ�
                        System.Windows.Forms.MessageBox.Show("���̵� ���Ұ�!");
                        this.wnd.id_ok = false;
                        break;

                    case (int)MSG.STOC_MESSAGE_REGISTER_ZIPCODEDATA: // �����ȣ ��ȸ ���
                        this.wnd.zipcodewnd.ZipdataInput(token[1].Trim());
                        break;

                    case (int)MSG.STOC_MESSAGE_REGISTER_ZIPCODERR: // �����ȣ ��ȸ ����
                        System.Windows.Forms.MessageBox.Show("�����ȣ ��ȸ ����!");
                        break;
                }

            }
            catch (Exception ex)
            {
                this.wnd.wnd.Add_MSG(ex.Message);
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
                    this.wnd.wnd.Add_MSG("�޽��� ���� ����!");
                }
            }
            catch (Exception ex)
            {
                this.wnd.wnd.Add_MSG(ex.Message);
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
                this.wnd.wnd.Add_MSG(ex.Message);
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
                    recv_data = this.client.Receive(data, total, left_data, 0);
                    if (recv_data == 0) break;
                    total += recv_data;
                    left_data -= recv_data;
                }
                return data;
            }
            catch (Exception ex)
            {
                this.wnd.wnd.Add_MSG(ex.Message);
                return null;
            }
        }




        #endregion
    }
}
