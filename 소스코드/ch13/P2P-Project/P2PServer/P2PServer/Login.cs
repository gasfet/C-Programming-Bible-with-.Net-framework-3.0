using System;
using System.Data;            // �����ͺ��̽� ����
using System.Data.SqlClient;  // SQL ������ ����
using System.Data.OleDb;       // OLE DB�� ���� 

namespace P2PServer
{

    /// <summary>
    /// P2P ���� �α��� ó���� ���õ� Ŭ����
    /// </summary>
    public class Login
    {
        // user_id  = �α��� ���̵�
        // user_pwd = �α��� ��ȣ
        // myIP     = �α��� Ŭ���̾�Ʈ IP
        string user_id, user_pwd, myIP;

        /// <summary>
        /// �α���Ŭ���� ������
        /// </summary>
        /// <param name="user_id">�α��� ���̵�</param>
        /// <param name="user_pwd">�α��� ��й�ȣ</param>
        /// <param name="myIP">�α���Ŭ���̾�Ʈ IP</param>
        public Login(string user_id, string user_pwd, string myIP)
        {
            this.user_id = user_id;    // �α��� ���̵� 
            this.user_pwd = user_pwd;  // �α��� ��й�ȣ
            this.myIP = myIP;          // �α��� Ŭ���̾�Ʈ IP			
        }


        /// <summary>
        ///  �α��� ó�� ���� 
        /// </summary>
        /// <returns>�α��� ����,���� �޽���</returns>
        public string Connection()
        {
            // ��ȯ�� ���� ����
            string return_value = null;

            // ������ ������ �ּ� ���ϱ�		
            // member ���̺� �α��� ���̵�� ��ġ�ϴ� ���ڵ� �˻�
            string sql = "select id, pwd from TBL_member where id='" + user_id + "'";

            // DB ���� �غ�
            DB_conn conn = new DB_conn();
            // DB ����
            conn.Open();
            // select ���� ����� ���� SqlDataReader �غ�
            SqlDataReader reader = null;

            // ������ ���̽� ��� ó���� �߻��� ���� ó��
            try
            { // try ��� ����
                // select �� ��� ��ȯ 
                reader = conn.ExecuteReader(sql);


                if (reader.Read())
                {  // ���̵� ������ ���
                    if (reader[1].ToString().Equals(user_pwd))
                    {  // ��й�ȣ ��ġ�� ���
                        PASS_confirm(user_id, myIP);    // PASS ���̺� ����� ���

                        return_value = "S_RES_LOGINOK#";  // �α��� ���� �޽���

                        // Pass���̺� ���� ���� ���� Ŭ���� �ʱ�ȭ
                        PassTableInfo info = new PassTableInfo();
                        // �α��� ������ ������ ��� ���� ���
                        return_value += info.Get_Current_Server(myIP);

                    }
                    else
                    { // �н����尡 ��ġ���� ���� ���
                        // �α��� ��й�ȣ Ʋ��
                        return_value = "S_RES_PASSWORD#";
                    }
                }
                else
                { // �α��� ���̵� �������� ���� ���
                    // �α��� ���̵� �������� ����
                    return_value = "S_RES_USERID#";
                }
            }
            catch (Exception ex)
            { // DB ���ῡ�� ���� �߻�
                // ���� �߻� ������ ���
                System.Windows.Forms.MessageBox.Show("�����߻�" + ex.StackTrace);
                // ������ Ŭ���̾�Ʈ�� DB ó�� ���� �޽��� �˸�
                return_value = "S_RES_LOGINFAIL#";
            }
            finally
            { // ���ܰ� �߻��ϰ� ���ϰ� ������ ó���� ���
                // reader �� ����Ǿ� ������ �޸� ����
                if (reader != null) reader.Close();
                // DB���� conn �ν��Ͻ� ����
                if (conn != null) conn.Close();
            }
            return return_value; // ��ȯ�� 
        }


        /// <summary>
        ///  Pass ���̺� �α��� ����� ���
        /// </summary>
        /// <param name="user_id">�α��� ���̵�</param>
        /// <param name="myIP">������ ����� IP</param>
        void PASS_confirm(string user_id, string myIP)
        {
            // Pass ���̺��� �α��λ���ڰ� �ִ��� �˻�
            string str = "Select * from TBL_pass where user_id='" + user_id + "'";
            // �������� ó���� ���� ����
            string query = null;

            // DB���� ó������ conn1 �� conn2 �ν��Ͻ� ����
            DB_conn conn1 = new DB_conn();
            DB_conn conn2 = new DB_conn();

            // conn1 �� conn2 ����
            conn1.Open();
            conn2.Open();

            // Select ������ ��� ��ȯ ���� ���� ����
            SqlDataReader reader = null;

            try
            {
                // �α��� ����ڰ� �̹� Pass���̺� ��ϵǾ� �ִ��� �˻�
                reader = conn1.ExecuteReader(str);


                if (reader.Read())
                {  // Pass ���̺� �̹� ����ڰ� �ִٸ�
                    // ������� IP�� ���� ������Ʈ
                    query = "update TBL_pass set ip ='" + myIP + "' where user_id='" + user_id + "'";
                }
                else
                {  // Pass���̺� �α��� ����ڰ� ���ٸ�
                    // ����� ID�� IP�� Pass ���̺� �߰�
                    query = "insert into TBL_pass values('" + user_id + "','" + myIP + "')";
                }
                // ���ο� ������� ����
                conn2.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            { // DBó�� �������� ���ܰ� �߻��ϸ�
                // ���� �޽��� ���
                System.Windows.Forms.MessageBox.Show(ex.StackTrace);
            }
            finally
            { // DB ó�� �����߿� ������ ó���� ����
                // reader �ν��Ͻ� ����
                if (reader != null) reader.Close();
                // conn1 �ν��Ͻ� ����
                if (conn1 != null) conn1.Close();
                // conn2 �ν��Ͻ� ����
                if (conn2 != null) conn2.Close();
            }

        }

    }
}
