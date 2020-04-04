using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDolls.Data;
using NDolls.Data.Entity;

namespace NShop.Service
{
    public class StockService
    {
        public static IRepository<NShop.Model.view_GoodsStockLog> r =
            RepositoryFactory<NShop.Model.view_GoodsStockLog>.CreateRepository("NShop.Model.view_GoodsStockLog");

        public List<NShop.Model.view_GoodsStockLog> GetStockLog(String ids)
        {
            List<Item> items = new List<Item>();
            items.Add(new ConditionItem("GoodsID", ids, SearchType.ValuesIn));
            items.Add(new OrderItem("CreateTime", OrderType.DESC));
            List<NShop.Model.view_GoodsStockLog> list = r.FindByCondition(items);
            return list;
        }
    }
}
