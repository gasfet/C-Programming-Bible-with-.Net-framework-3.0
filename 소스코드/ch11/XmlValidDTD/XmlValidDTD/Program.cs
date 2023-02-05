using System;
using System.Xml;
using System.Xml.Schema;
class XmlValidDTD
{
   static void Main(string[] args)
    {
        Console.WriteLine("DTD 파일 유효성 검증 시작");
        Console.Write("DTD가 적용된 XML 파일 >>> ");
        string str_dtdname = Console.ReadLine();
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.ValidationType = ValidationType.DTD;
        settings.ProhibitDtd = false;
        settings.ValidationEventHandler +=
               new System.Xml.Schema.ValidationEventHandler(ValidationEventHandler);
        XmlReader reader = XmlReader.Create(str_dtdname, settings);        
        while (reader.Read()) ;
    }
    public static void ValidationEventHandler(object sender, ValidationEventArgs args)
    {
        Console.WriteLine("XML 파일에 문제가 있습니다.");
        if (args.Exception != null)
        {
            Console.WriteLine("err:{0}, {1}-{2}",
                args.Exception.Message,
                args.Exception.LineNumber,
                args.Exception.LinePosition);
        }
        if (args.Severity == XmlSeverityType.Error)
        {
            Console.WriteLine(" => 유효성 검증 에러 발생 !!!");
        }
        else if (args.Severity == XmlSeverityType.Warning)
        {
            Console.WriteLine(" => 스키마가 존재하지 않음 !!!");
        }
    }
}
