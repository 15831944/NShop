namespace NShop.Manage
{
    partial class SaleDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.varOrderID = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.varGoodsName = new System.Windows.Forms.ToolStripLabel();
            this.varGoodsNum = new System.Windows.Forms.ToolStripComboBox();
            this.btnRefund = new System.Windows.Forms.ToolStripButton();
            this.varDetailID = new System.Windows.Forms.ToolStripLabel();
            this.gridSlave = new NShop.DataGridViewEx();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSlave)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.varOrderID,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.varGoodsName,
            this.varGoodsNum,
            this.btnRefund,
            this.varDetailID});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(884, 30);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(78, 27);
            this.toolStripLabel1.Text = "订单编号:";
            // 
            // varOrderID
            // 
            this.varOrderID.Name = "varOrderID";
            this.varOrderID.Size = new System.Drawing.Size(17, 27);
            this.varOrderID.Text = "_";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(78, 27);
            this.toolStripLabel2.Text = "商品名称:";
            this.toolStripLabel2.Visible = false;
            // 
            // varGoodsName
            // 
            this.varGoodsName.ForeColor = System.Drawing.Color.Red;
            this.varGoodsName.Name = "varGoodsName";
            this.varGoodsName.Size = new System.Drawing.Size(17, 27);
            this.varGoodsName.Text = "_";
            this.varGoodsName.Visible = false;
            // 
            // varGoodsNum
            // 
            this.varGoodsNum.Name = "varGoodsNum";
            this.varGoodsNum.Size = new System.Drawing.Size(121, 30);
            this.varGoodsNum.Visible = false;
            // 
            // btnRefund
            // 
            this.btnRefund.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.btnRefund.Image = ((System.Drawing.Image)(resources.GetObject("btnRefund.Image")));
            this.btnRefund.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(62, 27);
            this.btnRefund.Text = "退货";
            this.btnRefund.Visible = false;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // varDetailID
            // 
            this.varDetailID.Name = "varDetailID";
            this.varDetailID.Size = new System.Drawing.Size(88, 27);
            this.varDetailID.Text = "订单商品id";
            this.varDetailID.Visible = false;
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
            this.gridSlave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSlave.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridSlave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSlave.Location = new System.Drawing.Point(0, 30);
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
            this.gridSlave.Size = new System.Drawing.Size(884, 419);
            this.gridSlave.TabIndex = 3;
            this.gridSlave.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSlave_RowEnter);
            // 
            // SaleDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 449);
            this.Controls.Add(this.gridSlave);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaleDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "销售明细";
            this.Load += new System.EventHandler(this.SaleDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSlave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private DataGridViewEx gridSlave;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel varOrderID;
        private System.Windows.Forms.ToolStripButton btnRefund;
        private System.Windows.Forms.ToolStripLabel varGoodsName;
        private System.Windows.Forms.ToolStripComboBox varGoodsNum;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel varDetailID;
    }
}