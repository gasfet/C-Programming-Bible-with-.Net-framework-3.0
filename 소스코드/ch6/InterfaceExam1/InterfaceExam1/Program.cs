using System;

interface 새
{
    void fly();
}
interface 말
{
    void run();
}

class 페가수스 : 새, 말
{
    public void fly() { Console.WriteLine(" 하늘을 난다! "); }
    public void run() { Console.WriteLine(" 대륙을 달린다! "); }
}

class InterfaceExam1
{
    static void Main(string[] args)
    {
        페가수스 pega = new 페가수스();
        pega.fly();
        pega.run();
    }
}

