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
			Console.WriteLine("�����ͺ��̽� ���� ����..");
		}
		catch(Exception ex)
		{
			Console.WriteLine("�����ͺ��̽� ���� ����..");
		}
		finally
		{
			if(conn != null)	
			{
				conn.Close();
				Console.WriteLine("�����ͺ��̽� ���� ����.. ");
			}
		}
        }
}          