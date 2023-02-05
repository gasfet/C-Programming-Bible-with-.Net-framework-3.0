using System;
using System.Drawing;
using System.Windows.Forms;

namespace MultiChatClient
{
    public partial class MainWnd : Form
    {
        private Network net = null;
        private string my_ip = null;
        private bool newtxtsend = false;

        private Font chat_font = new Font("굴림체", 10); // 채팅 기본 글꼴 지정
        private Color chat_color = Color.Black;       // 채팅 글꼴 색상

        private ImageList imageList = null;
        private EmoticonWnd emo_wnd = null;

        delegate void SetTextCallback(string msg);  // 문자열 출력 델리게이트

        public MainWnd()
        {
            net = new Network(this);
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
    

  
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (btn_Connect.Text == "서버 연결")
            {
                string ip = txt_IP.Text.Trim();
                if (ip == "")
                {
                    MessageBox.Show("아이피 번호를 입력하세요!");
                    return;
                }

                if (!this.net.Connect(ip, txt_Port.Text.Trim()))
                {
                    MessageBox.Show("서버 아이피 번호가 틀리거나\r\n 서버가 작동중이지 않습니다.");
                }
                else
                {
                    btn_Connect.Text = "접속중...";   // 접속이 성공하면...
                }
            }
            else
            {
                // 서버에 종료 메시지 전송
                this.net.Send("CTOS_MESSAGE_END\a" + this.net.Get_MyIP());
                this.net.DisConnect();
                btn_Connect.Text = "서버 연결";
            }
        }


        private void MainWnd_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (btn_Connect.Text == "접속중...")
                {
                    // 서버에 종료 메시지 전송
                    this.net.Send("CTOS_MESSAGE_END\a" + this.net.Get_MyIP());
                    this.net.DisConnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                if (btn_Connect.Text == "접속중...")
                {
                    this.net.Send(msg);
                    this.Add_MSG("[" + my_ip + "] 님의 말");
                    this.Add_RichData(chat_msg);
                    this.newtxtsend = false;
                }
                else
                {
                    this.Add_MSG("서버에 연결되어 있지 않습니다.!");
                }

                txt_Input.Text = "";
                txt_Input.Focus();
            }
            else  // 새 문자열 입력 신호 전달하는 부분
            {
                if (newtxtsend == false)
                {
                    // 새로운 문자열 신호 보냄
                    if (btn_Connect.Text == "접속중...")
                    {
                        this.net.Send("CTOC_CHAT_NEWTEXT_INFO\a");
                        newtxtsend = true;
                    }
                }
            }

        }

    }
}