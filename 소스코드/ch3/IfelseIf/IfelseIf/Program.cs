using System;
class IfelseIf
{
    public static void Main(string[] args)
    {
        int grade = 85 ;  // 초기화 지정

        if( grade > 90 )
		  Console.WriteLine("성적은 A 입니다.");
		else if( grade > 80 )
	      Console.WriteLine("성적은 B 입니다.");
		else if( grade > 70 )
		  Console.WriteLine("성적은 C 입니다.");
		else if( grade > 60 )
		  Console.WriteLine("성적은 D 입니다.");
		else
          Console.WriteLine("성적은 F 입니다.");		
	}
}

