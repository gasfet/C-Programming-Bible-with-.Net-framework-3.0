using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class GraphicsPathExam1 : System.Windows.Forms.Form
{
    public GraphicsPathExam1()
    {
        this.Text = "GraphicsPathExam1";
        this.Size = new Size(500, 500);
    }

    static void Main()
    {
        Application.Run(new GraphicsPathExam1());
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Pen pen = new Pen(Brushes.Black, 3);

        GraphicsPath gp = new GraphicsPath();
        gp.AddLine(10, 10, 100, 100);
        gp.AddEllipse(50, 50, 100, 100);
        gp.CloseFigure();
        gp.StartFigure();
        gp.AddArc(300, 300, 50, 50, 45, 180);
        gp.AddLine(250, 200, 370, 350);
        gp.CloseAllFigures();
        gp.AddPie(30, 300, 70, 70, 90, 270);

        g.DrawPath(pen, gp);
        g.FillPath(Brushes.Black, gp);

        pen.Dispose();
        gp.Dispose();
    }
}