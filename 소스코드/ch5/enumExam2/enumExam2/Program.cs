using System;
public class enumExam2
{
    enum Range1 : long { Max = 2147483648L, Min = 255L };
    enum Range2 : byte { Top = 255, Bottom = 0 }; // 0~255 값만 사용 가능
    static void Main()
    {
        long x = (long)Range1.Max;
        byte y = (byte)Range2.Bottom;
        Console.WriteLine("Max = {0}, Bottom = {1}", x, y);
    }
}
