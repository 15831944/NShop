using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using NDolls.Data.Attribute;
using NDolls.Data.Entity;
namespace NShop.Model
{
    [Entity("view_OrderGoods", "ID")]
    public class view_OrderGoods : EntityBase
    {
        /// <summary>
        /// ID
        /// </summary>		
        [DataField("ID", "nvarchar")]
        [Validate("不允许为空")]
        [Custom("GridCol", "ID", "系统编号", "invisible")]
        public string ID { get; set; }

        /// <summary>
        /// OrderID
        /// </summary>		
        [DataField("OrderID", "nvarchar")]
        [Custom("GridCol", "OrderID", "订单号")]
        public string OrderID { get; set; }

        /// <summary>
        /// GoodsID
        /// </summary>		
        [DataField("GoodsID", "nvarchar")]
        [Custom("GridCol", "GoodsID", "商品条码")]
        public string GoodsID { get; set; }

        /// <summary>
        /// GoodsName
        /// </summary>		
        [DataField("GoodsName", "nvarchar")]
        [Custom("GridCol", "GoodsName", "商品名称")]
        public string GoodsName { get; set; }

        /// <summary>
        /// UnitPrice
        /// </summary>		
        [DataField("UnitPrice", "float")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// GoodsNum
        /// </summary>		
        [DataField("GoodsNum", "integer")]
        [Custom("GridCol", "GoodsNum", "数量")]
        public int GoodsNum { get; set; }

        /// <summary>
        /// Unit
        /// </summary>		
        [DataField("Unit", "nvarchar")]
        [Custom("GridCol", "Unit", "单位")]
        public string Unit { get; set; }

        /// <summary>
        /// OriginalPrice
        /// </summary>		
        [DataField("OriginalPrice", "float")]
        public decimal OriginalPrice { get; set; }

        /// <summary>
        /// MemberPrice
        /// </summary>		
        [DataField("MemberPrice", "float")]
        public decimal MemberPrice { get; set; }

        /// <summary>
        /// DiscountRate
        /// </summary>		
        [DataField("DiscountRate", "float")]
        public decimal DiscountRate { get; set; }

        /// <summary>
        /// Discount
        /// </summary>		
        [DataField("Discount", "float")]
        public decimal Discount { get; set; }

        /// <summary>
        /// SalePrice
        /// </summary>		
        [DataField("SalePrice", "float")]
        [Custom("GridCol", "SalePrice", "销售金额")]
        public decimal SalePrice { get; set; }

        /// <summary>
        /// CostPrice
        /// </summary>		
        [DataField("CostPrice", "float")]
        [Custom("GridCol", "CostPrice", "成本金额")]
        public decimal CostPrice { get; set; }
        
        /// <summary>
        /// Profit
        /// </summary>		
        [DataField("Profit", "float")]
        [Custom("GridCol", "Profit", "利润额")]
        public decimal Profit { get; set; }

        /// <summary>
        /// MemberNo
        /// </summary>		
        [DataField("MemberNo", "nvarchar")]
        [Custom("GridCol", "MemberNo", "会员号")]
        public string MemberNo { get; set; }

        /// <summary>
        /// Supplier
        /// </summary>		
        [DataField("Supplier", "nvarchar")]
        public string Supplier { get; set; }

        /// <summary>
        /// Status
        /// </summary>		
        [DataField("Status", "integer")]
        public int Status { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>		
        [DataField("CreateTime", "datetime")]
        [Custom("GridCol", "CreateTime", "订单时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// UpdateTime
        /// </summary>		
        [DataField("UpdateTime", "datetime")]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// Modifier
        /// </summary>		
        [DataField("Modifier", "nvarchar")]
        [Custom("GridCol", "Modifier", "处理人")]
        public string Modifier { get; set; }

        /// <summary>
        /// Category
        /// </summary>		
        [DataField("Category", "nvarchar")]
        public string Category { get; set; }
        
        /// <summary>
        /// Promotion
        /// </summary>		
        [DataField("Promotion", "nvarchar")]
        public string Promotion { get; set; }
        
        /// <summary>
        /// Memo
        /// </summary>		
        [DataField("Memo", "nvarchar")]
        [Custom("GridCol", "Memo", "备注")]
        public string Memo { get; set; }
    }
}