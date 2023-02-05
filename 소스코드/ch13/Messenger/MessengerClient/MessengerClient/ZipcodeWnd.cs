using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MessengerClient
{
    /// <summary>
    /// �����ȣ ó�� ���
    /// </summary>
    public partial class ZipcodeWnd : Form
    {
        #region ��� ����

        private string addr = null;      // �ּ� ���� ����
        private string server_ip = null; // ���� ������
        private RegNetwork net = null;

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
        /// <param name="net">�޽��� ���� ��� ��ü</param>
        /// <param name="server_ip">�޽��� ���� ������</param>
        public ZipcodeWnd(RegNetwork net, string server_ip)
        {
            InitializeComponent();

            this.net = net;
            this.server_ip = server_ip;
            this.Init_listView();
        }

        #endregion

        #region ��� �޼���

        /// <summary>
        /// ListView �ʱ�ȭ �޼���
        /// </summary>
        private void Init_listView()
        {
            lst_View.Clear();                         // �ʱ�ȭ 
            lst_View.View = View.Details;             // View�ɼ��� Details�� ����
            lst_View.LabelEdit = false;               // ���� ��� ��Ȱ��ȭ
            lst_View.CheckBoxes = true;               // üũ �ڽ� ��� Ȱ��ȭ						
            lst_View.GridLines = true;                // ������ ����   
            lst_View.Sorting = SortOrder.Ascending;   // �������� ����
            // ���� ���̵� ��� �����
            lst_View.Columns.Add("���� �ּ�", 90, HorizontalAlignment.Center);
            // ���� �ð� ��� �����
            lst_View.Columns.Add("�� �ּ�", 370, HorizontalAlignment.Left);
        }

        /// <summary>
        /// ����Ʈ�信 ��� �߰�
        /// </summary>
        /// <param name="zipcode">�����ȣ</param>
        /// <param name="addr">���ּ�</param>
        private void Add_listView(string zipcode, string addr)
        {
            ListViewItem item = new ListViewItem(zipcode);
            item.SubItems.Add(addr);  // ������ �ð� ����
            this.lst_View.Items.Add(item);
        }

        /// <summary>
        /// �����ȣ ������ �м�
        /// </summary>
        /// <param name="data">�����ȣ#�ּ�#�����ȣ#�ּ�...</param>
        public void ZipdataInput(string data)
        {
            this.Init_listView();

            string[] token = data.Split('#'); // ¦����° �����ȣ, Ȧ����° �ּ�

            for (int i = 0; i < token.Length - 1; i += 2)
            {
                this.Add_listView(token[i], token[i + 1]);
            }
        }

        #endregion

        #region �̺�Ʈ ó��
        /// <summary>
        /// �ּ� �˻�
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

            string msg = (byte)MSG.CTOS_MESSAGE_REGISTER_ZIPCODE + "\a" + txt_Search.Text.Trim();

            this.net.Connect(this.server_ip);
            this.net.Send(msg);
        }

        /// <summary>
        /// �ּ� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Select_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (ListViewItem item in lst_View.Items)
            {
                if (item.Checked)
                {
                    int index = lst_View.Items.IndexOf(item);
                    this.addr += lst_View.Items[index].SubItems[0].Text.Trim() + "#";
                    this.addr += lst_View.Items[index].SubItems[1].Text.Trim() + "#";
                    count++;
                }
            }

            if (count > 1)
            {
                MessageBox.Show("�����ȣ�� �ϳ��� �����ؾ� �մϴ�.!");
                return;
            }
            if (count == 0)
            {
                MessageBox.Show("�����ȣ�� �����ϼ���.!");
                return;
            }

            this.Close();
        }

        /// <summary>
        /// �ּ� �Է��� ��Ʈ 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Search_KeyDown(object sender, KeyEventArgs e)
        {
            // ����Ű�� ������ ���ڿ� �޽��� ����
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_Search.Text.Length == 0)
                {
                    MessageBox.Show("�˻��� �ּҸ� �Է��ϼ���", "���� �޽���");
                    return;
                }

                string msg = (byte)MSG.CTOS_MESSAGE_REGISTER_ZIPCODE + "\a" + txt_Search.Text.Trim();

                this.net.Connect(this.server_ip);
                this.net.Send(msg);
            }
        }
        #endregion
    }
}