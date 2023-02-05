using System;
using System.IO;
using System.Text;
class StreamExam4
{
    static void Main()
    {
        MemoryStream mem = new MemoryStream();  // 메모리 스트림 생성
        mem.Capacity = 18;   // 메모리 스트림 크기 지장
        mem.Position = 0;     // 스트림의 위치를 시작 부분으로 이동
        byte[] data = Encoding.Default.GetBytes("www.magicsoft.pe.kr");

        mem.Write(data, 0, data.Length);   // byte 배열을 메모리 스트림에 출력

        mem.Position = 3;              // 메모리 스트림에서 4번째 위치로 이동
        mem.WriteByte((byte)65);       // 4번째 데이터를 65(대문자 A)로 변경

        data = mem.GetBuffer();         // 메모리 스트림 전체 내용을 byte 배열로 반환
        Console.WriteLine(Encoding.Default.GetString(data));  // 화면에 문자열로 변경 출력
    }
}

