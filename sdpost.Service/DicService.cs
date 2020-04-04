using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDolls.Data;
using NDolls.Data.Entity;
using System.Data;

namespace NShop.Service
{
    public class DicService
    {
        public static IRepository<Model.sys_Dictionary> r = RepositoryFactory<Model.sys_Dictionary>.CreateRepository("NShop.Model.sys_Dictionary");

        /// <summary>
        /// 按类别查询字典项信息
        /// </summary>
        /// <param name="type">字典类别</param>
        /// <returns>字典项信息</returns>
        public List<Model.sys_Dictionary> GetDicsByType(String type)
        {
            ConditionItem conditionItem = new ConditionItem("DType", type, SearchType.Accurate);
            OrderItem orderItem = new OrderItem("DName", OrderType.ASC);
            List<Item> list = new List<Item>() { conditionItem,orderItem };
            return r.FindByCondition(list);
        }

        /// <summary>
        /// 判断字典项是否存在
        /// </summary>
        /// <param name="type">分类类别</param>
        /// <param name="name">字典项名称</param>
        /// <returns></returns>
        public bool Exist(String type,String name)
        {
            List<Item> list = new List<Item>();
            ConditionItem item1 = new ConditionItem("DType", type, SearchType.Accurate);
            ConditionItem item2 = new ConditionItem("DName", name, SearchType.Accurate);
            list.Add(item1);
            list.Add(item2);

            return r.Exist(list);
        }

        /// <summary>
        /// 获取字典项类别信息
        /// </summary>
        public DataTable GetDicTypes()
        {
            return NDolls.Data.RepositoryBase<EntityBase>.Query("SELECT DISTINCT(DType) FROM sys_Dictionary");
        }

        /// <summary>
        /// 添加字典项
        /// </summary>
        public bool AddDic(Model.sys_Dictionary model)
        {
            return r.Add(model);
        }

        /// <summary>
        /// 添加字典项
        /// </summary>
        public bool UpdateDic(Model.sys_Dictionary model)
        {
            return r.Update(model);
        }

        /// <summary>
        /// 删除字典项
        /// </summary>
        public bool DeleteDic(String id)
        {
            return r.Delete(id);
        }

        /// <summary>
        /// 获取字典项信息
        /// </summary>
        public Model.sys_Dictionary GetDic(String id)
        {
            return r.FindByPK(id);
        }
    }
}
