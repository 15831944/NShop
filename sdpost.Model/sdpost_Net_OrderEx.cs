using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDolls.Data.Attribute;

namespace NShop.Model
{
    public partial class sdpost_Net_Order
    {
        [Association("FlowNo", "OrderID", AssociationType.Aggregation, CascadeType.ALL)]
        public List<sdpost_Net_OrderDetail> Details { get; set; }
    }
}
