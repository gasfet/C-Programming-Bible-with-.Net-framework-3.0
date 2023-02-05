using System;
class ExceptionExam3
{
    static void Main()
    {
        try
        {
            Console.Write("첫 번째 값을 입력하세요 -> ");
            int a = Convert.ToInt32(Console.ReadLine().Trim());
            Console.Write("두 번째 값을 입력하세요 -> ");
            int b = Convert.ToInt32(Console.ReadLine().Trim());

            if (b > a)    // 두 번째 값이 첫 번째 값보다 클 경우
            {
                checked   // 값이 범위가 맞는지 체크하는 키워드
                {
                    long num = Int64.MaxValue;  // long 자료형의 최대값
                    a = (int)num;                 // 예외 발생
                }
                Console.WriteLine("{0}/{1} = {2}", a, b, a / b);
            }
            else
            {
                Console.WriteLine("{0}/{1} = {2}", a, b, a / b);
            }
        }
        catch (OverflowException oe)   // 값이 범위를 벗어날 때 발생하는 예외
        {
            Console.WriteLine("Overflow 예외 발생");
        }
        catch (DivideByZeroException dz)  // 정수를 0으로 나누려고 할 때 발생하는 예외
        {
            Console.WriteLine("0으로 나눌 수 없습니다.");
        }
    }
}

