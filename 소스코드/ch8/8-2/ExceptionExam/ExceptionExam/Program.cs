using System;
class ExceptionExample
{
    static void Main()
    {
        Console.Write("첫 번째 값을 입력하세요 -> ");
        int a = Convert.ToInt32(Console.ReadLine().Trim());
        Console.Write("두 번째 값을 입력하세요 -> ");
        int b = Convert.ToInt32(Console.ReadLine().Trim());
        Console.WriteLine("{0}/{1} = {2}", a, b, a / b);
    }
}

