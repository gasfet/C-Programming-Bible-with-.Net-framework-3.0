using System;
using System.Threading;
public class ThreadExam1
{
    public static void Print1()
    {
        Console.WriteLine("첫 번째 Thread ***");
    }

    public void Print2()
    {
        Console.WriteLine("두 번째 Thread ***");
    }

    public static void Main()
    {
        Thread thread = new Thread(new ThreadStart(Print1));
        thread.Start(); // static method를 실행하는 쓰레드 생성 및 실행
        thread = new Thread(new ThreadStart((new ThreadExam1()).Print2));
        thread.Start(); // instance method를 실행하는 쓰래드 생성 및 실행 

        Console.WriteLine("세 번째 Thread ***");
    }
}

