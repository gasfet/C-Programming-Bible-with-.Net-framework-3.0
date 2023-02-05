using System;
using System.Threading;

public class ThreadExam4
{
    public static void Print()    // 스레드로 실행될 메서드
    {
        try
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(" Print 스레드 : {0} ", i);
            }
        }
        catch (ThreadAbortException ex)
        {
            Console.WriteLine("스레드 에러: " + ex.Message);
        }
    }

    public static void TInfo(Thread th)
    {
        Console.WriteLine("Thread ID : {0} \t 상태 : {1}", th.GetHashCode(), th.ThreadState);
    }

    public static void Main()
    {
        string msg = null;   // 스레드 정보를 출력할 문자열 

        Thread th = new Thread(new ThreadStart(Print));
        TInfo(th);    // 스레드 정보 출력

        th.Start();           // 스레드 시작 (Stated 상태로 변화됨)
        Thread.Sleep(100);  // th 스레드가 시작될 때까지 잠시 대기함
        TInfo(th);           // 스레드 상태가 UnStarted에서 Started로 변경

        th.Suspend();        // 스레드 Suspend(일시정지) 
        Thread.Sleep(100);  // 스레드가 일시 정지될 시간적 여유를 줌

        // 콘솔 화면은 Print 스레드가 사용하기 때문에 MessageBox로 화면에 스레드 정보 출력
        msg = "Thread ID :" + th.GetHashCode() + "\t 상태 : " + th.ThreadState.ToString();
        System.Windows.Forms.MessageBox.Show(msg);

        th.Resume();            // Suspend 상태 스레드를 깨움
        Thread.Sleep(100);      // Resume 이 적용될 시간적 여유를 줌

        msg = "Thread ID :" + th.GetHashCode() + "\t 상태 : " + th.ThreadState.ToString();
        System.Windows.Forms.MessageBox.Show(msg);

        th.Abort();              // 스레드 종료 메시지 
        th.Join();               // 스레드가 완전히 정지될 때까지 기다림

        TInfo(th);		   // 스레드 상태 정보 출력
    }
}
