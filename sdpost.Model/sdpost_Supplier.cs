using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using NDolls.Data.Attribute;
using NDolls.Data.Entity;

namespace NShop.Model
{
    [Entity("sdpost_Supplier", "SID")]
    public partial class sdpost_Supplier : EntityBase
    {

        /// <summary>
        /// SID
        /// </summary>		
        [DataField("SID", "nvarchar")]
        [Validate("不允许为空")]
        [Custom("GridCol", "SID", "系统编号", "invisible")]
        public string SID { get; set; }

        /// <summary>
        /// SName
        /// </summary>		
        [DataField("SName", "nvarchar")]
        [Custom("GridCol", "SName", "供应商名称")]
        public string SName { get; set; }

        /// <summary>
        /// ShortCode
        /// </summary>		
        [DataField("ShortCode", "nvarchar")]
        [Custom("GridCol", "ShortCode", "助记码")]
        public string ShortCode { get; set; }

        /// <summary>
        /// SAddress
        /// </summary>		
        [DataField("SAddress", "nvarchar")]
        [Custom("GridCol", "SAddress", "供应商地址")]
        public string SAddress { get; set; }

        /// <summary>
        /// SPhone
        /// </summary>		
        [DataField("SPhone", "nvarchar")]
        [Custom("GridCol", "SPhone", "联系电话")]
        public string SPhone { get; set; }

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