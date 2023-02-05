using System;
interface MyInterface
{
    void Display();
}
class MyClass
{
    public void Show() { Console.WriteLine("MyClass::Show()"); }
}
class ObjectClass : MyClass, MyInterface
{
    public void Display() { Console.WriteLine("MyInterface::Display()"); }
}

class InterfaceExam3
{
    static void Main(string[] args)
    {
        ObjectClass obj = new ObjectClass();
        obj.Show();        
        MyInterface inter = (MyInterface)obj;
        inter.Display();
    }
}

