namespace MessengerServer
{
    partial class EditMember
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
            this.txt_Zip2 = new System.Windows.Forms.TextBox();
            this.txt_Zip1 = new System.Windows.Forms.TextBox();
            this.txt_NickName = new System.Windows.Forms.TextBox();
            this.txt_Addr = new System.Windows.Forms.TextBox();
            this.txt_Intro = new System.Windows.Forms.TextBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_Tel = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Pwd = new System.Windows.Forms.TextBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.btn_Zip = new System.Windows.Forms.Button();
            this.lbl_Dash2 = new System.Windows.Forms.Label();
            this.lbl_Zip = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_NickName = new System.Windows.Forms.Label();
            this.lbl_Example = new System.Windows.Forms.Label();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.lbl_Intro = new System.Windows.Forms.Label();
            this.lbl_Addr = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_Tel = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_Pwd = new System.Windows.Forms.Label();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Zip2
            // 
            this.txt_Zip2.Location = new System.Drawing.Point(199, 177);
            this.txt_Zip2.Name = "txt_Zip2";
            this.txt_Zip2.ReadOnly = true;
            this.txt_Zip2.Size = new System.Drawing.Size(56, 21);
            this.txt_Zip2.TabIndex = 136;
            // 
            // txt_Zip1
            // 
            this.txt_Zip1.Location = new System.Drawing.Point(111, 177);
            this.txt_Zip1.Name = "txt_Zip1";
            this.txt_Zip1.ReadOnly = true;
            this.txt_Zip1.Size = new System.Drawing.Size(56, 21);
            this.txt_Zip1.TabIndex = 134;
            // 
            // txt_NickName
            // 
            this.txt_NickName.Location = new System.Drawing.Point(111, 85);
            this.txt_NickName.Name = "txt_NickName";
            this.txt_NickName.Size = new System.Drawing.Size(152, 21);
            this.txt_NickName.TabIndex = 115;
            // 
            // txt_Addr
            // 
            this.txt_Addr.Location = new System.Drawing.Point(111, 205);
            this.txt_Addr.Name = "txt_Addr";
            this.txt_Addr.Size = new System.Drawing.Size(328, 21);
            this.txt_Addr.TabIndex = 119;
            // 
            // txt_Intro
            // 
            this.txt_Intro.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_Intro.Location = new System.Drawing.Point(111, 245);
            this.txt_Intro.Multiline = true;
            this.txt_Intro.Name = "txt_Intro";
            this.txt_Intro.Size = new System.Drawing.Size(328, 64);
            this.txt_Intro.TabIndex = 120;
            // 
            // txt_Email
            // 
            this.txt_Email.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txt_Email.Location = new System.Drawing.Point(111, 149);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(328, 21);
            this.txt_Email.TabIndex = 117;
            // 
            // txt_Tel
            // 
            this.txt_Tel.Location = new System.Drawing.Point(111, 117);
            this.txt_Tel.Name = "txt_Tel";
            this.txt_Tel.Size = new System.Drawing.Size(152, 21);
            this.txt_Tel.TabIndex = 116;
            // 
            // txt_Name
            // 
            this.txt_Name.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txt_Name.Location = new System.Drawing.Point(311, 13);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.ReadOnly = true;
            this.txt_Name.Size = new System.Drawing.Size(120, 21);
            this.txt_Name.TabIndex = 127;
            // 
            // txt_Pwd
            // 
            this.txt_Pwd.Location = new System.Drawing.Point(111, 53);
            this.txt_Pwd.Name = "txt_Pwd";
            this.txt_Pwd.PasswordChar = '*';
            this.txt_Pwd.Size = new System.Drawing.Size(104, 21);
            this.txt_Pwd.TabIndex = 114;
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(111, 13);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(120, 21);
            this.txt_ID.TabIndex = 124;
            // 
            // btn_Zip
            // 
            this.btn_Zip.Location = new System.Drawing.Point(287, 177);
            this.btn_Zip.Name = "btn_Zip";
            this.btn_Zip.Size = new System.Drawing.Size(96, 23);
            this.btn_Zip.TabIndex = 118;
            this.btn_Zip.Text = "우편번호 찾기";
            this.btn_Zip.Click += new System.EventHandler(this.btn_Zip_Click);
            // 
            // lbl_Dash2
            // 
            this.lbl_Dash2.Location = new System.Drawing.Point(175, 185);
            this.lbl_Dash2.Name = "lbl_Dash2";
            this.lbl_Dash2.Size = new System.Drawing.Size(8, 16);
            this.lbl_Dash2.TabIndex = 137;
            this.lbl_Dash2.Text = "-";
            // 
            // lbl_Zip
            // 
            this.lbl_Zip.Location = new System.Drawing.Point(23, 185);
            this.lbl_Zip.Name = "lbl_Zip";
            this.lbl_Zip.Size = new System.Drawing.Size(80, 16);
            this.lbl_Zip.TabIndex = 135;
            this.lbl_Zip.Text = "우편번호";
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(239, 325);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(200, 23);
            this.btn_Close.TabIndex = 122;
            this.btn_Close.Text = "창 닫기";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_NickName
            // 
            this.lbl_NickName.Location = new System.Drawing.Point(23, 85);
            this.lbl_NickName.Name = "lbl_NickName";
            this.lbl_NickName.Size = new System.Drawing.Size(32, 16);
            this.lbl_NickName.TabIndex = 133;
            this.lbl_NickName.Text = "별칭";
            // 
            // lbl_Example
            // 
            this.lbl_Example.Location = new System.Drawing.Point(271, 125);
            this.lbl_Example.Name = "lbl_Example";
            this.lbl_Example.Size = new System.Drawing.Size(160, 16);
            this.lbl_Example.TabIndex = 132;
            this.lbl_Example.Text = "예) 02-123-1234";
            // 
            // btn_Edit
            // 
            this.btn_Edit.Location = new System.Drawing.Point(15, 325);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(200, 24);
            this.btn_Edit.TabIndex = 121;
            this.btn_Edit.Text = "회원 정보 변경";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // lbl_Intro
            // 
            this.lbl_Intro.Location = new System.Drawing.Point(23, 245);
            this.lbl_Intro.Name = "lbl_Intro";
            this.lbl_Intro.Size = new System.Drawing.Size(80, 16);
            this.lbl_Intro.TabIndex = 131;
            this.lbl_Intro.Text = "자기소개";
            // 
            // lbl_Addr
            // 
            this.lbl_Addr.Location = new System.Drawing.Point(23, 208);
            this.lbl_Addr.Name = "lbl_Addr";
            this.lbl_Addr.Size = new System.Drawing.Size(80, 16);
            this.lbl_Addr.TabIndex = 130;
            this.lbl_Addr.Text = "주소";
            // 
            // lbl_Email
            // 
            this.lbl_Email.Location = new System.Drawing.Point(23, 149);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(80, 16);
            this.lbl_Email.TabIndex = 129;
            this.lbl_Email.Text = "E-메일주소";
            // 
            // lbl_Tel
            // 
            this.lbl_Tel.Location = new System.Drawing.Point(23, 117);
            this.lbl_Tel.Name = "lbl_Tel";
            this.lbl_Tel.Size = new System.Drawing.Size(80, 16);
            this.lbl_Tel.TabIndex = 128;
            this.lbl_Tel.Text = "전화번호";
            // 
            // lbl_Name
            // 
            this.lbl_Name.Location = new System.Drawing.Point(271, 17);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(32, 16);
            this.lbl_Name.TabIndex = 126;
            this.lbl_Name.Text = "이름";
            // 
            // lbl_Pwd
            // 
            this.lbl_Pwd.Location = new System.Drawing.Point(23, 61);
            this.lbl_Pwd.Name = "lbl_Pwd";
            this.lbl_Pwd.Size = new System.Drawing.Size(80, 16);
            this.lbl_Pwd.TabIndex = 125;
            this.lbl_Pwd.Text = "비밀번호";
            // 
            // lbl_ID
            // 
            this.lbl_ID.Location = new System.Drawing.Point(23, 18);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(80, 16);
            this.lbl_ID.TabIndex = 123;
            this.lbl_ID.Text = "아이디";
            // 
            // EditMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 363);
            this.Controls.Add(this.txt_Zip2);
            this.Controls.Add(this.txt_Zip1);
            this.Controls.Add(this.txt_NickName);
            this.Controls.Add(this.txt_Addr);
            this.Controls.Add(this.txt_Intro);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.txt_Tel);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.txt_Pwd);
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.btn_Zip);
            this.Controls.Add(this.lbl_Dash2);
            this.Controls.Add(this.lbl_Zip);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.lbl_NickName);
            this.Controls.Add(this.lbl_Example);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.lbl_Intro);
            this.Controls.Add(this.lbl_Addr);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.lbl_Tel);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.lbl_Pwd);
            this.Controls.Add(this.lbl_ID);
            this.Name = "EditMember";
            this.Text = "회원 정보 수정";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Zip2;
        private System.Windows.Forms.TextBox txt_Zip1;
        private System.Windows.Forms.TextBox txt_NickName;
        private System.Windows.Forms.TextBox txt_Addr;
        private System.Windows.Forms.TextBox txt_Intro;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_Tel;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_Pwd;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.Button btn_Zip;
        private System.Windows.Forms.Label lbl_Dash2;
        private System.Windows.Forms.Label lbl_Zip;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_NickName;
        private System.Windows.Forms.Label lbl_Example;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Label lbl_Intro;
        private System.Windows.Forms.Label lbl_Addr;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_Tel;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_Pwd;
        private System.Windows.Forms.Label lbl_ID;
    }
}