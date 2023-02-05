using System;
sealed class WordProcess
{
    void Input() { }
    void Edit() { }
    void Print() { }
    void About()
    {
        Console.WriteLine("A회사에서 개발한 프로그램");
    }
}

class NewWordProcess : WordProcess
{
    new void About()
    {
        Console.WriteLine("B회사에서 개발한 프로그램");
    }
}

class sealedExam
{
    static void Main(string[] args)
    {
        NewWordProcess obj = new NewWordProcess();
    }
}

