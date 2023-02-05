using System;
class DateInfo
{
    public int year, month, day;
    public DateInfo(int year, int month, int day)
    {
        /*
        year = year;
        month = month;
        day = day;
        */
        this.year = year;
        this.month = month;
        this.day = day;
        
        this.Display();
    }
    public void Display()
    {
        Console.WriteLine("{0}/{1}/{2}", year, month, day);
    }    
}
class thisExam
{
    static void Main(string[] args)
    {
        DateInfo obj = new DateInfo(2007, 12, 25);
        obj.Display();
    }
}

