class MultiArray2
{
	static void Main()
	{
        int [,] arr = new int[2,3];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                arr[i,j] = i + j;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                System.Console.WriteLine("arr[{0}][{1}]={2}", i, j, arr[i,j]);
            }
        }
	}
}
