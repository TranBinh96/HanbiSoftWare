namespace SYS
{
    partial class SYS_User
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
            this.hbControlSearch = new HanbiControl.HbGroupControl();
            this.scRole = new HanbiControl.HbComboEditH();
            this.scLocation = new HanbiControl.HbPopupEditH();
            this.scUserName = new HanbiControl.HbTextEditH();
            this.hbControlUser = new HanbiControl.HbGroupControl();
            this.gridUser = new DevExpress.XtraGrid.GridControl();
            this.gridViewUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.hbControlForm = new HanbiControl.HbGroupControl();
            this.cbRole = new HanbiControl.HbComboEditH();
            this.chkUse = new HanbiControl.HbCheckEditH();
            this.popLocation = new HanbiControl.HbPopupEditH();
            this.txtPassword = new HanbiControl.HbTextEditH();
            this.txtUserName = new HanbiControl.HbTextEditH();
            this.txtUserID = new HanbiControl.HbTextEditH();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlSearch)).BeginInit();
            this.hbControlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlUser)).BeginInit();
            this.hbControlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUser)).BeginInit();
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
            this.hbControlSearch.Controls.Add(this.scRole);
            this.hbControlSearch.Controls.Add(this.scLocation);
            this.hbControlSearch.Controls.Add(this.scUserName);
            this.hbControlSearch.HeaderTextId = "search";
            this.hbControlSearch.Image = null;
            this.hbControlSearch.Location = new System.Drawing.Point(2, 0);
            this.hbControlSearch.Margin = new System.Windows.Forms.Padding(2);
            this.hbControlSearch.Name = "hbControlSearch";
            this.hbControlSearch.ResId = "";
            this.hbControlSearch.Size = new System.Drawing.Size(922, 64);
            this.hbControlSearch.TabIndex = 0;
            this.hbControlSearch.Text = "조회";
            this.hbControlSearch.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // scRole
            // 
            this.scRole.DataSource = null;
            this.scRole.DefaultRowName = "All";
            this.scRole.DefaultRowValue = "";
            this.scRole.DictionaryList = null;
            this.scRole.FieldName = "role_id";
            this.scRole.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scRole.HeaderTextId = "role_id";
            this.scRole.Location = new System.Drawing.Point(545, 25);
            this.scRole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scRole.Name = "scRole";
            this.scRole.ProcAction = procAction1;
            this.scRole.ReadOnlyBackColorKeep = true;
            this.scRole.ResId = "";
            this.scRole.Size = new System.Drawing.Size(220, 29);
            this.scRole.TabIndex = 3;
            this.scRole.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scRole.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.scRole.Value = null;
            // 
            // scLocation
            // 
            this.scLocation.ConnectedControls = new HanbiControl.HbControl[0];
            this.scLocation.FieldName = "loc_nm";
            this.scLocation.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scLocation.HeaderTextId = "loc_nm";
            this.scLocation.Location = new System.Drawing.Point(274, 25);
            this.scLocation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scLocation.MaxLengh = 0;
            this.scLocation.Name = "scLocation";
            this.scLocation.PopupFormClassName = "popPickupLocation";
            this.scLocation.PopupFormDllName = "SYS";
            this.scLocation.ReadOnlyBackColorKeep = true;
            this.scLocation.ResId = "";
            this.scLocation.SelectionStart = 0;
            this.scLocation.Size = new System.Drawing.Size(266, 30);
            this.scLocation.TabIndex = 2;
            this.scLocation.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scLocation.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // scUserName
            // 
            this.scUserName.FieldName = "user_nm";
            this.scUserName.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.scUserName.HeaderTextId = "user_nm";
            this.scUserName.Location = new System.Drawing.Point(4, 25);
            this.scUserName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scUserName.MaxLengh = 0;
            this.scUserName.Name = "scUserName";
            this.scUserName.ReadOnlyBackColorKeep = true;
            this.scUserName.ResId = "";
            this.scUserName.SelectionStart = 0;
            this.scUserName.Size = new System.Drawing.Size(266, 30);
            this.scUserName.TabIndex = 1;
            this.scUserName.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.scUserName.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // hbControlUser
            // 
            this.hbControlUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlUser.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlUser.Appearance.Options.UseFont = true;
            this.hbControlUser.AppearanceCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlUser.AppearanceCaption.Options.UseFont = true;
            this.hbControlUser.Controls.Add(this.gridUser);
            this.hbControlUser.HeaderTextId = "user";
            this.hbControlUser.Image = null;
            this.hbControlUser.Location = new System.Drawing.Point(2, 68);
            this.hbControlUser.Margin = new System.Windows.Forms.Padding(2);
            this.hbControlUser.Name = "hbControlUser";
            this.hbControlUser.ResId = "";
            this.hbControlUser.Size = new System.Drawing.Size(640, 542);
            this.hbControlUser.TabIndex = 1;
            this.hbControlUser.Text = "User";
            this.hbControlUser.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // gridUser
            // 
            this.gridUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUser.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridUser.Location = new System.Drawing.Point(4, 25);
            this.gridUser.MainView = this.gridViewUser;
            this.gridUser.Margin = new System.Windows.Forms.Padding(2);
            this.gridUser.Name = "gridUser";
            this.gridUser.Size = new System.Drawing.Size(636, 515);
            this.gridUser.TabIndex = 0;
            this.gridUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewUser});
            // 
            // gridViewUser
            // 
            this.gridViewUser.GridControl = this.gridUser;
            this.gridViewUser.Name = "gridViewUser";
            // 
            // hbControlForm
            // 
            this.hbControlForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hbControlForm.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlForm.Appearance.Options.UseFont = true;
            this.hbControlForm.AppearanceCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlForm.AppearanceCaption.Options.UseFont = true;
            this.hbControlForm.Controls.Add(this.cbRole);
            this.hbControlForm.Controls.Add(this.chkUse);
            this.hbControlForm.Controls.Add(this.popLocation);
            this.hbControlForm.Controls.Add(this.txtPassword);
            this.hbControlForm.Controls.Add(this.txtUserName);
            this.hbControlForm.Controls.Add(this.txtUserID);
            this.hbControlForm.HeaderTextId = "form";
            this.hbControlForm.Image = null;
            this.hbControlForm.Location = new System.Drawing.Point(646, 68);
            this.hbControlForm.Margin = new System.Windows.Forms.Padding(2);
            this.hbControlForm.Name = "hbControlForm";
            this.hbControlForm.ResId = "";
            this.hbControlForm.Size = new System.Drawing.Size(278, 542);
            this.hbControlForm.TabIndex = 2;
            this.hbControlForm.Text = "Form";
            this.hbControlForm.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // cbRole
            // 
            this.cbRole.DataSource = null;
            this.cbRole.DefaultRowName = "All";
            this.cbRole.DefaultRowValue = "";
            this.cbRole.DictionaryList = null;
            this.cbRole.FieldName = "role_id";
            this.cbRole.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbRole.HeaderTextId = "role_id";
            this.cbRole.Location = new System.Drawing.Point(5, 167);
            this.cbRole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbRole.Name = "cbRole";
            this.cbRole.ProcAction = procAction2;
            this.cbRole.ResId = "";
            this.cbRole.Size = new System.Drawing.Size(265, 29);
            this.cbRole.TabIndex = 4;
            this.cbRole.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.cbRole.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.cbRole.Value = null;
            // 
            // chkUse
            // 
            this.chkUse.Checked = false;
            this.chkUse.FieldName = "use_yn";
            this.chkUse.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkUse.HeaderTextId = "use_yn";
            this.chkUse.Location = new System.Drawing.Point(5, 203);
            this.chkUse.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkUse.Name = "chkUse";
            this.chkUse.ResId = "";
            this.chkUse.Size = new System.Drawing.Size(266, 30);
            this.chkUse.TabIndex = 7;
            this.chkUse.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.chkUse.Value = "N";
            // 
            // popLocation
            // 
            this.popLocation.ConnectedControls = new HanbiControl.HbControl[0];
            this.popLocation.FieldName = "loc_cd";
            this.popLocation.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.popLocation.HeaderTextId = "loc_cd";
            this.popLocation.Location = new System.Drawing.Point(4, 130);
            this.popLocation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.popLocation.MaxLengh = 0;
            this.popLocation.Name = "popLocation";
            this.popLocation.PopupFormClassName = "popPickupLocation";
            this.popLocation.PopupFormDllName = "SYS";
            this.popLocation.ReadOnlyBackColorKeep = true;
            this.popLocation.ResId = "";
            this.popLocation.SelectionStart = 0;
            this.popLocation.Size = new System.Drawing.Size(266, 30);
            this.popLocation.TabIndex = 6;
            this.popLocation.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.popLocation.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // txtPassword
            // 
            this.txtPassword.FieldName = "user_pw";
            this.txtPassword.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPassword.HeaderTextId = "user_pw";
            this.txtPassword.isPassword = true;
            this.txtPassword.Location = new System.Drawing.Point(4, 95);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPassword.MaxLengh = 0;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.ReadOnlyBackColorKeep = true;
            this.txtPassword.ResId = "";
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.Size = new System.Drawing.Size(266, 30);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtPassword.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // txtUserName
            // 
            this.txtUserName.FieldName = "user_nm";
            this.txtUserName.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtUserName.HeaderTextId = "user_nm";
            this.txtUserName.Location = new System.Drawing.Point(4, 60);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtUserName.MaxLengh = 0;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ResId = "";
            this.txtUserName.SelectionStart = 0;
            this.txtUserName.Size = new System.Drawing.Size(266, 30);
            this.txtUserName.TabIndex = 4;
            this.txtUserName.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtUserName.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // txtUserID
            // 
            this.txtUserID.FieldName = "user_id";
            this.txtUserID.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtUserID.HeaderTextId = "id";
            this.txtUserID.Location = new System.Drawing.Point(4, 25);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtUserID.MaxLengh = 0;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnlyBackColorKeep = true;
            this.txtUserID.ResId = "";
            this.txtUserID.SelectionStart = 0;
            this.txtUserID.Size = new System.Drawing.Size(266, 30);
            this.txtUserID.TabIndex = 3;
            this.txtUserID.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtUserID.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // SYS_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hbControlForm);
            this.Controls.Add(this.hbControlUser);
            this.Controls.Add(this.hbControlSearch);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SYS_User";
            this.Size = new System.Drawing.Size(925, 610);
            ((System.ComponentModel.ISupportInitialize)(this.hbControlSearch)).EndInit();
            this.hbControlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hbControlUser)).EndInit();
            this.hbControlUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlForm)).EndInit();
            this.hbControlForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HanbiControl.HbGroupControl hbControlSearch;
        private HanbiControl.HbPopupEditH scLocation;
        private HanbiControl.HbTextEditH scUserName;
        private HanbiControl.HbGroupControl hbControlUser;
        private DevExpress.XtraGrid.GridControl gridUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUser;
        private HanbiControl.HbGroupControl hbControlForm;
        private HanbiControl.HbCheckEditH chkUse;
        private HanbiControl.HbPopupEditH popLocation;
        private HanbiControl.HbTextEditH txtPassword;
        private HanbiControl.HbTextEditH txtUserName;
        private HanbiControl.HbTextEditH txtUserID;
        private HanbiControl.HbComboEditH scRole;
        private HanbiControl.HbComboEditH cbRole;
    }
}
