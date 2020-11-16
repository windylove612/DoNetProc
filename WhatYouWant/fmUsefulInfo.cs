using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading;
using DevExpress.Utils;
using System.Xml;
using System.Data.SqlClient;

namespace WhatYouWant
{
    public partial class fmUsefulInfo : Form
    {
        private List<string> itemListBox = new List<string>();
        private Dictionary<string, string> listBoxLists = new Dictionary<string, string>();
        //private Dictionary<string, string> barMenuLists = new Dictionary<string, string>();
        private List<detailView> mainView = new List<detailView>();
        private class detailView
        {
            public string code { get; set; }
            public string name { get; set; }
            public string note { get; set; }
            public string detail { get; set; }
            public detailView()
            {
                this.code = string.Empty;
                this.name = string.Empty;
                this.note = string.Empty;
                this.detail = string.Empty;
            }
        }

        public fmUsefulInfo()
        {
            InitializeComponent();
            //定位窗体位置在屏幕中间
            this.CenterToScreen();

            System.Threading.Thread.Sleep(1000);
            Splasher.Status = "客官别急，正在加载数据......";
            System.Threading.Thread.Sleep(1000);
            //.......此处加载耗时的代码
            Splasher.Status = "数据加载完毕............";
            System.Threading.Thread.Sleep(1000);

            Splasher.Close();
        }

