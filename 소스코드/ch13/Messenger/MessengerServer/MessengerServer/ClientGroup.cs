using System;
using System.Collections;

namespace MessengerServer
{
    /// <summary>
    /// ClientGroup�� ���� ��� �����Դϴ�.
    /// </summary>
    public class ClientGroup
    {
        #region ��� ����/�Ӽ�

        private Msg_Queue msg_queue = null;
        private ArrayList member = null;

        /// <summary>
        /// ���� ���ӵ� Ŭ���̾�Ʈ ��
        /// </summary>
        public int Length
        {
            get
            {
                return this.member.Count;
            }
        }

        public ArrayList Member
        {
            get
            {
                return this.member;
            }
        }

        #endregion


        #region ��� ������/�Ҹ���

        /// <summary>
        /// Ŭ���̾�Ʈ �׷� ������
        /// </summary>
        public ClientGroup()
        {
            this.msg_queue = new Msg_Queue();
            this.member = new ArrayList();
        }

        /// <summary>
        /// Ŭ���̾�Ʈ �׷� �Ҹ���
        /// </summary>
        public void Dispose()
        {
            try
            {
                foreach (Client obj in this.member)
                {
                    obj.Dispose();
                }
            }
            catch
            {
            }
        }

        #endregion


        #region ��� �޼���

        /// <summary>
        /// ��� �߰�
        /// </summary>
        /// <param name="client"></param>
        public void AddMember(Client client)
        {
            try
            {
                lock (this.member)
                {
                    client.Send_All += new Send_Message(Send_All);      // BroadCast ȿ��
                    client.Close_MSG += new Close_Message(Close_MSG);   // �α׾ƿ� �޽���
                    client.msg_queue = this.msg_queue;
                    this.member.Add(client);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// ��� ����
        /// </summary>
        /// <param name="user_id">����� ���̵�� ����</param>
        public void DeleteMember(string user_id)
        {
            try
            {
                lock (this.member)
                {
                    int index = 0;
                    foreach (Client obj in this.member)
                    {
                        if (obj.User_ID == user_id)
                        {
                            this.member.RemoveAt(index);
                            obj.Dispose();
                        }
                        index++;
                    }
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// ��� ��ü ����
        /// </summary>		
        public void DeleteAllMember()
        {
            try
            {
                int index = 0;
                lock (this.member)
                {
                    foreach (Client obj in this.member)
                    {
                        this.member.RemoveAt(index);
                        try
                        {
                            obj.Dispose();
                        }
                        catch
                        {
                        }
                        index++;
                    }
                    this.member.Clear();
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// Send_All �̺�Ʈ�� ���� Ŭ���̾�Ʈ �޽��� ���
        /// </summary>
        /// <param name="sender"></param>
        public void Send_All(object sender)
        {
            try
            {
                lock (this.member)
                {
                    string msg = this.msg_queue.Dequeue();

                    foreach (Client obj in this.member)
                    {
                        if (sender != obj)
                            obj.Send(msg);
                    }
                }
            }
            catch
            {
            }
        }

        public void Close_MSG(object sender)
        {
            string msg = this.msg_queue.Dequeue();
            this.DeleteMember(msg);
        }

        /// <summary>
        /// ������ ������ ��� Ŭ���̾�Ʈ�� �޽��� ���
        /// </summary>
        /// <param name="msg">����� �޽���</param>
        /// <returns>���� ����</returns>
        public bool BroadCast(string msg)
        {
            try
            {
                lock (this.member)
                {
                    foreach (Client obj in this.member)
                    {
                        if (obj.Connect)
                            obj.Send(msg);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// ������ ������ �׷쿡�Ը� ���ڿ� ���
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ips"></param>
        /// <returns></returns>
        public bool BroadCast(string msg, string ips)
        {
            try
            {
                string[] ip = ips.Split(';'); // ������ �ּҰ� ; ���·� ����
                for (int i = 0; i < ip.Length; i++)
                {
                    lock (this.member)
                    {
                        foreach (Client obj in this.member)
                        {
                            if ((obj.Client_IP == ip[i]) && (obj.Connect))
                                obj.Send(msg);
                        }
                    }

                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

    }
}
