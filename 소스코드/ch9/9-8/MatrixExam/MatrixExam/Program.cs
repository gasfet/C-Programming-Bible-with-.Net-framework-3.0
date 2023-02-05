using System;
using System.Drawing;
using System.Drawing.Drawing2D;  // Matrix 클래스
using System.Windows.Forms;

public class MatrixExam : Form
{
    protected override void OnPaint(PaintEventArgs e)
    {
        
        Graphics g = e.Graphics;
        float[] m1 = g.Transform.Elements;
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine("m1[{0}] = {1}", i, m1[i]);
        }
        g.ScaleTransform(10, 10);
        float[] m2 = g.Transform.Elements;
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine("m2[{0}] = {1}", i, m2[i]);
        }
        g.TranslateTransform(5, 5);
        float[] m3 = g.Transform.Elements;
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine("m3[{0}] = {1}", i, m3[i]);
        }
        
       /*
        Graphics g = e.Graphics;
        Matrix mat = new Matrix();
        mat.Scale(10,10);  
        mat.Translate(5,5);
        g.MultiplyTransform(mat); 

        float[] m3 = g.Transform.Elements;
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine("m3[{0}] = {1}", i, m3[i]);
        }
       */
    }

    public static void Main()
    {
        Application.Run(new MatrixExam());
    }
}
