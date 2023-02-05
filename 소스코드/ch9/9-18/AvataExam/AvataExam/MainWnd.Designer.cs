namespace AvataExam
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
            this.checkBox_Body = new System.Windows.Forms.CheckBox();
            this.btn_AvataCreate = new System.Windows.Forms.Button();
            this.radio_Pants = new System.Windows.Forms.RadioButton();
            this.radio_Shirt = new System.Windows.Forms.RadioButton();
            this.btn_Right = new System.Windows.Forms.Button();
            this.btn_Left = new System.Windows.Forms.Button();
            this.pBox_Sample = new System.Windows.Forms.PictureBox();
            this.pBox_Main = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Sample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_Body
            // 
            this.checkBox_Body.Location = new System.Drawing.Point(268, 235);
            this.checkBox_Body.Name = "checkBox_Body";
            this.checkBox_Body.Size = new System.Drawing.Size(104, 24);
            this.checkBox_Body.TabIndex = 16;
            this.checkBox_Body.Text = "몸 형태 변경";
            this.checkBox_Body.CheckedChanged += new System.EventHandler(this.checkBox_Body_CheckedChanged);
            // 
            // btn_AvataCreate
            // 
            this.btn_AvataCreate.Location = new System.Drawing.Point(44, 227);
            this.btn_AvataCreate.Name = "btn_AvataCreate";
            this.btn_AvataCreate.Size = new System.Drawing.Size(176, 40);
            this.btn_AvataCreate.TabIndex = 15;
            this.btn_AvataCreate.Text = "아바타 이미지 생성";
            this.btn_AvataCreate.Click += new System.EventHandler(this.btn_AvataCreate_Click);
            // 
            // radio_Pants
            // 
            this.radio_Pants.Location = new System.Drawing.Point(308, 187);
            this.radio_Pants.Name = "radio_Pants";
            this.radio_Pants.Size = new System.Drawing.Size(104, 24);
            this.radio_Pants.TabIndex = 14;
            this.radio_Pants.Text = "하의 선택하기";
            // 
            // radio_Shirt
            // 
            this.radio_Shirt.Checked = true;
            this.radio_Shirt.Location = new System.Drawing.Point(308, 155);
            this.radio_Shirt.Name = "radio_Shirt";
            this.radio_Shirt.Size = new System.Drawing.Size(104, 24);
            this.radio_Shirt.TabIndex = 13;
            this.radio_Shirt.TabStop = true;
            this.radio_Shirt.Text = "상의 선택하기";
            // 
            // btn_Right
            // 
            this.btn_Right.Location = new System.Drawing.Point(420, 75);
            this.btn_Right.Name = "btn_Right";
            this.btn_Right.Size = new System.Drawing.Size(32, 32);
            this.btn_Right.TabIndex = 12;
            this.btn_Right.Text = "▶";
            this.btn_Right.Click += new System.EventHandler(this.btn_Right_Click);
            // 
            // btn_Left
            // 
            this.btn_Left.Location = new System.Drawing.Point(268, 75);
            this.btn_Left.Name = "btn_Left";
            this.btn_Left.Size = new System.Drawing.Size(32, 32);
            this.btn_Left.TabIndex = 11;
            this.btn_Left.Text = "◀";
            this.btn_Left.Click += new System.EventHandler(this.btn_Left_Click);
            // 
            // pBox_Sample
            // 
            this.pBox_Sample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBox_Sample.Location = new System.Drawing.Point(308, 43);
            this.pBox_Sample.Name = "pBox_Sample";
            this.pBox_Sample.Size = new System.Drawing.Size(104, 96);
            this.pBox_Sample.TabIndex = 10;
            this.pBox_Sample.TabStop = false;
            // 
            // pBox_Main
            // 
            this.pBox_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBox_Main.Location = new System.Drawing.Point(92, 19);
            this.pBox_Main.Name = "pBox_Main";
            this.pBox_Main.Size = new System.Drawing.Size(98, 195);
            this.pBox_Main.TabIndex = 9;
            this.pBox_Main.TabStop = false;
            this.pBox_Main.Paint += new System.Windows.Forms.PaintEventHandler(this.pBox_Main_Paint);
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 286);
            this.Controls.Add(this.checkBox_Body);
            this.Controls.Add(this.btn_AvataCreate);
            this.Controls.Add(this.radio_Pants);
            this.Controls.Add(this.radio_Shirt);
            this.Controls.Add(this.btn_Right);
            this.Controls.Add(this.btn_Left);
            this.Controls.Add(this.pBox_Sample);
            this.Controls.Add(this.pBox_Main);
            this.Name = "MainWnd";
            this.Text = "아바타 이미지 만들기 ver 1.0";
            this.Load += new System.EventHandler(this.MainWnd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Sample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_Body;
        private System.Windows.Forms.Button btn_AvataCreate;
        private System.Windows.Forms.RadioButton radio_Pants;
        private System.Windows.Forms.RadioButton radio_Shirt;
        private System.Windows.Forms.Button btn_Right;
        private System.Windows.Forms.Button btn_Left;
        private System.Windows.Forms.PictureBox pBox_Sample;
        private System.Windows.Forms.PictureBox pBox_Main;

    }
}

