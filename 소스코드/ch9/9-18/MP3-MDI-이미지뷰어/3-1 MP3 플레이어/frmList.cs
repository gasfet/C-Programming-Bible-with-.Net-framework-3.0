using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MyPlayer
{
	/// <summary>
	/// frmList�� ���� ��� �����Դϴ�.
	/// </summary>
	/// 

	public class frmList : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.ListView lvPlayList;
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		
		MyPlayer.frmMain m_frmParent;
		//����Ʈ���� ù��° �������� Ű�������Ͽ� ���������� ��θ� �����Ѵ�.
		System.Collections.Specialized.StringCollection m_colData = new System.Collections.Specialized.StringCollection();
		//�����ϰ� �ִ� ����Ʈ���� ������ �ε���
		int m_nPlayIndex;

		public frmList()
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
				if(components != null)
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
			this.lvPlayList = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// lvPlayList
			// 
			this.lvPlayList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
			this.lvPlayList.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lvPlayList.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(102)), ((System.Byte)(153)), ((System.Byte)(204)));
			this.lvPlayList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lvPlayList.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lvPlayList.FullRowSelect = true;
			this.lvPlayList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvPlayList.Location = new System.Drawing.Point(8, 8);
			this.lvPlayList.MultiSelect = false;
			this.lvPlayList.Name = "lvPlayList";
			this.lvPlayList.Size = new System.Drawing.Size(240, 256);
			this.lvPlayList.TabIndex = 1;
			this.lvPlayList.View = System.Windows.Forms.View.Details;
			this.lvPlayList.DoubleClick += new System.EventHandler(this.lvPlayList_DoubleClick);
			// 
			// frmList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(256, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lvPlayList});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "frmList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Player List";
			this.Resize += new System.EventHandler(this.frmList_Resize);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmList_Closing);
			this.Load += new System.EventHandler(this.frmList_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmList_Load(object sender, System.EventArgs e)
		{
			 //����Ʈ�� �Ӽ�����
			lvPlayList.View = View.Details;
			//��� �÷� ����
			lvPlayList.HeaderStyle = ColumnHeaderStyle.None;

			//�÷� ����-�� �÷��� ����� ���������Ƿ� ���� ������ �ʴ´�.
			//���� �÷��� ���̿� Alignment ���� ����� ���� �� �� �ִ�
			lvPlayList.Columns.Add("Num", 20, HorizontalAlignment.Left);
			lvPlayList.Columns.Add("Title", lvPlayList.Width - 75, HorizontalAlignment.Left);
			lvPlayList.Columns.Add("Time", 50, HorizontalAlignment.Left);

		}

		//�θ��� ����
		public void SetParent(MyPlayer.frmMain frmParent)
		{
			m_frmParent = frmParent;
		}

		//-------------------------------------------------------------------
		//�Լ� : Init
		//���� : None
		//���� : ������ �ʱ�ȭ
		//-------------------------------------------------------------------
		public void Init()
		{
			int nIndex, nCount, nKey;

			nCount = lvPlayList.Items.Count;

			if(nCount > 0)
			{
				//Collection Remove
				for(nIndex = 0 ; nIndex < nCount ; nIndex++)
				{
					nKey = nIndex + 1;
					m_colData.Remove(nKey.ToString());
				}
			}

			//����Ʈ�� ������ ����
			lvPlayList.Items.Clear();

		}

		//-------------------------------------------------------------------
		//�Լ� : AddListItem
		//���� : strTitle    - �������� ����  
		//       strTime     - �������� ����ð�
		//       strPath     - �������� ���
		//���� : ������ �ʱ�ȭ
		//-------------------------------------------------------------------
		public void AddListItem(String strTitle, String strTime, String strPath)
		{
			ListViewItem lvItem = new ListViewItem();
			ListViewItem.ListViewSubItem lvSubItem1 =  new ListViewItem.ListViewSubItem();
			ListViewItem.ListViewSubItem lvSubItem2 =  new ListViewItem.ListViewSubItem();
			int nIndex;

			//����Ʈ�信 ������ ����
			nIndex = lvPlayList.Items.Count + 1;

			//������ ù��° �÷��� �����Ѵ�.
			//(����Ʈ�� �ε����� 0���� ����, ������ 1���� �����ϹǷ� ����Ʈ�� �ε����� + 1�� �� ���� �Է��Ѵ�.)
			lvItem.Text = nIndex.ToString();

			//���� ���ϸ�
			lvSubItem1.Text = strTitle;
			//���� ������ ���ֽð�
			lvSubItem2.Text = strTime;

			lvItem.SubItems.Add(lvSubItem1);
			lvItem.SubItems.Add(lvSubItem2);

			lvPlayList.Items.Add(lvItem);

			//Ű���� ���� ��θ� �����Ѵ�.
			//Value : strPath, Key : nIndex.ToString
			//���� ���� ���� Key ���� ����ؼ� Value�� ��´�.
			m_colData.Add(strPath);

		}

		//-------------------------------------------------------------------
		//�Լ� : ShowWindow
		//���� : None
		//���� : �� ���̱�
		//-------------------------------------------------------------------
		public void ShowWindow()
		{
			this.Location = m_frmParent.m_ptFrmList; 
			Size sz = m_frmParent.m_szForm;
			this.Width = sz.Width;

			this.Show();

		}

		//-------------------------------------------------------------------
		//�Լ� : SetPlayIndex
		//���� : nIndex - ������ ������ ����Ʈ �ε���
		//���� : ������ ���� ����Ʈ�� �ε��� ����
		//-------------------------------------------------------------------
		public void SetPlayIndex(int nIndex)
		{
			m_nPlayIndex = nIndex;
		}


		//-------------------------------------------------------------------
		//�Լ� : GetPlayIndex
		//���� : None
		//���� : �����ϰ� �ִ� ������ ����Ʈ �ε���
		//���� : �����ϰ� �ִ� ���� ����Ʈ�� �ε����� ��´�.
		//-------------------------------------------------------------------
		public int GetPlayIndex()
		{
			return m_nPlayIndex;
		}


		//-------------------------------------------------------------------
		//�Լ� : IsNextItem
		//���� : None
		//���� : ������ ������ ����Ʈ�信 �ִ��� Ȯ�� - true/false
		//���� : ���� ������ ������ ����Ʈ�信 �ִ��� Ȯ��
		//-------------------------------------------------------------------
		public bool IsNextItem()
		{
			if(m_nPlayIndex < (lvPlayList.Items.Count - 1))
				return true;

			return false;
		}

		//-------------------------------------------------------------------
		//�Լ� : GetPlayKey
		//���� : nIndex - ����Ʈ�� �ε���
		//���� : ����Ʈ�� �ε����� Ű���� ��´�.
		//���� : ����Ʈ�� �ε����� Ű���� ��´�.
		//-------------------------------------------------------------------
		public String GetPlayKey(int nIndex)
		{
			int nKey;
			nKey = nIndex + 1;

			return nKey.ToString();
		}


		//-------------------------------------------------------------------
		//�Լ� : GetItemPath
		//���� : strKey - Ű ��
		//���� : Ű���� �´� ��θ� �����Ѵ�.
		//���� : Ű���� ���� ��θ� ��´�.
		//-------------------------------------------------------------------
		public String GetItemPath(int nIndex)
		{
			String strValue;

			if(m_colData.Count <= 0)
				strValue = "";
			else
				strValue = m_colData[nIndex];
	

			return strValue;

		}


		//-------------------------------------------------------------------
		//�Լ� : GetSelectedItem
		//���� : None
		//���� : ���õ� �������� �ε���
		//���� : ���õ� �������� �ε����� ��´�.
		//-------------------------------------------------------------------
		private int GetSelectedItem()
		{
			int nSel;
			nSel = lvPlayList.SelectedItems[0].Index;
			
			return nSel;

		}

		//-------------------------------------------------------------------
		//�Լ� : frmList_Closing
		//���� : sender, e
		//���� : ����ڰ� X(����) ��ư�� ������ ��, ���� �����.
		//-------------------------------------------------------------------
		private void frmList_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		    //Close ��ư�� ������ ��, ���� Hide ��Ų��.
			this.Hide();

			//���� Hide���� frmMain�� ����
			m_frmParent.m_bShowPlayList = false;

			//���� Close�� �ƴ��� �����Ѵ�.
			e.Cancel = true;

		}
		
		
		//-------------------------------------------------------------------
		//�Լ� : lvPlayList_Resize
		//���� : sender, e
		//���� : ����Ʈ���� ũ�Ⱑ ����Ǿ��� ��, �� �÷��� ���̸� �����Ѵ�.
		//-------------------------------------------------------------------
		private void frmList_Resize(object sender, System.EventArgs e)
		{
		     //Load �̺�Ʈ�� �ռ� Resize�̺�Ʈ�� ���� �߻��Ѵ�.
			//�׷��Ƿ� ó�� ���� �ε�� ���� ����Ʈ���� �÷��� �����Ǳ� ���̹Ƿ�
			//�÷��� ���̸� �����ϰ� �Ǹ� ������ �߻��Ѵ�.
			//���� �÷��� ���� �� �÷��� ���� ���θ� �Ǻ��� �Ŀ� �÷��� ���̸� �����Ѵ�.
			if(lvPlayList.Columns.Count > 0)
			{
				lvPlayList.Columns[0].Width = 20;
				lvPlayList.Columns[1].Width = lvPlayList.Width - 75;
				lvPlayList.Columns[2].Width = 50;
			}

		}

		// ����Ŭ���ؼ� ������ �����Ҷ�
		private void lvPlayList_DoubleClick(object sender, System.EventArgs e)
		{
			int nIndex;
			String strSel;

			//���õ� ������ �ε����� ��´�.
			nIndex = GetSelectedItem();

			if(nIndex > 0)
			{
				String strKey;
				String strPath;

				m_nPlayIndex = nIndex;

				//Ű���� ����� �÷��ǿ� ����� ��θ� ��´�.
				strKey = lvPlayList.Items[nIndex].Text;
				strPath = m_colData[nIndex];

				//���õ� �������� �����Ѵ�.
				m_frmParent.PlayMusic(strPath);
			}
		}

	}
}
