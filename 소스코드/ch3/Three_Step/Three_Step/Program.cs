class Three_Step
{
    static void Main(string[] args)
    {
        int i, k, wc;
        int[] m = new int[3];

        if (args.Length != 3)
        {
            System.Console.WriteLine("3개의 10진수를 입력하세요!");
            return; // 프로그램 종료
        }

        for (i = 0; i < 3; i++)
            m[i] = System.Int32.Parse(args[i]);

        for (i = 0; i < 3; i++)
        {
            System.Console.Write(m[i] + " 은 이진수로 ==> ");
            for (k = 31; k >= 0; --k)
            {
                wc = (m[i] >> k) & 0x1;  //정수는 32비트이므로 이와같이 처리함.
                System.Console.Write(wc);
            }
            System.Console.WriteLine();
        }
    }
}
