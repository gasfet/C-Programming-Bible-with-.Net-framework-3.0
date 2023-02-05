using System;
using System.Windows.Forms;
class NewWinForm6 : Form
{
    public NewWinForm6(string strText)
    {
        this.Text = strText;
        this.MouseEnter += new System.EventHandler(this.Form_MouseEnter);
        this.MouseLeave += new System.EventHandler(this.Form_MouseLeave);
        this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
        //this.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
        this.FormClosed += new FormClosedEventHandler(this.Form_Closed);
        this.FormClosing += new FormClosingEventHandler(this.Form_Closing);
        this.Show();
    }
    static void Main(string[] args)
    {
        Application.Run(new NewWinForm6("이벤트 등록"));
    }

    private void Form_MouseEnter(object sender, System.EventArgs e)
    {
        Console.WriteLine("MouseEnter 이벤트 발생!!!");
    }

    private void Form_MouseLeave(object sender, System.EventArgs e)
    {
        Console.WriteLine("MouseLeave 이벤트 발생!!!");

    }

    private void Form_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        Console.WriteLine("MouseMove 이벤트 발생!!!");
        Console.WriteLine("(x,y)=({0},{1})", e.X, e.Y);
    }

    private void Form_Closed(object sender, FormClosedEventArgs e)
    {
        Console.WriteLine("윈도우가 Closed 됩니다.");
    }

    private void Form_Closing(object sender, FormClosingEventArgs e)
    {
        Console.WriteLine("윈도우가 Closing 됩니다.");
    }
}