using System;
using System.Drawing;
using System.Windows.Forms;
class GDIExam14 : Form
{
    int signal = 0;
    string[] str = new string[3] { "빨강", "노랑", "녹색" };
    public GDIExam14()
    {
        this.Text = "신호등 예제";
        this.Size = new Size(150, 400);

        Timer time = new Timer();
        time.Interval = 1000;
        time.Enabled = true;
        time.Tick += new EventHandler(time_Tick);
    }

    static void Main(string[] args)
    {
        Application.Run(new GDIExam14());
    }

    private void time_Tick(object sender, EventArgs ea)
    {
        Random rnd = new Random();
        signal = rnd.Next(3);

        Console.WriteLine(str[signal] + " 발생");

        this.Invalidate(new Rectangle(10, 10, 120, 350));
        //	this.Invalidate();
        this.Update();
    }


    // 신호등 외곽선 그리기
    private void DrawOutLine(Graphics g)
    {
        Pen pen = new Pen(Color.White, 3);
        g.FillRectangle(Brushes.Black, 10, 10, 120, 350);
        g.DrawEllipse(pen, 20, 20, 100, 100);
        g.DrawEllipse(pen, 20, 130, 100, 100);
        g.DrawEllipse(pen, 20, 240, 100, 100);
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Console.WriteLine("Invalidate 영역 = " + pea.ClipRectangle);
        Graphics g = pea.Graphics;
        DrawOutLine(g);

        switch (signal)
        {
            case 0: // red
                g.FillEllipse(Brushes.Red, 20, 20, 100, 100);
                break;
            case 1: // yellow
                g.FillEllipse(Brushes.Yellow, 20, 130, 100, 100);
                break;
            case 2: // green
                g.FillEllipse(Brushes.Green, 20, 240, 100, 100);
                break;

        }
    }
}