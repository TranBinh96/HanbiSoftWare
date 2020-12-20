namespace MA
{
    partial class MA_Product
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
            this.hbControlSearch = new HanbiControl.HbGroupControl();
            this.scUnitPrice = new HanbiControl.HbNumberEditH();
            this.scComparison = new HanbiControl.HbComboEditH();
            this.scUnit = new HanbiControl.HbTextEditH();
            this.scProductDesc = new HanbiControl.HbTextEditH();
            this.scProductName = new HanbiControl.HbTextEditH();
            this.hbControlProduct = new HanbiControl.HbGroupControl();
            this.gridProduct = new DevExpress.XtraGrid.GridControl();
            this.gridViewProduct = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.hbControlForm = new HanbiControl.HbGroupControl();
            this.txtProductName = new HanbiControl.HbTextEditH();
            this.txtProductNameKo = new HanbiControl.HbTextEditH();
            this.txtUnitPrice = new HanbiControl.HbNumberEditH();
            this.txtUnit = new HanbiControl.HbTextEditH();
            this.txtDesc = new HanbiControl.HbMemoEditH();
            this.chkVat = new HanbiControl.HbCheckEditH();
            this.txtProductNameEn = new HanbiControl.HbTextEditH();
            this.txtProductId = new HanbiControl.HbTextEditH();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlSearch)).BeginInit();
            this.hbControlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlProduct)).BeginInit();
            this.hbControlProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlForm)).BeginInit();
            this.hbControlForm.SuspendLayout();
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
            this.hbControlSearch.Controls.Add(this.scUnitPrice);
            this.hbControlSearch.Controls.Add(this.scComparison);
            this.hbControlSearch.Controls.Add(this.scUnit);
            this.hbControlSearch.Controls.Add(this.scProductDesc);
            this.hbControlSearch.Controls.Add(this.scProductName);
            this.hbControlSearch.HeaderTextId = "search";
            this.hbControlSearch.Image = null;
            this.hbControlSearch.Location = new System.Drawing.Point(2, 2);
            this.hbControlSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hbControlSearch.Name = "hbControlSearch";
            this.hbControlSearch.ResId = "";
            this.hbControlSearch.Size = new System.Drawing.Size(1294, 102);
            this.hbControlSearch.TabIndex = 0;
            this.hbControlSearch.Text = "Search";
            this.hbControlSearch.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // scUnitPrice
            // 
            this.scUnitPrice.DecimalPlaces = 0;
            this.scUnitPrice.DefaultValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.scUnitPrice.FieldName = "unit_price";
            this.scUnitPrice.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scUnitPrice.HeaderTextId = "unit_price";
            this.scUnitPrice.Location = new System.Drawing.Point(480, 65);
            this.scUnitPrice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scUnitPrice.MaxLengh = 0;
            this.scUnitPrice.Name = "scUnitPrice";
            this.scUnitPrice.ReadOnlyBackColorKeep = true;
            this.scUnitPrice.ResId = "";
            this.scUnitPrice.SelectionStart = 0;
            this.scUnitPrice.Size = new System.Drawing.Size(233, 32);
            this.scUnitPrice.TabIndex = 4;
            this.scUnitPrice.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scUnitPrice.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.scUnitPrice.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // scComparison
            // 
            this.scComparison.DataSource = null;
            this.scComparison.DefaultRowName = "All";
            this.scComparison.DefaultRowValue = "";
            this.scComparison.DictionaryList = null;
            this.scComparison.FieldName = "comparison";
            this.scComparison.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scComparison.HeaderTextId = "comparison";
            this.scComparison.Location = new System.Drawing.Point(242, 65);
            this.scComparison.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scComparison.Name = "scComparison";
            this.scComparison.ProcAction = procAction1;
            this.scComparison.ReadOnlyBackColorKeep = true;
            this.scComparison.ResId = "";
            this.scComparison.Size = new System.Drawing.Size(233, 32);
            this.scComparison.TabIndex = 3;
            this.scComparison.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scComparison.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.scComparison.Value = null;
            // 
            // scUnit
            // 
            this.scUnit.FieldName = "unit";
            this.scUnit.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scUnit.HeaderTextId = "unit";
            this.scUnit.Location = new System.Drawing.Point(4, 65);
            this.scUnit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scUnit.MaxLengh = 0;
            this.scUnit.Name = "scUnit";
            this.scUnit.ReadOnlyBackColorKeep = true;
            this.scUnit.ResId = "";
            this.scUnit.SelectionStart = 0;
            this.scUnit.Size = new System.Drawing.Size(233, 32);
            this.scUnit.TabIndex = 2;
            this.scUnit.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scUnit.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // scProductDesc
            // 
            this.scProductDesc.FieldName = "desc";
            this.scProductDesc.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scProductDesc.HeaderTextId = "desc";
            this.scProductDesc.Location = new System.Drawing.Point(242, 27);
            this.scProductDesc.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scProductDesc.MaxLengh = 0;
            this.scProductDesc.Name = "scProductDesc";
            this.scProductDesc.ResId = "";
            this.scProductDesc.SelectionStart = 0;
            this.scProductDesc.Size = new System.Drawing.Size(233, 32);
            this.scProductDesc.TabIndex = 1;
            this.scProductDesc.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scProductDesc.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // scProductName
            // 
            this.scProductName.FieldName = "prod_nm";
            this.scProductName.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scProductName.HeaderTextId = "prod_name";
            this.scProductName.Location = new System.Drawing.Point(4, 27);
            this.scProductName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scProductName.MaxLengh = 0;
            this.scProductName.Name = "scProductName";
            this.scProductName.ReadOnlyBackColorKeep = true;
            this.scProductName.ResId = "";
            this.scProductName.SelectionStart = 0;
            this.scProductName.Size = new System.Drawing.Size(233, 32);
            this.scProductName.TabIndex = 0;
            this.scProductName.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scProductName.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // hbControlProduct
            // 
            this.hbControlProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlProduct.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlProduct.Appearance.Options.UseFont = true;
            this.hbControlProduct.AppearanceCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlProduct.AppearanceCaption.Options.UseFont = true;
            this.hbControlProduct.Controls.Add(this.gridProduct);
            this.hbControlProduct.HeaderTextId = "prod";
            this.hbControlProduct.Image = null;
            this.hbControlProduct.Location = new System.Drawing.Point(2, 108);
            this.hbControlProduct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hbControlProduct.Name = "hbControlProduct";
            this.hbControlProduct.ResId = "";
            this.hbControlProduct.Size = new System.Drawing.Size(968, 508);
            this.hbControlProduct.TabIndex = 1;
            this.hbControlProduct.Text = "Products";
            this.hbControlProduct.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // gridProduct
            // 
            this.gridProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridProduct.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridProduct.Location = new System.Drawing.Point(4, 27);
            this.gridProduct.MainView = this.gridViewProduct;
            this.gridProduct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridProduct.Name = "gridProduct";
            this.gridProduct.Size = new System.Drawing.Size(960, 481);
            this.gridProduct.TabIndex = 0;
            this.gridProduct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewProduct});
            // 
            // gridViewProduct
            // 
            this.gridViewProduct.GridControl = this.gridProduct;
            this.gridViewProduct.Name = "gridViewProduct";
            // 
            // hbControlForm
            // 
            this.hbControlForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlForm.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlForm.Appearance.Options.UseFont = true;
            this.hbControlForm.AppearanceCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlForm.AppearanceCaption.Options.UseFont = true;
            this.hbControlForm.Controls.Add(this.txtProductName);
            this.hbControlForm.Controls.Add(this.txtProductNameKo);
            this.hbControlForm.Controls.Add(this.txtUnitPrice);
            this.hbControlForm.Controls.Add(this.txtUnit);
            this.hbControlForm.Controls.Add(this.txtDesc);
            this.hbControlForm.Controls.Add(this.chkVat);
            this.hbControlForm.Controls.Add(this.txtProductNameEn);
            this.hbControlForm.Controls.Add(this.txtProductId);
            this.hbControlForm.HeaderTextId = "form";
            this.hbControlForm.Image = null;
            this.hbControlForm.Location = new System.Drawing.Point(975, 108);
            this.hbControlForm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hbControlForm.Name = "hbControlForm";
            this.hbControlForm.ResId = "";
            this.hbControlForm.Size = new System.Drawing.Size(322, 508);
            this.hbControlForm.TabIndex = 2;
            this.hbControlForm.Text = "Form";
            this.hbControlForm.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // txtProductName
            // 
            this.txtProductName.FieldName = "prod_nm";
            this.txtProductName.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProductName.HeaderTextId = "prod_nm";
            this.txtProductName.Location = new System.Drawing.Point(4, 140);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtProductName.MaxLengh = 0;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ResId = "";
            this.txtProductName.SelectionStart = 0;
            this.txtProductName.Size = new System.Drawing.Size(311, 32);
            this.txtProductName.TabIndex = 3;
            this.txtProductName.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtProductName.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // txtProductNameKo
            // 
            this.txtProductNameKo.FieldName = "prod_nm_ko";
            this.txtProductNameKo.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProductNameKo.HeaderTextId = "prod_nm_ko";
            this.txtProductNameKo.Location = new System.Drawing.Point(4, 65);
            this.txtProductNameKo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtProductNameKo.MaxLengh = 0;
            this.txtProductNameKo.Name = "txtProductNameKo";
            this.txtProductNameKo.ReadOnlyBackColorKeep = true;
            this.txtProductNameKo.ResId = "";
            this.txtProductNameKo.SelectionStart = 0;
            this.txtProductNameKo.Size = new System.Drawing.Size(311, 32);
            this.txtProductNameKo.TabIndex = 1;
            this.txtProductNameKo.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtProductNameKo.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.DecimalPlaces = 0;
            this.txtUnitPrice.DefaultValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtUnitPrice.FieldName = "unit_price";
            this.txtUnitPrice.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtUnitPrice.HeaderTextId = "unit_price";
            this.txtUnitPrice.Location = new System.Drawing.Point(4, 322);
            this.txtUnitPrice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtUnitPrice.MaxLengh = 0;
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.ResId = "";
            this.txtUnitPrice.SelectionStart = 0;
            this.txtUnitPrice.Size = new System.Drawing.Size(311, 32);
            this.txtUnitPrice.TabIndex = 7;
            this.txtUnitPrice.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtUnitPrice.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.txtUnitPrice.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtUnit
            // 
            this.txtUnit.FieldName = "unit";
            this.txtUnit.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtUnit.HeaderTextId = "unit";
            this.txtUnit.Location = new System.Drawing.Point(4, 284);
            this.txtUnit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtUnit.MaxLengh = 0;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnlyBackColorKeep = true;
            this.txtUnit.ResId = "";
            this.txtUnit.SelectionStart = 0;
            this.txtUnit.Size = new System.Drawing.Size(311, 32);
            this.txtUnit.TabIndex = 6;
            this.txtUnit.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtUnit.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // txtDesc
            // 
            this.txtDesc.FieldName = "desc";
            this.txtDesc.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtDesc.HeaderTextId = "desc";
            this.txtDesc.Location = new System.Drawing.Point(4, 178);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDesc.MaxLengh = 0;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnlyBackColorKeep = true;
            this.txtDesc.ResId = "";
            this.txtDesc.SelectionStart = 0;
            this.txtDesc.Size = new System.Drawing.Size(311, 63);
            this.txtDesc.TabIndex = 4;
            this.txtDesc.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtDesc.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // chkVat
            // 
            this.chkVat.Checked = false;
            this.chkVat.FieldName = "vat_tp";
            this.chkVat.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkVat.HeaderTextId = "vat_tp";
            this.chkVat.Location = new System.Drawing.Point(4, 247);
            this.chkVat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkVat.Name = "chkVat";
            this.chkVat.ResId = "";
            this.chkVat.Size = new System.Drawing.Size(311, 32);
            this.chkVat.TabIndex = 5;
            this.chkVat.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.chkVat.Value = "N";
            // 
            // txtProductNameEn
            // 
            this.txtProductNameEn.FieldName = "prod_nm_en";
            this.txtProductNameEn.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProductNameEn.HeaderTextId = "prod_nm_en";
            this.txtProductNameEn.Location = new System.Drawing.Point(4, 102);
            this.txtProductNameEn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtProductNameEn.MaxLengh = 0;
            this.txtProductNameEn.Name = "txtProductNameEn";
            this.txtProductNameEn.ResId = "";
            this.txtProductNameEn.SelectionStart = 0;
            this.txtProductNameEn.Size = new System.Drawing.Size(311, 32);
            this.txtProductNameEn.TabIndex = 2;
            this.txtProductNameEn.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtProductNameEn.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // txtProductId
            // 
            this.txtProductId.FieldName = "prod_cd";
            this.txtProductId.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProductId.HeaderTextId = "prod_cd";
            this.txtProductId.Location = new System.Drawing.Point(4, 27);
            this.txtProductId.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtProductId.MaxLengh = 0;
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.ReadOnlyBackColorKeep = true;
            this.txtProductId.ResId = "";
            this.txtProductId.SelectionStart = 0;
            this.txtProductId.Size = new System.Drawing.Size(311, 32);
            this.txtProductId.TabIndex = 0;
            this.txtProductId.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtProductId.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // MA_Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hbControlForm);
            this.Controls.Add(this.hbControlProduct);
            this.Controls.Add(this.hbControlSearch);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MA_Product";
            this.Size = new System.Drawing.Size(1299, 618);
            ((System.ComponentModel.ISupportInitialize)(this.hbControlSearch)).EndInit();
            this.hbControlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hbControlProduct)).EndInit();
            this.hbControlProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlForm)).EndInit();
            this.hbControlForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HanbiControl.HbGroupControl hbControlSearch;
        private HanbiControl.HbGroupControl hbControlProduct;
        private HanbiControl.HbGroupControl hbControlForm;
        private HanbiControl.HbTextEditH scProductName;
        private HanbiControl.HbTextEditH scUnit;
        private HanbiControl.HbTextEditH scProductDesc;
        private HanbiControl.HbNumberEditH scUnitPrice;
        private HanbiControl.HbComboEditH scComparison;
        private DevExpress.XtraGrid.GridControl gridProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProduct;
        private HanbiControl.HbNumberEditH txtUnitPrice;
        private HanbiControl.HbTextEditH txtUnit;
        private HanbiControl.HbMemoEditH txtDesc;
        private HanbiControl.HbCheckEditH chkVat;
        private HanbiControl.HbTextEditH txtProductNameEn;
        private HanbiControl.HbTextEditH txtProductId;
        private HanbiControl.HbTextEditH txtProductName;
        private HanbiControl.HbTextEditH txtProductNameKo;
    }
}
