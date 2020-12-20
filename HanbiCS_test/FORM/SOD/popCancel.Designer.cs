namespace SOD
{
    partial class popCancel
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
            this.etOrdNo = new HanbiControl.HbTextEditH();
            this.btnConfirm = new HanbiControl.HbSimpleButton();
            this.etStopReason = new HanbiControl.HbMemoEditH();
            this.SuspendLayout();
            // 
            // etOrdNo
            // 
            this.etOrdNo.FieldName = "";
            this.etOrdNo.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etOrdNo.HeaderTextId = "ord_no";
            this.etOrdNo.HeaderWidth = 140;
            this.etOrdNo.Location = new System.Drawing.Point(10, 10);
            this.etOrdNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.etOrdNo.MaxLengh = 0;
            this.etOrdNo.Name = "etOrdNo";
            this.etOrdNo.ReadOnly = true;
            this.etOrdNo.ResId = "";
            this.etOrdNo.SelectionStart = 0;
            this.etOrdNo.Size = new System.Drawing.Size(231, 25);
            this.etOrdNo.TabIndex = 0;
            this.etOrdNo.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etOrdNo.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConfirm.HeaderTextId = "confirm";
            this.btnConfirm.Image = null;
            this.btnConfirm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnConfirm.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnConfirm.Location = new System.Drawing.Point(264, 111);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.ResId = "";
            this.btnConfirm.Size = new System.Drawing.Size(108, 40);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnConfirm.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnConfirm_HbClick);
            // 
            // etStopReason
            // 
            this.etStopReason.FieldName = "";
            this.etStopReason.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etStopReason.HeaderTextId = "stop_reason";
            this.etStopReason.HeaderWidth = 140;
            this.etStopReason.Location = new System.Drawing.Point(10, 43);
            this.etStopReason.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.etStopReason.MaxLengh = 0;
            this.etStopReason.Name = "etStopReason";
            this.etStopReason.ResId = "";
            this.etStopReason.SelectionStart = 0;
            this.etStopReason.Size = new System.Drawing.Size(362, 60);
            this.etStopReason.TabIndex = 1;
            this.etStopReason.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etStopReason.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // popCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.etStopReason);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.etOrdNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "popCancel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stop order reason";
            this.ResumeLayout(false);

        }

        #endregion

        private HanbiControl.HbTextEditH etOrdNo;
        private HanbiControl.HbSimpleButton btnConfirm;
        private HanbiControl.HbMemoEditH etStopReason;
    }
}