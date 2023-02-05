using System;
using System.IO;
class StreamExam3
{
    static void Main()
    {
        // Example.txt 파일을 읽기/쓰기 형태로 생성합니다.	
        FileStream file = new FileStream("Example.txt",
            FileMode.OpenOrCreate, FileAccess.ReadWrite);
        StreamWriter sw = new StreamWriter(file);     // StreamWriter 개체 생성			sw.WriteLine("Stream 클래스 예제입니다.");       // 문장 단위로 데이터 입력
        sw.WriteLine("C# 스트림 클래스는 강력합니다.");  // 문장 단위로 데이터 입력
        sw.WriteLine("www.magicsoft.pe.kr");           // 문장 단위로 데이터 입력
        sw.Close();  // 스트림을 닫습니다.

        // Example.txt 파일을 읽기 전용으로 읽어옴
        file = new FileStream("Example.txt", FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(file);     // StreamReader 개체 생성
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(sr.ReadLine());      // 문장 단위로 읽어
        }		                             // 화면에 출력		
        sr.Close();  // 스트림을 닫습니다.
    }
}

