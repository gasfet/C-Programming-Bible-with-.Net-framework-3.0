using System;
class CallbyValue
{
    static void Main()
    {
        int x, y;
        x = 5;
        y = 10;
        Console.WriteLine("Main1(x, y)값 = ({0}, {1})", x, y);
        Swap(x, y);
        Console.WriteLine("Main2(x, y)값 = ({0}, {1})", x, y);
    }
    public static void Swap(int x, int y)
    {
        int temp = x;
        x = y;
        y = temp;
        Console.WriteLine("Swap(x, y)값 = ({0}, {1})", x, y);
    }
}

