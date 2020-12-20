namespace SOD
{
    partial class SOD_Order
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
            WebUtil.ProcAction procAction6 = new WebUtil.ProcAction();
            this.hbControlSearch = new HanbiControl.HbGroupControl();
            this.scStopOrder = new HanbiControl.HbComboEditH();
            this.scDelivered = new HanbiControl.HbComboEditH();
            this.scDeliveryOrder = new HanbiControl.HbComboEditH();
            this.scPicked = new HanbiControl.HbComboEditH();
            this.scPickOrder = new HanbiControl.HbComboEditH();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.scEndDate = new HanbiControl.HbDateEditH();
            this.scStartDate = new HanbiControl.HbDateEditH();
            this.scPay = new HanbiControl.HbComboEditH();
            this.scLocation = new HanbiControl.HbPopupEditH();
            this.scTelNo = new HanbiControl.HbTextEditH();
            this.btnPickOrder = new HanbiControl.HbSimpleButton();
            this.hbControlOrder = new HanbiControl.HbGroupControl();
            this.btnStop = new HanbiControl.HbSimpleButton();
            this.gridOrder = new DevExpress.XtraGrid.GridControl();
            this.gridViewOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.hbControlOrderDetail = new HanbiControl.HbGroupControl();
            this.gridOrderDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewOrderDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlSearch)).BeginInit();
            this.hbControlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlOrder)).BeginInit();
            this.hbControlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlOrderDetail)).BeginInit();
            this.hbControlOrderDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrderDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrderDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hbControlSearch
            // 
            this.hbControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlSearch.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlSearch.Appearance.Options.UseFont = true;
            this.hbControlSearch.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlSearch.AppearanceCaption.Options.UseFont = true;
            this.hbControlSearch.Controls.Add(this.scStopOrder);
            this.hbControlSearch.Controls.Add(this.scDelivered);
            this.hbControlSearch.Controls.Add(this.scDeliveryOrder);
            this.hbControlSearch.Controls.Add(this.scPicked);
            this.hbControlSearch.Controls.Add(this.scPickOrder);
            this.hbControlSearch.Controls.Add(this.labelControl1);
            this.hbControlSearch.Controls.Add(this.scEndDate);
            this.hbControlSearch.Controls.Add(this.scStartDate);
            this.hbControlSearch.Controls.Add(this.scPay);
            this.hbControlSearch.Controls.Add(this.scLocation);
            this.hbControlSearch.Controls.Add(this.scTelNo);
            this.hbControlSearch.HeaderTextId = "find";
            this.hbControlSearch.Image = null;
            this.hbControlSearch.Location = new System.Drawing.Point(2, 2);
            this.hbControlSearch.Margin = new System.Windows.Forms.Padding(2);
            this.hbControlSearch.Name = "hbControlSearch";
            this.hbControlSearch.ResId = "";
            this.hbControlSearch.Size = new System.Drawing.Size(1061, 97);
            this.hbControlSearch.TabIndex = 2;
            this.hbControlSearch.Text = "검색";
            this.hbControlSearch.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
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
            this.scStopOrder.Location = new System.Drawing.Point(857, 61);
            this.scStopOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scStopOrder.Name = "scStopOrder";
            this.scStopOrder.ProcAction = procAction1;
            this.scStopOrder.ReadOnlyBackColorKeep = true;
            this.scStopOrder.ResId = "";
            this.scStopOrder.Size = new System.Drawing.Size(200, 29);
            this.scStopOrder.TabIndex = 10;
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
            this.scDelivered.Location = new System.Drawing.Point(640, 61);
            this.scDelivered.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scDelivered.Name = "scDelivered";
            this.scDelivered.ProcAction = procAction2;
            this.scDelivered.ReadOnlyBackColorKeep = true;
            this.scDelivered.ResId = "";
            this.scDelivered.Size = new System.Drawing.Size(200, 29);
            this.scDelivered.TabIndex = 9;
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
            this.scDeliveryOrder.Location = new System.Drawing.Point(436, 61);
            this.scDeliveryOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scDeliveryOrder.Name = "scDeliveryOrder";
            this.scDeliveryOrder.ProcAction = procAction3;
            this.scDeliveryOrder.ReadOnlyBackColorKeep = true;
            this.scDeliveryOrder.ResId = "";
            this.scDeliveryOrder.Size = new System.Drawing.Size(199, 29);
            this.scDeliveryOrder.TabIndex = 8;
            this.scDeliveryOrder.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scDeliveryOrder.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.scDeliveryOrder.Value = null;
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
            this.scPicked.Location = new System.Drawing.Point(232, 61);
            this.scPicked.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scPicked.Name = "scPicked";
            this.scPicked.ProcAction = procAction4;
            this.scPicked.ReadOnlyBackColorKeep = true;
            this.scPicked.ResId = "";
            this.scPicked.Size = new System.Drawing.Size(199, 29);
            this.scPicked.TabIndex = 7;
            this.scPicked.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scPicked.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.scPicked.Value = null;
            // 
            // scPickOrder
            // 
            this.scPickOrder.DataSource = null;
            this.scPickOrder.DefaultRowName = "All";
            this.scPickOrder.DefaultRowValue = "";
            this.scPickOrder.DictionaryList = null;
            this.scPickOrder.FieldName = "pick_ord_yn";
            this.scPickOrder.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scPickOrder.HeaderTextId = "pick_ord_yn";
            this.scPickOrder.Location = new System.Drawing.Point(3, 61);
            this.scPickOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scPickOrder.Name = "scPickOrder";
            this.scPickOrder.ProcAction = procAction5;
            this.scPickOrder.ReadOnlyBackColorKeep = true;
            this.scPickOrder.ResId = "";
            this.scPickOrder.Size = new System.Drawing.Size(225, 29);
            this.scPickOrder.TabIndex = 6;
            this.scPickOrder.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scPickOrder.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.scPickOrder.Value = null;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(845, 32);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(8, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "~";
            // 
            // scEndDate
            // 
            this.scEndDate.DateTime = new System.DateTime(2020, 5, 30, 0, 0, 0, 0);
            this.scEndDate.FieldName = "end_date";
            this.scEndDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scEndDate.HeaderTextId = "end_date";
            this.scEndDate.Location = new System.Drawing.Point(857, 25);
            this.scEndDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scEndDate.MaxLengh = 0;
            this.scEndDate.Name = "scEndDate";
            this.scEndDate.ReadOnlyBackColorKeep = true;
            this.scEndDate.ResId = "";
            this.scEndDate.SelectionStart = 0;
            this.scEndDate.Size = new System.Drawing.Size(200, 29);
            this.scEndDate.TabIndex = 5;
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
            this.scStartDate.Location = new System.Drawing.Point(640, 25);
            this.scStartDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scStartDate.MaxLengh = 0;
            this.scStartDate.Name = "scStartDate";
            this.scStartDate.ReadOnlyBackColorKeep = true;
            this.scStartDate.ResId = "";
            this.scStartDate.SelectionStart = 0;
            this.scStartDate.Size = new System.Drawing.Size(200, 29);
            this.scStartDate.TabIndex = 4;
            this.scStartDate.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scStartDate.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.scStartDate.Value = "2020-05-30";
            // 
            // scPay
            // 
            this.scPay.DataSource = null;
            this.scPay.DefaultRowName = "All";
            this.scPay.DefaultRowValue = "";
            this.scPay.DictionaryList = null;
            this.scPay.FieldName = "pay_tp";
            this.scPay.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scPay.HeaderTextId = "pay_tp";
            this.scPay.Location = new System.Drawing.Point(436, 25);
            this.scPay.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scPay.Name = "scPay";
            this.scPay.ProcAction = procAction6;
            this.scPay.ReadOnlyBackColorKeep = true;
            this.scPay.ResId = "";
            this.scPay.Size = new System.Drawing.Size(200, 29);
            this.scPay.TabIndex = 3;
            this.scPay.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scPay.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.scPay.Value = null;
            // 
            // scLocation
            // 
            this.scLocation.ConnectedControls = new HanbiControl.HbControl[0];
            this.scLocation.FieldName = "loc_nm";
            this.scLocation.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scLocation.HeaderTextId = "loc_nm";
            this.scLocation.Location = new System.Drawing.Point(3, 25);
            this.scLocation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scLocation.MaxLengh = 0;
            this.scLocation.Name = "scLocation";
            this.scLocation.PopupFormClassName = "popPickupLocation";
            this.scLocation.PopupFormDllName = "SYS";
            this.scLocation.ReadOnlyBackColorKeep = true;
            this.scLocation.ResId = "";
            this.scLocation.SelectionStart = 0;
            this.scLocation.Size = new System.Drawing.Size(225, 29);
            this.scLocation.TabIndex = 1;
            this.scLocation.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scLocation.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // scTelNo
            // 
            this.scTelNo.FieldName = "tel_no";
            this.scTelNo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scTelNo.HeaderTextId = "tel_no";
            this.scTelNo.Location = new System.Drawing.Point(232, 25);
            this.scTelNo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scTelNo.MaxLengh = 0;
            this.scTelNo.Name = "scTelNo";
            this.scTelNo.ReadOnlyBackColorKeep = true;
            this.scTelNo.ResId = "";
            this.scTelNo.SelectionStart = 0;
            this.scTelNo.Size = new System.Drawing.Size(200, 29);
            this.scTelNo.TabIndex = 2;
            this.scTelNo.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scTelNo.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // btnPickOrder
            // 
            this.btnPickOrder.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPickOrder.HeaderTextId = "pick_order";
            this.btnPickOrder.Image = null;
            this.btnPickOrder.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPickOrder.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnPickOrder.Location = new System.Drawing.Point(3, 25);
            this.btnPickOrder.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPickOrder.Name = "btnPickOrder";
            this.btnPickOrder.ResId = "";
            this.btnPickOrder.Size = new System.Drawing.Size(53, 55);
            this.btnPickOrder.TabIndex = 1;
            this.btnPickOrder.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnPickOrder.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnPickOrder_Click);
            // 
            // hbControlOrder
            // 
            this.hbControlOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlOrder.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlOrder.Appearance.Options.UseFont = true;
            this.hbControlOrder.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlOrder.AppearanceCaption.Options.UseFont = true;
            this.hbControlOrder.Controls.Add(this.btnStop);
            this.hbControlOrder.Controls.Add(this.gridOrder);
            this.hbControlOrder.Controls.Add(this.btnPickOrder);
            this.hbControlOrder.HeaderTextId = "order";
            this.hbControlOrder.Image = null;
            this.hbControlOrder.Location = new System.Drawing.Point(2, 2);
            this.hbControlOrder.Margin = new System.Windows.Forms.Padding(2);
            this.hbControlOrder.Name = "hbControlOrder";
            this.hbControlOrder.ResId = "";
            this.hbControlOrder.Size = new System.Drawing.Size(1061, 281);
            this.hbControlOrder.TabIndex = 1;
            this.hbControlOrder.Text = "주문";
            this.hbControlOrder.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStop.HeaderTextId = "stop_yn";
            this.btnStop.Image = null;
            this.btnStop.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnStop.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnStop.Location = new System.Drawing.Point(3, 222);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.ResId = "";
            this.btnStop.Size = new System.Drawing.Size(53, 55);
            this.btnStop.TabIndex = 2;
            this.btnStop.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnStop.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnStop_HbClick);
            // 
            // gridOrder
            // 
            this.gridOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridOrder.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridOrder.Location = new System.Drawing.Point(60, 25);
            this.gridOrder.MainView = this.gridViewOrder;
            this.gridOrder.Margin = new System.Windows.Forms.Padding(2);
            this.gridOrder.Name = "gridOrder";
            this.gridOrder.Size = new System.Drawing.Size(998, 252);
            this.gridOrder.TabIndex = 0;
            this.gridOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOrder});
            // 
            // gridViewOrder
            // 
            this.gridViewOrder.GridControl = this.gridOrder;
            this.gridViewOrder.Name = "gridViewOrder";
            this.gridViewOrder.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewOrder_RowCellStyle);
            this.gridViewOrder.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewOrder_RowStyle);
            this.gridViewOrder.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewOrder_FocusedRowChanged);
            this.gridViewOrder.DoubleClick += new System.EventHandler(this.gridViewOrder_DoubleClick);
            this.gridViewOrder.DataSourceChanged += new System.EventHandler(this.gridViewOrder_DataSourceChanged);
            // 
            // hbControlOrderDetail
            // 
            this.hbControlOrderDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlOrderDetail.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlOrderDetail.Appearance.Options.UseFont = true;
            this.hbControlOrderDetail.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlOrderDetail.AppearanceCaption.Options.UseFont = true;
            this.hbControlOrderDetail.Controls.Add(this.gridOrderDetail);
            this.hbControlOrderDetail.HeaderTextId = "order_dtl";
            this.hbControlOrderDetail.Image = null;
            this.hbControlOrderDetail.Location = new System.Drawing.Point(2, 1);
            this.hbControlOrderDetail.Margin = new System.Windows.Forms.Padding(2);
            this.hbControlOrderDetail.Name = "hbControlOrderDetail";
            this.hbControlOrderDetail.ResId = "";
            this.hbControlOrderDetail.Size = new System.Drawing.Size(1061, 195);
            this.hbControlOrderDetail.TabIndex = 3;
            this.hbControlOrderDetail.Text = "주문상세";
            this.hbControlOrderDetail.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // gridOrderDetail
            // 
            this.gridOrderDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridOrderDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridOrderDetail.Location = new System.Drawing.Point(3, 25);
            this.gridOrderDetail.MainView = this.gridViewOrderDetail;
            this.gridOrderDetail.Margin = new System.Windows.Forms.Padding(2);
            this.gridOrderDetail.Name = "gridOrderDetail";
            this.gridOrderDetail.Size = new System.Drawing.Size(1055, 166);
            this.gridOrderDetail.TabIndex = 0;
            this.gridOrderDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOrderDetail});
            // 
            // gridViewOrderDetail
            // 
            this.gridViewOrderDetail.GridControl = this.gridOrderDetail;
            this.gridViewOrderDetail.Name = "gridViewOrderDetail";
            this.gridViewOrderDetail.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewOrderDetail_RowStyle);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 101);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.hbControlOrder);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.hbControlOrderDetail);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1065, 486);
            this.splitContainerControl1.SplitterPosition = 284;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // SOD_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hbControlSearch);
            this.Controls.Add(this.splitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SOD_Order";
            this.Size = new System.Drawing.Size(1065, 588);
            ((System.ComponentModel.ISupportInitialize)(this.hbControlSearch)).EndInit();
            this.hbControlSearch.ResumeLayout(false);
            this.hbControlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlOrder)).EndInit();
            this.hbControlOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlOrderDetail)).EndInit();
            this.hbControlOrderDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridOrderDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrderDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HanbiControl.HbGroupControl hbControlSearch;
        private HanbiControl.HbGroupControl hbControlOrder;
        private HanbiControl.HbGroupControl hbControlOrderDetail;
        private HanbiControl.HbTextEditH scTelNo;
        private HanbiControl.HbPopupEditH scLocation;
        private HanbiControl.HbComboEditH scPay;
        private HanbiControl.HbDateEditH scStartDate;
        private HanbiControl.HbDateEditH scEndDate;
        private DevExpress.XtraGrid.GridControl gridOrder;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOrder;
        private DevExpress.XtraGrid.GridControl gridOrderDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOrderDetail;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private HanbiControl.HbSimpleButton btnPickOrder;
        private HanbiControl.HbComboEditH scPickOrder;
        private HanbiControl.HbComboEditH scPicked;
        private HanbiControl.HbComboEditH scDeliveryOrder;
        private HanbiControl.HbComboEditH scDelivered;
        private HanbiControl.HbComboEditH scStopOrder;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private HanbiControl.HbSimpleButton btnStop;
    }
}
