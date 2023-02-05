using System;
using System.Collections;
using System.IO;                   // 입출력 처리
using System.Threading;            // 쓰레드 처리
using System.Net.Sockets;          // 네트워크 연결 처리
using System.Net;                 // 네트워크 처리


namespace P2PServer
{

    /// <summary>
    ///  P2P 서버 기능 구현 클래스
    /// </summary>
    class Server
    {
        // TCP 서버 구동 리스너 선언
        TcpListener listener = null;
        // 접속한 서버 등록 클래스 
        ClientGroup member = null;
        // 쓰레드 변수
        Thread th = null;

        // 정지 조건 flag
        bool stop;
        // P2P 서버 포트 번호 지정
        int port = 7007;


        /// <summary>
        /// 생성자 
        /// </summary>
        /// <param name="port">p2p서버 포트번호</param>
        public Server(int port)
        {
            //외부에서 입력한 포트 번호 지정          
            this.port = port;
        }

        /// <summary>
        /// 클라이언트 요청을 기다림
        /// </summary>
        public void Accept()
        {

            try
            {  // TCP리스너 처리는 예외처리가 필요함

                // TCP 리스너 생성
                listener = new TcpListener(IPAddress.Any, port);
                // TCP 리스너 작동 시작
                listener.Start();

            }
            catch
            { // 예외 발생할 경우 Accept 메서드 반환
                return;
            }

            // 데몬상태 시작( 클라이언트 접속을 기다림 )
            while (true)
            {
                // 클라이언트  접속 대기중
                Socket socket = listener.AcceptSocket();

                if (socket.Connected)
                { // 클라이언트가 접속하면...
                    // Client 클래스를 생성하고, 리스트에 추가
                    member.Add(new Client(socket));

                }
            }
        }

        /// <summary>
        ///  P2P 서버 작동 시작
        /// </summary>
        public void Start()
        {
            // ClientGroup 변수 초기화
            member = new ClientGroup();
            // Accep 메서드 쓰레드 처리
            th = new Thread(new ThreadStart(Accept));
            th.IsBackground = true;  // Background 스레드 처리
            // 쓰레드 시작
            th.Start();
            // 서버 정지 조건 처리 (서버 시작)
            stop = true;
        }

        /// <summary>
        /// P2P 서비스 종료
        /// </summary>
        public void Stop()
        {
            if (stop)
            {          // stop 플래그를 검사해서
                listener.Stop();  // Listener 중지
                member.Dispose(); // ClientGroup()에서 제거
                stop = false;     // stop 플래그를 false로 바꿈
                th.Abort();       // 쓰레드 중지
            }
        }
    }


    /// <summary>
    ///  접속한 클라이언트 처리 클래스
    /// </summary>
    class Client
    {

        StreamReader read;    // 입력 스트림
        StreamWriter write;   // 출력 스트림
        NetworkStream stream;  // 스트림
        Socket socket;  // 소켓

        Thread reader;   // 읽어오기 쓰레드


        /// <summary>
        ///  생성자
        /// </summary>
        /// <param name="socket">접속한 클라이언트 소켓</param>
        public Client(Socket socket)
        {

            this.socket = socket; // 소켓 지정

            if (this.socket.Connected)
            {           // 연결된다면
                stream = new NetworkStream(socket);// 소켓에서 스트림 생성
                read = new StreamReader(stream);   // 스트림 읽기 생성
                write = new StreamWriter(stream);  // 스트림 쓰기 생성

                // Receive 메서드 쓰레드 준비
                reader = new Thread(new ThreadStart(Receive));
                reader.IsBackground = true;
                // 쓰레드 시작
                reader.Start();
            }
        }

        /// <summary>
        ///  클아이언트 접속 종료
        /// </summary>
        public void Close()
        {
            read.Close();       // 스트림 읽기 해제
            write.Close();		// 스트림 쓰기 해제				 		
            stream.Close();     // 스트림 해제
            socket.Close();     // 소켓 해제
            reader.Abort();     // Receive 메서드에 대한 쓰레드 해제 
        }

        /// <summary>
        ///  접속한 클라이언트와 통신 
        /// </summary>
        public void Receive()
        {
            try
            {
                while (true)
                {
                    // 클라이언트 메시지 수신
                    string message = read.ReadLine().Trim(); // 읽어올때 공백 제거
                    // 메시지를읽어옴
                    if (message != null)
                    {  // 메시지가 있으면 
                        char[] ch = { '#' }; // # 토큰을 메시지열 분석
                        string[] token = message.Split(ch);

                        switch (token[0])
                        {  // 첫번째 문자열이 

                            // 로그인 로그아웃에 대한 메시지
                            case "C_REQ_LOGIN":  // 로그인 요청이면
                                Login(message);   // 로그인 메서드 호출
                                break;

                            case "C_REQ_LOGOUT": // 로그 아웃 요청이면
                                Logout(token[1]); // 로그 아웃 메서드 호출
                                break;

                            // 접속한 모든 서버에 갱신된 서버리스트 전송
                            case "C_REQ_REFRESH":   // 서버 리스트 갱신 요청이면
                                Send_All(token[1]); // 리스트 갱신 메서드 호출
                                break;

                            // 회원가입에 관련된 메시지
                            case "C_REQ_MEMBERID_CHECK": // 아이디 중복 체크
                                Id_Check(token[1]);    // 아이디 중복 메서드 호출 
                                break;

                            case "C_REQ_MEMBER":         // 회원 가입 요청 
                                Register(message);      // 회원 가입 메서드 호출
                                break;
                        }
                    }
                }
            }
            catch
            { // 예외가 발생하면 ( 클라이언트와 통신 실패 )
                Close();  // 모든 연결 상태 해제
            }
        }

