namespace MA
{
    partial class MA_Report_General
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
            this.hbGroupControl1 = new HanbiControl.HbGroupControl();
            this.scLocation = new HanbiControl.HbPopupEditH();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.scEndDate = new HanbiControl.HbDateEditH();
            this.scStartDate = new HanbiControl.HbDateEditH();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.hbGroupControl2 = new HanbiControl.HbGroupControl();
            this.btnExport = new HanbiControl.HbSimpleButton();
            this.gridReport = new DevExpress.XtraGrid.GridControl();
            this.gridViewReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl1)).BeginInit();
            this.hbGroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl2)).BeginInit();
            this.hbGroupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReport)).BeginInit();
            this.SuspendLayout();
            // 
            // hbGroupControl1
            // 
            this.hbGroupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbGroupControl1.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbGroupControl1.Appearance.Options.UseFont = true;
            this.hbGroupControl1.AppearanceCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbGroupControl1.AppearanceCaption.Options.UseFont = true;
            this.hbGroupControl1.Controls.Add(this.scLocation);
            this.hbGroupControl1.Controls.Add(this.labelControl1);
            this.hbGroupControl1.Controls.Add(this.scEndDate);
            this.hbGroupControl1.Controls.Add(this.scStartDate);
            this.hbGroupControl1.HeaderTextId = "search";
            this.hbGroupControl1.Image = null;
            this.hbGroupControl1.Location = new System.Drawing.Point(3, 3);
            this.hbGroupControl1.Name = "hbGroupControl1";
            this.hbGroupControl1.ResId = "";
            this.hbGroupControl1.Size = new System.Drawing.Size(1041, 61);
            this.hbGroupControl1.TabIndex = 0;
            this.hbGroupControl1.Text = "Search";
            this.hbGroupControl1.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // scLocation
            // 
            this.scLocation.ConnectedControls = new HanbiControl.HbControl[0];
            this.scLocation.FieldName = "loc_nm";
            this.scLocation.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scLocation.HeaderTextId = "loc_nm";
            this.scLocation.Location = new System.Drawing.Point(5, 26);
            this.scLocation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scLocation.MaxLengh = 0;
            this.scLocation.Name = "scLocation";
            this.scLocation.PopupFormClassName = "popPickupLocation";
            this.scLocation.PopupFormDllName = "SYS";
            this.scLocation.ReadOnlyBackColorKeep = true;
            this.scLocation.ResId = "";
            this.scLocation.SelectionStart = 0;
            this.scLocation.Size = new System.Drawing.Size(225, 29);
            this.scLocation.TabIndex = 17;
            this.scLocation.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scLocation.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(439, 33);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(8, 13);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "~";
            // 
            // scEndDate
            // 
            this.scEndDate.DateTime = new System.DateTime(2020, 5, 30, 0, 0, 0, 0);
            this.scEndDate.FieldName = "end_date";
            this.scEndDate.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scEndDate.HeaderTextId = "end_date";
            this.scEndDate.Location = new System.Drawing.Point(451, 26);
            this.scEndDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scEndDate.MaxLengh = 0;
            this.scEndDate.Name = "scEndDate";
            this.scEndDate.ReadOnlyBackColorKeep = true;
            this.scEndDate.ResId = "";
            this.scEndDate.SelectionStart = 0;
            this.scEndDate.Size = new System.Drawing.Size(200, 29);
            this.scEndDate.TabIndex = 15;
            this.scEndDate.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scEndDate.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.scEndDate.Value = "2020-05-30";
            // 
            // scStartDate
            // 
            this.scStartDate.DateTime = new System.DateTime(2020, 5, 30, 0, 0, 0, 0);
            this.scStartDate.FieldName = "start_date";
            this.scStartDate.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scStartDate.HeaderTextId = "start_date";
            this.scStartDate.Location = new System.Drawing.Point(234, 26);
            this.scStartDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scStartDate.MaxLengh = 0;
            this.scStartDate.Name = "scStartDate";
            this.scStartDate.ReadOnlyBackColorKeep = true;
            this.scStartDate.ResId = "";
            this.scStartDate.SelectionStart = 0;
            this.scStartDate.Size = new System.Drawing.Size(200, 29);
            this.scStartDate.TabIndex = 14;
            this.scStartDate.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scStartDate.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.scStartDate.Value = "2020-05-30";
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // hbGroupControl2
            // 
            this.hbGroupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbGroupControl2.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbGroupControl2.Appearance.Options.UseFont = true;
            this.hbGroupControl2.AppearanceCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbGroupControl2.AppearanceCaption.Options.UseFont = true;
            this.hbGroupControl2.Controls.Add(this.btnExport);
            this.hbGroupControl2.Controls.Add(this.gridReport);
            this.hbGroupControl2.HeaderTextId = "store";
            this.hbGroupControl2.Image = null;
            this.hbGroupControl2.Location = new System.Drawing.Point(3, 70);
            this.hbGroupControl2.Name = "hbGroupControl2";
            this.hbGroupControl2.ResId = "";
            this.hbGroupControl2.Size = new System.Drawing.Size(1041, 523);
            this.hbGroupControl2.TabIndex = 2;
            this.hbGroupControl2.Text = "Store";
            this.hbGroupControl2.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExport.HeaderTextId = "export";
            this.btnExport.Image = null;
            this.btnExport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExport.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnExport.Location = new System.Drawing.Point(5, 26);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.ResId = "";
            this.btnExport.Size = new System.Drawing.Size(55, 55);
            this.btnExport.TabIndex = 1;
            this.btnExport.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnExport.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnExport_HbClick);
            // 
            // gridReport
            // 
            this.gridReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridReport.Location = new System.Drawing.Point(65, 26);
            this.gridReport.MainView = this.gridViewReport;
            this.gridReport.Name = "gridReport";
            this.gridReport.Size = new System.Drawing.Size(971, 494);
            this.gridReport.TabIndex = 0;
            this.gridReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewReport});
            // 
            // gridViewReport
            // 
            this.gridViewReport.GridControl = this.gridReport;
            this.gridViewReport.Name = "gridViewReport";
            this.gridViewReport.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewReport_FocusedRowChanged);
            this.gridViewReport.DoubleClick += new System.EventHandler(this.gridViewReport_DoubleClick);
            this.gridViewReport.DataSourceChanged += new System.EventHandler(this.gridViewReport_DataSourceChanged);
            // 
            // MA_Report_General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hbGroupControl2);
            this.Controls.Add(this.hbGroupControl1);
            this.Name = "MA_Report_General";
            this.Size = new System.Drawing.Size(1047, 596);
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl1)).EndInit();
            this.hbGroupControl1.ResumeLayout(false);
            this.hbGroupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl2)).EndInit();
            this.hbGroupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HanbiControl.HbGroupControl hbGroupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private HanbiControl.HbDateEditH scEndDate;
        private HanbiControl.HbDateEditH scStartDate;
        private HanbiControl.HbPopupEditH scLocation;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private HanbiControl.HbGroupControl hbGroupControl2;
        private HanbiControl.HbSimpleButton btnExport;
        private DevExpress.XtraGrid.GridControl gridReport;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewReport;
    }
}
