using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NDolls.Data.Entity;
using NDolls.Data;

namespace NShop.Report
{
    public partial class SaleReport : BaseForm
    {
        private DataTable dt = new DataTable();
        private NShop.Service.DicService s = new NShop.Service.DicService();
        private bool enable3D = false;

        public SaleReport()
        {
            InitializeComponent();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            varDurationType_SelectedIndexChanged(sender, e);
        }

        /// <summary>
        /// 按水平序列生成图表（第一列为序列名称，后面列为序列值）
        /// </summary>
        /// <param name="dt"></param>
        private void showChartByHorizon(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                chart1.Series["Series1"].Points.AddXY(row[0].ToString(),row[1]);
            }
        }

        private void updateReport()
        {
            // Show as 3D
            chart1.ChartAreas["Default"].Area3DStyle.Enable3D = enable3D;
            chart1.Series["Series1"].IsValueShownAsLabel = true;

            if (chart1.Series["Series1"].ChartType == SeriesChartType.Pie)
                chart1.Legends[0].Enabled = true;
            else
                chart1.Legends[0].Enabled = false;
        }

        private void SaleReport_Load(object sender, EventArgs e)
        {
            varBegin.Value = DateTime.Now.AddDays(-7);
            varDurationType.SelectedIndex = 0;

            List<NShop.Model.sys_Dictionary> types = s.GetDicsByType("图表类型");
            NDolls.Forms.WinUtil.InitComboBox<NShop.Model.sys_Dictionary>(varChartType, "DName", "ExtDll", types);
            varChartType.Text = "柱状图";

            Version ver = System.Environment.OSVersion.Version;
            if (ver.Major == 5 && ver.Minor == 1)
            {
                btnOutput.Visible = false;
            }
        }

        private void varReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Series series in chart1.Series)
            {
                try
                {
                    series.ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), varChartType.SelectedValue.ToString().Replace(" ", ""));
                }
                catch { }
            }
            updateReport();
        }

        private void varDurationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (varDurationType.Text == "按天统计")
            {
                dt = RepositoryBase<EntityBase>.
                    Query("SELECT date(CreateTime) AS day,SUM(ReceivablePrice) FROM sdpost_Order WHERE day BETWEEN '" +
                    varBegin.Value.ToString("yyyy-MM-dd") + "' AND '" + varEnd.Value.ToString("yyyy-MM-dd") + "' GROUP BY date(CreateTime)");
            }
            else if (varDurationType.Text == "按月统计")
            {
                dt = RepositoryBase<EntityBase>.
                    Query("SELECT strftime('%Y-%m',CreateTime,'localtime') AS day,SUM(ReceivablePrice) FROM sdpost_Order WHERE day BETWEEN '" +
                    varBegin.Value.ToString("yyyy-MM") + "' AND '" + varEnd.Value.ToString("yyyy-MM") + "' GROUP BY strftime('%Y-%m',CreateTime,'localtime')");
            }

            chart1.Series["Series1"].Points.Clear();
            showChartByHorizon(dt);
            updateReport();
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "图片文件|*.jpeg";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                chart1.SaveImage(sfd.FileName, ChartImageFormat.Jpeg);
            }
        }
    }
}
