using System;
using System.Collections;
class ForEachTest
{
    static void Main(string[] args)
    {
        int[] count = new int[] { 0, 1, 2, 3, 5, 8, 13 };
        string[] str = { "월", "화", "수", "목", "금", "토", "일" };

        ArrayList arr = new ArrayList();
        arr.Add("한국");
        arr.Add("미국");
        arr.Add("중국");
        arr.Add("영국");
        arr.Add("일본");

        
        foreach(int i in count)
        {
            Console.WriteLine(i);
        }

        foreach (string yoil in str)
        {
            Console.Write(yoil + " \t ");
        }
        
        foreach (string item in arr)
        {
            Console.WriteLine(item);
        }

        /*
        
        for (int i = 0; i < count.Length; i++)
        {
            Console.WriteLine(i);
        }

        for (int j = 0; j < str.Length; j++)
        {
            Console.WriteLine(str[j] + " \t ");
        }

        for (int k = 0; k < arr.Count; k++)
        {
            Console.WriteLine(arr[k].ToString());
        }
        */
    }
}