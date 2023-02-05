class A          // A 클래스
{            
    public int a = 1;   // A 클래스의 객체 속성 변수
}
class B : A      // A를 상속받은 B클래스
{
    public int b = 2;  // B 클래스의 객체 속성 변수
}
class C : B      // B를 상속받은 C클래스
{
    public int c = 3;  // C 클래스의 객체 속성 변수
}
class InheritanceEx1
{
    static void Main(string[] args)
    {
 		C ins = new C();  // C 클래스의 객체 참조 변수 ins
        System.Console.WriteLine("ins 의 객체 속성 변수 a 의 값은 " + ins.a);
        System.Console.WriteLine("ins 의 객체 속성 변수 b 의 값은 " + ins.b);
        System.Console.WriteLine("ins 의 객체 속성 변수 c 의 값은 " + ins.c);
    }
}

