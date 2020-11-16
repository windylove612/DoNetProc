namespace WhatYouWant
{
    partial class fmSetOtherProcess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmSetOtherProcess));
            this.edtDir = new DevExpress.XtraEditors.TextEdit();
            this.btnSetMod = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.edtToolsName = new DevExpress.XtraEditors.TextEdit();
            this.btnSaveDir = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ComFl = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnFl = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lstTools = new DevExpress.XtraEditors.ListBoxControl();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.ComHotKey = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.ComHotKeyItem = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtToolsName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComFl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstTools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComHotKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComHotKeyItem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // edtDir
            // 
            this.edtDir.Location = new System.Drawing.Point(108, 109);
            this.edtDir.Name = "edtDir";
            this.edtDir.Size = new System.Drawing.Size(357, 20);
            this.edtDir.TabIndex = 4;
            // 
            // btnSetMod
            // 
            this.btnSetMod.Location = new System.Drawing.Point(35, 106);
            this.btnSetMod.Name = "btnSetMod";
            this.btnSetMod.Size = new System.Drawing.Size(65, 23);
            this.btnSetMod.TabIndex = 3;
            this.btnSetMod.Text = "设置路径";
            this.btnSetMod.Click += new System.EventHandler(this.btnSetMod_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 67);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "工具名称";
            // 
            // edtToolsName
            // 
            this.edtToolsName.Location = new System.Drawing.Point(108, 64);
            this.edtToolsName.Name = "edtToolsName";
            this.edtToolsName.Size = new System.Drawing.Size(261, 20);
            this.edtToolsName.TabIndex = 6;
            // 
            // btnSaveDir
            // 
            this.btnSaveDir.Location = new System.Drawing.Point(108, 188);
            this.btnSaveDir.Name = "btnSaveDir";
            this.btnSaveDir.Size = new System.Drawing.Size(75, 23);
            this.btnSaveDir.TabIndex = 7;
            this.btnSaveDir.Text = "保存";
            this.btnSaveDir.Click += new System.EventHandler(this.btnSaveDir_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(294, 188);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(35, 24);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "工具分类";
            // 
            // ComFl
            // 
            this.ComFl.Location = new System.Drawing.Point(108, 21);
            this.ComFl.Name = "ComFl";
            this.ComFl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComFl.Size = new System.Drawing.Size(261, 20);
            this.ComFl.TabIndex = 10;
            this.ComFl.SelectedIndexChanged += new System.EventHandler(this.ComFl_SelectedIndexChanged);
            // 
            // btnFl
            // 
            this.btnFl.Location = new System.Drawing.Point(384, 18);
            this.btnFl.Name = "btnFl";
            this.btnFl.Size = new System.Drawing.Size(65, 23);
            this.btnFl.TabIndex = 11;
            this.btnFl.Text = "设置分类";
            this.btnFl.Click += new System.EventHandler(this.btnFl_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(505, 18);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(96, 14);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "分类下已定义工具";
            // 
            // lstTools
            // 
            this.lstTools.Location = new System.Drawing.Point(505, 38);
            this.lstTools.Name = "lstTools";
            this.lstTools.Size = new System.Drawing.Size(187, 141);
            this.lstTools.TabIndex = 13;
            this.lstTools.SelectedIndexChanged += new System.EventHandler(this.lstTools_SelectedIndexChanged);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(203, 188);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 14;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(35, 151);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "快捷热键";
            // 
            // ComHotKey
            // 
            this.ComHotKey.Location = new System.Drawing.Point(108, 148);
            this.ComHotKey.Name = "ComHotKey";
            this.ComHotKey.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComHotKey.Properties.Items.AddRange(new object[] {
            "None",
            "Alt",
            "Ctrl",
            "Shift",
            "WindowsKey"});
            this.ComHotKey.Size = new System.Drawing.Size(96, 20);
            this.ComHotKey.TabIndex = 17;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(210, 151);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(8, 14);
            this.labelControl5.TabIndex = 18;
            this.labelControl5.Text = "+";
            // 
            // ComHotKeyItem
            // 
            this.ComHotKeyItem.Location = new System.Drawing.Point(224, 148);
            this.ComHotKeyItem.Name = "ComHotKeyItem";
            this.ComHotKeyItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComHotKeyItem.Properties.Items.AddRange(new object[] {
            "None",
            "Alt",
            "Ctrl",
            "Shift",
            "WindowsKey"});
            this.ComHotKeyItem.Size = new System.Drawing.Size(96, 20);
            this.ComHotKeyItem.TabIndex = 19;
            // 
            // fmSetOtherProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 223);
            this.Controls.Add(this.ComHotKeyItem);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.ComHotKey);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.lstTools);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnFl);
            this.Controls.Add(this.ComFl);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSaveDir);
            this.Controls.Add(this.edtToolsName);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.edtDir);
            this.Controls.Add(this.btnSetMod);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmSetOtherProcess";
            this.Text = "路径设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmSetOtherProcess_FormClosed);
            this.Load += new System.EventHandler(this.fmSetOtherProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edtDir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtToolsName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComFl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstTools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComHotKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComHotKeyItem.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit edtDir;
        private DevExpress.XtraEditors.SimpleButton btnSetMod;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit edtToolsName;
        private DevExpress.XtraEditors.SimpleButton btnSaveDir;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit ComFl;
        private DevExpress.XtraEditors.SimpleButton btnFl;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ListBoxControl lstTools;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit ComHotKey;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit ComHotKeyItem;
    }
}