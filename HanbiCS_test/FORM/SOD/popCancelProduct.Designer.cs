namespace SOD
{
    partial class popCancelProduct
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
            this.txtOrdNo = new HanbiControl.HbTextEditH();
            this.btnConfirm = new HanbiControl.HbSimpleButton();
            this.txtProductCode = new HanbiControl.HbTextEditH();
            this.txtProductName = new HanbiControl.HbMemoEditH();
            this.txtOrdQty = new HanbiControl.HbNumberEditH();
            this.txtPickQty = new HanbiControl.HbNumberEditH();
            this.txtRemainQty = new HanbiControl.HbNumberEditH();
            this.txtCancelQty = new HanbiControl.HbNumberEditH();
            this.SuspendLayout();
            // 
            // txtOrdNo
            // 
            this.txtOrdNo.FieldName = "";
            this.txtOrdNo.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtOrdNo.HeaderTextId = "ord_no";
            this.txtOrdNo.HeaderWidth = 150;
            this.txtOrdNo.Location = new System.Drawing.Point(12, 10);
            this.txtOrdNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOrdNo.MaxLengh = 0;
            this.txtOrdNo.Name = "txtOrdNo";
            this.txtOrdNo.ReadOnly = true;
            this.txtOrdNo.ResId = "";
            this.txtOrdNo.SelectionStart = 0;
            this.txtOrdNo.Size = new System.Drawing.Size(322, 26);
            this.txtOrdNo.TabIndex = 2;
            this.txtOrdNo.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtOrdNo.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConfirm.HeaderTextId = "confirm";
            this.btnConfirm.Image = null;
            this.btnConfirm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnConfirm.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnConfirm.Location = new System.Drawing.Point(226, 303);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.ResId = "";
            this.btnConfirm.Size = new System.Drawing.Size(108, 40);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnConfirm.HbClick += new HanbiControl.clsControl.ClickEventHandler(this.btnConfirm_HbClick);
            // 
            // txtProductCode
            // 
            this.txtProductCode.FieldName = "";
            this.txtProductCode.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProductCode.HeaderTextId = "prod_cd";
            this.txtProductCode.HeaderWidth = 150;
            this.txtProductCode.Location = new System.Drawing.Point(12, 64);
            this.txtProductCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductCode.MaxLengh = 0;
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.ResId = "";
            this.txtProductCode.SelectionStart = 0;
            this.txtProductCode.Size = new System.Drawing.Size(322, 26);
            this.txtProductCode.TabIndex = 3;
            this.txtProductCode.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtProductCode.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // txtProductName
            // 
            this.txtProductName.FieldName = "";
            this.txtProductName.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProductName.HeaderTextId = "prod_nm";
            this.txtProductName.HeaderWidth = 150;
            this.txtProductName.Location = new System.Drawing.Point(12, 98);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductName.MaxLengh = 0;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.ResId = "";
            this.txtProductName.SelectionStart = 0;
            this.txtProductName.Size = new System.Drawing.Size(322, 52);
            this.txtProductName.TabIndex = 4;
            this.txtProductName.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtProductName.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            // 
            // txtOrdQty
            // 
            this.txtOrdQty.DecimalPlaces = 0;
            this.txtOrdQty.DefaultValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOrdQty.FieldName = "";
            this.txtOrdQty.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtOrdQty.HeaderTextId = "ord_qty";
            this.txtOrdQty.HeaderWidth = 150;
            this.txtOrdQty.Location = new System.Drawing.Point(12, 158);
            this.txtOrdQty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOrdQty.MaxLengh = 0;
            this.txtOrdQty.Name = "txtOrdQty";
            this.txtOrdQty.ReadOnly = true;
            this.txtOrdQty.ResId = "";
            this.txtOrdQty.SelectionStart = 0;
            this.txtOrdQty.Size = new System.Drawing.Size(322, 26);
            this.txtOrdQty.TabIndex = 5;
            this.txtOrdQty.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtOrdQty.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.txtOrdQty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtPickQty
            // 
            this.txtPickQty.DecimalPlaces = 0;
            this.txtPickQty.DefaultValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPickQty.FieldName = "";
            this.txtPickQty.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPickQty.HeaderTextId = "pick_qty";
            this.txtPickQty.HeaderWidth = 150;
            this.txtPickQty.Location = new System.Drawing.Point(12, 192);
            this.txtPickQty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPickQty.MaxLengh = 0;
            this.txtPickQty.Name = "txtPickQty";
            this.txtPickQty.ReadOnly = true;
            this.txtPickQty.ResId = "";
            this.txtPickQty.SelectionStart = 0;
            this.txtPickQty.Size = new System.Drawing.Size(322, 26);
            this.txtPickQty.TabIndex = 6;
            this.txtPickQty.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtPickQty.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.txtPickQty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtRemainQty
            // 
            this.txtRemainQty.DecimalPlaces = 0;
            this.txtRemainQty.DefaultValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRemainQty.FieldName = "";
            this.txtRemainQty.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRemainQty.HeaderTextId = "remain_qty";
            this.txtRemainQty.HeaderWidth = 150;
            this.txtRemainQty.Location = new System.Drawing.Point(12, 226);
            this.txtRemainQty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRemainQty.MaxLengh = 0;
            this.txtRemainQty.Name = "txtRemainQty";
            this.txtRemainQty.ReadOnly = true;
            this.txtRemainQty.ResId = "";
            this.txtRemainQty.SelectionStart = 0;
            this.txtRemainQty.Size = new System.Drawing.Size(322, 26);
            this.txtRemainQty.TabIndex = 7;
            this.txtRemainQty.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtRemainQty.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.txtRemainQty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtCancelQty
            // 
            this.txtCancelQty.DecimalPlaces = 0;
            this.txtCancelQty.DefaultValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCancelQty.FieldName = "";
            this.txtCancelQty.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCancelQty.HeaderTextId = "cancel_qty";
            this.txtCancelQty.HeaderWidth = 150;
            this.txtCancelQty.Location = new System.Drawing.Point(12, 260);
            this.txtCancelQty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCancelQty.MaxLengh = 0;
            this.txtCancelQty.Name = "txtCancelQty";
            this.txtCancelQty.ResId = "";
            this.txtCancelQty.SelectionStart = 0;
            this.txtCancelQty.Size = new System.Drawing.Size(322, 26);
            this.txtCancelQty.TabIndex = 0;
            this.txtCancelQty.Text_Align = DevExpress.Utils.HorzAlignment.Default;
            this.txtCancelQty.TextFont = new System.Drawing.Font("Malgun Gothic", 9F);
            this.txtCancelQty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCancelQty.HbTextChanged += new HanbiControl.clsControl.ChangeTextEventHandler(this.txtCancelQty_HbTextChanged);
            // 
            // popCancelProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 356);
            this.Controls.Add(this.txtCancelQty);
            this.Controls.Add(this.txtRemainQty);
            this.Controls.Add(this.txtPickQty);
            this.Controls.Add(this.txtOrdQty);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtOrdNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "popCancelProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancel Product";
            this.ResumeLayout(false);

        }

        #endregion

        private HanbiControl.HbTextEditH txtOrdNo;
        private HanbiControl.HbSimpleButton btnConfirm;
        private HanbiControl.HbTextEditH txtProductCode;
        private HanbiControl.HbMemoEditH txtProductName;
        private HanbiControl.HbNumberEditH txtOrdQty;
        private HanbiControl.HbNumberEditH txtPickQty;
        private HanbiControl.HbNumberEditH txtRemainQty;
        private HanbiControl.HbNumberEditH txtCancelQty;
    }
}