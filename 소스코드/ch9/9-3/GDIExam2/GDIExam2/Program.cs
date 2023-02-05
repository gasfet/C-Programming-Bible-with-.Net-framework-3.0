using System;
using System.Drawing;
using System.Windows.Forms;
class GDIExam2 : Form
{
    public GDIExam2()
    {
        this.Text = "Graphics 개체 얻기2";
    }

    static void Main(string[] args)
    {
        Application.Run(new GDIExam2());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics grfx = pea.Graphics;
        grfx.FillRectangle(new SolidBrush(Color.Blue), this.ClientRectangle);
    }
}