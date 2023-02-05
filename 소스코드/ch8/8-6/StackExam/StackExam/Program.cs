using System;
using System.Collections;
class StackExam
{
    static void Main(string[] args)
    {
        Stack obj = new Stack();
        obj.Push("strawberry");
        obj.Push("apple");
        obj.Push("orange");
        
        Console.WriteLine("=====[1]=============================");
        foreach (Object data in obj)
            Console.WriteLine("{0}", data);

        obj.Peek();                
        Console.WriteLine("=====[2]=============================");
        foreach (Object data in obj)
            Console.WriteLine("{0}", data);

        Console.WriteLine("=====[3]=============================");
        Console.WriteLine("{0}", obj.Contains("apple") ? "사과 있음" : "사과 없음");
        Console.WriteLine("첫번째 요소 {0} 제거", obj.Pop());
        foreach (Object data in obj)
            Console.WriteLine("{0}", data);
        
    }
}

