namespace Scratch
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
            this.lbl_Info = new System.Windows.Forms.Label();
            this.prBar = new System.Windows.Forms.ProgressBar();
            this.btn_Image = new System.Windows.Forms.Button();
            this.pb_Image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Info
            // 
            this.lbl_Info.Location = new System.Drawing.Point(384, 311);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(48, 24);
            this.lbl_Info.TabIndex = 9;
            this.lbl_Info.Text = "진행률";
            // 
            // prBar
            // 
            this.prBar.Location = new System.Drawing.Point(136, 303);
            this.prBar.Maximum = 300;
            this.prBar.Name = "prBar";
            this.prBar.Size = new System.Drawing.Size(224, 40);
            this.prBar.TabIndex = 8;
            // 
            // btn_Image
            // 
            this.btn_Image.Location = new System.Drawing.Point(16, 295);
            this.btn_Image.Name = "btn_Image";
            this.btn_Image.Size = new System.Drawing.Size(104, 56);
            this.btn_Image.TabIndex = 7;
            this.btn_Image.Text = "이미지 선택";
            this.btn_Image.Click += new System.EventHandler(this.btn_Image_Click);
            // 
            // pb_Image
            // 
            this.pb_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Image.Location = new System.Drawing.Point(8, 7);
            this.pb_Image.Name = "pb_Image";
            this.pb_Image.Size = new System.Drawing.Size(432, 280);
            this.pb_Image.TabIndex = 6;
            this.pb_Image.TabStop = false;
            this.pb_Image.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_Image_MouseDown);
            this.pb_Image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_Image_MouseMove);
            this.pb_Image.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_Image_MouseUp);
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 358);
            this.Controls.Add(this.lbl_Info);
            this.Controls.Add(this.prBar);
            this.Controls.Add(this.btn_Image);
            this.Controls.Add(this.pb_Image);
            this.Name = "MainWnd";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pb_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.ProgressBar prBar;
        private System.Windows.Forms.Button btn_Image;
        private System.Windows.Forms.PictureBox pb_Image;
    }
}

