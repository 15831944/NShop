using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using CustomUIControls;
using System.Reflection;

namespace NShop
{
    public partial class BaseForm : DockContent
    {
        public BaseForm()
        {
            if (Funs.Constant.UserRole != "Admin")//若不是管理员，进行权限检查
            {
                String cls = this.GetType().FullName;
                if (!Funs.Constant.RolePermission.ContainsKey(cls))
                {
                    MessageBox.Show("您没有该操作权限，请联系店长处理.");
                    this.Close();
                    return;
                }
            }

            InitializeComponent();

            this.KeyPreview = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                this.Close();
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (!this.GetType().FullName.Contains("NShop.sale") && !this.GetType().FullName.Contains("List"))//排除收银台相关模块
            {
                if ((ActiveControl is TextBox || ActiveControl is ComboBox) && keyData == Keys.Enter)
                {
                    keyData = Keys.Tab;
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            if (Funs.Constant.UserRole != "Admin")
            {
                String cls = this.GetType().FullName;
                if (Funs.Constant.RolePermission.ContainsKey(cls))
                {
                    if (Funs.Constant.RolePermission[cls] == "") return;//若是模块全权限，跳出后面的具体功能检测

                    foreach (Control c in this.Controls)
                    {
                        setPermission(c, cls);
                    }
                }
                else
                {
                    MessageBox.Show("您没有该操作权限，请联系店长处理.");
                    this.Close();
                    return;
                }
            }
        }

        private void setPermission(Control ctrl,String cls)
        {
            if (ctrl.HasChildren)
            {
                checkToolStrip(ctrl, cls);

                foreach (Control c in ctrl.Controls)
                {
                    if (c is DataGridView)
                    {
                        ClearEvents(c, "DoubleClick");
                    }

                    setPermission(c, cls);
                }
            }
            else
            {
                if (ctrl.GetType().FullName.Contains("Button") && !Funs.Constant.RolePermission[cls].Contains(ctrl.Name))
                {
                    ctrl.Visible = false;
                    //Funs.ControlUtil.ClearEvent(ctrl, "Click");
                }

                checkToolStrip(ctrl, cls);
            }
        }

        private void checkToolStrip(Control ctrl, String cls)
        {
            if (ctrl is ToolStrip)
            {
                foreach (ToolStripItem item in ((ToolStrip)ctrl).Items)
                {
                    if (item.GetType().FullName.Contains("Button") && !Funs.Constant.RolePermission[cls].Contains(item.Name))
                    {
                        item.Visible = false;
                        //Funs.ControlUtil.ClearEvent(item, "Click");
                    }
                }
            }
        }

        /// <summary>
        /// 清除一个对象的某个事件所挂钩的delegate
        /// </summary>
        /// <param name="ctrl">控件对象</param>
        /// <param name="eventName">事件名称，默认的</param>
        protected static void ClearEvents(object ctl, string eventname="All")
        {
            if (ctl == null) return;
            if (string.IsNullOrEmpty(eventname)) return;

            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Static;
            Type cType = ctl.GetType();
            PropertyInfo propertyInfo = cType.GetProperty("Events", bindingFlags);
            EventHandlerList handlerList = (EventHandlerList)propertyInfo.GetValue(ctl, null);
            EventInfo[] events = ctl.GetType().GetEvents(bindingFlags);

            foreach (EventInfo ei in events)
            {
                try
                {
                    if (eventname != "All" && eventname != ei.Name) continue;

                    FieldInfo fi = ei.DeclaringType.GetField("Event" + ei.Name, bindingFlags);
                    Delegate d = handlerList[fi.GetValue(ctl)];

                    if (d == null) continue;

                    foreach (Delegate dx in d.GetInvocationList())
                        ei.RemoveEventHandler(ctl, dx);
                }
                catch { }
            }
        }

    }
}
