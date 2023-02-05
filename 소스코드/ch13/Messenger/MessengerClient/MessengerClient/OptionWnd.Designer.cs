namespace MessengerClient
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
            this.radio_XML = new System.Windows.Forms.RadioButton();
            this.radio_Registry = new System.Windows.Forms.RadioButton();
            this.lbl_Hide = new System.Windows.Forms.Label();
            this.txt_Hide = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.chk_Crypto = new System.Windows.Forms.CheckBox();
            this.grBox_Crypto = new System.Windows.Forms.GroupBox();
            this.grBox_OptionStyle = new System.Windows.Forms.GroupBox();
            this.grBox_Notify = new System.Windows.Forms.GroupBox();
            this.lbl_Stay = new System.Windows.Forms.Label();
            this.txt_Stay = new System.Windows.Forms.TextBox();
            this.lbl_Show = new System.Windows.Forms.Label();
            this.txt_Show = new System.Windows.Forms.TextBox();
            this.txt_LoginPwd = new System.Windows.Forms.TextBox();
            this.txt_LoginID = new System.Windows.Forms.TextBox();
            this.chk_AutoLogin = new System.Windows.Forms.CheckBox();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.grBox_Autologin = new System.Windows.Forms.GroupBox();
            this.lbl_PWD = new System.Windows.Forms.Label();
            this.txt_PathFile = new System.Windows.Forms.TextBox();
            this.btn_PathFile = new System.Windows.Forms.Button();
            this.grBox_PathFile = new System.Windows.Forms.GroupBox();
            this.grBox_Crypto.SuspendLayout();
            this.grBox_OptionStyle.SuspendLayout();
            this.grBox_Notify.SuspendLayout();
            this.grBox_Autologin.SuspendLayout();
            this.grBox_PathFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // radio_XML
            // 
            this.radio_XML.Location = new System.Drawing.Point(32, 24);
            this.radio_XML.Name = "radio_XML";
            this.radio_XML.Size = new System.Drawing.Size(232, 24);
            this.radio_XML.TabIndex = 6;
            this.radio_XML.Text = "옵션을 XML 파일로 저장";
            // 
            // radio_Registry
            // 
            this.radio_Registry.Location = new System.Drawing.Point(32, 56);
            this.radio_Registry.Name = "radio_Registry";
            this.radio_Registry.Size = new System.Drawing.Size(232, 24);
            this.radio_Registry.TabIndex = 7;
            this.radio_Registry.Text = "옵션을 레지스터에 저장";
            // 
            // lbl_Hide
            // 
            this.lbl_Hide.Location = new System.Drawing.Point(205, 27);
            this.lbl_Hide.Name = "lbl_Hide";
            this.lbl_Hide.Size = new System.Drawing.Size(40, 16);
            this.lbl_Hide.TabIndex = 5;
            this.lbl_Hide.Text = "숨김";
            // 
            // txt_Hide
            // 
            this.txt_Hide.Location = new System.Drawing.Point(252, 22);
            this.txt_Hide.Name = "txt_Hide";
            this.txt_Hide.Size = new System.Drawing.Size(40, 21);
            this.txt_Hide.TabIndex = 4;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(528, 50);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(72, 23);
            this.btn_Cancel.TabIndex = 18;
            this.btn_Cancel.Text = "취소";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(528, 18);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(72, 23);
            this.btn_OK.TabIndex = 17;
            this.btn_OK.Text = "확인";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // chk_Crypto
            // 
            this.chk_Crypto.Location = new System.Drawing.Point(32, 20);
            this.chk_Crypto.Name = "chk_Crypto";
            this.chk_Crypto.Size = new System.Drawing.Size(248, 24);
            this.chk_Crypto.TabIndex = 0;
            this.chk_Crypto.Text = "채팅 문자열 암호화";
            // 
            // grBox_Crypto
            // 
            this.grBox_Crypto.Controls.Add(this.chk_Crypto);
            this.grBox_Crypto.Location = new System.Drawing.Point(216, 170);
            this.grBox_Crypto.Name = "grBox_Crypto";
            this.grBox_Crypto.Size = new System.Drawing.Size(304, 56);
            this.grBox_Crypto.TabIndex = 16;
            this.grBox_Crypto.TabStop = false;
            this.grBox_Crypto.Text = "암호화 기능 사용";
            // 
            // grBox_OptionStyle
            // 
            this.grBox_OptionStyle.Controls.Add(this.radio_XML);
            this.grBox_OptionStyle.Controls.Add(this.radio_Registry);
            this.grBox_OptionStyle.Location = new System.Drawing.Point(216, 74);
            this.grBox_OptionStyle.Name = "grBox_OptionStyle";
            this.grBox_OptionStyle.Size = new System.Drawing.Size(304, 88);
            this.grBox_OptionStyle.TabIndex = 15;
            this.grBox_OptionStyle.TabStop = false;
            this.grBox_OptionStyle.Text = "옵션 저장 형식";
            // 
            // grBox_Notify
            // 
            this.grBox_Notify.Controls.Add(this.lbl_Hide);
            this.grBox_Notify.Controls.Add(this.txt_Hide);
            this.grBox_Notify.Controls.Add(this.lbl_Stay);
            this.grBox_Notify.Controls.Add(this.txt_Stay);
            this.grBox_Notify.Controls.Add(this.lbl_Show);
            this.grBox_Notify.Controls.Add(this.txt_Show);
            this.grBox_Notify.Location = new System.Drawing.Point(216, 10);
            this.grBox_Notify.Name = "grBox_Notify";
            this.grBox_Notify.Size = new System.Drawing.Size(304, 56);
            this.grBox_Notify.TabIndex = 14;
            this.grBox_Notify.TabStop = false;
            this.grBox_Notify.Text = "공지창 시간 설정";
            // 
            // lbl_Stay
            // 
            this.lbl_Stay.Location = new System.Drawing.Point(108, 27);
            this.lbl_Stay.Name = "lbl_Stay";
            this.lbl_Stay.Size = new System.Drawing.Size(36, 16);
            this.lbl_Stay.TabIndex = 3;
            this.lbl_Stay.Text = "지속";
            // 
            // txt_Stay
            // 
            this.txt_Stay.Location = new System.Drawing.Point(156, 23);
            this.txt_Stay.Name = "txt_Stay";
            this.txt_Stay.Size = new System.Drawing.Size(40, 21);
            this.txt_Stay.TabIndex = 2;
            // 
            // lbl_Show
            // 
            this.lbl_Show.Location = new System.Drawing.Point(12, 28);
            this.lbl_Show.Name = "lbl_Show";
            this.lbl_Show.Size = new System.Drawing.Size(40, 16);
            this.lbl_Show.TabIndex = 1;
            this.lbl_Show.Text = "출력";
            // 
            // txt_Show
            // 
            this.txt_Show.Location = new System.Drawing.Point(60, 23);
            this.txt_Show.Name = "txt_Show";
            this.txt_Show.Size = new System.Drawing.Size(40, 21);
            this.txt_Show.TabIndex = 0;
            // 
            // txt_LoginPwd
            // 
            this.txt_LoginPwd.Location = new System.Drawing.Point(80, 80);
            this.txt_LoginPwd.Name = "txt_LoginPwd";
            this.txt_LoginPwd.Size = new System.Drawing.Size(100, 21);
            this.txt_LoginPwd.TabIndex = 2;
            // 
            // txt_LoginID
            // 
            this.txt_LoginID.Location = new System.Drawing.Point(80, 56);
            this.txt_LoginID.Name = "txt_LoginID";
            this.txt_LoginID.Size = new System.Drawing.Size(100, 21);
            this.txt_LoginID.TabIndex = 1;
            // 
            // chk_AutoLogin
            // 
            this.chk_AutoLogin.Location = new System.Drawing.Point(24, 21);
            this.chk_AutoLogin.Name = "chk_AutoLogin";
            this.chk_AutoLogin.Size = new System.Drawing.Size(152, 24);
            this.chk_AutoLogin.TabIndex = 0;
            this.chk_AutoLogin.Text = "자동 로그인 기능 사용";
            // 
            // lbl_ID
            // 
            this.lbl_ID.Location = new System.Drawing.Point(16, 56);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(56, 23);
            this.lbl_ID.TabIndex = 3;
            this.lbl_ID.Text = "아이디";
            // 
            // grBox_Autologin
            // 
            this.grBox_Autologin.Controls.Add(this.lbl_PWD);
            this.grBox_Autologin.Controls.Add(this.lbl_ID);
            this.grBox_Autologin.Controls.Add(this.txt_LoginPwd);
            this.grBox_Autologin.Controls.Add(this.txt_LoginID);
            this.grBox_Autologin.Controls.Add(this.chk_AutoLogin);
            this.grBox_Autologin.Location = new System.Drawing.Point(8, 10);
            this.grBox_Autologin.Name = "grBox_Autologin";
            this.grBox_Autologin.Size = new System.Drawing.Size(200, 120);
            this.grBox_Autologin.TabIndex = 12;
            this.grBox_Autologin.TabStop = false;
            this.grBox_Autologin.Text = "자동 로그인";
            // 
            // lbl_PWD
            // 
            this.lbl_PWD.Location = new System.Drawing.Point(16, 88);
            this.lbl_PWD.Name = "lbl_PWD";
            this.lbl_PWD.Size = new System.Drawing.Size(56, 23);
            this.lbl_PWD.TabIndex = 4;
            this.lbl_PWD.Text = "비밀번호";
            // 
            // txt_PathFile
            // 
            this.txt_PathFile.Location = new System.Drawing.Point(8, 24);
            this.txt_PathFile.Name = "txt_PathFile";
            this.txt_PathFile.Size = new System.Drawing.Size(184, 21);
            this.txt_PathFile.TabIndex = 6;
            // 
            // btn_PathFile
            // 
            this.btn_PathFile.Location = new System.Drawing.Point(8, 56);
            this.btn_PathFile.Name = "btn_PathFile";
            this.btn_PathFile.Size = new System.Drawing.Size(184, 23);
            this.btn_PathFile.TabIndex = 5;
            this.btn_PathFile.Text = "받은 파일 저장 경로 지정";
            this.btn_PathFile.Click += new System.EventHandler(this.btn_PathFile_Click);
            // 
            // grBox_PathFile
            // 
            this.grBox_PathFile.Controls.Add(this.txt_PathFile);
            this.grBox_PathFile.Controls.Add(this.btn_PathFile);
            this.grBox_PathFile.Location = new System.Drawing.Point(9, 138);
            this.grBox_PathFile.Name = "grBox_PathFile";
            this.grBox_PathFile.Size = new System.Drawing.Size(199, 88);
            this.grBox_PathFile.TabIndex = 13;
            this.grBox_PathFile.TabStop = false;
            this.grBox_PathFile.Text = "받은 파일 경로 지정";
            // 
            // OptionWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 237);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.grBox_Crypto);
            this.Controls.Add(this.grBox_OptionStyle);
            this.Controls.Add(this.grBox_Notify);
            this.Controls.Add(this.grBox_Autologin);
            this.Controls.Add(this.grBox_PathFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OptionWnd";
            this.Text = "메신저 옵션 설정창";
            this.grBox_Crypto.ResumeLayout(false);
            this.grBox_OptionStyle.ResumeLayout(false);
            this.grBox_Notify.ResumeLayout(false);
            this.grBox_Notify.PerformLayout();
            this.grBox_Autologin.ResumeLayout(false);
            this.grBox_Autologin.PerformLayout();
            this.grBox_PathFile.ResumeLayout(false);
            this.grBox_PathFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radio_XML;
        private System.Windows.Forms.RadioButton radio_Registry;
        private System.Windows.Forms.Label lbl_Hide;
        private System.Windows.Forms.TextBox txt_Hide;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.CheckBox chk_Crypto;
        private System.Windows.Forms.GroupBox grBox_Crypto;
        private System.Windows.Forms.GroupBox grBox_OptionStyle;
        private System.Windows.Forms.GroupBox grBox_Notify;
        private System.Windows.Forms.Label lbl_Stay;
        private System.Windows.Forms.TextBox txt_Stay;
        private System.Windows.Forms.Label lbl_Show;
        private System.Windows.Forms.TextBox txt_Show;
        private System.Windows.Forms.TextBox txt_LoginPwd;
        private System.Windows.Forms.TextBox txt_LoginID;
        private System.Windows.Forms.CheckBox chk_AutoLogin;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.GroupBox grBox_Autologin;
        private System.Windows.Forms.Label lbl_PWD;
        private System.Windows.Forms.TextBox txt_PathFile;
        private System.Windows.Forms.Button btn_PathFile;
        private System.Windows.Forms.GroupBox grBox_PathFile;
    }
}