namespace RTFExample
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
            this.btn_Write = new System.Windows.Forms.Button();
            this.btn_Read = new System.Windows.Forms.Button();
            this.rtb_Print = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_Write
            // 
            this.btn_Write.Location = new System.Drawing.Point(162, 222);
            this.btn_Write.Name = "btn_Write";
            this.btn_Write.Size = new System.Drawing.Size(75, 23);
            this.btn_Write.TabIndex = 5;
            this.btn_Write.Text = "RTF쓰기";
            this.btn_Write.Click += new System.EventHandler(this.btn_Write_Click);
            // 
            // btn_Read
            // 
            this.btn_Read.Location = new System.Drawing.Point(42, 222);
            this.btn_Read.Name = "btn_Read";
            this.btn_Read.Size = new System.Drawing.Size(75, 23);
            this.btn_Read.TabIndex = 4;
            this.btn_Read.Text = "RTF읽기";
            this.btn_Read.Click += new System.EventHandler(this.btn_Read_Click);
            // 
            // rtb_Print
            // 
            this.rtb_Print.Location = new System.Drawing.Point(18, 22);
            this.rtb_Print.Name = "rtb_Print";
            this.rtb_Print.Size = new System.Drawing.Size(256, 176);
            this.rtb_Print.TabIndex = 3;
            this.rtb_Print.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.btn_Write);
            this.Controls.Add(this.btn_Read);
            this.Controls.Add(this.rtb_Print);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Write;
        private System.Windows.Forms.Button btn_Read;
        private System.Windows.Forms.RichTextBox rtb_Print;
    }
}

