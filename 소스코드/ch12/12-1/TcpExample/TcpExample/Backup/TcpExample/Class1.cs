using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpExample
{
	class TcpServer
	{	
		static void Main(string[] args)
		{
			IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 7000);
			Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			server.Bind(ipep);
            server.Listen(20);

			Console.WriteLine("서버 시작... 클라이언트 접속 대기중...");
 
			Socket client = server.Accept();

			IPEndPoint ip = (IPEndPoint)client.RemoteEndPoint;
			Console.WriteLine("{0}주소, {1}포트 접속", ip.Address, ip.Port);

			byte [] data = Encoding.Default.GetBytes("환영합니다.*^^*");

			client.Send(data, data.Length, SocketFlags.None);

			data = new byte[1024];

			if( client.Receive(data) != 0)
				Console.WriteLine("수신 메시지: " + Encoding.Default.GetString(data));
			else
				Console.WriteLine("수신 데이터 없음...");

			client.Close();
			server.Close();         
			
	}
	}
}
