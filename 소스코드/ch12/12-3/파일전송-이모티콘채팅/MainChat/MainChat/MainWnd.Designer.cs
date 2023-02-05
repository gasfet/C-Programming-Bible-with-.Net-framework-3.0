namespace MainChat
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
            this.prg_Bar = new System.Windows.Forms.ProgressBar();
            this.btn_FileSend = new System.Windows.Forms.Button();
            this.btn_Emoticon = new System.Windows.Forms.Button();
            this.txt_Input = new System.Windows.Forms.RichTextBox();
            this.txt_Info = new System.Windows.Forms.RichTextBox();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.btn_Font = new System.Windows.Forms.Button();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.btn_Server = new System.Windows.Forms.Button();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // prg_Bar
            // 
            this.prg_Bar.Location = new System.Drawing.Point(8, 332);
            this.prg_Bar.Name = "prg_Bar";
            this.prg_Bar.Size = new System.Drawing.Size(232, 23);
            this.prg_Bar.TabIndex = 40;
            // 
            // btn_FileSend
            // 
            this.btn_FileSend.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_FileSend.Location = new System.Drawing.Point(80, 260);
            this.btn_FileSend.Name = "btn_FileSend";
            this.btn_FileSend.Size = new System.Drawing.Size(72, 25);
            this.btn_FileSend.TabIndex = 39;
            this.btn_FileSend.Text = "파일전송";
            this.btn_FileSend.Click += new System.EventHandler(this.btn_FileSend_Click);
            // 
            // btn_Emoticon
            // 
            this.btn_Emoticon.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Emoticon.Location = new System.Drawing.Point(160, 260);
            this.btn_Emoticon.Name = "btn_Emoticon";
            this.btn_Emoticon.Size = new System.Drawing.Size(80, 25);
            this.btn_Emoticon.TabIndex = 38;
            this.btn_Emoticon.Text = "이모티콘";
            this.btn_Emoticon.Click += new System.EventHandler(this.btn_Emoticon_Click);
            // 
            // txt_Input
            // 
            this.txt_Input.ImeMode = System.Windows.Forms.ImeMode.HangulFull;
            this.txt_Input.Location = new System.Drawing.Point(8, 292);
            this.txt_Input.Multiline = false;
            this.txt_Input.Name = "txt_Input";
            this.txt_Input.Size = new System.Drawing.Size(232, 32);
            this.txt_Input.TabIndex = 37;
            this.txt_Input.Text = "";
            this.txt_Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Input_KeyDown);
            // 
            // txt_Info
            // 
            this.txt_Info.Location = new System.Drawing.Point(8, 92);
            this.txt_Info.Name = "txt_Info";
            this.txt_Info.ReadOnly = true;
            this.txt_Info.Size = new System.Drawing.Size(232, 160);
            this.txt_Info.TabIndex = 36;
            this.txt_Info.Text = "";
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 359);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(248, 22);
            this.statusBar.TabIndex = 35;
            // 
            // btn_Font
            // 
            this.btn_Font.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Font.Location = new System.Drawing.Point(8, 260);
            this.btn_Font.Name = "btn_Font";
            this.btn_Font.Size = new System.Drawing.Size(64, 25);
            this.btn_Font.TabIndex = 34;
            this.btn_Font.Text = "폰트";
            this.btn_Font.Click += new System.EventHandler(this.btn_Font_Click);
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(184, 56);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(32, 21);
            this.txt_Port.TabIndex = 16;
            this.txt_Port.Text = "7000";
            // 
            // lbl_IP
            // 
            this.lbl_IP.Location = new System.Drawing.Point(16, 56);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(72, 16);
            this.lbl_IP.TabIndex = 15;
            this.lbl_IP.Text = "서버아이피";
            // 
            // btn_Server
            // 
            this.btn_Server.Location = new System.Drawing.Point(24, 20);
            this.btn_Server.Name = "btn_Server";
            this.btn_Server.Size = new System.Drawing.Size(103, 28);
            this.btn_Server.TabIndex = 32;
            this.btn_Server.Text = "서버 시작";
            this.btn_Server.Click += new System.EventHandler(this.btn_Server_Click);
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(88, 56);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(88, 21);
            this.txt_IP.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Port);
            this.groupBox1.Controls.Add(this.lbl_IP);
            this.groupBox1.Controls.Add(this.txt_IP);
            this.groupBox1.Controls.Add(this.btn_Connect);
            this.groupBox1.Location = new System.Drawing.Point(8, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 80);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "옵션";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(120, 16);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(104, 28);
            this.btn_Connect.TabIndex = 13;
            this.btn_Connect.Text = "서버 연결";
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 381);
            this.Controls.Add(this.prg_Bar);
            this.Controls.Add(this.btn_FileSend);
            this.Controls.Add(this.btn_Emoticon);
            this.Controls.Add(this.txt_Input);
            this.Controls.Add(this.txt_Info);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.btn_Font);
            this.Controls.Add(this.btn_Server);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainWnd";
            this.Text = "파일전송&이모티콘 채팅";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWnd_FormClosed);
            this.Load += new System.EventHandler(this.MainWnd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar prg_Bar;
        private System.Windows.Forms.Button btn_FileSend;
        private System.Windows.Forms.Button btn_Emoticon;
        private System.Windows.Forms.RichTextBox txt_Input;
        private System.Windows.Forms.RichTextBox txt_Info;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.Button btn_Font;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.Button btn_Server;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Connect;
    }
}

