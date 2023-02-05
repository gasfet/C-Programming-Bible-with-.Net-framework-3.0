using System;
using System.Drawing;
using System.Windows.Forms;
class GDIExam8 : Form
{
    public GDIExam8()
    {
        this.Text = "그래픽 그리기";
        this.Size = new Size(200, 200);
    }

    static void Main(string[] args)
    {
        Application.Run(new GDIExam8());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;
        Pen pen = new Pen(Color.Black, 2);
        g.DrawLine(pen, 10, 10, 190, 190);
        g.DrawRectangle(pen, 10, 10, 100, 100);
        g.DrawEllipse(pen, 50, 50, 100, 100);
        g.DrawArc(pen, 100, 100, 80, 80, 0, -90);
    }
}