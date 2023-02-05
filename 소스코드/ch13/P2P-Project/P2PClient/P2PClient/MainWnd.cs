using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using System.IO;          // 입출력 처리
using System.Text;        // 문자열 처리
using System.Net;         // 네트워크 처리
using System.Net.Sockets; // TCP 소켓 사용 
using System.Threading;   // 스레드 사용

using Microsoft.Win32; // 레지스트리 값 읽어오기
/*   
 *   Microsoft.Win32 를 사용하는 부분은 플랫폼간 이식성이 없습니다. 
 *   윈도우에서만 지원되는 레지스트리 기능을 사용합니다.
 */

namespace P2PClient
{
    public partial class MainWnd : Form
    {
        delegate void InvokeFormShowHide(bool visible);  // MainWnd Show/Hide

        // 레지스트리 경로 
        const string strRegkey = "Software\\MagicSoft\\P2PClient";
        // 파일 공유 디렉토리 초기화
        public string sharedirectory = @"c:\";  // 초기값은 c:\
        // 파일 다운로드 디렉토리 초기화
        public string downdirectory = @"c:\";  // 초기값은 c:\ 

        // 파일 검색 창
        SearchWnd dlg = null;

        // 현재 자신의 IP 저장하는 변수, IP는 15자리 문자열		
        public string myIP = null;

        // 현재 활성화된 서버 목록 
        public string[] server_list;

        // 확장창 속성
        private bool extend = false;

        // 회원 가입 폼
        RegisterWnd reg = null;

        // 파일 검색 서버
        SearchServer sserver = null;


        // 서버/클라이언트 멤버		

        public NetworkStream stream;    // 네트워크 스트림 
        public StreamReader read;       // 데이터 읽어오기
        public StreamWriter write;      // 데이터 보내기

        public int port = 7007;        // P2P 서버 포트 번호

        private Thread Reader;          // 읽기 쓰레드

        public bool IsConnect = false;  // 서버 접속 플래그

        TcpClient client;               // P2P 서버 연결용 TCP클라이언트 

        public MainWnd()
        {            
            InitializeComponent();

            // 레지스트리에서 공유,다운로드 디렉토리 값 읽어오기
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey(strRegkey);

            // 레지스트리 값이 있다면
            if (regkey != null)
            {
                this.sharedirectory = (string)regkey.GetValue("SHARE"); // 공유 디렉토리 지정
                this.downdirectory = (string)regkey.GetValue("DOWN");  // 다운로드 디렉토리 지정
                regkey.Close();  // 레지스트리 키 닫기
            }
        }


        /// <summary>
        ///  메인 서버 연결
        /// </summary>
        public void Connect()
        {
            // P2P 서버 연결용 TcpClient 초기화
            client = new TcpClient();

            try
            {
                client.Connect(txt_server.Text, port); // 연걸 시도
            }
            catch
            {                  // 접속에 실패할 경우 예외 발생
                IsConnect = false; // 메인 서버 접속 실패!
                return;
            }

            IsConnect = true;  // 메인 서버에 접속 됨!


            stream = client.GetStream();        // 서버와 입출력 스트림 연결

            read = new StreamReader(stream);  // 읽어오기 스트림..
            write = new StreamWriter(stream); // 출력하기 스트림..

            Reader = new Thread(new ThreadStart(Receive)); // P2P 클라이언트 쓰레드 시작
            Reader.IsBackground = true;
            Reader.Start();

        }

        /// <summary>
        ///  메인 서버 연결 끊기
        /// </summary>
        public void Disconnect()
        {
            read.Close();      // 읽기 해제
            write.Close();	   // 쓰기 해제			 					
            stream.Close();    // 스트림 해제

            client.Close();    // 서버 연결 종료

            try
            {
                Reader.Abort();    // 쓰레드 종료
            }
            catch
            {
                //this.Close();      // 접속창 메모리 해제
            }
        }

