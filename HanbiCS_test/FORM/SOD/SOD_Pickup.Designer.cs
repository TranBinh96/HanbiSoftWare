namespace SOD
{
    partial class SOD_Pickup
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
            WebUtil.ProcAction procAction1 = new WebUtil.ProcAction();
            WebUtil.ProcAction procAction2 = new WebUtil.ProcAction();
            WebUtil.ProcAction procAction3 = new WebUtil.ProcAction();
            WebUtil.ProcAction procAction4 = new WebUtil.ProcAction();
            WebUtil.ProcAction procAction5 = new WebUtil.ProcAction();
            this.hbControlFind = new HanbiControl.HbGroupControl();
            this.scPicked = new HanbiControl.HbComboEditH();
            this.scStopOrder = new HanbiControl.HbComboEditH();
            this.scDelivered = new HanbiControl.HbComboEditH();
            this.scDeliveryOrder = new HanbiControl.HbComboEditH();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.scStartDate = new HanbiControl.HbDateEditH();
            this.scPickupStatus = new HanbiControl.HbComboEditH();
            this.scEndDate = new HanbiControl.HbDateEditH();
            this.scPickupLocation = new HanbiControl.HbPopupEditH();
            this.hbControlPickup = new HanbiControl.HbGroupControl();
            this.btnDeliveryOrder = new HanbiControl.HbSimpleButton();
            this.gridPickup = new DevExpress.XtraGrid.GridControl();
            this.gridViewPickup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.hbControlPickupOrderDetail = new HanbiControl.HbGroupControl();
            this.btnCancelProduct = new HanbiControl.HbSimpleButton();
            this.gridPickupDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewPickupDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlFind)).BeginInit();
            this.hbControlFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlPickup)).BeginInit();
            this.hbControlPickup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPickup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPickup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlPickupOrderDetail)).BeginInit();
            this.hbControlPickupOrderDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPickupDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPickupDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hbControlFind
            // 
            this.hbControlFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlFind.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlFind.Appearance.Options.UseFont = true;
            this.hbControlFind.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlFind.AppearanceCaption.Options.UseFont = true;
            this.hbControlFind.Controls.Add(this.scPicked);
            this.hbControlFind.Controls.Add(this.scStopOrder);
            this.hbControlFind.Controls.Add(this.scDelivered);
            this.hbControlFind.Controls.Add(this.scDeliveryOrder);
            this.hbControlFind.Controls.Add(this.labelControl1);
            this.hbControlFind.Controls.Add(this.scStartDate);
            this.hbControlFind.Controls.Add(this.scPickupStatus);
            this.hbControlFind.Controls.Add(this.scEndDate);
            this.hbControlFind.Controls.Add(this.scPickupLocation);
            this.hbControlFind.HeaderTextId = "find";
            this.hbControlFind.Image = null;
            this.hbControlFind.Location = new System.Drawing.Point(2, 2);
            this.hbControlFind.Margin = new System.Windows.Forms.Padding(2);
            this.hbControlFind.Name = "hbControlFind";
            this.hbControlFind.ResId = "";
            this.hbControlFind.Size = new System.Drawing.Size(945, 97);
            this.hbControlFind.TabIndex = 2;
            this.hbControlFind.Text = "검색";
            this.hbControlFind.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // scPicked
            // 
            this.scPicked.DataSource = null;
            this.scPicked.DefaultRowName = "All";
            this.scPicked.DefaultRowValue = "";
            this.scPicked.DictionaryList = null;
            this.scPicked.FieldName = "pick_yn";
            this.scPicked.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scPicked.HeaderTextId = "pick_yn";
            this.scPicked.Location = new System.Drawing.Point(3, 61);
            this.scPicked.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scPicked.Name = "scPicked";
            this.scPicked.ProcAction = procAction1;
            this.scPicked.ResId = "";
            this.scPicked.Size = new System.Drawing.Size(264, 29);
            this.scPicked.TabIndex = 4;
            this.scPicked.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scPicked.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.scPicked.Value = null;
            // 
            // scStopOrder
            // 
            this.scStopOrder.DataSource = null;
            this.scStopOrder.DefaultRowName = "All";
            this.scStopOrder.DefaultRowValue = "";
            this.scStopOrder.DictionaryList = null;
            this.scStopOrder.FieldName = "stop_yn";
            this.scStopOrder.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scStopOrder.HeaderTextId = "stop_yn";
            this.scStopOrder.Location = new System.Drawing.Point(695, 61);
            this.scStopOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scStopOrder.Name = "scStopOrder";
            this.scStopOrder.ProcAction = procAction2;
            this.scStopOrder.ResId = "";
            this.scStopOrder.Size = new System.Drawing.Size(200, 29);
            this.scStopOrder.TabIndex = 7;
            this.scStopOrder.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scStopOrder.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.scStopOrder.Value = null;
            // 
            // scDelivered
            // 
            this.scDelivered.DataSource = null;
            this.scDelivered.DefaultRowName = "All";
            this.scDelivered.DefaultRowValue = "";
            this.scDelivered.DictionaryList = null;
            this.scDelivered.FieldName = "delv_yn";
            this.scDelivered.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scDelivered.HeaderTextId = "delv_yn";
            this.scDelivered.Location = new System.Drawing.Point(479, 61);
            this.scDelivered.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scDelivered.Name = "scDelivered";
            this.scDelivered.ProcAction = procAction3;
            this.scDelivered.ResId = "";
            this.scDelivered.Size = new System.Drawing.Size(200, 29);
            this.scDelivered.TabIndex = 6;
            this.scDelivered.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scDelivered.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.scDelivered.Value = null;
            // 
            // scDeliveryOrder
            // 
            this.scDeliveryOrder.DataSource = null;
            this.scDeliveryOrder.DefaultRowName = "All";
            this.scDeliveryOrder.DefaultRowValue = "";
            this.scDeliveryOrder.DictionaryList = null;
            this.scDeliveryOrder.FieldName = "delv_ord_yn";
            this.scDeliveryOrder.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scDeliveryOrder.HeaderTextId = "delv_ord_yn";
            this.scDeliveryOrder.Location = new System.Drawing.Point(275, 61);
            this.scDeliveryOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scDeliveryOrder.Name = "scDeliveryOrder";
            this.scDeliveryOrder.ProcAction = procAction4;
            this.scDeliveryOrder.ResId = "";
            this.scDeliveryOrder.Size = new System.Drawing.Size(199, 29);
            this.scDeliveryOrder.TabIndex = 5;
            this.scDeliveryOrder.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scDeliveryOrder.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.scDeliveryOrder.Value = null;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(682, 31);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(8, 13);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "~";
            // 
            // scStartDate
            // 
            this.scStartDate.DateTime = new System.DateTime(2020, 5, 30, 0, 0, 0, 0);
            this.scStartDate.FieldName = "start_date";
            this.scStartDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scStartDate.HeaderTextId = "start_date";
            this.scStartDate.Location = new System.Drawing.Point(478, 25);
            this.scStartDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scStartDate.MaxLengh = 0;
            this.scStartDate.Name = "scStartDate";
            this.scStartDate.ReadOnlyBackColorKeep = true;
            this.scStartDate.ResId = "";
            this.scStartDate.SelectionStart = 0;
            this.scStartDate.Size = new System.Drawing.Size(200, 29);
            this.scStartDate.TabIndex = 2;
            this.scStartDate.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scStartDate.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.scStartDate.Value = "2020-05-30";
            // 
            // scPickupStatus
            // 
            this.scPickupStatus.DataSource = null;
            this.scPickupStatus.DefaultRowName = "All";
            this.scPickupStatus.DefaultRowValue = "";
            this.scPickupStatus.DictionaryList = null;
            this.scPickupStatus.FieldName = "pick_sts";
            this.scPickupStatus.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scPickupStatus.HeaderTextId = "pick_sts";
            this.scPickupStatus.Location = new System.Drawing.Point(274, 25);
            this.scPickupStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scPickupStatus.Name = "scPickupStatus";
            this.scPickupStatus.ProcAction = procAction5;
            this.scPickupStatus.ReadOnlyBackColorKeep = true;
            this.scPickupStatus.ResId = "";
            this.scPickupStatus.Size = new System.Drawing.Size(200, 29);
            this.scPickupStatus.TabIndex = 1;
            this.scPickupStatus.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scPickupStatus.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.scPickupStatus.Value = null;
            // 
            // scEndDate
            // 
            this.scEndDate.DateTime = new System.DateTime(2020, 5, 30, 0, 0, 0, 0);
            this.scEndDate.FieldName = "end_date";
            this.scEndDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scEndDate.HeaderTextId = "end_date";
            this.scEndDate.Location = new System.Drawing.Point(695, 24);
            this.scEndDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scEndDate.MaxLengh = 0;
            this.scEndDate.Name = "scEndDate";
            this.scEndDate.ResId = "";
            this.scEndDate.SelectionStart = 0;
            this.scEndDate.Size = new System.Drawing.Size(200, 29);
            this.scEndDate.TabIndex = 3;
            this.scEndDate.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scEndDate.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.scEndDate.Value = "2020-05-30";
            // 
            // scPickupLocation
            // 
            this.scPickupLocation.ConnectedControls = new HanbiControl.HbControl[0];
            this.scPickupLocation.FieldName = "loc_nm";
            this.scPickupLocation.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scPickupLocation.HeaderTextId = "loc_nm";
            this.scPickupLocation.Location = new System.Drawing.Point(3, 25);
            this.scPickupLocation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scPickupLocation.MaxLengh = 0;
            this.scPickupLocation.Name = "scPickupLocation";
            this.scPickupLocation.PopupFormClassName = "popPickupLocation";
            this.scPickupLocation.PopupFormDllName = "SYS";
            this.scPickupLocation.ReadOnlyBackColorKeep = true;
            this.scPickupLocation.ResId = "";
            this.scPickupLocation.SelectionStart = 0;
            this.scPickupLocation.Size = new System.Drawing.Size(265, 29);
            this.scPickupLocation.TabIndex = 0;
            this.scPickupLocation.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scPickupLocation.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // hbControlPickup
            // 
            this.hbControlPickup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlPickup.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlPickup.Appearance.Options.UseFont = true;
            this.hbControlPickup.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlPickup.AppearanceCaption.Options.UseFont = true;
            this.hbControlPickup.Controls.Add(this.btnDeliveryOrder);
            this.hbControlPickup.Controls.Add(this.gridPickup);
            this.hbControlPickup.HeaderTextId = "pick";
            this.hbControlPickup.Image = null;
            this.hbControlPickup.Location = new System.Drawing.Point(2, 2);
            this.hbControlPickup.Margin = new System.Windows.Forms.Padding(2);
            this.hbControlPickup.Name = "hbControlPickup";
            this.hbControlPickup.ResId = "";
            this.hbControlPickup.Size = new System.Drawing.Size(945, 281);
            this.hbControlPickup.TabIndex = 1;
            this.hbControlPickup.Text = "피킹";
            this.hbControlPickup.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // btnDeliveryOrder
            // 
            this.btnDeliveryOrder.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDeliveryOrder.HeaderTextId = "delivery_order";
            this.btnDeliveryOrder.Image = null;
            this.btnDeliveryOrder.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnDeliveryOrder.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDeliveryOrder.Location = new System.Drawing.Point(3, 25);
            this.btnDeliveryOrder.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDeliveryOrder.Name = "btnDeliveryOrder";
            this.btnDeliveryOrder.ResId = "";
            this.btnDeliveryOrder.Size = new System.Drawing.Size(53, 55);
            this.btnDeliveryOrder.TabIndex = 1;
            this.btnDeliveryOrder.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnDeliveryOrder.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnDeliveryOrder_Click);
            // 
            // gridPickup
            // 
            this.gridPickup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPickup.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridPickup.Location = new System.Drawing.Point(60, 25);
            this.gridPickup.MainView = this.gridViewPickup;
            this.gridPickup.Margin = new System.Windows.Forms.Padding(2);
            this.gridPickup.Name = "gridPickup";
            this.gridPickup.Size = new System.Drawing.Size(882, 252);
            this.gridPickup.TabIndex = 0;
            this.gridPickup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPickup});
            // 
            // gridViewPickup
            // 
            this.gridViewPickup.GridControl = this.gridPickup;
            this.gridViewPickup.Name = "gridViewPickup";
            this.gridViewPickup.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewPickup_RowCellStyle);
            this.gridViewPickup.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewPickup_RowStyle);
            this.gridViewPickup.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewPickup_FocusedRowChanged);
            this.gridViewPickup.DoubleClick += new System.EventHandler(this.gridViewPickup_DoubleClick);
            this.gridViewPickup.DataSourceChanged += new System.EventHandler(this.gridViewPickup_DataSourceChanged);
            // 
            // hbControlPickupOrderDetail
            // 
            this.hbControlPickupOrderDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlPickupOrderDetail.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlPickupOrderDetail.Appearance.Options.UseFont = true;
            this.hbControlPickupOrderDetail.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlPickupOrderDetail.AppearanceCaption.Options.UseFont = true;
            this.hbControlPickupOrderDetail.Controls.Add(this.btnCancelProduct);
            this.hbControlPickupOrderDetail.Controls.Add(this.gridPickupDetail);
            this.hbControlPickupOrderDetail.HeaderTextId = "pick_dtl";
            this.hbControlPickupOrderDetail.Image = null;
            this.hbControlPickupOrderDetail.Location = new System.Drawing.Point(2, 1);
            this.hbControlPickupOrderDetail.Margin = new System.Windows.Forms.Padding(2);
            this.hbControlPickupOrderDetail.Name = "hbControlPickupOrderDetail";
            this.hbControlPickupOrderDetail.ResId = "";
            this.hbControlPickupOrderDetail.Size = new System.Drawing.Size(945, 195);
            this.hbControlPickupOrderDetail.TabIndex = 3;
            this.hbControlPickupOrderDetail.Text = "피킹상세";
            this.hbControlPickupOrderDetail.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // btnCancelProduct
            // 
            this.btnCancelProduct.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancelProduct.HeaderTextId = "cancel";
            this.btnCancelProduct.Image = null;
            this.btnCancelProduct.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelProduct.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCancelProduct.Location = new System.Drawing.Point(4, 26);
            this.btnCancelProduct.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancelProduct.Name = "btnCancelProduct";
            this.btnCancelProduct.ResId = "";
            this.btnCancelProduct.Size = new System.Drawing.Size(53, 55);
            this.btnCancelProduct.TabIndex = 2;
            this.btnCancelProduct.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnCancelProduct.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnCancelProduct_HbClick);
            // 
            // gridPickupDetail
            // 
            this.gridPickupDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPickupDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridPickupDetail.Location = new System.Drawing.Point(60, 25);
            this.gridPickupDetail.MainView = this.gridViewPickupDetail;
            this.gridPickupDetail.Margin = new System.Windows.Forms.Padding(2);
            this.gridPickupDetail.Name = "gridPickupDetail";
            this.gridPickupDetail.Size = new System.Drawing.Size(882, 166);
            this.gridPickupDetail.TabIndex = 0;
            this.gridPickupDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPickupDetail});
            // 
            // gridViewPickupDetail
            // 
            this.gridViewPickupDetail.GridControl = this.gridPickupDetail;
            this.gridViewPickupDetail.Name = "gridViewPickupDetail";
            this.gridViewPickupDetail.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewPickupDetail_RowStyle);
            this.gridViewPickupDetail.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewPickupDetail_FocusedRowChanged);
            this.gridViewPickupDetail.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewPickupDetail_CellValueChanged);
            this.gridViewPickupDetail.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewPickupDetail_CellValueChanging);
            this.gridViewPickupDetail.DoubleClick += new System.EventHandler(this.gridViewPickupDetail_DoubleClick);
            this.gridViewPickupDetail.DataSourceChanged += new System.EventHandler(this.gridViewPickupDetail_DataSourceChanged);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 101);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.hbControlPickup);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.hbControlPickupOrderDetail);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(949, 486);
            this.splitContainerControl1.SplitterPosition = 284;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // SOD_Pickup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hbControlFind);
            this.Controls.Add(this.splitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SOD_Pickup";
            this.Size = new System.Drawing.Size(949, 588);
            ((System.ComponentModel.ISupportInitialize)(this.hbControlFind)).EndInit();
            this.hbControlFind.ResumeLayout(false);
            this.hbControlFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlPickup)).EndInit();
            this.hbControlPickup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPickup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPickup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlPickupOrderDetail)).EndInit();
            this.hbControlPickupOrderDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPickupDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPickupDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HanbiControl.HbGroupControl hbControlFind;
        private HanbiControl.HbPopupEditH scPickupLocation;
        private HanbiControl.HbComboEditH scPickupStatus;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private HanbiControl.HbDateEditH scEndDate;
        private HanbiControl.HbDateEditH scStartDate;
        private HanbiControl.HbGroupControl hbControlPickup;
        private DevExpress.XtraGrid.GridControl gridPickup;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPickup;
        private HanbiControl.HbGroupControl hbControlPickupOrderDetail;
        private DevExpress.XtraGrid.GridControl gridPickupDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPickupDetail;
        private HanbiControl.HbSimpleButton btnDeliveryOrder;
        private HanbiControl.HbComboEditH scStopOrder;
        private HanbiControl.HbComboEditH scDelivered;
        private HanbiControl.HbComboEditH scDeliveryOrder;
        private HanbiControl.HbComboEditH scPicked;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private HanbiControl.HbSimpleButton btnCancelProduct;
    }
}
