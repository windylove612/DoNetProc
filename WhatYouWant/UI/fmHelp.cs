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
    public partial class fmHelp : Form
    {
        public fmHelp()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void fmHelp_Load(object sender, EventArgs e)
        {
            string sHelpStr = string.Empty;
            sHelpStr += "各种第三方接口调用玩耍请按F5~" + "\r\n";
            sHelpStr += "已设置快捷热键定义查看请按F11~" + "\r\n";
            memoEdit1.Text = sHelpStr;
            memoEdit1.Select(0, 0);
        }
    }
}
