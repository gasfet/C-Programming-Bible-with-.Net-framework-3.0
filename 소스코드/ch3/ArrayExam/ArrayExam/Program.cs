using System;
class ArrayExam
{
    static void Main()
    {
        int[] month = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        Console.WriteLine("Array.IndexOf(30)={0}", Array.IndexOf(month, 30));
        Console.WriteLine("Array.LastIndexOf(30)={0}", Array.LastIndexOf(month, 30));
        Console.WriteLine("\n month Original -->");
        for (int i = 0; i < month.Length; i++)
        {
            Console.Write("{0} , ", month[i]);
        }
        Console.WriteLine("\n Array.Reverse(month) -->");
        Array.Reverse(month);
        for (int i = 0; i < month.Length; i++)
        {
            Console.Write("{0} , ", month[i]);
        }        
        Console.WriteLine("\n Array.Srot(month) -->");
        Array.Sort(month);
        for (int i = 0; i < month.Length; i++)
        {
            Console.Write("{0} , ", month[i]);
        }

        Array.BinarySearch(
    }
}

