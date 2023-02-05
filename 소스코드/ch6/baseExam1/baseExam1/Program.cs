using System;
class Base
{
    public int x = 10;
    public void SetData(int data)
    {
        this.x = data;
    }
}
class Derived : Base
{
    public new int x = 100;
    public new void SetData(int data)
    {
        Console.WriteLine("before Base::x = {0}", base.x);
        Console.WriteLine("before Derived:x = {0}", this.x);
        base.SetData(200);        
        this.x = base.x + this.x + data;
        Console.WriteLine("after Base::x = {0}", base.x);
        Console.WriteLine("after Derived:x = {0}", this.x);
    }
}

class baseExam1
{
    static void Main(string[] args)
    {
        Derived obj = new Derived();
        Console.WriteLine("Derived.x = {0}", obj.x);
        obj.SetData(10);
        Console.WriteLine("SetData => Derived.x = {0}", obj.x);
    }
}

