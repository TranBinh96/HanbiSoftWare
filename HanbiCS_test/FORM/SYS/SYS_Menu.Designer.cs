namespace SYS
{
    partial class SYS_Menu
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.hbGroupControl1 = new HanbiControl.HbGroupControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnKo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnEn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnVi = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnUseYn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.grpForm = new HanbiControl.HbGroupControl();
            this.etParentId = new HanbiControl.HbTextEditH();
            this.etMenuId = new HanbiControl.HbTextEditH();
            this.etCloseYn = new HanbiControl.HbCheckEditH();
            this.etOpenYn = new HanbiControl.HbCheckEditH();
            this.etMenuGroup = new HanbiControl.HbComboEditH();
            this.etDepth = new HanbiControl.HbNumberEditH();
            this.etUseYn = new HanbiControl.HbCheckEditH();
            this.etClassName = new HanbiControl.HbTextEditH();
            this.etDllName = new HanbiControl.HbTextEditH();
            this.etMenuName = new HanbiControl.HbTextEditH();
            this.etSort = new HanbiControl.HbNumberEditH();
            this.etMenuType = new HanbiControl.HbComboEditH();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl1)).BeginInit();
            this.hbGroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpForm)).BeginInit();
            this.grpForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.hbGroupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grpForm);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1386, 907);
            this.splitContainerControl1.SplitterPosition = 657;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // hbGroupControl1
            // 
            this.hbGroupControl1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbGroupControl1.Appearance.Options.UseFont = true;
            this.hbGroupControl1.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbGroupControl1.AppearanceCaption.Options.UseFont = true;
            this.hbGroupControl1.Controls.Add(this.treeList1);
            this.hbGroupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hbGroupControl1.HeaderTextId = "treelist";
            this.hbGroupControl1.Image = null;
            this.hbGroupControl1.Location = new System.Drawing.Point(0, 0);
            this.hbGroupControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hbGroupControl1.Name = "hbGroupControl1";
            this.hbGroupControl1.ResId = "";
            this.hbGroupControl1.Size = new System.Drawing.Size(441, 907);
            this.hbGroupControl1.TabIndex = 0;
            this.hbGroupControl1.Text = "트리리스트";
            this.hbGroupControl1.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // treeList1
            // 
            this.treeList1.Appearance.BandPanel.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.BandPanel.Options.UseFont = true;
            this.treeList1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.treeList1.Appearance.Empty.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.Empty.Options.UseFont = true;
            this.treeList1.Appearance.EvenRow.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.EvenRow.Options.UseFont = true;
            this.treeList1.Appearance.FilterPanel.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.FilterPanel.Options.UseFont = true;
            this.treeList1.Appearance.FixedLine.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.FixedLine.Options.UseFont = true;
            this.treeList1.Appearance.FocusedCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.FocusedCell.Options.UseFont = true;
            this.treeList1.Appearance.FocusedRow.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.FocusedRow.Options.UseFont = true;
            this.treeList1.Appearance.FooterPanel.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.FooterPanel.Options.UseFont = true;
            this.treeList1.Appearance.GroupButton.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.GroupButton.Options.UseFont = true;
            this.treeList1.Appearance.GroupFooter.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.GroupFooter.Options.UseFont = true;
            this.treeList1.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.HeaderPanel.Options.UseFont = true;
            this.treeList1.Appearance.HeaderPanelBackground.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.HeaderPanelBackground.Options.UseFont = true;
            this.treeList1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treeList1.Appearance.HorzLine.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.HorzLine.Options.UseFont = true;
            this.treeList1.Appearance.OddRow.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.OddRow.Options.UseFont = true;
            this.treeList1.Appearance.Preview.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.Preview.Options.UseFont = true;
            this.treeList1.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.Row.Options.UseFont = true;
            this.treeList1.Appearance.SelectedRow.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.SelectedRow.Options.UseFont = true;
            this.treeList1.Appearance.TreeLine.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.TreeLine.Options.UseFont = true;
            this.treeList1.Appearance.VertLine.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.treeList1.Appearance.VertLine.Options.UseFont = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnId,
            this.treeListColumnKo,
            this.treeListColumnEn,
            this.treeListColumnVi,
            this.treeListColumnUseYn});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(2, 33);
            this.treeList1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.DragNodes = true;
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.Size = new System.Drawing.Size(437, 872);
            this.treeList1.TabIndex = 0;
            this.treeList1.AfterDragNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList1_AfterDragNode);
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeList1_DragOver);
            // 
            // treeListColumnId
            // 
            this.treeListColumnId.Caption = "ID";
            this.treeListColumnId.FieldName = "id";
            this.treeListColumnId.Name = "treeListColumnId";
            this.treeListColumnId.Visible = true;
            this.treeListColumnId.VisibleIndex = 0;
            this.treeListColumnId.Width = 81;
            // 
            // treeListColumnKo
            // 
            this.treeListColumnKo.Caption = "KO";
            this.treeListColumnKo.FieldName = "ko";
            this.treeListColumnKo.Name = "treeListColumnKo";
            this.treeListColumnKo.Visible = true;
            this.treeListColumnKo.VisibleIndex = 1;
            this.treeListColumnKo.Width = 82;
            // 
            // treeListColumnEn
            // 
            this.treeListColumnEn.Caption = "EN";
            this.treeListColumnEn.FieldName = "en";
            this.treeListColumnEn.Name = "treeListColumnEn";
            this.treeListColumnEn.Visible = true;
            this.treeListColumnEn.VisibleIndex = 2;
            this.treeListColumnEn.Width = 81;
            // 
            // treeListColumnVi
            // 
            this.treeListColumnVi.Caption = "VI";
            this.treeListColumnVi.FieldName = "vi";
            this.treeListColumnVi.Name = "treeListColumnVi";
            this.treeListColumnVi.Visible = true;
            this.treeListColumnVi.VisibleIndex = 3;
            this.treeListColumnVi.Width = 81;
            // 
            // treeListColumnUseYn
            // 
            this.treeListColumnUseYn.Caption = "Usable";
            this.treeListColumnUseYn.FieldName = "use_yn";
            this.treeListColumnUseYn.Name = "treeListColumnUseYn";
            this.treeListColumnUseYn.Visible = true;
            this.treeListColumnUseYn.VisibleIndex = 4;
            this.treeListColumnUseYn.Width = 81;
            // 
            // grpForm
            // 
            this.grpForm.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.grpForm.Appearance.Options.UseFont = true;
            this.grpForm.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.grpForm.AppearanceCaption.Options.UseFont = true;
            this.grpForm.Controls.Add(this.etParentId);
            this.grpForm.Controls.Add(this.etMenuId);
            this.grpForm.Controls.Add(this.etCloseYn);
            this.grpForm.Controls.Add(this.etOpenYn);
            this.grpForm.Controls.Add(this.etMenuGroup);
            this.grpForm.Controls.Add(this.etDepth);
            this.grpForm.Controls.Add(this.etUseYn);
            this.grpForm.Controls.Add(this.etClassName);
            this.grpForm.Controls.Add(this.etDllName);
            this.grpForm.Controls.Add(this.etMenuName);
            this.grpForm.Controls.Add(this.etSort);
            this.grpForm.Controls.Add(this.etMenuType);
            this.grpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpForm.HeaderTextId = "form";
            this.grpForm.Image = null;
            this.grpForm.Location = new System.Drawing.Point(0, 0);
            this.grpForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpForm.Name = "grpForm";
            this.grpForm.ResId = "";
            this.grpForm.Size = new System.Drawing.Size(940, 907);
            this.grpForm.TabIndex = 0;
            this.grpForm.Text = "폼";
            this.grpForm.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // etParentId
            // 
            this.etParentId.FieldName = "parent_id";
            this.etParentId.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etParentId.HeaderTextId = "parent_menu_id";
            this.etParentId.Location = new System.Drawing.Point(330, 42);
            this.etParentId.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.etParentId.MaxLengh = 0;
            this.etParentId.Name = "etParentId";
            this.etParentId.ReadOnly = true;
            this.etParentId.ReadOnlyBackColorKeep = true;
            this.etParentId.ResId = "";
            this.etParentId.SelectionStart = 0;
            this.etParentId.Size = new System.Drawing.Size(314, 41);
            this.etParentId.TabIndex = 13;
            this.etParentId.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etParentId.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // etMenuId
            // 
            this.etMenuId.FieldName = "menu_id";
            this.etMenuId.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etMenuId.HeaderTextId = "menu_id";
            this.etMenuId.Location = new System.Drawing.Point(7, 96);
            this.etMenuId.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.etMenuId.MaxLengh = 0;
            this.etMenuId.Name = "etMenuId";
            this.etMenuId.ReadOnly = true;
            this.etMenuId.ResId = "";
            this.etMenuId.SelectionStart = 0;
            this.etMenuId.Size = new System.Drawing.Size(314, 41);
            this.etMenuId.TabIndex = 12;
            this.etMenuId.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etMenuId.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // etCloseYn
            // 
            this.etCloseYn.Checked = false;
            this.etCloseYn.FieldName = "close_yn";
            this.etCloseYn.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etCloseYn.HeaderTextId = "menu_close_yn";
            this.etCloseYn.Location = new System.Drawing.Point(330, 310);
            this.etCloseYn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.etCloseYn.Name = "etCloseYn";
            this.etCloseYn.ResId = "";
            this.etCloseYn.Size = new System.Drawing.Size(314, 41);
            this.etCloseYn.TabIndex = 11;
            this.etCloseYn.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.etCloseYn.Value = "N";
            this.etCloseYn.HbCheckedChanged += new HanbiControl.clsControl.CheckedChangedEventHandler(this.etCloseYn_HbCheckedChanged);
            // 
            // etOpenYn
            // 
            this.etOpenYn.Checked = false;
            this.etOpenYn.FieldName = "open_yn";
            this.etOpenYn.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etOpenYn.HeaderTextId = "menu_open_yn";
            this.etOpenYn.Location = new System.Drawing.Point(7, 310);
            this.etOpenYn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.etOpenYn.Name = "etOpenYn";
            this.etOpenYn.ResId = "";
            this.etOpenYn.Size = new System.Drawing.Size(314, 41);
            this.etOpenYn.TabIndex = 10;
            this.etOpenYn.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.etOpenYn.Value = "N";
            this.etOpenYn.HbCheckedChanged += new HanbiControl.clsControl.CheckedChangedEventHandler(this.etOpenYn_HbCheckedChanged);
            // 
            // etMenuGroup
            // 
            this.etMenuGroup.DataSource = null;
            this.etMenuGroup.DefaultRowName = "All";
            this.etMenuGroup.DefaultRowValue = "";
            this.etMenuGroup.DictionaryList = null;
            this.etMenuGroup.FieldName = "menu_group";
            this.etMenuGroup.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etMenuGroup.HeaderTextId = "menu_group";
            this.etMenuGroup.Location = new System.Drawing.Point(7, 42);
            this.etMenuGroup.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.etMenuGroup.Name = "etMenuGroup";
            this.etMenuGroup.ProcAction = procAction1;
            this.etMenuGroup.ReadOnly = true;
            this.etMenuGroup.ResId = "";
            this.etMenuGroup.Size = new System.Drawing.Size(314, 41);
            this.etMenuGroup.TabIndex = 9;
            this.etMenuGroup.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etMenuGroup.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.etMenuGroup.Value = null;
            // 
            // etDepth
            // 
            this.etDepth.DecimalPlaces = 0;
            this.etDepth.DefaultValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.etDepth.FieldName = "depth";
            this.etDepth.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etDepth.HeaderTextId = "menu_depth";
            this.etDepth.Location = new System.Drawing.Point(7, 203);
            this.etDepth.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.etDepth.MaxLengh = 0;
            this.etDepth.Name = "etDepth";
            this.etDepth.ReadOnly = true;
            this.etDepth.ResId = "";
            this.etDepth.SelectionStart = 0;
            this.etDepth.Size = new System.Drawing.Size(314, 41);
            this.etDepth.TabIndex = 8;
            this.etDepth.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etDepth.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.etDepth.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // etUseYn
            // 
            this.etUseYn.Checked = false;
            this.etUseYn.FieldName = "use_yn";
            this.etUseYn.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etUseYn.HeaderTextId = "use_yn";
            this.etUseYn.Location = new System.Drawing.Point(7, 363);
            this.etUseYn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.etUseYn.Name = "etUseYn";
            this.etUseYn.ResId = "";
            this.etUseYn.Size = new System.Drawing.Size(314, 41);
            this.etUseYn.TabIndex = 7;
            this.etUseYn.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.etUseYn.Value = "N";
            this.etUseYn.FontChanged += new System.EventHandler(this.etUseYn_FontChanged);
            // 
            // etClassName
            // 
            this.etClassName.FieldName = "class_name";
            this.etClassName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etClassName.HeaderTextId = "class_name";
            this.etClassName.Location = new System.Drawing.Point(330, 256);
            this.etClassName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.etClassName.MaxLengh = 0;
            this.etClassName.Name = "etClassName";
            this.etClassName.ResId = "";
            this.etClassName.SelectionStart = 0;
            this.etClassName.Size = new System.Drawing.Size(314, 41);
            this.etClassName.TabIndex = 6;
            this.etClassName.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etClassName.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.etClassName.HbTextChanged += new HanbiControl.clsControl.ChangeTextEventHandler(this.etClassName_HbTextChanged);
            // 
            // etDllName
            // 
            this.etDllName.FieldName = "dll_name";
            this.etDllName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etDllName.HeaderTextId = "dll_name";
            this.etDllName.Location = new System.Drawing.Point(7, 256);
            this.etDllName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.etDllName.MaxLengh = 0;
            this.etDllName.Name = "etDllName";
            this.etDllName.ReadOnlyBackColorKeep = true;
            this.etDllName.ResId = "";
            this.etDllName.SelectionStart = 0;
            this.etDllName.Size = new System.Drawing.Size(314, 41);
            this.etDllName.TabIndex = 5;
            this.etDllName.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etDllName.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.etDllName.HbTextChanged += new HanbiControl.clsControl.ChangeTextEventHandler(this.etDllName_HbTextChanged);
            // 
            // etMenuName
            // 
            this.etMenuName.FieldName = "menu_name";
            this.etMenuName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etMenuName.HeaderTextId = "menu_name";
            this.etMenuName.Location = new System.Drawing.Point(7, 149);
            this.etMenuName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.etMenuName.MaxLengh = 0;
            this.etMenuName.Name = "etMenuName";
            this.etMenuName.ResId = "";
            this.etMenuName.SelectionStart = 0;
            this.etMenuName.Size = new System.Drawing.Size(637, 41);
            this.etMenuName.TabIndex = 4;
            this.etMenuName.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etMenuName.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.etMenuName.HbTextChanged += new HanbiControl.clsControl.ChangeTextEventHandler(this.etMenuName_HbTextChanged);
            // 
            // etSort
            // 
            this.etSort.DecimalPlaces = 0;
            this.etSort.DefaultValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.etSort.FieldName = "sort";
            this.etSort.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etSort.HeaderTextId = "sort_seq";
            this.etSort.Location = new System.Drawing.Point(330, 203);
            this.etSort.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.etSort.MaxLengh = 0;
            this.etSort.Name = "etSort";
            this.etSort.ReadOnly = true;
            this.etSort.ReadOnlyBackColorKeep = true;
            this.etSort.ResId = "";
            this.etSort.SelectionStart = 0;
            this.etSort.Size = new System.Drawing.Size(314, 41);
            this.etSort.TabIndex = 3;
            this.etSort.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etSort.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.etSort.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // etMenuType
            // 
            this.etMenuType.DataSource = null;
            this.etMenuType.DefaultRowName = "All";
            this.etMenuType.DefaultRowValue = "";
            this.etMenuType.DictionaryList = null;
            this.etMenuType.FieldName = "menu_type";
            this.etMenuType.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etMenuType.HeaderTextId = "menu_type";
            this.etMenuType.Location = new System.Drawing.Point(330, 96);
            this.etMenuType.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.etMenuType.Name = "etMenuType";
            this.etMenuType.ProcAction = procAction2;
            this.etMenuType.ReadOnly = true;
            this.etMenuType.ReadOnlyBackColorKeep = true;
            this.etMenuType.ResId = "";
            this.etMenuType.Size = new System.Drawing.Size(314, 41);
            this.etMenuType.TabIndex = 2;
            this.etMenuType.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etMenuType.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.etMenuType.Value = null;
            // 
            // SYS_Menu
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "SYS_Menu";
            this.Size = new System.Drawing.Size(1386, 907);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl1)).EndInit();
            this.hbGroupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpForm)).EndInit();
            this.grpForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private HanbiControl.HbGroupControl hbGroupControl1;
        private HanbiControl.HbGroupControl grpForm;
        private HanbiControl.HbComboEditH etMenuGroup;
        private HanbiControl.HbNumberEditH etDepth;
        private HanbiControl.HbCheckEditH etUseYn;
        private HanbiControl.HbTextEditH etClassName;
        private HanbiControl.HbTextEditH etDllName;
        private HanbiControl.HbTextEditH etMenuName;
        private HanbiControl.HbNumberEditH etSort;
        private HanbiControl.HbComboEditH etMenuType;
        private HanbiControl.HbCheckEditH etCloseYn;
        private HanbiControl.HbCheckEditH etOpenYn;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnKo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnEn;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnVi;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnUseYn;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnId;
        private HanbiControl.HbTextEditH etParentId;
        private HanbiControl.HbTextEditH etMenuId;





    }
}
