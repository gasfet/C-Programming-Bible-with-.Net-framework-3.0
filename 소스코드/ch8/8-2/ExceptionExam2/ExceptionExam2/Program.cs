using System;
class ExceptionExam2
{
    static void Main()
    {
        try
        {
            Console.Write("첫 번째 값을 입력하세요 -> ");
            int a = Convert.ToInt32(Console.ReadLine().Trim());
            Console.Write("두 번째 값을 입력하세요 -> ");
            int b = Convert.ToInt32(Console.ReadLine().Trim());

            Console.WriteLine("{0}/{1} = {2}", a, b, a / b);
        }
        catch (Exception ex)   // 예외가 발생하면 처리될 구문
        {
            Console.WriteLine("예외 발생: " + ex.Message);
        }
    }
}
