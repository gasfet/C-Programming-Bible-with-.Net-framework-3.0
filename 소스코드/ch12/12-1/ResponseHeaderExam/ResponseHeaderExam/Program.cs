using System;
using System.Net;
using System.Collections.Specialized;

class ResponseHeaderExam
{
    static void Main(string[] args)
    {
        Console.WriteLine("웹 페이지 주소를 입력하세요 >> ");
        string addr = Console.ReadLine();

        WebClient wc = new WebClient();
        byte[] data = wc.DownloadData(addr);
        WebHeaderCollection whc = wc.ResponseHeaders;

        Console.WriteLine(addr + " 페이지 HTTP 정보 출력 ");
        Console.WriteLine("헤더 정보 개수 : " + whc.Count);
        for (int i = 0; i < whc.Count; i++)
        {
            Console.WriteLine("{0} = {0}", whc.GetKey(i), whc.Get(i));
        }
    }
}
