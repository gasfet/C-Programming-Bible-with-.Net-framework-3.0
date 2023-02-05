using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class ClippingExam3 : System.Windows.Forms.Form
{
    static void Main()
    {
        Application.Run(new ClippingExam3());
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        Console.WriteLine("Clipping 영역 : {0}", e.ClipRectangle);
    }
}