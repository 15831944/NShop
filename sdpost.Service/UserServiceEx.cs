using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NDolls.Data;

namespace NShop.Service
{
    public partial class UserService
    {
        public DataTable FindBySQL(String sql)
        {
            return RepositoryBase<NDolls.Data.Entity.EntityBase>.Query(sql);
        }
    }
}
