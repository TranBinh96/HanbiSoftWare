namespace SOD
{
    partial class SOD_Delivery
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
            this.hbControlFind = new HanbiControl.HbGroupControl();
            this.scStopOrder = new HanbiControl.HbComboEditH();
            this.scDelivered = new HanbiControl.HbComboEditH();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.scEndDate = new HanbiControl.HbDateEditH();
            this.scStartDate = new HanbiControl.HbDateEditH();
            this.scShipAddress = new HanbiControl.HbTextEditH();
            this.scFullName = new HanbiControl.HbTextEditH();
            this.scPickupLocation = new HanbiControl.HbPopupEditH();
            this.scTelNo = new HanbiControl.HbTextEditH();
            this.hbControlDelivery = new HanbiControl.HbGroupControl();
            this.btnReturn = new HanbiControl.HbSimpleButton();
            this.btnDeliveryFinish = new HanbiControl.HbSimpleButton();
            this.gridDelivery = new DevExpress.XtraGrid.GridControl();
            this.gridViewDelivery = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.hbControlDeliveryDetail = new HanbiControl.HbGroupControl();
            this.gridDeliveryDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewDeliveryDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlFind)).BeginInit();
            this.hbControlFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlDelivery)).BeginInit();
            this.hbControlDelivery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlDeliveryDetail)).BeginInit();
            this.hbControlDeliveryDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDeliveryDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDeliveryDetail)).BeginInit();
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
            this.hbControlFind.Controls.Add(this.scStopOrder);
            this.hbControlFind.Controls.Add(this.scDelivered);
            this.hbControlFind.Controls.Add(this.labelControl1);
            this.hbControlFind.Controls.Add(this.scEndDate);
            this.hbControlFind.Controls.Add(this.scStartDate);
            this.hbControlFind.Controls.Add(this.scShipAddress);
            this.hbControlFind.Controls.Add(this.scFullName);
            this.hbControlFind.Controls.Add(this.scPickupLocation);
            this.hbControlFind.Controls.Add(this.scTelNo);
            this.hbControlFind.HeaderTextId = "find";
            this.hbControlFind.Image = null;
            this.hbControlFind.Location = new System.Drawing.Point(2, 2);
            this.hbControlFind.Margin = new System.Windows.Forms.Padding(2);
            this.hbControlFind.Name = "hbControlFind";
            this.hbControlFind.ResId = "";
            this.hbControlFind.Size = new System.Drawing.Size(887, 97);
            this.hbControlFind.TabIndex = 2;
            this.hbControlFind.Text = "검색";
            this.hbControlFind.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
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
            this.scStopOrder.Location = new System.Drawing.Point(678, 61);
            this.scStopOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scStopOrder.Name = "scStopOrder";
            this.scStopOrder.ProcAction = procAction1;
            this.scStopOrder.ReadOnlyBackColorKeep = true;
            this.scStopOrder.ResId = "";
            this.scStopOrder.Size = new System.Drawing.Size(200, 29);
            this.scStopOrder.TabIndex = 8;
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
            this.scDelivered.Location = new System.Drawing.Point(678, 25);
            this.scDelivered.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scDelivered.Name = "scDelivered";
            this.scDelivered.ProcAction = procAction2;
            this.scDelivered.ResId = "";
            this.scDelivered.Size = new System.Drawing.Size(200, 29);
            this.scDelivered.TabIndex = 4;
            this.scDelivered.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scDelivered.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.scDelivered.Value = null;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(461, 34);
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
            this.scEndDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scEndDate.HeaderTextId = "end_date";
            this.scEndDate.Location = new System.Drawing.Point(473, 25);
            this.scEndDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scEndDate.MaxLengh = 0;
            this.scEndDate.Name = "scEndDate";
            this.scEndDate.ReadOnlyBackColorKeep = true;
            this.scEndDate.ResId = "";
            this.scEndDate.SelectionStart = 0;
            this.scEndDate.Size = new System.Drawing.Size(200, 29);
            this.scEndDate.TabIndex = 3;
            this.scEndDate.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scEndDate.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.scEndDate.Value = "2020-05-30";
            // 
            // scStartDate
            // 
            this.scStartDate.DateTime = new System.DateTime(2020, 5, 30, 0, 0, 0, 0);
            this.scStartDate.FieldName = "start_date";
            this.scStartDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scStartDate.HeaderTextId = "start_date";
            this.scStartDate.Location = new System.Drawing.Point(257, 25);
            this.scStartDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scStartDate.MaxLengh = 0;
            this.scStartDate.Name = "scStartDate";
            this.scStartDate.ResId = "";
            this.scStartDate.SelectionStart = 0;
            this.scStartDate.Size = new System.Drawing.Size(200, 29);
            this.scStartDate.TabIndex = 2;
            this.scStartDate.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scStartDate.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.scStartDate.Value = "2020-05-30";
            // 
            // scShipAddress
            // 
            this.scShipAddress.FieldName = "ship_addr";
            this.scShipAddress.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scShipAddress.HeaderTextId = "ship_addr";
            this.scShipAddress.Location = new System.Drawing.Point(3, 61);
            this.scShipAddress.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scShipAddress.MaxLengh = 0;
            this.scShipAddress.Name = "scShipAddress";
            this.scShipAddress.ResId = "";
            this.scShipAddress.SelectionStart = 0;
            this.scShipAddress.Size = new System.Drawing.Size(250, 29);
            this.scShipAddress.TabIndex = 5;
            this.scShipAddress.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scShipAddress.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // scFullName
            // 
            this.scFullName.FieldName = "full_name";
            this.scFullName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scFullName.HeaderTextId = "full_name";
            this.scFullName.Location = new System.Drawing.Point(257, 61);
            this.scFullName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scFullName.MaxLengh = 0;
            this.scFullName.Name = "scFullName";
            this.scFullName.ResId = "";
            this.scFullName.SelectionStart = 0;
            this.scFullName.Size = new System.Drawing.Size(200, 29);
            this.scFullName.TabIndex = 6;
            this.scFullName.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scFullName.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
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
            this.scPickupLocation.ResId = "";
            this.scPickupLocation.SelectionStart = 0;
            this.scPickupLocation.Size = new System.Drawing.Size(250, 29);
            this.scPickupLocation.TabIndex = 1;
            this.scPickupLocation.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scPickupLocation.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // scTelNo
            // 
            this.scTelNo.FieldName = "tel_no";
            this.scTelNo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scTelNo.HeaderTextId = "tel_no";
            this.scTelNo.Location = new System.Drawing.Point(473, 61);
            this.scTelNo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scTelNo.MaxLengh = 0;
            this.scTelNo.Name = "scTelNo";
            this.scTelNo.ReadOnlyBackColorKeep = true;
            this.scTelNo.ResId = "";
            this.scTelNo.SelectionStart = 0;
            this.scTelNo.Size = new System.Drawing.Size(200, 29);
            this.scTelNo.TabIndex = 7;
            this.scTelNo.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scTelNo.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // hbControlDelivery
            // 
            this.hbControlDelivery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlDelivery.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlDelivery.Appearance.Options.UseFont = true;
            this.hbControlDelivery.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlDelivery.AppearanceCaption.Options.UseFont = true;
            this.hbControlDelivery.Controls.Add(this.btnReturn);
            this.hbControlDelivery.Controls.Add(this.btnDeliveryFinish);
            this.hbControlDelivery.Controls.Add(this.gridDelivery);
            this.hbControlDelivery.HeaderTextId = "delv";
            this.hbControlDelivery.Image = null;
            this.hbControlDelivery.Location = new System.Drawing.Point(2, 2);
            this.hbControlDelivery.Margin = new System.Windows.Forms.Padding(2);
            this.hbControlDelivery.Name = "hbControlDelivery";
            this.hbControlDelivery.ResId = "";
            this.hbControlDelivery.Size = new System.Drawing.Size(887, 281);
            this.hbControlDelivery.TabIndex = 1;
            this.hbControlDelivery.Text = "배송";
            this.hbControlDelivery.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReturn.HeaderTextId = "return";
            this.btnReturn.Image = null;
            this.btnReturn.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnReturn.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnReturn.Location = new System.Drawing.Point(3, 222);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.ResId = "";
            this.btnReturn.Size = new System.Drawing.Size(53, 55);
            this.btnReturn.TabIndex = 3;
            this.btnReturn.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnReturn.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnReturn_HbClick);
            // 
            // btnDeliveryFinish
            // 
            this.btnDeliveryFinish.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDeliveryFinish.HeaderTextId = "delv";
            this.btnDeliveryFinish.Image = null;
            this.btnDeliveryFinish.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnDeliveryFinish.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDeliveryFinish.Location = new System.Drawing.Point(3, 25);
            this.btnDeliveryFinish.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDeliveryFinish.Name = "btnDeliveryFinish";
            this.btnDeliveryFinish.ResId = "";
            this.btnDeliveryFinish.Size = new System.Drawing.Size(53, 55);
            this.btnDeliveryFinish.TabIndex = 2;
            this.btnDeliveryFinish.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnDeliveryFinish.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnDeliveryFinish_HbClick);
            // 
            // gridDelivery
            // 
            this.gridDelivery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDelivery.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridDelivery.Location = new System.Drawing.Point(60, 25);
            this.gridDelivery.MainView = this.gridViewDelivery;
            this.gridDelivery.Margin = new System.Windows.Forms.Padding(2);
            this.gridDelivery.Name = "gridDelivery";
            this.gridDelivery.Size = new System.Drawing.Size(824, 252);
            this.gridDelivery.TabIndex = 0;
            this.gridDelivery.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDelivery});
            // 
            // gridViewDelivery
            // 
            this.gridViewDelivery.GridControl = this.gridDelivery;
            this.gridViewDelivery.Name = "gridViewDelivery";
            this.gridViewDelivery.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewDelivery_RowCellStyle);
            this.gridViewDelivery.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewDelivery_RowStyle);
            this.gridViewDelivery.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewDelivery_FocusedRowChanged);
            this.gridViewDelivery.DoubleClick += new System.EventHandler(this.gridViewDelivery_DoubleClick);
            this.gridViewDelivery.DataSourceChanged += new System.EventHandler(this.gridViewDelivery_DataSourceChanged);
            // 
            // hbControlDeliveryDetail
            // 
            this.hbControlDeliveryDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlDeliveryDetail.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlDeliveryDetail.Appearance.Options.UseFont = true;
            this.hbControlDeliveryDetail.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlDeliveryDetail.AppearanceCaption.Options.UseFont = true;
            this.hbControlDeliveryDetail.Controls.Add(this.gridDeliveryDetail);
            this.hbControlDeliveryDetail.HeaderTextId = "delv_dtl";
            this.hbControlDeliveryDetail.Image = null;
            this.hbControlDeliveryDetail.Location = new System.Drawing.Point(2, 1);
            this.hbControlDeliveryDetail.Margin = new System.Windows.Forms.Padding(2);
            this.hbControlDeliveryDetail.Name = "hbControlDeliveryDetail";
            this.hbControlDeliveryDetail.ResId = "";
            this.hbControlDeliveryDetail.Size = new System.Drawing.Size(887, 195);
            this.hbControlDeliveryDetail.TabIndex = 3;
            this.hbControlDeliveryDetail.Text = "배상상세";
            this.hbControlDeliveryDetail.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // gridDeliveryDetail
            // 
            this.gridDeliveryDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDeliveryDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridDeliveryDetail.Location = new System.Drawing.Point(3, 25);
            this.gridDeliveryDetail.MainView = this.gridViewDeliveryDetail;
            this.gridDeliveryDetail.Margin = new System.Windows.Forms.Padding(2);
            this.gridDeliveryDetail.Name = "gridDeliveryDetail";
            this.gridDeliveryDetail.Size = new System.Drawing.Size(881, 166);
            this.gridDeliveryDetail.TabIndex = 0;
            this.gridDeliveryDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDeliveryDetail});
            // 
            // gridViewDeliveryDetail
            // 
            this.gridViewDeliveryDetail.GridControl = this.gridDeliveryDetail;
            this.gridViewDeliveryDetail.Name = "gridViewDeliveryDetail";
            this.gridViewDeliveryDetail.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewDeliveryDetail_RowStyle);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 101);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.hbControlDelivery);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.hbControlDeliveryDetail);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(891, 486);
            this.splitContainerControl1.SplitterPosition = 284;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // SOD_Delivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.hbControlFind);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SOD_Delivery";
            this.Size = new System.Drawing.Size(891, 588);
            ((System.ComponentModel.ISupportInitialize)(this.hbControlFind)).EndInit();
            this.hbControlFind.ResumeLayout(false);
            this.hbControlFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlDelivery)).EndInit();
            this.hbControlDelivery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlDeliveryDetail)).EndInit();
            this.hbControlDeliveryDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDeliveryDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDeliveryDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HanbiControl.HbGroupControl hbControlFind;
        private HanbiControl.HbGroupControl hbControlDelivery;
        private HanbiControl.HbGroupControl hbControlDeliveryDetail;
        private HanbiControl.HbPopupEditH scPickupLocation;
        private HanbiControl.HbTextEditH scTelNo;
        private HanbiControl.HbTextEditH scFullName;
        private HanbiControl.HbTextEditH scShipAddress;
        private DevExpress.XtraGrid.GridControl gridDelivery;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDelivery;
        private DevExpress.XtraGrid.GridControl gridDeliveryDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDeliveryDetail;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private HanbiControl.HbDateEditH scEndDate;
        private HanbiControl.HbDateEditH scStartDate;
        private HanbiControl.HbSimpleButton btnDeliveryFinish;
        private HanbiControl.HbComboEditH scDelivered;
        private HanbiControl.HbSimpleButton btnReturn;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private HanbiControl.HbComboEditH scStopOrder;
    }
}
