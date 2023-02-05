using System;
public class ValidateExam
{
    /// <summary>
    ///  숫자와 영문 입력 체크 메서드
    /// </summary>
    /// <param name="str">체크할 문자열</param>
    /// <returns></returns>
    private bool A_or_D(string str)
    {
        // 소문자로 만들기
        string lower_str = str.ToLower();
        // a~z , 0< ? < 9 안에 포함되었는지 검사
        foreach (char ch in lower_str)
        {
            if (((ch < 'a') || (ch > 'z')) && ((ch < '0') || (ch > '9')))
                return false;
        }
        return true;
    }

    /// <summary>
    /// 전화 번호 입력 체크 메서드
    /// </summary>
    /// <param name="str">체크할 전화번호</param>
    /// <returns></returns>
    private bool Tel_Check(string str)
    {
        // 분석할 문자열을 소문자로 만듬
        string lower_str = str.ToLower();
        // 전화번호는 - 와 0~9 사이 값이 같이 입력되어야 함
        if (lower_str.IndexOf("-") == -1)
        {
            return false;
        }

        foreach (char ch in lower_str)
        {
            if ((ch != '-') && ((ch < '0') || (ch > '9')))
                return false;
        }
        return true;
    }

    /// <summary>
    /// 숫자 입력 확인
    /// </summary>
    /// <param name="str">분석할 문자열</param>
    /// <returns></returns>
    private bool Digit_Check(string str)
    {
        // 소문자로 변환
        string lower_str = str.ToLower();
        // 0~9 숫자 인지 확인
        foreach (char ch in lower_str)
        {
            if ((ch < '0') || (ch > '9'))
                return true;
        }
        return false;
    }

    /// <summary>
    ///  E 메일 주소 유효성 검사 메서드
    /// </summary>
    /// <param name="str">검사할 문자열</param>
    /// <returns></returns>
    private bool Email_Check(string str)
    {
        byte stock = 0;
        // 전자 우편 주소는 @ 와 . 이 포함되어 있어야함.
        foreach (char ch in str)
        {
            if (ch == '@' || ch == '.') stock++;
        }
        if (stock >= 2) return true;
        return false;
    }

    /// <summary>
    /// 주민번호 유효성 검사 메서드
    /// </summary>
    /// <param name="str">검사할 주민번호</param>
    /// <returns></returns>
    private bool Check_Digit(string str)
    {
        if (Digit_Check(str)) return false; // 숫자만 입력했는지 체크
        if (str.Length != 13) return false; // 주민 번호는 13자리 수
        int sum = 0;   // 유효성 계산
        int temp = 0;
        // 주민 번호를 배열에 저장
        int[] num = new int[13];
        // 가중치 값 저장
        int[] digit = { 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5 };

        // 입력된 문자를 숫자로!
        for (int i = 0; i < 13; i++)
        {
            num[i] = Int32.Parse(str[i] + "");
        }

        // 주민 번호 유효성 검사
        for (int i = 0; i < 12; i++)
        {
            sum += digit[i] * num[i];
        }
        // 유효성 검증
        temp = sum % 11;

        int check_digit_num1 = temp;
        int check_digit_num2 = num[12];

        if (check_digit_num1 == 0)
        {
            if (check_digit_num2 == 1)
                return true;
            else
                return false;
        }
        else if (check_digit_num1 == 1)
        {
            if (check_digit_num2 == 0)
                return true;
            else
                return false;
        }
        else if ((11 - check_digit_num1) == check_digit_num2) return true;
        else return false;
    }

    public static void Main()
    {
        ValidateExam obj = new ValidateExam();    // 유효성 검증 클래스 객체 생성

        Console.Write("문자열을 입력하세요. >> ");
        string msg = Console.ReadLine();        //  유효성을 검사할 문자열 입력 받기

        if (obj.A_or_D(msg.Trim()))        // 입력한 문자열이 영문자 혹은 숫자읹 검사
        {
            Console.WriteLine("{0}: 영문자 혹은 숫자", msg);
        }
        else
        {
            Console.WriteLine("{0}: 영문자 혹은 숫자가 아닌 문자 있음!", msg);
        }

        Console.Write("전화번호를 입력하세요.(예. 02-1234-5678) >> ");
        msg = Console.ReadLine();            // 전화 번호 문자열 입력 받기

        if (obj.Tel_Check(msg.Trim()))       // 전화번호 유효성 검증
        {
            Console.WriteLine("{0}는 유효한 전화번호입니다.", msg);
        }
        else
        {
            Console.WriteLine("{0}는 유효하지 않은 전화번호입니다.", msg);
        }

        Console.Write("전자 우편 주소를 입력하세요. >> ");
        msg = Console.ReadLine();        // Email 주소 입력 받기

        if (obj.Email_Check(msg.Trim()))   // Email 주소 유효성 검사
        {
            Console.WriteLine("{0}는 유효한 전자 우편 주소입니다.", msg);
        }
        else
        {
            Console.WriteLine("{0}는 유효하지 않은 전자 우편 주소입니다.", msg);
        }

        Console.Write("주민 번호를 입력하세요. >> ");
        msg = Console.ReadLine();       // 주민 번호 입력

        if (obj.Check_Digit(msg.Trim()))    //  주민 번호 유효성 검사
        {
            Console.WriteLine("{0}는 유효한 주민 번호입니다.", msg);
        }
        else
        {
            Console.WriteLine("{0}는 유효하지 않은 주민 번호입니다.", msg);
        }

    }
}



