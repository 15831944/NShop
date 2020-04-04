using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDolls.Data;
using NDolls.Core;
using System.Data;
using NDolls.Data.Entity;


namespace NShop.Service
{
    public class OrderService
    {
        public static IRepository<Model.sdpost_Order> r = RepositoryFactory<Model.sdpost_Order>.CreateRepository("NShop.Model.sdpost_Order");
        public static IRepository<Model.sdpost_Net_Order> rnet = RepositoryFactory<Model.sdpost_Net_Order>.CreateRepository("NShop.Model.sdpost_Net_Order");
        public static IRepository<Model.sdopst_OrderDetail> dr = RepositoryFactory<Model.sdopst_OrderDetail>.CreateRepository("NShop.Model.sdopst_OrderDetail");

        public bool AddTest(Model.sdpost_Order order)
        {
            return r.Add(order);
        }

        public bool UpdateOrder(Model.sdpost_Order order)
        {
            return r.Update(order);
        }

        public List<NShop.Model.sdpost_Order> GetOrders(List<Item> conditions)
        {
            return r.FindByCondition(conditions);
        }

        public List<NShop.Model.sdopst_OrderDetail> GetOrderDetails(List<Item> conditions)
        {
            return dr.FindByCondition(conditions);
        }

        public DataTable GetOrders(String begin, String end)
        {
            begin = NDolls.Core.Util.ValidateUtil.FilterIllegal(begin);
            end = NDolls.Core.Util.ValidateUtil.FilterIllegal(end);
            DataTable orders = RepositoryBase<NDolls.Data.Entity.EntityBase>.Query("SELECT * FROM sdpost_Order WHERE CreateTime BETWEEN '" + begin + " 00:00:01' AND '" + end + " 23:59:59' ORDER BY CreateTime DESC");
            return orders;
        }

        public DataTable GetSendOrders(String beginflowno)
        {
            beginflowno = NDolls.Core.Util.ValidateUtil.FilterIllegal(beginflowno);
            //订单流水号|商品数量|订单价格|总优惠金额|整单折扣|应收金额|实收金额|利润额
            DataTable orders = RepositoryBase<NDolls.Data.Entity.EntityBase>.Query("SELECT FlowNo,GoodsNum,OriginalPrice,Discount,DiscountRate,ReceivablePrice,Received,Profit,PayType,Cash,BandCard,IsPostCard FROM sdpost_Order WHERE FlowNo> '" + beginflowno + "' ORDER BY FlowNo DESC");
            return orders;
        }

        public DataTable GetSendOrderDetails(String flowno)
        {
            flowno = NDolls.Core.Util.ValidateUtil.FilterIllegal(flowno);
            //商品名称|商品分类|商品单件售价|购买数量|单件成本价|折扣|优惠金额|供应商|编码/条码|单位
            DataTable orders = RepositoryBase<NDolls.Data.Entity.EntityBase>.Query("SELECT GoodsName,Category,UnitPrice,GoodsNum,OriginalPrice,DiscountRate,Discount,Supplier,GoodsID,Unit FROM sdpost_Orderdetail WHERE OrderID= '" + flowno + "' ORDER BY ID DESC");
            return orders;
        }

