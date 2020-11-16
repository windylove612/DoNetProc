using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace WhatYouWant
{
    public partial class fmDataBase : Form
    {
        public MyKeyValueSetting currConnection;
        public fmDataBase()
        {
            InitializeComponent();
            this.CenterToParent();
        }

        public fmDataBase(bool isShow)
        {
            InitializeComponent();
            this.CenterToParent();
            this.btnSure.Visible = isShow;
            this.btnCancel.Visible = isShow;
        }

        public DataBaseSection ConfigObj;
        private void fmDataBase_Load(object sender, EventArgs e)
        {
            SetComBox();
        }

        public class TableFields
        {
            public string sTableName { get; set; }
            public string sFields { get; set; }
        }

        private void SetComBox()
        {
            ConfigObj = (DataBaseSection)ConfigurationManager.GetSection("DataBaseSections");
            comBoxLink.SelectedIndex = -1;
            comBoxLink.Properties.Items.Clear();
            var lstSettings = ConfigObj.Section.Cast<MyKeyValueSetting>();
            foreach (var item in lstSettings)
            {
                comBoxLink.Properties.Items.Add(item.name);
            }
        }

        private void comBoxLink_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comBoxLink.SelectedIndex < 0)
            {
                Init();
            }
            else
            {
                GetSection(comBoxLink.SelectedItem.ToString());
            }
        }

        private void Init()
        {
            edtShowDataBase.Text = "";
            //edtShowFields.Text = "";
            edtShowPsw.Text = "";
            edtShowServer.Text = "";
            //edtShowTable.Text = "";
            edtShowUser.Text = "";
            gcShow.DataSource = null;
        }

        private void GetSection(string sName)
        {
            if (ConfigObj != null)
            {
                MyKeyValueSetting oneSetting = ConfigObj.Section[sName];
                //解析connectionstring,server=WINDYCOMPUTER\TESTDB;database=CIS_TEST;uid=sa;pwd=winning
                //edtShowFields.Text = oneSetting.column;
                //edtShowTable.Text = oneSetting.table;
                SetConnectString(oneSetting.ConnectString);
                //表格
                gcShow.DataSource = null;
                gcShow.RefreshDataSource();
                List<TableFields> showData = new List<TableFields>();
                string[] tableArray = oneSetting.table.Split(';');
                string[] fieldArray = oneSetting.column.Split(';');
                for (int i = 0; i < tableArray.Length; i++)
                {
                    TableFields item = new TableFields();
                    item.sTableName = tableArray[i];
                    item.sFields = fieldArray[i];
                    showData.Add(item);
                }
                gcShow.DataSource = showData;
                gcShow.RefreshDataSource();
            }
        }

        private void SetConnectString(string sConnection)
        {
            string[] connectList = sConnection.Split(';');
            int index = connectList[0].IndexOf("=");
            edtShowServer.Text = connectList[0].Substring(index + 1, connectList[0].Length - index - 1);
            index = connectList[1].IndexOf("=");
            edtShowDataBase.Text = connectList[1].Substring(index + 1, connectList[1].Length - index - 1);
            index = connectList[2].IndexOf("=");
            edtShowUser.Text = connectList[2].Substring(index + 1, connectList[2].Length - index - 1);
            index = connectList[3].IndexOf("=");
            edtShowPsw.Text = connectList[3].Substring(index + 1, connectList[3].Length - index - 1);
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (comBoxLink.SelectedIndex < 0)
            {
                MessageBox.Show("请选择数据链接！");
                return;
            }
            currConnection = ConfigObj.Section[comBoxLink.SelectedItem.ToString()];
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnDelDataBase_Click(object sender, EventArgs e)
        {
            if (comBoxLink.SelectedIndex < 0)
            {
                MessageBox.Show("请选择数据链接！");
                return;
            }
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            DataBaseSection currSection = (DataBaseSection)config.GetSection("DataBaseSections");
            currSection.Section.Remove(comBoxLink.SelectedItem.ToString());
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("DataBaseSections");
            SetComBox();
            MessageBox.Show("删除成功");
        }

        private void btnAddDataBase_Click(object sender, EventArgs e)
        {
            if (edtName.Text == "")
            {
                MessageBox.Show("请输入链接名称");
                return;
            }
            if (edtServer.Text == "")
            {
                MessageBox.Show("请输入服务名");
                return;
            }
            if (edtDataBase.Text == "")
            {
                MessageBox.Show("请输入数据库名");
                return;
            }
            if (edtUserName.Text == "")
            {
                MessageBox.Show("请输入用户名");
                return;
            }
            if (comBoxLink.Properties.Items.Contains(edtName.Text))
            {
                MessageBox.Show("该链接名称已存在！");
                return;
            }
            string sConnect = "server=" + edtServer.Text + ";database=" + edtDataBase.Text + ";uid=" + edtUserName.Text + ";pwd=" + edtPassWord.Text;
            MyKeyValueSetting addSetting = new MyKeyValueSetting();
            addSetting.ConnectString = sConnect;
            addSetting.name = edtName.Text;
            string[] sRetArray = GetStringArrayByList(gcDetail.DataSource as List<TableFields>);
            addSetting.table = sRetArray[0];
            addSetting.column = sRetArray[1];

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            DataBaseSection currSection = (DataBaseSection)config.GetSection("DataBaseSections");
            currSection.Section.Add(addSetting);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("DataBaseSections");
            SetComBox();
            MessageBox.Show("添加成功");
        }

        /// <summary>
        /// 返回字符串
        /// </summary>
        /// <param name="tableFields">列表</param>
        /// <returns></returns>
        private string[] GetStringArrayByList(List<TableFields> tableFields)
        {
            string[] sReturnArray = new string[2];
            string sTables = string.Empty;
            string sFields = string.Empty;
            foreach (TableFields item in tableFields)
            {
                sTables += item.sTableName + ";";
                sFields += item.sFields + ";";
            }
            if (!string.IsNullOrEmpty(sTables))
                sTables = sTables.Substring(0, sTables.Length - 1);
            if (!string.IsNullOrEmpty(sFields))
                sFields = sFields.Substring(0, sFields.Length - 1);
            sReturnArray[0] = sTables;
            sReturnArray[1] = sFields;
            return sReturnArray;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (edtName.Text == "")
            {
                MessageBox.Show("请输入链接名称");
                return;
            }
            if (edtServer.Text == "")
            {
                MessageBox.Show("请输入服务名");
                return;
            }
            if (edtDataBase.Text == "")
            {
                MessageBox.Show("请输入数据库名");
                return;
            }
            if (edtUserName.Text == "")
            {
                MessageBox.Show("请输入用户名");
                return;
            }
            string sConnect = "server=" + edtServer.Text + ";database=" + edtDataBase.Text + ";uid=" + edtUserName.Text + ";pwd=" + edtPassWord.Text;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = sConnect;
                con.Open();

                MessageBox.Show("测试链接成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("测试链接失败");
            }
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if ((edtTable.Text == "") || (edtFields.Text == ""))
            {
                MessageBox.Show("表名和字段集合不能为空！");
                return;
            }
            List<TableFields> gcDataSource = gcDetail.DataSource as List<TableFields>;

            TableFields tableFields = new TableFields();
            tableFields.sTableName = edtTable.Text;
            tableFields.sFields = edtFields.Text;
            if (gcDataSource == null)
                gcDataSource = new List<TableFields>();
            gcDataSource.Add(tableFields);
            gcDetail.DataSource = gcDataSource;
            gcDetail.RefreshDataSource();
        }

        private void btnDelDetail_Click(object sender, EventArgs e)
        {
            if (gvDetail.FocusedRowHandle < -1) return;
            List<TableFields> gcDataSource = gcDetail.DataSource as List<TableFields>;
            gcDataSource.RemoveAt(gvDetail.FocusedRowHandle);
            gcDetail.DataSource = gcDataSource;
            gcDetail.RefreshDataSource();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (comBoxLink.SelectedIndex < 0)
            {
                MessageBox.Show("请先选择现有链接！");
                return;
            }
            edtServer.Text = edtShowServer.Text;
            edtDataBase.Text = edtShowDataBase.Text;
            edtUserName.Text = edtShowUser.Text;
            edtPassWord.Text = edtShowPsw.Text;
            edtName.Text = comBoxLink.SelectedItem.ToString();
        }
    }
}
