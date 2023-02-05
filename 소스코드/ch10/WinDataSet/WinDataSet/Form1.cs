using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WinDataSet
{
    public partial class Form1 : Form
    {
        private DataTable cpu = null;      // CPU 정보 저장
        private DataTable hard = null;     // 하드디스크 정보 저장
        private DataTable graphic = null;  // 그래픽 카드 정보 저장

        private DataTable tbl = null;      // 장바구니 테이블
        private DataSet dataSet = null;    // 제품 정보 DataSet 생성
        private DataSet CartDataSet = null;// 장바구니 DataSet 생성

        // CPU, HardDisk, GraphicCard 정보저장 동적 배열 설정
        private ArrayList CPU, HARD, GRAPHIC;


        public Form1()
        {
            InitializeComponent();

            this.cpu = new DataTable("CPUTable");
            this.hard = new DataTable("HardDiskTable");
            this.graphic = new DataTable("GraphicCardTable");

            // 장바구니 테이블
            tbl = new DataTable("CART");
            // 제품 정보 DataSet 생성
            dataSet = new DataSet();
            // 장바구니 DataSet 생성
            CartDataSet = new DataSet();

            // cpu, hard, graphic 초기화
            CPU = new ArrayList();
            CPU.Add(new Cpu("Intel", "P4 1.8A", "130,000"));
            CPU.Add(new Cpu("AMD", "XP 2500+", "110,000"));
            CPU.Add(new Cpu("Intel", "P4 2.4C", "180,000"));
            CPU.Add(new Cpu("Intel", "P4 2.8E", "220,000"));
            CPU.Add(new Cpu("AMD", "XP 3200+", "250,000"));
            CPU.Add(new Cpu("AMD", "AMD 64 3400+", "570,000"));

            HARD = new ArrayList();
            HARD.Add(new Harddisk("삼성", "180G", "180,000"));
            HARD.Add(new Harddisk("맥스터", "140G", "120,000"));
            HARD.Add(new Harddisk("시게이트", "280G", "287,000"));
            HARD.Add(new Harddisk("웨스터디지털", "160G", "150,000"));

            GRAPHIC = new ArrayList();
            GRAPHIC.Add(new Graphiccard("ATI", "Radeon800X", "347,000"));
            GRAPHIC.Add(new Graphiccard("ATI", "Radeon9800", "117,000"));
            GRAPHIC.Add(new Graphiccard("NVidia", "FX5700", "127,000"));
            GRAPHIC.Add(new Graphiccard("NVidia", "FX6800", "247,000")); 
        }

        private void MakeTable()
        {
            // DataColumn 변수
            DataColumn col = null;

            // CPU 테이블 작성
            //  회사 이름 컬럼 만들기
            col = new DataColumn();
            col.DataType = Type.GetType("System.String");
            col.ColumnName = "company";
            col.ReadOnly = true;
            col.AllowDBNull = false;
            cpu.Columns.Add(col);  // company 칼럼 등록

            // 클럭 속도 컬럼 만들기
            col = new DataColumn();
            col.DataType = Type.GetType("System.String");
            col.ColumnName = "speed";
            cpu.Columns.Add(col);

            // 가격 컬럼 만들기
            col = new DataColumn();
            col.DataType = Type.GetType("System.String");
            col.ColumnName = "price";
            cpu.Columns.Add(col);


            // HARDDISK 테이블 작성
            //  회사 이름 컬럼 만들기
            col = new DataColumn();
            col.DataType = Type.GetType("System.String");
            col.ColumnName = "company";
            col.ReadOnly = true;
            col.AllowDBNull = false;
            hard.Columns.Add(col);  // company 칼럼 등록

            // 하드 디스크 용량 컬럼 만들기
            col = new DataColumn();
            col.DataType = Type.GetType("System.String");
            col.ColumnName = "size";
            hard.Columns.Add(col);

            // 가격 컬럼 만들기
            col = new DataColumn();
            col.DataType = Type.GetType("System.String");
            col.ColumnName = "price";
            hard.Columns.Add(col);

            // Graphic 테이블 작성
            //  회사 이름 컬럼 만들기
            col = new DataColumn();
            col.DataType = Type.GetType("System.String");
            col.ColumnName = "company";
            col.ReadOnly = true;
            col.AllowDBNull = false;
            graphic.Columns.Add(col);  // company 컬럼 등록

            // 그래픽 카드 이름 컬럼 만들기
            col = new DataColumn();
            col.DataType = Type.GetType("System.String");
            col.ColumnName = "name";
            graphic.Columns.Add(col);

            // 가격 컬럼 만들기
            col = new DataColumn();
            col.DataType = Type.GetType("System.String");
            col.ColumnName = "price";
            graphic.Columns.Add(col);

            DataRow newRow = null;

            foreach (Cpu c in CPU)
            {
                newRow = cpu.NewRow();
                newRow["company"] = c.company;
                newRow["speed"] = c.speed;
                newRow["price"] = c.price;
                cpu.Rows.Add(newRow);
            }
            foreach (Harddisk h in HARD)
            {
                newRow = hard.NewRow();
                newRow["company"] = h.company;
                newRow["size"] = h.size;
                newRow["price"] = h.price;
                hard.Rows.Add(newRow);
            }
            foreach (Graphiccard g in GRAPHIC)
            {
                newRow = graphic.NewRow();
                newRow["company"] = g.company;
                newRow["name"] = g.name;
                newRow["price"] = g.price;
                graphic.Rows.Add(newRow);
            }

            // DataGrid에 출력하기
            DG_CPU.DataSource = cpu;
            DG_HARD.DataSource = hard;
            DG_GRAPHIC.DataSource = graphic;

            // DataSet에 테이블 등록
            dataSet.Tables.Add(cpu);
            dataSet.Tables.Add(hard);
            dataSet.Tables.Add(graphic);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MakeTable();
        }

        private void btn_Cart_Click(object sender, EventArgs e)
        {
            DataColumn col;

            // 장바구니 테이블 작성
            //  회사 이름 컬럼 만들기
            col = new DataColumn();
            col.DataType = Type.GetType("System.String");
            col.ColumnName = "company";
            col.ReadOnly = true;
            col.AllowDBNull = false;
            tbl.Columns.Add(col);  // company 컬럼 등록

            // 상품 속성 컬럼 만들기
            col = new DataColumn();
            col.DataType = Type.GetType("System.String");
            col.ColumnName = "name";
            tbl.Columns.Add(col);

            // 상품 가격 컬럼 만들기
            col = new DataColumn();
            col.DataType = Type.GetType("System.String");
            col.ColumnName = "price";
            tbl.Columns.Add(col);

            CartDataSet.Tables.Add(tbl);
            DG_CART.CaptionText = "장바구니 만들어짐..!";
            DG_CART.SetDataBinding(CartDataSet, "CART");
            btn_Cart.Enabled = false; // 장바구니 추가 생성 방지

            DG_CPU.Enabled = true;
            DG_HARD.Enabled = true;
            DG_GRAPHIC.Enabled = true;

            btn_CartXMLSave.Enabled = true;
            btn_CartXMLRead.Enabled = true;
        }

        private void btn_ReadXML_Click(object sender, EventArgs e)
        {
            dataSet.Clear();
            dataSet.Dispose();
            MessageBox.Show("DataSet 초기화중...");
            dataSet = new DataSet();

            dataSet.ReadXml("dataSet.xml");

            MessageBox.Show(" XML 파일을 읽어오고 있습니다!...");

            DG_CPU.SetDataBinding(dataSet, "CPUTable");
            DG_HARD.SetDataBinding(dataSet, "HardDiskTable");
            DG_GRAPHIC.SetDataBinding(dataSet, "GraphicCardTable");

        }

        private void btn_SaveXML_Click(object sender, EventArgs e)
        {
            dataSet.WriteXml("dataSet.xml");
            MessageBox.Show("dataSet.XML 파일을 생성했습니다.!");

        }

        private void btn_CartXMLRead_Click(object sender, EventArgs e)
        {
            CartDataSet.Clear();
            CartDataSet.Dispose();
            MessageBox.Show("CartDataSet 초기화중...");
            CartDataSet = new DataSet();

            CartDataSet.ReadXml("Cart.xml");

            MessageBox.Show(" XML 파일을 읽어오고 있습니다!...");
            btn_CartXMLRead.Enabled = false;

            // 장바구니에 출력하기
            DG_CART.SetDataBinding(CartDataSet, "CART");
        }

        private void btn_CartXMLSave_Click(object sender, EventArgs e)
        {
            CartDataSet.WriteXml("Cart.xml");
            MessageBox.Show("Cart.XML 파일을 생성했습니다.!");
            btn_CartXMLRead.Enabled = true;

        }

        // Cpu 정보 처리 클래스 
        public class Cpu
        {
            public string company, speed, price;
            public Cpu(string company, string speed, string price)
            {
                this.company = company;  // CPU 제작 회사
                this.speed = speed;   // CPU 클럭 속도
                this.price = price; // CPU 가격

            }
        }

        // Graphiccard 정보 처리 클래스 
        public class Graphiccard
        {
            public string company, name, price;
            public Graphiccard(string company, string name, string price)
            {
                this.company = company;  // 그래픽 카드 제조사
                this.name = name;   // 그래픽 카드 이름
                this.price = price;  // 그래픽 카드 가격
            }
        }

        // Harddisk 정보 처리 클래스
        public class Harddisk
        {
            public string company, size, price;
            public Harddisk(string company, string size, string price)
            {
                this.company = company;  // 하드디스크 제조 회사
                this.size = size; // 하드디스크 용량
                this.price = price; // 하드디스크 가격
            }
        }

        private void DG_CPU_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = CartDataSet.Tables["CART"].NewRow();
            object[] info = dataSet.Tables["CPUTable"].Rows[DG_CPU.CurrentCell.RowNumber].ItemArray;
            row["company"] = info[0].ToString();  // 상품 회사 등록
            row["name"] = info[1].ToString();
            row["price"] = info[2].ToString();

            CartDataSet.Tables["CART"].Rows.Add(row);
            DG_CART.SetDataBinding(CartDataSet, "CART");
        }

        private void DG_GRAPHIC_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = CartDataSet.Tables["CART"].NewRow();
            object[] info = dataSet.Tables["GraphicCardTable"].Rows[DG_GRAPHIC.CurrentCell.RowNumber].ItemArray;
            row["company"] = info[0].ToString();  // 상품 회사 등록
            row["name"] = info[1].ToString();
            row["price"] = info[2].ToString();

            CartDataSet.Tables["CART"].Rows.Add(row);
            DG_CART.SetDataBinding(CartDataSet, "CART");

        }

        private void DG_HARD_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = CartDataSet.Tables["CART"].NewRow();
            object[] info = dataSet.Tables["HardDiskTable"].Rows[DG_HARD.CurrentCell.RowNumber].ItemArray;
            row["company"] = info[0].ToString();  // 상품 회사 등록
            row["name"] = info[1].ToString();
            row["price"] = info[2].ToString();

            CartDataSet.Tables["CART"].Rows.Add(row);
            DG_CART.SetDataBinding(CartDataSet, "CART");			

        }

   
    }
}