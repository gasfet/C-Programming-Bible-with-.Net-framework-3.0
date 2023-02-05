using System;
class StringExam1
{
    static void Main()
    {
        System.String str = "Hello C#";    // 문자열 선언
        str += "MagicSoft.pe.kr";      // 문자열 + 문자열 연산 수행 

        System.Char ch = str[0];      // 문자열은 System.Char 의 배열 형태입니다.
        Console.WriteLine("str = {0} , ch = {1}", str, ch);  // 배열은 0부터 시작하므로
        // "Hello C#MagicSoft.pe.kr" 문자열의 첫 번째 글자인 H가 ch에 저장됩니다.

        for (int i = 0; i < str.Length; i++)  // 문자열의 Length 속성은 문자 배열의 크기임
        {
            Console.Write(str[i]); // str 문자열은 문자 배열 개념이므로 배열을 이용해
        }                               // 문자열 전체(0~ str.Length -1)를 읽어 출력합니다.

        Console.WriteLine("\n str 문자열의 길이: {0}", str.Length);
        Console.WriteLine(" str.IndexOf({0}) : {1}", "Magic", str.IndexOf("Magic"));
        // str 문자열의 앞머리부터 "Magic"이라는 문자열이 처음 나오는 위치 출력

        str = null;    // 문자열 str을 초기화합니다. 

        for (int i = 2; i < 10; i++)
            for (int j = 2; j < 10; j++)
            {        // 문자열에 구구단 결과를 출력합니다.
                str += i + " * " + j + " = " + (i * j) + "\r\n";
            }

        Console.WriteLine("****** 구구단 출력 ******");
        Console.WriteLine(str);  // 화면에 구구단을 출력합니다. 
    }
}
