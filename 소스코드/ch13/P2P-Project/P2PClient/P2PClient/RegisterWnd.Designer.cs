namespace P2PClient
{
    partial class RegisterWnd
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
            this.btn_id = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_register = new System.Windows.Forms.Button();
            this.lbl_pwd_ok = new System.Windows.Forms.Label();
            this.txt_pwd_ok = new System.Windows.Forms.TextBox();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_pwd = new System.Windows.Forms.Label();
            this.lbl_id = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_id
            // 
            this.btn_id.Location = new System.Drawing.Point(59, 54);
            this.btn_id.Name = "btn_id";
            this.btn_id.Size = new System.Drawing.Size(200, 23);
            this.btn_id.TabIndex = 9;
            this.btn_id.Text = "아이디 중복 검사";
            this.btn_id.Click += new System.EventHandler(this.btn_id_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(163, 198);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(96, 23);
            this.btn_reset.TabIndex = 17;
            this.btn_reset.Text = "다시쓰기";
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_register
            // 
            this.btn_register.Location = new System.Drawing.Point(35, 198);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(88, 23);
            this.btn_register.TabIndex = 15;
            this.btn_register.Text = "회원가입";
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // lbl_pwd_ok
            // 
            this.lbl_pwd_ok.Location = new System.Drawing.Point(35, 126);
            this.lbl_pwd_ok.Name = "lbl_pwd_ok";
            this.lbl_pwd_ok.Size = new System.Drawing.Size(100, 23);
            this.lbl_pwd_ok.TabIndex = 18;
            this.lbl_pwd_ok.Text = "비밀확인";
            // 
            // txt_pwd_ok
            // 
            this.txt_pwd_ok.Location = new System.Drawing.Point(155, 126);
            this.txt_pwd_ok.Name = "txt_pwd_ok";
            this.txt_pwd_ok.PasswordChar = '*';
            this.txt_pwd_ok.Size = new System.Drawing.Size(100, 21);
            this.txt_pwd_ok.TabIndex = 12;
            // 
            // lbl_email
            // 
            this.lbl_email.Location = new System.Drawing.Point(35, 158);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(100, 23);
            this.lbl_email.TabIndex = 16;
            this.lbl_email.Text = "E-mail 주소";
            // 
            // lbl_pwd
            // 
            this.lbl_pwd.Location = new System.Drawing.Point(35, 94);
            this.lbl_pwd.Name = "lbl_pwd";
            this.lbl_pwd.Size = new System.Drawing.Size(100, 23);
            this.lbl_pwd.TabIndex = 13;
            this.lbl_pwd.Text = "비밀번호";
            // 
            // lbl_id
            // 
            this.lbl_id.Location = new System.Drawing.Point(35, 22);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(100, 23);
            this.lbl_id.TabIndex = 11;
            this.lbl_id.Text = "가입 아이디";
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(155, 158);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(100, 21);
            this.txt_email.TabIndex = 14;
            // 
            // txt_pwd
            // 
            this.txt_pwd.Location = new System.Drawing.Point(155, 94);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.PasswordChar = '*';
            this.txt_pwd.Size = new System.Drawing.Size(100, 21);
            this.txt_pwd.TabIndex = 10;
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(155, 22);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(100, 21);
            this.txt_id.TabIndex = 8;
            // 
            // RegisterWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 243);
            this.Controls.Add(this.btn_id);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.lbl_pwd_ok);
            this.Controls.Add(this.txt_pwd_ok);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_pwd);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.txt_id);
            this.Name = "RegisterWnd";
            this.Text = "회원가입";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_id;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Label lbl_pwd_ok;
        private System.Windows.Forms.TextBox txt_pwd_ok;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_pwd;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.TextBox txt_id;
    }
}