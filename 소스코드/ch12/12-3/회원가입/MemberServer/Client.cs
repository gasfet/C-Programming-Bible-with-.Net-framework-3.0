using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace MemberServer
{
	/// <summary>
	/// 
	/// </summary>

	public delegate void Send_Message( object sender );
	public delegate void Close_Message( object sender );

	public class Client
	{
		public event Send_Message  Send_All;
		public event Close_Message Close_MSG;
		public Msg_Queue msg_queue = null;

		Socket client = null;
		MainWnd wnd = null;
		string user_id = null;

		Thread th = null;
       
		string client_ip = null;

		public bool Connect
		{
			get
			{
				return this.client.Connected;
			}
		}

		public string Client_IP
		{
			get
			{
				return client_ip;
			}
		}

		public string User_ID
		{
			get
			{
				return user_id;
			}
		}

		public Client(Socket client, MainWnd wnd, string user_id)
		{
			this.client = client;
            this.wnd = wnd;
            this.user_id = user_id;

			IPEndPoint ip = (IPEndPoint)this.client.RemoteEndPoint;
			this.client_ip = ip.Address.ToString();

			try
			{			
				th = new Thread(new ThreadStart(Receive));
				th.Start();
			}
			catch(Exception ex)
			{
               this.wnd.Add_MSG(ex.Message);
			}
		}

		public void Dispose()
		{
			try
			{
                if(th.IsAlive)
					th.Abort();
				this.client.Close();
			}
			catch(Exception ex)
			{
				this.wnd.Add_MSG(ex.Message);
			}
		}

		public void Receive()
		{
			try
			{
               while(client != null && client.Connected)  
			   {
				   byte [] data = this.ReceiveData();
				   string msg = Encoding.Default.GetString(data);
				   if(msg != null)
				   {
					   string [] token = msg.Split('\a');
					   switch(token[0])
					   {
						   case "CTOS_MESSAGE_END":
							   this.msg_queue.Enqueue(token[1].Trim());
							   Close_MSG(this);
							   this.wnd.Add_MSG(token[1] + "���� �α׾ƿ��߽��ϴ�.");
							   //this.wnd.Delete_listView(token[1].Trim()); // ����Ʈ�信�� ����
							   break;

						   default:
							   this.msg_queue.Enqueue(msg);
							   Send_All(this);
							   break;
					   }
				   }

			   }
			}
			catch(Exception ex)
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
				if( client.Connected )
				{
					byte [] data = Encoding.Default.GetBytes(msg);
					this.SendData(data);
				}
				else
				{
					this.wnd.Add_MSG("�޽��� ���� ����!");
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
				left_data = size ;

				byte [] data = new byte[size];
				// �������� ������ ���� ������ ����
				while(total < size)
				{
					recv_data = this.client.Receive(data, total, left_data, 0);
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
		/// ������ ����
		/// </summary>
		/// <param name="data">������ ������</param>
		private void SendData(byte[] data)
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
				send_data = this.client.Send(data_size);			
				
				// ���� ������ ����
				while(total < size)
				{  
					send_data  = this.client.Send(data, total, left_data, SocketFlags.None);
					total     += send_data;
					left_data -= send_data;
				}
			}
			catch(Exception ex)
			{
				this.wnd.Add_MSG(ex.Message);
			}
		}	
		
	}
}
