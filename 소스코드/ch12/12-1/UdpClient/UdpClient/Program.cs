﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
class UdpClient
{
    static void Main(string[] args)
    {
        byte[] data = new byte[1024];

        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7000);
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
                ProtocolType.Udp);

        data = Encoding.Default.GetBytes("Hello Udp Server !");
        server.SendTo(data, data.Length, SocketFlags.None, ipep);

        Console.WriteLine(" UDP 서버 접속 성공...");

        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
        EndPoint remote = (EndPoint)(sender);

        for (int i = 0; i < 10; i++)  // 데이터 10번 수신
        {
            data = new byte[1024];
            int recv_size = server.ReceiveFrom(data, ref remote);
            Console.WriteLine("{0} : 수신데이터 : {1}", remote.ToString(),
                  Encoding.Default.GetString(data, 0, recv_size));
        }
        server.Close();
    }
}
