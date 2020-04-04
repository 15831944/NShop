using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Automation;
using System.Threading;

namespace NShop.Funs
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class Automation
    {
        ///<summary>
        ///根据传入的路径启动相应的可执行程序，并返回进程ID
        ///</summary>
        public static Int32 StartExe(string strExePath)
        {
            if (null == strExePath)
            {
                return 0;
            }

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = strExePath;
            psi.UseShellExecute = false;
            psi.WorkingDirectory = strExePath.Substring(0, strExePath.LastIndexOf('\\'));
            psi.CreateNoWindow = true;
            Process ps = Process.Start(psi);
            Thread.Sleep(1000);

            return ps.Id;
        }

        ///<summary>
        ///根据进程ＩＤ，查找相应窗体，并返回窗体句柄
        ///</summary>
        public static AutomationElement GetWindowHandle(Int32 pid, int iWaitSecond)
        {
            AutomationElement targetWindow = null;
            int iWaitTime = 0;

            try
            {
                Process ps = Process.GetProcessById(pid);

                targetWindow = AutomationElement.FromHandle(ps.MainWindowHandle);

                while (null == targetWindow)
                {
                    if (iWaitTime > iWaitSecond)
                    {
                        break;
                    }

                    Thread.Sleep(500);

                    targetWindow = AutomationElement.FromHandle(ps.MainWindowHandle);
                }

                return targetWindow;
            }
            catch (System.Exception ex)
            {
                string msg = "没有找到指定的窗口，请确认窗口已经启动！";

                throw new InvalidProgramException(msg, ex);
            }
        }

        ///<summary>
        ///根据窗口句柄以及TextEdit的AutomationID，返回TextEdit句柄
        ///</summary>
        public static AutomationElement GetTextEditHandle(AutomationElement parentWindowHandle, string sAutomationID)
        {
            PropertyCondition condition = null;
            PropertyCondition codEdit = null;
            AndCondition andConditon = null;
            AutomationElement targetEditHandle = null;

            try
            {
                if (null == parentWindowHandle)
                {
                    return null;
                }

                condition = new PropertyCondition(AutomationElement.AutomationIdProperty, sAutomationID);
                codEdit = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit);
                andConditon = new AndCondition(condition, codEdit);

                targetEditHandle = parentWindowHandle.FindFirst(TreeScope.Children, andConditon);

                return targetEditHandle;
            }
            catch (System.Exception ex)
            {
                string msg = "没有找到指定的TextEdit，请确认TextEdit的AutomationID是否正确！";

                throw new InvalidProgramException(msg, ex);
            }
        }

        ///<summary>
        ///根据窗口句柄以及ComboBox的AutomationID，返回TextEdit句柄
        ///</summary>
        public static AutomationElement GetComboBoxHandle(AutomationElement parentWindowHandle, string sAutomationID)
        {
            PropertyCondition condition = null;
            PropertyCondition codEdit = null;
            AndCondition andConditon = null;
            AutomationElement targetEditHandle = null;

            try
            {
                if (null == parentWindowHandle)
                {
                    return null;
                }

                condition = new PropertyCondition(AutomationElement.AutomationIdProperty, sAutomationID);
                codEdit = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ComboBox);
                andConditon = new AndCondition(condition, codEdit);

                targetEditHandle = parentWindowHandle.FindFirst(TreeScope.Children, andConditon);

                return targetEditHandle;
            }
            catch (System.Exception ex)
            {
                string msg = "没有找到指定的ComboBox，请确认ComboBox的AutomationID是否正确！";

                throw new InvalidProgramException(msg, ex);
            }
        }

        ///<summary>
        ///根据TextEdit句柄，在TextEdit内填写数据
        ///只能设置单行输入的TextEdit
        ///</summary>
        public static bool SetTextEditData(AutomationElement TextEditHandle, string strData)
        {
            ValuePattern vpTextEdit = null;

            if (!TextEditHandle.Current.IsEnabled)
            {
                throw new InvalidOperationException("The control is not enabled.\n\n");
            }

            if (!TextEditHandle.Current.IsKeyboardFocusable)
            {
                throw new InvalidOperationException("The control is not focusable.\n\n");
            }

            vpTextEdit = TextEditHandle.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            if (null == vpTextEdit)
            {
                return false;
            }

            if (vpTextEdit.Current.IsReadOnly)
            {
                throw new InvalidOperationException("The control is read-only.");
            }

            vpTextEdit.SetValue(strData);

            return true;
        }

        ///<summary>
        ///根据窗口句柄以及Button的AutomationID，返回Button的句柄
        ///</summary>
        public static AutomationElement GetButtonHandle(AutomationElement parentWindowHandle, string sAutomationID)
        {
            PropertyCondition condition = null;
            PropertyCondition codButton = null;
            AndCondition andConditon = null;
            AutomationElement targetButtonHandle = null;

            try
            {
                if (null == parentWindowHandle)
                {
                    return null;
                }

                condition = new PropertyCondition(AutomationElement.AutomationIdProperty, sAutomationID);
                codButton = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button);
                andConditon = new AndCondition(condition, codButton);

                targetButtonHandle = parentWindowHandle.FindFirst(TreeScope.Children, andConditon);

                return targetButtonHandle;
            }
            catch (System.Exception ex)
            {
                string msg = "没有找到指定的按钮，请确认按钮AutomationID是否正确！";

                throw new InvalidProgramException(msg, ex);
            }
        }

        ///<summart>
        ///根据Button按钮句柄，进行鼠标左键单击
        ///</summary>
        public static bool ButtonLeftClick(AutomationElement ButtonHandle)
        {
            object objButton = null;
            InvokePattern ivkpButton = null;

            try
            {
                if (null == ButtonHandle)
                {
                    return false;
                }

                if (!ButtonHandle.TryGetCurrentPattern(InvokePattern.Pattern, out objButton))
                {
                    return false;
                }

                ivkpButton = (InvokePattern)objButton;

                ivkpButton.Invoke();

                return true;
            }
            catch (System.Exception ex)
            {
                string msg = "鼠标左键单击失败！";

                throw new InvalidProgramException(msg, ex);
            }
        }

        ///<summary>
        ///根据窗口句柄以及ListBox控件AutomationID，返回该ListBox控件句柄
        ///</summary>
        public static AutomationElement GetListBoxHandle(AutomationElement parentWindowHandle, string sAutomationID)
        {
            AutomationElement ListBoxHandle = null;
            PropertyCondition NameCondition = null;
            PropertyCondition TypeCondition = null;
            AndCondition andCondition = null;

            if (null == parentWindowHandle || null == sAutomationID)
            {
                return null;
            }

            NameCondition = new PropertyCondition(AutomationElement.AutomationIdProperty, sAutomationID);
            TypeCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.List);
            andCondition = new AndCondition(NameCondition, TypeCondition);

            ListBoxHandle = parentWindowHandle.FindFirst(TreeScope.Children, andCondition);
            if (null == ListBoxHandle)
            {
                return null;
            }

            return ListBoxHandle;
        }

        ///<summary>
        ///根据ListBox控件句柄以及ItemCount，选择该Item
        ///</summary>
        public static string GetListBoxItemName(AutomationElement ListBoxHandle, int iItemCount)
        {
            AutomationElementCollection ListBoxHandleCollection = null;
            PropertyCondition TypeCondition = null;

            if (null == ListBoxHandle || 0 > iItemCount)
            {
                return null;
            }

            TypeCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem);

            ListBoxHandleCollection = ListBoxHandle.FindAll(TreeScope.Children, TypeCondition);
            if (null == ListBoxHandleCollection)
            {
                return null;
            }

            if (iItemCount >= ListBoxHandleCollection.Count)
            {
                return null;
            }

            return ListBoxHandleCollection[iItemCount].Current.Name;
        }

        ///<summary>
        ///根据窗口句柄，以及MenuBar控件AutomationID，返回该MenuBar控件句柄
        ///</summary>
        public static AutomationElement GetMenuBarHandle(AutomationElement parentWindow, string sAutomationID)
        {
            AutomationElement MBHandle = null;
            PropertyCondition NameCondition = null;
            PropertyCondition TypeCondition = null;
            AndCondition andCondition = null;

            if (null == parentWindow || null == sAutomationID)
            {
                return null;
            }

            NameCondition = new PropertyCondition(AutomationElement.AutomationIdProperty, sAutomationID);
            TypeCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuBar);
            andCondition = new AndCondition(NameCondition, TypeCondition);

            MBHandle = parentWindow.FindFirst(TreeScope.Children, andCondition);
            if (null == MBHandle)
            {
                return null;
            }

            return MBHandle;
        }

        ///<summary>
        ///根据MenuBar控件句柄以及一级菜单名称，弹出一级菜单
        ///</summary>
        private static AutomationElement PopupMenuBarItem(AutomationElement MBHandle, string FirMenuTitle)
        {
            InvokePattern IPMenu = null;
            AutomationElement MenuHandle = null;
            PropertyCondition NameCondition = null;
            PropertyCondition TypeCondition = null;
            AndCondition andCondition = null;

            if (null == MBHandle || null == FirMenuTitle)
            {
                return null;
            }

            NameCondition = new PropertyCondition(AutomationElement.NameProperty, FirMenuTitle);
            TypeCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem);
            andCondition = new AndCondition(NameCondition, TypeCondition);

            MenuHandle = MBHandle.FindFirst(TreeScope.Children, andCondition);
            if (null == MenuHandle)
            {
                return null;
            }

            IPMenu = MenuHandle.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            if (null == IPMenu)
            {
                return null;
            }

            IPMenu.Invoke();

            return MenuHandle;
        }

        ///<summary>
        ///根据MenuBar控件句柄以及传入的菜单名称，选择相应的菜单
        ///传入的菜单名称，必须以空字符串结束
        ///</summary>
        public static bool SelectMenuBarItem(AutomationElement MBHandle, string[] strTitle)
        {
            AutomationElement MenuItemHandle = null;

            MenuItemHandle = MBHandle;

            foreach (string str in strTitle)
            {
                if ("" == str)
                {
                    break;
                }

                MenuItemHandle = PopupMenuBarItem(MenuItemHandle, str);
                if (null == MenuItemHandle)
                {
                    return false;
                }

                Thread.Sleep(400);
            }

            return true;
        }

        /// <summary>
        /// 通过按钮名称，获取按钮对象.
        /// </summary>
        /// <param name="name">按钮名称</param>
        /// <returns></returns>
        public static AutomationElement GetButtonControl(AutomationElement parentWindowHandle, String name)
        {
            //AutomationElementCollection panes = parentWindowHandle.FindAll(TreeScope.Children,
            //new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Pane));

            //// 获取主窗体上的所有按钮.
            //AutomationElementCollection testAllButtons = panes[0].FindAll(TreeScope.Children,
            //new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button));

            // 获取主窗体上的所有按钮.
            AutomationElementCollection testAllButtons = parentWindowHandle.FindAll(TreeScope.Children,
            new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button));

            foreach (AutomationElement element in testAllButtons)
            {
                if (element.Current.Name == name)
                {
                    return element;
                }
            }
            // 遍历所有都没有检索到，返回NULL.
            return null;
        }

        /// <summary>
        /// 通过Panel名称，获取Panel对象.
        /// </summary>
        /// <param name="name">按钮名称</param>
        public static AutomationElement GetPanelControl(AutomationElement parentWindowHandle, String name)
        {
            // 获取主窗体上的所有按钮.
            AutomationElementCollection testAllButtons = parentWindowHandle.FindAll(TreeScope.Children,
            new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Pane));

            foreach (AutomationElement element in testAllButtons)
            {
                if (element.Current.Name == name)
                {
                    return element;
                }
            }
            // 遍历所有都没有检索到，返回NULL.
            return null;
        }

    }
}
