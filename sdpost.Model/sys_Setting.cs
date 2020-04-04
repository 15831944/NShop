using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using NDolls.Data.Attribute;
using NDolls.Data.Entity;

namespace NShop.Model
{
    [Entity("sys_Setting", "SKey")]
    public class sys_Setting : EntityBase
    {

        /// <summary>
        /// SKey
        /// </summary>		
        [DataField("SKey", "nvarchar")]
        [Validate("")]
        public string SKey { get; set; }

        /// <summary>
        /// SValue
        /// </summary>		
        [DataField("SValue", "nvarchar")]
        public string SValue { get; set; }

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