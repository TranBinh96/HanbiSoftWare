namespace SOD
{
    partial class popRefund
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
            this.btnRefundOrder = new HanbiControl.HbSimpleButton();
            this.hbControlReturn = new HanbiControl.HbGroupControl();
            this.etRetReason = new HanbiControl.HbMemoEditH();
            this.radioGroup = new DevExpress.XtraEditors.RadioGroup();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.etRetPriceTotal = new HanbiControl.HbNumberEditH();
            this.etRetPriceReal = new HanbiControl.HbNumberEditH();
            ((System.ComponentModel.ISupportInitialize)(this.hbControlReturn)).BeginInit();
            this.hbControlReturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).BeginInit();
            this.radioGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // etOrdNo
            // 
            this.etOrdNo.FieldName = "";
            this.etOrdNo.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etOrdNo.HeaderTextId = "ord_no";
            this.etOrdNo.HeaderWidth = 160;
            this.etOrdNo.Location = new System.Drawing.Point(15, 12);
            this.etOrdNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.etOrdNo.MaxLengh = 0;
            this.etOrdNo.Name = "etOrdNo";
            this.etOrdNo.ReadOnly = true;
            this.etOrdNo.ResId = "";
            this.etOrdNo.SelectionStart = 0;
            this.etOrdNo.Size = new System.Drawing.Size(251, 29);
            this.etOrdNo.TabIndex = 3;
            this.etOrdNo.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etOrdNo.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // btnRefundOrder
            // 
            this.btnRefundOrder.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRefundOrder.HeaderTextId = "refund";
            this.btnRefundOrder.Image = null;
            this.btnRefundOrder.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnRefundOrder.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnRefundOrder.Location = new System.Drawing.Point(10, 363);
            this.btnRefundOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefundOrder.Name = "btnRefundOrder";
            this.btnRefundOrder.ResId = "";
            this.btnRefundOrder.Size = new System.Drawing.Size(328, 44);
            this.btnRefundOrder.TabIndex = 2;
            this.btnRefundOrder.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnRefundOrder.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnRefundOrder_HbClick);
            // 
            // hbControlReturn
            // 
            this.hbControlReturn.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlReturn.Appearance.Options.UseFont = true;
            this.hbControlReturn.AppearanceCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.hbControlReturn.AppearanceCaption.Options.UseFont = true;
            this.hbControlReturn.Controls.Add(this.etRetReason);
            this.hbControlReturn.Controls.Add(this.radioGroup);
            this.hbControlReturn.Controls.Add(this.etRetPriceTotal);
            this.hbControlReturn.Controls.Add(this.etRetPriceReal);
            this.hbControlReturn.HeaderTextId = "refund";
            this.hbControlReturn.Image = null;
            this.hbControlReturn.Location = new System.Drawing.Point(10, 48);
            this.hbControlReturn.Name = "hbControlReturn";
            this.hbControlReturn.ResId = "";
            this.hbControlReturn.Size = new System.Drawing.Size(328, 308);
            this.hbControlReturn.TabIndex = 18;
            this.hbControlReturn.Text = "Refund";
            this.hbControlReturn.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // etRetReason
            // 
            this.etRetReason.FieldName = "";
            this.etRetReason.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etRetReason.HeaderTextId = "ret_reason";
            this.etRetReason.HeaderWidth = 318;
            this.etRetReason.Location = new System.Drawing.Point(5, 101);
            this.etRetReason.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.etRetReason.MaxLengh = 0;
            this.etRetReason.Name = "etRetReason";
            this.etRetReason.ReadOnly = true;
            this.etRetReason.ResId = "";
            this.etRetReason.SelectionStart = 0;
            this.etRetReason.Size = new System.Drawing.Size(318, 29);
            this.etRetReason.TabIndex = 6;
            this.etRetReason.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etRetReason.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // radioGroup
            // 
            this.radioGroup.Controls.Add(this.radioButton1);
            this.radioGroup.Controls.Add(this.radioButton2);
            this.radioGroup.Controls.Add(this.radioButton3);
            this.radioGroup.Controls.Add(this.radioButton4);
            this.radioGroup.Controls.Add(this.radioButton5);
            this.radioGroup.Location = new System.Drawing.Point(5, 137);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.radioGroup.Size = new System.Drawing.Size(318, 160);
            this.radioGroup.TabIndex = 1;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(20, 10);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(87, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(20, 40);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(87, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(20, 70);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(87, 17);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(20, 100);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(87, 17);
            this.radioButton4.TabIndex = 4;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(20, 130);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(87, 17);
            this.radioButton5.TabIndex = 5;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "radioButton5";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // etRetPriceTotal
            // 
            this.etRetPriceTotal.DecimalPlaces = 0;
            this.etRetPriceTotal.DefaultValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.etRetPriceTotal.FieldName = "";
            this.etRetPriceTotal.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etRetPriceTotal.HeaderTextId = "ret_price_total";
            this.etRetPriceTotal.HeaderWidth = 160;
            this.etRetPriceTotal.Location = new System.Drawing.Point(5, 27);
            this.etRetPriceTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.etRetPriceTotal.MaxLengh = 0;
            this.etRetPriceTotal.Name = "etRetPriceTotal";
            this.etRetPriceTotal.ReadOnly = true;
            this.etRetPriceTotal.ResId = "";
            this.etRetPriceTotal.SelectionStart = 0;
            this.etRetPriceTotal.Size = new System.Drawing.Size(251, 29);
            this.etRetPriceTotal.TabIndex = 4;
            this.etRetPriceTotal.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etRetPriceTotal.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.etRetPriceTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // etRetPriceReal
            // 
            this.etRetPriceReal.DecimalPlaces = 0;
            this.etRetPriceReal.DefaultValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.etRetPriceReal.FieldName = "";
            this.etRetPriceReal.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etRetPriceReal.HeaderTextId = "ret_price_real";
            this.etRetPriceReal.HeaderWidth = 160;
            this.etRetPriceReal.Location = new System.Drawing.Point(5, 64);
            this.etRetPriceReal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.etRetPriceReal.MaxLengh = 0;
            this.etRetPriceReal.Name = "etRetPriceReal";
            this.etRetPriceReal.ReadOnly = true;
            this.etRetPriceReal.ResId = "";
            this.etRetPriceReal.SelectionStart = 0;
            this.etRetPriceReal.Size = new System.Drawing.Size(251, 29);
            this.etRetPriceReal.TabIndex = 5;
            this.etRetPriceReal.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.etRetPriceReal.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.etRetPriceReal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // popRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 420);
            this.Controls.Add(this.hbControlReturn);
            this.Controls.Add(this.btnRefundOrder);
            this.Controls.Add(this.etOrdNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "popRefund";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Return/Refund";
            ((System.ComponentModel.ISupportInitialize)(this.hbControlReturn)).EndInit();
            this.hbControlReturn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).EndInit();
            this.radioGroup.ResumeLayout(false);
            this.radioGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private HanbiControl.HbTextEditH etOrdNo;
        private HanbiControl.HbSimpleButton btnRefundOrder;
        private HanbiControl.HbGroupControl hbControlReturn;
        private HanbiControl.HbNumberEditH etRetPriceTotal;
        private HanbiControl.HbNumberEditH etRetPriceReal;
        private HanbiControl.HbMemoEditH etRetReason;
        private System.Windows.Forms.RadioButton radioButton1;
        private DevExpress.XtraEditors.RadioGroup radioGroup;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}