using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class RegionExam2 : Form
{
    public RegionExam2()
    {
        this.Text = "    원 모양 폼";
    }

    static void Main()
    {
        Application.Run(new RegionExam2());
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        GraphicsPath shape = new GraphicsPath();
        shape.AddEllipse(0, 0, 100, 100);
        shape.AddRectangle(new Rectangle(100, 0, this.Width - 100, this.Height));
        shape.AddLine(100, 100, 0, 200);
        shape.AddLine(0, 200, 200, 200);
        shape.CloseFigure();
        this.Region = new Region(shape);
        shape.Dispose();

        g.DrawString("GraphicsPath와 Region 응용", this.Font, Brushes.Black, 120, 30);
    }
}