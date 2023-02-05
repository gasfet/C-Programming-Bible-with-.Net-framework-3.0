using System;
using System.Windows.Forms;
using System.Net;
using System.Text;
using System.IO;      

namespace WebReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_read_Click(object sender, EventArgs e)
        {          // 웹 페이지 연결
            WebRequest request = WebRequest.Create(txt_url.Text.Trim());
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            // 스트림에서 데이터 읽기
            StreamReader read = new StreamReader(stream);
            // 문자열을 효율적으로 처리하기 위해 StringBuilder 클래스 선언
            StringBuilder str_data = new StringBuilder();
            // 문장 단위로 데이터 읽어오기
            while ((read.ReadLine()) != null)
            {
                str_data.Append(read.ReadLine() + "\r\n");
            }
            // 스트림 닫기
            read.Close();
            // 화면에 출력
            txt_result.Text = str_data.ToString();
        }

    }
}