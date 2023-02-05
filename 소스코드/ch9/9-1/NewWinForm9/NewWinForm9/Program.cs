using System;
using System.Windows.Forms;
class NewWinForm9 : Form
{
    Form childForm = null;
    public NewWinForm9(string strText)
    {
        this.Text = strText;  // LocationChaned 이벤트 등록			
        this.LocationChanged += new EventHandler(this.Form_LocationChanged); // ❶
        this.SetBounds(10, 10, 250, 100);

        childForm = new Form();   // ❷ 자식 폼 만들기
        childForm.Text = "자식윈도우";
        childForm.SetBounds(10, 110, 250, 100);

        childForm.Show();         // 자식 윈도우 출력
        this.Show();
    }
    static void Main(string[] args)
    {
        Application.Run(new NewWinForm9("자석 효과 윈도우 예제"));
    }

    private void Form_LocationChanged(object sender, System.EventArgs e) // ❸
    {
        try
        {    // 자식 폼이 화면에 출력되어 있다면
            if (childForm.Visible)
            {
                childForm.Left = this.Left;
                childForm.Top = this.Top + this.Height;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} + 예외발생!!!", ex.ToString());
        }
    }
}
