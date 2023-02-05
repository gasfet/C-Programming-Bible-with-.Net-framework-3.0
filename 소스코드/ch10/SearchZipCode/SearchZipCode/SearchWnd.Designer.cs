namespace SearchZipCode
{
    partial class SearchWnd
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_FileLocation = new System.Windows.Forms.TextBox();
            this.txt_Addr = new System.Windows.Forms.TextBox();
            this.lbl_Addr = new System.Windows.Forms.Label();
            this.btn_MDB = new System.Windows.Forms.Button();
            this.dataGrid_Search = new System.Windows.Forms.DataGrid();
            this.dataGrid_All = new System.Windows.Forms.DataGrid();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_All)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_FileLocation
            // 
            this.txt_FileLocation.Location = new System.Drawing.Point(8, 168);
            this.txt_FileLocation.Name = "txt_FileLocation";
            this.txt_FileLocation.ReadOnly = true;
            this.txt_FileLocation.Size = new System.Drawing.Size(280, 21);
            this.txt_FileLocation.TabIndex = 19;
            this.txt_FileLocation.Text = "MDB 파일 위치를 선택하세요.";
            // 
            // txt_Addr
            // 
            this.txt_Addr.Location = new System.Drawing.Point(304, 248);
            this.txt_Addr.Name = "txt_Addr";
            this.txt_Addr.ReadOnly = true;
            this.txt_Addr.Size = new System.Drawing.Size(280, 21);
            this.txt_Addr.TabIndex = 18;
            this.txt_Addr.Text = "주소를 선택하세요.";
            // 
            // lbl_Addr
            // 
            this.lbl_Addr.Location = new System.Drawing.Point(312, 168);
            this.lbl_Addr.Name = "lbl_Addr";
            this.lbl_Addr.Size = new System.Drawing.Size(100, 23);
            this.lbl_Addr.TabIndex = 17;
            this.lbl_Addr.Text = "검색할 주소 :";
            // 
            // btn_MDB
            // 
            this.btn_MDB.Location = new System.Drawing.Point(24, 196);
            this.btn_MDB.Name = "btn_MDB";
            this.btn_MDB.Size = new System.Drawing.Size(240, 40);
            this.btn_MDB.TabIndex = 16;
            this.btn_MDB.Text = "MDB 파일 지정";
            this.btn_MDB.Click += new System.EventHandler(this.btn_MDB_Click);
            // 
            // dataGrid_Search
            // 
            this.dataGrid_Search.DataMember = "";
            this.dataGrid_Search.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid_Search.Location = new System.Drawing.Point(296, 8);
            this.dataGrid_Search.Name = "dataGrid_Search";
            this.dataGrid_Search.Size = new System.Drawing.Size(296, 152);
            this.dataGrid_Search.TabIndex = 15;
            this.dataGrid_Search.DoubleClick += new System.EventHandler(this.dataGrid_Search_DoubleClick);
            // 
            // dataGrid_All
            // 
            this.dataGrid_All.DataMember = "";
            this.dataGrid_All.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid_All.Location = new System.Drawing.Point(8, 8);
            this.dataGrid_All.Name = "dataGrid_All";
            this.dataGrid_All.Size = new System.Drawing.Size(280, 152);
            this.dataGrid_All.TabIndex = 14;
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(432, 168);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(144, 21);
            this.txt_Search.TabIndex = 13;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(312, 200);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(264, 32);
            this.btn_Search.TabIndex = 12;
            this.btn_Search.Text = "주소 검색";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(24, 236);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(240, 40);
            this.btn_Load.TabIndex = 11;
            this.btn_Load.Text = "데이터불러오기";
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // SearchWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 285);
            this.Controls.Add(this.txt_FileLocation);
            this.Controls.Add(this.txt_Addr);
            this.Controls.Add(this.lbl_Addr);
            this.Controls.Add(this.btn_MDB);
            this.Controls.Add(this.dataGrid_Search);
            this.Controls.Add(this.dataGrid_All);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.btn_Load);
            this.Name = "SearchWnd";
            this.Text = "우편번호 검색";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchWnd_FormClosing);
            this.Load += new System.EventHandler(this.SearchWnd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_All)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_FileLocation;
        private System.Windows.Forms.TextBox txt_Addr;
        private System.Windows.Forms.Label lbl_Addr;
        private System.Windows.Forms.Button btn_MDB;
        private System.Windows.Forms.DataGrid dataGrid_Search;
        private System.Windows.Forms.DataGrid dataGrid_All;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_Load;
    }
}

