using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MessengerClient
{
    public partial class FriendWnd : Form
    {
        #region ��� ����

        /// <summary>
        /// �޽��� ���� ȭ��
        /// </summary>
        private Network net = null;
        private string my_id = null;
        private DataTable tbl_Friend = null;
        private DataTable tbl_Group = null;

        #endregion

        #region ������
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="net"></param>
        /// <param name="my_id"></param>
        /// <param name="tbl_Friend"></param>
        /// <param name="tbl_Group"></param>
        public FriendWnd(Network net, string my_id, DataTable tbl_Friend, DataTable tbl_Group)
        {
            InitializeComponent();

            this.net = net;
            this.my_id = my_id;
            this.tbl_Friend = tbl_Friend;
            this.tbl_Group = tbl_Group;

            this.btn_FriendAdd.Enabled = false;
            this.btn_FriendModify.Enabled = false;
            this.btn_FriendRemove.Enabled = false;
        }

        #endregion


        #region ��� �޼���
        /// <summary>
        /// ����� ��ȸ �������� ���
        /// </summary>
        public void FriendUserOK()
        {
            this.btn_FriendAdd.Enabled = true;

            this.txt_FriendID.Text = this.txt_UserID.Text;
            this.txt_ID.Text = this.my_id;

            DataRow[] rows = this.tbl_Group.Select();
            foreach (DataRow row in rows)
            {
                this.cbx_GroupName.Items.Add(row["group_name"]);
            }

        }

        /// <summary>
        /// ����� ��ȸ�� �������� ���
        /// </summary>
        public void FriendUserFail()
        {
            MessageBox.Show(this.txt_UserID.Text + "���� ģ���� ��� �� �� �����ϴ�.", "�����߻�");
            this.txt_UserID.Focus();
        }

        /// <summary>
        /// ģ�� ���� ��� ���
        /// </summary>
        /// <param name="msg"></param>
        public void FriendWndMessage(string msg)
        {
            MessageBox.Show(msg);
            this.Close();
        }

        #endregion


        /// <summary>
        /// ����� ���̵� �˻� ��ư Ŭ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>    
        private void btn_Search_Click(object sender, System.EventArgs e)
        {
            this.btn_FriendAdd.Enabled = false;
            this.btn_FriendModify.Enabled = false;
            this.btn_FriendRemove.Enabled = false;

            if (this.txt_UserID.Text.Trim() == this.my_id)
            {
                MessageBox.Show("�ڱ� �ڽ��� ģ���� �߰��� ���� �����ϴ�.!", "���� �߻�");
                return;
            }


            if (this.txt_UserID.Text.Length > 0)
            {
                DataRow[] rows = this.tbl_Friend.Select("id='" + this.txt_UserID.Text.Trim() + "'");
                if (rows.Length > 0) // �̹� ģ���� ��ϵǾ� �ִٸ� (���� �Ǵ� ���� �ش�)
                {
                    this.txt_ID.Text = this.my_id;
                    this.txt_FriendID.Text = this.txt_UserID.Text;
                    this.txt_GroupID.Text = rows[0]["group_id"].ToString().Trim();

                    this.btn_FriendRemove.Enabled = true;

                    DataRow[] groupname = this.tbl_Group.Select();
                    foreach (DataRow obj in groupname)
                    {
                        this.cbx_GroupName.Items.Add(obj["group_name"]);
                    }
                }
                else   // ģ���� ��ϵǾ� ���� �ʴٸ� ( ���Ӱ� �߰� )
                {
                    string msg = (byte)MSG.CTOS_MESSAGE_FRIEND_SEARCH + "\a" + this.txt_UserID.Text.Trim();
                    this.net.Send(msg);
                }
            }
            else
                MessageBox.Show(" �˻��� ����� ���̵� �Է��ϼ��� ");
        }

        /// <summary>
        /// ģ�� �߰� ��ư Ŭ�� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_FriendAdd_Click(object sender, EventArgs e)
        {
            // ����� ���̵�, ģ�� ���̵�, �׷� ���̵�
            string msg = (byte)MSG.CTOS_MESSAGE_FRIEND_ADD + "\a";
            msg += this.my_id + "\a" + this.txt_FriendID.Text.Trim() + "\a";
            msg += this.txt_GroupID.Text.Trim();
            this.net.Send(msg);
        }


        /// <summary>
        /// ģ�� ���� ���� Ŭ�� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_FriendModify_Click(object sender, EventArgs e)
        {
            // ����� ���̵�, ģ�� ���̵�, �׷� ���̵�
            string msg = (byte)MSG.CTOS_MESSAGE_FRIEND_MODIFY + "\a";
            msg += this.my_id + "\a" + this.txt_FriendID.Text.Trim() + "\a";
            msg += this.txt_GroupID.Text.Trim();
            this.net.Send(msg);		 
        }

        /// <summary>
        /// ģ�� ���� ���� Ŭ�� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_FriendRemove_Click(object sender, EventArgs e)
        {
            // ����� ���̵�, ģ�� ���̵�, �׷� ���̵�
            string msg = (byte)MSG.CTOS_MESSAGE_FRIEND_REMOVE + "\a";
            msg += this.my_id + "\a" + this.txt_FriendID.Text.Trim() + "\a";
            msg += this.txt_GroupID.Text.Trim();
            this.net.Send(msg);
        }

        /// <summary>
        /// â �ݱ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// �׷� �̸� ���� �޹� �ڽ� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_GroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btn_FriendRemove.Enabled = false;
            this.btn_FriendModify.Enabled = true;

            string groupname = this.cbx_GroupName.Text;

            DataRow[] rows = this.tbl_Group.Select("group_name='" + groupname + "'");

            this.txt_GroupID.Text = rows[0]["group_id"].ToString().Trim();

        }



    }
}