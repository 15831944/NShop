using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using NDolls.Data.Attribute;
using NDolls.Data.Entity;

namespace NShop.Model
{
    [Entity("sys_Dictionary", "DID")]
    public class sys_Dictionary : EntityBase
    {

        /// <summary>
        /// DID
        /// </summary>		
        [DataField("DID", "nvarchar")]
        [Validate("")]
        [Custom("GridCol", "DID", "字典项编号", "invisible")]
        public string DID { get; set; }

        /// <summary>
        /// DType
        /// </summary>		
        [DataField("DType", "nvarchar")]
        [Custom("GridCol", "DType", "字典类别")]
        [Validate("类别名称")]
        public string DType { get; set; }

        /// <summary>
        /// DName
        /// </summary>		
        [DataField("DName", "nvarchar")]
        [Custom("GridCol", "DName", "字典项名称")]
        [Validate("类别项名称")]
        public string DName { get; set; }

        /// <summary>
        /// Sequence
        /// </summary>		
        [DataField("Sequence", "nvarchar")]
        [Custom("GridCol", "Sequence", "排列顺序")]
        public string Sequence { get; set; }

        /// <summary>
        /// ExtDLL
        /// </summary>		
        [DataField("ExtDLL", "nvarchar")]
        public string ExtDLL { get; set; }

        /// <summary>
        /// Memo
        /// </summary>		
        [DataField("Memo", "nvarchar")]
        [Custom("GridCol", "Memo", "备注")]
        public string Memo { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>		
        [DataField("CreateTime", "datetime")]
        [Custom("GridCol", "CreateTime", "创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// UpdateTime
        /// </summary>		
        [DataField("UpdateTime", "datetime")]
        [Custom("GridCol", "UpdateTime", "最近修改时间")]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// Modifier
        /// </summary>		
        [DataField("Modifier", "nvarchar")]
        public string Modifier { get; set; }

    }
}