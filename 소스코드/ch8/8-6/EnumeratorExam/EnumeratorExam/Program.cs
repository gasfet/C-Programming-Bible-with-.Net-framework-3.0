using System;
using System.Collections;
class Program
{
    static void Main(string[] args)
    {
        int index = 0;
        string[] obj = { "빨", "주", "노", "초", "파", "남", "보" };

        IEnumerator e = obj.GetEnumerator();
        while (e.MoveNext())
        {
            Console.Write(" - {0}", e.Current);
        }
        Console.WriteLine();
        e.Reset();
        while (e.MoveNext())
        {
            if ((index % 2) == 1)
                Console.Write(" - {0}", e.Current);
            index++;
        }
    }
}

