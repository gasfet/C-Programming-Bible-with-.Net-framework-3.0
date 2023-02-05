using System;
class ConvertSwitch
{
    static void Main()
    {
        for (int i = 0; i <= 6; i++)
        {
            Console.Write(i);
            if (i == 1 | i == 3 | i == 5)
                Console.WriteLine("는 홀수 입니다.");
            else if (i == 2 | i == 4 | i == 6)
                Console.WriteLine("는 짝수 입니다.");
            else
                Console.WriteLine(" 홀수도 짝수도 아닙니다.");
        }
    }
}
