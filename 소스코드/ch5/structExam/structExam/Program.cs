struct Point
{
    public int x, y;    
    public Point(int a, int b)
    {
        this.x = a;
        this.y = b;
    }
    public void Show()
    {
        System.Console.WriteLine("x = {0}, y = {1}", x, y);
    }
}
class structExam
{
    static void Main(string[] args)
    {
        Point obj1 = new Point();
        Point obj2 = new Point(10, 100);
        Point obj3;

        obj1.Show();
        obj2.Show();

        obj3.x = obj3.y = 10;
        obj3.Show();
    }
}


