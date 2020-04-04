namespace NShop.Manage
{
    partial class SaleList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleList));
            this.bMaster = new System.Windows.Forms.BindingSource(this.components);
            this.bSlave = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridSlave = new NShop.DataGridViewEx();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCopyCell = new System.Windows.Forms.ToolStripMenuItem();
            this.gridMaster = new NShop.DataGridViewEx();
            this.masterMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.varSales = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.varProfit = new System.Windows.Forms.ToolStripStatusLabel();
            this.varEndDate = new System.Windows.Forms.DateTimePicker();
            this.varBeginDate = new System.Windows.Forms.DateTimePicker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.varOrderType = new System.Windows.Forms.ToolStripComboBox();
            this.lblGoodsName = new System.Windows.Forms.ToolStripLabel();
            this.varGoodsName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.varMemberNo = new System.Windows.Forms.ToolStripTextBox();
            this.varShowType = new System.Windows.Forms.ToolStripComboBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnRefund = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnOutput = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReport = new System.Windows.Forms.ToolStripButton();
            this.MyPrintDocument = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.bMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSlave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSlave)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
            this.masterMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridSlave);
            this.splitContainer1.Panel1.Controls.Add(this.gridMaster);
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(1053, 488);
            this.splitContainer1.SplitterDistance = 268;
            this.splitContainer1.TabIndex = 9;
            // 
            // gridSlave
            // 
            this.gridSlave.AllowUserToAddRows = false;
            this.gridSlave.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.gridSlave.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSlave.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSlave.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridSlave.ColumnHeadersHeight = 28;
            this.gridSlave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridSlave.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSlave.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridSlave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSlave.GridColor = System.Drawing.Color.DarkGray;
            this.gridSlave.Location = new System.Drawing.Point(0, 0);
            this.gridSlave.MultiSelect = false;
            this.gridSlave.Name = "gridSlave";
            this.gridSlave.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSlave.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridSlave.RowTemplate.Height = 38;
            this.gridSlave.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSlave.Size = new System.Drawing.Size(1053, 443);
            this.gridSlave.TabIndex = 3;
            this.gridSlave.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.gridSlave_CellContextMenuStripNeeded);
            this.gridSlave.DoubleClick += new System.EventHandler(this.gridSlave_DoubleClick);
            this.gridSlave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridSlave_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopyCell});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 26);
            // 
            // btnCopyCell
            // 
            this.btnCopyCell.Name = "btnCopyCell";
            this.btnCopyCell.Size = new System.Drawing.Size(160, 22);
            this.btnCopyCell.Text = "复制单元格内容";
            this.btnCopyCell.Click += new System.EventHandler(this.btnCopyCell_Click);
            // 
            // gridMaster
            // 
            this.gridMaster.AllowUserToAddRows = false;
            this.gridMaster.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightBlue;
            this.gridMaster.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridMaster.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridMaster.ColumnHeadersHeight = 28;
            this.gridMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridMaster.ContextMenuStrip = this.masterMenu;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMaster.DefaultCellStyle = dataGridViewCellStyle7;
            this.gridMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMaster.GridColor = System.Drawing.Color.DarkGray;
            this.gridMaster.Location = new System.Drawing.Point(0, 0);
            this.gridMaster.MultiSelect = false;
            this.gridMaster.Name = "gridMaster";
            this.gridMaster.ReadOnly = true;
            this.gridMaster.RowTemplate.Height = 38;
            this.gridMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMaster.Size = new System.Drawing.Size(1053, 443);
            this.gridMaster.TabIndex = 1;
            this.gridMaster.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.gridSlave_CellContextMenuStripNeeded);
            this.gridMaster.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMaster_CellDoubleClick);
            this.gridMaster.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridMaster_CellFormatting);
            this.gridMaster.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridSlave_MouseMove);
            // 
            // masterMenu
            // 
            this.masterMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.masterMenu.Name = "contextMenuStrip1";
            this.masterMenu.Size = new System.Drawing.Size(161, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem1.Text = "复制单元格内容";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.btnCopyCell_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.statusStrip1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.varSales,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2,
            this.varProfit});
            this.statusStrip1.Location = new System.Drawing.Point(0, 443);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1053, 45);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(126, 40);
            this.toolStripStatusLabel1.Text = "总销售金额：";
            // 
            // varSales
            // 
            this.varSales.ForeColor = System.Drawing.Color.Red;
            this.varSales.Name = "varSales";
            this.varSales.Size = new System.Drawing.Size(28, 40);
            this.varSales.Text = "--";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(24, 40);
            this.toolStripStatusLabel3.Text = "  ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(107, 40);
            this.toolStripStatusLabel2.Text = "总利润额：";
            this.toolStripStatusLabel2.Visible = false;
            // 
            // varProfit
            // 
            this.varProfit.Name = "varProfit";
            this.varProfit.Size = new System.Drawing.Size(28, 40);
            this.varProfit.Text = "--";
            this.varProfit.Visible = false;
            // 
            // varEndDate
            // 
            this.varEndDate.Location = new System.Drawing.Point(133, 4);
            this.varEndDate.Name = "varEndDate";
            this.varEndDate.Size = new System.Drawing.Size(107, 21);
            this.varEndDate.TabIndex = 1;
            this.varEndDate.TabStop = false;
            this.varEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.varBeginDate_KeyDown);
            // 
            // varBeginDate
            // 
            this.varBeginDate.CalendarFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.varBeginDate.Location = new System.Drawing.Point(6, 4);
            this.varBeginDate.Name = "varBeginDate";
            this.varBeginDate.Size = new System.Drawing.Size(107, 21);
            this.varBeginDate.TabIndex = 0;
            this.varBeginDate.TabStop = false;
            this.varBeginDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.varBeginDate_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Font = new System.Drawing.Font("黑体", 12F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.toolStripLabel3,
            this.varOrderType,
            this.lblGoodsName,
            this.varGoodsName,
            this.toolStripLabel5,
            this.varMemberNo,
            this.varShowType,
            this.btnSearch,
            this.btnRefund,
            this.btnPrint,
            this.btnOutput,
            this.toolStripSeparator1,
            this.btnReport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1053, 30);
            this.toolStrip1.TabIndex = 10;
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
            // varOrderType
            // 
            this.varOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.varOrderType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.varOrderType.Items.AddRange(new object[] {
            "全部订单",
            "销售订单",
            "退货订单"});
            this.varOrderType.Name = "varOrderType";
            this.varOrderType.Size = new System.Drawing.Size(90, 30);
            // 
            // lblGoodsName
            // 
            this.lblGoodsName.Name = "lblGoodsName";
            this.lblGoodsName.Size = new System.Drawing.Size(80, 27);
            this.lblGoodsName.Text = "商品信息:";
            // 
            // varGoodsName
            // 
            this.varGoodsName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.varGoodsName.Name = "varGoodsName";
            this.varGoodsName.Size = new System.Drawing.Size(100, 30);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(64, 27);
            this.toolStripLabel5.Text = "会员号:";
            // 
            // varMemberNo
            // 
            this.varMemberNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.varMemberNo.Name = "varMemberNo";
            this.varMemberNo.Size = new System.Drawing.Size(100, 30);
            // 
            // varShowType
            // 
            this.varShowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.varShowType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.varShowType.Items.AddRange(new object[] {
            "按商品展示",
            "按订单展示"});
            this.varShowType.Name = "varShowType";
            this.varShowType.Size = new System.Drawing.Size(105, 30);
            this.varShowType.SelectedIndexChanged += new System.EventHandler(this.varShowType_SelectedIndexChanged);
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
            // btnRefund
            // 
            this.btnRefund.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnRefund.Image = ((System.Drawing.Image)(resources.GetObject("btnRefund.Image")));
            this.btnRefund.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(92, 27);
            this.btnRefund.Text = "商品退货";
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(92, 27);
            this.btnPrint.Text = "小票补打";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            // btnReport
            // 
            this.btnReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(92, 20);
            this.btnReport.Text = "打印流水";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // MyPrintDocument
            // 
            this.MyPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.MyPrintDocument_PrintPage);
            // 
            // SaleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 518);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.varEndDate);
            this.Controls.Add(this.varBeginDate);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SaleList";
            this.Text = "销售记录";
            this.Load += new System.EventHandler(this.SaleList_Load);
            this.Enter += new System.EventHandler(this.SaleList_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.bMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSlave)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSlave)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
            this.masterMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripButton btnOutput;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.BindingSource bMaster;
        private System.Windows.Forms.DateTimePicker varEndDate;
        private System.Windows.Forms.DateTimePicker varBeginDate;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.BindingSource bSlave;
        private DataGridViewEx gridMaster;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel varSales;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel varProfit;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripTextBox varMemberNo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripComboBox varShowType;
        private DataGridViewEx gridSlave;
        private System.Windows.Forms.ToolStripLabel lblGoodsName;
        private System.Windows.Forms.ToolStripTextBox varGoodsName;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnRefund;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnCopyCell;
        private System.Windows.Forms.ContextMenuStrip masterMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripComboBox varOrderType;
        private System.Windows.Forms.ToolStripButton btnReport;
        private System.Drawing.Printing.PrintDocument MyPrintDocument;


    }
}