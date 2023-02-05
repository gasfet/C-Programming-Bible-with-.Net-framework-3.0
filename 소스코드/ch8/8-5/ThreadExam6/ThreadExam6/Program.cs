using System;
using System.Threading;
public class ThreadExam6
{
    public static void Print1() { Console.WriteLine("Print1 스레드 *"); }
    public static void Print2() { Console.WriteLine("Print2 스레드 **"); }
    public static void Print3() { Console.WriteLine("Print3 스레드 ***"); }
    public static void Print4() { Console.WriteLine("Print4 스레드 ****"); }
    public static void Print5() { Console.WriteLine("Print5 스레드 *****"); }

    public static void Main()
    {
        Thread th1 = new Thread(new ThreadStart(Print1));
        Thread th2 = new Thread(new ThreadStart(Print2));
        Thread th3 = new Thread(new ThreadStart(Print3));
        Thread th4 = new Thread(new ThreadStart(Print4));
        Thread th5 = new Thread(new ThreadStart(Print5));

        th1.Priority = ThreadPriority.Highest;   // th1 스레드 우선순위 부여
        th5.Priority = ThreadPriority.Lowest;    // th5 스레드 우선순위 부여

        th2.Start();	 // 스레드 시작
        th5.Start();
        th3.Start();
        th4.Start();
        th1.Start();
    }
}
