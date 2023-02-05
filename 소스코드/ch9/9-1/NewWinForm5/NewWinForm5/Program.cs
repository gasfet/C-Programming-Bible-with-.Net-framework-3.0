using System;
using System.Windows.Forms;
class NewWinForm5 : Form
{
    public NewWinForm5(string strText)
    {
        this.Text = strText;
        this.Load += new System.EventHandler(this.Form_Load);
        this.FormClosed += new FormClosedEventHandler(this.Form_Closed);
        this.Show();
    }
    static void Main(string[] args)
    {
        Application.Run(new NewWinForm5("이벤트 등록"));
    }

    private void Form_Load(object sender, System.EventArgs e)
    {
        Console.WriteLine("윈도우가 Load 됩니다.");
    }

    private void Form_Closed(object sender, FormClosedEventArgs e)
    {
        Console.WriteLine("윈도우가 Closed 됩니다.");
    }
}


