namespace MessengerClient
{
    partial class AboutWnd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutWnd));
            this.link_Homepage = new System.Windows.Forms.LinkLabel();
            this.link_Emal = new System.Windows.Forms.LinkLabel();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // link_Homepage
            // 
            this.link_Homepage.LinkVisited = true;
            this.link_Homepage.Location = new System.Drawing.Point(12, 150);
            this.link_Homepage.Name = "link_Homepage";
            this.link_Homepage.Size = new System.Drawing.Size(264, 16);
            this.link_Homepage.TabIndex = 8;
            this.link_Homepage.TabStop = true;
            this.link_Homepage.Text = "Homepage: www.magicsoft.pe.kr";
            this.link_Homepage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_Homepage_LinkClicked);
            // 
            // link_Emal
            // 
            this.link_Emal.LinkVisited = true;
            this.link_Emal.Location = new System.Drawing.Point(14, 126);
            this.link_Emal.Name = "link_Emal";
            this.link_Emal.Size = new System.Drawing.Size(264, 16);
            this.link_Emal.TabIndex = 7;
            this.link_Emal.TabStop = true;
            this.link_Emal.Text = "Email: magicsoft@empal.com";
            this.link_Emal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_Emal_LinkClicked);
            // 
            // lbl_Info
            // 
            this.lbl_Info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Info.Location = new System.Drawing.Point(14, 14);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(264, 104);
            this.lbl_Info.TabIndex = 6;
            this.lbl_Info.Text = resources.GetString("lbl_Info.Text");
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(6, 182);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(280, 24);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "확      인";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // AboutWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 220);
            this.Controls.Add(this.link_Homepage);
            this.Controls.Add(this.link_Emal);
            this.Controls.Add(this.lbl_Info);
            this.Controls.Add(this.btn_Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AboutWnd";
            this.Text = "메신저 정보 2006.11 ver1.1";
            this.Load += new System.EventHandler(this.AboutWnd_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel link_Homepage;
        private System.Windows.Forms.LinkLabel link_Emal;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.Button btn_Close;
    }
}