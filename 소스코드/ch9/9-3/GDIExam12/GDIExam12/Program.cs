using System;
using System.Drawing;
using System.Windows.Forms;
class GDIExam12 : Form
{
    public GDIExam12()
    {
        this.Text = "얼굴 그리기";
    }

    static void Main(string[] args)
    {
        Application.Run(new GDIExam12());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;
        g.DrawArc(Pens.Black, 70, 20, 130, 180, 180, -180);  // 아랫턱 그리기

        for (int i = 0; i < 15; i++)
        {
            g.DrawArc(Pens.Brown, 50 + 2 * i, 50, 100, 160, 130, 80);
            g.DrawArc(Pens.Brown, 20 + 2 * i, 50, 190, 160, 140, 100);
            g.DrawArc(Pens.Brown, 90 + 2 * i, 50, 100, 160, 200, 260);
            g.DrawArc(Pens.Brown, 80 + 3 * i, 50, 100, 90, 130, 80);
        }

        g.DrawEllipse(Pens.Black, 90, 120, 20, 25);			// 눈
        g.DrawEllipse(Pens.Black, 155, 120, 20, 25);		// 눈
        g.FillEllipse(Brushes.Blue, 93, 130, 15, 15);		// 눈동자
        g.FillEllipse(Brushes.Blue, 158, 130, 15, 15);		// 눈동자
        g.DrawArc(Pens.Black, 110, 150, 50, 40, 0, 180);
    }
}