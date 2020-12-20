namespace MA
{
    partial class MA_Supplier_Order
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
            WebUtil.ProcAction procAction2 = new WebUtil.ProcAction();
            this.hbGroupControl1 = new HanbiControl.HbGroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.scEndDate = new HanbiControl.HbDateEditH();
            this.scStartDate = new HanbiControl.HbDateEditH();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.hbGroupControl2 = new HanbiControl.HbGroupControl();
            this.btnExport = new HanbiControl.HbSimpleButton();
            this.grd_supplier = new DevExpress.XtraGrid.GridControl();
            this.grd_view_supplier = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.hbGroupControl3 = new HanbiControl.HbGroupControl();
            this.grd_order = new DevExpress.XtraGrid.GridControl();
            this.grd_view_order = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.scSupplier = new HanbiControl.HbComboEditH();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl1)).BeginInit();
            this.hbGroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl2)).BeginInit();
            this.hbGroupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_supplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_view_supplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl3)).BeginInit();
            this.hbGroupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_order)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_view_order)).BeginInit();
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
            this.hbGroupControl1.Controls.Add(this.scSupplier);
            this.hbGroupControl1.Controls.Add(this.labelControl1);
            this.hbGroupControl1.Controls.Add(this.scEndDate);
            this.hbGroupControl1.Controls.Add(this.scStartDate);
            this.hbGroupControl1.HeaderTextId = "search";
            this.hbGroupControl1.Image = null;
            this.hbGroupControl1.Location = new System.Drawing.Point(3, 3);
            this.hbGroupControl1.Name = "hbGroupControl1";
            this.hbGroupControl1.ResId = "";
            this.hbGroupControl1.Size = new System.Drawing.Size(1042, 60);
            this.hbGroupControl1.TabIndex = 0;
            this.hbGroupControl1.Text = "Search";
            this.hbGroupControl1.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(515, 35);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(8, 13);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "~";
            // 
            // scEndDate
            // 
            this.scEndDate.DateTime = new System.DateTime(2020, 5, 30, 0, 0, 0, 0);
            this.scEndDate.FieldName = "end_date";
            this.scEndDate.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scEndDate.HeaderTextId = "end_date";
            this.scEndDate.Location = new System.Drawing.Point(527, 27);
            this.scEndDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scEndDate.MaxLengh = 0;
            this.scEndDate.Name = "scEndDate";
            this.scEndDate.ReadOnlyBackColorKeep = true;
            this.scEndDate.ResId = "";
            this.scEndDate.SelectionStart = 0;
            this.scEndDate.Size = new System.Drawing.Size(200, 29);
            this.scEndDate.TabIndex = 22;
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
            this.scStartDate.Location = new System.Drawing.Point(310, 27);
            this.scStartDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scStartDate.MaxLengh = 0;
            this.scStartDate.Name = "scStartDate";
            this.scStartDate.ReadOnlyBackColorKeep = true;
            this.scStartDate.ResId = "";
            this.scStartDate.SelectionStart = 0;
            this.scStartDate.Size = new System.Drawing.Size(200, 29);
            this.scStartDate.TabIndex = 21;
            this.scStartDate.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scStartDate.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.scStartDate.Value = "2020-05-30";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(3, 69);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.hbGroupControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.hbGroupControl3);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1047, 524);
            this.splitContainerControl1.SplitterPosition = 281;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
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
            this.hbGroupControl2.Controls.Add(this.grd_supplier);
            this.hbGroupControl2.HeaderTextId = "supplier";
            this.hbGroupControl2.Image = null;
            this.hbGroupControl2.Location = new System.Drawing.Point(0, 0);
            this.hbGroupControl2.Name = "hbGroupControl2";
            this.hbGroupControl2.ResId = "";
            this.hbGroupControl2.Size = new System.Drawing.Size(1041, 281);
            this.hbGroupControl2.TabIndex = 0;
            this.hbGroupControl2.Text = null;
            this.hbGroupControl2.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExport.HeaderTextId = "export";
            this.btnExport.Image = null;
            this.btnExport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExport.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnExport.Location = new System.Drawing.Point(5, 24);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.ResId = "";
            this.btnExport.Size = new System.Drawing.Size(55, 55);
            this.btnExport.TabIndex = 1;
            this.btnExport.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnExport.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnExport_HbClick);
            // 
            // grd_supplier
            // 
            this.grd_supplier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_supplier.Location = new System.Drawing.Point(66, 24);
            this.grd_supplier.MainView = this.grd_view_supplier;
            this.grd_supplier.Name = "grd_supplier";
            this.grd_supplier.Size = new System.Drawing.Size(970, 252);
            this.grd_supplier.TabIndex = 0;
            this.grd_supplier.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grd_view_supplier});
            // 
            // grd_view_supplier
            // 
            this.grd_view_supplier.GridControl = this.grd_supplier;
            this.grd_view_supplier.Name = "grd_view_supplier";
            this.grd_view_supplier.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grd_view_supplier_RowCellStyle);
            this.grd_view_supplier.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grd_view_supplier_FocusedRowChanged);
            this.grd_view_supplier.DoubleClick += new System.EventHandler(this.grd_view_supplier_DoubleClick);
            this.grd_view_supplier.DataSourceChanged += new System.EventHandler(this.grd_view_supplier_DataSourceChanged);
            // 
            // hbGroupControl3
            // 
            this.hbGroupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbGroupControl3.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbGroupControl3.Appearance.Options.UseFont = true;
            this.hbGroupControl3.AppearanceCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbGroupControl3.AppearanceCaption.Options.UseFont = true;
            this.hbGroupControl3.Controls.Add(this.grd_order);
            this.hbGroupControl3.HeaderTextId = "order";
            this.hbGroupControl3.Image = null;
            this.hbGroupControl3.Location = new System.Drawing.Point(0, 0);
            this.hbGroupControl3.Name = "hbGroupControl3";
            this.hbGroupControl3.ResId = "";
            this.hbGroupControl3.Size = new System.Drawing.Size(1041, 235);
            this.hbGroupControl3.TabIndex = 0;
            this.hbGroupControl3.Text = "Order";
            this.hbGroupControl3.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // grd_order
            // 
            this.grd_order.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_order.Location = new System.Drawing.Point(5, 23);
            this.grd_order.MainView = this.grd_view_order;
            this.grd_order.Name = "grd_order";
            this.grd_order.Size = new System.Drawing.Size(1031, 204);
            this.grd_order.TabIndex = 0;
            this.grd_order.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grd_view_order});
            // 
            // grd_view_order
            // 
            this.grd_view_order.GridControl = this.grd_order;
            this.grd_view_order.Name = "grd_view_order";
            // 
            // scSupplier
            // 
            this.scSupplier.DataSource = null;
            this.scSupplier.DefaultRowName = "All";
            this.scSupplier.DefaultRowValue = "";
            this.scSupplier.DictionaryList = null;
            this.scSupplier.FieldName = "supplier_code";
            this.scSupplier.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scSupplier.HeaderTextId = "supplier_nm";
            this.scSupplier.HeaderWidth = 130;
            this.scSupplier.Location = new System.Drawing.Point(5, 27);
            this.scSupplier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scSupplier.Name = "scSupplier";
            this.scSupplier.ProcAction = procAction2;
            this.scSupplier.ReadOnlyBackColorKeep = true;
            this.scSupplier.ResId = "";
            this.scSupplier.Size = new System.Drawing.Size(300, 29);
            this.scSupplier.TabIndex = 1;
            this.scSupplier.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scSupplier.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.scSupplier.Value = null;
            // 
            // MA_Supplier_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.hbGroupControl1);
            this.Name = "MA_Supplier_Order";
            this.Size = new System.Drawing.Size(1047, 596);
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl1)).EndInit();
            this.hbGroupControl1.ResumeLayout(false);
            this.hbGroupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl2)).EndInit();
            this.hbGroupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_supplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_view_supplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl3)).EndInit();
            this.hbGroupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_order)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_view_order)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HanbiControl.HbGroupControl hbGroupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private HanbiControl.HbDateEditH scEndDate;
        private HanbiControl.HbDateEditH scStartDate;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private HanbiControl.HbGroupControl hbGroupControl2;
        private DevExpress.XtraGrid.GridControl grd_supplier;
        private DevExpress.XtraGrid.Views.Grid.GridView grd_view_supplier;
        private HanbiControl.HbSimpleButton btnExport;
        private HanbiControl.HbGroupControl hbGroupControl3;
        private DevExpress.XtraGrid.GridControl grd_order;
        private DevExpress.XtraGrid.Views.Grid.GridView grd_view_order;
        private HanbiControl.HbComboEditH scSupplier;
    }
}
