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
    public partial class fmLoading : Form,ISplashForm
    {
        public fmLoading()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.ControlBox = false;   // 设置不出现关闭按钮
        }

        //实现接口方法，主要用于接口的反射调用
        #region ISplashForm
        void ISplashForm.SetStatusInfo(string NewStatusInfo)
        {
            lbl_caption.Text = NewStatusInfo;
        }
        #endregion
    }
}
