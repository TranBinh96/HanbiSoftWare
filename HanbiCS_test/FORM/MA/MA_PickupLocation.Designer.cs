namespace MA
{
    partial class MA_PickupLocation
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
            this.hbControlSearch = new HanbiControl.HbGroupControl();
            this.hbControlPickupLoc = new HanbiControl.HbGroupControl();
            this.hbControlForm = new HanbiControl.HbGroupControl();
            this.scLocName = new HanbiControl.HbTextEditH();
            this.scPostCode = new HanbiControl.HbNumberEditH();
            this.scAddress = new HanbiControl.HbTextEditH();
            this.gridPickupLoc = new DevExpress.XtraGrid.GridControl();
            this.gridViewPickupLoc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtLocCd = new HanbiControl.HbTextEditH();
            this.txtLocName = new HanbiControl.HbTextEditH();
            this.txtPostCode = new HanbiControl.HbNumberEditH();
            this.txtAddress = new HanbiControl.HbMemoEditH();
            this.txtAddressDetail = new HanbiControl.HbMemoEditH();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlSearch)).BeginInit();
            this.hbControlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlPickupLoc)).BeginInit();
            this.hbControlPickupLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlForm)).BeginInit();
            this.hbControlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPickupLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPickupLoc)).BeginInit();
            this.SuspendLayout();
            // 
            // hbControlSearch
            // 
            this.hbControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlSearch.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlSearch.Appearance.Options.UseFont = true;
            this.hbControlSearch.AppearanceCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlSearch.AppearanceCaption.Options.UseFont = true;
            this.hbControlSearch.Controls.Add(this.scAddress);
            this.hbControlSearch.Controls.Add(this.scPostCode);
            this.hbControlSearch.Controls.Add(this.scLocName);
            this.hbControlSearch.HeaderTextId = "search";
            this.hbControlSearch.Image = null;
            this.hbControlSearch.Location = new System.Drawing.Point(3, 3);
            this.hbControlSearch.Name = "hbControlSearch";
            this.hbControlSearch.ResId = "";
            this.hbControlSearch.Size = new System.Drawing.Size(1500, 88);
            this.hbControlSearch.TabIndex = 0;
            this.hbControlSearch.Text = "Search";
            this.hbControlSearch.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // hbControlPickupLoc
            // 
            this.hbControlPickupLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlPickupLoc.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlPickupLoc.Appearance.Options.UseFont = true;
            this.hbControlPickupLoc.AppearanceCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlPickupLoc.AppearanceCaption.Options.UseFont = true;
            this.hbControlPickupLoc.Controls.Add(this.gridPickupLoc);
            this.hbControlPickupLoc.HeaderTextId = "pickup_loc";
            this.hbControlPickupLoc.Image = null;
            this.hbControlPickupLoc.Location = new System.Drawing.Point(3, 97);
            this.hbControlPickupLoc.Name = "hbControlPickupLoc";
            this.hbControlPickupLoc.ResId = "";
            this.hbControlPickupLoc.Size = new System.Drawing.Size(1079, 689);
            this.hbControlPickupLoc.TabIndex = 1;
            this.hbControlPickupLoc.Text = "Pickup Location";
            this.hbControlPickupLoc.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // hbControlForm
            // 
            this.hbControlForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlForm.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlForm.Appearance.Options.UseFont = true;
            this.hbControlForm.AppearanceCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlForm.AppearanceCaption.Options.UseFont = true;
            this.hbControlForm.Controls.Add(this.txtAddressDetail);
            this.hbControlForm.Controls.Add(this.txtAddress);
            this.hbControlForm.Controls.Add(this.txtPostCode);
            this.hbControlForm.Controls.Add(this.txtLocName);
            this.hbControlForm.Controls.Add(this.txtLocCd);
            this.hbControlForm.HeaderTextId = "form";
            this.hbControlForm.Image = null;
            this.hbControlForm.Location = new System.Drawing.Point(1088, 97);
            this.hbControlForm.Name = "hbControlForm";
            this.hbControlForm.ResId = "";
            this.hbControlForm.Size = new System.Drawing.Size(415, 689);
            this.hbControlForm.TabIndex = 2;
            this.hbControlForm.Text = "Form";
            this.hbControlForm.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // scLocName
            // 
            this.scLocName.FieldName = "loc_nm";
            this.scLocName.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scLocName.HeaderTextId = "loc_nm";
            this.scLocName.Location = new System.Drawing.Point(5, 37);
            this.scLocName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scLocName.MaxLengh = 0;
            this.scLocName.Name = "scLocName";
            this.scLocName.ReadOnlyBackColorKeep = true;
            this.scLocName.ResId = "";
            this.scLocName.SelectionStart = 0;
            this.scLocName.Size = new System.Drawing.Size(350, 43);
            this.scLocName.TabIndex = 0;
            this.scLocName.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scLocName.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // scPostCode
            // 
            this.scPostCode.DecimalPlaces = 0;
            this.scPostCode.DefaultValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.scPostCode.FieldName = "loc_post_cd";
            this.scPostCode.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scPostCode.HeaderTextId = "loc_post_cd";
            this.scPostCode.Location = new System.Drawing.Point(361, 37);
            this.scPostCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scPostCode.MaxLengh = 0;
            this.scPostCode.Name = "scPostCode";
            this.scPostCode.ReadOnlyBackColorKeep = true;
            this.scPostCode.ResId = "";
            this.scPostCode.SelectionStart = 0;
            this.scPostCode.Size = new System.Drawing.Size(350, 43);
            this.scPostCode.TabIndex = 1;
            this.scPostCode.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scPostCode.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.scPostCode.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // scAddress
            // 
            this.scAddress.FieldName = "loc_addr";
            this.scAddress.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scAddress.HeaderTextId = "loc_addr";
            this.scAddress.Location = new System.Drawing.Point(717, 37);
            this.scAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scAddress.MaxLengh = 0;
            this.scAddress.Name = "scAddress";
            this.scAddress.ResId = "";
            this.scAddress.SelectionStart = 0;
            this.scAddress.Size = new System.Drawing.Size(350, 43);
            this.scAddress.TabIndex = 2;
            this.scAddress.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scAddress.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // gridPickupLoc
            // 
            this.gridPickupLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPickupLoc.Location = new System.Drawing.Point(5, 36);
            this.gridPickupLoc.MainView = this.gridViewPickupLoc;
            this.gridPickupLoc.Name = "gridPickupLoc";
            this.gridPickupLoc.Size = new System.Drawing.Size(1069, 648);
            this.gridPickupLoc.TabIndex = 0;
            this.gridPickupLoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPickupLoc});
            // 
            // gridViewPickupLoc
            // 
            this.gridViewPickupLoc.GridControl = this.gridPickupLoc;
            this.gridViewPickupLoc.Name = "gridViewPickupLoc";
            // 
            // txtLocCd
            // 
            this.txtLocCd.FieldName = "loc_cd";
            this.txtLocCd.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLocCd.HeaderTextId = "loc_cd";
            this.txtLocCd.Location = new System.Drawing.Point(5, 37);
            this.txtLocCd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLocCd.MaxLengh = 0;
            this.txtLocCd.Name = "txtLocCd";
            this.txtLocCd.ResId = "";
            this.txtLocCd.SelectionStart = 0;
            this.txtLocCd.Size = new System.Drawing.Size(400, 43);
            this.txtLocCd.TabIndex = 0;
            this.txtLocCd.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtLocCd.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // txtLocName
            // 
            this.txtLocName.FieldName = "loc_nm";
            this.txtLocName.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLocName.HeaderTextId = "loc_nm";
            this.txtLocName.Location = new System.Drawing.Point(5, 88);
            this.txtLocName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLocName.MaxLengh = 0;
            this.txtLocName.Name = "txtLocName";
            this.txtLocName.ReadOnlyBackColorKeep = true;
            this.txtLocName.ResId = "";
            this.txtLocName.SelectionStart = 0;
            this.txtLocName.Size = new System.Drawing.Size(400, 43);
            this.txtLocName.TabIndex = 1;
            this.txtLocName.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtLocName.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // txtPostCode
            // 
            this.txtPostCode.DecimalPlaces = 0;
            this.txtPostCode.DefaultValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPostCode.FieldName = "loc_post_cd";
            this.txtPostCode.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPostCode.HeaderTextId = "loc_post_cd";
            this.txtPostCode.Location = new System.Drawing.Point(5, 139);
            this.txtPostCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPostCode.MaxLengh = 0;
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.ResId = "";
            this.txtPostCode.SelectionStart = 0;
            this.txtPostCode.Size = new System.Drawing.Size(400, 43);
            this.txtPostCode.TabIndex = 2;
            this.txtPostCode.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtPostCode.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.txtPostCode.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtAddress
            // 
            this.txtAddress.FieldName = "loc_addr";
            this.txtAddress.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAddress.HeaderTextId = "loc_addr";
            this.txtAddress.Location = new System.Drawing.Point(5, 190);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.MaxLengh = 0;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnlyBackColorKeep = true;
            this.txtAddress.ResId = "";
            this.txtAddress.SelectionStart = 0;
            this.txtAddress.Size = new System.Drawing.Size(400, 96);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtAddress.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // txtAddressDetail
            // 
            this.txtAddressDetail.FieldName = "loc_addr_dtl";
            this.txtAddressDetail.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAddressDetail.HeaderTextId = "loc_addr_dtl";
            this.txtAddressDetail.Location = new System.Drawing.Point(8, 296);
            this.txtAddressDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddressDetail.MaxLengh = 0;
            this.txtAddressDetail.Name = "txtAddressDetail";
            this.txtAddressDetail.ResId = "";
            this.txtAddressDetail.SelectionStart = 0;
            this.txtAddressDetail.Size = new System.Drawing.Size(400, 96);
            this.txtAddressDetail.TabIndex = 4;
            this.txtAddressDetail.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtAddressDetail.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // MA_PickupLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hbControlForm);
            this.Controls.Add(this.hbControlPickupLoc);
            this.Controls.Add(this.hbControlSearch);
            this.Name = "MA_PickupLocation";
            this.Size = new System.Drawing.Size(1506, 789);
            ((System.ComponentModel.ISupportInitialize)(this.hbControlSearch)).EndInit();
            this.hbControlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hbControlPickupLoc)).EndInit();
            this.hbControlPickupLoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hbControlForm)).EndInit();
            this.hbControlForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPickupLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPickupLoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HanbiControl.HbGroupControl hbControlSearch;
        private HanbiControl.HbTextEditH scLocName;
        private HanbiControl.HbGroupControl hbControlPickupLoc;
        private HanbiControl.HbGroupControl hbControlForm;
        private HanbiControl.HbNumberEditH scPostCode;
        private HanbiControl.HbTextEditH scAddress;
        private DevExpress.XtraGrid.GridControl gridPickupLoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPickupLoc;
        private HanbiControl.HbTextEditH txtLocCd;
        private HanbiControl.HbNumberEditH txtPostCode;
        private HanbiControl.HbTextEditH txtLocName;
        private HanbiControl.HbMemoEditH txtAddressDetail;
        private HanbiControl.HbMemoEditH txtAddress;
    }
}
