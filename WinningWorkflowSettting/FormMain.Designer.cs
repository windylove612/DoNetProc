namespace WinningWorkflowSettting
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelTitleBar = new System.Windows.Forms.Panel();
            this.btnSrch = new System.Windows.Forms.Button();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.btnExpand = new System.Windows.Forms.Button();
            this.edtSrch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.edtDir = new System.Windows.Forms.TextBox();
            this.btnChoiceFile = new System.Windows.Forms.Button();
            this.PanelListBar = new System.Windows.Forms.Panel();
            this.treeWorkflow = new System.Windows.Forms.TreeView();
            this.PanelUpDown = new System.Windows.Forms.Panel();
            this.sbtnDown = new System.Windows.Forms.Button();
            this.sbtnUp = new System.Windows.Forms.Button();
            this.PanelFuncBar = new System.Windows.Forms.Panel();
            this.btnGetActivity = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.PanelRight = new System.Windows.Forms.Panel();
            this.btnIndex = new System.Windows.Forms.Button();
            this.comEnable = new System.Windows.Forms.ComboBox();
            this.comCreate = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.edtIndex = new System.Windows.Forms.TextBox();
            this.edtMemo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.edtFunction = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edtClass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edtModule = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edtLogic = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edtSectionName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edtSection = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelTitleBar.SuspendLayout();
            this.PanelListBar.SuspendLayout();
            this.PanelUpDown.SuspendLayout();
            this.PanelFuncBar.SuspendLayout();
            this.PanelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTitleBar
            // 
            this.PanelTitleBar.Controls.Add(this.btnSrch);
            this.PanelTitleBar.Controls.Add(this.btnCollapse);
            this.PanelTitleBar.Controls.Add(this.btnExpand);
            this.PanelTitleBar.Controls.Add(this.edtSrch);
            this.PanelTitleBar.Controls.Add(this.label1);
            this.PanelTitleBar.Controls.Add(this.edtDir);
            this.PanelTitleBar.Controls.Add(this.btnChoiceFile);
            this.PanelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.PanelTitleBar.Name = "PanelTitleBar";
            this.PanelTitleBar.Size = new System.Drawing.Size(877, 93);
            this.PanelTitleBar.TabIndex = 0;
            // 
            // btnSrch
            // 
            this.btnSrch.Location = new System.Drawing.Point(381, 39);
            this.btnSrch.Name = "btnSrch";
            this.btnSrch.Size = new System.Drawing.Size(68, 23);
            this.btnSrch.TabIndex = 6;
            this.btnSrch.Text = "搜索";
            this.btnSrch.UseVisualStyleBackColor = true;
            this.btnSrch.Click += new System.EventHandler(this.btnSrch_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.Location = new System.Drawing.Point(127, 66);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(109, 23);
            this.btnCollapse.TabIndex = 5;
            this.btnCollapse.Text = "全部节点收起";
            this.btnCollapse.UseVisualStyleBackColor = true;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // btnExpand
            // 
            this.btnExpand.Location = new System.Drawing.Point(12, 66);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(109, 23);
            this.btnExpand.TabIndex = 4;
            this.btnExpand.Text = "全部节点展开";
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // edtSrch
            // 
            this.edtSrch.Location = new System.Drawing.Point(76, 39);
            this.edtSrch.Name = "edtSrch";
            this.edtSrch.Size = new System.Drawing.Size(300, 21);
            this.edtSrch.TabIndex = 3;
            this.edtSrch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtSrch_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "搜索节点";
            // 
            // edtDir
            // 
            this.edtDir.Location = new System.Drawing.Point(127, 14);
            this.edtDir.Name = "edtDir";
            this.edtDir.Size = new System.Drawing.Size(529, 21);
            this.edtDir.TabIndex = 1;
            // 
            // btnChoiceFile
            // 
            this.btnChoiceFile.Location = new System.Drawing.Point(12, 12);
            this.btnChoiceFile.Name = "btnChoiceFile";
            this.btnChoiceFile.Size = new System.Drawing.Size(109, 23);
            this.btnChoiceFile.TabIndex = 0;
            this.btnChoiceFile.Text = "选择工作流文件";
            this.btnChoiceFile.UseVisualStyleBackColor = true;
            this.btnChoiceFile.Click += new System.EventHandler(this.btnChoiceFile_Click);
            // 
            // PanelListBar
            // 
            this.PanelListBar.Controls.Add(this.treeWorkflow);
            this.PanelListBar.Controls.Add(this.PanelUpDown);
            this.PanelListBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelListBar.Location = new System.Drawing.Point(0, 93);
            this.PanelListBar.Name = "PanelListBar";
            this.PanelListBar.Size = new System.Drawing.Size(436, 361);
            this.PanelListBar.TabIndex = 2;
            // 
            // treeWorkflow
            // 
            this.treeWorkflow.AllowDrop = true;
            this.treeWorkflow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeWorkflow.Location = new System.Drawing.Point(33, 0);
            this.treeWorkflow.Name = "treeWorkflow";
            this.treeWorkflow.Size = new System.Drawing.Size(403, 361);
            this.treeWorkflow.TabIndex = 2;
            this.treeWorkflow.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeWorkflow_AfterCheck);
            this.treeWorkflow.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeWorkflow_ItemDrag);
            this.treeWorkflow.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeWorkflow_AfterSelect);
            this.treeWorkflow.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeWorkflow_DragDrop);
            this.treeWorkflow.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeWorkflow_DragEnter);
            // 
            // PanelUpDown
            // 
            this.PanelUpDown.Controls.Add(this.sbtnDown);
            this.PanelUpDown.Controls.Add(this.sbtnUp);
            this.PanelUpDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelUpDown.Location = new System.Drawing.Point(0, 0);
            this.PanelUpDown.Name = "PanelUpDown";
            this.PanelUpDown.Size = new System.Drawing.Size(33, 361);
            this.PanelUpDown.TabIndex = 3;
            // 
            // sbtnDown
            // 
            this.sbtnDown.Image = global::WinningWorkflowSettting.Properties.Resources.timgdown;
            this.sbtnDown.Location = new System.Drawing.Point(3, 43);
            this.sbtnDown.Name = "sbtnDown";
            this.sbtnDown.Size = new System.Drawing.Size(26, 42);
            this.sbtnDown.TabIndex = 1;
            this.sbtnDown.UseVisualStyleBackColor = true;
            this.sbtnDown.Click += new System.EventHandler(this.sbtnDown_Click);
            // 
            // sbtnUp
            // 
            this.sbtnUp.Image = global::WinningWorkflowSettting.Properties.Resources.timgup1;
            this.sbtnUp.Location = new System.Drawing.Point(3, 0);
            this.sbtnUp.Name = "sbtnUp";
            this.sbtnUp.Size = new System.Drawing.Size(26, 42);
            this.sbtnUp.TabIndex = 0;
            this.sbtnUp.UseVisualStyleBackColor = true;
            this.sbtnUp.Click += new System.EventHandler(this.sbtnUp_Click);
            // 
            // PanelFuncBar
            // 
            this.PanelFuncBar.Controls.Add(this.btnGetActivity);
            this.PanelFuncBar.Controls.Add(this.btnSave);
            this.PanelFuncBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelFuncBar.Location = new System.Drawing.Point(0, 454);
            this.PanelFuncBar.Name = "PanelFuncBar";
            this.PanelFuncBar.Size = new System.Drawing.Size(877, 40);
            this.PanelFuncBar.TabIndex = 3;
            // 
            // btnGetActivity
            // 
            this.btnGetActivity.Location = new System.Drawing.Point(440, 6);
            this.btnGetActivity.Name = "btnGetActivity";
            this.btnGetActivity.Size = new System.Drawing.Size(97, 23);
            this.btnGetActivity.TabIndex = 6;
            this.btnGetActivity.Text = "获取工作流";
            this.btnGetActivity.UseVisualStyleBackColor = true;
            this.btnGetActivity.Click += new System.EventHandler(this.btnGetActivity_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(308, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // PanelRight
            // 
            this.PanelRight.Controls.Add(this.btnIndex);
            this.PanelRight.Controls.Add(this.comEnable);
            this.PanelRight.Controls.Add(this.comCreate);
            this.PanelRight.Controls.Add(this.label11);
            this.PanelRight.Controls.Add(this.label10);
            this.PanelRight.Controls.Add(this.edtIndex);
            this.PanelRight.Controls.Add(this.edtMemo);
            this.PanelRight.Controls.Add(this.label8);
            this.PanelRight.Controls.Add(this.edtFunction);
            this.PanelRight.Controls.Add(this.label7);
            this.PanelRight.Controls.Add(this.edtClass);
            this.PanelRight.Controls.Add(this.label6);
            this.PanelRight.Controls.Add(this.edtModule);
            this.PanelRight.Controls.Add(this.label5);
            this.PanelRight.Controls.Add(this.edtLogic);
            this.PanelRight.Controls.Add(this.label4);
            this.PanelRight.Controls.Add(this.edtSectionName);
            this.PanelRight.Controls.Add(this.label3);
            this.PanelRight.Controls.Add(this.edtSection);
            this.PanelRight.Controls.Add(this.label2);
            this.PanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelRight.Location = new System.Drawing.Point(436, 93);
            this.PanelRight.Name = "PanelRight";
            this.PanelRight.Size = new System.Drawing.Size(441, 361);
            this.PanelRight.TabIndex = 4;
            // 
            // btnIndex
            // 
            this.btnIndex.Location = new System.Drawing.Point(4, 283);
            this.btnIndex.Name = "btnIndex";
            this.btnIndex.Size = new System.Drawing.Size(64, 23);
            this.btnIndex.TabIndex = 42;
            this.btnIndex.Text = "索引值";
            this.btnIndex.UseVisualStyleBackColor = true;
            this.btnIndex.Click += new System.EventHandler(this.btnIndex_Click);
            // 
            // comEnable
            // 
            this.comEnable.FormattingEnabled = true;
            this.comEnable.Items.AddRange(new object[] {
            "是",
            "否"});
            this.comEnable.Location = new System.Drawing.Point(300, 321);
            this.comEnable.Name = "comEnable";
            this.comEnable.Size = new System.Drawing.Size(129, 20);
            this.comEnable.TabIndex = 41;
            // 
            // comCreate
            // 
            this.comCreate.FormattingEnabled = true;
            this.comCreate.Items.AddRange(new object[] {
            "是",
            "否"});
            this.comCreate.Location = new System.Drawing.Point(73, 321);
            this.comCreate.Name = "comCreate";
            this.comCreate.Size = new System.Drawing.Size(129, 20);
            this.comCreate.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(247, 327);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 39;
            this.label11.Text = "Enabled";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 324);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 37;
            this.label10.Text = "IsCreate";
            // 
            // edtIndex
            // 
            this.edtIndex.Location = new System.Drawing.Point(73, 284);
            this.edtIndex.Name = "edtIndex";
            this.edtIndex.Size = new System.Drawing.Size(356, 21);
            this.edtIndex.TabIndex = 36;
            // 
            // edtMemo
            // 
            this.edtMemo.Location = new System.Drawing.Point(73, 246);
            this.edtMemo.Name = "edtMemo";
            this.edtMemo.Size = new System.Drawing.Size(356, 21);
            this.edtMemo.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 33;
            this.label8.Text = "说明";
            // 
            // edtFunction
            // 
            this.edtFunction.Location = new System.Drawing.Point(73, 206);
            this.edtFunction.Name = "edtFunction";
            this.edtFunction.Size = new System.Drawing.Size(356, 21);
            this.edtFunction.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 31;
            this.label7.Text = "方法名";
            // 
            // edtClass
            // 
            this.edtClass.Location = new System.Drawing.Point(73, 164);
            this.edtClass.Name = "edtClass";
            this.edtClass.Size = new System.Drawing.Size(356, 21);
            this.edtClass.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "类名";
            // 
            // edtModule
            // 
            this.edtModule.Location = new System.Drawing.Point(73, 122);
            this.edtModule.Name = "edtModule";
            this.edtModule.Size = new System.Drawing.Size(356, 21);
            this.edtModule.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "模块名称";
            // 
            // edtLogic
            // 
            this.edtLogic.Location = new System.Drawing.Point(73, 80);
            this.edtLogic.Name = "edtLogic";
            this.edtLogic.Size = new System.Drawing.Size(356, 21);
            this.edtLogic.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "逻辑节点";
            // 
            // edtSectionName
            // 
            this.edtSectionName.Location = new System.Drawing.Point(73, 43);
            this.edtSectionName.Name = "edtSectionName";
            this.edtSectionName.Size = new System.Drawing.Size(356, 21);
            this.edtSectionName.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "节点名称";
            // 
            // edtSection
            // 
            this.edtSection.Location = new System.Drawing.Point(73, 5);
            this.edtSection.Name = "edtSection";
            this.edtSection.Size = new System.Drawing.Size(356, 21);
            this.edtSection.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "节点";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 494);
            this.Controls.Add(this.PanelRight);
            this.Controls.Add(this.PanelListBar);
            this.Controls.Add(this.PanelTitleBar);
            this.Controls.Add(this.PanelFuncBar);
            this.Name = "frmMain";
            this.Text = "工作流设置";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.PanelTitleBar.ResumeLayout(false);
            this.PanelTitleBar.PerformLayout();
            this.PanelListBar.ResumeLayout(false);
            this.PanelUpDown.ResumeLayout(false);
            this.PanelFuncBar.ResumeLayout(false);
            this.PanelRight.ResumeLayout(false);
            this.PanelRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitleBar;
        private System.Windows.Forms.TextBox edtDir;
        private System.Windows.Forms.Button btnChoiceFile;
        private System.Windows.Forms.Panel PanelListBar;
        private System.Windows.Forms.TreeView treeWorkflow;
        private System.Windows.Forms.Panel PanelFuncBar;
        private System.Windows.Forms.TextBox edtSrch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCollapse;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnSrch;
        private System.Windows.Forms.Panel PanelRight;
        private System.Windows.Forms.TextBox edtIndex;
        private System.Windows.Forms.TextBox edtMemo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox edtFunction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox edtClass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edtModule;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox edtLogic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edtSectionName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edtSection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comEnable;
        private System.Windows.Forms.ComboBox comCreate;
        private System.Windows.Forms.Button btnIndex;
        private System.Windows.Forms.Panel PanelUpDown;
        private System.Windows.Forms.Button sbtnDown;
        private System.Windows.Forms.Button sbtnUp;
        private System.Windows.Forms.Button btnGetActivity;
    }
}

