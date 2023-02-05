using System;
class DataTypeInfo
{
    static void Main()
    {
        int data1 = 1;
        float data2 = 10.5f;
        Console.WriteLine("data1과 data2는 {0}", data1.Equals(data2));
        Console.WriteLine("data1 타입:{0}", data1.GetType());
        Console.WriteLine("data2 타입:{0}", data2.GetType());
        Console.WriteLine("data2의 문자열:{0}", data2.ToString());
        Console.WriteLine("data2의 해쉬코드:{0}", data2.GetHashCode());
        Console.WriteLine("data1의 BaseType:{0}", data1.GetType().BaseType);
        Console.WriteLine("문자열의 BaseType:{0}", "문자열".GetType().BaseType);
    }
}
