namespace WinDataSet
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
            this.DG_CART = new System.Windows.Forms.DataGrid();
            this.DG_GRAPHIC = new System.Windows.Forms.DataGrid();
            this.btn_CartXMLRead = new System.Windows.Forms.Button();
            this.btn_CartXMLSave = new System.Windows.Forms.Button();
            this.btn_Cart = new System.Windows.Forms.Button();
            this.btn_ReadXML = new System.Windows.Forms.Button();
            this.btn_SaveXML = new System.Windows.Forms.Button();
            this.DG_HARD = new System.Windows.Forms.DataGrid();
            this.DG_CPU = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.DG_CART)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG_GRAPHIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG_HARD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG_CPU)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_CART
            // 
            this.DG_CART.CaptionText = "장바구니 (비어있음!)";
            this.DG_CART.DataMember = "";
            this.DG_CART.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DG_CART.Location = new System.Drawing.Point(300, 159);
            this.DG_CART.Name = "DG_CART";
            this.DG_CART.Size = new System.Drawing.Size(240, 208);
            this.DG_CART.TabIndex = 17;
            // 
            // DG_GRAPHIC
            // 
            this.DG_GRAPHIC.CaptionText = "그래픽 카드 선택";
            this.DG_GRAPHIC.DataMember = "";
            this.DG_GRAPHIC.Enabled = false;
            this.DG_GRAPHIC.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DG_GRAPHIC.Location = new System.Drawing.Point(12, 135);
            this.DG_GRAPHIC.Name = "DG_GRAPHIC";
            this.DG_GRAPHIC.Size = new System.Drawing.Size(280, 112);
            this.DG_GRAPHIC.TabIndex = 16;
            this.DG_GRAPHIC.DoubleClick += new System.EventHandler(this.DG_GRAPHIC_DoubleClick);
            // 
            // btn_CartXMLRead
            // 
            this.btn_CartXMLRead.Enabled = false;
            this.btn_CartXMLRead.Location = new System.Drawing.Point(300, 119);
            this.btn_CartXMLRead.Name = "btn_CartXMLRead";
            this.btn_CartXMLRead.Size = new System.Drawing.Size(120, 24);
            this.btn_CartXMLRead.TabIndex = 15;
            this.btn_CartXMLRead.Text = "장바구니 XML읽기";
            this.btn_CartXMLRead.Click += new System.EventHandler(this.btn_CartXMLRead_Click);
            // 
            // btn_CartXMLSave
            // 
            this.btn_CartXMLSave.Enabled = false;
            this.btn_CartXMLSave.Location = new System.Drawing.Point(420, 119);
            this.btn_CartXMLSave.Name = "btn_CartXMLSave";
            this.btn_CartXMLSave.Size = new System.Drawing.Size(120, 24);
            this.btn_CartXMLSave.TabIndex = 14;
            this.btn_CartXMLSave.Text = "장바구니XML 저장";
            this.btn_CartXMLSave.Click += new System.EventHandler(this.btn_CartXMLSave_Click);
            // 
            // btn_Cart
            // 
            this.btn_Cart.Location = new System.Drawing.Point(300, 23);
            this.btn_Cart.Name = "btn_Cart";
            this.btn_Cart.Size = new System.Drawing.Size(144, 88);
            this.btn_Cart.TabIndex = 13;
            this.btn_Cart.Text = "장바구니 테이블 만들기";
            this.btn_Cart.Click += new System.EventHandler(this.btn_Cart_Click);
            // 
            // btn_ReadXML
            // 
            this.btn_ReadXML.Location = new System.Drawing.Point(452, 21);
            this.btn_ReadXML.Name = "btn_ReadXML";
            this.btn_ReadXML.Size = new System.Drawing.Size(88, 40);
            this.btn_ReadXML.TabIndex = 12;
            this.btn_ReadXML.Text = "XML읽어오기";
            this.btn_ReadXML.Click += new System.EventHandler(this.btn_ReadXML_Click);
            // 
            // btn_SaveXML
            // 
            this.btn_SaveXML.Location = new System.Drawing.Point(452, 69);
            this.btn_SaveXML.Name = "btn_SaveXML";
            this.btn_SaveXML.Size = new System.Drawing.Size(88, 40);
            this.btn_SaveXML.TabIndex = 11;
            this.btn_SaveXML.Text = "XML만들기";
            this.btn_SaveXML.Click += new System.EventHandler(this.btn_SaveXML_Click);
            // 
            // DG_HARD
            // 
            this.DG_HARD.CaptionText = "하드 디스크 선택";
            this.DG_HARD.DataMember = "";
            this.DG_HARD.Enabled = false;
            this.DG_HARD.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DG_HARD.Location = new System.Drawing.Point(12, 255);
            this.DG_HARD.Name = "DG_HARD";
            this.DG_HARD.Size = new System.Drawing.Size(280, 112);
            this.DG_HARD.TabIndex = 10;
            this.DG_HARD.DoubleClick += new System.EventHandler(this.DG_HARD_DoubleClick);
            // 
            // DG_CPU
            // 
            this.DG_CPU.CaptionText = "CPU 선택";
            this.DG_CPU.DataMember = "";
            this.DG_CPU.Enabled = false;
            this.DG_CPU.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DG_CPU.Location = new System.Drawing.Point(12, 15);
            this.DG_CPU.Name = "DG_CPU";
            this.DG_CPU.Size = new System.Drawing.Size(280, 112);
            this.DG_CPU.TabIndex = 9;
            this.DG_CPU.DoubleClick += new System.EventHandler(this.DG_CPU_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 382);
            this.Controls.Add(this.DG_CART);
            this.Controls.Add(this.DG_GRAPHIC);
            this.Controls.Add(this.btn_CartXMLRead);
            this.Controls.Add(this.btn_CartXMLSave);
            this.Controls.Add(this.btn_Cart);
            this.Controls.Add(this.btn_ReadXML);
            this.Controls.Add(this.btn_SaveXML);
            this.Controls.Add(this.DG_HARD);
            this.Controls.Add(this.DG_CPU);
            this.Name = "Form1";
            this.Text = "DataSet 클래스 예제";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG_CART)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG_GRAPHIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG_HARD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG_CPU)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid DG_CART;
        private System.Windows.Forms.DataGrid DG_GRAPHIC;
        private System.Windows.Forms.Button btn_CartXMLRead;
        private System.Windows.Forms.Button btn_CartXMLSave;
        private System.Windows.Forms.Button btn_Cart;
        private System.Windows.Forms.Button btn_ReadXML;
        private System.Windows.Forms.Button btn_SaveXML;
        private System.Windows.Forms.DataGrid DG_HARD;
        private System.Windows.Forms.DataGrid DG_CPU;
    }
}

