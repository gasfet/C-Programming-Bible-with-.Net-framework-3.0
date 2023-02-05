using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;
class XPathNavigatorExam
{
    static void Main(string[] args)
    {
        string xml = "<?xml version='1.0'?>";
        xml += "<song genre='ballade'>";
        xml += "<title>아름다운세상</title>";
        xml += "<singer>박학기</singer>";
        xml += "<year>1990</year>";
        xml += "</song>";

        StringReader str = new StringReader(xml);

        XPathDocument doc = new XPathDocument(str);
        XPathNavigator nav = doc.CreateNavigator();
        nav.MoveToRoot();
        Console.WriteLine(nav.NodeType);
        nav.MoveToFirstChild();
        Console.WriteLine(nav.NodeType + ":<" + nav.Name + ">");
        nav.MoveToFirstChild();
        Console.WriteLine(nav.NodeType + ":<" + nav.Name + ">");
        nav.MoveToNext();
        Console.WriteLine(nav.NodeType + ":<" + nav.Name + ">");
        nav.MoveToNext();
        Console.WriteLine(nav.NodeType + ":<" + nav.Name + ">");
        nav.MoveToParent();
        nav.MoveToFirstAttribute();
        Console.WriteLine(nav.NodeType + ":" + nav.Name + "=" + nav.Value);                
    }
}