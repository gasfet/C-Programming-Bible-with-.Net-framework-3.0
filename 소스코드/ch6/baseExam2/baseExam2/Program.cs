using System;
class Base
{
    public int data = 100;
    public Base()
    {
        Console.WriteLine("Base::Base() 생성자");
    }
    public Base(int data)
    {
        this.data = data;
        Console.WriteLine("Base::Base(int data) 생성자");
    }    
}
class Derived : Base
{
    public Derived()
        : base()
    {
        Console.WriteLine("Derived::Derived() 생성자");
    }
    public Derived(int data)
        : base(data)
    {
        Console.WriteLine("Derived::Derived(int data) 생성자");
    }

    public void PrintData()
    {
        Console.WriteLine("data = {0}", data);    
    }   
}

class baseExam2
{
    static void Main(string[] args)
    {
        Derived obj = new Derived();
        obj.PrintData();
        obj = new Derived(200);
        obj.PrintData();
    }
}

