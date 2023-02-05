using System;
class ClassExam
{
    public ClassExam()
    {
        Console.WriteLine("생성자");
    }
    ~ClassExam()
    {
        Console.WriteLine("소멸자");
    }
    public void Display()
    {
        Console.WriteLine("멤버 메서드 호출");
    }
}

class ClassExam3
{
    static void Main(string[] args)
    {
        ClassExam obj = new ClassExam();
        obj.Display();
    }
}

