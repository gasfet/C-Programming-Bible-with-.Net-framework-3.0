using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class TransExam2 : System.Windows.Forms.Form
{
    public TransExam2()
    {
        this.Text = "이동(Translation) 변환";
    }
    static void Main()
    {
        Application.Run(new TransExam2());
    }
    private void DrawGrid(Graphics g)
    {
        Pen pen = new Pen(Color.Blue, 0.1f);
        pen.DashStyle = DashStyle.Dot;

        for (int i = 0; i < this.Width; i += 10)
            g.DrawLine(pen, i, 0, i, this.Height);

        for (int j = 0; j < this.Height; j += 10)
            g.DrawLine(pen, 0, j, this.Width, j);

        pen.Dispose();
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        this.DrawGrid(g);

        Font font = new Font("궁서체", 20);

        g.DrawString("VC#", font, Brushes.Black, 10, 20);
        g.DrawLine(Pens.Black, 0, 100, this.Width, 100);
        g.DrawLine(Pens.Black, 100, 0, 100, this.Height);

        g.TranslateTransform(100, 100);

        g.DrawString("VC#", font, Brushes.Red, 10, 20);

        font.Dispose();
    }
}

