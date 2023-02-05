using System;
using System.Windows.Forms;

namespace RTFExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            this.rtb_Print.LoadFile("sample.rtf");
        }

        private void btn_Write_Click(object sender, EventArgs e)
        {
            this.rtb_Print.SaveFile("sample.rtf");
        }
    }
}