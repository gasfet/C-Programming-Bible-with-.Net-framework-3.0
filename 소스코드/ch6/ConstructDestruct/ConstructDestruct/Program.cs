using System;
class A
{
    public A()
    {
        Console.WriteLine("A 생성자");
    }
    ~A()
    {
        Console.WriteLine("A 소멸자");
    }
}
class B : A
{
    public B()
    {
        Console.WriteLine("B 생성자");
    }
    ~B()
    {
        Console.WriteLine("B 소멸자");
    }
}
class C : B
{
    public C()
    {
        Console.WriteLine("C 생성자");
    }
    ~C()
    {
        Console.WriteLine("C 소멸자");
    }
}

class ConstructDestruct
{
    static void Main(string[] args)
    {
        C obj = new C();
    }
}

