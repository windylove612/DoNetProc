namespace WhatYouWant
{
    partial class fmSetModelType
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
            this.listFl = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.edtName = new DevExpress.XtraEditors.TextEdit();
            this.btnQd = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.listFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // listFl
            // 
            this.listFl.Location = new System.Drawing.Point(12, 40);
            this.listFl.Name = "listFl";
            this.listFl.Size = new System.Drawing.Size(175, 195);
            this.listFl.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "已有分类";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(224, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "名称";
            // 
            // edtName
            // 
            this.edtName.Location = new System.Drawing.Point(224, 37);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(172, 20);
            this.edtName.TabIndex = 3;
            // 
            // btnQd
            // 
            this.btnQd.Location = new System.Drawing.Point(233, 109);
            this.btnQd.Name = "btnQd";
            this.btnQd.Size = new System.Drawing.Size(75, 23);
            this.btnQd.TabIndex = 4;
            this.btnQd.Text = "确定添加";
            this.btnQd.Click += new System.EventHandler(this.btnQd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(321, 109);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // fmSetModelType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 244);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnQd);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.listFl);
            this.Name = "fmSetModelType";
            this.Text = "设置分类";
            this.Load += new System.EventHandler(this.fmSetModelType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl listFl;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit edtName;
        private DevExpress.XtraEditors.SimpleButton btnQd;
        private DevExpress.XtraEditors.SimpleButton btnExit;
    }
}