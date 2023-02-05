
using System;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;

using System.Text;

namespace MemberServer
{
	/// <summary>
	/// Server�� ���� ��� �����Դϴ�.
	/// </summary>
	
	class Server
	{
		MainWnd wnd = null;
		int port = 7007;

		Socket server = null;		
		Thread th = null;

		ClientGroup cgroup = null;


		public Server(MainWnd wnd, int port)
		{
			this.wnd = wnd;
			this.port = port;			
		}	

        
		public void ServerStart()
		{
			try
			{	
				cgroup = new ClientGroup(); // Ŭ���̾�Ʈ �׷� ������ ȣ��

				th = new Thread(new ThreadStart(AcceptClient));
				th.Start();
			}
			catch(Exception ex)
			{
				this.wnd.Add_MSG(ex.Message);
			}
		}

		public void ServerStop()
		{
           try
		   {
			   cgroup.Dispose(); // Ŭ���̾�Ʈ �׷� �Ҹ��� ȣ��

               if(th.IsAlive)
			   {
				   th.Abort();
			   }
			   server.Close();
		   }
		   catch(Exception ex)
		   {
			   this.wnd.Add_MSG(ex.Message);
		   }
		}


		public void AcceptClient()
		{
			try
			{			
				IPEndPoint ipep = new IPEndPoint(IPAddress.Any, this.port);
				server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				server.Bind(ipep);
				server.Listen(20);

				while(true)
				{
					Socket client = server.Accept();
					IPEndPoint ip = (IPEndPoint)client.RemoteEndPoint;
					this.wnd.Add_MSG(ip.Address + "����...");

					if( client.Connected )
					{
						ClientConnect(client);  // ����ó�� (1, �α���, 2. ȸ������)
					}
						
				}

			}
			catch(Exception ex)
			{
				this.wnd.Add_MSG(ex.Message);
			}
		}


		public bool BroadCast(string msg)
		{
			return cgroup.BroadCast(msg);
		}

		public bool BroadCast(string msg, string ips)
		{
			return cgroup.BroadCast(msg, ips);
		}

		public void DeleteClient(string ip)
		{
			cgroup.DeleteMember(ip);
		}

		
		
		/// <summary>
		/// ������ ����
		/// </summary>
		/// <param name="data">������ ������</param>
		private void SendData(byte[] data, Socket client)
		{
			try
			{		 
				int total = 0;
				int size = data.Length;
				int left_data = size ;
				int send_data = 0;

				// ������ ���� �������� ũ�� ����
				byte [] data_size =new byte[4];
				data_size = BitConverter.GetBytes(size);
				send_data = client.Send(data_size);			
				
				// ���� ������ ����
				while(total < size)
				{  
					send_data  = client.Send(data, total, left_data, SocketFlags.None);
					total     += send_data;
					left_data -= send_data;
				}
			}
			catch(Exception ex)
			{
				this.wnd.Add_MSG(ex.Message);
			}
		}

	
		/// <summary>
		/// ������ ����
		/// </summary>		
		/// <returns>������ ������ �迭</returns>
		private byte[] ReceiveData(Socket client)
		{
			try
			{
				int total = 0;
				int size = 0;
				int left_data = 0;
				int recv_data = 0;

				// ������ ������ ũ�� �˾Ƴ���   
				byte[] data_size = new byte[4];  
				recv_data = client.Receive(data_size, 0, 4, SocketFlags.None);
				size = BitConverter.ToInt32(data_size, 0);
				left_data = size ;

				byte [] data = new byte[size];
				// �������� ������ ���� ������ ����
				while(total < size)
				{
					recv_data = client.Receive(data, total, left_data, SocketFlags.None);
					if(recv_data == 0) break;
					total     += recv_data ;
					left_data -= recv_data;
				}
				return data;
			}
			catch(Exception ex)
			{
				this.wnd.Add_MSG(ex.Message);
				return null;
			}
		}


		/// <summary>
		/// �α��� ó�� �Լ�
		/// </summary>
		/// <param name="user_id">����� ���̵�</param>
		/// <param name="user_pwd">����� ��й�ȣ</param>
		/// <returns>�α��� ��������</returns>
		private bool LoginProcess(string user_id, string user_pwd)
		{
			return this.wnd.MemberCheck(user_id, user_pwd);			
		}

