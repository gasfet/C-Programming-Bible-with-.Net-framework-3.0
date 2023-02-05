using System;
class ExceptionExam5
{         // OverflowException 예외를 발생시키는 메서드
    static void A()
    {
        throw (new OverflowException("오버플러우 예외***"));
    }

    static void Main()
    {
        try
        {       // 예외가 발생하면... 
            A();
        }
        catch (Exception ex)   // 예외 메시지를 화면에 출력...
        {
            Console.WriteLine("예외 발생:" + ex.Message);
        }
		finally    // 예외 발생 유무와 상관없이 화면에 출력
        {
            Console.WriteLine("1. 이 문장은 무조건 출력됩니다.");
        }


        try
        {         // 이 구문에서는 예외가 발생하지 않음...
            Console.WriteLine("예외 발생 없음!");
        }
        catch (Exception ex)
        {         // 예외가 발생하지 않기 때문에 활성화되지 않음 
            Console.WriteLine("예외 발생:" + ex.Message);
        }
        finally
        {         // 예외가 발생하지 않아도 무조건 실행됨
            Console.WriteLine("2. 이 문장은 무조건 출력됩니다.");
        }
        
        try
        {
            Console.WriteLine("finally 구문만 있을 경우!");
        }
        finally
        {         // finally 구문은 catch 구문이 없어도 상관없음
            Console.WriteLine("3. 이 문장은 무조건 출력됩니다.");
        }

    }
}
