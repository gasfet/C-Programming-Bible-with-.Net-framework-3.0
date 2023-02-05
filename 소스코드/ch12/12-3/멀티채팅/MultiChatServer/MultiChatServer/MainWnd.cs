using System;
using System.Drawing;
using System.Windows.Forms;

namespace MultiChatServer
{
    /// <summary>
    /// 다중 채팅 서버는  포트 번호를 7007 번 사용함
    /// </summary>
    public partial class MainWnd : Form
    {
        private Server server = null;     // 멀티 채팅 서버

        delegate void SetTextCallback(string msg);
        delegate void AddListViewCallback(string ip, string time);
        delegate void DeleteListViewCallback(string ip);

        public MainWnd()
        {
            InitializeComponent();
        }

        private void MainWnd_Load(object sender, EventArgs e)
        {
            Init_listView();
        }


        /// <summary>
        /// txt_info 텍스트에 메시지 추가
        /// </summary>
        /// <param name="msg">메시지</param>		
        public void Add_MSG(string msg)
        {
            try
            {
                if (this.txt_Info.InvokeRequired) // 컨트롤 요청이 들어올 경우
                {   // 델리게이트를 이용해 Add_MSG 메서드를 다시 호출
                    SetTextCallback d = new SetTextCallback(Add_MSG);
                    this.Invoke(d, new object[] { msg });
                }
                else
                {   // 컨트롤 접근이 가능할 경우, 다음 구문 처리
                    this.txt_Info.AppendText(msg + "\r\n");  // 채팅 문자열 출력
                    this.txt_Info.ScrollToCaret();	         // txt_info 텍스트 박스 자동 스크롤
                }
            }
            catch { } // 멀티 스레드 환경에서 뜻하지 않은 예외가 발생할 경우 처리
        }

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
            lst_View.Columns.Add("접속 아이피", 100, HorizontalAlignment.Center);
            // 접속 시간 헤더 만들기
            lst_View.Columns.Add("접속 시간", 175, HorizontalAlignment.Center);
        }

        public void Add_listView(string ip, string time)
        {
            try
            {
                if (this.lst_View.InvokeRequired) // 컨트롤 요청이 들어올 경우
                {   // 델리게이트를 이용해 Add_MSG 메서드를 다시 호출
                    AddListViewCallback d = new AddListViewCallback(Add_listView);
                    this.Invoke(d, new object[] {ip, time});
                }
                else
                {   // 컨트롤 접근이 가능할 경우, 다음 구문 처리
                    ListViewItem item = new ListViewItem(ip);
                    item.SubItems.Add(time);         // 접속한 시간 정보 출력
                    this.lst_View.Items.Add(item);   // ListView에 개체 추가 
                }
            }
            catch { } // 멀티 스레드 환경에서 뜻하지 않은 예외가 발생할 경우 처리       
        }


        public void Delete_listView(string ip)
        {
            try
            {
                if (this.lst_View.InvokeRequired) // 컨트롤 요청이 들어올 경우
                {   // 델리게이트를 이용해 Add_MSG 메서드를 다시 호출
                    DeleteListViewCallback d = new DeleteListViewCallback(Delete_listView);
                    this.Invoke(d, new object[] {ip});
                }
                else
                {   // 컨트롤 접근이 가능할 경우, 다음 구문 처리
                    ListViewItem item = new ListViewItem(ip);
                    this.lst_View.Items.Remove(item);
                }
            }
            catch { } // 멀티 스레드 환경에서 뜻하지 않은 예외가 발생할 경우 처리               
        }



        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (btn_Start.Text == "서버 시작")
            {
                server = new Server(this, 7007);// 포트 번호 7007번 사용
                server.ServerStart();            // 멀티 채팅 서버 시작                

                this.Add_MSG("서버 시작되었음");
                btn_Start.BackColor = Color.Red;
                btn_Start.Text = "서버 종료";
            }
            else
            {
                server.ServerStop();             // 멀티 채팅 서버 종료
                btn_Start.Text = "서버 시작";
                btn_Start.BackColor = this.BackColor;
            }
        }

        private void btn_Broadcast_Click(object sender, EventArgs e)
        {
            string ips = "";

            foreach (ListViewItem item in lst_View.Items)
            {
                if (item.Checked)
                {
                    int index = lst_View.Items.IndexOf(item);
                    ips += lst_View.Items[index].SubItems[0].Text.Trim() + ";";
                }
            }

            string msg = this.txt_Broadcast.Text.Trim();

            if (msg != "")
            {
                msg = "STOC_MESSAGE_INFO\a" + "[서버 방송 메시지] " + msg;
                if (ips != "")
                    this.server.BroadCast(msg, ips); // 지정된 클라이언트 그룹에게 메시지 전송 
                else
                    this.server.BroadCast(msg);      // 전체에게 메시지 전송
            }
            else
            {
                MessageBox.Show("방송할 메시지를 입력하세요!", "입력 에러");
            }
            this.txt_Broadcast.Focus();
        }

        private void MainWnd_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (btn_Start.Text == "서버 종료")
            {
                server.ServerStop();
            }
        }	  		

    }
}