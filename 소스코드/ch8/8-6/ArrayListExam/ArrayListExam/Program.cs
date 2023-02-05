using System;
using System.Collections;

class ArrayListExam
{
    static void Main(string[] args)
    {
        ArrayList obj = new ArrayList();
        obj.Add("안녕하세요");
        obj.Add(1000);
        obj.Add(DateTime.Now);

        foreach (Object data in obj)
        {
            Console.WriteLine("{0}", data);
        }

        int index = obj.IndexOf(1000);
        Console.WriteLine("숫자 1000 위치는 {0} 입니다.", index);

        obj.Insert(1, 10.5);
        Console.WriteLine("\n\n 데이터 추가 후 ArrayList 출력 \n");
        
        foreach (Object data in obj)
        {
            Console.WriteLine("{0}", data);
        }
    }
}

