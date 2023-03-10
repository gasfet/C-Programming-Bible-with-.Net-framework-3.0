using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class UdpServer
{
    static void Main(string[] args)
    {
        byte[] data = new byte[1024];

        IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 7000);
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
                ProtocolType.Udp);

        server.Bind(ipep);
        Console.WriteLine(" UDP 서버 시작...");

        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
        EndPoint remote = (EndPoint)(sender);

        int recv_size = server.ReceiveFrom(data, ref remote);

        Console.WriteLine("{0} : 수신데이터 : {1}", remote.ToString(),
        Encoding.Default.GetString(data, 0, recv_size));

        for (int i = 0; i < 10; i++)
        {
            data = Encoding.Default.GetBytes("Send data :[" + i + "]");
            server.SendTo(data, data.Length, SocketFlags.None, remote);
        }
        server.Close();
    }
}
