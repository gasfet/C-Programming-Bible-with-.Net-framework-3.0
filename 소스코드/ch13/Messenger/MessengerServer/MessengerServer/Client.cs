using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace MessengerServer
{

    // Ŭ���̾�Ʈ�� �α��ε� ��ü ����ڿ��� �޽��� ���	
    public delegate void Send_Message(object sender);
    public delegate void Close_Message(object sender);

    /// <summary>
    /// ������ ������ Ŭ���̾�Ʈ ���
    /// </summary>
    public class Client
    {

        #region ��� ����

        public event Send_Message Send_All;
        public event Close_Message Close_MSG;
        public Msg_Queue msg_queue = null;

        private Socket client = null;
        private MainWnd wnd = null;
        /// <summary>
        /// ����� ���̵�
        /// </summary>
        private string user_id = null;
        /// <summary>
        /// ����� ������
        /// </summary>
        private string client_ip = null;
        /// <summary>
        /// ���� �ð�
        /// </summary>
        private DateTime connecttime;

        private Thread th = null;

        /// <summary>
        /// Ŭ���̾�Ʈ ���� ����
        /// </summary>
        private byte clientstate;

        #endregion


        #region ��� �Ӽ�

        /// <summary>
        /// Ŭ���̾�Ʈ ���� ���� Ȯ��
        /// </summary>
        public bool Connect
        {
            get
            {
                return this.client.Connected;
            }
        }

        /// <summary>
        /// Ŭ���̾�Ʈ ������
        /// </summary>
        public string Client_IP
        {
            get
            {
                return this.client_ip;
            }
        }

        /// <summary>
        /// ����� ���̵�
        /// </summary>
        public string User_ID
        {
            get
            {
                return this.user_id;
            }
        }

        /// <summary>
        /// ���� �ð�
        /// </summary>
        public DateTime ConnectTime
        {
            get
            {
                return this.connecttime;
            }
        }

        /// <summary>
        /// Ŭ���̾�Ʈ ����
        /// </summary>
        public byte ClientState
        {
            set
            {
                this.clientstate = value;
            }
            get
            {
                return this.clientstate;
            }
        }

        #endregion


        #region ��� ������/�Ҹ���

        /// <summary>
        /// Ŭ���̾�Ʈ ������
        /// </summary>
        /// <param name="wnd">����� ���� ǥ��</param>
        /// <param name="client">����</param>
        /// <param name="user_id">����� ���̵�</param>
        public Client(MainWnd wnd, Socket client, string user_id)
        {
            this.client = client;
            this.wnd = wnd;
            this.user_id = user_id;

            IPEndPoint ip = (IPEndPoint)this.client.RemoteEndPoint;
            this.client_ip = ip.Address.ToString();

            this.connecttime = DateTime.Now;

            this.clientstate = (byte)ClientStates.online;   // ó�� �����ϸ� �¶��� ����

            try
            {
                th = new Thread(new ThreadStart(Receive));
                th.IsBackground = true;
                th.Start();
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// Ŭ���̾�Ʈ ���� ����
        /// </summary>
        public void Dispose()
        {
            try
            {
                this.client.Close();

                if (this.th.IsAlive)
                    th.Abort();
            }
            catch
            {
            }
        }

        #endregion


        #region ��� �޼���

        /// <summary>
        /// Ŭ���̾�Ʈ �޽��� ����
        /// </summary>
        public void Receive()
        {
            string message = null;
            string ips = null;

            try
            {
                while (client != null && client.Connected)
                {
                    byte[] data = this.ReceiveData();
                    string msg = Encoding.Default.GetString(data);
                    if (msg != null)
                    {
                        string[] token = msg.Split('\a');
                        switch (Convert.ToByte(token[0].Trim()))
                        {
                            case (byte)MSG.CTOS_MESSAGE_LOGOUT_REQUEST:  // �α� �ƿ� ��û
                                this.msg_queue.Enqueue(token[1].Trim());
                                try
                                {
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_LOGOUT + "\a" + this.user_id.ToString(); // ģ���鿡�� �α׾ƿ� �˸�
                                    ips = this.wnd.ConnectMyFriendToNotify(this.user_id.Trim());  // �α��ε� ģ�� ip ��� ��������
                                    this.wnd.BroadCast(message, ips);// ģ���鿡�� �α׾ƿ� ���� ����

                                    Close_MSG(this);                  // ���� ���� ����
                                }
                                finally
                                {
                                    this.wnd.ConnectRefresh();
                                    this.wnd.Add_MSG(token[1] + "���� �α׾ƿ��߽��ϴ�.");
                                }

                                break;

                            case (byte)MSG.CTOS_MESSAGE_MY_STATES:      // �� ���� ���� 
                                this.clientstate = Convert.ToByte(token[1].Trim());
                                this.wnd.ConnectRefresh();

                                message = (byte)MSG.STOC_MESSAGE_FRIEND_STATES + "\a";
                                message += this.user_id.ToString() + "\a" + (byte)this.clientstate; // ģ�� �α��� �˸� �޽��� 
                                ips = this.wnd.ConnectMyFriendToNotify(this.user_id.Trim());  // �α��ε� ģ�� ip ��� ��������

                                this.wnd.BroadCast(message, ips);// ģ���鿡�� �� ���� ����
                                break;

                            ///// ģ�� ���� ���
                            case (byte)MSG.CTOS_MESSAGE_FRIEND_SEARCH:	  // ģ�� ���̵� �˻�(ģ�� �߰���)						   
                                if (this.wnd.FriendSearch(token[1].Trim()))
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_SEARCH_OK + "\a";// �˻� ����
                                else
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_SEARCH_FAIL + "\a";// �˻� ����
                                this.Send(message);
                                break;

                            case (byte)MSG.CTOS_MESSAGE_FRIEND_ADD:  // ģ�� �߰��ϱ�
                                if (this.wnd.FriendAdd(token[1].Trim(), token[2].Trim(), token[3].Trim()))
                                {
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_ADD_OK + "\a";// ģ�� �߰� ����
                                    message += this.wnd.MyGroupInfo(this.User_ID.Trim()) + "#";
                                    message += this.wnd.MyFriendInfo(this.User_ID.Trim());
                                }
                                else
                                {
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_ADD_FAIL + "\a";// ģ�� �߰� ����
                                }
                                this.Send(message);
                                break;

                            case (byte)MSG.CTOS_MESSAGE_FRIEND_MODIFY:  // ģ�� ���� �����ϱ�
                                if (this.wnd.FriendModify(token[1].Trim(), token[2].Trim(), token[3].Trim()))
                                {
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_MODIFY_OK + "\a";// ģ�� ���� ���� ����
                                    message += this.wnd.MyGroupInfo(this.User_ID.Trim()) + "#";
                                    message += this.wnd.MyFriendInfo(this.User_ID.Trim());
                                }
                                else
                                {
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_MODIFY_FAIL + "\a";// ģ�� ���� ���� ����
                                }
                                this.Send(message);
                                break;

                            case (byte)MSG.CTOS_MESSAGE_FRIEND_REMOVE:  // ģ�� ���� �����ϱ�
                                if (this.wnd.FriendRemove(token[1].Trim(), token[2].Trim(), token[3].Trim()))
                                {
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_REMOVE_OK + "\a";// ģ�� ���� ���� ����
                                    message += this.wnd.MyGroupInfo(this.User_ID.Trim()) + "#";
                                    message += this.wnd.MyFriendInfo(this.User_ID.Trim());
                                }
                                else
                                {
                                    message = (byte)MSG.STOC_MESSAGE_FRIEND_REMOVE_FAIL + "\a";// ģ�� ���� ���� ����
                                }
                                this.Send(message);
                                break;

                            /// �׷� ����							   
                            case (byte)MSG.CTOS_MESSAGE_GROUP_ADD:    // ����� �׷� �߰��ϱ�
                                if (this.wnd.GroupAdd(token[1].Trim(), token[2].Trim())) // ����� ���̵�, �׷��̸�
                                {
                                    message = (byte)MSG.STOC_MESSAGE_GROUP_ADD_OK + "\a";// �׷� ���� ���� ����
                                    message += this.wnd.MyGroupInfo(this.User_ID.Trim()) + "#";
                                    message += this.wnd.MyFriendInfo(this.User_ID.Trim());
                                }
                                else
                                {
                                    message = (byte)MSG.STOC_MESSAGE_GROUP_ADD_FAIL + "\a";// �׷� ���� ���� ����
                                }
                                this.Send(message);
                                break;

                            case (byte)MSG.CTOS_MESSAGE_GROUP_MODIFY:    // ����� �׷� ���� �����ϱ�
                                if (this.wnd.GroupModify(token[1].Trim(), token[2].Trim(), token[3].Trim())) // ����� ���̵�, �׷���̵�, �׷��̸�
                                {
                                    message = (byte)MSG.STOC_MESSAGE_GROUP_MODIFY_OK + "\a";// �׷� ���� ���� ����
                                    message += this.wnd.MyGroupInfo(this.User_ID.Trim()) + "#";
                                    message += this.wnd.MyFriendInfo(this.User_ID.Trim());
                                }
                                else
                                {
                                    message = (byte)MSG.STOC_MESSAGE_GROUP_MODIFY_FAIL + "\a";// �׷� ���� ���� ����
                                }
                                this.Send(message);
                                break;

                            case (byte)MSG.CTOS_MESSAGE_GROUP_REMOVE:    // ����� �׷� ���� �����ϱ�
                                if (this.wnd.GroupRemove(token[1].Trim(), token[2].Trim(), token[3].Trim())) // ����� ���̵�, �׷���̵�, �׷��̸�
                                {
                                    message = (byte)MSG.STOC_MESSAGE_GROUP_REMOVE_OK + "\a";// �׷� ���� ���� ����
                                    message += this.wnd.MyGroupInfo(this.User_ID.Trim()) + "#";
                                    message += this.wnd.MyFriendInfo(this.User_ID.Trim());
                                }
                                else
                                {
                                    message = (byte)MSG.STOC_MESSAGE_GROUP_REMOVE_FAIL + "\a";// �׷� ���� ���� ����
                                }
                                this.Send(message);
                                break;

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
                this.wnd.Add_MSG(ex.Message);
                return null;
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

        #endregion
    }
}
