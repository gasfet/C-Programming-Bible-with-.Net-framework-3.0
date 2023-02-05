﻿using System;
using System.IO;
class FileExam1
{
    static void Main()
    {         // DirectoryInfo 개체 변수 생성
        DirectoryInfo dinfo = new DirectoryInfo(@"C:\Program Files\Internet Explorer");

        if (dinfo.Exists)  // 해당 디렉토리가 존재하면
        {
            Console.WriteLine("전체 경로     : {0}", dinfo.FullName);
            Console.WriteLine("디렉토리 이름 : {0}", dinfo.Name);
            Console.WriteLine("생성일        : {0}", dinfo.CreationTime);
            Console.WriteLine("디렉토리 속성 : {0}", dinfo.Attributes);
            Console.WriteLine("루트 경로     : {0}", dinfo.Root);
            Console.WriteLine("부모 디렉토리 : {0}", dinfo.Parent);
        }
        else
        {
            Console.WriteLine("디렉토리가 존재하지 않습니다.");
        }
    }
}

