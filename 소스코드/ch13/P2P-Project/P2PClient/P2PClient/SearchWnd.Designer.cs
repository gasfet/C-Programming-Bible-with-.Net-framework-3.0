namespace P2PClient
{
    partial class SearchWnd
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
            this.lstView = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_message = new System.Windows.Forms.TextBox();
            this.txt_file = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menu = new System.Windows.Forms.MainMenu(this.components);
            this.cmb_ext = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pgb_search = new System.Windows.Forms.ProgressBar();
            this.stb_text = new System.Windows.Forms.StatusBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_select = new System.Windows.Forms.Button();
            this.lbl_ext = new System.Windows.Forms.Label();
            this.lbl_file = new System.Windows.Forms.Label();
            this.tab_ctl = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tab_ctl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstView
            // 
            this.lstView.Location = new System.Drawing.Point(8, 8);
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(528, 184);
            this.lstView.TabIndex = 0;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.DoubleClick += new System.EventHandler(this.lstView_DoubleClick);
            this.lstView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstView_ColumnClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_message);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(542, 299);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "수신데이터";
            // 
            // txt_message
            // 
            this.txt_message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_message.Location = new System.Drawing.Point(0, 0);
            this.txt_message.Multiline = true;
            this.txt_message.Name = "txt_message";
            this.txt_message.ReadOnly = true;
            this.txt_message.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_message.Size = new System.Drawing.Size(542, 299);
            this.txt_message.TabIndex = 0;
            // 
            // txt_file
            // 
            this.txt_file.Location = new System.Drawing.Point(8, 40);
            this.txt_file.Name = "txt_file";
            this.txt_file.Size = new System.Drawing.Size(216, 21);
            this.txt_file.TabIndex = 1;
            this.txt_file.Text = "*";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(344, 24);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(96, 40);
            this.btn_search.TabIndex = 0;
            this.btn_search.Text = "검색";
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2});
            this.menuItem1.Text = "설정사항";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "공유폴더 지정";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menu
            // 
            this.menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // cmb_ext
            // 
            this.cmb_ext.Location = new System.Drawing.Point(232, 40);
            this.cmb_ext.Name = "cmb_ext";
            this.cmb_ext.Size = new System.Drawing.Size(88, 20);
            this.cmb_ext.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pgb_search);
            this.tabPage1.Controls.Add(this.stb_text);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.lstView);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(542, 299);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "검색창";
            // 
            // pgb_search
            // 
            this.pgb_search.Location = new System.Drawing.Point(3, 280);
            this.pgb_search.Name = "pgb_search";
            this.pgb_search.Size = new System.Drawing.Size(528, 23);
            this.pgb_search.TabIndex = 3;
            // 
            // stb_text
            // 
            this.stb_text.Location = new System.Drawing.Point(0, 277);
            this.stb_text.Name = "stb_text";
            this.stb_text.Size = new System.Drawing.Size(542, 22);
            this.stb_text.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_select);
            this.groupBox1.Controls.Add(this.lbl_ext);
            this.groupBox1.Controls.Add(this.lbl_file);
            this.groupBox1.Controls.Add(this.cmb_ext);
            this.groupBox1.Controls.Add(this.txt_file);
            this.groupBox1.Controls.Add(this.btn_search);
            this.groupBox1.Location = new System.Drawing.Point(8, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "파일 검색";
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(448, 24);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(75, 40);
            this.btn_select.TabIndex = 5;
            this.btn_select.Text = "다운";
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // lbl_ext
            // 
            this.lbl_ext.Location = new System.Drawing.Point(232, 16);
            this.lbl_ext.Name = "lbl_ext";
            this.lbl_ext.Size = new System.Drawing.Size(100, 16);
            this.lbl_ext.TabIndex = 4;
            this.lbl_ext.Text = "파일 확장자";
            // 
            // lbl_file
            // 
            this.lbl_file.Location = new System.Drawing.Point(8, 16);
            this.lbl_file.Name = "lbl_file";
            this.lbl_file.Size = new System.Drawing.Size(136, 23);
            this.lbl_file.TabIndex = 3;
            this.lbl_file.Text = "검색할 파일이름";
            // 
            // tab_ctl
            // 
            this.tab_ctl.Controls.Add(this.tabPage1);
            this.tab_ctl.Controls.Add(this.tabPage2);
            this.tab_ctl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_ctl.Location = new System.Drawing.Point(0, 0);
            this.tab_ctl.Name = "tab_ctl";
            this.tab_ctl.SelectedIndex = 0;
            this.tab_ctl.Size = new System.Drawing.Size(550, 324);
            this.tab_ctl.TabIndex = 1;
            // 
            // SearchWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 324);
            this.Controls.Add(this.tab_ctl);
            this.Menu = this.menu;
            this.Name = "SearchWnd";
            this.Text = "P2P 파일 검색";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchWnd_FormClosing);
            this.Load += new System.EventHandler(this.SearchWnd_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tab_ctl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txt_message;
        private System.Windows.Forms.TextBox txt_file;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MainMenu menu;
        private System.Windows.Forms.ComboBox cmb_ext;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ProgressBar pgb_search;
        private System.Windows.Forms.StatusBar stb_text;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Label lbl_ext;
        private System.Windows.Forms.Label lbl_file;
        private System.Windows.Forms.TabControl tab_ctl;
    }
}