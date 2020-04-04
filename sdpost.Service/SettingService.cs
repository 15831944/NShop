using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDolls.Data;
using NDolls.Core;

namespace NShop.Service
{
    public class SettingService
    {
        public static IRepository<Model.Setting> r = RepositoryFactory<Model.Setting>.CreateRepository("NShop.Model.Setting");

        public bool Add(Model.Setting setting)
        {
            return r.Add(setting);
        }

        public bool AddorUpdate(Model.Setting setting)
        {
            return r.AddOrUpdate(setting);
        }

        public bool update(Model.Setting setting)
        {
            return r.Update(setting);
        }

        public List<Model.Setting> findall()
        {
            return r.FindAll();
        }

        public List<Model.Setting> GetSettings(String key)
        {
            List<NDolls.Data.Entity.Item> items = new List<NDolls.Data.Entity.Item>();
            items.Add(new NDolls.Data.Entity.ConditionItem("SKey", key, NDolls.Data.Entity.SearchType.Fuzzy));//条件项

            return r.FindByCondition(items);
        }

        public Model.Setting GetSetting(string key)
        {
            return r.FindByPK(key);
        }

        public Model.Setting get(string pkey)
        {
            return r.FindByPK(pkey);
        }

        public List<Model.Setting> findbycondition(List<NDolls.Data.Entity.Item> items)
        {
            //List<NDolls.Data.Entity.Item> items = new List<NDolls.Data.Entity.Item>();
            //items.Add(new NDolls.Data.Entity.ConditionItem("ID", orderID, NDolls.Data.Entity.SearchType.Accurate));//条件项

            return r.FindByCondition(items);
        }
    }
}
