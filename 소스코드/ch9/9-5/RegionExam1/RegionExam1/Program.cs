using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class RegionExam1 : Form
{
    Rectangle rect1, rect2;
    Region reg1, reg2;

    public RegionExam1()
    {
        this.Text = "Region 개체 조합 예제";
        this.Size = new Size(700, 200);
    }
    static void Main()
    {
        Application.Run(new RegionExam1());
    }

    private void DrawRect(Graphics g, string str)
    {
        g.DrawRectangle(Pens.Black, rect1);
        g.DrawRectangle(Pens.Black, rect2);
        g.FillRegion(Brushes.Black, reg1);
        g.DrawString(str, this.Font, Brushes.Black, rect2.X + 20, rect1.Y + 130);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        rect1 = new Rectangle(50, 20, 50, 110);
        rect2 = new Rectangle(20, 50, 110, 50);

        reg1 = new Region(rect1);
        reg2 = new Region(rect2);
        reg1.Complement(reg2);
        this.DrawRect(g, "Complement");

        rect1.X += 130;
        rect2.X += 130;
        reg1 = new Region(rect1);
        reg2 = new Region(rect2);
        reg1.Exclude(reg2);
        this.DrawRect(g, "Exclude");


        rect1.X += 130;
        rect2.X += 130;
        reg1 = new Region(rect1);
        reg2 = new Region(rect2);
        reg1.Intersect(reg2);
        this.DrawRect(g, "  Intersect");


        rect1.X += 130;
        rect2.X += 130;
        reg1 = new Region(rect1);
        reg2 = new Region(rect2);
        reg1.Union(reg2);
        this.DrawRect(g, "   Union");

        rect1.X += 130;
        rect2.X += 130;
        reg1 = new Region(rect1);
        reg2 = new Region(rect2);
        reg1.Xor(reg2);
        this.DrawRect(g, "    Xor");

        reg1.Dispose();
        reg2.Dispose();
    }
}