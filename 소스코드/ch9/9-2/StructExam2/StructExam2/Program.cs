using System;
using System.Drawing;
class StructExam2
{
    static void Main(string[] args)
    {
        Size sz = new Size();
        SizeF szf = new SizeF(100.3f, 100.7f);

        sz = Size.Ceiling(szf);
        System.Console.WriteLine("Ceiling 결과 :" + sz.ToString());

        sz = Size.Round(szf);
        System.Console.WriteLine("Round 결과 :" + sz.ToString());

        sz = Size.Truncate(szf);
        System.Console.WriteLine("Truncate 결과 :" + sz.ToString());
    }
}