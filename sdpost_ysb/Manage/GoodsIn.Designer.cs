namespace NShop.Manage
{
    partial class GoodsIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.varGoodsName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.varBarCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.varTotal = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.varSupplier = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.varMemo = new System.Windows.Forms.RichTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.varCreateTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.varInCount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.varBuyingPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.varGoodsName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.varBarCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.varTotal);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 326);
            this.panel1.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(279, 292);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 48;
            this.btnNew.Text = "新增入库";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // varGoodsName
            // 
            this.varGoodsName.AutoSize = true;
            this.varGoodsName.ForeColor = System.Drawing.Color.Red;
            this.varGoodsName.Location = new System.Drawing.Point(102, 50);
            this.varGoodsName.Name = "varGoodsName";
            this.varGoodsName.Size = new System.Drawing.Size(53, 12);
            this.varGoodsName.TabIndex = 47;
            this.varGoodsName.Text = "商品名称";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 46;
            this.label5.Text = "商品名称：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(493, 18);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(11, 12);
            this.label22.TabIndex = 44;
            this.label22.Text = "*";
            // 
            // varBarCode
            // 
            this.varBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.varBarCode.Location = new System.Drawing.Point(104, 13);
            this.varBarCode.Name = "varBarCode";
            this.varBarCode.Size = new System.Drawing.Size(383, 21);
            this.varBarCode.TabIndex = 0;
            this.varBarCode.Leave += new System.EventHandler(this.varBarCode_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 42;
            this.label2.Text = "条码/编号：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(360, 292);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保 存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(441, 292);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关 闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // varTotal
            // 
            this.varTotal.AutoSize = true;
            this.varTotal.ForeColor = System.Drawing.Color.Red;
            this.varTotal.Location = new System.Drawing.Point(360, 50);
            this.varTotal.Name = "varTotal";
            this.varTotal.Size = new System.Drawing.Size(41, 12);
            this.varTotal.TabIndex = 25;
            this.varTotal.Text = "库存量";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(277, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 24;
            this.label12.Text = "当前库存量：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.varSupplier);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.varMemo);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.varCreateTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.varInCount);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.varBuyingPrice);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(12, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "入库信息";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(475, 60);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(37, 23);
            this.btnSelect.TabIndex = 53;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // varSupplier
            // 
            this.varSupplier.Location = new System.Drawing.Point(334, 62);
            this.varSupplier.Name = "varSupplier";
            this.varSupplier.Size = new System.Drawing.Size(141, 21);
            this.varSupplier.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(263, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 52;
            this.label6.Text = "供应商：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(455, 29);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 12);
            this.label20.TabIndex = 44;
            this.label20.Text = "元";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(481, 28);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(11, 12);
            this.label26.TabIndex = 43;
            this.label26.Text = "*";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(239, 29);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(11, 12);
            this.label25.TabIndex = 42;
            this.label25.Text = "*";
            // 
            // varMemo
            // 
            this.varMemo.Location = new System.Drawing.Point(92, 98);
            this.varMemo.Name = "varMemo";
            this.varMemo.Size = new System.Drawing.Size(383, 80);
            this.varMemo.TabIndex = 4;
            this.varMemo.Text = "";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(23, 98);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 12);
            this.label19.TabIndex = 37;
            this.label19.Text = "备 注：";
            // 
            // varCreateTime
            // 
            this.varCreateTime.CustomFormat = "yyyy-MM-dd hh:mm";
            this.varCreateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.varCreateTime.Location = new System.Drawing.Point(92, 62);
            this.varCreateTime.Name = "varCreateTime";
            this.varCreateTime.Size = new System.Drawing.Size(141, 21);
            this.varCreateTime.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "入库时间：";
            // 
            // varInCount
            // 
            this.varInCount.Location = new System.Drawing.Point(92, 24);
            this.varInCount.Name = "varInCount";
            this.varInCount.Size = new System.Drawing.Size(141, 21);
            this.varInCount.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 26;
            this.label11.Text = "入库数量：";
            // 
            // varBuyingPrice
            // 
            this.varBuyingPrice.Location = new System.Drawing.Point(334, 24);
            this.varBuyingPrice.Name = "varBuyingPrice";
            this.varBuyingPrice.Size = new System.Drawing.Size(141, 21);
            this.varBuyingPrice.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(265, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "商品进价：";
            // 
            // GoodsIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 326);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoodsIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品入库";
            this.Load += new System.EventHandler(this.GoodsIn_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox varBarCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label varTotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.RichTextBox varMemo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker varCreateTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox varInCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox varBuyingPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label varGoodsName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox varSupplier;
        private System.Windows.Forms.Label label6;
    }
}