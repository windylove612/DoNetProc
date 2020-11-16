namespace WhatYouWant
{
    partial class fmApiBigData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmApiBigData));
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnKuaidi = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(22, 12);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(146, 42);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "手机归属地查询";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnKuaidi
            // 
            this.btnKuaidi.Image = ((System.Drawing.Image)(resources.GetObject("btnKuaidi.Image")));
            this.btnKuaidi.Location = new System.Drawing.Point(22, 73);
            this.btnKuaidi.Name = "btnKuaidi";
            this.btnKuaidi.Size = new System.Drawing.Size(146, 42);
            this.btnKuaidi.TabIndex = 1;
            this.btnKuaidi.Text = "快递查询";
            this.btnKuaidi.Click += new System.EventHandler(this.btnKuaidi_Click);
            // 
            // fmApiBigData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 263);
            this.Controls.Add(this.btnKuaidi);
            this.Controls.Add(this.simpleButton1);
            this.Name = "fmApiBigData";
            this.Text = "api接口整合";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnKuaidi;
    }
}