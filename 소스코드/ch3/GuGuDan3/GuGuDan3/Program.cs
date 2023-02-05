class GuGuDan3
{
    static void Main()
    {
        int i = 1, j = 1;
        while (i < 10)
        {
            while (j < 10)
            {
                System.Console.WriteLine(i + " * " + j + " = " + i * j);
                j++;
            }
            i++; j = 1;
        }
    }
}
