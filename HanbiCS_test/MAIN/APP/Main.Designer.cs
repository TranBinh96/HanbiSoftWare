namespace APP
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.nav = new DevExpress.XtraNavBar.NavBarControl();
            this.navGrpApp = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.treeApp = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.treeAdmin = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.navBarGroupControlContainer3 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.treeSystem = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.navGrpAdmin = new DevExpress.XtraNavBar.NavBarGroup();
            this.navGrpSystem = new DevExpress.XtraNavBar.NavBarGroup();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.etCancelSync = new HanbiControl.HbCheckEditH();
            this.etInterface = new HanbiControl.HbCheckEditH();
            this.btnLogout = new HanbiControl.HbSimpleButton();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.lblLocName = new DevExpress.XtraEditors.LabelControl();
            this.btnPrint = new HanbiControl.HbSimpleButton();
            this.btnCopy = new HanbiControl.HbSimpleButton();
            this.btnDelete = new HanbiControl.HbSimpleButton();
            this.btnSave = new HanbiControl.HbSimpleButton();
            this.btnNew = new HanbiControl.HbSimpleButton();
            this.btnSearch = new HanbiControl.HbSimpleButton();
            this.cbSkin = new HanbiControl.HbComboEditH();
            this.cbLang = new HanbiControl.HbComboEditH();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barMain = new DevExpress.XtraBars.Bar();
            this.barStatus = new DevExpress.XtraBars.Bar();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barHeaderItem2 = new DevExpress.XtraBars.BarHeaderItem();
            this.barHeaderItem3 = new DevExpress.XtraBars.BarHeaderItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            ((System.ComponentModel.ISupportInitialize)(this.nav)).BeginInit();
            this.nav.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeApp)).BeginInit();
            this.navBarGroupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeAdmin)).BeginInit();
            this.navBarGroupControlContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            this.SuspendLayout();
            // 
            // nav
            // 
            this.nav.ActiveGroup = this.navGrpApp;
            this.nav.Controls.Add(this.navBarGroupControlContainer1);
            this.nav.Controls.Add(this.navBarGroupControlContainer2);
            this.nav.Controls.Add(this.navBarGroupControlContainer3);
            this.nav.Dock = System.Windows.Forms.DockStyle.Left;
            this.nav.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.nav.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navGrpApp,
            this.navGrpAdmin,
            this.navGrpSystem});
            this.nav.Location = new System.Drawing.Point(0, 20);
            this.nav.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nav.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.nav.Name = "nav";
            this.nav.OptionsNavPane.ExpandedWidth = 200;
            this.nav.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.nav.Size = new System.Drawing.Size(200, 957);
            this.nav.StoreDefaultPaintStyleName = true;
            this.nav.TabIndex = 0;
            this.nav.Text = "navBarControl1";
            // 
            // navGrpApp
            // 
            this.navGrpApp.Caption = "Application";
            this.navGrpApp.ControlContainer = this.navBarGroupControlContainer1;
            this.navGrpApp.Expanded = true;
            this.navGrpApp.GroupClientHeight = 654;
            this.navGrpApp.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navGrpApp.Name = "navGrpApp";
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer1.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer1.Controls.Add(this.treeApp);
            this.navBarGroupControlContainer1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(200, 798);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // treeApp
            // 
            this.treeApp.Appearance.BandPanel.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.BandPanel.Options.UseFont = true;
            this.treeApp.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.treeApp.Appearance.Empty.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.Empty.Options.UseFont = true;
            this.treeApp.Appearance.EvenRow.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.EvenRow.Options.UseFont = true;
            this.treeApp.Appearance.FilterPanel.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.FilterPanel.Options.UseFont = true;
            this.treeApp.Appearance.FixedLine.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.FixedLine.Options.UseFont = true;
            this.treeApp.Appearance.FocusedCell.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.FocusedCell.Options.UseFont = true;
            this.treeApp.Appearance.FocusedRow.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.FocusedRow.Options.UseFont = true;
            this.treeApp.Appearance.FooterPanel.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.FooterPanel.Options.UseFont = true;
            this.treeApp.Appearance.GroupButton.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.GroupButton.Options.UseFont = true;
            this.treeApp.Appearance.GroupFooter.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.GroupFooter.Options.UseFont = true;
            this.treeApp.Appearance.HeaderPanel.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.HeaderPanel.Options.UseFont = true;
            this.treeApp.Appearance.HeaderPanelBackground.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.HeaderPanelBackground.Options.UseFont = true;
            this.treeApp.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treeApp.Appearance.HorzLine.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.HorzLine.Options.UseFont = true;
            this.treeApp.Appearance.OddRow.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.OddRow.Options.UseFont = true;
            this.treeApp.Appearance.Preview.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.Preview.Options.UseFont = true;
            this.treeApp.Appearance.Row.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.Row.Options.UseFont = true;
            this.treeApp.Appearance.SelectedRow.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.SelectedRow.Options.UseFont = true;
            this.treeApp.Appearance.TreeLine.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.TreeLine.Options.UseFont = true;
            this.treeApp.Appearance.VertLine.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeApp.Appearance.VertLine.Options.UseFont = true;
            this.treeApp.AppearancePrint.BandPanel.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeApp.AppearancePrint.BandPanel.Options.UseFont = true;
            this.treeApp.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeApp.AppearancePrint.EvenRow.Options.UseFont = true;
            this.treeApp.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeApp.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.treeApp.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeApp.AppearancePrint.GroupFooter.Options.UseFont = true;
            this.treeApp.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeApp.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.treeApp.AppearancePrint.Lines.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeApp.AppearancePrint.Lines.Options.UseFont = true;
            this.treeApp.AppearancePrint.OddRow.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeApp.AppearancePrint.OddRow.Options.UseFont = true;
            this.treeApp.AppearancePrint.Preview.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeApp.AppearancePrint.Preview.Options.UseFont = true;
            this.treeApp.AppearancePrint.Row.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeApp.AppearancePrint.Row.Options.UseFont = true;
            this.treeApp.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn3,
            this.treeListColumn4});
            this.treeApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeApp.Location = new System.Drawing.Point(0, 0);
            this.treeApp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.treeApp.Name = "treeApp";
            this.treeApp.OptionsBehavior.Editable = false;
            this.treeApp.OptionsView.ShowColumns = false;
            this.treeApp.OptionsView.ShowHorzLines = false;
            this.treeApp.OptionsView.ShowIndicator = false;
            this.treeApp.OptionsView.ShowVertLines = false;
            this.treeApp.Size = new System.Drawing.Size(200, 798);
            this.treeApp.TabIndex = 1;
            this.treeApp.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tree_FocusedNodeChanged);
            this.treeApp.DoubleClick += new System.EventHandler(this.tree_DoubleClick);
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "name";
            this.treeListColumn3.FieldName = "name";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 0;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "id";
            this.treeListColumn4.FieldName = "id";
            this.treeListColumn4.Name = "treeListColumn4";
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer2.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer2.Controls.Add(this.treeAdmin);
            this.navBarGroupControlContainer2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(200, 466);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // treeAdmin
            // 
            this.treeAdmin.Appearance.BandPanel.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.BandPanel.Options.UseFont = true;
            this.treeAdmin.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.treeAdmin.Appearance.Empty.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.Empty.Options.UseFont = true;
            this.treeAdmin.Appearance.EvenRow.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.EvenRow.Options.UseFont = true;
            this.treeAdmin.Appearance.FilterPanel.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.FilterPanel.Options.UseFont = true;
            this.treeAdmin.Appearance.FixedLine.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.FixedLine.Options.UseFont = true;
            this.treeAdmin.Appearance.FocusedCell.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.FocusedCell.Options.UseFont = true;
            this.treeAdmin.Appearance.FocusedRow.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.FocusedRow.Options.UseFont = true;
            this.treeAdmin.Appearance.FooterPanel.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.FooterPanel.Options.UseFont = true;
            this.treeAdmin.Appearance.GroupButton.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.GroupButton.Options.UseFont = true;
            this.treeAdmin.Appearance.GroupFooter.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.GroupFooter.Options.UseFont = true;
            this.treeAdmin.Appearance.HeaderPanel.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.HeaderPanel.Options.UseFont = true;
            this.treeAdmin.Appearance.HeaderPanelBackground.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.HeaderPanelBackground.Options.UseFont = true;
            this.treeAdmin.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treeAdmin.Appearance.HorzLine.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.HorzLine.Options.UseFont = true;
            this.treeAdmin.Appearance.OddRow.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.OddRow.Options.UseFont = true;
            this.treeAdmin.Appearance.Preview.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.Preview.Options.UseFont = true;
            this.treeAdmin.Appearance.Row.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.Row.Options.UseFont = true;
            this.treeAdmin.Appearance.SelectedRow.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.SelectedRow.Options.UseFont = true;
            this.treeAdmin.Appearance.TreeLine.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.TreeLine.Options.UseFont = true;
            this.treeAdmin.Appearance.VertLine.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeAdmin.Appearance.VertLine.Options.UseFont = true;
            this.treeAdmin.AppearancePrint.BandPanel.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeAdmin.AppearancePrint.BandPanel.Options.UseFont = true;
            this.treeAdmin.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeAdmin.AppearancePrint.EvenRow.Options.UseFont = true;
            this.treeAdmin.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeAdmin.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.treeAdmin.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeAdmin.AppearancePrint.GroupFooter.Options.UseFont = true;
            this.treeAdmin.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeAdmin.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.treeAdmin.AppearancePrint.Lines.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeAdmin.AppearancePrint.Lines.Options.UseFont = true;
            this.treeAdmin.AppearancePrint.OddRow.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeAdmin.AppearancePrint.OddRow.Options.UseFont = true;
            this.treeAdmin.AppearancePrint.Preview.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeAdmin.AppearancePrint.Preview.Options.UseFont = true;
            this.treeAdmin.AppearancePrint.Row.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeAdmin.AppearancePrint.Row.Options.UseFont = true;
            this.treeAdmin.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn5,
            this.treeListColumn6});
            this.treeAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeAdmin.Location = new System.Drawing.Point(0, 0);
            this.treeAdmin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.treeAdmin.Name = "treeAdmin";
            this.treeAdmin.OptionsBehavior.Editable = false;
            this.treeAdmin.OptionsView.ShowColumns = false;
            this.treeAdmin.OptionsView.ShowHorzLines = false;
            this.treeAdmin.OptionsView.ShowIndicator = false;
            this.treeAdmin.OptionsView.ShowVertLines = false;
            this.treeAdmin.Size = new System.Drawing.Size(200, 466);
            this.treeAdmin.TabIndex = 2;
            this.treeAdmin.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tree_FocusedNodeChanged);
            this.treeAdmin.DoubleClick += new System.EventHandler(this.tree_DoubleClick);
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "name";
            this.treeListColumn5.FieldName = "name";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 0;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "id";
            this.treeListColumn6.FieldName = "id";
            this.treeListColumn6.Name = "treeListColumn6";
            // 
            // navBarGroupControlContainer3
            // 
            this.navBarGroupControlContainer3.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer3.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer3.Controls.Add(this.treeSystem);
            this.navBarGroupControlContainer3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.navBarGroupControlContainer3.Name = "navBarGroupControlContainer3";
            this.navBarGroupControlContainer3.Size = new System.Drawing.Size(200, 466);
            this.navBarGroupControlContainer3.TabIndex = 2;
            // 
            // treeSystem
            // 
            this.treeSystem.Appearance.BandPanel.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.BandPanel.Options.UseFont = true;
            this.treeSystem.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.treeSystem.Appearance.Empty.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.Empty.Options.UseFont = true;
            this.treeSystem.Appearance.EvenRow.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.EvenRow.Options.UseFont = true;
            this.treeSystem.Appearance.FilterPanel.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.FilterPanel.Options.UseFont = true;
            this.treeSystem.Appearance.FixedLine.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.FixedLine.Options.UseFont = true;
            this.treeSystem.Appearance.FocusedCell.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.FocusedCell.Options.UseFont = true;
            this.treeSystem.Appearance.FocusedRow.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.FocusedRow.Options.UseFont = true;
            this.treeSystem.Appearance.FooterPanel.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.FooterPanel.Options.UseFont = true;
            this.treeSystem.Appearance.GroupButton.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.GroupButton.Options.UseFont = true;
            this.treeSystem.Appearance.GroupFooter.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.GroupFooter.Options.UseFont = true;
            this.treeSystem.Appearance.HeaderPanel.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.HeaderPanel.Options.UseFont = true;
            this.treeSystem.Appearance.HeaderPanelBackground.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.HeaderPanelBackground.Options.UseFont = true;
            this.treeSystem.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treeSystem.Appearance.HorzLine.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.HorzLine.Options.UseFont = true;
            this.treeSystem.Appearance.OddRow.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.OddRow.Options.UseFont = true;
            this.treeSystem.Appearance.Preview.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.Preview.Options.UseFont = true;
            this.treeSystem.Appearance.Row.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.Row.Options.UseFont = true;
            this.treeSystem.Appearance.SelectedRow.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.SelectedRow.Options.UseFont = true;
            this.treeSystem.Appearance.TreeLine.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.TreeLine.Options.UseFont = true;
            this.treeSystem.Appearance.VertLine.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.treeSystem.Appearance.VertLine.Options.UseFont = true;
            this.treeSystem.AppearancePrint.BandPanel.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeSystem.AppearancePrint.BandPanel.Options.UseFont = true;
            this.treeSystem.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeSystem.AppearancePrint.EvenRow.Options.UseFont = true;
            this.treeSystem.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeSystem.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.treeSystem.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeSystem.AppearancePrint.GroupFooter.Options.UseFont = true;
            this.treeSystem.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeSystem.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.treeSystem.AppearancePrint.Lines.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeSystem.AppearancePrint.Lines.Options.UseFont = true;
            this.treeSystem.AppearancePrint.OddRow.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeSystem.AppearancePrint.OddRow.Options.UseFont = true;
            this.treeSystem.AppearancePrint.Preview.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeSystem.AppearancePrint.Preview.Options.UseFont = true;
            this.treeSystem.AppearancePrint.Row.Font = new System.Drawing.Font("Malgun Gothic", 8.25F);
            this.treeSystem.AppearancePrint.Row.Options.UseFont = true;
            this.treeSystem.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeSystem.Location = new System.Drawing.Point(0, 0);
            this.treeSystem.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.treeSystem.Name = "treeSystem";
            this.treeSystem.OptionsBehavior.Editable = false;
            this.treeSystem.OptionsView.ShowColumns = false;
            this.treeSystem.OptionsView.ShowHorzLines = false;
            this.treeSystem.OptionsView.ShowIndicator = false;
            this.treeSystem.OptionsView.ShowVertLines = false;
            this.treeSystem.Size = new System.Drawing.Size(200, 466);
            this.treeSystem.TabIndex = 0;
            this.treeSystem.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tree_FocusedNodeChanged);
            this.treeSystem.DoubleClick += new System.EventHandler(this.tree_DoubleClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "name";
            this.treeListColumn1.FieldName = "name";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "id";
            this.treeListColumn2.FieldName = "id";
            this.treeListColumn2.Name = "treeListColumn2";
            // 
            // navGrpAdmin
            // 
            this.navGrpAdmin.Caption = "Administrator";
            this.navGrpAdmin.ControlContainer = this.navBarGroupControlContainer2;
            this.navGrpAdmin.GroupClientHeight = 466;
            this.navGrpAdmin.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navGrpAdmin.Name = "navGrpAdmin";
            // 
            // navGrpSystem
            // 
            this.navGrpSystem.Caption = "System";
            this.navGrpSystem.ControlContainer = this.navBarGroupControlContainer3;
            this.navGrpSystem.GroupClientHeight = 466;
            this.navGrpSystem.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navGrpSystem.Name = "navGrpSystem";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.tabControl);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(200, 20);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1206, 957);
            this.panelControl1.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.tabControl.Location = new System.Drawing.Point(0, 67);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabControl.Name = "tabControl";
            this.tabControl.Size = new System.Drawing.Size(1206, 890);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabControl_SelectedPageChanged);
            this.tabControl.CloseButtonClick += new System.EventHandler(this.tabControl_CloseButtonClick);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.panelControl2.Appearance.Options.UseFont = true;
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Controls.Add(this.btnPrint);
            this.panelControl2.Controls.Add(this.btnCopy);
            this.panelControl2.Controls.Add(this.btnDelete);
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Controls.Add(this.btnNew);
            this.panelControl2.Controls.Add(this.btnSearch);
            this.panelControl2.Controls.Add(this.cbSkin);
            this.panelControl2.Controls.Add(this.cbLang);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1206, 67);
            this.panelControl2.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl3.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.panelControl3.Appearance.Options.UseFont = true;
            this.panelControl3.Controls.Add(this.etCancelSync);
            this.panelControl3.Controls.Add(this.etInterface);
            this.panelControl3.Controls.Add(this.btnLogout);
            this.panelControl3.Controls.Add(this.lblUserName);
            this.panelControl3.Controls.Add(this.lblLocName);
            this.panelControl3.Location = new System.Drawing.Point(506, 3);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(468, 61);
            this.panelControl3.TabIndex = 16;
            // 
            // etCancelSync
            // 
            this.etCancelSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.etCancelSync.Checked = false;
            this.etCancelSync.FieldName = "";
            this.etCancelSync.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etCancelSync.HeaderTextId = "cancel_if";
            this.etCancelSync.Location = new System.Drawing.Point(228, 33);
            this.etCancelSync.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.etCancelSync.Name = "etCancelSync";
            this.etCancelSync.ResId = "";
            this.etCancelSync.Size = new System.Drawing.Size(145, 26);
            this.etCancelSync.TabIndex = 17;
            this.etCancelSync.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.etCancelSync.Value = "N";
            this.etCancelSync.HbCheckedChanged += new HanbiControl.clsControl.CheckedChangedEventHandler(this.etCancelSync_HbCheckedChanged);
            // 
            // etInterface
            // 
            this.etInterface.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.etInterface.Checked = false;
            this.etInterface.FieldName = "";
            this.etInterface.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etInterface.HeaderTextId = "interface";
            this.etInterface.Location = new System.Drawing.Point(228, 3);
            this.etInterface.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.etInterface.Name = "etInterface";
            this.etInterface.ResId = "";
            this.etInterface.Size = new System.Drawing.Size(145, 26);
            this.etInterface.TabIndex = 16;
            this.etInterface.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.etInterface.Value = "N";
            this.etInterface.HbCheckedChanged += new HanbiControl.clsControl.CheckedChangedEventHandler(this.etInterface_HbCheckedChanged);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLogout.HeaderTextId = "logout";
            this.btnLogout.Image = global::APP.Properties.Resources.reset_16x16;
            this.btnLogout.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnLogout.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnLogout.Location = new System.Drawing.Point(379, 4);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.ResId = "";
            this.btnLogout.Size = new System.Drawing.Size(86, 53);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnLogout.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnLogout_HbClick);
            // 
            // lblUserName
            // 
            this.lblUserName.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.lblUserName.Location = new System.Drawing.Point(8, 34);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(59, 15);
            this.lblUserName.TabIndex = 14;
            this.lblUserName.Text = "User Name";
            // 
            // lblLocName
            // 
            this.lblLocName.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.lblLocName.Location = new System.Drawing.Point(8, 9);
            this.lblLocName.Name = "lblLocName";
            this.lblLocName.Size = new System.Drawing.Size(86, 15);
            this.lblLocName.TabIndex = 13;
            this.lblLocName.Text = "Pickup Location";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrint.HeaderTextId = "print";
            this.btnPrint.Image = global::APP.Properties.Resources.print_32x32;
            this.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPrint.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.None;
            this.btnPrint.Location = new System.Drawing.Point(317, 5);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ResId = "";
            this.btnPrint.Size = new System.Drawing.Size(56, 56);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnPrint.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnPrint_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCopy.HeaderTextId = "copy";
            this.btnCopy.Image = global::APP.Properties.Resources.copy_32x32;
            this.btnCopy.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnCopy.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.None;
            this.btnCopy.Location = new System.Drawing.Point(255, 5);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.ResId = "";
            this.btnCopy.Size = new System.Drawing.Size(56, 56);
            this.btnCopy.TabIndex = 11;
            this.btnCopy.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnCopy.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnCopy_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.HeaderTextId = "delete";
            this.btnDelete.Image = global::APP.Properties.Resources.delete_32x32;
            this.btnDelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnDelete.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.None;
            this.btnDelete.Location = new System.Drawing.Point(193, 5);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ResId = "";
            this.btnDelete.Size = new System.Drawing.Size(56, 56);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnDelete.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.HeaderTextId = "save";
            this.btnSave.Image = global::APP.Properties.Resources.save_32x32;
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.None;
            this.btnSave.Location = new System.Drawing.Point(131, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.ResId = "";
            this.btnSave.Size = new System.Drawing.Size(56, 56);
            this.btnSave.TabIndex = 9;
            this.btnSave.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnSave.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNew.HeaderTextId = "new";
            this.btnNew.Image = global::APP.Properties.Resources.edit_32x32;
            this.btnNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnNew.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.None;
            this.btnNew.Location = new System.Drawing.Point(69, 5);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.ResId = "";
            this.btnNew.Size = new System.Drawing.Size(56, 56);
            this.btnNew.TabIndex = 8;
            this.btnNew.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnNew.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnNew_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.HeaderTextId = "search";
            this.btnSearch.Image = global::APP.Properties.Resources.preview_32x32;
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSearch.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.None;
            this.btnSearch.Location = new System.Drawing.Point(7, 5);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ResId = "";
            this.btnSearch.Size = new System.Drawing.Size(56, 56);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnSearch.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnSearch_Click);
            // 
            // cbSkin
            // 
            this.cbSkin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSkin.DataSource = null;
            this.cbSkin.DefaultRowName = "All";
            this.cbSkin.DefaultRowValue = "";
            this.cbSkin.DictionaryList = null;
            this.cbSkin.FieldName = "";
            this.cbSkin.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbSkin.HeaderTextId = "skin";
            this.cbSkin.Location = new System.Drawing.Point(980, 36);
            this.cbSkin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbSkin.Name = "cbSkin";
            this.cbSkin.ProcAction = null;
            this.cbSkin.ResId = "";
            this.cbSkin.Size = new System.Drawing.Size(220, 26);
            this.cbSkin.TabIndex = 6;
            this.cbSkin.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.cbSkin.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.cbSkin.Value = null;
            // 
            // cbLang
            // 
            this.cbLang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLang.DataSource = null;
            this.cbLang.DefaultRowName = "All";
            this.cbLang.DefaultRowValue = "";
            this.cbLang.DictionaryList = null;
            this.cbLang.FieldName = "";
            this.cbLang.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbLang.HeaderTextId = "lang";
            this.cbLang.Location = new System.Drawing.Point(980, 6);
            this.cbLang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbLang.Name = "cbLang";
            this.cbLang.ProcAction = null;
            this.cbLang.ResId = "";
            this.cbLang.Size = new System.Drawing.Size(220, 26);
            this.cbLang.TabIndex = 5;
            this.cbLang.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.cbLang.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.cbLang.Value = null;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMain,
            this.barStatus});
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barHeaderItem2,
            this.barHeaderItem3,
            this.barSubItem3});
            this.barManager1.MainMenu = this.barMain;
            this.barManager1.MaxItemId = 6;
            this.barManager1.StatusBar = this.barStatus;
            // 
            // barMain
            // 
            this.barMain.BarAppearance.Disabled.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.barMain.BarAppearance.Disabled.Options.UseFont = true;
            this.barMain.BarAppearance.Hovered.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.barMain.BarAppearance.Hovered.Options.UseFont = true;
            this.barMain.BarAppearance.Normal.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.barMain.BarAppearance.Normal.Options.UseFont = true;
            this.barMain.BarAppearance.Pressed.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.barMain.BarAppearance.Pressed.Options.UseFont = true;
            this.barMain.BarName = "Main Menu";
            this.barMain.DockCol = 0;
            this.barMain.DockRow = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.OptionsBar.MultiLine = true;
            this.barMain.OptionsBar.UseWholeRow = true;
            this.barMain.Text = "Main Menu";
            // 
            // barStatus
            // 
            this.barStatus.BarName = "Status bar";
            this.barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barStatus.DockCol = 0;
            this.barStatus.DockRow = 0;
            this.barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barStatus.OptionsBar.AllowQuickCustomization = false;
            this.barStatus.OptionsBar.DrawDragBorder = false;
            this.barStatus.OptionsBar.UseWholeRow = true;
            this.barStatus.Text = "Status bar";
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            this.barAndDockingController1.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
            this.barAndDockingController1.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1406, 20);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 977);
            this.barDockControlBottom.Size = new System.Drawing.Size(1406, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 20);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 957);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1406, 20);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 957);
            // 
            // barHeaderItem2
            // 
            this.barHeaderItem2.Caption = "Administrator";
            this.barHeaderItem2.Id = 1;
            this.barHeaderItem2.Name = "barHeaderItem2";
            // 
            // barHeaderItem3
            // 
            this.barHeaderItem3.Caption = "System Menu";
            this.barHeaderItem3.Id = 2;
            this.barHeaderItem3.Name = "barHeaderItem3";
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "menu3";
            this.barSubItem3.Id = 5;
            this.barSubItem3.Name = "barSubItem3";
            // 
            // Main
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 1000);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.nav);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.IsMdiContainer = true;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Main";
            this.Text = "Hanbi CS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nav)).EndInit();
            this.nav.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeApp)).EndInit();
            this.navBarGroupControlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeAdmin)).EndInit();
            this.navBarGroupControlContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraNavBar.NavBarControl nav;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraNavBar.NavBarGroup navGrpApp;
        private DevExpress.XtraNavBar.NavBarGroup navGrpAdmin;
        private DevExpress.XtraNavBar.NavBarGroup navGrpSystem;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer3;
        private DevExpress.XtraTreeList.TreeList treeSystem;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.TreeList treeAdmin;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraTreeList.TreeList treeApp;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private HanbiControl.HbSimpleButton btnSearch;
        private HanbiControl.HbSimpleButton btnPrint;
        private HanbiControl.HbSimpleButton btnCopy;
        private HanbiControl.HbSimpleButton btnDelete;
        private HanbiControl.HbSimpleButton btnSave;
        private HanbiControl.HbSimpleButton btnNew;
        private HanbiControl.HbComboEditH cbSkin;
        private HanbiControl.HbComboEditH cbLang;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem2;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem3;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private HanbiControl.HbSimpleButton btnLogout;
        private DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraEditors.LabelControl lblLocName;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private HanbiControl.HbCheckEditH etInterface;
        private HanbiControl.HbCheckEditH etCancelSync;
    }
}