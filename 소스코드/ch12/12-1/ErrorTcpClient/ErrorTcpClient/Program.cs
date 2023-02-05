using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class ErrorTcpClient
{
    static void Main(string[] args)
    {
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7000);
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                         ProtocolType.Tcp);

        server.Connect(ipep);

        for (int i = 0; i < 10; i++)
        {   // 서버에  send data :0~9 문자열을 10번 전송
            server.Send(Encoding.Default.GetBytes("send data :" + i));
        }

        server.Close();
    }
}

