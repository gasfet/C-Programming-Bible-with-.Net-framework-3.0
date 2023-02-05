using System;
using System.Net;
using System.Collections.Specialized;
using System.Text;
class UploadValuesExam
{
    static void Main(string[] args)
    {
        string addr = "http://localhost/test.aspx";

        NameValueCollection nvc = new NameValueCollection();
        nvc.Add("id", "korea");
        nvc.Add("password", "12345");
        nvc.Add("name", "HongGilDong");

        WebClient wc = new WebClient();
        byte[] data = wc.UploadValues(addr, nvc);

        Console.WriteLine(Encoding.Default.GetString(data));
    }
}
