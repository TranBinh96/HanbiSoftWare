using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DevExpress.XtraEditors;
using WebUtil;
using HanbiControl;
using SYS;

namespace SOD
{
    public partial class SOD_Pickup : DevExpress.XtraEditors.XtraUserControl
    {

        const string STR_ORD_QTY = "ord_qty";
        const string STR_PICK_QTY = "pick_qty";
        const string STR_REMAIN_QTY = "remain_qty";
        const string STR_PICK_TRY = "pick_try";

        int ord_qty, pick_qty, remain_qty, cancel_qty;          // Current pickup quantity
        int pick_try;                               // Current Pickup times
        string pickStatus;                          // Pickup status
        string deliveryOrder, delivered, stopOrder; // Flag from Order to decide to Delivery

        private string pick_no, ord_no;
        private int currentSelected = 0;

        private bool bolCellChanging = false;

        //COM.COM_HanNux Alarm;

        public string ordNo {get; set;}
        public string pickOrdYn {get; set;}
        public string pickYn {get; set;}
        public string delvOrdYn { get; set; }
        public string delvYn { get; set; }

        public SOD_Pickup()
        {
            InitializeComponent();

            InitGridPickup();
            InitGridPickupDetail();
            InitSearchForm();
            InitSearchDate(COM.MainUtils.searchDate);

            Search();
            pick_no = String.Empty;
            ord_no = String.Empty;
        }

        public SOD_Pickup(string ord_no)
        {
            this.ordNo = ord_no;
            InitializeComponent();

            InitGridPickup();
            InitGridPickupDetail();
            InitSearchForm();
            InitSearchDate(COM.MainUtils.searchDate);

            Search();
            this.ordNo = String.Empty;
        }

        public SOD_Pickup(string pick_ord_yn, string pick_yn, string delv_ord_yn, string delv_yn)
        {
            this.pickOrdYn = pick_ord_yn;
            this.pickYn = pick_yn;
            this.delvOrdYn = delv_ord_yn;
            this.delvYn = delv_yn;

            InitializeComponent();

            InitGridPickup();
            InitGridPickupDetail();
            InitSearchForm();

            InitFromDoubleClick();
        }

        void InitFromDoubleClick()
        {
            //scPickOrder.Value = pickOrdYn;
            scPicked.Value = pickYn != null? pickYn : String.Empty;
            scDeliveryOrder.Value = delvOrdYn != null? delvOrdYn: String.Empty;
            scDelivered.Value = delvYn != null? delvYn : String.Empty;

            InitSearchDate(COM.MainUtils.searchDate);
            Search();

            this.pickOrdYn = String.Empty;
            this.pickYn = String.Empty;
            this.delvOrdYn = String.Empty;
            this.delvYn = String.Empty;
            this.ordNo = String.Empty;
        }

        void Research()
        {

            if (gridViewPickup.FocusedRowHandle > 0)
            {
                this.ordNo = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "ord_no").ToString();
            }

            string currenPickNo = pick_no;
            pick_no = String.Empty;
            Search();
            pick_no = currenPickNo;
        }

        private void InitSearchForm()
        {
            scPickupLocation.Text = COM.UserInfo.LocName;

            scPickupStatus.ProcAction.proc = WebUtil.Values.PROC_SQL;
            scPickupStatus.ProcAction.text = "SELECT cd value, cd_nm name FROM tb_sys_code WHERE grp_cd = 'PICKUP_STATUS' UNION SELECT '' value, '' name ORDER BY value ASC";
            scPickupStatus.SetDataByProcAction();

            scPicked.ProcAction.proc = WebUtil.Values.PROC_SQL;
            scPicked.ProcAction.text = "SELECT cd value, cd_nm name FROM tb_sys_code WHERE grp_cd = 'ORDER_STATUS' UNION SELECT '' value, '' name ORDER BY value ASC";
            scPicked.SetDataByProcAction();

            scDeliveryOrder.ProcAction.proc = WebUtil.Values.PROC_SQL;
            scDeliveryOrder.ProcAction.text = "SELECT cd value, cd_nm name FROM tb_sys_code WHERE grp_cd = 'ORDER_STATUS' UNION SELECT '' value, '' name ORDER BY value ASC";
            scDeliveryOrder.SetDataByProcAction();

            scDelivered.ProcAction.proc = WebUtil.Values.PROC_SQL;
            scDelivered.ProcAction.text = "SELECT cd value, cd_nm name FROM tb_sys_code WHERE grp_cd = 'ORDER_STATUS' UNION SELECT '' value, '' name ORDER BY value ASC";
            scDelivered.SetDataByProcAction();

            scStopOrder.ProcAction.proc = WebUtil.Values.PROC_SQL;
            scStopOrder.ProcAction.text = "SELECT cd value, cd_nm name FROM tb_sys_code WHERE grp_cd = 'ORDER_STATUS' UNION SELECT '' value, '' name ORDER BY value ASC";
            scStopOrder.SetDataByProcAction();

            DateTime som = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            scStartDate.Value = som.ToString("yyyy-MM-dd");
            scEndDate.Value = som.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

            btnDeliveryOrder.Enabled = false;
            btnCancelProduct.Enabled = false;
        }

        private void InitSearchDate(string date)
        {
            DateTime startDate;
            if (String.IsNullOrEmpty(date) ||
                (!String.IsNullOrEmpty(date) && !DateTime.TryParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out startDate)))
            {
                startDate = DateTime.Today;
            }
            else
            {
                startDate = DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }

