namespace MA
{
    partial class MA_Alarm
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
            WebUtil.ProcAction procAction4 = new WebUtil.ProcAction();
            WebUtil.ProcAction procAction5 = new WebUtil.ProcAction();
            WebUtil.ProcAction procAction1 = new WebUtil.ProcAction();
            WebUtil.ProcAction procAction2 = new WebUtil.ProcAction();
            this.hbGroupControl1 = new HanbiControl.HbGroupControl();
            this.txtAlarm = new HanbiControl.HbComboEditH();
            this.txtGreen = new HanbiControl.HbComboEditH();
            this.txtAmber = new HanbiControl.HbComboEditH();
            this.txtRed = new HanbiControl.HbComboEditH();
            this.btnGet = new HanbiControl.HbSimpleButton();
            this.btnSet = new HanbiControl.HbSimpleButton();
            this.txtSound = new HanbiControl.HbNumberEditH();
            this.etPort = new HanbiControl.HbTextEditH();
            this.etRequest = new HanbiControl.HbTextEditH();
            this.etResponse = new HanbiControl.HbTextEditH();
            this.btnRequest = new HanbiControl.HbSimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl1)).BeginInit();
            this.hbGroupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hbGroupControl1
            // 
            this.hbGroupControl1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbGroupControl1.Appearance.Options.UseFont = true;
            this.hbGroupControl1.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.hbGroupControl1.AppearanceCaption.Options.UseFont = true;
            this.hbGroupControl1.Controls.Add(this.btnRequest);
            this.hbGroupControl1.Controls.Add(this.etResponse);
            this.hbGroupControl1.Controls.Add(this.etRequest);
            this.hbGroupControl1.Controls.Add(this.etPort);
            this.hbGroupControl1.Controls.Add(this.txtAlarm);
            this.hbGroupControl1.Controls.Add(this.txtGreen);
            this.hbGroupControl1.Controls.Add(this.txtAmber);
            this.hbGroupControl1.Controls.Add(this.txtRed);
            this.hbGroupControl1.Controls.Add(this.btnGet);
            this.hbGroupControl1.Controls.Add(this.btnSet);
            this.hbGroupControl1.Controls.Add(this.txtSound);
            this.hbGroupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hbGroupControl1.HeaderTextId = "alarm";
            this.hbGroupControl1.Image = null;
            this.hbGroupControl1.Location = new System.Drawing.Point(0, 0);
            this.hbGroupControl1.Name = "hbGroupControl1";
            this.hbGroupControl1.ResId = "";
            this.hbGroupControl1.Size = new System.Drawing.Size(1088, 731);
            this.hbGroupControl1.TabIndex = 0;
            this.hbGroupControl1.Text = "Alarm";
            this.hbGroupControl1.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // txtAlarm
            // 
            this.txtAlarm.DataSource = null;
            this.txtAlarm.DefaultRowName = "All";
            this.txtAlarm.DefaultRowValue = "";
            this.txtAlarm.DictionaryList = null;
            this.txtAlarm.FieldName = "";
            this.txtAlarm.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAlarm.HeaderTextId = "alarm";
            this.txtAlarm.Location = new System.Drawing.Point(4, 35);
            this.txtAlarm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAlarm.Name = "txtAlarm";
            this.txtAlarm.ProcAction = procAction4;
            this.txtAlarm.ReadOnlyBackColorKeep = true;
            this.txtAlarm.ResId = "";
            this.txtAlarm.Size = new System.Drawing.Size(311, 41);
            this.txtAlarm.TabIndex = 10;
            this.txtAlarm.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtAlarm.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtAlarm.Value = null;
            // 
            // txtGreen
            // 
            this.txtGreen.DataSource = null;
            this.txtGreen.DefaultRowName = "All";
            this.txtGreen.DefaultRowValue = "";
            this.txtGreen.DictionaryList = null;
            this.txtGreen.FieldName = "";
            this.txtGreen.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtGreen.HeaderTextId = "al_green";
            this.txtGreen.Location = new System.Drawing.Point(4, 180);
            this.txtGreen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGreen.Name = "txtGreen";
            this.txtGreen.ProcAction = procAction5;
            this.txtGreen.ResId = "";
            this.txtGreen.Size = new System.Drawing.Size(311, 41);
            this.txtGreen.TabIndex = 9;
            this.txtGreen.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtGreen.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtGreen.Value = null;
            // 
            // txtAmber
            // 
            this.txtAmber.DataSource = null;
            this.txtAmber.DefaultRowName = "All";
            this.txtAmber.DefaultRowValue = "";
            this.txtAmber.DictionaryList = null;
            this.txtAmber.FieldName = "";
            this.txtAmber.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAmber.HeaderTextId = "al_amber";
            this.txtAmber.Location = new System.Drawing.Point(4, 132);
            this.txtAmber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAmber.Name = "txtAmber";
            this.txtAmber.ProcAction = procAction1;
            this.txtAmber.ReadOnlyBackColorKeep = true;
            this.txtAmber.ResId = "";
            this.txtAmber.Size = new System.Drawing.Size(311, 41);
            this.txtAmber.TabIndex = 8;
            this.txtAmber.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtAmber.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtAmber.Value = null;
            // 
            // txtRed
            // 
            this.txtRed.DataSource = null;
            this.txtRed.DefaultRowName = "All";
            this.txtRed.DefaultRowValue = "";
            this.txtRed.DictionaryList = null;
            this.txtRed.FieldName = "";
            this.txtRed.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRed.HeaderTextId = "al_red";
            this.txtRed.Location = new System.Drawing.Point(4, 83);
            this.txtRed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRed.Name = "txtRed";
            this.txtRed.ProcAction = procAction2;
            this.txtRed.ResId = "";
            this.txtRed.Size = new System.Drawing.Size(311, 41);
            this.txtRed.TabIndex = 7;
            this.txtRed.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtRed.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtRed.Value = null;
            // 
            // btnGet
            // 
            this.btnGet.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGet.HeaderTextId = "al_get";
            this.btnGet.Image = null;
            this.btnGet.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGet.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnGet.Location = new System.Drawing.Point(97, 277);
            this.btnGet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGet.Name = "btnGet";
            this.btnGet.ResId = "";
            this.btnGet.Size = new System.Drawing.Size(107, 76);
            this.btnGet.TabIndex = 6;
            this.btnGet.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnGet.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnGet_HbClick);
            // 
            // btnSet
            // 
            this.btnSet.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSet.HeaderTextId = "al_set";
            this.btnSet.Image = null;
            this.btnSet.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSet.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSet.Location = new System.Drawing.Point(209, 277);
            this.btnSet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSet.Name = "btnSet";
            this.btnSet.ResId = "";
            this.btnSet.Size = new System.Drawing.Size(107, 76);
            this.btnSet.TabIndex = 5;
            this.btnSet.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnSet.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnSet_HbClick);
            // 
            // txtSound
            // 
            this.txtSound.DecimalPlaces = 0;
            this.txtSound.DefaultValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSound.FieldName = "";
            this.txtSound.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSound.HeaderTextId = "al_sound";
            this.txtSound.Location = new System.Drawing.Point(4, 228);
            this.txtSound.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSound.MaxLengh = 0;
            this.txtSound.Name = "txtSound";
            this.txtSound.ResId = "";
            this.txtSound.SelectionStart = 0;
            this.txtSound.Size = new System.Drawing.Size(311, 41);
            this.txtSound.TabIndex = 3;
            this.txtSound.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtSound.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtSound.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // etPort
            // 
            this.etPort.FieldName = "";
            this.etPort.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etPort.HeaderTextId = "";
            this.etPort.Location = new System.Drawing.Point(466, 150);
            this.etPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.etPort.MaxLengh = 0;
            this.etPort.Name = "etPort";
            this.etPort.ResId = "";
            this.etPort.SelectionStart = 0;
            this.etPort.Size = new System.Drawing.Size(366, 26);
            this.etPort.TabIndex = 12;
            this.etPort.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etPort.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // etRequest
            // 
            this.etRequest.FieldName = "";
            this.etRequest.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etRequest.HeaderTextId = "";
            this.etRequest.Location = new System.Drawing.Point(466, 184);
            this.etRequest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.etRequest.MaxLengh = 0;
            this.etRequest.Name = "etRequest";
            this.etRequest.ReadOnlyBackColorKeep = true;
            this.etRequest.ResId = "";
            this.etRequest.SelectionStart = 0;
            this.etRequest.Size = new System.Drawing.Size(366, 26);
            this.etRequest.TabIndex = 13;
            this.etRequest.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etRequest.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // etResponse
            // 
            this.etResponse.FieldName = "";
            this.etResponse.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etResponse.HeaderTextId = "";
            this.etResponse.Location = new System.Drawing.Point(466, 218);
            this.etResponse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.etResponse.MaxLengh = 0;
            this.etResponse.Name = "etResponse";
            this.etResponse.ResId = "";
            this.etResponse.SelectionStart = 0;
            this.etResponse.Size = new System.Drawing.Size(366, 26);
            this.etResponse.TabIndex = 14;
            this.etResponse.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etResponse.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            // 
            // btnRequest
            // 
            this.btnRequest.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRequest.HeaderTextId = "al_get";
            this.btnRequest.Image = null;
            this.btnRequest.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnRequest.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnRequest.Location = new System.Drawing.Point(466, 252);
            this.btnRequest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.ResId = "";
            this.btnRequest.Size = new System.Drawing.Size(107, 76);
            this.btnRequest.TabIndex = 15;
            this.btnRequest.TextFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnRequest.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnRequest_HbClick);
            // 
            // MA_Alarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hbGroupControl1);
            this.Name = "MA_Alarm";
            this.Size = new System.Drawing.Size(1088, 731);
            ((System.ComponentModel.ISupportInitialize)(this.hbGroupControl1)).EndInit();
            this.hbGroupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HanbiControl.HbGroupControl hbGroupControl1;
        private HanbiControl.HbNumberEditH txtSound;
        private HanbiControl.HbSimpleButton btnSet;
        private HanbiControl.HbSimpleButton btnGet;
        private HanbiControl.HbComboEditH txtRed;
        private HanbiControl.HbComboEditH txtGreen;
        private HanbiControl.HbComboEditH txtAmber;
        private HanbiControl.HbComboEditH txtAlarm;
        private HanbiControl.HbSimpleButton btnRequest;
        private HanbiControl.HbTextEditH etResponse;
        private HanbiControl.HbTextEditH etRequest;
        private HanbiControl.HbTextEditH etPort;

    }
}
