using System;
using System.Data;            // �����ͺ��̽� ����
using System.Data.SqlClient;  // SQL ������ ����
using System.Data.OleDb;       // OLE DB�� ���� 


namespace P2PServer
{
    /// <summary>
    /// Pass ���̺� ó�� Ŭ����.
    /// </summary>
    public class PassTableInfo
    {
        /// <summary>
        /// ������
        /// </summary>
        public PassTableInfo()
        {
        }

        /// <summary>
        /// ���� ������ ���� ��� �˾Ƴ��� �޼���
        /// </summary>
        /// <param name="myIP">���� ����� �䱸�ϴ� ������� IP</param>
        /// <returns>���� ������ ���� ���</returns>
        public string Get_Current_Server(string myIP)
        {
            // ��ȯ�� ó�� ����
            string return_value = null;
            // DB���� �ν��Ͻ� ����
            DB_conn conn = new DB_conn();
            // DB ����
            conn.Open();

            // Pass ���̺��� myIP�� ��ġ���� �ʴ� ��� ip��ȣ ��ȯ			
            string sql = "select ip from TBL_pass where ip <> '" + myIP + "'";

            // sql������ ��ȯ�� ó�� ����
            SqlDataReader reader = null;

            try
            { // DB ����߿��� ����ó�� ����
                // Select �� ��ȯ�� �޾ƿ���
                reader = conn.ExecuteReader(sql);

                // ������ ������ ��� ����� IP��ȯ
                while (reader.Read())
                {
                    // ���� ������ ���� ��� ��� ( ������ & �̿� )
                    return_value += "&" + reader[0].ToString().Trim();
                }
            }
            catch (Exception ex)
            { // DB ó���� ���ܰ� �߻��ϸ�
                // ���� �޽��� ���
                System.Windows.Forms.MessageBox.Show("�����߻�" + ex.StackTrace);
                // ���ܰ� �߻��ϸ� ���� ������ ����� �ϳ��� ����
                return_value = "";
            }
            finally
            { // DBó���� ������ ó���� ����
                // reader �ν��Ͻ� ����
                if (reader != null) reader.Close();
                // conn �ν��Ͻ� ����
                if (conn != null) conn.Close();
            }
            return return_value; // ���� ������ ���� ��� ��ȯ		

        }
    }
}
