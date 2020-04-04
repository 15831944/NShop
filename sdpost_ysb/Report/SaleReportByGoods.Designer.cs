namespace NShop.Report
{
    partial class SaleReportByGoods
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOutput = new System.Windows.Forms.Button();
            this.varOrderType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.varEnd = new System.Windows.Forms.DateTimePicker();
            this.varBegin = new System.Windows.Forms.DateTimePicker();
            this.btnReport = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.varName = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.varName);
            this.panel1.Controls.Add(this.btnOutput);
            this.panel1.Controls.Add(this.varOrderType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.varEnd);
            this.panel1.Controls.Add(this.varBegin);
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(919, 65);
            this.panel1.TabIndex = 3;
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(645, 21);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 23);
            this.btnOutput.TabIndex = 5;
            this.btnOutput.Text = "导出报表";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // varOrderType
            // 
            this.varOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.varOrderType.FormattingEnabled = true;
            this.varOrderType.Items.AddRange(new object[] {
            "按销售数量统计",
            "按销售额统计",
            "按销售利润统计"});
            this.varOrderType.Location = new System.Drawing.Point(436, 23);
            this.varOrderType.Name = "varOrderType";
            this.varOrderType.Size = new System.Drawing.Size(121, 20);
            this.varOrderType.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "～";
            // 
            // varEnd
            // 
            this.varEnd.Location = new System.Drawing.Point(181, 23);
            this.varEnd.Name = "varEnd";
            this.varEnd.Size = new System.Drawing.Size(121, 21);
            this.varEnd.TabIndex = 2;
            // 
            // varBegin
            // 
            this.varBegin.Location = new System.Drawing.Point(33, 23);
            this.varBegin.Name = "varBegin";
            this.varBegin.Size = new System.Drawing.Size(121, 21);
            this.varBegin.TabIndex = 1;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(564, 21);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "生成报表";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chart1.BackSecondaryColor = System.Drawing.Color.White;
            this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart1.BorderlineWidth = 2;
            this.chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea5.Area3DStyle.Inclination = 15;
            chartArea5.Area3DStyle.IsClustered = true;
            chartArea5.Area3DStyle.IsRightAngleAxes = false;
            chartArea5.Area3DStyle.Perspective = 10;
            chartArea5.Area3DStyle.Rotation = 10;
            chartArea5.Area3DStyle.WallWidth = 0;
            chartArea5.AxisX.Interval = 1D;
            chartArea5.AxisX.IsLabelAutoFit = false;
            chartArea5.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea5.AxisX.LabelStyle.Angle = 30;
            chartArea5.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea5.AxisX.LabelStyle.Interval = 1D;
            chartArea5.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea5.AxisX.MajorGrid.Interval = 1D;
            chartArea5.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea5.AxisX.ScrollBar.LineColor = System.Drawing.Color.Black;
            chartArea5.AxisX.ScrollBar.Size = 10D;
            chartArea5.AxisX.Title = "商品名称";
            chartArea5.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea5.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea5.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea5.AxisY.ScrollBar.LineColor = System.Drawing.Color.Black;
            chartArea5.AxisY.ScrollBar.Size = 10D;
            chartArea5.BackColor = System.Drawing.Color.Gainsboro;
            chartArea5.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea5.BackSecondaryColor = System.Drawing.Color.White;
            chartArea5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea5.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea5.CursorX.IsUserEnabled = true;
            chartArea5.CursorX.IsUserSelectionEnabled = true;
            chartArea5.CursorY.IsUserEnabled = true;
            chartArea5.CursorY.IsUserSelectionEnabled = true;
            chartArea5.Name = "Default";
            chartArea5.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.BackColor = System.Drawing.Color.Transparent;
            legend5.Enabled = false;
            legend5.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend5.IsTextAutoFit = false;
            legend5.Name = "Default";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(0, 65);
            this.chart1.Name = "chart1";
            series13.BorderWidth = 3;
            series13.ChartArea = "Default";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series13.Legend = "Default";
            series13.LegendText = "商品销量";
            series13.MarkerSize = 8;
            series13.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series13.Name = "SaleCount";
            series13.ShadowOffset = 2;
            series14.BorderWidth = 3;
            series14.ChartArea = "Default";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series14.IsValueShownAsLabel = true;
            series14.IsXValueIndexed = true;
            series14.Label = "#VAL{C}";
            series14.Legend = "Default";
            series14.LegendText = "商品销售额";
            series14.MarkerSize = 8;
            series14.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series14.Name = "SaleVolume";
            series14.ShadowOffset = 2;
            series14.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series15.BorderWidth = 3;
            series15.ChartArea = "Default";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series15.IsValueShownAsLabel = true;
            series15.Label = "#VAL{C}";
            series15.Legend = "Default";
            series15.LegendText = "销售利润";
            series15.MarkerSize = 8;
            series15.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle;
            series15.Name = "SaleProfit";
            series15.ShadowOffset = 2;
            this.chart1.Series.Add(series13);
            this.chart1.Series.Add(series14);
            this.chart1.Series.Add(series15);
            this.chart1.Size = new System.Drawing.Size(919, 395);
            this.chart1.TabIndex = 4;
            title5.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            title5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            title5.Name = "Title1";
            title5.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            title5.ShadowOffset = 3;
            title5.Text = "商 品 销 量 统 计";
            this.chart1.Titles.Add(title5);
            // 
            // varName
            // 
            this.varName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.varName.FormattingEnabled = true;
            this.varName.Items.AddRange(new object[] {
            "按商品名称",
            "按供应商"});
            this.varName.Location = new System.Drawing.Point(308, 23);
            this.varName.Name = "varName";
            this.varName.Size = new System.Drawing.Size(121, 20);
            this.varName.TabIndex = 6;
            // 
            // SaleReportByGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 460);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.Name = "SaleReportByGoods";
            this.Text = "商品销量统计";
            this.Load += new System.EventHandler(this.SaleReportByGoods_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker varEnd;
        private System.Windows.Forms.DateTimePicker varBegin;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox varOrderType;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.ComboBox varName;
    }
}