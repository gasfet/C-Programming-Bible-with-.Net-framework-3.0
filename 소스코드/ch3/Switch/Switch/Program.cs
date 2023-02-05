using System;
class Switch
{
    static void Main()
    {
        for (int i = 0; i <= 6; i++)
        {
            Console.Write(i);
            switch (i)
            {
                case 1:       // i 값이  1 일때
                case 3:       // i 값이  3 일때
                case 5:       // i 값이  5 일때
                    Console.WriteLine("는 홀수 입니다.");
                    break;  // switch 문 탈출 -> 21 라인으로 이동
                case 2:      // i 값이  2 일때  
                case 4:      // i 값이  4 일때
                case 6:      // i 값이  6 일때
                    Console.WriteLine("는 짝수 입니다.");
                    break;  // switch 문 탈출 -> 21 라인으로 이동
                default:     // i 값이 case와 일치하지 않을 경우에
                    Console.WriteLine(" 홀수도 짝수도 아닙니다.");
                    break;
            }
        }
    }
}
