using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;

namespace MemberServer
{
	/// <summary>
	/// ZipcodeWnd에 대한 요약 설명입니다.
	/// </summary>
	public class ZipcodeWnd : System.Windows.Forms.Form
	{
        private DataSet ds = null;	
		private string addr = null;

		private System.Windows.Forms.DataGrid dataGrid_Info;
		private System.Windows.Forms.Label lbl_Search;
		private System.Windows.Forms.TextBox txt_Search;
		private System.Windows.Forms.Button btn_Search;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ZipcodeWnd()
		{
			InitializeComponent();

			ds = new DataSet();		

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
			this.dataGrid_Info = new System.Windows.Forms.DataGrid();
			this.lbl_Search = new System.Windows.Forms.Label();
			this.txt_Search = new System.Windows.Forms.TextBox();
			this.btn_Search = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid_Info)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid_Info
			// 
			this.dataGrid_Info.DataMember = "";
			this.dataGrid_Info.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid_Info.Location = new System.Drawing.Point(8, 8);
			this.dataGrid_Info.Name = "dataGrid_Info";
			this.dataGrid_Info.Size = new System.Drawing.Size(464, 152);
			this.dataGrid_Info.TabIndex = 0;
			this.dataGrid_Info.DoubleClick += new System.EventHandler(this.dataGrid_Info_DoubleClick);
			// 
			// lbl_Search
			// 
			this.lbl_Search.Location = new System.Drawing.Point(32, 171);
			this.lbl_Search.Name = "lbl_Search";
			this.lbl_Search.Size = new System.Drawing.Size(160, 16);
			this.lbl_Search.TabIndex = 11;
			this.lbl_Search.Text = "검색할 주소(예: 암사동) :";
			// 
			// txt_Search
			// 
			this.txt_Search.Location = new System.Drawing.Point(200, 168);
			this.txt_Search.Name = "txt_Search";
			this.txt_Search.Size = new System.Drawing.Size(144, 21);
			this.txt_Search.TabIndex = 10;
			this.txt_Search.Text = "";
			// 
			// btn_Search
			// 
			this.btn_Search.Location = new System.Drawing.Point(352, 168);
			this.btn_Search.Name = "btn_Search";
			this.btn_Search.Size = new System.Drawing.Size(120, 24);
			this.btn_Search.TabIndex = 9;
			this.btn_Search.Text = "주소 검색";
			this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
			// 
			// ZipcodeWnd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(480, 197);
			this.Controls.Add(this.lbl_Search);
			this.Controls.Add(this.txt_Search);
			this.Controls.Add(this.btn_Search);
			this.Controls.Add(this.dataGrid_Info);
			this.Name = "ZipcodeWnd";
			this.Text = "우편번호 검색창";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid_Info)).EndInit();
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
		/// 우편번호 데이터 불러오기
		/// </summary>
		private void ZicodeLoad(string sql)
		{
			try
			{	
				string dsn = "server=localhost;database=member;uid=sa;pwd=magic";
				SqlDataAdapter adapter = new SqlDataAdapter(sql, dsn);
				adapter.Fill(ds, "ZipCode");
				this.dataGrid_Info.SetDataBinding(ds, "ZipCode");
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btn_Search_Click(object sender, System.EventArgs e)
		{
			if(txt_Search.Text.Length == 0) 
			{
				MessageBox.Show("검색할 주소를 입력하세요", "에러 메시지");
				return;
			}

			string sql = "select * from zipcode where addr3 like '%";
			sql += txt_Search.Text.Trim() + "%'";

			this.ZicodeLoad(sql);
		}

		private void dataGrid_Info_DoubleClick(object sender, System.EventArgs e)
		{
			int index = dataGrid_Info.CurrentRowIndex;  // 왼쪽 그리드에서 선택한 주소 위치
            
			DataRow dr = ds.Tables[0].Rows[index];        // 데이터셋에서 행값 가져오기

			addr = dr["zipcode"] + "#";
			addr += dr["addr1"] + " " + dr["addr2"] + " " + dr["addr3"] + " ";
			
			if(dr["no_start"].ToString().Length > 0)
			    addr += dr["no_start"] ;
			if(dr["no_end"].ToString().Length > 0)
			     addr += "~" + dr["no_end"]+ " ";
             if(dr["addr4"].ToString().Length > 0 )
				 addr += dr["addr4"];
		
			this.Close();
		}
	}
}
