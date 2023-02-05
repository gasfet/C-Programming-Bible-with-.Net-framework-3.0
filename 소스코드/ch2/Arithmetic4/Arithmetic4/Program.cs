class Arithmetic4
{
    static void Main()
    {
        bool A = (3 > 10) & (10 > 3);
        bool B = (3 > 10) && (10 > 3);//단축 논리 연산자
        bool C = (10 > 3) | (3 > 10);
        bool D = (10 > 3) || (3 > 10);//단축 논리 연산자
        System.Console.WriteLine("A=" + A + " B=" + B + " C=" + C + " D=" + D);
    }
}

