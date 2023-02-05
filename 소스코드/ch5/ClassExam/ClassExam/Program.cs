using System;
class Example
{
    public int data;
    public const double PI = 3.141517;
    public Example()
    {
        Console.WriteLine("Example 생성자");
        data = 10;
    }
    public void Display()
    {
        Console.WriteLine("클래스 메서드 호출");
    }
}

class ClassExam
{
    static void Main(string[] args)
    {
        Example obj = new Example();
        Console.WriteLine("data = {0}, PI = {1}", obj.data, Example.PI);
        Console.WriteLine("Example 클래스 Display 메서드 호출");
        obj.Display();
    }
}
