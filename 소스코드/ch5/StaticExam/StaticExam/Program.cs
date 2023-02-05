using System;
class Example
{
    public static int i = 10;
    public static void Show()
    {
        Console.WriteLine("Show는 정적 메서드입니다.");
    }
}
class StaticExam
{
    static void Main(string[] args)
    {
        Console.WriteLine("Example.i = {0}", Example.i);
        Example.Show();
    }
}

