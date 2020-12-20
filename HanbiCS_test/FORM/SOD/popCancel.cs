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
    public partial class popCancel : DevExpress.XtraEditors.XtraForm
    {
        public string stop_reason {get; set;}

        public popCancel(string ordNo)
        {
            InitializeComponent();
            this.LookAndFeel.SkinName = CommonUtil.AccessDB.GetConfig("skin");
            string lang = CommonUtil.AccessDB.GetConfig("lang");
            if (lang == "ko") this.Text = "주문 중지 이유";
            else if (lang == "vi") this.Text = "Lý do hủy đơn hàng";
            else this.Text = "Stop order reason";
            this.Refresh();

            etOrdNo.Text = ordNo;
            stop_reason = String.Empty;

            btnConfirm.Focus();
        }

        private void btnConfirm_HbClick(object sender, EventArgs e)
        {
            stop_reason = etStopReason.Text;
            this.DialogResult = DialogResult.OK;
        }

    }
}