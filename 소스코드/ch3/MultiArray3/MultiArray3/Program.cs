class MultiArray3
{
    static void Main()
    {
        int[][] var = new int[3][];
        var[0] = new int[1];
        var[1] = new int[2];
        var[2] = new int[3];
        // 배열 초기값 입력
        int i, j, k = 0;
        for (i = 0; i < 3; i++)
            for (j = 0; j < i + 1; j++)
                var[i][j] = k++;
        // 배열 내용 출력 
        for (i = 0; i < 3; i++)
        {
            for (j = 0; j < i + 1; j++)
                System.Console.Write(var[i][j] + "\t");
            System.Console.WriteLine();
        }
    }
}
