using System;
class StringExam3
{
    static void Main()
    {
        long start = DateTime.Now.Ticks;    // 시작 시간 가져오기
        System.String str = null;              // str 문자열 선언

        for (int i = 0; i < 20000; i++)       // “안녕하세요”를 20000번 더함
        {
            str += "안녕하세요";
        }

        str = str.Replace('안', '만');           // 문자열에서 ‘안’자를 찾아 ‘만’자로 교체
        str = str.Remove(30, str.Length - 30);  // 앞에 30자만 남기고 제거

        long end = DateTime.Now.Ticks;     // 종료 시간 가져오기

        Console.WriteLine("str 크기: {0}", str.Length);  // 문자열 길이 출력
        Console.WriteLine("str 내용: {0}", str);         // 문자열 내용 출력

        Console.WriteLine("소요 시간 : {0}", end - start);  // 소요 시간 출력

        Console.ReadLine();
    }
}

