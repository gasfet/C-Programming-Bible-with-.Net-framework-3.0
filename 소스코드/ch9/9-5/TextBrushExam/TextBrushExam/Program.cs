using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class TextBrushExam : Form
{
    public TextBrushExam()
    {
        this.Text = "TextBrush 예제";
    }

    static void Main()
    {
        Application.Run(new TextBrushExam());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;
        Bitmap bmp = new Bitmap("logo.bmp");
        Rectangle rect = new Rectangle(0, 0, 20, 20);
        Font font = new Font("궁서체", 30, FontStyle.Bold);

        Brush brush = new TextureBrush(bmp);
        g.DrawString("TexTureBrush...", font, brush, 10, 20);
        brush = new LinearGradientBrush(rect, Color.Yellow, Color.Magenta, 45.0f);
        g.DrawString("LinearGradientBrush...", font, brush, 10, 70);
        brush = new HatchBrush(HatchStyle.Cross, Color.Orange, Color.Green);
        g.DrawString("HatchBrush...", font, brush, 10, 120);

        brush.Dispose();

    }
}