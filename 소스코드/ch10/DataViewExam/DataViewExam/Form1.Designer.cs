namespace DataViewExam
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
            this.lbl_View2 = new System.Windows.Forms.Label();
            this.lbl_View1 = new System.Windows.Forms.Label();
            this.lbl_Table = new System.Windows.Forms.Label();
            this.btn_EXE = new System.Windows.Forms.Button();
            this.dataGrid_View2 = new System.Windows.Forms.DataGrid();
            this.dataGrid_View1 = new System.Windows.Forms.DataGrid();
            this.dataGrid_Table = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_View2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_View1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Table)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_View2
            // 
            this.lbl_View2.Location = new System.Drawing.Point(16, 235);
            this.lbl_View2.Name = "lbl_View2";
            this.lbl_View2.Size = new System.Drawing.Size(64, 32);
            this.lbl_View2.TabIndex = 14;
            this.lbl_View2.Text = "두번째 View";
            // 
            // lbl_View1
            // 
            this.lbl_View1.Location = new System.Drawing.Point(16, 131);
            this.lbl_View1.Name = "lbl_View1";
            this.lbl_View1.Size = new System.Drawing.Size(64, 32);
            this.lbl_View1.TabIndex = 13;
            this.lbl_View1.Text = "첫번째 View";
            // 
            // lbl_Table
            // 
            this.lbl_Table.Location = new System.Drawing.Point(16, 27);
            this.lbl_Table.Name = "lbl_Table";
            this.lbl_Table.Size = new System.Drawing.Size(64, 32);
            this.lbl_Table.TabIndex = 12;
            this.lbl_Table.Text = "DataTable 정보";
            // 
            // btn_EXE
            // 
            this.btn_EXE.Location = new System.Drawing.Point(8, 67);
            this.btn_EXE.Name = "btn_EXE";
            this.btn_EXE.Size = new System.Drawing.Size(75, 48);
            this.btn_EXE.TabIndex = 11;
            this.btn_EXE.Text = "실행";
            this.btn_EXE.Click += new System.EventHandler(this.btn_EXE_Click);
            // 
            // dataGrid_View2
            // 
            this.dataGrid_View2.DataMember = "";
            this.dataGrid_View2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid_View2.Location = new System.Drawing.Point(96, 227);
            this.dataGrid_View2.Name = "dataGrid_View2";
            this.dataGrid_View2.Size = new System.Drawing.Size(304, 96);
            this.dataGrid_View2.TabIndex = 10;
            // 
            // dataGrid_View1
            // 
            this.dataGrid_View1.DataMember = "";
            this.dataGrid_View1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid_View1.Location = new System.Drawing.Point(96, 123);
            this.dataGrid_View1.Name = "dataGrid_View1";
            this.dataGrid_View1.Size = new System.Drawing.Size(304, 96);
            this.dataGrid_View1.TabIndex = 9;
            // 
            // dataGrid_Table
            // 
            this.dataGrid_Table.DataMember = "";
            this.dataGrid_Table.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid_Table.Location = new System.Drawing.Point(96, 19);
            this.dataGrid_Table.Name = "dataGrid_Table";
            this.dataGrid_Table.Size = new System.Drawing.Size(304, 96);
            this.dataGrid_Table.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 342);
            this.Controls.Add(this.lbl_View2);
            this.Controls.Add(this.lbl_View1);
            this.Controls.Add(this.lbl_Table);
            this.Controls.Add(this.btn_EXE);
            this.Controls.Add(this.dataGrid_View2);
            this.Controls.Add(this.dataGrid_View1);
            this.Controls.Add(this.dataGrid_Table);
            this.Name = "Form1";
            this.Text = "DataView 예제";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_View2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_View1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_View2;
        private System.Windows.Forms.Label lbl_View1;
        private System.Windows.Forms.Label lbl_Table;
        private System.Windows.Forms.Button btn_EXE;
        private System.Windows.Forms.DataGrid dataGrid_View2;
        private System.Windows.Forms.DataGrid dataGrid_View1;
        private System.Windows.Forms.DataGrid dataGrid_Table;
    }
}

