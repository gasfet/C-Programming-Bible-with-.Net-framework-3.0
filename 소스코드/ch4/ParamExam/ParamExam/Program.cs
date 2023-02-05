using System;
class ParamExam
{
    static void Main()
    {
        Month(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
    }
    
    public static void Month(params int[] args)
    {
        for(int i = 0; i < args.Length; i++)
        {
            Console.WriteLine("{0}달= {1}일", i + 1, args[i]);
        }
    }
}

