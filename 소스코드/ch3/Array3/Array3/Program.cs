class Array3
{
    static void Main()
    {
        int[] a = new int[100];
        for (int i = 0; i < 100; i++)
            a[i] = i;

        System.Console.WriteLine("a 배열의 개수는 " + a.Length);
    }
}

