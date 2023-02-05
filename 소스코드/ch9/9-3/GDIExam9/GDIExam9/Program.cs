using System;
using System.Drawing;
using System.Windows.Forms;
class GDIExam9 : Form
{
    Point[] point1 = new Point[5];
    Point[] point2 = new Point[3];

    public GDIExam9()
    {
        this.Text = "다각형과 타원 그리기";
        this.Size = new Size(300, 400);

        point1[0] = new Point(10, 20);
        point1[1] = new Point(20, 70);
        point1[2] = new Point(50, 100);
        point1[3] = new Point(10, 150);
        point1[4] = new Point(100, 100);

        point2[0] = new Point(100, 10);
        point2[1] = new Point(10, 100);
        point2[2] = new Point(190, 100);

    }

    static void Main(string[] args)
    {
        Application.Run(new GDIExam9());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;
        Pen pen = new Pen(Color.Red, 2);
        g.DrawPolygon(pen, point1);

        pen = new Pen(Color.Blue, 3);
        g.DrawPolygon(pen, point2);

        pen = new Pen(Color.Black, 1);
        for (int i = 0; i < 200; i += 20)
        {
            g.DrawEllipse(pen, 70, 130, i, i + 50);
        }
    }
}