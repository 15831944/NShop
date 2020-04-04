namespace NShop.Manage
{
    partial class GoodsInEx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodsInEx));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.varBarCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.varTotal = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.varProfitRate = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.varBrand = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.varMemo = new System.Windows.Forms.RichTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.varAlarm = new System.Windows.Forms.TextBox();
            this.varCreateTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.varShelfLife = new System.Windows.Forms.TextBox();
            this.varInCount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.varSupplier = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.varMemberPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.varRetailPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.varBuyingPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.varCategory = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.varShortCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.varUnit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.varGoodsName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.varProductionDate = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.varExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.varStockNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.varBarCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.varTotal);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.varProductionDate);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.varExpirationDate);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.varStockNo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 395);
            this.panel1.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(279, 360);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 45;
            this.btnNew.Text = "新 建(&N)";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(251, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(11, 12);
            this.label22.TabIndex = 44;
            this.label22.Text = "*";
            // 
            // varBarCode
            // 
            this.varBarCode.Location = new System.Drawing.Point(104, 13);
            this.varBarCode.Name = "varBarCode";
            this.varBarCode.Size = new System.Drawing.Size(141, 21);
            this.varBarCode.TabIndex = 0;
            this.varBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.varBarCode_KeyDown);
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
            this.btnSave.Location = new System.Drawing.Point(360, 360);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保 存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(441, 360);
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
            this.varTotal.Location = new System.Drawing.Point(360, 17);
            this.varTotal.Name = "varTotal";
            this.varTotal.Size = new System.Drawing.Size(41, 12);
            this.varTotal.TabIndex = 25;
            this.varTotal.Text = "库存量";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(277, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 24;
            this.label12.Text = "当前库存量：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.varProfitRate);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.varBrand);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.varMemo);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.varAlarm);
            this.groupBox1.Controls.Add(this.varCreateTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.varShelfLife);
            this.groupBox1.Controls.Add(this.varInCount);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.varSupplier);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.varMemberPrice);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.varRetailPrice);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.varBuyingPrice);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.varCategory);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.varShortCode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.varUnit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.varGoodsName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 305);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "入库信息";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(213, 182);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(17, 12);
            this.label29.TabIndex = 48;
            this.label29.Text = "元";
            // 
            // varProfitRate
            // 
            this.varProfitRate.Enabled = false;
            this.varProfitRate.Location = new System.Drawing.Point(334, 278);
            this.varProfitRate.Name = "varProfitRate";
            this.varProfitRate.Size = new System.Drawing.Size(141, 21);
            this.varProfitRate.TabIndex = 46;
            this.varProfitRate.Visible = false;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(265, 284);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(53, 12);
            this.label28.TabIndex = 47;
            this.label28.Text = "利润率：";
            this.label28.Visible = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(213, 151);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(17, 12);
            this.label27.TabIndex = 45;
            this.label27.Text = "元";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(213, 120);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 12);
            this.label20.TabIndex = 44;
            this.label20.Text = "元";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(239, 119);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(11, 12);
            this.label26.TabIndex = 43;
            this.label26.Text = "*";
            // 
            // varBrand
            // 
            this.varBrand.FormattingEnabled = true;
            this.varBrand.Location = new System.Drawing.Point(92, 268);
            this.varBrand.Name = "varBrand";
            this.varBrand.Size = new System.Drawing.Size(141, 20);
            this.varBrand.TabIndex = 9;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(481, 31);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(11, 12);
            this.label25.TabIndex = 42;
            this.label25.Text = "*";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(239, 148);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(11, 12);
            this.label24.TabIndex = 40;
            this.label24.Text = "*";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(239, 31);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(11, 12);
            this.label23.TabIndex = 40;
            this.label23.Text = "*";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(481, 121);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(11, 12);
            this.label21.TabIndex = 40;
            this.label21.Text = "*";
            // 
            // varMemo
            // 
            this.varMemo.Location = new System.Drawing.Point(334, 149);
            this.varMemo.Name = "varMemo";
            this.varMemo.Size = new System.Drawing.Size(141, 135);
            this.varMemo.TabIndex = 16;
            this.varMemo.Text = "";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(265, 151);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 12);
            this.label19.TabIndex = 37;
            this.label19.Text = "备 注：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(265, 92);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 35;
            this.label18.Text = "库存预警：";
            // 
            // varAlarm
            // 
            this.varAlarm.Location = new System.Drawing.Point(334, 87);
            this.varAlarm.Name = "varAlarm";
            this.varAlarm.Size = new System.Drawing.Size(141, 21);
            this.varAlarm.TabIndex = 14;
            this.varAlarm.Text = "0";
            // 
            // varCreateTime
            // 
            this.varCreateTime.CustomFormat = "yyyy-MM-dd hh:mm";
            this.varCreateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.varCreateTime.Location = new System.Drawing.Point(334, 118);
            this.varCreateTime.Name = "varCreateTime";
            this.varCreateTime.Size = new System.Drawing.Size(141, 21);
            this.varCreateTime.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "入库日期：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(265, 61);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 33;
            this.label17.Text = "保质期：";
            // 
            // varShelfLife
            // 
            this.varShelfLife.Location = new System.Drawing.Point(334, 56);
            this.varShelfLife.Name = "varShelfLife";
            this.varShelfLife.Size = new System.Drawing.Size(141, 21);
            this.varShelfLife.TabIndex = 12;
            // 
            // varInCount
            // 
            this.varInCount.Location = new System.Drawing.Point(334, 25);
            this.varInCount.Name = "varInCount";
            this.varInCount.Size = new System.Drawing.Size(141, 21);
            this.varInCount.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(265, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 26;
            this.label11.Text = "入库数量：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(23, 274);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 24;
            this.label14.Text = "商品品牌：";
            // 
            // varSupplier
            // 
            this.varSupplier.Location = new System.Drawing.Point(92, 237);
            this.varSupplier.Name = "varSupplier";
            this.varSupplier.Size = new System.Drawing.Size(141, 21);
            this.varSupplier.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 243);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 22;
            this.label13.Text = "供应商：";
            // 
            // varMemberPrice
            // 
            this.varMemberPrice.Location = new System.Drawing.Point(92, 177);
            this.varMemberPrice.Name = "varMemberPrice";
            this.varMemberPrice.Size = new System.Drawing.Size(141, 21);
            this.varMemberPrice.TabIndex = 6;
            this.varMemberPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.varRetailPrice_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 183);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "会员价：";
            // 
            // varRetailPrice
            // 
            this.varRetailPrice.Location = new System.Drawing.Point(92, 146);
            this.varRetailPrice.Name = "varRetailPrice";
            this.varRetailPrice.Size = new System.Drawing.Size(141, 21);
            this.varRetailPrice.TabIndex = 5;
            this.varRetailPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.varRetailPrice_KeyPress);
            this.varRetailPrice.Leave += new System.EventHandler(this.varRetailPrice_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "零售价：";
            // 
            // varBuyingPrice
            // 
            this.varBuyingPrice.Location = new System.Drawing.Point(92, 115);
            this.varBuyingPrice.Name = "varBuyingPrice";
            this.varBuyingPrice.Size = new System.Drawing.Size(141, 21);
            this.varBuyingPrice.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "商品进价：";
            // 
            // varCategory
            // 
            this.varCategory.FormattingEnabled = true;
            this.varCategory.Location = new System.Drawing.Point(92, 86);
            this.varCategory.Name = "varCategory";
            this.varCategory.Size = new System.Drawing.Size(141, 20);
            this.varCategory.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "商品类别：";
            // 
            // varShortCode
            // 
            this.varShortCode.Location = new System.Drawing.Point(92, 55);
            this.varShortCode.Name = "varShortCode";
            this.varShortCode.Size = new System.Drawing.Size(141, 21);
            this.varShortCode.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "助记码：";
            // 
            // varUnit
            // 
            this.varUnit.FormattingEnabled = true;
            this.varUnit.Location = new System.Drawing.Point(92, 208);
            this.varUnit.Name = "varUnit";
            this.varUnit.Size = new System.Drawing.Size(141, 20);
            this.varUnit.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "商品单位：";
            // 
            // varGoodsName
            // 
            this.varGoodsName.Location = new System.Drawing.Point(92, 25);
            this.varGoodsName.Name = "varGoodsName";
            this.varGoodsName.Size = new System.Drawing.Size(141, 21);
            this.varGoodsName.TabIndex = 0;
            this.varGoodsName.Leave += new System.EventHandler(this.varGoodsName_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "商品名称：";
            // 
            // varProductionDate
            // 
            this.varProductionDate.Checked = false;
            this.varProductionDate.CustomFormat = "yyyy-MM-dd";
            this.varProductionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.varProductionDate.Location = new System.Drawing.Point(75, 363);
            this.varProductionDate.Name = "varProductionDate";
            this.varProductionDate.ShowCheckBox = true;
            this.varProductionDate.Size = new System.Drawing.Size(141, 21);
            this.varProductionDate.TabIndex = 11;
            this.varProductionDate.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 369);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 31;
            this.label15.Text = "生产日期：";
            this.label15.Visible = false;
            // 
            // varExpirationDate
            // 
            this.varExpirationDate.Checked = false;
            this.varExpirationDate.CustomFormat = "yyyy-MM-dd";
            this.varExpirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.varExpirationDate.Location = new System.Drawing.Point(75, 353);
            this.varExpirationDate.Name = "varExpirationDate";
            this.varExpirationDate.ShowCheckBox = true;
            this.varExpirationDate.Size = new System.Drawing.Size(141, 21);
            this.varExpirationDate.TabIndex = 13;
            this.varExpirationDate.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 359);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 32;
            this.label16.Text = "过期日期：";
            this.label16.Visible = false;
            // 
            // varStockNo
            // 
            this.varStockNo.Location = new System.Drawing.Point(77, 353);
            this.varStockNo.Name = "varStockNo";
            this.varStockNo.Size = new System.Drawing.Size(141, 21);
            this.varStockNo.TabIndex = 2;
            this.varStockNo.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "商品货号：";
            this.label6.Visible = false;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(233, 235);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(37, 23);
            this.btnSelect.TabIndex = 49;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // GoodsIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 395);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GoodsIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品入库";
            this.Activated += new System.EventHandler(this.GoodsIn_Activated);
            this.Load += new System.EventHandler(this.GoodsIn_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker varCreateTime;
        private System.Windows.Forms.TextBox varGoodsName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox varUnit;
        private System.Windows.Forms.TextBox varShortCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox varStockNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox varCategory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox varRetailPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox varBuyingPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox varMemberPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label varTotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox varSupplier;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox varInCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker varProductionDate;
        private System.Windows.Forms.DateTimePicker varExpirationDate;
        private System.Windows.Forms.TextBox varShelfLife;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox varAlarm;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RichTextBox varMemo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox varBrand;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox varBarCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox varProfitRate;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnSelect;
    }
}