using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDolls.Data;
using NDolls.Core;
using NDolls.Data.Entity;
using NShop;

namespace NShop.Service
{
    public partial class UserService : ServiceBase<NShop.Model.SYS_User>
    {

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>是否添加成功</returns>
        public bool AddUser(NShop.Model.SYS_User user)
        {
            return r.Add(user);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user">用户账号</param>
        /// <returns>是否删除成功</returns>
        public bool DeleteUser(String userName)
        {
            return r.Delete(userName);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>是否修改成功</returns>
        public bool UpdateUser(NShop.Model.SYS_User user)
        {
            return r.Update(user);
        }

        public bool SaveUser(Model.SYS_User user)
        {
            return r.AddOrUpdate(user);
        }

        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns>用户数据列表</returns>
        public IList<NShop.Model.SYS_User> GetUsers(List<Item> list)
        {
            return r.FindByCondition(list);
        }

        public NShop.Model.SYS_User GetUser(String userName)
        {
            return r.FindByPK(userName);
        }

        public NShop.Model.SYS_User GetUser(String userName,String password)
        {
            List<Item> list = new List<Item>();
            list.Add(new ConditionItem("UserName", userName, SearchType.Accurate));
            list.Add(new ConditionItem("Password", password, SearchType.Accurate));
            List<NShop.Model.SYS_User> uList = r.FindByCondition(list);
            if (uList != null && uList.Count > 0) return uList[0];
            else return null;
        }
    }

}
