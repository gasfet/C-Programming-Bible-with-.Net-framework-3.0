using System;
using System.Data;
using System.Windows.Forms;

// 네트워크 처리를 위한 네임 스페이스
using System.Net;
using System.IO;  // 파일 입출력


namespace P2PClient
{
    public partial class FileDownWnd : Form
    {
        delegate void InvokeSetBtnCancele(string text);
        delegate void InvokeSet_Info(string fname, string fsize, string ftime, string s_ip);
        delegate void InvokeProgress_Bar_Make(int total);
        delegate void InvokeProgress_Bar(int current);
        delegate void InvokeSet_lblInfo1(long total, long time, long size);
        delegate void InvokeSet_lblInfo2(long size);
        delegate void InvokeSet_Connect(string str);
        delegate void InvokeInitText();
        delegate void InvokeFormClose();


        //*** 파일 정보 ***//
        public string fname = null; // 파일 이름
        public string fsize = null; // 파일 크기
        public string ftime = null; // 파일 생성시간
        string s_ip = null;        // 파일이 있는 컴퓨터

        SearchClient s_client = null; // 파일 받기 클라이언트

        public string downdirectory;  // 파일 저장 디렉토리

        /// <summary>
        /// 파일 전송 완료시 취소버튼 글자를 닫기로 변경
        /// </summary>
        public string Button_Text
        {
            set
            {
                SetBtnCancel(value);
            }
        }

        /// <summary>
        ///  내려받기 완료시 자동으로 대화상자 닫음 속성 
        /// </summary>
        public bool CLOSE_DLG
        {
            get
            {
                return this.cb_close.Checked;
            }
        }

