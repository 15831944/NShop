using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDolls.Data;
using NDolls.Data.Entity;
using System.Data;

namespace NShop.Service
{
    public class GoodsService
    {
        public static IRepository<Model.sdpost_Goods> r = RepositoryFactory<Model.sdpost_Goods>.CreateRepository("NShop.Model.sdpost_Goods");
        public static IRepository<Model.sdpost_GoodsIn> ir = RepositoryFactory<Model.sdpost_GoodsIn>.CreateRepository("NShop.Model.sdpost_GoodsIn");
        public static IRepository<Model.sdpost_Net_Goods> rnetgoods = RepositoryFactory<Model.sdpost_Net_Goods>.CreateRepository("NShop.Model.sdpost_Net_GoodsIn");

        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="key">条码、货号或助记码</param>
        /// <returns>符合条件的商品集合</returns>
        public List<NShop.Model.sdpost_Goods> GetGoods(String key)
        {
            key = NDolls.Core.Util.ValidateUtil.FilterIllegal(key);
            return r.Find("BarCode LIKE '%" + key + "%' OR StockNo LIKE '%" + key + "%' OR ShortCode LIKE '%" + key + "%'");
        }

        public List<NShop.Model.sdpost_Net_Goods> GetNetGoods(String key)
        {
            key = NDolls.Core.Util.ValidateUtil.FilterIllegal(key);
            return rnetgoods.Find("BarCode LIKE '%" + key + "%' OR StockNo LIKE '%" + key + "%' OR ShortCode LIKE '%" + key + "%'");
        }

        public List<NShop.Model.sdpost_Net_Goods> GetNetGoodsfirst(int count)
        {
            //key = NDolls.Core.Util.ValidateUtil.FilterIllegal(key);
            return rnetgoods.Find(" status=0 ORDER BY updatetime LIMIT 0," + count);
        }

        public List<NShop.Model.sdpost_Net_Goods> GetNetGoodsUpdated(int count,string lasttime)
        {
            //key = NDolls.Core.Util.ValidateUtil.FilterIllegal(key);
            return rnetgoods.Find(" updatetime>strftime('" + lasttime + "') ORDER BY updatetime LIMIT 0," + count);
        }

        public List<NShop.Model.sdpost_Goods> SearchGoods(List<Item> conditions)
        {
            return r.FindByCondition(conditions);
        }

        public DataTable CustomSearch(String fields,List<Item> conditions)
        {
            return r.FindByCustom(fields, conditions);
        }

        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="key">条码、货号或助记码</param>
        /// <returns>符合条件的商品集合</returns>
        public List<NShop.Model.sdpost_Goods> SearchGoods(String key)
        {
            key = NDolls.Core.Util.ValidateUtil.FilterIllegal(key);
            return r.Find("BarCode='" + key + "' OR StockNo LIKE '%" + key + "%' OR ShortCode LIKE '%" + key + "%'" + " OR GoodsName LIKE '%" + key + "%'");
        }

        /// <summary>
        /// 根据商品编号（主键）获取商品信息
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <returns>商品对象</returns>
        public NShop.Model.sdpost_Goods GetGoodsByID(String id)
        {
            return r.FindByPK(id);
        }

        /// <summary>
        /// 更新入库数量
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="inID">入库ID</param>
        /// <param name="newInCount">新入库数量</param>
        /// <param name="oldInCount">老入库数量</param>
        /// <returns></returns>
        public bool ChangeStock(String goodsID,String inID,int newInCount,int oldInCount)
        {
            String sqlGoodsIn = "UPDATE sdpost_GoodsIn SET InCount=" + newInCount + ",UpdateTime='" + DateTime.Now.ToString("s") + "' WHERE ID='" + inID + "'";
            String sqlGoods = "UPDATE sdpost_Goods SET Total=Total+" + (newInCount - oldInCount) + ",UpdateTime='" + DateTime.Now.ToString("s") + "' WHERE ID='" + goodsID + "'";
            List<String> list = new List<string>() { sqlGoodsIn, sqlGoods };

            return NDolls.Data.RepositoryBase<NShop.Model.sdpost_Goods>.Excute(list);
        }

