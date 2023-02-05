using System;
class A
{
    public A()
    {
        Console.WriteLine("A클래스 생성자");
    }
    ~A()
    {
        Console.WriteLine("A클래스 소멸자");
    }
}
class B : A
{
    public B()
    {
        Console.WriteLine("B클래스 생성자");
    }
    ~B()
    {
        Console.WriteLine("B클래스 소멸자");
    }
}
class C : B
{
    public C()
    {
        Console.WriteLine("C클래스 생성자");
    }
    ~C()
    {
        Console.WriteLine("C클래스 소멸자");
    }
}
class InheritanceExam2
{
    static void Main(string[] args)
    {
        C obj = new C();
    }
}

