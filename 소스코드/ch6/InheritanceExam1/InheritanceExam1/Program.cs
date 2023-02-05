using System;
class Father
{
    protected string family_name = "김";
    private string name = "아무개1";
    private int age = 39;
}
class Son : Father
{
    private string name = "아무개2";
    private int age = 10;
    public void Info()
    {
        Console.WriteLine("이름은 {0}{1} 입니다.", family_name, name);
        Console.WriteLine("나이는 {0} 살 입니다.", age);
    }
}
class InheritanceExam1
{
    static void Main(string[] args)
    {
        Son obj = new Son();
        obj.Info();
    }
}

