using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpClientExample
{
	class Class1
	{
		static void Main(string[] args)
		{
		   IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7000);
	
		   Socket server = new Socket(AddressFamily.InterNetwork,
			                          SocketType.Stream, ProtocolType.Tcp);

           server.Connect(ipep);

           Console.WriteLine("������ ����...");
		
	       byte [] data = new byte[1024];
         
           server.Receive(data);

           Console.WriteLine("���� ������: " + Encoding.Default.GetString(data));

		   server.Send(Encoding.Default.GetBytes("������ ����..."));
          
           server.Close();
		}
	}
}
