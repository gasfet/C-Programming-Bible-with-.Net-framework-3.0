using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Data.SqlClient;

namespace MemberServer
{
	/// <summary>
	/// Form1�� ���� ��� �����Դϴ�.
	/// </summary>
	public class MainWnd : System.Windows.Forms.Form
	{
		private Server server = null;

		// �߰� �ڵ�		
		public DataSet ds = null;   // �޸� �����ͺ��̽�        		
        
		private SqlDataAdapter adapter = null;	
		private SqlConnection  conn = null;
		private string dsn = null;

		private System.Windows.Forms.TabPage tab_Member_Info;
		private System.Windows.Forms.TabPage tab_Current_Info;
		private System.Windows.Forms.TabPage tab_Debug_Info;
		private System.Windows.Forms.TabPage tab_Server;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TextBox txt_Info;
		private System.Windows.Forms.GroupBox grb_ServerInfo;
		private System.Windows.Forms.Label lbl_ServerDB;
		private System.Windows.Forms.TextBox txt_DBname;
		private System.Windows.Forms.Label lbl_ServerPWD;
		private System.Windows.Forms.TextBox txt_PWD;
		private System.Windows.Forms.Label lbl_ServerID;
		private System.Windows.Forms.TextBox txt_ID;
		private System.Windows.Forms.Label lbl_ServerIP;
		private System.Windows.Forms.TextBox txt_IP;
		private System.Windows.Forms.GroupBox grb_DataManager;
		private System.Windows.Forms.Button btn_DeleteMember;
		private System.Windows.Forms.Button btn_EditMember;
		private System.Windows.Forms.Button btn_InsertMember;
		private System.Windows.Forms.GroupBox grb_DataReadWrite;
		private System.Windows.Forms.Button btn_XMLWriter;
		private System.Windows.Forms.Button btn_XMLReader;
		private System.Windows.Forms.Button btn_SqlWriter;
		private System.Windows.Forms.Button btn_SqlReader;
		private System.Windows.Forms.DataGrid dataGrid_MemberInfo;
		private System.Windows.Forms.DataGrid dataGrid_ConnectInfo;
		private System.Windows.Forms.TextBox txt_SelectMemberInfo;
		private System.Windows.Forms.Button btn_Start;
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainWnd()
		{
			InitializeComponent();

			ds = new DataSet(); // �޸� �����ͺ��̽� �ʱ�ȭ

		}

