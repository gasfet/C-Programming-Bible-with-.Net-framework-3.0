using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace WebInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient();  // TcpClient 생성
            try
            {
                client.Connect(txt_addr.Text.Trim(), 80); // 서버에 접속
            }
            catch  // 서버 접속에 실패하면 예외 처리
            {
                MessageBox.Show(" 서버에 접속 할 수 없습니다.");
            }

            Stream stream = client.GetStream(); // 서버와 스트림 연결

            string msg = "GET /index.html HTTP/1.0\r\n\n"; // 서버 정보 요청
            // 문자열을 바이트 형식으로 변형
            Byte[] byteSend = Encoding.Default.GetBytes(msg.ToCharArray());
            // 서버에 서버 정보 요청 문자열 전송 
            stream.Write(byteSend, 0, byteSend.Length);
            // 버퍼에 있는 모든 내용을 상대편에 전송
            stream.Flush();
            // 서버 정보 수신 버퍼
            byte[] response = new byte[256];
            int size = stream.Read(response, 0, response.Length);
            // 수신한 데이터를 화면에 출력			
            txt_info.AppendText(" 받은 바이트 수 : " + size + " Byte \r\n");
            txt_info.AppendText("서버에서 보내준 메시지 --->\r\n\r\n ");
            txt_info.AppendText(Encoding.Default.GetString(response));

        }
    }
}