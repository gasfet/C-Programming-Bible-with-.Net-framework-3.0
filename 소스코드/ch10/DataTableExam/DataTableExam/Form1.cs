using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DataTableExam
{
    public partial class Form1 : Form
    {
        private DataTable tbl = null;  

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_DataTable_Click(object sender, EventArgs e)
        {
            tbl = new DataTable("classinfo"); // classInfo 테이블 생성
            DataColumn column;   // 컬럼 인스턴스 생성

            // 학번 컬럼 만들기
            column = new DataColumn();
            column.DataType = Type.GetType("System.String"); // 데이터형 지정
            column.ColumnName = "Name";  // 칼럼 이름 설정
            column.AllowDBNull = false;  // 널 값 허용 안함
            tbl.Columns.Add(column);     // 테이블에 칼럼 추가

            // 국어 컬럼 만들기
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32"); // 데이터형
            column.ColumnName = "Kor";  // 컬럼 이름
            column.AllowDBNull = false;  // 널값 허용 안함
            tbl.Columns.Add(column);  // 테이블에 컬럼 추가

            // 영어 컬럼 만들기
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32"); // 데이터형
            column.ColumnName = "Eng";  // 컬럼 이름
            column.AllowDBNull = false;  // 널값 허용 안함
            tbl.Columns.Add(column);  // 테이블에 컬럼 추가

            // 수학 컬럼 만들기
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32"); // 데이터형
            column.ColumnName = "Math";  // 컬럼 이름
            column.AllowDBNull = false;  // 널값 허용 안함
            tbl.Columns.Add(column);  // 테이블에 컬럼 추가

            // 평균 컬럼 만들기
            column = new DataColumn();
            column.DataType = Type.GetType("System.Double"); // 데이터형
            column.ColumnName = "Avg";  // 컬럼 이름
            column.AllowDBNull = false;  // 널값 허용 안함
            tbl.Columns.Add(column);  // 테이블에 컬럼 추가

            //학번 컬럼을 기본 키 설정
            DataColumn[] pk = new DataColumn[1];
            pk[0] = tbl.Columns["No"];
            tbl.PrimaryKey = pk;

            // 새로운 레코드 추가하기
            DataRow row;
            row = tbl.NewRow();  // 200501 번 데이터
            row["Name"] = "홍길동";
            row["Kor"] = 90;
            row["Eng"] = 83;
            row["Math"] = 81;
            row["Avg"] = (90 + 83 + 81) / 3.0;
            tbl.Rows.Add(row);

            row = tbl.NewRow();  // 200502 번 데이터
            row["Name"] = "김동현";
            row["Kor"] = 95;
            row["Eng"] = 81;
            row["Math"] = 90;
            row["Avg"] = (95 + 81 + 90) / 3.0;
            tbl.Rows.Add(row);

            row = tbl.NewRow();  // 200503 번 데이터
            row["Name"] = "오종석";
            row["Kor"] = 80;
            row["Eng"] = 90;
            row["Math"] = 75;
            row["Avg"] = (80 + 90 + 75) / 3.0;
            tbl.Rows.Add(row);

            data_Grid.DataSource = tbl;  // 데이터 그리드 화면 출력
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string name = txt_Name.Text.Trim();
            string kor = txt_Kor.Text.Trim();
            string eng = txt_Eng.Text.Trim();
            string math = txt_Math.Text.Trim();

            if (name != "" && kor != "" && eng != "" && math != "")
            {
                try
                {
                    int kk = Convert.ToInt32(kor);
                    int ee = Convert.ToInt32(eng);
                    int mm = Convert.ToInt32(math);

                    DataRow row = tbl.NewRow();
                    row["Name"] = name;
                    row["Kor"] = kk;
                    row["Eng"] = ee;
                    row["Math"] = mm;
                    row["Avg"] = (kk + ee + mm) / 3;
                    tbl.Rows.Add(row);
                }
                catch
                {
                    MessageBox.Show(" 국/영/수 성적이 잘못 입력되었습니다!");
                }
            }
            else
            {
                MessageBox.Show("이름, 국/영/수 성적을 입력하세요!");
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                int index = this.data_Grid.CurrentRowIndex;

                int kor = Convert.ToInt32(this.txt_Kor.Text.Trim());
                int eng = Convert.ToInt32(this.txt_Eng.Text.Trim());
                int math = Convert.ToInt32(this.txt_Math.Text.Trim());

                DataRow row = this.tbl.Rows[index];
                row.BeginEdit();
                row["Name"] = this.txt_Name.Text.Trim();
                row["Kor"] = kor;
                row["Eng"] = eng;
                row["Math"] = math;
                row["Avg"] = (kor + eng + math) / 3.0;
                row.EndEdit();
            }
            catch
            {
                MessageBox.Show("데이터그리드에서 편집할 레코드를 선택하세요!");
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = this.data_Grid.CurrentRowIndex;

                DataRow row = this.tbl.Rows[index];
                row.Delete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("에러 발생 : " + ex.Message);
            }
        }

        private void btn_Delete_All_Click(object sender, EventArgs e)
        {
            try
            {
                tbl.Rows.Clear();   // 전체 레코드 삭제
            }
            catch (Exception ex)
            {
                MessageBox.Show("에러 메시지 : " + ex.Message);
            }
        }

        private void data_Grid_Click(object sender, EventArgs e)
        {
            try
            {
                int index = this.data_Grid.CurrentRowIndex;
                DataRow row = this.tbl.Rows[index];
                this.txt_Name.Text = row["Name"].ToString();
                this.txt_Kor.Text = row["Kor"].ToString();
                this.txt_Eng.Text = row["Eng"].ToString();
                this.txt_Math.Text = row["Math"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("에러 발생 : " + ex.Message);
            }

        }
    }
}