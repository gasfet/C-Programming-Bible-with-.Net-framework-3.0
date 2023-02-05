using System;
using System.Drawing;
using System.Windows.Forms;
class GDIExam1 : Form
{
    public GDIExam1()
    {
        this.Text = "Graphics 개체 얻기1";
        this.Paint += new PaintEventHandler(GDIExam_Paint);
    }

    static void Main(string[] args)
    {
        Application.Run(new GDIExam1());
    }

    public void GDIExam_Paint(object sender, PaintEventArgs pea)
    {
        Graphics grfx = pea.Graphics;
        grfx.FillRectangle(new SolidBrush(Color.Blue), this.ClientRectangle);
    }
}
