using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using NDolls.Data.Attribute;
using NDolls.Data.Entity;
namespace NShop.Model
{
    [Entity("sdpost_StockLog", "ID")]
    public class sdpost_StockLog : EntityBase
    {

        /// <summary>
        /// 系统编号
        /// </summary>		
        [DataField("ID", "nvarchar")]
        [Validate("不允许为空")]
        public string ID { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>		
        [DataField("GoodsID", "nvarchar")]
        public string GoodsID { get; set; }

        /// <summary>
        /// 变化前库存量
        /// </summary>		
        [DataField("PreStock", "integer")]
        public int PreStock { get; set; }

        /// <summary>
        /// 库存变化量
        /// </summary>		
        [DataField("Variation", "integer")]
        public int Variation { get; set; }

        /// <summary>
        /// 变化后库存量
        /// </summary>		
        [DataField("AfterStock", "integer")]
        public int AfterStock { get; set; }

        /// <summary>
        /// 库存变动说明
        /// </summary>
        [DataField("StockMark", "integer")]
        public String StockMark { get; set; }

        /// <summary>
        /// Status
        /// </summary>		
        [DataField("Status", "integer")]
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