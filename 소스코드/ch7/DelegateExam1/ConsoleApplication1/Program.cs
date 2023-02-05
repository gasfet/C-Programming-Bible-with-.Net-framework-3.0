class Arithmetic
{
    public int Add(int a, int b)
    {
        return a + b;
    }
    public int Sub(int a, int b)
    {
        return a - b;
    }
    public int Mul(int a, int b)
    {
        return a * b;
    }
    public int Div(int a, int b)
    {
        if ((a == 0) || (b == 0))
            return 0;
        return a / b;
    }
    public void PrintInfo(string str)
    {
        System.Console.WriteLine("Arithmetic::PrintInfo = {0}", str);
    }
}

public delegate int ArithmeticDelegate(int a, int b);    // 델리게이트 선언
public delegate void PrintInfoDelegate(string srt);

class DelegateExam1
{
    public static void Main()
     {
         Arithmetic obj = new Arithmetic();
         ArithmeticDelegate ex1 = new ArithmeticDelegate(obj.Add); //Add메서드를 가리키는 델리게이트 생성
         System.Console.WriteLine("Add: ex(20, 10) = {0}", ex1(20, 10));
         ex1 = new ArithmeticDelegate(obj.Sub);            //Sub메서드를 가리키는 델리게이트 생성
         System.Console.WriteLine("Sub: ex(20, 10) = {0}", ex1(20, 10));
         ex1 = new ArithmeticDelegate(obj.Mul);            //Mul메서드를 가리키는 델리게이트 생성 
         System.Console.WriteLine("Mul: ex(20, 10) = {0}", ex1(20, 10));
         ex1 = new ArithmeticDelegate(obj.Div);            //Div메서드를 가리키는 델리게이트 생성
         System.Console.WriteLine("Div: ex(20, 10) = {0}", ex1(20, 10));

         PrintInfoDelegate ex2 = new PrintInfoDelegate(obj.PrintInfo); //Add메서드를 가리키는 델리게이트 생성
         ex2("델리게이트 예제");
     }
}
