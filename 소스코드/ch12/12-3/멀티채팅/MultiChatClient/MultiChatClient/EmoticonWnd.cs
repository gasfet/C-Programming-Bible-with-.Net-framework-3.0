using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace MultiChatClient
{
    public delegate void EmoticonWndEventHandler(object sender, EmoticonWndEventArgs ewea);

    public partial class EmoticonWnd : Form
    {
        public event EmoticonWndEventHandler ItemClick = null;

        protected ToolTip tooltip = null;

        string[,] tooltip_str = new string[,]{{"�����̼�", "ȯ�ѿ���", "��ũ", "���", "�޷�", "����", "�̾�", "����", "�β�����", "�쾾"},
											   {"����", "��~", "����", "�쾾~", "���", "�ù���", "��û", "��ǰ","����", "����~"},
											   {"�ұټұ�", "���", "����", "���", "���������~", "ģ��", "�߿���", "�۸���", "������", "��"},
											   {"��", "��", "��", "������", "�����~��", "�����~��", "�Լ�", "���", "�õ����", "�ð�"},
											   {"����", "����", "ī�޶�", "����", "Ŀ��", "��ȭ��", "�ڵ���", "�ڵ���", "�����", "��ǻ��"},
											   {"��", "��ȭ", "����", "����", "�౸", "����", "����", "����", "��", "���"}};

        // Bitmap ����(��ü�� �̸�Ƽ���� �ϳ��� Bitmap���� �����.)
        protected Bitmap bitmap = null;
        // �̸�Ƽ���� �̹��� ����Ʈ
        protected ImageList imageList = null;
        // Bitmap�� ��
        protected int bitmap_width = 0;
        // Bitmap�� ����
        protected int bitmap_height = 0;
        // �ϳ��� �̸�Ƽ���� ��
        protected int item_width = 0;
        // �ϳ��� �̸�Ƽ���� ����
        protected int item_height = 0;
        // �̸�Ƽ���� ������ ����
        protected int rows = 0;
        // �̸�Ƽ���� ������ ����
        protected int columns = 0;

        protected int space_H = 0;
        protected int space_V = 0;
        protected int coord_X = -1;
        protected int coord_Y = -1;
        protected bool mousedown = false;

    
        public EmoticonWnd()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Minimized;
            base.Show();
            base.Hide();
            this.WindowState = FormWindowState.Normal;
            //�۾�ǥ���� �������� ����
            this.ShowInTaskbar = false;
            // �Ǿ����� ǥ��
            this.TopMost = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;

            tooltip = new ToolTip();
        }

        public bool Init(ImageList imageList, int space_H, int space_V, int columns, int rows)
        {
            int i = 0, j = 0;
            this.imageList = imageList;
            this.columns = columns;
            this.rows = rows;
            this.space_H = space_H;
            this.space_V = space_V;
            this.item_width = this.imageList.ImageSize.Width + space_V;
            this.item_height = this.imageList.ImageSize.Height + space_H;
            this.bitmap_width = this.columns * this.item_width + 1;
            this.bitmap_height = this.rows * this.item_height + 1;
            this.Width = this.bitmap_width;
            this.Height = this.bitmap_height;

            // Bitmap�� ���� �׾ȿ� ������ �̸�Ƽ���� ������� ǥ������ �׷� �ִ´�.
            this.bitmap = new Bitmap(this.bitmap_width, this.bitmap_height);
            Graphics gp = Graphics.FromImage(this.bitmap);

            gp.FillRectangle(new SolidBrush(Color.White), 0, 0, this.bitmap_width, this.bitmap_height);

            for (i = 0; i < this.columns; i++)
                gp.DrawLine(new Pen(Color.SaddleBrown), i * this.item_width, 0, i * this.item_width, this.bitmap_height - 1);

            for (i = 0; i < this.rows; i++)
                gp.DrawLine(new Pen(Color.SaddleBrown), 0, i * this.item_height, this.bitmap_width - 1, i * this.item_height);

            gp.DrawRectangle(new Pen(Color.SaddleBrown), 0, 0, this.bitmap_width - 1, this.bitmap_height - 1);

            for (i = 0; i < this.columns; i++)
            {
                for (j = 0; j < this.rows; j++)
                {
                    if ((j * this.columns + i) < this.imageList.Images.Count)
                        imageList.Draw(gp,
                            i * this.item_width + this.space_H / 2,
                            j * this.item_height + this.space_V / 2,
                            this.imageList.ImageSize.Width,
                            this.imageList.ImageSize.Height,
                            j * this.columns + i);
                }
            }

            return true;

        }


        protected override void OnDeactivate(EventArgs ea)
        {
            this.Hide();
        }

        protected override void OnPaintBackground(PaintEventArgs pea)
        {
            Graphics gp = pea.Graphics;
            gp.PageUnit = GraphicsUnit.Pixel;

            Bitmap screenbitmap = new Bitmap(this.bitmap_width, this.bitmap_height);
            Graphics gpfx = Graphics.FromImage(screenbitmap);

            gpfx.DrawImage(this.bitmap, 0, 0);


            if (this.coord_X != -1 && this.coord_Y != -1 && (this.coord_Y * this.columns + this.coord_X) < this.imageList.Images.Count)
            {

                gpfx.FillRectangle(new SolidBrush(Color.RoyalBlue), this.coord_X * this.item_width + 1, this.coord_Y * this.item_height + 1, this.item_width - 1, this.item_height - 1);
                if (this.mousedown)
                {
                    this.imageList.Draw(gpfx,
                        this.coord_X * this.item_width + this.space_H / 2 + 1,
                        this.coord_Y * this.item_height + this.space_V / 2 + 1,
                        this.imageList.ImageSize.Width,
                        this.imageList.ImageSize.Height,
                        this.coord_Y * this.columns + this.coord_X);
                }
                else
                {
                    this.imageList.Draw(gpfx,
                        this.coord_X * this.item_width + this.space_H / 2,
                        this.coord_Y * this.item_height + this.space_V / 2,
                        this.imageList.ImageSize.Width,
                        this.imageList.ImageSize.Height,
                        this.coord_Y * this.columns + this.coord_X);
                }

                gpfx.DrawRectangle(new Pen(Color.RoyalBlue), this.coord_X * this.item_width, this.coord_Y * this.item_height, this.item_width, this.item_height);
            }

            gp.DrawImage(screenbitmap, 0, 0);

        }


        /// �̸�Ƽ�� �̹��� ������ ���콺�� ������ �� 
        protected override void OnMouseMove(MouseEventArgs mea)
        {
            if (this.ClientRectangle.Contains(new Point(mea.X, mea.Y)))
            {
                if (this.mousedown)
                {
                    int nImage = this.coord_Y * this.columns + this.coord_X;
                    DataObject data = new DataObject();
                    data.SetData(DataFormats.Text, nImage.ToString());
                    data.SetData(DataFormats.Bitmap, this.imageList.Images[nImage]);
                    DragDropEffects dde = DoDragDrop(data, DragDropEffects.Copy | DragDropEffects.Move);
                    this.mousedown = false;
                }

                if (((mea.X / this.item_width) != this.coord_X) || ((mea.Y / this.item_height) != this.coord_Y))
                {
                    try
                    {
                        this.coord_X = mea.X / this.item_width;
                        this.coord_Y = mea.Y / this.item_height;
                        tooltip.SetToolTip(this, tooltip_str[coord_Y, coord_X]);
                        Invalidate();
                    }
                    catch { }
                }
            }
            else
            {
                this.coord_X = -1;
                this.coord_Y = -1;
                Invalidate();
            }
            base.OnMouseMove(mea);
        }


        protected override void OnMouseDown(MouseEventArgs mea)
        {
            base.OnMouseDown(mea);
            this.mousedown = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mea)
        {
            base.OnMouseDown(mea);
            this.mousedown = false;

            int nImageId = this.coord_Y * this.columns + this.coord_X;

            if (ItemClick != null && nImageId >= 0 && nImageId < this.imageList.Images.Count)
            {
                ItemClick(this, new EmoticonWndEventArgs(nImageId));
                Hide();
            }

        }


        public void ShowWnd(Point pt)
        {
            this.Location = pt;

            this.Show();

        }
    }

    public class EmoticonWndEventArgs : EventArgs
    {
        public int SelectedItem;

        public EmoticonWndEventArgs(int selectedItem)
        {
            this.SelectedItem = selectedItem;
        }
    }

}
