using System;
using System.Xml;
using System.Xml.Schema;
class XmlValidSchema
{
   static void Main(string[] args)
    {
        Console.WriteLine("Schema 파일 유효성 검증 시작");
        Console.Write("Schema 파일 >>> ");
        string str_schema = Console.ReadLine();
        Console.Write("XML 파일 이름 >>> ");
        string str_schemadata = Console.ReadLine();

        XmlReaderSettings xrs = new XmlReaderSettings();
        //xrs.Schemas.Add("song.xsd", str_schema);
        xrs.Schemas.Add(null, str_schema);
        xrs.ValidationType = ValidationType.Schema;
        xrs.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);

        XmlReader xr = XmlReader.Create(str_schemadata, xrs);
        Console.WriteLine(str_schemadata + " 파일 유효성 검사 시작!!!");
        while (xr.Read()) ;
        xr.Close();
        Console.WriteLine(str_schemadata + " 파일 유효성 검사 완료!!!");
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

