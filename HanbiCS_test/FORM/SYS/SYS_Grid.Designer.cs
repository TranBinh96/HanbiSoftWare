namespace SYS
{
    partial class SYS_Grid
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
            this.hbGroupControl1 = new HanbiControl.HbGroupControl();
            this.scFind = new HanbiControl.HbTextEditH();
            this.hbGroupControl2 = new HanbiControl.HbGroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.hbGroupControl3 = new HanbiControl.HbGroupControl();
            this.etGridId = new HanbiControl.HbTextEditH();
            this.etClassName = new HanbiControl.HbTextEditH();
            this.etDllName = new HanbiControl.HbTextEditH();
            this.etGridDesc = new HanbiControl.HbMemoEditH();
            this.etGridName = new HanbiControl.HbTextEditH();
            this.hbGroupControl4 = new HanbiControl.HbGroupControl();
            this.btnMoveDown = new HanbiControl.HbSimpleButton();
            this.btnMoveUp = new HanbiControl.HbSimpleButton();
            this.btnDeleteRow = new HanbiControl.HbSimpleButton();
            this.btnAddRow = new HanbiControl.HbSimpleButton();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl1)).BeginInit();
            this.hbGroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl2)).BeginInit();
            this.hbGroupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl3)).BeginInit();
            this.hbGroupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl4)).BeginInit();
            this.hbGroupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // hbGroupControl1
            // 
            this.hbGroupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbGroupControl1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbGroupControl1.Appearance.Options.UseFont = true;
            this.hbGroupControl1.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbGroupControl1.AppearanceCaption.Options.UseFont = true;
            this.hbGroupControl1.Controls.Add(this.scFind);
            this.hbGroupControl1.HeaderTextId = "search_condition";
            this.hbGroupControl1.Image = null;
            this.hbGroupControl1.Location = new System.Drawing.Point(3, 3);
            this.hbGroupControl1.Name = "hbGroupControl1";
            this.hbGroupControl1.ResId = "";
            this.hbGroupControl1.Size = new System.Drawing.Size(1450, 83);
            this.hbGroupControl1.TabIndex = 0;
            this.hbGroupControl1.Text = "조회조건";
            this.hbGroupControl1.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // scFind
            // 
            this.scFind.FieldName = "";
            this.scFind.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scFind.HeaderTextId = "find";
            this.scFind.Location = new System.Drawing.Point(4, 38);
            this.scFind.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.scFind.MaxLengh = 0;
            this.scFind.Name = "scFind";
            this.scFind.ReadOnlyBackColorKeep = true;
            this.scFind.ResId = "";
            this.scFind.SelectionStart = 0;
            this.scFind.Size = new System.Drawing.Size(314, 41);
            this.scFind.TabIndex = 0;
            this.scFind.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scFind.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // hbGroupControl2
            // 
            this.hbGroupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.hbGroupControl2.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbGroupControl2.Appearance.Options.UseFont = true;
            this.hbGroupControl2.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbGroupControl2.AppearanceCaption.Options.UseFont = true;
            this.hbGroupControl2.Controls.Add(this.gridControl1);
            this.hbGroupControl2.HeaderTextId = "list";
            this.hbGroupControl2.Image = null;
            this.hbGroupControl2.Location = new System.Drawing.Point(4, 93);
            this.hbGroupControl2.Name = "hbGroupControl2";
            this.hbGroupControl2.ResId = "";
            this.hbGroupControl2.Size = new System.Drawing.Size(423, 658);
            this.hbGroupControl2.TabIndex = 1;
            this.hbGroupControl2.Text = "List";
            this.hbGroupControl2.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 33);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(419, 623);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.DataSourceChanged += new System.EventHandler(this.gridView1_DataSourceChanged);
            // 
            // hbGroupControl3
            // 
            this.hbGroupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbGroupControl3.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbGroupControl3.Appearance.Options.UseFont = true;
            this.hbGroupControl3.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbGroupControl3.AppearanceCaption.Options.UseFont = true;
            this.hbGroupControl3.Controls.Add(this.etGridId);
            this.hbGroupControl3.Controls.Add(this.etClassName);
            this.hbGroupControl3.Controls.Add(this.etDllName);
            this.hbGroupControl3.Controls.Add(this.etGridDesc);
            this.hbGroupControl3.Controls.Add(this.etGridName);
            this.hbGroupControl3.HeaderTextId = "form";
            this.hbGroupControl3.Image = null;
            this.hbGroupControl3.Location = new System.Drawing.Point(433, 93);
            this.hbGroupControl3.Name = "hbGroupControl3";
            this.hbGroupControl3.ResId = "";
            this.hbGroupControl3.Size = new System.Drawing.Size(1020, 266);
            this.hbGroupControl3.TabIndex = 2;
            this.hbGroupControl3.Text = "Form";
            this.hbGroupControl3.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // etGridId
            // 
            this.etGridId.FieldName = "grid_id";
            this.etGridId.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etGridId.HeaderTextId = "grid_id";
            this.etGridId.isMandatory = true;
            this.etGridId.Location = new System.Drawing.Point(7, 41);
            this.etGridId.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.etGridId.MaxLengh = 0;
            this.etGridId.Name = "etGridId";
            this.etGridId.ReadOnly = true;
            this.etGridId.ResId = "";
            this.etGridId.SelectionStart = 0;
            this.etGridId.Size = new System.Drawing.Size(314, 41);
            this.etGridId.TabIndex = 5;
            this.etGridId.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etGridId.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // etClassName
            // 
            this.etClassName.FieldName = "class_name";
            this.etClassName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etClassName.HeaderTextId = "class_name";
            this.etClassName.Location = new System.Drawing.Point(644, 41);
            this.etClassName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.etClassName.MaxLengh = 0;
            this.etClassName.Name = "etClassName";
            this.etClassName.ReadOnlyBackColorKeep = true;
            this.etClassName.ResId = "";
            this.etClassName.SelectionStart = 0;
            this.etClassName.Size = new System.Drawing.Size(314, 41);
            this.etClassName.TabIndex = 4;
            this.etClassName.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etClassName.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // etDllName
            // 
            this.etDllName.FieldName = "dll_name";
            this.etDllName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etDllName.HeaderTextId = "dll_name";
            this.etDllName.Location = new System.Drawing.Point(324, 41);
            this.etDllName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.etDllName.MaxLengh = 0;
            this.etDllName.Name = "etDllName";
            this.etDllName.ReadOnlyBackColorKeep = true;
            this.etDllName.ResId = "";
            this.etDllName.SelectionStart = 0;
            this.etDllName.Size = new System.Drawing.Size(314, 41);
            this.etDllName.TabIndex = 3;
            this.etDllName.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etDllName.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // etGridDesc
            // 
            this.etGridDesc.FieldName = "grid_desc";
            this.etGridDesc.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etGridDesc.HeaderTextId = "grid_desc";
            this.etGridDesc.Location = new System.Drawing.Point(6, 143);
            this.etGridDesc.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.etGridDesc.MaxLengh = 0;
            this.etGridDesc.Name = "etGridDesc";
            this.etGridDesc.ReadOnlyBackColorKeep = true;
            this.etGridDesc.ResId = "";
            this.etGridDesc.SelectionStart = 0;
            this.etGridDesc.Size = new System.Drawing.Size(953, 94);
            this.etGridDesc.TabIndex = 2;
            this.etGridDesc.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etGridDesc.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // etGridName
            // 
            this.etGridName.FieldName = "grid_name";
            this.etGridName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etGridName.HeaderTextId = "grid_name";
            this.etGridName.Location = new System.Drawing.Point(7, 91);
            this.etGridName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.etGridName.MaxLengh = 0;
            this.etGridName.Name = "etGridName";
            this.etGridName.ReadOnlyBackColorKeep = true;
            this.etGridName.ResId = "";
            this.etGridName.SelectionStart = 0;
            this.etGridName.Size = new System.Drawing.Size(951, 41);
            this.etGridName.TabIndex = 1;
            this.etGridName.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etGridName.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // hbGroupControl4
            // 
            this.hbGroupControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbGroupControl4.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbGroupControl4.Appearance.Options.UseFont = true;
            this.hbGroupControl4.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbGroupControl4.AppearanceCaption.Options.UseFont = true;
            this.hbGroupControl4.Controls.Add(this.btnMoveDown);
            this.hbGroupControl4.Controls.Add(this.btnMoveUp);
            this.hbGroupControl4.Controls.Add(this.btnDeleteRow);
            this.hbGroupControl4.Controls.Add(this.btnAddRow);
            this.hbGroupControl4.Controls.Add(this.gridControl2);
            this.hbGroupControl4.HeaderTextId = "detail_list";
            this.hbGroupControl4.Image = null;
            this.hbGroupControl4.Location = new System.Drawing.Point(433, 365);
            this.hbGroupControl4.Name = "hbGroupControl4";
            this.hbGroupControl4.ResId = "";
            this.hbGroupControl4.Size = new System.Drawing.Size(1020, 387);
            this.hbGroupControl4.TabIndex = 3;
            this.hbGroupControl4.Text = "Detail List";
            this.hbGroupControl4.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMoveDown.HeaderTextId = "move_down";
            this.btnMoveDown.Image = null;
            this.btnMoveDown.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnMoveDown.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnMoveDown.Location = new System.Drawing.Point(344, 42);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.ResId = "";
            this.btnMoveDown.Size = new System.Drawing.Size(111, 41);
            this.btnMoveDown.TabIndex = 4;
            this.btnMoveDown.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnMoveDown.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnMoveDown_HbClick);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMoveUp.HeaderTextId = "move_up";
            this.btnMoveUp.Image = null;
            this.btnMoveUp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnMoveUp.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnMoveUp.Location = new System.Drawing.Point(224, 42);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.ResId = "";
            this.btnMoveUp.Size = new System.Drawing.Size(111, 41);
            this.btnMoveUp.TabIndex = 3;
            this.btnMoveUp.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnMoveUp.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnMoveUp_HbClick);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDeleteRow.HeaderTextId = "delete_row";
            this.btnDeleteRow.Image = null;
            this.btnDeleteRow.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnDeleteRow.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDeleteRow.Location = new System.Drawing.Point(116, 42);
            this.btnDeleteRow.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.ResId = "";
            this.btnDeleteRow.Size = new System.Drawing.Size(100, 41);
            this.btnDeleteRow.TabIndex = 2;
            this.btnDeleteRow.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnDeleteRow.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnDeleteRow_HbClick);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAddRow.HeaderTextId = "add_row";
            this.btnAddRow.Image = null;
            this.btnAddRow.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAddRow.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnAddRow.Location = new System.Drawing.Point(7, 42);
            this.btnAddRow.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.ResId = "";
            this.btnAddRow.Size = new System.Drawing.Size(100, 41);
            this.btnAddRow.TabIndex = 1;
            this.btnAddRow.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnAddRow.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnAddRow_HbClick);
            // 
            // gridControl2
            // 
            this.gridControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl2.Location = new System.Drawing.Point(3, 93);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(1014, 291);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView2_InitNewRow);
            this.gridView2.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView2_CellValueChanged);
            // 
            // SYS_Grid
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hbGroupControl4);
            this.Controls.Add(this.hbGroupControl3);
            this.Controls.Add(this.hbGroupControl2);
            this.Controls.Add(this.hbGroupControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SYS_Grid";
            this.Size = new System.Drawing.Size(1456, 756);
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl1)).EndInit();
            this.hbGroupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl2)).EndInit();
            this.hbGroupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl3)).EndInit();
            this.hbGroupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl4)).EndInit();
            this.hbGroupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HanbiControl.HbGroupControl hbGroupControl1;
        private HanbiControl.HbTextEditH scFind;
        private HanbiControl.HbGroupControl hbGroupControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private HanbiControl.HbGroupControl hbGroupControl3;
        private HanbiControl.HbGroupControl hbGroupControl4;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private HanbiControl.HbTextEditH etClassName;
        private HanbiControl.HbTextEditH etDllName;
        private HanbiControl.HbMemoEditH etGridDesc;
        private HanbiControl.HbTextEditH etGridName;
        private HanbiControl.HbSimpleButton btnMoveDown;
        private HanbiControl.HbSimpleButton btnMoveUp;
        private HanbiControl.HbSimpleButton btnDeleteRow;
        private HanbiControl.HbSimpleButton btnAddRow;
        private HanbiControl.HbTextEditH etGridId;

    }
}
