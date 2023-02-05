using System;
class Arithmetic2
{
    static void Main() 
	{
		int i = 10 ;

		Console.WriteLine("전위 연산자가 사용된 i = "+ (++i));
        Console.WriteLine("후위 연산자가 사용된 i = "+ (i++));
        Console.WriteLine("후위 연산자 사용 후  i = " + i); 
	}
}
