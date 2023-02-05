class Char
{
    static void Main()
    {
        char ch1 = '\u0061';     // 유니코드 형식
        char ch2 = (char)97;     // 숫자 형식
        char ch3 = 'a';            // 문자 형식  
        System.Console.Write("\'출력[1]\' 문자열>> " + ch1 + "\t");
        System.Console.Write("\"출력[2]\" 문자열>> " + ch2 + "\t");
        System.Console.Write("\\출력[3]\\ 문자열>> " + ch3 + "\n");
    }
}

