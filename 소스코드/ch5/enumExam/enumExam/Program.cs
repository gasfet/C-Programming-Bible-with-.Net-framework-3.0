using System;
class enumExam
{
    enum Rainbow1 { red, orange, yellow, green, blue, indigo, violet }
    enum Rainbow2 { red = 2, orange, yellow, green, blue, indigo, violet }
    enum Rainbow3 { red, orange, yellow = 5, green, blue = 9, indigo, violet }

    static void Main(string[] args)
    {        
        Console.WriteLine("Rainbow1 = {0}-{1}-{2}-{3}-{4}-{5}-{6}",
            (int)Rainbow1.red, (int)Rainbow1.orange, (int)Rainbow1.yellow, (int)Rainbow1.green,
            (int)Rainbow1.blue, (int)Rainbow1.indigo, (int)Rainbow1.violet);
        Console.WriteLine("Rainbow2 = {0}-{1}-{2}-{3}-{4}-{5}-{6}",
            (int)Rainbow2.red, (int)Rainbow2.orange, (int)Rainbow2.yellow, (int)Rainbow2.green,
            (int)Rainbow2.blue, (int)Rainbow2.indigo, (int)Rainbow2.violet);
        Console.WriteLine("Rainbow3 = {0}-{1}-{2}-{3}-{4}-{5}-{6}",
            (int)Rainbow3.red, (int)Rainbow3.orange, (int)Rainbow3.yellow, (int)Rainbow3.green,
            (int)Rainbow3.blue, (int)Rainbow3.indigo, (int)Rainbow3.violet);
    }
}

