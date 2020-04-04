using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDolls.Data.Attribute;

namespace NShop.Model
{
    public partial class sdpost_Order
    {
        [Association("ID","OrderID", AssociationType.Aggregation, CascadeType.UNDELETE)]
        public List<sdopst_OrderDetail> Details { get; set; }
    }
}
