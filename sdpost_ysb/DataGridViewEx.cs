using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NShop
{
    public partial class DataGridViewEx : DataGridView
    {
        public DataGridViewEx()
        {
            InitializeComponent();

            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            this.RowTemplate.Height = 38;
        }

        protected override void OnBackgroundColorChanged(EventArgs e)
        {
            this.BackgroundColor = Color.FromArgb(227, 239, 255);
        }

        protected override void OnColumnHeadersDefaultCellStyleChanged(EventArgs e)
        {
            this.ColumnHeadersDefaultCellStyle.Font = new Font(new FontFamily("微软雅黑"), 12);
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        protected override void OnDefaultCellStyleChanged(EventArgs e)
        {
            this.DefaultCellStyle.Font = new Font(new FontFamily("微软雅黑"), 12);
        }

        protected override void OnAlternatingRowsDefaultCellStyleChanged(EventArgs e)
        {
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
        }

        //列表头添加行
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dataGridView1.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dataGridView1.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

    }
}
