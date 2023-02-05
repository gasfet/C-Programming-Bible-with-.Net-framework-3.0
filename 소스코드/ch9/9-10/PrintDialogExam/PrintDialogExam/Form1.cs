using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace PrintDialogExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrinterSettings ps = new PrinterSettings();

            PrintDialog pdlg = new PrintDialog();
            pdlg.PrinterSettings = ps;
            pdlg.ShowDialog();

            string info = String.Format(" PrinterName = {0} \r\n PaperSizes = {1}",
                                          ps.PrinterName, ps.Copies);
            MessageBox.Show(info);

            /*
            PrintDocument pd1 = new PrintDocument();
            pd1.PrinterSettings = ps;
            ...
            */
        }
    }
}