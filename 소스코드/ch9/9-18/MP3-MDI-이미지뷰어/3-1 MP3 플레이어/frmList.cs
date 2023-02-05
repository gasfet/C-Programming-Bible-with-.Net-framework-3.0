using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MyPlayer
{
	/// <summary>
	/// frmList에 대한 요약 설명입니다.
	/// </summary>
	/// 

	public class frmList : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.ListView lvPlayList;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		
		MyPlayer.frmMain m_frmParent;
		//리스트뷰의 첫번째 아이템을 키값으로하여 음악파일의 경로를 저장한다.
		System.Collections.Specialized.StringCollection m_colData = new System.Collections.Specialized.StringCollection();
		//연주하고 있는 리스트뷰의 아이템 인덱스
		int m_nPlayIndex;

		public frmList()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
		}

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
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
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
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
			 //리스트뷰 속성설정
			lvPlayList.View = View.Details;
			//헤더 컬럼 제거
			lvPlayList.HeaderStyle = ColumnHeaderStyle.None;

			//컬럼 설정-이 컬럼은 헤더를 제거했으므로 값이 보이지 않는다.
			//단지 컬럼의 넓이와 Alignment 만이 적용된 것을 볼 수 있다
			lvPlayList.Columns.Add("Num", 20, HorizontalAlignment.Left);
			lvPlayList.Columns.Add("Title", lvPlayList.Width - 75, HorizontalAlignment.Left);
			lvPlayList.Columns.Add("Time", 50, HorizontalAlignment.Left);

		}

		//부모폼 저장
		public void SetParent(MyPlayer.frmMain frmParent)
		{
			m_frmParent = frmParent;
		}

		//-------------------------------------------------------------------
		//함수 : Init
		//인자 : None
		//설명 : 데이터 초기화
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

			//리스트뷰 아이템 삭제
			lvPlayList.Items.Clear();

		}

		//-------------------------------------------------------------------
		//함수 : AddListItem
		//인자 : strTitle    - 음악파일 제목  
		//       strTime     - 음악파일 재생시간
		//       strPath     - 음악파일 경로
		//설명 : 데이터 초기화
		//-------------------------------------------------------------------
		public void AddListItem(String strTitle, String strTime, String strPath)
		{
			ListViewItem lvItem = new ListViewItem();
			ListViewItem.ListViewSubItem lvSubItem1 =  new ListViewItem.ListViewSubItem();
			ListViewItem.ListViewSubItem lvSubItem2 =  new ListViewItem.ListViewSubItem();
			int nIndex;

			//리스트뷰에 아이템 삽입
			nIndex = lvPlayList.Items.Count + 1;

			//순서를 첫번째 컬럼에 삽입한다.
			//(리스트뷰 인덱스는 0부터 시작, 순서는 1부터 시작하므로 리스트뷰 인덱스에 + 1을 한 값을 입력한다.)
			lvItem.Text = nIndex.ToString();

			//음악 파일명
			lvSubItem1.Text = strTitle;
			//음악 파일의 연주시간
			lvSubItem2.Text = strTime;

			lvItem.SubItems.Add(lvSubItem1);
			lvItem.SubItems.Add(lvSubItem2);

			lvPlayList.Items.Add(lvItem);

			//키값에 맞춰 경로를 저장한다.
			//Value : strPath, Key : nIndex.ToString
			//값을 얻을 때는 Key 값을 사용해서 Value를 얻는다.
			m_colData.Add(strPath);

		}

		//-------------------------------------------------------------------
		//함수 : ShowWindow
		//인자 : None
		//설명 : 폼 보이기
		//-------------------------------------------------------------------
		public void ShowWindow()
		{
			this.Location = m_frmParent.m_ptFrmList; 
			Size sz = m_frmParent.m_szForm;
			this.Width = sz.Width;

			this.Show();

		}

		//-------------------------------------------------------------------
		//함수 : SetPlayIndex
		//인자 : nIndex - 연주할 파일의 리스트 인덱스
		//설명 : 연주할 파일 리스트뷰 인덱스 설정
		//-------------------------------------------------------------------
		public void SetPlayIndex(int nIndex)
		{
			m_nPlayIndex = nIndex;
		}


		//-------------------------------------------------------------------
		//함수 : GetPlayIndex
		//인자 : None
		//리턴 : 연주하고 있는 파일의 리스트 인덱스
		//설명 : 연주하고 있는 파일 리스트뷰 인덱스를 얻는다.
		//-------------------------------------------------------------------
		public int GetPlayIndex()
		{
			return m_nPlayIndex;
		}


		//-------------------------------------------------------------------
		//함수 : IsNextItem
		//인자 : None
		//리턴 : 연주할 파일이 리스트뷰에 있는지 확인 - true/false
		//설명 : 다음 연주할 파일이 리스트뷰에 있는지 확인
		//-------------------------------------------------------------------
		public bool IsNextItem()
		{
			if(m_nPlayIndex < (lvPlayList.Items.Count - 1))
				return true;

			return false;
		}

		//-------------------------------------------------------------------
		//함수 : GetPlayKey
		//인자 : nIndex - 리스트뷰 인덱스
		//리턴 : 리스트뷰 인덱스로 키값을 얻는다.
		//설명 : 리스트뷰 인덱스로 키값을 얻는다.
		//-------------------------------------------------------------------
		public String GetPlayKey(int nIndex)
		{
			int nKey;
			nKey = nIndex + 1;

			return nKey.ToString();
		}


		//-------------------------------------------------------------------
		//함수 : GetItemPath
		//인자 : strKey - 키 값
		//리턴 : 키값에 맞는 경로를 리턴한다.
		//설명 : 키값에 대한 경로를 얻는다.
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
		//함수 : GetSelectedItem
		//인자 : None
		//리턴 : 선택된 아이템의 인덱스
		//설명 : 선택된 아이템의 인덱스를 얻는다.
		//-------------------------------------------------------------------
		private int GetSelectedItem()
		{
			int nSel;
			nSel = lvPlayList.SelectedItems[0].Index;
			
			return nSel;

		}

		//-------------------------------------------------------------------
		//함수 : frmList_Closing
		//인자 : sender, e
		//설명 : 사용자가 X(종료) 버튼을 눌렀을 때, 폼을 감춘다.
		//-------------------------------------------------------------------
		private void frmList_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		    //Close 버튼을 눌렀을 때, 폼을 Hide 시킨다.
			this.Hide();

			//폼이 Hide됨을 frmMain에 저장
			m_frmParent.m_bShowPlayList = false;

			//폼의 Close가 아님을 설정한다.
			e.Cancel = true;

		}
		
		
		//-------------------------------------------------------------------
		//함수 : lvPlayList_Resize
		//인자 : sender, e
		//설명 : 리스트뷰의 크기가 변경되었을 때, 각 컬럼의 넓이를 조절한다.
		//-------------------------------------------------------------------
		private void frmList_Resize(object sender, System.EventArgs e)
		{
		     //Load 이벤트에 앞서 Resize이벤트가 먼저 발생한다.
			//그러므로 처음 폼이 로드될 때는 리스트뷰의 컬럼이 생성되기 전이므로
			//컬럼의 넓이를 조절하게 되면 에러를 발생한다.
			//먼저 컬럼의 수를 얻어서 컬럼의 생성 여부를 판별한 후에 컬럼의 넓이를 조절한다.
			if(lvPlayList.Columns.Count > 0)
			{
				lvPlayList.Columns[0].Width = 20;
				lvPlayList.Columns[1].Width = lvPlayList.Width - 75;
				lvPlayList.Columns[2].Width = 50;
			}

		}

		// 더블클리해서 음악을 선택할때
		private void lvPlayList_DoubleClick(object sender, System.EventArgs e)
		{
			int nIndex;
			String strSel;

			//선택된 아이템 인덱스를 얻는다.
			nIndex = GetSelectedItem();

			if(nIndex > 0)
			{
				String strKey;
				String strPath;

				m_nPlayIndex = nIndex;

				//키값을 사용해 컬렉션에 저장된 경로를 얻는다.
				strKey = lvPlayList.Items[nIndex].Text;
				strPath = m_colData[nIndex];

				//선택된 아이템을 연주한다.
				m_frmParent.PlayMusic(strPath);
			}
		}

	}
}
