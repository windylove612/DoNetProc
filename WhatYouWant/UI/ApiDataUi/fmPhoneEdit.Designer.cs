namespace WhatYouWant
{
    partial class fmPhoneEdit
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.edtPhone = new DevExpress.XtraEditors.TextEdit();
            this.btnSrch = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.edtPhone.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(34, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(221, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "请输入您要查询的手机号码：";
            // 
            // edtPhone
            // 
            this.edtPhone.Location = new System.Drawing.Point(34, 37);
            this.edtPhone.Name = "edtPhone";
            this.edtPhone.Size = new System.Drawing.Size(263, 20);
            this.edtPhone.TabIndex = 1;
            // 
            // btnSrch
            // 
            this.btnSrch.Location = new System.Drawing.Point(66, 72);
            this.btnSrch.Name = "btnSrch";
            this.btnSrch.Size = new System.Drawing.Size(75, 23);
            this.btnSrch.TabIndex = 2;
            this.btnSrch.Text = "查询";
            this.btnSrch.Click += new System.EventHandler(this.btnSrch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(191, 72);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fmPhoneEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 107);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSrch);
            this.Controls.Add(this.edtPhone);
            this.Controls.Add(this.labelControl1);
            this.Name = "fmPhoneEdit";
            this.Text = "手机号输入";
            ((System.ComponentModel.ISupportInitialize)(this.edtPhone.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit edtPhone;
        private DevExpress.XtraEditors.SimpleButton btnSrch;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}