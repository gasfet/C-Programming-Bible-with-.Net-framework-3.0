using System;
using System.Drawing;
using System.Windows.Forms;
class GDIExam13 : Form
{
    public GDIExam13()
    {
        this.Text = "Invalidate 예제";
        this.Click += new EventHandler(this.GDIExam_Click);
    }

    static void Main(string[] args)
    {
        Application.Run(new GDIExam13());
    }

    private void DrawGraphics()
    {
        Graphics g = this.CreateGraphics();

        g.DrawRectangle(Pens.Black, 10, 10, 200, 200);
        g.FillRectangle(Brushes.Yellow, 20, 20, 180, 180);
        g.DrawString("www.Youngjin.co.kr", this.Font, Brushes.Black, 30, 100);

    }

    private void GDIExam_Click(object sender, System.EventArgs e)
    {
        this.DrawGraphics();
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        // 자동으로 화면 갱신
        // this.DrawGraphics();
    }

}