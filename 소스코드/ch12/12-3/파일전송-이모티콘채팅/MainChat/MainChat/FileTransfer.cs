using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Text;

namespace MainChat
{
    /// <summary>a
    /// FileTransfer�� ���� ��� �����Դϴ�.
    /// </summary>
    public class FileTransfer
    {
        private MainWnd wnd = null;

        private Socket server = null;
        private Socket client = null;
        private Thread th = null;

        private string client_ip = null;

        private const int BUFFER = 4096;

        public FileInfo file_info = null;

        public FileTransfer(MainWnd wnd)
        {
            this.wnd = wnd;
        }


        /// <summary>
        /// ���� ���α׷� ����
        /// </summary>
        public void ServerStart()
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 7500);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(ipep);
                server.Listen(10);
                this.wnd.Add_MSG("���� ���� ����...");

                this.client = server.Accept();

                IPEndPoint ip = (IPEndPoint)this.client.RemoteEndPoint;
                this.wnd.Add_MSG(ip.Address + "����...");

                this.client_ip = ip.Address.ToString();

                th = new Thread(new ThreadStart(Receive));
                th.IsBackground = true;
                th.Start();
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// ���� ���α׷� ����
        /// </summary>
        public void ServerStop()
        {
            try
            {
                if (client != null)
                {
                    if (client.Connected)
                    {
                        client.Close();  // Ŭ���̾�Ʈ ���� ����				

                        if (th.IsAlive)
                            th.Abort();      // ������ ����
                    }
                }

                server.Close();
                this.wnd.Add_MSG("���� ���� ����...");

            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }


        /// <summary>
        /// ���� ������ ���� �õ�
        /// </summary>
        /// <param name="ip">������ ���� ������</param>
        /// <returns>���� ����</returns>
        public bool Connect(string ip)
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 7500);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                client.Connect(ipep);

                this.wnd.Add_MSG(ip + "������ ���� ����...");

                this.client_ip = ip;

                th = new Thread(new ThreadStart(Receive));
                th.IsBackground = true;
                th.Start();

                return true;
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
                return false;
            }
        }


        /// <summary>
        /// ���� ���� ���� ����...
        /// </summary>   
        public void DisConnect()
        {
            try
            {
                if (client != null)
                {
                    if (client.Connected)
                        client.Close();

                    if (th.IsAlive)
                        th.Abort();
                }

                this.wnd.Add_MSG("���� ���� ���� ����!");
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }


        /// <summary>
        /// ���ӵ� �������κ��� ������ ����
        /// </summary>  
        public void Receive()
        {
            try
            {
                while (client != null && client.Connected)
                {
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

        /// <summary>
        /// ���ڿ� �޽��� ����
        /// </summary>
        /// <param name="msg">������ ���ڿ�</param>
        public void Send(string msg)
        {
            byte[] data = Encoding.Default.GetBytes(msg);
            this.SendData(data);
        }


        /// <summary>
        /// ������ ����
        /// </summary>
        /// <param name="data">������ ������</param>
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


        /// <summary>
        /// ������ ����
        /// </summary>		
        /// <returns>������ ������ �迭</returns>
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

        /// <summary>
        /// ������ ����
        /// </summary>
        /// <param name="data">������ ������</param>
        private void SendFileData(FileInfo file, long current_size)
        {
            long total_size = file.Length;
            long size = file.Length - current_size;
            long count = size / BUFFER;
            long remain_byte = size % BUFFER;

            long index = 0;
            long prg_value = 0;
            long time = 0;

            FileStream fs = null;
            BinaryReader br = null;

            this.wnd.ProgressBarInit();

            try
            {
                // ������ ���� ���� ������ ũ�� ����
                fs = file.Open(FileMode.Open, FileAccess.Read, FileShare.Read);

                if (current_size > 0)   // �ִ� ������ �ǳʶٱ�
                {
                    fs.Seek(current_size, SeekOrigin.Begin);
                    prg_value += current_size;
                }

                br = new BinaryReader(fs);

                Byte[] data = new byte[BUFFER];

                while (index < count)
                {
                    if (DateTime.Now.Ticks - time > 10E6)// 0.1��
                    {
                        time = DateTime.Now.Ticks;
                        this.wnd.ProgressBarSetData(prg_value + index * BUFFER, total_size);
                    }

                    br.Read(data, 0, BUFFER);
                    client.Send(data, 0, BUFFER, SocketFlags.None);
                    index++;

                }

                if (remain_byte > 0)
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


        /// <summary>
        /// ���� ������ ����
        /// </summary>
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

            Byte[] data = new byte[BUFFER];

            this.wnd.ProgressBarInit();

            try
            {
                bw = new BinaryWriter(fs);

                if (total_size > remain_size)
                {
                    bw.Seek((int)(total_size - remain_size), SeekOrigin.Begin); // �̾�ޱ� ���
                    this.wnd.Add_MSG("���� �̾�ޱ� ó����...");
                    prg_value += total_size - remain_size;
                }

                while (total < remain_size)
                {
                    if (DateTime.Now.Ticks - time > 10E6) // 0.1��
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




        /// <summary>
        /// ���� ���� ���� �м� �� ���� ����
        /// </summary>
        /// <param name="filename">���۹��� �����̸�</param>
        /// <param name="filesize">���۹��� ����ũ��</param>
        public void FileInfo(string filename, long filesize)
        {
            // �����̸�/����ũ��
            string message = this.client_ip + " ���� ������ ���ϸ� : " + filename + " (" + filesize + " byte)�� �ٿ� �����ðڽ��ϱ�?";

            this.wnd.Add_MSG(message);

            if (MessageBox.Show(message, "���� ���� Ȯ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // ���� ���� Ȯ��				
                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                this.Send("CTOC_FILE_TRANS_YES\a" + fs.Length.ToString());
                this.ReceiveFileData(fs, filesize, filesize - fs.Length); // ���� ���� ����

                fs.Close();
            }
            else
            {
                // ���� ���� �ź�
                this.wnd.Add_MSG(this.client_ip + " ���� ���� ���Ͽ� ���� ����ڰ� ������ �ź��߽��ϴ�.");

                this.Send("CTOC_FILE_TRANS_NO\a");
            }
        }
    }
}
