using System;
class SwitchSwitch
{
    static void Main()
    {
        int count = 3;
        int age = 25;
        switch (count)
        {
            case 1:
                break;
            case 3:
                switch (age)
                {
                    case 20:
                    case 25:
                        Console.WriteLine(count + "를 선택하고 나이는 20대");
                        break;
                    case 30:
                    case 35:
                        Console.WriteLine(count + "를 선택하고 나이는 30대");
                        break;
                }
                break;
            default:
                break;
        }
    }
}
