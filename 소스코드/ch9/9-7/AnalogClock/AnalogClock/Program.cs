using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class AnalogClock : System.Windows.Forms.Form
{
    int baseX, baseY, clockW, clockH;
    public AnalogClock()
    {
        baseX = 10; baseY = 10;
        clockW = 300; clockH = 300;

        this.Size = new Size(330, 350);
        Timer time = new Timer();
        time.Interval = 1 * 1000;
        time.Tick += new EventHandler(time_Tick);
        time.Enabled = true;
    }

    protected void time_Tick(object obj, EventArgs ea)
    {
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics grfx = pea.Graphics;
        DrawAnalogClock(grfx);
    }

    private void DrawAnalogClock(Graphics g)
    {
        int center = baseX + clockH / 2;
        long seconds = DateTime.Now.Hour * 60 * 60 + DateTime.Now.Minute * 60
            + DateTime.Now.Second;

        double hourAngle = 2 * Math.PI * (seconds - 15 * 60 * 60) / (12 * 60 * 60);
        double minuteAngle = 2 * Math.PI * (seconds - 15 * 60) / (60 * 60);
        double secondAngle = 2 * Math.PI * (seconds - 15) / 60;

        g.DrawEllipse(new Pen(Brushes.Black, 3), baseX, baseY, clockW, clockH);

        g.DrawLine(new Pen(Brushes.Red, 7), center, center,
            center + (int)(100 * Math.Cos(hourAngle)),
            center + (int)(100 * Math.Sin(hourAngle)));
        g.DrawLine(new Pen(Brushes.Green, 5), center, center,
            center + (int)(130 * Math.Cos(minuteAngle)),
            center + (int)(130 * Math.Sin(minuteAngle)));
        g.DrawLine(new Pen(Brushes.Blue, 5), center, center,
            center + (int)(145 * Math.Cos(secondAngle)),
            center + (int)(145 * Math.Sin(secondAngle)));
        this.Text = "아날로그 시계: " + DateTime.Now.ToShortTimeString();
    }

    static void Main()
    {
        Application.Run(new AnalogClock());
    }
}