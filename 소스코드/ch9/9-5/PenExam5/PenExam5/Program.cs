using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class PenExam5 : Form
{
    public PenExam5()
    {
        this.Text = "선의 결합";
    }

    static void Main()
    {
        Application.Run(new PenExam5());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;

        Pen pen = new Pen(Color.Black, 15);

        g.DrawRectangle(pen, 10, 10, 100, 100);
        pen.LineJoin = LineJoin.Bevel;
        g.DrawRectangle(pen, 10, 130, 100, 100);
        pen.LineJoin = LineJoin.Round;
        g.DrawRectangle(pen, 130, 130, 100, 100);
        pen.LineJoin = LineJoin.Miter;
        g.DrawRectangle(pen, 250, 130, 100, 100);
        pen.LineJoin = LineJoin.MiterClipped;
        g.DrawRectangle(pen, 370, 130, 100, 100);

        pen.Dispose();
    }
}