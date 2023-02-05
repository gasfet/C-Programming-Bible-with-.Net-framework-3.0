﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;          // 파일 전송 기능 추가

namespace MainChat
{
    public partial class MainWnd : Form
    {
        private Network net = null;
        private FileTransfer ft = null;

        private Thread server_th = null;
        private Thread file_server_th = null;
        private string my_ip = null;
        private bool newtxtsend = false;		
        
        private Font chat_font = new Font("굴림체", 10); // 채팅 기본 글꼴 지정
        private Color chat_color = Color.Black;       // 채팅 글꼴 색상

        private ImageList imageList = null;
        private EmoticonWnd emo_wnd = null;

        delegate void SetTextCallback(string msg);  // 문자열 출력 델리게이트
        delegate void ProgressBarSetDataCallback(double index, long total_size);
        // 프로그래스바 처리 델리게이트 

        public MainWnd()
        {
            net = new Network(this);
            ft = new FileTransfer(this);

            my_ip = net.Get_MyIP();

            imageList = new ImageList();
            imageList.ImageSize = new Size(19, 19);
            imageList.ColorDepth = ColorDepth.Depth24Bit;
            imageList.Images.AddStrip(new Bitmap(GetType(), "emoticons.bmp"));
            imageList.TransparentColor = Color.FromArgb(255, 0, 255);

            emo_wnd = new EmoticonWnd();
            emo_wnd.Init(imageList, 8, 8, 10, 6);
            emo_wnd.ItemClick += new EmoticonWndEventHandler(OnItemClicked);
            emo_wnd.Show();
            emo_wnd.Hide();

            InitializeComponent();
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


        public void ProgressBarInit()
        {
            this.prg_Bar.Minimum = 0;
            this.prg_Bar.Maximum = 100;
        }

        public void ProgressBarSetData(double index, long total_size)
        {
            try
            {
                if (this.prg_Bar.InvokeRequired) // 컨트롤 요청이 들어올 경우
                {   // 델리게이트를 이용해 Add_MSG 메서드를 다시 호출
                    ProgressBarSetDataCallback d = new ProgressBarSetDataCallback(ProgressBarSetData);
                    this.Invoke(d, new object[] { index, total_size });
                }
                else
                {   // 컨트롤 접근이 가능할 경우, 다음 구문 처리
                    this.prg_Bar.Value = (int)((index * 100) / total_size);
                }
            }
            catch { } // 멀티 스레드 환경에서 뜻하지 않은 예외가 발생할 경우 처리               
        }


        private void MainWnd_Load(object sender, EventArgs e)
        {
            file_server_th = new Thread(new ThreadStart(this.ft.ServerStart));
            file_server_th.IsBackground = true;
            file_server_th.Start();	
        }

        private void MainWnd_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (btn_Connect.Text == "접속중...")
                {
                    this.net.DisConnect();
                    this.ft.DisConnect();
                }
                /////// 파일 서버 ///////////////////
                this.ft.ServerStop();

                if (file_server_th.IsAlive)
                    file_server_th.Abort();
                ////////////////////////////////////
                this.net.ServerStop();

                if ((server_th != null) && (server_th.IsAlive))
                    server_th.Abort();

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
                {
                    server_th = new Thread(new ThreadStart(this.net.ServerStart));
                    server_th.IsBackground = true;
                    server_th.Start();

                    btn_Server.Text = "서버 멈춤";
                }
                else
                {
                    this.net.ServerStop();

                    if (server_th.IsAlive)
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
                string ip = txt_IP.Text.Trim();
                string port = txt_Port.Text.Trim();
                if (ip == "")
                {
                    MessageBox.Show("아이피 번호를 입력하세요!");
                    return;
                }

                if (!this.net.Connect(ip, port))
                {
                    MessageBox.Show("서버 아이피 주소가 틀리거나\r\n 서버가 작동중이지 않습니다.");
                }
                else
                {
                    this.ft.Connect(ip); // 파일 서버 접속
                    btn_Connect.Text = "접속중...";   // 접속이 성공하면...
                }
            }
            else
            {
                this.net.DisConnect();
                this.ft.DisConnect();   // 파일 서버 접속 해지
                btn_Connect.Text = "서버 연결";
            }
        }

        private void btn_Font_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.ShowColor = true;              // 색 선택

            dlg.Font = this.chat_font;
            dlg.Color = this.chat_color;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_Input.Font = dlg.Font;
                this.txt_Input.ForeColor = dlg.Color;
                this.chat_font = dlg.Font;
                this.chat_color = dlg.Color;
            }
        }

        private void btn_FileSend_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "전송할 파일을 지정하세요!";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileInfo send_file = new FileInfo(dlg.FileName);

                string msg = "CTOC_FILE_TRANS_INFO\a" +
                              send_file.Name + "\a" +
                              send_file.Length.ToString();

                this.ft.Send(msg);

                this.ft.file_info = send_file;
            }
        }

        private void btn_Emoticon_Click(object sender, EventArgs e)
        {
            Point pt = new Point(btn_Emoticon.Right, btn_Emoticon.Bottom);
            pt = this.PointToScreen(pt);

            emo_wnd.ShowWnd(pt);
        }

        private void OnItemClicked(object sender, EmoticonWndEventArgs ewea)
        {

            int index = ewea.SelectedItem;

            Bitmap bitmap = new Bitmap(19, 19);
            Graphics gp = Graphics.FromImage(bitmap);
            this.imageList.Draw(gp, 0, 0, 19, 19, index);

            Clipboard.SetDataObject(bitmap);
            DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);

            if (txt_Input.CanPaste(myFormat))
            {
                //그림을 보여준다.
                txt_Input.Paste(myFormat);
            }
            else
            {
                MessageBox.Show("이모티콘 붙여넣기가 실패했습니다.!");
            }
        }

        private void txt_Input_KeyDown(object sender, KeyEventArgs e)
        {
            // 엔터키가 눌리면 문자열 메시지 전송
            if (e.KeyCode == Keys.Enter)
            {
                string chat_msg = txt_Input.Rtf;

                string msg = "CTOC_CHAT_MESSAGE_INFO\a"
                    + chat_msg;

                this.net.Send(msg);

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