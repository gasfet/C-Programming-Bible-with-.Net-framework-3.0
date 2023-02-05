using System;
using System.Drawing;
class StructExam1
{
    static void Main(string[] args)
    {
        Size sz1 = new Size(100, 100);
        Size sz2 = new Size(50, -50);
        Size sz3 = new Size();
        sz3 = sz1 + sz2;
        System.Console.WriteLine(sz3.ToString());
        sz3 = sz2 - sz1;
        System.Console.WriteLine(sz3.ToString());
        sz3 += sz1;
        System.Console.WriteLine(sz3.ToString());
        sz3 -= sz2;
        System.Console.WriteLine(sz3.ToString());
    }
}
