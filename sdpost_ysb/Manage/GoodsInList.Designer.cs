namespace NShop.Manage
{
    partial class GoodsInList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodsInList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.varSalePrice = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.varInPrice = new System.Windows.Forms.ToolStripStatusLabel();
            this.varEndDate = new System.Windows.Forms.DateTimePicker();
            this.varBeginDate = new System.Windows.Forms.DateTimePicker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.varKeywords = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnUpdate = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateSupplier = new System.Windows.Forms.ToolStripButton();
            this.btnOutput = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnInMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnGoodsIn = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInput = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCheckOut = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewEx1 = new NShop.DataGridViewEx();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.statusStrip1.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.varSalePrice,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2,
            this.varInPrice});
            this.statusStrip1.Location = new System.Drawing.Point(0, 401);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(906, 50);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(145, 45);
            this.toolStripStatusLabel1.Text = "商品总价值：";
            // 
            // varSalePrice
            // 
            this.varSalePrice.Name = "varSalePrice";
            this.varSalePrice.Size = new System.Drawing.Size(33, 45);
            this.varSalePrice.Text = "--";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(27, 45);
            this.toolStripStatusLabel3.Text = "  ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(145, 45);
            this.toolStripStatusLabel2.Text = "商品总进价：";
            this.toolStripStatusLabel2.Visible = false;
            // 
            // varInPrice
            // 
            this.varInPrice.Name = "varInPrice";
            this.varInPrice.Size = new System.Drawing.Size(33, 45);
            this.varInPrice.Text = "--";
            this.varInPrice.Visible = false;
            // 
            // varEndDate
            // 
            this.varEndDate.Location = new System.Drawing.Point(133, 4);
            this.varEndDate.Name = "varEndDate";
            this.varEndDate.Size = new System.Drawing.Size(107, 21);
            this.varEndDate.TabIndex = 4;
            // 
            // varBeginDate
            // 
            this.varBeginDate.Location = new System.Drawing.Point(6, 4);
            this.varBeginDate.Name = "varBeginDate";
            this.varBeginDate.Size = new System.Drawing.Size(107, 21);
            this.varBeginDate.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Font = new System.Drawing.Font("黑体", 12F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.toolStripLabel3,
            this.toolStripLabel4,
            this.varKeywords,
            this.btnSearch,
            this.btnUpdate,
            this.btnUpdateSupplier,
            this.btnOutput,
            this.toolStripSeparator1,
            this.btnInMenu});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(906, 30);
            this.toolStrip1.TabIndex = 1;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(104, 27);
            this.toolStripLabel1.Text = "　　　　　　";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(24, 27);
            this.toolStripLabel2.Text = "～";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(104, 27);
            this.toolStripLabel3.Text = "　　　　　　";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(136, 27);
            this.toolStripLabel4.Text = "商品名称/供应商:";
            // 
            // varKeywords
            // 
            this.varKeywords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.varKeywords.Name = "varKeywords";
            this.varKeywords.Size = new System.Drawing.Size(100, 30);
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 27);
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(148, 27);
            this.btnUpdate.Text = "入库数量修改(&M)";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnUpdateSupplier
            // 
            this.btnUpdateSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnUpdateSupplier.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateSupplier.Image")));
            this.btnUpdateSupplier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateSupplier.Name = "btnUpdateSupplier";
            this.btnUpdateSupplier.Size = new System.Drawing.Size(132, 27);
            this.btnUpdateSupplier.Text = "供应商修改(&S)";
            this.btnUpdateSupplier.Click += new System.EventHandler(this.btnUpdateSupplier_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnOutput.Image = ((System.Drawing.Image)(resources.GetObject("btnOutput.Image")));
            this.btnOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(124, 20);
            this.btnOutput.Text = "导出Excel(&O)";
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // btnInMenu
            // 
            this.btnInMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGoodsIn,
            this.btnInput,
            this.btnCheckOut});
            this.btnInMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnInMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnInMenu.Image")));
            this.btnInMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInMenu.Name = "btnInMenu";
            this.btnInMenu.Size = new System.Drawing.Size(133, 20);
            this.btnInMenu.Text = "快速入库(F2)";
            this.btnInMenu.Visible = false;
            // 
            // btnGoodsIn
            // 
            this.btnGoodsIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnGoodsIn.Name = "btnGoodsIn";
            this.btnGoodsIn.Size = new System.Drawing.Size(204, 22);
            this.btnGoodsIn.Text = "快速入库(F2)";
            this.btnGoodsIn.Click += new System.EventHandler(this.btnGoodsIn_Click);
            // 
            // btnInput
            // 
            this.btnInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(204, 22);
            this.btnInput.Text = "批量入库(&I)";
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(204, 22);
            this.btnCheckOut.Text = "Excel模板下载(&D)";
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dataGridViewEx1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEx1.AutoGenerateColumns = false;
            this.dataGridViewEx1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEx1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEx1.DataSource = this.bindingSource1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEx1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.GridColor = System.Drawing.Color.DarkGray;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 30);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowTemplate.Height = 38;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(906, 371);
            this.dataGridViewEx1.TabIndex = 6;
            this.dataGridViewEx1.DoubleClick += new System.EventHandler(this.dataGridViewEx1_DoubleClick);
            this.dataGridViewEx1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewEx1_KeyDown);
            // 
            // GoodsInList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 451);
            this.Controls.Add(this.dataGridViewEx1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.varEndDate);
            this.Controls.Add(this.varBeginDate);
            this.Controls.Add(this.toolStrip1);
            this.Name = "GoodsInList";
            this.Text = "入库记录明细";
            this.Load += new System.EventHandler(this.GoodsInList_Load);
            this.Enter += new System.EventHandler(this.GoodsInList_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.DateTimePicker varBeginDate;
        private System.Windows.Forms.DateTimePicker varEndDate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnOutput;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel varSalePrice;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel varInPrice;
        private DataGridViewEx dataGridViewEx1;
        private System.Windows.Forms.ToolStripDropDownButton btnInMenu;
        private System.Windows.Forms.ToolStripMenuItem btnInput;
        private System.Windows.Forms.ToolStripMenuItem btnCheckOut;
        private System.Windows.Forms.ToolStripButton btnUpdate;
        private System.Windows.Forms.ToolStripMenuItem btnGoodsIn;
        private System.Windows.Forms.ToolStripButton btnUpdateSupplier;
        private System.Windows.Forms.ToolStripTextBox varKeywords;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
    }
}