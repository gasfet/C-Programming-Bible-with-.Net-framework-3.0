namespace SoundExam
{
    partial class Form1
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
            this.btn_SystemSound = new System.Windows.Forms.Button();
            this.btn_WaveSyncPlay = new System.Windows.Forms.Button();
            this.btn_WaveAsyncPlay = new System.Windows.Forms.Button();
            this.btn_WaveAsyncPlayLoop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_SystemSound
            // 
            this.btn_SystemSound.Location = new System.Drawing.Point(59, 38);
            this.btn_SystemSound.Name = "btn_SystemSound";
            this.btn_SystemSound.Size = new System.Drawing.Size(143, 33);
            this.btn_SystemSound.TabIndex = 0;
            this.btn_SystemSound.Text = "시스템 사운드";
            this.btn_SystemSound.UseVisualStyleBackColor = true;
            this.btn_SystemSound.Click += new System.EventHandler(this.btn_SystemSound_Click);
            // 
            // btn_WaveSyncPlay
            // 
            this.btn_WaveSyncPlay.Location = new System.Drawing.Point(59, 86);
            this.btn_WaveSyncPlay.Name = "btn_WaveSyncPlay";
            this.btn_WaveSyncPlay.Size = new System.Drawing.Size(143, 31);
            this.btn_WaveSyncPlay.TabIndex = 1;
            this.btn_WaveSyncPlay.Text = "동기 wav 파일 재생";
            this.btn_WaveSyncPlay.UseVisualStyleBackColor = true;
            this.btn_WaveSyncPlay.Click += new System.EventHandler(this.btn_WavePlay_Click);
            // 
            // btn_WaveAsyncPlay
            // 
            this.btn_WaveAsyncPlay.Location = new System.Drawing.Point(59, 133);
            this.btn_WaveAsyncPlay.Name = "btn_WaveAsyncPlay";
            this.btn_WaveAsyncPlay.Size = new System.Drawing.Size(143, 31);
            this.btn_WaveAsyncPlay.TabIndex = 2;
            this.btn_WaveAsyncPlay.Text = "비동기 wav 파일 재생";
            this.btn_WaveAsyncPlay.UseVisualStyleBackColor = true;
            this.btn_WaveAsyncPlay.Click += new System.EventHandler(this.btn_WaveAsyncPlay_Click);
            // 
            // btn_WaveAsyncPlayLoop
            // 
            this.btn_WaveAsyncPlayLoop.Location = new System.Drawing.Point(59, 180);
            this.btn_WaveAsyncPlayLoop.Name = "btn_WaveAsyncPlayLoop";
            this.btn_WaveAsyncPlayLoop.Size = new System.Drawing.Size(143, 31);
            this.btn_WaveAsyncPlayLoop.TabIndex = 3;
            this.btn_WaveAsyncPlayLoop.Text = "비동기 wav 반복 재생";
            this.btn_WaveAsyncPlayLoop.UseVisualStyleBackColor = true;
            this.btn_WaveAsyncPlayLoop.Click += new System.EventHandler(this.btn_WaveAsyncPlayLoop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.btn_WaveAsyncPlayLoop);
            this.Controls.Add(this.btn_WaveAsyncPlay);
            this.Controls.Add(this.btn_WaveSyncPlay);
            this.Controls.Add(this.btn_SystemSound);
            this.Name = "Form1";
            this.Text = "사운드 재생하기";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_SystemSound;
        private System.Windows.Forms.Button btn_WaveSyncPlay;
        private System.Windows.Forms.Button btn_WaveAsyncPlay;
        private System.Windows.Forms.Button btn_WaveAsyncPlayLoop;
    }
}

