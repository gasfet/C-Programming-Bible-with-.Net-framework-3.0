using System;
struct structExam2
{
    public int x;
    public int y;
    structExam2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    static void Main(string[] args)
    {
        structExam2 obj = new structExam2(100, 200);
        Console.WriteLine("x={0}, y={1}", obj.x, obj.y);
    }
}
