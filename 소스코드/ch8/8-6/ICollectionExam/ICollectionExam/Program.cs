using System;
using System.Collections;
using System.Threading;
class ICollectionExam
{
    int[] obj = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public void Run()
    {
        ICollection c = obj;
        IEnumerator e = c.GetEnumerator();
        while (e.MoveNext())
        {
            Console.Write("{0}-", e.Current);
            try
            {
                Thread.Sleep(100);
            }
            catch{}
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        ICollectionExam obj = new ICollectionExam();
        Thread t1 = new Thread(new ThreadStart(obj.Run));
        t1.Start();
        Thread t2 = new Thread(new ThreadStart(obj.Run));
        t2.Start();        
    }
}

