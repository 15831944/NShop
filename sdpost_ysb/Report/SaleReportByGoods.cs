using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NDolls.Data;
using NDolls.Data.Entity;

namespace NShop.Report
{
    public partial class SaleReportByGoods : BaseForm
    {
        private Boolean enable3D = false;
        private DataTable dt;

        private String sql = "SELECT {Name},SUM(GoodsNum) TotalCount,SUM(SalePrice) TotalPrice,SUM(Profit) as TotalProfit " +
            "FROM view_OrderGoods WHERE {Name} IS NOT NULL AND {Name} <> '' AND CreateTime BETWEEN '{BTime}' AND '{ETime}' GROUP BY GoodsName ORDER BY {OrderField} DESC LIMIT 10 OFFSET 0";

        public SaleReportByGoods()
        {
            InitializeComponent();
        }

        private void SaleReportByGoods_Load(object sender, EventArgs e)
        {
            varBegin.Value = DateTime.Now.AddDays(-30);
            varEnd.Value = DateTime.Now;
            varName.SelectedIndex = 0;
            varOrderType.SelectedIndex = 0;

            Version ver = System.Environment.OSVersion.Version;
            if (ver.Major == 5 && ver.Minor == 1)
            {
                btnOutput.Visible = false;
            }
        }

        /// <summary>
        /// 更新图表数据
        /// </summary>
        private void updateData()
        {
            String s = sql.
                Replace("{BTime}", varBegin.Value.ToString("yyyy-MM-dd") + " 00:00:01").
                Replace("{ETime}", varEnd.Value.ToString("yyyy-MM-dd") + " 23:59:59");

            switch (varName.Text)
            {
                case "按商品名称":
                    s = s.Replace("{Name}", "GoodsName");
                    break;
                case "按供应商":
                    s = s.Replace("{Name}", "Supplier");
                    break;
                default:
                    s = s.Replace("{Name}", "GoodsName");
                    break;
            }

            switch (varOrderType.Text)
            {
                case "按销售数量统计":
                    s = s.Replace("{OrderField}","TotalCount");
                    break;
                case "按销售额统计":
                    s = s.Replace("{OrderField}", "TotalPrice");
                    break;
                case "按销售利润统计":
                    s = s.Replace("{OrderField}", "TotalProfit");
                    break;
                default:
                    s = s.Replace("{OrderField}", "TotalCount");
                    break;
            }

            dt = RepositoryBase<EntityBase>.Query(s);

            chart1.Series["SaleCount"].Points.Clear();
            chart1.Series["SaleVolume"].Points.Clear();
            chart1.Series["SaleProfit"].Points.Clear();
            foreach (DataRow row in dt.Rows)
            {
                chart1.Series["SaleCount"].Points.AddXY(row[0].ToString(), row[1]);//销售量
                chart1.Series["SaleVolume"].Points.AddXY(row[0].ToString(), row[2]);//销售量
                chart1.Series["SaleProfit"].Points.AddXY(row[0].ToString(), row[3]);//销售量
            }
        }

        /// <summary>
        /// 更新图表样式
        /// </summary>
        private void updateReport()
        {
            chart1.ChartAreas["Default"].Area3DStyle.Enable3D = enable3D;
            chart1.Series["SaleCount"].IsValueShownAsLabel = true;
            chart1.Series["SaleVolume"].IsValueShownAsLabel = true;
            chart1.Legends[0].Enabled = true;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            updateData();
            updateReport();
        }

        private void varOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateData();
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
