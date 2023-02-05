using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class PenExam2 : Form
{
    public PenExam2()
    {
        this.Text = "파선 그리기";
        this.Size = new Size(450, 200);
    }

    static void Main()
    {
        Application.Run(new PenExam2());
    }

    void DrawGraphPaper(Graphics g)
    {
        int i;
        for (i = 0; i < this.Width; i += 10)
            g.DrawLine(Pens.Blue, i, 0, i, this.Height);

        for (i = 0; i < this.Width; i += 10)
            g.DrawLine(Pens.Blue, 0, i, this.Width, i);

    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;

        DrawGraphPaper(g);

        DashStyle[] dash = {DashStyle.Custom, DashStyle.Dash, DashStyle.DashDot, 
							 DashStyle.DashDotDot, DashStyle.Dot, DashStyle.Solid};


        Pen pen = new Pen(Color.Black, 10);

        for (int i = 0; i < dash.Length; i++)
        {
            pen.DashStyle = dash[i];
            g.DrawLine(pen, 10, 15 + (20 * i), 400, 15 + (20 * i));
        }
    }
}