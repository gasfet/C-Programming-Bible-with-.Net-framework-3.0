using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MDIViewer
{
	/// <summary>
	/// Form1�� ���� ��� �����Դϴ�.
	/// </summary>
	public class frmMDI : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.MainMenu mnuMainMenu;
		internal System.Windows.Forms.MenuItem mnuFile;
		internal System.Windows.Forms.MenuItem mnuOpen;
		internal System.Windows.Forms.MenuItem MenuItem5;
		internal System.Windows.Forms.MenuItem mnuExit;
		internal System.Windows.Forms.MenuItem mnuWindow;
		internal System.Windows.Forms.MenuItem mnuHorizntal;
		internal System.Windows.Forms.MenuItem mnuVertical;
		internal System.Windows.Forms.MenuItem mnuCascade;
		internal System.Windows.Forms.MenuItem mnuIcon;
		internal System.Windows.Forms.Panel panTab;
		internal System.Windows.Forms.TabControl tabCtrl;
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMDI()
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
			this.mnuMainMenu = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuOpen = new System.Windows.Forms.MenuItem();
			this.MenuItem5 = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.mnuWindow = new System.Windows.Forms.MenuItem();
			this.mnuHorizntal = new System.Windows.Forms.MenuItem();
			this.mnuVertical = new System.Windows.Forms.MenuItem();
			this.mnuCascade = new System.Windows.Forms.MenuItem();
			this.mnuIcon = new System.Windows.Forms.MenuItem();
			this.panTab = new System.Windows.Forms.Panel();
			this.tabCtrl = new System.Windows.Forms.TabControl();
			this.panTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMainMenu
			// 
			this.mnuMainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.mnuFile,
																						this.mnuWindow});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuOpen,
																					this.MenuItem5,
																					this.mnuExit});
			this.mnuFile.Text = "����";
			// 
			// mnuOpen
			// 
			this.mnuOpen.Index = 0;
			this.mnuOpen.Text = "����";
			this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
			// 
			// MenuItem5
			// 
			this.MenuItem5.Index = 1;
			this.MenuItem5.Text = "-";
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 2;
			this.mnuExit.Text = "����";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// mnuWindow
			// 
			this.mnuWindow.Index = 1;
			this.mnuWindow.MdiList = true;
			this.mnuWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuHorizntal,
																					  this.mnuVertical,
																					  this.mnuCascade,
																					  this.mnuIcon});
			this.mnuWindow.Text = "â";
			// 
			// mnuHorizntal
			// 
			this.mnuHorizntal.Index = 0;
			this.mnuHorizntal.Text = "����ٵ��ǽ�����";
			this.mnuHorizntal.Click += new System.EventHandler(this.mnuHorizntal_Click);
			// 
			// mnuVertical
			// 
			this.mnuVertical.Index = 1;
			this.mnuVertical.Text = "�����ٵ��ǽ�����";
			this.mnuVertical.Click += new System.EventHandler(this.mnuVertical_Click);
			// 
			// mnuCascade
			// 
			this.mnuCascade.Index = 2;
			this.mnuCascade.Text = "��ܽ�����";
			this.mnuCascade.Click += new System.EventHandler(this.mnuCascade_Click);
			// 
			// mnuIcon
			// 
			this.mnuIcon.Index = 3;
			this.mnuIcon.Text = "����������";
			this.mnuIcon.Click += new System.EventHandler(this.mnuIcon_Click);
			// 
			// panTab
			// 
			this.panTab.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.tabCtrl});
			this.panTab.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panTab.Location = new System.Drawing.Point(0, 377);
			this.panTab.Name = "panTab";
			this.panTab.Size = new System.Drawing.Size(520, 24);
			this.panTab.TabIndex = 2;
			// 
			// tabCtrl
			// 
			this.tabCtrl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabCtrl.Name = "tabCtrl";
			this.tabCtrl.SelectedIndex = 0;
			this.tabCtrl.Size = new System.Drawing.Size(520, 24);
			this.tabCtrl.TabIndex = 0;
			this.tabCtrl.SelectedIndexChanged += new System.EventHandler(this.tabCtrl_SelectedIndexChanged);
			// 
			// frmMDI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(520, 401);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panTab});
			this.IsMdiContainer = true;
			this.Menu = this.mnuMainMenu;
			this.Name = "frmMDI";
			this.Text = "MDIPlayer";
			this.MdiChildActivate += new System.EventHandler(this.frmMDI_MdiChildActivate);
			this.Load += new System.EventHandler(this.frmMDI_Load);
			this.panTab.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �ش� ���� ���α׷��� �� �������Դϴ�.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMDI());
		}


		
		//����� ���� �Լ�
    
    
		// ������ �̸��� ��´�.
		private String GetTitle(String strPath)
		{
			int nLen, nFind;
			String strTitle;

			nLen = strPath.Length;
			nFind = strPath.LastIndexOf("\\");
			strTitle = strPath.Substring(nFind + 2);
			strTitle = strTitle.Substring(1, strTitle.Length - 4);

			return strTitle;

		}


    
		// �̹� �����ִ� �������� Ȯ���Ѵ�.
		private bool IsExitFileName(String strPath)
		{
			bool bExist;

			bExist = false;
			foreach(Form frmTemp in this.MdiChildren)    
			{

				if(frmTemp.Text.Equals(strPath)) 
				{
					bExist = true;
					break;
				}

			}

			return bExist;

		}


    
		// �ڽ� ���� ���� �� ȣ��Ǿ� TabPage�� �����Ѵ�.
		public void RemoveTabItem(String strText)
		{
			int nIndex;
			String strTitle;

			//���� ������ ���� ����� TabPage�� ã�� �����Ѵ�.
			for(nIndex = 0 ; nIndex < tabCtrl.TabPages.Count ; nIndex++)
			{
				strTitle = tabCtrl.TabPages[nIndex].Text;

				if(strText.Equals(strTitle)) 
				{
					tabCtrl.TabPages.RemoveAt(nIndex);
					break;
				}

			}

		}

		/////////////// �̺�Ʈ �Լ� /////////////////////////
		
		// �� �ε�
		private void frmMDI_Load(object sender, System.EventArgs e)
		{
			tabCtrl.Alignment = TabAlignment.Bottom;
		}

		// �ڽ� ���� Ȱ��ȭ/���� �ÿ� ȣ��ȴ�.
		private void frmMDI_MdiChildActivate(object sender, System.EventArgs e)
		{
			//Ȱ��ȭ�� �ڽ� ���� ��´�.
			Form ActiveChild  = this.ActiveMdiChild;
			String strTitle;              //���� Tag ���� ��Ÿ����.
			int nIndex = 0;

			if (ActiveChild != null)
			{            
				if(ActiveChild.Tag != null)
				{
					//���� Tag ���� ��´�.
					strTitle = ActiveChild.Tag.ToString();

					//Tab ����
					String strTemp;
					int nCnt, i;

					nCnt = tabCtrl.TabCount; 

					//����Ʈ�ѿ��� ���� Tag ���� ���� �� Text�� ���� �ִ� ���� ã�� �������ش�.
					for(i=0 ; i<nCnt ; i++)
					{
						strTemp = tabCtrl.TabPages[nIndex].Text;

						if(strTitle.Equals(strTemp))
						{
							tabCtrl.SelectedIndex = nIndex;
							break;
						}

						nIndex += 1;
					}

				}

			}

		}

		// �� ��Ʈ�� ���� ����� ����� ���� Ȱ��ȭ�Ѵ�.
		private void tabCtrl_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//���� ���������� ���ٸ� return
			if(tabCtrl.TabCount <= 0) 
				return;
        

			String strName;
			int nSelected;

			nSelected = tabCtrl.SelectedIndex;

				//���õ� �� TEXT�� ��´�.
				strName = tabCtrl.TabPages[nSelected].Text;

			//�� �������� Text�� ���� ���� ���� �ִ� ���� Tag�� ã�� ���� Ȱ��ȭ�Ѵ�.

			

			foreach(Form frmTemp in this.MdiChildren)    
			{
		
				if(frmTemp.Tag.ToString().Equals(strName))
				{
					frmTemp.Activate();
					break;
				}

			}
		}
		
	
		// ����
		private void mnuOpen_Click(object sender, System.EventArgs e)
		{
		        
			OpenFileDialog OpenFileDlg = new OpenFileDialog();

			//���� ����
			OpenFileDlg.Filter = "Multimedia files (*.mpg;*.avi;*.asf;*.dat;*.mp3)|*.mpg;*.avi;*.asf;*.dat;*.mp3";

			OpenFileDlg.FilterIndex = 0;
			OpenFileDlg.RestoreDirectory = true;
			OpenFileDlg.Multiselect = true;
			OpenFileDlg.Title = "Multimedia Files ����";

			if(OpenFileDlg.ShowDialog() == DialogResult.OK) 
			{
				String strTitle;

				foreach(String strPath in OpenFileDlg.FileNames)    
				{

					System.Windows.Forms.Application.DoEvents();

					//�̹� ������ �����̶�� ���� �������� �ʴ´�. �̴� ���� ���� ����� �� Tag�� ������ ���Ѵ�.
					//��ü ��θ� �����Ͽ� ���ϴ� ����� ���� �� �ִ�. �̶��� ���� Text�� ���� �̸����� ��Ÿ���� Tag�� �̿��Ͽ� ��θ� �����Ѵ�.
					if(IsExitFileName(strPath) == false) 
					{
						strTitle = GetTitle(strPath);    //���ϸ�

						//�ڽ� �� ����
						frmChild frmPlayer = new frmChild();

                     
						frmPlayer.MdiParent = this;                 //�θ� ����
						frmPlayer.mpPlayer.FileName = strPath;    //����� ��� ����
						frmPlayer.Text = strPath;   //���� Ÿ��Ʋ�� 
						frmPlayer.Tag = strTitle;                 //TabPage�� ������ �� ����
						frmPlayer.Show();
                    

						//TabPage ����
						TabPage tabPage = new TabPage();
						tabPage.Text = strTitle;             //���� ������ �� ����

						//TabControl�� �߰�
						tabCtrl.TabPages.Add(tabPage);
					}

				}

			}

			//�ٽ� �׸���
			this.Refresh();


		}

		// ����
		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			//�ڽ� ��
			foreach(Form frmTemp in this.MdiChildren)    
			{
				frmTemp.Dispose();
			}

			//TabPage
			int nIndex;

			//���� ������ ���� ����� TabPage�� ã�� �����Ѵ�.
			for(nIndex = 0 ; nIndex < tabCtrl.TabPages.Count ; nIndex++)
				tabCtrl.TabPages[nIndex].Dispose();


			//TabControl
			tabCtrl.Dispose();

			//�θ� ��
			this.Dispose();
		}

		// ����ٵ��ǽ�
		private void mnuHorizntal_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileHorizontal);

		}

		// �����ٵ��ǽ�
		private void mnuVertical_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileVertical);

		}

		// ��ܽ�
		private void mnuCascade_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}

		// ������ ����
		private void mnuIcon_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.ArrangeIcons);
		}

	}
}
