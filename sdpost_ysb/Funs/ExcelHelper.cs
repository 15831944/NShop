using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Collections;

namespace NShop.Funs
{
    public class ExcelHelper
    {
        #region 私有变量
        private string _connStr = "";
        private OleDbConnection _conn = new OleDbConnection();
        private OleDbDataAdapter adapter = new OleDbDataAdapter();
        #endregion

        #region  属性
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnStr
        {
            get { return _connStr; }
            set { _connStr = value; }
        }

        /// <summary>
        /// Excel的OleDbConnection
        /// </summary>
        public OleDbConnection Conn
        {
            get { return _conn; }
            set { _conn = value; }
        }

        /// <summary>
        /// Excel的OleDbAdapter
        /// </summary>
        public OleDbDataAdapter Adapter
        {
            get { return adapter; }
            set { adapter = value; }
        }
        #endregion

        #region  函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fileName">Excel文件的绝对路径</param>
        public ExcelHelper(string fileName)
        {
            this.ConnStr = " Provider=Microsoft.Jet.OLEDB.4.0; " +
               " Data Source=" + fileName + "; " +
               " Extended Properties=\'Excel 8.0; HDR=YES;IMEX=1\';" + //Excel 8.0; HDR=NO;IMEX=1两侧的单引号不要丢了，否则会出错。
               " Persist Security Info=False";
        }

        /// <summary>
        /// 打开连接
        /// </summary>
        public void Open()
        {
            Conn = new OleDbConnection(ConnStr);
            if (Conn.State == ConnectionState.Closed)
            {
                try
                {
                    Conn.Open();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    Conn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 返回指定表页中的所有数据
        /// </summary>
        /// <param name="sheetName">所要查询的表页</param>
        /// <returns>通过DataSet返回查询到的数据,数据存放在DataSet中的名为sheetName的DataTable中</returns>
        public DataSet ReadExcel(string sheetName)
        {
            DataSet ds = new DataSet();
            string scmd = "select * from [" + sheetName + "]";

            Open();
            try
            {
                Adapter = new OleDbDataAdapter(scmd, Conn);
                Adapter.Fill(ds, sheetName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }

            return ds;
        }

        /// <summary>
        /// 获得OleDbDataReader，使用时需先手动打开连接，使用完毕后需手动关闭连接
        /// </summary>
        /// <param name="sheetName">Excel路径名</param>
        /// <returns>返回OleDbDataReader</returns>
        public OleDbDataReader GetDataReader(string sheetName)
        {
            OleDbDataReader reader = null;
            string scmd = "select * from [" + sheetName + "]";

            //Open();
            try
            {
                OleDbCommand command = new OleDbCommand(scmd, Conn);
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Close();
            }
            return reader;
        }

        /// <summary>
        /// 获得Excel中某个sheet页表的列值
        /// </summary>
        /// <param name="sheetName">页表名</param>
        /// <returns>存储列名称的list</returns>
        public ArrayList GetSchemaColumsName(string sheetName)
        {
            ArrayList list = new ArrayList();
            OleDbDataReader reader = null;
            string scmd = "select * from [" + sheetName + "]";

            Open();
            try
            {
                OleDbCommand command = new OleDbCommand(scmd, Conn);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (reader.GetName(i) != "")
                        {
                            list.Add(reader.GetName(i).Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
            return list;
        }

        /// <summary>
        /// 获取Excel的表结构（各个sheet的表名）
        /// </summary>
        /// <returns></returns>
        public ArrayList GetSchemaTableName()
        {
            ArrayList list = new ArrayList();

            Open();
            try
            {
                DataTable tables = Conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "table" });
                foreach (DataRow row in tables.Rows)
                {
                    list.Add(row["table_name"].ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Close(); }

            return list;
        }

        #endregion
    }
}
