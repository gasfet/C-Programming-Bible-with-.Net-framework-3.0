using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AvataExam
{
    public partial class MainWnd : Form
    {
        private ImageList body = null;    // 몸 형태
        private ImageList shirt = null;   // 상의 형태
        private ImageList pants = null;   // 하의 형태

        private Bitmap bmp_avata = null;   // 출력 이미지 파일 
        private Graphics gp_avata = null;  // 그래픽 팬

        private int current_position = 0;  // 현재 이미지 인덱스


        public MainWnd()
        {
            InitializeComponent();

            this.bmp_avata = new Bitmap(98, 195);  // 이미지 파일 생성

            // 그래픽 펜 생성
            this.gp_avata = Graphics.FromImage(this.bmp_avata);
            this.gp_avata.PageUnit = GraphicsUnit.Pixel;

            this.body = new ImageList();   // 몸 이미지 읽어오기
            this.body.ColorDepth = ColorDepth.Depth8Bit;
            this.body.ImageSize = new Size(98, 195);
            this.body.Images.Add(new Bitmap(GetType(), "body1.gif"));
            this.body.Images.Add(new Bitmap(GetType(), "body2.gif"));

            this.shirt = new ImageList();   // 상의 이미지 읽어오기
            this.shirt.ColorDepth = ColorDepth.Depth8Bit;
            this.shirt.ImageSize = new Size(94, 130);
            this.shirt.Images.Add(new Bitmap(GetType(), "shirt1.gif"));
            this.shirt.Images.Add(new Bitmap(GetType(), "shirt2.gif"));
            this.shirt.Images.Add(new Bitmap(GetType(), "shirt3.gif"));
            this.shirt.Images.Add(new Bitmap(GetType(), "shirt4.gif"));
            this.shirt.Images.Add(new Bitmap(GetType(), "shirt5.gif"));
            this.shirt.Images.Add(new Bitmap(GetType(), "shirt6.gif"));

            this.pants = new ImageList();   // 하의 이미지 읽어오기
            this.pants.ColorDepth = ColorDepth.Depth8Bit;
            this.pants.ImageSize = new Size(94, 130);

            this.pants.Images.Add(new Bitmap(GetType(), "pants1.gif"));
            this.pants.Images.Add(new Bitmap(GetType(), "pants2.gif"));
            this.pants.Images.Add(new Bitmap(GetType(), "pants3.gif"));
            this.pants.Images.Add(new Bitmap(GetType(), "pants4.gif"));
            this.pants.Images.Add(new Bitmap(GetType(), "pants5.gif"));
            this.pants.Images.Add(new Bitmap(GetType(), "pants6.gif"));

            // 이미지 크기에 맞게 출력
            this.pBox_Sample.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pBox_Main.SizeMode = PictureBoxSizeMode.StretchImage;

            // 초기 몸형태 지정
            this.pBox_Main.Image = this.body.Images[0];
            this.gp_avata.DrawImage(this.body.Images[0], 0, 0, this.pBox_Main.Width, this.pBox_Main.Height);

        }

        /// <summary>
        /// 상의 하의 옷을 입히기
        /// </summary>
        /// <param name="image">입힐 옷 이미지</param>
        /// <param name="flag">상의 / 하의 구분</param>
        private void Composite(Image image, bool flag)
        {
            if (flag)   // 상의일 경우
            {
                this.gp_avata.DrawImage(image, 0, 33, image.Width, image.Height);
                this.pBox_Main.Refresh();
            }
            else       // 하의일 경우
            {
                this.gp_avata.DrawImage(image, 0, 76, image.Width, image.Height);
                this.pBox_Main.Refresh();
            }
        }

        /// <summary>
        /// 화면이 출력되기 직전에 실행될 부분
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWnd_Load(object sender, EventArgs e)
        {
            if (this.radio_Shirt.Checked)
            {
                this.pBox_Sample.Image = this.shirt.Images[0];
                Composite(this.shirt.Images[this.current_position], true);
            }
            else if (this.radio_Pants.Checked)
            {
                this.pBox_Sample.Image = this.pants.Images[0];
                Composite(this.pants.Images[this.current_position], false);
            }
        }


        /// <summary>
        /// 왼쪽 버튼이 클릭될때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Left_Click(object sender, EventArgs e)
        {
            if (this.current_position >= 1)
            {
                this.current_position--;

                if (this.radio_Shirt.Checked)
                {
                    this.pBox_Sample.Image = this.shirt.Images[this.current_position];
                    Composite(this.shirt.Images[this.current_position], true);
                }
                else if (this.radio_Pants.Checked)
                {
                    this.pBox_Sample.Image = this.pants.Images[this.current_position];
                    Composite(this.pants.Images[this.current_position], false);
                }
            }         		

        }

        /// <summary>
        /// 오른쪽 버튼이 클릭될 때 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Right_Click(object sender, EventArgs e)
        {
            if (this.current_position < 5)
            {
                this.current_position++;

                if (this.radio_Shirt.Checked)
                {
                    this.pBox_Sample.Image = this.shirt.Images[this.current_position];
                    Composite(this.shirt.Images[this.current_position], true);
                }
                else if (this.radio_Pants.Checked)
                {
                    this.pBox_Sample.Image = this.pants.Images[this.current_position];
                    Composite(this.pants.Images[this.current_position], false);
                }
            }
        }

        /// <summary>
        /// 아바타 이미지 파일 생성(bmp 형태)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AvataCreate_Click(object sender, EventArgs e)
        {
            string file_name = "Avata" + DateTime.Now.Ticks + ".bmp";
            Graphics g = Graphics.FromImage(this.pBox_Main.Image);
            g.PageUnit = GraphicsUnit.Pixel;
            g.DrawImage(this.bmp_avata, 0, 0);

            this.bmp_avata.Save(file_name, System.Drawing.Imaging.ImageFormat.Bmp);
            MessageBox.Show(file_name + " : 이미지 저장 완료");
        }

        /// <summary>
        /// pBox_Main 화면 새롭게 갱신하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBox_Main_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.PageUnit = GraphicsUnit.Pixel;
            gr.DrawImage(this.bmp_avata, 0, 0);
        }


        /// <summary>
        /// 몸 형태 변경 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_Body_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_Body.Checked)
            {
                this.pBox_Main.Image = this.body.Images[1];
                this.gp_avata.DrawImage(this.body.Images[1], 0, 0, this.pBox_Main.Width, this.pBox_Main.Height);
            }
            else
            {
                this.pBox_Main.Image = this.body.Images[1];
                this.gp_avata.DrawImage(this.body.Images[1], 0, 0, this.pBox_Main.Width, this.pBox_Main.Height);
            }

        }
    }
}