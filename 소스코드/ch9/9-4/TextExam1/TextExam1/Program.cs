using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
public class TextExam1 : Form
{
    public TextExam1()
    {
        this.Text = "Font 예제";
    }

    static void Main()
    {
        Application.Run(new TextExam1());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;
        Font font = new Font("Timesroman", 20);
        SolidBrush brush = new SolidBrush(Color.Blue);
        RectangleF rect = new RectangleF(50, 10, 200, 30);

        g.DrawString("안녕하세요", font, brush, rect);

        font = new Font("돋움", 10);
        g.DrawString("폰트 예제입니다.", font, brush, 50, 50);

        font = new Font("궁서", 15);
        brush = new SolidBrush(Color.Red);
        PointF point = new PointF(10, 10);
        StringFormat sf = new StringFormat();
        sf.FormatFlags = StringFormatFlags.DirectionVertical;

        g.DrawString("C# Font 다루기", font, brush, point, sf);
    }
}