using System;
using System.Net;
class IpInfo
{
    static void Main(string[] args)
    {

        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
    string myip = host.AddressList[0].ToString();
    Console.WriteLine("{0} => ", myip);


        /*
        Console.Write(" 주소를 입력 하세요 -> ");
        string str = Console.ReadLine();
        IPHostEntry host = Dns.GetHostEntry(str);
        Console.WriteLine("호스트 이름: " + host.HostName);
        Console.WriteLine(" 아이피 주소 리스트 :");

        for (int i = 0; i < host.AddressList.Length; i++)
        {
            IPAddress ip = host.AddressList[i];
            Console.WriteLine("[{0}]", ip.ToString());
        }
         */
    }
}

