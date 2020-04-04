using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDolls.Data;
using NDolls.Data.Entity;

namespace NShop.Service
{
    public class OrderGoodsService
    {
        public static IRepository<Model.view_OrderGoods> r = RepositoryFactory<Model.view_OrderGoods>.CreateRepository("NShop.Model.view_OrderGoods");

        public List<Model.view_OrderGoods> GetOrderGoods(List<Item> conditions)
        {
            return r.FindByCondition(conditions);
        }
    }
}
