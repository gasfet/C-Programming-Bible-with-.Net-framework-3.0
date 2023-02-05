class DoWhile
{
    static void Main()
    {
        int sum = 0;
        int i = 1;
        do
        {
            sum += i;
            i++;
        } while (i <= 100);
        System.Console.WriteLine("1~100의 합은 " + sum);
    }
}
