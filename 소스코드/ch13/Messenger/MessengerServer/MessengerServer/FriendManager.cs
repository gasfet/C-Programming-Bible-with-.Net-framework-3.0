using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;

namespace MessengerServer
{
    public partial class FriendManager : Form
    {
        #region ��� ����

        private DataSet ds = null;
        private DataTable user = null;  // ģ�� �˻� ��� ���� ���̺�
        private Hashtable ht = null;    // �׷� ���� ���� ������ �ؽ� ���̺� 

        #endregion

        #region ������

        public FriendManager(DataSet ds)
        {
            InitializeComponent();

            this.ds = ds;
        }

        #endregion

        #region ��� �޼���

        /// <summary>
        /// ģ�� �׷� ���� ó��
        /// </summary>
        /// <param name="user_id">����� ���̵�</param>
        private void GroupInfo(string user_id)
        {
            try
            {
                DataRow[] rows = ds.Tables["TBL_Group"].Select("user_id ='" + user_id + "'");

                this.cbx_GroupName.Enabled = true;

                this.ht = new Hashtable();

                for (int i = 0; i < rows.Length; i++)
                {
                    this.ht.Add(rows[i]["group_id"], rows[i]["group_name"]);
                    this.cbx_GroupName.Items.Add(rows[i]["group_name"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// ģ���� �߰��� �� �ִ� ��� ��� ����ϱ�
        /// </summary>
        /// <param name="user_id">����� ���̵�</param>
        private void AddFriend(string user_id)
        {
            try
            {
                DataRow[] rows = ds.Tables["TBL_Member"].Select("user_id <> '" + user_id + "'");

                for (int i = 0; i < rows.Length; i++)
                {
                    this.cbx_Friend.Items.Add(rows[i]["user_id"]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ģ�� ���, �׷���� �ùٸ��� �����ߴ��� Ȯ��
        /// </summary>
        /// <returns>ģ��/�׷�� ���� Ȯ��</returns>
        private bool SelectValidation()
        {
            if ((this.cbx_Friend.Text == "ģ������") || (this.cbx_GroupName.Text == "�׷���� �����ϼ���!"))
                return false;
            else
                return true;
        }


        /// <summary>
        /// ģ�� �߰�
        /// </summary>
        /// <param name="user_id">����� ���̵�</param>
        /// <param name="friend_id">ģ�� ���̵�</param>
        /// <param name="group_id">�׷� ���̵�</param>
        private void AddFriendInfo(string user_id, string friend_id, string group_id)
        {
            try
            {
                string sql = "user_id='" + user_id + "' AND friend_id='" + friend_id + "'";
                DataRow[] rows = ds.Tables["TBL_Friend"].Select(sql);
                if (rows.Length > 0) // ģ�� ������ �̹� �߰��Ǿ� �ִٸ�...
                {
                    MessageBox.Show("ģ�� ������ �̹� ��ϵǾ� �ֽ��ϴ�.!");
                }
                else
                {
                    DataRow row = ds.Tables["TBL_Friend"].NewRow();  // ���� �����ͺ��̽� ����
                    row["user_id"] = user_id;
                    row["friend_id"] = friend_id;
                    row["group_id"] = group_id;
                    ds.Tables["TBL_Friend"].Rows.Add(row);

                    row = this.user.NewRow();                       // ���� ��ȭ���� �׸���â ���� ����
                    row["user_id"] = user_id;
                    row["friend_id"] = friend_id;
                    row["group_id"] = group_id;
                    this.user.Rows.Add(row);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// ģ�� ���� �����ϱ�
        /// </summary>
        /// <param name="user_id">����� ���̵�</param>
        /// <param name="friend_id">ģ�� ���̵�</param>
        /// <param name="group_id">�׷� ���̵�</param>
        private void RemoveFriendInfo(string user_id, string friend_id, string group_id)
        {
            try
            {
                string sql = "user_id='" + user_id + "' AND friend_id='" + friend_id + "' AND group_id=" + group_id;
                DataRow[] rows = ds.Tables["TBL_Friend"].Select(sql);
                if (rows.Length > 0) // ģ�� ������ ��ϵǾ� �ִٸ�
                {
                    rows[0].Delete(); // ���� �޸𸮿��� ģ�� ���� ����

                    rows = this.user.Select(sql);
                    rows[0].Delete(); // ���� ��ȭ���ڿ� �׸��� ���ڿ��� ����
                }
                else
                {
                    MessageBox.Show("������ ģ�� ������ ��� �Ǿ����� �ʽ��ϴ�.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// ģ�� ���� �����ϱ�
        /// </summary>
        /// <param name="user_id">����� ���̵�</param>
        /// <param name="friend_id">ģ�� ���̵�</param>
        /// <param name="group_id">�׷� ���̵�</param>
        private void ModifyFriendInfo(string user_id, string friend_id, string group_id)
        {
            try
            {
                string sql = "user_id='" + user_id + "' And friend_id='" + friend_id + "'";

                DataRow[] rows = ds.Tables["TBL_Friend"].Select(sql); // �˻��� ��� 

                if (rows.Length > 0)
                {
                    int i = 0;
                    for (i = 0; i < this.user.Rows.Count; i++)
                    {
                        if ((this.user.Rows[i]["user_id"] == rows[0]["user_id"]) && (this.user.Rows[i]["friend_id"] == rows[0]["friend_id"]))
                        {
                            break;
                        }
                    }

                    DataRow temp = ds.Tables["TBL_Friend"].Rows[i];
                    temp.BeginEdit();
                    temp["group_id"] = group_id;
                    temp.EndEdit();

                    temp = this.user.Rows[i];
                    temp.BeginEdit();
                    temp["group_id"] = group_id;
                    temp.EndEdit();

                }
                else
                {
                    MessageBox.Show("������ �����Ͱ� �������� �ʽ��ϴ�.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region �̺�Ʈ
        /// <summary>
        /// �� �ε� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FriendManager_Load(object sender, EventArgs e)
        {
            this.btn_FriendAdd.Enabled = false;
            this.btn_FriendRemove.Enabled = false;
            this.btn_FriendModify.Enabled = false;

            this.cbx_GroupName.Enabled = false;
        }
        /// <summary>
        /// ����� ���̵� �˻�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Search_Click(object sender, EventArgs e)
        {
            // ����� ģ�� ���� �������
            // GroupName �޺� �ڽ��� ����ڰ� ������ �� �ִ� �׷� ���� ����ϱ�
            try
            {
                string user_id = txt_UserID.Text.Trim();

                if (user_id.Length > 0)  // �Է��� ���ڿ��� �ִٸ�
                {
                    DataRow[] rows = ds.Tables["TBL_Friend"].Select("user_id='" + user_id + "'");
                    DataRow[] temp = ds.Tables["TBL_Member"].Select("user_id='" + user_id + "'");

                    this.user = ds.Tables["TBL_Friend"].Clone();

                    if ((rows.Length == 0) && (temp.Length == 0))
                    {
                        MessageBox.Show("�˻��� ����� �����ϴ�.\r\n���̵� �ٽ� Ȯ���� �ּ���!", "�����߻�!");
                    }
                    else
                    {
                        for (int i = 0; i < rows.Length; i++)
                        {
                            DataRow row = this.user.NewRow();

                            row["user_id"] = rows[i]["user_id"];
                            row["friend_id"] = rows[i]["friend_id"];
                            row["group_id"] = rows[i]["group_id"];

                            this.user.Rows.Add(row);
                        }

                        this.dataGrid_Friend.DataSource = this.user;

                        // �׷� �̸� ����ϱ�
                        this.GroupInfo(user_id);
                        // �߰��� �� �ִ� ģ�� ���
                        this.AddFriend(user_id);

                        this.txt_ID.Text = user_id;

                        this.btn_FriendAdd.Enabled = true;
                        this.btn_FriendModify.Enabled = true;
                        this.btn_FriendRemove.Enabled = true;

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ģ�� ���� �߰�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_FriendAdd_Click(object sender, EventArgs e)
        {
            if (this.SelectValidation())
            {
                string user_id = this.txt_ID.Text.Trim();
                string friend_id = this.cbx_Friend.Text.Trim();
                string group_id = this.txt_GroupID.Text.Trim();

                // ģ�� ���� �߰�
                this.AddFriendInfo(user_id, friend_id, group_id);

            }
            else
            {
                MessageBox.Show("ģ��/�׷���� �����ϼ���!", "���� �޽���");
            }
        }

        /// <summary>
        /// ģ�� ���� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_FriendRemove_Click(object sender, EventArgs e)
        {
            if (this.SelectValidation())
            {
                string user_id = this.txt_ID.Text.Trim();
                string friend_id = this.cbx_Friend.Text.Trim();
                string group_id = this.txt_GroupID.Text.Trim();

                // ģ�� ���� ����
                this.RemoveFriendInfo(user_id, friend_id, group_id);
            }
            else
            {
                MessageBox.Show("ģ��/�׷���� �����ϼ���!", "���� �޽���");
            }		
        }

        /// <summary>
        /// ģ�� ���� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_FriendModify_Click(object sender, EventArgs e)
        {
            if (this.SelectValidation())
            {
                string user_id = this.txt_ID.Text.Trim();
                string friend_id = this.cbx_Friend.Text.Trim();
                string group_id = this.txt_GroupID.Text.Trim();

                // ģ�� ���� ����
                this.ModifyFriendInfo(user_id, friend_id, group_id);
            }
            else
            {
                MessageBox.Show("ģ��/�׷���� �����ϼ���!", "���� �޽���");
            }		
        }

        /// <summary>
        /// ģ�� ����â �ݱ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// �׷�� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_GroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = this.cbx_GroupName.Text;

            IDictionaryEnumerator enu = ht.GetEnumerator();

            while (enu.MoveNext())
            {
                if (enu.Value.ToString() == str)
                {
                    this.txt_GroupID.Text = enu.Key.ToString();
                    break;
                }
            }
        }

        #endregion
    }
}