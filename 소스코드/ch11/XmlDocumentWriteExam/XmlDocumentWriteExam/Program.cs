using System;
using System.Xml;

class XmlDocumentWriteExam
{
   static void Main(string[] args)
   {
       XmlDocument xdoc = new XmlDocument();
       xdoc.Load("song.xml");
       XmlElement genre = xdoc.CreateElement("song");
       genre.SetAttribute("genre", "jazz");

       XmlElement title = xdoc.CreateElement("title");
       title.InnerText = "Plastico";
       genre.AppendChild(title);

       XmlElement singer = xdoc.CreateElement("singer");
       singer.InnerText = "Willie Colon";
       genre.AppendChild(singer);

       XmlElement year = xdoc.CreateElement("year");
       year.InnerText = "2000";
       genre.AppendChild(year);

       xdoc.DocumentElement.AppendChild(genre);

       XmlTextWriter xtw = new XmlTextWriter("song_add.xml", null);
       xtw.Formatting = Formatting.Indented;
       xdoc.WriteContentTo(xtw);
       xtw.Close();
   }
}
