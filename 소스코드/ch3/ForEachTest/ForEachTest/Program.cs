using System;
using System.Collections;   // ArrayList 컬렉션 참조
class ForEachTest
{
    static void Main()
    {
        int[] count = new int[] { 0, 1, 2, 3, 5, 8, 13 };   // 정수 배열
        string[] str = { "월", "화", "수", "목", "금", "토", "일" }; // 문자 배열

        ArrayList arr = new ArrayList();   // 컬렉션 
        arr.Add("한국"); arr.Add("미국");   // arr 컬렉션에 요소 추가
        arr.Add("중국"); arr.Add("영국");
        arr.Add("일본");

        foreach (int i in count) // 정수 배열 count에서 int 형 자료 i부터 마지막 
        {                      // 요소까지 출력하기
            Console.WriteLine(i);  // 0, 1, 2, 3, 5, 13 출력
        }

        foreach (string yoil in str) // 문자 배열 str 의 첫 번째 요소부터 출력
        {
            Console.Write(yoil + " \t "); // 월 ~ 일 출력
        }

        foreach (string item in arr) // 컬렉션 arr 첫 번째 요소부터 출력
        {
            Console.WriteLine(item);
        }
    }
}

