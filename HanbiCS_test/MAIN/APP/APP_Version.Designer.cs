namespace APP
{
    partial class APP_Version
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblText = new DevExpress.XtraEditors.LabelControl();
            this.pbTotal = new DevExpress.XtraEditors.ProgressBarControl();
            this.grpVersion = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.pbTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpVersion)).BeginInit();
            this.grpVersion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblText.Location = new System.Drawing.Point(5, 80);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(153, 25);
            this.lblText.TabIndex = 3;
            this.lblText.Text = "Checking update....";
            // 
            // pbTotal
            // 
            this.pbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTotal.Location = new System.Drawing.Point(5, 33);
            this.pbTotal.Name = "pbTotal";
            this.pbTotal.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.pbTotal.ShowProgressInTaskBar = true;
            this.pbTotal.Size = new System.Drawing.Size(728, 41);
            this.pbTotal.TabIndex = 2;
            // 
            // grpVersion
            // 
            this.grpVersion.Controls.Add(this.pbTotal);
            this.grpVersion.Controls.Add(this.lblText);
            this.grpVersion.Location = new System.Drawing.Point(2, 3);
            this.grpVersion.Name = "grpVersion";
            this.grpVersion.Size = new System.Drawing.Size(738, 115);
            this.grpVersion.TabIndex = 4;
            this.grpVersion.Text = "Version Update";
            // 
            // APP_Version
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpVersion);
            this.Name = "APP_Version";
            this.Size = new System.Drawing.Size(744, 122);
            this.Resize += new System.EventHandler(this.APP_Version_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpVersion)).EndInit();
            this.grpVersion.ResumeLayout(false);
            this.grpVersion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblText;
        private DevExpress.XtraEditors.ProgressBarControl pbTotal;
        private DevExpress.XtraEditors.GroupControl grpVersion;
    }
}
