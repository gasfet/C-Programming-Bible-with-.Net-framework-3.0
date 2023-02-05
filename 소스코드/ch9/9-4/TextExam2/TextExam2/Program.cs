using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;

public class TextExam : Form
{
    public TextExam()
    {
        this.Text = "그림자 효과 주기";
        this.Size = new Size(400, 150);
    }
    static void Main()
    {
        Application.Run(new TextExam());
    }
    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;
        Font font = new Font("Timesroman", 30, FontStyle.Italic);
        string str = "빨주노초파남보";
        Color[] color = {Color.Red, Color.Orange, Color.Yellow, 
								  Color.Green, Color.Blue, Color.Magenta,
								  Color.Violet};
        for (int i = 0; i < 7; i++)
        {
            g.DrawString(str, font, new SolidBrush(color[6 - i]), (20 + i), 30 + (i * 2));
            System.Console.WriteLine("{0},{1}", 20 + i, 30 + 2 * i);
        }
    }
}