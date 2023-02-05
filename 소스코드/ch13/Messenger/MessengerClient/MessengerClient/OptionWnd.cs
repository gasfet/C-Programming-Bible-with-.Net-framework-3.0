using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Threading;

namespace MessengerClient
{
    public partial class OptionWnd : Form
    {
        #region ��� ����
        
        private DataTable tbl_Option = null;
        private string str_fdown_dir = null;

        #endregion

        #region ������
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="tbl_Option"></param>
        public OptionWnd(DataTable tbl_Option)
        {

            InitializeComponent();

            this.tbl_Option = tbl_Option;

            this.InitOptionWnd();

        }
        #endregion

        #region ��� �޼���
        /// <summary>
        /// �ɼ�â �ʱ�ȭ
        /// </summary>
        private void InitOptionWnd()
        {
            this.radio_XML.Parent = this.grBox_OptionStyle;
            this.radio_Registry.Parent = this.grBox_OptionStyle;
            this.radio_Registry.Checked = true;

            DataRow row = this.tbl_Option.Rows[0];

            this.chk_AutoLogin.Checked = Convert.ToBoolean(row["login_auto"].ToString().Trim());
            if (this.chk_AutoLogin.Checked)
            {
                this.txt_LoginID.Text = row["login_id"].ToString().Trim();
                this.txt_LoginPwd.Text = row["login_pwd"].ToString().Trim();
            }
            this.txt_PathFile.Text = row["path_file"].ToString().Trim();
            this.txt_Show.Text = row["notify_show"].ToString().Trim();
            this.txt_Stay.Text = row["notify_stay"].ToString().Trim();
            this.txt_Hide.Text = row["notify_hide"].ToString().Trim();

            if (Convert.ToBoolean(row["option_style"].ToString().Trim()))
                this.radio_XML.Checked = true;

            this.chk_Crypto.Checked = Convert.ToBoolean(row["cryptograph"].ToString().Trim());

        }
        #endregion

        /// <summary>
        /// �ɼ�â Ȯ�� ��ư Ŭ�� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            DataRow row = this.tbl_Option.Rows[0];
            row.BeginEdit();

            row["login_auto"] = this.chk_AutoLogin.Checked;
            if (this.chk_AutoLogin.Checked)
            {
                row["login_id"] = this.txt_LoginID.Text.Trim();
                row["login_pwd"] = this.txt_LoginPwd.Text.Trim();
            }
            else
            {
                row["login_id"] = "";
                row["login_pwd"] = "";
            }

            row["path_file"] = this.txt_PathFile.Text.Trim();

            MainWnd.PATH_FILE = this.txt_PathFile.Text.Trim();

            row["notify_show"] = Convert.ToInt32(this.txt_Show.Text.Trim());
            row["notify_stay"] = Convert.ToInt32(this.txt_Stay.Text.Trim());
            row["notify_hide"] = Convert.ToInt32(this.txt_Hide.Text.Trim());

            if (this.radio_Registry.Checked)
                row["option_style"] = false;
            else
                row["option_style"] = true;

            row["cryptograph"] = this.chk_Crypto.Checked;

            MainWnd.CHAT_Crypto = this.chk_Crypto.Checked;

            this.Close();
        }

        /// <summary>
        /// ��� ��ư Ŭ�� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>	
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ���� ��� ��ư Ŭ�� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  		
        private void btn_PathFile_Click(object sender, EventArgs e)
        {
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
                    this.str_fdown_dir = folder.SelectedPath.Trim();
                }
            }
        }

        private void SetLabelText()
        {
            if(this.str_fdown_dir != null)
                this.txt_PathFile.Text = this.str_fdown_dir;
        }
        
     
    }
}