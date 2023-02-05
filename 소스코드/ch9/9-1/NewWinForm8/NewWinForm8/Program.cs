using System;
using System.Windows.Forms;
class NewWinForm8 : Form
{
    Button[] btn = new Button[4];
    Form[] newMDIChild = new Form[10];
    string[] strData = { "수평", "수직", "계단식", "아이콘" };
    public NewWinForm8(string strText)
    {
        this.Text = strText;
        this.IsMdiContainer = true;
        this.Load += new EventHandler(this.Form_Load);
        this.FormClosed += new FormClosedEventHandler(this.Form_Closed);

        for (int i = 0; i < 4; i++)
        {
            btn[i] = new Button();
            btn[i].Text = strData[i];
            btn[i].SetBounds(50 * i, 10, 50, 50);
            btn[i].Click += new EventHandler(this.Btn_Click);
            this.Controls.Add(btn[i]);
        }
        this.Show();
    }

    static void Main(string[] args)
    {
        Application.Run(new NewWinForm8("MDI 만들기 예제"));
    }

    private void Form_Load(object sender, System.EventArgs e)
    {
        Console.WriteLine("윈도우에 자식창을 작성합니다.");
        for (int i = 0; i < 10; i++)
        {
            newMDIChild[i] = new Form();
            newMDIChild[i].Text = i + "번째 자식창";
            newMDIChild[i].MdiParent = this; // MDI 자식 폼 등록
            newMDIChild[i].FormClosed += new FormClosedEventHandler(this.Form_Closed);
            newMDIChild[i].Show();
        }
    }

    private void Form_Closed(object sender, FormClosedEventArgs e)
    {
        Console.WriteLine(((Form)sender).Text + "윈도우가 Closed 됩니다.");
    }

    private void Btn_Click(object sender, System.EventArgs e) // 버튼 클릭 이벤트
    {
        if ((Button)sender == btn[0])      // ❸ “수평” 버튼일 경우
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
            this.Text = "수평 바둑판 정렬";
        }
        else if ((Button)sender == btn[1]) // ❹ “수직” 버튼일 경우
        {
            this.LayoutMdi(MdiLayout.TileVertical);
            this.Text = "수직 바둑판 정렬";
        }
        else if ((Button)sender == btn[2]) // ❺ “계단식” 버튼일 경우
        {
            this.LayoutMdi(MdiLayout.Cascade);
            this.Text = "계단식 정렬";
        }
        else if ((Button)sender == btn[3])  // ❻ “아이콘” 버튼일 경우
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
            this.Text = "아이콘 정렬";
        }
    }   
}