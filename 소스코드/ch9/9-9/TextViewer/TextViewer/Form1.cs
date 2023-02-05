using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TextViewer
{
    public partial class Form1 : Form
    {
        string strText = "";      // 문자 저장
        int count = 0;            // 출력 위치 저장   
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            count = count + e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            Invalidate();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int height = (int)(-count * this.Font.GetHeight()) + 70;
            g.DrawString(strText, this.Font, Brushes.Black, 10, height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.InitialDirectory = "C:\\";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // 파일 읽어오기
                TextReader txt = new StreamReader(dlg.FileName);
                strText = txt.ReadToEnd();                
                Invalidate();
            }

        }
    }
}