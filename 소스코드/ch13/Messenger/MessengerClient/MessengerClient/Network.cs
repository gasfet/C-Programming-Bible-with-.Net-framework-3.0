using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Collections;
using System.Data;

namespace MessengerClient
{
    /// <summary>
    /// ä�� ������ ����ϴ� NetWork Ŭ����	
    /// </summary>
    public class Network
    {
        #region ��� ����/������

        private MainWnd wnd = null;      // �α��� â

        private Socket client = null;
        private Thread th = null;

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="wnd">ä�� â</param>
        public Network(MainWnd wnd)
        {
            this.wnd = wnd;
        }

        #endregion

        #region ��� ����

        /// <summary>
        /// �޽��� ������ ���� �õ�
        /// </summary>
        /// <param name="ip">������ ���� ������</param>
        /// <returns>���� ����</returns>
        public bool Connect(string ip)
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 7007);  // ä�� ���� ���� ����
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                client.Connect(ipep);

                this.wnd.Add_MSG(ip + "������ ���� ����...");

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

                this.wnd.Add_MSG("���� ���� ����!");
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
                        case (byte)MSG.STOC_MESSAGE_LOGIN_OK: // ���̵� �ߺ���ȸ ��� ��밡��
                            this.LoginOK(token[1].Trim());    // �α��� ó��							
                            //System.Windows.Forms.MessageBox.Show("�α��� ����!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_LOGIN_FAIL:  //���̵� �ߺ���ȸ ��� ���Ұ�
                            System.Windows.Forms.MessageBox.Show("���̵�/��й�ȣ Ʋ��!");
                            this.DisConnect();
                            break;

