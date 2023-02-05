class isOperator
{
    static void Main()
    {
        char data = 'a';    // 문자 변수 data를 선언함
        if (data is char)
            System.Console.WriteLine("문자 데이터입니다.");
        else
            System.Console.WriteLine("문자 데이터가 아닙니다.");
    }
}
