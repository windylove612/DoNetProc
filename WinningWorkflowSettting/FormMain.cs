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
using System.Xml.Linq;
using System.Xml;
using System.Data.SqlClient;

namespace WinningWorkflowSettting
{
    public partial class frmMain : Form
    {
        private List<SectionInfo> sectionInfo;
        private List<WorkflowInfo> workflowObj;
        private string sConfigName = string.Empty;
        public frmMain()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnChoiceFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.config)|*.config";
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
                sConfigName = fileDialog.SafeFileName;
                //if (MessageBox.Show("已选择文件:" + file + "，是否保存该配置", "选择文件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                //    return;
                //else
                //    this.btnSaveDir_Click(sender, e);
                sectionInfo = LoadFileSections(file);
                workflowObj = LoadFileByXml(file);
                if (workflowObj != null && workflowObj.Count > 0)
                {
                    SetWorkFlowToTreeView(workflowObj);
                }
            }
        }

        private List<SectionInfo> LoadFileSections(string fullConfigFileName)
        {
            List<SectionInfo> result = new List<SectionInfo>();
            XDocument doc = XDocument.Load(fullConfigFileName);
            XElement configurationElement = doc.Elements().FirstOrDefault(p => p.Name == "configuration");
            if (configurationElement != null)
            {
                //获取Section
                XElement SectionsElement = configurationElement.Elements().FirstOrDefault(p => p.Name == "configSections");
                if (SectionsElement != null)
                {
                    foreach (XElement nodeElement in SectionsElement.Elements())
                    {
                        string name = null;
                        string type = null;
                        foreach (XAttribute attribute in nodeElement.Attributes())
                        {
                            switch (attribute.Name.LocalName)
                            {
                                case "name":
                                    name = attribute.Value;
                                    break;
                                case "type":
                                    type = attribute.Value;
                                    break;
                                default:
                                    break;
                            }
                        }
                        SectionInfo sectionInfo = new SectionInfo(name, type);
                        result.Add(sectionInfo);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 从xml获取内容
        /// </summary>
        /// <param name="fullConfigFileName"></param>
        /// <returns></returns>
        private List<WorkflowInfo> LoadFileByXml(string fullConfigFileName)
        {
            List<WorkflowInfo> result = new List<WorkflowInfo>();

            XDocument doc = XDocument.Load(fullConfigFileName);
            XElement configurationElement = doc.Elements().FirstOrDefault(p => p.Name == "configuration");
            if (configurationElement != null)
            {
                //读取工作流配置
                XElement logicPathElement = configurationElement.Elements().FirstOrDefault(p => p.Name == "LogicPath");
                if (logicPathElement != null)
                {
                    XElement nodeGroupElement = logicPathElement.Elements().FirstOrDefault(p => p.Name == "NodeGroup");
                    if (nodeGroupElement != null)
                    {
                        foreach (XElement nodeElement in nodeGroupElement.Elements())
                        {
                            string id = null;
                            string name = null;
                            string title = null;
                            foreach (XAttribute attribute in nodeElement.Attributes())
                            {
                                switch (attribute.Name.LocalName)
                                {
                                    case "IndexId":
                                        id = attribute.Value;
                                        break;
                                    case "EventLogicPath":
                                        name = attribute.Value;
                                        break;
                                    case "Memo":
                                        title = attribute.Value;
                                        break;
                                    default:
                                        break;
                                }
                            }

                            WorkflowInfo workflow = new WorkflowInfo(id, name, title);
                            result.Add(workflow);
                        }
                    }
                }

                //读取工作流节点
                foreach (WorkflowInfo workflow in result)
                {
                    XElement workflowElement = configurationElement.Elements().FirstOrDefault(p => p.Name == workflow.Name);
                    if (workflowElement != null)
                    {
                        XElement nodeGroupElement = workflowElement.Elements().FirstOrDefault(p => p.Name == "NodeGroup");
                        if (nodeGroupElement != null)
                        {
                            foreach (XElement nodeElement in nodeGroupElement.Elements())
                            {
                                string id = null;
                                string workflowName = null;
                                string title = null;
                                bool isEnabled = false;
                                string moduleName = null;
                                string className = null;
                                string functionName = null;
                                bool isCreate = false;
                                foreach (XAttribute attribute in nodeElement.Attributes())
                                {
                                    switch (attribute.Name.LocalName)
                                    {
                                        case "IndexId":
                                            id = attribute.Value;
                                            break;
                                        case "SalfLogicPath":
                                            workflowName = attribute.Value;
                                            break;
                                        case "Enabled":
                                            isEnabled = attribute.Value != "false";
                                            break;
                                        case "Memo":
                                            title = attribute.Value;
                                            break;
                                        case "ModuleName":
                                            moduleName = attribute.Value;
                                            break;
                                        case "StartClass":
                                            className = attribute.Value;
                                            break;
                                        case "StartFunction":
                                            functionName = attribute.Value;
                                            break;
                                        case "IsCreate":
                                            isCreate = attribute.Value != "false";
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                List<string> names = new List<string>();
                                if (!string.IsNullOrWhiteSpace(functionName))
                                {
                                    names.Add(functionName);
                                }
                                if (!string.IsNullOrWhiteSpace(className))
                                {
                                    names.Add(className);
                                }
                                if (!string.IsNullOrWhiteSpace(moduleName))
                                {
                                    names.Add(moduleName);
                                }
                                ActivityInfo activity = new ActivityInfo(workflowName, id, title, isEnabled, functionName, moduleName, className, string.Join(",", names), workflow.Title, isCreate);
                                workflow.Activities.Add(activity);
                            }
                        }
                    }
                }
            }
            return result;
        }

        private void SetWorkFlowToTreeView(List<WorkflowInfo> WorkFlowList)
        {
            List<WorkflowInfo> WorkFlows = new List<WorkflowInfo>();
            foreach (WorkflowInfo item in WorkFlowList)
            {
                WorkflowInfo info = new WorkflowInfo();
                info = item.Clone();
                WorkFlows.Add(info);
            }
            WorkFlows = WorkFlows.OrderBy(p => p.Name).ToList();
            this.treeWorkflow.Nodes.Clear();
            try
            {
                TreeNode treeNodeFirst = new TreeNode();
                treeNodeFirst.Text = "工作流";
                treeNodeFirst.Name = "WorkFlow";
                treeNodeFirst.Tag = "LevelOne";
                foreach (WorkflowInfo item in WorkFlows)
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = item.Name + "(" + item.Title + ")";
                    treeNode.Name = item.Title;
                    treeNode.Tag = "LevelTwo";
                    foreach (ActivityInfo detail in item.Activities)
                    {
                        TreeNode treeNodeDetail = new TreeNode();
                        treeNodeDetail.Text = detail.FunctionName + "(" + detail.Title + ")";
                        treeNodeDetail.Name = detail.Title;
                        treeNodeDetail.Tag = detail;
                        treeNode.Nodes.Add(treeNodeDetail);
                    }
                    treeNodeFirst.Nodes.Add(treeNode);
                }
                this.treeWorkflow.Nodes.Add(treeNodeFirst);
                this.treeWorkflow.TopNode.Expand();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        private void edtSrch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SrchByCondition(edtSrch.Text);
            }
        }

        private void SrchByCondition(string srchStr)
        {
            SetAllNodesInit();
            foreach (TreeNode node in this.treeWorkflow.Nodes)
            {
                foreach (TreeNode nodeLevel in node.Nodes)
                {
                    nodeLevel.Collapse();
                }
            }
            FindNode(this.treeWorkflow.Nodes[0], srchStr);
        }

        private void SetAllNodesInit()
        {
            foreach (TreeNode node in this.treeWorkflow.Nodes)
            {
                node.Checked = false;
                foreach (TreeNode nodeLevel in node.Nodes)
                {
                    nodeLevel.Checked = false;
                    foreach (TreeNode nodeLevel2 in nodeLevel.Nodes)
                    {
                        nodeLevel2.Checked = false;
                    }
                }
            }
        }


        private List<TreeNode> nodesFindByCondition = new List<TreeNode>();
        public void FindNode(TreeNode tnParent, string strValue)
        {
            if (tnParent == null) return;
            if (strValue == "") return;
            if (tnParent.Text.ToLower().Contains(strValue.ToLower()) && (!tnParent.Checked))
            {
                tnParent.Checked = true;
                tnParent.ExpandAll();
                //如果是第三级的，上级也要展开
                if (tnParent.Parent.Tag.ToString() == "LevelTwo")
                {
                    tnParent.Parent.ExpandAll();
                }
            }

            foreach (TreeNode tn in tnParent.Nodes)
            {
                FindNode(tn, strValue);
            }
        }

        public List<TreeNode> FindNodes(string strValue)
        {
            if (strValue == "")
                return null;
            List<TreeNode> nodesGet = new List<TreeNode>();
            foreach (TreeNode item in this.treeWorkflow.Nodes)
            {
                if (item.Text.ToLower().Contains(strValue.ToLower()) && (!item.Checked))
                {
                    item.Checked = true;
                    nodesGet.Add(item);
                }
                else
                {
                    foreach (TreeNode itemTwo in item.Nodes)
                    {
                        if (itemTwo.Text.ToLower().Contains(strValue.ToLower()) && (!itemTwo.Checked))
                        {
                            itemTwo.Checked = true;
                            nodesGet.Add(itemTwo);
                        }
                        else
                        {
                            foreach (TreeNode itemThree in itemTwo.Nodes)
                            {
                                if (itemThree.Text.ToLower().Contains(strValue.ToLower()) && (!itemThree.Checked))
                                {
                                    itemThree.Checked = true;
                                    nodesGet.Add(itemThree);
                                }
                            }
                        }
                    }
                }
            }
            return nodesGet;
        }

        private void treeWorkflow_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetEditInit();
            TreeNode SelectObj = treeWorkflow.SelectedNode;
            if (SelectObj != null)
            {
                if (SelectObj.Tag.ToString() == "LevelOne")
                { }
                else if (SelectObj.Tag.ToString() == "LevelTwo")
                {
                    int index = SelectObj.Text.IndexOf("(");
                    edtSection.Text = SelectObj.Text.Substring(0, index);
                    edtSectionName.Text = SelectObj.Name;
                }
                else if (SelectObj.Tag.ToString() != "LevelOne" && SelectObj.Tag.ToString() != "LevelTwo")
                {
                    ActivityInfo detailInfo = SelectObj.Tag as ActivityInfo;
                    edtSection.Text = detailInfo.WorkflowName;
                    edtSectionName.Text = detailInfo.SectionName;
                    edtLogic.Text = detailInfo.WorkflowName;
                    edtModule.Text = detailInfo.ModuleName;
                    edtClass.Text = detailInfo.ClassName;
                    edtFunction.Text = detailInfo.FunctionName;
                    edtMemo.Text = detailInfo.Title;
                    edtIndex.Text = detailInfo.Id;
                    comCreate.SelectedIndex = detailInfo.IsCreate ? 0 : 1;
                    comEnable.SelectedIndex = detailInfo.IsEnabled ? 0 : 1;
                }
            }
        }

        private void SetEditInit()
        {
            edtSection.Text = "";
            edtSectionName.Text = "";
            edtLogic.Text = "";
            edtModule.Text = "";
            edtClass.Text = "";
            edtFunction.Text = "";
            edtMemo.Text = "";
            edtIndex.Text = "";
            comCreate.SelectedIndex = -1;
            comEnable.SelectedIndex = -1;
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            this.treeWorkflow.ExpandAll();
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            this.treeWorkflow.CollapseAll();
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            SrchByCondition(edtSrch.Text);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //this.treeWorkflow.DrawMode = TreeViewDrawMode.OwnerDrawText;
            //this.treeWorkflow.DrawNode += new DrawTreeNodeEventHandler(treeWorkflow_DrawNode);
        }

        //在绘制节点事件中，按自已想的绘制
        private void treeWorkflow_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            //e.DrawDefault = true; //我这里用默认颜色即可，只需要在TreeView失去焦点时选中节点仍然突显
            //return;
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                //演示为绿底白字
                e.Graphics.FillRectangle(Brushes.DarkBlue, e.Node.Bounds);
                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, Rectangle.Inflate(e.Bounds, 2, 0));
            }
            else
            {
                e.DrawDefault = true;
            }

            if ((e.State & TreeNodeStates.Focused) != 0)
            {
                using (Pen focusPen = new Pen(Color.Black))
                {
                    focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    Rectangle focusBounds = e.Node.Bounds;
                    focusBounds.Size = new Size(focusBounds.Width - 1,
                    focusBounds.Height - 1);
                    e.Graphics.DrawRectangle(focusPen, focusBounds);
                }
            }

        }

        private void treeWorkflow_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                e.Node.ForeColor = Color.Red;
                Font font = new Font(Font, FontStyle.Regular);
                e.Node.NodeFont = font;
            }
            else
            {
                e.Node.ForeColor = Color.Black;
                Font font = new Font(Font, FontStyle.Regular);
                e.Node.NodeFont = font;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sText = ConvertionToXml();
            int iReturn = DoSaveConfig(sText);
            if (iReturn == 1)
            {
                MessageBox.Show("保存成功！");
            }
            else if (iReturn == 2)
            {
                MessageBox.Show("保存失败！");
            }
            //DoSaveWorkFlowConfig();
        }

        /// <summary>
        /// 保存内容
        /// </summary>
        /// <param name="sText"></param>
        /// <returns>0忽略1成功2失败</returns>
        private void DoSaveWorkFlowConfig()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Config files (*.Config)|*.Config|All files (*.*)|*.*";
            saveDialog.RestoreDirectory = true;
            saveDialog.FileName = sConfigName;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    WorkFlowData flowFunction = new WorkFlowData();
                    flowFunction.CreateWorkflows(saveDialog.FileName, workflowObj);
                    MessageBox.Show("保存成功！");
                }
                catch
                {
                    MessageBox.Show("保存失败！");
                }
            }
        }

        /// <summary>
        /// 保存内容
        /// </summary>
        /// <param name="sText"></param>
        /// <returns>0忽略1成功2失败</returns>
        private int DoSaveConfig(string sText)
        {
            int isOk = 0;
            StreamWriter myStream;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Config files (*.Config)|*.Config|All files (*.*)|*.*";
            saveDialog.RestoreDirectory = true;
            saveDialog.FileName = sConfigName;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    myStream = new StreamWriter(saveDialog.FileName);
                    myStream.Write(sText);
                    myStream.Flush();
                    myStream.Close();
                    isOk = 1;
                }
                catch
                {
                    isOk = 2;
                }
            }
            else
            {
                isOk = 0;
            }
            return isOk;
        }

        private string ConvertionToXml()
        {
            string sText = string.Empty;
            sText += GetXmlString(CommonEnum.XmlType.XmlTile);
            sText += GetXmlString(CommonEnum.XmlType.XmlRoot);
            if (sectionInfo != null)
            {
                sText += FillChar(0, 4, ' ') + GetXmlString(CommonEnum.XmlType.XmlSelfDefine, "configSections");
                foreach (SectionInfo item in sectionInfo)
                {
                    sText += FillChar(0, 8, ' ') + "<section"
                            + " name=\"" + item.Name + "\""
                            + " type=\"" + item.Type + "\"" + " />" + Environment.NewLine;
                }
                sText += FillChar(0, 4, ' ') + GetXmlString(CommonEnum.XmlType.XmlSelfDefineTail, "configSections");
            }
            if (workflowObj != null)
            {
                sText += FillChar(0, 4, ' ') + GetXmlString(CommonEnum.XmlType.XmlSelfDefine, "LogicPath");
                sText += FillChar(0, 8, ' ') + GetXmlString(CommonEnum.XmlType.XmlSelfDefine, "NodeGroup");
                foreach (WorkflowInfo item in workflowObj)
                {
                    sText += FillChar(0, 12, ' ') + "<NodeInfo"
                            + " EventLogicPath=\"" + item.Name + "\""
                            + " GotoLogicPath=\"" + "" + "\""
                            + " Memo=\"" + item.Title + "\"" + Environment.NewLine
                            + FillChar(0, 16, ' ') + "IndexId=\"" + item.Id + "\"" + " />" + Environment.NewLine;
                }
                sText += FillChar(0, 8, ' ') + GetXmlString(CommonEnum.XmlType.XmlSelfDefineTail, "NodeGroup");
                sText += FillChar(0, 4, ' ') + GetXmlString(CommonEnum.XmlType.XmlSelfDefineTail, "LogicPath");
            }
            foreach (TreeNode item in this.treeWorkflow.Nodes)
            {
                if (item.Tag.ToString() == "LevelOne")
                {
                    foreach (TreeNode itemTwo in item.Nodes)
                    {
                        int index = itemTwo.Text.IndexOf("(");
                        string sSectionId = itemTwo.Text.Substring(0, index);
                        sText += FillChar(0, 4, ' ') + GetXmlString(CommonEnum.XmlType.XmlSelfDefine, sSectionId);
                        sText += FillChar(0, 8, ' ') + GetXmlString(CommonEnum.XmlType.XmlSelfDefine, "NodeGroup");
                        foreach (TreeNode itemThree in itemTwo.Nodes)
                        {
                            ActivityInfo activeInfo = itemThree.Tag as ActivityInfo;
                            sText += FillChar(0, 12, ' ') + "<NodeInfo"
                                    + " SalfLogicPath=\"" + activeInfo.WorkflowName + "\""
                                    + " GotoLogicPath=\"" + "" + "\""
                                    + " ModuleName=\"" + activeInfo.ModuleName + "\"" + Environment.NewLine
                                    + FillChar(0, 16, ' ') + "StartClass=\"" + activeInfo.ClassName + "\"" + Environment.NewLine
                                    + FillChar(0, 16, ' ') + "StartFunction=\"" + activeInfo.FunctionName + "\""
                                    + " IsCreate=\"" + (activeInfo.IsCreate ? "true" : "false") + "\""
                                    + " Enabled=\"" + (activeInfo.IsEnabled ? "true" : "false") + "\"" + Environment.NewLine
                                    + FillChar(0, 16, ' ') + "Memo=\"" + activeInfo.Title + "\""
                                    + " IndexId=\"" + activeInfo.Id + "\"" + " />" + Environment.NewLine;
                        }
                        sText += FillChar(0, 8, ' ') + GetXmlString(CommonEnum.XmlType.XmlSelfDefineTail, "NodeGroup");
                        sText += FillChar(0, 4, ' ') + GetXmlString(CommonEnum.XmlType.XmlSelfDefineTail, sSectionId);
                    }
                }
            }
            sText += GetXmlString(CommonEnum.XmlType.XmlRootTail);
            return sText;
        }

        private string FillChar(int iType, int TotalWidth, char c)
        {
            string sNr = string.Empty;
            if (iType == 0)
            {
                sNr = sNr.PadLeft(TotalWidth, c);
            }
            else if (iType == 1)
            {
                sNr = sNr.PadRight(TotalWidth, c);
            }
            return sNr;
        }

        private string GetXmlString(CommonEnum.XmlType xmlType, string sSelfDefineStr = "", bool isNeedNewLine = true)
        {
            string sContent = string.Empty;
            switch (xmlType)
            {
                case CommonEnum.XmlType.XmlTile:
                    sContent = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + (isNeedNewLine ? Environment.NewLine : "");
                    break;
                case CommonEnum.XmlType.XmlRoot:
                    sContent = "<configuration>" + (isNeedNewLine ? Environment.NewLine : "");
                    break;
                case CommonEnum.XmlType.XmlRootTail:
                    sContent = "</configuration>" + (isNeedNewLine ? Environment.NewLine : "");
                    break;
                case CommonEnum.XmlType.XmlSelfDefine:
                    sContent = "<" + sSelfDefineStr + ">" + (isNeedNewLine ? Environment.NewLine : "");
                    break;
                case CommonEnum.XmlType.XmlSelfDefineTail:
                    sContent = "</" + sSelfDefineStr + ">" + (isNeedNewLine ? Environment.NewLine : "");
                    break;
                default:
                    break;
            }
            return sContent;
        }

        private void btnIndex_Click(object sender, EventArgs e)
        {
            edtIndex.Text = Guid.NewGuid().ToString();
        }

        private void sbtnUp_Click(object sender, EventArgs e)
        {
            TreeNode Node = this.treeWorkflow.SelectedNode;
            if (Node.Tag.ToString() == "LevelOne" || Node.Tag.ToString() == "LevelTwo")
                return;
            TreeNode PrevNode = Node.PrevNode;
            if (PrevNode != null)
            {
                TreeNode NewNode = (TreeNode)Node.Clone();
                if (Node.Parent == null)
                {
                    this.treeWorkflow.Nodes.Insert(PrevNode.Index, NewNode);
                }
                else
                {
                    Node.Parent.Nodes.Insert(PrevNode.Index, NewNode);
                }
                Node.Remove();
                this.treeWorkflow.SelectedNode = NewNode;
            }
        }

        private void sbtnDown_Click(object sender, EventArgs e)
        {
            TreeNode Node = this.treeWorkflow.SelectedNode;
            if (Node.Tag.ToString() == "LevelOne" || Node.Tag.ToString() == "LevelTwo")
                return;
            TreeNode NextNode = Node.NextNode;
            if (NextNode != null)
            {
                TreeNode NewNode = (TreeNode)Node.Clone();
                if (Node.Parent == null)
                {
                    this.treeWorkflow.Nodes.Insert(NextNode.Index + 1, NewNode);
                }
                else
                {
                    Node.Parent.Nodes.Insert(NextNode.Index + 1, NewNode);
                }
                Node.Remove();
                this.treeWorkflow.SelectedNode = NewNode;
            }
        }

        private void treeWorkflow_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void treeWorkflow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode"))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void treeWorkflow_DragDrop(object sender, DragEventArgs e)
        {
            //获得拖放中的节点
            TreeNode moveNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            //根据鼠标坐标确定要移动到的目标节点
            Point pt;
            TreeNode targeNode;
            pt = ((TreeView)(sender)).PointToClient(new Point(e.X, e.Y));
            targeNode = this.treeWorkflow.GetNodeAt(pt);

            //如果目标节点无子节点则添加为同级节点,反之添加到下级节点的未端
            TreeNode NewMoveNode = (TreeNode)moveNode.Clone();
            if (targeNode.Nodes.Count == 0)
            {
                targeNode.Parent.Nodes.Insert(targeNode.Index, NewMoveNode);
            }
            else
            {
                targeNode.Nodes.Insert(targeNode.Nodes.Count, NewMoveNode);
            }
            //更新当前拖动的节点选择
            this.treeWorkflow.SelectedNode = NewMoveNode;
            //展开目标节点,便于显示拖放效果
            targeNode.Expand();
            //移除拖放的节点
            moveNode.Remove();
        }

        public class aaa
        {
            public string sZddm { get; set; }
            public string sZdmc { get; set; }
            public int iXh { get; set; }

        }
        private void btnGetActivity_Click(object sender, EventArgs e)
        {
            List<aaa> ab = new List<aaa>();
            ab.Add(new aaa { sZddm = "aa",sZdmc = "bb", iXh = 1});
            ab.Add(new aaa { sZddm = "aa", sZdmc = "bb", iXh = 2 });
            ab.Add(new aaa { sZddm = "aa", sZdmc = "bb", iXh = 3 });


            #region 字段值组装
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@ID",SqlDbType.VarChar),   //医院代码
                new SqlParameter("@NAME",SqlDbType.VarChar), //医院名称
            };
            param[0].Value = "aa"; //医院代码
            param[1].Value = "bb"; //医院代码
            //param.SetValue("bb", 1); //医院名称

            Hashtable ht = new Hashtable();
            for (int i = 0; i < param.Length; i++)
            {
                ht.Add(param[i].ParameterName, param[i].Value);
            }
            #endregion
            string aa = Newtonsoft.Json.JsonConvert.SerializeObject(ht);

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.dll)|*.dll";
            fileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                WorkFlowData workGet = new WorkFlowData();
                List<ComponentInfo> aaa = workGet.LoadTypeFromAssembly(file, "");
            }
        }
    }
}
