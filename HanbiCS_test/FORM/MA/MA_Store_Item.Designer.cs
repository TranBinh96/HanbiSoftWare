namespace MA
{
    partial class MA_Store_Item
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
            this.hbGroupControl2 = new HanbiControl.HbGroupControl();
            this.btnExport = new HanbiControl.HbSimpleButton();
            this.grd_store = new DevExpress.XtraGrid.GridControl();
            this.grd_view_store = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.hbGroupControl4 = new HanbiControl.HbGroupControl();
            this.grd_item = new DevExpress.XtraGrid.GridControl();
            this.grd_view_item = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl1)).BeginInit();
            this.hbGroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl2)).BeginInit();
            this.hbGroupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_store)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_view_store)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl4)).BeginInit();
            this.hbGroupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_view_item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
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
            this.hbGroupControl2.Controls.Add(this.grd_store);
            this.hbGroupControl2.HeaderTextId = "store";
            this.hbGroupControl2.Image = null;
            this.hbGroupControl2.Location = new System.Drawing.Point(3, 0);
            this.hbGroupControl2.Name = "hbGroupControl2";
            this.hbGroupControl2.ResId = "";
            this.hbGroupControl2.Size = new System.Drawing.Size(1041, 281);
            this.hbGroupControl2.TabIndex = 1;
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
            // grd_store
            // 
            this.grd_store.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_store.Location = new System.Drawing.Point(65, 26);
            this.grd_store.MainView = this.grd_view_store;
            this.grd_store.Name = "grd_store";
            this.grd_store.Size = new System.Drawing.Size(971, 252);
            this.grd_store.TabIndex = 0;
            this.grd_store.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grd_view_store});
            // 
            // grd_view_store
            // 
            this.grd_view_store.GridControl = this.grd_store;
            this.grd_view_store.Name = "grd_view_store";
            this.grd_view_store.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grd_view_store_RowCellStyle);
            this.grd_view_store.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grd_view_store_FocusedRowChanged);
            this.grd_view_store.DoubleClick += new System.EventHandler(this.grd_view_store_DoubleClick);
            this.grd_view_store.DataSourceChanged += new System.EventHandler(this.grd_view_store_DataSourceChanged);
            // 
            // hbGroupControl4
            // 
            this.hbGroupControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbGroupControl4.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbGroupControl4.Appearance.Options.UseFont = true;
            this.hbGroupControl4.AppearanceCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbGroupControl4.AppearanceCaption.Options.UseFont = true;
            this.hbGroupControl4.Controls.Add(this.grd_item);
            this.hbGroupControl4.HeaderTextId = "item";
            this.hbGroupControl4.Image = null;
            this.hbGroupControl4.Location = new System.Drawing.Point(3, 1);
            this.hbGroupControl4.Name = "hbGroupControl4";
            this.hbGroupControl4.ResId = "";
            this.hbGroupControl4.Size = new System.Drawing.Size(1041, 235);
            this.hbGroupControl4.TabIndex = 3;
            this.hbGroupControl4.Text = "Item";
            this.hbGroupControl4.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // grd_item
            // 
            this.grd_item.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_item.Location = new System.Drawing.Point(5, 26);
            this.grd_item.MainView = this.grd_view_item;
            this.grd_item.Name = "grd_item";
            this.grd_item.Size = new System.Drawing.Size(1031, 204);
            this.grd_item.TabIndex = 1;
            this.grd_item.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grd_view_item});
            // 
            // grd_view_item
            // 
            this.grd_view_item.GridControl = this.grd_item;
            this.grd_view_item.Name = "grd_view_item";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 70);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.hbGroupControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.hbGroupControl4);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1047, 525);
            this.splitContainerControl1.SplitterPosition = 281;
            this.splitContainerControl1.TabIndex = 3;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // MA_Store_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.hbGroupControl1);
            this.Name = "MA_Store_Item";
            this.Size = new System.Drawing.Size(1047, 596);
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl1)).EndInit();
            this.hbGroupControl1.ResumeLayout(false);
            this.hbGroupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl2)).EndInit();
            this.hbGroupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_store)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_view_store)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl4)).EndInit();
            this.hbGroupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_view_item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HanbiControl.HbGroupControl hbGroupControl1;
        private HanbiControl.HbGroupControl hbGroupControl2;
        private HanbiControl.HbGroupControl hbGroupControl4;
        private DevExpress.XtraGrid.GridControl grd_store;
        private DevExpress.XtraGrid.Views.Grid.GridView grd_view_store;
        private DevExpress.XtraGrid.GridControl grd_item;
        private DevExpress.XtraGrid.Views.Grid.GridView grd_view_item;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private HanbiControl.HbDateEditH scEndDate;
        private HanbiControl.HbDateEditH scStartDate;
        private HanbiControl.HbPopupEditH scLocation;
        private HanbiControl.HbSimpleButton btnExport;
    }
}
