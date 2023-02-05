using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Scratch
{
    public partial class MainWnd : Form
    {
        private string Image_Name = null; // 이미지 파일 이름
        private Image m_Image = null;

        private Point pre_Point;
        private int moves;

        public MainWnd()
        {
            InitializeComponent();
        }

        private void btn_Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = @"C:\";
            dlg.Title = "스크래치할 이미지를 선택하세요!";
            dlg.Filter = " Jpeg(*.jpg)|*.jpg| Gif(*.gif)|*.gif| Bmp(*.bmp)|*.bmp| All(*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.Image_Name = dlg.FileName;
                this.m_Image = new Bitmap(this.Image_Name);  // 이미지 파일 읽어오기				
                this.prBar.Maximum = 500;
                this.moves = 0;
                this.prBar.Value = 0;

                this.pb_Image.Width = this.m_Image.Width;
                this.pb_Image.Height = this.m_Image.Height;
            }

        }

        private void pb_Image_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.pb_Image.Capture)
                return;

            Point new_Point = new Point(e.X, e.Y);
            this.pre_Point = new_Point;

            Graphics g = this.pb_Image.CreateGraphics();
            Brush texture_brush = new TextureBrush(this.m_Image);

            Pen pen = new Pen(texture_brush, 50);

            pen.StartCap = LineCap.Round;	//팬에 라운드 주기
            pen.EndCap = LineCap.Round;

            g.DrawLine(pen, this.pre_Point, new_Point);
            this.pb_Image.Capture = true;
        }

        private void pb_Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.pb_Image.Capture)
                return;

            if (this.moves < 500)
            {
                this.moves++;

                Point new_Point = new Point(e.X, e.Y);
                Graphics g = this.pb_Image.CreateGraphics();

                Brush texture_brush = new TextureBrush(this.m_Image);
                Pen pen = new Pen(texture_brush, 50);

                pen.StartCap = LineCap.Round;	//팬에 라운드 주기
                pen.EndCap = LineCap.Round;

                g.DrawLine(pen, this.pre_Point, new_Point);

                this.pre_Point = new_Point;

                this.lbl_Info.Text = this.moves.ToString();
                this.prBar.Value = this.moves;
            }
            else
            {
                MessageBox.Show("전체 이미지를 공개합니다.!");
                this.pb_Image.Image = this.m_Image;
            }
        }

        private void pb_Image_MouseUp(object sender, MouseEventArgs e)
        {
            Point new_Point = new Point(e.X, e.Y);
            Graphics g = this.pb_Image.CreateGraphics();

            Brush texture_brush = new TextureBrush(this.m_Image);
            Pen pen = new Pen(texture_brush, 50);

            pen.StartCap = LineCap.Round;	//팬에 라운드 주기
            pen.EndCap = LineCap.Round;

            g.DrawLine(pen, this.pre_Point, new_Point);
            this.pre_Point = new_Point;

            this.pb_Image.Capture = false;
        }
    }
}