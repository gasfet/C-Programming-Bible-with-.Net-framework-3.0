using System;
using System.Text;
class StringExam5
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder("www.youngjin.co.kr", 25);  // 문자열 생성
        sb.Capacity = 20;      // StringBuilder의 용량을 20으로 축소

        Console.WriteLine(sb.ToString());    // 화면에 문자열 출력
        Console.WriteLine("Capacity    : {0}", sb.Capacity);  // 문자열 용량 출력
        Console.WriteLine("MaxCapacity : {0}", sb.MaxCapacity); // 최대 용량 출력
        Console.WriteLine("Length      : {0}", sb.Length);   // 문자열 길이 출력

        sb.Append(" 홈페이지 ");                   // 문자열 추가하기
        sb.AppendFormat("{0}{1}", "입니다.", "!");  // 형식화를 이용한 문자열 추가
        Console.WriteLine(sb.ToString());          // 문자열 출력하기
        Console.WriteLine("Capacity    : {0}", sb.Capacity); // 문자열 용량 출력
        Console.WriteLine("Length      : {0}", sb.Length);  // 문자열 길이 출력

        sb.Replace("홈페이지", "사이트");      // “홈페이지” 문자열을 찾아 “사이트”로 교체
        sb.Insert(0, "http://");                 // 문자열 첫머리에 “http://" 추가
        Console.WriteLine(sb.ToString());     // 문자열 출력하기
        Console.WriteLine(sb.ToString().ToUpper());  // 모든 문자를 대문자로 변환

        sb.Remove(25, sb.Length - 25);       // 25번째 문자부터 끝까지 삭제      
        Console.WriteLine(sb.ToString());      // 문자열 출력
    }
}