        private void Load_Infomation()
        {
            //加载listbox中的内容到list里
            itemListBox.Clear();
            for (int i = 0; i < listMain.ItemCount; i++)
            {
                itemListBox.Add(listMain.Items[i].ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (edtSet.Text.Trim() == "")
            {
                MessageBox.Show("请输入项目名称！");
                return;
            }
            int useType = 0;
            fmSelType fmSel = new fmSelType();
            fmSel.ShowDialog();
            if (fmSel.DialogResult == DialogResult.OK)
            {
                useType = fmSel.useMode;
            }
            else
            {
                return;
            }
            //检索listbox里是否有重复的
            Load_Infomation();
            if (itemListBox.Contains(edtSet.Text))
            {
                listMain.SelectedItem = edtSet.Text;
                MessageBox.Show("已定义过该项内容~~~");
                return;
            }
            else
            {
                if (listMain.ItemCount <= 0)
                    listMain.SelectedIndex = -1;
                else
                    listMain.SelectedIndex = listMain.ItemCount - 1;
                listMain.Items.Add(edtSet.Text);
            }
            SaveToTheConfig(1, useType);
            //定位到新添加的行
            listMain.SelectedIndex = listMain.ItemCount - 1;
            listMain_Click(null, null);
        }


        /// <summary>
        /// 检查文件是否存在，没有则创建
        /// </summary>
        private void CheckFileExists(string dirName, List<string> filenameList)
        {
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            foreach (var item in filenameList)
            {
                if (!File.Exists(dirName + "\\" + item.ToString()))
                {
                    File.Create(dirName + "\\" + item.ToString()).Close();

                }
            }
        }

        /// <summary>
        /// 保存相应的内容到txt中
        /// </summary>
        /// <param name="saveType">类型，1是listbox保存</param>
        private void SaveToTheConfig(int saveType, int useMode)
        {
            string configName = string.Empty;
            string dirName = pubDefines.allPathDefine.mainConfigPath;
            string filename = string.Empty;
            string msg = string.Empty;
            List<string> fileList = new List<string>();
            switch (saveType)
            {
                case 1: //listbox的保存
                    filename = pubDefines.allNameDefine.name_ListBox;
                    break;
                default:
                    break;
            }
            fileList.Add(filename);
            configName = dirName + "\\" + filename;
            //判断文件夹和文件是否存在，没有则创建
            CheckFileExists(dirName, fileList);
            //加载信息到相应的list里便于后续的保存
            Load_Infomation();
            //保存config
            if (SaveConfig(out msg, configName, useMode))
            {
                //MessageBox.Show("保存配置设置成功！");
                Load_configInfo();
            }
            else
            {
                MessageBox.Show("保存配置设置失败：" + msg);
            }
        }

        /// <summary>
        /// 保存config配置
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        private bool SaveConfig(out string msg, string path, int useMode)
        {
            msg = "";
            string contents = string.Empty;
            foreach (var item in itemListBox)
            {
                if (!listBoxLists.ContainsKey(item))
                    contents += item.ToString() + "=" + useMode.ToString() + "\r\n";
                else
                    contents += item.ToString() + "=" + listBoxLists.FirstOrDefault(p => p.Key == item).Value + "\r\n";
            }
            if (pubFunction.WriteContentToTxt(path, contents, out msg))
            {
                //load配置信息
            }
            return (msg == "");
        }

        private void Load_configInfo()
        {
            string msg = string.Empty;
            string dirName = pubDefines.allPathDefine.mainConfigPath;
            string listBoxConfig = pubDefines.allNameDefine.name_ListBox;
            //string barMenuConfig = pubUtils.allNameDefine.name_SetDir;
            List<string> fileList = new List<string>();
            fileList.Add(listBoxConfig);
            //fileList.Add(barMenuConfig);
            CheckFileExists(dirName, fileList);
            //读取配置信息
            listBoxLists = pubFunction.ReadContentFromTxt(dirName + "\\" + listBoxConfig, out msg);
            listMain.Items.Clear();
            if (listBoxLists.Count > 0)
            {
                foreach (var item in listBoxLists)
                {
                    listMain.Items.Add(item.Key);
                }
            }
            //barMenuLists = pubFunction.ReadContentFromTxt(dirName + "\\" + barMenuConfig, out msg);
            pubDefines.isShowDetail = false;
            this.NOTE.Caption = pubDefines.isShowDetail ? "说明(按F7可以隐藏详细说明)" : "说明(按F7可以显示详细说明)";
        }

        private void getIpMethod()
        {
            if (commonUtils.InternetCheck.IsConnectInternet())
            {
                string ipAddr = commonUtils.GetIPBySohu();
                lblIP.Text = ipAddr;
                if (ipAddr != "" && ipAddr != "未获取到IP地址")
                {
                    string sCity = string.Empty;
                    lblIP.Text += " " + commonUtils.GetCityNameByPcOnline(ipAddr, out sCity);
                    lblCity.Text = sCity;
                    GetWeatherInfo(sCity);
                }
            }
            //this.Invoke((EventHandler)(delegate
            //{
            //    if (commonUtils.InternetCheck.IsConnectInternet())
            //    {
            //        string ipAddr = commonUtils.GetIP1();
            //        lblIP.Text = ipAddr;
            //        if (ipAddr != "" && ipAddr != "未获取到IP地址")
            //        {
            //            string sCity = string.Empty;
            //            lblIP.Text += " " + commonUtils.GetSinaIp(ipAddr,out sCity);
            //            lblCity.Text = sCity;
            //            GetWeatherInfo(sCity);
            //        }
            //    }
            //}));
            ////这个不能放在Invoke里面，不然又Form窗体假死情况  
            //Thread.Sleep(500);
        }

        private void getIpMethodRefresh()
        {
            this.Invoke((EventHandler)(delegate
            {
                if (commonUtils.InternetCheck.IsConnectInternet())
                {
                    string ipAddr = commonUtils.GetIP1();
                    lblIP.Text = ipAddr;
                    if (ipAddr != "" && ipAddr != "未获取到IP地址")
                    {
                        string sCity = string.Empty;
                        lblIP.Text += " " + commonUtils.GetCityNameByPcOnline(ipAddr, out sCity);
                        lblCity.Text = sCity;
                        GetWeatherInfo(sCity);
                    }
                }
            }));
            //这个不能放在Invoke里面，不然又Form窗体假死情况  
            Thread.Sleep(500);
        }

        private void getWeatherMethodRefresh()
        {
            this.Invoke((EventHandler)(delegate
            {
                if (commonUtils.InternetCheck.IsConnectInternet())
                {
                    if (lblCity.Text != "")
                    {
                        GetWeatherInfo(lblCity.Text);
                    }
                }
            }));
            //这个不能放在Invoke里面，不然又Form窗体假死情况  
            Thread.Sleep(500);
        }

        weatherDataObject.weatherWebObj objWeather = new weatherDataObject.weatherWebObj();
        private void GetWeatherInfo(string sCity)
        {
            if (!string.IsNullOrEmpty(sCity))
            {
                objWeather = weatherUtils.GetWeatherByCityWebServices(sCity);
                if (objWeather != null)
                    lblWeather.Text = objWeather.tempDetail + " " + objWeather.temp;
            }
        }

        private void fmUsefulInfo_Load(object sender, EventArgs e)
        {
            Load_configInfo();
            setBarMenuInfo();
            if (listMain.ItemCount > 0)
            {
                listMain.SelectedIndex = 0;
                listMain_Click(null, null);
            }
            rgType_SelectedIndexChanged(null, null);
            getIpMethod();
            //设置热键
            HotKey.SetHotKey(this.Handle, AllHotKeyDict);
        }


        private void btnDel_Click(object sender, EventArgs e)
        {
            if (listMain.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择要删除的项目！");
                return;
            }
            if (MessageBox.Show("是否确定删除该项目(" + listMain.SelectedItem + ")?同时会删除对应的内容", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string msg = string.Empty;
                int index = listMain.SelectedIndex;
                string sDelPathName = string.Empty;
                if (rgType.SelectedIndex == 0)
                    sDelPathName = "memo_" + listMain.SelectedItem + ".txt";
                else if (rgType.SelectedIndex == 1)
                    sDelPathName = "grid_" + listMain.SelectedItem + ".txt";
                listMain.Items.RemoveAt(index);
                //删除文件
                try
                {
                    pubFunction.deleteFile(pubDefines.allPathDefine.mainConfigPath + "\\" + sDelPathName, out msg);
                }
                catch
                { }
                //保存config
                SaveToTheConfig(1, rgType.SelectedIndex);
                //加载config
                Load_configInfo();
                listMain_Click(null, null);
            }
        }

        private void rgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rgType.SelectedIndex == 0)
            {
                this.gridControlGrid.Visible = true;
                this.edtMemo.Visible = false;
                this.gridControlGrid.Dock = DockStyle.Fill;
                this.gridControlGrid.DataSource = mainView;
                this.gridControlGrid.RefreshDataSource();
            }
            else if (this.rgType.SelectedIndex == 1)
            {
                this.gridControlGrid.Visible = false;
                this.edtMemo.Visible = true;
                this.edtMemo.Dock = DockStyle.Fill;
                this.gridControlGrid.DataSource = null;
                this.gridControlGrid.RefreshDataSource();
            }
            //listMain_Click(null,null);
        }

        private void listMain_Click(object sender, EventArgs e)
        {
            if (listMain.ItemCount <= 0)
            {
                if (rgType.SelectedIndex == 1)
                {
                    edtMemo.Text = "";
                }
                else if (rgType.SelectedIndex == 0)
                {
                    gridControlGrid.DataSource = null;
                    gridControlGrid.RefreshDataSource();
                }
                return;
            }
            string item = listMain.SelectedItem.ToString();
            int index = Convert.ToInt32(listBoxLists.FirstOrDefault(p => p.Key == item).Value);
            rgType.SelectedIndex = index;

            if (rgType.SelectedIndex == 1)
            {
                //加载对应的memo文件内容
                ShowMemoContent();
                btnUpdateByDataBase.Text = "数据链接设置";
            }
            else if (rgType.SelectedIndex == 0)
            {
                //加载对应grid的内容
                ShowGridContent();
                btnUpdateByDataBase.Text = "从数据库更新";
            }
        }

        /// <summary>
        /// 显示memo的tips内容
        /// </summary>
        private void ShowMemoContent()
        {
            string msg = string.Empty;
            #region 显示memo的tips内容
            try
            {
                string memoPath = Directory.GetFiles(pubDefines.allPathDefine.mainSavePath, "memo_" + listMain.SelectedItem.ToString() + ".txt").FirstOrDefault();
                if (memoPath != "")
                {
                    string[] contents = { };
                    contents = pubFunction.ReadContentFromTxtAll(memoPath, out msg);
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        //MessageBox.Show("内容加载失败!" + msg);
                        edtMemo.Text = string.Empty;
                        return;
                    }
                    else
                    {
                        string rslMemo = string.Empty;
                        foreach (string detail in contents)
                        {
                            rslMemo += detail + "\r\n";
                        }
                        edtMemo.Text = rslMemo;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                edtMemo.Text = string.Empty;
                return;
            }
            #endregion
        }

        /// <summary>
        /// 显示grid的内容
        /// </summary>
        private void ShowGridContent()
        {
            string msg = string.Empty;
            #region 显示grid中的内容
            string aaa = "";
            try
            {
                string gridPath = Directory.GetFiles(pubDefines.allPathDefine.mainSavePath, "grid_" + listMain.SelectedItem.ToString() + ".txt").FirstOrDefault();
                if (gridPath != "")
                {
                    string[] contents = { };
                    contents = pubFunction.ReadContentFromTxtAll(gridPath, out msg);
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        //MessageBox.Show("内容加载失败!" + msg);
                        mainView.Clear();
                        gridControlGrid.DataSource = mainView;
                        gridControlGrid.RefreshDataSource();
                        return;
                    }
                    else
                    {
                        mainView.Clear();
                        foreach (string detail in contents)
                        {
                            string[] strCont = detail.Split('\t');
                            detailView item = new detailView();
                            aaa = strCont[0].ToString();
                            item.code = strCont[0].ToString();
                            item.name = strCont[1].ToString();
                            item.note = strCont[2].ToString();
                            if (strCont.Length > 3)
                                item.detail = (strCont[3] ?? "").ToString();
                            mainView.Add(item);
                        }
                        gridControlGrid.DataSource = mainView;
                        gridControlGrid.RefreshDataSource();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + aaa);
                gridControlGrid.DataSource = null;
                gridControlGrid.RefreshDataSource();
                return;
            }
            #endregion
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            //如果是表格形式
            if (gridControlGrid.Visible)
            {
                fmEnterContent frmCon = new fmEnterContent();
                frmCon.ShowDialog();
                if (frmCon.DialogResult == DialogResult.OK)
                {
                    string strValue = frmCon.StrValue;
                    string strName = frmCon.StrName;
                    string strMemo = frmCon.StrMemo;
                    string strDetail = frmCon.StrDetail;

                    List<detailView> dataList = new List<detailView>();
                    detailView item = new detailView();
                    item.code = strValue;
                    item.name = strName;
                    item.note = strMemo;
                    item.detail = strDetail;
                    dataList.Add(item);
                    addDataToView(dataList, false);

                    //直接保存
                    btnSave.PerformClick();
                }
            }
            if (edtMemo.Visible)
            {
                edtMemo.Enabled = true;
            }
        }

        /// <summary>
        /// excel导入的数据添加到grid中
        /// </summary>
        /// <param name="dataDetailList">数据</param>
        /// <param name="isFold">是否覆盖</param>
        private void addDataToView(List<detailView> dataDetailList, bool isFold = false)
        {
            if (isFold)
                mainView.Clear();
            for (int i = 0; i < dataDetailList.Count; i++)
            {
                detailView detail = new detailView();
                detail.code = dataDetailList[i].code;
                detail.name = dataDetailList[i].name;
                detail.note = dataDetailList[i].note;
                detail.detail = dataDetailList[i].detail;
                mainView.Add(detail);
            }
            this.gridControlGrid.DataSource = mainView;
            this.gridControlGrid.RefreshDataSource();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> savePath = new List<string>();
            string msg = string.Empty;
            //如果是表格形式
            if (gridControlGrid.Visible)
            {
                if (mainView.Count == 0)
                {
                    MessageBox.Show("还没有录入内容");
                    return;
                }
                string gridContent = string.Empty;
                foreach (detailView details in mainView)
                {
                    //用制表符做分隔符
                    int index = 0;
                    if (index < mainView.Count - 1)
                        gridContent += details.code + "\t" + details.name + "\t" + details.note + "\t" + details.detail + "\r\n";
                    else
                        gridContent += details.code + "\t" + details.name + "\t" + details.note + "\t" + details.detail;
                    index++;
                }
                savePath.Clear();
                savePath.Add(pubDefines.allNameDefine.name_PathGrid + "_" + listMain.SelectedItem.ToString() + ".txt");
                CheckFileExists(pubDefines.allPathDefine.mainSavePath, savePath);
                if (pubFunction.WriteContentToTxt(pubDefines.allPathDefine.mainSavePath + "\\" + savePath[0].ToString(), gridContent, out msg))
                {
                    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (edtMemo.Visible)
            {
                if (edtMemo.Text == "")
                {
                    MessageBox.Show("还没有录入内容");
                    return;
                }
                savePath.Clear();
                savePath.Add(pubDefines.allNameDefine.name_PathMemo + "_" + listMain.SelectedItem.ToString() + ".txt");
                CheckFileExists(pubDefines.allPathDefine.mainSavePath, savePath);
                if (pubFunction.WriteContentToTxt(pubDefines.allPathDefine.mainSavePath + "\\" + savePath[0].ToString(), edtMemo.Text, out msg))
                {
                    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void listMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            edtSrchContent.Text = "";
            if (rgType.SelectedIndex == 0)
            {
                gridMain.ActiveFilterString = "";
            }
        }

        private void barBtnSetDir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fmSetDir frm = new fmSetDir();
            frm.ShowDialog();
            //string exePath = (sender as DevExpress.XtraBars.BarButtonItem).Description;
            //Process p = new Process();
            //p.StartInfo.FileName = exePath;
            //p.StartInfo.UseShellExecute = false;
            //p.Start();
        }

        private void btnDelDetail_Click(object sender, EventArgs e)
        {
            if (edtMemo.Visible)
            {
                if (MessageBox.Show("是否确定删除内容？", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    edtMemo.Text = "";
                }
            }
            else if (gridControlGrid.Visible)
            {
                if (gridMain.SelectedRowsCount <= 0)
                {
                    MessageBox.Show("请选择要删除的行！");
                    return;
                }
                if (gridMain.FocusedRowHandle > -1)
                {
                    int lHandel = gridMain.FocusedRowHandle;
                    detailView _lInfo = this.mainView[this.gridMain.GetDataSourceRowIndex(lHandel)];
                    if (MessageBox.Show("是否确定删除该行内容(代码值" + _lInfo.code + ",属性值" + _lInfo.name + ")?", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        mainView.Remove(_lInfo);
                        this.gridControlGrid.DataSource = mainView;
                        this.gridControlGrid.RefreshDataSource();

                        btnSave.PerformClick();
                    }
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (listMain.SelectedItem != null)
            {
                //打开excel选择框
                OpenFileDialog frm = new OpenFileDialog();
                frm.Filter = "Excel文件(*.xls,xlsx)|*.xls;*.xlsx";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string excelName = frm.FileName;
                    DataTable dt = AsPoseHelper.ExcelToDataTable(excelName, null, false, false);
                    if ((dt != null) && (dt.Rows.Count > 0))
                    {
                        List<detailView> dataList = new List<detailView>();
                        for (int i = 0; i < dt.Rows.Count - 1; i++)
                        {
                            string strValue = dt.Rows[i][0].ToString();
                            string strName = dt.Rows[i][1].ToString();
                            string strMemo = dt.Rows[i][2].ToString();
                            string strDetail = (dt.Rows[i][3] ?? "").ToString();

                            detailView item = new detailView();
                            item.code = strValue;
                            item.name = strName;
                            item.note = strMemo;
                            item.detail = strDetail;
                            dataList.Add(item);
                        }
                        if (System.Windows.Forms.MessageBox.Show("是否覆盖现有的数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            addDataToView(dataList, true);
                        else
                            addDataToView(dataList, false);
                        //直接保存
                        btnSave.PerformClick();
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择一个项目");
                return;
            }
        }

        private void gridControlGrid_Click(object sender, EventArgs e)
        {

        }

        private List<string> lstFilter = new List<string>();
        private void edtSrch_EditValueChanged(object sender, EventArgs e)
        {
            //标题高亮显示
            lstFilter.Clear();
            if (edtSrch.Text != "")
            {
                Load_configInfo();
                for (int i = 0; i < listMain.ItemCount; i++)
                {
                    if (listMain.Items[i].ToString().ToUpper().Contains(edtSrch.Text.ToUpper()))
                    {
                        lstFilter.Add(listMain.Items[i].ToString());
                    }
                }
                listMain.Items.Clear();
                lstFilter.ForEach(p => listMain.Items.Add(p));
            }
            else
            {
                Load_configInfo();
            }
            listMain_Click(listMain, e);
        }

        private void edtSrchContent_EditValueChanged(object sender, EventArgs e)
        {
            if (rgType.SelectedIndex == 0)
            {
                if (edtSrchContent.Text != "")
                {
                    string[] srchConditionArray = edtSrchContent.Text.Split(' ');
                    string sSrchConditionStr = string.Empty;
                    for (int i = 0; i < srchConditionArray.Length; i++)
                    {
                        sSrchConditionStr += "(code like '%" + srchConditionArray[i] + "%'"
                                           + "or name like '%" + srchConditionArray[i] + "%'"
                                           + "or note like '%" + srchConditionArray[i] + "%')" + " and ";
                    }
                    sSrchConditionStr = sSrchConditionStr.Substring(0, sSrchConditionStr.Length - 4);
                    gridMain.ActiveFilterString = sSrchConditionStr;
                }
                else
                {
                    gridMain.ActiveFilterString = "";
                }
            }
            else if (rgType.SelectedIndex == 1)
            {

            }
        }

        private void barButtonAllset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fmSetOtherProcess frm = new fmSetOtherProcess();
            frm.ShowDialog();
        }

        private List<string> GetAllCatogery()
        {
            //按分类来区分
            //读取section
            string configName = pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_SetDir;
            List<string> sections = new List<string>();
            sections = useUtils.ReadSections(configName);
            return sections;
        }

        private Dictionary<string, string> GetAllItemsByCatogery(string sCategory)
        {
            //按分类来区分
            //读取section
            string configName = pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_SetDir;
            Dictionary<string, string> secItems = new Dictionary<string, string>();
            secItems = useUtils.ReadSingleSection(sCategory, configName);
            return secItems;
        }

        private Dictionary<string, string> GetHotKeysByCatogery(string sCategory)
        {
            //按分类来区分
            //读取section
            string configName = pubDefines.allPathDefine.mainConfigPath + "\\" + pubDefines.allNameDefine.name_SetHotKey;
            Dictionary<string, string> secItems = new Dictionary<string, string>();
            secItems = useUtils.ReadSingleSection(sCategory, configName);
            return secItems;
        }

        private void setBarMenuInfo()
        {
            //常用工具按钮
            this.barMenu.LinksPersistInfo.Clear();
            barManager1.Items.Clear();
            DevExpress.XtraBars.BarButtonItem barSetAll = new DevExpress.XtraBars.BarButtonItem();
            barSetAll.Name = "barButtonAllset";
            barSetAll.Caption = "常用工具设置";
            barSetAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonAllset_ItemClick);
            barSetAll.ItemAppearance.Hovered.BackColor = Color.Yellow;
            barSetAll.ItemAppearance.Pressed.BackColor = Color.Red;
            barManager1.Items.Add(barSetAll);
            this.barMenu.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(barSetAll));

            //其他自定义的
            List<string> sectionList = GetAllCatogery();
            for (int i = 0; i < sectionList.Count; i++)
            {
                DevExpress.XtraBars.BarLinkContainerItem item = new DevExpress.XtraBars.BarLinkContainerItem();
                item.Name = "barItemLink_" + i.ToString();
                item.Caption = sectionList[i];
                barManager1.Items.Add(item);
                this.barMenu.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(item));
                //子项
                Dictionary<string, string> sectionItems = GetAllItemsByCatogery(sectionList[i]);
                Dictionary<string, string> hotKeyItem = GetHotKeysByCatogery(sectionList[i]);
                string sHotKeyValue = string.Empty;
                int j = 1;
                foreach (var detail in sectionItems)
                {
                    DevExpress.XtraBars.BarButtonItem items = new DevExpress.XtraBars.BarButtonItem();
                    items.Name = "barItemLinkDetail_" + j.ToString();
                    items.Caption = detail.Key;
                    items.Tag = detail.Value;
                    items.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.processDo);
                    items.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                    barManager1.Items.Add(items);
                    item.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(items));
                    //获取热键
                    if (hotKeyItem.ContainsKey(detail.Key))
                    {
                        sHotKeyValue = hotKeyItem[detail.Key];
                        if (!string.IsNullOrWhiteSpace(sHotKeyValue))
                        {
                            AllHotKeyDict.Add(sHotKeyValue, items);
                            AllHotKeyTips.Add(detail.Key, sHotKeyValue);
                        }
                    }
                    j++;
                }
            }
        }

        Dictionary<string, DevExpress.XtraBars.BarButtonItem> AllHotKeyDict = new Dictionary<string, DevExpress.XtraBars.BarButtonItem>();
        Dictionary<string, string> AllHotKeyTips = new Dictionary<string, string>();

        private void processDo(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //获取当前选择的item
            if (e.Item.Tag.ToString().StartsWith("http://") || e.Item.Tag.ToString().StartsWith("https://"))
            {
                try
                {
                    System.Diagnostics.Process.Start(pubDefines.sOwnBrowserPath, e.Item.Tag.ToString());
                }
                catch
                {
                    try
                    {
                        System.Diagnostics.Process.Start("chrome.exe", e.Item.Tag.ToString());
                    }
                    catch
                    {
                        System.Diagnostics.Process.Start(e.Item.Tag.ToString());
                    }
                }
            }
            else
            {
                Process p = new Process();
                p.StartInfo.FileName = e.Item.Tag.ToString();
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            this.lblClock.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {
            if (lblIP.Text == "" || lblIP.Text == "未获取到IP地址")
            {
                //Thread waitT = new Thread(new ThreadStart(GetIpAddress));
                //waitT.Start();
                var thread = new System.Threading.Thread(new System.Threading.ThreadStart(()
                =>
                {
                    getIpMethodRefresh();
                }))
                { IsBackground = true };
                thread.Start();
                //var thread = new System.Threading.Thread(new System.Threading.ThreadStart(delegate
                //{
                //    ThreadMethodTxt();
                //    //GetIpAddress();
                //    //这里面写你的代码，一般会吧比较耗时的方法放在后台里执行。
                //})) { IsBackground = true };
                //thread.Start();
            }
        }

        //public delegate void GetIpAddress();
        //public GetIpAddress getIp;

        //public void ThreadMethodGet()
        //{
        //    this.BeginInvoke(getIp);
        //    Thread.Sleep(1000);
        //}


        private void fmUsefulInfo_Shown(object sender, EventArgs e)
        {
            //getIp = new GetIpAddress(getIpMethod);
            //var thread = new System.Threading.Thread(new System.Threading.ThreadStart(delegate
            //{
            //    ThreadMethodGet();
            //})) { IsBackground = true };
            //thread.Start();
        }

        ToolTipControllerShowEventArgs toolinfo;

        private void lblWeather_MouseEnter(object sender, EventArgs e)
        {
            //显示tips
            weatherDataObject.weatherWebObj objWeatherOld = objWeather;
            var thread = new System.Threading.Thread(new System.Threading.ThreadStart(()
            =>
            {
                getWeatherMethodRefresh();
            }))
            { IsBackground = true };
            thread.Start();
            if (objWeather == null)
                objWeather = objWeatherOld;

            toolinfo = new ToolTipControllerShowEventArgs();
            if (objWeather != null)
            {
                toolinfo.AllowHtmlText = DefaultBoolean.True;
                toolinfo.ToolTip = objWeather.note;
                toolinfo.Rounded = true;//圆角 
                toolinfo.RoundRadius = 7;//圆角率 
                toolinfo.ToolTipType = ToolTipType.Standard;
                SetToolTipsSetting(toolinfo, pubDefines.toolTipsType.type_Weather);
                if (toolinfo.Title != "" || toolinfo.ToolTip != "")
                {
                    Point pLocate = new Point(lblWeather.Location.X, lblWeather.Location.Y); // 0,0 是左上角 
                    pLocate = lblWeather.PointToScreen(pLocate); // p.X, p.Y 是控件左上角在屏幕上的坐标 
                    SetToolTipsControllerSetting(toolTipController1, pubDefines.toolTipsType.type_Weather);
                    toolTipController1.ShowHint(toolinfo, pLocate);
                }
            }
        }

        private void SetToolTipsSetting(ToolTipControllerShowEventArgs showTips, string sType)
        {
            if (sType == pubDefines.toolTipsType.type_Weather)
            {
                showTips.ToolTipLocation = ToolTipLocation.TopLeft;   //位置
                showTips.ShowBeak = false;  //去掉鸟嘴
                showTips.Title = "天气详情：";
                showTips.Appearance.BorderColor = Color.Blue;
            }
            else if (sType == pubDefines.toolTipsType.type_GridDetail)
            {
                showTips.ToolTipLocation = ToolTipLocation.Default;   //位置
                showTips.ShowBeak = false;  //去掉鸟嘴
                showTips.Title = "详细说明：";
                showTips.Appearance.BorderColor = Color.Blue;
            }
        }

        private void SetToolTipsControllerSetting(ToolTipController showTipsControl, string sType)
        {
            //showTipsControl.AutoPopDelay = 0;  //展示10s  ms单位
            showTipsControl.InitialDelay = 0;
        }

        private void lblWeather_MouseLeave(object sender, EventArgs e)
        {
            toolTipController1.HideHint();
        }

        private void lblWeather_Click(object sender, EventArgs e)
        {
            var thread = new System.Threading.Thread(new System.Threading.ThreadStart(()
            =>
            {
                getWeatherMethodRefresh();
            }))
            { IsBackground = true };
            thread.Start();
        }

        private void btnBigData_Click(object sender, EventArgs e)
        {
            //fmApiBigData frm = new fmApiBigData();
            //frm.ShowDialog();
        }

        private void fmUsefulInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                fmHelp frmHelp = new fmHelp();
                frmHelp.ShowDialog();
            }
            else if (e.KeyCode == Keys.F5)
            {
                fmApiBigData frm = new fmApiBigData();
                frm.ShowDialog();
            }
            else if (e.Control && e.KeyCode == Keys.S)  //按下了ctrl+s键
            {
                btnSave.PerformClick();
            }
            else if (e.KeyCode == Keys.F7)
            {
                pubDefines.isShowDetail = Convert.ToBoolean(1 - (pubDefines.isShowDetail ? 1 : 0));
                if (!pubDefines.isShowDetail)
                    toolTipControllerGrid.HideHint();
                this.NOTE.Caption = pubDefines.isShowDetail ? "说明(按F7可以隐藏详细说明)" : "说明(按F7可以显示详细说明)";
            }
            else if (e.KeyCode == Keys.F11)
            {
                if (AllHotKeyTips != null && AllHotKeyTips.Count > 0)
                {
                    string sTips = string.Empty;
                    foreach (var item in AllHotKeyTips)
                    {
                        sTips += item.Key + "：" + item.Value + "\r\n";
                    }
                    MessageBox.Show(sTips);
                }
            }
        }

        private void gridMain_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        private void ShowToolTipsGrid()
        {
            toolinfo = new ToolTipControllerShowEventArgs();
            detailView detailData = gridMain.GetFocusedRow() as detailView;
            if (detailData != null)
            {
                toolinfo.AllowHtmlText = DefaultBoolean.True;
                toolinfo.ToolTip = NewLineStr(detailData.detail.Replace('#', '\r').Replace('^', '\n'), 50);
                toolinfo.Rounded = true;//圆角 
                toolinfo.RoundRadius = 7;//圆角率 
                toolinfo.ToolTipType = ToolTipType.Standard;
                SetToolTipsSetting(toolinfo, pubDefines.toolTipsType.type_GridDetail);
                if (toolinfo.Title != "" || toolinfo.ToolTip != "")
                {
                    Point pLocate = new Point(MousePosition.X, MousePosition.Y); // 0,0 是左上角 
                    //pLocate = gridControlGrid.PointToScreen(pLocate); // p.X, p.Y 是控件左上角在屏幕上的坐标 
                    SetToolTipsControllerSetting(toolTipControllerGrid, pubDefines.toolTipsType.type_GridDetail);
                    if (toolinfo.ToolTip != "")
                        toolTipControllerGrid.ShowHint(toolinfo, pLocate);
                    else
                        toolTipControllerGrid.HideHint();
                }
            }
        }

        private void gridMain_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (pubDefines.isShowDetail)
            {
                if (gridMain.FocusedColumn == this.NOTE)
                    ShowToolTipsGrid();
            }
        }

        private void listMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (listMain.SelectedIndex < 0) return;
        }

        private void toolStripOpenPath_Click(object sender, EventArgs e)
        {
            string sName = (rgType.SelectedIndex == 0) ? "grid" : "memo";
            string sFullName = pubDefines.allPathDefine.mainSavePath + "\\" + sName + "_" + listMain.SelectedItem.ToString() + ".txt";
            //if (File.Exists(sFullName))
            //{
            //    Process.Start("explorer", "/select,\"" + sFullName + "\"");
            //}
            OpenFolderHelper.ExplorerFile(sFullName);
        }

        static string NewLineStr(string oldStr, int len)
        {
            StringBuilder strb = new StringBuilder();
            for (int i = 0, counter = 0; i < oldStr.Length; i++)
            {
                strb.Append(oldStr[i]);
                int charcode = (int)(oldStr[i]);
                counter += (charcode > 0x4E00 && charcode < 0x9FA5) ? 2 : 1;
                if (counter >= len * 2)
                {
                    strb.Append(Environment.NewLine);
                    counter = 0;
                }
            }
            return strb.ToString();
        }

        private void btnUpdateByDataBase_Click(object sender, EventArgs e)
        {
            if (gridControlGrid.Visible)
            {
                MyKeyValueSetting currSetting;
                fmDataBase frm = new fmDataBase();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    currSetting = frm.currConnection;
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = currSetting.ConnectString;
                        con.Open();

                        string[] tableArray = currSetting.table.Split(';');
                        string[] fieldArray = currSetting.column.Split(';');
                        string sSql = string.Empty;
                        for (int i = 0; i < tableArray.Length; i++)
                        {
                            sSql += "select " + fieldArray[i] + " from " + tableArray[i] + "\r\n";
                            sSql += "union" + "\r\n";
                        }
                        if (!string.IsNullOrEmpty(sSql))
                            sSql = sSql.Substring(0, sSql.Length - 7);
                        SqlCommand com = new SqlCommand();
                        com.Connection = con;
                        com.CommandType = CommandType.Text;
                        com.CommandText = sSql;
                        SqlDataReader dr = com.ExecuteReader();//执行SQL语句

                        List<detailView> dataList = new List<detailView>();
                        while (dr.Read())
                        {
                            string strValue = dr.IsDBNull(0) ? "" : dr.GetValue(0).ToString();
                            string strName = dr.IsDBNull(1) ? "" : dr.GetValue(1).ToString();
                            string strMemo = dr.IsDBNull(2) ? "" : dr.GetValue(2).ToString();
                            string strDetail = dr.IsDBNull(3) ? "" : dr.GetValue(3).ToString();

                            detailView item = new detailView();
                            item.code = strValue;
                            item.name = strName;
                            item.note = strMemo.Replace('\t', ' ').Replace('\r', '#').Replace('\n', '^');
                            item.detail = strDetail.Replace('\t', ' ').Replace('\r', '#').Replace('\n', '^');
                            dataList.Add(item);
                        }
                        dr.Close();//关闭执行
                        con.Close();//关闭数据库

                        if (System.Windows.Forms.MessageBox.Show("是否覆盖现有的数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            addDataToView(dataList, true);
                        else
                            addDataToView(dataList, false);
                        //直接保存
                        btnSave.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                fmDataBase frm = new fmDataBase(false);
                frm.ShowDialog();
            }
        }

        private void listMain_DoubleClick(object sender, EventArgs e)
        {
            if (listMain.SelectedIndex < 0) return;
            string sName = (rgType.SelectedIndex == 0) ? "grid" : "memo";
            string sFullName = pubDefines.allPathDefine.mainSavePath + "\\" + sName + "_" + listMain.SelectedItem.ToString() + ".txt";
            OpenFolderHelper.ExplorerFile(sFullName);
        }

        private void fmUsefulInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            //注销热键
            HotKey.LogOutHotKey(this.Handle);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;//如果m.Msg的值为0x0312那么表示用户按下了热键
                                         //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    //switch (m.WParam.ToInt32())
                    //{
                    //    case 100:    //按下的是Shift+S
                    //                 //此处填写快捷键响应代码     
                    //        MessageBox.Show("aa");
                    //        break;
                    //}
                    HotKey.processsHotKey(m.WParam.ToInt32());
                    break;
            }
            base.WndProc(ref m);
        }
    }
}