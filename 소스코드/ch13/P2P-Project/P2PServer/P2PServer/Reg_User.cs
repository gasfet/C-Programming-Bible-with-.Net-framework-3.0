using System;
using System.Windows.Forms;
using System.Data;            // �����ͺ��̽� ����
using System.Data.SqlClient;  // SQL ������ ����
using System.Data.OleDb;       // OLE DB�� ���� 


namespace P2PServer
{
    /// <summary>
    /// P2P ������ ȸ�� ��� ó�� Ŭ����
    /// </summary>
    public class Reg_User
    {
        /// <summary>
        ///  ������
        /// </summary>
        public Reg_User()
        {
        }


        /// <summary>
        /// ���̵� �ߺ� üũ �Լ�
        /// </summary>
        /// <param name="id">�ߺ� �˻��� id</param>
        /// <returns>�ߺ� üũ ��� ��ȯ</returns>

        public string Id_Check(string id)
        {
            // ��ȯ�� ó�� ���� 
            string return_value;
            // member���̺� �̹� ID�� ��ϵǾ� �ִ��� �˻�
            string sql = "select id from TBL_member where id='" + id + "'";

            // DB ���� �ν��Ͻ� ����
            DB_conn conn = new DB_conn();
            // DB ����
            conn.Open();

            // select ������ ��ȯ�� ó�� ����
            SqlDataReader reader = null;

            try
            { // DBó���߿� �߻��� ����ó��
                // sql ���� ��ȯ�� �޾ƿ���
                reader = conn.ExecuteReader(sql);

                if (!reader.Read())
                {  // ���̵� ��밡�� �Ҷ�				
                    // ���̵� �ߺ� �˻� ����, ��û�� ���̵� ��밡��
                    return_value = "S_RES_MEMBERIDOK#";
                }
                else
                { // ���̵� �̹� member ���̺� ������ ���               
                    // ���̵� ��� �Ұ�
                    return_value = "S_RES_MEMBERIDFAIL#";
                }
            }
            catch (Exception ex)
            { // ���ܰ� �߻��� ���
                // �������� ���� �߻�
                return_value = "S_RES_ERROR#" + ex.ToString();
            }
            finally
            {
                // reader �ν��Ͻ� ����
                if (reader != null) reader.Close();
                // conn �ν��Ͻ� ����
                if (conn != null) conn.Close();
            }

            // ID ��� ������ ��ȯ
            return return_value;

        }

        /// <summary>
        ///  ȸ�� ���� �Լ�
        /// </summary>
        /// <param name="message">ȸ�� ���� ��û �޽���</param>
        /// <returns>ȸ�� ���� ���� ���� ��ȯ</returns>

        public bool IsRegister(string message)
        {
            // ȸ�� ���� ���� ���� üũ ����
            bool flag = false;

            // ȸ�� ���� ��û �޽��� �޾ƿ���
            string str = message;
            // # ��ū�� �̿��� �޽��� �м�
            char[] ch = { '#' };
            string[] token = str.Split(ch);

            //�޽����� #����ھ��̵�#��й�ȣ#�̸����ּ� �������� ������

            // DB ���� 
            DB_conn conn = new DB_conn();
            conn.Open();


            // member ���̺� ȸ���� ���� ������ Insert
            string sql = "Insert into TBL_member ( id, pwd,  email ) values('";

            sql += token[1] + "','";   // ���̵�
            sql += token[2] + "','";   // ��й�ȣ
            sql += token[3] + "')";    // �̸��� �ּ� 

            try
            {
                // ȸ�� ���� ������ ����
                conn.ExecuteNonQuery(sql);
                // ȸ�� ���� ����
                flag = true;
            }
            catch
            {
                // ȸ�� ������ ������ ��� 
                flag = false;
            }
            finally
            {
                // DB���� ���� 
                if (conn != null) conn.Close();
            }
            return flag; // ȸ�� ���� ���� ���� ��ȯ
        }

    }
}
