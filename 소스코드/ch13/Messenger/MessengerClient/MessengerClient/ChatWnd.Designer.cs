namespace MessengerClient
{
    partial class ChatWnd
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
            this.lbl_userid = new System.Windows.Forms.Label();
            this.lbl_txt = new System.Windows.Forms.Label();
            this.btn_SendMSG = new System.Windows.Forms.Button();
            this.btn_Emoticon = new System.Windows.Forms.Button();
            this.txt_Input = new System.Windows.Forms.RichTextBox();
            this.txt_Info = new System.Windows.Forms.RichTextBox();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.btn_Font = new System.Windows.Forms.Button();
            this.prg_Bar = new System.Windows.Forms.ProgressBar();
            this.btn_FileSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_userid
            // 
            this.lbl_userid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_userid.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_userid.Location = new System.Drawing.Point(96, 5);
            this.lbl_userid.Name = "lbl_userid";
            this.lbl_userid.Size = new System.Drawing.Size(200, 24);
            this.lbl_userid.TabIndex = 53;
            // 
            // lbl_txt
            // 
            this.lbl_txt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_txt.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_txt.Location = new System.Drawing.Point(9, 4);
            this.lbl_txt.Name = "lbl_txt";
            this.lbl_txt.Size = new System.Drawing.Size(80, 25);
            this.lbl_txt.TabIndex = 52;
            this.lbl_txt.Text = "상대방 :";
            // 
            // btn_SendMSG
            // 
            this.btn_SendMSG.Location = new System.Drawing.Point(240, 285);
            this.btn_SendMSG.Name = "btn_SendMSG";
            this.btn_SendMSG.Size = new System.Drawing.Size(56, 48);
            this.btn_SendMSG.TabIndex = 51;
            this.btn_SendMSG.Text = "전송";
            this.btn_SendMSG.Click += new System.EventHandler(this.btn_SendMSG_Click);
            // 
            // btn_Emoticon
            // 
            this.btn_Emoticon.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Emoticon.Location = new System.Drawing.Point(207, 251);
            this.btn_Emoticon.Name = "btn_Emoticon";
            this.btn_Emoticon.Size = new System.Drawing.Size(88, 31);
            this.btn_Emoticon.TabIndex = 48;
            this.btn_Emoticon.Text = "이모티콘";
            this.btn_Emoticon.Click += new System.EventHandler(this.btn_Emoticon_Click);
            // 
            // txt_Input
            // 
            this.txt_Input.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Input.ImeMode = System.Windows.Forms.ImeMode.HangulFull;
            this.txt_Input.Location = new System.Drawing.Point(8, 285);
            this.txt_Input.Name = "txt_Input";
            this.txt_Input.Size = new System.Drawing.Size(224, 48);
            this.txt_Input.TabIndex = 47;
            this.txt_Input.Text = "";
            this.txt_Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Input_KeyDown);
            // 
            // txt_Info
            // 
            this.txt_Info.Location = new System.Drawing.Point(8, 37);
            this.txt_Info.Name = "txt_Info";
            this.txt_Info.Size = new System.Drawing.Size(288, 208);
            this.txt_Info.TabIndex = 46;
            this.txt_Info.Text = "";
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 341);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(307, 22);
            this.statusBar.TabIndex = 45;
            // 
            // btn_Font
            // 
            this.btn_Font.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Font.Location = new System.Drawing.Point(7, 251);
            this.btn_Font.Name = "btn_Font";
            this.btn_Font.Size = new System.Drawing.Size(96, 31);
            this.btn_Font.TabIndex = 44;
            this.btn_Font.Text = "폰트";
            this.btn_Font.Click += new System.EventHandler(this.btn_Font_Click);
            // 
            // prg_Bar
            // 
            this.prg_Bar.Location = new System.Drawing.Point(12, 347);
            this.prg_Bar.Name = "prg_Bar";
            this.prg_Bar.Size = new System.Drawing.Size(280, 19);
            this.prg_Bar.TabIndex = 50;
            // 
            // btn_FileSend
            // 
            this.btn_FileSend.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_FileSend.Location = new System.Drawing.Point(111, 251);
            this.btn_FileSend.Name = "btn_FileSend";
            this.btn_FileSend.Size = new System.Drawing.Size(88, 31);
            this.btn_FileSend.TabIndex = 49;
            this.btn_FileSend.Text = "파일전송";
            this.btn_FileSend.Click += new System.EventHandler(this.btn_FileSend_Click);
            // 
            // ChatWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 363);
            this.Controls.Add(this.lbl_userid);
            this.Controls.Add(this.lbl_txt);
            this.Controls.Add(this.btn_SendMSG);
            this.Controls.Add(this.btn_Emoticon);
            this.Controls.Add(this.txt_Input);
            this.Controls.Add(this.txt_Info);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.btn_Font);
            this.Controls.Add(this.prg_Bar);
            this.Controls.Add(this.btn_FileSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChatWnd";
            this.Text = "메신저 채팅창";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatWnd_FormClosing);
            this.Load += new System.EventHandler(this.ChatWnd_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_userid;
        private System.Windows.Forms.Label lbl_txt;
        private System.Windows.Forms.Button btn_SendMSG;
        private System.Windows.Forms.Button btn_Emoticon;
        private System.Windows.Forms.RichTextBox txt_Input;
        private System.Windows.Forms.RichTextBox txt_Info;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.Button btn_Font;
        private System.Windows.Forms.ProgressBar prg_Bar;
        private System.Windows.Forms.Button btn_FileSend;
    }
}