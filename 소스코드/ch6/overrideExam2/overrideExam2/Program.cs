using System;
class Parent
{
    public virtual void Show()
    {
        Console.WriteLine("부모 클래스::Show");
    }
}
class Child : Parent
{
    public override void Show()
    {
        Console.WriteLine("자식 클래스::Show");
    }
}

class overrideExam2
{
    static void Main(string[] args)
    {
        Parent obj = new Parent();
        obj.Show();
        obj = new Child();
        obj.Show();
    }
}

