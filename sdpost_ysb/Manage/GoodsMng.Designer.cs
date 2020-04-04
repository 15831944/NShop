namespace NShop.Manage
{
    partial class GoodsMng
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodsMng));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.varTotal = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnChangeStock = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.btnInStock = new System.Windows.Forms.Button();
            this.lBarcode = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.varIsOnSaleY = new System.Windows.Forms.RadioButton();
            this.btnNew = new System.Windows.Forms.Button();
            this.varIsOnSaleN = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.varBarCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.varAlarm = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.varBuyingPrice = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.varMemberPrice = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.varRetailPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.varSupplier = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.varUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.varBrand = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.varShortCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.varCategory = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.varGoodsName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.varTotal);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.btnInStock);
            this.panel1.Controls.Add(this.lBarcode);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.varIsOnSaleY);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.varIsOnSaleN);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.varBarCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 359);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(385, 327);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保 存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // varTotal
            // 
            this.varTotal.Enabled = false;
            this.varTotal.Location = new System.Drawing.Point(115, 286);
            this.varTotal.Name = "varTotal";
            this.varTotal.Size = new System.Drawing.Size(106, 21);
            this.varTotal.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.varAlarm);
            this.groupBox2.Controls.Add(this.btnChangeStock);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 264);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(529, 57);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "库存情况";
            // 
            // btnChangeStock
            // 
            this.btnChangeStock.Location = new System.Drawing.Point(227, 21);
            this.btnChangeStock.Name = "btnChangeStock";
            this.btnChangeStock.Size = new System.Drawing.Size(43, 23);
            this.btnChangeStock.TabIndex = 43;
            this.btnChangeStock.Text = "调整";
            this.btnChangeStock.UseVisualStyleBackColor = true;
            this.btnChangeStock.Click += new System.EventHandler(this.btnChangeStock_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(215, 25);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(17, 12);
            this.label24.TabIndex = 44;
            this.label24.Text = "* ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(281, 27);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 12);
            this.label20.TabIndex = 42;
            this.label20.Text = "库存预警值：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 40;
            this.label8.Text = "当前库存量：";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(466, 327);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关 闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(42, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(377, 12);
            this.label22.TabIndex = 41;
            this.label22.Text = "注：若出现同条码不同商品，可在原商品条码后增加两位，加以区分。";
            // 
            // btnInStock
            // 
            this.btnInStock.Location = new System.Drawing.Point(283, 30);
            this.btnInStock.Name = "btnInStock";
            this.btnInStock.Size = new System.Drawing.Size(75, 23);
            this.btnInStock.TabIndex = 42;
            this.btnInStock.Text = "快速入库";
            this.btnInStock.UseVisualStyleBackColor = true;
            this.btnInStock.Click += new System.EventHandler(this.btnInStock_Click);
            // 
            // lBarcode
            // 
            this.lBarcode.AutoSize = true;
            this.lBarcode.Location = new System.Drawing.Point(42, 36);
            this.lBarcode.Name = "lBarcode";
            this.lBarcode.Size = new System.Drawing.Size(47, 12);
            this.lBarcode.TabIndex = 40;
            this.lBarcode.Text = "barcode";
            this.lBarcode.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(277, 35);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(168, 16);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.Text = "无条码商品(系统自动生成)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(260, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 30;
            this.label13.Text = "*";
            // 
            // varIsOnSaleY
            // 
            this.varIsOnSaleY.AutoSize = true;
            this.varIsOnSaleY.Checked = true;
            this.varIsOnSaleY.Location = new System.Drawing.Point(113, 330);
            this.varIsOnSaleY.Name = "varIsOnSaleY";
            this.varIsOnSaleY.Size = new System.Drawing.Size(35, 16);
            this.varIsOnSaleY.TabIndex = 9;
            this.varIsOnSaleY.TabStop = true;
            this.varIsOnSaleY.Text = "是";
            this.varIsOnSaleY.UseVisualStyleBackColor = true;
            this.varIsOnSaleY.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(299, 327);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "新 建(&N)";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // varIsOnSaleN
            // 
            this.varIsOnSaleN.AutoSize = true;
            this.varIsOnSaleN.Location = new System.Drawing.Point(154, 330);
            this.varIsOnSaleN.Name = "varIsOnSaleN";
            this.varIsOnSaleN.Size = new System.Drawing.Size(35, 16);
            this.varIsOnSaleN.TabIndex = 10;
            this.varIsOnSaleN.Text = "否";
            this.varIsOnSaleN.UseVisualStyleBackColor = true;
            this.varIsOnSaleN.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(42, 332);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 29;
            this.label10.Text = "是否在售：";
            this.label10.Visible = false;
            // 
            // varBarCode
            // 
            this.varBarCode.Location = new System.Drawing.Point(113, 31);
            this.varBarCode.Name = "varBarCode";
            this.varBarCode.Size = new System.Drawing.Size(141, 21);
            this.varBarCode.TabIndex = 0;
            this.varBarCode.Leave += new System.EventHandler(this.varBarCode_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "商品条码：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.varBuyingPrice);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.varMemberPrice);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.varRetailPrice);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.varSupplier);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.varUnit);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.varBrand);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.varShortCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.varCategory);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.varGoodsName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 202);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "商品信息";
            // 
            // varAlarm
            // 
            this.varAlarm.Location = new System.Drawing.Point(353, 22);
            this.varAlarm.Name = "varAlarm";
            this.varAlarm.Size = new System.Drawing.Size(141, 21);
            this.varAlarm.TabIndex = 1;
            this.varAlarm.Text = "10";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(493, 92);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(37, 23);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(281, 174);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(173, 12);
            this.label23.TabIndex = 43;
            this.label23.Text = "商品进价为最新入库的商品进价";
            this.label23.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(499, 134);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(11, 12);
            this.label16.TabIndex = 41;
            this.label16.Text = "*";
            this.label16.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(248, 174);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 40;
            this.label17.Text = "* ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(471, 136);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 12);
            this.label21.TabIndex = 39;
            this.label21.Text = "元";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(221, 135);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 12);
            this.label19.TabIndex = 36;
            this.label19.Text = "元";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(221, 173);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 35;
            this.label18.Text = "元";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(248, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 12);
            this.label15.TabIndex = 32;
            this.label15.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(248, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 31;
            this.label14.Text = "*";
            // 
            // varBuyingPrice
            // 
            this.varBuyingPrice.Location = new System.Drawing.Point(101, 169);
            this.varBuyingPrice.Name = "varBuyingPrice";
            this.varBuyingPrice.Size = new System.Drawing.Size(141, 21);
            this.varBuyingPrice.TabIndex = 9;
            this.varBuyingPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.varRetailPrice_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 174);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 29;
            this.label12.Text = "商品进价：";
            // 
            // varMemberPrice
            // 
            this.varMemberPrice.Location = new System.Drawing.Point(352, 131);
            this.varMemberPrice.Name = "varMemberPrice";
            this.varMemberPrice.Size = new System.Drawing.Size(141, 21);
            this.varMemberPrice.TabIndex = 8;
            this.varMemberPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.varRetailPrice_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(281, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "商品会员价：";
            // 
            // varRetailPrice
            // 
            this.varRetailPrice.Location = new System.Drawing.Point(101, 131);
            this.varRetailPrice.Name = "varRetailPrice";
            this.varRetailPrice.Size = new System.Drawing.Size(141, 21);
            this.varRetailPrice.TabIndex = 7;
            this.varRetailPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.varRetailPrice_KeyPress);
            this.varRetailPrice.Leave += new System.EventHandler(this.varRetailPrice_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 23;
            this.label9.Text = "商品零售价：";
            // 
            // varSupplier
            // 
            this.varSupplier.Location = new System.Drawing.Point(352, 94);
            this.varSupplier.Name = "varSupplier";
            this.varSupplier.Size = new System.Drawing.Size(141, 21);
            this.varSupplier.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(281, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "供应商：";
            // 
            // varUnit
            // 
            this.varUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.varUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.varUnit.FormattingEnabled = true;
            this.varUnit.Location = new System.Drawing.Point(101, 94);
            this.varUnit.Name = "varUnit";
            this.varUnit.Size = new System.Drawing.Size(141, 20);
            this.varUnit.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "商品单位：";
            // 
            // varBrand
            // 
            this.varBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.varBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.varBrand.FormattingEnabled = true;
            this.varBrand.Location = new System.Drawing.Point(352, 58);
            this.varBrand.Name = "varBrand";
            this.varBrand.Size = new System.Drawing.Size(141, 20);
            this.varBrand.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "商品品牌：";
            // 
            // varShortCode
            // 
            this.varShortCode.Location = new System.Drawing.Point(352, 21);
            this.varShortCode.Name = "varShortCode";
            this.varShortCode.Size = new System.Drawing.Size(141, 21);
            this.varShortCode.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "助记码：";
            // 
            // varCategory
            // 
            this.varCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.varCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.varCategory.FormattingEnabled = true;
            this.varCategory.Location = new System.Drawing.Point(101, 58);
            this.varCategory.Name = "varCategory";
            this.varCategory.Size = new System.Drawing.Size(141, 20);
            this.varCategory.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "商品类别：";
            // 
            // varGoodsName
            // 
            this.varGoodsName.Location = new System.Drawing.Point(101, 21);
            this.varGoodsName.Name = "varGoodsName";
            this.varGoodsName.Size = new System.Drawing.Size(141, 21);
            this.varGoodsName.TabIndex = 0;
            this.varGoodsName.Leave += new System.EventHandler(this.varGoodsName_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "商品名称：";
            // 
            // GoodsMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 359);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GoodsMng";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品信息";
            this.Load += new System.EventHandler(this.GoodsMng_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox varGoodsName;
        private System.Windows.Forms.ComboBox varCategory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox varBarCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox varShortCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox varBrand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox varUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox varSupplier;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox varRetailPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox varMemberPrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton varIsOnSaleY;
        private System.Windows.Forms.RadioButton varIsOnSaleN;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox varBuyingPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lBarcode;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnInStock;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox varAlarm;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox varTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnChangeStock;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label24;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}