using System;
using System.Drawing;
using System.Windows.Forms;
public class TextExam6 : Form
{
    public TextExam6()
    {
        this.Text = "문자열 출력";
        this.Size = new Size(450, 200);
    }

    static void Main()
    {
        Application.Run(new TextExam6());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;
        string str = "한산섬 달밝은 밤에 수루에 홀로 앉아";
        str += "큰 칼 옆에 차고 깊은 시름하는 차에";
        str += "어디서 일성호가는 남의 애를 끊나니.";
        str += "-난중일기中-";

        Font font = new Font("궁서체", 15);
        Rectangle rect = new Rectangle(20, 20, 400, font.Height * 4);
        g.DrawRectangle(Pens.Red, rect);
        g.DrawString(str, font, Brushes.Black, rect);
    }
}