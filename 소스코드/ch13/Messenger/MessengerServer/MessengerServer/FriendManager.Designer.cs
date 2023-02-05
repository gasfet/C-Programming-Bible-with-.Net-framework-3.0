namespace MessengerServer
{
    partial class FriendManager
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
            this.cbx_GroupName = new System.Windows.Forms.ComboBox();
            this.lbl_Group = new System.Windows.Forms.Label();
            this.txt_GroupID = new System.Windows.Forms.TextBox();
            this.lbl_Friend = new System.Windows.Forms.Label();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.cbx_Friend = new System.Windows.Forms.ComboBox();
            this.btn_FriendModify = new System.Windows.Forms.Button();
            this.btn_FriendRemove = new System.Windows.Forms.Button();
            this.btn_FriendAdd = new System.Windows.Forms.Button();
            this.lbl_UserID = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.txt_UserID = new System.Windows.Forms.TextBox();
            this.dataGrid_Friend = new System.Windows.Forms.DataGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Friend)).BeginInit();
            this.SuspendLayout();
            // 
            // cbx_GroupName
            // 
            this.cbx_GroupName.Location = new System.Drawing.Point(24, 112);
            this.cbx_GroupName.Name = "cbx_GroupName";
            this.cbx_GroupName.Size = new System.Drawing.Size(192, 20);
            this.cbx_GroupName.TabIndex = 6;
            this.cbx_GroupName.Text = "그룹명을 선택하세요!";
            this.cbx_GroupName.SelectedIndexChanged += new System.EventHandler(this.cbx_GroupName_SelectedIndexChanged);
            // 
            // lbl_Group
            // 
            this.lbl_Group.Location = new System.Drawing.Point(16, 88);
            this.lbl_Group.Name = "lbl_Group";
            this.lbl_Group.Size = new System.Drawing.Size(88, 16);
            this.lbl_Group.TabIndex = 5;
            this.lbl_Group.Text = "그룹 아이디";
            // 
            // txt_GroupID
            // 
            this.txt_GroupID.Location = new System.Drawing.Point(104, 84);
            this.txt_GroupID.Name = "txt_GroupID";
            this.txt_GroupID.ReadOnly = true;
            this.txt_GroupID.Size = new System.Drawing.Size(112, 21);
            this.txt_GroupID.TabIndex = 4;
            // 
            // lbl_Friend
            // 
            this.lbl_Friend.Location = new System.Drawing.Point(16, 56);
            this.lbl_Friend.Name = "lbl_Friend";
            this.lbl_Friend.Size = new System.Drawing.Size(88, 16);
            this.lbl_Friend.TabIndex = 3;
            this.lbl_Friend.Text = "친구 아이디";
            // 
            // lbl_ID
            // 
            this.lbl_ID.Location = new System.Drawing.Point(16, 29);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(88, 16);
            this.lbl_ID.TabIndex = 2;
            this.lbl_ID.Text = "사용자 아이디";
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(104, 23);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(112, 21);
            this.txt_ID.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Close);
            this.groupBox1.Controls.Add(this.cbx_Friend);
            this.groupBox1.Controls.Add(this.btn_FriendModify);
            this.groupBox1.Controls.Add(this.btn_FriendRemove);
            this.groupBox1.Controls.Add(this.btn_FriendAdd);
            this.groupBox1.Controls.Add(this.cbx_GroupName);
            this.groupBox1.Controls.Add(this.lbl_Group);
            this.groupBox1.Controls.Add(this.txt_GroupID);
            this.groupBox1.Controls.Add(this.lbl_Friend);
            this.groupBox1.Controls.Add(this.lbl_ID);
            this.groupBox1.Controls.Add(this.txt_ID);
            this.groupBox1.Location = new System.Drawing.Point(7, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 144);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "친구 정보 추가/제거/변경";
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(224, 112);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(160, 24);
            this.btn_Close.TabIndex = 11;
            this.btn_Close.Text = "친구관리 창 닫기";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // cbx_Friend
            // 
            this.cbx_Friend.Location = new System.Drawing.Point(104, 54);
            this.cbx_Friend.Name = "cbx_Friend";
            this.cbx_Friend.Size = new System.Drawing.Size(112, 20);
            this.cbx_Friend.TabIndex = 10;
            this.cbx_Friend.Text = "친구선택";
            // 
            // btn_FriendModify
            // 
            this.btn_FriendModify.Location = new System.Drawing.Point(224, 81);
            this.btn_FriendModify.Name = "btn_FriendModify";
            this.btn_FriendModify.Size = new System.Drawing.Size(160, 24);
            this.btn_FriendModify.TabIndex = 9;
            this.btn_FriendModify.Text = "친구 정보 변경";
            this.btn_FriendModify.Click += new System.EventHandler(this.btn_FriendModify_Click);
            // 
            // btn_FriendRemove
            // 
            this.btn_FriendRemove.Location = new System.Drawing.Point(224, 51);
            this.btn_FriendRemove.Name = "btn_FriendRemove";
            this.btn_FriendRemove.Size = new System.Drawing.Size(160, 24);
            this.btn_FriendRemove.TabIndex = 8;
            this.btn_FriendRemove.Text = "친구 정보 제거";
            this.btn_FriendRemove.Click += new System.EventHandler(this.btn_FriendRemove_Click);
            // 
            // btn_FriendAdd
            // 
            this.btn_FriendAdd.Location = new System.Drawing.Point(224, 21);
            this.btn_FriendAdd.Name = "btn_FriendAdd";
            this.btn_FriendAdd.Size = new System.Drawing.Size(160, 24);
            this.btn_FriendAdd.TabIndex = 7;
            this.btn_FriendAdd.Text = "친구 정보 추가";
            this.btn_FriendAdd.Click += new System.EventHandler(this.btn_FriendAdd_Click);
            // 
            // lbl_UserID
            // 
            this.lbl_UserID.Location = new System.Drawing.Point(7, 169);
            this.lbl_UserID.Name = "lbl_UserID";
            this.lbl_UserID.Size = new System.Drawing.Size(100, 16);
            this.lbl_UserID.TabIndex = 8;
            this.lbl_UserID.Text = "사용자 아이디 :";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(282, 165);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(120, 23);
            this.btn_Search.TabIndex = 7;
            this.btn_Search.Text = "사용자 아이디 검색";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // txt_UserID
            // 
            this.txt_UserID.Location = new System.Drawing.Point(111, 165);
            this.txt_UserID.Name = "txt_UserID";
            this.txt_UserID.Size = new System.Drawing.Size(160, 21);
            this.txt_UserID.TabIndex = 6;
            // 
            // dataGrid_Friend
            // 
            this.dataGrid_Friend.DataMember = "";
            this.dataGrid_Friend.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid_Friend.Location = new System.Drawing.Point(7, 5);
            this.dataGrid_Friend.Name = "dataGrid_Friend";
            this.dataGrid_Friend.Size = new System.Drawing.Size(400, 152);
            this.dataGrid_Friend.TabIndex = 5;
            // 
            // FriendManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 347);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_UserID);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.txt_UserID);
            this.Controls.Add(this.dataGrid_Friend);
            this.Name = "FriendManager";
            this.Text = "친구 관리";
            this.Load += new System.EventHandler(this.FriendManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Friend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_GroupName;
        private System.Windows.Forms.Label lbl_Group;
        private System.Windows.Forms.TextBox txt_GroupID;
        private System.Windows.Forms.Label lbl_Friend;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.ComboBox cbx_Friend;
        private System.Windows.Forms.Button btn_FriendModify;
        private System.Windows.Forms.Button btn_FriendRemove;
        private System.Windows.Forms.Button btn_FriendAdd;
        private System.Windows.Forms.Label lbl_UserID;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox txt_UserID;
        private System.Windows.Forms.DataGrid dataGrid_Friend;
    }
}