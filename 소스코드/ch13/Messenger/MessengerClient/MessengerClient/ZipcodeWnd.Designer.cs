namespace MessengerClient
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
            this.btn_Select = new System.Windows.Forms.Button();
            this.lst_View = new System.Windows.Forms.ListView();
            this.lbl_Search = new System.Windows.Forms.Label();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(391, 185);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(88, 23);
            this.btn_Select.TabIndex = 19;
            this.btn_Select.Text = "주소 선택";
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // lst_View
            // 
            this.lst_View.Location = new System.Drawing.Point(15, 9);
            this.lst_View.Name = "lst_View";
            this.lst_View.Size = new System.Drawing.Size(464, 160);
            this.lst_View.TabIndex = 18;
            this.lst_View.UseCompatibleStateImageBehavior = false;
            // 
            // lbl_Search
            // 
            this.lbl_Search.Location = new System.Drawing.Point(15, 190);
            this.lbl_Search.Name = "lbl_Search";
            this.lbl_Search.Size = new System.Drawing.Size(144, 16);
            this.lbl_Search.TabIndex = 20;
            this.lbl_Search.Text = "검색할 주소(예: 중곡동) :";
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(159, 185);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(136, 21);
            this.txt_Search.TabIndex = 16;
            this.txt_Search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Search_KeyDown);
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(303, 185);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(80, 24);
            this.btn_Search.TabIndex = 17;
            this.btn_Search.Text = "주소 검색";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // ZipcodeWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 219);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.lst_View);
            this.Controls.Add(this.lbl_Search);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.btn_Search);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ZipcodeWnd";
            this.Text = "우편번호 검색창";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.ListView lst_View;
        private System.Windows.Forms.Label lbl_Search;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Button btn_Search;
    }
}