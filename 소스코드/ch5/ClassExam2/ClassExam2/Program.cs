
// 생성자 오버로딩 예제

using System;

class Example
{
    public Example()
    {
        Console.WriteLine("생성자 1");
    }
    public Example(int data)
    {
        Console.WriteLine("생성자 2 :" + data);
    }
    public Example(string str)
    {
        Console.WriteLine("생성자 3 :" + str);
    }
    public Example(double a, float b)
    {
        Console.WriteLine("생성자 4 : " + (a + b));
    }
}

class ClassExam2
{
    static void Main(string[] args)
    {
        Example obj1 = new Example();
        Example obj2 = new Example(100);
        Example obj3 = new Example("안녕하세요");
        Example obj4 = new Example(10.5, 0.5f);
    }
}
