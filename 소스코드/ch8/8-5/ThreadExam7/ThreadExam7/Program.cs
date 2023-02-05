﻿using System;
using System.Threading;

class Account
{
    int money;                       // 계좌 잔액
    Random rnd = new Random();       // 입출금 금액 난수 발생
    /// 생성자
    public Account(int money)
    {
        this.money = money;           // 초기 계좌 잔액 지정
    }

    /// 예금 입금
    int Deposit(int amount)
    {
        lock (this)                   // 동기화 처리
        {
            Console.WriteLine("*** {0}님이 {1}원을 입금하려 합니다.",
                                           Thread.CurrentThread.Name, amount);
            Console.WriteLine("입금전 예금 잔액 : \\ " + this.money);
            Console.WriteLine("입금 금액        :-\\ " + amount);
            this.money += amount;
            Console.WriteLine("입금후 예금 잔액 : \\ " + this.money + "\n");
        }
        return amount;
    }

    /// 예금 인출
    int Withdraw(int amount)
    {
        if (this.money < 0)
        {
            throw new Exception("인출 가능한 잔액이 없습니다.");
        }

        lock (this)
        {
            if (this.money >= amount)
            {
                Console.WriteLine("*** {0}님이 {1}원을 인출하려 합니다.",
                                               Thread.CurrentThread.Name, amount);
                Console.WriteLine("인출전 예금 잔액 : \\ " + this.money);
                Console.WriteLine("인출 금액        :-\\ " + amount);
                this.money -= amount;
                Console.WriteLine("인출후 예금 잔액 : \\ " + this.money + "\n");
                return amount;
            }
            else
            {
                return 0; // 인출 금액이 계좌 잔액보다 많을 경우
            }
        }
    }

    /// 예금 입출금 처리
    public void Trans()
    {
        for (int i = 0; i < 10; i++)  // 각각의 고객이 10번씩 입출금을 수행함
        {
            int money = rnd.Next(-3000, 3000); // -3000~3000원 사이에 값 발생
            if (money > 0)   // 발생된 금액이 양수면 출금 기능 수행
            {
                if (this.Withdraw(money) == 0)  // Withdraw() 메서드가 0을 반환하면
                {
                    Console.WriteLine("## Err : 인출 금액이 계좌 잔액보다 많습니다.");
                }
            }
            else          // 발생된 금액이 음수면 입금 기능 수행
            {
                this.Deposit(money * -1);
            }
        }
    }
}

class ThreadExam7
{
    public static void Main()
    {
        Thread[] th = new Thread[3];         // 스레드 개체 3개 생성 
        Account obj = new Account(10000);  // 계좌 잔액을 만원으로 초기화
        for (int i = 0; i < 3; i++)
        {         // 스레드 등록 
            th[i] = new Thread(new ThreadStart(obj.Trans));
            th[i].Name = "고객[" + i + "]";   // 스레드 이름 등록
        }

        for (int i = 0; i < 3; i++)
        {
            th[i].Start();                  // 스레드 시작
        }
    }
}

