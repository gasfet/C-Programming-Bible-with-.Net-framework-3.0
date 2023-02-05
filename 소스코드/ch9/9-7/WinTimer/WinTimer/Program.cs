using System;
using System.Drawing;
using System.Windows.Forms;
public class WinTimer : System.Windows.Forms.Form
{
    Timer time;
    int timecount = 0;

    public WinTimer()
    {
        this.Text = "10초후에 닫히는 창 예제";
        time = new Timer();
        time.Interval = 1 * 1000;
        time.Tick += new EventHandler(time_Tick);

        this.Load += new EventHandler(WinTimer_Load);
    }

    private void WinTimer_Load(object obj, EventArgs e)
    {
        System.Console.WriteLine("타이머 시작!!!");
        time.Start();    // 타이머 시작
    }

    private void time_Tick(object sender, EventArgs ea)
    {
        if (timecount < 10)
        {
            System.Console.WriteLine("{0} Tick...", DateTime.Now);
            this.Text = (10 - timecount) + " 초 남았습니다...";
            timecount++;
        }
        else
        {
            time.Stop();
            MessageBox.Show("프로그램을 종료합니다.", "10초 타이머");
            this.Close();
        }
    }

    public static void Main()
    {
        Application.Run(new WinTimer());
    }
}