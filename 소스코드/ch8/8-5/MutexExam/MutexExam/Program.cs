using System;
using System.Threading;

class MutexExam
{
    private static Mutex mtx = new Mutex(false, "MutexExam");
    int count = 0;
    public MutexExam(int count)
    {
        this.count = count;
    }
    public void ShowData()
    {
        mtx.WaitOne();  // Mutex 요청하기        
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
            mtx.ReleaseMutex(); // Mutex 해제하기
        }
    }
    public static void Main()
    {
        MutexExam obj1 = new MutexExam(3);
        MutexExam obj2 = new MutexExam(5);
        Thread t1 = new Thread(new ThreadStart(obj1.ShowData));
        Thread t2 = new Thread(new ThreadStart(obj2.ShowData));
        t1.Name = "Thread - A";
        t2.Name = "Thread - B";
        t1.Start();
        t2.Start();
    }
}
