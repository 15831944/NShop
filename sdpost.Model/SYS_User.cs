using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using NDolls.Data.Attribute;
using NDolls.Data.Entity;
namespace NShop.Model
{
    [Entity("SYS_User", "UserName")]
    public class SYS_User : EntityBase
    {

        /// <summary>
        /// UserName
        /// </summary>		
        [DataField("UserName", "nvarchar")]
        [Validate("用户名不允许为空")]
        [Custom("GridCol", "UserName", "用户帐号")]
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>		
        [DataField("Password", "nvarchar")]
        [Validate("用户密码不允许为空")]
        public string Password { get; set; }

        /// <summary>
        /// RealName
        /// </summary>		
        [DataField("RealName", "nvarchar")]
        [Custom("GridCol", "RealName", "店员姓名")]
        public string RealName { get; set; }

        /// <summary>
        /// UserRole
        /// </summary>		
        [DataField("Phone", "nvarchar")]
        [Custom("GridCol", "Phone", "店员手机号")]
        public string Phone { get; set; }

        /// <summary>
        /// UserRole
        /// </summary>		
        [DataField("UserRole", "nvarchar")]
        [Validate("用户角色不允许为空")]
        //[Custom("GridCol", "UserRole", "用户角色")]
        public string UserRole { get; set; }

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

        /// <summary>
        /// Status
        /// </summary>		
        [DataField("Status", "int")]
        public int Status { get; set; }

    }
}