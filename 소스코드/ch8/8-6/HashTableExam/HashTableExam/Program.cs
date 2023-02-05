using System;
using System.Collections;

class HashTableExam
{
    static void Main(string[] args)
    {
        Hashtable obj = new Hashtable();
        obj.Add("strawberry", "딸기");
        obj.Add("apple", "사과");
        obj.Add("orange", "오렌지");
        obj.Add("banana", "바나나");
        obj.Add("melon", "멜론");

        Console.WriteLine("=====[1]=============================");
        foreach (DictionaryEntry data in obj)
        {
            Console.WriteLine("{0} : {1}", data.Key, data.Value);
        }
        
        obj.Add("pineapple", "파인애플");
        obj.Remove("banana");        

        Console.WriteLine("=====[2]=============================");
        
        foreach (DictionaryEntry data in obj)
        {
            Console.WriteLine("{0} : {1}", data.Key, data.Value);
        }

        Console.WriteLine("=====[3]=============================");

        Console.WriteLine("{0}", obj.Contains("orange")? "바나나 있음":"바나나 없음");
        Console.WriteLine("{0}", obj.ContainsValue("포도") ? "포도 있음" : "포도 없음");
    }
}

