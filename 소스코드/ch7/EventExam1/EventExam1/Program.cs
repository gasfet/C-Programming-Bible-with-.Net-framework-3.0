using System;
class MyEventArgs : EventArgs     // System.EentArgs 클래스 상속
{
    private int ClickCount;
    public MyEventArgs()
    {
        this.ClickCount = 0;
    }
    public MyEventArgs(int data)
    {
        this.ClickCount = data;
    }
    public int GetClickCount()
    {
        return this.ClickCount;
    }
}

class ExampleClass
{
    public void OnClick(object sender, MyEventArgs args)
    {
        Console.WriteLine("{0} 개체에서 {1}번 이벤트가 발생했습니다.",
           sender.ToString(), args.GetClickCount());
    }
}
class EventExam1
{
    public delegate void ClickEvent(object sender, MyEventArgs args);
    private event ClickEvent ExamEvent;

    public EventExam1()
    {
        ExampleClass obj = new ExampleClass();
        ExamEvent += new ClickEvent(obj.OnClick);
    }
    public void ClickMethod(int clickcount)
    {
        if (ExamEvent != null)
        {
            MyEventArgs args = new MyEventArgs(10);
            ExamEvent(this, args);
        }
    }
    public static void Main()
    {
        EventExam1 obj = new EventExam1();
        obj.ClickMethod(10);
    }
}
