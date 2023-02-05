class Break1
{
    static void Main()
	{
		int sum = 0 ;
		for(int i = 0 ; i < 100 ; i++)
        {
			if( i% 3 == 0)
            { // 3의 배수 구하기
				sum += i ;			
				System.Console.Write( i + "\t") ;
			}
			if( sum > 200 ) break ;
		} //  이곳으로 이동
        System.Console.WriteLine("Sum = " + sum);
	}
}
