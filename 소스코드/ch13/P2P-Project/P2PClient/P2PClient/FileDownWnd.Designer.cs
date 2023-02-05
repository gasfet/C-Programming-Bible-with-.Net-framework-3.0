namespace P2PClient
{
    partial class FileDownWnd
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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lbl_info = new System.Windows.Forms.Label();
            this.cb_close = new System.Windows.Forms.CheckBox();
            this.txt_connect = new System.Windows.Forms.TextBox();
            this.prg_down = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(202, 114);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 56);
            this.btn_cancel.TabIndex = 10;
            this.btn_cancel.Text = "취소";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lbl_info
            // 
            this.lbl_info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_info.Location = new System.Drawing.Point(10, 114);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(184, 56);
            this.lbl_info.TabIndex = 9;
            // 
            // cb_close
            // 
            this.cb_close.Location = new System.Drawing.Point(10, 178);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(264, 22);
            this.cb_close.TabIndex = 8;
            this.cb_close.Text = "내려받기 완료시 자동으로 대화상자 닫음";
            // 
            // txt_connect
            // 
            this.txt_connect.BackColor = System.Drawing.SystemColors.Desktop;
            this.txt_connect.ForeColor = System.Drawing.SystemColors.Window;
            this.txt_connect.Location = new System.Drawing.Point(10, 2);
            this.txt_connect.Multiline = true;
            this.txt_connect.Name = "txt_connect";
            this.txt_connect.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_connect.Size = new System.Drawing.Size(264, 80);
            this.txt_connect.TabIndex = 7;
            // 
            // prg_down
            // 
            this.prg_down.Location = new System.Drawing.Point(10, 90);
            this.prg_down.Name = "prg_down";
            this.prg_down.Size = new System.Drawing.Size(264, 16);
            this.prg_down.TabIndex = 6;
            // 
            // FileDownWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 203);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.cb_close);
            this.Controls.Add(this.txt_connect);
            this.Controls.Add(this.prg_down);
            this.Name = "FileDownWnd";
            this.Text = "FileDownWnd";
            this.Load += new System.EventHandler(this.FileDownWnd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.CheckBox cb_close;
        private System.Windows.Forms.TextBox txt_connect;
        private System.Windows.Forms.ProgressBar prg_down;
    }
}