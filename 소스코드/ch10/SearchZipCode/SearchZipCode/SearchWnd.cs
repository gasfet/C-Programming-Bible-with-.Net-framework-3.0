using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Data.OleDb;

namespace SearchZipCode
{
    public partial class SearchWnd : Form
    {

        OleDbConnection conn = null;  // 액세스 파일 연결  

        DataSet addr_ds = null;       // 우편번호 데이터 저장
        DataSet ds = null;

        public SearchWnd()
        {
            InitializeComponent();

            this.addr_ds = new DataSet(); // DataSet 초기화
        }

        /// <summary>
        /// 액세스 파일 연결
        /// </summary>
        /// <param name="dsn">연결 dsn 문자열</param>
        /// <returns>연결 성공 유무</returns>
        private bool Connection(string dsn)
        {
            try
            {
                conn = new OleDbConnection();
                conn.ConnectionString = dsn;
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// addr_ds 데이터셋에 우편번호 저장하기
        /// </summary>
        private void GetZipCode()
        {
            OleDbDataAdapter ole_da = new OleDbDataAdapter();
            ole_da.SelectCommand = new OleDbCommand("select * from zipcode", conn);
            ole_da.Fill(addr_ds);   // 우편번호 채우기
            this.dataGrid_All.DataSource = addr_ds.Tables[0]; // 왼쪽 그리드 창에 값 출력하기			
        }

        /// <summary>
        /// 주소 검색(동이름 기준)
        /// </summary>
        /// <param name="sql">주소 검색</param>
        private void GetSearchData(string sql)
        {
            ds = addr_ds.Clone();  // 데이터 구조 복사한 새로운 DataSet 생성

            DataRow[] dr = addr_ds.Tables[0].Select(sql);  // 데이터 검색 결과

            // ds 데이터셋에 검색 결과 저장하기
            for (int i = 0; i < dr.Length; i++)
            {
                DataRow newrow = ds.Tables[0].NewRow();

                newrow[0] = dr[i][0];
                newrow[1] = dr[i][1];
                newrow[2] = dr[i][2];
                newrow[3] = dr[i][3];
                newrow[4] = dr[i][4];
                newrow[5] = dr[i][5];
                newrow[6] = dr[i][6];
                newrow[7] = dr[i][7];

                ds.Tables[0].Rows.Add(newrow);
            }

            this.dataGrid_Search.DataSource = ds.Tables[0]; // 오른쪽 그리드에 검색 결과 출력

            this.txt_Addr.Text = "검색된 데이터는 총 " + ds.Tables[0].Rows.Count + " 개 입니다.";
        }


      

        private void btn_MDB_Click(object sender, EventArgs e)
        {
            // MDB 파일 위치 지정
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = @"c:\";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_FileLocation.Text = dlg.FileName;
                this.btn_Load.Enabled = true;
                this.btn_Load.Focus();
            }
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            string dsn = this.txt_FileLocation.Text.Trim();
            if (dsn != null)
            {
                dsn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dsn + ";";

                if (!Connection(dsn))  // 데이터베이스 연결 시도
                {
                    MessageBox.Show("데이터베이스 연결 에러");
                }

                GetZipCode();       // 우편번호 메모리 데이터베이스에 출력	

                this.btn_Search.Enabled = true;
                this.txt_Search.Enabled = true;
                this.txt_Search.Focus();

            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string sql = this.txt_Search.Text.Trim();

            if (sql != "")
            {
                sql = "addr3 like '%" + sql + "%'";  // like 쿼리문 생성
                this.GetSearchData(sql);             // 우편번호 검색
            }
            else
            {
                MessageBox.Show("검색할 문자열을 입력하세요", "검색 에러!");
            }	
        }

        private void dataGrid_Search_DoubleClick(object sender, EventArgs e)
        {
            // 특정 주소를 선택하면

            int index = dataGrid_Search.CurrentRowIndex;  // 왼쪽 그리드에서 선택한 주소 위치

            DataRow dr = ds.Tables[0].Rows[index];        // 데이터셋에서 행값 가져오기

            string addr = null;

            for (int i = 1; i < ds.Tables[0].Columns.Count; i++)
            {
                addr = addr + dr[i] + " ";  // 선택한 행의 주소 가져오기
            }

            this.txt_Addr.Text = addr;  // 선택한 주소 출력하기
        }

        private void SearchWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (conn != null) conn.Close();	// 프로그램이 종료할 때 데이터베이스 연결 끊기
            }
            catch (Exception ex)
            {
                MessageBox.Show("에러발생!", ex.Message);
            }
        }

        private void SearchWnd_Load(object sender, EventArgs e)
        {
            // 데이터불러오기, 검색 버튼 비 활성화
            this.btn_Load.Enabled = false;
            this.btn_Search.Enabled = false;
            this.txt_Search.Enabled = false;
        }

       
   
    }
}