using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using NDolls.Data.Attribute;
using NDolls.Data.Entity;
namespace NShop.Model
{
    [Entity("Account", "AccountType")]
    public class sdpost_Account : EntityBase
    {
        /// <summary>
        /// 账户类别(来自哪个应用的账户)
        /// </summary>		
        [DataField("AccountType", "nvarchar")]
        public string AccountType { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>		
        [DataField("UserName", "nvarchar")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>		
        [DataField("Password", "nvarchar")]
        public string Password { get; set; }

    }
}