        /// <summary>
        ///  접속한 클라이언트에 메시지 보내기
        /// </summary>
        /// <param name="msg">전송할 메시지</param>
        public void Send(string msg)
        {
            // 클라이언트에 문자열 전송 
            write.WriteLine(msg);
            // 버퍼에 있는 내용 비우기
            write.Flush();
        }

        /// <summary>
        /// 로그인 체크 함수
        /// </summary>
        /// <param name="message">로그인 요청 메시지</param>
        private void Login(string message)
        {
            // 메시지 받아오기
            string str = message;

            // # 토큰을 이용해 문자열 문석
            char[] ch = { '#' };
            string[] token = str.Split(ch);

            // 메시지 구성 : #C_REQ_LOGIN#로그인아이디#비밀번호#접속자IP

            // 로그인 처리 클래스 생성
            Login login = new Login(token[1], token[2], token[3]);

            // 로그인 결과 전송
            Send(login.Connection());
        }

        /// <summary>
        /// 로그아웃 처리
        /// </summary>
        /// <param name="user_ip">로그 아웃할 IP </param>
        private void Logout(string user_ip)
        {
            // Pass 테이블에서 IP번호 삭제
            string str = "Delete from TBL_Pass where ip='" + user_ip + "'";


            // DB 처리 생성
            DB_conn conn = new DB_conn();
            conn.Open();
            try
            {
                // 쿼리문 실행
                conn.ExecuteNonQuery(str);
            }
            finally
            {
                // DB 연결 해제
                if (conn != null) conn.Close();
            }
            Send("S_RES_LOGOUT#"); // 로그아웃 성공 메시지 전송
        }


        /// <summary>
        /// 아이디 중복 체크 메서드
        /// </summary>
        /// <param name="id">중복 검사할 아이디</param>
        private void Id_Check(string id)
        {
            // 회원 가입 클래스 생성 ( Id_Checkted(id) 호출)
            Reg_User reg = new Reg_User();
            // 아이디 체크 결과 보내기
            Send(reg.Id_Check(id));
        }

        /// <summary>
        ///  회원 등록
        /// </summary>
        /// <param name="message">회원 등록 정보</param>
        private void Register(string message)
        {
            // 회원 등록 처리 클래스 생성
            Reg_User reg = new Reg_User();

            if (reg.IsRegister(message))     // 회원 가입 시도
                Send("S_RES_MEMBEROK#");   // 회원 가입 성공
            else
                Send("S_RES_MEMBERFAIL#"); // 회원 가입 실패 

        }

        /// <summary>
        ///  리스트 갱신 메서드
        /// </summary>
        /// <param name="myIP">갱신 요청 클라이언트 IP</param>
        private void Send_All(string myIP)
        {

            // 7008 번 파일 검색 서버에 메시지 전송
            // 하기 위해서 새로운 Socket 연결

            Socket conn = null;           // 소켓
            NetworkStream stream = null;   // 스트림
            StreamWriter write = null;     // 송신 스트림

            // Pass 테이블 내용 가져오기
            PassTableInfo info = new PassTableInfo();
            // 로그인 시점에 접속한 모든 서버 리스트 반환
            string str = info.Get_Current_Server(myIP);

            try
            {
                // 메시지 & 토큰을 이용해 분석
                string[] token = str.Split('&');

                // 접속한 모든 서버에 메시지 보냄
                for (int i = 1; i < token.Length; i++)
                {

                    // 접속한 서버 7008(파일검색)포트에 연결 시도
                    conn = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    // 포트 번호 지정  
                    IPEndPoint E_IP = new IPEndPoint(IPAddress.Parse(token[i]), 7008);


                    try
                    {
                        conn.Connect(E_IP);   // 접속 시도 				 
                        stream = new NetworkStream(conn);       // 스트림 생성
                        write = new StreamWriter(stream);     // 송신 스트림 생성
                        write.WriteLine("S_RES_REFRESH#" + myIP); // 현재 새로 접속한 IP전송
                        write.Flush();
                    }
                    finally
                    {
                        if (write != null) write.Close();         // 송신 스트림 해제
                        if (stream != null) stream.Close();      // 스트림 해제
                        if (conn != null) conn.Close();          // 접속 해제
                    }
                }
            }
            catch
            { // 예외 발생
            }

        }
    }

    /// <summary>
    ///  접속한 클라이언트 그룹 처리
    /// </summary>
    class ClientGroup
    {
        ArrayList member = new ArrayList(); // 클라이언트 리스트

        /// <summary>
        ///  클라이언트 추가
        /// </summary>
        /// <param name="client">현재 접속한 클라이언트</param> 
        public void Add(Client client)
        {
            // member변수에 추가
            member.Add(client);
        }

        /// <summary>
        ///  현재 연결된  Client  제거
        /// </summary>
        public void Dispose()
        {
            foreach (Client client in member)
            {
                // 현재 접속한 클라이언트 해제
                client.Close();
            }
        }
    }
}