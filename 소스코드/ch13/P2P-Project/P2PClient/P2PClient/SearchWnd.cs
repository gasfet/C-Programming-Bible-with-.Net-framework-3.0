using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace P2PClient
{
    public partial class SearchWnd : Form
    {
        delegate void InvokeInit_ListView();
        delegate void InvokeAdd_ListView(string fname, string fsize, string ftime, string s_ip);
        delegate void InvokeSortColumn(int iColumn);
        delegate void InvokeInit_Progress_Bar(int i);
        delegate void InvokeProgress_Bar();
        delegate void InvokeSet_Message(string str);

        public MainWnd client = null;       // ���� ���� ���� Ŭ���̾�Ʈ
        private int progress = 0;           // �˻� ���� ���� ���α׷����� ���� ��ġ
        private int pgb_index = 0;          // �˻� ���� ���� ���α׷����� �ʱ�ȭ


        public SearchWnd(MainWnd client)
        {
            InitializeComponent();
            this.client = client;
        }


        /// <summary>
        /// ListView �ʱ�ȭ �޼���
        /// </summary>
        private void Init_ListView()
        {
            try
            {
                if (lstView.InvokeRequired)
                {
                    InvokeInit_ListView d = new InvokeInit_ListView(Init_ListView);
                    this.Invoke(d, new object[] {});
                }
                else
                {
                    lstView.Clear();                         // �ʱ�ȭ 
                    lstView.View = View.Details;             // View�ɼ��� Details�� ����
                    lstView.LabelEdit = false;               // ���� ��� ��Ȱ��ȭ
                    lstView.CheckBoxes = true;               // üũ �ڽ� ��� Ȱ��ȭ
                    lstView.FullRowSelect = true;            // ��ü ���� ��� Ȱ��ȭ 
                    lstView.GridLines = true;                // ������ ����   
                    lstView.Sorting = SortOrder.Ascending;   // �������� ����
                    // ���ϸ� ��� ��� �����
                    lstView.Columns.Add("���ϸ�", 225, HorizontalAlignment.Left);
                    // ���� ũ�� ��� ��� �����
                    lstView.Columns.Add("����ũ��", 80, HorizontalAlignment.Right);
                    // �������� ��� ��� �����
                    lstView.Columns.Add("��������", 120, HorizontalAlignment.Right);
                    // ���� IP ��� ��� �����
                    lstView.Columns.Add("����IP", 90, HorizontalAlignment.Center);
                }
            }
            catch { } //  ��Ƽ ������ ȯ�濡�� ������ ���� ���ܰ� �߻��� ��� ó��

        }

        /// <summary>
        /// ����Ʈ �信 ��� �߰� �޼���
        /// </summary>
        /// <param name="fname">���� �̸�</param>
        /// <param name="fsize">���� ������</param>
        /// <param name="ftime">���� �����ð�</param>
        /// <param name="s_ip">������ �����ϴ� ��ǻ�� IP</param>
        public void Add_ListViwe(string fname, string fsize, string ftime, string s_ip)
        {
            try
            {
                if (lstView.InvokeRequired)
                {
                    InvokeAdd_ListView d = new InvokeAdd_ListView(Add_ListViwe);
                    this.Invoke(d, new object[] { fname, fsize, ftime, s_ip });
                }
                else
                {
                    ListViewItem item = new ListViewItem(fname, 0); // ���� �̸�
                    item.SubItems.Add(fsize);   // ���� ũ��
                    item.SubItems.Add(ftime);   // ���� �����ð�
                    item.SubItems.Add(s_ip);   // ���� ���� ���� ������		
                    lstView.Items.Add(item);    // ListView �� �߰�
                }
            }
            catch { } // ��Ƽ ������ ȯ�濡�� ������ ���� ���ܰ� �߻��� ��� ó��

        }

        /// <summary>
        ///  ������ �÷� ���� �޼���
        /// </summary>
        /// <param name="iColumn">������ �÷�</param>
        public void SortColumn(int iColumn)
        {
            try
            {
                if (lstView.InvokeRequired)
                {
                    InvokeSortColumn d = new InvokeSortColumn(SortColumn);
                    this.Invoke(d, new object[] { iColumn });
                }
                else
                {
                    // �÷� ������ ���� ���� ListViewCompare Ŭ���� ����
                    ListViewComparer lvc = new ListViewComparer();
                    try
                    {
                        string s1 = lstView.Items[1].SubItems[iColumn].Text.ToUpper().Trim();
                        long lng = Convert.ToInt32(s1);
                        lvc.BNUMERIC = true;
                    }
                    catch
                    {
                        lvc.BNUMERIC = false;
                    }
                    lvc.COLUMN = iColumn;
                    lstView.ListViewItemSorter = lvc;
                }
            }
            catch { } // ��Ƽ ������ ȯ�濡�� ������ ���� ���ܰ� �߻��� ��� ó��
        }



        /// <summary>
        ///  �˻� ���� ���� ���α׷����� �ʱ�ȭ
        /// </summary>
        /// <param name="i">���α׷����� �ִ� ũ��</param>
        private void Init_Progress_Bar(int i)
        {
            try
            {
                if (pgb_search.InvokeRequired)
                {
                    InvokeInit_Progress_Bar d = new InvokeInit_Progress_Bar(Init_Progress_Bar);
                    this.Invoke(d, new object[] { i });
                }
                else
                {
                    pgb_search.Value = 0;
                    this.progress = (100 / i);
                }
            }
            catch { } // ��Ƽ ������ ȯ�濡�� ������ ���� ���ܰ� �߻��� ��� ó��
        }

        /// <summary>
        /// �˻� ������� ���α׷����� �޼���
        /// </summary>
        public void Progress_Bar()
        {
            try
            {
                if (pgb_search.InvokeRequired)
                {
                    InvokeProgress_Bar d = new InvokeProgress_Bar(Progress_Bar);
                    this.Invoke(d, new object[] {});
                }
                else
                {
                    pgb_index++;
                    pgb_search.Value = (pgb_index * progress) > 100 ? 0 : (pgb_index * progress);
                }
            }
            catch { } // ��Ƽ ������ ȯ�濡�� ������ ���� ���ܰ� �߻��� ��� ó��
        }

 

   
        /// <summary>
        /// ���� ������ â�� �޽��� �߰� �޼���
        /// </summary>
        /// <param name="str">�߰��� �޽���</param>
        public void Set_Message(string str)
        {
            try
            {
                if (txt_message.InvokeRequired)
                {
                    InvokeSet_Message d = new InvokeSet_Message(Set_Message);
                    this.Invoke(d, new object[] { str });
                }
                else
                {
                    txt_message.Text += "\r\n" + str; // �޽��� �߰�     
                }
            }
            catch { } // ��Ƽ ������ ȯ�濡�� ������ ���� ���ܰ� �߻��� ��� ó��            
        }



        /// <summary>
        ///  �˻�â�� ������ �ʱ�ȭ �۾� �޼���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchWnd_Load(object sender, System.EventArgs e)
        {
            Init_ListView();              // ListView �ֱ�ȭ

            cmb_ext.BeginUpdate();		//���� Ȯ���� ���� �޺��ڽ� ���� ������Ʈ ����
            cmb_ext.Items.Add(".*");    // .* �޺��ڽ��� �߰�
            cmb_ext.Items.Add(".txt");  // .txt �޺��ڽ��� �߰�
            cmb_ext.Items.Add(".avi");  // .avi �޺��ڽ��� �߰�						
            cmb_ext.Items.Add(".mp3");  // .mp3 �޺��ڽ��� �߰�
            cmb_ext.Items.Add(".mpg");  // .mpg �޺��ڽ��� �߰�            
            cmb_ext.Items.Add(".zip");  // .zip �޺��ڽ��� �߰�
            cmb_ext.Items.Add(".jpg");  // .jpg �޺��ڽ��� �߰�
            cmb_ext.Items.Add(".gif");  // .gif �޺��ڽ��� �߰�
            cmb_ext.EndUpdate();        // �޺��ڽ� ���� ������Ʈ �� 

            cmb_ext.SelectedIndex = 0; //���� Ȯ���� ���� �޺��ڽ� 0 ��..����.
        }

  
        /// <summary>
        /// ListView���� ���� Ŭ���ÿ� �߻��ϴ� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstView_DoubleClick(object sender, System.EventArgs e)
        {
            int index = 0; // ���� ����Ŭ���� ��ġ ���� ����

            foreach (ListViewItem item in lstView.SelectedItems)
            {
                index = lstView.Items.IndexOf(item);
            }

            string fname = lstView.Items[index].SubItems[0].Text;// ���� �̸�
            string fsize = lstView.Items[index].SubItems[1].Text;// ���� ������
            string ftime = lstView.Items[index].SubItems[2].Text;// ���� ���� �ð�
            string s_ip = lstView.Items[index].SubItems[3].Text;// ���� ��ġ 

            // ���� �ٿ�ε� Ŭ���� ����
            FileDownWnd fd = new FileDownWnd(this.client.downdirectory);
            // ���� �̸�, ����ũ�� , ���� ���� �ð�, ������ġ
            fd.Set_Info(fname, fsize, ftime, s_ip);
            // ���� �ٿ�ε� ȭ�� ���
            fd.Show();
        }


        /// <summary>
        /// ListView �÷��� Ŭ�� ������ �߻��ϴ� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstView_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            SortColumn(e.Column); // �÷��� ���� 			
        }

        /// <summary>
        /// �˻� ��ư Ŭ���ÿ� �߻��ϴ� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_search_Click(object sender, System.EventArgs e)
        {
            try
            {
                //����Ʈ �� �ʱ�ȭ
                Init_ListView();
                //�˻� ���α׷����� �ʱ�ȭ
                Init_Progress_Bar(client.server_list.Length);

                // �˻� ���ڿ�  
                string[] ext_type = { ".*", ".txt", "*.avi", "*.mp3", "*.mpg", "*.zip", "*.jpg", "*.gif" };

                //S_C_FILE#�˻���û��ǻ��IP#�˻� ���ϸ�			

                string message = "S_C_FILE#" + client.myIP + "#";

                // �˻� ���� Ÿ�� ����
                message += txt_file.Text.Trim() + ext_type[cmb_ext.SelectedIndex];

                // ���� �˻� ������ Ŭ���̾�Ʈ �����ؼ� ���� �õ�
                SearchClient[] s_client = new SearchClient[client.server_list.Length];

                for (int i = 0; i < client.server_list.Length; i++)
                {
                    // Ŭ���̾�Ʈ ������ ���� �˻� ��û..!!
                    s_client[i] = new SearchClient(this);
                    s_client[i].Connect(client.server_list[i], message);
                }
            }
            catch
            {
                MessageBox.Show(" �˻� ���� ! ");
            }
        }

        /// <summary>
        /// ���� ���� ���� �޴� Ŭ���Ҷ� �߻��ϴ� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            // ���� ���� �ٿ�ε� ����â ����
            OptionWnd op = new OptionWnd(this.client);
            // ���� ����â ���̱�
            op.ShowDialog();
        }


        /// <summary>
        /// �˻�â ����ÿ� �߻��ϴ� �޽���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
			e.Cancel=true;               //���ݱ� ���
			this.ShowInTaskbar = false; //�½�ũ�ٿ��� �Ⱥ��̰�..			
			this.Hide();                // ���� â �Ⱥ��̰� �ϱ�		
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstView.CheckedItems)
            {
                int index = lstView.Items.IndexOf(item);

                string fname = lstView.Items[index].SubItems[0].Text; // ���� �̸�
                string fsize = lstView.Items[index].SubItems[1].Text; // ���� ������
                string ftime = lstView.Items[index].SubItems[2].Text; // ���� ���� �ð�
                string s_ip = lstView.Items[index].SubItems[3].Text; // ���� ��ġ

                // ���� �ٿ�ε� Ŭ���� ����
                FileDownWnd fd = new FileDownWnd(this.client.downdirectory);
                // ���� �̸�, ����ũ�� , ���� ������, ������ġ
                fd.Set_Info(fname, fsize, ftime, s_ip);
                // ���� �ٿ�ε� ȭ�� ���
                fd.Show();
            }
        }
    }




    /// <summary>
    /// ���� ó�� Ŭ����
    /// </summary>
    class ListViewComparer : System.Collections.IComparer  // IComparer �������̽� ���
    {
        private int m_Column;       // �÷�  
        private bool m_bNumeric;    // ������ ����

        /// <summary>
        ///  �ΰ� ��ü �� �޼���
        /// </summary>
        /// <param name="Object1">ù��° �񱳴��</param>
        /// <param name="Object2">�ι�° �񱳴��</param>
        /// <returns></returns>
        public int Compare(object Object1, object Object2)
        {
            if (!(Object1 is ListViewItem) && !(Object2 is
                ListViewItem))
                return 0;

            // ListViewItem �������� �� ��ȯ
            ListViewItem lv1 = (ListViewItem)Object1;
            ListViewItem lv2 = (ListViewItem)Object2;

            if (m_bNumeric)
                return (Convert.ToInt32(lv1.SubItems
                    [m_Column].Text) - Convert.ToInt32(lv2.SubItems
                    [m_Column].Text));
            else
                return String.Compare(lv1.SubItems
                    [m_Column].Text, lv2.SubItems[m_Column].Text);
        }

        /// <summary>
        /// bNumeric �Ӽ�
        /// </summary>
        public bool BNUMERIC
        {
            set
            {
                m_bNumeric = value;
            }
        }

        /// <summary>
        ///  Column �Ӽ�
        /// </summary>
        public int COLUMN
        {
            set
            {
                m_Column = value;
            }
        }
    }
}