using System;
class Arithmetic1
{
    static void Main()
    {
        byte A = 10;
        short B = 10;
        short C = 0;
        C = A + B;  // 에러발생 ! C변수를 int 형으로 고쳐야 함
    }
}

