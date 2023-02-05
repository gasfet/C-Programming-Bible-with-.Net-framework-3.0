namespace WebReader
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_read = new System.Windows.Forms.Button();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("휴먼매직체", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(47, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "웹 페이지 가져오기 ver 1.0";
            // 
            // btn_read
            // 
            this.btn_read.Location = new System.Drawing.Point(311, 299);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(120, 24);
            this.btn_read.TabIndex = 10;
            this.btn_read.Text = "읽어오기";
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(31, 299);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(274, 21);
            this.txt_url.TabIndex = 9;
            this.txt_url.Text = "http://www.yahoo.com/index.html";
            // 
            // txt_result
            // 
            this.txt_result.Location = new System.Drawing.Point(31, 35);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.Size = new System.Drawing.Size(400, 248);
            this.txt_result.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 339);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_read);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(this.txt_result);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.TextBox txt_result;
    }
}

