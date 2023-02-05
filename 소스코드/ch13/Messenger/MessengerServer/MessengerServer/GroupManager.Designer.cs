namespace MessengerServer
{
    partial class GroupManager
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
            this.cbx_SelectUser = new System.Windows.Forms.ComboBox();
            this.btn_GroupAdd = new System.Windows.Forms.Button();
            this.lbl_GroupName = new System.Windows.Forms.Label();
            this.txt_GroupName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_GroupDelete = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_GroupUpdate = new System.Windows.Forms.Button();
            this.lbl_UserID = new System.Windows.Forms.Label();
            this.dataGrid_GroupInfo = new System.Windows.Forms.DataGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_GroupInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // cbx_SelectUser
            // 
            this.cbx_SelectUser.Location = new System.Drawing.Point(296, 24);
            this.cbx_SelectUser.Name = "cbx_SelectUser";
            this.cbx_SelectUser.Size = new System.Drawing.Size(121, 20);
            this.cbx_SelectUser.TabIndex = 3;
            this.cbx_SelectUser.Text = "사용자 선택";
            // 
            // btn_GroupAdd
            // 
            this.btn_GroupAdd.Location = new System.Drawing.Point(8, 72);
            this.btn_GroupAdd.Name = "btn_GroupAdd";
            this.btn_GroupAdd.Size = new System.Drawing.Size(88, 32);
            this.btn_GroupAdd.TabIndex = 2;
            this.btn_GroupAdd.Text = "그룹 추가";
            this.btn_GroupAdd.Click += new System.EventHandler(this.btn_GroupAdd_Click);
            // 
            // lbl_GroupName
            // 
            this.lbl_GroupName.Location = new System.Drawing.Point(16, 27);
            this.lbl_GroupName.Name = "lbl_GroupName";
            this.lbl_GroupName.Size = new System.Drawing.Size(64, 16);
            this.lbl_GroupName.TabIndex = 1;
            this.lbl_GroupName.Text = "그룹 이름";
            // 
            // txt_GroupName
            // 
            this.txt_GroupName.Location = new System.Drawing.Point(80, 24);
            this.txt_GroupName.Name = "txt_GroupName";
            this.txt_GroupName.Size = new System.Drawing.Size(120, 21);
            this.txt_GroupName.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_GroupDelete);
            this.groupBox1.Controls.Add(this.btn_Close);
            this.groupBox1.Controls.Add(this.btn_GroupUpdate);
            this.groupBox1.Controls.Add(this.lbl_UserID);
            this.groupBox1.Controls.Add(this.cbx_SelectUser);
            this.groupBox1.Controls.Add(this.btn_GroupAdd);
            this.groupBox1.Controls.Add(this.lbl_GroupName);
            this.groupBox1.Controls.Add(this.txt_GroupName);
            this.groupBox1.Location = new System.Drawing.Point(7, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 120);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "그룹 관리";
            // 
            // btn_GroupDelete
            // 
            this.btn_GroupDelete.Location = new System.Drawing.Point(212, 72);
            this.btn_GroupDelete.Name = "btn_GroupDelete";
            this.btn_GroupDelete.Size = new System.Drawing.Size(88, 32);
            this.btn_GroupDelete.TabIndex = 7;
            this.btn_GroupDelete.Text = "그룹 삭제";
            this.btn_GroupDelete.Click += new System.EventHandler(this.btn_GroupDelete_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(312, 72);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(112, 32);
            this.btn_Close.TabIndex = 6;
            this.btn_Close.Text = "그룹 관리창 닫기";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_GroupUpdate
            // 
            this.btn_GroupUpdate.Location = new System.Drawing.Point(104, 72);
            this.btn_GroupUpdate.Name = "btn_GroupUpdate";
            this.btn_GroupUpdate.Size = new System.Drawing.Size(96, 32);
            this.btn_GroupUpdate.TabIndex = 5;
            this.btn_GroupUpdate.Text = "그룹 정보 갱신";
            this.btn_GroupUpdate.Click += new System.EventHandler(this.btn_GroupUpdate_Click);
            // 
            // lbl_UserID
            // 
            this.lbl_UserID.Location = new System.Drawing.Point(232, 29);
            this.lbl_UserID.Name = "lbl_UserID";
            this.lbl_UserID.Size = new System.Drawing.Size(64, 16);
            this.lbl_UserID.TabIndex = 4;
            this.lbl_UserID.Text = "사용자";
            // 
            // dataGrid_GroupInfo
            // 
            this.dataGrid_GroupInfo.DataMember = "";
            this.dataGrid_GroupInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid_GroupInfo.Location = new System.Drawing.Point(7, 9);
            this.dataGrid_GroupInfo.Name = "dataGrid_GroupInfo";
            this.dataGrid_GroupInfo.Size = new System.Drawing.Size(432, 136);
            this.dataGrid_GroupInfo.TabIndex = 2;
            this.dataGrid_GroupInfo.Click += new System.EventHandler(this.dataGrid_GroupInfo_Click);
            // 
            // GroupManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 283);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGrid_GroupInfo);
            this.Name = "GroupManager";
            this.Text = "그룹 관리";
            this.Load += new System.EventHandler(this.GroupManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_GroupInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_SelectUser;
        private System.Windows.Forms.Button btn_GroupAdd;
        private System.Windows.Forms.Label lbl_GroupName;
        private System.Windows.Forms.TextBox txt_GroupName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_GroupDelete;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_GroupUpdate;
        private System.Windows.Forms.Label lbl_UserID;
        private System.Windows.Forms.DataGrid dataGrid_GroupInfo;
    }
}