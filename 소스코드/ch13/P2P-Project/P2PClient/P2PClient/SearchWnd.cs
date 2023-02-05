using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace P2PClient
{
    public partial class SearchWnd : Form
    {
        delegate void InvokeInit_ListView();
        delegate void InvokeAdd_ListView(string fname, string fsize, string ftime, string s_ip);
        delegate void InvokeSortColumn(int iColumn);
        delegate void InvokeInit_Progress_Bar(int i);
        delegate void InvokeProgress_Bar();
        delegate void InvokeSet_Message(string str);

        public MainWnd client = null;       // 메인 서버 연결 클라이언트
        private int progress = 0;           // 검색 진행 사항 프로그래스바 현재 위치
        private int pgb_index = 0;          // 검색 진행 사항 프로그래스바 초기화


        public SearchWnd(MainWnd client)
        {
            InitializeComponent();
            this.client = client;
        }


        /// <summary>
        /// ListView 초기화 메서드
        /// </summary>
        private void Init_ListView()
        {
            try
            {
                if (lstView.InvokeRequired)
                {
                    InvokeInit_ListView d = new InvokeInit_ListView(Init_ListView);
                    this.Invoke(d, new object[] {});
                }
                else
                {
                    lstView.Clear();                         // 초기화 
                    lstView.View = View.Details;             // View옵션을 Details로 설정
                    lstView.LabelEdit = false;               // 편집 기능 비활성화
                    lstView.CheckBoxes = true;               // 체크 박스 기능 활성화
                    lstView.FullRowSelect = true;            // 전체 선택 기능 활성화 
                    lstView.GridLines = true;                // 윤곽선 설정   
                    lstView.Sorting = SortOrder.Ascending;   // 오름차순 정렬
                    // 파일명 출력 헤더 만들기
                    lstView.Columns.Add("파일명", 225, HorizontalAlignment.Left);
                    // 파일 크기 출력 헤더 만들기
                    lstView.Columns.Add("파일크기", 80, HorizontalAlignment.Right);
                    // 수정일자 출력 헤더 만들기
                    lstView.Columns.Add("수정일자", 120, HorizontalAlignment.Right);
                    // 서버 IP 출력 헤더 만들기
                    lstView.Columns.Add("서버IP", 90, HorizontalAlignment.Center);
                }
            }
            catch { } //  멀티 스레드 환경에서 뜻하지 않은 예외가 발생할 경우 처리

        }

        /// <summary>
        /// 리스트 뷰에 목록 추가 메서드
        /// </summary>
        /// <param name="fname">파일 이름</param>
        /// <param name="fsize">파일 사이즈</param>
        /// <param name="ftime">파일 생성시간</param>
        /// <param name="s_ip">파일이 존재하는 컴퓨터 IP</param>
        public void Add_ListViwe(string fname, string fsize, string ftime, string s_ip)
        {
            try
            {
                if (lstView.InvokeRequired)
                {
                    InvokeAdd_ListView d = new InvokeAdd_ListView(Add_ListViwe);
                    this.Invoke(d, new object[] { fname, fsize, ftime, s_ip });
                }
                else
                {
                    ListViewItem item = new ListViewItem(fname, 0); // 파일 이름
                    item.SubItems.Add(fsize);   // 파일 크기
                    item.SubItems.Add(ftime);   // 파일 생성시간
                    item.SubItems.Add(s_ip);   // 파일 존재 서버 아이피		
                    lstView.Items.Add(item);    // ListView 에 추가
                }
            }
            catch { } // 멀티 스레드 환경에서 뜻하지 않은 예외가 발생할 경우 처리

        }

        /// <summary>
        ///  선택한 컬럼 정렬 메서드
        /// </summary>
        /// <param name="iColumn">선택한 컬럼</param>
        public void SortColumn(int iColumn)
        {
            try
            {
                if (lstView.InvokeRequired)
                {
                    InvokeSortColumn d = new InvokeSortColumn(SortColumn);
                    this.Invoke(d, new object[] { iColumn });
                }
                else
                {
                    // 컬럼 정렬을 위해 만든 ListViewCompare 클래스 선언
                    ListViewComparer lvc = new ListViewComparer();
                    try
                    {
                        string s1 = lstView.Items[1].SubItems[iColumn].Text.ToUpper().Trim();
                        long lng = Convert.ToInt32(s1);
                        lvc.BNUMERIC = true;
                    }
                    catch
                    {
                        lvc.BNUMERIC = false;
                    }
                    lvc.COLUMN = iColumn;
                    lstView.ListViewItemSorter = lvc;
                }
            }
            catch { } // 멀티 스레드 환경에서 뜻하지 않은 예외가 발생할 경우 처리
        }



        /// <summary>
        ///  검색 진행 사항 프로그래스바 초기화
        /// </summary>
        /// <param name="i">프로그래스바 최대 크기</param>
        private void Init_Progress_Bar(int i)
        {
            try
            {
                if (pgb_search.InvokeRequired)
                {
                    InvokeInit_Progress_Bar d = new InvokeInit_Progress_Bar(Init_Progress_Bar);
                    this.Invoke(d, new object[] { i });
                }
                else
                {
                    pgb_search.Value = 0;
                    this.progress = (100 / i);
                }
            }
            catch { } // 멀티 스레드 환경에서 뜻하지 않은 예외가 발생할 경우 처리
        }

        /// <summary>
        /// 검색 진행사항 프로그래스바 메서드
        /// </summary>
        public void Progress_Bar()
        {
            try
            {
                if (pgb_search.InvokeRequired)
                {
                    InvokeProgress_Bar d = new InvokeProgress_Bar(Progress_Bar);
                    this.Invoke(d, new object[] {});
                }
                else
                {
                    pgb_index++;
                    pgb_search.Value = (pgb_index * progress) > 100 ? 0 : (pgb_index * progress);
                }
            }
            catch { } // 멀티 스레드 환경에서 뜻하지 않은 예외가 발생할 경우 처리
        }

 

   
        /// <summary>
        /// 수신 데이터 창에 메시지 추가 메서드
        /// </summary>
        /// <param name="str">추가할 메시지</param>
        public void Set_Message(string str)
        {
            try
            {
                if (txt_message.InvokeRequired)
                {
                    InvokeSet_Message d = new InvokeSet_Message(Set_Message);
                    this.Invoke(d, new object[] { str });
                }
                else
                {
                    txt_message.Text += "\r\n" + str; // 메시지 추가     
                }
            }
            catch { } // 멀티 스레드 환경에서 뜻하지 않은 예외가 발생할 경우 처리            
        }



        /// <summary>
        ///  검색창이 떴을때 초기화 작업 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchWnd_Load(object sender, System.EventArgs e)
        {
            Init_ListView();              // ListView 최기화

            cmb_ext.BeginUpdate();		//파일 확장자 선택 콤보박스 내용 업데이트 시작
            cmb_ext.Items.Add(".*");    // .* 콤보박스에 추가
            cmb_ext.Items.Add(".txt");  // .txt 콤보박스에 추가
            cmb_ext.Items.Add(".avi");  // .avi 콤보박스에 추가						
            cmb_ext.Items.Add(".mp3");  // .mp3 콤보박스에 추가
            cmb_ext.Items.Add(".mpg");  // .mpg 콤보박스에 추가            
            cmb_ext.Items.Add(".zip");  // .zip 콤보박스에 추가
            cmb_ext.Items.Add(".jpg");  // .jpg 콤보박스에 추가
            cmb_ext.Items.Add(".gif");  // .gif 콤보박스에 추가
            cmb_ext.EndUpdate();        // 콤보박스 내용 업데이트 끝 

            cmb_ext.SelectedIndex = 0; //파일 확장자 선택 콤보박스 0 번..설정.
        }

  
        /// <summary>
        /// ListView에서 더블 클릭시에 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstView_DoubleClick(object sender, System.EventArgs e)
        {
            int index = 0; // 현재 더블클릭한 위치 저장 변수

            foreach (ListViewItem item in lstView.SelectedItems)
            {
                index = lstView.Items.IndexOf(item);
            }

            string fname = lstView.Items[index].SubItems[0].Text;// 파일 이름
            string fsize = lstView.Items[index].SubItems[1].Text;// 파일 사이즈
            string ftime = lstView.Items[index].SubItems[2].Text;// 파일 생성 시간
            string s_ip = lstView.Items[index].SubItems[3].Text;// 파일 위치 

            // 파일 다운로드 클래스 선언
            FileDownWnd fd = new FileDownWnd(this.client.downdirectory);
            // 파일 이름, 파일크기 , 파일 생성 시간, 파일위치
            fd.Set_Info(fname, fsize, ftime, s_ip);
            // 파일 다운로드 화면 출력
            fd.Show();
        }


        /// <summary>
        /// ListView 컬럼을 클릭 했을때 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstView_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            SortColumn(e.Column); // 컬럼을 정렬 			
        }

        /// <summary>
        /// 검색 버튼 클릭시에 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_search_Click(object sender, System.EventArgs e)
        {
            try
            {
                //리스트 뷰 초기화
                Init_ListView();
                //검색 프로그래스바 초기화
                Init_Progress_Bar(client.server_list.Length);

                // 검색 문자열  
                string[] ext_type = { ".*", ".txt", "*.avi", "*.mp3", "*.mpg", "*.zip", "*.jpg", "*.gif" };

                //S_C_FILE#검색요청컴퓨터IP#검색 파일명			

                string message = "S_C_FILE#" + client.myIP + "#";

                // 검색 파일 타입 지정
                message += txt_file.Text.Trim() + ext_type[cmb_ext.SelectedIndex];

                // 파일 검색 서버에 클라이언트 생성해서 접속 시도
                SearchClient[] s_client = new SearchClient[client.server_list.Length];

                for (int i = 0; i < client.server_list.Length; i++)
                {
                    // 클라이언트 서버에 파일 검색 요청..!!
                    s_client[i] = new SearchClient(this);
                    s_client[i].Connect(client.server_list[i], message);
                }
            }
            catch
            {
                MessageBox.Show(" 검색 실패 ! ");
            }
        }

        /// <summary>
        /// 공유 폴더 지정 메뉴 클릭할때 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            // 파일 공유 다운로드 설정창 생성
            OptionWnd op = new OptionWnd(this.client);
            // 파일 공유창 보이기
            op.ShowDialog();
        }


        /// <summary>
        /// 검색창 종료시에 발생하는 메시지
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
			e.Cancel=true;               //폼닫기 취소
			this.ShowInTaskbar = false; //태스크바에서 안보이게..			
			this.Hide();                // 현재 창 안보이게 하기		
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstView.CheckedItems)
            {
                int index = lstView.Items.IndexOf(item);

                string fname = lstView.Items[index].SubItems[0].Text; // 파일 이름
                string fsize = lstView.Items[index].SubItems[1].Text; // 파일 사이즈
                string ftime = lstView.Items[index].SubItems[2].Text; // 파일 생성 시간
                string s_ip = lstView.Items[index].SubItems[3].Text; // 파일 위치

                // 파일 다운로드 클래스 선언
                FileDownWnd fd = new FileDownWnd(this.client.downdirectory);
                // 파일 이름, 파일크기 , 파일 사이즈, 파일위치
                fd.Set_Info(fname, fsize, ftime, s_ip);
                // 파일 다운로드 화면 출력
                fd.Show();
            }
        }
    }




    /// <summary>
    /// 정렬 처리 클래스
    /// </summary>
    class ListViewComparer : System.Collections.IComparer  // IComparer 인터페이스 상속
    {
        private int m_Column;       // 컬럼  
        private bool m_bNumeric;    // 정렬할 갯수

        /// <summary>
        ///  두개 객체 비교 메서드
        /// </summary>
        /// <param name="Object1">첫번째 비교대상</param>
        /// <param name="Object2">두번째 비교대상</param>
        /// <returns></returns>
        public int Compare(object Object1, object Object2)
        {
            if (!(Object1 is ListViewItem) && !(Object2 is
                ListViewItem))
                return 0;

            // ListViewItem 형식으로 형 변환
            ListViewItem lv1 = (ListViewItem)Object1;
            ListViewItem lv2 = (ListViewItem)Object2;

            if (m_bNumeric)
                return (Convert.ToInt32(lv1.SubItems
                    [m_Column].Text) - Convert.ToInt32(lv2.SubItems
                    [m_Column].Text));
            else
                return String.Compare(lv1.SubItems
                    [m_Column].Text, lv2.SubItems[m_Column].Text);
        }

        /// <summary>
        /// bNumeric 속성
        /// </summary>
        public bool BNUMERIC
        {
            set
            {
                m_bNumeric = value;
            }
        }

        /// <summary>
        ///  Column 속성
        /// </summary>
        public int COLUMN
        {
            set
            {
                m_Column = value;
            }
        }
    }
}