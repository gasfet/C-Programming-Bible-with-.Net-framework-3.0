using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;  // Win32 함수 사용

namespace MessengerClient
{
    public partial class NotifyWnd : Form
    {
        #region NotifyWnd 클래스 멤버 변수

        private Bitmap backgroundImage = null;   // 배경화면
        private Bitmap closeButtonImage = null;  // 종료버튼 이미지  

        private Point closeButtonLocation;       // 종료 버튼 출력 위치
        private Size closeButtonSize;            // 종료 버튼 출력 크기
        private Rectangle titleRect;              // 제목 출력 영역
        private Rectangle realTitleRect;          // 제목을 클릭할때 마우스 영역
        private Rectangle contentRect;            // 내용 출력 영역
        private Rectangle realContentRect;        // 내용을 클릭할때 마우스 영역
        private Rectangle screenRect;             // 공지창 출력 영역
        private Timer timer = null;               // 타이머

        private string title;                          // 제목 
        private string content;                        // 내용 

        private int nShowCount = 0;                    // 화면 출력될때 애니메이션 시간 간격
        private int nShowIncrement = 0;                // 화면이 출력될때 애니메이션당 증가치
        private int nVisibleCount = 0;                 // 화면에 공지창 출력 시간 간격
        private int nHideCount = 0;                    // 화면 사라질때 애니메이션 시간 간격
        private int nHideDecrement = 0;                // 화면 사라질때 애니메이션 횟수

        private NotifyState notifyState = NotifyState.Hidden;

        private bool bMouseOverClose = false;         // 종료버튼위에 마우스가 있는지 체크
        private bool bMouseDown = false;               // 종료버튼위에서 마우스가 눌렸는지 체크
        private bool bMouseOverTitle = false;          // 제목 위에 마우스가 있는지 체크
        private bool bMouseOverContent = false;        // 내용 위에 마우스가 있는지 체크
        private bool bMouseOverNotify = false;        // 공지창에 마우스가 올라왔는지 체크

        public event EventHandler TitleClick = null;   // 제목 클릭할 때 발생하는 이벤트
        public event EventHandler ContentClick = null; // 내용 클릭할 때 발생하는 이벤트
        public event EventHandler CloseClick = null;   // 종료 버튼 클릭할때 발생하는 이벤트

        #endregion

        #region NotifyWnd 클래스 생성자

        /// <summary>
        ///  공지창 생성자
        /// </summary>
        /// <param name="backbmp">배경 이미지</param>
        /// <param name="closebmp">종료버튼 이미지</param>
        public NotifyWnd(Bitmap backbmp, Bitmap closebmp)
        {
            // 윈도우 초기화
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Minimized;
            base.Show();
            base.Hide();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = false;
            TopMost = true;
            MaximizeBox = false;
            MinimizeBox = false;
            ControlBox = false;

            // 타이머 설정
            timer = new Timer();
            timer.Enabled = true;
            timer.Tick += new EventHandler(OnTimer);

            // 출력될 배경 이미지 설정
            this.backgroundImage = backbmp;   // 배경 이미지 설정
            this.Width = backbmp.Width;       // 출력 창의 폭 설정 
            this.Height = backbmp.Height;     // 출력 창의 높이 설정

            // 종료 버튼 이미지 설정
            this.closeButtonImage = closebmp;
            this.closeButtonLocation = new Point(127, 8);
            this.closeButtonSize = new Size(closebmp.Width / 3, closebmp.Height);

            // 제목/내용 출력 영역
            this.titleRect = new Rectangle(38, 10, 90, 25);
            this.contentRect = new Rectangle(10, 40, 130, 70);
        }

        #endregion

        #region 상수와 속성(property)
        /// <summary>
        /// NotifyState 상수 정의
        /// </summary>
        public enum NotifyState
        {
            Hidden = 0,
            Visible = 1,
            Appear = 2,
            DisAppear = 3
        }

        /// <summary>
        /// 출력된 제목 문자열
        /// </summary>
        public string TitleText
        {
            get
            {
                return this.title;
            }
        }

        /// <summary>
        /// 출력된 내용 문자열
        /// </summary>
        public string ContentText
        {
            get
            {
                return this.content;
            }
        }

