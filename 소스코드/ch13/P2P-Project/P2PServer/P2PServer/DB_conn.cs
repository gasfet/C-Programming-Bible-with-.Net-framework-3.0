using System;
using System.Data;            // 데이터베이스 연결
using System.Data.SqlClient;  // SQL 서버에 연결

namespace P2PServer 
{
	/// <summary>
	/// SQL Express 2005 서버를 사용하는 DB_conn
	/// </summary>	
	public class DB_conn 
    {
		//  SQL 2005서버 dsn 설정
		//  Server = localhost 
		//  데이터베이스 = p2p
        //  사용자 계정 = mydb
        //  사용자 암호 = 1234 
        private string dsn = @"Server=localhost\sqlexpress;database=p2p;uid=mydb;pwd=1234;";			

		// SQL 2000 서버 연결에 사용하는 클래스
		private SqlConnection conn = null ;             

		/// <summary>
		/// DB_conn 생성자1
		/// 매개 변수 없는 default 생성자
		/// </summary>
		public DB_conn()
        {			
		}

		/// <summary>
		/// DB_conn 생성자 2
		/// SQL 서버 연결용 dsn 설정
		/// </summary>
		/// <param name="dsn"></param>
		public DB_conn( string dsn )
        {
			// dsn 지정
			this.dsn = dsn ; 
		}

		/// <summary>
		///  SQL 서버 연결
		/// </summary>
		public void Open() 
        {
			// dsn 설정에 따라 SQL 서버 인스턴스 설정
			conn = new SqlConnection(dsn);
            conn.Open();  // 데이터베이스 연결
		}

		/// <summary>
		/// SQL 서버와 연결 종료
		/// </summary>
		public void Close() 
        {
			// 데이터베이스와 연결 종료
			conn.Close();
		}
        
		/// <summary>
		/// SQL 쿼리문 실행
		/// - insert, update, delete , alter, create
		/// - drop 문 사용 가능
		/// - select 문은 사용불가
		/// </summary>
		/// <param name="sql">SQL 쿼리문 </param>		
		
		public void ExecuteNonQuery( string sql ) 
        {
			// SQL 쿼리문 실행 준비
			SqlCommand cmd = new SqlCommand (sql, conn);
			// SQL 쿼리문 실행 (반환값이 없는 쿼리문)
			cmd.ExecuteNonQuery();			
		}
        
		/// <summary>
		///  SQL 쿼리문 실행
		///  - select 문 전용
		/// </summary>
		/// <param name="sql">SQL 쿼리문</param>
		/// <returns>select 문 결과 반환</returns>
		public SqlDataReader ExecuteReader( string sql ) 
        {
			// SQL 쿼리문 실행 준비 
			SqlCommand cmd = new SqlCommand (sql,conn);
			// SQL 쿼리문 실행 결과 반환
			return cmd.ExecuteReader() ;
		}          

	}
}
