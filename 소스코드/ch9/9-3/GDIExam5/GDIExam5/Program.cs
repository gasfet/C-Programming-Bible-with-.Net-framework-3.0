using System;
using System.Drawing;
using System.Windows.Forms;
class GDIExam5 : Form
{
    Button btn = null;
    Image image = null;
    public GDIExam5()
    {
        this.Text = "Graphics 개체 얻기5";
        btn = new Button();
        btn.Text = "그림위에 글씨 쓰기";
        btn.SetBounds(10, 100, 200, 100);
        btn.Click += new EventHandler(btn_Click);
        this.Controls.Add(btn);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics grfx = e.Graphics;
        if (image != null)
            grfx.DrawImage(image, 0, 0);
    }

    static void Main(string[] args)
    {
        Application.Run(new GDIExam5());
    }

    public void btn_Click(object sender, EventArgs e)
    {
        Image imageFile = Image.FromFile("ocean.jpg");
        Graphics grfx = Graphics.FromImage(imageFile);

        Font font = new Font("돋음", 20);
        Brush brush = Brushes.Pink;

        grfx.DrawString("이미지에 글자쓰기", font, brush, 10, 10);
        grfx.Dispose();

        imageFile.Save("ocean.gif", System.Drawing.Imaging.ImageFormat.Gif);

        this.image = Image.FromFile("ocean.gif");
        this.Invalidate(this.ClientRectangle);
    }
}