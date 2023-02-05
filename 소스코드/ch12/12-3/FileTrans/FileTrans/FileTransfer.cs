using System;
using System.Net;               // ��Ʈ��ũ
using System.Net.Sockets;       // ����
using System.IO;                // ���� �����
using System.Threading;         // ������ ó��
using System.Windows.Forms;   // �޽��� �ڽ� ���
using System.Text;              // ���ڿ� ���ڵ�

namespace FileTrans
{
    public class FileTransfer
    {
        private FileWnd wnd = null;          // ���� ���� ������
        private Socket server = null;         // ������ ���� 
        private Socket client = null;          // ���� ���ӿ� ���� 
        private Thread th = null;             // ���� ���� ���� Receive �޼��� ������
        private string client_ip = null;        // ������ ������ �ּ�
        public FileInfo file_info = null;       // ���� ����
        private const int BUFFER = 4096;   // ��Ʈ��ũ���� �ѹ��� ������ ����Ʈ �迭�� ũ��

        public FileTransfer(FileWnd wnd)     // FileTransfer Ŭ���� ������
        {
            this.wnd = wnd;
        }


        /// ���� ���� ���α׷� ����
        public void ServerStart()
        {
            try
            {   // 7500 �� ��Ʈ�� �̿��� ���� ���� ���� 			
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 7500);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(ipep);  // ���� ���ε�
                server.Listen(10);  // Ŭ���̾�Ʈ ���� ���
                this.wnd.Add_MSG("���� ���� ����...");

                this.client = server.Accept();   // Ŭ���̾�Ʈ�� �����ϸ� 

                IPEndPoint ip = (IPEndPoint)this.client.RemoteEndPoint;   // ���� ������ �˾Ƴ���
                this.wnd.Add_MSG(ip.Address + "����...");

                this.client_ip = ip.Address.ToString();  // ������ ���� ������ �ּ� ����

                th = new Thread(new ThreadStart(Receive)); // Receive �޼��� ������ ����
                th.Start();
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// ���� ���α׷� ����
        public void ServerStop()
        {
            try
            {
                if (client != null)
                {
                    if (client.Connected)  // ���� ���� Ŭ���̾�Ʈ�� ����Ǿ� �ִٸ�
                    {
                        client.Close();   // Ŭ���̾�Ʈ ���� ����							if(th.IsAlive)
                        th.Abort();  // ������ ����
                    }
                } server.Close();   // ���� ���� ���� �ݱ�
                this.wnd.Add_MSG("���� ���� ����...");
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }


        /// ���� ������ ���� �õ�
        /// <param name="ip">������ ���� ������ �ּ�</param>
        public bool Connect(string ip)
        {
            try
            {   // ������ ���� ���� ������ �ּҿ� ��Ʈ��ȣ ����
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 7500);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(ipep);  // ���� ������ ����   
                this.wnd.Add_MSG(ip + "������ ���� ����...");
                this.client_ip = ip;   // ���� ���� ������ �ּ� ���

                th = new Thread(new ThreadStart(Receive));  // ���� ������ ������ ������ ����
                th.Start();

                return true;   // ���� ���� ���ӿ� �����ϸ� true �� ��ȯ
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
                return false;   // ���� ���� ���ӿ� �����ϸ� false �� ��ȯ
            }
        }

        /// ���� ���� ���� ����...
        public void Disconnect()
        {
            try
            {
                if (client != null)  // ���� ������ ���ӵǾ� �ִٸ�
                {
                    if (client.Connected) client.Close();  // ���� ����		
                    if (th.IsAlive) th.Abort();     // ������ ����
                }
                this.wnd.Add_MSG("���� ���� ���� ����!");
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// ���ӵ� �������κ��� ������ ����
        public void Receive()
        {
            try
            {         // ����� ����Ǿ� �ִٸ� 
                while (client != null && client.Connected)
                {        // ������ ���� ������ �о����
                    byte[] data = this.ReceiveData();
                    string msg = Encoding.Default.GetString(data);

                    string[] token = msg.Split('\a');

                    switch (token[0])
                    {
                        case "CTOC_FILE_TRANS_INFO":  // ������ ���� ����
                            FileInfo(token[1], Convert.ToInt64(token[2].Trim()));
                            break;

                        case "CTOC_FILE_TRANS_YES":	 // ���� ���� ����
                            long current_size = Convert.ToInt64(token[1].Trim());
                            this.SendFileData(this.file_info, current_size);
                            break;

                        case "CTOC_FILE_TRANS_NO":  // ���� ���� �ź�
                            this.wnd.Add_MSG("������ ���� ������ �ź��߽��ϴ�.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// ������ ���� �����͸� ���̳ʸ� ���·� �о����(���� ä�� �κ� ����)
        private byte[] ReceiveData()
        {
            try
            {
                int total = 0;
                int size = 0;
                int left_data = 0;
                int recv_data = 0;

                // ������ ������ ũ�� �˾Ƴ���   
                byte[] data_size = new byte[8];
                recv_data = this.client.Receive(data_size, 0, 8, SocketFlags.None);
                size = BitConverter.ToInt32(data_size, 0);
                left_data = size;
                byte[] data = new byte[size];
                // �������� ������ ���� ������ ����
                while (total < size)
                {
                    recv_data = this.client.Receive(data, total, left_data, SocketFlags.None);
                    if (recv_data == 0) break;
                    total += recv_data;
                    left_data -= recv_data;
                }
                return data;
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
                return null;
            }
        }

        /// ���ڿ� �޽��� ����
        /// <param name="msg">������ ���ڿ�</param>
        public void Send(string msg)
        {
            byte[] data = Encoding.Default.GetBytes(msg);
            this.SendData(data);
        }

        /// ���濡�� ���̳ʸ� ���·� ������ ������(���� ä�� �κ� ����)
        private void SendData(byte[] data)
        {
            try
            {
                int total = 0;
                int size = data.Length;
                int left_data = size;
                int send_data = 0;

                // ������ ���� �������� ũ�� ����
                byte[] data_size = new byte[4];
                data_size = BitConverter.GetBytes(size);
                send_data = this.client.Send(data_size);

                // ���� ������ ����
                while (total < size)
                {
                    send_data = this.client.Send(data, total, left_data, SocketFlags.None);
                    total += send_data;
                    left_data -= send_data;
                }
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// ���� ������ ����
        /// <param name="file">���濡�� ���� ���� ����</param>
        /// <param name="currentl_size">���濡�� ���� ���� ������ ��ġ</param>
        private void SendFileData(FileInfo file, long current_size)
        {
            long total_size = file.Length;  // ���� ũ��
            long size = file.Length - current_size;  // ���� ���� ��ġ ����
            long count = size / BUFFER;             // ������ Ƚ��
            long remain_byte = size % BUFFER;

            long index = 0;
            long prg_value = 0;
            long time = 0;

            FileStream fs = null;
            BinaryReader br = null;

            this.wnd.ProgressBarInit();      // ���α׷����� �ʱ�ȭ

            try
            {  // ������ ���� ���� ������ ũ�� ����
                fs = file.Open(FileMode.Open, FileAccess.Read, FileShare.Read);

                if (current_size > 0)   // ������ ���濡�� ���� ��� ���� ������ �̵�
                {
                    fs.Seek(current_size, SeekOrigin.Begin);
                    prg_value += current_size;
                }

                br = new BinaryReader(fs);   // ���� �о����

                Byte[] data = new byte[BUFFER]; // 4096 ������ �о ����

                while (index < count)
                {
                    if (DateTime.Now.Ticks - time > 10E7)// 1�ʸ��� ���α׷����� ����
                    {
                        time = DateTime.Now.Ticks;
                        this.wnd.ProgressBarSetData(prg_value + index * BUFFER, total_size);
                    }
                    br.Read(data, 0, BUFFER);
                    client.Send(data, 0, BUFFER, SocketFlags.None);
                    index++;
                }

                if (remain_byte > 0)   // �����ִ� �����Ͱ� �ִٸ�
                {
                    br.Read(data, 0, (int)remain_byte);
                    client.Send(data, 0, (int)remain_byte, SocketFlags.None);
                }

                this.wnd.ProgressBarSetData(total_size, total_size);
                this.wnd.Add_MSG("���� ���� �Ϸ�!");
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
            finally
            {
                if (br != null) br.Close();
                if (fs != null) fs.Close();
            }
        }

        /// ���� ������ ����
        /// <param name="fs">������ ���� ��Ʈ��</param>
        /// <param name="total_size">���� ��ü ũ��</param>
        /// <param name="remain_size">������ ���� ũ��</param>
        private void ReceiveFileData(FileStream fs, long total_size, long remain_size)
        {
            long total = 0;
            long left_size = remain_size;
            int recv_size = 0;

            long prg_value = 0;
            long time = 0;

            BinaryWriter bw = null;

            Byte[] data = new byte[BUFFER];  // 4096 ������ ������ ����

            this.wnd.ProgressBarInit();   // ���α׷����� �ʱ�ȭ

            try
            {
                bw = new BinaryWriter(fs);

                if (total_size > remain_size)   // �̾�ޱ� ����� ��� �ش� ��ġ�� ���� �������̵�
                {
                    bw.Seek((int)(total_size - remain_size), SeekOrigin.Begin);
                    this.wnd.Add_MSG("���� �̾�ޱ� ó����...");
                    prg_value += total_size - remain_size;
                }

                while (total < remain_size)
                {
                    if (DateTime.Now.Ticks - time > 10E7) // 1�ʸ��� ���α׷����� ����
                    {
                        time = DateTime.Now.Ticks;
                        this.wnd.ProgressBarSetData(prg_value + total, total_size);
                    }

                    if (left_size > BUFFER)
                        recv_size = this.client.Receive(data, BUFFER, SocketFlags.None);
                    else
                        recv_size = this.client.Receive(data, (int)left_size, SocketFlags.None);

                    if (recv_size == 0) break;
                    bw.Write(data, 0, recv_size);
                    total += recv_size;
                    left_size -= recv_size;
                }
                this.wnd.ProgressBarSetData(total_size, total_size);
                this.wnd.Add_MSG("�������� �Ϸ�!");
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
            finally
            {
                if (bw != null) bw.Close();
            }
        }

        // ������ �����Ϸ��� ���� �̸��� ũ�� ���, ���� ���ű�� ����
        public void FileInfo(string filename, long filesize)
        {	// �����̸�/����ũ��
            string message = this.client_ip + " ���� ������ ���ϸ� : " + filename +
                                    " (" + filesize + " byte)�� �ٿ� �����ðڽ��ϱ�?";
            this.wnd.Add_MSG(message);

            if (MessageBox.Show(message, "���� ���� Ȯ��", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question) == DialogResult.Yes)
            {    // ���� ���� Ȯ��				
                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate,
                                                      FileAccess.ReadWrite, FileShare.None);
                this.Send("CTOC_FILE_TRANS_YES\a" + fs.Length.ToString());
                this.ReceiveFileData(fs, filesize, filesize - fs.Length); // ���� ���� ����
                fs.Close();  // ���� �ݱ�
            }
            else
            {   // ���� ���� �ź�
                this.wnd.Add_MSG(this.client_ip + " ���� ���� ���Ͽ� ���� ����ڰ� ������ �ź��߽��ϴ�.");
                this.Send("CTOC_FILE_TRANS_NO\a");
            }
        }
    }
}

