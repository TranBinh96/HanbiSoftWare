namespace SYS
{
    partial class SYS_Code
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SYS_Code));
            this.gcCodeGroup = new HanbiControl.HbGroupControl();
            this.gridCodeGroup = new DevExpress.XtraGrid.GridControl();
            this.gridViewCodeGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcForm = new HanbiControl.HbGroupControl();
            this.txtRemark = new HanbiControl.HbMemoEditH();
            this.chkUse = new HanbiControl.HbCheckEditH();
            this.chkSys = new HanbiControl.HbCheckEditH();
            this.txtGroupName = new HanbiControl.HbTextEditH();
            this.txtGroupId = new HanbiControl.HbTextEditH();
            this.btnDeleteCode = new HanbiControl.HbSimpleButton();
            this.btnSaveCode = new HanbiControl.HbSimpleButton();
            this.btnNewCode = new HanbiControl.HbSimpleButton();
            this.gcCode = new HanbiControl.HbGroupControl();
            this.gridCode = new DevExpress.XtraGrid.GridControl();
            this.gridViewCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gcCodeGroup)).BeginInit();
            this.gcCodeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodeGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCodeGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcForm)).BeginInit();
            this.gcForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCode)).BeginInit();
            this.gcCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCode)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCodeGroup
            // 
            this.gcCodeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gcCodeGroup.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.gcCodeGroup.Appearance.Options.UseFont = true;
            this.gcCodeGroup.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.gcCodeGroup.AppearanceCaption.Options.UseFont = true;
            this.gcCodeGroup.Controls.Add(this.gridCodeGroup);
            this.gcCodeGroup.HeaderTextId = "code_group";
            this.gcCodeGroup.Image = null;
            this.gcCodeGroup.Location = new System.Drawing.Point(3, 3);
            this.gcCodeGroup.Name = "gcCodeGroup";
            this.gcCodeGroup.ResId = "";
            this.gcCodeGroup.Size = new System.Drawing.Size(677, 998);
            this.gcCodeGroup.TabIndex = 0;
            this.gcCodeGroup.Text = "Code Group";
            this.gcCodeGroup.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // gridCodeGroup
            // 
            this.gridCodeGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCodeGroup.Location = new System.Drawing.Point(2, 33);
            this.gridCodeGroup.MainView = this.gridViewCodeGroup;
            this.gridCodeGroup.Name = "gridCodeGroup";
            this.gridCodeGroup.Size = new System.Drawing.Size(673, 963);
            this.gridCodeGroup.TabIndex = 0;
            this.gridCodeGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCodeGroup});
            // 
            // gridViewCodeGroup
            // 
            this.gridViewCodeGroup.GridControl = this.gridCodeGroup;
            this.gridViewCodeGroup.Name = "gridViewCodeGroup";
            this.gridViewCodeGroup.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewCodeGroup_InitNewRow);
            this.gridViewCodeGroup.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewCodeGroup_FocusedRowChanged);
            this.gridViewCodeGroup.DataSourceChanged += new System.EventHandler(this.gridViewCodeGroup_DataSourceChanged);
            // 
            // gcForm
            // 
            this.gcForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcForm.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.gcForm.Appearance.Options.UseFont = true;
            this.gcForm.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.gcForm.AppearanceCaption.Options.UseFont = true;
            this.gcForm.Controls.Add(this.txtRemark);
            this.gcForm.Controls.Add(this.chkUse);
            this.gcForm.Controls.Add(this.chkSys);
            this.gcForm.Controls.Add(this.txtGroupName);
            this.gcForm.Controls.Add(this.txtGroupId);
            this.gcForm.HeaderTextId = "form";
            this.gcForm.Image = null;
            this.gcForm.Location = new System.Drawing.Point(687, 3);
            this.gcForm.Name = "gcForm";
            this.gcForm.ResId = "";
            this.gcForm.Size = new System.Drawing.Size(1176, 276);
            this.gcForm.TabIndex = 1;
            this.gcForm.Text = "Form";
            this.gcForm.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // txtRemark
            // 
            this.txtRemark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtRemark.FieldName = "remark";
            this.txtRemark.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRemark.HeaderTextId = "remark";
            this.txtRemark.Location = new System.Drawing.Point(7, 161);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtRemark.MaxLengh = 0;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ReadOnlyBackColorKeep = true;
            this.txtRemark.ResId = "";
            this.txtRemark.SelectionStart = 0;
            this.txtRemark.Size = new System.Drawing.Size(894, 109);
            this.txtRemark.TabIndex = 4;
            this.txtRemark.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtRemark.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // chkUse
            // 
            this.chkUse.Checked = false;
            this.chkUse.FieldName = "use_yn";
            this.chkUse.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkUse.HeaderTextId = "use_yn";
            this.chkUse.Location = new System.Drawing.Point(679, 102);
            this.chkUse.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.chkUse.Name = "chkUse";
            this.chkUse.ResId = "";
            this.chkUse.Size = new System.Drawing.Size(222, 50);
            this.chkUse.TabIndex = 3;
            this.chkUse.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.chkUse.Value = "N";
            // 
            // chkSys
            // 
            this.chkSys.Checked = false;
            this.chkSys.FieldName = "sys_yn";
            this.chkSys.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkSys.HeaderTextId = "sys_yn";
            this.chkSys.Location = new System.Drawing.Point(679, 43);
            this.chkSys.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.chkSys.Name = "chkSys";
            this.chkSys.ResId = "";
            this.chkSys.Size = new System.Drawing.Size(222, 50);
            this.chkSys.TabIndex = 2;
            this.chkSys.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.chkSys.Value = "N";
            // 
            // txtGroupName
            // 
            this.txtGroupName.FieldName = "grp_nm";
            this.txtGroupName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtGroupName.HeaderTextId = "grp_nm";
            this.txtGroupName.Location = new System.Drawing.Point(6, 102);
            this.txtGroupName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtGroupName.MaxLengh = 0;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.ReadOnlyBackColorKeep = true;
            this.txtGroupName.ResId = "";
            this.txtGroupName.SelectionStart = 0;
            this.txtGroupName.Size = new System.Drawing.Size(667, 50);
            this.txtGroupName.TabIndex = 1;
            this.txtGroupName.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtGroupName.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // txtGroupId
            // 
            this.txtGroupId.FieldName = "grp_cd";
            this.txtGroupId.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtGroupId.HeaderTextId = "grp_cd";
            this.txtGroupId.Location = new System.Drawing.Point(6, 43);
            this.txtGroupId.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtGroupId.MaxLengh = 0;
            this.txtGroupId.Name = "txtGroupId";
            this.txtGroupId.ResId = "";
            this.txtGroupId.SelectionStart = 0;
            this.txtGroupId.Size = new System.Drawing.Size(500, 50);
            this.txtGroupId.TabIndex = 0;
            this.txtGroupId.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtGroupId.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // btnDeleteCode
            // 
            this.btnDeleteCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDeleteCode.HeaderTextId = "delete";
            this.btnDeleteCode.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteCode.Image")));
            this.btnDeleteCode.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnDeleteCode.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.None;
            this.btnDeleteCode.Location = new System.Drawing.Point(9, 247);
            this.btnDeleteCode.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDeleteCode.Name = "btnDeleteCode";
            this.btnDeleteCode.ResId = "";
            this.btnDeleteCode.Size = new System.Drawing.Size(89, 93);
            this.btnDeleteCode.TabIndex = 13;
            this.btnDeleteCode.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnDeleteCode.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnDeleteCode_Click);
            // 
            // btnSaveCode
            // 
            this.btnSaveCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSaveCode.HeaderTextId = "save";
            this.btnSaveCode.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveCode.Image")));
            this.btnSaveCode.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSaveCode.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.None;
            this.btnSaveCode.Location = new System.Drawing.Point(9, 145);
            this.btnSaveCode.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSaveCode.Name = "btnSaveCode";
            this.btnSaveCode.ResId = "";
            this.btnSaveCode.Size = new System.Drawing.Size(89, 93);
            this.btnSaveCode.TabIndex = 12;
            this.btnSaveCode.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnSaveCode.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnSaveCode_Click);
            // 
            // btnNewCode
            // 
            this.btnNewCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNewCode.HeaderTextId = "new";
            this.btnNewCode.Image = ((System.Drawing.Image)(resources.GetObject("btnNewCode.Image")));
            this.btnNewCode.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnNewCode.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.None;
            this.btnNewCode.Location = new System.Drawing.Point(9, 43);
            this.btnNewCode.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnNewCode.Name = "btnNewCode";
            this.btnNewCode.ResId = "";
            this.btnNewCode.Size = new System.Drawing.Size(89, 93);
            this.btnNewCode.TabIndex = 11;
            this.btnNewCode.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnNewCode.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnNewCode_Click);
            // 
            // gcCode
            // 
            this.gcCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcCode.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.gcCode.Appearance.Options.UseFont = true;
            this.gcCode.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.gcCode.AppearanceCaption.Options.UseFont = true;
            this.gcCode.Controls.Add(this.btnDeleteCode);
            this.gcCode.Controls.Add(this.gridCode);
            this.gcCode.Controls.Add(this.btnSaveCode);
            this.gcCode.Controls.Add(this.btnNewCode);
            this.gcCode.HeaderTextId = "code";
            this.gcCode.Image = null;
            this.gcCode.Location = new System.Drawing.Point(687, 286);
            this.gcCode.Name = "gcCode";
            this.gcCode.ResId = "";
            this.gcCode.Size = new System.Drawing.Size(1176, 719);
            this.gcCode.TabIndex = 2;
            this.gcCode.Text = "Code";
            this.gcCode.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // gridCode
            // 
            this.gridCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCode.Location = new System.Drawing.Point(104, 43);
            this.gridCode.MainView = this.gridViewCode;
            this.gridCode.Name = "gridCode";
            this.gridCode.Size = new System.Drawing.Size(1066, 670);
            this.gridCode.TabIndex = 0;
            this.gridCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCode});
            // 
            // gridViewCode
            // 
            this.gridViewCode.GridControl = this.gridCode;
            this.gridViewCode.Name = "gridViewCode";
            this.gridViewCode.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewCode_InitNewRow);
            // 
            // SYS_Code
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcCode);
            this.Controls.Add(this.gcForm);
            this.Controls.Add(this.gcCodeGroup);
            this.Name = "SYS_Code";
            this.Size = new System.Drawing.Size(1862, 1005);
            ((System.ComponentModel.ISupportInitialize)(this.gcCodeGroup)).EndInit();
            this.gcCodeGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCodeGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCodeGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcForm)).EndInit();
            this.gcForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCode)).EndInit();
            this.gcCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCode)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private HanbiControl.HbGroupControl gcCodeGroup;
        private HanbiControl.HbGroupControl gcForm;
        private HanbiControl.HbGroupControl gcCode;
        private DevExpress.XtraGrid.GridControl gridCodeGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCodeGroup;
        private DevExpress.XtraGrid.GridControl gridCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCode;
        private HanbiControl.HbCheckEditH chkUse;
        private HanbiControl.HbCheckEditH chkSys;
        private HanbiControl.HbTextEditH txtGroupName;
        private HanbiControl.HbTextEditH txtGroupId;
        private HanbiControl.HbSimpleButton btnDeleteCode;
        private HanbiControl.HbSimpleButton btnSaveCode;
        private HanbiControl.HbSimpleButton btnNewCode;
        private HanbiControl.HbMemoEditH txtRemark;
    }
}
