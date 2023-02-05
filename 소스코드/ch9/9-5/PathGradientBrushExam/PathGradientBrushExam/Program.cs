using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class PathGradientBrushExam : Form
{
    public PathGradientBrushExam()
    {
        this.Text = "PathGradientBrush 예제";
    }

    static void Main()
    {
        Application.Run(new PathGradientBrushExam());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;

        GraphicsPath gp = new GraphicsPath();
        gp.AddLine(150, 10, 300, 100);
        gp.AddLine(300, 100, 270, 250);
        gp.AddLine(270, 250, 150, 300);
        gp.AddLine(150, 300, 50, 250);
        gp.AddLine(50, 250, 30, 150);
        gp.AddLine(30, 150, 50, 70);
        gp.AddLine(50, 70, 150, 10);
        gp.CloseFigure();

        PathGradientBrush pgb = new PathGradientBrush(gp);
        pgb.CenterColor = Color.White;
        pgb.SurroundColors = new Color[] { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Indigo, Color.Magenta };

        g.FillPath(pgb, gp);
        g.DrawPath(Pens.Black, gp);

        pgb.Dispose();
        gp.Dispose();
    }
}