﻿using System;
using System.IO;
class FileExam4
{
    static void Main(string[] args)
    {
        if (args.Length < 2)   // 입력한 매개변수가 2개 미만이면 사용법 출력 후 종료
        {
            Console.WriteLine("사용법 : FileExam4.exe [복사할 파일]  [복사할 경로]");
            return;
        }
        FileInfo s_file = new FileInfo(args[0]);    // FileInfo 개체 생성
        string dest_filename = args[1] + s_file.Name;  // 저장할 파일 경로 지정
        if (s_file.Exists)                           // 복사하려는 파일이 이미 존재하면
        {
            Console.WriteLine("{0} 파일을 {1}로 복사합니다...", s_file.Name, args[1]);
            FileInfo c_file = s_file.CopyTo(dest_filename, true); // 파일 복사
            c_file.MoveTo(dest_filename);  // 파일 이동
            if (c_file.Exists)                // 파일이 존재하면 
            {
                Console.WriteLine("파일을 성공적으로 복사했습니다.!");
            }
        }
        //복사한 파일을 삭제하려면 대문자 Y를 입력합니다. 
        Console.WriteLine("복사한 파일을 삭제하려면 Y 키를 입력하세요 >>");
        string input = Console.ReadLine().Trim();    // 사용자 메시지 입력

        if (input[0] == 'Y')  // 대문자 Y를 입력하면 
        {
            FileInfo m_file = new FileInfo(dest_filename);
            m_file.Delete();   // 파일 삭제
            Console.WriteLine("{0} 파일을 삭제했습니다!", m_file.Name);
        }
    }
}

