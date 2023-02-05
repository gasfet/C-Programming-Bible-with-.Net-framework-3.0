using System;
using System.Threading;
public class ThreadExam3
{
    public static void Print1(object obj)
    {
        Console.WriteLine("첫 번째 Thread : ***");
    }

    public void Print2(object obj)
    {
        Console.WriteLine("두 번째 Thread : ***");
    }

    public static void Main()
    {
        // static method를 이용한 ThreadPool 에 대한 작업 요청
        Timer timer = new Timer(new TimerCallback(Print1), null, 200, 100);
        // instance method를 이용한 ThreadPool 에 대한 작업 요청
        timer = new Timer(new TimerCallback((new ThreadExam3()).Print2), null, 200, 100);
        Thread.Sleep(500);   // Main 스레드를 곧바로 종료하지 않고 0.5초간 중지시킴

        timer.Dispose();  //Timer 를 종료
    }
}
