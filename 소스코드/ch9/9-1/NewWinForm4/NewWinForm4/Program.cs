using System;
using System.Windows.Forms;
class NewWinForm4 : Form
{
    public NewWinForm4(string strText)
    {
        this.Text = strText;
        this.Top = 10;
        this.Left = 10;
        this.Width = 250;
        this.Height = 200;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Show();
    }
    static void Main(string[] args)
    {
        Application.Run(new NewWinForm4("상속받아 구현된 윈도우"));
    }
}