using System;
using System.Data;
using System.Data.SqlClient;

class ConsoleConnection
{
	static void Main(string[] args)
	{
		SqlConnection conn = new SqlConnection();
		conn.ConnectionString = "Server=localhost;database=ADO;uid=sa;pwd=magic;" ;
		try
		{
			conn.Open();
			Console.WriteLine("데이터베이스 연결 성공..");
		}
		catch(Exception ex)
		{
			Console.WriteLine("데이터베이스 연결 실패..");
		}
		finally
		{
			if(conn != null)	
			{
				conn.Close();
				Console.WriteLine("데이터베이스 연결 해제.. ");
			}
		}
        }
}          