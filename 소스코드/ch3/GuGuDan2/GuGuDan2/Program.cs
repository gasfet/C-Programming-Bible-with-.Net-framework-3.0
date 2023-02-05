class GuGuDan2
{
    static void Main()
    {
        int i = 1, j = 1;
        do
        {
            do
            {
                System.Console.WriteLine(i + " * " + j + " = " + i * j);
                j++;
            } while (j < 10);
            i++; j = 1;
        } while (i < 10);
    }
}
