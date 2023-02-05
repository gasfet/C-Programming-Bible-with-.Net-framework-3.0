class Break2
{
    static void Main()
    {
        int grade = 100;
        System.Console.WriteLine("문장 1");
        switch (grade)
        {
            case 100:
                System.Console.WriteLine("문장 2");
                break; // 12번째 줄로 이동
            case 200:
                System.Console.WriteLine("문장 3");
                break; // 12번째 줄로 이동
        }
        System.Console.WriteLine("문장 4");
    }
}
