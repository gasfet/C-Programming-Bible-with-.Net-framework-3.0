using System;
using System.Net;
using System.IO;
class UploadFileExam
{
    static void Main(string[] args)
    {
        Console.WriteLine("데이터를 보낼 웹 서버 주소을 입력하세요 >> ");
        string addr = Console.ReadLine();

        Console.WriteLine("업로드할 파일이름을 입력하세요 >> ");
        string fileName = Console.ReadLine();

        WebClient wc = new WebClient();
        wc.UploadFile(addr, fileName);
    }
}

