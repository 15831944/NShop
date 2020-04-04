using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NDolls.Data.Attribute;
using System.Data;
using System.IO;
using System.Reflection;

namespace NShop.Funs
{
    public class GridUtil
    {
        public static void InitDataGrid(DataGridView grid, List<CustomAttribute> cols)
        {
            grid.AutoGenerateColumns = false;

            grid.Columns.Clear();
            foreach (CustomAttribute col in cols)
            {
                DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
                c.Name = col.CusName;
                c.HeaderText = col.CusValue;
                c.DataPropertyName = col.CusName;
                if (col.CusMemo == "invisible")
                {
                    c.Visible = false;
                }
                else if (col.CusMemo == "sortble")
                {
                    c.SortMode = DataGridViewColumnSortMode.Automatic;
                }
                grid.Columns.Add(c);
            }
        }

        public static void AppendRow<T>(BindingSource bindSource, T model)
        {
            try
            {
                bindSource.Add(model);
                bindSource.MoveLast();
            }
            catch { }
        }

        public static void UpdateRow(BindingSource bindSource, object o)
        {
            Type t = o.GetType();
            PropertyInfo[] properties = t.GetProperties();
            object p = bindSource.Current;
            foreach (PropertyInfo pi in properties)
            {
                if (pi.CanWrite)
                {
                    object value = pi.GetValue(o, null);
                    pi.SetValue(p, value, null);
                }
            }

            bindSource.ResetCurrentItem();
        }

        public static void DataToExcel(DataGridView grid)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存EXECL文件";
            kk.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                string FileName = kk.FileName;
                if (File.Exists(FileName))
                    File.Delete(FileName);
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    if (grid.Columns[i].Visible == true)
                    {
                        strLine = strLine + grid.Columns[i].HeaderText.ToString() + Convert.ToChar(9);
                    }
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";

                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    if (grid.Columns[0].Visible == true)
                    {
                        if (grid.Rows[i].Cells[0].Value == null)
                            strLine = strLine + " " + Convert.ToChar(9);
                        else
                            strLine = strLine + " " + grid.Rows[i].Cells[0].Value.ToString() + Convert.ToChar(9);
                    }
                    for (int j = 1; j < grid.Columns.Count; j++)
                    {
                        if (grid.Columns[j].Visible == true)
                        {
                            if (grid.Rows[i].Cells[j].Value == null)
                                strLine = strLine + " " + Convert.ToChar(9);
                            else
                            {
                                string rowstr = "";
                                rowstr = grid.Rows[i].Cells[j].Value.ToString();
                                if (rowstr.IndexOf("\r\n") > 0)
                                    rowstr = rowstr.Replace("\r\n", " ");
                                if (rowstr.IndexOf("\t") > 0)
                                    rowstr = rowstr.Replace("\t", " ");
                                strLine = strLine + rowstr + Convert.ToChar(9);
                            }
                        }
                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = "";
                }
                objStreamWriter.Close();
                objFileStream.Close();
                MessageBox.Show("保存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