        /// <summary>
        ///  메인 서버 데이터 읽기
        /// </summary>
        public void Receive()
        {
            try
            {
                while (IsConnect)
                {   // 서버와 접속되면 while 시작
                    // 서버에서 수신한 메시지를 줄단위로 읽어옴
                    string message = read.ReadLine().Trim();

                    // 읽어온 메시지가 있다면
                    if (message != null)
                    {
                        // # 토큰을 이용해 문자열 분석
                        char[] ch = { '#' };
                        string[] token = message.Split(ch);

                        switch (token[0])// 첫번째 토큰이
                        {
                            // 서버 에러 
                            case "S_RES_ERROR":
                                MessageBox.Show("서버 에러 :\r\n" + token[1]);
                                break;

                            /// 로그인 관련 

                            // 로그인 성공
                            case "S_RES_LOGINOK":
                                Server_List(token[1]);// 서버리스트
                                Login_OK(); // 로그인 처리 메서드
                                break;

                            // 로그인 실패
                            case "S_RES_LOGINFAIL":
                                MessageBox.Show("로그인 실패!");
                                this.IsConnect = false;  // 메인 서버와 연결 해제
                                break;

                            // 로그인 아이디 틀림
                            case "S_RES_USERIDFAIL":
                                MessageBox.Show("아이디 틀림!");
                                this.IsConnect = false;  // 메인 서버와 연결 해제
                                break;

                            // 비밀번호 틀림
                            case "S_RES_PASSWORD":
                                MessageBox.Show("비밀번호 틀림!");
                                this.IsConnect = false;  // 메인 서버와 연결 해제
                                break;

                            // 로그아웃							
                            case "S_RES_LOGOUT":
                                sserver.Stop(); // 파일 검색 서버 종료
                                this.IsConnect = false; // 메인 서버와 연결 해제
                                break;


                            /// 회원 가입 부분 

                            // 아이디가 사용가능 할때
                            case "S_RES_MEMBERIDOK":
                                reg.ID_OK = true;		// 아이디 중복체크 확인
                                MessageBox.Show("아이디 사용가능");
                                break;

                            // 아이디 사용 불가
                            case "S_RES_MEMBERIDFAIL":
                                MessageBox.Show("아이디 사용불가");
                                break;

                            // 회원 가입 성공
                            case "S_RES_MEMBEROK":
                                MessageBox.Show("회원가입 성공\n 프로그램을 다시 실행하고 로그인 해주세요^^!");
                                this.IsConnect = false; // 메인 서버와 연결 해제
                                break;

                            //회원 가입 실패
                            case "S_RES_MEMBERFAIL":
                                MessageBox.Show("회원 가입 실패");
                                this.IsConnect = false; // 메인 서버와 연결 해제
                                break;

                        }
                    }
                }
            }
            catch//(Exception e) // 메인서버와 통신에서 예외 발생할 경우
            {
               // MessageBox.Show(e.Message + "P2P 서버에서 데이터를 읽는 과정에서 오류가 발생했습니다.");
            }
            finally
            {
                Disconnect();  // 서버 연결 종료...				
            }

        }



        /// <summary>
        ///  메인 서버에 데이터 전송
        /// </summary>
        /// <param name="str"></param>
        public void Send(string str)
        {
            try
            {
                write.WriteLine(str);  // 서버에 데이터 전송
                write.Flush();
            }
            catch
            {
                MessageBox.Show("데이터 보내기 실패!");
            }
        }

        /// <summary>
        ///  P2P 파일 서버 목록 갱신 메서드
        /// </summary>
        /// <param name="str">새로운 서버 목록</param>
        public void Refresh_List(string str)
        {
            int i = 0;
            int index = server_list.Length + 1;     // 배열 하나 증가
            string[] temp_list = new string[index];// 서버 리스트를 하나 증가시키기 위해서 
            for (i = 0; i < index - 1; i++)          // 임시 문자열 배열 새로 생성
                temp_list[i] = server_list[i];        // 기존 서버 리스트 저장

            temp_list[index - 1] = str;               // 새롭게 추가된 리스트 저장 

            server_list = new string[index];        // 서버 리스트 목록 변경
            for (i = 0; i < index; i++)
                server_list[i] = temp_list[i];
        }


        /// <summary>
        ///  서버 리스트 저장 메서드
        /// </summary>
        /// <param name="str">서버 리스트 문자열</param>
        private void Server_List(string str)
        {
            // 서버 리스트 문자열 분석
            char[] ch = { '&' };
            string[] token = str.Split(ch);

            // 서버 리스트 배열 할당
            this.server_list = null;
            this.server_list = new string[token.Length - 1];

            // 서버 리스트 배열 저장
            for (int i = 1; i < token.Length; i++)
            {
                this.server_list[i - 1] = token[i];
            }
        }



        /// <summary>
        ///  로그인
        /// </summary>
        private void Login()
        {
            string str; // 전송 문자열 

            Connect();  // 서버와 연결... 

            // 현재 컴퓨터 아이피 주소 구하기
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            myIP = host.AddressList[0].ToString();


            // P2P 서버에 로그인 요청 문자열 
            // 형식: C_REQ_LOGIN#아이디#비밀번호#접속요청컴퓨터아이피
            str = "C_REQ_LOGIN#" + txt_id.Text.Trim() + "#" + txt_pwd.Text.Trim() + "#" + myIP;

            // P2P 서버에 문자열 전송
            Send(str);
        }


