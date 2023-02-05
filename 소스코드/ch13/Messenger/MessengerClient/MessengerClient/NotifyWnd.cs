using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;  // Win32 �Լ� ���

namespace MessengerClient
{
    public partial class NotifyWnd : Form
    {
        #region NotifyWnd Ŭ���� ��� ����

        private Bitmap backgroundImage = null;   // ���ȭ��
        private Bitmap closeButtonImage = null;  // �����ư �̹���  

        private Point closeButtonLocation;       // ���� ��ư ��� ��ġ
        private Size closeButtonSize;            // ���� ��ư ��� ũ��
        private Rectangle titleRect;              // ���� ��� ����
        private Rectangle realTitleRect;          // ������ Ŭ���Ҷ� ���콺 ����
        private Rectangle contentRect;            // ���� ��� ����
        private Rectangle realContentRect;        // ������ Ŭ���Ҷ� ���콺 ����
        private Rectangle screenRect;             // ����â ��� ����
        private Timer timer = null;               // Ÿ�̸�

        private string title;                          // ���� 
        private string content;                        // ���� 

        private int nShowCount = 0;                    // ȭ�� ��µɶ� �ִϸ��̼� �ð� ����
        private int nShowIncrement = 0;                // ȭ���� ��µɶ� �ִϸ��̼Ǵ� ����ġ
        private int nVisibleCount = 0;                 // ȭ�鿡 ����â ��� �ð� ����
        private int nHideCount = 0;                    // ȭ�� ������� �ִϸ��̼� �ð� ����
        private int nHideDecrement = 0;                // ȭ�� ������� �ִϸ��̼� Ƚ��

        private NotifyState notifyState = NotifyState.Hidden;

        private bool bMouseOverClose = false;         // �����ư���� ���콺�� �ִ��� üũ
        private bool bMouseDown = false;               // �����ư������ ���콺�� ���ȴ��� üũ
        private bool bMouseOverTitle = false;          // ���� ���� ���콺�� �ִ��� üũ
        private bool bMouseOverContent = false;        // ���� ���� ���콺�� �ִ��� üũ
        private bool bMouseOverNotify = false;        // ����â�� ���콺�� �ö�Դ��� üũ

        public event EventHandler TitleClick = null;   // ���� Ŭ���� �� �߻��ϴ� �̺�Ʈ
        public event EventHandler ContentClick = null; // ���� Ŭ���� �� �߻��ϴ� �̺�Ʈ
        public event EventHandler CloseClick = null;   // ���� ��ư Ŭ���Ҷ� �߻��ϴ� �̺�Ʈ

        #endregion

        #region NotifyWnd Ŭ���� ������

        /// <summary>
        ///  ����â ������
        /// </summary>
        /// <param name="backbmp">��� �̹���</param>
        /// <param name="closebmp">�����ư �̹���</param>
        public NotifyWnd(Bitmap backbmp, Bitmap closebmp)
        {
            // ������ �ʱ�ȭ
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

            // Ÿ�̸� ����
            timer = new Timer();
            timer.Enabled = true;
            timer.Tick += new EventHandler(OnTimer);

            // ��µ� ��� �̹��� ����
            this.backgroundImage = backbmp;   // ��� �̹��� ����
            this.Width = backbmp.Width;       // ��� â�� �� ���� 
            this.Height = backbmp.Height;     // ��� â�� ���� ����

            // ���� ��ư �̹��� ����
            this.closeButtonImage = closebmp;
            this.closeButtonLocation = new Point(127, 8);
            this.closeButtonSize = new Size(closebmp.Width / 3, closebmp.Height);

            // ����/���� ��� ����
            this.titleRect = new Rectangle(38, 10, 90, 25);
            this.contentRect = new Rectangle(10, 40, 130, 70);
        }

        #endregion

        #region ����� �Ӽ�(property)
        /// <summary>
        /// NotifyState ��� ����
        /// </summary>
        public enum NotifyState
        {
            Hidden = 0,
            Visible = 1,
            Appear = 2,
            DisAppear = 3
        }

