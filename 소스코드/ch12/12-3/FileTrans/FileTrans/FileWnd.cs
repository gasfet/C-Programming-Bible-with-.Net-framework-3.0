using System;
using System.Windows.Forms;
using System.Threading;       // 네임스페이스 추가
using System.IO;              // 네임스페이스 추가 

namespace FileTrans
{
    public partial class FileWnd : Form
    {
        private FileTransfer ft = null;             // 파일 전송 클래스 객체 변수
        private Thread server_th = null;	        // 스레드 	
        delegate void SetTextCallback(string msg);  // Add_MSG 메서드 델리게이트
        delegate void SetProgressBarInitCallback(); // ProgressBarInit 메서드 델리게이트
        delegate void SetProgressCallback(double index, long total_size);  // ProgressBarSetData 메서드 델리게이트


        public FileWnd()
        {
            InitializeComponent();
            ft = new FileTransfer(this);	  // FileTransfer 객체 변수 추가		
        }

        // txt_Info 텍스트 박스에 문자열(msg)을 출력합니다.
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
                    this.txt_Info.ScrollToCaret();	            // txt_info 텍스트 박스 자동 스크롤
               }
            }
            catch { } // 멀티 스레드 환경에서 뜻하지 않은 예외가 발생할 경우 처리
        }

        // 파일 수신 진행 상태를 표시하기위해 prg_Bar 프로그래스바를 초기화합니다.
        public void ProgressBarInit()
        {
            try
            {
                if (this.prg_Bar.InvokeRequired) // 컨트롤 요청이 들어올 경우
                {   // 델리게이트를 이용해 ProgressBarInit 메서드를 다시 호출
                    SetProgressBarInitCallback d = new SetProgressBarInitCallback(ProgressBarInit);
                    this.Invoke(d, new object[] {});
                }
                else
                {   // 컨트롤 접근이 가능할 경우, 다음 구문 처리   
                    this.prg_Bar.Minimum = 0;
                    this.prg_Bar.Maximum = 100;
                }
            }
            catch { } // 멀티 스레드 환경에서 뜻하지 않은 예외가 발생할 경우 처리
        }

        // 프로그래스바에 진행 상태를 표시합니다.
        public void ProgressBarSetData(double index, long total_size)
        {
            try
            {
                if (this.prg_Bar.InvokeRequired) // 컨트롤 요청이 들어올 경우
                {   // 델리게이트를 이용해 ProgressBarSetData 메서드를 다시 호출
                    SetProgressCallback d = new SetProgressCallback(ProgressBarSetData);
                    this.Invoke(d, new object[] { index, total_size });
                }
                else
                {   // 컨트롤 접근이 가능할 경우, 다음 구문 처리               
                    this.prg_Bar.Value = (int)((index * 100) / total_size);
                }
            }
            catch { } // 멀티 스레드 환경에서 뜻하지 않은 예외가 발생할 경우 처리
        }



        private void FileWnd_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (btn_Connect.Text == "접속중...")
                {
                    this.ft.Disconnect();	// 파일 서버 접속 해제
                }

                this.ft.ServerStop();  // 파일 서버 작동 중지

                if ((server_th != null) && (server_th.IsAlive))
                    server_th.Abort();	// 수신 스레드 종료	
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }			


        }

        private void btn_Server_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_Server.Text == "서버 시작")
                {         // 파일 서버 스레드를 실행합니다.
                    server_th = new Thread(new ThreadStart(this.ft.ServerStart));
                    server_th.Start();	 // 파일 서버 실행

                    btn_Server.Text = "서버 멈춤";
                }
                else   // 버튼 글자가 “서버 멈춤”일 경우
                {
                    this.ft.ServerStop();    // 파일 서버 중지
                    if (server_th.IsAlive)    // 파일 서버 스레드 중지
                        server_th.Abort();

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
            if (btn_Connect.Text == "서버 연결")
            {
                string ip = txt_IP.Text.Trim();  // 작동중인 파일 서버 아이피 주소를 가져옵니다.
                if (ip == "")
                {
                    MessageBox.Show("아이피 주소를 입력하세요!");
                    return;
                }

                if (!this.ft.Connect(ip))  // 파일 서버 연결 시도
                {
                    MessageBox.Show("서버 아이피 주소가 틀리거나\r\n 서버가 작동중이지 않습니다.");
                }
                else // 파일 서버에 연결이 되면
                {
                    btn_Connect.Text = "접속중...";   // 버튼 문자열을 “접속중...”으로 변경
                }
            }
            else    // 서버 연결을 끝내고 싶을 경우...
            {
                this.ft.Disconnect();    // 채팅 서버 연결 종료
                btn_Connect.Text = "서버 연결";
            }

        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();   // 상대에게 보낼 파일 선택
            dlg.Title = "전송할 파일을 선택하세요!";

            if (dlg.ShowDialog() == DialogResult.OK)
            {   // 파일 정보 읽어오기
                FileInfo send_file = new FileInfo(dlg.FileName);
                // 파일 정보 메시지 작성하기, 파일이름, 파일 크기
                string msg = "CTOC_FILE_TRANS_INFO\a" + send_file.Name + "\a" +
                         send_file.Length.ToString();
                this.ft.Send(msg);           // 파일 정보 보내기
                this.ft.file_info = send_file;  // 전송할 파일 정보 설정
            }

        }
    }
}