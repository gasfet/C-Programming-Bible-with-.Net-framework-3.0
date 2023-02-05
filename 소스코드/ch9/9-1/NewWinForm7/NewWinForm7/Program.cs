using System;
using System.Windows.Forms;
class NewWinForm7 : Form
{
    public NewWinForm7(string strText)
    {
        this.Text = strText;
        this.IsMdiContainer = true;  // ❶. MDI 부모 폼 만들기 
        this.Load += new EventHandler(this.Form_Load);
        this.Closed += new System.EventHandler(this.Form_Closed);
        this.Show();
    }
    static void Main(string[] args)
    {
        Application.Run(new NewWinForm7("MDI 만들기 예제"));
    }

    private void Form_Load(object sender, System.EventArgs e)
    {
        Console.WriteLine("윈도우에 자식창을 작성합니다.");
        Form[] newMDIChild = new Form[3];  // ❷ 자식 폼 생성
        for (int i = 0; i < 3; i++)
        {
            newMDIChild[i] = new Form();
            newMDIChild[i].Text = i + "번째 자식창";
            newMDIChild[i].MdiParent = this;  // ❸. MDI 자식 폼 만들기
            newMDIChild[i].Closed += new System.EventHandler(this.Form_Closed);
            newMDIChild[i].Show();
        }
    }
    private void Form_Closed(object sender, System.EventArgs e)
    {
        Console.WriteLine(((Form)sender).Text + "윈도우가 Closed 됩니다.");
    }
}
