class Return
{
    public static void Main()
	{
		int result = sum(10,20);
		System.Console.WriteLine( "10 + 20 = " + result );
	}

    static int sum(int x, int y)
    {
        return x + y;
    }
}
