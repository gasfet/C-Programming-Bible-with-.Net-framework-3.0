﻿using System;
using System.IO;
class FileExam3
{
    static void Main(string[] args)
    {
        if (args.Length < 1)  // 콘솔에서 아규먼트 값 입력받기
        {                      // 만약 입력한 매개변수 값이 없다면...
            Console.WriteLine("사용법 : FileExam3.exe [디렉토리 경로] ");
            return;          // 프로그램 종료
        }
        DirectoryInfo dinfo = new DirectoryInfo(args[0]);
        if (dinfo.Exists)  // 디렉토리가 존재하면 
        {
            DirectoryInfo[] dir = dinfo.GetDirectories(); // 하위디렉토리를 파일 정보 출력
            foreach (DirectoryInfo d in dir)
            {
                FileInfo[] files = d.GetFiles(); // 디렉토리 안에 있는 파일 목록 출력
                Console.WriteLine("디렉토리: {0}, 포함된 파일 수: {1}", d.FullName, files.Length);
                int index = 0;
                foreach (FileInfo f in files)    // 파일 이름 출력
                {
                    string str = String.Format("[{0}] : Name:{1}, Ext:{2}, Size:{3}",
                                                           ++index, f.Name, f.Extension, f.Length);
                    Console.WriteLine(str);
                }
            }
        }
    }
}

