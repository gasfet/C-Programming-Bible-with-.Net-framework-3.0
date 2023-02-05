using System;
using System.Data;            // 데이터베이스 연결
using System.Data.SqlClient;  // SQL 서버에 연결
using System.Data.OleDb;       // OLE DB에 연결 


namespace P2PServer
{
    /// <summary>
    /// Pass 테이블 처리 클래스.
    /// </summary>
    public class PassTableInfo
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public PassTableInfo()
        {
        }

        /// <summary>
        /// 현재 접속한 서버 목록 알아내는 메서드
        /// </summary>
        /// <param name="myIP">현재 목록을 요구하는 사용자의 IP</param>
        /// <returns>현재 접속한 서버 목록</returns>
        public string Get_Current_Server(string myIP)
        {
            // 반환값 처리 변수
            string return_value = null;
            // DB연결 인스턴스 생성
            DB_conn conn = new DB_conn();
            // DB 연결
            conn.Open();

            // Pass 테이블에서 myIP와 일치하지 않는 모든 ip번호 반환			
            string sql = "select ip from TBL_pass where ip <> '" + myIP + "'";

            // sql변수의 반환값 처리 변수
            SqlDataReader reader = null;

            try
            { // DB 사용중에는 예외처리 시작
                // Select 문 반환값 받아오기
                reader = conn.ExecuteReader(sql);

                // 서버에 접속한 모든 사용자 IP반환
                while (reader.Read())
                {
                    // 현재 접속한 서버 목록 출력 ( 구분자 & 이용 )
                    return_value += "&" + reader[0].ToString().Trim();
                }
            }
            catch (Exception ex)
            { // DB 처리중 예외가 발생하면
                // 예외 메시지 출력
                System.Windows.Forms.MessageBox.Show("에러발생" + ex.StackTrace);
                // 예외가 발생하면 현재 접속한 사용자 하나도 없음
                return_value = "";
            }
            finally
            { // DB처리중 무조건 처리할 구문
                // reader 인스턴스 해제
                if (reader != null) reader.Close();
                // conn 인스턴스 해제
                if (conn != null) conn.Close();
            }
            return return_value; // 현재 접속한 서버 목록 반환		

        }
    }
}
