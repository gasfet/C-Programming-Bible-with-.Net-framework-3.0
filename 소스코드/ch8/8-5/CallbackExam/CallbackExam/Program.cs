using System;
using System.Threading;

public class CallbackExam
{    
    private ExampleCallback callback;

    public CallbackExam(ExampleCallback callbackDelegate)
    {
        callback = callbackDelegate;
    }

   public void ThreadProc()
    {
        Console.WriteLine(Thread.CurrentThread.Name + " : ThreadProc() 호출");
        Thread.Sleep(1000);
        if (callback != null)
            callback(1000);
    }
}

public delegate void ExampleCallback(int lineCount);

public class Example
{
    private static int examdata = 0;
    
    public static void ResultCallback(int data)
    {
        Console.WriteLine(Thread.CurrentThread.Name +" 스레드가 실행한 ResultCallback : " + data);
        Example.examdata = data;
    }

    public static void ShowData()
    {
        Console.WriteLine("Example.ShowData() => " + Example.examdata);
    }

    public static void Main()
    {
         CallbackExam ce = new CallbackExam(new ExampleCallback(ResultCallback)
        );

        Thread th = new Thread(new ThreadStart(ce.ThreadProc));
        th.Name = "Thread A";
        th.Start();
        Console.WriteLine("th 스레드 Start() 메서드 실행 후~");
        th.Join();
        Example.ShowData();        
    }

  
}