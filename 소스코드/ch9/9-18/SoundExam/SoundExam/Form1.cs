using System;
using System.Drawing;
using System.Media;     // Sound 클래스
using System.Threading;
using System.Windows.Forms;

namespace SoundExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_SystemSound_Click(object sender, EventArgs e)
        {
            SystemSounds.Asterisk.Play();
            SystemSound obj = SystemSounds.Question;
            obj.Play();
            /*
            Thread.Sleep(1000);
            SystemSounds.Beep.Play();
            Thread.Sleep(1000);
            SystemSounds.Exclamation.Play();
            Thread.Sleep(1000);
            SystemSounds.Hand.Play();
            Thread.Sleep(1000);
            SystemSounds.Question.Play();
            */ 
        }

        private void btn_WavePlay_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer();

            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {                
                player.SoundLocation = dlg.FileName;
                player.Load();
                player.PlaySync();
                btn_WaveSyncPlay.Text = "파일 로딩...";
            }
        }

        private void btn_WaveAsyncPlay_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer();

            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                player.SoundLocation = dlg.FileName;
                player.LoadAsync();
                player.Play();
                btn_WaveAsyncPlay.Text = "파일 로딩...";
            }
        }

        private void btn_WaveAsyncPlayLoop_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer();

            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                player.SoundLocation = dlg.FileName;
                player.LoadAsync();
                player.PlayLooping();
                btn_WaveAsyncPlay.Text = "파일 로딩...";
            }
        }
    }
}