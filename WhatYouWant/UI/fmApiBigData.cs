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
    public partial class fmApiBigData : Form
    {
        public fmApiBigData()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            fmPhoneEdit frm = new fmPhoneEdit();
            frm.ShowDialog();
        }

        private void btnKuaidi_Click(object sender, EventArgs e)
        {
            fmKuaiDi frm = new fmKuaiDi();
            frm.ShowDialog();
        }
    }
}
