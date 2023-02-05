using System;
using System.Drawing;
using System.Windows.Forms;

public class ScrollExam : Form
{
    Panel top_panel = null;
    Panel panel = null;
    Label[] lbl = new Label[6];
    VScrollBar[] vscroll = new VScrollBar[3];
    HScrollBar hscroll = null;
    string[] strcolor = { "빨강", "초록", "파랑" };
    int r, g, b;

    public ScrollExam()
    {
        r = g = b = 0;
        int cx = this.ClientSize.Width;
        int cy = this.ClientSize.Height;

        top_panel = new Panel();
        top_panel.Parent = this;
        top_panel.Location = new Point(cx / 2, 0);
        top_panel.Size = new Size(cx / 2, 100);
        top_panel.BackColor = Color.Blue;

        hscroll = new HScrollBar();
        hscroll.Parent = top_panel;
        hscroll.Minimum = 0;
        hscroll.Maximum = 255;
        hscroll.TabStop = true;
        hscroll.ValueChanged += new EventHandler(ScrollExam_ValueChanged);
        hscroll.Scroll += new ScrollEventHandler(ScrollExam_Scroll);
        hscroll.Location = new Point(20, 30);
        hscroll.Size = new Size(cx / 2 - 30, 20);

        panel = new Panel();
        panel.Parent = this;
        panel.Location = new Point(0, 0);
        panel.Size = new Size(cx / 2, cy);
        panel.BackColor = Color.Yellow;

        for (int i = 0; i < 3; i++)
        {
            lbl[i * 2] = new Label();
            lbl[i * 2].Parent = panel;
            lbl[i * 2].TextAlign = ContentAlignment.MiddleCenter;
            lbl[i * 2].Text = strcolor[i];
            lbl[i * 2].Location = new Point(i * cx / 6, 5);
            lbl[i * 2].Size = new Size(cx / 6, 15);

            vscroll[i] = new VScrollBar();
            vscroll[i].Parent = panel;
            vscroll[i].SmallChange = 1;
            vscroll[i].LargeChange = 15;
            vscroll[i].Minimum = 0;
            vscroll[i].Maximum = 255;
            vscroll[i].ValueChanged += new EventHandler(ScrollExam_ValueChanged);
            vscroll[i].TabStop = true;
            vscroll[i].Location = new Point((4 * i + 1) * cx / 24, 24);
            vscroll[i].Size = new Size(cx / 12, cy - 4 * 12);

            lbl[2 * i + 1] = new Label();
            lbl[2 * i + 1].Parent = panel;
            lbl[2 * i + 1].TextAlign = ContentAlignment.MiddleCenter;
            lbl[2 * i + 1].Text = "0";
            lbl[2 * i + 1].Location = new Point(i * cx / 6, cy - 3 * 6);
            lbl[2 * i + 1].Size = new Size(cx / 6, 15);
        }
    }

    private void ScrollExam_ValueChanged(object sender, EventArgs e)
    {
        ScrollBar obj = (ScrollBar)sender;
        if (obj == vscroll[0])
        {
            r = obj.Value;
            lbl[1].Text = r.ToString();
        }
        else if (obj == vscroll[1])
        {
            g = obj.Value;
            lbl[3].Text = g.ToString();
        }
        else if (obj == vscroll[2])
        {
            b = obj.Value;
            lbl[5].Text = b.ToString();
        }
        else if (obj == hscroll)
        {
            this.Text = "알파(투명도)값 :" + obj.Value;

        }
        this.BackColor = Color.FromArgb(r, g, b);
    }

    private void ScrollExam_Scroll(object sender, ScrollEventArgs e)
    {
        string str = String.Format("NewValue = {0}, OldValue = {1}, ScrollEventType = {2}, ScrollOrientation = {3}", e.NewValue, e.OldValue, e.Type, e.ScrollOrientation);
        this.Text = str;
    }

    public static void Main()
    {
        Application.Run(new ScrollExam());
    }
}