        #endregion


        #region 멤버 함수

        /// <summary>
        /// 화면에 Notify 창을 호출하기위해 Win32 API 사용
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);

        /// <summary>
        /// 제목과 내용이 위치한 마우스 영역 감지
        /// </summary>
        private void MouseRegion()
        {
            Graphics grfx = CreateGraphics();

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;

            SizeF sTitle = grfx.MeasureString(this.title, new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Pixel), this.titleRect.Width, sf);
            SizeF sContent = grfx.MeasureString(this.content, new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel), this.contentRect.Width, sf);

            grfx.Dispose();


            if (sTitle.Height > this.titleRect.Height)
            {
                this.realTitleRect = new Rectangle(this.titleRect.Left, this.titleRect.Top, this.titleRect.Width, this.titleRect.Height);
            }
            else
            {
                this.realTitleRect = new Rectangle(this.titleRect.Left, this.titleRect.Top, (int)sTitle.Width, (int)sTitle.Height);
            }

            this.realTitleRect.Inflate(0, 2);


            if (sContent.Height > this.contentRect.Height)
            {
                this.realContentRect = new Rectangle((this.contentRect.Width - (int)this.contentRect.Width) / 2 + this.contentRect.Left, this.contentRect.Top, (int)sContent.Width, this.contentRect.Height);
            }
            else
            {
                this.realContentRect = new Rectangle((this.contentRect.Width - (int)sContent.Width) / 2 + this.contentRect.Left, (this.contentRect.Height - (int)sContent.Height) / 2 + this.contentRect.Top, (int)sContent.Width, (int)sContent.Height);
            }

            this.realContentRect.Inflate(0, 2);
        }



        /// <summary>
        /// 공지창 출력
        /// </summary>
        /// <param name="strTitle">제목</param>
        /// <param name="strContent">내용</param>
        /// <param name="nShowTime">출력 시간</param>
        /// <param name="nStayTime">지속 시간</param>
        /// <param name="nHideTime">닫히는 시간</param>
        public void Show(string strTitle, string strContent, int nShowTime, int nStayTime, int nHideTime)
        {
            this.screenRect = Screen.GetWorkingArea(this.screenRect);

            this.title = strTitle;        // 제목
            this.content = strContent;    // 출력 내용

            this.MouseRegion();           // 마우스가 감지될 영역 설정 

            this.nVisibleCount = nStayTime;

            // 화면에 창이 출력될때 애니메이션 설정
            int nCount = 0;             // 화면 갱신 횟수

            if (nShowTime > 10)
            {
                nCount = Math.Min((nShowTime / 10), this.backgroundImage.Height);
                this.nShowCount = nShowTime / nCount;    // 화면 출력될때 애니메이션 횟수
                this.nShowIncrement = this.backgroundImage.Height / nCount;  // 한번 화면이 갱신될때 증가치
            }
            else
            {
                this.nShowCount = 10;
                this.nShowIncrement = this.backgroundImage.Height;
            }

            // 화면이 닫힐때 애니메이션 설정
            if (nHideTime > 10)
            {
                nCount = Math.Min((nHideTime / 10), this.backgroundImage.Height);
                this.nHideCount = nHideTime / nCount;
                this.nHideDecrement = this.backgroundImage.Height / nCount;
            }
            else
            {
                this.nHideCount = 10;
                this.nHideDecrement = this.backgroundImage.Height;
            }

            // Hidden -> Appear -> Visible -> DisAppear -> Hidden 순으로 화면 변화
            switch (this.notifyState)
            {
                case NotifyState.Hidden:
                    this.notifyState = NotifyState.Appear;
                    this.SetBounds(this.screenRect.Right - this.backgroundImage.Width - 10, this.screenRect.Bottom - 1, this.backgroundImage.Width, 0);
                    timer.Interval = this.nShowCount;  // 타이머 시간 설정
                    timer.Start();
                    // 바탕 화면에 창 출력
                    ShowWindow(this.Handle, 4); // Win32 API 함수 호출
                    break;

                case NotifyState.Visible:
                    timer.Stop();
                    timer.Interval = this.nVisibleCount;
                    timer.Start();
                    Refresh();
                    break;

                case NotifyState.Appear:
                    Refresh();
                    break;

                case NotifyState.DisAppear:
                    timer.Stop();
                    this.notifyState = NotifyState.Visible;
                    this.SetBounds(this.screenRect.Right - this.backgroundImage.Width - 10, this.screenRect.Bottom - this.backgroundImage.Height - 1, this.backgroundImage.Width, this.backgroundImage.Height);
                    timer.Interval = this.nVisibleCount;
                    timer.Start();
                    Refresh();
                    break;
            }
        }

        #endregion


        #region 오버라이딩 메소드

        /// <summary>
        /// 바탕화면 그리기
        /// </summary>
        /// <param name="pea"></param> 
        protected override void OnPaintBackground(PaintEventArgs pea)
        {
            Graphics grfx = pea.Graphics;
            grfx.PageUnit = GraphicsUnit.Pixel;

            Graphics offscreen;
            Bitmap bmp;

            bmp = new Bitmap(this.backgroundImage.Width, this.backgroundImage.Height);
            offscreen = Graphics.FromImage(bmp);

            // 바탕화면 그리기
            offscreen.DrawImage(this.backgroundImage, 0, 0, this.backgroundImage.Width, this.backgroundImage.Height);
            // 종료버튼 그리기
            Rectangle rectDest = new Rectangle(this.closeButtonLocation, this.closeButtonSize);
            Rectangle rectSrc;
            if (bMouseOverClose)
            {
                if (bMouseDown)
                    rectSrc = new Rectangle(new Point(this.closeButtonSize.Width * 2, 0), this.closeButtonSize);
                else
                    rectSrc = new Rectangle(new Point(this.closeButtonSize.Width, 0), this.closeButtonSize);
            }
            else
            {
                rectSrc = new Rectangle(new Point(0, 0), this.closeButtonSize);
            }
            offscreen.DrawImage(this.closeButtonImage, rectDest, rectSrc, GraphicsUnit.Pixel);

            // 제목과 내용 출력
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.NoWrap;
            sf.Trimming = StringTrimming.EllipsisCharacter;

            if (bMouseOverTitle)
            {
                offscreen.DrawString(this.title, new Font("Arial", 11, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.DarkCyan), this.titleRect, sf);
                ControlPaint.DrawBorder3D(offscreen, this.realTitleRect, Border3DStyle.Etched, Border3DSide.Top | Border3DSide.Bottom | Border3DSide.Left | Border3DSide.Right);
            }
            else
            {
                offscreen.DrawString(this.title, new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Pixel), new SolidBrush(Color.Navy), this.titleRect, sf);
            }

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
            sf.Trimming = StringTrimming.Word;

            offscreen.DrawString(this.content, new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel), new SolidBrush(Color.Black), this.contentRect, sf);

            if (bMouseOverContent)
            {
                offscreen.DrawString(this.content, new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel), new SolidBrush(Color.Brown), this.contentRect, sf);
                ControlPaint.DrawBorder3D(offscreen, this.realContentRect, Border3DStyle.Etched, Border3DSide.Top | Border3DSide.Bottom | Border3DSide.Left | Border3DSide.Right);
            }

            grfx.DrawImage(bmp, 0, 0);
        }

        /// <summary>
        /// 타이머 이벤트 메소드
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        protected void OnTimer(Object obj, EventArgs ea)
        {
            switch (this.notifyState)
            {
                case NotifyState.Appear:
                    if (this.Height < this.backgroundImage.Height)
                    {
                        this.SetBounds(this.Left, this.Top - this.nShowIncrement, this.Width, this.Height + this.nShowIncrement);
                    }
                    else
                    {
                        timer.Stop();
                        this.Height = this.backgroundImage.Height;
                        timer.Interval = this.nVisibleCount;
                        this.notifyState = NotifyState.Visible;
                        timer.Start();
                    }
                    break;

                case NotifyState.Visible:
                    timer.Stop();
                    timer.Interval = this.nHideCount;

                    this.notifyState = NotifyState.DisAppear;

                    timer.Start();
                    break;

                case NotifyState.DisAppear:
                    if (this.bMouseOverNotify)
                    {
                        this.notifyState = NotifyState.Appear;
                    }
                    else
                    {
                        if (this.Top < this.screenRect.Bottom)
                            this.SetBounds(this.Left, this.Top + this.nHideDecrement, this.Width, this.Height - this.nHideDecrement);
                        else
                            this.Hide();
                    }
                    break;
            }

        }


        /// <summary>
        /// 창 숨기기
        /// </summary> 
        public new void Hide()
        {
            if (this.notifyState != NotifyState.Hidden)
            {
                timer.Stop();
                this.notifyState = NotifyState.Hidden;
                base.Hide();
            }
        }

        /// <summary>
        /// 마우스 들어옴
        /// </summary>
        /// <param name="ea"></param>
        protected override void OnMouseEnter(EventArgs ea)
        {
            base.OnMouseEnter(ea);
            this.bMouseOverNotify = true;
            Refresh();
        }

        /// <summary>
        /// 마우스 나감
        /// </summary>
        /// <param name="ea"></param>
        protected override void OnMouseLeave(EventArgs ea)
        {
            base.OnMouseLeave(ea);
            this.bMouseOverNotify = false;
            this.bMouseOverTitle = false;
            this.bMouseOverContent = false;
            Refresh();
        }

        /// <summary>
        /// 마우스 이동
        /// </summary>
        /// <param name="mea"></param>
        protected override void OnMouseMove(MouseEventArgs mea)
        {
            base.OnMouseMove(mea);

            bool bContentModified = false;

            // 종료 버튼 이미지에 위치할 경우
            if ((mea.X > this.closeButtonLocation.X) && (mea.X < this.closeButtonLocation.X + this.closeButtonSize.Width) && (mea.Y > this.closeButtonLocation.Y) && (mea.Y < this.closeButtonLocation.Y + this.closeButtonSize.Height))
            {
                if (!this.bMouseOverClose)
                {
                    this.bMouseOverClose = true;
                    this.bMouseOverTitle = false;
                    this.bMouseOverContent = false;
                    Cursor = Cursors.Hand;
                    bContentModified = true;
                }
            }
            else if (this.realTitleRect.Contains(new Point(mea.X, mea.Y))) // 제목에 마우스가 위치할때
            {
                if (!this.bMouseOverTitle)
                {
                    this.bMouseOverTitle = true;
                    this.bMouseOverContent = false;
                    this.bMouseOverClose = false;

                    Cursor = Cursors.Hand;
                    bContentModified = true;
                }
            }
            else if (this.realContentRect.Contains(new Point(mea.X, mea.Y))) // 내용에 마우스가 위치할때
            {
                if (!this.bMouseOverContent)
                {
                    this.bMouseOverContent = true;
                    this.bMouseOverClose = false;
                    this.bMouseOverTitle = false;

                    Cursor = Cursors.Hand;
                    bContentModified = true;
                }
            }
            else        // 종료버튼, 제목, 내용 이외에 마우스가 위치할때
            {
                if (this.bMouseOverClose || this.bMouseOverTitle || this.bMouseOverContent)
                {
                    bContentModified = true;
                }

                this.bMouseOverClose = false;
                this.bMouseOverTitle = false;
                this.bMouseOverContent = false;

                Cursor = Cursors.Default;
            }

            if (bContentModified)
                Refresh();
        }

        /// <summary>
        /// 마우스가 눌릴때
        /// </summary>
        /// <param name="mea"></param>
        protected override void OnMouseDown(MouseEventArgs mea)
        {
            base.OnMouseDown(mea);
            this.bMouseDown = true;

            if (this.bMouseOverClose)
                Refresh();
        }

        /// <summary>
        /// 마우스가 놓일때
        /// </summary>
        /// <param name="mea"></param>
        protected override void OnMouseUp(MouseEventArgs mea)
        {
            base.OnMouseUp(mea);
            this.bMouseDown = false;

            if (this.bMouseOverClose)
            {
                Hide();

                if (this.CloseClick != null)
                    CloseClick(this, new EventArgs());
            }
            else if (this.bMouseOverTitle)
            {
                if (this.TitleClick != null)
                    TitleClick(this, new EventArgs());
            }
            else if (this.bMouseOverContent)
            {
                if (this.ContentClick != null)
                    ContentClick(this, new EventArgs());
            }
        }
        #endregion

    }
}