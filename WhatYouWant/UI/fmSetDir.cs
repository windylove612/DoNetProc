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
    public partial class fmSetDir : Form
    {
        public fmSetDir()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckFileExists(pubDefines.allPathDefine.mainConfigPath, pubDefines.allNameDefine.name_SetDir);
            //显示信息
            ShowMain("setModDir");
        }

        /// <summary>
        /// 检查文件是否存在，没有则创建
        /// </summary>
        private void CheckFileExists(string dirName, string filename)
        {
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            if (!File.Exists(dirName + "\\" + filename))
            {
                File.Create(dirName + "\\" + filename).Close();

            }
        }

        private void btnMofidyDir_Click(object sender, EventArgs e)
        {
            string exePath = edtDir.Text;
            Process p = new Process();
            p.StartInfo.FileName = exePath;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            //p.WaitForExit();
        }

        private void btnSaveDir_Click(object sender, EventArgs e)
        {
            //保存config配置
            string configName = pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_SetDir;
            if (!File.Exists(configName))
            {
                try
                {
                    File.Create(configName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            //写入配置文件内容
            if (WriteContentToTxt(pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_SetDir, "setModDir", edtDir.Text))
            {
                MessageBox.Show("保存路径配置成功！");
                ShowMain("setModDir");
            }
        }

        private void ShowMain(string showname)
        {
            Dictionary<string, string> confList = ReadContentFromTxt(pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_SetDir, showname);
            if (confList.Count > 0)
            {
                if (showname == "setModDir")
                    edtDir.Text = confList.First().Value;
            }
        }

        private Dictionary<string, string> ReadContentFromTxt(string paths, string name)
        {
            string[] contents = File.ReadAllLines(paths, Encoding.Default);
            Dictionary<string, string> settingList = new Dictionary<string, string>();
            if (name == "all")
            {
                foreach (string str in contents)
                {
                    if (str.Contains("="))
                        settingList.Add(str.Split('=')[0].ToString(), str.Split('=')[1].ToString());
                }
            }
            else
            {
                foreach (string str in contents)
                {
                    if (str.Contains("="))
                    {
                        if (str.Split('=')[0].ToString() == name)
                        {
                            settingList.Add(str.Split('=')[0].ToString(), str.Split('=')[1].ToString());
                        }
                    }
                }
            }
            return settingList;
        }

        public class TxtLines
        {
            public string name { get; set; }
            public string value { get; set; }
            public TxtLines()
            {
                this.name = string.Empty;
                this.value = string.Empty;
            }
        }
        private bool WriteContentToTxt(string paths, string name, string newValue)
        {
            string resultContent = "";
            //读取全部内容
            try
            {
                Dictionary<string, string> confList = ReadContentFromTxt(pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_SetDir, "all");
                foreach (var item in confList)
                {
                    if (item.Key == name)
                        resultContent += item.Key + "=" + newValue + "\r\n";
                    else
                        resultContent += item.Key + "=" + item.Value + "\r\n";
                }
                if (resultContent == "")
                {
                    resultContent += name + "=" + newValue + "\r\n";
                }
                byte[] fs = System.Text.Encoding.Default.GetBytes(resultContent);
                //全部内容读取之后重新写入，目前没其他好办法
                FileStream writeFile = new FileStream(paths, FileMode.OpenOrCreate);
                writeFile.Write(fs, 0, fs.Length);
                writeFile.Close();
                writeFile.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