		/// <summary>
		/// ��� ���� ��� ���ҽ��� �����մϴ�.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tab_Server = new System.Windows.Forms.TabPage();
			this.grb_ServerInfo = new System.Windows.Forms.GroupBox();
			this.lbl_ServerDB = new System.Windows.Forms.Label();
			this.txt_DBname = new System.Windows.Forms.TextBox();
			this.lbl_ServerPWD = new System.Windows.Forms.Label();
			this.txt_PWD = new System.Windows.Forms.TextBox();
			this.lbl_ServerID = new System.Windows.Forms.Label();
			this.txt_ID = new System.Windows.Forms.TextBox();
			this.lbl_ServerIP = new System.Windows.Forms.Label();
			this.txt_IP = new System.Windows.Forms.TextBox();
			this.btn_Start = new System.Windows.Forms.Button();
			this.tab_Member_Info = new System.Windows.Forms.TabPage();
			this.grb_DataManager = new System.Windows.Forms.GroupBox();
			this.btn_DeleteMember = new System.Windows.Forms.Button();
			this.btn_EditMember = new System.Windows.Forms.Button();
			this.btn_InsertMember = new System.Windows.Forms.Button();
			this.grb_DataReadWrite = new System.Windows.Forms.GroupBox();
			this.btn_XMLWriter = new System.Windows.Forms.Button();
			this.btn_XMLReader = new System.Windows.Forms.Button();
			this.btn_SqlWriter = new System.Windows.Forms.Button();
			this.btn_SqlReader = new System.Windows.Forms.Button();
			this.dataGrid_MemberInfo = new System.Windows.Forms.DataGrid();
			this.tab_Current_Info = new System.Windows.Forms.TabPage();
			this.txt_SelectMemberInfo = new System.Windows.Forms.TextBox();
			this.dataGrid_ConnectInfo = new System.Windows.Forms.DataGrid();
			this.tab_Debug_Info = new System.Windows.Forms.TabPage();
			this.txt_Info = new System.Windows.Forms.TextBox();
			this.tabControl.SuspendLayout();
			this.tab_Server.SuspendLayout();
			this.grb_ServerInfo.SuspendLayout();
			this.tab_Member_Info.SuspendLayout();
			this.grb_DataManager.SuspendLayout();
			this.grb_DataReadWrite.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid_MemberInfo)).BeginInit();
			this.tab_Current_Info.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid_ConnectInfo)).BeginInit();
			this.tab_Debug_Info.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tab_Server);
			this.tabControl.Controls.Add(this.tab_Member_Info);
			this.tabControl.Controls.Add(this.tab_Current_Info);
			this.tabControl.Controls.Add(this.tab_Debug_Info);
			this.tabControl.Location = new System.Drawing.Point(8, 8);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(416, 376);
			this.tabControl.TabIndex = 0;
			// 
			// tab_Server
			// 
			this.tab_Server.Controls.Add(this.grb_ServerInfo);
			this.tab_Server.Controls.Add(this.btn_Start);
			this.tab_Server.Location = new System.Drawing.Point(4, 21);
			this.tab_Server.Name = "tab_Server";
			this.tab_Server.Size = new System.Drawing.Size(408, 351);
			this.tab_Server.TabIndex = 3;
			this.tab_Server.Text = "���� ����";
			// 
			// grb_ServerInfo
			// 
			this.grb_ServerInfo.Controls.Add(this.lbl_ServerDB);
			this.grb_ServerInfo.Controls.Add(this.txt_DBname);
			this.grb_ServerInfo.Controls.Add(this.lbl_ServerPWD);
			this.grb_ServerInfo.Controls.Add(this.txt_PWD);
			this.grb_ServerInfo.Controls.Add(this.lbl_ServerID);
			this.grb_ServerInfo.Controls.Add(this.txt_ID);
			this.grb_ServerInfo.Controls.Add(this.lbl_ServerIP);
			this.grb_ServerInfo.Controls.Add(this.txt_IP);
			this.grb_ServerInfo.Location = new System.Drawing.Point(20, 160);
			this.grb_ServerInfo.Name = "grb_ServerInfo";
			this.grb_ServerInfo.Size = new System.Drawing.Size(360, 168);
			this.grb_ServerInfo.TabIndex = 1;
			this.grb_ServerInfo.TabStop = false;
			this.grb_ServerInfo.Text = "ȸ�� ���� ���� ȯ�� ����";
			// 
			// lbl_ServerDB
			// 
			this.lbl_ServerDB.Location = new System.Drawing.Point(8, 128);
			this.lbl_ServerDB.Name = "lbl_ServerDB";
			this.lbl_ServerDB.Size = new System.Drawing.Size(136, 23);
			this.lbl_ServerDB.TabIndex = 7;
			this.lbl_ServerDB.Text = "SQL ���� �����ͺ��̽�";
			// 
			// txt_DBname
			// 
			this.txt_DBname.Location = new System.Drawing.Point(160, 128);
			this.txt_DBname.Name = "txt_DBname";
			this.txt_DBname.Size = new System.Drawing.Size(192, 21);
			this.txt_DBname.TabIndex = 6;
			this.txt_DBname.Text = "Member";
			// 
			// lbl_ServerPWD
			// 
			this.lbl_ServerPWD.Location = new System.Drawing.Point(9, 96);
			this.lbl_ServerPWD.Name = "lbl_ServerPWD";
			this.lbl_ServerPWD.Size = new System.Drawing.Size(120, 23);
			this.lbl_ServerPWD.TabIndex = 5;
			this.lbl_ServerPWD.Text = "SQL ���� ���� ��ȣ";
			// 
			// txt_PWD
			// 
			this.txt_PWD.Location = new System.Drawing.Point(160, 96);
			this.txt_PWD.Name = "txt_PWD";
			this.txt_PWD.PasswordChar = '*';
			this.txt_PWD.Size = new System.Drawing.Size(192, 21);
			this.txt_PWD.TabIndex = 4;
			this.txt_PWD.Text = "magic";
			// 
			// lbl_ServerID
			// 
			this.lbl_ServerID.Location = new System.Drawing.Point(9, 64);
			this.lbl_ServerID.Name = "lbl_ServerID";
			this.lbl_ServerID.TabIndex = 3;
			this.lbl_ServerID.Text = "SQL ���� ���̵�";
			// 
			// txt_ID
			// 
			this.txt_ID.Location = new System.Drawing.Point(160, 64);
			this.txt_ID.Name = "txt_ID";
			this.txt_ID.Size = new System.Drawing.Size(192, 21);
			this.txt_ID.TabIndex = 2;
			this.txt_ID.Text = "sa";
			// 
			// lbl_ServerIP
			// 
			this.lbl_ServerIP.Location = new System.Drawing.Point(9, 32);
			this.lbl_ServerIP.Name = "lbl_ServerIP";
			this.lbl_ServerIP.TabIndex = 1;
			this.lbl_ServerIP.Text = "SQL ���� ������";
			// 
			// txt_IP
			// 
			this.txt_IP.Location = new System.Drawing.Point(160, 32);
			this.txt_IP.Name = "txt_IP";
			this.txt_IP.Size = new System.Drawing.Size(192, 21);
			this.txt_IP.TabIndex = 0;
			this.txt_IP.Text = "localhost";
			// 
			// btn_Start
			// 
			this.btn_Start.Location = new System.Drawing.Point(16, 16);
			this.btn_Start.Name = "btn_Start";
			this.btn_Start.Size = new System.Drawing.Size(376, 120);
			this.btn_Start.TabIndex = 0;
			this.btn_Start.Text = "���� ����";
			this.btn_Start.Click += new System.EventHandler(this.btn_Server_Click);
			// 
			// tab_Member_Info
			// 
			this.tab_Member_Info.Controls.Add(this.grb_DataManager);
			this.tab_Member_Info.Controls.Add(this.grb_DataReadWrite);
			this.tab_Member_Info.Controls.Add(this.dataGrid_MemberInfo);
			this.tab_Member_Info.Location = new System.Drawing.Point(4, 21);
			this.tab_Member_Info.Name = "tab_Member_Info";
			this.tab_Member_Info.Size = new System.Drawing.Size(408, 351);
			this.tab_Member_Info.TabIndex = 0;
			this.tab_Member_Info.Text = "ȸ�� ��������";
			// 
			// grb_DataManager
			// 
			this.grb_DataManager.Controls.Add(this.btn_DeleteMember);
			this.grb_DataManager.Controls.Add(this.btn_EditMember);
			this.grb_DataManager.Controls.Add(this.btn_InsertMember);
			this.grb_DataManager.Location = new System.Drawing.Point(184, 192);
			this.grb_DataManager.Name = "grb_DataManager";
			this.grb_DataManager.Size = new System.Drawing.Size(216, 152);
			this.grb_DataManager.TabIndex = 2;
			this.grb_DataManager.TabStop = false;
			this.grb_DataManager.Text = "������ �����ϱ�";
			// 
			// btn_DeleteMember
			// 
			this.btn_DeleteMember.Location = new System.Drawing.Point(16, 112);
			this.btn_DeleteMember.Name = "btn_DeleteMember";
			this.btn_DeleteMember.Size = new System.Drawing.Size(184, 32);
			this.btn_DeleteMember.TabIndex = 2;
			this.btn_DeleteMember.Text = "������ ȸ�� ���� �����ϱ�";
			this.btn_DeleteMember.Click += new System.EventHandler(this.btn_DeleteMember_Click);
			// 
			// btn_EditMember
			// 
			this.btn_EditMember.Location = new System.Drawing.Point(16, 69);
			this.btn_EditMember.Name = "btn_EditMember";
			this.btn_EditMember.Size = new System.Drawing.Size(184, 32);
			this.btn_EditMember.TabIndex = 1;
			this.btn_EditMember.Text = "������ ȸ�� ���� �����ϱ�";
			this.btn_EditMember.Click += new System.EventHandler(this.btn_EditMember_Click);
			// 
			// btn_InsertMember
			// 
			this.btn_InsertMember.Location = new System.Drawing.Point(16, 24);
			this.btn_InsertMember.Name = "btn_InsertMember";
			this.btn_InsertMember.Size = new System.Drawing.Size(184, 32);
			this.btn_InsertMember.TabIndex = 0;
			this.btn_InsertMember.Text = "�ű� ȸ�� ���� �Է��ϱ�";
			this.btn_InsertMember.Click += new System.EventHandler(this.btn_InsertMember_Click);
			// 
			// grb_DataReadWrite
			// 
			this.grb_DataReadWrite.Controls.Add(this.btn_XMLWriter);
			this.grb_DataReadWrite.Controls.Add(this.btn_XMLReader);
			this.grb_DataReadWrite.Controls.Add(this.btn_SqlWriter);
			this.grb_DataReadWrite.Controls.Add(this.btn_SqlReader);
			this.grb_DataReadWrite.Location = new System.Drawing.Point(8, 192);
			this.grb_DataReadWrite.Name = "grb_DataReadWrite";
			this.grb_DataReadWrite.Size = new System.Drawing.Size(168, 152);
			this.grb_DataReadWrite.TabIndex = 1;
			this.grb_DataReadWrite.TabStop = false;
			this.grb_DataReadWrite.Text = "������ �б�/����";
			// 
			// btn_XMLWriter
			// 
			this.btn_XMLWriter.Location = new System.Drawing.Point(16, 120);
			this.btn_XMLWriter.Name = "btn_XMLWriter";
			this.btn_XMLWriter.Size = new System.Drawing.Size(136, 23);
			this.btn_XMLWriter.TabIndex = 3;
			this.btn_XMLWriter.Text = "XML�� ���� �����ϱ�";
			this.btn_XMLWriter.Click += new System.EventHandler(this.btn_XMLWriter_Click);
			// 
			// btn_XMLReader
			// 
			this.btn_XMLReader.Location = new System.Drawing.Point(16, 88);
			this.btn_XMLReader.Name = "btn_XMLReader";
			this.btn_XMLReader.Size = new System.Drawing.Size(136, 23);
			this.btn_XMLReader.TabIndex = 2;
			this.btn_XMLReader.Text = "XML ���� �о����";
			this.btn_XMLReader.Click += new System.EventHandler(this.btn_XMLReader_Click);
			// 
			// btn_SqlWriter
			// 
			this.btn_SqlWriter.Location = new System.Drawing.Point(16, 56);
			this.btn_SqlWriter.Name = "btn_SqlWriter";
			this.btn_SqlWriter.Size = new System.Drawing.Size(136, 23);
			this.btn_SqlWriter.TabIndex = 1;
			this.btn_SqlWriter.Text = "SQL�� ���� �����ϱ�";
			this.btn_SqlWriter.Click += new System.EventHandler(this.btn_SqlWriter_Click);
			// 
			// btn_SqlReader
			// 
			this.btn_SqlReader.Location = new System.Drawing.Point(16, 24);
			this.btn_SqlReader.Name = "btn_SqlReader";
			this.btn_SqlReader.Size = new System.Drawing.Size(136, 23);
			this.btn_SqlReader.TabIndex = 0;
			this.btn_SqlReader.Text = "SQL ���� �о����";
			this.btn_SqlReader.Click += new System.EventHandler(this.btn_SqlReader_Click);
			// 
			// dataGrid_MemberInfo
			// 
			this.dataGrid_MemberInfo.DataMember = "";
			this.dataGrid_MemberInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid_MemberInfo.Location = new System.Drawing.Point(8, 8);
			this.dataGrid_MemberInfo.Name = "dataGrid_MemberInfo";
			this.dataGrid_MemberInfo.Size = new System.Drawing.Size(392, 176);
			this.dataGrid_MemberInfo.TabIndex = 0;
			this.dataGrid_MemberInfo.DoubleClick += new System.EventHandler(this.dataGrid_MemberInfo_DoubleClick);
			// 
			// tab_Current_Info
			// 
			this.tab_Current_Info.Controls.Add(this.txt_SelectMemberInfo);
			this.tab_Current_Info.Controls.Add(this.dataGrid_ConnectInfo);
			this.tab_Current_Info.Location = new System.Drawing.Point(4, 21);
			this.tab_Current_Info.Name = "tab_Current_Info";
			this.tab_Current_Info.Size = new System.Drawing.Size(408, 351);
			this.tab_Current_Info.TabIndex = 1;
			this.tab_Current_Info.Text = "���� ������ ȸ��";
			// 
			// txt_SelectMemberInfo
			// 
			this.txt_SelectMemberInfo.Location = new System.Drawing.Point(8, 232);
			this.txt_SelectMemberInfo.Multiline = true;
			this.txt_SelectMemberInfo.Name = "txt_SelectMemberInfo";
			this.txt_SelectMemberInfo.ReadOnly = true;
			this.txt_SelectMemberInfo.Size = new System.Drawing.Size(392, 104);
			this.txt_SelectMemberInfo.TabIndex = 2;
			this.txt_SelectMemberInfo.Text = "����ȸ�� �� ����";
			// 
			// dataGrid_ConnectInfo
			// 
			this.dataGrid_ConnectInfo.DataMember = "";
			this.dataGrid_ConnectInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid_ConnectInfo.Location = new System.Drawing.Point(8, 8);
			this.dataGrid_ConnectInfo.Name = "dataGrid_ConnectInfo";
			this.dataGrid_ConnectInfo.Size = new System.Drawing.Size(392, 208);
			this.dataGrid_ConnectInfo.TabIndex = 0;
			this.dataGrid_ConnectInfo.Click += new System.EventHandler(this.dataGrid_ConnectInfo_Click);
			// 
			// tab_Debug_Info
			// 
			this.tab_Debug_Info.Controls.Add(this.txt_Info);
			this.tab_Debug_Info.Location = new System.Drawing.Point(4, 21);
			this.tab_Debug_Info.Name = "tab_Debug_Info";
			this.tab_Debug_Info.Size = new System.Drawing.Size(408, 351);
			this.tab_Debug_Info.TabIndex = 2;
			this.tab_Debug_Info.Text = "����� ����";
			// 
			// txt_Info
			// 
			this.txt_Info.Location = new System.Drawing.Point(8, 16);
			this.txt_Info.Multiline = true;
			this.txt_Info.Name = "txt_Info";
			this.txt_Info.ReadOnly = true;
			this.txt_Info.Size = new System.Drawing.Size(392, 320);
			this.txt_Info.TabIndex = 0;
			this.txt_Info.Text = "";
			// 
			// MainWnd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(432, 389);
			this.Controls.Add(this.tabControl);
			this.Name = "MainWnd";
			this.Text = "ȸ������ ����";
			this.Closed += new System.EventHandler(this.MainWnd_Closed);
			this.tabControl.ResumeLayout(false);
			this.tab_Server.ResumeLayout(false);
			this.grb_ServerInfo.ResumeLayout(false);
			this.tab_Member_Info.ResumeLayout(false);
			this.grb_DataManager.ResumeLayout(false);
			this.grb_DataReadWrite.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid_MemberInfo)).EndInit();
			this.tab_Current_Info.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid_ConnectInfo)).EndInit();
			this.tab_Debug_Info.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �ش� ���� ���α׷��� �� �������Դϴ�.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainWnd());
		}

		/// <summary>
		/// �����â�� �޽��� ���
		/// </summary>
		/// <param name="msg">����� �޽���</param>		
		public void Add_MSG(string msg)
		{
			this.txt_Info.AppendText(msg+"\r\n");
			this.txt_Info.ScrollToCaret();	
		}


		/// <summary>
		/// SQL �����ͺ��̽� ����
		/// </summary>
		private void OpenSqlConnection()
		{
			try
			{
				dsn = "server=" + txt_IP.Text;
				dsn += ";uid=" + txt_ID.Text;
				dsn += ";pwd=" + txt_PWD.Text;
				dsn += ";database=" + txt_DBname.Text + ";";

				this.conn = new SqlConnection(dsn);	
		
				this.adapter = new SqlDataAdapter();	
		
				string insert_sql = "Insert Into Member values(@id, @pwd, @name, @nickname, @ssn, @tel, @email, @zipcode, @address, @intro)";
				string update_sql = "update Member set pwd=@pwd, nickname=@nickname, tel=@tel, email=@email, zipcode=@zipcode, address=@address, intro=@intro where id=@id";
				string delete_sql = "delete from Member where id=@id";

				// InsertCommand ������Ƽ
				this.adapter.InsertCommand = new SqlCommand(insert_sql, conn);
				this.adapter.InsertCommand.Parameters.Add("@id", SqlDbType.VarChar, 30, "id");
				this.adapter.InsertCommand.Parameters.Add("@pwd", SqlDbType.VarChar, 30, "pwd");
				this.adapter.InsertCommand.Parameters.Add("@name", SqlDbType.VarChar, 50, "name"); 
				this.adapter.InsertCommand.Parameters.Add("@nickname", SqlDbType.VarChar, 50, "nickname");
				this.adapter.InsertCommand.Parameters.Add("@ssn", SqlDbType.Char, 14, "ssn");
				this.adapter.InsertCommand.Parameters.Add("@tel", SqlDbType.Char, 15, "tel");
				this.adapter.InsertCommand.Parameters.Add("@email", SqlDbType.VarChar, 50, "email");
				this.adapter.InsertCommand.Parameters.Add("@zipcode", SqlDbType.Char, 7, "zipcode");
				this.adapter.InsertCommand.Parameters.Add("@address", SqlDbType.VarChar, 100, "address");
				this.adapter.InsertCommand.Parameters.Add("@intro", SqlDbType.Text, 0, "intro");

				// UpdateCommand ������Ƽ
				this.adapter.UpdateCommand = new SqlCommand(update_sql, conn);
				this.adapter.UpdateCommand.Parameters.Add("@pwd", SqlDbType.VarChar, 30, "pwd");
				this.adapter.UpdateCommand.Parameters.Add("@nickname", SqlDbType.VarChar, 50, "nickname");
				this.adapter.UpdateCommand.Parameters.Add("@tel", SqlDbType.Char, 15, "tel");
				this.adapter.UpdateCommand.Parameters.Add("@email", SqlDbType.VarChar, 50, "email");
				this.adapter.UpdateCommand.Parameters.Add("@zipcode", SqlDbType.Char, 7, "zipcode");
				this.adapter.UpdateCommand.Parameters.Add("@address", SqlDbType.VarChar, 100, "address");
				this.adapter.UpdateCommand.Parameters.Add("@intro", SqlDbType.Text, 0, "intro");
				SqlParameter param_update = adapter.UpdateCommand.Parameters.Add("@id", SqlDbType.VarChar, 30, "id");
				param_update.SourceVersion = DataRowVersion.Original;					

				// Delete ������Ƽ
				this.adapter.DeleteCommand = new SqlCommand(delete_sql, conn);
				SqlParameter param_delete = adapter.DeleteCommand.Parameters.Add("@id", SqlDbType.VarChar, 30, "id");
				param_delete.SourceVersion = DataRowVersion.Original;

			}
			catch(Exception ex)
			{
				this.Add_MSG(ex.Message);
			}
		}

		/// <summary>
		/// SQL �����ͺ��̽� ���� ����
		/// </summary>
		private void CloseSqlConnection()
		{
			try
			{			
				this.conn.Close();
			}
			catch(Exception ex)
			{
				this.Add_MSG(ex.Message);
			}
		}

		/// <summary>
		/// SQL �������� �� ��������
		/// </summary>
		private void GetSqlData()
		{	
			try
			{
				string sql1 = "select * from member";
				string sql2 = "select * from connect";
			
				this.adapter.SelectCommand = new SqlCommand(sql1, conn);
				this.adapter.Fill(ds, "Member");

				this.adapter.SelectCommand = new SqlCommand(sql2, conn);
				this.adapter.Fill(ds, "Connect");

				this.dataGrid_MemberInfo.DataSource = ds.Tables["Member"];
				this.dataGrid_ConnectInfo.DataSource = ds.Tables["Connect"];			
			}
			catch(Exception ex)
			{
				this.Add_MSG(ex.Message);
			}
		}

		/// <summary>
		/// SQL ���� ������ ������Ʈ(�޸𸮵����ͺ��̽� -> SQL ����)
		/// </summary>
		private void SetSqlData()
		{
			try
			{	
				this.adapter.Update(ds, "Member");
				this.adapter.Update(ds, "Connect");
				
				this.Add_MSG("�޸� �����͸� SQL������ ������Ʈ��");
			}
			catch(Exception ex)
			{
				this.Add_MSG(ex.Message);
			}
		}


		/// <summary>
		/// ȸ�� ���̵�� ��й�ȣ üũ
		/// </summary>
		/// <param name="user_id"></param>
		/// <param name="user_pwd"></param>
		/// <returns></returns>
		public bool MemberCheck(string user_id, string user_pwd)
		{
			DataRow [] row = ds.Tables["Member"].Select("id='" + user_id + "'");
		   
			if((row.Length > 0) && (row[0]["pwd"].ToString() == user_pwd ))
			{
				return true;
			}
			else
			{
				return false;
			}

		}


		/// <summary>
		/// ȸ�� �߰��ϱ�
		/// </summary>
		/// <param name="data"></param>
		public bool InsertMember(string data)
		{
			try
			{			
				string [] token = data.Split('#');

				DataRow row = ds.Tables["Member"].NewRow();
          
				row["id"] = token[0];
				row["pwd"] = token[1];
				row["name"] = token[2];
				row["nickname"] = token[3];
				row["ssn"] = token[4];
				row["tel"] = token[5];
				row["email"] = token[6];
				row["address"] = token[7];
				row["intro"] = token[8];

				ds.Tables["Member"].Rows.Add(row);

				this.dataGrid_MemberInfo.SetDataBinding(ds, "Member");
				return true;
			}
			catch
			{
				return false;
			}
		}
		
		/// <summary>
		/// ���̵� ��� ���� ��ȸ
		/// </summary>
		/// <param name="user_id">��ȸ�� ���̵�</param>
		/// <returns>���̵� ��� ����</returns>
		public bool SearchID(string user_id)
		{
			DataRow [] row = ds.Tables["Member"].Select("id='" + user_id + "'");
			if( row.Length > 0) // ���̵� �̹� ����
				return true;
			else                // ���̵� ���� 
				return false;
		}


		/// <summary>
		/// �����ȣ ������ �ҷ�����
		/// </summary>
		public string ZicodeLoad(string addr)
		{
			string return_value = null; // �����ȣ#�ּ�@�����ȣ#�ּ�...
			try
			{			
				string sql = "select * from zipcode where addr3 like '%" + addr + "%'";

				SqlCommand cmd = new SqlCommand(sql, this.conn);
				cmd.CommandType = CommandType.Text;
				this.conn.Open();
                														   
				SqlDataReader reader = cmd.ExecuteReader();

				while( reader.Read() )
				{
					return_value += reader["zipcode"].ToString() + "#" ;
					return_value += reader["addr1"].ToString() + " " + reader["addr2"].ToString() + " ";
					return_value += reader["addr3"].ToString() + " ";
					if(reader["no_start"].ToString() != " ")
						return_value += reader["no_start"].ToString() + "~" + reader["no_end"].ToString() + " ";
					if(reader["addr4"].ToString() != " ")
						return_value += reader["addr4"].ToString();
					return_value += "#";
				}
				
				this.conn.Close();

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return return_value;
		}

		/// <summary>
		/// ��� �α��ν� ���� �α�â ���� ����
		/// </summary>		
		public void ConnectMember(string userid, string ip)
		{
            DataRow row = ds.Tables["Connect"].NewRow();

			row["id"] = userid.Trim();
			row["ip"] = ip.Trim();
			row["state"] = '1'; // �α��� ��
			row["entertime"] = DateTime.Now.ToString();

			ds.Tables["Connect"].Rows.Add(row);

			//this.dataGrid_ConnectInfo.SetDataBinding(ds, "Connect");
		}
	

		/// <summary>
		/// ���� ���� ��ư ó��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_Server_Click(object sender, System.EventArgs e)
		{			
			if( btn_Start.Text == "���� ����")
			{
				server =  new Server(this, 7007);// ��Ʈ ��ȣ 7007�� ���
				server.ServerStart();            // ���� ä�� ���� ����                
				
				this.Add_MSG("���� ���۵Ǿ���");
				btn_Start.BackColor = Color.Red;
				btn_Start.Text = "���� ����";

				this.OpenSqlConnection();  // DB �����ϱ�
				this.GetSqlData();         // DB ���� ������� 

			}
			else
			{
				server.ServerStop();             // ���� ä�� ���� ����
				btn_Start.Text = "���� ����";
				btn_Start.BackColor = this.BackColor;
			}
		}

		/// <summary>
		/// ���� ���α׷� ���� �̺�Ʈ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainWnd_Closed(object sender, System.EventArgs e)
		{
			if( this.conn.State == ConnectionState.Connecting) // DB����Ǿ����� �ݾƶ�.
			{
				this.CloseSqlConnection();
			}
			if( btn_Start.Text == "���� ����" )
			{
				server.ServerStop();
			}
		}

		private void btn_InsertMember_Click(object sender, System.EventArgs e)
		{
			InsertMember dlg = new InsertMember(this.ds);
			dlg.ShowDialog();
			this.dataGrid_MemberInfo.SetDataBinding(ds, "Member");
		}

		private void btn_EditMember_Click(object sender, System.EventArgs e)
		{
			int index = this.dataGrid_MemberInfo.CurrentRowIndex;  // ���� �׸��忡�� ������ �ּ� ��ġ
            
			EditMember dlg = new EditMember(this.ds, index);
			dlg.ShowDialog();
			this.dataGrid_MemberInfo.SetDataBinding(ds, "Member");
		}

		private void btn_SqlReader_Click(object sender, System.EventArgs e)
		{
			this.ds = new DataSet();
			this.GetSqlData();  // SQL �������� ������ �ҷ�����
		}

		private void btn_SqlWriter_Click(object sender, System.EventArgs e)
		{   
			try
			{			
				this.adapter.Update(ds, "Member");
			}
			catch(Exception ex)
			{
				this.Add_MSG(ex.Message);
			}
		}

		private void btn_XMLWriter_Click(object sender, System.EventArgs e)
		{
			ds.WriteXml("Messanger.xml");
		}

		private void btn_XMLReader_Click(object sender, System.EventArgs e)
		{
			ds = new DataSet();
			ds.ReadXml("Messanger.xml");
			this.dataGrid_MemberInfo.SetDataBinding(ds, "Member");
			
		}

		private void dataGrid_MemberInfo_DoubleClick(object sender, System.EventArgs e)
		{
			int index = this.dataGrid_MemberInfo.CurrentRowIndex;  // ���� �׸��忡�� ������ �ּ� ��ġ
            
			EditMember dlg = new EditMember(this.ds, index);
			dlg.ShowDialog();
			this.dataGrid_MemberInfo.SetDataBinding(ds, "Member");
		}

		private void btn_DeleteMember_Click(object sender, System.EventArgs e)
		{
			try
			{			
				int index = this.dataGrid_MemberInfo.CurrentRowIndex;  // ���� �׸��忡�� ������ �ּ� ��ġ
            
				DataRow row = ds.Tables["Member"].Rows[index];

				string str = row["id"].ToString() + " �� ���� �Ͻðڽ��ϱ�?";

				if(MessageBox.Show(str, "���� Ȯ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					row.Delete();
					this.dataGrid_MemberInfo.SetDataBinding(ds, "Member");
				}	
				
			}
			catch(Exception ex)
			{
				this.Add_MSG(ex.Message);
			}
		}

		private void dataGrid_ConnectInfo_Click(object sender, System.EventArgs e)
		{
			int index = this.dataGrid_ConnectInfo.CurrentRowIndex;  // ���� �׸��忡�� ������ �ּ� ��ġ
            
			DataRow row1 = ds.Tables["Connect"].Rows[index];
            
			DataRow [] row2 = ds.Tables["Member"].Select("id='" + row1["id"].ToString() + "'");
			
			string info = row2[0]["id"].ToString() + "���� ������ \r\n";
			info += " �̸� :" + row2[0]["name"].ToString() + " ��Ī :" + row2[0]["nickname"].ToString() ;
			info += "\r\n ��ȭ��ȣ :" + row2[0]["tel"].ToString() + " �����ּ� :" + row2[0]["email"].ToString();
			info += "\r\n �����ȣ :" + row2[0]["zipcode"].ToString() + " �ּ� :" + row2[0]["address"].ToString();
			info += "\r\n �ڱ�Ұ� :" + row2[0]["intro"].ToString();
         
			this.txt_SelectMemberInfo.Text = info;			
		}

		private void btn_ConnectHistorySave_Click(object sender, System.EventArgs e)
		{
			string filename = DateTime.Now.ToShortDateString().ToString() + ".xml";
			ds.WriteXml(filename);
		}

		

		
		

		

		
	}
}
