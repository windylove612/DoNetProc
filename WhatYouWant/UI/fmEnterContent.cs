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
    public partial class fmEnterContent : Form
    {
        private string strValue = string.Empty;
        private string strName = string.Empty;
        private string strMemo = string.Empty;
        private string strDetail = string.Empty;

        internal string StrValue
        {
            get { return this.strValue; }
        }
        internal string StrName
        {
            get { return this.strName; }
        }
        internal string StrMemo
        {
            get { return this.strMemo; }
        }
        internal string StrDetail
        {
            get { return this.strDetail; }
        }

        public fmEnterContent()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if ((edtValue.Text.Trim() == "") || (edtName.Text.Trim() == ""))
            {
                MessageBox.Show("代码值或属性值不能为空！");
                return;
            }
            this.strValue = edtValue.Text.Trim();
            this.strName = edtName.Text.Trim();
            this.strMemo = memoContent.Text;
            this.strDetail = memoDetail.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
