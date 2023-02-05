using System;
class ConvertExam
{
   static void Main( )
   {
       string data1 = "1234567";
       float data2 = 10.5f;
       int data3 = 0;

       System.Console.WriteLine("문자열 data1=" + data1);
       data3 = System.Convert.ToInt32(data1) + System.Convert.ToInt32(data2);
       System.Console.WriteLine("계산값 =" + data3);
   }
}
