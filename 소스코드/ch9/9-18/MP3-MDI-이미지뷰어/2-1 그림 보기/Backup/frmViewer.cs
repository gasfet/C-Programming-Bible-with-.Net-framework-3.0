using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ImgViewer
{
	/// <summary>
	/// Form1�� ���� ��� �����Դϴ�.
	/// </summary>
	public class frmViewer : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.ImageList imglstTmp;
		internal System.Windows.Forms.ToolTip tipPath;
		internal System.Windows.Forms.ColumnHeader ColumnHeader1;
		internal System.Windows.Forms.Panel Panel1;
		internal System.Windows.Forms.Panel Panel4;
		internal System.Windows.Forms.ListView lstDir;
		internal System.Windows.Forms.Label lblPath;
		internal System.Windows.Forms.Panel Panel3;
		internal System.Windows.Forms.PictureBox picSelect;
		private System.Windows.Forms.Splitter splitter1;
		internal System.Windows.Forms.Panel Panel2;
		private System.ComponentModel.IContainer components;

		// �������� ����
		int m_nCnt;
		int m_nSelLabel;

		public frmViewer()
		{
			//
			// Windows Form �����̳� ������ �ʿ��մϴ�.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent�� ȣ���� ���� ������ �ڵ带 �߰��մϴ�.
			//
		}

		/// <summary>
		/// ��� ���� ��� ���ҽ��� �����մϴ�.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// �����̳� ������ �ʿ��� �޼����Դϴ�.
		/// �� �޼����� ������ �ڵ� ������� �������� ���ʽÿ�.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmViewer));
			this.imglstTmp = new System.Windows.Forms.ImageList(this.components);
			this.tipPath = new System.Windows.Forms.ToolTip(this.components);
			this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.Panel4 = new System.Windows.Forms.Panel();
			this.lstDir = new System.Windows.Forms.ListView();
			this.lblPath = new System.Windows.Forms.Label();
			this.Panel3 = new System.Windows.Forms.Panel();
			this.picSelect = new System.Windows.Forms.PictureBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.Panel2 = new System.Windows.Forms.Panel();
			this.Panel1.SuspendLayout();
			this.Panel4.SuspendLayout();
			this.Panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// imglstTmp
			// 
			this.imglstTmp.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imglstTmp.ImageSize = new System.Drawing.Size(16, 16);
			this.imglstTmp.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstTmp.ImageStream")));
			this.imglstTmp.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// ColumnHeader1
			// 
			this.ColumnHeader1.Text = "����̺� �� ����";
			this.ColumnHeader1.Width = 200;
			// 
			// Panel1
			// 
			this.Panel1.AutoScroll = true;
			this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.Panel4,
																				 this.Panel3});
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(200, 477);
			this.Panel1.TabIndex = 3;
			// 
			// Panel4
			// 
			this.Panel4.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lstDir,
																				 this.lblPath});
			this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel4.Name = "Panel4";
			this.Panel4.Size = new System.Drawing.Size(196, 321);
			this.Panel4.TabIndex = 1;
			// 
			// lstDir
			// 
			this.lstDir.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					 this.ColumnHeader1});
			this.lstDir.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstDir.Location = new System.Drawing.Point(0, 14);
			this.lstDir.MultiSelect = false;
			this.lstDir.Name = "lstDir";
			this.lstDir.Size = new System.Drawing.Size(196, 307);
			this.lstDir.SmallImageList = this.imglstTmp;
			this.lstDir.TabIndex = 1;
			this.lstDir.View = System.Windows.Forms.View.Details;
			this.lstDir.DoubleClick += new System.EventHandler(this.lstDir_DoubleClick);
			// 
			// lblPath
			// 
			this.lblPath.AutoSize = true;
			this.lblPath.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(43, 14);
			this.lblPath.TabIndex = 0;
			this.lblPath.Text = "Label1";
			this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Panel3
			// 
			this.Panel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.picSelect});
			this.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Panel3.Location = new System.Drawing.Point(0, 321);
			this.Panel3.Name = "Panel3";
			this.Panel3.Size = new System.Drawing.Size(196, 152);
			this.Panel3.TabIndex = 0;
			// 
			// picSelect
			// 
			this.picSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.picSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picSelect.Location = new System.Drawing.Point(5, 8);
			this.picSelect.Name = "picSelect";
			this.picSelect.Size = new System.Drawing.Size(184, 136);
			this.picSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picSelect.TabIndex = 0;
			this.picSelect.TabStop = false;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(200, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 477);
			this.splitter1.TabIndex = 4;
			this.splitter1.TabStop = false;
			// 
			// Panel2
			// 
			this.Panel2.AutoScroll = true;
			this.Panel2.AutoScrollMinSize = new System.Drawing.Size(180, 180);
			this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel2.Location = new System.Drawing.Point(203, 0);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(437, 477);
			this.Panel2.TabIndex = 5;
			this.Panel2.Resize += new System.EventHandler(this.Panel2_Resize);
			// 
			// frmViewer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(640, 477);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Panel2,
																		  this.splitter1,
																		  this.Panel1});
			this.Name = "frmViewer";
			this.Text = "�̹��� ���";
			this.Load += new System.EventHandler(this.frmViewer_Load);
			this.Panel1.ResumeLayout(false);
			this.Panel4.ResumeLayout(false);
			this.Panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �ش� ���� ���α׷��� �� �������Դϴ�.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmViewer());
		}

		private void frmViewer_Load(object sender, System.EventArgs e)
		{
			SetFolder("C:\\");
			lblPath.Text = "C:";
			SetImgFile("C:\\");
			m_nSelLabel = -1;

			// ���� ����
			tipPath.SetToolTip(lblPath, lblPath.Text);
		}

		// ����̺� ��� �� �޺��ڽ��� �Է�
		// ��ȯ�� : ����̺� ����
		private int SetDrive()
		{
			String[] strDrives;
			String strTmp;

			// Up �׸��� �߰��Ѵ�.
			lstDir.Items.Add("..", 0);

			// ����̺� ����� ��´�. 
			strDrives = System.IO.Directory.GetLogicalDrives();

			// ������ ����̺� ����� ����Ʈ�信 �Է��Ѵ�.
			foreach (string str in strDrives) 
			{
				strTmp = str.Remove(2, 1);
				lstDir.Items.Add(strTmp, 1);
			}
        
			return lstDir.Items.Count; 
		}

		// ���� ������ ȭ�鿡 ����Ѵ�.
		// ��ȯ�� : ����, ����
		private bool SetFolder(String strParentPath)
		{
			System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(strParentPath);

			// ����Ʈ���� �������� ��� ��������
			lstDir.Items.Clear();

			// ����̺� ������ �����ش�.
			m_nCnt = SetDrive();
			lblPath.Text = "";
			
			try
			{

				foreach (System.IO.DirectoryInfo dirInfoCurDir in dirInfo.GetDirectories("*")) 
				{
					lstDir.Items.Add(dirInfoCurDir.Name.ToString(), 2);
				}
				lblPath.Text = strParentPath.Remove(strParentPath.Length - 1, 1);
			}
			catch
			{
				MessageBox.Show("���ٿ� �����߽��ϴ�.");
				return false;
			}
		
			return true;
		}

		// �׸������� ������ Ȯ���ڷ� ã�´�.
		// ��ȯ�� : true, false
		private bool IsImgFile(String strExi)
		{
			//BMP WMF, EMF, ICO, JPG, Gif, PNG
			String strTmp;
			strTmp = strExi.ToUpper();
			if (strTmp.IndexOf(".BMP") != -1)
				return true;
			else if (strTmp.IndexOf(".WMF") != -1) 
				return true;
			else if (strTmp.IndexOf(".EMF") != -1) 
				return true;
			else if (strTmp.IndexOf(".ICO") != -1) 
				return true;
			else if (strTmp.IndexOf(".JPG") != -1) 
				return true;
			else if (strTmp.IndexOf(".GIF") != -1) 
				return true;
			else if (strTmp.IndexOf(".PNG") != -1) 
				return true;
			else
				return false;
		}

		// �׸� ������ ã�Ƽ� �����ش�.
		private void SetImgFile(String strParentPath)
		{
			
			System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(strParentPath);
			int nCnt;
						
			Panel2.Controls.Clear();
			nCnt = 0;
	
			try
			{
				foreach (System.IO.FileInfo fileInfo in dirInfo.GetFiles("*.*")) 
				{
					if (IsImgFile(fileInfo.Extension))
					{
						MakePicCtrl(nCnt, fileInfo.FullName);
						nCnt += 1;
						MakeLblCtrl(nCnt, fileInfo.Name);
						nCnt += 1;
						Application.DoEvents();
					}
				}
				lblPath.Text = strParentPath.Remove(strParentPath.Length  - 1, 1);
			}
			catch
			{
			}
		}
	
		// ��ó�ڽ� ��Ʈ���� �����Ѵ�.
		private void MakePicCtrl(int nIndex, String strFilePath)
		{
			PictureBox pic = new PictureBox();
			Point pos;

			pic.Name = "pic" + nIndex.ToString(); // �̸�
			pic.SizeMode = PictureBoxSizeMode.StretchImage;
			pic.Tag = nIndex.ToString(); // tag�� ��Ʈ���� �ε����� ����
			pic.Size = new Size(80, 80); //ũ��

			GetPos(nIndex, out pos);

			pic.Location = pos;
			pic.BorderStyle = BorderStyle.FixedSingle;
			Panel2.Controls.Add(pic); // �гο� �߰�
						
			try
			{
				pic.Image = System.Drawing.Bitmap.FromFile(strFilePath); // �׸� �����ֱ�
			}
			catch
			{
				pic.Image = null;
			}
			
			// Ŭ��/����Ŭ�� �̺�Ʈ�� �����Ѵ�.
			pic.Click += new System.EventHandler(Ctrl_Click);
			pic.DoubleClick += new System.EventHandler(Ctrl_DoubleClick);
		}


		// �� ��Ʈ���� �����Ѵ�.
		private void MakeLblCtrl(int nIndex, String strFileName)
		{
			Label lbl = new Label();
			Point pos;

			lbl.Name = "lbl" + nIndex.ToString(); // �̸�
			lbl.Tag = nIndex.ToString();
			lbl.Size = new Size(80, 20); //ũ��
			lbl.TextAlign = ContentAlignment.MiddleLeft;

			GetPos(nIndex, out pos);

			lbl.Location = pos;
			lbl.BorderStyle = BorderStyle.FixedSingle;
			Panel2.Controls.Add(lbl); // �гο� �߰�
			lbl.Text = strFileName; // �׸� �̸� �����ֱ�
			lbl.BackColor = Color.GreenYellow;

			// Ŭ��/����Ŭ�� �̺�Ʈ�� �����Ѵ�.
			lbl.Click += new System.EventHandler(Ctrl_Click);
			lbl.DoubleClick += new System.EventHandler(Ctrl_DoubleClick);
		}

		private void GetPos(int nIndex, out Point pos)
		{
			pos = new Point();
			Size sizePan = new Size(Panel2.Width, Panel2.Height);
			int nXCnt;
			int i;

			if((nIndex % 2) == 0)// ��ó�ڽ���Ʈ���� ���
			{
				nXCnt = (int)(sizePan.Width / 85);

				i = (int)(nIndex / 2) % nXCnt;
				pos.X = (i * 80) + (5 * i) + 5;

				i = (int)((nIndex / 2) / nXCnt);
				pos.Y = (i * 80) + (35 * i) + 5;
			}
			else // �� ��Ʈ���� ���
			{
				nXCnt = (int)(sizePan.Width / 85);

				i = (int)(nIndex / 2) % nXCnt;
				pos.X = (i * 80) + (5 * i) + 5;

				i = (int)((nIndex / 2) / nXCnt);
				pos.Y = (i * 80) + (35 * i) + 5 + 82;
			}
		}

		
		// ��Ʈ�� �ε����� ���� ��ġ�� �����Ѵ�.
		// �г� ũ�⿡ ���� ��ó�ڽ� ��Ʈ���� ��ġ�� ������ �Ѵ�.
		private void MovePicCtrl()
		{
			int i=0;
			Point pos;

			Control.ControlCollection myCtrl = Panel2.Controls;

			foreach(Control ctl in myCtrl)    
			{
				GetPos(i, out pos);
				ctl.Location = pos;
				i++;
			}

		}

		// �ʿ��� ��Ʈ���� ��´�.
		private Control GetCtrl(String strCtrlName, int nTag)
		{
			Control.ControlCollection myCtrl = Panel2.Controls;

			foreach(Control ctl in myCtrl)    
			{
				// ��Ʈ�� ������ ��ġ�ϰ�
				if(ctl.GetType().Name.IndexOf(strCtrlName) != -1)
				{
					// �±װ� ��ġ�ϸ�
					if(Convert.ToInt32(ctl.Tag.ToString()) == nTag)
						return ctl;
				}
			}

			return null;

		}

		// �������� ��Ʈ���� Ŭ��/����Ŭ�� �̺�Ʈ
		private void Ctrl_Click(object sender, System.EventArgs e)
		{
			PictureBox pic;
			Label lbl;

			if(sender.GetType().Name.IndexOf("PictureBox") != -1) // Ŭ���� ��Ʈ���� ��ó�ڽ��� ���
			{
				pic = (System.Windows.Forms.PictureBox)sender;

				// �� ��Ʈ���� ��´�.
				lbl = (System.Windows.Forms.Label)GetCtrl("Label", Convert.ToInt32(pic.Tag) + 1);
			}
			else // Ŭ���� ��Ʈ���� ���� ���
			{
				lbl = (System.Windows.Forms.Label)sender;

				// ��ó�ڽ� ��Ʈ���� ��´�.
				pic = (System.Windows.Forms.PictureBox)GetCtrl("PictureBox", Convert.ToInt32(lbl.Tag) - 1);
			}
            

			// Ŭ���� ��ó�ڽ��� ������ picSelect�� �����ش�.
			picSelect.Image = pic.Image;

			// ������ �� ��Ʈ���� ���� ��������� �Ѵ�.
			lbl.BackColor = Color.Yellow;

        	//������ ������ �� ��Ʈ���� ���� GreenYellow�� �Ѵ�.
			if (m_nSelLabel != -1 && m_nSelLabel != Convert.ToInt32(lbl.Tag)) 
				GetCtrl("Label", m_nSelLabel).BackColor = Color.GreenYellow;

			m_nSelLabel = Convert.ToInt32(lbl.Tag);
		}
		
		private void Ctrl_DoubleClick(object sender, System.EventArgs e)
		{
			PictureBox pic;
			Label lbl;

			if(sender.GetType().Name.IndexOf("PictureBox") != -1) // Ŭ���� ��Ʈ���� ��ó�ڽ��� ���
			{
				pic = (System.Windows.Forms.PictureBox)sender;

				// �� ��Ʈ���� ��´�.
				lbl = (System.Windows.Forms.Label)GetCtrl("Label", Convert.ToInt32(pic.Tag) + 1);
			}
			else // Ŭ���� ��Ʈ���� ���� ���
			{
				lbl = (System.Windows.Forms.Label)sender;
			}


			// ���� �����Ѵ�.
			ImgViewer.frmSelect dlg = new ImgViewer.frmSelect();
			Size sizePic = new Size();

			// ���� ĸ���� �׸��� ��ü ��η� �Ѵ�.
			dlg.Text = "�׸� ���� - " + lblPath.Text + "\\" + lbl.Text;
			// ������ �׸��� picSel�� �����ش�.
			dlg.picSel.Image = System.Drawing.Bitmap.FromFile(lblPath.Text + "\\" + lbl.Text);

			// ���� ũ�⸦ ������ �����Ѵ�.
			sizePic = dlg.picSel.Size;
			sizePic.Height += 30;
			sizePic.Width += 15;

			dlg.Size = sizePic;
			dlg.picSel.Location = new Point(5, 5);

			// ���� ��� ���·� �����ش�.
			dlg.ShowDialog();
		}

		private void Panel2_Resize(object sender, System.EventArgs e)
		{
			MovePicCtrl();
		}

		// ����Ʈ�� ����Ŭ��
		// ����/����̺� ���� ó��
		private void lstDir_DoubleClick(object sender, System.EventArgs e)
		{
			int nSel;
			String strSelText;
			String strTmp;

			// ���õ� �׸��� �ؽ�Ʈ�� �ε����� ��´�.
			nSel = lstDir.SelectedItems[0].Index;
			strSelText = lstDir.SelectedItems[0].SubItems[0].Text;
        
	        m_nSelLabel = -1;
		    picSelect.Image = null;

			if (nSel == 0) // ���� 
			{
				int nStart;

				nStart = lblPath.Text.LastIndexOf("\\");
				if (nStart == -1) 
					return;
            
				strTmp = lblPath.Text.Remove(nStart, lblPath.Text.Length  - nStart) + "\\";
			}
			else if(m_nCnt > nSel) // ����̺� Ŭ��
				strTmp = strSelText + "\\";
			else    
				strTmp = lblPath.Text + "\\" + strSelText + "\\";
        

			// ���� �������� �����ش�.
			if (SetFolder(strTmp)) 
				SetImgFile(strTmp);
			

			// ���� ����
			tipPath.SetToolTip(lblPath, lblPath.Text);
		}

	}
}
