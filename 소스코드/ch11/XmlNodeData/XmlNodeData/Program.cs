using System;
using System.IO;
using System.Xml;
class XmlNodeData
{
    static void Main(string[] args)
    {
        int i ;
        Console.Write("읽어들일 XML 파일명 >>>");
        string str_xmlname = Console.ReadLine();
        XmlTextReader xtr = new XmlTextReader(str_xmlname); // XML 열기
        while (xtr.Read())   
        {
            for (i = 0; i < xtr.Depth; i++)
                Console.Write(" ");

            if (xtr.NodeType == XmlNodeType.Element)
            {
                Console.Write("<" + xtr.Name);
                if (xtr.AttributeCount > 0)
                {
                    for (i = 0; i < xtr.AttributeCount; i++)
                    {
                        xtr.MoveToAttribute(i);
                        Console.Write("{0}={1}", xtr.Name, xtr.Value);
                    }
                }
                Console.WriteLine(">");
            }
            else if (xtr.NodeType == XmlNodeType.Text)
            {
                Console.WriteLine(xtr.Value);
            }
            else if(xtr.NodeType == XmlNodeType.EndElement)
            {
                Console.WriteLine("</" + xtr.Name + ">");
            }            
        }
        xtr.Close();
    }
}



