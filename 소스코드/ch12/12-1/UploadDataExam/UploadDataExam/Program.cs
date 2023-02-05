using System;
using System.Net;
using System.Text;
class UploadDataExam
{
    static void Main(string[] args)
    {
        byte[] data = Encoding.Default.GetBytes("안녕하세요 *^^* ! ");
        Console.WriteLine("데이터를 보낼 웹 서버 주소을 입력하세요 >> ");
        string addr = Console.ReadLine();

        WebClient wc = new WebClient();
        wc.UploadData(addr, data);
    }
}
