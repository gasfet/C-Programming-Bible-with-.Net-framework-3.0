using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;

public class TextExam3 : Form
{
    public TextExam3()
    {
        this.Text = "FontFamily 예제";
        this.AutoScrollMinSize = new Size(200, 500);
    }

    static void Main()
    {
        Application.Run(new TextExam3());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;

        int height = 20;
        FontFamily[] fontname = FontFamily.Families;
        //FontFamily [] fontname = FontFamily.GetFamilies(g);
        for (int i = 0; i < fontname.Length; i++)
        {
            if (fontname[i].IsStyleAvailable(FontStyle.Regular))
            {
                Font font = new Font(fontname[i], 10);
                g.DrawString(fontname[i].Name + " :[ 글꼴, ABC 123 ]", font, Brushes.Black, 10, height);
                height += font.Height + 5;
                System.Console.WriteLine("{0}-{1}", i, fontname[i].Name);
                font.Dispose();
            }
        }
    }
}