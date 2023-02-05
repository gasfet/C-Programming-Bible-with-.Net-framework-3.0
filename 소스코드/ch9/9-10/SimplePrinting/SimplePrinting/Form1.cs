using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;


namespace SimplePrinting
{
    public partial class Form1 : Form
    {
        int count;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.BeginPrint += new PrintEventHandler(pd_BeginPrint);
            pd.QueryPageSettings += new QueryPageSettingsEventHandler(pd_QueryPageSettings);
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            pd.EndPrint += new PrintEventHandler(pd_EndPrint);

            pd.Print();
        }

        private void pd_BeginPrint(object sender, PrintEventArgs ev)
        {
            Console.WriteLine("### 프린팅 BeginPrint 단계");
            this.count = 1;
        }

        private void pd_QueryPageSettings(object sender, QueryPageSettingsEventArgs ev)
        {
            Console.WriteLine("### 프린팅 QueryPageSettings 단계");
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Console.WriteLine("### [{0}] 프린팅 PrintPage 단계", this.count);

            if (this.count < 3)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;

            this.count++;

            int leftMargin = ev.MarginBounds.Left;
            int topMargin = ev.MarginBounds.Top;

            int yPos = topMargin + 50;

            string str = this.count + " 번째 문장입니다...";
            ev.Graphics.DrawString(str, this.Font, Brushes.Black, leftMargin, yPos, new StringFormat());
        }

        private void pd_EndPrint(object sender, PrintEventArgs ev)
        {
            Console.WriteLine("### 프린팅 EndPrint 단계");
        }

    }
}