using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Configuration;

namespace WhatYouWant
{
    public partial class fmSetOtherProcess : Form
    {
        List<string> modelTypeList = new List<string>();
        private bool bModify = false;
        Dictionary<string, string> hotKeyDict = new Dictionary<string, string>();
        public fmSetOtherProcess()
        {
            InitializeComponent();
            this.CenterToParent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmSetOtherProcess_Load(object sender, EventArgs e)
        {
            pubFunction.CheckFileExists(pubDefines.allPathDefine.mainConfigPath, pubDefines.allNameDefine.name_SetDir);
            pubFunction.CheckFileExists(pubDefines.allPathDefine.mainConfigPath, pubDefines.allNameDefine.name_SetHotKey);
            pubFunction.CheckFileExists(pubDefines.allPathDefine.mainConfigPath, pubDefines.allNameDefine.name_ModelType);
            getModelTypeInfo();
            bModify = false;
            //初始化填充HotKey
            SetHotKeyComBox();
        }

        private void getModelTypeInfo()
        {
            string msg = string.Empty;
            modelTypeList = pubFunction.ReadContentFromTxtToLList(pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_ModelType, out msg);
            ComFl.Properties.Items.Clear();
            modelTypeList.ForEach(p => ComFl.Properties.Items.Add(p));
        }

        private void btnSetMod_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (edtDir.Text != "")
            {
                if (File.Exists(edtDir.Text))
                    fileDialog.InitialDirectory = edtDir.Text;
                else
                    fileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            }
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                edtDir.Text = file;
                if (MessageBox.Show("已选择文件:" + file + "，是否保存该配置", "选择文件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                    return;
                else
                    this.btnSaveDir_Click(sender, e);
            }
        }

        private void btnSaveDir_Click(object sender, EventArgs e)
        {
            if (ComFl.SelectedIndex < 0)
            {
                MessageBox.Show("请选择工具分类！");
                return;
            }
            if (edtToolsName.Text == "")
            {
                MessageBox.Show("请输入工具名称");
                return;
            }
            if (edtDir.Text == "")
            {
                MessageBox.Show("请选择路径！");
                return;
            }
            //按分类来区分
            //保存config配置
            pubFunction.CheckFileExists(pubDefines.allPathDefine.mainConfigPath, pubDefines.allNameDefine.name_SetDir);
            pubFunction.CheckFileExists(pubDefines.allPathDefine.mainConfigPath, pubDefines.allNameDefine.name_SetHotKey);
            string msg = string.Empty;
            string configName = pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_SetDir;
            string configNameHotKey = pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_SetHotKey;
            if (ComHotKey.SelectedIndex >= 0 || ComHotKeyItem.SelectedIndex >= 0)
            {
                string mainHotKey = ComHotKey.SelectedIndex >= 0 ? ComHotKey.SelectedItem.ToString() : "None";
                string itemHotKey = ComHotKeyItem.SelectedIndex >= 0 ? ComHotKeyItem.SelectedItem.ToString() : "";
                if (!CheckIsExistHotKey(mainHotKey + "+" + itemHotKey))
                    return;
            }
            try
            {
                useUtils.WriteIniKey(ComFl.Text.Trim(), edtToolsName.Text.Trim(), edtDir.Text.Trim(), configName);
                if (ComHotKey.SelectedIndex >= 0 || ComHotKeyItem.SelectedIndex >= 0)
                {
                    string mainHotKey = ComHotKey.SelectedIndex >= 0 ? ComHotKey.SelectedItem.ToString() : "None";
                    string itemHotKey = ComHotKeyItem.SelectedIndex >= 0 ? ComHotKeyItem.SelectedItem.ToString() : "";
                    useUtils.WriteIniKey(ComFl.Text.Trim(), edtToolsName.Text.Trim(), mainHotKey + "+" + itemHotKey, configNameHotKey);
                }
                MessageBox.Show("保存路径配置成功！");
                GetAllItemsByCatogery();
            }
            catch { }
            bModify = true;
        }

        private void btnFl_Click(object sender, EventArgs e)
        {
            fmSetModelType frm = new fmSetModelType();
            frm.ShowDialog();
            getModelTypeInfo();
        }

        private void ComFl_SelectedIndexChanged(object sender, EventArgs e)
        {
            edtToolsName.Text = "";
            edtDir.Text = "";
            //获取分类下已定义的工具
            if (ComFl.SelectedIndex >= 0)
                GetAllItemsByCatogery();
            else
                lstTools.Items.Clear();
        }

        private void GetAllItemsByCatogery()
        {
            //按分类来区分
            //读取section
            string configName = pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_SetDir;
            string configNameHotKey = pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_SetHotKey;
            Dictionary<string, string> secItems = new Dictionary<string, string>();
            secItems = useUtils.ReadSingleSection(ComFl.Text, configName);
            hotKeyDict.Clear();
            hotKeyDict = useUtils.ReadSingleSection(ComFl.Text, configNameHotKey);

            if (secItems != null)
            {
                lstTools.Items.Clear();
                foreach (var item in secItems)
                {
                    lstTools.Items.Add(new ListBoxItem() { Text = item.Key.ToString(), Value = item.Value });
                }
            }
        }

        public class ListBoxItem
        {
            public string Text = "";
            public string Value = "";
            public override string ToString()
            {
                return Text.Trim();
            }
        }

        private void lstTools_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTools.Items.Count > 0)
            {
                ListBoxItem items = lstTools.SelectedItem as ListBoxItem;
                edtToolsName.Text = items.Text;
                edtDir.Text = items.Value;
                //查找热键
                string mainHotKey = string.Empty;
                string itemHotKey = string.Empty;
                if (hotKeyDict.ContainsKey(items.Text))
                {
                    string hotKeyObj = hotKeyDict[items.Text];
                    if (!string.IsNullOrWhiteSpace(hotKeyObj))
                    {
                        string[] hotkeyArray = hotKeyObj.Split('+');
                        if (hotkeyArray.Length >= 1)
                            mainHotKey = hotkeyArray[0];
                        if (hotkeyArray.Length >= 2)
                            itemHotKey = hotkeyArray[1];
                    }
                }
                if (!string.IsNullOrWhiteSpace(mainHotKey))
                    ComHotKey.SelectedItem = mainHotKey;
                else
                    ComHotKey.SelectedIndex = -1;
                if (!string.IsNullOrWhiteSpace(itemHotKey))
                    ComHotKeyItem.SelectedItem = itemHotKey;
                else
                    ComHotKeyItem.SelectedIndex = -1;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (ComFl.SelectedIndex < 0)
            {
                MessageBox.Show("请选择工具分类！");
                return;
            }
            if (edtToolsName.Text == "")
            {
                MessageBox.Show("请输入工具名称");
                return;
            }
            //按分类来区分
            //保存config配置
            pubFunction.CheckFileExists(pubDefines.allPathDefine.mainConfigPath, pubDefines.allNameDefine.name_SetDir);
            pubFunction.CheckFileExists(pubDefines.allPathDefine.mainConfigPath, pubDefines.allNameDefine.name_SetHotKey);
            string msg = string.Empty;
            string configName = pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_SetDir;
            string configNameHotKey = pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_SetHotKey;
            try
            {
                useUtils.DeleteIniKey(ComFl.Text.Trim(), edtToolsName.Text.Trim(), configName);
                useUtils.DeleteIniKey(ComFl.Text.Trim(), edtToolsName.Text.Trim(), configNameHotKey);
                MessageBox.Show("删除路径配置成功！");
                GetAllItemsByCatogery();
            }
            catch { }
            bModify = true;
        }

        private void fmSetOtherProcess_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bModify)
            {
                if (MessageBox.Show("已有新设置，需要重启后才能生效，是否重启？", "友情提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Exit();
                    Application.Restart();
                }
            }
        }

        string[] keysItem = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N",
                              "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1",
                              "2", "3", "4", "5", "6", "7", "8", "9", "0", "`", "-", "=", "[", "]",
                              ",", ".", "/", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10",
                              "F11", "F12"};
        /// <summary>
        /// 初始化填充HotKey
        /// </summary>
        private void SetHotKeyComBox()
        {
            ComHotKeyItem.Properties.Items.Clear();
            for (int i = 0; i < keysItem.Length; i++)
            {
                ComHotKeyItem.Properties.Items.Add(keysItem[i]);
            }
        }

        /// <summary>
        /// 判断热键是否已经有定义了
        /// </summary>
        /// <returns></returns>
        private bool CheckIsExistHotKey(string sHotKey)
        {
            if (hotKeyDict.ContainsValue(sHotKey))
            {
                MessageBox.Show("该热键已存在，请重新定义！");
                return false;
            }
            return true;
        }
    }
}
