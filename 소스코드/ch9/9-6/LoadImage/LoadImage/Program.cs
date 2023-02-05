using System;
using System.Drawing;
using System.Windows.Forms;

public class LoadImage : System.Windows.Forms.Form
{
    static void Main()
    {
        Application.Run(new LoadImage());
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Image bmp = Image.FromFile("f15.jpg");
        //Bitmap bmp = new Bitmap("f15.jpg");

        this.Height = bmp.Height;
        this.Width = bmp.Width;

        g.DrawImage(bmp, 0, 0);
    }
}

