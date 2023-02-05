namespace SMTP_Exam
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
            this.btn_AttachPath = new System.Windows.Forms.Button();
            this.txt_Attach_Path = new System.Windows.Forms.TextBox();
            this.lbl_Attach = new System.Windows.Forms.Label();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.lbl_Body = new System.Windows.Forms.Label();
            this.txt_Body = new System.Windows.Forms.TextBox();
            this.lbl_From = new System.Windows.Forms.Label();
            this.txt_From = new System.Windows.Forms.TextBox();
            this.lbl_Subject = new System.Windows.Forms.Label();
            this.txt_Subject = new System.Windows.Forms.TextBox();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Send = new System.Windows.Forms.Button();
            this.lbl_To = new System.Windows.Forms.Label();
            this.txt_To = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_AttachPath
            // 
            this.btn_AttachPath.Location = new System.Drawing.Point(279, 308);
            this.btn_AttachPath.Name = "btn_AttachPath";
            this.btn_AttachPath.Size = new System.Drawing.Size(56, 23);
            this.btn_AttachPath.TabIndex = 49;
            this.btn_AttachPath.Text = "선택";
            this.btn_AttachPath.Click += new System.EventHandler(this.btn_AttachPath_Click);
            // 
            // txt_Attach_Path
            // 
            this.txt_Attach_Path.Location = new System.Drawing.Point(79, 308);
            this.txt_Attach_Path.Name = "txt_Attach_Path";
            this.txt_Attach_Path.Size = new System.Drawing.Size(192, 21);
            this.txt_Attach_Path.TabIndex = 48;
            // 
            // lbl_Attach
            // 
            this.lbl_Attach.Location = new System.Drawing.Point(15, 312);
            this.lbl_Attach.Name = "lbl_Attach";
            this.lbl_Attach.Size = new System.Drawing.Size(64, 16);
            this.lbl_Attach.TabIndex = 47;
            this.lbl_Attach.Text = "첨부파일";
            // 
            // lbl_Info
            // 
            this.lbl_Info.Location = new System.Drawing.Point(79, 16);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(208, 23);
            this.lbl_Info.TabIndex = 46;
            this.lbl_Info.Text = "메일 발송하기";
            // 
            // lbl_Body
            // 
            this.lbl_Body.Location = new System.Drawing.Point(15, 176);
            this.lbl_Body.Name = "lbl_Body";
            this.lbl_Body.Size = new System.Drawing.Size(48, 23);
            this.lbl_Body.TabIndex = 45;
            this.lbl_Body.Text = "내용";
            // 
            // txt_Body
            // 
            this.txt_Body.Location = new System.Drawing.Point(79, 176);
            this.txt_Body.Multiline = true;
            this.txt_Body.Name = "txt_Body";
            this.txt_Body.Size = new System.Drawing.Size(248, 120);
            this.txt_Body.TabIndex = 40;
            // 
            // lbl_From
            // 
            this.lbl_From.Location = new System.Drawing.Point(15, 96);
            this.lbl_From.Name = "lbl_From";
            this.lbl_From.Size = new System.Drawing.Size(56, 23);
            this.lbl_From.TabIndex = 44;
            this.lbl_From.Text = "보내는이";
            // 
            // txt_From
            // 
            this.txt_From.Location = new System.Drawing.Point(79, 96);
            this.txt_From.Name = "txt_From";
            this.txt_From.Size = new System.Drawing.Size(248, 21);
            this.txt_From.TabIndex = 37;
            // 
            // lbl_Subject
            // 
            this.lbl_Subject.Location = new System.Drawing.Point(15, 136);
            this.lbl_Subject.Name = "lbl_Subject";
            this.lbl_Subject.Size = new System.Drawing.Size(56, 23);
            this.lbl_Subject.TabIndex = 43;
            this.lbl_Subject.Text = "제목";
            // 
            // txt_Subject
            // 
            this.txt_Subject.Location = new System.Drawing.Point(79, 136);
            this.txt_Subject.Name = "txt_Subject";
            this.txt_Subject.Size = new System.Drawing.Size(248, 21);
            this.txt_Subject.TabIndex = 39;
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(199, 344);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(120, 23);
            this.btn_Reset.TabIndex = 42;
            this.btn_Reset.Text = "다시 쓰기";
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(47, 344);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(120, 23);
            this.btn_Send.TabIndex = 41;
            this.btn_Send.Text = "메일 발송";
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // lbl_To
            // 
            this.lbl_To.Location = new System.Drawing.Point(15, 56);
            this.lbl_To.Name = "lbl_To";
            this.lbl_To.Size = new System.Drawing.Size(56, 23);
            this.lbl_To.TabIndex = 38;
            this.lbl_To.Text = "받는이";
            // 
            // txt_To
            // 
            this.txt_To.Location = new System.Drawing.Point(79, 56);
            this.txt_To.Name = "txt_To";
            this.txt_To.Size = new System.Drawing.Size(248, 21);
            this.txt_To.TabIndex = 36;
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 382);
            this.Controls.Add(this.btn_AttachPath);
            this.Controls.Add(this.txt_Attach_Path);
            this.Controls.Add(this.lbl_Attach);
            this.Controls.Add(this.lbl_Info);
            this.Controls.Add(this.lbl_Body);
            this.Controls.Add(this.txt_Body);
            this.Controls.Add(this.lbl_From);
            this.Controls.Add(this.txt_From);
            this.Controls.Add(this.lbl_Subject);
            this.Controls.Add(this.txt_Subject);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.lbl_To);
            this.Controls.Add(this.txt_To);
            this.Name = "MainWnd";
            this.Text = "전자 메일 보내기";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_AttachPath;
        private System.Windows.Forms.TextBox txt_Attach_Path;
        private System.Windows.Forms.Label lbl_Attach;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.Label lbl_Body;
        private System.Windows.Forms.TextBox txt_Body;
        private System.Windows.Forms.Label lbl_From;
        private System.Windows.Forms.TextBox txt_From;
        private System.Windows.Forms.Label lbl_Subject;
        private System.Windows.Forms.TextBox txt_Subject;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Label lbl_To;
        private System.Windows.Forms.TextBox txt_To;
    }
}

