using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class ClippingExam1 : System.Windows.Forms.Form
{
    static void Main()
    {
        Application.Run(new ClippingExam1());
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Pen p = new Pen(Color.Black);
        p.DashStyle = DashStyle.Dot;
        g.DrawRectangle(p, 100, 100, 100, 100);
        g.DrawRectangle(p, 10, 10, 50, 50);
        g.DrawRectangle(p, 150, 150, 200, 200);
        g.SetClip(new Rectangle(100, 100, 100, 100));
        g.FillRectangle(Brushes.Black, 10, 10, 50, 50);
        g.FillRectangle(Brushes.Red, 150, 150, 200, 200);
    }
}