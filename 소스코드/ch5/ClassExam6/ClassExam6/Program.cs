using System;
class Example
{
    private int size;
    public string[] strArray;
    public string this[int index]
    {
        get
        {
            if (index > -1 && index < size)
            {
                return strArray[index];
            }
            else
            {
                Console.WriteLine("인덱스값 오류!!!");
                return null;
            }
        }
        set { strArray[index] = value; }
    }
    public int Length
    {
        get { return strArray.Length; }
    }
    public Example(int strSize)
    {
        size = strSize;
        strArray = new string[size];
    }
}
class ClassExam6
{
    static void Main(string[] args)
    {
        Example obj = new Example(3);
        obj[0] = "안녕하세요!!!";
        obj[1] = "인덱스 예제입니다.";
        obj[2] = "인덱스는 스마트 배열로 불립니다.";

        for (int i = 0; i < obj.Length; i++)
        {
            Console.WriteLine("obj[{0}] = {1}", i, obj[i]);
        }
    }
}

