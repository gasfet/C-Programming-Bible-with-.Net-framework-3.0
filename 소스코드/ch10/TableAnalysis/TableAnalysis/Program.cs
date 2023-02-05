using System;
using System.Data;
using System.Data.SqlClient;

class TableAnalysis
{
    static void Main(string[] args)
    {
        string sql = @"Server=localhost\sqlexpress;database=ADO;uid=mydb;pwd=1234;";
        SqlConnection conn = new SqlConnection(sql);
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from member";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            SqlDataReader read = cmd.ExecuteReader();

            Console.WriteLine(" ***** 테이블 분석 결과 *****");

            for (int i = 0; i < read.FieldCount; i++)
            {
                Console.Write("필드 이름 : {0} \n", read.GetName(i));
            }
            Console.WriteLine("총 필드 갯수는 " + read.FieldCount);
            read.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine("에러발생 {0}", ex.Message);
        }
        finally
        {
            if (conn != null)
            {
                conn.Close();// 데이터베이스 연결 해제
                Console.WriteLine("데이터베이스 연결 해제.. ");
            }
        }
    }
}
