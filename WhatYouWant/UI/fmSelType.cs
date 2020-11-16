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
    public partial class fmSelType : Form
    {
        private int useType = 0;
        internal int useMode
        {
            get { return this.useType; }
        }

        public fmSelType()
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
            if (rgType.SelectedIndex<0)
            {
                MessageBox.Show("请选择类型！");
                return;
            }
            this.useType = rgType.SelectedIndex;
            this.DialogResult = DialogResult.OK;
        }
    }
}
