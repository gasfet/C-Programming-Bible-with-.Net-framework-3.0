using System;
interface MyInterface
{
    void Show();
}
class A : MyInterface
{
    public void Show() { Console.WriteLine("A-Class::Show()"); }
}
class B : MyInterface
{
    public void Show() { Console.WriteLine("B-Class::Show()"); }
}
class C : MyInterface
{
    public void Show() { Console.WriteLine("C-Class::Show()"); }
}

class InterfaceExam4
{
    static void Main(string[] args)
    {
        A a = new A();
        B b = new B();
        C c = new C();

        MyInterface[] inter = new MyInterface[3];
        inter[0] = (MyInterface)a;
        inter[1] = (MyInterface)b;
        inter[2] = (MyInterface)c;

        for (int i = 0; i < inter.Length; i++)
            inter[i].Show();
    }
}

