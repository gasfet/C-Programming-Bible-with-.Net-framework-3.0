using System;
using System.Drawing;
using System.Windows.Forms;
class GDIExam3 : Form
{
    Button btn = null;
    public GDIExam3()
    {
        this.Text = "Graphics 개체 얻기3";
        btn = new Button();
        btn.Text = "버튼위에 GDI+ 출력";
        btn.SetBounds(10, 10, 200, 100);
        btn.Click += new EventHandler(btn_Click);
        this.Controls.Add(btn);
    }

    static void Main(string[] args)
    {
        Application.Run(new GDIExam3());
    }

    public void btn_Click(object sender, EventArgs e)
    {

        Graphics grfx = btn.CreateGraphics();
        grfx.FillRectangle(new SolidBrush(Color.Blue), btn.ClientRectangle);
        grfx.Dispose();

        // using(Graphics grfx = btn.CreateGraphics())
        // {				 
        //	 grfx.FillRectangle(new SolidBrush(Color.Blue), this.ClientRectangle);
        // }

    }
}
