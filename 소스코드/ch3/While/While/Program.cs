class While
{
	static void Main()
	{
		int sum = 0 ; 
		int i = 1 ;  
		while( i < 101 )
        {
			sum += i ;
			i = i + 2 ;
		}
		System.Console.WriteLine("1~100의 홀수의 합은 " + sum);
	}
}
