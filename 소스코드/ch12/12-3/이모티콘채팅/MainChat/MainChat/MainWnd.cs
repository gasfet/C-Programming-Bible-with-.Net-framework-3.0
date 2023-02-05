using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace MainChat
{
    public partial class MainWnd : Form
    {
        private Network net = null;              // Network 클래스에서 서버/클라이언트 처리를 전담합니다.
        private Thread server_th = null;        // 채팅 서버 스레드
        private string my_ip = null;             // 내 아이피 주소를 저장할 변수
        private bool newtxtsend = false;	 // 문자열 입력중인지 알아내는 플래그	

        private Font chat_font = new Font("굴림체", 10); // 채팅 기본 글꼴 지정
        private Color chat_color = Color.Black;       // 채팅 글꼴 색상

        private ImageList imageList = null;            // 이모티콘 이미지 저장 리스트
        private EmoticonWnd emo_wnd = null;         // 이모티콘 윈도우 처리

        private int m_index = 0;



        delegate void SetTextCallback(string msg);  // 문자열 출력 델리게이트


        public MainWnd()
        {
            net = new Network(this);     // Network 클래스 개체 생성
            my_ip = net.Get_MyIP();        // 내 아이피 주소 저장하기

            imageList = new ImageList();    // 이모티콘 이미지 저장 리스트 개체 생성
            imageList.ImageSize = new Size(19, 19);  // 이모티콘 이미지 크기 지정 19*19
            imageList.ColorDepth = ColorDepth.Depth24Bit;   // 이미지 해상도 24bit true 칼라
            imageList.Images.AddStrip(new Bitmap(GetType(), "emoticons.bmp")); //이미지 읽어오기
            imageList.TransparentColor = Color.FromArgb(255, 0, 255);  // 자주색으로 투명화 설정

            emo_wnd = new EmoticonWnd();   // 이모티콘 윈도우 개체 생성
            emo_wnd.Init(imageList, 8, 8, 10, 6);   // 이모티콘 윈도우에 아이콘 이미지 등록
            emo_wnd.ItemClick += new EmoticonWndEventHandler(OnItemClicked); // 이모티콘 클릭 이벤트 
            emo_wnd.Show();  // 이모티콘 윈도우를 잠시 출력했다 닫음
            emo_wnd.Hide();

            InitializeComponent();    // 폼 디자이너가 생성한 코드
        }

        /// 문자열 정보 출력
        /// <param name="msg">문자열</param>
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
                    this.txt_Info.AppendText(msg + "\r\n");  // 문자열 추가
                    this.txt_Info.ScrollToCaret();	        // 입력 포커스가 있는 부분으로 스크롤
                    this.txt_Input.Focus();                 // 채팅 입력창에 포커스를 맞춤
                }
            }
            catch { } // 멀티 스레드 환경에서 뜻하지 않은 예외가 발생할 경우 처리
        }



        /// RichText 데이터 추가
        /// <param name="msg">출력할 RTF 데이터</param>
        public void Add_RichData(string msg)
        {
            try
            {
                if (this.txt_Info.InvokeRequired) // 컨트롤 요청이 들어올 경우
                {   // 델리게이트를 이용해 Add_MSG 메서드를 다시 호출
                    SetTextCallback d = new SetTextCallback(Add_RichData);
                    this.Invoke(d, new object[] { msg });
                }
                else
                {   // 컨트롤 접근이 가능할 경우, 다음 구문 처리
                    this.txt_Info.Select(txt_Info.TextLength, 0);
                    this.txt_Info.SelectedRtf = msg;    // RTF 문서 연결시킴
                    this.txt_Info.Focus();
                    this.txt_Info.ScrollToCaret();
                    this.txt_Input.Focus();
                }
            }
            catch { } // 멀티 스레드 환경에서 뜻하지 않은 예외가 발생할 경우 처리
        }

        /// 상태바에 메시지 출력
        /// <param name="msg">출력 메시지</param>
        public void Add_Status(string msg)
        {
            try
            {
                if (this.statusBar.InvokeRequired) // 컨트롤 요청이 들어올 경우
                {   // 델리게이트를 이용해 Add_MSG 메서드를 다시 호출
                    SetTextCallback d = new SetTextCallback(Add_Status);
                    this.Invoke(d, new object[] { msg });
                }
                else
                {   // 컨트롤 접근이 가능할 경우, 다음 구문 처리
                    this.statusBar.Text = msg;  // 상태바에 메시지 출력
                }
            }
            catch { } // 멀티 스레드 환경에서 뜻하지 않은 예외가 발생할 경우 처리            
        }




        /// 이모티콘 윈도우에서 마우스를 클릭할 때 발생하는 이벤트
        private void OnItemClicked(object sender, EmoticonWndEventArgs ewea)
        {
            try
            {
                this.m_index = ewea.SelectedItem;  // 현재 선택한 이모티콘 불러옴
                Thread thread = new Thread(new ThreadStart(PasteEmoticon));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
                this.txt_Input.Paste();
            }
            catch{}
        }

        private void PasteEmoticon()
        {
            try
            {
                Bitmap bitmap = new Bitmap(19, 19);
                Graphics gp = Graphics.FromImage(bitmap);
                this.imageList.Draw(gp, 0, 0, 19, 19, this.m_index);
                Clipboard.Clear();
                Clipboard.SetImage(bitmap);
            }
            catch { }
        }
 


        private void MainWnd_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (btn_Connect.Text == "접속중...")  // 만약 채팅 서버에 접속 중이라면
                {
                    this.net.Disconnect(); // 채팅 서버와의 연결을 종료합니다.
                }
                this.net.ServerStop();  // 채팅 서버 프로그램이 실행중이면 종료합니다.
                if ((server_th != null) && (server_th.IsAlive))
                    server_th.Abort();	   // 채팅 서버 프로그램 종료		
            }
            catch (Exception ex)   // 예외가 발생하면 에러 메시지 출력
            {
                MessageBox.Show(ex.Message);
            }	
        }

        private void btn_Server_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_Server.Text == "서버 시작")  // 채팅 서버를 켜면
                {      // Network 클래스의 ServerStart 메서드 호출
                    server_th = new Thread(new ThreadStart(this.net.ServerStart));
                    server_th.IsBackground = true;
                    server_th.Start();	// 채팅 서버 스레드 실행

                    btn_Server.Text = "서버 멈춤";
                }
                else  // 채팅 서버를 종료하면
                {
                    this.net.ServerStop();   // 채팅 서버 종료
                    if (server_th.IsAlive) server_th.Abort();	  // 채팅 스레드 종료

                    btn_Server.Text = "서버 시작";
                }
            }
            catch (Exception ex)
            {
                this.Add_MSG(ex.Message);
            }
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (btn_Connect.Text == "서버 연결")        //  채팅 서버에 연결을 시도합니다.
            {
                string ip = txt_IP.Text.Trim();   // 채팅 서버 아이피 주소 가져오기		
                if (ip == "")  // 만약 아이피 주소가 없다면
                {
                    MessageBox.Show("아이피 번호를 입력하세요!");
                    return;
                }
                if (!this.net.Connect(ip))  // 아이피 주소에 접속을 시도합니다.
                {
                    MessageBox.Show("서버 아이피 번호가 틀리거나\r\n 서버가 작동중이지 않습니다.");
                }
                else   // 채팅 서버에 접속이 성공하면 버튼 글자를 변경합니다.
                {
                    btn_Connect.Text = "접속중...";
                }
            }
            else     // 채팅 서버에 연결된 접속을 끊을 때 
            {
                this.net.Disconnect();      //  채팅 서버 연결을 끊습니다.
                btn_Connect.Text = "서버 연결"; // ꋐ 버튼 글자를 변경합니다.
            }

        }

        private void btn_Font_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog(); // 폰트 다이얼로그 객체 생성  
            dlg.ShowColor = true;              // 폰트 다이얼로그에서 색 선택부분 활성화

            dlg.Font = this.chat_font;     // 기본 글꼴을 현재 채팅창에 설정된 글꼴로 대체
            dlg.Color = this.chat_color;   // 기본 색상을 현재 채팅창에 설정된 색상으로 대체

            if (dlg.ShowDialog() == DialogResult.OK)  // 폰트와 색상을 선택하면
            {
                this.txt_Input.Font = dlg.Font;       // ꋖ입력창 글꼴 갱신
                this.txt_Input.ForeColor = dlg.Color; // ꋖ 입력창 글꼴 색상 변경
                this.chat_font = dlg.Font;            // ꋓ채팅 메시지 출력창 글꼴 변경
                this.chat_color = dlg.Color;          // ꋓ 채팅 메시지 출력창 색상 변경
            }

        }

        private void btn_Emoticon_Click(object sender, EventArgs e)
        {      
            // [이모티콘] 버튼의 우측 하단부에 이모티콘 윈도우 출력
            Point pt = new Point(btn_Emoticon.Right, btn_Emoticon.Bottom);
            pt = this.PointToScreen(pt);
            emo_wnd.ShowWnd(pt);  // 이모티콘 윈도우 출력   
        }

        private void txt_Input_KeyDown(object sender, KeyEventArgs e)
        {
            // 엔터키가 눌리면 문자열 메시지 전송
            if (e.KeyCode == Keys.Enter)
            {
                string chat_msg = txt_Input.Rtf;
                string msg = "CTOC_CHAT_MESSAGE_INFO\a" + chat_msg; this.net.Send(msg);

                this.Add_MSG("[" + my_ip + "] 님의 말");
                this.Add_RichData(chat_msg);

                this.newtxtsend = false;
                txt_Input.Text = "";
                txt_Input.Focus();
            }
            else  // 새 문자열 입력 신호 전달하는 부분
            {
                if (newtxtsend == false)
                {
                    // 새로운 문자열 신호 보냄
                    this.net.Send("CTOC_CHAT_NEWTEXT_INFO\a");
                    newtxtsend = true;
                }
            }

        }
    }
}