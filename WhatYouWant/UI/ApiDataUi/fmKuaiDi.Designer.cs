namespace WhatYouWant
{
    partial class fmKuaiDi
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
            this.memoNr = new DevExpress.XtraEditors.MemoEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSrch = new DevExpress.XtraEditors.SimpleButton();
            this.edtKdh = new DevExpress.XtraEditors.TextEdit();
            this.comKd = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.memoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKdh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comKd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // memoNr
            // 
            this.memoNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoNr.Location = new System.Drawing.Point(0, 73);
            this.memoNr.Name = "memoNr";
            this.memoNr.Size = new System.Drawing.Size(428, 301);
            this.memoNr.TabIndex = 4;
            this.memoNr.UseOptimizedRendering = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSrch);
            this.panelControl1.Controls.Add(this.edtKdh);
            this.panelControl1.Controls.Add(this.comKd);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(428, 73);
            this.panelControl1.TabIndex = 5;
            // 
            // btnSrch
            // 
            this.btnSrch.Location = new System.Drawing.Point(303, 43);
            this.btnSrch.Name = "btnSrch";
            this.btnSrch.Size = new System.Drawing.Size(75, 23);
            this.btnSrch.TabIndex = 8;
            this.btnSrch.Text = "查询";
            this.btnSrch.Click += new System.EventHandler(this.btnSrch_Click);
            // 
            // edtKdh
            // 
            this.edtKdh.Location = new System.Drawing.Point(100, 44);
            this.edtKdh.Name = "edtKdh";
            this.edtKdh.Size = new System.Drawing.Size(182, 20);
            this.edtKdh.TabIndex = 7;
            // 
            // comKd
            // 
            this.comKd.Location = new System.Drawing.Point(100, 12);
            this.comKd.Name = "comKd";
            this.comKd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comKd.Size = new System.Drawing.Size(161, 20);
            this.comKd.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(46, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "快递单号";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(46, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "快递公司";
            // 
            // fmKuaiDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 374);
            this.Controls.Add(this.memoNr);
            this.Controls.Add(this.panelControl1);
            this.Name = "fmKuaiDi";
            this.Text = "快递查询";
            this.Load += new System.EventHandler(this.fmKuaiDi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKdh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comKd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit memoNr;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSrch;
        private DevExpress.XtraEditors.TextEdit edtKdh;
        private DevExpress.XtraEditors.ComboBoxEdit comKd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;

    }
}