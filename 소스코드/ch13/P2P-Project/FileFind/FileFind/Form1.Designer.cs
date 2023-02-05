namespace FileFind
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
            this.btn_search = new System.Windows.Forms.Button();
            this.lbl_str = new System.Windows.Forms.Label();
            this.txt_dir = new System.Windows.Forms.TextBox();
            this.txt_filename = new System.Windows.Forms.TextBox();
            this.lstView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(373, 217);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(134, 31);
            this.btn_search.TabIndex = 0;
            this.btn_search.Text = "검색";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // lbl_str
            // 
            this.lbl_str.AutoSize = true;
            this.lbl_str.Location = new System.Drawing.Point(19, 17);
            this.lbl_str.Name = "lbl_str";
            this.lbl_str.Size = new System.Drawing.Size(81, 12);
            this.lbl_str.TabIndex = 1;
            this.lbl_str.Text = "검색할 문자열";
            // 
            // txt_dir
            // 
            this.txt_dir.Location = new System.Drawing.Point(127, 17);
            this.txt_dir.Name = "txt_dir";
            this.txt_dir.Size = new System.Drawing.Size(380, 21);
            this.txt_dir.TabIndex = 2;
            this.txt_dir.Text = "C:\\";
            // 
            // txt_filename
            // 
            this.txt_filename.Location = new System.Drawing.Point(21, 223);
            this.txt_filename.Name = "txt_filename";
            this.txt_filename.Size = new System.Drawing.Size(334, 21);
            this.txt_filename.TabIndex = 4;
            this.txt_filename.Text = "*.*";
            // 
            // lstView
            // 
            this.lstView.Location = new System.Drawing.Point(21, 53);
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(486, 155);
            this.lstView.TabIndex = 5;
            this.lstView.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 266);
            this.Controls.Add(this.lstView);
            this.Controls.Add(this.txt_filename);
            this.Controls.Add(this.txt_dir);
            this.Controls.Add(this.lbl_str);
            this.Controls.Add(this.btn_search);
            this.Name = "Form1";
            this.Text = "파일 검색하기";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label lbl_str;
        private System.Windows.Forms.TextBox txt_dir;
        private System.Windows.Forms.TextBox txt_filename;
        private System.Windows.Forms.ListView lstView;
    }
}

