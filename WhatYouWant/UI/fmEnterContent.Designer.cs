namespace WhatYouWant
{
    partial class fmEnterContent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmEnterContent));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.edtValue = new DevExpress.XtraEditors.TextEdit();
            this.edtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.memoContent = new DevExpress.XtraEditors.MemoEdit();
            this.btnSure = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.memoDetail = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.edtValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDetail.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(27, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "代码值";
            // 
            // edtValue
            // 
            this.edtValue.Location = new System.Drawing.Point(117, 20);
            this.edtValue.Name = "edtValue";
            this.edtValue.Size = new System.Drawing.Size(240, 20);
            this.edtValue.TabIndex = 1;
            // 
            // edtName
            // 
            this.edtName.Location = new System.Drawing.Point(117, 71);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(240, 20);
            this.edtName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 74);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "属性值（名称）";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(27, 142);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "说明内容";
            // 
            // memoContent
            // 
            this.memoContent.Location = new System.Drawing.Point(117, 140);
            this.memoContent.Name = "memoContent";
            this.memoContent.Size = new System.Drawing.Size(460, 111);
            this.memoContent.TabIndex = 5;
            this.memoContent.UseOptimizedRendering = true;
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(170, 383);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 6;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(369, 383);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // memoDetail
            // 
            this.memoDetail.Location = new System.Drawing.Point(117, 266);
            this.memoDetail.Name = "memoDetail";
            this.memoDetail.Size = new System.Drawing.Size(460, 111);
            this.memoDetail.TabIndex = 9;
            this.memoDetail.UseOptimizedRendering = true;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(27, 268);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "详细说明";
            // 
            // fmEnterContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 418);
            this.Controls.Add(this.memoDetail);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.memoContent);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.edtValue);
            this.Controls.Add(this.labelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmEnterContent";
            this.Text = "内容录入";
            ((System.ComponentModel.ISupportInitialize)(this.edtValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDetail.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit edtValue;
        private DevExpress.XtraEditors.TextEdit edtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit memoContent;
        private DevExpress.XtraEditors.SimpleButton btnSure;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.MemoEdit memoDetail;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}