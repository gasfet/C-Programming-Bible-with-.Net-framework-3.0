class Array
{
    static void Main()
    {
		 int sum = 0 ;                  
		 int [] month ; 
		 month = new int[12] ;
		 month[0] = 31;   //  1월
		 month[1] = 28;   //  2월
		 month[2] = 31;   //  3월
		 month[3] = 30;   //  4월
		 month[4] = 31;   //  5월
		 month[5] = 30;   //  6월
		 month[6] = 31;   //  7월
		 month[7] = 31;   //  8월
		 month[8] = 30;   //  9월
		 month[9] = 31;   // 10월
		 month[10] = 30;  // 11월
		 month[11] = 31;  // 12월
		 
		 for( int i = 0 ; i < 12 ; i++)
		    	sum += month[i] ; 
		
		System.Console.WriteLine("모든 달의 합은 "+ sum ) ; 
	}
 }