        public string resetOrderDetails(Model.sdpost_Goods resetgoods)
        {
            DataTable ddd = RepositoryBase<NDolls.Data.Entity.EntityBase>.Query("SELECT id,orderid,goodsid,goodsnum FROM sdpost_Orderdetail WHERE originalprice=0 and goodsid= '" + resetgoods.BarCode + "' ORDER BY ID DESC");
            int iii, jjj, resp;
            string json = "", respdetail = "";
            for (iii = 0; iii < ddd.Rows.Count; iii++)
            {
                json = "update sdpost_Orderdetail set OriginalPrice=" + resetgoods.BuyingPrice + ",costprice=goodsnum*" + resetgoods.BuyingPrice + ",profit=profit-goodsnum*" + resetgoods.BuyingPrice + " where id='" + ddd.Rows[iii]["id"] + "'";
                resp=NDolls.Data.RepositoryBase<NShop.Model.sdopst_OrderDetail>.Excute(json);
                respdetail = respdetail + ddd.Rows[iii]["id"].ToString() + "|" + resp.ToString() + "|";
                if (resp == 1)
                {
                    json = "update sdpost_Order set profit=profit-" + resetgoods.BuyingPrice*Convert.ToDecimal(ddd.Rows[iii]["goodsnum"]) + " where flowno='" + ddd.Rows[iii]["orderid"] + "'";
                    resp = NDolls.Data.RepositoryBase<NShop.Model.sdopst_OrderDetail>.Excute(json);
                    respdetail = respdetail + resp.ToString() + "|";
                }
                else
                    respdetail = respdetail + " |";
            }
                //for (iii = 0; iii < ddd.Columns.Count; iii++)
                //{
                //    json = json + ddd.Rows[0][iii].ToString() + "|";
                //}
                //DataTable eee = sss.GetSendOrderDetails(ddd.Rows[0]["FlowNo"].ToString());
                //for (iii = 0; iii < eee.Rows.Count; iii++)
                //{
                //    json = json + "detail:";
                //    for (jjj = 0; jjj < eee.Columns.Count; jjj++)
                //    {
                //        json = json + ddd.Rows[iii][jjj].ToString() + "|";
                //    }
                //}

            return respdetail;
        }

        public int GetOrdersCount(String dt)
        {
            dt = NDolls.Core.Util.ValidateUtil.FilterIllegal(dt);
            DataTable orders = RepositoryBase<NDolls.Data.Entity.EntityBase>.Query("SELECT COUNT(1) FROM sdpost_Order WHERE CreateTime > '" + dt +"'");
            return int.Parse(orders.Rows[0][0].ToString());
        }

        public List<Model.sdpost_Net_Order> GetOrdersByDate(String dt, int pageCount, int pageIndex)
        {
            List<Item> list = new List<Item>();
            list.Add(new ConditionItem("CreateTime", dt + ".999999", SearchType.Greater));
            list.Add(new OrderItem("CreateTime", OrderType.ASC));

            return rnet.FindByPage(pageCount, pageIndex, list);
        }

        public List<Model.sdopst_OrderDetail> GetOrderDetails(String orderID)
        {
            return dr.FindByCondition(new ConditionItem("OrderID", orderID, SearchType.Accurate));
        }

        public DataSet GetOrdersEx(String begin,String end)
        {
            begin = NDolls.Core.Util.ValidateUtil.FilterIllegal(begin);
            end = NDolls.Core.Util.ValidateUtil.FilterIllegal(end);

            DataSet ds = new DataSet();

            DataTable orders = RepositoryBase<NDolls.Data.Entity.EntityBase>.Query("SELECT * FROM sdpost_Order WHERE CreateTime BETWEEN '" + begin + " 00:00:01' AND '" + end + " 23:59:59' ORDER BY CreateTime DESC");
            ds = orders.DataSet;
            orders.TableName = "Orders";

            DataTable details = RepositoryBase<NDolls.Data.Entity.EntityBase>.Query("SELECT * FROM sdpost_OrderDetail WHERE CreateTime BETWEEN '" + begin + " 00:00:01' AND '" + end + " 23:59:59'");
            ds.Tables.Add(details.Copy());
            ds.Tables[1].TableName = "Details";

            DataColumn parentCol = ds.Tables["Orders"].Columns["ID"];
            DataColumn childCol = ds.Tables["Details"].Columns["OrderID"]; 
            DataRelation relation = new DataRelation("FK_Order_Detail", parentCol, childCol);  // 建立主从关系              
            ds.Relations.Add(relation);  // 添加主从关系到数据集中

            return ds;
        }

        public List<Model.sdpost_Order> SearchTest()
        {
            return r.FindAll();
        }

        public Model.sdpost_Order GetOrder(string orderID)
        {
            return r.FindByPK(orderID);
        }
    }
}
