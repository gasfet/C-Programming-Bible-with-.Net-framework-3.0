using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace MessengerClient
{
    public class RegNetwork
    {

        #region 멤버 변수/생성자

        RegForm wnd = null;      // 회원 가입폼

        Socket client = null;
        Thread th = null;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="wnd">회원 가입폼 인스턴스</param>
        public RegNetwork(RegForm wnd)
        {
            this.wnd = wnd;
        }

        #endregion


        #region 멤버 메서드

        /// <summary>
        /// 메신저 서버와 연결 시도
        /// </summary>
        /// <param name="ip">연결할 서버 아이피</param>
        /// <returns>연결 유무</returns>
        public bool Connect(string ip)
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), 7007);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                client.Connect(ipep);

                th = new Thread(new ThreadStart(Receive));
                th.Start();

                return true;
            }
            catch (Exception ex)
            {
                this.wnd.wnd.Add_MSG(ex.Message);
                return false;
            }
        }


        /// <summary>
        /// 메신저 서버 연결 종료...
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

                this.wnd.wnd.Add_MSG("서버 연결 종료!");
            }
            catch (Exception ex)
            {
                this.wnd.wnd.Add_MSG(ex.Message);
            }
        }


        /// <summary>
        /// 메신저 서버가 전송하는 데이터 수신
        /// </summary>  
        public void Receive()
        {
            try
            {
                byte[] data = this.ReceiveData();
                string msg = Encoding.Default.GetString(data);
                string[] token = msg.Split('\a');

                switch (Convert.ToInt32(token[0].Trim()))
                {
                    case (int)MSG.STOC_MESSAGE_REGISTER_OK:   // 회원 가입 성공  
                        System.Windows.Forms.MessageBox.Show("회원 가입 성공! \r\n 새로 로그인 해주세요!");
                        this.wnd.Close();  // 회원 가입창 닫기
                        break;

                    case (int)MSG.STOC_MESSAGE_REGISTER_FAIL: // 회원 가입 실패 
                        System.Windows.Forms.MessageBox.Show("회원 가입 실패!");
                        this.wnd.Close();  // 회원 가입창 닫기
                        break;

                    case (int)MSG.STOC_MESSAGE_REGISTER_IDYES: //아이디 중복조회 결과 사용가능
                        System.Windows.Forms.MessageBox.Show("아이디 사용가능!");
                        this.wnd.id_ok = true;
                        break;

                    case (int)MSG.STOC_MESSAGE_REGISTER_IDNO:  //아이디 중복조회 결과 사용불가
                        System.Windows.Forms.MessageBox.Show("아이디 사용불가!");
                        this.wnd.id_ok = false;
                        break;

                    case (int)MSG.STOC_MESSAGE_REGISTER_ZIPCODEDATA: // 우편번호 조회 결과
                        this.wnd.zipcodewnd.ZipdataInput(token[1].Trim());
                        break;

                    case (int)MSG.STOC_MESSAGE_REGISTER_ZIPCODERR: // 우편번호 조회 에러
                        System.Windows.Forms.MessageBox.Show("우편번호 조회 에러!");
                        break;
                }

            }
            catch (Exception ex)
            {
                this.wnd.wnd.Add_MSG(ex.Message);
            }
        }


        /// <summary>
        /// 접속한 상대방에 데이터 전송
        /// </summary>
        /// <param name="msg">전송할 문자열</param>
        public void Send(string msg)
        {
            try
            {
                if (client.Connected)
                {
                    byte[] data = Encoding.Default.GetBytes(msg);
                    this.SendData(data);
                }
                else
                {
                    this.wnd.wnd.Add_MSG("메시지 전송 실패!");
                }
            }
            catch (Exception ex)
            {
                this.wnd.wnd.Add_MSG(ex.Message);
            }
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
                this.wnd.wnd.Add_MSG(ex.Message);
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
                byte[] data_size = new byte[4];
                recv_data = this.client.Receive(data_size, 0, 4, SocketFlags.None);
                size = BitConverter.ToInt32(data_size, 0);
                left_data = size;

                byte[] data = new byte[size];
                // 서버에서 전송한 실제 데이터 수신
                while (total < size)
                {
                    recv_data = this.client.Receive(data, total, left_data, 0);
                    if (recv_data == 0) break;
                    total += recv_data;
                    left_data -= recv_data;
                }
                return data;
            }
            catch (Exception ex)
            {
                this.wnd.wnd.Add_MSG(ex.Message);
                return null;
            }
        }




        #endregion
    }
}
