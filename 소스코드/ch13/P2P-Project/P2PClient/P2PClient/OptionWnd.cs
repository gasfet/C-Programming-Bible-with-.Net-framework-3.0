using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Threading;

namespace P2PClient
{
    /// <summary>
    /// 공유 다운로드 디렉토리 지정 옵션창
    /// OptionWnd 에 대한 요약 설명입니다.
    /// </summary>
    public partial class OptionWnd : Form
    {
        delegate void InvokeSetLabelText();        

        int bSelectButton = -1;  // share or down 버튼

        MainWnd client = null;   // 클라이언트 인스턴스 

        /// <summary>
        /// OptionWnd 생성자
        /// 파일 공유, 저장 디렉토리는 Client에 있으므로 
        /// 값을 사용하기 위해서 Client인자 필요함
        /// </summary>
        /// <param name="client">MainWnd 인자</param>
        public OptionWnd(MainWnd client) 
        {
            InitializeComponent();
            this.client = client; 
        }

        /// <summary>
        /// 공유 저장 디렉토리 창이 뜨기 직전에 실행될 구문
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionWnd_Load(object sender, EventArgs e)
        {
            this.lbl_share.Text = this.client.sharedirectory;
            this.lbl_down.Text = this.client.downdirectory;
        }


        /// <summary>
        ///  창 오른쪽 모서리의 X 를 누르면 또는 창이 닫힐때 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.client.sharedirectory = lbl_share.Text.Trim();  // 공유 디렉토리 저장
            this.client.downdirectory = lbl_down.Text.Trim();   // 다운로드 디렉토리 저장

        }

        /// <summary>
        /// 확인 버튼을 클릭하면 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            // 현재 창을 닫음
            this.Close();
        }

        /// <summary>
        /// 공유 디렉토리 설정 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void btn_share_Click(object sender, EventArgs e)
        {
            this.bSelectButton = 1;

            Thread thread = new Thread(new ThreadStart(ShowFolderBrowser));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            SetLabelText();
        }


        /// <summary>
        /// 다운로드 디렉토리 설정 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_down_Click(object sender, EventArgs e)
        {
            this.bSelectButton = 2;

            Thread thread = new Thread(new ThreadStart(ShowFolderBrowser));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            SetLabelText();
        }

        private void ShowFolderBrowser()
        {
            using (FolderBrowserDialog folder = new FolderBrowserDialog())
            {
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    if (this.bSelectButton == 1)
                        this.client.sharedirectory = folder.SelectedPath.Trim();
                    else if (this.bSelectButton == 2)
                        this.client.downdirectory = folder.SelectedPath.Trim();
                }
            }
        }

        private void SetLabelText()
        {
            if (this.bSelectButton == 1)
                this.lbl_share.Text = this.client.sharedirectory;
            else if (this.bSelectButton == 2)
                this.lbl_down.Text = this.client.downdirectory;            
        }
    }
}