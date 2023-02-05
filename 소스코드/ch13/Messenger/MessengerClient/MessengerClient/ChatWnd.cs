using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Threading;

namespace MessengerClient
{
    public delegate void InvokeMessage();
    public delegate void InvokeAddMsg(string gmsg);
    public delegate void InvokeShowProgreess(bool flag);
    public delegate void InvokeProgressBarSetData(double index, long total_size);        
    public delegate void InvokeShowEmoticon(Point pt);
    public delegate void InitEmoticon();


    public partial class ChatWnd : Form
    {

        #region 멤버 변수/속성

        private ChatNetwork net = null;      // 채팅 문자열 통신  
        private FileClient ft = null;        // 파일 전송
        private string m_strFileName = null; // 전송할 파일 이름

        private bool newtxtsend = false;      // 새로운 문자열 입력이 있는지 확인 	        

        private Font chat_font = new Font("굴림체", 10); // 채팅 기본 글꼴 지정
        private Color chat_color = Color.Black;       // 채팅 글꼴 색상

        private ImageList imageList = null;    // 이모티콘 이미지 저장   
        private EmoticonWnd emo_wnd = null;    // 이모티콘 윈도우
        private int  m_index = 0;


        #endregion


        #region 멤버 속성


        public string USERID
        {
            get
            {
                return this.net.USERID;
            }
        }

        public FileClient FT
        {
            set
            {
                this.ft = value;
            }
        }

        #endregion

        #region 생성자
        /// <summary>
        /// 내가 상대방에게 대화 요청
        /// </summary>
        /// <param name="net">상대방과 통신하는 소켓</param>
        /// <param name="flag">true : 상대방 연결, false : 내가 요청</param>
        public ChatWnd(ChatNetwork net, bool flag)
        {
            InitializeComponent();

            this.prg_Bar.Parent = this.statusBar;
            this.prg_Bar.Dock = DockStyle.Fill;
            this.prg_Bar.SendToBack();
            this.prg_Bar.Visible = false;

            this.net = net;

            // 파일 전송 소켓
            if (flag)  // 상대방이 연결했다면.. 내가 상대방 파일 서버에 다시 접속
            {
                this.ft = new FileClient(this, this.net.ClientIP.Trim());
            }

            this.lbl_userid.Text = this.net.USERID;

            imageList = new ImageList();
            imageList.ImageSize = new Size(19, 19);
            imageList.ColorDepth = ColorDepth.Depth24Bit;
            imageList.Images.AddStrip(new Bitmap(GetType(), "Image_Emoticons.bmp"));
            imageList.TransparentColor = Color.FromArgb(255, 0, 255);

            emo_wnd = new EmoticonWnd();
            emo_wnd.Init(imageList, 8, 8, 10, 6);
            emo_wnd.ItemClick += new EmoticonWndEventHandler(OnItemClicked);
        }

        #endregion

        #region 멤버 메서드

        
      
