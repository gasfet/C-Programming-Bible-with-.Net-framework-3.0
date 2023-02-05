using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class GraphicsPathExam2 : System.Windows.Forms.Form
{
    public GraphicsPathExam2()
    {
        this.Text = "GraphicsPathExam2";
        this.Size = new Size(250, 150);
    }
    static void Main()
    {
        Application.Run(new GraphicsPathExam2());
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Pen pen = new Pen(Brushes.Black, 3);

        GraphicsPath gp = new GraphicsPath();
        gp.AddLine(10, 10, 10, 110);
        gp.AddLine(10, 110, 110, 110);
        gp.AddLine(110, 110, 110, 10);
        gp.CloseFigure();
        gp.AddLine(120, 10, 120, 110);
        gp.AddLine(120, 110, 220, 110);
        gp.AddLine(220, 110, 220, 10);

        g.DrawPath(pen, gp);

        pen.Dispose();
        gp.Dispose();
    }

}