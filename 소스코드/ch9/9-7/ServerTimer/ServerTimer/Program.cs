using System;
using System.Timers;
public class ServerTimer
{

    public static void Main()
    {
        System.Timers.Timer serverTimer = new System.Timers.Timer();
        serverTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        serverTimer.Enabled = true;
        serverTimer.Interval = 1000;

        Console.WriteLine("예제를 종료하려면 q를 입력하세요.");
        while (Console.Read() != 'q') ;
    }

    private static void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("서버 타이머 이벤트 발생");
        Console.WriteLine("발생 시간 : {0}", e.SignalTime);
    }
}