namespace APP
{
    partial class APP_Login
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
            this.grpLogin = new HanbiControl.HbGroupControl();
            this.chkLoginInfoSave = new HanbiControl.HbCheckEditH();
            this.cbLang = new HanbiControl.HbComboEditH();
            this.btnLogin = new HanbiControl.HbSimpleButton();
            this.etPw = new HanbiControl.HbTextEditH();
            this.etId = new HanbiControl.HbTextEditH();
            ((System.ComponentModel.ISupportInitialize)(this.grpLogin)).BeginInit();
            this.grpLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLogin
            // 
            this.grpLogin.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.grpLogin.Appearance.Options.UseFont = true;
            this.grpLogin.AppearanceCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.grpLogin.AppearanceCaption.Options.UseFont = true;
            this.grpLogin.Controls.Add(this.chkLoginInfoSave);
            this.grpLogin.Controls.Add(this.cbLang);
            this.grpLogin.Controls.Add(this.btnLogin);
            this.grpLogin.Controls.Add(this.etPw);
            this.grpLogin.Controls.Add(this.etId);
            this.grpLogin.HeaderTextId = "login";
            this.grpLogin.Image = null;
            this.grpLogin.Location = new System.Drawing.Point(127, 75);
            this.grpLogin.Margin = new System.Windows.Forms.Padding(2);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.ResId = "";
            this.grpLogin.Size = new System.Drawing.Size(293, 230);
            this.grpLogin.TabIndex = 0;
            this.grpLogin.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // chkLoginInfoSave
            // 
            this.chkLoginInfoSave.Checked = false;
            this.chkLoginInfoSave.FieldName = "";
            this.chkLoginInfoSave.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkLoginInfoSave.HeaderTextId = "login_info_save";
            this.chkLoginInfoSave.Location = new System.Drawing.Point(14, 135);
            this.chkLoginInfoSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkLoginInfoSave.Name = "chkLoginInfoSave";
            this.chkLoginInfoSave.ResId = "";
            this.chkLoginInfoSave.Size = new System.Drawing.Size(267, 29);
            this.chkLoginInfoSave.TabIndex = 4;
            this.chkLoginInfoSave.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.chkLoginInfoSave.Value = "N";
            // 
            // cbLang
            // 
            this.cbLang.DataSource = null;
            this.cbLang.DefaultRowName = "All";
            this.cbLang.DefaultRowValue = "";
            this.cbLang.DictionaryList = null;
            this.cbLang.FieldName = "";
            this.cbLang.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbLang.HeaderTextId = "lang";
            this.cbLang.Location = new System.Drawing.Point(14, 31);
            this.cbLang.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbLang.Name = "cbLang";
            this.cbLang.ProcAction = procAction1;
            this.cbLang.ResId = "";
            this.cbLang.Size = new System.Drawing.Size(267, 29);
            this.cbLang.TabIndex = 1;
            this.cbLang.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.cbLang.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.cbLang.Value = null;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLogin.HeaderTextId = "login";
            this.btnLogin.Image = null;
            this.btnLogin.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnLogin.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnLogin.Location = new System.Drawing.Point(194, 175);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.ResId = "";
            this.btnLogin.Size = new System.Drawing.Size(87, 43);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnLogin.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnLogin_HbClick);
            // 
            // etPw
            // 
            this.etPw.FieldName = "";
            this.etPw.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etPw.HeaderTextId = "password";
            this.etPw.isPassword = true;
            this.etPw.Location = new System.Drawing.Point(14, 101);
            this.etPw.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.etPw.MaxLengh = 0;
            this.etPw.Name = "etPw";
            this.etPw.ResId = "";
            this.etPw.SelectionStart = 0;
            this.etPw.Size = new System.Drawing.Size(267, 29);
            this.etPw.TabIndex = 3;
            this.etPw.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etPw.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // etId
            // 
            this.etId.FieldName = "";
            this.etId.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etId.HeaderTextId = "id";
            this.etId.Location = new System.Drawing.Point(14, 66);
            this.etId.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.etId.MaxLengh = 0;
            this.etId.Name = "etId";
            this.etId.ResId = "";
            this.etId.SelectionStart = 0;
            this.etId.Size = new System.Drawing.Size(267, 29);
            this.etId.TabIndex = 2;
            this.etId.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etId.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // APP_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpLogin);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "APP_Login";
            this.Size = new System.Drawing.Size(691, 468);
            this.Load += new System.EventHandler(this.APP_Login_Load);
            this.Resize += new System.EventHandler(this.APP_Login_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grpLogin)).EndInit();
            this.grpLogin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HanbiControl.HbGroupControl grpLogin;
        private HanbiControl.HbComboEditH cbLang;
        private HanbiControl.HbSimpleButton btnLogin;
        private HanbiControl.HbTextEditH etPw;
        private HanbiControl.HbTextEditH etId;
        private HanbiControl.HbCheckEditH chkLoginInfoSave;
    }
}