            scStartDate.Value = startDate.ToString("yyyy-MM-dd");
        }

        private void InitGridPickup()
        {
            GridOption gridOption = new GridOption();
            gridOption.SetTextColInfo(false, true, true, true, false, false, 1, "pick_id", "pick_id", 80, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 2, "pick_no", "pick_no", 120, GridOption.Align.left);
            gridOption.SetNumberColInfo(false, false, true, true, false, false, -1, "ord_id", "ord_id", 50, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 3, "ord_no", "ord_no", 120, GridOption.Align.left);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 4, "pick_try", "pick_try", 100, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetPopupColInfo(false, true, true, true, false, false, -1, "loc_cd", "loc_cd", 100, GridOption.Align.left, "SYS", "popPickupLocation");
            gridOption.SetTextColInfo(false, true, true, true, false, false, 5, "loc_nm", "loc_nm", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "pick_sts", "pick_sts", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 6, "pick_sts_nm", "pick_sts_nm", 100, GridOption.Align.center);


            // Order information for Delivery
            // Customer Information
            gridOption.SetTextColInfo(false, true, true, true, true, false, -1, "cust_id", "cust_id", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "full_name", "full_name", 250, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "email", "email", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "mobile_no", "mobile_no", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "tel_no", "tel_no", 100, GridOption.Align.left);

            //Payment and Shipping Infor
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "ord_dt", "ord_dt", 120, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "delv_dt", "delv_dt", 120, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "delv_tp", "delv_tp", 250, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "pay_tp", "pay_tp", 250, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "pay_info", "pay_info", 250, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "ship_post_cd", "ship_post_cd", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "ship_addr", "ship_addr", 300, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "ship_addr_dtl", "ship_addr_dtl", 300, GridOption.Align.left);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "price_total", "price_total", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "price_delv", "price_delv", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "price_point", "price_point", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "price_card", "price_card", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "price_real", "price_real", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "price_event_point", "price_event_point", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "price_coupon", "price_coupon", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "price_cancel", "price_cancel", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            //Deliveriable
            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 7, "pick_yn", "pick_yn", 80, "Y", "N", "N", true);
            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 8, "delv_ord_yn", "delv_ord_yn", 100, "Y", "N", "N", true);
            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 9, "delv_yn", "delv_yn", 80, "Y", "N", "N", true);
            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 10, "stop_yn", "stop_yn", 80, "Y", "N", "N", true);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 11, "stop_reason", "stop_reason", 150, GridOption.Align.left);

            gridOption.Apply(gridViewPickup);
        }

        private void InitGridPickupDetail()
        {
            GridOption gridOption = new GridOption();
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 1, "pick_seq", "pick_seq", 50, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, false, true, true, false, false, -1, "pick_dtl_id", "pick_dtl_id", 50, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, false, true, true, false, false, -1, "pick_id", "pick_id", 50, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetTextColInfo(false, false, true, true, false, false, -1, "pick_no", "pick_no", 100, GridOption.Align.left);
            gridOption.SetNumberColInfo(false, false, true, true, false, false, -1, "ord_id", "ord_id", 50, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetTextColInfo(false, false, true, true, false, false, -1, "ord_no", "ord_no", 50, GridOption.Align.left);

            //Products
            gridOption.SetTextColInfo(false, false, true, true, true, false, 2, "prod_cd", "prod_cd", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, false, true, true, false, false, 3, "prod_nm_ko", "prod_nm_ko", 200, GridOption.Align.left);
            //gridOption.SetTextColInfo(false, false, true, true, false, false, 4, "prod_nm_en", "prod_nm_en", 200, GridOption.Align.left);
            gridOption.SetTextColInfo(false, false, true, true, false, false, 5, "prod_nm", "prod_nm", 200, GridOption.Align.left);
            //gridOption.SetTextColInfo(false, false, true, true, false, false, 6, "unit", "unit", 100, GridOption.Align.center);
            gridOption.SetNumberColInfo(false, false, true, true, false, false, 7, "ord_qty", "ord_qty", 100, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, false, false, true, false, false, 8, "pick_qty", "pick_qty", 100, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, false, true, true, false, false, 9, "remain_qty", "remain_qty", 100, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, false, true, true, false, false, 10, "cancel_qty", "cancel_qty", 100, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            gridOption.SetPopupColInfo(false, true, true, true, false, false, -1, "loc_cd", "loc_cd", 100, GridOption.Align.left, "SYS", "popPickupLocation");
            gridOption.SetTextColInfo(false, true, true, true, false, false, 11, "loc_nm", "loc_nm", 150, GridOption.Align.left);

            // Order detail information for Delivery detail
            gridOption.SetNumberColInfo(false, false, true, true, false, false, -1, "ord_dtl_id", "ord_dtl_id", 50, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "ord_seq", "ord_seq", 50, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "unit_price", "unit_price", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "unit_sale_price", "unit_sale_price", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "unit_delv_price", "unit_delv_price", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            gridOption.Apply(gridViewPickupDetail);
        }

        void Search()
        {
            if (!String.IsNullOrEmpty(pick_no))
            {

                //if (XtraMessageBox.Show("주문 번호를 받으려고합니다: " + pick_no + ". 멈추시겠습니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
                if (XtraMessageBox.Show("Đơn hàng: " + pick_no + " đang được xử lý. \nBạn có muốn tìm kiếm lại hay không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    pick_no = String.Empty;
                }
                else
                {
                    gridViewPickup.FocusedRowHandle = currentSelected;
                    return;
                }
            }

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT A.pick_id, A.pick_no, A.ord_id, A.ord_no, A.pick_try,");
            sql.Append(" A.loc_cd, B.loc_nm, A.pick_sts, C.cd_nm AS pick_sts_nm, ");
            sql.Append(" D.cust_id, D.full_name, D.email, D.mobile_no, D.tel_no,");
            sql.Append(" DATE_FORMAT(D.ord_dt, '%Y-%m-%d %T') ord_dt, DATE_FORMAT(D.delv_dt, '%Y-%m-%d %T') delv_dt, D.delv_tp, D.pay_tp, D.pay_info, D.ship_post_cd, D.ship_addr, D.ship_addr_dtl,");
            sql.Append(" D.price_total, D.price_delv, D.price_point, D.price_card, D.price_real, D.price_event_point, D.price_coupon, D.price_cancel,");
            sql.Append(" D.pick_yn, D.delv_ord_yn, D.delv_yn, D.stop_yn, D.stop_reason");
            sql.Append(" FROM " + HBConstant.TB_SO_PICK + " A");
            sql.Append(" LEFT JOIN " + HBConstant.TB_MA_PICKUP_LOC + " B ON A.loc_cd = B.loc_cd");
            sql.Append(" LEFT JOIN " + HBConstant.TB_SYS_CODE + " C ON A.pick_sts = C.cd");
            sql.Append(" RIGHT JOIN " + HBConstant.TB_SO_ORDER + " D ON A.ord_id = D.ord_id AND A.ord_no = D.ord_no ");

            // Searching with Location
            if (COM.UserInfo.LocName == scPickupLocation.Text)
            {
                sql.Append(" WHERE A.loc_cd = #{loc_cd}");
                action.param.Add("loc_cd", COM.UserInfo.LocCode);
            }
            else if (!String.IsNullOrEmpty(scPickupLocation.Text))
            {
                sql.Append(" WHERE B.loc_nm like concat('%', #{loc_nm}, '%')");
                action.param.Add(scPickupLocation.FieldName, scPickupLocation.Text);
            }
            else
            {
                sql.Append(" WHERE B.loc_nm like concat('%', #{loc_nm}, '%')");
                action.param.Add(scPickupLocation.FieldName, scPickupLocation.Text);
            }

            // Searching with Pickup status
            if(!String.IsNullOrEmpty(scPickupStatus.Value.ToString()))
            {
                sql.Append(" AND A.pick_sts = #{pick_sts}");
                action.param.Add(scPickupStatus.FieldName, scPickupStatus.Value);
            }

            if (!String.IsNullOrEmpty(scPicked.Value.ToString()))
            {
                sql.Append(" AND (D.pick_yn IS NULL OR D.pick_yn = #{pick_yn})");
                action.param.Add(scPicked.FieldName, scPicked.Value);
            }

            if (!String.IsNullOrEmpty(scDeliveryOrder.Value.ToString()))
            {
                sql.Append(" AND (D.delv_ord_yn IS NULL OR D.delv_ord_yn = #{delv_ord_yn})");
                action.param.Add(scDeliveryOrder.FieldName, scDeliveryOrder.Value);
            }

            if (!String.IsNullOrEmpty(scDelivered.Value.ToString()))
            {
                sql.Append(" AND (D.delv_yn IS NULL OR D.delv_yn = #{delv_yn})");
                action.param.Add(scDelivered.FieldName, scDelivered.Value);
            }

            if (!String.IsNullOrEmpty(scStopOrder.Value.ToString()))
            {
                sql.Append(" AND (D.stop_yn IS NULL OR D.stop_yn = #{stop_yn})");
                action.param.Add(scStopOrder.FieldName, scStopOrder.Value);
            }

            // TODO Search with date of Pickup
            if (scStartDate.DateTime <= scEndDate.DateTime)
            {
                sql.Append(" AND (A.in_dt BETWEEN #{start_date} AND #{end_date})");
                action.param.Add(scStartDate.FieldName, scStartDate.DateTime);
                action.param.Add(scEndDate.FieldName, scEndDate.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59));
            }

            sql.Append(" ORDER BY D.stop_yn, D.pick_yn, D.delv_ord_yn, D.delv_yn, A.pick_id ASC ");

            action.text = sql.ToString();

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            gridPickup.DataSource = ds.Tables[0];

            gridViewPickup.RefreshData();
            if (!String.IsNullOrEmpty(ordNo)) ChoiceOrd();
        }

        private void ChoiceOrd()
        {

            for (int i = 0; i < gridViewPickup.RowCount; i++)
            {
                if (gridViewPickup.GetRowCellValue(i, "ord_no").ToString() == this.ordNo)
                {
                    gridViewPickup.FocusedRowHandle = i;
                    break;
                }
            }

            this.ordNo = String.Empty;
        }

        private void gridViewPickup_DataSourceChanged(object sender, EventArgs e)
        {
            if (gridViewPickup.RowCount > 0)
            {
                gridViewPickup.FocusedRowHandle = 0;
                pick_try = int.Parse(gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, STR_PICK_TRY).ToString());
                pickStatus = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, scPickupStatus.FieldName).ToString();
                
                deliveryOrder = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "delv_ord_yn").ToString();
                delivered = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "delv_yn").ToString();
                stopOrder = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "stop_yn").ToString();
                
                if (pickStatus == "done" && HBConstant.NO.Equals(deliveryOrder) &&
                    HBConstant.NO.Equals(delivered) && HBConstant.NO.Equals(stopOrder))
                {
                    btnDeliveryOrder.Enabled = true;
                }
                else btnDeliveryOrder.Enabled = false;

                if (HBConstant.NO.Equals(deliveryOrder) &&
                    HBConstant.NO.Equals(delivered) && HBConstant.NO.Equals(stopOrder)) btnCancelProduct.Enabled = true;
                else btnCancelProduct.Enabled = false;
            }
            else
            {
                gridPickupDetail.DataSource = null;
            }

        }

        private void gridViewPickup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if (e.FocusedRowHandle < 0 || e.FocusedRowHandle >= gridViewPickup.RowCount) return;

            if (!String.IsNullOrEmpty(pick_no) && pick_no != gridViewPickup.GetRowCellValue(e.FocusedRowHandle, "pick_no").ToString())
            {

                //if (XtraMessageBox.Show("주문 번호를 받으려고합니다: " + pick_no + ". 멈추시겠습니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
                if (XtraMessageBox.Show("Đơn hàng: " + pick_no + " đang được xử lý. Bạn có muốn thay đổi hay không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    pick_no = String.Empty;
                }
                else
                {
                    gridViewPickup.FocusedRowHandle = currentSelected;
                    return;
                }
            }

            currentSelected = e.FocusedRowHandle;
            SearchPickupDetail(e.FocusedRowHandle);
            pick_try = int.Parse(gridViewPickup.GetRowCellValue(e.FocusedRowHandle, STR_PICK_TRY).ToString());
            pickStatus = gridViewPickup.GetRowCellValue(e.FocusedRowHandle, scPickupStatus.FieldName).ToString();

            deliveryOrder = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "delv_ord_yn").ToString();
            delivered = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "delv_yn").ToString();
            stopOrder = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "stop_yn").ToString();

            if (pickStatus == "done" && HBConstant.NO.Equals(deliveryOrder) &&
                HBConstant.NO.Equals(delivered) && HBConstant.NO.Equals(stopOrder))
            {
                btnDeliveryOrder.Enabled = true;
                if (!COM.MainUtils.bolConfirmMessage && XtraMessageBox.Show("Đơn lấy hàng " + gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "pick_no").ToString() + " đã hoàn thành. \nBạn có muốn thực hiện giao hàng cho đơn đặt hàng này không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    btnDeliveryOrder_Click(sender, e);
                }

                COM.MainUtils.bolConfirmMessage = true;
            }
            else
            {
                btnDeliveryOrder.Enabled = false;
                COM.MainUtils.bolConfirmMessage = false;
            }

            if (HBConstant.NO.Equals(deliveryOrder) &&
                    HBConstant.NO.Equals(delivered) && HBConstant.NO.Equals(stopOrder)) btnCancelProduct.Enabled = true;
            else btnCancelProduct.Enabled = false;

        }

        private void gridViewPickup_DoubleClick(object sender, System.EventArgs e)
        {
            if (gridViewPickup.RowCount <= 0) return;

            string ord_no = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "ord_no").ToString();
            string delv_ord_yn = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "delv_ord_yn").ToString();

            if (HBConstant.NO.Equals(delv_ord_yn)) return;

            COM.MainUtils.SetParameter(ord_no, String.Empty, String.Empty, delv_ord_yn, String.Empty);
            COM.MainUtils.OpenTab("SOD", "SOD_Delivery");
            COM.MainUtils.ResetParameter();
        }

        private void gridViewPickup_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (gridViewPickup.RowCount <= 0 || e.RowHandle < 0) return;

            if (gridViewPickup.GetRowCellValue(e.RowHandle, "delv_yn").ToString() == "N" &&
                gridViewPickup.GetRowCellValue(e.RowHandle, "stop_yn").ToString() == "N" && e.Appearance.BackColor != Color.LightCoral)
            {
                e.Appearance.BackColor = Color.LightCoral;
            }
            else if (gridViewPickup.GetRowCellValue(e.RowHandle, "delv_yn").ToString() == "Y" &&
             gridViewPickup.GetRowCellValue(e.RowHandle, "stop_yn").ToString() == "N" && e.Appearance.BackColor != Color.Gray)
            {
                e.Appearance.BackColor = Color.Gray;

            }
            else if (gridViewPickup.GetRowCellValue(e.RowHandle, "stop_yn").ToString() == "Y" && e.Appearance.BackColor != Color.White)
            {
                e.Appearance.BackColor = Color.White;
                e.Appearance.ForeColor = Color.Red;
            }
            e.HighPriority = true;
        }


        private void gridViewPickup_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (gridViewPickup.RowCount <= 0 || e.RowHandle < 0) return;

            if (gridViewPickup.GetRowCellValue(e.RowHandle, "stop_yn").ToString() == "Y" && e.Appearance.ForeColor != Color.Red)
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }

        void SearchPickupDetail(int row)
        {
            if (row < 0)
            {
                gridPickupDetail.DataSource = null;
                return;
            }

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT A.pick_seq, A.pick_dtl_id, A.pick_id, A.pick_no, A.ord_id,");
            sql.Append(" A.ord_no, A.prod_cd, B.prod_nm_ko, B.prod_nm_en, B.prod_nm,");
            sql.Append(" A.unit, A.ord_qty, A.pick_qty, A.remain_qty, A.cancel_qty, A.loc_cd,");
            sql.Append(" C.loc_nm, A.ord_dtl_id, A.ord_seq, D.unit_price,");
            sql.Append(" D.unit_sale_price, D.unit_delv_price");
            sql.Append(" FROM " + HBConstant.TB_SO_PICK_DTL + " A");
            sql.Append(" LEFT JOIN " + HBConstant.TB_MA_PRODUCT + " B ON A.prod_cd = B.prod_cd ");
            sql.Append(" LEFT JOIN " + HBConstant.TB_MA_PICKUP_LOC + " C ON A.loc_cd = C.loc_cd ");
            sql.Append(" LEFT JOIN " + HBConstant.TB_SO_ORDER_DTL + " D ON A.ord_dtl_id = D.ord_dtl_id AND A.ord_id = D.ord_id");
            sql.Append(" WHERE A.pick_id = #{pick_id}  ");
            sql.Append(" AND A.pick_no = #{pick_no} ");

            action.text = sql.ToString();
            action.param.Add("pick_id", gridViewPickup.GetRowCellValue(row, "pick_id"));
            action.param.Add("pick_no", gridViewPickup.GetRowCellValue(row, "pick_no"));

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            gridPickupDetail.DataSource = ds.Tables[0];
        }

        private void gridViewPickupDetail_DataSourceChanged(object sender, EventArgs e)
        {
            if (gridViewPickupDetail.RowCount > 0)
            {
                gridViewPickupDetail.FocusedRowHandle = 0;
            }

        }

        private void gridViewPickupDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int selRow = gridViewPickupDetail.FocusedRowHandle;
            if (selRow < 0 || selRow >= gridViewPickupDetail.RowCount) return;
            try
            {
                if (!(int.TryParse(gridViewPickupDetail.GetRowCellValue(selRow, STR_ORD_QTY).ToString(), out ord_qty) &&
                    int.TryParse(gridViewPickupDetail.GetRowCellValue(selRow, STR_PICK_QTY).ToString(), out pick_qty) &&
                    int.TryParse(gridViewPickupDetail.GetRowCellValue(selRow, STR_REMAIN_QTY).ToString(), out remain_qty) &&
                    int.TryParse(gridViewPickupDetail.GetRowCellValue(selRow, "cancel_qty").ToString(), out cancel_qty))) return;

                ord_qty = int.Parse(gridViewPickupDetail.GetRowCellValue(selRow, STR_ORD_QTY).ToString());
                pick_qty = int.Parse(gridViewPickupDetail.GetRowCellValue(selRow, STR_PICK_QTY).ToString());
                remain_qty = int.Parse(gridViewPickupDetail.GetRowCellValue(selRow, STR_REMAIN_QTY).ToString());
                cancel_qty = int.Parse(gridViewPickupDetail.GetRowCellValue(selRow, "cancel_qty").ToString());
            }
            catch (NullReferenceException ex)
            {
                Search();
            }

        }

        // Update Pickup quantity
        private void gridViewPickupDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            int tmp_pick_qty = 0;
            int tmp_remain_qty = 0;           //Calculation pickup quantity after update
            int selRow = gridViewPickupDetail.FocusedRowHandle;
            bool bolPickDone = false;
            int chkOrderQty, chkPickQty, chkRemainQty, chkCancelQty;

            deliveryOrder = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "delv_ord_yn").ToString();
            delivered = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "delv_yn").ToString();

            if (deliveryOrder == "Y" || delivered == "Y" || e.Column.FieldName != STR_PICK_QTY )
            {
                if (e.Column.FieldName != STR_REMAIN_QTY && e.Column.FieldName != "cancel_qty" ) gridViewPickupDetail.CancelUpdateCurrentRow();
                bolCellChanging = false;
                return;
            }
            if (!int.TryParse(gridViewPickupDetail.GetRowCellValue(selRow, STR_PICK_QTY).ToString(), out pick_qty))
            {
                gridViewPickupDetail.CancelUpdateCurrentRow();
                return;
            }


            ord_qty = int.Parse(gridViewPickupDetail.GetRowCellValue(selRow, STR_ORD_QTY).ToString());
            pick_qty = int.Parse(gridViewPickupDetail.GetRowCellValue(selRow, STR_PICK_QTY).ToString());
            remain_qty = int.Parse(gridViewPickupDetail.GetRowCellValue(selRow, STR_REMAIN_QTY).ToString());
            cancel_qty = int.Parse(gridViewPickupDetail.GetRowCellValue(selRow, "cancel_qty").ToString());

            if (!String.IsNullOrEmpty(e.Value.ToString()) && !e.Value.ToString().StartsWith("-") && int.TryParse(e.Value.ToString(), out tmp_pick_qty))
            {
                tmp_pick_qty = int.Parse(e.Value.ToString());
                tmp_remain_qty = ord_qty - tmp_pick_qty - cancel_qty;

                // Pickup quantity are not change
                //if (tmp_pick_qty == pick_qty)
                //{
                //    //XtraMessageBox.Show("픽업 수량은 변경되지 않습니다.", "성공");
                //    XtraMessageBox.Show("Số lượng lấy hàng không thay đổi.", "Thông báo");
                //    bolCellChanging = false;
                //    return;
                //}
            }
            else
            {
                //XtraMessageBox.Show("픽업 수량은 0과 주문 수량 사이 여야합니다.", "성공");
                XtraMessageBox.Show("Số lượng lấy hàng phải lớn hơn 0 và nhỏ hơn số lượng đặt hàng.", "Thông báo");
                //gridViewPickupDetail.SetRowCellValue(selRow, STR_PICK_QTY, pick_qty);
                gridViewPickupDetail.CancelUpdateCurrentRow();
                bolCellChanging = false;
                return;
            }

            // Pickup quantity > order quantity
            if ((tmp_pick_qty + cancel_qty) > ord_qty || tmp_remain_qty < 0)
            {
                //if (XtraMessageBox.Show("픽업 수량이 주문 수량보다 큽니다. 그들 모두를 선택?", "확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
                if (XtraMessageBox.Show("Số lượng lấy hàng đang lớn hơn số lượng đặt hàng. \nBạn có muốn cập nhật lại thành số lượng đặt hàng không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    tmp_pick_qty = ord_qty - cancel_qty;
                    tmp_remain_qty = 0;
                    bolPickDone = true;
                    //gridViewPickupDetail.SetRowCellValue(selRow, STR_PICK_QTY, ord_qty);
                    //gridViewPickupDetail.SetRowCellValue(selRow, STR_REMAIN_QTY, 0);
                }
                else
                {
                    //XtraMessageBox.Show("픽업 수량은 0과 주문 수량 사이 여야합니다.", "성공");
                    XtraMessageBox.Show("Số lượng lấy hàng phải lớn hơn 0 và nhỏ hơn số lượng đặt hàng.", "Thông báo");
                    gridViewPickupDetail.CancelUpdateCurrentRow();
                    bolCellChanging = false;
                    return;
                }
            }
            // Order quantity is equal to pickup quantity: Update status of pickup to done
            else if (ord_qty == (tmp_pick_qty + cancel_qty))
            {
                bolPickDone = true;
            }
            // Order quantity is still greater than pickup quantity: Update status of pickup to retry
            else
            {
                bolPickDone = false;
            }

            pick_no = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "pick_no").ToString();
            ord_no = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "ord_no").ToString();

            // Update Pickup detail
            JsonRequest request = new JsonRequest();
            StringBuilder sql = new StringBuilder();

            ProcAction updatePickDetail = request.NewAction();
            updatePickDetail.proc = WebUtil.Values.PROC_SQL;

            sql.Append("UPDATE " + HBConstant.TB_SO_PICK_DTL);
            sql.Append(" SET pick_qty = #{pick_qty}, remain_qty = #{remain_qty}, up_id = #{up_id}, up_dt = CURRENT_TIMESTAMP");
            sql.Append(" WHERE pick_dtl_id = #{pick_dtl_id} AND pick_id = #{pick_id} AND pick_no = #{pick_no}");

            updatePickDetail.text = sql.ToString();
            updatePickDetail.param.Add(STR_PICK_QTY, tmp_pick_qty);
            updatePickDetail.param.Add(STR_REMAIN_QTY, tmp_remain_qty);
            updatePickDetail.param.Add(HBConstant.C_UP_ID, COM.UserInfo.UserID);
            updatePickDetail.param.Add("pick_dtl_id", gridViewPickupDetail.GetRowCellValue(selRow, "pick_dtl_id"));
            updatePickDetail.param.Add("pick_id", gridViewPickupDetail.GetRowCellValue(selRow, "pick_id"));
            updatePickDetail.param.Add("pick_no", gridViewPickupDetail.GetRowCellValue(selRow, "pick_no"));

            // If current pickup is done, check other pickups
            if (bolPickDone && gridViewPickupDetail.RowCount > 1)
            {
                for (int i = 0; i < gridViewPickupDetail.RowCount; i++)
                {
                    chkOrderQty = int.Parse(gridViewPickupDetail.GetRowCellValue(i, STR_ORD_QTY).ToString());
                    chkPickQty = int.Parse(gridViewPickupDetail.GetRowCellValue(i, STR_PICK_QTY).ToString());
                    chkRemainQty = int.Parse(gridViewPickupDetail.GetRowCellValue(i, STR_REMAIN_QTY).ToString());
                    chkCancelQty = int.Parse(gridViewPickupDetail.GetRowCellValue(i, "cancel_qty").ToString());
                    if (i != selRow && (chkOrderQty != chkPickQty + chkCancelQty || chkRemainQty != 0))
                    {
                        bolPickDone = false;
                        break;
                    }
                }
            }

            // Update status of Pickup and Order
            // All pickup details are done: Pickup done and Order was picked up
            if (bolPickDone)
            {
                ProcAction updatePick = request.NewAction();
                updatePick.proc = WebUtil.Values.PROC_SQL;
                sql.Clear();

                sql.Append("UPDATE " + HBConstant.TB_SO_PICK);
                sql.Append(" SET pick_sts = #{pick_sts}, up_id = #{up_id}, up_dt = CURRENT_TIMESTAMP");
                sql.Append(" WHERE pick_id = #{pick_id} AND pick_no = #{pick_no}");

                updatePick.text = sql.ToString();
                updatePick.param.Add("pick_sts", "done");
                updatePick.param.Add(HBConstant.C_UP_ID, COM.UserInfo.UserID);
                updatePick.param.Add("pick_id", gridViewPickupDetail.GetRowCellValue(selRow, "pick_id"));
                updatePick.param.Add("pick_no", gridViewPickupDetail.GetRowCellValue(selRow, "pick_no"));

                ProcAction updateOrder = request.NewAction();
                updateOrder.proc = WebUtil.Values.PROC_SQL;
                sql.Clear();

                sql.Append("UPDATE " + HBConstant.TB_SO_ORDER);
                sql.Append(" SET pick_yn = #{pick_yn}, up_id = #{up_id}, up_dt = CURRENT_TIMESTAMP");
                sql.Append(" WHERE ord_id = #{ord_id} AND ord_no = #{ord_no}");

                updateOrder.text = sql.ToString();
                updateOrder.param.Add("pick_yn", HBConstant.YES);
                updateOrder.param.Add(HBConstant.C_UP_ID, COM.UserInfo.UserID);
                updateOrder.param.Add("ord_id", gridViewPickupDetail.GetRowCellValue(selRow, "ord_id"));
                updateOrder.param.Add("ord_no", gridViewPickupDetail.GetRowCellValue(selRow, "ord_no"));
            }
            // Exist at least one pickup detail are try: Pickup try be increased
            else
            {
                pick_try = pick_try + 1;
                ProcAction updatePick = request.NewAction();
                updatePick.proc = WebUtil.Values.PROC_SQL;
                sql.Clear();

                sql.Append("UPDATE " + HBConstant.TB_SO_PICK);
                sql.Append(" SET pick_sts = #{pick_sts}, pick_try = #{pick_try}, up_id = #{up_id}, up_dt = CURRENT_TIMESTAMP");
                sql.Append(" WHERE pick_id = #{pick_id} AND pick_no = #{pick_no}");

                updatePick.text = sql.ToString();
                updatePick.param.Add("pick_sts", "retry");
                updatePick.param.Add("pick_try", pick_try);
                updatePick.param.Add(HBConstant.C_UP_ID, COM.UserInfo.UserID);
                updatePick.param.Add("pick_id", gridViewPickupDetail.GetRowCellValue(selRow, "pick_id"));
                updatePick.param.Add("pick_no", gridViewPickupDetail.GetRowCellValue(selRow, "pick_no"));
            }

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);
            if (client.check)
            {
                // TODO Message
                //XtraMessageBox.Show("픽업 주문이 업데이트되었습니다.", "성공");
                int selPickup = gridViewPickup.FocusedRowHandle;
                if (bolPickDone)
                {
                    gridViewPickup.SetRowCellValue(selPickup, "pick_sts", "done");
                    gridViewPickup.SetRowCellValue(selPickup, "pick_sts_nm", "Done");
                    gridViewPickup.SetRowCellValue(selPickup, "pick_yn", "Y");
                    ord_no = String.Empty;
                    pick_no = String.Empty;
                    btnDeliveryOrder.Enabled = true;

                    gridViewPickup.RefreshData();
                    gridViewPickupDetail.RefreshData();

                    if (gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "pick_sts").ToString() == "done" &&
                        gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "pick_sts_nm").ToString() == "Done" &&
                        gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "pick_yn").ToString() == "Y" &&
                        gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "delv_ord_yn").ToString() == "N")
                    {
                        string strPickNo = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "pick_no").ToString();
                        if (XtraMessageBox.Show("Đơn lấy hàng " + strPickNo + " đã hoàn thành. \nBạn có muốn thực hiện giao hàng cho đơn đặt hàng này không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            btnDeliveryOrder_Click(sender, e);
                        }
                    }
                }
                else
                {
                    gridViewPickup.SetRowCellValue(selPickup, "pick_sts", "retry");
                    gridViewPickup.SetRowCellValue(selPickup, "pick_sts_nm", "Retry");
                    gridViewPickup.SetRowCellValue(selPickup, "pick_try", pick_try);
                    btnDeliveryOrder.Enabled = false;
                }
                gridViewPickup.RefreshData();
                SearchPickupDetail(selPickup);
            }
            else
            {
                //XtraMessageBox.Show("픽업 주문 업데이트 실패 : " + client.message, "실패");
                XtraMessageBox.Show("Có lỗi xảy ra: \n" + client.message, "Lỗi");
            }

            bolCellChanging = false;
        }

        private void gridViewPickupDetail_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
            bolCellChanging = true;
        }


        private void gridViewPickupDetail_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            int pickQty = 0;
            int ordQty = 0;
            int cancelQty = 0;

            if (gridViewPickupDetail.RowCount <= 0 || e.RowHandle < 0) return;

            if (int.TryParse(gridViewPickupDetail.GetRowCellValue(e.RowHandle, STR_ORD_QTY).ToString(), out ordQty) &&
                int.TryParse(gridViewPickupDetail.GetRowCellValue(e.RowHandle, STR_PICK_QTY).ToString(), out pickQty) &&
                int.TryParse(gridViewPickupDetail.GetRowCellValue(e.RowHandle, "cancel_qty").ToString(), out cancelQty) &&
                ordQty == (pickQty + cancelQty) && e.Appearance.BackColor != Color.LightGreen)
            {
                e.Appearance.BackColor = Color.LightGreen;
                //gridViewPickupDetail.RefreshRow(e.RowHandle);
            }

            //if (gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "delv_ord_yn").ToString() == "Y" &&
            //   gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "delv_yn").ToString() == "N" &&
            //   gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "stop_yn").ToString() == "N" && e.Appearance.BackColor != Color.LightCoral)
            //{
            //    e.Appearance.BackColor = Color.LightCoral;
            //}
            //else if (gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "delv_ord_yn").ToString() == "Y" &&
            // gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "delv_yn").ToString() == "Y" &&
            // gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "stop_yn").ToString() == "N" && e.Appearance.BackColor != Color.Gray )
            //{
            //    e.Appearance.BackColor = Color.Gray;
            //
            //}
            //else if (gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "stop_yn").ToString() == "Y" && e.Appearance.BackColor != Color.White )
            //{
            //    e.Appearance.BackColor = Color.White;
            //    e.Appearance.ForeColor = Color.Red;
            //}
            e.HighPriority = true;

        }

        private void btnDeliveryOrder_Click(object sender, System.EventArgs e)
        {
            if (gridViewPickup.RowCount <= 0)
            {
                return;
            }

            int selPickRow = gridViewPickup.FocusedRowHandle;
            int delvId = int.Parse(gridViewPickup.GetRowCellValue(selPickRow, "ord_id").ToString());
            string delvNo = getNextDeliveryNo();

            if (String.IsNullOrEmpty(delvNo))
            {
                return;
            }

            JsonRequest request = new JsonRequest();
            StringBuilder sql = new StringBuilder();

            // Update Order
            ProcAction updateOrder = request.NewAction();
            updateOrder.proc = WebUtil.Values.PROC_SQL;

            sql.Append("UPDATE " + HBConstant.TB_SO_ORDER);
            sql.Append(" SET delv_ord_yn = #{delv_ord_yn}, up_id = #{up_id}, up_dt = CURRENT_TIMESTAMP");
            sql.Append(" WHERE ord_id = #{ord_id} AND ord_no = #{ord_no}");

            updateOrder.text = sql.ToString();
            updateOrder.param.Add("delv_ord_yn", "Y");
            updateOrder.param.Add(HBConstant.C_UP_ID, COM.UserInfo.UserID);
            updateOrder.param.Add("ord_id", gridViewPickup.GetRowCellValue(selPickRow, "ord_id"));
            updateOrder.param.Add("ord_no", gridViewPickup.GetRowCellValue(selPickRow, "ord_no"));

            // Create Delivery
            ProcAction insertDelv = request.NewAction();
            insertDelv.proc = WebUtil.Values.PROC_SQL;

            sql.Clear();
            sql.Append("INSERT INTO " + HBConstant.TB_SO_DELV);
            sql.Append(" (delv_id, delv_no, ord_id, ord_no, loc_cd,");
            sql.Append(" cust_id, full_name, email, mobile_no, tel_no,");
            sql.Append(" ord_dt, delv_dt, delv_tp, pay_tp, pay_info, ship_post_cd, ship_addr, ship_addr_dtl,");
            sql.Append(" price_total, price_delv, price_point, price_card, price_real, price_event_point, price_coupon, price_cancel, delv_yn, in_id, in_dt)");

            sql.Append(" VALUES (#{delv_id}, #{delv_no}, #{ord_id}, #{ord_no}, #{loc_cd},");
            sql.Append(" #{cust_id}, #{full_name}, #{email}, #{mobile_no}, #{tel_no},");
            sql.Append(" #{ord_dt}, #{delv_dt}, #{delv_tp}, #{pay_tp}, #{pay_info}, #{ship_post_cd}, #{ship_addr}, #{ship_addr_dtl}, ");
            sql.Append(" #{price_total}, #{price_delv}, #{price_point}, #{price_card}, #{price_real}, #{price_event_point}, #{price_coupon}, #{price_cancel}, #{delv_yn}, #{in_id}, CURRENT_TIMESTAMP)");

            insertDelv.text = sql.ToString();
            insertDelv.param.Add("delv_id", delvId);                                                               // delv_id
            insertDelv.param.Add("delv_no", delvNo);                                                               // delv_no
            insertDelv.param.Add("ord_id", gridViewPickup.GetRowCellValue(selPickRow, "ord_id"));                  // ord_id
            insertDelv.param.Add("ord_no", gridViewPickup.GetRowCellValue(selPickRow, "ord_no"));                  // ord_no
            insertDelv.param.Add("loc_cd", gridViewPickup.GetRowCellValue(selPickRow, "loc_cd"));                  // loc_cd
            insertDelv.param.Add("cust_id", gridViewPickup.GetRowCellValue(selPickRow, "cust_id"));                // cust_id
            insertDelv.param.Add("full_name", gridViewPickup.GetRowCellValue(selPickRow, "full_name"));            // full_name
            insertDelv.param.Add("email", gridViewPickup.GetRowCellValue(selPickRow, "email"));                    // email
            insertDelv.param.Add("mobile_no", gridViewPickup.GetRowCellValue(selPickRow, "mobile_no"));            // mobile_no
            insertDelv.param.Add("tel_no", gridViewPickup.GetRowCellValue(selPickRow, "tel_no"));                  // tel_no
            insertDelv.param.Add("ord_dt", gridViewPickup.GetRowCellValue(selPickRow, "ord_dt"));                  // ord_dt
            insertDelv.param.Add("delv_dt", gridViewPickup.GetRowCellValue(selPickRow, "delv_dt"));                  // delv_dt
            insertDelv.param.Add("delv_tp", gridViewPickup.GetRowCellValue(selPickRow, "delv_tp"));                  // delv_tp
            insertDelv.param.Add("pay_tp", gridViewPickup.GetRowCellValue(selPickRow, "pay_tp"));                  // pay_tp
            insertDelv.param.Add("pay_info", gridViewPickup.GetRowCellValue(selPickRow, "pay_info"));              // pay_info
            insertDelv.param.Add("ship_post_cd", gridViewPickup.GetRowCellValue(selPickRow, "ship_post_cd"));      // ship_post_cd
            insertDelv.param.Add("ship_addr", gridViewPickup.GetRowCellValue(selPickRow, "ship_addr"));            // ship_addr
            insertDelv.param.Add("ship_addr_dtl", gridViewPickup.GetRowCellValue(selPickRow, "ship_addr_dtl"));    // ship_addr_dtl
            insertDelv.param.Add("price_total", gridViewPickup.GetRowCellValue(selPickRow, "price_total"));  // price_total
            insertDelv.param.Add("price_delv", gridViewPickup.GetRowCellValue(selPickRow, "price_delv"));        // price_delv
            insertDelv.param.Add("price_point", gridViewPickup.GetRowCellValue(selPickRow, "price_point"));        // price_point
            insertDelv.param.Add("price_card", gridViewPickup.GetRowCellValue(selPickRow, "price_card"));  // price_card
            insertDelv.param.Add("price_real", gridViewPickup.GetRowCellValue(selPickRow, "price_real"));  // price_real
            insertDelv.param.Add("price_event_point", gridViewPickup.GetRowCellValue(selPickRow, "price_event_point"));  // price_event_point
            insertDelv.param.Add("price_coupon", gridViewPickup.GetRowCellValue(selPickRow, "price_coupon"));  // price_coupon
            insertDelv.param.Add("price_cancel", gridViewPickup.GetRowCellValue(selPickRow, "price_cancel"));  // price_cancel
            insertDelv.param.Add("delv_yn", gridViewPickup.GetRowCellValue(selPickRow, "delv_yn"));                // delv_yn
            insertDelv.param.Add(HBConstant.C_IN_ID, COM.UserInfo.UserID);                                         // in_id

            // Create Delivery detail
            ProcAction insertDelvDtl = request.NewAction();
            insertDelvDtl.proc = WebUtil.Values.PROC_SQL;

            sql.Clear();
            sql.Append("INSERT INTO " + HBConstant.TB_SO_DELV_DTL);
            sql.Append(" (delv_id, delv_no, delv_seq, ord_dtl_id, ord_id,");
            sql.Append(" ord_no, ord_seq, loc_cd, prod_cd, prod_nm,");
            sql.Append(" unit, ord_qty, pick_qty, cancel_qty, unit_price, unit_sale_price,");
            sql.Append(" unit_delv_price, in_id, in_dt)");
            sql.Append(" VALUES ");

            int pickupDtlCount = gridViewPickupDetail.DataRowCount;
            for (int i = 0; i < pickupDtlCount; i++)
            {
                sql.Append(" (#{delv_id},");                                                                //delv_id
                sql.Append(" #{delv_no},");                                                                 //delv_no
                sql.Append(" '" + gridViewPickupDetail.GetRowCellValue(i, "ord_seq") + "',");               //delv_seq
                sql.Append(" '" + gridViewPickupDetail.GetRowCellValue(i, "ord_dtl_id") + "',");            //ord_dtl_id
                sql.Append(" '" + gridViewPickupDetail.GetRowCellValue(i, "ord_id") + "',");                //ord_id
                sql.Append(" '" + gridViewPickupDetail.GetRowCellValue(i, "ord_no") + "',");                //ord_no
                sql.Append(" '" + gridViewPickupDetail.GetRowCellValue(i, "ord_seq") + "',");               //ord_seq
                sql.Append(" '" + gridViewPickupDetail.GetRowCellValue(i, "loc_cd") + "',");                //loc_cd
                sql.Append(" '" + gridViewPickupDetail.GetRowCellValue(i, "prod_cd") + "',");               //prod_cd
                sql.Append(" '" + gridViewPickupDetail.GetRowCellValue(i, "prod_nm") + "',");               //prod_nm
                sql.Append(" '" + gridViewPickupDetail.GetRowCellValue(i, "unit") + "',");                  //unit
                sql.Append(" '" + gridViewPickupDetail.GetRowCellValue(i, "ord_qty") + "',");               //ord_qty
                sql.Append(" '" + gridViewPickupDetail.GetRowCellValue(i, "pick_qty") + "',");               //pick_qty
                sql.Append(" '" + gridViewPickupDetail.GetRowCellValue(i, "cancel_qty") + "',");               //cancel_qty
                sql.Append(" '" + gridViewPickupDetail.GetRowCellValue(i, "unit_price") + "',");            //unit_price
                sql.Append(" '" + gridViewPickupDetail.GetRowCellValue(i, "unit_sale_price") + "',");       //unit_sale_price
                sql.Append(" '" + gridViewPickupDetail.GetRowCellValue(i, "unit_delv_price") + "',");          //unit_delv_price
                sql.Append(" #{in_id},");                                                                   //in_id
                sql.Append(" CURRENT_TIMESTAMP)");                                                          //in_dt
                
                if (i < pickupDtlCount - 1) sql.Append(",");
            }
            insertDelvDtl.text = sql.ToString();
            insertDelvDtl.param.Add("delv_id", delvId);                                                     // delv_id
            insertDelvDtl.param.Add("delv_no", delvNo);                                                     // delv_no
            insertDelvDtl.param.Add(HBConstant.C_IN_ID, COM.UserInfo.UserID);                               // in_id

            // Update shopping mall order status
            ProcAction updateShoppingMall = request.NewAction();

            if (gridViewPickup.GetRowCellValue(selPickRow, "delv_tp").ToString() == "D")
            {
                updateShoppingMall = HBConstant.UpdateOrder(updateShoppingMall, gridViewPickup.GetRowCellValue(selPickRow, "ord_no").ToString(), HBConstant.STS_DELIVERY_D);
            }
            else if (gridViewPickup.GetRowCellValue(selPickRow, "delv_tp").ToString() == "P")
            {
                updateShoppingMall = HBConstant.UpdateOrder(updateShoppingMall, gridViewPickup.GetRowCellValue(selPickRow, "ord_no").ToString(), HBConstant.STS_DELIVERY_P);
            }

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (client.check)
            {
                //XtraMessageBox.Show("피킹 성공.", "성공");
                //Search();
                gridViewPickup.SetRowCellValue(selPickRow, "delv_ord_yn", "Y");
                gridViewPickup.RefreshData();
                gridViewPickupDetail.RefreshData();
                gridViewPickup.FocusedRowHandle = selPickRow;
                XtraMessageBox.Show("Sẵn sàng giao hàng.", "Thông báo");
                btnDeliveryOrder.Enabled = false;
                btnCancelProduct.Enabled = false;

                COM.PrintFormats.PrintDelivery(gridViewPickup.GetRowCellValue(selPickRow, "ord_no").ToString());
            }
            else
            {
                //XtraMessageBox.Show("피킹에 실패: " + client.message, "실패");
                XtraMessageBox.Show("Có lỗi xảy ra: \n" + client.message, "Lỗi");
            }
        }

        private string getNextDeliveryNo()
        {
            string delvNo = String.Empty;

            JsonRequest request = new JsonRequest();
            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            action.text = " SELECT get_next_no(#{p_prefix}, #{p_no_dt}) AS pick_no";
            action.param.Add("p_prefix", HBConstant.F_DELV_NO_PREFIX);
            action.param.Add("p_no_dt", DateTime.Now.ToString("yyyyMMdd"));

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                delvNo = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }

            return delvNo;
        }

        void Print()
        {
            if (gridViewPickup.DataRowCount == 0)
            {
                return;
            }

            COM.PrintFormats.PrintPickOrder(gridViewPickup.GetFocusedRowCellValue("ord_no").ToString());
            //if (COM.UserInfo.LocCode == "0") COM.EmailHelper.SendEmail(gridViewPickup.GetFocusedRowCellValue("ord_no").ToString());
        }

        private string _barcode = "";
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            char c = (char)keyData;

            if (c == '#' || char.IsNumber(c) || c == (char)Keys.ShiftKey || c == '&')
                _barcode += c;

            if (c == (char)Keys.Return)
            {
                
                if (_barcode == "" || bolCellChanging)
                {
                    _barcode = "";
                    return base.ProcessCmdKey(ref msg, keyData);
                }
                // Order No
                else if (_barcode.Substring(0, 1) == "#" || (_barcode.Length > 2 && _barcode.Contains(string.Concat((char)Keys.ShiftKey, "3"))))
                {
                    string ordNo = _barcode.Substring(1, _barcode.Length - 1);

                    if ( _barcode.Length > 2 && _barcode.Contains(string.Concat((char)Keys.ShiftKey, "3")))
                    {
                        int position = _barcode.IndexOf(string.Concat((char)Keys.ShiftKey, "3"));
                        ordNo = _barcode.Substring(position + 2, _barcode.Length - (2 + position));
                    }

                    // Focus Picking, what matching with ord_no
                    //XtraMessageBox.Show(_barcode);
                    //int ordRow = 0;

                    //for (int i = 0; i < gridViewPickup.RowCount; i++)
                    //{
                    //    if (ordNo == gridViewPickup.GetRowCellValue(i, "ord_no").ToString())
                    //    {
                    //        ordRow = i;
                    //        gridViewPickup.FocusedRowHandle = ordRow;
                    //        break;
                    //    }
                    //}

                    this.ordNo = ordNo;
                    COM.MainUtils.bolConfirmMessage = false;
                    InitSearchForm();
                    Search();

                    _barcode = "";
                    return false;

                }
                // Picking No
                else if (_barcode.Substring(0, 1) == "&" || (_barcode.Length > 2 && _barcode.Contains(string.Concat((char)Keys.ShiftKey, "7"))))
                {
                    string ordNo = _barcode.Substring(1, _barcode.Length - 1);

                    if (_barcode.Length > 2 && _barcode.Contains(string.Concat((char)Keys.ShiftKey, "7")))
                    {
                        int position = _barcode.IndexOf(string.Concat((char)Keys.ShiftKey, "7"));
                        ordNo = _barcode.Substring(position + 2, _barcode.Length - (2 + position));
                    }

                    // Open Delivery screen
                    COM.MainUtils.bolConfirmMessage = false;
                    COM.MainUtils.SetParameter(ordNo, String.Empty, String.Empty, String.Empty, String.Empty);
                    if (COM.MainUtils.CheckOrders("3"))
                    {
                        COM.MainUtils.OpenTab("SOD", "SOD_Delivery", true);
                    }
                    else COM.MainUtils.OpenTab("SOD", "SOD_Delivery");
                    COM.MainUtils.ResetParameter();

                    _barcode = "";
                    return false;
                }
                // Product Code
                else
                {

                    //XtraMessageBox.Show(_barcode);
                    // Process [ickup a products
                    if (pickStatus == "done" || pickStatus == "cancel")
                    {
                        //XtraMessageBox.Show("Pickup is already done or cancel.", "Warning");
                        XtraMessageBox.Show("Đơn hàng này đã sẵn sàng giao hàng hoặc đã bị hủy.", "Thông báo");
                        _barcode = "";
                        return false;
                    }

                    //pick_no = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "pick_no").ToString();
                    //ord_no = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "ord_no").ToString();

                    bool isProduct = false;
                    int row = 0;
                    string prodcutCode;
                    string productName;
                    int pickQty, ordQty, cancelQty; ;
                    int i = 0;
                    while (!isProduct && i < gridViewPickupDetail.DataRowCount)
                    {
                        prodcutCode = gridViewPickupDetail.GetRowCellValue(i, "prod_cd").ToString();

                        pickQty = int.Parse(gridViewPickupDetail.GetRowCellValue(i, "pick_qty").ToString());
                        ordQty = int.Parse(gridViewPickupDetail.GetRowCellValue(i, "ord_qty").ToString());
                        cancelQty = int.Parse(gridViewPickupDetail.GetRowCellValue(i, "cancel_qty").ToString());

                        if ((prodcutCode == _barcode || prodcutCode.Contains(_barcode)) && (pickQty + cancelQty) < ordQty)
                        {
                            isProduct = true;
                        }
                        row = i;

                        i++;
                    }

                    if (isProduct)
                    {
                        gridViewPickupDetail.FocusedRowHandle = row;
                        productName = gridViewPickupDetail.GetRowCellValue(row, "prod_nm").ToString();

                        cancelQty = int.Parse(gridViewPickupDetail.GetRowCellValue(row, "cancel_qty").ToString());
                        pickQty = int.Parse(gridViewPickupDetail.GetRowCellValue(row, "pick_qty").ToString());
                        if (pickQty == pick_qty && (pickQty + cancelQty) < ord_qty)
                        {
                            pickQty = pickQty + 1;

                            gridViewPickupDetail.SetRowCellValue(row, "pick_qty", pickQty);

                        }
                        else
                        {
                            //XtraMessageBox.Show("The picking of there product was completed", "Warning");
                            XtraMessageBox.Show("Sản phẩm này đã được hoàn thành.", "Thông báo");
                        }

                        gridViewPickupDetail.FocusedRowHandle = row;

                        //XtraMessageBox.Show(productName, "성공");
                    }
                    else
                    {
                        //XtraMessageBox.Show("Wrong product or there product was picked up completely.", "Warning");
                        XtraMessageBox.Show("Sản phẩm không khớp hoặc sản phẩm đã được hoàn thành.", "Thông báo");
                    }
                }

                _barcode = "";
                return false;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        //Cancel product

        private void gridViewPickupDetail_DoubleClick(object sender, System.EventArgs e)
        {
            if (gridViewPickupDetail.FocusedRowHandle < 0) return;

            if (btnCancelProduct.Enabled) CancelProduct();
        }

        private void btnCancelProduct_HbClick(object sender, EventArgs e)
        {
            if (gridViewPickupDetail.FocusedRowHandle < 0) return;
            CancelProduct();
        }

        private void CancelProduct()
        {
            int selectProdRow = gridViewPickupDetail.FocusedRowHandle;
            string ord_no = gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "ord_no").ToString();
            int pickQty, remainQty, cancelQty;

            popCancelProduct popCancelProduct = new popCancelProduct(gridViewPickupDetail, ord_no);
            popCancelProduct.ShowDialog();
            popCancelProduct.Dispose();

            pickQty = popCancelProduct.pick_qty;
            remainQty = popCancelProduct.remain_qty;
            cancelQty = popCancelProduct.cancel_qty;

            // Cancel quantity not change
            if (popCancelProduct.DialogResult != DialogResult.OK || (pickQty == pick_qty && remainQty == remain_qty)) return;

            JsonRequest request = new JsonRequest();
            StringBuilder sql = new StringBuilder();

            ProcAction updatePickDetail = request.NewAction();
            updatePickDetail.proc = WebUtil.Values.PROC_SQL;

            sql.Append("UPDATE " + HBConstant.TB_SO_PICK_DTL);
            sql.Append(" SET pick_qty = #{pick_qty}, remain_qty = #{remain_qty}, cancel_qty = #{cancel_qty}, up_id = #{up_id}, up_dt = CURRENT_TIMESTAMP");
            sql.Append(" WHERE pick_dtl_id = #{pick_dtl_id} AND pick_id = #{pick_id} AND pick_no = #{pick_no}");

            updatePickDetail.text = sql.ToString();
            updatePickDetail.param.Add(STR_PICK_QTY, pickQty);
            updatePickDetail.param.Add(STR_REMAIN_QTY, remainQty);
            updatePickDetail.param.Add("cancel_qty", cancelQty);
            updatePickDetail.param.Add(HBConstant.C_UP_ID, COM.UserInfo.UserID);
            updatePickDetail.param.Add("pick_dtl_id", gridViewPickupDetail.GetRowCellValue(selectProdRow, "pick_dtl_id"));
            updatePickDetail.param.Add("pick_id", gridViewPickupDetail.GetRowCellValue(selectProdRow, "pick_id"));
            updatePickDetail.param.Add("pick_no", gridViewPickupDetail.GetRowCellValue(selectProdRow, "pick_no"));

            // TODO Re-calculation order's price total and price real
            double priceTotal = double.Parse(gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "price_total").ToString());
            double priceReal = double.Parse(gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "price_real").ToString());
            double priceCancel = double.Parse(gridViewPickup.GetRowCellValue(gridViewPickup.FocusedRowHandle, "price_cancel").ToString());
            double prodSalePrice = double.Parse(gridViewPickupDetail.GetRowCellValue(selectProdRow, "unit_sale_price").ToString());

            double newPriceTotal = 0, newPriceReal = 0, newPriceCancel = 0;
            bool priceChange = false;

            if ( cancelQty > cancel_qty)
            {
                int descendProd = cancelQty - cancel_qty;
                double descendPrice = descendProd * prodSalePrice;

                newPriceTotal = priceTotal - descendPrice < 0 ? 0 : priceTotal - descendPrice;
                newPriceReal = priceReal - descendPrice < 0 ? 0 : priceReal - descendPrice;
                newPriceCancel = priceCancel + descendPrice;
                priceChange = true;

            } else if (cancelQty < cancel_qty)
            {
                int ascentProd = cancel_qty - cancelQty;

                double ascentPrice = ascentProd * prodSalePrice;
                newPriceTotal = priceTotal + ascentPrice;
                newPriceReal = priceReal + ascentPrice;
                newPriceCancel = priceCancel - ascentPrice;
                priceChange = true;
            }
            
            //Update order prices
            if (priceChange)
            {
                sql.Clear();
                sql.Append(" UPDATE " + HBConstant.TB_SO_ORDER);
                sql.Append(" SET price_total = #{price_total},");
                sql.Append(" price_real = #{price_real},");
                sql.Append(" price_cancel = #{price_cancel},");
                sql.Append(" up_id = #{up_id},");
                sql.Append(" up_dt = CURRENT_TIMESTAMP");
                sql.Append(" WHERE ord_no = #{ord_no}");

                ProcAction updateOrder = request.NewAction();
                updateOrder.proc = WebUtil.Values.PROC_SQL;
                updateOrder.text = sql.ToString();

                updateOrder.param.Add("price_total", newPriceTotal);
                updateOrder.param.Add("price_real", newPriceReal);
                updateOrder.param.Add("price_cancel", newPriceCancel);
                updateOrder.param.Add(HBConstant.C_UP_ID, COM.UserInfo.UserID);
                updateOrder.param.Add("ord_no", ord_no);
            }

            /*
            ProcAction logAction = request.NewAction();
            logAction.proc = WebUtil.Values.PROC_SQL;
            sql.Clear();
            sql.Append("insert into tb_log_wms(ord_no, log_type, store_cd, pos_no, sale_dt, sale_tm, tran_no, in_dt, in_id) ");
            sql.Append("values(#{ord_no}, #{log_type}, #{store_cd}, #{pos_no}, date_format(current_timestamp, '%Y%m%d'), date_format(current_timestamp, '%H%i%S'), get_next_tran_no2(#{store_cd}, #{pos_no}, null), current_timestamp, #{in_id}) ");
            logAction.text = sql.ToString();
            logAction.param.Add("ord_no", ord_no);
            logAction.param.Add("log_type", "return");
            logAction.param.Add("store_cd", COM.UserInfo.StoreCd);
            logAction.param.Add("pos_no", COM.UserInfo.PosNo);
            logAction.param.Add("in_id", COM.UserInfo.UserID);

            ProcAction selectAction = request.NewAction();
            selectAction.proc = WebUtil.Values.PROC_SQL;
            selectAction.table = "ret";
            sql.Clear();
            sql.Append("select date_format(a.in_dt, '%Y%m%d%H%i%S') open_dt, a.pay_info, a.point_no, a.full_name ");
            sql.Append("from tb_so_order ");
            sql.Append("where a.ord_no = #{ord_no}  ");
            selectAction.text = sql.ToString();
            selectAction.param.Add("ord_no", ord_no);

            ProcAction selectLogAction = request.NewAction();
            selectLogAction.proc = WebUtil.Values.PROC_SQL;
            selectLogAction.table = "log";
            sql.Clear();
            sql.Append("select a.log_id, a.sale_dt, a.sale_tm, a.tran_no ");
            sql.Append("from tb_log_wms a ");
            sql.Append("where a.ord_no = #{ord_no} ");
            sql.Append("  and a.log_type = 'order' ");
            sql.Append("order by a.log_id desc limit 1 ");
            selectLogAction.text = sql.ToString();
            selectLogAction.param.Add("ord_no", ord_no);


            ProcAction itemAction = request.NewAction();
            itemAction.proc = WebUtil.Values.PROC_SQL;
            itemAction.table = "item";
            sql.Clear();
            sql.Append("select a.prod_cd plu_cd, @RANKT := @RANK + 1 item_seq, c.ex_cd item_cd, c.vndr_cd, concat(c.prod_nm, ' / ', c.prod_nm_ko) plu_nm, ");
            sql.Append("	#{cancel_qty} sale_qty, #{cancel_qty} * a.unit_sale_price tot_amt, a.unit_sale_price sale_prc, #{cancel_qty} * a.unit_price tot_unit, a.unit_price ");
            sql.Append("from tb_so_pick_dtl a ");
            sql.Append("	inner join (SELECT @RANK := 0) b ");
            sql.Append("    left join tb_ma_product c on a.prod_cd = c.prod_cd ");
            sql.Append("where pick_dtl_id = #{pick_dtl_id} AND pick_id = #{pick_id} AND pick_no = #{pick_no} ");
            itemAction.text = sql.ToString();
            itemAction.param.Add("pick_dtl_id", gridViewPickupDetail.GetRowCellValue(selectProdRow, "pick_dtl_id"));
            itemAction.param.Add("pick_id", gridViewPickupDetail.GetRowCellValue(selectProdRow, "pick_id"));
            itemAction.param.Add("pick_no", gridViewPickupDetail.GetRowCellValue(selectProdRow, "pick_no"));
            itemAction.param.Add("cancel_qty", cancelQty);
             */

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);
            if (client.check)
            {
                // TODO Recalculate the order's price
                if (priceChange)
                {
                    gridViewPickup.SetRowCellValue(gridViewPickup.FocusedRowHandle, "price_total", newPriceTotal);
                    gridViewPickup.SetRowCellValue(gridViewPickup.FocusedRowHandle, "price_real", newPriceReal);
                    gridViewPickup.SetRowCellValue(gridViewPickup.FocusedRowHandle, "price_cancel", newPriceCancel);
                    gridViewPickup.RefreshData();
                }

                // TODO Message
                //XtraMessageBox.Show("픽업 주문이 업데이트되었습니다.", "성공");
                gridViewPickupDetail.SetRowCellValue(selectProdRow, "cancel_qty", cancelQty);
                gridViewPickupDetail.SetRowCellValue(selectProdRow, "remain_qty", remainQty);
                gridViewPickupDetail.SetRowCellValue(selectProdRow, "pick_qty", pickQty);

                gridViewPickupDetail.FocusedRowHandle = selectProdRow;


                /*
                DataTable dt = ds.Tables["ret"];
                DataTable dtLog = ds.Tables["log"];
                DataTable dtItem = ds.Tables["item"];

                GetAvailPoint(dt, dtLog);
                //double priceTotal = Convert.ToDouble(this.priceTotal);
                //double pricePoint = Convert.ToDouble(this.pricePoint);
                //double priceCard = Convert.ToDouble(this.priceCard);
                //double priceCoupon = Convert.ToDouble(this.priceCoupon);
                //double priceDc = pricePoint + priceCard + priceCoupon;
                //double priceAll = priceTotal - priceDc;

                double priceTotUnit = 0;
                double priceTotSaleUnit = 0;
                for (int i = 0; i < dtItem.Rows.Count; i++)
                {
                    priceTotUnit += Convert.ToDouble(dtItem.Rows[i]["tot_unit"].ToString());
                    priceTotSaleUnit += Convert.ToDouble(dtItem.Rows[i]["tot_amt"].ToString());
                }


                JObject wmsRequest = new JObject();

                JObject irtModel = new JObject();
                wmsRequest.Add("IRT_MODEL", irtModel);

                JObject irtHeader = new JObject();
                irtModel.Add("IRT_HEADER", irtHeader);
                irtHeader.Add("WCC", "Q001");
                irtHeader.Add("SALE_DY", dtLog.Rows[0]["sale_dt"].ToString());
                irtHeader.Add("SITE_CD", COM.UserInfo.StoreCd);
                irtHeader.Add("PROG_NO", COM.UserInfo.PosNo);
                irtHeader.Add("RECEIPT_NO", dtLog.Rows[0]["tran_no"].ToString());
                irtHeader.Add("TRAN_FG", "");
                irtHeader.Add("DES_FG", "Y");
                irtHeader.Add("ORG_LEN", "1000");
                irtHeader.Add("STATUS", "");
                irtHeader.Add("EMP_NO", "");
                irtHeader.Add("SYSTEM", "WMSP");

                JObject tranReq = new JObject();
                irtModel.Add("TRAN_REQ", tranReq);
                tranReq.Add("EJ_DATA", new JArray());
                tranReq.Add("SIGN_DATAS", new JArray());
                tranReq.Add("STORE_CD", COM.UserInfo.StoreCd);
                tranReq.Add("POS_NO", COM.UserInfo.PosNo);
                tranReq.Add("RECEIPT_NO", dtLog.Rows[0]["tran_no"].ToString());
                tranReq.Add("SALE_DY", dtLog.Rows[0]["sale_dt"].ToString());
                tranReq.Add("SALE_TM", dtLog.Rows[0]["sale_tm"].ToString());
                tranReq.Add("REG_EMP_NO", "");


                JObject trData = new JObject();
                trData.Add("TRADE_CALL", new JArray());
                trData.Add("TEMP_OFFER_LIST", new JArray());
                trData.Add("STR_CD", COM.UserInfo.StoreCd);
                trData.Add("SALE_DT", dtLog.Rows[0]["sale_dt"].ToString());
                trData.Add("POS_NO", COM.UserInfo.PosNo);
                trData.Add("SALE_TM", dtLog.Rows[0]["sale_tm"].ToString());
                trData.Add("TRAN_NO", dtLog.Rows[0]["tran_no"].ToString());
                trData.Add("TERMINAL_FG", "01");
                trData.Add("MIX_TRAN_FG", "N");
                trData.Add("TRAN_FG", "2");     //반품
                trData.Add("TRANQ_FG", "0");    //수동반품
                trData.Add("SAVE_FG", "");
                //trData.Add("ORG_DT", dt.Rows[0]["sale_dt"].ToString());
                //trData.Add("ORG_TM", dt.Rows[0]["sale_tm"].ToString());
                //trData.Add("ORG_POS_NO", COM.UserInfo.PosNo);
                //trData.Add("ORG_TRAN_NO", dt.Rows[0]["tran_no"].ToString());
                //trData.Add("ORG_DT", dtLog.Rows[0]["sale_dt"].ToString());
                //trData.Add("ORG_TM", dtLog.Rows[0]["sale_tm"].ToString());
                //trData.Add("ORG_POS_NO", COM.UserInfo.PosNo);
                //trData.Add("ORG_TRAN_NO", dtLog.Rows[0]["tran_no"].ToString());
                trData.Add("ORG_DT", "");
                trData.Add("ORG_TM", "");
                trData.Add("ORG_POS_NO", "");
                trData.Add("ORG_TRAN_NO", "");
                trData.Add("JASA_SUMPAY_FG", "");
                trData.Add("JASA_HALBU_FG", "");
                trData.Add("TASA_SUMPAY_FG", "");
                trData.Add("TASA_HALBU_FG", "");
                trData.Add("CHECK_CARD_FG", "");
                trData.Add("CASH_IC_CARD_FG", "");
                trData.Add("GIFT_FG", "");
                trData.Add("TRAN_TYPE_FG", "10");
                trData.Add("CARD_CD", "");
                trData.Add("FOR_FG", "K");
                trData.Add("OPEN_DT", dt.Rows[0]["open_dt"].ToString());
                trData.Add("CLOSE_DT", dtLog.Rows[0]["sale_dt"].ToString() + dtLog.Rows[0]["sale_tm"].ToString());
                trData.Add("CASHIER_ID", "");
                trData.Add("CASHIER_NAME", COM.UserInfo.UserName);
                trData.Add("WON_AMT", 0.0);
                trData.Add("RESON_CD", "3");   //기타사유
                trData.Add("ORG_CASHIER_ID", "");
                trData.Add("CUST_CD", custCd);
                trData.Add("PGM_VER", "A");
                trData.Add("MST_VER", "A");
                trData.Add("POS_FG", "PS01");
                trData.Add("GIFT_FREE_FG", "");
                trData.Add("TAX_INVOICE_FG", "0");
                trData.Add("PUR_LIMIT", "");
                trData.Add("EMPTY_BOTTLE_SALE", "");
                trData.Add("POS_IP", "");
                trData.Add("EVT_NO", null);
                trData.Add("FOREIGNER_NAME", "");
                trData.Add("UNIONPAY_YN", "");
                trData.Add("SPECIALCARD_YN", "");
                trData.Add("PUBLICSERVANT_YN", "");
                trData.Add("LPAY_FG", false);
                trData.Add("VIC_MEMSALE", "");
                trData.Add("VIC_MEM_CHARGE", "");
                trData.Add("VIC_ONEDAY", "");
                trData.Add("SPECIAL_CARD_SALE", "0");
                trData.Add("LIQUOR_BEER_LITER", 0.0);
                trData.Add("LIQUOR_SOJU_LITER", 0.0);
                trData.Add("LIQUOR_FORIEN_LITER", 0.0);
                trData.Add("LIQUOR_OTH_LITER", 0.0);
                trData.Add("DCC_FG", "");
                trData.Add("CREDT_FG", "");
                trData.Add("EMP_DISCOUNTFG", false);
                trData.Add("USER_PWD", null);
                trData.Add("VIC_SALES", false);
                trData.Add("LawDCCStep", "");
                trData.Add("BioPayFlag", false);
                trData.Add("BioOtcNo", "");
                trData.Add("BioCardNm", "");
                trData.Add("BioFlag", false);
                trData.Add("BioModel", "");
                trData.Add("WCardDcApplyFlag", false);
                trData.Add("OverPayFlag", false);
                trData.Add("SALE_AMT", priceTotUnit);
                trData.Add("DC_AMT", priceTotUnit - priceTotSaleUnit);
                trData.Add("TOT_AMT", priceTotSaleUnit);
                JObject trTranSales = new JObject();
                trData.Add("TR_TRAN_SALES", trTranSales);
                JArray trItemList = new JArray();
                trTranSales.Add("TR_ITEM_LIST", trItemList);


                for (int i = 0; i < dtItem.Rows.Count; i++)
                {
                    double qty = Convert.ToDouble(dtItem.Rows[i]["sale_qty"].ToString());
                    double unitPrice = Convert.ToDouble(dtItem.Rows[i]["unit_price"].ToString());
                    double salePrice = Convert.ToDouble(dtItem.Rows[i]["sale_prc"].ToString());
                    double unitTotal = Convert.ToDouble(dtItem.Rows[i]["tot_unit"].ToString());
                    double saleTotal = Convert.ToDouble(dtItem.Rows[i]["tot_amt"].ToString());

                    JObject item = new JObject();
                    trItemList.Add(item);
                    item.Add("PLU_CD", dtItem.Rows[i]["plu_cd"].ToString());
                    item.Add("ITEM_SEQ", i + 1);
                    item.Add("ITEM_CD", dtItem.Rows[i]["item_cd"].ToString());
                    item.Add("CLASS_CD", "");
                    item.Add("BTL_CD", "");
                    item.Add("WEIGHT_CD", "");
                    item.Add("SALE_QTY", qty);
                    item.Add("TOT_AMT", unitTotal);
                    item.Add("InclusionAddTaxToDiscount", 0.0);
                    item.Add("CURR_SALE_PRC", unitPrice);
                    item.Add("ORG_SALE_PRC", unitPrice);
                    item.Add("NOR_SALE_PRC", unitPrice);
                    item.Add("NEW_PRC_FG", "0");
                    item.Add("ITEM_FG", "0");
                    item.Add("CANCEL_FG", "1");
                    item.Add("PLU_NM", dtItem.Rows[i]["plu_nm"].ToString());
                    item.Add("DC_FG", "02");
                    item.Add("DC_AMT", unitTotal - saleTotal);
                    item.Add("DC_VAL", 0);
                    item.Add("DC_REASON", "");
                    item.Add("ENURI_PER", 0.0);
                    item.Add("ENURI_AMT", 0.0);
                    item.Add("BOTTLE_PRC", 0.0);
                    item.Add("PBOX_PRC", 0.0);
                    item.Add("PBOX_CD", "");
                    item.Add("GREEN_PNT", 0.0);
                    item.Add("VNDR_CD", dtItem.Rows[i]["vndr_cd"].ToString());
                    item.Add("GREEN_PNT2", 0.0);
                    item.Add("SPECIAL_PNT", 0.0);
                    item.Add("FRESH_WEIGHT", 0.0);
                    item.Add("FRESH_QTY", 0.0);
                    item.Add("FRESH_DC_STICKER", "");
                    item.Add("PUBLIC_SERVANT_FLAG", "");
                    item.Add("TAX_FG", "2");
                    item.Add("TR_ITEM_DETAIL", null);
                    item.Add("OfferNmList", new JArray());
                    item.Add("TAX_RT", 0.0);
                    item.Add("GEO_FG", "1");
                    item.Add("RTNRESN_CODE", "");
                    item.Add("OriginalPrice", 0.0);
                    item.Add("TR_ITEM_COUPON", new JArray());
                    item.Add("REMARK", "");
                    item.Add("DESCRIPTION", "");
                    item.Add("SpecialCardNo", "");
                    item.Add("SpecialCardNoMask", "");
                    item.Add("INFANTFG", "");
                    item.Add("ITEMINFO", "");
                    item.Add("ITEM_LOCAL_CHECK", false);
                    item.Add("CalcPrice", salePrice);
                    item.Add("Position", 0);
                    item.Add("LIQUORFG", "000");
                    item.Add("LIQUOR_TOT_QTY", 0.0);
                    item.Add("STATFG", "1");
                    item.Add("DISP_UNIT", "");
                    item.Add("DISPTOTQTY", 0.0);
                    item.Add("DISPBASEQTY", 0.0);
                    item.Add("L3CD", "");
                    item.Add("PURCHASE_CAP_AMT", 0.0);
                    item.Add("EMP_DC_RT", 0.0);
                    item.Add("EMP_DC_EXCT_FG", "");
                    item.Add("PNT_EXCT_FG", "Y");
                    item.Add("DC_CPN_EXCT_FG", "");
                    item.Add("PNT_CPN_EXCT_FG", "");
                    item.Add("RCPT_CAMPAING_EXCT_FG", "");
                    item.Add("MINOR_LIMIT_FG", "");
                    item.Add("PIZZA_PRT_FG", "");
                    item.Add("ITEMFILLER1", dtItem.Rows[i]["plu_cd"].ToString());
                    item.Add("OFFERPLUPRTFG", "");
                    item.Add("OFFER_PLU_PRT_MARK", "");
                    item.Add("DISCOUNT_TYPE", "");
                    item.Add("EXPIRATION_DATE", "");
                    item.Add("PURCHASE_CAP_OVER_FG", false);
                    item.Add("OIL_AMT", 0.0);
                    item.Add("SCALE_FLAG", false);
                    item.Add("GOODS_RATE_CD", "00");
                    item.Add("itemWonAmt", 0.0);
                    item.Add("Subtotal", saleTotal);
                    item.Add("TaxSubtotal", saleTotal);
                    item.Add("GreenPntSum", 0.0);
                    item.Add("GreenSpecialPntSum", 0.0);
                    item.Add("DiscountTotal", unitTotal - saleTotal);
                    item.Add("TAX_AMT", 0);
                    item.Add("LOTTE_CARD_VOUCHER", "");
                    item.Add("POINT_RESERVE_RATE", 1.0);
                    item.Add("SALE_EVENT_DIV", "1");
                    item.Add("SALE_EVENT_NO", "");
                    item.Add("SALE_PRICE", salePrice);
                    item.Add("GROUP_EVENT_DIV", "1");
                    item.Add("GROUP_EVENT_NO", "");
                    item.Add("GROUP_PRICE_CD", "00");
                    item.Add("POINT_APP_AMT", 0.0);
                    item.Add("DEAL_TIME", dtLog.Rows[0]["sale_tm"].ToString());
                    JObject groupCdHash = new JObject();
                    item.Add("groupCdHash", groupCdHash);
                    groupCdHash.Add("00", Convert.ToDouble(dtItem.Rows[i]["tot_amt"].ToString()));
                    groupCdHash.Add("01", Convert.ToDouble(dtItem.Rows[i]["tot_amt"].ToString()));
                    groupCdHash.Add("02", Convert.ToDouble(dtItem.Rows[i]["tot_amt"].ToString()));
                    groupCdHash.Add("03", Convert.ToDouble(dtItem.Rows[i]["tot_amt"].ToString()));
                    groupCdHash.Add("04", Convert.ToDouble(dtItem.Rows[i]["tot_amt"].ToString()));
                    groupCdHash.Add("05", Convert.ToDouble(dtItem.Rows[i]["tot_amt"].ToString()));
                    groupCdHash.Add("06", Convert.ToDouble(dtItem.Rows[i]["tot_amt"].ToString()));
                    groupCdHash.Add("07", Convert.ToDouble(dtItem.Rows[i]["tot_amt"].ToString()));
                    groupCdHash.Add("08", Convert.ToDouble(dtItem.Rows[i]["tot_amt"].ToString()));
                    groupCdHash.Add("09", Convert.ToDouble(dtItem.Rows[i]["tot_amt"].ToString()));
                    item.Add("GOODS_REGI_FG", "0");
                    item.Add("GOODS_REASON_DTL", null);
                    item.Add("Returntotal", saleTotal);
                    item.Add("DATA_STATE", "3");
                }

                JArray trTenderList = new JArray();
                trTranSales.Add("TR_TENDER_LIST", trTenderList);

                int seq = 0;
                if (priceTotSaleUnit > 0)
                {
                    seq++;
                    JObject tender = new JObject();
                    trTenderList.Add(tender);
                    tender.Add("TENDER_SEQ", seq);
                    tender.Add("TRAN_FG", "");
                    tender.Add("GOODS_TRAN_FG", "1");
                    tender.Add("RECEIVE_AMOUNT", priceTotSaleUnit);
                    tender.Add("SUBTOTAL_AMOUNT", priceTotSaleUnit);
                    JArray cashList = new JArray();
                    tender.Add("TR_TENDER_CASH", cashList);
                    tender.Add("TENDER_FG", "CA01");
                    JObject cash = new JObject();
                    cashList.Add(cash);
                    cash.Add("TENDER_SEQ", 1);
                    cash.Add("CASH_FG", "CA01");
                    cash.Add("RCV_AMT", priceTotSaleUnit);
                    cash.Add("PAY_AMT", priceTotSaleUnit);
                    cash.Add("CHG_AMT", 0);
                    tender.Add("TENDER_NM", "");
                }

                JObject trCashReceipt = new JObject();
                trTranSales.Add("TR_CASHRECEIPT", trCashReceipt);
                trCashReceipt.Add("NET_AMT", priceTotSaleUnit);
                trCashReceipt.Add("TAX_AMT", 0.0);
                trCashReceipt.Add("SVC_AMT", 0.0);
                trCashReceipt.Add("TOT_AMT", priceTotSaleUnit);
                trCashReceipt.Add("CASHBILL_FG", "");
                trCashReceipt.Add("APPLY_FG", "");
                trCashReceipt.Add("INPUT_DATA_FG", "");
                trCashReceipt.Add("INPUT_DATA", "");
                trCashReceipt.Add("INPUT_DATA_MASK", "");
                trCashReceipt.Add("INPUT_FG", "01");
                trCashReceipt.Add("APPLY_NO", "");
                trCashReceipt.Add("AUTO_APPLY_FG", "00");
                trCashReceipt.Add("VENDOR_CD", "");
                trCashReceipt.Add("LPOINT_CASHBILL_FG", "0");

                trTranSales.Add("TR_SPECAL_LIST", new JArray());
                trTranSales.Add("TR_OFFER_SAVE", new JArray());
                trTranSales.Add("TR_COUPON_LIST", new JArray());

                JArray custInfoList = new JArray();
                trTranSales.Add("CustInfoList", custInfoList);
                JObject custInfo = new JObject();
                custInfoList.Add(custInfo);
                custInfo.Add("ANS_CD", "");
                custInfo.Add("ANS_DESC", "");
                custInfo.Add("CUST_CD", custCd);
                custInfo.Add("CUST_NM", dt.Rows[0]["full_name"].ToString());
                custInfo.Add("CUST_ABB", dt.Rows[0]["full_name"].ToString());
                custInfo.Add("BUSI_NO", "");    // 모름
                custInfo.Add("CEO_NM", dt.Rows[0]["full_name"].ToString());
                custInfo.Add("GROUP_PRICE_CD", "00");
                custInfo.Add("NATION_DIV", "V");
                custInfo.Add("CUST_ADDR", "");
                custInfo.Add("TEL_NO", "");
                custInfo.Add("CEL_NO", custCd);
                custInfo.Add("POINT_NO", dt.Rows[0]["point_no"].ToString());
                custInfo.Add("ABLE_POINT", availPoint);
                custInfo.Add("RESERVE_RATE", 1.0);
                custInfo.Add("POINT_PWD", "");
                custInfo.Add("CREDIT_TRADE_YN", "N");
                custInfo.Add("LOAN_TRADE_YN", "N");
                custInfo.Add("LOAN_AMT", "0");
                custInfo.Add("MISU_AMT", "0");
                custInfo.Add("DEAL_LIMIT_YN", "N");
                custInfo.Add("DEAL_LIMIT_AMT", "0");
                custInfo.Add("DEAL_AMT", "0");
                custInfo.Add("CUST_SECTOR", "P");
                custInfo.Add("SONATA_CD", "");

                trTranSales.Add("ItemDiscountTotal", 0.0);
                trTranSales.Add("ItemDiscountAmount", 0.0);
                trTranSales.Add("ItemEnuriAmount", 0.0);
                trTranSales.Add("ItemMCouponDiscountAmount", 0.0);
                trTranSales.Add("ItemMCouponDiscountCount", 0);
                trTranSales.Add("InfantAmount", 0.0);
                trTranSales.Add("InfantDiscountAmount", 0.0);
                trTranSales.Add("InfantSavePoint", 0.0);
                trTranSales.Add("GiftAmount", 0.0);
                trTranSales.Add("TenderMCouponCount", 0);
                trTranSales.Add("TenderTotalAmount", priceTotSaleUnit);
                trTranSales.Add("OpenCashDrawer", false);
                trTranSales.Add("GetOfferTotalDiscount", 0);
                trTranSales.Add("GetLPointCpn", new JArray());

                string trInfo = JsonConvert.SerializeObject(trData);
                string utf8String = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(trInfo));
                byte[] bytes = Encoding.UTF8.GetBytes(utf8String);
                string base64 = Convert.ToBase64String(bytes);

                tranReq.Add("TR_DATA", base64);

                COM.WmsSocket socket = new COM.WmsSocket();
                JObject result = socket.Connect(30001, wmsRequest);


                string reqInfo = JsonConvert.SerializeObject(wmsRequest);
                string retInfo = JsonConvert.SerializeObject(result);

                request = new JsonRequest();
                logAction = request.NewAction();
                logAction.proc = WebUtil.Values.PROC_SQL;
                sql.Clear();
                sql.Append("update tb_log_wms set req_info = #{req_info}, tr_info = #{tr_info}, ret_info = #{ret_info} ");
                sql.Append(" WHERE log_id = #{log_id} ");
                logAction.text = sql.ToString();
                logAction.param.Add("log_id", dtLog.Rows[0]["log_id"]);
                logAction.param.Add("req_info", reqInfo);
                logAction.param.Add("tr_info", trInfo);
                logAction.param.Add("ret_info", retInfo);

                client = new WebClient();
                client.Execute(request);
                */

            }
            else
            {
                //XtraMessageBox.Show("픽업 주문 업데이트 실패 : " + client.message, "실패");
                XtraMessageBox.Show("Có lỗi xảy ra: \n" + client.message, "Lỗi");
            }

        }


        private double availPoint = 0.0;
        private string custCd = "";

        private void GetAvailPoint(DataTable dt, DataTable dtLog)
        {
            if (dt.Rows[0]["point_no"] == null || dt.Rows[0]["point_no"] == DBNull.Value || dt.Rows[0]["point_no"].ToString() == "")
            {
                availPoint = 0.0;
                custCd = "99999999";
                return;
            }

            JObject wmsRequest = new JObject();

            JObject irtModel = new JObject();
            wmsRequest.Add("IRT_MODEL", irtModel);

            JObject irtHeader = new JObject();
            irtModel.Add("IRT_HEADER", irtHeader);
            irtHeader.Add("WCC", "T003");
            irtHeader.Add("SALE_DY", dtLog.Rows[0]["sale_dt"].ToString());
            irtHeader.Add("SITE_CD", COM.UserInfo.StoreCd);
            irtHeader.Add("PROG_NO", COM.UserInfo.PosNo);
            irtHeader.Add("RECEIPT_NO", dtLog.Rows[0]["tran_no"].ToString());
            irtHeader.Add("TRAN_FG", "0");
            irtHeader.Add("DES_FG", "Y");
            irtHeader.Add("ORG_LEN", "1000");
            irtHeader.Add("STATUS", "");
            irtHeader.Add("EMP_NO", "");
            irtHeader.Add("SYSTEM", "WMSP");

            JObject custReq = new JObject();
            irtModel.Add("CUST_REQ", custReq);
            custReq.Add("CALL_TYPE", "POINT");
            custReq.Add("SITE_CD", COM.UserInfo.StoreCd);
            custReq.Add("CUST_INFO", dt.Rows[0]["point_no"].ToString());
            custReq.Add("CUST_INFO_LIST", new JArray());

            COM.WmsSocket socket = new COM.WmsSocket();
            JObject result = socket.Connect(30011, wmsRequest);

            JObject resultModel = (JObject)result["IRT_MODEL"];
            JObject resultCustReq = (JObject)resultModel["CUST_REQ"];
            JArray resultCustInfoList = (JArray)resultCustReq["CUST_INFO_LIST"];
            if (resultCustInfoList.Count == 0)
            {
                availPoint = 0.0;
                custCd = "99999999";
                return;
            }
            for (int i = 0; i < resultCustInfoList.Count; i++)
            {
                JObject custInfo = (JObject)resultCustInfoList[i];
                if (custInfo["POINT_NO"].ToString() == dt.Rows[0]["point_no"].ToString())
                {
                    availPoint = Convert.ToDouble(custInfo["ABLE_POINT"].ToString());
                    custCd = custInfo["CUST_CD"].ToString();
                    return;
                }
            }
            availPoint = 0.0;
            custCd = "99999999";
        }

    }
}
