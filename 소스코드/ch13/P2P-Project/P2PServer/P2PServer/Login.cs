using System;
using System.Data;            // 데이터베이스 연결
using System.Data.SqlClient;  // SQL 서버에 연결
using System.Data.OleDb;       // OLE DB에 연결 

namespace P2PServer
{

    /// <summary>
    /// P2P 서버 로그인 처리에 관련된 클래스
    /// </summary>
    public class Login
    {
        // user_id  = 로그인 아이디
        // user_pwd = 로그인 암호
        // myIP     = 로그인 클라이언트 IP
        string user_id, user_pwd, myIP;

        /// <summary>
        /// 로그인클래스 생성자
        /// </summary>
        /// <param name="user_id">로그인 아이디</param>
        /// <param name="user_pwd">로그인 비밀번호</param>
        /// <param name="myIP">로그인클라이언트 IP</param>
        public Login(string user_id, string user_pwd, string myIP)
        {
            this.user_id = user_id;    // 로그인 아이디 
            this.user_pwd = user_pwd;  // 로그인 비밀번호
            this.myIP = myIP;          // 로그인 클라이언트 IP			
        }


        /// <summary>
        ///  로그인 처리 수행 
        /// </summary>
        /// <returns>로그인 성공,실패 메시지</returns>
        public string Connection()
        {
            // 반환값 저장 변수
            string return_value = null;

            // 접속자 아이피 주소 구하기		
            // member 테이블에 로그인 아이디와 일치하는 레코드 검색
            string sql = "select id, pwd from TBL_member where id='" + user_id + "'";

            // DB 연결 준비
            DB_conn conn = new DB_conn();
            // DB 열기
            conn.Open();
            // select 문의 결과를 받을 SqlDataReader 준비
            SqlDataReader reader = null;

            // 데이터 베이스 결과 처리시 발생할 예외 처리
            try
            { // try 블록 시작
                // select 문 결과 반환 
                reader = conn.ExecuteReader(sql);


                if (reader.Read())
                {  // 아이디 존재할 경우
                    if (reader[1].ToString().Equals(user_pwd))
                    {  // 비밀번호 일치할 경우
                        PASS_confirm(user_id, myIP);    // PASS 테이블에 사용자 등록

                        return_value = "S_RES_LOGINOK#";  // 로그인 성공 메시지

                        // Pass테이블에 대한 정보 추출 클래스 초기화
                        PassTableInfo info = new PassTableInfo();
                        // 로그인 시점에 접속한 모든 서버 목록
                        return_value += info.Get_Current_Server(myIP);

                    }
                    else
                    { // 패스워드가 일치하지 않을 경우
                        // 로그인 비밀번호 틀림
                        return_value = "S_RES_PASSWORD#";
                    }
                }
                else
                { // 로그인 아이디가 존재하지 않을 경우
                    // 로그인 아이디 존재하지 않음
                    return_value = "S_RES_USERID#";
                }
            }
            catch (Exception ex)
            { // DB 연결에서 예외 발생
                // 예외 발생 이유를 출력
                System.Windows.Forms.MessageBox.Show("에러발생" + ex.StackTrace);
                // 접속한 클라이언트에 DB 처리 예외 메시지 알림
                return_value = "S_RES_LOGINFAIL#";
            }
            finally
            { // 예외가 발생하건 안하건 무조건 처리할 블록
                // reader 가 연결되어 있으면 메모리 해제
                if (reader != null) reader.Close();
                // DB연결 conn 인스턴스 해제
                if (conn != null) conn.Close();
            }
            return return_value; // 반환값 
        }


        /// <summary>
        ///  Pass 테이블에 로그인 사용자 등록
        /// </summary>
        /// <param name="user_id">로그인 아이디</param>
        /// <param name="myIP">접속한 사용자 IP</param>
        void PASS_confirm(string user_id, string myIP)
        {
            // Pass 테이블에서 로그인사용자가 있는지 검사
            string str = "Select * from TBL_pass where user_id='" + user_id + "'";
            // 쿼리문을 처리할 변수 선언
            string query = null;

            // DB연결 처리위해 conn1 과 conn2 인스턴스 생성
            DB_conn conn1 = new DB_conn();
            DB_conn conn2 = new DB_conn();

            // conn1 과 conn2 연결
            conn1.Open();
            conn2.Open();

            // Select 쿼리문 결과 반환 받을 변수 선언
            SqlDataReader reader = null;

            try
            {
                // 로그인 사용자가 이미 Pass테이블에 등록되어 있는지 검사
                reader = conn1.ExecuteReader(str);


                if (reader.Read())
                {  // Pass 테이블에 이미 사용자가 있다면
                    // 사용자의 IP를 새로 업데이트
                    query = "update TBL_pass set ip ='" + myIP + "' where user_id='" + user_id + "'";
                }
                else
                {  // Pass테이블에 로그인 사용자가 없다면
                    // 사용자 ID와 IP를 Pass 테이블에 추가
                    query = "insert into TBL_pass values('" + user_id + "','" + myIP + "')";
                }
                // 새로운 변경사항 실행
                conn2.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            { // DB처리 과정에서 예외가 발생하면
                // 예외 메시지 출력
                System.Windows.Forms.MessageBox.Show(ex.StackTrace);
            }
            finally
            { // DB 처리 과정중에 무조건 처리할 구문
                // reader 인스턴스 해제
                if (reader != null) reader.Close();
                // conn1 인스턴스 해제
                if (conn1 != null) conn1.Close();
                // conn2 인스턴스 해제
                if (conn2 != null) conn2.Close();
            }

        }

    }
}
