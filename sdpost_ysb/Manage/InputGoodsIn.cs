using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NShop.Funs;

namespace NShop.Manage
{
    public partial class InputGoodsIn : Form
    {
        NShop.Service.GoodsService gs = new NShop.Service.GoodsService();
        NShop.Service.DicService ds = new NShop.Service.DicService();

        NShop.Model.sdpost_Goods gm = new NShop.Model.sdpost_Goods();
        NShop.Model.sdpost_GoodsIn gim = new NShop.Model.sdpost_GoodsIn();

        public InputGoodsIn()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.varFileName.Text = openFileDialog1.FileName;
            }
        }

        //按标准模板导入
        private void btnInput_Click(object sender, EventArgs e)
        {
            List<NDolls.Data.Entity.EntityBase> list = new List<NDolls.Data.Entity.EntityBase>();

            if (this.varFileName.Text.Trim() == "")
            {
                MessageBox.Show("请选择要导入Excel文件!");
                return;
            }
            
            writeLog("数据合法性检测开始...");
            if (!checkData())
            {
                MessageBox.Show("导入数据有不符合要求内容，请修改正确后重新导入.");
                return;
            }
            writeLog("数据合法性检测结束");
            
            ExcelHelper hp = new ExcelHelper(varFileName.Text);
            hp.Open();

            int i = 2;
            System.Data.OleDb.OleDbDataReader reader = hp.GetDataReader("Sheet1$");
            varInputResult.Text = "";
            writeLog("数据导入开始...");
            while (reader.Read())
            {
                if (!ds.Exist("商品类别", reader["商品类别"].ToString().Trim()))
                {
                    NShop.Model.sys_Dictionary dm = new NShop.Model.sys_Dictionary();
                    dm.DID = Guid.NewGuid().ToString("N");
                    dm.DType = "商品类别";
                    dm.DName = reader["商品类别"].ToString().Trim();
                    dm.CreateTime = dm.UpdateTime = DateTime.Now;
                    list.Add(dm);
                }
                if (!ds.Exist("商品单位", reader["商品单位"].ToString().Trim()))
                {
                    NShop.Model.sys_Dictionary dm = new NShop.Model.sys_Dictionary();
                    dm.DID = Guid.NewGuid().ToString("N");
                    dm.DType = "商品单位";
                    dm.DName = reader["商品类别"].ToString().Trim();
                    dm.CreateTime = dm.UpdateTime = DateTime.Now;
                    list.Add(dm);
                }
                if (!ds.Exist("商品品牌", reader["商品品牌"].ToString().Trim()))
                {
                    NShop.Model.sys_Dictionary dm = new NShop.Model.sys_Dictionary();
                    dm.DID = Guid.NewGuid().ToString("N");
                    dm.DType = "商品品牌";
                    dm.DName = reader["商品品牌"].ToString().Trim();
                    dm.CreateTime = dm.UpdateTime = DateTime.Now;
                    list.Add(dm);
                }

                writeLog("\n第" + (i++) + "行_" + reader["商品条码"].ToString().Trim() + "导入:");
                gm = gs.GetGoodsByBarCode_mustone(reader["商品条码"].ToString().Trim());
                if (gm == null)
                {
                    gm = new NShop.Model.sdpost_Goods();
                    gm.ID = Guid.NewGuid().ToString("N");
                }

                if (reader["商品条码"].ToString().Trim() != "")
                {
                    gm.BarCode = reader["商品条码"].ToString().Trim();
                }
                else
                {
                    writeLog("商品条码不允许为空;");
                    continue;
                }

                if (reader["商品名称"].ToString().Trim() != "")
                {
                    gm.GoodsName = reader["商品名称"].ToString().Trim();
                }
                else 
                {
                    writeLog("商品名称不允许为空;");
                    continue;
                }

                if (ValidateUtil.GetDecimal(reader["商品进价"].ToString().Trim()) >= 0)
                {
                    gm.BuyingPrice = ValidateUtil.GetDecimal(reader["商品进价"].ToString().Trim());
                }
                else
                {
                    writeLog("商品进价应大于等于0;");
                    continue;
                }

                if (ValidateUtil.GetDecimal(reader["零售价"].ToString().Trim()) > 0)
                {
                    gm.RetailPrice = ValidateUtil.GetDecimal(reader["零售价"].ToString().Trim());
                }
                else
                {
                    writeLog("商品零售价应大于0;");
                    continue;
                }

                if (ValidateUtil.GetInt(reader["入库数量"].ToString().Trim()) >= 0)
                {
                    gm.Total += ValidateUtil.GetInt(reader["入库数量"].ToString().Trim());
                }
                else
                {
                    writeLog("入库数量应为大于等于0的正整数;");
                    continue;
                }

                gm.MemberPrice = ValidateUtil.GetDecimal(reader["会员价"].ToString().Trim());
                gm.Brand = reader["商品品牌"].ToString().Trim();
                gm.Category = reader["商品类别"].ToString().Trim();
                gm.IsOnSale = true;
                gm.IsPromotion = false;
                gm.ShortCode = SpellingUtil.GetPrefixLetters(gm.GoodsName);
                gm.Supplier = reader["供应商"].ToString().Trim();
                gm.Unit = reader["商品单位"].ToString().Trim();
                gm.UpdateTime = DateTime.Now;
                list.Add(gm);

                if (ValidateUtil.GetInt(reader["入库数量"].ToString().Trim()) > 0)
                {
                    gim = new NShop.Model.sdpost_GoodsIn();
                    gim.BarCode = gm.BarCode;
                    gim.Brand = gm.Brand;
                    gim.BuyingPrice = gm.BuyingPrice;
                    gim.CreateTime = ValidateUtil.GetDateTime(reader["入库时间"].ToString().Trim());
                    gim.GoodsID = gm.ID;
                    gim.GoodsName = gm.GoodsName;
                    gim.ID = Guid.NewGuid().ToString("N");
                    gim.InCount = ValidateUtil.GetInt(reader["入库数量"].ToString().Trim());
                    gim.RetailPrice = gm.RetailPrice;
                    gim.Supplier = gm.Supplier;
                    gim.Unit = gm.Unit;
                    gim.UpdateTime = DateTime.Now;
                    list.Add(gim);
                }

                if (NDolls.Data.RepositoryBase<NDolls.Data.Entity.EntityBase>.BatchSave(list))
                {
                    writeLog("入库成功");
                }
                else
                {
                    writeLog("入库失败");
                }
                varInputResult.ScrollToCaret();
                Application.DoEvents();
            }
            hp.Close();

            MessageBox.Show("完成");
        }

        private void writeLog(String msg)
        {
            varInputResult.Text += msg ;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            writeLog("数据合法性检测开始...");
            if (!checkData())
            {
                MessageBox.Show("导入数据有不符合要求内容，请修改正确后重新导入.");
            }
            else
            {
                writeLog("数据检测成功，点击【数据导入】，完成数据导入操作.");
            }

            writeLog("数据合法性检测结束");
        }

        private bool checkData()
        {
            if (this.varFileName.Text.Trim() == "")
            {
                MessageBox.Show("请选择要导入Excel文件!");
                return false;
            }

            bool ret = true;

            ExcelHelper hp = new ExcelHelper(varFileName.Text);
            hp.Open();

            int i = 2;
            System.Data.OleDb.OleDbDataReader reader = hp.GetDataReader("Sheet1$");
            varInputResult.Text = "";
            String error = "";
            while (reader.Read())
            {
                error = "";

                if (reader["商品条码"].ToString().Trim() == "")
                {
                    error += "商品条码不允许为空;";
                    ret = false;
                }

                if (reader["商品名称"].ToString().Trim() == "")
                {
                    error += "商品名称不允许为空;";
                    ret = false;
                }

                if (ValidateUtil.GetDecimal(reader["商品进价"].ToString().Trim()) < 0)
                {
                    error += "商品进价应大于等于0;";
                    ret = false;
                }

                if (ValidateUtil.GetDecimal(reader["零售价"].ToString().Trim()) <= 0)
                {
                    error += "商品零售价应大于0;";
                    ret = false;
                }

                if (ValidateUtil.GetInt(reader["入库数量"].ToString().Trim()) < 0)
                {
                    error += "入库数量应为大于等于0的正整数;";
                    ret = false;
                }

                if (!String.IsNullOrEmpty(error))
                {
                    writeLog("\n第" + (i) + "行_" + reader["商品条码"].ToString().Trim() + "导入:");
                    writeLog(error);
                }

                i++;
            }
            hp.Close();

            return ret;
        }

        //邮乐数据导入
        private void button1_Click(object sender, EventArgs e)
        {
            List<NDolls.Data.Entity.EntityBase> list = new List<NDolls.Data.Entity.EntityBase>();

            ExcelHelper hp = new ExcelHelper(varFileName.Text);
            hp.Open();

            System.Data.OleDb.OleDbDataReader reader = hp.GetDataReader("Sheet1$");
            writeLog("数据导入开始...");
            String barcode;
            NShop.Model.sdpost_Goods m;
            while (reader.Read())
            {
                barcode = reader["商品条码"].ToString().Trim();
                m = gs.GetGoodsByBarCode_mustone(barcode);
                if (m == null)
                {
                    try
                    {
                        if (!ds.Exist("商品类别", reader["商品分类"].ToString().Trim()))
                        {
                            NShop.Model.sys_Dictionary dm = new NShop.Model.sys_Dictionary();
                            dm.DID = Guid.NewGuid().ToString("N");
                            dm.DType = "商品类别";
                            dm.DName = reader["商品分类"].ToString().Trim();
                            dm.CreateTime = dm.UpdateTime = DateTime.Now;
                            list.Add(dm);
                        }

                        m = new NShop.Model.sdpost_Goods();
                        m.ID = barcode;
                        m.GoodsName = reader["商品名称"].ToString();
                        m.BarCode = barcode;
                        m.Brand = "";
                        m.BuyingPrice = 0;
                        m.RetailPrice = ValidateUtil.GetDecimal(reader["售价"].ToString().Trim('¥'));
                        m.MemberPrice = ValidateUtil.GetDecimal(reader["售价"].ToString().Trim('¥'));
                        m.Category = reader["商品分类"].ToString().Trim();
                        m.IsOnSale = true;
                        m.IsPromotion = false;
                        m.ShortCode = SpellingUtil.GetPrefixLetters(m.GoodsName);
                        m.Supplier = "";
                        m.Unit = reader["库存数量"].ToString().Trim().Substring(reader["库存数量"].ToString().Trim().Length-1);
                        m.UpdateTime = DateTime.Now;
                        m.Total = int.Parse(reader["库存数量"].ToString().Substring(0,reader["库存数量"].ToString().Length-1));
                        list.Add(m);

                        if (NDolls.Data.RepositoryBase<NDolls.Data.Entity.EntityBase>.BatchSave(list))
                        {
                            writeLog(barcode + "导入成功\n");
                        }
                        else
                        {
                            writeLog(barcode + "导入失败\n");
                        }
                    }
                    catch {
                        writeLog(barcode + "导入失败-------------------\n");
                    }
                }

                Application.DoEvents();
            }
            hp.Close();
        }

    }
}
