using System;
using System.Drawing;
using System.Windows.Forms;
public class TransExam1 : System.Windows.Forms.Form
{
    public TransExam1()
    {
        this.Text = "배율(Scaling) 변환";
    }
    static void Main()
    {
        Application.Run(new TransExam1());
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        Rectangle rect = new Rectangle(0, 0, 100, 100);
        Graphics g = e.Graphics;

        g.DrawRectangle(Pens.Black, rect);
        g.DrawString("VC#", this.Font, Brushes.Black, 10, 50);

        g.ScaleTransform(3.0f, 2.5f);

        g.DrawRectangle(Pens.Red, rect);
        g.DrawString("VC#", this.Font, Brushes.Red, 10, 50);
    }
}
