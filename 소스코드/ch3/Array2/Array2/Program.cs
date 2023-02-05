class Array2
{
    static void Main()
    {
        int[] month = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        int sum = 0;

        for (int i = 0; i < 12; i++)
            sum += month[i];

        System.Console.WriteLine("모든 달의 합은 " + sum);
    }
}
