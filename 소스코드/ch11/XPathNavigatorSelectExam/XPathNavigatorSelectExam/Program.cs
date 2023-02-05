using System;
using System.Xml;
using System.Xml.XPath;
class XPathNavigatorSelectExam
{
    static void Main(string[] args)
    {
        int index = 0;
        XPathDocument xdoc = new XPathDocument("song.xml");
        XPathNavigator nav = xdoc.CreateNavigator();
        
        XPathNodeIterator iter = nav.Select("songdata/song/title");
        while (iter.MoveNext())
        {
            index++;
            Console.WriteLine("[곡명] " + index + ": " + iter.Current.Value);
        }

        XPathExpression exp = nav.Compile("songdata/song/singer");
        XPathNodeIterator iter2 = nav.Select(exp);

        index = 0;
        while (iter2.MoveNext())
        {
            index++;
            Console.WriteLine("[가수] " + index + ": " + iter2.Current.Value);
        }
    }
}

