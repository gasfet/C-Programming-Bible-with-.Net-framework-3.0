using System;
using System.Text;
using System.Xml;
class XmlDTDWrite
{
   static void Main(string[] args)
   {
       XmlTextWriter xtw = new XmlTextWriter("DTDExam.xml", Encoding.Unicode);
       xtw.Formatting = Formatting.Indented;
       xtw.WriteStartDocument();
       xtw.WriteDocType("songdata", null, "song.dtd", null);
       xtw.WriteComment("DTD 기반의 XML 파일 생성");
       xtw.WriteStartElement("songdata");
       xtw.WriteStartElement("song", null);
       xtw.WriteAttributeString("genre", "ballade");
       xtw.WriteElementString("title", null, "아름다운세상");
       xtw.WriteElementString("singer", null, "박학기");
       xtw.WriteElementString("year", null, "1990");
       xtw.WriteEndElement();   // song       
       xtw.WriteEndDocument();  // songdata
       xtw.Flush();
       xtw.Close();
   }
}
