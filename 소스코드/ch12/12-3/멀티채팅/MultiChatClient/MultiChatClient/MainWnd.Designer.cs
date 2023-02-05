namespace MultiChatClient
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
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.lbl_Ip = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_Emoticon = new System.Windows.Forms.Button();
            this.txt_Input = new System.Windows.Forms.RichTextBox();
            this.txt_Info = new System.Windows.Forms.RichTextBox();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.btn_Font = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(184, 56);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(32, 21);
            this.txt_Port.TabIndex = 16;
            this.txt_Port.Text = "7007";
            // 
            // lbl_Ip
            // 
            this.lbl_Ip.Location = new System.Drawing.Point(16, 56);
            this.lbl_Ip.Name = "lbl_Ip";
            this.lbl_Ip.Size = new System.Drawing.Size(72, 16);
            this.lbl_Ip.TabIndex = 15;
            this.lbl_Ip.Text = "서버아이피";
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(88, 56);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(88, 21);
            this.txt_IP.TabIndex = 14;
            this.txt_IP.Text = "192.168.0.2";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(8, 16);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(216, 28);
            this.btn_Connect.TabIndex = 13;
            this.btn_Connect.Text = "서버 연결";
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_Emoticon
            // 
            this.btn_Emoticon.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Emoticon.Location = new System.Drawing.Point(126, 256);
            this.btn_Emoticon.Name = "btn_Emoticon";
            this.btn_Emoticon.Size = new System.Drawing.Size(112, 24);
            this.btn_Emoticon.TabIndex = 46;
            this.btn_Emoticon.Text = "이모티콘";
            this.btn_Emoticon.Click += new System.EventHandler(this.btn_Emoticon_Click);
            // 
            // txt_Input
            // 
            this.txt_Input.ImeMode = System.Windows.Forms.ImeMode.HangulFull;
            this.txt_Input.Location = new System.Drawing.Point(8, 290);
            this.txt_Input.Multiline = false;
            this.txt_Input.Name = "txt_Input";
            this.txt_Input.Size = new System.Drawing.Size(232, 32);
            this.txt_Input.TabIndex = 45;
            this.txt_Input.Text = "";
            this.txt_Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Input_KeyDown);
            // 
            // txt_Info
            // 
            this.txt_Info.Location = new System.Drawing.Point(8, 90);
            this.txt_Info.Name = "txt_Info";
            this.txt_Info.Size = new System.Drawing.Size(232, 160);
            this.txt_Info.TabIndex = 44;
            this.txt_Info.Text = "";
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 331);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(248, 22);
            this.statusBar.TabIndex = 43;
            // 
            // btn_Font
            // 
            this.btn_Font.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Font.Location = new System.Drawing.Point(8, 256);
            this.btn_Font.Name = "btn_Font";
            this.btn_Font.Size = new System.Drawing.Size(112, 24);
            this.btn_Font.TabIndex = 42;
            this.btn_Font.Text = "폰트";
            this.btn_Font.Click += new System.EventHandler(this.btn_Font_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Port);
            this.groupBox1.Controls.Add(this.lbl_Ip);
            this.groupBox1.Controls.Add(this.txt_IP);
            this.groupBox1.Controls.Add(this.btn_Connect);
            this.groupBox1.Location = new System.Drawing.Point(8, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 80);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "옵션";
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 353);
            this.Controls.Add(this.btn_Emoticon);
            this.Controls.Add(this.txt_Input);
            this.Controls.Add(this.txt_Info);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.btn_Font);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainWnd";
            this.Text = "서버/클라이언트채팅";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWnd_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Label lbl_Ip;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_Emoticon;
        private System.Windows.Forms.RichTextBox txt_Input;
        private System.Windows.Forms.RichTextBox txt_Info;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.Button btn_Font;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