        /// <summary>
        /// 更新供应商
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="inID">入库ID</param>
        /// <param name="supplier">新入库数量</param>
        /// <returns></returns>
        public bool ChangeSupplier(String goodsID, String inID, String supplier)
        {
            String sqlGoodsIn = "UPDATE sdpost_GoodsIn SET Supplier='" + supplier + "',UpdateTime='" + DateTime.Now.ToString("s") + "' WHERE ID='" + inID + "'";
            String sqlGoods = "UPDATE sdpost_Goods SET Supplier=" + supplier + ",UpdateTime='" + DateTime.Now.ToString("s") + "' WHERE ID='" + goodsID + "'";
            List<String> list = new List<string>() { sqlGoodsIn, sqlGoods };

            return NDolls.Data.RepositoryBase<NShop.Model.sdpost_Goods>.Excute(list);
        }

        /// <summary>
        /// 根据条码获取商品信息
        /// </summary>
        /// <param name="code">商品条码值</param>
        /// <returns>商品对象</returns>
        public List<NShop.Model.sdpost_Goods> GetGoodsByBarCode(String code)
        {
            ConditionItem item = new ConditionItem("BarCode", code, SearchType.Accurate);
            List<Model.sdpost_Goods> list = r.FindByCondition(item);

            return list;
        }

        public NShop.Model.sdpost_Goods GetGoodsByBarCode_mustone(String code)
        {
            ConditionItem item = new ConditionItem("BarCode", code, SearchType.Accurate);
            List<Model.sdpost_Goods> list = r.FindByCondition(item);
            if (list.Count > 0)
                return (NShop.Model.sdpost_Goods)list[0];
            else
                return null;
        }

        public NShop.Model.sdpost_GoodsIn GetGoodsIn(String goodsInID)
        {
            return ir.FindByPK(goodsInID);
        }

        public List<NShop.Model.sdpost_GoodsIn> GetGoodsIn(String begin,String end,String key)
        {
            //List<Item> list = new List<Item>();
            //list.Add(new ConditionItem("CreateTime",begin, SearchType.Greater));
            //list.Add(new ConditionItem("CreateTime", end, SearchType.Lower));
            //if (!String.IsNullOrEmpty(goods))
            //{
            //    list.Add(new ConditionItem("GoodsID", goods, SearchType.ValuesIn));
            //}
            //list.Add(new OrderItem("CreateTime", OrderType.DESC));

            //return ir.FindByCondition(list);

            key = NDolls.Core.Util.ValidateUtil.FilterIllegal(key);
            String sql = "(CreateTime BETWEEN '" + begin + "' AND '" + end + "') AND ";
                sql += "(BarCode='" + key + "' OR GoodsName LIKE '%" + key + "%' OR Supplier LIKE '%" + key + "%')";
            return ir.Find(sql);
        }

        public static IRepository<Model.sdpost_Net_GoodsIn> rnet = RepositoryFactory<Model.sdpost_Net_GoodsIn>.CreateRepository("NShop.Model.sdpost_Net_GoodsIn");
        public List<Model.sdpost_Net_GoodsIn> GetOrdersByDate(String dt, int pageCount, int pageIndex)
        {
            List<Item> list = new List<Item>();
            list.Add(new ConditionItem("CreateTime", dt + ".999999", SearchType.Greater));
            list.Add(new OrderItem("CreateTime", OrderType.ASC));

            return rnet.FindByPage(pageCount, pageIndex, list);
        }

        public bool DelGoods(String id)
        {
            return r.Delete(id);
        }

        public bool updateGoodsnum(Model.sdpost_Goods id)
        {
            return r.Update(id);
            
        }
    }
}
