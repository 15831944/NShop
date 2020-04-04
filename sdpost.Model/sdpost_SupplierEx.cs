using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDolls.Data.Attribute;

namespace NShop.Model
{
    public partial class sdpost_Supplier
    {
        /// <summary>
        /// 供应商商品
        /// </summary>
        [Association("SID", "SID", AssociationType.Aggregation, CascadeType.SELECT)]
        public List<sdpost_SupplierGoods> Goods { get; set; }
    }
}
