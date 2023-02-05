using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MemberReg
{
	/// <summary>
	/// ZipcodeWnd�� ���� ��� �����Դϴ�.
	/// </summary>
	public class ZipcodeWnd : System.Windows.Forms.Form
	{
		private string addr = null;      // �ּ� ���� ����
		private string server_ip = null; // ���� ������
		private RegNetwork net = null; 

		private System.Windows.Forms.Label lbl_Search;
		private System.Windows.Forms.TextBox txt_Search;
		private System.Windows.Forms.Button btn_Search;
		private System.Windows.Forms.ListView lst_View;
		private System.Windows.Forms.Button btn_Select;
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ZipcodeWnd(RegNetwork net, string server_ip)
		{
			InitializeComponent();

			this.net = net; 
			this.server_ip = server_ip;
			this.Init_listView();
		}

		/// <summary>
		/// ��� ���� ��� ���ҽ��� �����մϴ�.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form �����̳ʿ��� ������ �ڵ�
		/// <summary>
		/// �����̳� ������ �ʿ��� �޼����Դϴ�.
		/// �� �޼����� ������ �ڵ� ������� �������� ���ʽÿ�.
		/// </summary>
		private void InitializeComponent()
		{
			this.lbl_Search = new System.Windows.Forms.Label();
			this.txt_Search = new System.Windows.Forms.TextBox();
			this.btn_Search = new System.Windows.Forms.Button();
			this.lst_View = new System.Windows.Forms.ListView();
			this.btn_Select = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbl_Search
			// 
			this.lbl_Search.Location = new System.Drawing.Point(16, 185);
			this.lbl_Search.Name = "lbl_Search";
			this.lbl_Search.Size = new System.Drawing.Size(144, 16);
			this.lbl_Search.TabIndex = 15;
			this.lbl_Search.Text = "�˻��� �ּ�(��: �ϻ絿) :";
			// 
			// txt_Search
			// 
			this.txt_Search.Location = new System.Drawing.Point(160, 184);
			this.txt_Search.Name = "txt_Search";
			this.txt_Search.Size = new System.Drawing.Size(136, 21);
			this.txt_Search.TabIndex = 0;
			this.txt_Search.Text = "";
			this.txt_Search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Search_KeyDown);
			// 
			// btn_Search
			// 
			this.btn_Search.Location = new System.Drawing.Point(304, 184);
			this.btn_Search.Name = "btn_Search";
			this.btn_Search.Size = new System.Drawing.Size(80, 24);
			this.btn_Search.TabIndex = 1;
			this.btn_Search.Text = "�ּ� �˻�";
			this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
			// 
			// lst_View
			// 
			this.lst_View.Location = new System.Drawing.Point(16, 8);
			this.lst_View.Name = "lst_View";
			this.lst_View.Size = new System.Drawing.Size(464, 160);
			this.lst_View.TabIndex = 2;
			// 
			// btn_Select
			// 
			this.btn_Select.Location = new System.Drawing.Point(392, 184);
			this.btn_Select.Name = "btn_Select";
			this.btn_Select.Size = new System.Drawing.Size(88, 23);
			this.btn_Select.TabIndex = 3;
			this.btn_Select.Text = "�ּ� ����";
			this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
			// 
			// ZipcodeWnd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(496, 221);
			this.Controls.Add(this.btn_Select);
			this.Controls.Add(this.lst_View);
			this.Controls.Add(this.lbl_Search);
			this.Controls.Add(this.txt_Search);
			this.Controls.Add(this.btn_Search);
			this.Name = "ZipcodeWnd";
			this.Text = "�����ȣ �˻�â";
			this.ResumeLayout(false);

		}
		#endregion

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

           string [] token = data.Split('#'); // ¦����° �����ȣ, Ȧ����° �ּ�
          
			for(int i = 0 ; i < token.Length - 1 ; i += 2)
			{
				this.Add_listView(token[i], token[i+1]);
			}
		}

		private void btn_Search_Click(object sender, System.EventArgs e)
		{
			if(txt_Search.Text.Length == 0) 
			{
				MessageBox.Show("�˻��� �ּҸ� �Է��ϼ���", "���� �޽���");
				return;
			}

			string msg = "CTOS_MESSAGE_REGISTER_ZIPCODE\a" + txt_Search.Text.Trim();
			
			this.net.Connect(this.server_ip);
			this.net.Send(msg);
		}

		

		private void btn_Select_Click(object sender, System.EventArgs e)
		{
            int count = 0;
			foreach(ListViewItem item in lst_View.Items)
			{
				if(item.Checked)
				{
					int index = lst_View.Items.IndexOf(item);
					this.addr += lst_View.Items[index].SubItems[0].Text.Trim() + "#";
					this.addr += lst_View.Items[index].SubItems[1].Text.Trim() + "#";			       
					count++;
				}				
			}

			if(count > 1 )
			{
				MessageBox.Show("�����ȣ�� �ϳ��� �����ؾ� �մϴ�.!");
				return ;
			}
			if( count == 0 )
			{
				MessageBox.Show("�����ȣ�� �����ϼ���.!");
				return ;
			}

			this.Close();
		}

		private void txt_Search_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			// ����Ű�� ������ ���ڿ� �޽��� ����
			if( e.KeyCode == Keys.Enter )
			{
				if(txt_Search.Text.Length == 0) 
				{
					MessageBox.Show("�˻��� �ּҸ� �Է��ϼ���", "���� �޽���");
					return;
				}

				string msg = "CTOS_MESSAGE_REGISTER_ZIPCODE\a" + txt_Search.Text.Trim();
			
				this.net.Connect(this.server_ip);
				this.net.Send(msg);
			}
		}
		
	}
}
