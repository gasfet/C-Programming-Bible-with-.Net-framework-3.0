using System;
using System.Windows.Forms;
class NewWinForm2
{
    static void Main(string[] args)
    {
        Form obj = new Form();
        obj.Text = "Form클래스를 이용한 윈폼";
        obj.SetBounds(10, 10, 300, 150);
        obj.MaximizeBox = false;
        obj.StartPosition = FormStartPosition.CenterScreen;
        Application.Run(obj);
    }
}

