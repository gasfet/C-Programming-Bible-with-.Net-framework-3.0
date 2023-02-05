using System;
using System.Net;
class DownloadFileExam
{
    static void Main(string[] args)
    {
        Console.WriteLine("읽어올 웹페이지를 입력하세요 >> ");
        string addr = Console.ReadLine();
        Console.WriteLine("저장 파일 이름을 입력하세요 >> ");
        string fileName = Console.ReadLine();

        WebClient wc = new WebClient();
        wc.DownloadFile(addr, fileName);

        Console.WriteLine("파일 다운로드 완료!");
    }
}
