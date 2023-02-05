using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;

namespace MessengerClient
{
    public partial class GroupWnd : Form
    {

        #region 멤버 변수/생성자

        private Network net = null;
        private string my_id = null;
        private DataTable tbl_Group = null;


        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="net"></param>
        /// <param name="my_id"></param>
        /// <param name="tbl_Group"></param>
        public GroupWnd(Network net, string my_id, DataTable tbl_Group)
        {
            InitializeComponent();

            this.net = net;
            this.my_id = my_id;
            this.tbl_Group = tbl_Group;

            this.dataGrid_GroupInfo.DataSource = this.tbl_Group;

            this.Text = this.my_id + "님의 그룹 관리 창";

            this.btn_GroupUpdate.Enabled = false;
            this.btn_GroupRemove.Enabled = false;

        }

        #endregion

        #region 멤버 메서드

        /// <summary>
        /// 그룹 관리 결과 표시
        /// </summary>
        /// <param name="msg"></param>
        public void GroupWndMessage(string msg)
        {
            MessageBox.Show(msg);
            this.Close();
        }

        #endregion

        /// <summary>
        /// 데이터 그리드 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_GroupInfo_Click(object sender, EventArgs e)
        {
            try
            {
                int index = this.dataGrid_GroupInfo.CurrentRowIndex;

                DataRow row = this.tbl_Group.Rows[index];

                this.txt_GroupID.Text = row["group_id"].ToString().Trim();
                this.txt_GroupName.Text = row["group_name"].ToString().Trim();

                this.btn_GroupUpdate.Enabled = true;
                this.btn_GroupRemove.Enabled = true;
                this.btn_GroupAdd.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 그룹 추가 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GroupAdd_Click(object sender, EventArgs e)
        {
            if (this.txt_GroupName.Text.Length > 0)
            {
                string msg = (byte)MSG.CTOS_MESSAGE_GROUP_ADD + "\a";
                msg += this.my_id + "\a" + this.txt_GroupName.Text.Trim();

                this.net.Send(msg);
                this.dataGrid_GroupInfo.DataSource = null;
            }
            else
            {
                MessageBox.Show("그룹 이름을 입력하세요");
            }
        }


        /// <summary>
        /// 그룹 정보 갱신
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GroupUpdate_Click(object sender, EventArgs e)
        {
            if (this.txt_GroupName.Text.Length > 0)
            {
                string msg = (byte)MSG.CTOS_MESSAGE_GROUP_MODIFY + "\a";
                msg += this.my_id + "\a" + this.txt_GroupID.Text.Trim() + "\a";
                msg += this.txt_GroupName.Text.Trim();

                this.net.Send(msg);
                this.dataGrid_GroupInfo.DataSource = null;
            }
            else
            {
                MessageBox.Show("그룹 이름을 입력하세요");
            }
        }

        /// <summary>
        /// 그룹 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GroupRemove_Click(object sender, EventArgs e)
        {
            if (this.txt_GroupName.Text.Length > 0)
            {
                string msg = (byte)MSG.CTOS_MESSAGE_GROUP_REMOVE + "\a";
                msg += this.my_id + "\a" + this.txt_GroupID.Text.Trim() + "\a";
                msg += this.txt_GroupName.Text.Trim();

                this.net.Send(msg);
                this.dataGrid_GroupInfo.DataSource = null;
            }
            else
            {
                MessageBox.Show("그룹 이름을 입력하세요");
            }
        }

        /// <summary>
        /// 창닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}