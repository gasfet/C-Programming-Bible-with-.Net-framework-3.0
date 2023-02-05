using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MemberReg
{
	/// <summary>
	/// ZipcodeWnd에 대한 요약 설명입니다.
	/// </summary>
	public class ZipcodeWnd : System.Windows.Forms.Form
	{
		private string addr = null;      // 주소 저장 변수
		private string server_ip = null; // 서버 아이피
		private RegNetwork net = null; 

		private System.Windows.Forms.Label lbl_Search;
		private System.Windows.Forms.TextBox txt_Search;
		private System.Windows.Forms.Button btn_Search;
		private System.Windows.Forms.ListView lst_View;
		private System.Windows.Forms.Button btn_Select;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ZipcodeWnd(RegNetwork net, string server_ip)
		{
			InitializeComponent();

			this.net = net; 
			this.server_ip = server_ip;
			this.Init_listView();
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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.lbl_Search = new System.Windows.Forms.Label();
			this.txt_Search = new System.Windows.Forms.TextBox();
			this.btn_Search = new System.Windows.Forms.Button();
			this.lst_View = new System.Windows.Forms.ListView();
			this.btn_Select = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbl_Search
			// 
			this.lbl_Search.Location = new System.Drawing.Point(16, 185);
			this.lbl_Search.Name = "lbl_Search";
			this.lbl_Search.Size = new System.Drawing.Size(144, 16);
			this.lbl_Search.TabIndex = 15;
			this.lbl_Search.Text = "검색할 주소(예: 암사동) :";
			// 
			// txt_Search
			// 
			this.txt_Search.Location = new System.Drawing.Point(160, 184);
			this.txt_Search.Name = "txt_Search";
			this.txt_Search.Size = new System.Drawing.Size(136, 21);
			this.txt_Search.TabIndex = 0;
			this.txt_Search.Text = "";
			this.txt_Search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Search_KeyDown);
			// 
			// btn_Search
			// 
			this.btn_Search.Location = new System.Drawing.Point(304, 184);
			this.btn_Search.Name = "btn_Search";
			this.btn_Search.Size = new System.Drawing.Size(80, 24);
			this.btn_Search.TabIndex = 1;
			this.btn_Search.Text = "주소 검색";
			this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
			// 
			// lst_View
			// 
			this.lst_View.Location = new System.Drawing.Point(16, 8);
			this.lst_View.Name = "lst_View";
			this.lst_View.Size = new System.Drawing.Size(464, 160);
			this.lst_View.TabIndex = 2;
			// 
			// btn_Select
			// 
			this.btn_Select.Location = new System.Drawing.Point(392, 184);
			this.btn_Select.Name = "btn_Select";
			this.btn_Select.Size = new System.Drawing.Size(88, 23);
			this.btn_Select.TabIndex = 3;
			this.btn_Select.Text = "주소 선택";
			this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
			// 
			// ZipcodeWnd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(496, 221);
			this.Controls.Add(this.btn_Select);
			this.Controls.Add(this.lst_View);
			this.Controls.Add(this.lbl_Search);
			this.Controls.Add(this.txt_Search);
			this.Controls.Add(this.btn_Search);
			this.Name = "ZipcodeWnd";
			this.Text = "우편번호 검색창";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 우편번호 주소 반환
		/// </summary>
		public string Addr
		{
			get
			{
				return addr;
			}
		}

		/// <summary>
		/// ListView 초기화 메서드
		/// </summary>
		private void Init_listView() 
		{
			lst_View.Clear();                         // 초기화 
			lst_View.View = View.Details;             // View옵션을 Details로 설정
			lst_View.LabelEdit = false;               // 편집 기능 비활성화
			lst_View.CheckBoxes = true;               // 체크 박스 기능 활성화						
			lst_View.GridLines = true;                // 윤곽선 설정   
			lst_View.Sorting = SortOrder.Ascending;   // 오름차순 정렬
			// 접속 아이디 헤더 만들기
			lst_View.Columns.Add("우편 주소", 90, HorizontalAlignment.Center);
			// 접속 시간 헤더 만들기
			lst_View.Columns.Add("상세 주소", 370, HorizontalAlignment.Left);			
		}	

		/// <summary>
		/// 리스트뷰에 목록 추가
		/// </summary>
		/// <param name="zipcode">우편번호</param>
		/// <param name="addr">상세주소</param>
		private void Add_listView(string zipcode, string addr)
		{
			ListViewItem item = new ListViewItem(zipcode);			
			item.SubItems.Add(addr);  // 접속한 시간 정보
			this.lst_View.Items.Add(item);
		}

		/// <summary>
		/// 우편번호 데이터 분석
		/// </summary>
		/// <param name="data">우편번호#주소#우편번호#주소...</param>
		public void ZipdataInput(string data)
		{
		   this.Init_listView();

           string [] token = data.Split('#'); // 짝수번째 우편번호, 홀수번째 주소
          
			for(int i = 0 ; i < token.Length - 1 ; i += 2)
			{
				this.Add_listView(token[i], token[i+1]);
			}
		}

		private void btn_Search_Click(object sender, System.EventArgs e)
		{
			if(txt_Search.Text.Length == 0) 
			{
				MessageBox.Show("검색할 주소를 입력하세요", "에러 메시지");
				return;
			}

			string msg = "CTOS_MESSAGE_REGISTER_ZIPCODE\a" + txt_Search.Text.Trim();
			
			this.net.Connect(this.server_ip);
			this.net.Send(msg);
		}

		

		private void btn_Select_Click(object sender, System.EventArgs e)
		{
            int count = 0;
			foreach(ListViewItem item in lst_View.Items)
			{
				if(item.Checked)
				{
					int index = lst_View.Items.IndexOf(item);
					this.addr += lst_View.Items[index].SubItems[0].Text.Trim() + "#";
					this.addr += lst_View.Items[index].SubItems[1].Text.Trim() + "#";			       
					count++;
				}				
			}

			if(count > 1 )
			{
				MessageBox.Show("우편번호는 하나만 선택해야 합니다.!");
				return ;
			}
			if( count == 0 )
			{
				MessageBox.Show("우편번호를 선택하세요.!");
				return ;
			}

			this.Close();
		}

		private void txt_Search_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			// 엔터키가 눌리면 문자열 메시지 전송
			if( e.KeyCode == Keys.Enter )
			{
				if(txt_Search.Text.Length == 0) 
				{
					MessageBox.Show("검색할 주소를 입력하세요", "에러 메시지");
					return;
				}

				string msg = "CTOS_MESSAGE_REGISTER_ZIPCODE\a" + txt_Search.Text.Trim();
			
				this.net.Connect(this.server_ip);
				this.net.Send(msg);
			}
		}
		
	}
}
