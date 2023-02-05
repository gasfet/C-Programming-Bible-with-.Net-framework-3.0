using System;
using System.Drawing;
using System.Windows.Forms;
class NewForm : Form
{
    string strText = null;
    public NewForm(string str)
    {
        this.Text = str;
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    }

    public string TextLabel
    {
        set
        {
            this.strText = value;
        }
    }
    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics grfx = pea.Graphics;
        SolidBrush br = new SolidBrush(Color.Black);
        grfx.DrawString(this.strText, this.Font, br, 10, 7);
    }
}
class StructExam4 : Form
{
    Button btn = null;
    public StructExam4()
    {
        this.Text = "KnownColor";
        this.IsMdiContainer = true;

        Array arr = System.Enum.GetValues(typeof(KnownColor));
        NewForm[] frm = new NewForm[arr.Length];

        for (int i = 0; i < arr.Length; i++)
        {
            frm[i] = new NewForm(arr.GetValue(i).ToString());
            frm[i].TextLabel = arr.GetValue(i).ToString();
            frm[i].BackColor = Color.FromName(arr.GetValue(i).ToString());
            frm[i].SetBounds(0, 0, 200, 50);
            frm[i].MdiParent = this;
            frm[i].Show();
        }
        btn = new Button();
        btn.Text = "정렬하기";
        btn.Click += new EventHandler(this.btn_Click);
        btn.SetBounds(0, 0, 100, 50);
        this.Controls.Add(btn);
    }
    static void Main(string[] args)
    {
        Application.Run(new StructExam4());

    }

    public void btn_Click(object Sender, EventArgs e)
    {
        this.LayoutMdi(MdiLayout.TileVertical);
    }

}