class GoTo
 {
   public static void Main()
    {
        int index = 2;

        for( int i = 0 ; i < 10 ; i++)
        {
         for( int j = 0 ; j < 10 ; j++)
         {
          for( int k = 0 ; k < 10 ; k++)
          {
		    System.Console.WriteLine("{0}*{1}*{2}={3}", i, j, k, i*j*k);
		    goto next ;  
          }
         }
       }
       
       next:       
       switch (index)
       {
           case 1:
               System.Console.WriteLine("Index => 1");
               goto case 3;
               break;
           case 2:
               System.Console.WriteLine("Index => 2");		
               goto case 1;
               break;
           case 3:
               System.Console.WriteLine("Index => 3");		
               break;
       }

	  System.Console.WriteLine("프로그램 종료!");		
	}	
 }
