using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WhatYouWant
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //登陆界面
            WhatYouWant.Splasher.Show(typeof(WhatYouWant.fmLoading));
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.Run(new fmUsefulInfo());

        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs ex)
        {
            //LogHelper.Error(ex.Exception);

            string message = string.Format("{0}\r\n操作发生错误，您需要退出系统么？", ex.Exception.Message);
            if (DialogResult.Yes == MessageBox.Show(message, "系统错误", MessageBoxButtons.YesNo))
            {
                Application.Exit();
            }
        }

    }
}
