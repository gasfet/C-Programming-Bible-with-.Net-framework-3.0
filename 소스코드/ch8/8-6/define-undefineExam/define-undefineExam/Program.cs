#define UNIX_BASE
#undef UNIX_BASE

using System;

namespace define_undefineExam
{
    class Program
    {

 #region Member Variable Block
        int data = 10;
        string str = "문자열 초기화... ";
 #endregion
 #region Method Block
        void Show() { Console.WriteLine("보여주기..."); }
  #endregion

        static void Main(string[] args)
        {

            int a = 1;
            int b = 1;

#line 1000
#warning "이 부분은 Real-Time 시에 정상작동 하는지 확인필요!!!"
         Console.WriteLine("a / b 결과는 {0} 입니다.", a / b); // b가 0이 들어오면???


#line 500 "define-undefineExam.cs"
#warning "#라인을 500으로 변경"


#line default
#warning "#line 문의 default 적용"


        Console.WriteLine("디버거 모드 시작"); 
#line hidden
            Console.WriteLine("디버거 모드 숨김");
#line default
            Console.WriteLine("디버거 모드 종료"); 

#if UNIX_BASE    // UNIX 기반 Mono 플랫폼으로 컴파일시에
#error "작성된 코드는 Mono 플랫폼에서는 사용할 수 없음!!!"
#endif
        }
    }
}
