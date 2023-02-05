using System;
class ExceptionExam6
{
    static void Main()
    {
        try
        {
            Console.Write("첫 번째 값을 입력하세요 -> ");
            int a = Convert.ToInt32(Console.ReadLine().Trim());
            Console.Write("두 번째 값을 입력하세요 -> ");
            int b = Convert.ToInt32(Console.ReadLine().Trim());

            if (b > a)
            {
                checked
                {
                    long num = Int64.MaxValue;
                    a = (int)num;    // 산술연산 예외 발생
                }
                Console.WriteLine("{0}/{1} = {2}", a, b, a / b);
            }
            else
            {
                Console.WriteLine("{0}/{1} = {2}", a, b, a / b);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("예외 발생:" + ex.Message);
        }
        catch (OverflowException oe)
        {
            Console.WriteLine("Overflow 예외 발생");
        }
        catch (DivideByZeroException dz)
        {
            Console.WriteLine("0으로 나눌 수 없습니다.");
        }
    }
}

