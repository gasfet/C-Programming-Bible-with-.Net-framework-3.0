using System;
using System.Net;
using System.IO;

class OpenWriteExam
{
    static void Main(string[] args)
    {
        Console.WriteLine("데이터를 보낼 웹 서버 주소을 입력하세요 >> ");
        string addr = Console.ReadLine();

        WebClient wc = new WebClient();

        Stream strm = wc.OpenWrite(addr);
        StreamWriter sw = new StreamWriter(strm);
        sw.WriteLine("데이터 전송...");  // “데이터 전송...” 이란 문자열을 전송
        sw.Close();
        strm.Close();
    }
}
