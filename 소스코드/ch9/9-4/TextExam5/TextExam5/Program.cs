using System;
using System.Drawing;
using System.Windows.Forms;
public class TextExam5 : Form
{
    public TextExam5()
    {
        this.Text = "글꼴 수치 예제";
        this.Size = new Size(360, 170);
    }

    static void Main()
    {
        Application.Run(new TextExam5());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;
        float EmSizeGraphicsUnit = 50;  // 글꼴 크기 
        float EmSizeDesignUnit;
        float AscentGraphicsUnit;
        float DescentGraphicsUnit;
        float LinespacingGraphicsUnit;
        PointF baseLine = new PointF(30, 30);

        Font font = new Font("궁서체", EmSizeGraphicsUnit);
        FontFamily ff = new FontFamily("궁서체");

        EmSizeDesignUnit = ff.GetEmHeight(FontStyle.Regular);

        float ascent = ff.GetCellAscent(FontStyle.Regular);
        float descent = ff.GetCellDescent(FontStyle.Regular);
        float linespacing = ff.GetLineSpacing(FontStyle.Regular);

        AscentGraphicsUnit = ascent * (EmSizeGraphicsUnit / EmSizeDesignUnit);
        DescentGraphicsUnit = descent * (EmSizeGraphicsUnit / EmSizeDesignUnit);
        LinespacingGraphicsUnit = linespacing * (EmSizeGraphicsUnit / EmSizeDesignUnit);

        g.DrawString("Youngjin", font, Brushes.Black, baseLine);

        g.DrawLine(Pens.Red, baseLine, new PointF(baseLine.X + 300, baseLine.Y));

        PointF p = new PointF(baseLine.X, baseLine.Y + LinespacingGraphicsUnit);
        g.DrawLine(Pens.Blue, p, new PointF(p.X + 300, p.Y));
        p = new PointF(baseLine.X, baseLine.Y + LinespacingGraphicsUnit - AscentGraphicsUnit);
        g.DrawLine(Pens.Magenta, p, new PointF(p.X + 300, p.Y));
        p = new PointF(baseLine.X, baseLine.Y + LinespacingGraphicsUnit + DescentGraphicsUnit);
        g.DrawLine(Pens.Green, p, new PointF(p.X + 300, p.Y));

    }
}