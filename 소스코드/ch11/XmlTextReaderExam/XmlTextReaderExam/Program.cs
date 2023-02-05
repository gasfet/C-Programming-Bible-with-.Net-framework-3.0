using System;
using System.IO;
using System.Xml;
class XmlTextReaderExam
{
    static void Main(string[] args)
    {
        Console.Write("읽어들일 XML 파일명 >>>");
        string str_xmlname = Console.ReadLine();
        XmlTextReader xtr = new XmlTextReader(str_xmlname); // XML 열기
        while (xtr.Read())   
        {
            if (xtr.NodeType == XmlNodeType.Text)
                Console.WriteLine(xtr.Value);
        }
        xtr.Close(); // XmlTextReader 닫기
    }
}
