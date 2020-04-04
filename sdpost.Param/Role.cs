using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NShop.Param
{
    public class Role
    {
        private static Dictionary<String, Dictionary<String, String>> roles = null;
        /// <summary>
        /// 角色集合
        /// </summary>
        public static Dictionary<String, Dictionary<String, String>> Roles
        {
            get 
            {
                if (roles == null)
                {
                    roles = new Dictionary<string, Dictionary<string, string>>();
                    roles.Add("Salesman", SalesmanPermission);
                }

                return Role.roles; 
            }
        }

        private static Dictionary<String, String> salesmanPermission = null;
        /// <summary>
        /// 店员角色权限
        /// </summary>
        public static Dictionary<String, String> SalesmanPermission
        {
            get 
            {
                if (salesmanPermission == null)
                {
                    salesmanPermission = new Dictionary<string, string>();
                    salesmanPermission.Add("NShop.Main","");//主界面
                    salesmanPermission.Add("NShop.sale.saleForm", "");//销售
                    salesmanPermission.Add("NShop.Manage.SaleDetail", "");//销售明细
                    salesmanPermission.Add("NShop.Manage.SaleList", "btnSearch,btnRefund,btnPrint");//销售流水
                    salesmanPermission.Add("NShop.Manage.GoodsList", "btnAdd,btnSearch");//商品销售
                    salesmanPermission.Add("NShop.Manage.GoodsMng", "btnClose,btnSave");//商品销售
                    salesmanPermission.Add("NShop.Manage.GoodsInList", "btnSearch");//商品入库
                    salesmanPermission.Add("NShop.Manage.MemberList", "btnAdd,btnSearch,btnClear");//会员管理
                    salesmanPermission.Add("NShop.Manage.MemberMng", "btnClose,btnSave");//会员管理
                    salesmanPermission.Add("NShop.sale.backsaleForm", "");
                }

                return Role.salesmanPermission; 
            }
        }
    }
}
