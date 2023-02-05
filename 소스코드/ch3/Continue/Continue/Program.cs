class Continue 
{
	static void Main()
	{
		int sum = 0 ;
		for( int i = 0 ; i < 10 ; i++)
        { // 이동!
			if( i%2 == 0 ) continue ;
		    sum +=  i ; 
		    System.Console.Write( i + "\t" );
		}
        System.Console.Write("Sum = " + sum);
	}
 }
