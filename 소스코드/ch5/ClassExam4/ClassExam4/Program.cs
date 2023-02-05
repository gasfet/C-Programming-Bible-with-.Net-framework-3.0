
using System;
class Example
{
    public readonly int x;       // 읽기 전용 필드
    public const int y = 10;     // 상수 

    public Example(int data)
    {
        x = data;
    }
}

class ClassExam4
{
    static void Main(string[] args)
    {
        Example obj = new Example(20);

        Console.WriteLine("상수 X 값={0}, Y 값={1}", obj.x, Example.y);
    }
}
