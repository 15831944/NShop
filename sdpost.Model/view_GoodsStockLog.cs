using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using NDolls.Data.Attribute;
using NDolls.Data.Entity;

namespace NShop.Model
{
    [Entity("view_GoodsStockLog", "ID")]
    public class view_GoodsStockLog : EntityBase
    {
        /// <summary>
        /// ID
        /// </summary>		
        [DataField("ID", "nvarchar")]
        [Validate("不允许为空")]
        [Custom("GridCol", "ID", "编号", "invisible")]
        public string ID { get; set; }

        /// <summary>
        /// GoodsID
        /// </summary>		
        [DataField("GoodsID", "nvarchar")]
        [Custom("GridCol", "GoodsID", "商品编号", "invisible")]
        public string GoodsID { get; set; }

        /// <summary>
        /// GoodsName
        /// </summary>		
        [DataField("GoodsName", "nvarchar")]
        [Custom("GridCol", "GoodsName", "商品名称")]
        public string GoodsName { get; set; }

        /// <summary>
        /// BarCode
        /// </summary>		
        [DataField("BarCode", "nvarchar")]
        [Custom("GridCol", "BarCode", "商品条码")]
        public string BarCode { get; set; }

        /// <summary>
        /// ShortCode
        /// </summary>		
        [DataField("ShortCode", "nvarchar")]
        public string ShortCode { get; set; }

        /// <summary>
        /// Category
        /// </summary>		
        [DataField("Category", "nvarchar")]
        [Custom("GridCol", "Category", "商品分类")]
        public string Category { get; set; }

        /// <summary>
        /// Supplier
        /// </summary>		
        [DataField("Supplier", "nvarchar")]
        [Custom("GridCol", "Supplier", "供应商")]
        public string Supplier { get; set; }

        /// <summary>
        /// Brand
        /// </summary>		
        [DataField("Brand", "nvarchar")]
        [Custom("GridCol", "Brand", "商品品牌")]
        public string Brand { get; set; }

        /// <summary>
        /// PreStock
        /// </summary>		
        [DataField("PreStock", "integer")]
        public int PreStock { get; set; }

        /// <summary>
        /// Variation
        /// </summary>		
        [DataField("Variation", "integer")]
        [Custom("GridCol", "Variation", "库存变化量")]
        public int Variation { get; set; }

        /// <summary>
        /// AfterStock
        /// </summary>		
        [DataField("AfterStock", "integer")]
        [Custom("GridCol", "AfterStock", "调整后库存量")]
        public int AfterStock { get; set; }

        /// <summary>
        /// StockMark
        /// </summary>		
        [DataField("StockMark", "nvarchar")]
        [Custom("GridCol", "StockMark", "调整说明")]
        public string StockMark { get; set; }

        /// <summary>
        /// Status
        /// </summary>		
        [DataField("Status", "integer")]
        public int Status { get; set; }

        /// <summary>
        /// Memo
        /// </summary>		
        [DataField("Memo", "nvarchar")]
        [Custom("GridCol", "Memo", "调整原因")]
        public string Memo { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>		
        [DataField("CreateTime", "datetime")]
        [Custom("GridCol", "CreateTime", "调整时间")]
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