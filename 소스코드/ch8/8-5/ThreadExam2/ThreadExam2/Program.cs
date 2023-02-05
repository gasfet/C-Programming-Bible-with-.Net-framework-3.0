﻿using System;
using System.Threading;
public class ThreadExam2
{
    static int i = 0;
    // 첫 번째 스레드
    public static void Print1(object obj)
    {
        for (i = 0; i < 3; i++)
        {
            Console.WriteLine("첫 번째 Thread :{0} ***", i);
            Thread.Sleep(100);   // 0.1 초 동안 스레드 정지
        }

    }
    // 두 번째 스레드
    public void Print2(object obj)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("두 번째 Thread :{0} ***", i);
            Thread.Sleep(100);   // 0.1 초 동안 스레드 정지
        }


    }

    public static void Main()
    {
        // static method를 이용한 ThreadPool 에 대한 작업 요청
        ThreadPool.QueueUserWorkItem(new WaitCallback(Print1), null);
        // instance method를 이용한 ThreadPool 에 대한 작업 요청			
        ThreadPool.QueueUserWorkItem(new WaitCallback((new ThreadExam2()).Print2), null);

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("main: {0}", i);
            Thread.Sleep(100);  // 메인 스레드 
        }
    }
}

