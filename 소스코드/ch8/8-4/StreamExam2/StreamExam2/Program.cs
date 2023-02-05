using System;
using System.IO;
class StreamExam2
{
    static void Main()
    {
        byte[] data = new byte[127];
        // Example.txt 파일을 읽기/쓰기 형태로 생성합니다.	
        FileStream file = new FileStream("Example.txt",
               FileMode.OpenOrCreate, FileAccess.ReadWrite);
        // BufferedStream 개체 생성
        BufferedStream bs = new BufferedStream(file);
        for (int i = 0; i < 127; i++)
        {   //  1~ 127 사이의 아스키(ASCII) 코드를 Exmaple.txt 에 출력
            data[i] = (byte)(i + 1);
        }
        bs.Write(data, 0, data.Length);
        bs.Close();  // 스트림을 닫습니다.

        // Example.txt 파일을 읽기 전용으로 읽어옴
        file = new FileStream("Example.txt", FileMode.Open, FileAccess.Read);
        bs = new BufferedStream(file);

        data = new byte[127];
        bs.Read(data, 0, 127);

        Console.WriteLine(System.Text.Encoding.Default.GetString(data));
        bs.Close();  // 스트림을 닫습니다.
    }
}
