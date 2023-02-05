namespace P2PClient
{
    partial class OptionWnd
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
            this.btn_ok = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_down = new System.Windows.Forms.Label();
            this.btn_down = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_share = new System.Windows.Forms.Label();
            this.btn_share = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(99, 250);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(224, 23);
            this.btn_ok.TabIndex = 17;
            this.btn_ok.Text = "확인";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(51, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "다운로드 디렉토리 지정 :";
            // 
            // lbl_down
            // 
            this.lbl_down.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_down.Location = new System.Drawing.Point(43, 202);
            this.lbl_down.Name = "lbl_down";
            this.lbl_down.Size = new System.Drawing.Size(360, 16);
            this.lbl_down.TabIndex = 14;
            this.lbl_down.Text = "C:\\";
            // 
            // btn_down
            // 
            this.btn_down.Location = new System.Drawing.Point(275, 154);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(128, 32);
            this.btn_down.TabIndex = 13;
            this.btn_down.Text = "디렉토리 지정";
            this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(11, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(432, 112);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "다운로드 디렉토리 설정";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(51, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "공유 디렉토리 지정 :";
            // 
            // lbl_share
            // 
            this.lbl_share.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_share.Location = new System.Drawing.Point(43, 82);
            this.lbl_share.Name = "lbl_share";
            this.lbl_share.Size = new System.Drawing.Size(360, 16);
            this.lbl_share.TabIndex = 10;
            this.lbl_share.Text = "C:\\";
            // 
            // btn_share
            // 
            this.btn_share.Location = new System.Drawing.Point(275, 34);
            this.btn_share.Name = "btn_share";
            this.btn_share.Size = new System.Drawing.Size(128, 32);
            this.btn_share.TabIndex = 9;
            this.btn_share.Text = "디렉토리 지정";
            this.btn_share.Click += new System.EventHandler(this.btn_share_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 112);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "공유 디렉토리 설정";
            // 
            // OptionWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 283);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_down);
            this.Controls.Add(this.btn_down);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_share);
            this.Controls.Add(this.btn_share);
            this.Controls.Add(this.groupBox1);
            this.Name = "OptionWnd";
            this.Text = "공유 & 다운로드 설정 옵션창";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionWnd_FormClosing);
            this.Load += new System.EventHandler(this.OptionWnd_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_down;
        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_share;
        private System.Windows.Forms.Button btn_share;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}