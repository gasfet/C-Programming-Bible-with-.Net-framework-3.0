using System;
using System.Drawing;
using System.Windows.Forms;

public class ScreenExam : System.Windows.Forms.Form
{
    Random rnd = new Random();
    public ScreenExam()
    {
        this.Text = "타이머를 이용한 화면 보호기";
        this.Bounds = Screen.PrimaryScreen.Bounds;
        Timer time = new Timer();
        time.Interval = 50;
        time.Tick += new EventHandler(time_Tick);
        time.Enabled = true;
    }

    protected void time_Tick(object obj, EventArgs ea)
    {
        Graphics grfx = this.CreateGraphics();
        int shape = rnd.Next(3);
        switch (shape)
        {
            case 0:
                grfx.DrawEllipse(Pens.Red, rnd.Next(this.Width),
                    rnd.Next(this.Height), rnd.Next(100), rnd.Next(100));
                break;
            case 1:
                grfx.DrawRectangle(Pens.Blue, rnd.Next(this.Width),
                    rnd.Next(this.Height), rnd.Next(100), rnd.Next(100));
                break;
            case 2:
                grfx.DrawArc(Pens.Green, rnd.Next(this.Width),
                    rnd.Next(this.Height), 30, 30, rnd.Next(360), rnd.Next(360));
                break;
        }
    }

    static void Main()
    {
        Application.Run(new ScreenExam());
    }
}