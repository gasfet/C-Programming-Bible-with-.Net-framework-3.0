using System;
using System.Drawing;
class StructExam3
{

    static void Main(string[] args)
    {
        Rectangle rect = new Rectangle();
        Rectangle rect1 = new Rectangle(10, 10, 100, 100);
        Rectangle rect2 = new Rectangle(50, 50, 100, 100);

        rect = Rectangle.FromLTRB(30, 30, 50, 50);
        System.Console.WriteLine("rect 값(FromLTRB) :" + rect.ToString());

        rect.Offset(10, -10);
        System.Console.WriteLine("rect 값(Offset) :" + rect.ToString());

        Rectangle.Inflate(rect1, 50, 50);
        System.Console.WriteLine("rect 값(Inflate) :" + rect.ToString());

        rect1 = Rectangle.Union(rect1, rect2);
        System.Console.WriteLine("rect 값(Union) :" + rect.ToString());

        rect1 = Rectangle.Intersect(rect1, rect2);
        System.Console.WriteLine("rect 값(Intersect) :" + rect.ToString());

        if (rect1.Contains(rect2))
            System.Console.WriteLine("rect2는 rect1에 포함되어 있습니다.");

        if (rect2.IntersectsWith(rect1))
            System.Console.WriteLine("rect2는 rect1과 교차합니다.");

    }
}