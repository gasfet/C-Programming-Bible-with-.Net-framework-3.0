// 접근 제한자 이해하기
using System;
class Class1
{
    public int i = 0;
    private int j = 1;
    protected int k = 2;
}
class Class2 : Class1
{
    void Display()
    {
        Console.WriteLine("i + k = {0}", i + k);
        // Console.WriteLine(" j = {0} ", j); 보호 수준 때문에 'Class1.j'에 액세스할 수 없습니다.
    }
}

class ClassExam7
{
    static void Main(string[] args)
    {
        Class1 obj1 = new Class1();
        Console.WriteLine("Class1.i = {0}", obj1.i);
        //Console.WriteLine("Class1.j = {0}", obj1.j);
        //Console.WriteLine("Class1.k = {0}", obj1.k);

        Class2 obj2 = new Class2();
        //obj2.Display(); 생략하면 기본적으로 private

        OutClass obj3 = new OutClass();
        obj3.i = 1000;
        Console.WriteLine("OutClass.i = {0}", obj3.i);
    }
}



