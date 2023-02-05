using System;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DragandDropExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;          // 폼 드롭 기능 활성화

            this.txt_box.AllowDrop = true;  // TextBox 드롭 기능 활성화
            this.txt_box.DragOver += new DragEventHandler(txt_box_DragOver); 
            this.txt_box.DragDrop += new DragEventHandler(txt_box_DragDrop);

            this.rich_txt_box.AllowDrop = true; // RichTextBox 드롭 기능 활성화            
            this.rich_txt_box.DragEnter += new DragEventHandler(rich_txt_box_DragEnter);
            this.rich_txt_box.DragDrop  += new DragEventHandler(rich_txt_box_DragDrop);

            this.DragOver += new DragEventHandler(pic_box_DragOver); //DragOver 이벤트
            this.DragDrop += new DragEventHandler(pic_box_DragDrop); //DragDrop 이벤트
        }

        // TextBox 위에 마우스가 위치하면
        void txt_box_DragOver(object sender, DragEventArgs dea)
        {

            if (dea.Data.GetDataPresent(DataFormats.FileDrop) ||
               dea.Data.GetDataPresent(DataFormats.StringFormat))
            {
                if ((dea.AllowedEffect & DragDropEffects.Move) != 0)
                    dea.Effect = DragDropEffects.Move;
                if(((dea.AllowedEffect & DragDropEffects.Copy) != 0) &&
                   ((dea.KeyState & 8) != 0))
                    dea.Effect = DragDropEffects.Copy;
                    
            }
        }

        void txt_box_DragDrop(object sender, DragEventArgs dea)
        {
            if (dea.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fname = (string[])dea.Data.GetData(DataFormats.FileDrop);
                TextReader tr = new StreamReader(fname[0]);
                txt_box.Text = tr.ReadToEnd();
                tr.Close();
            }
        }

        void rich_txt_box_DragEnter(object sender, DragEventArgs dea)
        {
            if (dea.Data.GetDataPresent(DataFormats.FileDrop) ||
                dea.Data.GetDataPresent(typeof(string)))
            {
                if ((dea.AllowedEffect & DragDropEffects.Move) != 0)
                    dea.Effect = DragDropEffects.Move;

                if (((dea.AllowedEffect & DragDropEffects.Copy) != 0) &&
                    ((dea.KeyState & 8) != 0))
                    dea.Effect = DragDropEffects.Copy;
            }
        }

        void rich_txt_box_DragDrop(object sender, DragEventArgs dea)
        {
            if (dea.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fname = (string[])dea.Data.GetData(DataFormats.FileDrop);                
                this.rich_txt_box.LoadFile(fname[0]);
            }
        }

        void pic_box_DragOver(object sender, DragEventArgs dea)
        {
            if (dea.Data.GetDataPresent(DataFormats.FileDrop) ||
               dea.Data.GetDataPresent(typeof(Bitmap)))
            {
                if ((dea.AllowedEffect & DragDropEffects.Move) != 0)
                    dea.Effect = DragDropEffects.Move;

                if (((dea.AllowedEffect & DragDropEffects.Copy) != 0) &&
                    ((dea.KeyState & 8) != 0))
                    dea.Effect = DragDropEffects.Copy;
            }
        }

        void pic_box_DragDrop(object sender, DragEventArgs dea)
        {
            if (dea.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string [] fname = (string [])dea.Data.GetData(DataFormats.FileDrop);
                try
                {
                    Image img = Image.FromFile(fname[0]);
                    this.pic_box.Image = img;                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

        }
    }
}