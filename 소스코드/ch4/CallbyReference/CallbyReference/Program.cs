using System;
class CallbyReference
{
    static void Main()
    {
        int x, y;
        x = 5;
        y = 10;
        Console.WriteLine("Main1(x, y)값 = ({0}, {1})", x, y);
        Swap1(ref x, ref y);
        Console.WriteLine("Main2(x, y)값 = ({0}, {1})", x, y);
        Swap2(out x, out y);
        Console.WriteLine("Main3(x, y)값 = ({0}, {1})", x, y);
    }
    public static void Swap1(ref int x, ref int y)
    {
        int temp = x;
        x = y;
        y = temp;
        Console.WriteLine("ref Swap(x, y)값 = ({0}, {1})", x, y);
    }
    public static void Swap2(out int x, out int y)
    {        
        x = 100;
        y = 200;
        Console.WriteLine("out Swap(x, y)값 = ({0}, {1})", x, y);
    }

}

