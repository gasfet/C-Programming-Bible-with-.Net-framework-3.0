using System;
using System.Drawing;
using System.Windows.Forms;

namespace KeyExamChar
{
    public class KeyExamChar : Form
    {
        public static void Main()
        {
            Application.Run(new KeyExamChar());
        }

        string strdata = " "; // 화면에 출력할 문자
        public KeyExamChar()
        {
            this.Text = "문자 입력 예제";
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            this.Size = new Size(500, 300);

            this.KeyDown += new KeyEventHandler(KeyDownFunc);
            this.KeyUp += new KeyEventHandler(KeyUpFunc);
            this.KeyPress += new KeyPressEventHandler(KeyPressFunc);
        }

        private void KeyDownFunc(object sender, KeyEventArgs key)
        {
            strdata += String.Format("\n ① {0} 키가 눌림*****", key.KeyCode);
            Invalidate();
        }

        private void KeyUpFunc(object sender, KeyEventArgs key)
        {
            strdata += String.Format("\n ③ {0} 키가 놓임*****", key.KeyCode);
            Invalidate();
        }

        private void KeyPressFunc(object sender, KeyPressEventArgs key)
        {
            strdata += String.Format("\n ② 문자키 {0} 눌림*****", key.KeyChar);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString(strdata, new Font("궁서체", 20, FontStyle.Bold), Brushes.White, 20, 30);
        }
    }
}