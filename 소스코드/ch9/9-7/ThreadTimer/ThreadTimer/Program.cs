using System;
using System.Threading;

class TimerExampleState 
{
	public int counter = 0;
	public Timer timer;
}

class ThreadTimer 
{
	public static void Main()
	{
		TimerExampleState s = new TimerExampleState();

		TimerCallback timerDelegate = new TimerCallback(CheckStatus);

		Timer timer = new Timer(timerDelegate, s, 2000, 1000);
    
		s.timer = timer;

		while(s.timer != null);					
	}

	private static void CheckStatus(Object state)
	{
		TimerExampleState ts =(TimerExampleState)state;
		ts.counter++;
		if(ts.counter == 3)
		{
			Console.WriteLine("{0}:스레드 체크 :{1}.", ts.counter, DateTime.Now);
			(ts.timer).Change(5000,2000);
			Console.WriteLine("스레드 상태 변경...");
			Console.WriteLine("5초후에 2초 간격으로 다시 시작됩니다.");
		}
		else if(ts.counter == 4)
		{
			Console.WriteLine("스레드 상태 변경 => 2초 간격으로 시작");
			Console.WriteLine("{0}:스레드 체크 :{1}.", ts.counter, DateTime.Now);			
		}
		else if(ts.counter == 7)
		{
			Console.WriteLine("타이머를 종료합니다...");
			ts.timer.Dispose();
			ts.timer = null;
		}
		else
		{
			Console.WriteLine("{0}:스레드 체크 :{1}.", ts.counter, DateTime.Now);
		}
	}
}

