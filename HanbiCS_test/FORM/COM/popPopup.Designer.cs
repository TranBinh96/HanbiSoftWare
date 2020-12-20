namespace COM
{
    partial class popPopup
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnConfirm = new HanbiControl.HbSimpleButton();
            this.btnSearch = new HanbiControl.HbSimpleButton();
            this.etFind = new HanbiControl.HbTextEditH();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(2, 35);
            this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(497, 396);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConfirm.HeaderTextId = "confirm";
            this.btnConfirm.Image = null;
            this.btnConfirm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnConfirm.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnConfirm.Location = new System.Drawing.Point(439, 2);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.ResId = "";
            this.btnConfirm.Size = new System.Drawing.Size(60, 26);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnConfirm.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnConfirm_HbClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.HeaderTextId = "search";
            this.btnSearch.Image = null;
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSearch.Location = new System.Drawing.Point(373, 2);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ResId = "";
            this.btnSearch.Size = new System.Drawing.Size(60, 26);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnSearch.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnSearch_HbClick);
            // 
            // etFind
            // 
            this.etFind.FieldName = "";
            this.etFind.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etFind.HeaderTextId = "find";
            this.etFind.Location = new System.Drawing.Point(2, 2);
            this.etFind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.etFind.MaxLengh = 0;
            this.etFind.Name = "etFind";
            this.etFind.ReadOnlyBackColorKeep = true;
            this.etFind.ResId = "";
            this.etFind.SelectionStart = 0;
            this.etFind.Size = new System.Drawing.Size(301, 26);
            this.etFind.TabIndex = 4;
            this.etFind.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etFind.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // popPopup
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(501, 433);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.etFind);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "popPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "popPopup";
            this.VisibleChanged += new System.EventHandler(this.popPopupEditor_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private HanbiControl.HbSimpleButton btnConfirm;
        private HanbiControl.HbSimpleButton btnSearch;
        private HanbiControl.HbTextEditH etFind;
    }
}