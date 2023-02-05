using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class HatchBrushExam : Form
{
    public HatchBrushExam()
    {
        this.Text = "HatchBrush 예제";
    }

    static void Main()
    {
        Application.Run(new HatchBrushExam());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;

        HatchBrush hb = new HatchBrush(HatchStyle.Divot, Color.Red, Color.Blue);
        g.FillRectangle(hb, this.ClientRectangle);

        hb = new HatchBrush(HatchStyle.Cross, Color.Orange, Color.Green);
        g.FillRectangle(hb, 50, 50, 100, 100);

        hb = new HatchBrush(HatchStyle.DiagonalBrick, Color.Pink, Color.Cyan);
        g.FillRectangle(hb, 150, 50, 100, 100);

        hb = new HatchBrush(HatchStyle.Wave, Color.Yellow, Color.Magenta);
        g.FillRectangle(hb, 50, 150, 100, 100);

        hb = new HatchBrush(HatchStyle.ZigZag, Color.White, Color.Black);
        g.FillRectangle(hb, 150, 150, 100, 100);

        hb.Dispose();
    }
}