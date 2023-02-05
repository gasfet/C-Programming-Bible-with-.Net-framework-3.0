using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class TextureBrushExam1 : Form
{
    public TextureBrushExam1()
    {
        this.Text = "TextureBrush 예제";
    }

    static void Main()
    {
        Application.Run(new TextureBrushExam1());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;

        Bitmap bmp = new Bitmap("logo.bmp");
        TextureBrush tb = new TextureBrush(bmp);

        g.FillRectangle(tb, 10, 10, 200, 100);
        g.FillEllipse(tb, 100, 150, 100, 100);

        bmp.Dispose();
        tb.Dispose();
    }
}