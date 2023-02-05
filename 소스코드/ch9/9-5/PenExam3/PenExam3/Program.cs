using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class PenExam3 : Form
{
    public PenExam3()
    {
        this.Text = "사용자 지정 파선 그리기";
        this.Size = new Size(450, 200);
    }

    static void Main()
    {
        Application.Run(new PenExam3());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;

        Pen pen1 = new Pen(Color.Red, 5);
        Pen pen2 = new Pen(Color.Black, 5);

        pen1.DashStyle = DashStyle.Dot;
        g.DrawLine(pen1, 10, 20, 410, 20);
        g.DrawRectangle(pen1, 10, 30, 400, 100);

        float[] dashpattern = { 15, 10, 5, 10, 20 };
        pen2.DashPattern = dashpattern;

        g.DrawLine(pen2, 10, 20, 410, 20);
        g.DrawRectangle(pen2, 10, 30, 400, 100);

        pen1.Dispose();
        pen2.Dispose();
    }
}