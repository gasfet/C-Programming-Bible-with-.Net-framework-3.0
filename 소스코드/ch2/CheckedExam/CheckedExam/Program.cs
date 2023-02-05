using System;
class CheckedExam
{
    static void Main()
    {
        int data1 = 99999;
        short data2 = checked((short)data1);

        Console.WriteLine("data1 = " + data1);
        
    }
}

