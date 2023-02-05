namespace WebInfo
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
            this.txt_info = new System.Windows.Forms.TextBox();
            this.btn_check = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_addr = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_info
            // 
            this.txt_info.Location = new System.Drawing.Point(21, 109);
            this.txt_info.Multiline = true;
            this.txt_info.Name = "txt_info";
            this.txt_info.Size = new System.Drawing.Size(229, 229);
            this.txt_info.TabIndex = 7;
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(21, 61);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(229, 28);
            this.btn_check.TabIndex = 6;
            this.btn_check.Text = "검사";
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "검사할 웹 사이트";
            // 
            // txt_addr
            // 
            this.txt_addr.Location = new System.Drawing.Point(21, 34);
            this.txt_addr.Name = "txt_addr";
            this.txt_addr.Size = new System.Drawing.Size(229, 21);
            this.txt_addr.TabIndex = 4;
            this.txt_addr.Text = "www.magicsoft.pe.kr";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 359);
            this.Controls.Add(this.txt_info);
            this.Controls.Add(this.btn_check);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_addr);
            this.Name = "Form1";
            this.Text = "WebInfo 1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_info;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_addr;
    }
}

