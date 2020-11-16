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
    public partial class fmSetModelType : Form
    {
        List<string> confList = new List<string>();
        public fmSetModelType()
        {
            InitializeComponent();
            this.CenterToParent();
        }

        private void fmSetModelType_Load(object sender, EventArgs e)
        {
            pubFunction.CheckFileExists(pubDefines.allPathDefine.mainConfigPath, pubDefines.allNameDefine.name_ModelType);
            //显示信息
            ShowMain();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowMain()
        {
            string msg = string.Empty;
            confList = pubFunction.ReadContentFromTxtToLList(pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_ModelType, out msg);
            listFl.Items.Clear();
            if (confList.Count > 0)
            {
                foreach (var item in confList)
                {
                    listFl.Items.Add(item);
                }
            }
        }

        private void btnQd_Click(object sender, EventArgs e)
        {
            if (edtName.Text == "")
            {
                MessageBox.Show("请输入名称");
                return;
            }
            if (confList.IndexOf(edtName.Text) >= 0)
            {
                MessageBox.Show("已经有过该分类了");
                return;
            }
            //保存config配置
            string msg = string.Empty;
            string configName = pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_ModelType;
            confList = pubFunction.ReadContentFromTxtToLList(pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_ModelType, out msg);
            string writeContent = string.Empty;
            if (confList.Count > 0)
            {
                int index = 1;
                foreach (var item in confList)
                {
                    if (index < confList.Count)
                        writeContent += item + "\r\n";
                    else
                        writeContent += item;
                    index++;
                }
                writeContent += "\r\n" + edtName.Text;
            }
            else
            {
                writeContent += edtName.Text;
            }
            if (pubFunction.WriteContentToTxt(pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_ModelType, writeContent, out msg))
            {
                ShowMain();
            }
            else
            {
                MessageBox.Show(msg);
                return;
            }
        }
    }
}
