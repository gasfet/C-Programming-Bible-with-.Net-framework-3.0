using System;
using System.Net;
class IpInfo
{
    static void Main(string[] args)
    {
        Console.Write(" 주소를 입력 하세요 -> ");
        string str = Console.ReadLine();

        IPAddress[] host = Dns.GetHostAddresses(str);

        Console.WriteLine("호스트 이름: " + Dns.GetHostEntry(host[0]).HostName);
        Console.WriteLine(" 아이피 주소 리스트 :");

        for (int i = 0; i < host.Length; i++)
        {
            IPAddress ip = host[i];
            Console.WriteLine("[{0}]", ip.ToString());
        }
    }
}



