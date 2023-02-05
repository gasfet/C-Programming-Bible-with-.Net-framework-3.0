using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace P2PClient
{
    /// <summary>
    /// ChatClient에 대한 요약 설명입니다.
    /// 서버들에 공유된 파일을 찾는 클라이언트 부분
    /// </summary>
    public class SearchClient
    {

        private const int BUFFER = 4096;  // 파일 버퍼..

        private SearchWnd dlg = null;       // 파일 검색창... 

        public FileDownWnd fdown = null;    // 파일 다운로드...

        private Socket connect = null;   // 상대방 접속


        /// 서버/클라이언트 멤버		
        public NetworkStream stream;      // 네트워크 스트림 
        public StreamReader read;         // 읽기
        public StreamWriter write;        // 쓰기

        public int port = 7008;          // 파일 포트 번호
        private Thread Reader;            // 읽기 쓰레드


        /// <summary>
        /// SearchClient 생성자 
        /// </summary>
        /// <param name="dlg">파일 검색창</param>
        public SearchClient(SearchWnd dlg)
        {
            this.dlg = dlg;             // 파일 검색창 공유
        }

        /// <summary>
        /// SearchClient 생성자
        /// </summary>
        /// <param name="fdown">파일 다운로드 창</param>
        public SearchClient(FileDownWnd fdown)
        {
            this.fdown = fdown;
        }


        /// <summary>
        /// 상대방 연결
        /// </summary>
        /// <param name="server_ip">연결할 서버 아이피</param>
        /// <param name="message">전송할 메시지</param>
        public void Connect(string server_ip, string message)
        {
            connect = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint E_IP = new IPEndPoint(IPAddress.Parse(server_ip), port);

            try
            {
                connect.Connect(E_IP);  // 연결 시도				
            }
            catch    // 연결이 실패하면
            {
                if (this.fdown != null)
                    fdown.Set_Connect("> 연결 실패!");
                else
                    this.dlg.Set_Message(server_ip + " 서버 연결 실패!");
                return;
            }
            // 네트워크 스트림 생성
            stream = new NetworkStream(connect);

            read = new StreamReader(stream); // 읽어오기
            write = new StreamWriter(stream);// 보내기 스트림 생성


            // 파일 검색 요청 스레드 생성...
            if (this.fdown != null)
            {
                Reader = new Thread(new ThreadStart(ReceiveFile));
                Reader.IsBackground = true;
                Reader.Start();
            }
            else  // 파일 검색
            {
                Reader = new Thread(new ThreadStart(Receive));
                Reader.IsBackground = true;
                Reader.Start();
            }

            this.Send(message);

        }

        /// <summary>
        /// 상대방과 연결해제
        /// </summary>
        public void Disconnect()
        {
            read.Close();            // 읽기 해제
            write.Close();		     // 쓰기 해제			 				
            stream.Close();          // 스트림 해제
            if (fdown != null && fdown.CLOSE_DLG == true) fdown.Close();
            try
            {
                Reader.Abort();      // 스레드 종료
            }
            catch { }                 // 스레드 종료시 예외 처리			
        }

        /// <summary>
        /// 파일 데이터 수신하기
        /// </summary> 
        private void ReceiveFile()
        {
            FileStream fs = null;              // 파일 스트림
            string file_name = fdown.downdirectory + "\\" + fdown.fname;
            long total_size = Int64.Parse(fdown.fsize);
            long remain_size = 0;

            if (File.Exists(file_name))
            {
                fs = new FileStream(file_name, FileMode.Open, FileAccess.ReadWrite);
                if (total_size == fs.Length)
                {
                    fs.Close();
                    this.fdown.Set_Connect("수신하려는 파일과 동일한 파일이 이미 있습니다!");
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
                    bw.Seek((int)remain_size, SeekOrigin.Begin); // 이어받기 기능
                    this.fdown.Set_Connect("파일 이어받기 처리중...");
                    prg_value += remain_size;
                }

                times = DateTime.Now.Ticks;

                while (total < (total_size - remain_size))
                {
                    if (DateTime.Now.Ticks - time > 10E6) // 0.1초
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
                this.fdown.Set_Connect("파일 수신 완료!");
                this.fdown.Set_lblInfo(total_size);
                this.fdown.Button_Text = "닫기";
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
        ///  상대방 데이터 수신 클라이언트
        /// </summary>
        public void Receive()
        {
            try
            {
                // 수신 메시지 읽어오기
                string message = read.ReadLine().Trim();

                // 메시지를읽어옴
                if (message != null)
                {
                    char[] ch = { '#' }; // # 을 토큰으로 문자열 분리
                    string[] token = message.Split(ch); // 문자열 분리

                    switch (token[0])
                    {
                        //     형식 : S_S_FILE#검색서버IP#파일개수#파일이름&파일사이즈&
                        //   	파일생성일&파일이름&파일사이즈......
                        case "S_S_FILE": // 파일 검색 결과							    
                            string[] file = token[3].Split('&');// & 를 토큰으로 파일 정보추출
                            int k = Int32.Parse(token[2]) * 3; // 파일이름,사이즈,생성일
                            for (int i = 0; i < k; i += 3)
                            {
                                lock (dlg)
                                { // 임계 영역 처리
                                    // 리스트뷰에 추가
                                    dlg.Add_ListViwe(file[i], file[i + 1], file[i + 2], token[1]);
                                    // 데이터 수신 메시지 기록
                                    this.dlg.Set_Message(token[1] + " 서버 데이터 수신!");
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
        ///  메시지 전송
        /// </summary>
        /// <param name="str">전달할 메시지</param>
        public void Send(string str)
        {
            try
            {
                write.WriteLine(str);
                write.Flush();

            }
            catch
            {
                this.dlg.Set_Message(" 데이터 보내기 실패!");
                // "데이터 보내기 실패!";
            }
        }

    }
}
