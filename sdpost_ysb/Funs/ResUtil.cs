using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace NShop.Funs
{
    public class ResUtil
    {
        public static void OutputXLS(String fileName)
        {
            Assembly asm = Assembly.LoadFrom("NShop.Param.dll");
            Stream fs = asm.GetManifestResourceStream("NShop.Param.Res." + fileName);
            byte[] buffer = new byte[fs.Length];
            try
            {
                fs.Read(buffer, 0, (int)fs.Length);
            }
            catch{}
            finally
            {
                fs.Close();
            }

            SaveFileDialog sfg = new SaveFileDialog();
            sfg.Filter = "Excel文件|*.xls";
            sfg.FileName = fileName;
            if (sfg.ShowDialog() == DialogResult.OK)
            {
                FileStream fstream = File.Create(sfg.FileName, buffer.Length);
                try
                {
                    fstream.Write(buffer, 0, buffer.Length);   //二进制转换成文件
                }
                catch { }
                finally
                {
                    fstream.Close();
                }
            }
        }
    }
}
