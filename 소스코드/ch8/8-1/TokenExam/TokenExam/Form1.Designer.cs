namespace TokenExam
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
            this.btn_Start = new System.Windows.Forms.Button();
            this.txt_Info = new System.Windows.Forms.TextBox();
            this.txt_MSG = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(9, 228);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(271, 33);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "분석";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // txt_Info
            // 
            this.txt_Info.Location = new System.Drawing.Point(9, 9);
            this.txt_Info.Multiline = true;
            this.txt_Info.Name = "txt_Info";
            this.txt_Info.ReadOnly = true;
            this.txt_Info.Size = new System.Drawing.Size(270, 186);
            this.txt_Info.TabIndex = 1;
            // 
            // txt_MSG
            // 
            this.txt_MSG.Location = new System.Drawing.Point(9, 201);
            this.txt_MSG.Name = "txt_MSG";
            this.txt_MSG.Size = new System.Drawing.Size(270, 21);
            this.txt_MSG.TabIndex = 2;
            this.txt_MSG.Text = "S_S_FILE#검색서버IP#파일개수#파일이름&파일사이즈&파일생성일";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.txt_MSG);
            this.Controls.Add(this.txt_Info);
            this.Controls.Add(this.btn_Start);
            this.Name = "Form1";
            this.Text = "문자열";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.TextBox txt_Info;
        private System.Windows.Forms.TextBox txt_MSG;
    }
}

