class One_Step
{
    static void Main()
	{
		int sum = 0 ; // 구하고자 하는 총합
		
		for( int k = 1 ; k < 1001 ; k++)
        {
			if( k%3 == 0 & k%7 == 0 )
                sum += k ;
		}
		
		System.Console.WriteLine("결과 : "+sum);
	}
}