                        case (byte)MSG.STOC_MESSAGE_BROADCAST:  // ���� ��� �޽��� ����
                            this.wnd.NotifyPopup(token[1].Trim(), token[2].Trim());
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_LOGIN:  // ģ�� �α��� ���� ����
                            string title = token[1].Trim() + "�� �α���";
                            string content = "ģ������ " + DateTime.Now.ToShortTimeString() + "�� �α��� �ϼ̽��ϴ�.!";
                            this.wnd.NotifyPopup(title, content);
                            this.UpdateData(token[1].Trim(), token[2].Trim()); // ģ������ ������Ʈ
                            this.wnd.Update_TreeFriend(token[1].Trim(), (byte)ClientStates.online); // �¶������� ǥ��
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_LOGOUT: // ģ�� �α׾ƿ� ���� ����
                            this.wnd.Update_TreeFriend(token[1].Trim(), (byte)ClientStates.offline); // �¶������� ǥ��                           
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_STATES: // ģ�� ���� ���� ��ȭ
                            // ģ�� ���̵� : token[1]
                            // ģ�� ���� ���� : token[2]
                            this.wnd.Update_TreeFriend(token[1].Trim(), Convert.ToByte(token[2].Trim()));
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_SEARCH_OK:// ����� �˻� ����
                            this.wnd.FRIENDWND.FriendUserOK();
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_SEARCH_FAIL: // ����� �˻� ����
                            this.wnd.FRIENDWND.FriendUserFail();
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_ADD_OK:      // ģ�� �߰� ����
                            this.wnd.TREE_FRIEND.Nodes.Clear();
                            this.wnd.TBL_FRIEND.Rows.Clear();
                            this.wnd.TBL_GROUP.Rows.Clear();
                            this.LoginOK(token[1].Trim());              // ģ�� �߰� ����
                            this.wnd.FRIENDWND.FriendWndMessage("ģ�� �߰� ����!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_ADD_FAIL:     // ģ�� �߰� ����
                            this.wnd.FRIENDWND.FriendWndMessage("ģ�� �߰� ����!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_MODIFY_OK:      // ģ�� ���� ���� ����
                            this.wnd.TREE_FRIEND.Nodes.Clear();
                            this.wnd.TBL_FRIEND.Rows.Clear();
                            this.wnd.TBL_GROUP.Rows.Clear();
                            this.LoginOK(token[1].Trim());                 // ģ�� ���� ���� ����
                            this.wnd.FRIENDWND.FriendWndMessage("ģ�� ���� ���� ����!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_MODIFY_FAIL:     // ģ�� ���� ���� ����
                            this.wnd.FRIENDWND.FriendWndMessage("ģ�� ���� ���� ����!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_REMOVE_OK:      // ģ�� ���� ���� ����
                            this.wnd.TREE_FRIEND.Nodes.Clear();
                            this.wnd.TBL_FRIEND.Rows.Clear();
                            this.wnd.TBL_GROUP.Rows.Clear();
                            this.LoginOK(token[1].Trim());                 // ģ�� ���� ���� ����
                            this.wnd.FRIENDWND.FriendWndMessage("ģ�� ���� ���� ����!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_FRIEND_REMOVE_FAIL:     // ģ�� ���� ���� ����
                            this.wnd.FRIENDWND.FriendWndMessage("ģ�� ���� ���� ����!");
                            break;

                        /// �׷� ó��							
                        case (byte)MSG.STOC_MESSAGE_GROUP_ADD_OK:
                            this.wnd.TREE_FRIEND.Nodes.Clear();
                            this.wnd.TBL_FRIEND.Rows.Clear();
                            this.wnd.TBL_GROUP.Rows.Clear();
                            this.LoginOK(token[1].Trim());                 // �׷� ���� �߰� ����
                            this.wnd.GROUPWND.GroupWndMessage("�׷� ���� �߰� ����!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_GROUP_ADD_FAIL:
                            this.wnd.GROUPWND.GroupWndMessage("�׷� ���� �߰� ����!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_GROUP_MODIFY_OK:
                            this.wnd.TREE_FRIEND.Nodes.Clear();
                            this.wnd.TBL_FRIEND.Rows.Clear();
                            this.wnd.TBL_GROUP.Rows.Clear();
                            this.LoginOK(token[1].Trim());                 // �׷� ���� ���� ����
                            this.wnd.GROUPWND.GroupWndMessage("�׷� ���� ���� ����!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_GROUP_MODIFY_FAIL:
                            this.wnd.GROUPWND.GroupWndMessage("ģ�� ���� ���� ����!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_GROUP_REMOVE_OK:
                            this.wnd.TREE_FRIEND.Nodes.Clear();
                            this.wnd.TBL_FRIEND.Rows.Clear();
                            this.wnd.TBL_GROUP.Rows.Clear();
                            this.LoginOK(token[1].Trim());                 // �׷� ���� ���� ����
                            this.wnd.GROUPWND.GroupWndMessage("�׷� ���� ���� ����!");
                            break;

                        case (byte)MSG.STOC_MESSAGE_GROUP_REMOVE_FAIL:
                            this.wnd.GROUPWND.GroupWndMessage("�׷� ���� ���� ����!");
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
        /// ����� ������ ����
        /// </summary>
        /// <param name="id">����� ���̵�</param>
        /// <param name="ip">����� ������</param>
        private void UpdateData(string id, string ip)
        {
            try
            {
                DataRow[] rows = this.wnd.TBL_FRIEND.Select("id='" + id.Trim() + "'");
                if (rows.Length > 0)
                {
                    int i = 0;
                    for (i = 0; i < this.wnd.TBL_FRIEND.Rows.Count; i++)
                    {
                        if ((this.wnd.TBL_FRIEND.Rows[i]["id"] == rows[0]["id"]))
                        {
                            break;
                        }
                    }

                    DataRow temp = this.wnd.TBL_FRIEND.Rows[i];
                    temp.BeginEdit();
                    temp["ip"] = ip.Trim();
                    temp["state"] = (byte)ClientStates.online;
                    temp.EndEdit();
                }
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG("ģ�� ������ �ּ� ���� ���� : " + ex.Message);
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
        /// �ڽ��� ������ ��ȣ �˾Ƴ���
        /// </summary>
        /// <returns></returns>
        public string GetMyIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string myip = host.AddressList[0].ToString();
            return myip;
        }

        /// <summary>
        /// �α��� �������� ��� ó���� ����
        /// Ʈ���� �׸���
        /// </summary>
        /// <param name="msg">�׷��̸� + # + �׷� ���̵�, ����� ���̵�, ����� ������, ...</param>
        private void LoginOK(string msg)
        {
            try
            {
                string[] token = msg.Split('#');

                /// �׷� �̸��� �����ϱ�
                if (token[0].Trim() != "NOT_GROUPNAME")  // �׷� �̸��� �ִٸ�
                {
                    string[] group_name = token[0].Split('@');

                    for (int i = 0; i < group_name.Length - 1; i += 2)
                    {
                        DataRow row = this.wnd.TBL_GROUP.NewRow();
                        row["group_name"] = group_name[i];
                        row["group_id"] = Convert.ToInt32(group_name[i + 1].Trim());
                        this.wnd.TBL_GROUP.Rows.Add(row);
                    }

                }

                this.wnd.Add_treeGroupName();   // ģ�� �׷� ��� ����ϱ�

                this.wnd.Refresh_TreeFriend();  // Ʈ���� �����ϱ�

                /// ������ �����ϱ�
                if (token[1].Trim() != "NOT_FRIEND")  // ģ�� ������ �ִٸ�
                {
                    string[] temp = token[1].Split('$');  //�׷���̵�+����+������+���̵�+�̸�+��Ī+���ڸ���

                    for (int i = 0; i < temp.Length - 1; i += 7)
                    {
                        this.wnd.Add_treeFriend(temp[i], temp[i + 1], temp[i + 2], temp[i + 3], temp[i + 4], temp[i + 5], temp[i + 6]);

                        DataRow row = this.wnd.TBL_FRIEND.NewRow();
                        row["id"] = temp[i + 3];
                        row["name"] = temp[i + 4];
                        row["nickname"] = temp[i + 5];
                        row["email"] = temp[i + 6];
                        row["ip"] = temp[i + 2];
                        row["state"] = Convert.ToByte(temp[i + 1].Trim());
                        row["group_id"] = temp[i];
                        this.wnd.TBL_FRIEND.Rows.Add(row);

                    }
                }
                else   // ģ�� ������ ���ٸ�
                {
                    this.wnd.Add_treeFriend(null, null, null, null, null, null, null);
                }

            }

            catch (Exception ex)
            {
                this.wnd.Add_MSG("�α��� ó�� ���� : " + ex.Message);
            }

        }

        #endregion

    }
}
