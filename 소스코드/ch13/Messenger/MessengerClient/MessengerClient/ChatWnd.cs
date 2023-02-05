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

        #region ��� ����/�Ӽ�

        private ChatNetwork net = null;      // ä�� ���ڿ� ���  
        private FileClient ft = null;        // ���� ����
        private string m_strFileName = null; // ������ ���� �̸�

        private bool newtxtsend = false;      // ���ο� ���ڿ� �Է��� �ִ��� Ȯ�� 	        

        private Font chat_font = new Font("����ü", 10); // ä�� �⺻ �۲� ����
        private Color chat_color = Color.Black;       // ä�� �۲� ����

        private ImageList imageList = null;    // �̸�Ƽ�� �̹��� ����   
        private EmoticonWnd emo_wnd = null;    // �̸�Ƽ�� ������
        private int  m_index = 0;


        #endregion


        #region ��� �Ӽ�


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

        #region ������
        /// <summary>
        /// ���� ���濡�� ��ȭ ��û
        /// </summary>
        /// <param name="net">����� ����ϴ� ����</param>
        /// <param name="flag">true : ���� ����, false : ���� ��û</param>
        public ChatWnd(ChatNetwork net, bool flag)
        {
            InitializeComponent();

            this.prg_Bar.Parent = this.statusBar;
            this.prg_Bar.Dock = DockStyle.Fill;
            this.prg_Bar.SendToBack();
            this.prg_Bar.Visible = false;

            this.net = net;

            // ���� ���� ����
            if (flag)  // ������ �����ߴٸ�.. ���� ���� ���� ������ �ٽ� ����
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

        #region ��� �޼���

        
      
        /// <summary>
        /// ���α׷����� ���
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
        /// ���α׷����� �ʱ�ȭ
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
        /// ���α׷����� ����� ǥ��
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
        /// ���ڿ� ���� ���
        /// </summary>
        /// <param name="msg">���ڿ�</param>
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
        /// RichText ������ �߰�
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
        /// ���¹ٿ� �޽��� ���
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
        /// �̸�Ƽ�� ���
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
        /// ä���߿� ���� �߻��� ��� ����
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
        /// ���� �߻��� �� ������ ���
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
        /// �۲� ��ư Ŭ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Font_Click(object sender, System.EventArgs e)
        {
            try
            {
                FontDialog dlg = new FontDialog();
                dlg.ShowColor = true;              // �� ����

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
                this.Add_MSG("��Ʈ ���� ���� �߻�!!!");
            }
        }

        /// <summary>
        /// ���� ���� Ŭ��
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
            dlg.Title = "������ ������ �����ϼ���!";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.m_strFileName = dlg.FileName;
            }
        }


        /// <summary>
        /// �̸�Ƽ�� ��ư Ŭ��
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
        /// ���� ��ư ����
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


                this.Add_MSG("[" + MainWnd.MYID + "] ���� ��");
                this.Add_RichData(chat_msg);

                this.newtxtsend = false;

                txt_Input.Text = "";
                txt_Input.Focus();
            }
            catch { }
        }


        /// <summary>
        /// ä�� ���ڿ� �Է��� ����Ű ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txt_Input_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                // ����Ű�� ������ ���ڿ� �޽��� ����
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

                    this.Add_MSG("[" + MainWnd.MYID + "] ���� ��");
                    this.Add_RichData(chat_msg);

                    this.newtxtsend = false;

                    txt_Input.Text = "";
                    txt_Input.Focus();
                }
                else  // �� ���ڿ� �Է� ��ȣ �����ϴ� �κ�
                {
                    if (newtxtsend == false)
                    {
                        // ���ο� ���ڿ� ��ȣ ����
                        this.net.Send((byte)MSG.CTOC_CHAT_NEWTEXT_INFO + "\a");
                        newtxtsend = true;
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// ä��â �ε� �̺�Ʈ
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
        /// �̸�Ƽ�� ������ �ʱ�ȭ
        /// </summary>
        public void InitEmoticonWnd()
        {
            emo_wnd.Show();
            emo_wnd.Hide();
        }

        /// <summary>
        /// ä��â ������ 
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

                 // ä�� �� ���� ���� ������ ����.
                this.net.DisConnect();
                this.ft.DisConnect();
            }
            catch { }
        }

    }
}