using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDolls.Data.Entity;

namespace NShop.Service
{
    public class MemberService
    {
        public static NDolls.Data.IRepository<NShop.Model.sdpost_Member> r =
            NDolls.Data.RepositoryFactory<NShop.Model.sdpost_Member>.CreateRepository("NShop.Model.sdpost_Member");


        public static NDolls.Data.IRepository<NShop.Model.NShop_MemberCostume> r1 =
            NDolls.Data.RepositoryFactory<NShop.Model.NShop_MemberCostume>.CreateRepository("NShop.Model.NShop_MemberCostume");

        public bool SaveMemberCostume(NShop.Model.NShop_MemberCostume m)
        {
            return r1.AddOrUpdate(m);
        }

        public NShop.Model.NShop_MemberCostume GetMemberCostume(String id)
        {
            return r1.FindByPK(id);
        }

        public bool AddMember(NShop.Model.sdpost_Member m)
        {
            return r.Add(m);
        }

        public bool UpdateMember(NShop.Model.sdpost_Member m)
        {
            return r.Update(m);
        }

        public bool SaveMember(NShop.Model.sdpost_Member m)
        {
            return r.AddOrUpdate(m);
        }

        public NShop.Model.sdpost_Member GetMember(String id)
        {
            return r.FindByPK(id);
        }

        public NShop.Model.sdpost_Member GetMemberByMemberNo(String memberNo)
        {
            List<Item> list = new List<Item>();
            list.Add(new ConditionItem("MemberNo", memberNo, SearchType.Accurate));
            return r.FindByCondition(list)[0];
        }

        public List<NShop.Model.sdpost_Member> GetMembers(NShop.Model.sdpost_Member m)
        {
            return r.Find(m);
        }

        public List<NShop.Model.sdpost_Member> GetMemberNoPhone(String key)
        {
            key = NDolls.Core.Util.ValidateUtil.FilterIllegal(key);
            return r.Find("MemberNo='" + key + "' OR PhoneNo='" + key + "' OR MemberName LIKE '" + key + "%' OR ShortCode LIKE '" + key + "%'");
        }


        public String ValidateUnique(NShop.Model.sdpost_Member m)
        {
            List<Item> list = new List<Item>();
            list.Add(new ConditionItem("MemberNo", m.MemberNo, SearchType.Accurate));
            list.Add(new ConditionItem("ID", m.ID, SearchType.Unequal));
            if (r.Exist(list))
            {
                return "已存在该会员号，不允许重复";
            }
            
            list = new List<Item>();
            list.Add(new ConditionItem("PhoneNo", m.PhoneNo, SearchType.Accurate));
            list.Add(new ConditionItem("ID", m.ID, SearchType.Unequal));
            if (r.Exist(list))
            {
                return "已存在该手机号，不允许重复";
            }

            return "";
        }

        public String Validate(NShop.Model.sdpost_Member m)
        {
            String err = r.Validate(m);
            if(String.IsNullOrEmpty(err))
            {
                err = ValidateUnique(m);
            }

            return err;
        }
    }
}
