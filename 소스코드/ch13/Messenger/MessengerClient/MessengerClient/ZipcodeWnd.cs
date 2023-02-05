using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MessengerClient
{
    /// <summary>
    /// 우편번호 처리 모듈
    /// </summary>
    public partial class ZipcodeWnd : Form
    {
        #region 멤버 변수

        private string addr = null;      // 주소 저장 변수
        private string server_ip = null; // 서버 아이피
        private RegNetwork net = null;

        /// <summary>
        /// 우편번호 주소 반환
        /// </summary>
        public string Addr
        {
            get
            {
                return addr;
            }
        }

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="net">메신저 서버 통신 개체</param>
        /// <param name="server_ip">메신저 서버 아이피</param>
        public ZipcodeWnd(RegNetwork net, string server_ip)
        {
            InitializeComponent();

            this.net = net;
            this.server_ip = server_ip;
            this.Init_listView();
        }

        #endregion

        #region 멤버 메서드

        /// <summary>
        /// ListView 초기화 메서드
        /// </summary>
        private void Init_listView()
        {
            lst_View.Clear();                         // 초기화 
            lst_View.View = View.Details;             // View옵션을 Details로 설정
            lst_View.LabelEdit = false;               // 편집 기능 비활성화
            lst_View.CheckBoxes = true;               // 체크 박스 기능 활성화						
            lst_View.GridLines = true;                // 윤곽선 설정   
            lst_View.Sorting = SortOrder.Ascending;   // 오름차순 정렬
            // 접속 아이디 헤더 만들기
            lst_View.Columns.Add("우편 주소", 90, HorizontalAlignment.Center);
            // 접속 시간 헤더 만들기
            lst_View.Columns.Add("상세 주소", 370, HorizontalAlignment.Left);
        }

        /// <summary>
        /// 리스트뷰에 목록 추가
        /// </summary>
        /// <param name="zipcode">우편번호</param>
        /// <param name="addr">상세주소</param>
        private void Add_listView(string zipcode, string addr)
        {
            ListViewItem item = new ListViewItem(zipcode);
            item.SubItems.Add(addr);  // 접속한 시간 정보
            this.lst_View.Items.Add(item);
        }

        /// <summary>
        /// 우편번호 데이터 분석
        /// </summary>
        /// <param name="data">우편번호#주소#우편번호#주소...</param>
        public void ZipdataInput(string data)
        {
            this.Init_listView();

            string[] token = data.Split('#'); // 짝수번째 우편번호, 홀수번째 주소

            for (int i = 0; i < token.Length - 1; i += 2)
            {
                this.Add_listView(token[i], token[i + 1]);
            }
        }

        #endregion

        #region 이벤트 처리
        /// <summary>
        /// 주소 검색
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (txt_Search.Text.Length == 0)
            {
                MessageBox.Show("검색할 주소를 입력하세요", "에러 메시지");
                return;
            }

            string msg = (byte)MSG.CTOS_MESSAGE_REGISTER_ZIPCODE + "\a" + txt_Search.Text.Trim();

            this.net.Connect(this.server_ip);
            this.net.Send(msg);
        }

        /// <summary>
        /// 주소 선택
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Select_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (ListViewItem item in lst_View.Items)
            {
                if (item.Checked)
                {
                    int index = lst_View.Items.IndexOf(item);
                    this.addr += lst_View.Items[index].SubItems[0].Text.Trim() + "#";
                    this.addr += lst_View.Items[index].SubItems[1].Text.Trim() + "#";
                    count++;
                }
            }

            if (count > 1)
            {
                MessageBox.Show("우편번호는 하나만 선택해야 합니다.!");
                return;
            }
            if (count == 0)
            {
                MessageBox.Show("우편번호를 선택하세요.!");
                return;
            }

            this.Close();
        }

        /// <summary>
        /// 주소 입력후 엔트 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Search_KeyDown(object sender, KeyEventArgs e)
        {
            // 엔터키가 눌리면 문자열 메시지 전송
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_Search.Text.Length == 0)
                {
                    MessageBox.Show("검색할 주소를 입력하세요", "에러 메시지");
                    return;
                }

                string msg = (byte)MSG.CTOS_MESSAGE_REGISTER_ZIPCODE + "\a" + txt_Search.Text.Trim();

                this.net.Connect(this.server_ip);
                this.net.Send(msg);
            }
        }
        #endregion
    }
}