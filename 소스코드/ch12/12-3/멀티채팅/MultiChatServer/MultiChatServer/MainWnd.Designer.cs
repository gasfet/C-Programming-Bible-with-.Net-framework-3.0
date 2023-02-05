namespace MultiChatServer
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
            this.txt_Broadcast = new System.Windows.Forms.TextBox();
            this.btn_Broadcast = new System.Windows.Forms.Button();
            this.tab_Info = new System.Windows.Forms.TabPage();
            this.txt_Info = new System.Windows.Forms.TextBox();
            this.lst_View = new System.Windows.Forms.ListView();
            this.btn_Start = new System.Windows.Forms.Button();
            this.tab_Connect = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab_Info.SuspendLayout();
            this.tab_Connect.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Broadcast
            // 
            this.txt_Broadcast.Location = new System.Drawing.Point(8, 216);
            this.txt_Broadcast.Name = "txt_Broadcast";
            this.txt_Broadcast.Size = new System.Drawing.Size(280, 21);
            this.txt_Broadcast.TabIndex = 2;
            // 
            // btn_Broadcast
            // 
            this.btn_Broadcast.Location = new System.Drawing.Point(8, 240);
            this.btn_Broadcast.Name = "btn_Broadcast";
            this.btn_Broadcast.Size = new System.Drawing.Size(280, 24);
            this.btn_Broadcast.TabIndex = 1;
            this.btn_Broadcast.Text = "방송";
            this.btn_Broadcast.Click += new System.EventHandler(this.btn_Broadcast_Click);
            // 
            // tab_Info
            // 
            this.tab_Info.Controls.Add(this.txt_Info);
            this.tab_Info.Location = new System.Drawing.Point(4, 21);
            this.tab_Info.Name = "tab_Info";
            this.tab_Info.Size = new System.Drawing.Size(296, 271);
            this.tab_Info.TabIndex = 1;
            this.tab_Info.Text = "접속 로그";
            // 
            // txt_Info
            // 
            this.txt_Info.Location = new System.Drawing.Point(8, 8);
            this.txt_Info.Multiline = true;
            this.txt_Info.Name = "txt_Info";
            this.txt_Info.ReadOnly = true;
            this.txt_Info.Size = new System.Drawing.Size(280, 256);
            this.txt_Info.TabIndex = 0;
            // 
            // lst_View
            // 
            this.lst_View.Location = new System.Drawing.Point(8, 8);
            this.lst_View.Name = "lst_View";
            this.lst_View.Size = new System.Drawing.Size(280, 200);
            this.lst_View.TabIndex = 0;
            this.lst_View.UseCompatibleStateImageBehavior = false;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(8, 314);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(304, 48);
            this.btn_Start.TabIndex = 3;
            this.btn_Start.Text = "서버 시작";
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // tab_Connect
            // 
            this.tab_Connect.Controls.Add(this.txt_Broadcast);
            this.tab_Connect.Controls.Add(this.btn_Broadcast);
            this.tab_Connect.Controls.Add(this.lst_View);
            this.tab_Connect.Location = new System.Drawing.Point(4, 21);
            this.tab_Connect.Name = "tab_Connect";
            this.tab_Connect.Size = new System.Drawing.Size(296, 271);
            this.tab_Connect.TabIndex = 0;
            this.tab_Connect.Text = "접속 정보";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tab_Connect);
            this.tabControl.Controls.Add(this.tab_Info);
            this.tabControl.Location = new System.Drawing.Point(8, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(304, 296);
            this.tabControl.TabIndex = 4;
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 373);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.tabControl);
            this.Name = "MainWnd";
            this.Text = "멀티채팅서버";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWnd_FormClosed);
            this.Load += new System.EventHandler(this.MainWnd_Load);
            this.tab_Info.ResumeLayout(false);
            this.tab_Info.PerformLayout();
            this.tab_Connect.ResumeLayout(false);
            this.tab_Connect.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Broadcast;
        private System.Windows.Forms.Button btn_Broadcast;
        private System.Windows.Forms.TabPage tab_Info;
        private System.Windows.Forms.TextBox txt_Info;
        private System.Windows.Forms.ListView lst_View;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.TabPage tab_Connect;
        private System.Windows.Forms.TabControl tabControl;
    }
}

