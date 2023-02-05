using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class TransExam6 : System.Windows.Forms.Form
{
    public TransExam6()
    {
        this.Text = "비누적 변환";
        this.Size = new Size(300, 300);
    }
    static void Main()
    {
        Application.Run(new TransExam6());
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

        g.DrawEllipse(Pens.Black, new Rectangle(10, 10, 100, 100));
        g.TranslateTransform(50, 50);
        g.DrawEllipse(Pens.Red, new Rectangle(10, 10, 100, 100));
        g.ResetTransform();
        g.DrawRectangle(Pens.Blue, new Rectangle(10, 10, 100, 100));
    }
}

