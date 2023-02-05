using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace MessengerServer
{
    public partial class ZipcodeWnd : Form
    {
        #region ��� ����/�Ӽ�

        private DataSet ds = null;
        private DataSet dsall = null;  // XML ���Ͽ��� ���� ��ü ������ ����
        private string addr = null;
        private string dsn = null;

        /// <summary>
        /// �����ȣ �ּ� ��ȯ
        /// </summary>
        public string Addr
        {
            get
            {
                return addr;
            }
        }


        #endregion

        #region ������
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="dsn"></param>
        public ZipcodeWnd(string dsn)
        {
            InitializeComponent();

            this.dsn = dsn;
        }
        #endregion

        #region ��� �޼���
        /// <summary>
        /// �����ȣ ������ �ҷ�����
        /// </summary>
        private void ZipcodeLoad(string search)
        {
            try
            {
                if (this.dsn != "XML")
                {
                    string sql = "select * from TBL_Zipcode where addr3 like '%";
                    sql += search + "%'";

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, this.dsn);

                    ds = new DataSet();

                    adapter.Fill(ds, "TBL_Zipcode");
                }
                else
                {
                    if (this.dsall == null)  // ó�� �˻��Ҷ��� XML ���Ͽ��� �о��
                    {
                        this.dsall = new DataSet();
                        dsall.ReadXmlSchema("ZipcodeSchema.xsd");
                        dsall.ReadXml("ZipcodeData.xml");
                    }
                    DataRow[] rows = dsall.Tables[0].Select("addr3 like '%" + search + "%'");

                    ds = dsall.Clone();
                    foreach (DataRow obj in rows)
                    {
                        DataRow row = ds.Tables[0].NewRow();
                        row["num"] = obj["num"];
                        row["zipcode"] = obj["zipcode"];
                        row["addr1"] = obj["addr1"];
                        row["addr2"] = obj["addr2"];
                        row["addr3"] = obj["addr3"];
                        row["no_start"] = obj["no_start"];
                        row["no_end"] = obj["no_end"];
                        row["addr4"] = obj["addr4"];
                        ds.Tables[0].Rows.Add(row);
                    }
                }
                this.dataGrid_Info.SetDataBinding(ds, "TBL_Zipcode");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        #region �̺�Ʈ
        /// <summary>
        /// ������ �׸��� ���� Ŭ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_Info_DoubleClick(object sender, EventArgs e)
        {
            int index = dataGrid_Info.CurrentRowIndex;  // ���� �׸��忡�� ������ �ּ� ��ġ

            DataRow dr = ds.Tables["TBL_Zipcode"].Rows[index];        // �����ͼ¿��� �ప ��������

            addr = dr["zipcode"] + "#";
            addr += dr["addr1"] + " " + dr["addr2"] + " " + dr["addr3"] + " ";

            if (dr["no_start"].ToString().Length > 0)
                addr += dr["no_start"];
            if (dr["no_end"].ToString().Length > 0)
                addr += "~" + dr["no_end"] + " ";
            if (dr["addr4"].ToString().Length > 0)
                addr += dr["addr4"];

            this.Close();
        }

        /// <summary>
        /// �ּ� �Է�â���� ����Ű ������ ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_Search.Text.Length == 0)
                {
                    MessageBox.Show("�˻��� �ּҸ� �Է��ϼ���", "���� �޽���");
                    return;
                }

                this.ZipcodeLoad(txt_Search.Text.Trim());
            }
        }

        /// <summary>
        /// �ּ� �˻� ��ư Ŭ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (txt_Search.Text.Length == 0)
            {
                MessageBox.Show("�˻��� �ּҸ� �Է��ϼ���", "���� �޽���");
                return;
            }

            this.ZipcodeLoad(txt_Search.Text.Trim());
        }

        #endregion

    }
}