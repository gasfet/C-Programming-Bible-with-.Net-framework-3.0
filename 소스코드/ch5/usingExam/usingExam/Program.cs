using System;
class DateInfo : IDisposable
{
    public int year, month, day;
    public void Display()
    {
        Console.WriteLine("{0}/{1}/{2}", year, month, day);
    }
    public void Dispose()
    {
        Console.WriteLine("Dispose 메서드 실행");
    }
}
class usingExam
{
    static void Main(string[] args)
    {
        using (DateInfo obj = new DateInfo())
        {
            obj.year = 2007;
            obj.month = 12;
            obj.day = 25;
            obj.Display();
        }
        Console.WriteLine("using 문 종료");
    }
}

