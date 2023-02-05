using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace P2PClient
{
    /// <summary>
    /// ChatClient�� ���� ��� �����Դϴ�.
    /// �����鿡 ������ ������ ã�� Ŭ���̾�Ʈ �κ�
    /// </summary>
    public class SearchClient
    {

        private const int BUFFER = 4096;  // ���� ����..

        private SearchWnd dlg = null;       // ���� �˻�â... 

        public FileDownWnd fdown = null;    // ���� �ٿ�ε�...

        private Socket connect = null;   // ���� ����


        /// ����/Ŭ���̾�Ʈ ���		
        public NetworkStream stream;      // ��Ʈ��ũ ��Ʈ�� 
        public StreamReader read;         // �б�
        public StreamWriter write;        // ����

        public int port = 7008;          // ���� ��Ʈ ��ȣ
        private Thread Reader;            // �б� ������


        /// <summary>
        /// SearchClient ������ 
        /// </summary>
        /// <param name="dlg">���� �˻�â</param>
        public SearchClient(SearchWnd dlg)
        {
            this.dlg = dlg;             // ���� �˻�â ����
        }

        /// <summary>
        /// SearchClient ������
        /// </summary>
        /// <param name="fdown">���� �ٿ�ε� â</param>
        public SearchClient(FileDownWnd fdown)
        {
            this.fdown = fdown;
        }


        /// <summary>
        /// ���� ����
        /// </summary>
        /// <param name="server_ip">������ ���� ������</param>
        /// <param name="message">������ �޽���</param>
        public void Connect(string server_ip, string message)
        {
            connect = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint E_IP = new IPEndPoint(IPAddress.Parse(server_ip), port);

            try
            {
                connect.Connect(E_IP);  // ���� �õ�				
            }
            catch    // ������ �����ϸ�
            {
                if (this.fdown != null)
                    fdown.Set_Connect("> ���� ����!");
                else
                    this.dlg.Set_Message(server_ip + " ���� ���� ����!");
                return;
            }
            // ��Ʈ��ũ ��Ʈ�� ����
            stream = new NetworkStream(connect);

            read = new StreamReader(stream); // �о����
            write = new StreamWriter(stream);// ������ ��Ʈ�� ����


            // ���� �˻� ��û ������ ����...
            if (this.fdown != null)
            {
                Reader = new Thread(new ThreadStart(ReceiveFile));
                Reader.IsBackground = true;
                Reader.Start();
            }
            else  // ���� �˻�
            {
                Reader = new Thread(new ThreadStart(Receive));
                Reader.IsBackground = true;
                Reader.Start();
            }

            this.Send(message);

        }

        /// <summary>
        /// ����� ��������
        /// </summary>
        public void Disconnect()
        {
            read.Close();            // �б� ����
            write.Close();		     // ���� ����			 				
            stream.Close();          // ��Ʈ�� ����
            if (fdown != null && fdown.CLOSE_DLG == true) fdown.Close();
            try
            {
                Reader.Abort();      // ������ ����
            }
            catch { }                 // ������ ����� ���� ó��			
        }

        /// <summary>
        /// ���� ������ �����ϱ�
        /// </summary> 
        private void ReceiveFile()
        {
            FileStream fs = null;              // ���� ��Ʈ��
            string file_name = fdown.downdirectory + "\\" + fdown.fname;
            long total_size = Int64.Parse(fdown.fsize);
            long remain_size = 0;

            if (File.Exists(file_name))
            {
                fs = new FileStream(file_name, FileMode.Open, FileAccess.ReadWrite);
                if (total_size == fs.Length)
                {
                    fs.Close();
                    this.fdown.Set_Connect("�����Ϸ��� ���ϰ� ������ ������ �̹� �ֽ��ϴ�!");
                    return;
                }
                else
                {
                    remain_size = fs.Length;
                }
            }
            else
            {
                fs = new FileStream(file_name, FileMode.Create, FileAccess.Write);
            }

            long total = 0;
            long left_size = total_size - remain_size;
            int recv_size = 0;

            long prg_value = 0;
            long time = 0;
            long times = 0;

            BinaryWriter bw = null;

            Byte[] data = new byte[BUFFER];

            this.fdown.Progress_Bar_Make((int)total_size);

            try
            {
                bw = new BinaryWriter(fs);

                if (remain_size > 0)
                {
                    bw.Seek((int)remain_size, SeekOrigin.Begin); // �̾�ޱ� ���
                    this.fdown.Set_Connect("���� �̾�ޱ� ó����...");
                    prg_value += remain_size;
                }

                times = DateTime.Now.Ticks;

                while (total < (total_size - remain_size))
                {
                    if (DateTime.Now.Ticks - time > 10E6) // 0.1��
                    {
                        time = DateTime.Now.Ticks;
                        if ((time - times) == 0)
                        {
                            this.fdown.Set_lblInfo(total + remain_size, 1, total_size);
                        }
                        this.fdown.Set_lblInfo(total + remain_size, time - times, total_size);
                        this.fdown.Progress_Bar((int)total);
                    }

                    if (left_size > BUFFER)
                        recv_size = this.connect.Receive(data, BUFFER, SocketFlags.None);
                    else
                        recv_size = this.connect.Receive(data, (int)left_size, SocketFlags.None);

                    if (recv_size == 0) break;

                    bw.Write(data, 0, recv_size);

                    total += recv_size;
                    left_size -= recv_size;
                }

                this.fdown.Progress_Bar((int)total_size);
                this.fdown.Set_Connect("���� ���� �Ϸ�!");
                this.fdown.Set_lblInfo(total_size);
                this.fdown.Button_Text = "�ݱ�";
                if (this.fdown.CLOSE_DLG)
                {
                    this.fdown.FileDown_Close();
                }

            }
            catch (Exception ex)
            {
                this.fdown.Set_Connect(ex.Message);
            }
            finally
            {
                if (bw != null) bw.Close();
                if (fs != null) fs.Close();
            }
        }

        /// <summary>
        ///  ���� ������ ���� Ŭ���̾�Ʈ
        /// </summary>
        public void Receive()
        {
            try
            {
                // ���� �޽��� �о����
                string message = read.ReadLine().Trim();

                // �޽������о��
                if (message != null)
                {
                    char[] ch = { '#' }; // # �� ��ū���� ���ڿ� �и�
                    string[] token = message.Split(ch); // ���ڿ� �и�

                    switch (token[0])
                    {
                        //     ���� : S_S_FILE#�˻�����IP#���ϰ���#�����̸�&���ϻ�����&
                        //   	���ϻ�����&�����̸�&���ϻ�����......
                        case "S_S_FILE": // ���� �˻� ���							    
                            string[] file = token[3].Split('&');// & �� ��ū���� ���� ��������
                            int k = Int32.Parse(token[2]) * 3; // �����̸�,������,������
                            for (int i = 0; i < k; i += 3)
                            {
                                lock (dlg)
                                { // �Ӱ� ���� ó��
                                    // ����Ʈ�信 �߰�
                                    dlg.Add_ListViwe(file[i], file[i + 1], file[i + 2], token[1]);
                                    // ������ ���� �޽��� ���
                                    this.dlg.Set_Message(token[1] + " ���� ������ ����!");
                                }
                            }
                            break;
                    }
                }
            }

            finally
            {
                lock (dlg)
                {
                    dlg.Progress_Bar();
                }
                Disconnect();
            }
        }

        /// <summary>
        ///  �޽��� ����
        /// </summary>
        /// <param name="str">������ �޽���</param>
        public void Send(string str)
        {
            try
            {
                write.WriteLine(str);
                write.Flush();

            }
            catch
            {
                this.dlg.Set_Message(" ������ ������ ����!");
                // "������ ������ ����!";
            }
        }

    }
}
