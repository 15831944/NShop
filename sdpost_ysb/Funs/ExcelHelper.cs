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
        #region ˽�б���
        private string _connStr = "";
        private OleDbConnection _conn = new OleDbConnection();
        private OleDbDataAdapter adapter = new OleDbDataAdapter();
        #endregion

        #region  ����
        /// <summary>
        /// �����ַ���
        /// </summary>
        public string ConnStr
        {
            get { return _connStr; }
            set { _connStr = value; }
        }

        /// <summary>
        /// Excel��OleDbConnection
        /// </summary>
        public OleDbConnection Conn
        {
            get { return _conn; }
            set { _conn = value; }
        }

        /// <summary>
        /// Excel��OleDbAdapter
        /// </summary>
        public OleDbDataAdapter Adapter
        {
            get { return adapter; }
            set { adapter = value; }
        }
        #endregion

        #region  ����
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="fileName">Excel�ļ��ľ���·��</param>
        public ExcelHelper(string fileName)
        {
            this.ConnStr = " Provider=Microsoft.Jet.OLEDB.4.0; " +
               " Data Source=" + fileName + "; " +
               " Extended Properties=\'Excel 8.0; HDR=YES;IMEX=1\';" + //Excel 8.0; HDR=NO;IMEX=1����ĵ����Ų�Ҫ���ˣ���������
               " Persist Security Info=False";
        }

        /// <summary>
        /// ������
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
        /// �ر�����
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
        /// ����ָ����ҳ�е���������
        /// </summary>
        /// <param name="sheetName">��Ҫ��ѯ�ı�ҳ</param>
        /// <returns>ͨ��DataSet���ز�ѯ��������,���ݴ����DataSet�е���ΪsheetName��DataTable��</returns>
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
        /// ���OleDbDataReader��ʹ��ʱ�����ֶ������ӣ�ʹ����Ϻ����ֶ��ر�����
        /// </summary>
        /// <param name="sheetName">Excel·����</param>
        /// <returns>����OleDbDataReader</returns>
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
        /// ���Excel��ĳ��sheetҳ�����ֵ
        /// </summary>
        /// <param name="sheetName">ҳ����</param>
        /// <returns>�洢�����Ƶ�list</returns>
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
        /// ��ȡExcel�ı�ṹ������sheet�ı�����
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
