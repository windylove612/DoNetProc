using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace WhatYouWant
{
    public partial class fmKuaiDi : Form
    {
        public fmKuaiDi()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        public class ComboxItem
        {
            public string Text = "";
            public string Value = "";
            public override string ToString()
            {
                return Text.Trim();
            }
        }

        private void InitControls()
        {
            PubApi apiProcess = new PubApi();
            comKd.Properties.Items.Clear();
            foreach (PubApi.ApiExpressType item in Enum.GetValues(typeof(PubApi.ApiExpressType)))
            {
                comKd.Properties.Items.Add(new ComboxItem() { Value = item.ToString(), Text = apiProcess.GetEnumDescription(item) });
            }
        }

        private void fmKuaiDi_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            if (comKd.SelectedIndex < 0)
            {
                MessageBox.Show("请选择快递公司！");
                return;
            }
            if (edtKdh.Text == "")
            {
                MessageBox.Show("请输入快递单号！");
                return;
            }
            ComboxItem item = comKd.SelectedItem as ComboxItem;
            ApiUtils apiGet = new ApiUtils();
            object obj = null;
            if (apiGet.ApiData_Get(PubApi.ApiTypeEnum.ApiExpressInfo, out obj, item.Value, edtKdh.Text))
            {
                if (obj != null)
                {
                    apiDataObject.ExpressInfoObj dataInfo = obj as apiDataObject.ExpressInfoObj;
                    if (dataInfo.status != "200")
                    {
                        MessageBox.Show("查询失败！");
                        return;
                    }
                    else
                    {
                        string sNr = string.Empty;
                        for (int i = 0; i < dataInfo.data.Count;i++ )
                        {
                            sNr += dataInfo.data[i].time+"\r\n";
                            sNr += dataInfo.data[i].context+"\r\n";
                            sNr += "------------------------------------------------------------------------\r\n";
                        }
                        memoNr.Text = sNr;
                    }
                }
            }
        }
    }
}
