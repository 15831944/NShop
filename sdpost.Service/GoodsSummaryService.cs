using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDolls.Data;

namespace NShop.Service
{
    public class GoodsSummaryService 
    {
        public static IRepository<Model.view_GoodsSummary> r = RepositoryFactory<Model.view_GoodsSummary>.CreateRepository("NShop.Model.view_GoodsSummary"); 

        public NShop.Model.view_GoodsSummary GetModel()
        {
            List<Model.view_GoodsSummary> list = r.FindAll();
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }
    }
}
