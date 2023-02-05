﻿using System;
using System.IO;
class FileExam2
{
    static void Main()
    {
        FileInfo finfo = new FileInfo(@"c:\test.txt");  // FileInfo 개체 생성

        if (finfo.Exists)  // 파일이 존재하면 
        {
            Console.WriteLine("폴더 이름 : {0}", finfo.Directory);
            Console.WriteLine("파일 이름 : {0}", finfo.Name);
            Console.WriteLine("확장자    : {0}", finfo.Extension);
            Console.WriteLine("생성일    : {0}", finfo.CreationTime);
            Console.WriteLine("파일 크기 : {0} byte", finfo.Length);
            Console.WriteLine("파일 속성 : {0}", finfo.Attributes);
        }
        else
        {
            Console.WriteLine("파일이 존재하지 않습니다.");
        }
    }
}
