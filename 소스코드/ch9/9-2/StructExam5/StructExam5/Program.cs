using System;
using System.Drawing;
using System.Windows.Forms;

class StructExam5 : Form
{
    Button btn1 = null, btn2 = null;
    public StructExam5()
    {
        btn1 = new Button();
        btn1.Text = "배경색 설정";
        btn1.SetBounds(10, 10, 100, 50);
        btn1.Click += new EventHandler(btn_Click);

        btn2 = new Button();
        btn2.Text = "전경색 설정";
        btn2.SetBounds(120, 10, 100, 50);
        btn2.Click += new EventHandler(btn_Click);

        this.Controls.Add(btn1);
        this.Controls.Add(btn2);
    }

    static void Main(string[] args)
    {
        Application.Run(new StructExam5());
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics grfx = pea.Graphics;
        SolidBrush br = new SolidBrush(this.ForeColor);
        Font font = new Font("돋음", 20);
        grfx.DrawString("글자색 변경", font, br, 10, 70);
    }

    protected void btn_Click(object sender, System.EventArgs e)
    {
        ColorDialog colorDlg = new ColorDialog();
        colorDlg.AllowFullOpen = false;
        colorDlg.ShowHelp = true;

        if ((Button)sender == btn1)  // 배경색 변경
        {
            colorDlg.Color = this.BackColor;
            if (colorDlg.ShowDialog() == DialogResult.OK)
                this.BackColor = colorDlg.Color;
        }
        else  // 전경색 변경
        {
            colorDlg.Color = this.ForeColor;
            if (colorDlg.ShowDialog() == DialogResult.OK)
                this.ForeColor = colorDlg.Color;
        }
    }

}