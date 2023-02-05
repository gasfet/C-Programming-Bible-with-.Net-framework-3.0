using System;
using System.Threading;

class MonitorExam
{
    private static Object obj = new Object();
    int count = 0;
    public MonitorExam(int count)
    {
        this.count = count;
    }
    public void ShowData()
    {
        Monitor.Enter(MonitorExam.obj);
        //Monitor.TryEnter(MonitorExam.obj, 1000);
        try
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " : " + i);
                Thread.Sleep(100);
                if (this.count == i) throw (new Exception());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Monitor.Exit(MonitorExam.obj);
        }
    }
    public static void Main()
    {
        MonitorExam obj1 = new MonitorExam(5);
        MonitorExam obj2 = new MonitorExam(7);
        Thread t1 = new Thread(new ThreadStart(obj1.ShowData));
        Thread t2 = new Thread(new ThreadStart(obj2.ShowData));
        t1.Name = "Thread - A";
        t2.Name = "Thread - B";
        t1.Start();
        t2.Start();
    }
}
