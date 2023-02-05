using System;
using System.Data;            // �����ͺ��̽� ����
using System.Data.SqlClient;  // SQL ������ ����

namespace P2PServer 
{
	/// <summary>
	/// SQL Express 2005 ������ ����ϴ� DB_conn
	/// </summary>	
	public class DB_conn 
    {
		//  SQL 2005���� dsn ����
		//  Server = localhost 
		//  �����ͺ��̽� = p2p
        //  ����� ���� = mydb
        //  ����� ��ȣ = 1234 
        private string dsn = @"Server=localhost\sqlexpress;database=p2p;uid=mydb;pwd=1234;";			

		// SQL 2000 ���� ���ῡ ����ϴ� Ŭ����
		private SqlConnection conn = null ;             

		/// <summary>
		/// DB_conn ������1
		/// �Ű� ���� ���� default ������
		/// </summary>
		public DB_conn()
        {			
		}

		/// <summary>
		/// DB_conn ������ 2
		/// SQL ���� ����� dsn ����
		/// </summary>
		/// <param name="dsn"></param>
		public DB_conn( string dsn )
        {
			// dsn ����
			this.dsn = dsn ; 
		}

		/// <summary>
		///  SQL ���� ����
		/// </summary>
		public void Open() 
        {
			// dsn ������ ���� SQL ���� �ν��Ͻ� ����
			conn = new SqlConnection(dsn);
            conn.Open();  // �����ͺ��̽� ����
		}

		/// <summary>
		/// SQL ������ ���� ����
		/// </summary>
		public void Close() 
        {
			// �����ͺ��̽��� ���� ����
			conn.Close();
		}
        
		/// <summary>
		/// SQL ������ ����
		/// - insert, update, delete , alter, create
		/// - drop �� ��� ����
		/// - select ���� ���Ұ�
		/// </summary>
		/// <param name="sql">SQL ������ </param>		
		
		public void ExecuteNonQuery( string sql ) 
        {
			// SQL ������ ���� �غ�
			SqlCommand cmd = new SqlCommand (sql, conn);
			// SQL ������ ���� (��ȯ���� ���� ������)
			cmd.ExecuteNonQuery();			
		}
        
		/// <summary>
		///  SQL ������ ����
		///  - select �� ����
		/// </summary>
		/// <param name="sql">SQL ������</param>
		/// <returns>select �� ��� ��ȯ</returns>
		public SqlDataReader ExecuteReader( string sql ) 
        {
			// SQL ������ ���� �غ� 
			SqlCommand cmd = new SqlCommand (sql,conn);
			// SQL ������ ���� ��� ��ȯ
			return cmd.ExecuteReader() ;
		}          

	}
}
