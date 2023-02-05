using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DataViewExam
{
    public partial class Form1 : Form
    {
        DataTable tbl = null;  // 테이블 

        public Form1()
        {
            InitializeComponent();
        }

        private void MakeTable()
        {
            tbl = new DataTable("grade"); // greade 테이블 생성
            DataColumn column;   // 컬럼 인스턴스 생성

            // 이름 칼럼 만들기
            column = new DataColumn();
            column.DataType = Type.GetType("System.String"); // 데이터형 지정
            column.ColumnName = "Name";  // 칼럼 이름 설정
            column.AllowDBNull = false;  // 널 값 허용 안함
            tbl.Columns.Add(column);     // 테이블에 칼럼 추가

            // 국어 칼럼 만들기
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32"); // 데이터형
            column.ColumnName = "Kor";  // 칼람 이름
            column.AllowDBNull = false;  // 널값 허용 안함
            tbl.Columns.Add(column);  // 테이블에 칼럼 추가

            // 영어 칼럼 만들기
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32"); // 데이터형
            column.ColumnName = "Eng";  // 칼럼 이름
            column.AllowDBNull = false;  // 널값 허용 안함
            tbl.Columns.Add(column);  // 테이블에 칼럼 추가

            // 수학 칼럼 만들기
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32"); // 데이터형
            column.ColumnName = "Math";  // 칼럼 이름
            column.AllowDBNull = false;  // 널값 허용 안함
            tbl.Columns.Add(column);  // 테이블에 칼럼 추가

            // 평균 칼럼 만들기
            column = new DataColumn();
            column.DataType = Type.GetType("System.Double"); // 데이터형
            column.ColumnName = "Avg";  // 칼럼 이름
            column.AllowDBNull = false;  // 널값 허용 안함
            tbl.Columns.Add(column);  // 테이블에 칼럼 추가			
        }

        private void InsertData()
        {
            // 새로운 레코드 추가하기
            DataRow row;
            row = tbl.NewRow();
            row["Name"] = "홍길동";
            row["Kor"] = 65;
            row["Eng"] = 50;
            row["Math"] = 30;
            row["Avg"] = (65 + 50 + 30) / 3.0;
            tbl.Rows.Add(row);

            row = tbl.NewRow();
            row["Name"] = "김동현";
            row["Kor"] = 90;
            row["Eng"] = 75;
            row["Math"] = 60;
            row["Avg"] = (90 + 75 + 60) / 3.0;
            tbl.Rows.Add(row);

            row = tbl.NewRow();
            row["Name"] = "오종석";
            row["Kor"] = 80;
            row["Eng"] = 95;
            row["Math"] = 70;
            row["Avg"] = (80 + 90 + 70) / 3.0;
            tbl.Rows.Add(row);

            row = tbl.NewRow();
            row["Name"] = "최영란";
            row["Kor"] = 100;
            row["Eng"] = 100;
            row["Math"] = 100;
            row["Avg"] = (100 + 100 + 100) / 3.0;
            tbl.Rows.Add(row);

            row = tbl.NewRow();
            row["Name"] = "박진수";
            row["Kor"] = 70;
            row["Eng"] = 90;
            row["Math"] = 60;
            row["Avg"] = (70 + 90 + 60) / 3.0;
            tbl.Rows.Add(row);
        }

        private void btn_EXE_Click(object sender, EventArgs e)
        {
            this.MakeTable();
            this.InsertData();

            DataView view1 = new DataView(this.tbl);
            DataView view2 = new DataView(this.tbl);

            view1.RowFilter = "Kor >= 80";
            view2.RowFilter = "Avg >= 75 And Eng >= 80";

            this.dataGrid_Table.DataSource = this.tbl;
            this.dataGrid_View1.DataSource = view1;
            this.dataGrid_View2.DataSource = view2;     
        }

    }
}