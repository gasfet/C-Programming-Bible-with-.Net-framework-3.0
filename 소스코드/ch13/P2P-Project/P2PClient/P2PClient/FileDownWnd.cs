using System;
using System.Data;
using System.Windows.Forms;

// ��Ʈ��ũ ó���� ���� ���� �����̽�
using System.Net;
using System.IO;  // ���� �����


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


        //*** ���� ���� ***//
        public string fname = null; // ���� �̸�
        public string fsize = null; // ���� ũ��
        public string ftime = null; // ���� �����ð�
        string s_ip = null;        // ������ �ִ� ��ǻ��

        SearchClient s_client = null; // ���� �ޱ� Ŭ���̾�Ʈ

        public string downdirectory;  // ���� ���� ���丮

        /// <summary>
        /// ���� ���� �Ϸ�� ��ҹ�ư ���ڸ� �ݱ�� ����
        /// </summary>
        public string Button_Text
        {
            set
            {
                SetBtnCancel(value);
            }
        }

        /// <summary>
        ///  �����ޱ� �Ϸ�� �ڵ����� ��ȭ���� ���� �Ӽ� 
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
        ///  FileDown Ŭ���� ������
        /// </summary>
        /// <param name="downdirectory">�ʱ� �ٿ�ε� ���丮</param>
        public FileDownWnd(string downdirectory)
        {
            InitializeComponent();
            this.downdirectory = downdirectory; // �ʱ� �ٿ�ε� ���丮 ����
        }

        /// <summary>
        ///  ���� ���� ���
        /// </summary>
        /// <param name="fname">���� �̸�</param>
        /// <param name="fsize">���� ũ��</param>
        /// <param name="ftime">���� ������</param>
        /// <param name="s_ip">���� ��ġ(IP)</param>
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
                    string str;  // ����� ���ڿ� ���� ����

                    this.fname = fname;
                    this.fsize = fsize;
                    this.ftime = ftime;
                    this.s_ip = s_ip;

                    str = "> �����̸� : " + fname + "\r\n";  //\r\n�� �ٹٲ�
                    str += "> ������ġ : " + s_ip + "\r\n";
                    str += "> �������Դϴ�.\r\n";

                    this.txt_connect.Text = str;   // �ؽ�Ʈ �ڽ��� ���ڿ� ���
                }
            }
            catch { }
        }


        /// <summary>
        /// ���� ���� ���α׷����� �ʱ�ȭ �޼���
        /// </summary>
        /// <param name="total">���α׷������� ��ü ũ��</param>
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
                    this.prg_down.Minimum = 0;      // ���α׷������� �ּ� ��
                    this.prg_down.Maximum = total;  // ���α׷������� �ִ� ��			 
                    this.prg_down.Value = 0;        // ���� ���α׷������� ��ġ 	
                }
            }
            catch { }		
        }


        /// <summary>
        /// ���� ���� ���α׷����� ���� �޼���
        /// </summary>
        /// <param name="current">���� ��ġ</param>
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
                    {   // ���࿡ �ִ� ���������� ũ�ٸ�
                        this.prg_down.Value = prg_down.Maximum; // ���� ���α׷������� ��ġ��
                    }                                        // ���α׷������� �ִ밪
                    else
                    {   // �׷��� �ʴٸ�
                        this.prg_down.Value = current;           // current ��ġ�� ����
                    }
                }
            }
            catch { }
        }


        /// <summary>
        /// ���� ���� ���� ǥ�� �޼���
        /// </summary>
        /// <param name="total">���� ���۷�</param>
        /// <param name="time">���� �ð�</param>
        /// <param name="size">��ü ũ�� </param>
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
                    double speed = (total) / ((time + 1) / 1024.0);             // �������۷�/���۽ð�
                    double remain_time = ((size - total) / 1024.0) / speed;     // ���� �ð� ���

                    double ftotal = total / 1024.0 / 1024.0;    // 1024.0/1024.0 �� MegaByte�� ȯ��
                    double fsize = size / 1024.0 / 1024.0;     // 1024.0/1024.0 �� MegaByte�� ȯ��

                    string str = string.Format(" ���۷�     : {0:##0.00}M/{1:##0.00}M\r\n", ftotal, fsize);
                    str += string.Format(" ���� �ӵ� : {0:##0.00}kbs\r\n", speed);
                    str += string.Format(" ���� �ð�  :  {0:##0.00} ��\r\n", remain_time / 10.0);
                    lbl_info.Text = str;                   // ���� ���ڿ� ǥ��                    
                }
            }
            catch { }
        }

        /// <summary>
        /// �� ���� ���۷� ǥ�� �޼���
        /// </summary>
        /// <param name="size">���� ��ü ũ��</param>
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

                    string str = string.Format(" ���۷�     : {0:##0.00}M/{1:##0.00}M\r\n", fsize, fsize); ;
                    str += " ���� �ӵ� :  0 kbps\r\n";
                    str += " �����ð�  :  0 ��";
                    this.lbl_info.Text = str;
                }
            }
            catch { }
        }

        /// <summary>
        ///  ���� �ٿ�ε尡 ���۵Ǹ� �޽��� â�� ���� �ٲ���
        /// </summary>
        /// <param name="str">���� �ٿ�ε� ������ ���� ���ڿ�</param>
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
                    // ���� �ٿ�ε� �޽��� ����
                    this.txt_connect.Text = txt_connect.Text + "> ���� �ٿ�ε� ���Դϴ�.\r\n";
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
                    this.Close();			    // ���� â�� ����
                }
            }
            catch { }
        }


        /// <summary>
        /// ���� �ٿ�ε� â �ݱ�
        /// </summary>
        public void FileDown_Close()
        {
            if (this.s_client != null)
                this.s_client.Disconnect(); // ���� ����� ������ ����
            FormClose();
        }


        /// <summary>
        /// ��� ��ư�� Ŭ�������� �߻��ϴ� �޼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (this.s_client != null)
                this.s_client.Disconnect(); // ���� �������� ������ �����ϴ�.
            FormClose();

        }


        /// <summary>
        /// FileDown Ŭ���� â�� ȭ�鿡 ��� ���� �۵��ϴ� �޼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileDownWnd_Load(object sender, EventArgs e)
        {
            long current_size = 0;
            //***   �ڽ��� ��ǻ�� IP�� �˾Ƴ��� ����  ***//
            string myIP = null;
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            myIP = host.AddressList[0].ToString();
            //*******************************************//			

            // ���� �ٿ�������� ������ �̹� �����Ѵٸ�
            string file_name = downdirectory + "\\" + fname;
            FileInfo finfo = new FileInfo(file_name);
            if (File.Exists(file_name))
            {
                current_size = finfo.Length;
            }


            string message = "S_C_FILEDOWN#" + myIP + "#";  // ���� �ٿ�ε� ��û		  
            message += this.fname.Trim() + "#" + current_size.ToString().Trim();

            s_client = new SearchClient(this);  // ���� ������ ���� �ν��Ͻ� ����

            s_client.Connect(this.s_ip.Trim(), message); // ������ �޽��� ����		      
            // Ŭ���̾�Ʈ ������ ���� �ٿ� ��û..!!

        }

 
    }
}