using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class TransExam3 : System.Windows.Forms.Form
{
    public TransExam3()
    {
        this.Text = "회전(Rotation) 변환";
        this.Size = new Size(300, 300);
    }
    static void Main()
    {
        Application.Run(new TransExam3());
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

        g.DrawString("Youngjin.com", font, Brushes.Black, 50, 20);
        g.DrawLine(Pens.Black, 0, 0, this.ClientSize.Width, this.ClientSize.Height);

        g.RotateTransform(45);

        g.DrawString("Youngjin.com", font, Brushes.Red, 50, 20);

        font.Dispose();
    }
}

