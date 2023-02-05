using System;
using System.Windows.Forms;

namespace PartialType
{
    public partial class TestNewWinForm : Form
    {
        public TestNewWinForm(string strText)
        {
            this.Text = strText;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.Closed += new System.EventHandler(this.Form_Closed);
            this.Show();
        }
    }
}
