using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using DevExpress.XtraEditors;
using WebUtil;
using HanbiControl;
using SYS;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace SOD
{
    public partial class SOD_Delivery : DevExpress.XtraEditors.XtraUserControl
    {
        //COM.COM_QlightST45 Alarm;

        public string ordNo { get; set; }
        public string pickOrdYn { get; set; }
        public string pickYn { get; set; }
        public string delvOrdYn { get; set; }
        public string delvYn { get; set; }

        public SOD_Delivery()
        {
            InitializeComponent();

            InitGridDelivery();
            InitGridDeliveryDetail();
            InitSearchForm();
            InitSearchDate(COM.MainUtils.searchDate);

            Search();
        }

        public SOD_Delivery(string ord_no)
        {
            this.ordNo = ord_no;
            InitializeComponent();
            InitGridDelivery();
            InitGridDeliveryDetail();
            InitSearchForm();
            InitSearchDate(COM.MainUtils.searchDate);

            Search();
            this.ordNo = String.Empty;
        }

        public SOD_Delivery(string pick_ord_yn, string pick_yn, string delv_ord_yn, string delv_yn)
        {
            this.pickOrdYn = pick_ord_yn;
            this.pickYn = pick_yn;
            this.delvOrdYn = delv_ord_yn;
            this.delvYn = delv_yn;

            InitializeComponent();
            InitGridDelivery();
            InitGridDeliveryDetail();
            InitSearchForm();

            InitFromDoubleClick();
        }

        void InitFromDoubleClick()
        {
            //scPickOrder.Value = pickOrdYn;
            //scPicked.Value = pickYn;
            //scDeliveryOrder.Value = delvOrdYn;
            if (!String.IsNullOrEmpty(delvYn)) scDelivered.Value = delvYn;

            InitSearchDate(COM.MainUtils.searchDate);
            Search();

            this.pickOrdYn = String.Empty;
            this.pickYn = String.Empty;
            this.delvOrdYn = String.Empty;
            this.delvYn = String.Empty;
            this.ordNo = String.Empty;
        }

        void InitFromDoubleClickAndHandle()
        {
            InitFromDoubleClick();
            this.btnDeliveryFinish_HbClick(new object[0], new EventArgs());
        }

        private void InitGridDelivery()
        {
            GridOption gridOption = new GridOption();
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 1, "delv_id", "delv_id", 80, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 2, "delv_no", "delv_no", 120, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 3, "ord_no", "ord_no", 120, GridOption.Align.left);
            gridOption.SetPopupColInfo(false, true, true, true, false, false, -1, "loc_cd", "loc_cd", 100, GridOption.Align.left, "SYS", "popPickupLocation");
            gridOption.SetTextColInfo(false, true, true, true, false, false, 4, "loc_nm", "loc_nm", 150, GridOption.Align.left);

            // Customer Information
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "ord_dt", "ord_dt", 100, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 5, "cust_id", "cust_id", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 6, "full_name", "full_name", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "email", "email", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 8, "mobile_no", "mobile_no", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 9, "tel_no", "tel_no", 100, GridOption.Align.left);

            //Payment and Shipping Infor
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "delv_tp", "delv_tp", 100, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "pay_tp", "pay_tp", 100, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 10, "delv_nm", "delv_nm", 80, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 11, "delv_dt", "delv_dt", 120, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 12, "pay_nm", "pay_nm", 100, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 13, "pay_info", "pay_info", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 14, "ship_post_cd", "ship_post_cd", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 15, "ship_addr", "ship_addr", 300, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 16, "ship_addr_dtl", "ship_addr_dtl", 300, GridOption.Align.left);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 17, "price_total", "price_total", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 18, "price_delv", "price_delv", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 19, "price_dc", "price_dc", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 20, "price_point", "price_point", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 21, "price_card", "price_card", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 22, "price_event_point", "price_event_point", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 23, "price_coupon", "price_coupon", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 24, "price_real", "price_real", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 25, "price_cancel", "price_cancel", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            // Status of Order
            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 26, "delv_yn", "delv_yn", 80, "Y", "N", "N", true);
            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 27, "ret_ord_yn", "ret_ord_yn", 80, "Y", "N", "N", true);
            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 28, "ret_yn", "ret_yn", 80, "Y", "N", "N", true);
            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, -1, "delv_dt", "delv_dt", 120, "Y", "N", "N", true);

            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 29, "stop_yn", "stop_yn", 80, "Y", "N", "N", true);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 30, "stop_reason", "stop_reason", 150, GridOption.Align.left);

            gridOption.Apply(gridViewDelivery);
        }

        private void InitGridDeliveryDetail()
        {
            GridOption gridOption = new GridOption();
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 1, "delv_seq", "delv_seq", 50, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, false, true, true, false, false, -1, "delv_dtl_id", "delv_dtl_id", 50, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "delv_id", "delv_id", 80, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "delv_no", "delv_no", 120, GridOption.Align.left);
            //Product
            gridOption.SetTextColInfo(false, false, true, true, true, false, 2, "prod_cd", "prod_cd", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, false, true, true, false, false, 3, "prod_nm_ko", "prod_nm_ko", 200, GridOption.Align.left);
            gridOption.SetTextColInfo(false, false, true, true, false, false, 4, "prod_nm_en", "prod_nm_en", 200, GridOption.Align.left);
            gridOption.SetTextColInfo(false, false, true, true, false, false, 5, "prod_nm", "prod_nm", 200, GridOption.Align.left);
            gridOption.SetTextColInfo(false, false, true, true, false, false, 6, "unit", "unit", 100, GridOption.Align.center);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 7, "ord_qty", "ord_qty", 100, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 8, "pick_qty", "pick_qty", 100, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 9, "cancel_qty", "cancel_qty", 100, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 10, "unit_price", "unit_price", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 11, "unit_sale_price", "unit_sale_price", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 12, "unit_delv_price", "unit_delv_price", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            gridOption.Apply(gridViewDeliveryDetail);
        }

        private void InitSearchForm()
        {
            scPickupLocation.Text = COM.UserInfo.LocName;

            scDelivered.ProcAction.proc = WebUtil.Values.PROC_SQL;
            scDelivered.ProcAction.text = "SELECT cd value, cd_nm name FROM tb_sys_code WHERE grp_cd = 'ORDER_STATUS' UNION SELECT '' value, '' name ORDER BY value ASC";
            scDelivered.SetDataByProcAction();

            scStopOrder.ProcAction.proc = WebUtil.Values.PROC_SQL;
            scStopOrder.ProcAction.text = "SELECT cd value, cd_nm name FROM tb_sys_code WHERE grp_cd = 'ORDER_STATUS' UNION SELECT '' value, '' name ORDER BY value ASC";
            scStopOrder.SetDataByProcAction();

            DateTime som = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            scStartDate.Value = som.ToString("yyyy-MM-dd");
            scEndDate.Value = som.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

            scShipAddress.Text = String.Empty;
            scFullName.Text = String.Empty;
            scTelNo.Text = String.Empty;
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

        void Research()
        {

            if (gridViewDelivery.FocusedRowHandle > 0)
            {
                this.ordNo = gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "ord_no").ToString();
            }

            Search();
        }

        void Search()
        {
            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT A.delv_id, A.delv_no, A.ord_id, A.ord_no, A.loc_cd,");
            sql.Append(" B.loc_nm, A.cust_id, A.full_name, DATE_FORMAT(A.ord_dt, '%Y-%m-%d %T') ord_dt, A.email, A.mobile_no,");
            sql.Append(" A.tel_no, A.delv_tp, D.delv_nm, DATE_FORMAT(A.delv_dt, '%Y-%m-%d %T') delv_dt, A.pay_tp, C.pay_nm, A.pay_info, A.ship_post_cd,");
            sql.Append(" A.ship_addr, A.ship_addr_dtl, A.price_total, A.price_delv, A.price_point, A.price_card, A.price_real, A.price_event_point, A.price_coupon, A.price_cancel,");
            sql.Append(" (A.price_total + A.price_delv - A.price_real - A.price_point - A.price_card - A.price_event_point - A.price_coupon) AS price_dc,"); //price_dc
            sql.Append(" A.delv_yn, E.ret_ord_yn, E.ret_yn, A.delv_dt, E.stop_yn, E.stop_reason");
            sql.Append(" FROM " + HBConstant.TB_SO_DELV + " A");
            sql.Append(" LEFT JOIN " + HBConstant.TB_MA_PICKUP_LOC + " B ON A.loc_cd = B.loc_cd ");
            sql.Append(" LEFT JOIN (SELECT cd as pay_tp, cd_nm as pay_nm FROM tb_sys_code WHERE grp_cd = 'PAY_TP') C ON A.pay_tp = C.pay_tp ");
            sql.Append(" LEFT JOIN (SELECT cd as delv_tp, cd_nm as delv_nm FROM tb_sys_code WHERE grp_cd = 'DELV_TP') D ON A.delv_tp = D.delv_tp ");

            // Right join with tb_so_order
            sql.Append(" RIGHT JOIN " + HBConstant.TB_SO_ORDER + " E ON A.ord_id = E.ord_id AND A.ord_no = E.ord_no");

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

            // Searching with address
            if(!String.IsNullOrEmpty(scShipAddress.Text))
            {
                sql.Append(" AND (A.ship_addr like concat('%', #{ship_addr}, '%') OR A.ship_addr_dtl like concat('%', #{ship_addr}, '%') )");
                action.param.Add(scShipAddress.FieldName, scShipAddress.Text);
            }

            // Searching with name
            if (!String.IsNullOrEmpty(scFullName.Text))
            {
                sql.Append(" AND A.full_name like concat('%', #{full_name}, '%')");
                action.param.Add(scFullName.FieldName, scFullName.Text);
            }

            // Searching with mobile no or tel no
            if (!String.IsNullOrEmpty(scTelNo.Text))
            {
                sql.Append(" AND (A.mobile_no like concat('%', #{tel_no}, '%') OR A.tel_no like concat('%', #{tel_no}, '%') )");
                action.param.Add(scTelNo.FieldName, scTelNo.Text);
            }

            // Searching with Delivery Status
            if (!String.IsNullOrEmpty(scDelivered.Value.ToString())){
                sql.Append(" AND A.delv_yn = #{delv_yn}");
                action.param.Add(scDelivered.FieldName, scDelivered.Value);
            }

            // Searching with Delivery Status
            if (!String.IsNullOrEmpty(scStopOrder.Value.ToString()))
            {
                sql.Append(" AND E.stop_yn = #{stop_yn}");
                action.param.Add(scStopOrder.FieldName, scStopOrder.Value);
            }

            // TODO Search with date of Order
            if (scStartDate.DateTime <= scEndDate.DateTime)
            {
                sql.Append(" AND (A.in_dt BETWEEN #{start_date} AND #{end_date})");
                action.param.Add(scStartDate.FieldName, scStartDate.DateTime);
                action.param.Add(scEndDate.FieldName, scEndDate.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59));
            }

            sql.Append(" ORDER BY E.stop_yn, A.delv_yn, A.delv_id ASC ");

            action.text = sql.ToString();

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            gridDelivery.DataSource = ds.Tables[0];

            gridViewDelivery.RefreshData();
            if (!String.IsNullOrEmpty(ordNo)) ChoiceOrd();
        }

        private void ChoiceOrd()
        {

            for (int i = 0; i < gridViewDelivery.RowCount; i++)
            {
                if (gridViewDelivery.GetRowCellValue(i, "ord_no").ToString() == this.ordNo)
                {
                    gridViewDelivery.FocusedRowHandle = i;
                    break;
                }
            }

            this.ordNo = String.Empty;
        }

        private void gridViewDelivery_DataSourceChanged(object sender, EventArgs e)
        {
            if (gridViewDelivery.RowCount > 0)
            {
                gridViewDelivery.FocusedRowHandle = 0;
            }
            else
            {
                gridDeliveryDetail.DataSource = null;
            }
        }

        private void gridViewDelivery_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0 || e.FocusedRowHandle >= gridViewDelivery.RowCount) return;
            SearchDeliveryDetail(e.FocusedRowHandle);

            if (gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "delv_yn").ToString() == "N" &&
                gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "stop_yn").ToString() == "N") btnDeliveryFinish.Enabled = true;
            else btnDeliveryFinish.Enabled = false;

            if (gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "delv_yn").ToString() == "Y" &&
                gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "ret_ord_yn").ToString() == "N" &&
                gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "stop_yn").ToString() == "N") btnReturn.Enabled = true;
            else btnReturn.Enabled = false;

            if (!String.IsNullOrEmpty(this.ordNo) &&
                gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "delv_yn").ToString() == "N" &&
                gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "stop_yn").ToString() == "N")
            {
                if (!COM.MainUtils.bolConfirmMessage && 
                    this.ordNo == gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "ord_no").ToString() && 
                    XtraMessageBox.Show("Đơn giao hàng " + gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "delv_no").ToString() + " đã hoàn thành. \nBạn có muốn thực hiện giao hàng cho đơn đặt hàng này không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    btnDeliveryFinish_HbClick(sender, e);
                }
                COM.MainUtils.bolConfirmMessage = true;
            }

        }

        private void gridViewDelivery_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {

            if (gridViewDelivery.RowCount <= 0 || e.RowHandle < 0) return;

            if (gridViewDelivery.GetRowCellValue(e.RowHandle, "delv_yn").ToString() == "N" &&
                gridViewDelivery.GetRowCellValue(e.RowHandle, "stop_yn").ToString() == "N" && e.Appearance.BackColor != Color.LightCoral)
            {
                e.Appearance.BackColor = Color.LightCoral;
            }

            else if (gridViewDelivery.GetRowCellValue(e.RowHandle, "delv_yn").ToString() == "Y" &&
                gridViewDelivery.GetRowCellValue(e.RowHandle, "stop_yn").ToString() == "N" && e.Appearance.BackColor != Color.Gray)
            {
                e.Appearance.BackColor = Color.Gray;

            }

            if (gridViewDelivery.GetRowCellValue(e.RowHandle, "stop_yn").ToString() == "Y" && e.Appearance.BackColor != Color.White)
            {
                e.Appearance.BackColor = Color.White;
                e.Appearance.ForeColor = Color.Red;
            }

            e.HighPriority = true;
        }

        private void gridViewDelivery_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (gridViewDelivery.RowCount <= 0 || e.RowHandle < 0) return;

            if (gridViewDelivery.GetRowCellValue(e.RowHandle, "stop_yn").ToString() == "Y" && e.Appearance.ForeColor != Color.Red)
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }

        private void gridViewDeliveryDetail_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (gridViewDeliveryDetail.RowCount <= 0 || e.RowHandle < 0) return;

            //if (gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "delv_yn").ToString() == "N" && e.Appearance.BackColor != Color.LightCoral)
            //{
            //    e.Appearance.BackColor = Color.LightCoral;
            //}
            //
            //if (gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "delv_yn").ToString() == "Y" && e.Appearance.BackColor != Color.Gray)
            //{
            //    e.Appearance.BackColor = Color.Gray;
            //}

            //else if (gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "stop_yn").ToString() == "Y" && e.Appearance.BackColor != Color.White)
            //{
            //    e.Appearance.BackColor = Color.White;
            //    e.Appearance.ForeColor = Color.Red;
            //}
            e.HighPriority = true;
        }

        private void gridViewDelivery_DoubleClick(object sender, System.EventArgs e)
        {
            if (gridViewDelivery.RowCount <= 0) return;

            string ord_no = gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "ord_no").ToString();
            string ret_ord_yn = gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "ret_ord_yn").ToString();

            if (HBConstant.NO.Equals(ret_ord_yn)) return;

            COM.MainUtils.SetParameter(ord_no, String.Empty, String.Empty, String.Empty, String.Empty);
            COM.MainUtils.OpenTab("SOD", "SOD_Return");
            COM.MainUtils.ResetParameter();
        }

        void SearchDeliveryDetail(int row)
        {
            if (row < 0)
            {
                gridDelivery.DataSource = null;
                return;
            }

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT A.delv_dtl_id, A.delv_id, A.delv_no, A.delv_seq, A.prod_cd,");
            sql.Append(" B.prod_nm_ko, B.prod_nm_en, B.prod_nm, A.unit, A.ord_qty, A.pick_qty, A.cancel_qty, ");
            sql.Append(" A.unit_price, A.unit_sale_price, A.unit_delv_price");
            sql.Append(" FROM " + HBConstant.TB_SO_DELV_DTL + " A ");
            sql.Append(" LEFT JOIN " + HBConstant.TB_MA_PRODUCT + " B ON A.prod_cd = B.prod_cd ");
            sql.Append(" WHERE A.delv_id = #{delv_id}  ");
            sql.Append(" AND A.delv_no = #{delv_no} ");

            action.text = sql.ToString();
            action.param.Add("delv_id", gridViewDelivery.GetRowCellValue(row, "delv_id"));
            action.param.Add("delv_no", gridViewDelivery.GetRowCellValue(row, "delv_no"));

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            gridDeliveryDetail.DataSource = ds.Tables[0];
        }


        void Print()
        {
            if (gridViewDelivery.DataRowCount == 0)
            {
                return;
            }

            COM.PrintFormats.PrintDelivery(gridViewDelivery.GetFocusedRowCellValue("ord_no").ToString());
        }

        private string _barcode = "";
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            char c = (char)keyData;

            if (c == '#' || char.IsNumber(c) || c == (char)Keys.ShiftKey || c == '&')
                _barcode += c;

            if (c == (char)Keys.Return)
            {

                if (_barcode == "")
                {
                    _barcode = "";
                    return base.ProcessCmdKey(ref msg, keyData);
                }
                // Order No
                else if (_barcode.Substring(0, 1) == "#" || (_barcode.Length > 2 && _barcode.Contains(string.Concat((char)Keys.ShiftKey, "3"))))
                {
                    string ordNo = _barcode.Substring(1, _barcode.Length - 1);

                    if (_barcode.Length > 2 && _barcode.Contains(string.Concat((char)Keys.ShiftKey, "3")))
                    {
                        int position = _barcode.IndexOf(string.Concat((char)Keys.ShiftKey, "3"));
                        ordNo = _barcode.Substring(position + 2, _barcode.Length - (2 + position));
                    }

                    // Open Picking screen
                    COM.MainUtils.SetParameter(ordNo, String.Empty, String.Empty, String.Empty, String.Empty);
                    if (COM.MainUtils.CheckOrders("2")) COM.MainUtils.OpenTab("SOD", "SOD_Delivery");
                    else COM.MainUtils.OpenTab("SOD", "SOD_Pickup");
                    COM.MainUtils.ResetParameter();

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

                    // Focus Delivering, what matching with ord_no
                    //int ordRow = 0;
                    //
                    //for (int i = 0; i < gridViewDelivery.RowCount; i++)
                    //{
                    //    if (ordNo == gridViewDelivery.GetRowCellValue(i, "ord_no").ToString())
                    //    {
                    //        ordRow = i;
                    //        gridViewDelivery.FocusedRowHandle = ordRow;
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
                // Product Code
                else
                {
                    //XtraMessageBox.Show("Mã barcode phải là mã của Hóa đơn lấy hàng hoặc hóa đơn giao hàng.", "Thông báo");
                    _barcode = "";
                    return base.ProcessCmdKey(ref msg, keyData);
                }

                _barcode = "";
                return false;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void btnDeliveryFinish_HbClick(object sender, EventArgs e)
        {
            if (gridViewDelivery.RowCount <= 0)
            {
                return;
            }
            if (gridViewDelivery.GetFocusedRowCellValue("delv_yn").ToString() == "Y")
            {
                //MessageBox.Show("Already Finished...");
                MessageBox.Show("Đơn hàng đã giao hàng thành công.", "Thông báo");
                return;
            }

            string ordNo = gridViewDelivery.GetFocusedRowCellValue("ord_no").ToString();
            string payTp = gridViewDelivery.GetFocusedRowCellValue("pay_tp").ToString();

            double priceTotal = Double.Parse(gridViewDelivery.GetFocusedRowCellValue("price_total").ToString());
            double pricePoint = Double.Parse(gridViewDelivery.GetFocusedRowCellValue("price_point").ToString());
            double priceCard = Double.Parse(gridViewDelivery.GetFocusedRowCellValue("price_card").ToString());
            double priceEventPoint = Double.Parse(gridViewDelivery.GetFocusedRowCellValue("price_event_point").ToString()); ;
            double priceCoupon = Double.Parse(gridViewDelivery.GetFocusedRowCellValue("price_coupon").ToString()); ;
            
            double priceDelv = Double.Parse(gridViewDelivery.GetFocusedRowCellValue("price_delv").ToString());
            double priceReal = Double.Parse(gridViewDelivery.GetFocusedRowCellValue("price_real").ToString());
            double priceAll = priceReal - priceDelv;

            popDeliveryFinish dialog = new popDeliveryFinish(gridViewDelivery, ordNo, payTp, priceTotal, pricePoint, priceCard, priceEventPoint, priceCoupon, priceAll, priceDelv, priceReal);
            dialog.ShowDialog();

            if (gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "delv_yn").ToString() == "N" &&
                gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "stop_yn").ToString() == "N") btnDeliveryFinish.Enabled = true;
            else btnDeliveryFinish.Enabled = false;

            if (gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "delv_yn").ToString() == "Y" &&
                gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "ret_ord_yn").ToString() == "N" &&
                gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "stop_yn").ToString() == "N") btnReturn.Enabled = true;
            else btnReturn.Enabled = false;

        }

        private void btnReturn_HbClick(object sender, System.EventArgs e)
        {
            if (gridViewDelivery.RowCount <= 0 || gridViewDelivery.FocusedRowHandle < 0) return;

            if (gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "delv_yn").ToString() == "N" ||
                gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "ret_yn").ToString() == "Y" ||
                gridViewDelivery.GetRowCellValue(gridViewDelivery.FocusedRowHandle, "stop_yn").ToString() == "Y")
            {
                //XtraMessageBox.Show("Cannot make return because Delivery was not deliverd.", "Error");
                XtraMessageBox.Show("Không thể trả hàng vì đơn giao hàng chưa được giao hoặc đã trả hàng.", "Lỗi");
                return;
            }

            if (XtraMessageBox.Show("Bạn có thực sự muốn trả hàng cho đơn hàng này không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            int selDelvRow = gridViewDelivery.FocusedRowHandle;
            string retNo = getNextReturnNo();

            if (String.IsNullOrEmpty(retNo)) return;

            JsonRequest request = new JsonRequest();
            StringBuilder sql = new StringBuilder();

            // Update Order
            ProcAction updateOrder = request.NewAction();
            updateOrder.proc = WebUtil.Values.PROC_SQL;

            sql.Append("UPDATE " + HBConstant.TB_SO_ORDER);
            sql.Append(" SET ret_ord_yn = #{ret_ord_yn}, up_id = #{up_id}, up_dt = CURRENT_TIMESTAMP");
            sql.Append(" WHERE ord_id = #{ord_id} AND ord_no = #{ord_no}");

            updateOrder.text = sql.ToString();
            updateOrder.param.Add("ret_ord_yn", "Y");
            updateOrder.param.Add(HBConstant.C_UP_ID, COM.UserInfo.UserID);
            updateOrder.param.Add("ord_id", gridViewDelivery.GetRowCellValue(selDelvRow, "ord_id"));
            updateOrder.param.Add("ord_no", gridViewDelivery.GetRowCellValue(selDelvRow, "ord_no"));

            // Create Delivery
            ProcAction insertReturn = request.NewAction();
            insertReturn.proc = WebUtil.Values.PROC_SQL;

            sql.Clear();
            sql.Append("INSERT INTO " + HBConstant.TB_SO_RETURN);
            sql.Append(" (ret_id, ret_no, ord_id, ord_no, loc_cd,");
            sql.Append(" cust_id, full_name, mobile_no, tel_no, delv_tp,");
            sql.Append(" pay_tp, pay_info, ship_addr, ship_addr_dtl, ord_dt, delv_dt,");
            sql.Append(" ret_yn, ret_tp, ret_dt, in_id, in_dt)");

            sql.Append(" SELECT ord_id, #{ret_no}, ord_id, ord_no, loc_cd,");
            sql.Append(" cust_id, full_name, mobile_no, tel_no, delv_tp,");
            sql.Append(" pay_tp, pay_info, ship_addr, ship_addr_dtl, ord_dt, delv_dt,");
            sql.Append(" #{ret_yn}, #{ret_tp}, CURRENT_TIMESTAMP, #{in_id}, CURRENT_TIMESTAMP");
            sql.Append(" FROM " + HBConstant.TB_SO_DELV);
            sql.Append(" WHERE ord_no = #{ord_no} AND delv_no = #{delv_no}");

            insertReturn.text = sql.ToString();
            insertReturn.param.Add("ret_no", retNo);                                                                // ret_no
            insertReturn.param.Add("ret_yn", "N");                                                                  // ret_yn
            insertReturn.param.Add("ret_tp", "part");                                                               // ret_tp
            insertReturn.param.Add(HBConstant.C_IN_ID, COM.UserInfo.UserID);                                        // in_id
            insertReturn.param.Add("ord_no", gridViewDelivery.GetRowCellValue(selDelvRow, "ord_no"));              // ord_no
            insertReturn.param.Add("delv_no", gridViewDelivery.GetRowCellValue(selDelvRow, "delv_no"));            // delv_no

            // Create Delivery detail
            ProcAction insertReturnDtl = request.NewAction();
            insertReturnDtl.proc = WebUtil.Values.PROC_SQL;

            sql.Clear();
            sql.Append("INSERT INTO " + HBConstant.TB_SO_RETURN_DTL);
            sql.Append(" (ret_id, ret_no, ret_seq, ord_dtl_id, ord_id,");
            sql.Append(" ord_no, ord_seq, loc_cd, prod_cd, prod_nm,");
            sql.Append(" unit, ord_qty, pick_qty, ret_qty, remain_qty, cancel_qty, unit_price,");
            sql.Append(" unit_sale_price, unit_delv_price, in_id, in_dt)");

            sql.Append(" SELECT ord_id, #{ret_no}, delv_seq, ord_dtl_id, ord_id,");
            sql.Append(" ord_no, ord_seq, loc_cd, prod_cd, prod_nm,");
            sql.Append(" unit, ord_qty, pick_qty, #{ret_qty}, ord_qty, cancel_qty, unit_price,");
            sql.Append(" unit_sale_price, unit_delv_price, #{in_id}, CURRENT_TIMESTAMP");
            sql.Append(" FROM " + HBConstant.TB_SO_DELV_DTL);
            sql.Append(" WHERE ord_no = #{ord_no} AND delv_no = #{delv_no} ");

            insertReturnDtl.text = sql.ToString();
            insertReturnDtl.param.Add("ret_no", retNo);                                                                // ret_no
            insertReturnDtl.param.Add("ret_qty", "0");                                                                 // ret_yn
            insertReturnDtl.param.Add(HBConstant.C_IN_ID, COM.UserInfo.UserID);                                        // in_id
            insertReturnDtl.param.Add("ord_no", gridViewDelivery.GetRowCellValue(selDelvRow, "ord_no"));               // ord_no
            insertReturnDtl.param.Add("delv_no", gridViewDelivery.GetRowCellValue(selDelvRow, "delv_no"));             // delv_no

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (client.check)
            {
                //XtraMessageBox.Show("피킹 성공.", "성공");
                //Search();
                gridViewDelivery.SetRowCellValue(selDelvRow, "ret_ord_yn", "Y");
                gridViewDelivery.RefreshData();
                gridViewDeliveryDetail.RefreshData();
                gridViewDelivery.FocusedRowHandle = selDelvRow;
                XtraMessageBox.Show("Sẵn sàng trả hàng.", "Thông báo");

                btnReturn.Enabled = false;

                // Print Return receipt
                //COM.PrintFormats.PrintDelivery(gridViewPickup.GetRowCellValue(selPickRow, "ord_no").ToString());

                // Open Return screen
                COM.MainUtils.SetParameter(gridViewDelivery.GetRowCellValue(selDelvRow, "ord_no").ToString(), String.Empty, String.Empty, String.Empty, String.Empty);
                COM.MainUtils.OpenTab("SOD", "SOD_Return");
                COM.MainUtils.ResetParameter();

            }
            else
            {
                //XtraMessageBox.Show("피킹에 실패: " + client.message, "실패");
                XtraMessageBox.Show("Có lỗi xảy ra: \n" + client.message, "Lỗi");
            }
        }

        private string getNextReturnNo()
        {
            string retNo = String.Empty;

            JsonRequest request = new JsonRequest();
            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            action.text = " SELECT get_next_no(#{p_prefix}, #{p_no_dt}) AS ret_no";
            action.param.Add("p_prefix", HBConstant.F_RETURN_NO_PREFIX);
            action.param.Add("p_no_dt", DateTime.Now.ToString("yyyyMMdd"));

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                retNo = ds.Tables[0].Rows[0]["ret_no"].ToString();
            }

            return retNo;
        }

    }
}
