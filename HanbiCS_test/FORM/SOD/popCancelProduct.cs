using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WebUtil;
using HanbiControl;

namespace SOD
{
    public partial class popCancelProduct : DevExpress.XtraEditors.XtraForm
    {
        public int pick_qty { get; set; }
        public int remain_qty { get; set; }
        public int cancel_qty { get; set; }

        DevExpress.XtraGrid.Views.Grid.GridView gridViewDetail;

        private int ord_qty;

        public popCancelProduct(DevExpress.XtraGrid.Views.Grid.GridView gridViewDetail, string ordNo)
        {
            InitializeComponent();
            this.LookAndFeel.SkinName = CommonUtil.AccessDB.GetConfig("skin");
            string lang = CommonUtil.AccessDB.GetConfig("lang");
            if (lang == "ko") this.Text = "제품 취소";
            else if (lang == "vi") this.Text = "Hủy sản phẩm";
            else this.Text = "Cancel product";
            this.Refresh();

            this.gridViewDetail = gridViewDetail;
            txtOrdNo.Text = ordNo;

            int selectRow = gridViewDetail.FocusedRowHandle;

            txtProductCode.Text = gridViewDetail.GetRowCellValue(selectRow, "prod_cd").ToString();
            txtProductName.Text = gridViewDetail.GetRowCellValue(selectRow, "prod_nm").ToString();

            ord_qty = int.Parse(gridViewDetail.GetRowCellValue(selectRow, "ord_qty").ToString());
            txtOrdQty.Text = ord_qty.ToString();
            pick_qty = int.Parse(gridViewDetail.GetRowCellValue(selectRow, "pick_qty").ToString());
            txtPickQty.Text = pick_qty.ToString();
            remain_qty = int.Parse(gridViewDetail.GetRowCellValue(selectRow, "remain_qty").ToString());
            txtRemainQty.Text = remain_qty.ToString();
            cancel_qty = int.Parse(gridViewDetail.GetRowCellValue(selectRow, "cancel_qty").ToString());
            txtCancelQty.Text = cancel_qty.ToString();

            txtCancelQty.Focus();
        }

        private void btnConfirm_HbClick(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
        }

        private void txtCancelQty_HbTextChanged(object setnder, EventArgs e)
        {
            if (txtCancelQty.Text.IndexOf(".") > 0)
            {
                cancel_qty = int.Parse(txtCancelQty.Text.Remove(txtCancelQty.Text.IndexOf(".")));
            }
            else
            {
                cancel_qty = int.Parse(txtCancelQty.Text);
            }

            remain_qty = ord_qty - pick_qty - cancel_qty;

            if (remain_qty > 0 && cancel_qty >= 0 && pick_qty + remain_qty + cancel_qty <= ord_qty)
            {
                remain_qty = ord_qty - (pick_qty + cancel_qty);
            }
            else if (remain_qty <= 0 && cancel_qty <= ord_qty && cancel_qty >= 0)
            {
                pick_qty = ord_qty - cancel_qty;
                remain_qty = 0;
            }
            else if (cancel_qty > ord_qty && cancel_qty >= 0)
            {
                pick_qty = 0;
                remain_qty = 0;
                cancel_qty = ord_qty;
            }
            else if (cancel_qty < 0)
            {
                cancel_qty = 0;
                remain_qty = ord_qty - pick_qty;
            }

            txtPickQty.Text = pick_qty.ToString();
            txtRemainQty.Text = remain_qty.ToString();
            txtCancelQty.Text = cancel_qty.ToString();
        }

    }
}