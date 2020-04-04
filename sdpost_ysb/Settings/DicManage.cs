using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NShop.Sys
{
    public partial class DicManage : BaseForm
    {
        private String id = "";
        private String type = "";
        private NShop.Model.sys_Dictionary model = new NShop.Model.sys_Dictionary();
        private NShop.Service.DicService s = new NShop.Service.DicService();

        public BindingSource BSource
        { get; set; }

        public DicManage(String id,String type)
        {
            this.id = id;
            this.type = type;

            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DicManage_Load(object sender, EventArgs e)
        {
            NDolls.Forms.WinUtil.InitComboBox(varDType,"DType", "DType", s.GetDicTypes());
            varDType.Text = type;

            if (!String.IsNullOrEmpty(id))
            {
                varDType.Enabled = false;
                model = s.GetDic(id);
                NDolls.Forms.WinUtil.SetObject(groupBox1, model, "var");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NDolls.Forms.WinUtil.GetModel(groupBox1, model, "var");
            model.UpdateTime = DateTime.Now;

            if (String.IsNullOrEmpty(id))//新增
            {
                model.DID = Guid.NewGuid().ToString("N");
                model.CreateTime = DateTime.Now;
            }

            String msg = NShop.Service.DicService.r.Validate(model);
            if (!String.IsNullOrEmpty(msg))
            {
                Controls.Find("var" + msg.Split(',')[0],true)[0].Focus();
                MessageBox.Show(msg.Split(',')[1]);
                return;
            }

            if (String.IsNullOrEmpty(id))
            {
                if (s.AddDic(model))
                {
                    id = model.DID;
                    Funs.GridUtil.AppendRow<NShop.Model.sys_Dictionary>(BSource, model);
                    //BSource.Add(model);
                    MessageBox.Show("添加成功");
                }
            }
            else
            {
                if (s.UpdateDic(model))
                {
                    Funs.GridUtil.UpdateRow(BSource, model);
                    MessageBox.Show("修改成功");
                }
            }
        }
    }
}
