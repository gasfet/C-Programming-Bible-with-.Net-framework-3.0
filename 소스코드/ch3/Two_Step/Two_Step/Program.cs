class Two_Step
{
    static void Main()
    { // sum 약수의 합 , total 완전수 갯수
        int sum = 0, total = 0;
        for (int i = 1; i < 1001; i++)
        {
            for (int k = 1; k < i + 1; k++)
            {
                if (i % k == 0)
                    sum += k;
            }
            if ((sum - i) == i)
            {
                System.Console.WriteLine(i + " 는 완전수 입니다.!");
                total++;
            }
            sum = 0; // 약수의 합 초기화	
        }
        System.Console.WriteLine(" 1~1000 사이에 완전수는 " + total + "개 있습니다.");
    }
}
