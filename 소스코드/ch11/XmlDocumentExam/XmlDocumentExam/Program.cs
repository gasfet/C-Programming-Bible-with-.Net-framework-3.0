using System;
using System.Xml;
class XmlDocumentExam
{
    static void Main(string[] args)
    {
        string xml = "<?xml version='1.0' ?>";
        xml += "<song genre='ballade'>";
        xml += "<title>아름다운세상</title>";
        xml += "<singer>박학기</singer>";
        xml += "<year>1990</year>";
        xml += "</song>";
  
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);
        
        XmlNode root = doc.DocumentElement;

        if(root.HasChildNodes)
        {
            XmlNodeList childnode = root.ChildNodes;
            for(int i = 0; i < childnode.Count; i++)
            {
                XmlNode child = childnode[i];
                Console.WriteLine(child.OuterXml + "의 내용:" + child.InnerText);
            }
        }

        XmlNode firstnode = root.FirstChild;
        Console.WriteLine("first:   " + firstnode.OuterXml);
        XmlNode siblingnode = firstnode.NextSibling;
        Console.WriteLine("sibling: " + siblingnode.OuterXml);
        XmlNode lastnode = root.LastChild;
        Console.WriteLine("lastnode:" + lastnode.OuterXml);
        XmlNode parentnode1 = siblingnode.ParentNode;
        XmlNode parentnode2 = lastnode.ParentNode;
        Console.WriteLine("sibling  Parent: " + parentnode1.Name);
        Console.WriteLine("lastnode Parent: " + parentnode2.Name);

        Console.WriteLine("FirstChild:     " + doc.FirstChild.OuterXml);
        Console.WriteLine("DocumentElement:" + doc.DocumentElement.Name);
        Console.WriteLine(doc.DocumentElement.OuterXml);
        Console.WriteLine(doc.DocumentElement.InnerXml);
 
    }
}