        /// <summary>
        ///  로그인 성공시 처리할 코드 
        /// </summary>
        private void Login_OK()
        {
            // 로그인이 성공하면 파일 검색창 초기화
            dlg = new SearchWnd(this);

            // 파일검색서버시작 
            sserver = new SearchServer(dlg);
            sserver.Start();

            // P2P서버에 서버 갱신된 정보 전송
            // P2P 서버는 이 메시지를 받고 접속한 모든 P2P파일 서버에
            // 현재 새롭게 로그인한 서버 아이피 전송
            this.Send("C_REQ_REFRESH#" + this.myIP.Trim());

            // 서버 로그인창 폼 닫기                    
            FormShowHide(false);            

            // 파일 검색창 띄우기		
            dlg.ShowDialog();
        }


        /// <summary>
        ///  로그아웃
        /// </summary>
        private void Logout()
        {
            // 로그아웃 메시지 전송
            string str = "C_REQ_LOGOUT#" + myIP.Trim();
            Send(str);
        }

        /// <summary>
        ///  접속 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_connect_Click(object sender, System.EventArgs e)
        {
            // 로그인 
            this.Login();
        }

        /// <summary>
        ///  확장 버튼 클릭 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///          		
        private void btn_extend_Click(object sender, System.EventArgs e)
        {
            if (!this.extend) // 창 확장 
            {
                Size extend = new Size(230, 320);
                this.Size = extend;
                this.btn_extend.Text = "▲";
                this.extend = true;
            }
            else             // 창 축소
            {
                Size initalsize = new Size(230, 180);
                this.Size = initalsize;
                this.btn_extend.Text = "▼";
                this.extend = false;
            }
        }

        /// <summary>
        ///  회원 가입창 띄우기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void btn_register_Click(object sender, System.EventArgs e)
        {
            // P2P 서버에 연결
            this.Connect();
            // 회원 가입창 띄우기
            reg = new RegisterWnd(this);
            reg.ShowDialog();
        }

        /// <summary>
        ///  트레이 아이콘 더블 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notify_Tray_DoubleClick(object sender, System.EventArgs e)
        {
            // 파일 검색창 보이기 & 활성화
            if (dlg != null)
            {
                if (!dlg.Visible)
                {
                    dlg.Show(); // 더블클릭시에 화면에 보임			
                    dlg.Activate();
                }
            }
        }

        /// <summary>
        /// 파일 검색창 보이기 메뉴 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctx_show_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!dlg.Visible)
                {
                    dlg.Show(); // 더블클릭시에 화면에 보임			
                    dlg.Activate();
                }
            }
            catch { }
        }

        /// <summary>
        ///  프로그램 종료 메뉴 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctx_exit_Click(object sender, System.EventArgs e)
        {
            try
            {
                // 파일 검색창 닫기
                dlg.Close();
                // P2P 서버에 로그아웃 메시지 전송
                this.Send("C_REQ_LOGOUT#" + myIP.Trim());
            }
            catch { }
            this.Close();
        }

        private void MainWnd_Load(object sender, EventArgs e)
        {
            Size initalsize = new Size(230, 180);
            this.Size = initalsize;
            this.btn_extend.Text = "▼";
            this.extend = false;
        }


        private void FormShowHide(bool visible)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeFormShowHide d = new InvokeFormShowHide(FormShowHide);
                    this.Invoke(d, new object[] { visible });
                }
                else
                {
                    this.Visible = visible; // MainWnd 창 Show, Visible 설정
                }
            }
            catch { }
        }


        /// <summary>
        /// P2PClient 가 종료될 때 Option에서 설정한 정보를 레지스트리에 저장함
        /// </summary> 
        private new void Close()
        {        
            //레지스트리에 공유, 다운 디렉토리 저장
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey(strRegkey, true);
            // 레지스트리가 없다면
            if (regkey == null)// 레지스트리를 새롭게 만듬
                regkey = Registry.CurrentUser.CreateSubKey(strRegkey);

            regkey.SetValue("SHARE", this.sharedirectory); // 공유 디렉토리 저장
            regkey.SetValue("DOWN", this.downdirectory); // 다운로드 디렉토리 저장

            regkey.Close(); // 레지스트리 닫기

            base.Close();   // 프로그램 종료
        }

    }
}