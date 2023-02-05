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
        #region 멤버 변수

        /// <summary>
        /// 메신저 메인 화면
        /// </summary>
        private Network net = null;
        private string my_id = null;
        private DataTable tbl_Friend = null;
        private DataTable tbl_Group = null;

        #endregion

        #region 생성자
        /// <summary>
        /// 생성자
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


        #region 멤버 메서드
        /// <summary>
        /// 사용자 조회 성공했을 경우
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
        /// 사용자 조회에 실패했을 경우
        /// </summary>
        public void FriendUserFail()
        {
            MessageBox.Show(this.txt_UserID.Text + "님은 친구로 등록 할 수 없습니다.", "에러발생");
            this.txt_UserID.Focus();
        }

        /// <summary>
        /// 친구 관리 결과 출력
        /// </summary>
        /// <param name="msg"></param>
        public void FriendWndMessage(string msg)
        {
            MessageBox.Show(msg);
            this.Close();
        }

        #endregion


        /// <summary>
        /// 사용자 아이디 검색 버튼 클릭
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
                MessageBox.Show("자기 자신을 친구로 추가할 수는 없습니다.!", "에러 발생");
                return;
            }


            if (this.txt_UserID.Text.Length > 0)
            {
                DataRow[] rows = this.tbl_Friend.Select("id='" + this.txt_UserID.Text.Trim() + "'");
                if (rows.Length > 0) // 이미 친구로 등록되어 있다면 (수정 또는 삭제 해당)
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
                else   // 친구로 등록되어 있지 않다면 ( 새롭게 추가 )
                {
                    string msg = (byte)MSG.CTOS_MESSAGE_FRIEND_SEARCH + "\a" + this.txt_UserID.Text.Trim();
                    this.net.Send(msg);
                }
            }
            else
                MessageBox.Show(" 검색할 사용자 아이디를 입력하세요 ");
        }

        /// <summary>
        /// 친구 추가 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_FriendAdd_Click(object sender, EventArgs e)
        {
            // 사용자 아이디, 친구 아이디, 그룹 아이디
            string msg = (byte)MSG.CTOS_MESSAGE_FRIEND_ADD + "\a";
            msg += this.my_id + "\a" + this.txt_FriendID.Text.Trim() + "\a";
            msg += this.txt_GroupID.Text.Trim();
            this.net.Send(msg);
        }


        /// <summary>
        /// 친구 정보 수정 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_FriendModify_Click(object sender, EventArgs e)
        {
            // 사용자 아이디, 친구 아이디, 그룹 아이디
            string msg = (byte)MSG.CTOS_MESSAGE_FRIEND_MODIFY + "\a";
            msg += this.my_id + "\a" + this.txt_FriendID.Text.Trim() + "\a";
            msg += this.txt_GroupID.Text.Trim();
            this.net.Send(msg);		 
        }

        /// <summary>
        /// 친구 정보 삭제 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_FriendRemove_Click(object sender, EventArgs e)
        {
            // 사용자 아이디, 친구 아이디, 그룹 아이디
            string msg = (byte)MSG.CTOS_MESSAGE_FRIEND_REMOVE + "\a";
            msg += this.my_id + "\a" + this.txt_FriendID.Text.Trim() + "\a";
            msg += this.txt_GroupID.Text.Trim();
            this.net.Send(msg);
        }

        /// <summary>
        /// 창 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 그룹 이름 선택 콤버 박스 이벤트
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