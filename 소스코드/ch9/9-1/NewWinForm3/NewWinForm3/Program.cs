using System;
using System.Windows.Forms;
class NewWinForm3
{
    static string[] strText = { "빨", "주", "노", "초", "파", "남", "보" };
    static void Main(string[] args)
    {
        Form[] wnd = new Form[7];
        for (int i = 0; i < 7; i++)
        {
            wnd[i] = new Form();
            wnd[i].Text = strText[i];
            wnd[i].SetBounds((i + 1) * 10, (i + 1) * 10, 100, 100);
            wnd[i].MaximizeBox = false;
            wnd[i].Show();
            Console.WriteLine("{0} 번째 윈도우 출력 성공!!!", i);
        }

        Application.Run(wnd[0]);
    }
}