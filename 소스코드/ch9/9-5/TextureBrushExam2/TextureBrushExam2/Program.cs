using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class TextureBrushExam2 : Form
{
    public TextureBrushExam2()
    {
        this.Text = "TextureBrush 예제";
    }

    static void Main()
    {
        Application.Run(new TextureBrushExam2());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;

        Bitmap bmp = new Bitmap("logo.bmp");
        TextureBrush tb = new TextureBrush(bmp);
        tb.WrapMode = WrapMode.Tile;
        //tb.WrapMode = WrapMode.TileFlipX;
        //tb.WrapMode = WrapMode.TileFlipXY;
        //tb.WrapMode = WrapMode.TileFlipY;

        g.FillRectangle(tb, this.ClientRectangle);

        bmp.Dispose();
        tb.Dispose();
    }
}