using System;
using System.IO;
class FileExam5
{
    static void Main(string[] args)
    {
        if (args.Length < 2)   // 입력한 매개 변수가 2개 미만이면...
        {
            Console.WriteLine("사용법 : FileExam5.exe [옵션] [디렉토리명]");
            Console.WriteLine("옵션   : -m  디렉토리 만들기");
            Console.WriteLine("       : -mm 디렉토리 생성 후 하위 디렉토리로 temp 생성"); Console.WriteLine("       : -r  디렉토리 삭제");
            Console.WriteLine("       : -rr 하위 디렉토리와 파일까지 모두 삭제"); return;
        }

        DirectoryInfo dir = new DirectoryInfo(args[1]);   // 디렉토리 정보 가져오기

        if (args[0].Trim() == "-m")  // 만약 옵션이 -m 일 경우(디렉토리 만들기)
        {
            if (dir.Exists)  // 만들려는 디렉토리가 이미 존재하면...
            {
                Console.WriteLine("{0} 디렉토리가 이미 존재합니다.", args[1]);
            }
            else
            {
                dir.Create();  // 디렉토리 생성
                Console.WriteLine("{0} 디렉토리 생성!", args[1]);
            }
        }
        else if (args[0].Trim() == "-mm")  // 옵션이 -mm 일 경우
        {   // 디렉토리를 생성한 후 Temp, Bin\Debug 하위 디렉토리 생성
            if (dir.Exists)
            {
                Console.WriteLine("{0} 디렉토리가 이미 존재합니다.", args[1]);
            }
            else
            {
                dir.Create();    // 디렉토리 생성
                dir.CreateSubdirectory(@"Temp");   // 하위 디렉토리 생성
                dir.CreateSubdirectory(@"Bin\Debug"); // 하위 디렉토리 생성
                Console.WriteLine("{0} 디렉토리 생성!", args[1]);
                Console.WriteLine("{0} 하위 디렉토리 생성!", "Temp");
                Console.WriteLine("{0} 하위 디렉토리 생성!", @"Bin\Debug");
            }
        }
        else if (args[0].Trim() == "-r")   // 옵션이 -r 일 경우
        {
            if (dir.Exists)    // 삭제하려는 디렉토리가 존재하면
            {
                dir.Delete();  // 해당 디렉토리를 삭제
                Console.WriteLine("{0} 디렉토리 삭제!", args[1]);
            }
            else
            {
                Console.WriteLine("{0} 디렉토리가 존재하지 않습니다.", args[1]);
            }
        }
        else if (args[0].Trim() == "-rr")  // 옵션이 -rr일 경우 
        {       // 하위 디렉토리까지 모두 삭제
            if (dir.Exists)    // 삭제하려는 디렉토리가 존재하면
            {
                dir.Delete(true);  // 모든 하위 디렉토리 삭제
                Console.WriteLine("{0} 디렉토리 하위항목까지 모두 삭제!", args[1]);
            }
            else
            {
                Console.WriteLine("{0} 디렉토리가 존재하지 않습니다.", args[1]);
            }
        }
        else
        {
            Console.WriteLine("옵션이 잘못되었습니다!");
            return;
        }

    }
}

