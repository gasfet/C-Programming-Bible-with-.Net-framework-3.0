using System;
using System.Drawing;
using System.Windows.Forms;
public class SolidBrushExam : Form
{
    public SolidBrushExam()
    {
        this.Text = "SolidBrush 사용예";
    }

    static void Main()
    {
        Application.Run(new SolidBrushExam());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;
        SolidBrush brush = new SolidBrush(Color.Black);

        g.FillRectangle(brush, this.ClientRectangle);

        brush.Color = Color.Yellow;
        g.FillRectangle(brush, 100, 100, 100, 100);

        brush.Dispose();
    }
}