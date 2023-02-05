using System;
class Example
{
    public static void StaticMethod()
    {
        Console.WriteLine("Static 메서드");
    }
    public void NormalMethod()
    {
        Console.WriteLine("Normal 메서드");
    }
}

delegate void ExamDelegate();

class DelegateExam2
{
    static void Main(string[] args)
    {
        Example obj = new Example();
        ExamDelegate ex1 = new ExamDelegate(obj.NormalMethod);
        ExamDelegate ex2 = new ExamDelegate(Example.StaticMethod);
     // ExamDelegate ex2 = new ExamDelegate(obj.StaticMethod);
        ex1();
        ex2();
    }
}
