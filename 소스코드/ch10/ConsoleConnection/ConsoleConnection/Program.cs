using System;
using System.Data;
using System.Data.SqlClient;

class ConsoleConnection
{
    static void Main(string[] args)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = @"Server=localhost\SQLEXPRESS;database=AdventureWorks;uid=mydb;pwd=1234;";
        try
        {
            conn.Open();
            Console.WriteLine("데이터베이스 연결 성공...");
        }
        catch (Exception ex)  // 예외 처리
        {
            Console.WriteLine("데이터베이스 연결 실패...:" + ex.Message);
        }
        finally
        {
            if (conn != null)
            {
                conn.Close();
                Console.WriteLine("데이터베이스 연결 해제.. ");
            }
        }
    }
}