		/// <summary>
		/// ȸ�� ����
		/// </summary>
		/// <param name="member_info">ȸ����������</param>
		private bool RegisterMember(string member_info)
		{
			return this.wnd.InsertMember(member_info);
		}

		/// <summary>
		/// ����� ���̵� ��ȸ
		/// </summary>
		/// <param name="user_id">���̵� ��ȸ</param>
		private bool SearchID(string user_id)
		{
			return this.wnd.SearchID(user_id.Trim());
		}

		/// <summary>
		/// �����ȣ ��� ��ȯ
		/// </summary>
		/// <param name="addr">��ȸ�� �ּ�(���̸�)</param>
		/// <param name="client">���� ����</param>
		private void ZipcodeInfo(string addr, Socket client)
		{
			string msg = null;

			msg += this.wnd.ZicodeLoad(addr);

			if( msg != "") // �˻��� �����ּ� ���� ���
				msg = "STOC_MESSAGE_REGISTER_ZIPCODEDATA\a" + msg;
			else           // �˻��� �����ּ� ���� ���
				msg = "STOC_MESSAGE_REGISTER_ZIPCODERR\a";

			byte [] data = Encoding.Default.GetBytes(msg);
			this.SendData(data, client); // �����ȣ ��� ��ȯ
		}

		/// <summary>
		/// Ŭ���̾�Ʈ ���� ó��
		/// 1. �α��� ó��
		/// 2. ȸ�� ���� ó��
		/// </summary>
		/// <param name="client"></param>
		private void ClientConnect(Socket client)
		{
			byte [] data = this.ReceiveData(client);
			string msg = Encoding.Default.GetString(data);

			string [] token = msg.Split('\a');   // Ŭ���̾�Ʈ�� ���� ������ �м�
						
			switch(token[0]) 
			{						
				case "CTOS_MESSAGE_LOGIN_REQUEST": // �޽���+���̵�+��й�ȣ
					if(LoginProcess(token[1].Trim(), token[2].Trim()))   // �α��� ó��(token[1]-���̵�,token[2]-��й�ȣ
					{
						// ���� �ν��Ͻ�, â ����, �α��� ���̵�
						Client obj = new Client( client, this.wnd, token[1].Trim() ); // Ŭ���̾�Ʈ �׷쿡 �߰�
						cgroup.AddMember(obj);         // ���� �׷쿡 ������ �߰�						
						
                        IPEndPoint ip = (IPEndPoint)client.RemoteEndPoint;
						this.wnd.ConnectMember(token[1], ip.Address.ToString());  // Ŭ���̾�Ʈ ���� �α� ����

						data = Encoding.Default.GetBytes("STOC_MESSAGE_LOGIN_OK");						
					}
					else                               // �α��� ����
					{
						data = Encoding.Default.GetBytes("STOC_MESSAGE_LOGIN_FAIL");						
					}
					this.SendData(data, client); 

					break;

				case "CTOS_MESSAGE_REGISTER_REQUEST":   // ȸ�� ���� ó�� + ȸ����������
					if(RegisterMember(token[1].Trim())) // ȸ�� ���� ����
					{
						data = Encoding.Default.GetBytes("STOC_MESSAGE_REGISTER_OK");						
					}
					else                               // ȸ�� ���� ����
					{
						data = Encoding.Default.GetBytes("STOC_MESSAGE_REGISTER_FAIL");						
					}    
					this.SendData(data, client);        
					break;

				case "CTOS_MESSAGE_REGISTER_IDSEARCH":  // ���̵� ��� ��ȸ + ���̵�
					if(!SearchID(token[1].Trim()))      // ���̵� ��� ����
					{
						data = Encoding.Default.GetBytes("STOC_MESSAGE_REGISTER_IDYES");
					}
					else                                // ���̵� ��� �Ұ�
					{
						data = Encoding.Default.GetBytes("STOC_MESSAGE_REGISTER_IDNO");
					}
					this.SendData(data, client); 
					break;

				case "CTOS_MESSAGE_REGISTER_ZIPCODE":   // �����ȣ ��ȸ + ��ȸ�� ���ڿ�(���̸�)
					ZipcodeInfo(token[1].Trim(), client);       // �����ȣ ��� ����
					break;
			}          
             
		}

        
	}		
}
