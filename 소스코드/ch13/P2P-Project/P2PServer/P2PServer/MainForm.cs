using System;
using System.Drawing;
using System.Windows.Forms;

namespace P2PServer
{
    public partial class MainForm : Form
    {
        // P2P 서버 변수
        Server m_server = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            // 서버 시작할때 			
            if (btn_start.Text == "P2P 서버 시작")
            {
                // Server의 생성자에 Port번호 넘겨줌(기본값 7007 번)
                m_server = new Server(Convert.ToInt16(txt_port.Text));
                // 서버 시작
                m_server.Start();
                // 버튼위에 글씨 변경( 서버 시작 -> 서버 종료 )
                btn_start.Text = "P2P 서버 종료";
                // 서버가 작동중임을 표시하기 위해 버튼 바탕색을 빨간색으로 변경
                btn_start.BackColor = Color.Red;
            }
            else
            { // 서버를 종료하고 싶을때
                // P2P 서버 종료 ( 7007 번 포트 종료 )
                m_server.Stop();
                // 버튼위에 글씨 변경 ( 서버 종료 -> 서버 시작)
                btn_start.Text = "P2P 서버 시작";
                // 서버가 중지되었음을 알리기 위해 버튼 바탕색을 녹색으로 변경
                btn_start.BackColor = Color.Green; ;
            }
        }
    }
}