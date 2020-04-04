using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using NDolls.Data.Attribute;
using NDolls.Data.Entity;

namespace NShop.Model
{
    [Entity("sdpost_SupplierGoods", "SID,GoodsID")]
    public class sdpost_SupplierGoods : EntityBase
    {

        /// <summary>
        /// SID
        /// </summary>		
        [DataField("SID", "nvarchar")]
        [Validate("不允许为空")]
        [Custom("GridCol", "SID", "系统编号", "invisible")]
        public string SID { get; set; }

        /// <summary>
        /// GoodsID
        /// </summary>		
        [DataField("GoodsID", "nvarchar")]
        [Validate("不允许为空")]
        [Custom("GridCol", "GoodsID", "商品编号", "invisible")]
        public string GoodsID { get; set; }

        /// <summary>
        /// GoodsName
        /// </summary>		
        [DataField("GoodsName", "nvarchar")]
        [Custom("GridCol", "GoodsName", "商品名称")]
        public string GoodsName { get; set; }

        /// <summary>
        /// GoodsBrand
        /// </summary>		
        [DataField("GoodsBrand", "nvarchar")]
        [Custom("GridCol", "GoodsBrand", "商品品牌")]
        public string GoodsBrand { get; set; }

        /// <summary>
        /// BuyingPrice
        /// </summary>		
        [DataField("BuyingPrice", "float")]
        [Custom("GridCol", "BuyingPrice", "商品进价")]
        public decimal BuyingPrice { get; set; }

        /// <summary>
        /// SalePrice
        /// </summary>		
        [DataField("SalePrice", "float")]
        public decimal SalePrice { get; set; }

        /// <summary>
        /// Status
        /// </summary>		
        [DataField("Status", "int")]
        public int Status { get; set; }

        /// <summary>
        /// Memo
        /// </summary>		
        [DataField("Memo", "nvarchar")]
        public string Memo { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>		
        [DataField("CreateTime", "datetime")]
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
        public string Modifier { get; set; }

    }
}