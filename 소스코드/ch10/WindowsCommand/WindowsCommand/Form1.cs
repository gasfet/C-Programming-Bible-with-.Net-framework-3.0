using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace WindowsCommand
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_CMD_Click(object sender, EventArgs e)
        {
            string sql = txt_SQL.Text.Trim().ToUpper();
            string sql_ori = txt_SQL.Text.Trim();

            try
            {
                if (sql.StartsWith("SELECT"))
                {
                    if (btn_SQL.Text == "SQL접속!")
                    {
                        m_sql_cmd.CommandText = sql_ori;
                        SqlDataReader read = m_sql_cmd.ExecuteReader();

                        txt_output.Text = "";

                        for (int i = 0; i < read.FieldCount; i++)
                            txt_output.Text = txt_output.Text + read.GetName(i) + "  ";
                        txt_output.Text = txt_output.Text + "\r\n";
                        while (read.Read())
                        {
                            for (int i = 0; i < read.FieldCount; i++)
                                txt_output.Text = txt_output.Text + read[i] + "  ";
                            txt_output.Text = txt_output.Text + "\r\n";
                        }
                        read.Close();

                    }
                    else if (btn_OLE.Text == "OLE 접속!")
                    {
                        m_ole_cmd.CommandText = sql;
                        OleDbDataReader read = m_ole_cmd.ExecuteReader();
                        txt_output.Text = "";

                        for (int i = 0; i < read.FieldCount; i++)
                            txt_output.Text = txt_output.Text + read.GetName(i) + "  ";
                        txt_output.Text = txt_output.Text + "\r\n";
                        while (read.Read())
                        {
                            for (int i = 0; i < read.FieldCount; i++)
                                txt_output.Text = txt_output.Text + read[i] + "  ";
                            txt_output.Text = txt_output.Text + "\r\n";
                        }
                        read.Close();
                    }
                }
                else
                {
                    if (btn_SQL.Text == "SQL접속!")
                    {
                        m_sql_cmd.CommandText = sql_ori;
                        m_sql_cmd.ExecuteNonQuery();
                        txt_output.Text = " 명령을 성공적으로 수행했음!";
                    }
                    else if (btn_OLE.Text == "OLE 접속!")
                    {
                        m_ole_cmd.CommandText = sql;
                        m_ole_cmd.ExecuteNonQuery();
                        txt_output.Text = " 명령을 성공적으로 수행했음!";
                    }
                }
            }
            catch(Exception ex)
            {
                string str = ex.Message;
                MessageBox.Show(sql_ori + "\n 쿼리문이 잘못되었습니다!", "잘못된 명령입니다!");
            }
        }

        private void btn_SQL_Click(object sender, EventArgs e)
        {
            if (btn_SQL.Text == "SQL서버")
            {
                try
                {
                    m_sql_connect.Open();
                    btn_SQL.Text = "SQL접속!";
                    btn_OLE.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace, "SQL 접속 에러발생");
                }
            }
            else
            {
                m_sql_connect.Close();
                btn_SQL.Text = "SQL서버";
                btn_OLE.Enabled = true;
            }
        }

        private void btn_OLE_Click(object sender, EventArgs e)
        {
            if (btn_OLE.Text == "OLE DB")
            {
                try
                {
                    m_ole_connect.Open();
                    btn_OLE.Text = "OLE 접속!";
                    btn_SQL.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace, "OLE 접속 에러발생");
                }
            }
            else
            {
                m_ole_connect.Close();
                btn_OLE.Text = "OLE DB";
                btn_SQL.Enabled = true;
            }

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}