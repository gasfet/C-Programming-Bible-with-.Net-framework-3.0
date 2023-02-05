using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
class ErrorTcpSvr
{
    static void Main(string[] args)
    {
        IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 7000);
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                                   ProtocolType.Tcp);

        server.Bind(ipep);
        server.Listen(20);

        Socket client = server.Accept();

        int recv_size;
        byte[] data = new byte[1024];

        for (int i = 0; i < 10; i++)
        {                                         // TCP 버퍼에서 
            recv_size = client.Receive(data);     // 1024 버퍼로 10번 데이터 읽어오기
            Console.WriteLine(Encoding.Default.GetString(data, 0, recv_size));
        }

        client.Close();
        server.Close();
    }
}

