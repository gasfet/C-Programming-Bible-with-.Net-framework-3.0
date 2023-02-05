using System;
using System.Collections;
using System.IO;
using System.Threading;
using System.Net.Sockets;

using System.Net;        // TCP 소켓


namespace P2PClient
{

    /// <summary>
    /// 파일 검색 서버 역할 클래스
    /// </summary> 
    class SearchServer
    {
        TcpListener listener;
        Thread th;

        bool stop;         // 정지 조건 flag
        int port = 7008;   // 파일 검색 서버는 7008

        SearchWnd dlg = null;  // 검색 창 

        /// <summary>
        ///  SearchServer 생성자
        /// </summary>
        /// <param name="dlg"></param> 
        public SearchServer(SearchWnd dlg)
        {
            this.dlg = dlg;
        }

        /// <summary>
        /// 클라이언트 요구를 처리
        /// </summary>
        public void Accept()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();  // TCP 리스너 작동
            }
            catch
            {
                return;
            }

            while (true)
            {
                // 클라이언트  접속을 대기중
                Socket socket = listener.AcceptSocket();

                if (socket.Connected) // 클라이언트가 접속하면...
                {
                    new SClient(socket, dlg);
                }
            }
        }

        /// <summary>
        ///파일 검색 서버 스레드 생성
        /// </summary>
        public void Start()
        {
            // 스레드 생성
            th = new Thread(new ThreadStart(Accept));
            th.IsBackground = true;
            // 스레드 시작
            th.Start();
            stop = true;
        }

        /// <summary>
        ///  파일 검색 서버 스레드 중지
        /// </summary>
        public void Stop()
        {
            if (stop)            // stop 플래그를 검사해서
            {
                listener.Stop();   // Listener 중지				

                stop = false;      // stop 플래그를 false로 바꿈
                try
                {
                    th.Abort();       // 스레드 중지
                }
                catch { }

            }
        }
    }


    /// <summary>
    /// 파일 검색&전송 처리 클라이언트 클래스
    /// </summary>
    class SClient
    {
        private const int BUFFER = 4096;  // 파일 버퍼..

        StreamReader read;    // 입력 스트림
        StreamWriter write;   // 출력 스트림
        NetworkStream stream;  // 스트림
        Socket socket;  // 소켓

        Thread reader;   // 읽어오기 쓰레드

        SearchWnd dlg = null;  // 파일 송수신 데이터 다이알로그 

        /// <summary>
        ///  SClient 생성자
        /// </summary>
        /// <param name="socket">소켓</param>
        /// <param name="dlg">검색창</param>
        public SClient(Socket socket, SearchWnd dlg)
        {
            this.socket = socket;
            this.dlg = dlg;
            if (this.socket.Connected)
            {// 연결된다면
                stream = new NetworkStream(socket);
                read = new StreamReader(stream);  // 스트림 읽기
                write = new StreamWriter(stream); //  스트림 보내기

                reader = new Thread(new ThreadStart(Receive));
                reader.IsBackground = true;
                reader.Start();

            }
        }

        /// <summary>
        /// 연결 해제
        /// </summary>
        public void Close()
        {
            read.Close();            // 읽기 해제
            write.Close();		     // 쓰기 해제			 				
            stream.Close();          // 스트림 해제
            socket.Close();

            try
            {
                reader.Abort();  // 스레드 종료
            }
            catch { } // 스레드 종료시 예외 처리

        }

        /// <summary>
        ///  메시지 수신
        /// </summary>
        public void Receive()
        {
            try
            {
                string message = read.ReadLine().Trim();
                // 메시지를읽어옴
                if (message != null)
                {
                    char[] ch = { '#' };
                    string[] token = message.Split(ch);

                    switch (token[0])
                    {
                        case "S_RES_REFRESH": // 서버 목록 갱신
                            lock (dlg)
                            {
                                dlg.client.Refresh_List(token[1]);
                                this.dlg.Set_Message(" 서버 목록 갱신 : " + DateTime.Now.ToLongTimeString());
                            }

                            break;


                        case "S_C_FILE":  // 클라이언트가 파일 이름 검색 요청
                            //형식 : S_C_FILE#검색요청컴퓨터IP#검색 파일명
                            SearchFile(token[1], token[2]);// 파일 검색
                            lock (dlg)
                            {
                                this.dlg.Set_Message(token[1] + " 클라이언트 " + token[2] + " 검색 요청");
                            }
                            break;

                        //형식 : S_S_FILEDOWN#클라이언트IP#파일이름#파일크기 
                        case "S_C_FILEDOWN": // 클라이언트 파일 다운로드 요청  
                            lock (dlg)
                            {
                                this.dlg.Set_Message(token[0] + " 클라이언트 " + token[1] + " 파일전송");
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
        /// 메시지 전송
        /// </summary>
        /// <param name="msg">전송할 메시지</param>
        public void Send(string msg)
        {
            write.WriteLine(msg);
            write.Flush();
        }

        /// <summary>
        /// 클라이언트 요청 파일 검색
        /// </summary>
        /// <param name="IP">요청 컴퓨터 아이피</param>
        /// <param name="filename">검색할 파일이름</param>
        private void SearchFile(string IP, string str)
        {
            // 파일 검색
            FindFile find = new FindFile(this.dlg.client.sharedirectory);
            // 검색된 파일 정보 가져오기
            string searchinfo = find.SearchFile(str);

            // 자신의 IP번호 알아내기
            string myIP;
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            myIP = host.AddressList[0].ToString();

            // 검색된 결과를 검색 서버 아이피 추가해서 전달
            string message = "S_S_FILE#" + myIP + "#" + searchinfo;

            Send(message);  // 파일 검색 결과 보내기
        }


        /// <summary>
        ///  파일 전송
        /// </summary>
        /// <param name="fname">파일 이름</param>
        /// <param name="current_size">현재 파일 크기</param>
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
                // 전송할 실제 파일 데이터 크기 전달
                fs = file.Open(FileMode.Open, FileAccess.Read, FileShare.Read);


                if (current_size > 0)   // 있는 파일은 건너뛰기
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
