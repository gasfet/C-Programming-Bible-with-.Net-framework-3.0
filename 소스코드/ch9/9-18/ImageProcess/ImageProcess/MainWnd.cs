using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcess
{
    public partial class MainWnd : Form
    {
        private string m_Image = null;   // 이미지 처리를 할 대상 파일
        private bool bDraw = false;
        private Bitmap [] tmpBitmap = new Bitmap[7];
        private LoadingWnd m_frmSearch;

        public MainWnd()
        {
            InitializeComponent();            
        }

        private void ImageAnalysis()
        {
            CImage image = null;

            CallLoadingWnd(7);

            try
            {
                RepaintLoadingWnd("원본이미지 읽어오기");
                tmpBitmap[0] = new Bitmap(this.m_Image);                
                image = new CImage(this.m_Image);
                RepaintLoadingWnd("흑백 이미지 변환");
                tmpBitmap[1] = new Bitmap((Image)image.Covert_Gray_Bitmap()); // 흑백 이미지
                RepaintLoadingWnd("라플라시안 에지");
                tmpBitmap[2] = new Bitmap((Image)image.Laplacian());          // 라플라시안 
                RepaintLoadingWnd("로버트 에지");
                tmpBitmap[3] = new Bitmap((Image)image.Robert());             // 로버트
                RepaintLoadingWnd("소벨 에지");
                tmpBitmap[4] = new Bitmap((Image)image.Sobel_Edge());         // 소벨
                RepaintLoadingWnd("미러(거울효과)");
                tmpBitmap[5] = new Bitmap((Image)image.Mirror());             // 미러 효과
                RepaintLoadingWnd("플립 효과");
                tmpBitmap[6] = new Bitmap((Image)image.Flip());               // 플립 효과                
            }
            catch (Exception ex)
            {
                MessageBox.Show("에러 발생 : " + ex.Message);
                bDraw = false;
                CloseLoadingWnd();
            }
            finally
            {
                if (image != null) image.Dispose();
            }
            CloseLoadingWnd();
        }

        private void ImageDraw(Graphics g)
        {            
              SolidBrush brush = new SolidBrush(Color.Yellow);
                Font font = new Font("궁서체", 13, FontStyle.Bold);

                g.DrawImage(tmpBitmap[0], 0, 0, 150, 150);
                g.DrawString("원본", font, brush, 10, 10);

                g.DrawImage(tmpBitmap[1], 160, 0, 150, 150);
                g.DrawString("흑백", font, brush, 170, 10);

                g.DrawImage(tmpBitmap[2], 320, 0, 150, 150);
                g.DrawString("라플라시안", font, brush, 330, 10);
                
                g.DrawImage(tmpBitmap[3], 480, 0, 150, 150);
                g.DrawString("로버트", font, brush, 490, 10);
                                
                g.DrawImage(tmpBitmap[4], 160, 170, 150, 150);
                g.DrawString("소벨에지", font, brush, 170, 180);

                g.DrawImage(tmpBitmap[5], 320, 170, 150, 150);
                g.DrawString("거울효과", font, brush, 330, 180);

                g.DrawImage(tmpBitmap[6], 480, 170, 150, 150);
                g.DrawString("플립", font, brush, 490, 180); 
        }

        private void btn_SelectImage_Click(object sender, EventArgs e)
        {
            this.bDraw = false;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "이미지 파일을 선택하세요!";
            dlg.InitialDirectory = @"c:\";
            dlg.Filter = " Jpeg(*.jpg)|*.jpg| Gif(*.gif)|*.gif| Bmp(*.bmp)|*.bmp| All(*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.m_Image = dlg.FileName;
                this.btn_ImageProcess.Enabled = true;
            }
        }

        private void btn_ImageProcess_Click(object sender, EventArgs e)
        {
            this.bDraw = true;
            ImageAnalysis();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.bDraw)
            {
                ImageDraw(e.Graphics);
            }
        }

        // 진행 상태를 표시하는 윈도우 생성
        private void CallLoadingWnd(int count)
        {
            // 이미 출력된 상태면 
            if (m_frmSearch != null) return;

            // 출력
            m_frmSearch = new LoadingWnd();
            m_frmSearch.CenterParentFrm(this, count);
            m_frmSearch.Show();
        }

        // 진행 상태 표시 폼을 제거한다.
        private void CloseLoadingWnd()
        {
            // 출력되기 전이라면 
            if (m_frmSearch == null) return;

            // 제거
            m_frmSearch.Close();
            m_frmSearch.Dispose();
            m_frmSearch = null;

        }

        // 진행 상태 갱신
        private void RepaintLoadingWnd(string str)
        {
            m_frmSearch.LoadingImage(str);
        }

    }
}