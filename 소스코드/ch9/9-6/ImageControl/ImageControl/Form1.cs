using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageControl
{
    public partial class Form1 : Form
    {   
        int state = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // 기울이기
        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "기울이기";

            Bitmap bmp = new Bitmap("f15.jpg");
            int width  = bmp.Width;
            int height = bmp.Height;

            Graphics g = this.m_picImg.CreateGraphics();
            g.FillRectangle(Brushes.White, this.m_picImg.ClientRectangle);
            Point[] destPoints = { new Point(0,0), 
                                   new Point(width, 0),
                                   new Point(width/3, height)};
            g.DrawImage(bmp, destPoints);
            g.Dispose();
            bmp.Dispose();
        }

        //뒤집기
        private void button2_Click(object sender, EventArgs e)
        {
            this.Text = "뒤집기";

            Bitmap bmp = new Bitmap("f15.jpg");
            int width = bmp.Width;
            int height = bmp.Height;

            Graphics g = this.m_picImg.CreateGraphics();
            g.FillRectangle(Brushes.White, this.m_picImg.ClientRectangle);
            Point[] destPoints = { new Point(0,height), 
                                    new Point(width, height),
                                    new Point(0, 0) };
            g.DrawImage(bmp, destPoints);
            g.Dispose();
            bmp.Dispose();
        }

        //회전하기
        private void button3_Click(object sender, EventArgs e)
        {
            this.Text = "회전하기";
            //static int state = 0;

            Bitmap bmp = new Bitmap("f15.jpg");
            int width = bmp.Width;
            int height = bmp.Height;

            Point[] destPoints = new Point[3];

            switch(this.state)
            {
                case 0: // 90도 회전
                    this.button3.Text = "90도 회전";

                    this.state = 1;
                    destPoints[0] = new Point(width,0);
                    destPoints[1] = new Point(width, height);
                    destPoints[2] = new Point(0, 0);
                    break;

                case 1: // 180도 회전
                    this.button3.Text = "180도 회전";

                    this.state = 2;
                    destPoints[0] = new Point(0, height);
                    destPoints[1] = new Point(width, height);
                    destPoints[2] = new Point(0, 0);
                    break;

                case 2: // 270도 회전
                    this.button3.Text = "270도 회전";

                    this.state = 3;
                    destPoints[0] = new Point(height, 0);
                    destPoints[1] = new Point(0, 0);
                    destPoints[2] = new Point(width, height); 
                    break;

                case 3: // 0도 회전
                    this.button3.Text = "회전하기";

                    this.state = 0;
                    destPoints[0] = new Point(0, 0);
                    destPoints[1] = new Point(width, 0);
                    destPoints[2] = new Point(0, height);       
                    break;
            }
            
            Graphics g = this.m_picImg.CreateGraphics();
            g.FillRectangle(Brushes.White, this.m_picImg.ClientRectangle);
            g.DrawImage(bmp, destPoints);
            g.Dispose();
            bmp.Dispose();

            /* RotateFlipType 을 이용한 이미지 회전 */
/*
            Bitmap bmp = new Bitmap("f15.jpg");
            int width = bmp.Width;
            int height = bmp.Height;

            switch (this.state)
            {
                case 0: // 90도 회전
                  this.button3.Text = "90도 회전";
                  bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                  this.state = 1;
                  break;
                case 1: // 180도 회전
                  this.button3.Text = "180도 회전";
                  bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                  this.state = 2;                  
                  break;
                case 2: // 270도 회전
                  this.button3.Text = "270도 회전";
                  bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                  this.state = 0;
                  break;
            }

            Graphics g = this.m_picImg.CreateGraphics();
            g.FillRectangle(Brushes.White, this.m_picImg.ClientRectangle);
            g.DrawImage(bmp, 0, 0);
*/
        }

        // 부분자르기
        private void button5_Click(object sender, EventArgs e)
        {
            this.Text = "부분 자르기";

            Bitmap bmp = new Bitmap("f15.jpg");
            
            Rectangle srcRect = new Rectangle(new Point(50, 10),
                                                new Size(100, 100));

            Graphics g = this.m_picImg.CreateGraphics();
            g.FillRectangle(Brushes.White, this.m_picImg.ClientRectangle);
            g.DrawImage(bmp, 0, 0, srcRect, GraphicsUnit.Pixel);
            g.Dispose();
            bmp.Dispose();

        }

        // 복제하기
        private void button4_Click(object sender, EventArgs e)
        {
            this.Text = "복제하기";

            Bitmap bmp1 = new Bitmap("f15.jpg");
            Rectangle rect = new Rectangle(0, 0, bmp1.Width, bmp1.Height);
            Bitmap bmp2 = bmp1.Clone(rect, System.Drawing.Imaging.PixelFormat.DontCare);
                        
            Graphics g = this.m_picImg.CreateGraphics();
            g.FillRectangle(Brushes.White, this.m_picImg.ClientRectangle);
            g.DrawImage(bmp1, new Rectangle(0, 0, 100, 100));
            g.DrawString("◀◀ 원본", this.Font, Brushes.Black, new Point(120, 50));
            g.DrawImage(bmp2, new Rectangle(110, 110, 100, 100));
            g.DrawString("복제본 ▶▶", this.Font, Brushes.Black, new Point(30, 150));
            g.Dispose();
            bmp1.Dispose();
            bmp2.Dispose();
        }

        // 이미지 합성
        private void button6_Click(object sender, EventArgs e)
        {
            this.Text = "이미지 합성";

            Bitmap bmp1 = new Bitmap("f15.jpg");
            Bitmap bmp2 = new Bitmap("flag.jpg");
            Bitmap bmp3 = new Bitmap(bmp2.Width, bmp2.Height);

            for (int y = 0; y < bmp2.Height; y++)
            {
                for (int x = 0; x < bmp2.Width; x++)
                {
                    Color temp = Color.FromArgb(50, bmp2.GetPixel(x, y));
                    bmp3.SetPixel(x, y, temp);
                }
            }

            Graphics g_temp = Graphics.FromImage(bmp1);
            g_temp.DrawImage(bmp3, new Rectangle(0, 0, bmp1.Width, bmp1.Height));
            
            Graphics g = this.m_picImg.CreateGraphics();
            g.FillRectangle(Brushes.White, this.m_picImg.ClientRectangle);
            g.DrawImage(bmp1, 0, 0);

            g_temp.Dispose();
            g.Dispose();
            bmp1.Dispose();
            bmp2.Dispose();
            bmp3.Dispose();
            
        }

        // 해상도 변경
        private void button7_Click(object sender, EventArgs e)
        {
            this.Text = "해상도 변경";
            
            Bitmap bmp = new Bitmap("f15.jpg");                       

            Graphics g = this.m_picImg.CreateGraphics();
            g.FillRectangle(Brushes.White, this.m_picImg.ClientRectangle);
            
            bmp.SetResolution(100f, 200f);
            g.DrawImage(bmp, 100, 0);
            g.DrawString("100*200", this.Font, Brushes.Black, 20, 50);

            bmp.SetResolution(300f, 300f);
            g.DrawImage(bmp, 100, 150);
            g.DrawString("300*300", this.Font, Brushes.Black, 20, 170);

            bmp.SetResolution(600f, 300f);
            g.DrawImage(bmp, 100, 250);
            g.DrawString("600*300", this.Font, Brushes.Black, 20, 270);

            g.Dispose();
            bmp.Dispose();
        }

        // Thumbnail
        private void button8_Click(object sender, EventArgs e)
        {
            this.Text = "Thumbnail";

            Bitmap bmp = new Bitmap("f15.jpg");
            int width = bmp.Width;
            int height = bmp.Height;

            Rectangle sRect = new Rectangle(new Point(0, 0),
                                            new Size(width, height));
            Rectangle dRect = new Rectangle(new Point(50, 10),
                                            new Size(100, 100));

            Graphics g = this.m_picImg.CreateGraphics();
            g.FillRectangle(Brushes.White, this.m_picImg.ClientRectangle);
            g.DrawImage(bmp, 0, 0);
            g.DrawRectangle(new Pen(Color.Red, 10), dRect);
            g.DrawImage(bmp, dRect, sRect, GraphicsUnit.Pixel);

            g.Dispose();
            bmp.Dispose();
        }

        // 원본 이미지
        private void button9_Click(object sender, EventArgs e)
        {
            this.Text = "원본 이미지";

            Bitmap bmp = new Bitmap("f15.jpg");
            this.m_picImg.Image = bmp;    //PixtureBox 클래스는 Image 곧바로 출력할 수 있음
            this.m_picImg.Refresh();      //PixtureBox 개체를 새로 그림
            bmp.Dispose();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap m_bmp = new Bitmap("f15.jpg");
            this.m_picImg.BackColor = Color.White; // PixtureBox 배경을 흰색으로 칠함
            this.m_picImg.Image = m_bmp;
            this.m_picImg.Refresh();            
        }
      
        
    }
}