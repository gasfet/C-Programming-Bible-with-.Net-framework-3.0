using System;
using System.Drawing;
using System.Windows.Forms;
public class PenExam1 : Form
{
    public PenExam1()
    {
        this.Text = "X자 그리기";
        this.Size = new Size(300, 300);
    }

    static void Main()
    {
        Application.Run(new PenExam1());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;
        Pen pen1 = new Pen(Color.Blue, 10);
        Pen pen2 = new Pen(Color.Red, 5);

        g.DrawLine(pen1, 50, 50, 250, 250);
        g.DrawLine(pen2, 250, 50, 50, 250);
    }
}