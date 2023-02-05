﻿using System;
using System.Diagnostics;

public class ThreadInfo
{
    public static void Main()
    {
        Process proc = Process.GetCurrentProcess();    // 현재 프로세스 정보 가져오기
        ProcessThreadCollection ths = proc.Threads;    // 스레드 정보 가져오기

        int threadID;                                  // 스레드 ID 번호
        DateTime startTime;                            // 스레드 시작 시간  
        int priority;                                  // 스레드 우선순위
        ThreadState thstate;                           // 스레드 상태 

        int index = 1;                                  // 스레드 번호 출력 

        Console.WriteLine(" 현재 프로세스에서 실행중인 스레드 수: " + ths.Count);

        foreach (ProcessThread pth in ths)
        {
            threadID = pth.Id;
            startTime = pth.StartTime;
            priority = pth.BasePriority;
            thstate = pth.ThreadState;

            Console.WriteLine("******* {0} 스레드 정보 *****", index++);
            Console.WriteLine(" ID: {0}\n 시작시간: {1}\n Priority: {2}\n 스레드 상태:{3}\n",
                    threadID, startTime, priority, thstate);
        }
    }
}
