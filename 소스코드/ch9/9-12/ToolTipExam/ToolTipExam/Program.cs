using System;
using System.Drawing;
using System.Windows.Forms;

public class ToolTipExam : Form
{
    ToolTip tooltip;
    Button btn;
    TextBox txt;

    public ToolTipExam()
    {
        tooltip = new ToolTip();

        btn = new Button();
        btn.Parent = this;
        btn.SetBounds(10, 10, 100, 30);
        btn.Text = "버튼";
        btn.Click += new EventHandler(btn_Click);

        txt = new TextBox();
        txt.Parent = this;
        txt.SetBounds(10, 50, 200, 100);
        txt.Text = "이름을 입력하세요>>";

        tooltip.SetToolTip(btn, "버튼을 클릭해 보세요!!");
        tooltip.SetToolTip(txt, "이름을 입력하는 부분입니다.");
    }

    private void btn_Click(object sender, EventArgs e)
    {
        tooltip.BackColor = Color.Black;
        tooltip.ForeColor = Color.White;

        tooltip.SetToolTip(txt, null);
        tooltip.SetToolTip(btn, "버튼을\n 클릭하셨네요 \n ^^");
    }

    public static void Main()
    {
        Application.Run(new ToolTipExam());
    }
}
