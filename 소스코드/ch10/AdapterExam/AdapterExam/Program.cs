using System;
using System.Data;
using System.Data.SqlClient;

namespace AdapterExam
{
    class AdapterExam
    {
        static void Main(string[] args)
        {
            try
            {
                string sql = @"Server=localhost\sqlexpress;Database=ADO;uid=mydb;pwd=1234";
                SqlConnection conn = new SqlConnection(sql);
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from member", conn);

                DataSet dataset = new DataSet("Member");
                adapter.Fill(dataset, "Member");     // Fill 메서드를 이용해 DataSet 생성

                Console.WriteLine(" ****************************** ");
                Console.WriteLine("  Member 테이블 칼럼 살펴보기   ");
                Console.WriteLine(" *      Fill 메서드 이용      * ");
                Console.WriteLine(" ****************************** ");

                Console.WriteLine(" 칼럼 이름 \t 데이터형 \t 데이터크기 \t 널값 허용여부 ");
                foreach (DataColumn col in dataset.Tables["Member"].Columns)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", col.ColumnName,
                        col.DataType, col.MaxLength, col.AllowDBNull);
                }
                Console.WriteLine("\n\n");

                adapter.FillSchema(dataset, SchemaType.Source, "Member");  // FillSchema 이용

                Console.WriteLine(" ****************************** ");
                Console.WriteLine("  Member 테이블 칼럼 살펴보기   ");
                Console.WriteLine(" *   FillSchema 메서드 이용   * ");
                Console.WriteLine(" ****************************** ");

                Console.WriteLine(" 칼럼 이름 \t 데이터형 \t 데이터크기 \t 널값 허용여부 ");
                foreach (DataColumn col in dataset.Tables["Member"].Columns)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", col.ColumnName,
                        col.DataType, col.MaxLength, col.AllowDBNull);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" 예외 발생 : {0}", ex.Message);
            }
        }
    }
}
