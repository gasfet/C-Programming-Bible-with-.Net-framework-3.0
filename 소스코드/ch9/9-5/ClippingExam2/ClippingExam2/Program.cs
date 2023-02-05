using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class ClippingExam2 : System.Windows.Forms.Form
{
    public ClippingExam2()
    {
        this.Text = "ClippingExam2";
        this.Size = new Size(600, 300);
    }

    static void Main()
    {
        Application.Run(new ClippingExam2());
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Bitmap bmp = new Bitmap("태극기.gif");
        FontFamily ff = new FontFamily("궁서체");

        Graphics g = e.Graphics;
        g.FillRectangle(Brushes.Pink, this.ClientRectangle);
        GraphicsPath gp = new GraphicsPath();
        gp.AddString("국기", ff, (int)FontStyle.Bold, 150, new Point(5, 20), StringFormat.GenericDefault);
        g.SetClip(gp);

        g.DrawImage(bmp, this.ClientRectangle);
    }
}