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
    /// ���� �ٿ�ε� ���丮 ���� �ɼ�â
    /// OptionWnd �� ���� ��� �����Դϴ�.
    /// </summary>
    public partial class OptionWnd : Form
    {
        delegate void InvokeSetLabelText();        

        int bSelectButton = -1;  // share or down ��ư

        MainWnd client = null;   // Ŭ���̾�Ʈ �ν��Ͻ� 

        /// <summary>
        /// OptionWnd ������
        /// ���� ����, ���� ���丮�� Client�� �����Ƿ� 
        /// ���� ����ϱ� ���ؼ� Client���� �ʿ���
        /// </summary>
        /// <param name="client">MainWnd ����</param>
        public OptionWnd(MainWnd client) 
        {
            InitializeComponent();
            this.client = client; 
        }

        /// <summary>
        /// ���� ���� ���丮 â�� �߱� ������ ����� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionWnd_Load(object sender, EventArgs e)
        {
            this.lbl_share.Text = this.client.sharedirectory;
            this.lbl_down.Text = this.client.downdirectory;
        }


        /// <summary>
        ///  â ������ �𼭸��� X �� ������ �Ǵ� â�� ������ �߻��ϴ� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.client.sharedirectory = lbl_share.Text.Trim();  // ���� ���丮 ����
            this.client.downdirectory = lbl_down.Text.Trim();   // �ٿ�ε� ���丮 ����

        }

        /// <summary>
        /// Ȯ�� ��ư�� Ŭ���ϸ� �߻��ϴ� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            // ���� â�� ����
            this.Close();
        }

        /// <summary>
        /// ���� ���丮 ���� ��ư Ŭ�� �̺�Ʈ
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
        /// �ٿ�ε� ���丮 ���� ��ư Ŭ�� �̺�Ʈ
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