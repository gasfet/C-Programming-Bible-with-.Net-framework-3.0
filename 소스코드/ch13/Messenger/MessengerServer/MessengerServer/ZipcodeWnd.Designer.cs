namespace MessengerServer
{
    partial class ZipcodeWnd
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
            this.lbl_Search = new System.Windows.Forms.Label();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.dataGrid_Info = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Info)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Search
            // 
            this.lbl_Search.Location = new System.Drawing.Point(31, 168);
            this.lbl_Search.Name = "lbl_Search";
            this.lbl_Search.Size = new System.Drawing.Size(160, 16);
            this.lbl_Search.TabIndex = 15;
            this.lbl_Search.Text = "검색할 주소(예: 중곡동) :";
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(199, 165);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(144, 21);
            this.txt_Search.TabIndex = 14;
            this.txt_Search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Search_KeyDown);
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(351, 165);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(120, 24);
            this.btn_Search.TabIndex = 13;
            this.btn_Search.Text = "주소 검색";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // dataGrid_Info
            // 
            this.dataGrid_Info.DataMember = "";
            this.dataGrid_Info.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid_Info.Location = new System.Drawing.Point(7, 5);
            this.dataGrid_Info.Name = "dataGrid_Info";
            this.dataGrid_Info.Size = new System.Drawing.Size(464, 152);
            this.dataGrid_Info.TabIndex = 12;
            this.dataGrid_Info.DoubleClick += new System.EventHandler(this.dataGrid_Info_DoubleClick);
            // 
            // ZipcodeWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 195);
            this.Controls.Add(this.lbl_Search);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.dataGrid_Info);
            this.Name = "ZipcodeWnd";
            this.Text = "우편번호 검색창";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Info)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Search;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.DataGrid dataGrid_Info;
    }
}