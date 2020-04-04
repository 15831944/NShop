using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDolls.Data;

namespace NShop.Service
{
    public class SupplierService : ServiceBase<NShop.Model.sdpost_Supplier>
    {
        public List<NShop.Model.sdpost_Supplier> GetModels(String keywords)
        {
            keywords = NDolls.Core.Util.ValidateUtil.FilterIllegal(keywords);
            return r.Find("SName LIKE '%" + keywords + "%' OR ShortCode LIKE '%" + keywords + "%'");
        }
    }
}
