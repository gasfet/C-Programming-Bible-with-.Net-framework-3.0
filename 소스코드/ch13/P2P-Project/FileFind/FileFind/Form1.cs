using System;
using System.Windows.Forms;

using System.IO;   // 추가된 부분

namespace FileFind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstView.Clear();                    // ListView 초기화
            lstView.View = View.Details;      // ListView의 View 모드 설정
            lstView.LabelEdit = false;         // 라벨 편집 못함
            lstView.CheckBoxes = true;       // 체크박스 표시
            lstView.FullRowSelect = true;     // 열 선택 가능  
            lstView.GridLines = true;          // 그리드 표시      
            lstView.Sorting = SortOrder.Ascending;  // 오름차순 정렬
            lstView.Columns.Add("파일명", 170, HorizontalAlignment.Left);
            lstView.Columns.Add("파일크기", 80, HorizontalAlignment.Right);
            lstView.Columns.Add("수정일자", 150, HorizontalAlignment.Left);

        }

        void Findfile(string str)
        {                     // str 로 파일 검색     
            string dir = txt_dir.Text.Trim();  // 검색할 디렉터리 이름 가져오기
            if (dir == "")                            // 검색할 디렉터리 이름이 없다면
            {
                MessageBox.Show("검색 디렉터리를 입력하세요.!");
                return;                               // 프로그램 종료
            }
            string[] files_list;                  // 검색 파일 리스트 저장
            try
            {
                files_list = Directory.GetFiles(dir, str);    // 파일 검색
                for (int i = 0; i < files_list.Length; i++)
                {  // ListView 에 검색 결과 출력하기
                    ListViewItem item1 = new ListViewItem(files_list[i], 0);
                    FileInfo finfo = new FileInfo(files_list[i]);
                    item1.SubItems.Add((finfo.Length/1024).ToString()+"kb");
                    item1.SubItems.Add(finfo.CreationTime.ToString());
                    lstView.Items.Add(item1);
                }
            }
            catch {	/*파일 검색 예외 발생 처리 */  }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_filename.Text != "")
            {
                lstView.Items.Clear(); 	      // ListView 초기화		
                Findfile(txt_filename.Text); // 파일 검색
            }

        }

    }
}