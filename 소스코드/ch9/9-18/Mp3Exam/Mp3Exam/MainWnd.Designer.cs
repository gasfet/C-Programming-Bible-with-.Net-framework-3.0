namespace Mp3Exam
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBar_volume = new System.Windows.Forms.TrackBar();
            this.trackBar_time = new System.Windows.Forms.TrackBar();
            this.lbl_filename = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_stop = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_end = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.lbl_time = new System.Windows.Forms.Label();
            this.btn_eject = new System.Windows.Forms.Button();
            this.axMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.btn_list = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_time)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar_volume
            // 
            this.trackBar_volume.Location = new System.Drawing.Point(308, 47);
            this.trackBar_volume.Name = "trackBar_volume";
            this.trackBar_volume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_volume.Size = new System.Drawing.Size(45, 95);
            this.trackBar_volume.TabIndex = 18;
            this.trackBar_volume.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // trackBar_time
            // 
            this.trackBar_time.Location = new System.Drawing.Point(12, 47);
            this.trackBar_time.Name = "trackBar_time";
            this.trackBar_time.Size = new System.Drawing.Size(290, 45);
            this.trackBar_time.TabIndex = 17;
            this.trackBar_time.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // lbl_filename
            // 
            this.lbl_filename.AutoSize = true;
            this.lbl_filename.BackColor = System.Drawing.Color.Black;
            this.lbl_filename.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_filename.ForeColor = System.Drawing.Color.White;
            this.lbl_filename.Location = new System.Drawing.Point(124, 10);
            this.lbl_filename.Name = "lbl_filename";
            this.lbl_filename.Size = new System.Drawing.Size(227, 21);
            this.lbl_filename.TabIndex = 16;
            this.lbl_filename.Text = "노래가사 스크롤되게...";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.btn_stop);
            this.panel1.Controls.Add(this.btn_start);
            this.panel1.Controls.Add(this.btn_play);
            this.panel1.Controls.Add(this.btn_end);
            this.panel1.Controls.Add(this.btn_pause);
            this.panel1.Location = new System.Drawing.Point(21, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 38);
            this.panel1.TabIndex = 15;
            // 
            // btn_stop
            // 
            this.btn_stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_stop.ImageIndex = 11;
            this.btn_stop.ImageList = this.imageList1;
            this.btn_stop.Location = new System.Drawing.Point(121, 3);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(32, 32);
            this.btn_stop.TabIndex = 4;
            this.btn_stop.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "start_up.bmp");
            this.imageList1.Images.SetKeyName(1, "start_down.bmp");
            this.imageList1.Images.SetKeyName(2, "start_normal.bmp");
            this.imageList1.Images.SetKeyName(3, "play_up.bmp");
            this.imageList1.Images.SetKeyName(4, "play_down.bmp");
            this.imageList1.Images.SetKeyName(5, "play_normal.bmp");
            this.imageList1.Images.SetKeyName(6, "pause_up.bmp");
            this.imageList1.Images.SetKeyName(7, "pause_down.bmp");
            this.imageList1.Images.SetKeyName(8, "pause_normal.bmp");
            this.imageList1.Images.SetKeyName(9, "stop_up.bmp");
            this.imageList1.Images.SetKeyName(10, "stop_down.bmp");
            this.imageList1.Images.SetKeyName(11, "stop_normal.bmp");
            this.imageList1.Images.SetKeyName(12, "end_up.bmp");
            this.imageList1.Images.SetKeyName(13, "end_down.bmp");
            this.imageList1.Images.SetKeyName(14, "end_normal.bmp");
            this.imageList1.Images.SetKeyName(15, "eject_up.bmp");
            this.imageList1.Images.SetKeyName(16, "eject_down.bmp");
            this.imageList1.Images.SetKeyName(17, "eject_normal.bmp");
            this.imageList1.Images.SetKeyName(18, "list_up.bmp");
            this.imageList1.Images.SetKeyName(19, "list_down.bmp");
            // 
            // btn_start
            // 
            this.btn_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_start.ImageIndex = 2;
            this.btn_start.ImageList = this.imageList1;
            this.btn_start.Location = new System.Drawing.Point(7, 3);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(32, 32);
            this.btn_start.TabIndex = 1;
            this.btn_start.UseVisualStyleBackColor = true;
            // 
            // btn_play
            // 
            this.btn_play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_play.ImageIndex = 5;
            this.btn_play.ImageList = this.imageList1;
            this.btn_play.Location = new System.Drawing.Point(45, 3);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(32, 32);
            this.btn_play.TabIndex = 2;
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // btn_end
            // 
            this.btn_end.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_end.ImageIndex = 14;
            this.btn_end.ImageList = this.imageList1;
            this.btn_end.Location = new System.Drawing.Point(159, 3);
            this.btn_end.Name = "btn_end";
            this.btn_end.Size = new System.Drawing.Size(32, 32);
            this.btn_end.TabIndex = 5;
            this.btn_end.UseVisualStyleBackColor = true;
            // 
            // btn_pause
            // 
            this.btn_pause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_pause.ImageIndex = 8;
            this.btn_pause.ImageList = this.imageList1;
            this.btn_pause.Location = new System.Drawing.Point(83, 3);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(32, 32);
            this.btn_pause.TabIndex = 3;
            this.btn_pause.UseVisualStyleBackColor = true;
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.BackColor = System.Drawing.SystemColors.ControlText;
            this.lbl_time.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbl_time.Location = new System.Drawing.Point(28, 10);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(98, 21);
            this.lbl_time.TabIndex = 14;
            this.lbl_time.Text = "00:00:00";
            // 
            // btn_eject
            // 
            this.btn_eject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_eject.ImageIndex = 17;
            this.btn_eject.ImageList = this.imageList1;
            this.btn_eject.Location = new System.Drawing.Point(229, 109);
            this.btn_eject.Name = "btn_eject";
            this.btn_eject.Size = new System.Drawing.Size(32, 35);
            this.btn_eject.TabIndex = 13;
            this.btn_eject.UseVisualStyleBackColor = true;
            // 
            // axMediaPlayer
            // 
            this.axMediaPlayer.Enabled = true;
            this.axMediaPlayer.Location = new System.Drawing.Point(278, 151);
            this.axMediaPlayer.Name = "axMediaPlayer";
            this.axMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMediaPlayer.OcxState")));
            this.axMediaPlayer.Size = new System.Drawing.Size(75, 23);
            this.axMediaPlayer.TabIndex = 12;
            this.axMediaPlayer.Visible = false;
            // 
            // btn_list
            // 
            this.btn_list.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_list.ImageIndex = 18;
            this.btn_list.ImageList = this.imageList1;
            this.btn_list.Location = new System.Drawing.Point(267, 109);
            this.btn_list.Name = "btn_list";
            this.btn_list.Size = new System.Drawing.Size(32, 35);
            this.btn_list.TabIndex = 19;
            this.btn_list.UseVisualStyleBackColor = true;
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(380, 169);
            this.Controls.Add(this.btn_list);
            this.Controls.Add(this.trackBar_volume);
            this.Controls.Add(this.trackBar_time);
            this.Controls.Add(this.lbl_filename);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.btn_eject);
            this.Controls.Add(this.axMediaPlayer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWnd";
            this.Text = "Mp3 Player 1.0";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_time)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBar_volume;
        private System.Windows.Forms.TrackBar trackBar_time;
        private System.Windows.Forms.Label lbl_filename;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_end;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Button btn_eject;
        private AxWMPLib.AxWindowsMediaPlayer axMediaPlayer;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_list;

    }
}