using System;
using System.Data;


class DataRowExam
{
    static void Main(string[] args)
    {
        DataTable table = new DataTable("member"); // 테이블 이름 지정

        // 테이블에 컬럼 생성
        DataColumn col = new DataColumn("Name", Type.GetType("System.String"));
        table.Columns.Add(col); // Name 컬럼 등록

        DataRow row = table.NewRow();
        // Detached 메시지 출력
        Console.WriteLine("레코드상태 {0}", row.RowState.ToString());

        table.Rows.Add(row); // 새로운 레코드 등록
        //Added 메시지 출력
        Console.WriteLine("레코드상태 {0}", row.RowState.ToString());

        table.AcceptChanges();
        // UnChanged 메시지 출력
        Console.WriteLine("레코드상태 {0}", row.RowState.ToString());

        row["Name"] = "홍길동";
        // Modified 메시지 출력
        Console.WriteLine("레코드상태 {0}", row.RowState.ToString());

        row.Delete();
        // Deleted 메시지 출력 
        Console.WriteLine("레코드상태 {0}", row.RowState.ToString());

        table.AcceptChanges();  // 테이블에 변경된 값 적용
    }
}


