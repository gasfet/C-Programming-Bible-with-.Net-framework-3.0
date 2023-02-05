using System;
using System.Drawing;
using System.Windows.Forms;

using System.Threading;           // 채팅 스레드 처리 

namespace MainChat
{
    public partial class MainWnd : Form
    {
        private Network net = null;            // 채팅을 처리하는 Network 클래스 변수 선언
        private Thread server_th = null;       // 채팅 서버 스레드 선언
        private string my_ip = null;           // 자신의 아이피 주소를 기록할 변수

        delegate void SetTextCallback(string msg);


        public MainWnd()
        {
            InitializeComponent();
            this.net = new Network(this);	 	// 네트워크 클래스 객체 생성			
        }

        /// <summary>
        /// txt_info 텍스트에 메시지 추가
        /// </summary>
        /// <param name="msg">메시지</param>		
        public void Add_MSG(string msg)
        {
            try
            {
                if (this.txt_info.InvokeRequired) // 컨트롤 요청이 들어올 경우
                {   // 델리게이트를 이용해 Add_MSG 메서드를 다시 호출
                    SetTextCallback d = new SetTextCallback(Add_MSG);
                    this.Invoke(d, new object[] { msg });
                }
                else
                {   // 컨트롤 접근이 가능할 경우, 다음 구문 처리
                    this.txt_info.AppendText(msg + "\r\n");  // 채팅 문자열 출력
                    this.txt_info.ScrollToCaret();	            // txt_info 텍스트 박스 자동 스크롤
                    this.txt_input.Focus();                     // txt_input 텍스트 박스에 초점 맞춤
                }
            }
            catch {} // 멀티 스레드 환경에서 뜻하지 않은 예외가 발생할 경우 처리
        }


        private void MainWnd_Load(object sender, EventArgs e)
        {
            my_ip = net.Get_MyIP();    // 자신의 아이피 정보 알아내기
            server_th = new Thread(new ThreadStart(this.net.ServerStart));  // 채팅 서버 시작
            server_th.Start();
        }

        private void MainWnd_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (btn_Connect.Text == "접속중...")
                    this.net.Disconnect();      // 채팅 서버와 연결되어 있으면 연결 끊기			
                                
                this.net.ServerStop();           // 채팅 서버 실행 중지

                if (server_th.IsAlive)          // ServerStart 스레드를 종료함
                    server_th.Abort();
                
                this.txt_info.Dispose();         // 스레드가 참조하는 컨트롤 Dispose                         
                this.txt_input.Dispose(); 
           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    // 예외 메시지 출력
            }
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (btn_Connect.Text == "연결")  // 채팅 서버에 접속할 경우
            {
                string ip = txt_ip.Text.Trim();	   // 접속할 서버 아이피 주소 가져오기		
                if (ip == "")  // 접속할 채팅 서버 아이피 주소가 없다면
                {
                    MessageBox.Show("아이피 번호를 입력하세요!");  // 에러 메시지 출력
                    return;
                }

                if (!this.net.Connect(ip))  // 채팅 서버에 접속 시도
                {  // 채팅 서버 접속에 실패하면
                    MessageBox.Show("서버 아이피 번호가 틀리거나\r\n 서버가 작동중이지 않습니다.");
                }
                else
                {  // 채팅 서버 접속에 성공하면
                    btn_Connect.Text = "접속중...";   // 채팅 서버 접속 성공하면 버튼 문자열 변경
                }
            }
            else    // 채팅 서버와의 접속을 끊을 때 
            {
                this.net.Disconnect();        // 채팅 서버와 연결을 끊음
                btn_Connect.Text = "연결";  // 버튼 문자열을 “접속중...”에서 “연결”로 변경
            }
        }

        private void txt_input_KeyDown(object sender, KeyEventArgs e)
        {
            // 엔터를 치면 문자열 메시지가 상대방에게 전송됨
            if (e.KeyCode == Keys.Enter)
            {
                string msg = txt_input.Text.Trim();
                this.Add_MSG("[" + my_ip + "] " + msg);
                this.net.Send(msg);
                txt_input.Text = "";
                txt_input.Focus();
            }
        }
    }
}