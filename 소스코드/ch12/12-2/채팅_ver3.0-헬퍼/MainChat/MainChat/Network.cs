using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;   // ver 2.0&3.0 추가 부분

namespace MainChat
{
    public class Network
    {
        MainWnd wnd = null;	         // 채팅 창 객체 변수 	 
        Thread th = null;                      // 스레드 처리
        private TcpListener server = null;    // 채팅 서버 
        private TcpClient client = null;     // 채팅 클라이언트
        private NetworkStream stream = null;  // 네트워크 스트림 객체
        private StreamReader reader = null;   // 스트림 읽기
        private StreamWriter writer = null;    // 스트림 쓰기		

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
            {	// 채팅 서버 포트 번호를 7000번으로 설정하고		
                server = new TcpListener(IPAddress.Any, 7000);
                server.Start();  // 채팅 서버를 실행...
                this.wnd.Add_MSG("채팅 서버 시작...");
                client = server.AcceptTcpClient(); // 채팅 클라이언트가 접속하면
                stream = client.GetStream();  // 연결된 클라이언트 스트림 가져오기
                reader = new StreamReader(stream); // 읽기 스트림 생성
                writer = new StreamWriter(stream);  // 쓰기 스트림 생성

                th = new Thread(new ThreadStart(Receive)); // 수신 스레드
                th.Start();
            }
            catch (Exception ex)  // 채팅 서버 처리에서 예외가 발생할 경우
            {
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
			       if(reader != null)    reader.Close();  // 읽기 스트림 종료
			       if(writer != null)    writer.Close();   // 쓰기 스트림 종료
			       if(stream != null)    stream.Close();  // 스트림 종료
			       if(client != null)    client.Close();       // 클라이언트 접속 끊음			
                   if((th != null)&&(th.IsAlive))  th.Abort();   // 스레드 종료		
                    server.Stop();  // TcpListener 서비스 중지
			}
			catch(Exception ex)
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
            {    // 채팅 서버 아이피 주소와 포트 번호 설정
                client = new TcpClient(ip, 7000);
                this.wnd.Add_MSG(ip + "서버에 접속 성공...");
                // 채팅 서버 연결에 성공하면 입출력 네트워크 스트림 생성
                stream = client.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);

                th = new Thread(new ThreadStart(Receive));
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
        /// 채팅 서버와 연결 끊음
        /// </summary>
        public void Disconnect()
        {
            try
            {
                if (client != null)  // 채팅 서버와 연결되어 있다면
                {
                    if (reader != null) reader.Close();  // 읽기 스트림 해제
                    if (writer != null) writer.Close();  // 쓰기 스트림 해제
                    if (stream != null) stream.Close(); // 스트림 해제		 
                    client.Close();     // 채팅 서버와 연결 끊기					
                    if(th.IsAlive)  th.Abort();           // 수신 스레드 종료
                }
                this.wnd.Add_MSG("접속 종료");
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
            string msg = null;
            try
            {
                do
                {
                    msg = reader.ReadLine();  // 문자열 읽어오기
                    this.wnd.Add_MSG("[" + "상대방" + "] " + msg);  // 문자열 출력
                } while (msg != null);
            }
            catch (Exception ex)
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
                writer.WriteLine(msg);  // 연결된 상대방에게 문자열 전송
                writer.Flush();
            }
            catch (Exception ex)
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

