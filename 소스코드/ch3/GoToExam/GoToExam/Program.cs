using System;
using System.Collections.Generic;
using System.Text;

namespace GoToExam
{
    class Program
    {
        static void Main(string[] args)
        {
            goto 하;
            Console.WriteLine("문장 출력 1 ===>");
            하:
            Console.WriteLine("문장 출력 2 ===>");
        }
    }
}
