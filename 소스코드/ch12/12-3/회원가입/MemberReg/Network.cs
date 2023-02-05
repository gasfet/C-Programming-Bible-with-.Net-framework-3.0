using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace MemberReg
{
	/// <summary>
	/// NetWork Ŭ������
	/// 1:1 ä�� ����� �߰��� �����Դϴ�.	
	/// </summary>
	public class Network
	{
		MainWnd wnd = null;      // �α��� â

		Socket server = null;
		Socket client = null;
		Thread th = null;

		string client_ip = null;

		/// <summary>
		/// ������
		/// </summary>
		/// <param name="wnd">ä�� â</param>
		public Network(MainWnd wnd)
		{			
			this.wnd = wnd;			
		}

		/// <summary>
		/// ä�� ������ ���� �õ�
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

				this.wnd.Add_MSG(ip+ "������ ���� ����...");				

				th = new Thread(new ThreadStart(Receive));
				th.Start(); 

				return true;
			}
			catch(Exception ex)
			{
				this.wnd.Add_MSG(ex.Message);
				return false;
			}
		}


        /// <summary>
        /// ä�� ���� ���� ����...
        /// </summary>   
		public void DisConnect()
		{
			try
			{
				if(client != null)
				{
					if( client.Connected ) 
						client.Close();
				
					if(th.IsAlive)
						th.Abort();
				}
				
				this.wnd.Add_MSG("���� ���� ����!");
			}
			catch(Exception ex)
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
				while( client != null && client.Connected )
				{
					byte [] data = this.ReceiveData();                    
					string msg = Encoding.Default.GetString(data);
					string [] token = msg.Split('\a'); 

					switch(token[0].Trim())
					{
						case "STOC_MESSAGE_LOGIN_OK": //���̵� �ߺ���ȸ ��� ��밡��
							System.Windows.Forms.MessageBox.Show("�α��� ����!");
						    break;

						case "STOC_MESSAGE_LOGIN_FAIL":  //���̵� �ߺ���ȸ ��� ���Ұ�
							System.Windows.Forms.MessageBox.Show("���̵�/��й�ȣ Ʋ��!");
							this.DisConnect();
							break;
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
		
		public string Get_MyIP()
		{
			IPHostEntry host = Dns.Resolve(Dns.GetHostName());
			string myip = host.AddressList[0].ToString();
			return myip;
		}

	}
}
