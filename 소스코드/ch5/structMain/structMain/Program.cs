struct structMain
{
    static void Display()
    {
        for (int i = 1; i < 10; i++)
            for (int j = 1; j < 10; j++)
                System.Console.WriteLine("{0}*{1}={2}", i, j, i * j);
    }
    static void Main(string[] args)
    {
        System.Console.WriteLine("struct 사용하기");
        Display();
    }
}

