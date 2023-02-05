using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;   // ver 2.0 추가부분 

namespace MainChat
{
    public class Network
    {
        MainWnd wnd = null;    // 채팅 창
        Socket server = null;    // 채팅 서버로 사용되는 소켓
        Socket client = null;     // 채팅 클라이언트로 사용되는 소켓
        Thread th = null;        // Receive 메서드 스레드 처리
        string client_ip = null;   // 아이피 주소 저장

        /* ver 2.0 추가된 부분 */
        NetworkStream stream = null;  // 네트워크 스트림
        StreamReader reader = null;   // 읽기 스트림
        StreamWriter writer = null;    // 쓰기 스트림     

        /// <summary>
        /// Network 클래스 생성자
        /// </summary>
        /// <param name="wnd">채팅 창 인스턴스</param>
        public Network(MainWnd wnd)
        {
            this.wnd = wnd;
        }

        /// <summary>
        /// 채팅 서버 프로그램 시작
        /// </summary>
        public void ServerStart()
        {
            try
            {	// 채팅 서버 프로그램 설정		
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 7000);
                server = new Socket(AddressFamily.InterNetwork,
                                                        SocketType.Stream, ProtocolType.Tcp);
                server.Bind(ipep);   // 채팅 서버 바인딩
                server.Listen(10);   // 채팅 서버 실행
                this.wnd.Add_MSG("채팅 서버 시작...");
                this.client = server.Accept();  // 채팅 클라이언트가 접속하면 
                // 상대방의 아이피 주소를 알아내 txt_info 에 출력
                IPEndPoint ip = (IPEndPoint)this.client.RemoteEndPoint;
                this.wnd.Add_MSG(ip.Address + "접속...");
                // 상대편 아이피 주소 기록
                this.client_ip = ip.Address.ToString();
                /// Ver 2.0 에 추가된 부분
                stream = new NetworkStream(this.client);
                reader = new StreamReader(stream);       // 추가된 내용
                writer = new StreamWriter(stream);

                th = new Thread(new ThreadStart(Receive));  // 상대방이 보낸 문자열 수신
                th.Start();
            }
            catch (Exception ex)  // 채팅 서버 실행 중 예외가 발생하면 
            {    // txt_info 객체에 에러 메시지 출력
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 채팅 서버 프로그램 중지
        /// </summary>
        public void ServerStop()
        {
            try
            {
                 if(reader != null)
                     reader.Close(); // StreamReader 종료  
                 if(writer != null)
                     writer.Close();  // StreamWriter 종료
                 if(stream != null) 
                     stream.Close(); // NetworkStream 종료   
                 if(client != null)
                     client.Close();  // 클라이언트 접속 끊음				                 
                if ((th != null)&&(th.IsAlive)) // Receive 메서드 
                     th.Abort();   // 스레드 종료
                                   
                 server.Close();   // 서버 소켓 종료
            }
            catch (Exception ex) // 예외 메시지 처리
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 채팅 서버와 연결 시도
        /// </summary>
        /// <param name="ip">연결할 서버 아이피 주소</param>
        /// <returns>연결 유무</returns>
        public bool Connect(string ip)
        {
            try
            {       // 채팅 서버 아이피 주소와 포트 번호 설정
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 7000);
                this.client = new Socket(AddressFamily.InterNetwork,
                                                   SocketType.Stream, ProtocolType.Tcp);

                this.client.Connect(ipep);  // 채팅 서버에 접속 시도
                this.wnd.Add_MSG(ip + "서버에 접속 성공...");
                this.client_ip = ip;        // 채팅 서버 아이피 주소 저장

                /// 추가된 부분 
                stream = new NetworkStream(this.client);
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);

                th = new Thread(new ThreadStart(Receive)); // 스레드 시작
                th.Start();

                return true;
            }
            catch (Exception ex)  // 예외 처리
            {
                this.wnd.Add_MSG(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 채팅 서버 연결 종료
        /// </summary>
        public void Disconnect()
        {
            try
            {
                if (client != null)
                {
                    if (client.Connected)   // 채팅 서버와 연결되어 있다면
                    {
                        reader.Close();  // StreamReader 닫기 
                        writer.Close();  // StreamWriter 닫기 
                        stream.Close(); // NetworkStream 닫기 
                        client.Close();  // 채팅 서버와 접속 끊기

                        if (th.IsAlive)
                            th.Abort();      // 스레드 종료
                    }
                }
                this.wnd.Add_MSG("채팅 서버 연결 종료!");
            }
            catch (Exception ex)
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 연결된 상대방이 보낸 데이터 수신하기
        /// </summary>  
        public void Receive()
        {
            try
            {
                while (client.Connected)
                {   /// 변경된 부분 
                    string msg = reader.ReadLine();  // 라인단위로 문자열 읽어오기
                    this.wnd.Add_MSG("[" + client_ip + "] " + msg);
                }
            }
            catch (Exception ex)  // 예외 처리
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 연결된 상대방에게 데이터 전송하기
        /// </summary>
        /// <param name="msg">전송할 문자열</param>
        public void Send(string msg)
        {
            try
            {
                if (client.Connected)  // 상대방과 접속이 되어 있다면
                {   // 변경된 부분 //
                    writer.WriteLine(msg);   // 문자열 메시지 전송
                    writer.Flush();
                }
                else   // 상대방과 연결되어 있지 않다면
                {
                    this.wnd.Add_MSG("메시지 전송 실패!");
                }
            }
            catch (Exception ex)  // 문자열 전송 중 예외가 발생하면
            {
                this.wnd.Add_MSG(ex.Message);
            }
        }

        /// <summary>
        /// 내 아이피 주소 알아내기
        /// </summary>
        /// <returns>아이피 주소</returns>
        public string Get_MyIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string myip = host.AddressList[0].ToString();
            return myip;
        }
    }
}
