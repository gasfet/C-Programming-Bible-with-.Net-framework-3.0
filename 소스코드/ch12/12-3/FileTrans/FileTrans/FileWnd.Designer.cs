namespace FileTrans
{
    partial class FileWnd
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
            this.btn_Connect = new System.Windows.Forms.Button();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.btn_Server = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.prg_Bar = new System.Windows.Forms.ProgressBar();
            this.txt_Info = new System.Windows.Forms.TextBox();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(270, 7);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(88, 56);
            this.btn_Connect.TabIndex = 13;
            this.btn_Connect.Text = "서버 연결";
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(110, 15);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(144, 21);
            this.txt_IP.TabIndex = 12;
            // 
            // btn_Server
            // 
            this.btn_Server.Location = new System.Drawing.Point(14, 15);
            this.btn_Server.Name = "btn_Server";
            this.btn_Server.Size = new System.Drawing.Size(80, 23);
            this.btn_Server.TabIndex = 11;
            this.btn_Server.Text = "서버 시작";
            this.btn_Server.Click += new System.EventHandler(this.btn_Server_Click);
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(22, 215);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(320, 32);
            this.btn_Select.TabIndex = 10;
            this.btn_Select.Text = "전송파일선택";
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // prg_Bar
            // 
            this.prg_Bar.Location = new System.Drawing.Point(22, 183);
            this.prg_Bar.Name = "prg_Bar";
            this.prg_Bar.Size = new System.Drawing.Size(320, 23);
            this.prg_Bar.TabIndex = 9;
            // 
            // txt_Info
            // 
            this.txt_Info.Location = new System.Drawing.Point(22, 79);
            this.txt_Info.Multiline = true;
            this.txt_Info.Name = "txt_Info";
            this.txt_Info.ReadOnly = true;
            this.txt_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Info.Size = new System.Drawing.Size(320, 97);
            this.txt_Info.TabIndex = 8;
            // 
            // lbl_Info
            // 
            this.lbl_Info.Location = new System.Drawing.Point(22, 55);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(100, 16);
            this.lbl_Info.TabIndex = 7;
            this.lbl_Info.Text = "전송할 파일 정보";
            // 
            // FileWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 262);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.btn_Server);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.prg_Bar);
            this.Controls.Add(this.txt_Info);
            this.Controls.Add(this.lbl_Info);
            this.Name = "FileWnd";
            this.Text = "파일 전송";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FileWnd_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.Button btn_Server;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.ProgressBar prg_Bar;
        private System.Windows.Forms.TextBox txt_Info;
        private System.Windows.Forms.Label lbl_Info;
    }
}

