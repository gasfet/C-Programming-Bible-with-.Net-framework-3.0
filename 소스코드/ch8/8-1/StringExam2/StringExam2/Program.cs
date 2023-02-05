using System;
class SystemExam2
{
	static void Main()
	{
		string str = " 가나다라마바사 ";
		Console.WriteLine("[{0}]", str);
		Console.WriteLine("[{0}]", str.TrimStart());  // 왼쪽 공백 제거
		Console.WriteLine("[{0}]", str.TrimEnd());   // 오른쪽 공백 제거
		Console.WriteLine("[{0}]", str.Trim());       // 양쪽 공백 제거
		Console.WriteLine("[{0}]", str.TrimStart().TrimEnd()); // 양쪽 공백 제거
		Console.WriteLine("[{0}]", str.Insert(2, "ABC"));  // 2번째 위치부터 “ABC"삽입
                    // " 가나다라마바사 “ + ”OneTwo하나둘“ 문자열 합하기
		Console.WriteLine("[{0}]", str + String.Concat("One", "Two", "하나", "둘"));
                    Console.WriteLine("[{0}]", str.Replace("나", "K"));  // 문자 ‘나‘를 찾아 ’K'로 변환
                    // 문자열 “라마바”를 찾아 “MAGIC"으로 변환
		Console.WriteLine("[{0}]", str.Replace("라마바", "MAGIC"));
                    // 문자 ‘나’를 찾아 ‘K'로 변환하고 다시 “라마바”를 찾아 “MAGIC"으로 변환
		Console.WriteLine("[{0}]", str.Replace("나", "K").Replace("라마바", "MAGIC"));
		// 문자열 출력 포맷 {0}*{1}={2}에 맞춰 문자열 작성	
		Console.WriteLine("[{0}]", String.Format("포맷 문자열 {0}*{1}={2}", 10, 10, 10*10));
                    // 문자열 3번 위치에서 3문자만큼 제거
		Console.WriteLine("[{0}]", str.Remove(3,3));
                    // str과 입력 문자열을 비교해 같으면 0, str문자가 크면 양수, str문자가 작으면 음수 반환
		if(str.CompareTo(" 가나다라마바사 ") == 0)
		    Console.WriteLine("같습니다.");
		else
		    Console.WriteLine("같지 않습니다.");
		
	}
}

