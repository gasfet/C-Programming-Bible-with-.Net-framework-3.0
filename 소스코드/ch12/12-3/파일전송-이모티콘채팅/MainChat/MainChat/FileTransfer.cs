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
    /// FileTransfer에 대한 요약 설명입니다.
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
        /// 서버 프로그램 시작
        /// </summary>
        public void ServerStart()
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 7500);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(ipep);
                server.Listen(10);
                this.wnd.Add_MSG("파일 서버 시작...");

                this.client = server.Accept();

                IPEndPoint ip = (IPEndPoint)this.client.RemoteEndPoint;
                this.wnd.Add_MSG(ip.Address + "접속...");

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
        /// 서버 프로그램 중지
        /// </summary>
        public void ServerStop()
        {
            try
            {
                if (client != null)
                {
                    if (client.Connected)
                    {
                        client.Close();  // 클라이언트 접속 끊음				

                        if (th.IsAlive)
                            th.Abort();      // 스레드 종료
                    }
                }

                server.Close();
                this.wnd.Add_MSG("파일 서버 종료...");

            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }


        /// <summary>
        /// 파일 서버와 연결 시도
        /// </summary>
        /// <param name="ip">연결할 서버 아이피</param>
        /// <returns>연결 유무</returns>
        public bool Connect(string ip)
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 7500);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                client.Connect(ipep);

                this.wnd.Add_MSG(ip + "서버에 접속 성공...");

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
        /// 파일 서버 연결 종료...
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

                this.wnd.Add_MSG("파일 서버 연결 종료!");
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }


        /// <summary>
        /// 접속된 상대방으로부터 데이터 수신
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
                        case "CTOC_FILE_TRANS_INFO":  // 전송할 파일 정보
                            FileInfo(token[1], Convert.ToInt64(token[2].Trim()));
                            break;

                        case "CTOC_FILE_TRANS_YES":	 // 파일 전송 수락
                            long current_size = Convert.ToInt64(token[1].Trim());
                            this.SendFileData(this.file_info, current_size);
                            break;

                        case "CTOC_FILE_TRANS_NO":  // 파일 전송 거부
                            this.wnd.Add_MSG("상대방이 파일 전송을 거부했습니다.");
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
        /// 문자열 메시지 전송
        /// </summary>
        /// <param name="msg">전송할 문자열</param>
        public void Send(string msg)
        {
            byte[] data = Encoding.Default.GetBytes(msg);
            this.SendData(data);
        }


        /// <summary>
        /// 데이터 전송
        /// </summary>
        /// <param name="data">전송할 데이터</param>
        private void SendData(byte[] data)
        {
            try
            {
                int total = 0;
                int size = data.Length;
                int left_data = size;
                int send_data = 0;

                // 전송할 실제 데이터의 크기 전달
                byte[] data_size = new byte[4];
                data_size = BitConverter.GetBytes(size);
                send_data = this.client.Send(data_size);

                // 실제 데이터 전송
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
        /// 데이터 수신
        /// </summary>		
        /// <returns>수신한 데이터 배열</returns>
        private byte[] ReceiveData()
        {
            try
            {
                int total = 0;
                int size = 0;
                int left_data = 0;
                int recv_data = 0;

                // 수신할 데이터 크기 알아내기   
                byte[] data_size = new byte[8];
                recv_data = this.client.Receive(data_size, 0, 8, SocketFlags.None);
                size = BitConverter.ToInt32(data_size, 0);
                left_data = size;

                byte[] data = new byte[size];
                // 서버에서 전송한 실제 데이터 수신
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
        /// 데이터 전송
        /// </summary>
        /// <param name="data">전송할 데이터</param>
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
                // 전송할 실제 파일 데이터 크기 전달
                fs = file.Open(FileMode.Open, FileAccess.Read, FileShare.Read);

                if (current_size > 0)   // 있는 파일은 건너뛰기
                {
                    fs.Seek(current_size, SeekOrigin.Begin);
                    prg_value += current_size;
                }

                br = new BinaryReader(fs);

                Byte[] data = new byte[BUFFER];

                while (index < count)
                {
                    if (DateTime.Now.Ticks - time > 10E6)// 0.1초
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
                this.wnd.Add_MSG("파일 전송 완료!");

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
        /// 파일 데이터 수신
        /// </summary>
        /// <param name="fs">수신할 파일 스트림</param>
        /// <param name="total_size">파일 전체 크기</param>
        /// <param name="remain_size">수신할 파일 크기</param>
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
                    bw.Seek((int)(total_size - remain_size), SeekOrigin.Begin); // 이어받기 기능
                    this.wnd.Add_MSG("파일 이어받기 처리중...");
                    prg_value += total_size - remain_size;
                }

                while (total < remain_size)
                {
                    if (DateTime.Now.Ticks - time > 10E6) // 0.1초
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
                this.wnd.Add_MSG("파일전송 완료!");
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
        /// 파일 수신 정보 분석 및 파일 수신
        /// </summary>
        /// <param name="filename">전송받을 파일이름</param>
        /// <param name="filesize">전송받을 파일크기</param>
        public void FileInfo(string filename, long filesize)
        {
            // 파일이름/파일크기
            string message = this.client_ip + " 님이 보내는 파일명 : " + filename + " (" + filesize + " byte)을 다운 받으시겠습니까?";

            this.wnd.Add_MSG(message);

            if (MessageBox.Show(message, "파일 전송 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // 파일 수신 확인				
                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                this.Send("CTOC_FILE_TRANS_YES\a" + fs.Length.ToString());
                this.ReceiveFileData(fs, filesize, filesize - fs.Length); // 파일 수신 시작

                fs.Close();
            }
            else
            {
                // 파일 수신 거부
                this.wnd.Add_MSG(this.client_ip + " 님이 보낸 파일에 대해 사용자가 수신을 거부했습니다.");

                this.Send("CTOC_FILE_TRANS_NO\a");
            }
        }
    }
}