        private void SetBtnCancel(string text)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeSetBtnCancele d = new InvokeSetBtnCancele(SetBtnCancel);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.btn_cancel.Text = text;
                }
            }
            catch { }
        }
        

        /// <summary>
        ///  FileDown 클래스 생성자
        /// </summary>
        /// <param name="downdirectory">초기 다운로드 디렉토리</param>
        public FileDownWnd(string downdirectory)
        {
            InitializeComponent();
            this.downdirectory = downdirectory; // 초기 다운로드 디렉토리 저장
        }

        /// <summary>
        ///  파일 정보 출력
        /// </summary>
        /// <param name="fname">파일 이름</param>
        /// <param name="fsize">파일 크기</param>
        /// <param name="ftime">파일 생성일</param>
        /// <param name="s_ip">파일 위치(IP)</param>
        public void Set_Info(string fname, string fsize, string ftime, string s_ip)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeSet_Info d = new InvokeSet_Info(Set_Info);
                    this.Invoke(d, new object[] { fname, fsize, ftime, s_ip });
                }
                else
                {
                    string str;  // 출력할 문자열 저장 변수

                    this.fname = fname;
                    this.fsize = fsize;
                    this.ftime = ftime;
                    this.s_ip = s_ip;

                    str = "> 파일이름 : " + fname + "\r\n";  //\r\n은 줄바꿈
                    str += "> 파일위치 : " + s_ip + "\r\n";
                    str += "> 연결중입니다.\r\n";

                    this.txt_connect.Text = str;   // 텍스트 박스에 문자열 출력
                }
            }
            catch { }
        }


        /// <summary>
        /// 파일 전송 프로그래스바 초기화 메서드
        /// </summary>
        /// <param name="total">프로그래스바의 전체 크기</param>
        public void Progress_Bar_Make(int total)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeProgress_Bar_Make d = new InvokeProgress_Bar_Make(Progress_Bar_Make);
                    this.Invoke(d, new object[] { total });
                }
                else
                {
                    this.prg_down.Minimum = 0;      // 프로그래스바의 최소 값
                    this.prg_down.Maximum = total;  // 프로그래스바의 최대 값			 
                    this.prg_down.Value = 0;        // 현재 프로그래스바의 위치 	
                }
            }
            catch { }		
        }


        /// <summary>
        /// 파일 전송 프로그래스바 설정 메서드
        /// </summary>
        /// <param name="current">현재 위치</param>
        public void Progress_Bar(int current)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeProgress_Bar d = new InvokeProgress_Bar(Progress_Bar);
                    this.Invoke(d, new object[] { current });
                }
                else
                {
                    if (current > prg_down.Maximum)
                    {   // 만약에 최대 지정값보다 크다면
                        this.prg_down.Value = prg_down.Maximum; // 현재 프로그래스바의 위치는
                    }                                        // 프로그래스바의 최대값
                    else
                    {   // 그렇지 않다면
                        this.prg_down.Value = current;           // current 위치로 지정
                    }
                }
            }
            catch { }
        }


        /// <summary>
        /// 파일 전송 상태 표시 메서드
        /// </summary>
        /// <param name="total">현재 전송량</param>
        /// <param name="time">전송 시간</param>
        /// <param name="size">전체 크기 </param>
        public void Set_lblInfo(long total, long time, long size)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeSet_lblInfo1 d = new InvokeSet_lblInfo1(Set_lblInfo);
                    this.Invoke(d, new object[] { total, time, size });
                }
                else
                {
                    double speed = (total) / ((time + 1) / 1024.0);             // 현재전송량/전송시간
                    double remain_time = ((size - total) / 1024.0) / speed;     // 남은 시간 계산

                    double ftotal = total / 1024.0 / 1024.0;    // 1024.0/1024.0 은 MegaByte로 환산
                    double fsize = size / 1024.0 / 1024.0;     // 1024.0/1024.0 은 MegaByte로 환산

                    string str = string.Format(" 전송량     : {0:##0.00}M/{1:##0.00}M\r\n", ftotal, fsize);
                    str += string.Format(" 전송 속도 : {0:##0.00}kbs\r\n", speed);
                    str += string.Format(" 남은 시간  :  {0:##0.00} 초\r\n", remain_time / 10.0);
                    lbl_info.Text = str;                   // 현재 문자열 표시                    
                }
            }
            catch { }
        }

        /// <summary>
        /// 총 파일 전송량 표시 메서드
        /// </summary>
        /// <param name="size">파일 전체 크기</param>
        public void Set_lblInfo(long size)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeSet_lblInfo2 d = new InvokeSet_lblInfo2(Set_lblInfo);
                    this.Invoke(d, new object[] { size });
                }
                else
                {
                    double fsize = size / 1024.0 / 1024.0;

                    string str = string.Format(" 전송량     : {0:##0.00}M/{1:##0.00}M\r\n", fsize, fsize); ;
                    str += " 전송 속도 :  0 kbps\r\n";
                    str += " 남은시간  :  0 초";
                    this.lbl_info.Text = str;
                }
            }
            catch { }
        }

        /// <summary>
        ///  파일 다운로드가 시작되면 메시지 창의 줄을 바꿔줌
        /// </summary>
        /// <param name="str">파일 다운로드 정보에 대한 문자열</param>
        public void Set_Connect(string str)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeSet_Connect d = new InvokeSet_Connect(Set_Connect);
                    this.Invoke(d, new object[] { str });
                }
                else
                {
                    this.txt_connect.Text = this.txt_connect.Text + "\r\n" + str;
                    this.txt_connect.ScrollToCaret();                    
                }
            }
            catch { } 
        }

        private void InitText()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeInitText d = new InvokeInitText(InitText);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    // 파일 다운로드 메시지 전송
                    this.txt_connect.Text = txt_connect.Text + "> 파일 다운로드 중입니다.\r\n";
                    this.txt_connect.ScrollToCaret();
                    this.txt_connect.Focus();
                }
            }
            catch { }
        }

        private void FormClose()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeFormClose d = new InvokeFormClose(FormClose);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    this.Close();			    // 현재 창을 닫음
                }
            }
            catch { }
        }


        /// <summary>
        /// 파일 다운로드 창 닫기
        /// </summary>
        public void FileDown_Close()
        {
            if (this.s_client != null)
                this.s_client.Disconnect(); // 현재 연결된 서버를 끊고
            FormClose();
        }


        /// <summary>
        /// 취소 버튼을 클릭했을때 발생하는 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (this.s_client != null)
                this.s_client.Disconnect(); // 파일 서버와의 접속을 끊습니다.
            FormClose();

        }


        /// <summary>
        /// FileDown 클래스 창이 화면에 띄기 전에 작동하는 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileDownWnd_Load(object sender, EventArgs e)
        {
            long current_size = 0;
            //***   자신의 컴퓨터 IP를 알아내는 구문  ***//
            string myIP = null;
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            myIP = host.AddressList[0].ToString();
            //*******************************************//			

            // 만약 다운받으려는 파일이 이미 존재한다면
            string file_name = downdirectory + "\\" + fname;
            FileInfo finfo = new FileInfo(file_name);
            if (File.Exists(file_name))
            {
                current_size = finfo.Length;
            }


            string message = "S_C_FILEDOWN#" + myIP + "#";  // 파일 다운로드 요청		  
            message += this.fname.Trim() + "#" + current_size.ToString().Trim();

            s_client = new SearchClient(this);  // 서버 연결을 위한 인스턴스 생성

            s_client.Connect(this.s_ip.Trim(), message); // 서버에 메시지 전송		      
            // 클라이언트 서버에 파일 다운 요청..!!

        }

 
    }
}