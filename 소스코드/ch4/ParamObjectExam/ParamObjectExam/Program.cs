using System;
class ParamObjectExam
{
    public static void Data(params object[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine("전달된 인수 ={0}, Type={1}", args[i], args[i].GetType());
        }
    }

    static void Main()
    {
        Data("C# 프로그램", 2006, "년");
    }
}

