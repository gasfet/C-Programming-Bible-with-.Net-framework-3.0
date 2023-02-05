using System;
using System.IO;
using System.Xml;
class XmlNodeDataDOM
{
    static void Main(string[] args)
    {
        int i ;
        Console.Write("읽어들일 XML 파일명 >>>");
        string str_xmlname = Console.ReadLine();
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load(str_xmlname);
        XmlNodeReader xtr = new XmlNodeReader(xdoc); // XML 열기
        while (xtr.Read())   
        {
            switch (xtr.NodeType)
            {
                case XmlNodeType.Element:
                    Console.WriteLine("<" + xtr.Name + ">");
                    break;
                case XmlNodeType.Text:
                case XmlNodeType.CDATA:
                    Console.WriteLine(xtr.Value);
                    break;
                case XmlNodeType.XmlDeclaration:
                    Console.WriteLine("<?xml version='1.0'?>");
                    break;
                case XmlNodeType.Comment:
                    Console.WriteLine("<!--{0}-->", xtr.Value);
                    break;
                case XmlNodeType.EndElement:
                    Console.WriteLine("</" + xtr.Name + ">");
                    break;
            }
        }
        xtr.Close();        
    }
}
