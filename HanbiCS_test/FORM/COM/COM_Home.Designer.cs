namespace COM
{
    partial class COM_Home
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
            this.hbControlDashboard = new HanbiControl.HbGroupControl();
            this.labelSummary = new System.Windows.Forms.Label();
            this.btnWaiting = new HanbiControl.HbSimpleButton();
            this.labelWaiting = new System.Windows.Forms.Label();
            this.btnDelivering = new HanbiControl.HbSimpleButton();
            this.labelDelivering = new System.Windows.Forms.Label();
            this.btnPicking = new HanbiControl.HbSimpleButton();
            this.labelPicking = new System.Windows.Forms.Label();
            this.btnNew = new HanbiControl.HbSimpleButton();
            this.labelNew = new System.Windows.Forms.Label();
            this.hbControlDetails = new HanbiControl.HbGroupControl();
            this.gridDashboard = new DevExpress.XtraGrid.GridControl();
            this.gridViewDashboard = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlDashboard)).BeginInit();
            this.hbControlDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlDetails)).BeginInit();
            this.hbControlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDashboard)).BeginInit();
            this.SuspendLayout();
            // 
            // hbControlDashboard
            // 
            this.hbControlDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlDashboard.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hbControlDashboard.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlDashboard.Appearance.Options.UseBackColor = true;
            this.hbControlDashboard.Appearance.Options.UseFont = true;
            this.hbControlDashboard.AppearanceCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlDashboard.AppearanceCaption.Options.UseFont = true;
            this.hbControlDashboard.Controls.Add(this.labelSummary);
            this.hbControlDashboard.Controls.Add(this.btnWaiting);
            this.hbControlDashboard.Controls.Add(this.labelWaiting);
            this.hbControlDashboard.Controls.Add(this.btnDelivering);
            this.hbControlDashboard.Controls.Add(this.labelDelivering);
            this.hbControlDashboard.Controls.Add(this.btnPicking);
            this.hbControlDashboard.Controls.Add(this.labelPicking);
            this.hbControlDashboard.Controls.Add(this.btnNew);
            this.hbControlDashboard.Controls.Add(this.labelNew);
            this.hbControlDashboard.HeaderTextId = "dashboard";
            this.hbControlDashboard.Image = null;
            this.hbControlDashboard.Location = new System.Drawing.Point(2, 3);
            this.hbControlDashboard.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.hbControlDashboard.Name = "hbControlDashboard";
            this.hbControlDashboard.ResId = "";
            this.hbControlDashboard.Size = new System.Drawing.Size(1018, 138);
            this.hbControlDashboard.TabIndex = 0;
            this.hbControlDashboard.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // labelSummary
            // 
            this.labelSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSummary.BackColor = System.Drawing.Color.Transparent;
            this.labelSummary.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSummary.Location = new System.Drawing.Point(752, 28);
            this.labelSummary.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(262, 30);
            this.labelSummary.TabIndex = 9;
            this.labelSummary.Text = "총 주문 : 9999999/9999999 건";
            this.labelSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnWaiting
            // 
            this.btnWaiting.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnWaiting.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnWaiting.HeaderTextId = "waiting";
            this.btnWaiting.Image = null;
            this.btnWaiting.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnWaiting.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnWaiting.Location = new System.Drawing.Point(544, 27);
            this.btnWaiting.Margin = new System.Windows.Forms.Padding(2);
            this.btnWaiting.Name = "btnWaiting";
            this.btnWaiting.ResId = "";
            this.btnWaiting.Size = new System.Drawing.Size(147, 30);
            this.btnWaiting.TabIndex = 7;
            this.btnWaiting.TextFont = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWaiting.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnWaiting_HbClick);
            // 
            // labelWaiting
            // 
            this.labelWaiting.BackColor = System.Drawing.Color.LightSkyBlue;
            this.labelWaiting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelWaiting.Font = new System.Drawing.Font("Malgun Gothic", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWaiting.Location = new System.Drawing.Point(544, 59);
            this.labelWaiting.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWaiting.Name = "labelWaiting";
            this.labelWaiting.Size = new System.Drawing.Size(148, 73);
            this.labelWaiting.TabIndex = 8;
            this.labelWaiting.Text = "0";
            this.labelWaiting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelWaiting.Click += new System.EventHandler(this.labelWaiting_Click);
            this.labelWaiting.DoubleClick += new System.EventHandler(this.labelWaiting_DoubleClick);
            // 
            // btnDelivering
            // 
            this.btnDelivering.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelivering.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelivering.HeaderTextId = "delivering";
            this.btnDelivering.Image = null;
            this.btnDelivering.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnDelivering.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDelivering.Location = new System.Drawing.Point(363, 28);
            this.btnDelivering.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelivering.Name = "btnDelivering";
            this.btnDelivering.ResId = "";
            this.btnDelivering.Size = new System.Drawing.Size(147, 30);
            this.btnDelivering.TabIndex = 5;
            this.btnDelivering.TextFont = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelivering.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnDelivering_HbClick);
            // 
            // labelDelivering
            // 
            this.labelDelivering.BackColor = System.Drawing.Color.LightCoral;
            this.labelDelivering.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDelivering.Font = new System.Drawing.Font("Malgun Gothic", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDelivering.Location = new System.Drawing.Point(363, 60);
            this.labelDelivering.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDelivering.Name = "labelDelivering";
            this.labelDelivering.Size = new System.Drawing.Size(148, 73);
            this.labelDelivering.TabIndex = 6;
            this.labelDelivering.Text = "0";
            this.labelDelivering.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDelivering.Click += new System.EventHandler(this.labelDelivering_Click);
            this.labelDelivering.DoubleClick += new System.EventHandler(this.labelDelivering_DoubleClick);
            // 
            // btnPicking
            // 
            this.btnPicking.BackColor = System.Drawing.Color.Khaki;
            this.btnPicking.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPicking.HeaderTextId = "picking";
            this.btnPicking.Image = null;
            this.btnPicking.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnPicking.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnPicking.Location = new System.Drawing.Point(183, 28);
            this.btnPicking.Margin = new System.Windows.Forms.Padding(2);
            this.btnPicking.Name = "btnPicking";
            this.btnPicking.ResId = "";
            this.btnPicking.Size = new System.Drawing.Size(147, 30);
            this.btnPicking.TabIndex = 3;
            this.btnPicking.TextFont = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPicking.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnPicking_HbClick);
            // 
            // labelPicking
            // 
            this.labelPicking.BackColor = System.Drawing.Color.Khaki;
            this.labelPicking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPicking.Font = new System.Drawing.Font("Malgun Gothic", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPicking.Location = new System.Drawing.Point(183, 60);
            this.labelPicking.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPicking.Name = "labelPicking";
            this.labelPicking.Size = new System.Drawing.Size(148, 73);
            this.labelPicking.TabIndex = 4;
            this.labelPicking.Text = "0";
            this.labelPicking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPicking.Click += new System.EventHandler(this.labelPicking_Click);
            this.labelPicking.DoubleClick += new System.EventHandler(this.labelPicking_DoubleClick);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.LightGreen;
            this.btnNew.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNew.ForeColor = System.Drawing.Color.Black;
            this.btnNew.HeaderTextId = "new";
            this.btnNew.Image = null;
            this.btnNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnNew.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnNew.Location = new System.Drawing.Point(3, 28);
            this.btnNew.Margin = new System.Windows.Forms.Padding(2);
            this.btnNew.Name = "btnNew";
            this.btnNew.ResId = "";
            this.btnNew.Size = new System.Drawing.Size(147, 30);
            this.btnNew.TabIndex = 1;
            this.btnNew.TextFont = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnNew_HbClick);
            // 
            // labelNew
            // 
            this.labelNew.BackColor = System.Drawing.Color.LightGreen;
            this.labelNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelNew.Font = new System.Drawing.Font("Malgun Gothic", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNew.Location = new System.Drawing.Point(3, 60);
            this.labelNew.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNew.Name = "labelNew";
            this.labelNew.Size = new System.Drawing.Size(148, 73);
            this.labelNew.TabIndex = 2;
            this.labelNew.Text = "0";
            this.labelNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelNew.Click += new System.EventHandler(this.labelNew_Click);
            this.labelNew.DoubleClick += new System.EventHandler(this.labelNew_DoubleClick);
            // 
            // hbControlDetails
            // 
            this.hbControlDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlDetails.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlDetails.Appearance.Options.UseFont = true;
            this.hbControlDetails.AppearanceCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlDetails.AppearanceCaption.Options.UseFont = true;
            this.hbControlDetails.Controls.Add(this.gridDashboard);
            this.hbControlDetails.HeaderTextId = "details";
            this.hbControlDetails.Image = null;
            this.hbControlDetails.Location = new System.Drawing.Point(2, 146);
            this.hbControlDetails.Margin = new System.Windows.Forms.Padding(2);
            this.hbControlDetails.Name = "hbControlDetails";
            this.hbControlDetails.ResId = "";
            this.hbControlDetails.Size = new System.Drawing.Size(1018, 332);
            this.hbControlDetails.TabIndex = 1;
            this.hbControlDetails.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // gridDashboard
            // 
            this.gridDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDashboard.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridDashboard.Location = new System.Drawing.Point(3, 22);
            this.gridDashboard.MainView = this.gridViewDashboard;
            this.gridDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.gridDashboard.Name = "gridDashboard";
            this.gridDashboard.Size = new System.Drawing.Size(1014, 308);
            this.gridDashboard.TabIndex = 0;
            this.gridDashboard.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDashboard});
            // 
            // gridViewDashboard
            // 
            this.gridViewDashboard.GridControl = this.gridDashboard;
            this.gridViewDashboard.Name = "gridViewDashboard";
            this.gridViewDashboard.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewDashboard_RowStyle);
            this.gridViewDashboard.DoubleClick += new System.EventHandler(this.gridViewDashboard_DoubleClick);
            // 
            // COM_Home
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hbControlDetails);
            this.Controls.Add(this.hbControlDashboard);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "COM_Home";
            this.Size = new System.Drawing.Size(1023, 480);
            ((System.ComponentModel.ISupportInitialize)(this.hbControlDashboard)).EndInit();
            this.hbControlDashboard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hbControlDetails)).EndInit();
            this.hbControlDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDashboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDashboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HanbiControl.HbGroupControl hbControlDashboard;
        private HanbiControl.HbGroupControl hbControlDetails;
        private DevExpress.XtraGrid.GridControl gridDashboard;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDashboard;
        private System.Windows.Forms.Label labelNew;
        private HanbiControl.HbSimpleButton btnNew;
        private HanbiControl.HbSimpleButton btnWaiting;
        private System.Windows.Forms.Label labelWaiting;
        private HanbiControl.HbSimpleButton btnDelivering;
        private System.Windows.Forms.Label labelDelivering;
        private HanbiControl.HbSimpleButton btnPicking;
        private System.Windows.Forms.Label labelPicking;
        private System.Windows.Forms.Label labelSummary;

    }
}
