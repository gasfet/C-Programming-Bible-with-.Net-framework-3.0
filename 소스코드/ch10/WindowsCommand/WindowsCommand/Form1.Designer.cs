namespace WindowsCommand
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_CMD = new System.Windows.Forms.Button();
            this.txt_output = new System.Windows.Forms.TextBox();
            this.m_sql_cmd = new System.Data.SqlClient.SqlCommand();
            this.m_sql_connect = new System.Data.SqlClient.SqlConnection();
            this.txt_SQL = new System.Windows.Forms.TextBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_OLE = new System.Windows.Forms.Button();
            this.btn_SQL = new System.Windows.Forms.Button();
            this.m_ole_connect = new System.Data.OleDb.OleDbConnection();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_ole_cmd = new System.Data.OleDb.OleDbCommand();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_CMD
            // 
            this.btn_CMD.Location = new System.Drawing.Point(32, 240);
            this.btn_CMD.Name = "btn_CMD";
            this.btn_CMD.Size = new System.Drawing.Size(328, 24);
            this.btn_CMD.TabIndex = 1;
            this.btn_CMD.Text = "명령 실행하기";
            this.btn_CMD.Click += new System.EventHandler(this.btn_CMD_Click);
            // 
            // txt_output
            // 
            this.txt_output.Location = new System.Drawing.Point(32, 40);
            this.txt_output.Multiline = true;
            this.txt_output.Name = "txt_output";
            this.txt_output.Size = new System.Drawing.Size(328, 152);
            this.txt_output.TabIndex = 2;
            // 
            // m_sql_cmd
            // 
            this.m_sql_cmd.Connection = this.m_sql_connect;
            // 
            // m_sql_connect
            // 
            this.m_sql_connect.ConnectionString = "Data Source=MAGIC7\\SQLEXPRESS;Initial Catalog=AdventureWorks;User ID=mydb;Passwor" +
                "d=1234";
            this.m_sql_connect.FireInfoMessageEventOnUserErrors = false;
            // 
            // txt_SQL
            // 
            this.txt_SQL.Location = new System.Drawing.Point(32, 200);
            this.txt_SQL.Name = "txt_SQL";
            this.txt_SQL.Size = new System.Drawing.Size(328, 21);
            this.txt_SQL.TabIndex = 0;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(280, 302);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(120, 32);
            this.btn_Close.TabIndex = 8;
            this.btn_Close.Text = "프로그램 종료";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_OLE
            // 
            this.btn_OLE.Location = new System.Drawing.Point(128, 302);
            this.btn_OLE.Name = "btn_OLE";
            this.btn_OLE.Size = new System.Drawing.Size(88, 32);
            this.btn_OLE.TabIndex = 7;
            this.btn_OLE.Text = "OLE DB";
            this.btn_OLE.Click += new System.EventHandler(this.btn_OLE_Click);
            // 
            // btn_SQL
            // 
            this.btn_SQL.Location = new System.Drawing.Point(24, 302);
            this.btn_SQL.Name = "btn_SQL";
            this.btn_SQL.Size = new System.Drawing.Size(88, 32);
            this.btn_SQL.TabIndex = 6;
            this.btn_SQL.Text = "SQL서버";
            this.btn_SQL.Click += new System.EventHandler(this.btn_SQL_Click);
            // 
            // m_ole_connect
            // 
            this.m_ole_connect.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\\C#Bible2006\\소스코드\\ch11\\ado.mdb";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(8, 286);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 56);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "데이터 Connect";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_output);
            this.groupBox1.Controls.Add(this.btn_CMD);
            this.groupBox1.Controls.Add(this.txt_SQL);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 280);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "데이터 Command";
            // 
            // m_ole_cmd
            // 
            this.m_ole_cmd.Connection = this.m_ole_connect;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 349);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_OLE);
            this.Controls.Add(this.btn_SQL);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "데이터베이스 명령 처리하기";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_CMD;
        private System.Windows.Forms.TextBox txt_output;
        private System.Data.SqlClient.SqlCommand m_sql_cmd;
        private System.Data.SqlClient.SqlConnection m_sql_connect;
        private System.Windows.Forms.TextBox txt_SQL;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_OLE;
        private System.Windows.Forms.Button btn_SQL;
        private System.Data.OleDb.OleDbConnection m_ole_connect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Data.OleDb.OleDbCommand m_ole_cmd;

    }
}

