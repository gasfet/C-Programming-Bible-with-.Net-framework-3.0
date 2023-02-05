﻿using System;
using System.Diagnostics;
public class ProcessInfo
{
    public static void Main()
    {
        try
        {
            Process proc = Process.GetCurrentProcess();  // 현재 파일 즉, ProcessInfo 의 
            string processName = proc.ProcessName;     // 프로세스 정보 얻어옴  
            DateTime startTime = proc.StartTime;        // 프로세스 시작 시간
            int proID = proc.Id;                           // 프로세스 PID(운영체제 식별번호)
            int memory = proc.VirtualMemorySize;        // 메모리 사용량

            Console.WriteLine("******* 현재 프로세스 정보 *****");
            Console.WriteLine(" Process: {0}\n ID: {1}\n 시작시간: {2}\n 메모리:{3}\n",
                    processName, proID, startTime, memory);


            Console.WriteLine("\n******* 모든 프로세스 정보 *****");
            Process[] allProc = Process.GetProcesses();  // 시스템에서 실행되는 모든 프로세스
            Console.WriteLine("시스템에서 실행중인 프로세스의 수: {0}", allProc.Length);
            int index = 1;  // 프로세스 번호 출력

            foreach (Process pro in allProc)
            {
                Console.WriteLine("***** {0}번째 프로세스 *****", index++);
                processName = pro.ProcessName;    // 프로세스 이름
                startTime = pro.StartTime;         // 프로세스 시작시간
                proID = pro.Id;                 // 프로세스 PID
                memory = pro.VirtualMemorySize; // 메모리 사용량

                Console.WriteLine(" Process: {0}\n ID: {1}\n 시작시간: {2}\n 메모리:{3}\n",
                        processName, proID, startTime, memory);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("프로세스 검사도중 예외 발생!!!");
            Console.WriteLine(e.Message);
        }
    }
}
