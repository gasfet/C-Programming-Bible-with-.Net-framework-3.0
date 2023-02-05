class MultiArray1
{
    static void Main()
    {
        int[,] array = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
        System.Console.WriteLine("array[0,0]:{0}, array[2,1]:{1}, array[1,1]:{2}",
                                    array[0, 0], array[2, 1], array[1, 1]);
    }
}
