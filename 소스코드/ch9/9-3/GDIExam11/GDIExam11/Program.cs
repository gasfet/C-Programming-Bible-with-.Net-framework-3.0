using System;
using System.Drawing;
using System.Windows.Forms;
class GDIExam11 : Form
{
    public GDIExam11()
    {
        this.Text = "그라데이션 효과주기";
    }

    static void Main(string[] args)
    {
        Application.Run(new GDIExam11());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;
        for (int i = 0; i < 256; i++)
        {
            g.DrawLine(new Pen(Color.FromArgb(i, 0, 0)), 10, 10, 265 - i, 10 + i);
        }
    }
}