        /// <summary>
        /// 프로그래스바 출력
        /// </summary>
        /// <param name="flag"></param>
        public void ProgressBar(bool flag)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeShowProgreess obj = new InvokeShowProgreess(ProgressBar);
                    this.Invoke(obj, new object[] { flag });
                }
                else
                {
                    this.prg_Bar.Visible = flag;
                }
            }
            catch { }
            
        }

       

        /// <summary>
        /// 프로그래스바 초기화
        /// </summary>
        public void ProgressBarInit()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeMessage obj = new InvokeMessage(ProgressBarInit);
                    this.Invoke(obj, new object[] { });
                }
                else
                {
                    this.prg_Bar.Minimum = 0;
                    this.prg_Bar.Maximum = 100;
                }
            }
            catch { }            
        }

        
        /// <summary>
        /// 프로그래스바 진행률 표시
        /// </summary>
        /// <param name="index"></param>
        /// <param name="total_size"></param>
        public void ProgressBarSetData(double index, long total_size)
        {            
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeProgressBarSetData obj = new InvokeProgressBarSetData(ProgressBarSetData);
                    this.Invoke(obj, new object[] { index, total_size });
                }
                else
                {
                    this.prg_Bar.Value = (int)((index * 100) / total_size);
                }
            }
            catch { }
        }

        
        /// <summary>
        /// 문자열 정보 출력
        /// </summary>
        /// <param name="msg">문자열</param>
        public void Add_MSG(string msg)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeAddMsg obj = new InvokeAddMsg(Add_MSG);
                    this.Invoke(obj, new object[] { msg });
                }
                else
                {
                    this.txt_Info.AppendText(msg + "\r\n");
                    this.txt_Info.ScrollToCaret();
                    this.txt_Input.Focus();
                }
            }
            catch { }
        }

       

        /// <summary>
        /// RichText 데이터 추가
        /// </summary>
        /// <param name="msg"></param>
        public void Add_RichData(string msg)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeAddMsg obj = new InvokeAddMsg(Add_RichData);
                    this.Invoke(obj, new object[] { msg });
                }
                else
                {
                    this.txt_Info.Select(this.txt_Info.TextLength, 0);
                    this.txt_Info.SelectedRtf = msg;
                    this.txt_Info.Focus();
                    this.txt_Info.ScrollToCaret();
                    this.txt_Input.Focus();
                }
            }
            catch { }
        }

        
        /// <summary>
        /// 상태바에 메시지 출력
        /// </summary>
        /// <param name="msg"></param>
        public void Add_Status(string msg)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeAddMsg obj = new InvokeAddMsg(Add_Status);
                    this.Invoke(obj, new object[] { msg });
                }
                else
                {
                    this.statusBar.Text = msg;
                }
            }
            catch { }
        }


        /// <summary>
        /// 이모티콘 출력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ewea"></param>
        private void OnItemClicked(object sender, EmoticonWndEventArgs ewea)
        {
            try
            {
                this.m_index = ewea.SelectedItem;                                
                Thread thread = new Thread(new ThreadStart(PasteEmoticon));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();

                this.txt_Input.Paste();
            }
            catch { }
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
  

     

        /// <summary>
        /// 채팅중에 에러 발생할 경우 실행
        /// </summary>
        public void Error()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeMessage obj = new InvokeMessage(Error);
                    this.Invoke(obj, new object[] { });
                }
                else
                {
                    this.txt_Input.ReadOnly = true;
                    this.txt_Input.BackColor = Color.Gray;
                }
            }
            catch { }
        }

        /// <summary>
        /// 에러 발생후 재 접속할 경우
        /// </summary>
        public void ReConnect()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeMessage obj = new InvokeMessage(ReConnect);
                    this.Invoke(obj, new object[] { });
                }
                else
                {
                    this.txt_Input.ReadOnly = false;
                    this.txt_Input.BackColor = System.Drawing.SystemColors.Window;
                }
            }
            catch { }
        }

        #endregion

        /// <summary>
        /// 글꼴 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Font_Click(object sender, System.EventArgs e)
        {
            try
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
            catch
            {
                this.Add_MSG("폰트 설정 에러 발생!!!");
            }
        }

        /// <summary>
        /// 파일 전송 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_FileSend_Click(object sender, System.EventArgs e)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(OpenFileDialogShow));
                thread.IsBackground = true;
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();

                FileInfo send_file = new FileInfo(this.m_strFileName);

                string msg = (byte)MSG.CTOC_FILE_TRANS_INFO + "\a";
                msg += send_file.Name + "\a";
                msg += send_file.Length.ToString();

                this.ft.Send(msg);
                this.ft.file_info = send_file;
            }
            catch { }
        }

        private void OpenFileDialogShow()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "전송할 파일을 선택하세요!";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.m_strFileName = dlg.FileName;
            }
        }


        /// <summary>
        /// 이모티콘 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Emoticon_Click(object sender, System.EventArgs e)
        {
                Point pt = new Point(btn_Emoticon.Right, btn_Emoticon.Bottom);
                pt = this.PointToScreen(pt);

                InvokeShowEmoticon obj = new InvokeShowEmoticon(ShowEmoticon_D);
                this.Invoke(obj, new object[] { pt });                        
        }

        public void ShowEmoticon_D(Point pt)
        {
            if (this.emo_wnd.Visible)
            {
                this.emo_wnd.Hide();            
            }
            else
            {
                this.emo_wnd.ShowWnd(pt);
            }
      
        }

        /// <summary>
        /// 전송 버튼 눌림
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SendMSG_Click(object sender, System.EventArgs e)
        {
            try
            {
                string chat_msg = txt_Input.Rtf.Trim();

                string msg = (byte)MSG.CTOC_CHAT_MESSAGE_INFO + "\a" + (MainWnd.CHAT_Crypto ? "1" : "0");

                this.net.Send(msg);

                if (MainWnd.CHAT_Crypto)
                {
                    CryptoAPI crypt = new CryptoAPI();
                    this.net.Send(crypt.Encryptor(chat_msg));
                }
                else
                {
                    this.net.Send(chat_msg);
                }


                this.Add_MSG("[" + MainWnd.MYID + "] 님의 말");
                this.Add_RichData(chat_msg);

                this.newtxtsend = false;

                txt_Input.Text = "";
                txt_Input.Focus();
            }
            catch { }
        }


        /// <summary>
        /// 채팅 문자열 입력후 엔터키 눌림
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txt_Input_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                // 엔터키가 눌리면 문자열 메시지 전송
                if (e.KeyCode == Keys.Enter)
                {
                    string chat_msg = txt_Input.Rtf;

                    string msg = (byte)MSG.CTOC_CHAT_MESSAGE_INFO + "\a" + (MainWnd.CHAT_Crypto ? "1" : "0");

                    this.net.Send(msg);

                    if (MainWnd.CHAT_Crypto)
                    {
                        CryptoAPI crypt = new CryptoAPI();
                        this.net.Send(crypt.Encryptor(chat_msg));
                    }
                    else
                    {
                        this.net.Send(chat_msg);
                    }

                    this.Add_MSG("[" + MainWnd.MYID + "] 님의 말");
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
                        this.net.Send((byte)MSG.CTOC_CHAT_NEWTEXT_INFO + "\a");
                        newtxtsend = true;
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 채팅창 로딩 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatWnd_Load(object sender, System.EventArgs e)
        {
            try
            {
                InvokeMessage obj = new InvokeMessage(InitEmoticonWnd);
                this.Invoke(obj);
            }
            catch { }
        }

        /// <summary>
        /// 이모티콘 윈도우 초기화
        /// </summary>
        public void InitEmoticonWnd()
        {
            emo_wnd.Show();
            emo_wnd.Hide();
        }

        /// <summary>
        /// 채팅창 닫을때 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {  

            int index = 0;

            if (MainWnd.MEMBER.Count > 0)
            {
                foreach (ChatNetwork obj in MainWnd.MEMBER)
                {
                    if (obj.USERID == this.net.USERID)
                    {
                        break;
                    }
                    index++;
                }
                MainWnd.MEMBER.RemoveAt(index);
            }

                 // 채팅 및 파일 서버 연결을 끊음.
                this.net.DisConnect();
                this.ft.DisConnect();
            }
            catch { }
        }

    }
}