        /// <summary>
        /// ��µ� ���� ���ڿ�
        /// </summary>
        public string TitleText
        {
            get
            {
                return this.title;
            }
        }

        /// <summary>
        /// ��µ� ���� ���ڿ�
        /// </summary>
        public string ContentText
        {
            get
            {
                return this.content;
            }
        }

        #endregion


        #region ��� �Լ�

        /// <summary>
        /// ȭ�鿡 Notify â�� ȣ���ϱ����� Win32 API ���
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);

        /// <summary>
        /// ����� ������ ��ġ�� ���콺 ���� ����
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
        /// ����â ���
        /// </summary>
        /// <param name="strTitle">����</param>
        /// <param name="strContent">����</param>
        /// <param name="nShowTime">��� �ð�</param>
        /// <param name="nStayTime">���� �ð�</param>
        /// <param name="nHideTime">������ �ð�</param>
        public void Show(string strTitle, string strContent, int nShowTime, int nStayTime, int nHideTime)
        {
            this.screenRect = Screen.GetWorkingArea(this.screenRect);

            this.title = strTitle;        // ����
            this.content = strContent;    // ��� ����

            this.MouseRegion();           // ���콺�� ������ ���� ���� 

            this.nVisibleCount = nStayTime;

            // ȭ�鿡 â�� ��µɶ� �ִϸ��̼� ����
            int nCount = 0;             // ȭ�� ���� Ƚ��

            if (nShowTime > 10)
            {
                nCount = Math.Min((nShowTime / 10), this.backgroundImage.Height);
                this.nShowCount = nShowTime / nCount;    // ȭ�� ��µɶ� �ִϸ��̼� Ƚ��
                this.nShowIncrement = this.backgroundImage.Height / nCount;  // �ѹ� ȭ���� ���ŵɶ� ����ġ
            }
            else
            {
                this.nShowCount = 10;
                this.nShowIncrement = this.backgroundImage.Height;
            }

            // ȭ���� ������ �ִϸ��̼� ����
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

            // Hidden -> Appear -> Visible -> DisAppear -> Hidden ������ ȭ�� ��ȭ
            switch (this.notifyState)
            {
                case NotifyState.Hidden:
                    this.notifyState = NotifyState.Appear;
                    this.SetBounds(this.screenRect.Right - this.backgroundImage.Width - 10, this.screenRect.Bottom - 1, this.backgroundImage.Width, 0);
                    timer.Interval = this.nShowCount;  // Ÿ�̸� �ð� ����
                    timer.Start();
                    // ���� ȭ�鿡 â ���
                    ShowWindow(this.Handle, 4); // Win32 API �Լ� ȣ��
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


        #region �������̵� �޼ҵ�

        /// <summary>
        /// ����ȭ�� �׸���
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

            // ����ȭ�� �׸���
            offscreen.DrawImage(this.backgroundImage, 0, 0, this.backgroundImage.Width, this.backgroundImage.Height);
            // �����ư �׸���
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

            // ����� ���� ���
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
        /// Ÿ�̸� �̺�Ʈ �޼ҵ�
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
        /// â �����
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
        /// ���콺 ����
        /// </summary>
        /// <param name="ea"></param>
        protected override void OnMouseEnter(EventArgs ea)
        {
            base.OnMouseEnter(ea);
            this.bMouseOverNotify = true;
            Refresh();
        }

        /// <summary>
        /// ���콺 ����
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
        /// ���콺 �̵�
        /// </summary>
        /// <param name="mea"></param>
        protected override void OnMouseMove(MouseEventArgs mea)
        {
            base.OnMouseMove(mea);

            bool bContentModified = false;

            // ���� ��ư �̹����� ��ġ�� ���
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
            else if (this.realTitleRect.Contains(new Point(mea.X, mea.Y))) // ���� ���콺�� ��ġ�Ҷ�
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
            else if (this.realContentRect.Contains(new Point(mea.X, mea.Y))) // ���뿡 ���콺�� ��ġ�Ҷ�
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
            else        // �����ư, ����, ���� �̿ܿ� ���콺�� ��ġ�Ҷ�
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
        /// ���콺�� ������
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
        /// ���콺�� ���϶�
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