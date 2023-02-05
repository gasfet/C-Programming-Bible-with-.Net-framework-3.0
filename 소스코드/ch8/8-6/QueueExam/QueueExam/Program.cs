using System;
using System.Collections;
class QueueExam
{
    static void Main(string[] args)
    {
        Queue obj = new Queue();
        obj.Enqueue("strawberry");
        obj.Enqueue("apple");
        obj.Enqueue("orange");
        obj.Enqueue("banana");
        obj.Enqueue("melon");

        Console.WriteLine("=====[1]=============================");
        foreach (Object data in obj)
            Console.WriteLine("{0}", data);

        obj.Dequeue();
        obj.Dequeue();
        obj.Enqueue("pineapple");

        Console.WriteLine("=====[2]=============================");
        foreach (Object data in obj)
            Console.WriteLine("{0}", data);

        Console.WriteLine("=====[3]=============================");
        Console.WriteLine("{0}", obj.Contains("apple") ? "사과 있음" : "사과 없음");
        Console.WriteLine("첫번째 요소 {0}", obj.Peek());
        foreach (Object data in obj)
            Console.WriteLine("{0}", data);
        
    }
}


