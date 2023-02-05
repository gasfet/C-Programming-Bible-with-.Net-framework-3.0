using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace MessengerServer
{
    public partial class GroupManager : Form
    {
        #region 멤버 변수

        private DataSet ds = null;

        #endregion

        #region 멤버 생성자/소멸자

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="ds"></param>
        public GroupManager(DataSet ds)
        {
            InitializeComponent();

            this.ds = ds;
            this.dataGrid_GroupInfo.SetDataBinding(ds, "TBL_Group");
        }

        #endregion

        #region 이벤트
        /// <summary>
        /// 폼로드 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupManager_Load(object sender, EventArgs e)
        {
            try
            {
                this.dataGrid_GroupInfo.Select(0);

                DataRow[] rows = ds.Tables["TBL_Member"].Select();

                for (int i = 0; i < rows.Length; i++)
                {
                    this.cbx_SelectUser.Items.Add(rows[i]["user_id"]);
                }

                this.txt_GroupName.Text = ds.Tables["TBL_Group"].Rows[0]["group_name"].ToString();
                this.cbx_SelectUser.Text = rows[0]["user_id"].ToString();
            }
            catch { }
        }

      
        /// <summary>
        /// 데이터 그리드 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_GroupInfo_Click(object sender, EventArgs e)
        {
            try
            {
                int index = this.dataGrid_GroupInfo.CurrentRowIndex;

                DataRow row = this.ds.Tables["TBL_Group"].Rows[index];

                this.txt_GroupName.Text = row["group_name"].ToString();
                this.cbx_SelectUser.Text = row["user_id"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 그룹 추가 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GroupAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string group_name = this.txt_GroupName.Text.Trim();
                string user_id = this.cbx_SelectUser.Text.Trim();

                if ((group_name.Length == 0) || (user_id == "사용자 선택"))
                {
                    MessageBox.Show("그룹이름/사용자아이디를 입력하세요");
                    return;
                }

                DataRow[] rows = ds.Tables["TBL_Group"].Select("group_name='" + group_name + "' AND user_id='" + user_id + "'");

                if (rows.Length > 0) // 그룹 이름과 사용자 정보가 이미 있다면..
                {
                    MessageBox.Show(user_id + " 계정 사용자는 이미 " + group_name + " 그룹 이름을 갖고 있습니다!", "확인 요망");
                }
                else
                {
                    int index = ds.Tables["TBL_Group"].Rows.Count - 1;
                    string count = null;
                    if (index < 0)
                    {
                        count = "0";
                    }
                    else
                    {
                        count = ds.Tables["TBL_Group"].Rows[index]["group_id"].ToString().Trim();
                    }

                    DataRow row = ds.Tables["TBL_Group"].NewRow();
                    row["group_id"] = Convert.ToInt32(count) + 1;
                    row["group_name"] = group_name;
                    row["user_id"] = user_id;
                    ds.Tables["TBL_Group"].Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }		

        }

        /// <summary>
        /// 그룹 정보 갱신 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GroupUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string group_name = this.txt_GroupName.Text.Trim();

                if ((group_name.Length == 0))
                {
                    MessageBox.Show("그룹이름을 입력하세요");
                    return;
                }

                int index = this.dataGrid_GroupInfo.CurrentRowIndex;
                DataRow row = ds.Tables["TBL_Group"].Rows[index];

                row.BeginEdit();
                row["group_name"] = group_name;
                row.EndEdit();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }		
        }

        /// <summary>
        /// 그룹 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GroupDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string group_name = this.txt_GroupName.Text.Trim();
                string user_name = this.cbx_SelectUser.Text.Trim();

                if ((group_name.Length == 0))
                {
                    MessageBox.Show("그룹이름을 입력하세요");
                    return;
                }

                int index = this.dataGrid_GroupInfo.CurrentRowIndex;
                DataRow row = ds.Tables["TBL_Group"].Rows[index];
                DataRow[] temp = ds.Tables["TBL_Group"].Select("group_id=" + row["group_id"].ToString());
                temp[0].Delete();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }		
        }

        /// <summary>
        /// 그룹 관리창 닫기 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}