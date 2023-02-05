using System;
using System.Collections;

namespace MemberServer
{
	/// <summary>
	/// ClientGroup에 대한 요약 설명입니다.
	/// </summary>
	public class ClientGroup
	{
		Msg_Queue msg_queue = null;
		ArrayList member = null;
		
		/// <summary>
		/// 클라이언트 그룹 생성자
		/// </summary>
		public ClientGroup()
		{
           msg_queue = new Msg_Queue();
		   member = new ArrayList();
		}

		/// <summary>
		/// 클라이언트 그룹 소멸자
		/// </summary>
		public void Dispose()
		{			
			foreach(Client obj in member)
			{
               obj.Dispose();               
			}			
		}

		/// <summary>
		/// 현재 접속된 클라이언트 수
		/// </summary>
		public int Length
		{
			get
			{
				return member.Count;
			}
		}

		/// <summary>
		/// 멤버 추가
		/// </summary>
		/// <param name="client"></param>
		public  void AddMember(Client client)
		{
			client.Send_All += new Send_Message(Send_All);      // BroadCast 효과
			client.Close_MSG += new Close_Message(Close_MSG);   // 로그아웃 메시지
            client.msg_queue = msg_queue ;
			member.Add(client);			
		}

		/// <summary>
		/// 멤버 제거
		/// </summary>
		/// <param name="user_id">사용자 아이디로 제거</param>
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
		/// Send_All 이벤트를 통한 클라이언트 메시지 방송
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
		/// 서버에 접속한 모든 클라이언트에 메시지 방송
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
		/// 지정된 아이피 그룹에게만 문자열 방송
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="ips"></param>
		/// <returns></returns>
		public bool BroadCast(string msg, string ips)
		{
			try
			{
				string [] ip = ips.Split(';'); // 아이피 주소가 ; 형태로 들어옴
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
