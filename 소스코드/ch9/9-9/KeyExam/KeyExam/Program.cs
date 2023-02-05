using System;
using System.Drawing;
using System.Windows.Forms;
public class KeyExam : Form
{
    public static void Main()
    {
        Application.Run(new KeyExam());
    }

    string strdata = " "; // 화면에 출력할 문자
    public KeyExam()
    {
        this.Text = "키보드 입력 예제";
        this.BackColor = Color.Black;
        this.ForeColor = Color.White;
    }
    protected override void OnKeyDown(KeyEventArgs key)
    {
        if (key.KeyCode == Keys.Back) // 백스페이스 키이면, 입력한 글자 지움
        {
            if (strdata.Length > 0)
            {
                strdata = strdata.Remove(strdata.Length - 1); // 마지막 문자 지움
            }
            Invalidate();
        }
        else if (key.KeyCode == Keys.Enter)
        {
            strdata += "\r\n";
            Invalidate();
        }
        else if (key.KeyCode == Keys.Space)
        {
            strdata += " ";
            Invalidate();
        }
        else if (key.KeyCode <= Keys.D9 && key.KeyCode >= Keys.D0)
        {
            strdata += (key.KeyValue - 48);
            Invalidate();
        }
        else if (key.KeyCode == Keys.F1)
        {
            MessageBox.Show("프로그램 도움말!");
        }
        else if ((key.KeyCode == Keys.F10) && (key.Control))  // ctrl+F10은 종료
        {
            MessageBox.Show("프로그램을 종료합니다.");
            this.Close();
        }
        else
        {
            strdata += key.KeyCode;
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.DrawString(strdata, new Font("궁서체", 20, FontStyle.Bold), Brushes.White, 20, 30);
    }
}