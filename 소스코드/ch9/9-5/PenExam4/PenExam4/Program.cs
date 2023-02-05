using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class PenExam4 : Form
{
    public PenExam4()
    {
        this.Text = "선끝 모양";
        this.Size = new Size(300, 300);
    }

    static void Main()
    {
        Application.Run(new PenExam4());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;

        Pen pen = new Pen(Brushes.Black, 10);

        LineCap[] lcap = {LineCap.ArrowAnchor, LineCap.DiamondAnchor, LineCap.Flat,
		                   LineCap.Round, LineCap.RoundAnchor, LineCap.Square,
		                   LineCap.SquareAnchor, LineCap.Triangle};

        for (int i = 0; i < lcap.Length; i++)
        {
            pen.StartCap = lcap[i];
            pen.EndCap = lcap[i];
            g.DrawLine(pen, 30, 30 + (30 * i), 100, 30 + (30 * i));
            g.DrawString(lcap[i].ToString(), this.Font, Brushes.Blue, 150, 25 + (30 * i));
        }
    }

}