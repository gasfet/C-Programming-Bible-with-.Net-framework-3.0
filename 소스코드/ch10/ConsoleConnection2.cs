using System;
using System.Data;
using System.Data.OleDb;

class ConsoleConnection2
{
	static void Main(string[] args)
	{
		string source = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\ado.mdb" ;
		OleDbConnection conn = new OleDbConnection(source);
		try
		{
			conn.Open();
			Console.WriteLine("데이터베이스 연결 성공...");
		}
		catch(Exception ex)
		{
			Console.WriteLine("데이터베이스 연결 실패...");
		}
		finally
		{
			if(conn != null)	
			{
				conn.Close();
				Console.WriteLine("데이터베이스 연결 해제...");
			}
		}
	}
}
