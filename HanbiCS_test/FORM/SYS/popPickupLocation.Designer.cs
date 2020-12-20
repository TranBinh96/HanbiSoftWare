namespace SYS
{
    partial class popPickupLocation
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridPickupLocation = new DevExpress.XtraGrid.GridControl();
            this.gridViewPickupLocation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnConfirm = new HanbiControl.HbSimpleButton();
            this.btnSearch = new HanbiControl.HbSimpleButton();
            this.scSearch = new HanbiControl.HbTextEditH();
            ((System.ComponentModel.ISupportInitialize)(this.gridPickupLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPickupLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPickupLocation
            // 
            this.gridPickupLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPickupLocation.Location = new System.Drawing.Point(2, 49);
            this.gridPickupLocation.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridPickupLocation.MainView = this.gridViewPickupLocation;
            this.gridPickupLocation.Name = "gridPickupLocation";
            this.gridPickupLocation.Size = new System.Drawing.Size(775, 443);
            this.gridPickupLocation.TabIndex = 4;
            this.gridPickupLocation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPickupLocation});
            // 
            // gridViewPickupLocation
            // 
            this.gridViewPickupLocation.GridControl = this.gridPickupLocation;
            this.gridViewPickupLocation.Name = "gridViewPickupLocation";
            this.gridViewPickupLocation.DoubleClick += new System.EventHandler(this.gridViewPickupLocation_DoubleClick);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConfirm.HeaderTextId = "confirm";
            this.btnConfirm.Image = null;
            this.btnConfirm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnConfirm.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnConfirm.Location = new System.Drawing.Point(697, 2);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.ResId = "";
            this.btnConfirm.Size = new System.Drawing.Size(70, 40);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnConfirm.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnConfirm_HbClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.HeaderTextId = "search";
            this.btnSearch.Image = null;
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSearch.Location = new System.Drawing.Point(309, 2);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ResId = "";
            this.btnSearch.Size = new System.Drawing.Size(70, 40);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnSearch.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnSearch_HbClick);
            // 
            // scSearch
            // 
            this.scSearch.FieldName = "";
            this.scSearch.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scSearch.HeaderTextId = "find";
            this.scSearch.Location = new System.Drawing.Point(2, 2);
            this.scSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scSearch.MaxLengh = 0;
            this.scSearch.Name = "scSearch";
            this.scSearch.ResId = "";
            this.scSearch.SelectionStart = 0;
            this.scSearch.Size = new System.Drawing.Size(300, 40);
            this.scSearch.TabIndex = 1;
            this.scSearch.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scSearch.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.scSearch.HbKeyDownPress += new HanbiControl.clsControl.KeyDownPressEventHandler(this.scSearch_HbKeyDownPress);
            // 
            // popPickupLocation
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(779, 494);
            this.Controls.Add(this.gridPickupLocation);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.scSearch);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "popPickupLocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pickup Location";
            ((System.ComponentModel.ISupportInitialize)(this.gridPickupLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPickupLocation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridPickupLocation;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPickupLocation;
        private HanbiControl.HbSimpleButton btnConfirm;
        private HanbiControl.HbSimpleButton btnSearch;
        private HanbiControl.HbTextEditH scSearch;
    }
}