using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using NDolls.Data.Attribute;
using NDolls.Data.Entity;

namespace NShop.Model
{
    [Entity("sdpost_Goods", "ID")]
    public class sdpost_Net_Goods : EntityBase
    {

        /// <summary>
        /// 系统编号
        /// </summary>		
        [DataField("ID", "nvarchar")]
        [Validate("商品系统编号不允许为空")]
        [Custom("GridCol", "ID","系统编号", "invisible")]
        [Custom("SCol", "ID", "系统编号", "invisible")]
        public string ID { get; set; }

        /// <summary>
        /// BarCode
        /// </summary>		
        [DataField("BarCode", "nvarchar")]
        [Validate("商品条码不允许为空")]
        [Custom("GridCol", "BarCode", "商品条码")]
        [Custom("SCol", "BarCode", "商品条码")]
        public string BarCode { get; set; }

        /// <summary>
        /// GoodsName
        /// </summary>		
        [DataField("GoodsName", "nvarchar")]
        [Validate("商品名称不允许为空")]
        [Custom("GridCol", "GoodsName", "商品名称")]
        [Custom("SCol", "GoodsName", "商品名称")]
        public string GoodsName { get; set; }

        /// <summary>
        /// BuyingPrice
        /// </summary>		
        [DataField("BuyingPrice", "float")]
        [Validate("商品进价应大于0", "PositiveNumber")]
        [Custom("GridCol", "BuyingPrice", "商品进价")]
        [Custom("SCol", "BuyingPrice", "商品进价")]
        public decimal BuyingPrice { get; set; }

        /// <summary>
        /// RetailPrice
        /// </summary>		
        [DataField("RetailPrice", "float")]
        [Validate("商品零售价应大于0", "PositiveNumber")]
        [Custom("GridCol", "RetailPrice", "零售价")]
        public decimal RetailPrice { get; set; }

        /// <summary>
        /// MemberPrice
        /// </summary>		
        [DataField("MemberPrice", "float")]
        [Validate("商品会员价应大于0", "PositiveNumber")]
        [Custom("GridCol", "MemberPrice", "会员价")]
        public decimal MemberPrice { get; set; }

        /// <summary>
        /// Unit
        /// </summary>		
        [DataField("Unit", "nvarchar")]
        [Custom("GridCol", "Unit", "商品单位")]
        public string Unit { get; set; }

        /// <summary>
        /// 当前库存
        /// </summary>		
        [DataField("Total", "integer")]
        [Custom("GridCol", "Total", "库存量")]
        public int Total { get; set; }

        /// <summary>
        /// Category
        /// </summary>		
        [DataField("Category", "nvarchar")]
        [Custom("GridCol", "Category", "商品类别")]
        [Custom("SCol", "Category", "商品类别")]
        public string Category { get; set; }

        /// <summary>
        /// 商品品牌
        /// </summary>		
        [DataField("Brand", "nvarchar")]
        [Custom("GridCol", "Brand", "商品品牌")]
        [Custom("SCol", "Brand", "商品品牌")]
        public string Brand { get; set; }

        /// <summary>
        /// Supplier
        /// </summary>		
        [DataField("Supplier", "nvarchar")]
        [Custom("GridCol", "Supplier", "供应商")]
        public string Supplier { get; set; }

        /// <summary>
        /// Memo
        /// </summary>		
        [DataField("Memo", "nvarchar")]
        public string Memo { get; set; }

        /// <summary>
        /// UpdateTime
        /// </summary>		
        [DataField("UpdateTime", "datetime")]
        public DateTime UpdateTime { get; set; }

    }
}