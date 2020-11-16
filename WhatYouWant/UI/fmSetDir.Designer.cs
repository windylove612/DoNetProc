namespace WhatYouWant
{
    partial class fmSetDir
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmSetDir));
            this.btnMofidyDir = new DevExpress.XtraEditors.SimpleButton();
            this.btnSetMod = new DevExpress.XtraEditors.SimpleButton();
            this.edtDir = new DevExpress.XtraEditors.TextEdit();
            this.btnSaveDir = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.edtDir.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMofidyDir
            // 
            this.btnMofidyDir.Location = new System.Drawing.Point(201, 65);
            this.btnMofidyDir.Name = "btnMofidyDir";
            this.btnMofidyDir.Size = new System.Drawing.Size(75, 23);
            this.btnMofidyDir.TabIndex = 0;
            this.btnMofidyDir.Text = "路径修改器";
            this.btnMofidyDir.Click += new System.EventHandler(this.btnMofidyDir_Click);
            // 
            // btnSetMod
            // 
            this.btnSetMod.Location = new System.Drawing.Point(12, 12);
            this.btnSetMod.Name = "btnSetMod";
            this.btnSetMod.Size = new System.Drawing.Size(121, 23);
            this.btnSetMod.TabIndex = 1;
            this.btnSetMod.Text = "设置路径修改器地址";
            this.btnSetMod.Click += new System.EventHandler(this.btnSetMod_Click);
            // 
            // edtDir
            // 
            this.edtDir.Location = new System.Drawing.Point(140, 14);
            this.edtDir.Name = "edtDir";
            this.edtDir.Size = new System.Drawing.Size(374, 20);
            this.edtDir.TabIndex = 2;
            // 
            // btnSaveDir
            // 
            this.btnSaveDir.Location = new System.Drawing.Point(109, 65);
            this.btnSaveDir.Name = "btnSaveDir";
            this.btnSaveDir.Size = new System.Drawing.Size(75, 23);
            this.btnSaveDir.TabIndex = 3;
            this.btnSaveDir.Text = "保存路径";
            this.btnSaveDir.Click += new System.EventHandler(this.btnSaveDir_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(295, 65);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "退出";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // fmSetDir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 112);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveDir);
            this.Controls.Add(this.edtDir);
            this.Controls.Add(this.btnSetMod);
            this.Controls.Add(this.btnMofidyDir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmSetDir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edtDir.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnMofidyDir;
        private DevExpress.XtraEditors.SimpleButton btnSetMod;
        private DevExpress.XtraEditors.TextEdit edtDir;
        private DevExpress.XtraEditors.SimpleButton btnSaveDir;
        private DevExpress.XtraEditors.SimpleButton btnClose;

    }
}

