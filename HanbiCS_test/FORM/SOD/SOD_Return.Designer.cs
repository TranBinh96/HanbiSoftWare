namespace SOD
{
    partial class SOD_Return
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
            this.scReturnType = new HanbiControl.HbComboEditH();
            this.scReturned = new HanbiControl.HbComboEditH();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.scEndDate = new HanbiControl.HbDateEditH();
            this.scStartDate = new HanbiControl.HbDateEditH();
            this.scShipAddress = new HanbiControl.HbTextEditH();
            this.scFullName = new HanbiControl.HbTextEditH();
            this.scPickupLocation = new HanbiControl.HbPopupEditH();
            this.scTelNo = new HanbiControl.HbTextEditH();
            this.hbControlReturnDetail = new HanbiControl.HbGroupControl();
            this.gridReturnDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewReturnDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.hbControlReturn = new HanbiControl.HbGroupControl();
            this.btnRefund = new HanbiControl.HbSimpleButton();
            this.gridReturn = new DevExpress.XtraGrid.GridControl();
            this.gridViewReturn = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlFind)).BeginInit();
            this.hbControlFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlReturnDetail)).BeginInit();
            this.hbControlReturnDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReturnDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReturnDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlReturn)).BeginInit();
            this.hbControlReturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReturn)).BeginInit();
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
            this.hbControlFind.Controls.Add(this.scReturnType);
            this.hbControlFind.Controls.Add(this.scReturned);
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
            // scReturnType
            // 
            this.scReturnType.DataSource = null;
            this.scReturnType.DefaultRowName = "All";
            this.scReturnType.DefaultRowValue = "";
            this.scReturnType.DictionaryList = null;
            this.scReturnType.FieldName = "ret_tp";
            this.scReturnType.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scReturnType.HeaderTextId = "ret_tp";
            this.scReturnType.Location = new System.Drawing.Point(678, 25);
            this.scReturnType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scReturnType.Name = "scReturnType";
            this.scReturnType.ProcAction = procAction1;
            this.scReturnType.ReadOnlyBackColorKeep = true;
            this.scReturnType.ResId = "";
            this.scReturnType.Size = new System.Drawing.Size(200, 29);
            this.scReturnType.TabIndex = 17;
            this.scReturnType.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scReturnType.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.scReturnType.Value = null;
            // 
            // scReturned
            // 
            this.scReturned.DataSource = null;
            this.scReturned.DefaultRowName = "All";
            this.scReturned.DefaultRowValue = "";
            this.scReturned.DictionaryList = null;
            this.scReturned.FieldName = "ret_yn";
            this.scReturned.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scReturned.HeaderTextId = "ret_yn";
            this.scReturned.Location = new System.Drawing.Point(678, 61);
            this.scReturned.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scReturned.Name = "scReturned";
            this.scReturned.ProcAction = procAction2;
            this.scReturned.ResId = "";
            this.scReturned.Size = new System.Drawing.Size(200, 29);
            this.scReturned.TabIndex = 4;
            this.scReturned.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scReturned.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.scReturned.Value = null;
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
            this.scFullName.ReadOnlyBackColorKeep = true;
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
            this.scPickupLocation.ReadOnlyBackColorKeep = true;
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
            // hbControlReturnDetail
            // 
            this.hbControlReturnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlReturnDetail.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlReturnDetail.Appearance.Options.UseFont = true;
            this.hbControlReturnDetail.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlReturnDetail.AppearanceCaption.Options.UseFont = true;
            this.hbControlReturnDetail.Controls.Add(this.gridReturnDetail);
            this.hbControlReturnDetail.HeaderTextId = "return_dtl";
            this.hbControlReturnDetail.Image = null;
            this.hbControlReturnDetail.Location = new System.Drawing.Point(2, 1);
            this.hbControlReturnDetail.Margin = new System.Windows.Forms.Padding(2);
            this.hbControlReturnDetail.Name = "hbControlReturnDetail";
            this.hbControlReturnDetail.ResId = "";
            this.hbControlReturnDetail.Size = new System.Drawing.Size(887, 195);
            this.hbControlReturnDetail.TabIndex = 3;
            this.hbControlReturnDetail.Text = "반품 세부 정보";
            this.hbControlReturnDetail.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // gridReturnDetail
            // 
            this.gridReturnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridReturnDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridReturnDetail.Location = new System.Drawing.Point(3, 25);
            this.gridReturnDetail.MainView = this.gridViewReturnDetail;
            this.gridReturnDetail.Margin = new System.Windows.Forms.Padding(2);
            this.gridReturnDetail.Name = "gridReturnDetail";
            this.gridReturnDetail.Size = new System.Drawing.Size(881, 166);
            this.gridReturnDetail.TabIndex = 0;
            this.gridReturnDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewReturnDetail});
            // 
            // gridViewReturnDetail
            // 
            this.gridViewReturnDetail.GridControl = this.gridReturnDetail;
            this.gridViewReturnDetail.Name = "gridViewReturnDetail";
            this.gridViewReturnDetail.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewReturnDetail_RowStyle);
            this.gridViewReturnDetail.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewReturnDetail_FocusedRowChanged);
            this.gridViewReturnDetail.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewReturnDetail_CellValueChanged);
            this.gridViewReturnDetail.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewReturnDetail_CellValueChanging);
            this.gridViewReturnDetail.DataSourceChanged += new System.EventHandler(this.gridViewReturnDetail_DataSourceChanged);
            // 
            // hbControlReturn
            // 
            this.hbControlReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlReturn.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlReturn.Appearance.Options.UseFont = true;
            this.hbControlReturn.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbControlReturn.AppearanceCaption.Options.UseFont = true;
            this.hbControlReturn.Controls.Add(this.btnRefund);
            this.hbControlReturn.Controls.Add(this.gridReturn);
            this.hbControlReturn.HeaderTextId = "return";
            this.hbControlReturn.Image = null;
            this.hbControlReturn.Location = new System.Drawing.Point(2, 2);
            this.hbControlReturn.Margin = new System.Windows.Forms.Padding(2);
            this.hbControlReturn.Name = "hbControlReturn";
            this.hbControlReturn.ResId = "";
            this.hbControlReturn.Size = new System.Drawing.Size(887, 281);
            this.hbControlReturn.TabIndex = 1;
            this.hbControlReturn.Text = "반환";
            this.hbControlReturn.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // btnRefund
            // 
            this.btnRefund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefund.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRefund.HeaderTextId = "refund";
            this.btnRefund.Image = null;
            this.btnRefund.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnRefund.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnRefund.Location = new System.Drawing.Point(3, 222);
            this.btnRefund.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.ResId = "";
            this.btnRefund.Size = new System.Drawing.Size(53, 55);
            this.btnRefund.TabIndex = 4;
            this.btnRefund.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnRefund.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnRefund_HbClick);
            // 
            // gridReturn
            // 
            this.gridReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridReturn.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridReturn.Location = new System.Drawing.Point(60, 25);
            this.gridReturn.MainView = this.gridViewReturn;
            this.gridReturn.Margin = new System.Windows.Forms.Padding(2);
            this.gridReturn.Name = "gridReturn";
            this.gridReturn.Size = new System.Drawing.Size(824, 252);
            this.gridReturn.TabIndex = 0;
            this.gridReturn.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewReturn});
            // 
            // gridViewReturn
            // 
            this.gridViewReturn.GridControl = this.gridReturn;
            this.gridViewReturn.Name = "gridViewReturn";
            this.gridViewReturn.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewReturn_RowStyle);
            this.gridViewReturn.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewReturn_FocusedRowChanged);
            this.gridViewReturn.DataSourceChanged += new System.EventHandler(this.gridViewReturn_DataSourceChanged);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 101);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.hbControlReturn);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.hbControlReturnDetail);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(891, 486);
            this.splitContainerControl1.SplitterPosition = 284;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // SOD_Return
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.hbControlFind);
            this.Name = "SOD_Return";
            this.Size = new System.Drawing.Size(891, 588);
            ((System.ComponentModel.ISupportInitialize)(this.hbControlFind)).EndInit();
            this.hbControlFind.ResumeLayout(false);
            this.hbControlFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlReturnDetail)).EndInit();
            this.hbControlReturnDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReturnDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReturnDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlReturn)).EndInit();
            this.hbControlReturn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HanbiControl.HbGroupControl hbControlFind;
        private HanbiControl.HbComboEditH scReturned;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private HanbiControl.HbDateEditH scEndDate;
        private HanbiControl.HbDateEditH scStartDate;
        private HanbiControl.HbTextEditH scShipAddress;
        private HanbiControl.HbTextEditH scFullName;
        private HanbiControl.HbPopupEditH scPickupLocation;
        private HanbiControl.HbTextEditH scTelNo;
        private HanbiControl.HbGroupControl hbControlReturnDetail;
        private DevExpress.XtraGrid.GridControl gridReturnDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewReturnDetail;
        private HanbiControl.HbGroupControl hbControlReturn;
        private DevExpress.XtraGrid.GridControl gridReturn;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewReturn;
        private HanbiControl.HbSimpleButton btnRefund;
        private HanbiControl.HbComboEditH scReturnType;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    }
}
