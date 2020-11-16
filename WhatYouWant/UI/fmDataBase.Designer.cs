namespace WhatYouWant
{
    partial class fmDataBase
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
            this.btnAddDataBase = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelDataBase = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.edtName = new DevExpress.XtraEditors.TextEdit();
            this.edtServer = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.edtDataBase = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.edtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.edtPassWord = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.PanelTitle = new DevExpress.XtraEditors.PanelControl();
            this.btnDelDetail = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddDetail = new DevExpress.XtraEditors.SimpleButton();
            this.gcDetail = new DevExpress.XtraGrid.GridControl();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColTable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColStr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnTest = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.edtFields = new DevExpress.XtraEditors.TextEdit();
            this.edtTable = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.PanelMain = new DevExpress.XtraEditors.PanelControl();
            this.gcShow = new DevExpress.XtraGrid.GridControl();
            this.gvShow = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColTableShow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColColumnShow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSure = new DevExpress.XtraEditors.SimpleButton();
            this.edtShowPsw = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.edtShowUser = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.edtShowDataBase = new DevExpress.XtraEditors.TextEdit();
            this.edtShowServer = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.comBoxLink = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDataBase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassWord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelTitle)).BeginInit();
            this.PanelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFields.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelMain)).BeginInit();
            this.PanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShowPsw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShowUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShowDataBase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShowServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comBoxLink.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddDataBase
            // 
            this.btnAddDataBase.Location = new System.Drawing.Point(4, 167);
            this.btnAddDataBase.Name = "btnAddDataBase";
            this.btnAddDataBase.Size = new System.Drawing.Size(75, 23);
            this.btnAddDataBase.TabIndex = 0;
            this.btnAddDataBase.Text = "添加链接";
            this.btnAddDataBase.Click += new System.EventHandler(this.btnAddDataBase_Click);
            // 
            // btnDelDataBase
            // 
            this.btnDelDataBase.Location = new System.Drawing.Point(85, 167);
            this.btnDelDataBase.Name = "btnDelDataBase";
            this.btnDelDataBase.Size = new System.Drawing.Size(75, 23);
            this.btnDelDataBase.TabIndex = 1;
            this.btnDelDataBase.Text = "删除链接";
            this.btnDelDataBase.Click += new System.EventHandler(this.btnDelDataBase_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "链接名称";
            // 
            // edtName
            // 
            this.edtName.Location = new System.Drawing.Point(68, 9);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(210, 20);
            this.edtName.TabIndex = 3;
            // 
            // edtServer
            // 
            this.edtServer.Location = new System.Drawing.Point(68, 35);
            this.edtServer.Name = "edtServer";
            this.edtServer.Size = new System.Drawing.Size(160, 20);
            this.edtServer.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "服务名";
            // 
            // edtDataBase
            // 
            this.edtDataBase.Location = new System.Drawing.Point(286, 35);
            this.edtDataBase.Name = "edtDataBase";
            this.edtDataBase.Size = new System.Drawing.Size(112, 20);
            this.edtDataBase.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(230, 38);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "数据库名";
            // 
            // edtUserName
            // 
            this.edtUserName.Location = new System.Drawing.Point(444, 35);
            this.edtUserName.Name = "edtUserName";
            this.edtUserName.Size = new System.Drawing.Size(106, 20);
            this.edtUserName.TabIndex = 9;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(402, 38);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "用户名";
            // 
            // edtPassWord
            // 
            this.edtPassWord.Location = new System.Drawing.Point(586, 35);
            this.edtPassWord.Name = "edtPassWord";
            this.edtPassWord.Size = new System.Drawing.Size(105, 20);
            this.edtPassWord.TabIndex = 11;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(556, 38);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 14);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "密码";
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.btnCopy);
            this.PanelTitle.Controls.Add(this.btnDelDetail);
            this.PanelTitle.Controls.Add(this.btnAddDetail);
            this.PanelTitle.Controls.Add(this.gcDetail);
            this.PanelTitle.Controls.Add(this.btnTest);
            this.PanelTitle.Controls.Add(this.labelControl13);
            this.PanelTitle.Controls.Add(this.edtFields);
            this.PanelTitle.Controls.Add(this.edtTable);
            this.PanelTitle.Controls.Add(this.labelControl14);
            this.PanelTitle.Controls.Add(this.labelControl1);
            this.PanelTitle.Controls.Add(this.edtPassWord);
            this.PanelTitle.Controls.Add(this.btnAddDataBase);
            this.PanelTitle.Controls.Add(this.labelControl5);
            this.PanelTitle.Controls.Add(this.btnDelDataBase);
            this.PanelTitle.Controls.Add(this.edtUserName);
            this.PanelTitle.Controls.Add(this.edtName);
            this.PanelTitle.Controls.Add(this.labelControl4);
            this.PanelTitle.Controls.Add(this.labelControl2);
            this.PanelTitle.Controls.Add(this.edtDataBase);
            this.PanelTitle.Controls.Add(this.edtServer);
            this.PanelTitle.Controls.Add(this.labelControl3);
            this.PanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitle.Location = new System.Drawing.Point(0, 0);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(773, 196);
            this.PanelTitle.TabIndex = 12;
            // 
            // btnDelDetail
            // 
            this.btnDelDetail.Location = new System.Drawing.Point(694, 116);
            this.btnDelDetail.Name = "btnDelDetail";
            this.btnDelDetail.Size = new System.Drawing.Size(75, 23);
            this.btnDelDetail.TabIndex = 19;
            this.btnDelDetail.Text = "删除明细";
            this.btnDelDetail.Click += new System.EventHandler(this.btnDelDetail_Click);
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.Location = new System.Drawing.Point(694, 87);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(75, 23);
            this.btnAddDetail.TabIndex = 18;
            this.btnAddDetail.Text = "添加明细";
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // gcDetail
            // 
            this.gcDetail.Location = new System.Drawing.Point(12, 87);
            this.gcDetail.MainView = this.gvDetail;
            this.gcDetail.Name = "gcDetail";
            this.gcDetail.Size = new System.Drawing.Size(676, 74);
            this.gcDetail.TabIndex = 17;
            this.gcDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            // 
            // gvDetail
            // 
            this.gvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColTable,
            this.ColStr});
            this.gvDetail.GridControl = this.gcDetail;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.OptionsBehavior.ReadOnly = true;
            this.gvDetail.OptionsView.ShowGroupPanel = false;
            // 
            // ColTable
            // 
            this.ColTable.Caption = "表名";
            this.ColTable.FieldName = "sTableName";
            this.ColTable.Name = "ColTable";
            this.ColTable.Visible = true;
            this.ColTable.VisibleIndex = 0;
            this.ColTable.Width = 109;
            // 
            // ColStr
            // 
            this.ColStr.Caption = "字段集合";
            this.ColStr.FieldName = "sFields";
            this.ColStr.Name = "ColStr";
            this.ColStr.Visible = true;
            this.ColStr.VisibleIndex = 1;
            this.ColStr.Width = 549;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(166, 167);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 16;
            this.btnTest.Text = "测试链接";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(12, 64);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(24, 14);
            this.labelControl13.TabIndex = 12;
            this.labelControl13.Text = "表名";
            // 
            // edtFields
            // 
            this.edtFields.Location = new System.Drawing.Point(286, 61);
            this.edtFields.Name = "edtFields";
            this.edtFields.Size = new System.Drawing.Size(402, 20);
            this.edtFields.TabIndex = 15;
            // 
            // edtTable
            // 
            this.edtTable.Location = new System.Drawing.Point(68, 61);
            this.edtTable.Name = "edtTable";
            this.edtTable.Size = new System.Drawing.Size(160, 20);
            this.edtTable.TabIndex = 13;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(230, 64);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(48, 14);
            this.labelControl14.TabIndex = 14;
            this.labelControl14.Text = "字段集合";
            // 
            // PanelMain
            // 
            this.PanelMain.Controls.Add(this.gcShow);
            this.PanelMain.Controls.Add(this.btnCancel);
            this.PanelMain.Controls.Add(this.btnSure);
            this.PanelMain.Controls.Add(this.edtShowPsw);
            this.PanelMain.Controls.Add(this.labelControl7);
            this.PanelMain.Controls.Add(this.edtShowUser);
            this.PanelMain.Controls.Add(this.labelControl8);
            this.PanelMain.Controls.Add(this.labelControl9);
            this.PanelMain.Controls.Add(this.edtShowDataBase);
            this.PanelMain.Controls.Add(this.edtShowServer);
            this.PanelMain.Controls.Add(this.labelControl10);
            this.PanelMain.Controls.Add(this.comBoxLink);
            this.PanelMain.Controls.Add(this.labelControl6);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 196);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(773, 187);
            this.PanelMain.TabIndex = 13;
            // 
            // gcShow
            // 
            this.gcShow.Location = new System.Drawing.Point(265, 5);
            this.gcShow.MainView = this.gvShow;
            this.gcShow.Name = "gcShow";
            this.gcShow.Size = new System.Drawing.Size(504, 143);
            this.gcShow.TabIndex = 26;
            this.gcShow.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvShow});
            // 
            // gvShow
            // 
            this.gvShow.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColTableShow,
            this.ColColumnShow});
            this.gvShow.GridControl = this.gcShow;
            this.gvShow.Name = "gvShow";
            this.gvShow.OptionsBehavior.ReadOnly = true;
            this.gvShow.OptionsView.ShowGroupPanel = false;
            // 
            // ColTableShow
            // 
            this.ColTableShow.Caption = "表名";
            this.ColTableShow.FieldName = "sTableName";
            this.ColTableShow.Name = "ColTableShow";
            this.ColTableShow.Visible = true;
            this.ColTableShow.VisibleIndex = 0;
            this.ColTableShow.Width = 96;
            // 
            // ColColumnShow
            // 
            this.ColColumnShow.Caption = "字段集合";
            this.ColColumnShow.FieldName = "sFields";
            this.ColColumnShow.Name = "ColColumnShow";
            this.ColColumnShow.Visible = true;
            this.ColColumnShow.VisibleIndex = 1;
            this.ColColumnShow.Width = 390;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(363, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(240, 155);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 24;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // edtShowPsw
            // 
            this.edtShowPsw.Location = new System.Drawing.Point(68, 128);
            this.edtShowPsw.Name = "edtShowPsw";
            this.edtShowPsw.Properties.ReadOnly = true;
            this.edtShowPsw.Size = new System.Drawing.Size(191, 20);
            this.edtShowPsw.TabIndex = 19;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 131);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(24, 14);
            this.labelControl7.TabIndex = 18;
            this.labelControl7.Text = "密码";
            // 
            // edtShowUser
            // 
            this.edtShowUser.Location = new System.Drawing.Point(68, 102);
            this.edtShowUser.Name = "edtShowUser";
            this.edtShowUser.Properties.ReadOnly = true;
            this.edtShowUser.Size = new System.Drawing.Size(191, 20);
            this.edtShowUser.TabIndex = 17;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 105);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(36, 14);
            this.labelControl8.TabIndex = 16;
            this.labelControl8.Text = "用户名";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 53);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(36, 14);
            this.labelControl9.TabIndex = 12;
            this.labelControl9.Text = "服务名";
            // 
            // edtShowDataBase
            // 
            this.edtShowDataBase.Location = new System.Drawing.Point(68, 76);
            this.edtShowDataBase.Name = "edtShowDataBase";
            this.edtShowDataBase.Properties.ReadOnly = true;
            this.edtShowDataBase.Size = new System.Drawing.Size(191, 20);
            this.edtShowDataBase.TabIndex = 15;
            // 
            // edtShowServer
            // 
            this.edtShowServer.Location = new System.Drawing.Point(68, 50);
            this.edtShowServer.Name = "edtShowServer";
            this.edtShowServer.Properties.ReadOnly = true;
            this.edtShowServer.Size = new System.Drawing.Size(191, 20);
            this.edtShowServer.TabIndex = 13;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(12, 79);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(48, 14);
            this.labelControl10.TabIndex = 14;
            this.labelControl10.Text = "数据库名";
            // 
            // comBoxLink
            // 
            this.comBoxLink.Location = new System.Drawing.Point(68, 6);
            this.comBoxLink.Name = "comBoxLink";
            this.comBoxLink.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comBoxLink.Size = new System.Drawing.Size(191, 20);
            this.comBoxLink.TabIndex = 6;
            this.comBoxLink.SelectedIndexChanged += new System.EventHandler(this.comBoxLink_SelectedIndexChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(14, 9);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(48, 14);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "选择链接";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(247, 167);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 20;
            this.btnCopy.Text = "复制链接";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // fmDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 383);
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.PanelTitle);
            this.Name = "fmDataBase";
            this.Text = "数据连接设置";
            this.Load += new System.EventHandler(this.fmDataBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDataBase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassWord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelTitle)).EndInit();
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFields.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelMain)).EndInit();
            this.PanelMain.ResumeLayout(false);
            this.PanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShowPsw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShowUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShowDataBase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShowServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comBoxLink.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnAddDataBase;
        private DevExpress.XtraEditors.SimpleButton btnDelDataBase;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit edtName;
        private DevExpress.XtraEditors.TextEdit edtServer;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit edtDataBase;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit edtUserName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit edtPassWord;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.PanelControl PanelTitle;
        private DevExpress.XtraEditors.PanelControl PanelMain;
        private DevExpress.XtraEditors.ComboBoxEdit comBoxLink;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit edtShowPsw;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit edtShowUser;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit edtShowDataBase;
        private DevExpress.XtraEditors.TextEdit edtShowServer;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSure;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.TextEdit edtFields;
        private DevExpress.XtraEditors.TextEdit edtTable;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.SimpleButton btnTest;
        private DevExpress.XtraGrid.GridControl gcDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn ColTable;
        private DevExpress.XtraGrid.Columns.GridColumn ColStr;
        private DevExpress.XtraEditors.SimpleButton btnDelDetail;
        private DevExpress.XtraEditors.SimpleButton btnAddDetail;
        private DevExpress.XtraGrid.GridControl gcShow;
        private DevExpress.XtraGrid.Views.Grid.GridView gvShow;
        private DevExpress.XtraGrid.Columns.GridColumn ColTableShow;
        private DevExpress.XtraGrid.Columns.GridColumn ColColumnShow;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
    }
}