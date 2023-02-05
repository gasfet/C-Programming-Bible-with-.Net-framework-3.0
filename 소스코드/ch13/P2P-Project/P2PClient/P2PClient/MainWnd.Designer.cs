namespace P2PClient
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWnd));
            this.ctx_menu = new System.Windows.Forms.ContextMenu();
            this.ctx_show = new System.Windows.Forms.MenuItem();
            this.menuItem = new System.Windows.Forms.MenuItem();
            this.ctx_exit = new System.Windows.Forms.MenuItem();
            this.notify_Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.lbl_server = new System.Windows.Forms.Label();
            this.txt_server = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_register = new System.Windows.Forms.Button();
            this.btn_extend = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.lbl_pwd = new System.Windows.Forms.Label();
            this.lbl_id = new System.Windows.Forms.Label();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctx_menu
            // 
            this.ctx_menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ctx_show,
            this.menuItem,
            this.ctx_exit});
            // 
            // ctx_show
            // 
            this.ctx_show.Index = 0;
            this.ctx_show.Text = "검색창 보이기";
            this.ctx_show.Click += new System.EventHandler(this.ctx_show_Click);
            // 
            // menuItem
            // 
            this.menuItem.Index = 1;
            this.menuItem.Text = "-";
            // 
            // ctx_exit
            // 
            this.ctx_exit.Index = 2;
            this.ctx_exit.Text = "프로그램 종료";
            this.ctx_exit.Click += new System.EventHandler(this.ctx_exit_Click);
            // 
            // notify_Tray
            // 
            this.notify_Tray.ContextMenu = this.ctx_menu;
            this.notify_Tray.Icon = ((System.Drawing.Icon)(resources.GetObject("notify_Tray.Icon")));
            this.notify_Tray.Text = "Magic P2P";
            this.notify_Tray.Visible = true;
            this.notify_Tray.DoubleClick += new System.EventHandler(this.notify_Tray_DoubleClick);
            // 
            // lbl_server
            // 
            this.lbl_server.Location = new System.Drawing.Point(16, 24);
            this.lbl_server.Name = "lbl_server";
            this.lbl_server.Size = new System.Drawing.Size(56, 23);
            this.lbl_server.TabIndex = 1;
            this.lbl_server.Text = "서버IP";
            // 
            // txt_server
            // 
            this.txt_server.Location = new System.Drawing.Point(88, 24);
            this.txt_server.Name = "txt_server";
            this.txt_server.Size = new System.Drawing.Size(112, 21);
            this.txt_server.TabIndex = 0;
            this.txt_server.Text = "localhost";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_register);
            this.groupBox1.Controls.Add(this.lbl_server);
            this.groupBox1.Controls.Add(this.txt_server);
            this.groupBox1.Location = new System.Drawing.Point(3, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 104);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "고급옵션";
            // 
            // btn_register
            // 
            this.btn_register.Location = new System.Drawing.Point(16, 64);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(184, 23);
            this.btn_register.TabIndex = 2;
            this.btn_register.Text = "회원가입";
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // btn_extend
            // 
            this.btn_extend.Location = new System.Drawing.Point(179, 94);
            this.btn_extend.Name = "btn_extend";
            this.btn_extend.Size = new System.Drawing.Size(32, 24);
            this.btn_extend.TabIndex = 20;
            this.btn_extend.Text = "▼";
            this.btn_extend.Click += new System.EventHandler(this.btn_extend_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(19, 94);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(152, 24);
            this.btn_connect.TabIndex = 19;
            this.btn_connect.Text = "접속";
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // lbl_pwd
            // 
            this.lbl_pwd.Location = new System.Drawing.Point(11, 46);
            this.lbl_pwd.Name = "lbl_pwd";
            this.lbl_pwd.Size = new System.Drawing.Size(56, 16);
            this.lbl_pwd.TabIndex = 18;
            this.lbl_pwd.Text = "비밀번호";
            // 
            // lbl_id
            // 
            this.lbl_id.Location = new System.Drawing.Point(11, 14);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(56, 16);
            this.lbl_id.TabIndex = 17;
            this.lbl_id.Text = "아이디";
            // 
            // txt_pwd
            // 
            this.txt_pwd.Location = new System.Drawing.Point(91, 46);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.PasswordChar = '*';
            this.txt_pwd.Size = new System.Drawing.Size(112, 21);
            this.txt_pwd.TabIndex = 16;
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(91, 14);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(112, 21);
            this.txt_id.TabIndex = 15;
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 269);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_extend);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.lbl_pwd);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.txt_id);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWnd";
            this.Text = "Magic P2P";
            this.Load += new System.EventHandler(this.MainWnd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenu ctx_menu;
        private System.Windows.Forms.MenuItem ctx_show;
        private System.Windows.Forms.MenuItem menuItem;
        private System.Windows.Forms.MenuItem ctx_exit;
        public System.Windows.Forms.NotifyIcon notify_Tray;
        private System.Windows.Forms.Label lbl_server;
        private System.Windows.Forms.TextBox txt_server;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Button btn_extend;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Label lbl_pwd;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.TextBox txt_id;
    }
}

