namespace DataTableExam
{
    partial class Form1
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
            this.lbl_Math = new System.Windows.Forms.Label();
            this.txt_Math = new System.Windows.Forms.TextBox();
            this.lbl_Eng = new System.Windows.Forms.Label();
            this.txt_Eng = new System.Windows.Forms.TextBox();
            this.lbl_Kor = new System.Windows.Forms.Label();
            this.txt_Kor = new System.Windows.Forms.TextBox();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.btn_Delete_All = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.data_Grid = new System.Windows.Forms.DataGrid();
            this.btn_DataTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Math
            // 
            this.lbl_Math.Location = new System.Drawing.Point(388, 253);
            this.lbl_Math.Name = "lbl_Math";
            this.lbl_Math.Size = new System.Drawing.Size(40, 16);
            this.lbl_Math.TabIndex = 27;
            this.lbl_Math.Text = "수학:";
            // 
            // txt_Math
            // 
            this.txt_Math.Location = new System.Drawing.Point(435, 249);
            this.txt_Math.Name = "txt_Math";
            this.txt_Math.Size = new System.Drawing.Size(48, 21);
            this.txt_Math.TabIndex = 26;
            // 
            // lbl_Eng
            // 
            this.lbl_Eng.Location = new System.Drawing.Point(282, 253);
            this.lbl_Eng.Name = "lbl_Eng";
            this.lbl_Eng.Size = new System.Drawing.Size(40, 16);
            this.lbl_Eng.TabIndex = 25;
            this.lbl_Eng.Text = "영어:";
            // 
            // txt_Eng
            // 
            this.txt_Eng.Location = new System.Drawing.Point(324, 249);
            this.txt_Eng.Name = "txt_Eng";
            this.txt_Eng.Size = new System.Drawing.Size(48, 21);
            this.txt_Eng.TabIndex = 24;
            // 
            // lbl_Kor
            // 
            this.lbl_Kor.Location = new System.Drawing.Point(172, 251);
            this.lbl_Kor.Name = "lbl_Kor";
            this.lbl_Kor.Size = new System.Drawing.Size(40, 16);
            this.lbl_Kor.TabIndex = 23;
            this.lbl_Kor.Text = "국어:";
            // 
            // txt_Kor
            // 
            this.txt_Kor.Location = new System.Drawing.Point(214, 248);
            this.txt_Kor.Name = "txt_Kor";
            this.txt_Kor.Size = new System.Drawing.Size(48, 21);
            this.txt_Kor.TabIndex = 22;
            // 
            // lbl_Name
            // 
            this.lbl_Name.Location = new System.Drawing.Point(12, 249);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(48, 16);
            this.lbl_Name.TabIndex = 21;
            this.lbl_Name.Text = "이름";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(60, 246);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(104, 21);
            this.txt_Name.TabIndex = 20;
            // 
            // btn_Delete_All
            // 
            this.btn_Delete_All.Location = new System.Drawing.Point(404, 17);
            this.btn_Delete_All.Name = "btn_Delete_All";
            this.btn_Delete_All.Size = new System.Drawing.Size(112, 23);
            this.btn_Delete_All.TabIndex = 19;
            this.btn_Delete_All.Text = "전체 데이터 삭제";
            this.btn_Delete_All.Click += new System.EventHandler(this.btn_Delete_All_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(308, 17);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(96, 23);
            this.btn_Delete.TabIndex = 18;
            this.btn_Delete.Text = "데이터 삭제";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Location = new System.Drawing.Point(212, 17);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(96, 23);
            this.btn_Edit.TabIndex = 17;
            this.btn_Edit.Text = "데이터 편집";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(116, 17);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(96, 23);
            this.btn_Add.TabIndex = 16;
            this.btn_Add.Text = "데이터 추가";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // data_Grid
            // 
            this.data_Grid.DataMember = "";
            this.data_Grid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.data_Grid.Location = new System.Drawing.Point(20, 57);
            this.data_Grid.Name = "data_Grid";
            this.data_Grid.Size = new System.Drawing.Size(488, 168);
            this.data_Grid.TabIndex = 15;
            this.data_Grid.Click += new System.EventHandler(this.data_Grid_Click);
            // 
            // btn_DataTable
            // 
            this.btn_DataTable.Location = new System.Drawing.Point(20, 17);
            this.btn_DataTable.Name = "btn_DataTable";
            this.btn_DataTable.Size = new System.Drawing.Size(88, 23);
            this.btn_DataTable.TabIndex = 14;
            this.btn_DataTable.Text = "테이블 생성";
            this.btn_DataTable.Click += new System.EventHandler(this.btn_DataTable_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 286);
            this.Controls.Add(this.lbl_Math);
            this.Controls.Add(this.txt_Math);
            this.Controls.Add(this.lbl_Eng);
            this.Controls.Add(this.txt_Eng);
            this.Controls.Add(this.lbl_Kor);
            this.Controls.Add(this.txt_Kor);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.btn_Delete_All);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.data_Grid);
            this.Controls.Add(this.btn_DataTable);
            this.Name = "Form1";
            this.Text = "DataTable 생성 예제";
            ((System.ComponentModel.ISupportInitialize)(this.data_Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Math;
        private System.Windows.Forms.TextBox txt_Math;
        private System.Windows.Forms.Label lbl_Eng;
        private System.Windows.Forms.TextBox txt_Eng;
        private System.Windows.Forms.Label lbl_Kor;
        private System.Windows.Forms.TextBox txt_Kor;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Button btn_Delete_All;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGrid data_Grid;
        private System.Windows.Forms.Button btn_DataTable;
    }
}

