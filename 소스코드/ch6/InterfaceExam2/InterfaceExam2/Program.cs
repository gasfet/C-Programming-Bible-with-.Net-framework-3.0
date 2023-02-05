using System;

interface 자동차
{
    void run();
}
interface 배
{
    void navigation();
}
interface 수륙양용자동차 : 자동차, 배
{
    void floating();
}

class NewCar : 수륙양용자동차
{    
    public void run() { Console.WriteLine("육지를 달리는 능력"); }
    public void navigation() { Console.WriteLine("바다를 항해하는 능력"); }
    public void floating() { Console.WriteLine("공중에 떠있는 기능"); }
}

class InterfaceExam2
{
    static void Main(string[] args)
    {
        NewCar car = new NewCar();
        car.run();
        car.navigation();
        car.floating();
    }
}

