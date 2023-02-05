using System;
using System.Net;
using System.Text;

class DownloadDataExam
{
    static void Main(string[] args)
    {
        Console.WriteLine("읽어올 웹 페이지 주소를 입력하세요. >> ");
        string path = Console.ReadLine();
        WebClient wc = new WebClient();
        byte[] data = wc.DownloadData(path.Trim());
        Console.WriteLine(Encoding.Default.GetString(data));
    }
}
