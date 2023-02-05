using System;
using System.Windows.Forms;

namespace PartialType
{
    partial class TestNewWinForm 
    {
        private void Form_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Console.WriteLine("MouseMove �̺�Ʈ �߻�!!!");
            Console.WriteLine("(x,y)=({0},{1})", e.X, e.Y);
        }

        private void Form_Closed(object sender, System.EventArgs e)
        {
            Console.WriteLine("�����찡 Closed �˴ϴ�.");
        }

    }	
}
