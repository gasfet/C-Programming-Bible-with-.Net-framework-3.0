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
        this.x = data * 2;
    }
}

class newExam
{
    static void Main(string[] args)
    {
        Derived obj = new Derived();
        Console.WriteLine("Derived.x = {0}", obj.x);
        obj.SetData(10);
        Console.WriteLine("SetData => Derived.x = {0}", obj.x);
    }
}

