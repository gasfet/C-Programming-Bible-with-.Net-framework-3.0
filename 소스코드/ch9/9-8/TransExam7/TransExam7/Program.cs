using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class TransExam7 : System.Windows.Forms.Form
{
    public TransExam7()
    {
        this.Text = "복합 변환";
        this.Size = new Size(350, 350);
    }
    static void Main()
    {
        Application.Run(new TransExam7());
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

        Font font = new Font("궁서체", 18);
        Pen pen = new Pen(Brushes.Red, 2);

        g.TranslateTransform(this.Width / 2, this.Height / 2);

        for (int i = 0; i < 360; i += 45)
        {
            g.RotateTransform(i);
            g.DrawRectangle(pen, 0, 0, 300, 24);
            g.DrawString(".NET 3.0", font, Brushes.Blue, 30, 0);
        }

        pen.Dispose();
        font.Dispose();
    }
}

