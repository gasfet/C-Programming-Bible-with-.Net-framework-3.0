using System;
using System.Collections;

namespace MemberServer
{
	/// <summary>
	/// ClientGroup�� ���� ��� �����Դϴ�.
	/// </summary>
	public class ClientGroup
	{
		Msg_Queue msg_queue = null;
		ArrayList member = null;
		
		/// <summary>
		/// Ŭ���̾�Ʈ �׷� ������
		/// </summary>
		public ClientGroup()
		{
           msg_queue = new Msg_Queue();
		   member = new ArrayList();
		}

		/// <summary>
		/// Ŭ���̾�Ʈ �׷� �Ҹ���
		/// </summary>
		public void Dispose()
		{			
			foreach(Client obj in member)
			{
               obj.Dispose();               
			}			
		}

		/// <summary>
		/// ���� ���ӵ� Ŭ���̾�Ʈ ��
		/// </summary>
		public int Length
		{
			get
			{
				return member.Count;
			}
		}

		/// <summary>
		/// ��� �߰�
		/// </summary>
		/// <param name="client"></param>
		public  void AddMember(Client client)
		{
			client.Send_All += new Send_Message(Send_All);      // BroadCast ȿ��
			client.Close_MSG += new Close_Message(Close_MSG);   // �α׾ƿ� �޽���
            client.msg_queue = msg_queue ;
			member.Add(client);			
		}

		/// <summary>
		/// ��� ����
		/// </summary>
		/// <param name="user_id">����� ���̵�� ����</param>
		public void DeleteMember(string user_id)
		{
			int index = 0;
			foreach(Client obj in member)
			{
				if(obj.User_ID == user_id)				
				{
					obj.Dispose();
					member.RemoveAt(index);				
				}
				index++;
			}
		}
        
		/// <summary>
		/// Send_All �̺�Ʈ�� ���� Ŭ���̾�Ʈ �޽��� ���
		/// </summary>
		/// <param name="sender"></param>
		public void Send_All( object sender )
		{
			string msg = this.msg_queue.Dequeue();

			foreach(Client obj in member)
			{
				if(sender != obj)
					obj.Send(msg);
			}
		}

		public void Close_MSG( object sender )
		{
			string msg = this.msg_queue.Dequeue();
			this.DeleteMember(msg);
		}

		/// <summary>
		/// ������ ������ ��� Ŭ���̾�Ʈ�� �޽��� ���
		/// </summary>
		/// <param name="msg"></param>
		/// <returns></returns>
		public bool BroadCast(string msg)
		{
			try
			{	
				lock(member)
				{				
					foreach(Client obj in member)
					{
						if(obj.Connect)
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
				string [] ip = ips.Split(';'); // ������ �ּҰ� ; ���·� ����
                for(int i = 0 ; i < ip.Length ; i++)
				{
					lock(member)
					{					
						foreach(Client obj in member)
						{
							if((obj.Client_IP == ip[i]) && (obj.Connect))						
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
	}
}
