using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatYouWant
{
    public partial class fmPhoneEdit : Form
    {
        public fmPhoneEdit()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            if (edtPhone.Text == "")
            {
                MessageBox.Show("请输入您要查询的手机号码！");
                return;
            }
            if (edtPhone.Text.Length != 11)
            {
                MessageBox.Show("您输入的手机号有误，请检查！");
                return;
            }
            ApiUtils apiGet = new ApiUtils();
            object obj = null;
            apiGet.ApiData_Get(PubApi.ApiTypeEnum.ApiMobileInfo,out obj, edtPhone.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
