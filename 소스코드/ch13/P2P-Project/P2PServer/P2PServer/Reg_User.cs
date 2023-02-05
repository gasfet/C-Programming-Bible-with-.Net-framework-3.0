using System;
using System.Windows.Forms;
using System.Data;            // 데이터베이스 연결
using System.Data.SqlClient;  // SQL 서버에 연결
using System.Data.OleDb;       // OLE DB에 연결 


namespace P2PServer
{
    /// <summary>
    /// P2P 서버에 회원 등록 처리 클래스
    /// </summary>
    public class Reg_User
    {
        /// <summary>
        ///  생성자
        /// </summary>
        public Reg_User()
        {
        }


        /// <summary>
        /// 아이디 중복 체크 함수
        /// </summary>
        /// <param name="id">중복 검사할 id</param>
        /// <returns>중복 체크 결과 반환</returns>

        public string Id_Check(string id)
        {
            // 반환값 처리 변수 
            string return_value;
            // member테이블에 이미 ID가 등록되어 있는지 검사
            string sql = "select id from TBL_member where id='" + id + "'";

            // DB 연결 인스턴스 생성
            DB_conn conn = new DB_conn();
            // DB 연결
            conn.Open();

            // select 쿼리문 반환값 처리 변수
            SqlDataReader reader = null;

            try
            { // DB처리중에 발생할 예외처리
                // sql 문의 반환값 받아오기
                reader = conn.ExecuteReader(sql);

                if (!reader.Read())
                {  // 아이디가 사용가능 할때				
                    // 아이디 중복 검사 성공, 요청한 아이디 사용가능
                    return_value = "S_RES_MEMBERIDOK#";
                }
                else
                { // 아이디가 이미 member 테이블에 존재할 경우               
                    // 아이디 사용 불가
                    return_value = "S_RES_MEMBERIDFAIL#";
                }
            }
            catch (Exception ex)
            { // 예외가 발생할 경우
                // 서버에서 예외 발생
                return_value = "S_RES_ERROR#" + ex.ToString();
            }
            finally
            {
                // reader 인스턴스 해제
                if (reader != null) reader.Close();
                // conn 인스턴스 해제
                if (conn != null) conn.Close();
            }

            // ID 사용 유무를 반환
            return return_value;

        }

        /// <summary>
        ///  회원 가입 함수
        /// </summary>
        /// <param name="message">회원 가입 요청 메시지</param>
        /// <returns>회원 가입 성공 유무 반환</returns>

        public bool IsRegister(string message)
        {
            // 회원 가입 성공 유무 체크 변수
            bool flag = false;

            // 회원 가입 요청 메시지 받아오기
            string str = message;
            // # 토큰을 이용해 메시지 분석
            char[] ch = { '#' };
            string[] token = str.Split(ch);

            //메시지는 #사용자아이디#비밀번호#이메일주소 형식으로 구성됨

            // DB 연결 
            DB_conn conn = new DB_conn();
            conn.Open();


            // member 테이블에 회원에 대한 정보를 Insert
            string sql = "Insert into TBL_member ( id, pwd,  email ) values('";

            sql += token[1] + "','";   // 아이디
            sql += token[2] + "','";   // 비밀번호
            sql += token[3] + "')";    // 이메일 주소 

            try
            {
                // 회원 가입 쿼리문 실행
                conn.ExecuteNonQuery(sql);
                // 회원 가입 성공
                flag = true;
            }
            catch
            {
                // 회원 가입이 실패할 경우 
                flag = false;
            }
            finally
            {
                // DB연결 해제 
                if (conn != null) conn.Close();
            }
            return flag; // 회원 가입 성공 유무 반환
        }

    }
}
