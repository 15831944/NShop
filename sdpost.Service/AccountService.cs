using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDolls.Data;

namespace NShop.Service
{
    public class AccountService
    {
        public static IRepository<Model.sdpost_Account> r = RepositoryFactory<Model.sdpost_Account>.CreateRepository("NShop.Model.Account");

        public bool SaveAccount(NShop.Model.sdpost_Account model)
        {
            return r.AddOrUpdate(model);
        }
    }
}
