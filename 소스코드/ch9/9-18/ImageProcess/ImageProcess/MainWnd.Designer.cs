namespace ImageProcess
{
    partial class MainWnd
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
            this.btn_ImageProcess = new System.Windows.Forms.Button();
            this.btn_SelectImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ImageProcess
            // 
            this.btn_ImageProcess.Enabled = false;
            this.btn_ImageProcess.Location = new System.Drawing.Point(12, 268);
            this.btn_ImageProcess.Name = "btn_ImageProcess";
            this.btn_ImageProcess.Size = new System.Drawing.Size(128, 40);
            this.btn_ImageProcess.TabIndex = 3;
            this.btn_ImageProcess.Text = "이미지 처리";
            this.btn_ImageProcess.Click += new System.EventHandler(this.btn_ImageProcess_Click);
            // 
            // btn_SelectImage
            // 
            this.btn_SelectImage.Location = new System.Drawing.Point(12, 212);
            this.btn_SelectImage.Name = "btn_SelectImage";
            this.btn_SelectImage.Size = new System.Drawing.Size(128, 40);
            this.btn_SelectImage.TabIndex = 2;
            this.btn_SelectImage.Text = "이미지 선택";
            this.btn_SelectImage.Click += new System.EventHandler(this.btn_SelectImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 326);
            this.Controls.Add(this.btn_ImageProcess);
            this.Controls.Add(this.btn_SelectImage);
            this.Name = "Form1";
            this.Text = "이미지 처리 프로그램 ver 1.0";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ImageProcess;
        private System.Windows.Forms.Button btn_SelectImage;
    }
}

