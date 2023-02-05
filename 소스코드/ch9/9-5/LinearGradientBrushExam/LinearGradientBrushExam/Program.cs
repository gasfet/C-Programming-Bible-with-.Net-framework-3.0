using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class LinearGradientBrushExam : Form
{
    public LinearGradientBrushExam()
    {
        this.Text = "LinearGradientBrush 예제";
    }

    static void Main()
    {
        Application.Run(new LinearGradientBrushExam());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;

        Point pt1 = new Point(0, 0);
        Point pt2 = new Point(30, 30);
        Rectangle rect = new Rectangle(0, 0, 50, 50);

        LinearGradientBrush lgb1 = new LinearGradientBrush(pt1, pt2, Color.Red, Color.Blue);
        LinearGradientBrush lgb2 = new LinearGradientBrush(rect, Color.Yellow, Color.Magenta, 45.0f);

        g.FillEllipse(lgb1, 30, 50, 100, 100);
        g.FillRectangle(lgb2, 150, 50, 100, 100);

        lgb1.Dispose();
        lgb2.Dispose();
    }
}