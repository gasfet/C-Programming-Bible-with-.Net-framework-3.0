using System;
struct Color
{
    public byte red;
    public byte green;
    public byte blue;
}
struct ColorPoint
{
    public int x;
    public int y;
    public Color color;
   // public ColorPoint() { } 매개변수 없는 생성자는 재정의 할 수 없음
    public ColorPoint(int x, int y, byte r, byte g, byte b)
    {
        Console.WriteLine("구조체 생성자 호출");            
        this.x = x;
        this.y = y;
        this.color.red = r;
        this.color.green = g;
        this.color.blue = b;
    }    
}
class structExam1
{
    static void Main(string[] args)
    {
        ColorPoint data1;
        data1.x = 10;
        data1.y = 10;
        data1.color.red = 255;
        data1.color.green = 0;
        data1.color.blue = 0;
        ColorPoint data2 = new ColorPoint();
        ColorPoint data3 = new ColorPoint(100, 100, 0, 255, 0);
        ColorPoint data4 = data1;

        Console.WriteLine("data1 : point({0},{1}), color({2},{3},{4})",
            data1.x, data1.y, data1.color.red, data1.color.green, data1.color.blue);
        Console.WriteLine("data2 : point({0},{1}), color({2},{3},{4})",
            data2.x, data2.y, data2.color.red, data2.color.green, data2.color.blue);
        Console.WriteLine("data3 : point({0},{1}), color({2},{3},{4})",
            data3.x, data3.y, data3.color.red, data3.color.green, data3.color.blue);
        Console.WriteLine("data4 : point({0},{1}), color({2},{3},{4})",
            data4.x, data4.y, data4.color.red, data4.color.green, data4.color.blue);
                
    }
}

