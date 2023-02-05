using System;
abstract class Parent
{
    public abstract void Show();
}
class Child : Parent
{
    public override void Show()
    {
        Console.WriteLine("Show 메서드 override");
    }
}

class overrideExam1
{
    static void Main(string[] args)
    {
        Parent obj = new Child();
        obj.Show();
    }
}
