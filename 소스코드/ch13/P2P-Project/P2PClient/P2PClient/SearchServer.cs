using System;
using System.Collections;
using System.IO;
using System.Threading;
using System.Net.Sockets;

using System.Net;        // TCP ����


namespace P2PClient
{

    /// <summary>
    /// ���� �˻� ���� ���� Ŭ����
    /// </summary> 
    class SearchServer
    {
        TcpListener listener;
        Thread th;

        bool stop;         // ���� ���� flag
        int port = 7008;   // ���� �˻� ������ 7008

        SearchWnd dlg = null;  // �˻� â 

        /// <summary>
        ///  SearchServer ������
        /// </summary>
        /// <param name="dlg"></param> 
        public SearchServer(SearchWnd dlg)
        {
            this.dlg = dlg;
        }

        /// <summary>
        /// Ŭ���̾�Ʈ �䱸�� ó��
        /// </summary>
        public void Accept()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();  // TCP ������ �۵�
            }
            catch
            {
                return;
            }

            while (true)
            {
                // Ŭ���̾�Ʈ  ������ �����
                Socket socket = listener.AcceptSocket();

                if (socket.Connected) // Ŭ���̾�Ʈ�� �����ϸ�...
                {
                    new SClient(socket, dlg);
                }
            }
        }

        /// <summary>
        ///���� �˻� ���� ������ ����
        /// </summary>
        public void Start()
        {
            // ������ ����
            th = new Thread(new ThreadStart(Accept));
            th.IsBackground = true;
            // ������ ����
            th.Start();
            stop = true;
        }

        /// <summary>
        ///  ���� �˻� ���� ������ ����
        /// </summary>
        public void Stop()
        {
            if (stop)            // stop �÷��׸� �˻��ؼ�
            {
                listener.Stop();   // Listener ����				

                stop = false;      // stop �÷��׸� false�� �ٲ�
                try
                {
                    th.Abort();       // ������ ����
                }
                catch { }

            }
        }
    }


    /// <summary>
    /// ���� �˻�&���� ó�� Ŭ���̾�Ʈ Ŭ����
    /// </summary>
    class SClient
    {
        private const int BUFFER = 4096;  // ���� ����..

        StreamReader read;    // �Է� ��Ʈ��
        StreamWriter write;   // ��� ��Ʈ��
        NetworkStream stream;  // ��Ʈ��
        Socket socket;  // ����

        Thread reader;   // �о���� ������

        SearchWnd dlg = null;  // ���� �ۼ��� ������ ���̾˷α� 

        /// <summary>
        ///  SClient ������
        /// </summary>
        /// <param name="socket">����</param>
        /// <param name="dlg">�˻�â</param>
        public SClient(Socket socket, SearchWnd dlg)
        {
            this.socket = socket;
            this.dlg = dlg;
            if (this.socket.Connected)
            {// ����ȴٸ�
                stream = new NetworkStream(socket);
                read = new StreamReader(stream);  // ��Ʈ�� �б�
                write = new StreamWriter(stream); //  ��Ʈ�� ������

                reader = new Thread(new ThreadStart(Receive));
                reader.IsBackground = true;
                reader.Start();

            }
        }

        /// <summary>
        /// ���� ����
        /// </summary>
        public void Close()
        {
            read.Close();            // �б� ����
            write.Close();		     // ���� ����			 				
            stream.Close();          // ��Ʈ�� ����
            socket.Close();

            try
            {
                reader.Abort();  // ������ ����
            }
            catch { } // ������ ����� ���� ó��

        }

        /// <summary>
        ///  �޽��� ����
        /// </summary>
        public void Receive()
        {
            try
            {
                string message = read.ReadLine().Trim();
                // �޽������о��
                if (message != null)
                {
                    char[] ch = { '#' };
                    string[] token = message.Split(ch);

                    switch (token[0])
                    {
                        case "S_RES_REFRESH": // ���� ��� ����
                            lock (dlg)
                            {
                                dlg.client.Refresh_List(token[1]);
                                this.dlg.Set_Message(" ���� ��� ���� : " + DateTime.Now.ToLongTimeString());
                            }

                            break;


                        case "S_C_FILE":  // Ŭ���̾�Ʈ�� ���� �̸� �˻� ��û
                            //���� : S_C_FILE#�˻���û��ǻ��IP#�˻� ���ϸ�
                            SearchFile(token[1], token[2]);// ���� �˻�
                            lock (dlg)
                            {
                                this.dlg.Set_Message(token[1] + " Ŭ���̾�Ʈ " + token[2] + " �˻� ��û");
                            }
                            break;

                        //���� : S_S_FILEDOWN#Ŭ���̾�ƮIP#�����̸�#����ũ�� 
                        case "S_C_FILEDOWN": // Ŭ���̾�Ʈ ���� �ٿ�ε� ��û  
                            lock (dlg)
                            {
                                this.dlg.Set_Message(token[0] + " Ŭ���̾�Ʈ " + token[1] + " ��������");
                            }
                            FileSend(token[2], Convert.ToInt64(token[3]));
                            break;

                    }
                }
            }
            catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// �޽��� ����
        /// </summary>
        /// <param name="msg">������ �޽���</param>
        public void Send(string msg)
        {
            write.WriteLine(msg);
            write.Flush();
        }

        /// <summary>
        /// Ŭ���̾�Ʈ ��û ���� �˻�
        /// </summary>
        /// <param name="IP">��û ��ǻ�� ������</param>
        /// <param name="filename">�˻��� �����̸�</param>
        private void SearchFile(string IP, string str)
        {
            // ���� �˻�
            FindFile find = new FindFile(this.dlg.client.sharedirectory);
            // �˻��� ���� ���� ��������
            string searchinfo = find.SearchFile(str);

            // �ڽ��� IP��ȣ �˾Ƴ���
            string myIP;
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            myIP = host.AddressList[0].ToString();

            // �˻��� ����� �˻� ���� ������ �߰��ؼ� ����
            string message = "S_S_FILE#" + myIP + "#" + searchinfo;

            Send(message);  // ���� �˻� ��� ������
        }


        /// <summary>
        ///  ���� ����
        /// </summary>
        /// <param name="fname">���� �̸�</param>
        /// <param name="current_size">���� ���� ũ��</param>
        private void FileSend(string fname, long current_size)
        {
            fname = this.dlg.client.sharedirectory + "\\" + fname;
            FileInfo file = new FileInfo(fname);
            long total_size = file.Length;
            long size = file.Length - current_size;
            long count = size / BUFFER;
            long remain_byte = size % BUFFER;

            long index = 0;

            FileStream fs = null;
            BinaryReader br = null;

            try
            {
                // ������ ���� ���� ������ ũ�� ����
                fs = file.Open(FileMode.Open, FileAccess.Read, FileShare.Read);


                if (current_size > 0)   // �ִ� ������ �ǳʶٱ�
                {
                    fs.Seek(current_size, SeekOrigin.Begin);
                }

                br = new BinaryReader(fs);

                Byte[] data = new byte[BUFFER];

                while (index < count)
                {
                    br.Read(data, 0, BUFFER);
                    this.socket.Send(data, 0, BUFFER, SocketFlags.None);
                    index++;
                }

                if (remain_byte > 0)
                {
                    br.Read(data, 0, (int)remain_byte);
                    this.socket.Send(data, 0, (int)remain_byte, SocketFlags.None);
                }
            }
            catch { }
            finally
            {
                if (br != null) br.Close();
                if (fs != null) fs.Close();
            }
        }

    }
}
