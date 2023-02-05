using System;
class ExceptionExam4
{
    static void A()
    {         // OverflowException 예외를 일부러 발생시킴
        throw (new OverflowException("오버플러우 예외***"));
    }

    static void Main()
    {
        try
        {
            A();   // OverflowException 예외 발생
        }
        catch (OverflowException oe)
        {
            Console.WriteLine("예외 발생: " + oe.Message);
        }
    }
}

