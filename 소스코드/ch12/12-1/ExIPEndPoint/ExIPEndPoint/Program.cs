using System;
using System.Net;
class ExIPEndPoint
{
    static void Main()
    {
        IPAddress ex = IPAddress.Parse("192.168.0.1");
        IPEndPoint ie = new IPEndPoint(ex, 8000);

        Console.WriteLine("ToString()    : {0}", ie.ToString());
        Console.WriteLine("AddressFamily : {0}", ie.AddressFamily);
        Console.WriteLine("Address       : {0}", ie.Address);
        Console.WriteLine("Port          : {0}", ie.Port);
        Console.WriteLine("MaxPort:{0}MinPort:{1}", IPEndPoint.MaxPort, IPEndPoint.MinPort);
    }
}
