using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class ClippingExam4 : System.Windows.Forms.Form
{
    static void Main()
    {
        Application.Run(new ClippingExam4());
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Console.WriteLine("Clipping 영역 : {0}", e.ClipRectangle);

        Rectangle rect = new Rectangle(0, 0, 200, 100);
        Graphics g = e.Graphics;

        g.DrawRectangle(Pens.Black, rect);
        g.SetClip(rect);

        //if (g.IsVisibleClipEmpty)
        if(rect.IntersectsWith(e.ClipRectangle))
        {
            g.DrawString("그리기 작업 수행", this.Font, Brushes.Black, 20, 10);
            Console.WriteLine("그리기 작업 실행됨!!!");
        }
        else
        {
            Console.WriteLine("아무 작업도 안함!!!");
        }

    }
}