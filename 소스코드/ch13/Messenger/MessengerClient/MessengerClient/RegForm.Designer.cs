namespace MessengerClient
{
    partial class RegForm
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
            this.txt_NickName = new System.Windows.Forms.TextBox();
            this.txt_Addr2 = new System.Windows.Forms.TextBox();
            this.txt_Addr1 = new System.Windows.Forms.TextBox();
            this.txt_Zip2 = new System.Windows.Forms.TextBox();
            this.txt_Zip1 = new System.Windows.Forms.TextBox();
            this.txt_Intro = new System.Windows.Forms.TextBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_Tel = new System.Windows.Forms.TextBox();
            this.txt_Ssn2 = new System.Windows.Forms.TextBox();
            this.txt_Ssn1 = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Pwd_Ok = new System.Windows.Forms.TextBox();
            this.txt_Pwd = new System.Windows.Forms.TextBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.lbl_NickName = new System.Windows.Forms.Label();
            this.lbl_addr2 = new System.Windows.Forms.Label();
            this.lbl_Example = new System.Windows.Forms.Label();
            this.btn_Re = new System.Windows.Forms.Button();
            this.btn_Reg = new System.Windows.Forms.Button();
            this.lbl_Intro = new System.Windows.Forms.Label();
            this.lbl_Addr = new System.Windows.Forms.Label();
            this.btn_Zip = new System.Windows.Forms.Button();
            this.lbl_Dash2 = new System.Windows.Forms.Label();
            this.lbl_Zip = new System.Windows.Forms.Label();
            this.btn_ID = new System.Windows.Forms.Button();
            this.lbl_Dash1 = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_Tel = new System.Windows.Forms.Label();
            this.lbl_Jumin = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_Pwd_Ok = new System.Windows.Forms.Label();
            this.lbl_Pwd = new System.Windows.Forms.Label();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_NickName
            // 
            this.txt_NickName.Location = new System.Drawing.Point(271, 85);
            this.txt_NickName.Name = "txt_NickName";
            this.txt_NickName.Size = new System.Drawing.Size(152, 21);
            this.txt_NickName.TabIndex = 50;
            // 
            // txt_Addr2
            // 
            this.txt_Addr2.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_Addr2.Location = new System.Drawing.Point(103, 269);
            this.txt_Addr2.Name = "txt_Addr2";
            this.txt_Addr2.Size = new System.Drawing.Size(296, 21);
            this.txt_Addr2.TabIndex = 60;
            // 
            // txt_Addr1
            // 
            this.txt_Addr1.Location = new System.Drawing.Point(103, 245);
            this.txt_Addr1.Name = "txt_Addr1";
            this.txt_Addr1.ReadOnly = true;
            this.txt_Addr1.Size = new System.Drawing.Size(296, 21);
            this.txt_Addr1.TabIndex = 67;
            // 
            // txt_Zip2
            // 
            this.txt_Zip2.Location = new System.Drawing.Point(191, 217);
            this.txt_Zip2.Name = "txt_Zip2";
            this.txt_Zip2.ReadOnly = true;
            this.txt_Zip2.Size = new System.Drawing.Size(56, 21);
            this.txt_Zip2.TabIndex = 65;
            // 
            // txt_Zip1
            // 
            this.txt_Zip1.Location = new System.Drawing.Point(103, 217);
            this.txt_Zip1.Name = "txt_Zip1";
            this.txt_Zip1.ReadOnly = true;
            this.txt_Zip1.Size = new System.Drawing.Size(56, 21);
            this.txt_Zip1.TabIndex = 58;
            // 
            // txt_Intro
            // 
            this.txt_Intro.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_Intro.Location = new System.Drawing.Point(103, 301);
            this.txt_Intro.Multiline = true;
            this.txt_Intro.Name = "txt_Intro";
            this.txt_Intro.Size = new System.Drawing.Size(304, 64);
            this.txt_Intro.TabIndex = 61;
            // 
            // txt_Email
            // 
            this.txt_Email.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txt_Email.Location = new System.Drawing.Point(103, 189);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(296, 21);
            this.txt_Email.TabIndex = 57;
            // 
            // txt_Tel
            // 
            this.txt_Tel.Location = new System.Drawing.Point(103, 157);
            this.txt_Tel.Name = "txt_Tel";
            this.txt_Tel.Size = new System.Drawing.Size(152, 21);
            this.txt_Tel.TabIndex = 55;
            // 
            // txt_Ssn2
            // 
            this.txt_Ssn2.Location = new System.Drawing.Point(231, 125);
            this.txt_Ssn2.Name = "txt_Ssn2";
            this.txt_Ssn2.Size = new System.Drawing.Size(136, 21);
            this.txt_Ssn2.TabIndex = 54;
            // 
            // txt_Ssn1
            // 
            this.txt_Ssn1.Location = new System.Drawing.Point(103, 125);
            this.txt_Ssn1.Name = "txt_Ssn1";
            this.txt_Ssn1.Size = new System.Drawing.Size(100, 21);
            this.txt_Ssn1.TabIndex = 52;
            // 
            // txt_Name
            // 
            this.txt_Name.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_Name.Location = new System.Drawing.Point(103, 85);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(104, 21);
            this.txt_Name.TabIndex = 48;
            // 
            // txt_Pwd_Ok
            // 
            this.txt_Pwd_Ok.Location = new System.Drawing.Point(319, 53);
            this.txt_Pwd_Ok.Name = "txt_Pwd_Ok";
            this.txt_Pwd_Ok.PasswordChar = '*';
            this.txt_Pwd_Ok.Size = new System.Drawing.Size(100, 21);
            this.txt_Pwd_Ok.TabIndex = 47;
            // 
            // txt_Pwd
            // 
            this.txt_Pwd.Location = new System.Drawing.Point(103, 53);
            this.txt_Pwd.Name = "txt_Pwd";
            this.txt_Pwd.PasswordChar = '*';
            this.txt_Pwd.Size = new System.Drawing.Size(104, 21);
            this.txt_Pwd.TabIndex = 44;
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(103, 13);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(120, 21);
            this.txt_ID.TabIndex = 40;
            // 
            // lbl_NickName
            // 
            this.lbl_NickName.Location = new System.Drawing.Point(223, 93);
            this.lbl_NickName.Name = "lbl_NickName";
            this.lbl_NickName.Size = new System.Drawing.Size(32, 16);
            this.lbl_NickName.TabIndex = 72;
            this.lbl_NickName.Text = "별칭";
            // 
            // lbl_addr2
            // 
            this.lbl_addr2.Location = new System.Drawing.Point(15, 269);
            this.lbl_addr2.Name = "lbl_addr2";
            this.lbl_addr2.Size = new System.Drawing.Size(80, 16);
            this.lbl_addr2.TabIndex = 71;
            this.lbl_addr2.Text = "상세주소";
            // 
            // lbl_Example
            // 
            this.lbl_Example.Location = new System.Drawing.Point(263, 165);
            this.lbl_Example.Name = "lbl_Example";
            this.lbl_Example.Size = new System.Drawing.Size(160, 16);
            this.lbl_Example.TabIndex = 70;
            this.lbl_Example.Text = "예) 02-123-1234";
            // 
            // btn_Re
            // 
            this.btn_Re.Location = new System.Drawing.Point(223, 373);
            this.btn_Re.Name = "btn_Re";
            this.btn_Re.Size = new System.Drawing.Size(176, 23);
            this.btn_Re.TabIndex = 63;
            this.btn_Re.Text = "다시 쓰기";
            this.btn_Re.Click += new System.EventHandler(this.btn_Re_Click);
            // 
            // btn_Reg
            // 
            this.btn_Reg.Location = new System.Drawing.Point(39, 373);
            this.btn_Reg.Name = "btn_Reg";
            this.btn_Reg.Size = new System.Drawing.Size(160, 24);
            this.btn_Reg.TabIndex = 62;
            this.btn_Reg.Text = "회원 가입";
            this.btn_Reg.Click += new System.EventHandler(this.btn_Reg_Click);
            // 
            // lbl_Intro
            // 
            this.lbl_Intro.Location = new System.Drawing.Point(15, 301);
            this.lbl_Intro.Name = "lbl_Intro";
            this.lbl_Intro.Size = new System.Drawing.Size(80, 16);
            this.lbl_Intro.TabIndex = 69;
            this.lbl_Intro.Text = "자기소개";
            // 
            // lbl_Addr
            // 
            this.lbl_Addr.Location = new System.Drawing.Point(15, 245);
            this.lbl_Addr.Name = "lbl_Addr";
            this.lbl_Addr.Size = new System.Drawing.Size(80, 16);
            this.lbl_Addr.TabIndex = 68;
            this.lbl_Addr.Text = "주소";
            // 
            // btn_Zip
            // 
            this.btn_Zip.Location = new System.Drawing.Point(279, 217);
            this.btn_Zip.Name = "btn_Zip";
            this.btn_Zip.Size = new System.Drawing.Size(96, 23);
            this.btn_Zip.TabIndex = 59;
            this.btn_Zip.Text = "우편번호 찾기";
            this.btn_Zip.Click += new System.EventHandler(this.btn_Zip_Click);
            // 
            // lbl_Dash2
            // 
            this.lbl_Dash2.Location = new System.Drawing.Point(167, 225);
            this.lbl_Dash2.Name = "lbl_Dash2";
            this.lbl_Dash2.Size = new System.Drawing.Size(20, 16);
            this.lbl_Dash2.TabIndex = 66;
            this.lbl_Dash2.Text = "-";
            // 
            // lbl_Zip
            // 
            this.lbl_Zip.Location = new System.Drawing.Point(15, 221);
            this.lbl_Zip.Name = "lbl_Zip";
            this.lbl_Zip.Size = new System.Drawing.Size(80, 16);
            this.lbl_Zip.TabIndex = 64;
            this.lbl_Zip.Text = "우편번호";
            // 
            // btn_ID
            // 
            this.btn_ID.Location = new System.Drawing.Point(247, 13);
            this.btn_ID.Name = "btn_ID";
            this.btn_ID.Size = new System.Drawing.Size(136, 23);
            this.btn_ID.TabIndex = 43;
            this.btn_ID.Text = "아이디 중복 검사";
            this.btn_ID.Click += new System.EventHandler(this.btn_ID_Click);
            // 
            // lbl_Dash1
            // 
            this.lbl_Dash1.Location = new System.Drawing.Point(207, 133);
            this.lbl_Dash1.Name = "lbl_Dash1";
            this.lbl_Dash1.Size = new System.Drawing.Size(20, 16);
            this.lbl_Dash1.TabIndex = 56;
            this.lbl_Dash1.Text = "-";
            // 
            // lbl_Email
            // 
            this.lbl_Email.Location = new System.Drawing.Point(15, 189);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(80, 16);
            this.lbl_Email.TabIndex = 53;
            this.lbl_Email.Text = "E-메일주소";
            // 
            // lbl_Tel
            // 
            this.lbl_Tel.Location = new System.Drawing.Point(15, 157);
            this.lbl_Tel.Name = "lbl_Tel";
            this.lbl_Tel.Size = new System.Drawing.Size(80, 16);
            this.lbl_Tel.TabIndex = 51;
            this.lbl_Tel.Text = "전화번호";
            // 
            // lbl_Jumin
            // 
            this.lbl_Jumin.Location = new System.Drawing.Point(15, 125);
            this.lbl_Jumin.Name = "lbl_Jumin";
            this.lbl_Jumin.Size = new System.Drawing.Size(64, 16);
            this.lbl_Jumin.TabIndex = 49;
            this.lbl_Jumin.Text = "주민 번호";
            // 
            // lbl_Name
            // 
            this.lbl_Name.Location = new System.Drawing.Point(15, 93);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(80, 16);
            this.lbl_Name.TabIndex = 46;
            this.lbl_Name.Text = "이름";
            // 
            // lbl_Pwd_Ok
            // 
            this.lbl_Pwd_Ok.Location = new System.Drawing.Point(215, 61);
            this.lbl_Pwd_Ok.Name = "lbl_Pwd_Ok";
            this.lbl_Pwd_Ok.Size = new System.Drawing.Size(88, 16);
            this.lbl_Pwd_Ok.TabIndex = 45;
            this.lbl_Pwd_Ok.Text = "비밀번호 확인";
            // 
            // lbl_Pwd
            // 
            this.lbl_Pwd.Location = new System.Drawing.Point(15, 61);
            this.lbl_Pwd.Name = "lbl_Pwd";
            this.lbl_Pwd.Size = new System.Drawing.Size(80, 16);
            this.lbl_Pwd.TabIndex = 42;
            this.lbl_Pwd.Text = "비밀번호";
            // 
            // lbl_ID
            // 
            this.lbl_ID.Location = new System.Drawing.Point(15, 21);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(80, 16);
            this.lbl_ID.TabIndex = 41;
            this.lbl_ID.Text = "아이디";
            // 
            // RegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 411);
            this.Controls.Add(this.txt_NickName);
            this.Controls.Add(this.txt_Addr2);
            this.Controls.Add(this.txt_Addr1);
            this.Controls.Add(this.txt_Zip2);
            this.Controls.Add(this.txt_Zip1);
            this.Controls.Add(this.txt_Intro);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.txt_Tel);
            this.Controls.Add(this.txt_Ssn2);
            this.Controls.Add(this.txt_Ssn1);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.txt_Pwd_Ok);
            this.Controls.Add(this.txt_Pwd);
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.lbl_NickName);
            this.Controls.Add(this.lbl_addr2);
            this.Controls.Add(this.lbl_Example);
            this.Controls.Add(this.btn_Re);
            this.Controls.Add(this.btn_Reg);
            this.Controls.Add(this.lbl_Intro);
            this.Controls.Add(this.lbl_Addr);
            this.Controls.Add(this.btn_Zip);
            this.Controls.Add(this.lbl_Dash2);
            this.Controls.Add(this.lbl_Zip);
            this.Controls.Add(this.btn_ID);
            this.Controls.Add(this.lbl_Dash1);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.lbl_Tel);
            this.Controls.Add(this.lbl_Jumin);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.lbl_Pwd_Ok);
            this.Controls.Add(this.lbl_Pwd);
            this.Controls.Add(this.lbl_ID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RegForm";
            this.Text = "메신저 회원 가입";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_NickName;
        private System.Windows.Forms.TextBox txt_Addr2;
        private System.Windows.Forms.TextBox txt_Addr1;
        private System.Windows.Forms.TextBox txt_Zip2;
        private System.Windows.Forms.TextBox txt_Zip1;
        private System.Windows.Forms.TextBox txt_Intro;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_Tel;
        private System.Windows.Forms.TextBox txt_Ssn2;
        private System.Windows.Forms.TextBox txt_Ssn1;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_Pwd_Ok;
        private System.Windows.Forms.TextBox txt_Pwd;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.Label lbl_NickName;
        private System.Windows.Forms.Label lbl_addr2;
        private System.Windows.Forms.Label lbl_Example;
        private System.Windows.Forms.Button btn_Re;
        private System.Windows.Forms.Button btn_Reg;
        private System.Windows.Forms.Label lbl_Intro;
        private System.Windows.Forms.Label lbl_Addr;
        private System.Windows.Forms.Button btn_Zip;
        private System.Windows.Forms.Label lbl_Dash2;
        private System.Windows.Forms.Label lbl_Zip;
        private System.Windows.Forms.Button btn_ID;
        private System.Windows.Forms.Label lbl_Dash1;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_Tel;
        private System.Windows.Forms.Label lbl_Jumin;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_Pwd_Ok;
        private System.Windows.Forms.Label lbl_Pwd;
        private System.Windows.Forms.Label lbl_ID;
    }
}