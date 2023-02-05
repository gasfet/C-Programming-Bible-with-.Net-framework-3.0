using System;
using System.IO;
class StreamExam1
{
    static void Main()
    {
        // Example.txt 파일을 읽기/쓰기 형태로 생성합니다.	
        FileStream file = new FileStream("Example.txt",
                                    FileMode.OpenOrCreate, FileAccess.ReadWrite);
        for (int i = 1; i <= 127; i++)
        {   //  1~ 127 사이의 아스키(ASCII) 코드를 Exmaple.txt 에 출력
            file.WriteByte(Convert.ToByte(i));  // int형 1~127값을 byte로 변환해 저장
        }
        file.Close();  // 파일 스트림을 닫습니다.
        // Example.txt 파일을 읽기 전용으로 읽어옴
        file = new FileStream("Example.txt", FileMode.Open, FileAccess.Read);
        for (int i = 0; i < 127; i++)
        {    // 파일 내용을 127번 읽어 화면에 출력
            Console.Write(Convert.ToChar(file.ReadByte())); // char 형태로 출력
        }
        file.Close();  // 파일 스트림을 닫습니다.
    }
}

