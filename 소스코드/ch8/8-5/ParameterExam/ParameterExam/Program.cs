using System;
using System.Threading;

public class ParameterExam
{
    public static void Main()
    {
        Thread th = new Thread(new ParameterizedThreadStart(ParameterExam.Int));
        th.Start(100);

        ParameterExam w = new ParameterExam();
        th = new Thread(new ParameterizedThreadStart(w.String));
        th.Start("안녕하세요.");
    }

    public static void Int(object data)
    {
        Console.WriteLine(data);
    }

    public void String(object data)
    {
        Console.WriteLine(data);
    }
}
