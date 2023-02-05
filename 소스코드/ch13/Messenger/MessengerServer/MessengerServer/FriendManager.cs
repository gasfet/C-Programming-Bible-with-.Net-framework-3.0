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
        #region 멤버 변수

        private DataSet ds = null;
        private DataTable user = null;  // 친구 검색 결과 저장 테이블
        private Hashtable ht = null;    // 그룹 관련 정보 저장한 해쉬 테이블 

        #endregion

        #region 생성자

        public FriendManager(DataSet ds)
        {
            InitializeComponent();

            this.ds = ds;
        }

        #endregion

        #region 멤버 메서드

        /// <summary>
        /// 친구 그룹 정보 처리
        /// </summary>
        /// <param name="user_id">사용자 아이디</param>
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
        /// 친구로 추가할 수 있는 사람 목록 출력하기
        /// </summary>
        /// <param name="user_id">사용자 아이디</param>
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
        /// 친구 목록, 그룹명을 올바르게 선택했는지 확인
        /// </summary>
        /// <returns>친구/그룹명 설정 확인</returns>
        private bool SelectValidation()
        {
            if ((this.cbx_Friend.Text == "친구선택") || (this.cbx_GroupName.Text == "그룹명을 선택하세요!"))
                return false;
            else
                return true;
        }


        /// <summary>
        /// 친구 추가
        /// </summary>
        /// <param name="user_id">사용자 아이디</param>
        /// <param name="friend_id">친구 아이디</param>
        /// <param name="group_id">그룹 아이디</param>
        private void AddFriendInfo(string user_id, string friend_id, string group_id)
        {
            try
            {
                string sql = "user_id='" + user_id + "' AND friend_id='" + friend_id + "'";
                DataRow[] rows = ds.Tables["TBL_Friend"].Select(sql);
                if (rows.Length > 0) // 친구 정보가 이미 추가되어 있다면...
                {
                    MessageBox.Show("친구 정보가 이미 등록되어 있습니다.!");
                }
                else
                {
                    DataRow row = ds.Tables["TBL_Friend"].NewRow();  // 메인 데이터베이스 갱신
                    row["user_id"] = user_id;
                    row["friend_id"] = friend_id;
                    row["group_id"] = group_id;
                    ds.Tables["TBL_Friend"].Rows.Add(row);

                    row = this.user.NewRow();                       // 현재 대화상자 그리드창 정보 갱신
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
        /// 친구 정보 삭제하기
        /// </summary>
        /// <param name="user_id">사용자 아이디</param>
        /// <param name="friend_id">친구 아이디</param>
        /// <param name="group_id">그룹 아이디</param>
        private void RemoveFriendInfo(string user_id, string friend_id, string group_id)
        {
            try
            {
                string sql = "user_id='" + user_id + "' AND friend_id='" + friend_id + "' AND group_id=" + group_id;
                DataRow[] rows = ds.Tables["TBL_Friend"].Select(sql);
                if (rows.Length > 0) // 친구 정보가 등록되어 있다면
                {
                    rows[0].Delete(); // 메인 메모리에서 친구 정보 삭제

                    rows = this.user.Select(sql);
                    rows[0].Delete(); // 현재 대화상자에 그리드 상자에서 제거
                }
                else
                {
                    MessageBox.Show("삭제할 친구 정보가 등록 되어있지 않습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 친구 정보 수정하기
        /// </summary>
        /// <param name="user_id">사용자 아이디</param>
        /// <param name="friend_id">친구 아이디</param>
        /// <param name="group_id">그룹 아이디</param>
        private void ModifyFriendInfo(string user_id, string friend_id, string group_id)
        {
            try
            {
                string sql = "user_id='" + user_id + "' And friend_id='" + friend_id + "'";

                DataRow[] rows = ds.Tables["TBL_Friend"].Select(sql); // 검색한 결과 

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
                    MessageBox.Show("수정할 데이터가 존재하지 않습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region 이벤트
        /// <summary>
        /// 폼 로드 이벤트
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
        /// 사용자 아이디 검색
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Search_Click(object sender, EventArgs e)
        {
            // 사용자 친구 정보 갖어오기
            // GroupName 콤보 박스에 사용자가 선택할 수 있는 그룹 정보 출력하기
            try
            {
                string user_id = txt_UserID.Text.Trim();

                if (user_id.Length > 0)  // 입력한 문자열이 있다면
                {
                    DataRow[] rows = ds.Tables["TBL_Friend"].Select("user_id='" + user_id + "'");
                    DataRow[] temp = ds.Tables["TBL_Member"].Select("user_id='" + user_id + "'");

                    this.user = ds.Tables["TBL_Friend"].Clone();

                    if ((rows.Length == 0) && (temp.Length == 0))
                    {
                        MessageBox.Show("검색한 결과가 없습니다.\r\n아이디를 다시 확인해 주세요!", "에러발생!");
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

                        // 그룹 이름 출력하기
                        this.GroupInfo(user_id);
                        // 추가할 수 있는 친구 목록
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
        /// 친구 정보 추가
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

                // 친구 정보 추가
                this.AddFriendInfo(user_id, friend_id, group_id);

            }
            else
            {
                MessageBox.Show("친구/그룹명을 선택하세요!", "에러 메시지");
            }
        }

        /// <summary>
        /// 친구 정보 제거
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

                // 친구 정보 제거
                this.RemoveFriendInfo(user_id, friend_id, group_id);
            }
            else
            {
                MessageBox.Show("친구/그룹명을 선택하세요!", "에러 메시지");
            }		
        }

        /// <summary>
        /// 친구 정보 변경
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

                // 친구 정보 변경
                this.ModifyFriendInfo(user_id, friend_id, group_id);
            }
            else
            {
                MessageBox.Show("친구/그룹명을 선택하세요!", "에러 메시지");
            }		
        }

        /// <summary>
        /// 친구 관리창 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 그룹명 선택
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