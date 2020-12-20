using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebUtil;
using HanbiControl;
using SYS;

namespace SOD
{
    public partial class SOD_Order : DevExpress.XtraEditors.XtraUserControl
    {

        string pickOrder, pickedUp, stopOrder;         // Pickup flag

        //COM.COM_HanNux Alarm;

        public string ordNo {get; set;}
        public string pickOrdYn {get; set;}
        public string pickYn {get; set;}
        public string delvOrdYn { get; set; }
        public string delvYn { get; set; }

        public SOD_Order()
        {
            InitializeComponent();

            InitGridOrder();
            InitGridOrderDetail();
            InitSearchForm();
            InitSearchDate(COM.MainUtils.searchDate);

            Search();

        }

        public SOD_Order(string ord_no)
        {
            this.ordNo = ord_no;
            InitializeComponent();

            InitGridOrder();
            InitGridOrderDetail();
            InitSearchForm();
            InitSearchDate(COM.MainUtils.searchDate);

            Search();

            this.ordNo = String.Empty;
        }

        public SOD_Order(string pick_ord_yn, string pick_yn, string delv_ord_yn, string delv_yn)
        {
            this.pickOrdYn = pick_ord_yn;
            this.pickYn = pick_yn;
            this.delvOrdYn = delv_ord_yn;
            this.delvYn = delv_yn;

            InitializeComponent();

            InitGridOrder();
            InitGridOrderDetail();
            InitSearchForm();

            InitFromDoubleClick();
        }

        void InitFromDoubleClick()
        {
            scPickOrder.Value = pickOrdYn != null? pickOrdYn: String.Empty;
            scPicked.Value = pickYn != null ? pickYn : String.Empty;
            scDeliveryOrder.Value = delvOrdYn != null ? delvOrdYn : String.Empty;
            scDelivered.Value = delvYn != null ? delvYn : String.Empty;

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

            if (gridViewOrder.FocusedRowHandle > 0)
            {
                this.ordNo = gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, "ord_no").ToString();
            }
            Search();
        }

        private void InitGridOrder()
        {
            GridOption gridOption = new GridOption();
            gridOption.SetTextColInfo(false, true, true, true, true, false, 1, "ord_no", "ord_no", 120, GridOption.Align.left);
            gridOption.SetPopupColInfo(false, true, true, true, false, false, -1, "loc_cd", "loc_cd", 100, GridOption.Align.left, "SYS", "popPickupLocation");
            gridOption.SetTextColInfo(false, true, true, true, false, false, 2, "loc_nm", "loc_nm", 150, GridOption.Align.left);

            // Customer Information
            gridOption.SetTextColInfo(false, true, true, true, true, false, 3, "cust_id", "cust_id", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 4, "full_name", "full_name", 250, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 5, "email", "email", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 6, "mobile_no", "mobile_no", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 7, "tel_no", "tel_no", 100, GridOption.Align.left);

            //Payment and Shipping Infor
            gridOption.SetTextColInfo(false, true, true, true, false, false, 8, "ord_dt", "ord_dt", 120, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 9, "delv_dt", "delv_dt", 120, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "delv_tp", "delv_tp", 50, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 10, "delv_nm", "delv_nm", 120, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "pay_tp", "pay_tp", 100, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 11, "pay_nm", "pay_nm", 100, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 12, "pay_info", "pay_info", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 13, "ship_post_cd", "ship_post_cd", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 14, "ship_addr", "ship_addr", 300, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 15, "ship_addr_dtl", "ship_addr_dtl", 300, GridOption.Align.left);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 16, "price_total", "price_total", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 17, "price_delv", "price_delv", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 18, "price_dc", "price_dc", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 19, "price_point", "price_point", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 20, "price_card", "price_card", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 21, "price_event_point", "price_event_point", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 22, "price_coupon", "price_coupon", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 23, "price_real", "price_real", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 24, "price_cancel", "price_cancel", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            // Status of Order
            //gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 21, "alarm_yn", "alarm_yn", 80, "Y", "N", "N", true);
            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 25, "pick_ord_yn", "pick_ord_yn", 80, "Y", "N", "N", true);
            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 26, "pick_yn", "pick_yn", 80, "Y", "N", "N", true);
            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 27, "delv_ord_yn", "delv_ord_yn", 100, "Y", "N", "N", true);
            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 28, "delv_yn", "delv_yn", 80, "Y", "N", "N", true);
            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 29, "stop_yn", "stop_yn", 80, "Y", "N", "N", true);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 30, "stop_reason", "stop_reason", 200, GridOption.Align.left);

            gridOption.Apply(gridViewOrder);
        }

        private void InitGridOrderDetail()
        {
            GridOption gridOption = new GridOption();
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 1, "ord_seq", "ord_seq", 50, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, false, true, true, false, false, -1, "ord_dtl_id", "ord_dtl_id", 50, GridOption.Align.center, 0, true, GridOption.SumType.sum);

            //Product
            gridOption.SetTextColInfo(false, false, true, true, true, false, 2, "prod_cd", "prod_cd", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, false, true, true, false, false, 3, "prod_nm_ko", "prod_nm_ko", 200, GridOption.Align.left);
            //gridOption.SetTextColInfo(false, false, true, true, false, false, 4, "prod_nm_en", "prod_nm_en", 200, GridOption.Align.left);
            gridOption.SetTextColInfo(false, false, true, true, false, false, 5, "prod_nm", "prod_nm", 200, GridOption.Align.left);
            //gridOption.SetTextColInfo(false, false, true, true, false, false, 6, "unit", "unit", 100, GridOption.Align.center);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 7, "ord_qty", "ord_qty", 100, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 8, "unit_price", "unit_price", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 9, "unit_sale_price", "unit_sale_price", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 10, "unit_delv_price", "unit_delv_price", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            gridOption.Apply(gridViewOrderDetail);
        }

        private void InitSearchForm()
        {
            scLocation.Text = COM.UserInfo.LocName;

            scPay.ProcAction.proc = WebUtil.Values.PROC_SQL;
            scPay.ProcAction.text = "SELECT cd value, cd_nm name FROM tb_sys_code WHERE grp_cd = 'PAY_TP' UNION SELECT '' value, '' name ORDER BY value ASC";
            scPay.SetDataByProcAction();

            scPickOrder.ProcAction.proc = WebUtil.Values.PROC_SQL;
            scPickOrder.ProcAction.text = "SELECT cd value, cd_nm name FROM tb_sys_code WHERE grp_cd = 'ORDER_STATUS' UNION SELECT '' value, '' name ORDER BY value ASC";
            scPickOrder.SetDataByProcAction();

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

            btnPickOrder.Enabled = false;
            btnStop.Enabled = false;
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

        void Search()
        {

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT A.ord_id, A.ord_no, A.loc_cd, B.loc_nm, A.cust_id,");
            sql.Append(" A.full_name, A.email, A.mobile_no, A.tel_no, DATE_FORMAT(A.ord_dt, '%Y-%m-%d %T') ord_dt, A.delv_tp, D.delv_nm, DATE_FORMAT(A.delv_dt, '%Y-%m-%d %T') delv_dt, A.pay_tp, C.pay_nm,");
            sql.Append(" A.pay_info, A.ship_post_cd, A.ship_addr, A.ship_addr_dtl, A.price_total,");
            sql.Append(" A.price_delv, A.price_point, A.price_card, A.price_real, A.price_event_point, A.price_coupon, A.price_cancel,");
            sql.Append(" (A.price_total + A.price_delv - A.price_real - A.price_point - A.price_card - A.price_event_point - A.price_coupon) AS price_dc,");    // price_dc
            sql.Append(" A.alarm_yn, A.pick_ord_yn, A.pick_yn,");
            sql.Append(" A.delv_ord_yn, A.delv_yn, A.stop_yn, A.stop_reason");
            sql.Append(" FROM " + HBConstant.TB_SO_ORDER + " A LEFT JOIN " + HBConstant.TB_MA_PICKUP_LOC + " B ON A.loc_cd = B.loc_cd ");
            sql.Append(" LEFT JOIN (SELECT cd as pay_tp, cd_nm as pay_nm FROM tb_sys_code WHERE grp_cd = 'PAY_TP') C ON A.pay_tp = C.pay_tp ");
            sql.Append(" LEFT JOIN (SELECT cd as delv_tp, cd_nm as delv_nm FROM tb_sys_code WHERE grp_cd = 'DELV_TP') D ON A.delv_tp = D.delv_tp ");

            // Searching with Location
            if (COM.UserInfo.LocName == scLocation.Text)
            {
                sql.Append(" WHERE A.loc_cd = #{loc_cd}");
                action.param.Add("loc_cd", COM.UserInfo.LocCode);
            }
            else if (!String.IsNullOrEmpty(scLocation.Text))
            {
                sql.Append(" WHERE B.loc_nm like concat('%', #{loc_nm}, '%')");
                action.param.Add(scLocation.FieldName, scLocation.Text);
            }
            else
            {
                sql.Append(" WHERE B.loc_nm like concat('%', #{loc_nm}, '%')");
                action.param.Add(scLocation.FieldName, scLocation.Text);
            }

            // Searching with mobile no or tel no
            if (!String.IsNullOrEmpty(scTelNo.Text))
            {
                sql.Append(" AND (A.mobile_no like concat('%', #{tel_no}, '%') OR A.tel_no like concat('%', #{tel_no}, '%') )");
                action.param.Add(scTelNo.FieldName, scTelNo.Text);
            }

            // Searching with Payment
            if (!String.IsNullOrEmpty(scPay.Value.ToString()))
            {
                sql.Append(" AND C.pay_tp = #{pay_tp}");
                action.param.Add(scPay.FieldName, scPay.Value);
            }

            // Searching with Alarm, Pickup, Picked up, Delivery, Delivered or Cancel
            //sql.Append(" AND (A.alarm_yn IS NULL OR A.alarm_yn = #{alarm_yn}) ");
            //action.param.Add(scAlarm.FieldName, scAlarm.Value);

            if (!String.IsNullOrEmpty(scPickOrder.Value.ToString()))
            {
                sql.Append(" AND (A.pick_ord_yn IS NULL OR A.pick_ord_yn = #{pick_ord_yn})");
                action.param.Add(scPickOrder.FieldName, scPickOrder.Value);
            }

            if (!String.IsNullOrEmpty(scPicked.Value.ToString()))
            {
                sql.Append(" AND (A.pick_yn IS NULL OR A.pick_yn = #{pick_yn})");
                action.param.Add(scPicked.FieldName, scPicked.Value);
            }

            if (!String.IsNullOrEmpty(scDeliveryOrder.Value.ToString()))
            {
                sql.Append(" AND (A.delv_ord_yn IS NULL OR A.delv_ord_yn = #{delv_ord_yn})");
                action.param.Add(scDeliveryOrder.FieldName, scDeliveryOrder.Value);
            }

            if (!String.IsNullOrEmpty(scDelivered.Value.ToString()))
            {
                sql.Append(" AND (A.delv_yn IS NULL OR A.delv_yn = #{delv_yn})");
                action.param.Add(scDelivered.FieldName, scDelivered.Value);
            }

            if (!String.IsNullOrEmpty(scStopOrder.Value.ToString()))
            {
                sql.Append(" AND (A.stop_yn IS NULL OR A.stop_yn = #{stop_yn})");
                action.param.Add(scStopOrder.FieldName, scStopOrder.Value);
            }

            // TODO Search with date of Order
            if (scStartDate.DateTime <= scEndDate.DateTime)
            {
                sql.Append(" AND (A.in_dt BETWEEN #{start_date} AND #{end_date})");
                action.param.Add(scStartDate.FieldName, scStartDate.DateTime);
                action.param.Add(scEndDate.FieldName, scEndDate.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59));
            }

            sql.Append(" ORDER BY A.stop_yn, A.pick_ord_yn, A.pick_yn, A.delv_ord_yn, A.delv_yn, A.ord_id ASC ");

            action.text = sql.ToString();

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            gridOrder.DataSource = ds.Tables[0];

            gridViewOrder.RefreshData();
            if (!String.IsNullOrEmpty(ordNo)) InitOrd();
        }

        private void InitOrd()
        {
            bool bolFoundOrd = false;
            int rowFound = 0;

            for (int i = 0; i < gridViewOrder.RowCount; i++)
            {
                if (gridViewOrder.GetRowCellValue(i, "ord_no").ToString() == this.ordNo)
                {
                    bolFoundOrd = true;
                    rowFound = i;
                    break;
                }
            }

            if (bolFoundOrd)
            {
                gridViewOrder.FocusedRowHandle = rowFound;
            }

            this.ordNo = String.Empty;
        }

        private void gridViewOrder_DataSourceChanged(object sender, EventArgs e)
        {
            if (gridViewOrder.RowCount > 0)
            {
                gridViewOrder.FocusedRowHandle = 0;

                pickOrder = gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, scPickOrder.FieldName).ToString();
                pickedUp = gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, scPicked.FieldName).ToString();
                stopOrder = gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, scStopOrder.FieldName).ToString();

                if (HBConstant.NO.Equals(pickOrder) && HBConstant.NO.Equals(pickedUp) && HBConstant.NO.Equals(stopOrder))
                {
                    btnPickOrder.Enabled = true;
                }
                else btnPickOrder.Enabled = false;

                if (HBConstant.NO.Equals(stopOrder) && HBConstant.NO.Equals(gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, scDeliveryOrder.FieldName).ToString()))
                    btnStop.Enabled = true;
                else btnStop.Enabled = false;
            }
            else
            {
                gridOrderDetail.DataSource = null;
            }
        }

        private void gridViewOrder_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0 || e.FocusedRowHandle >= gridViewOrder.RowCount) return;
            SearchOrderDetail(e.FocusedRowHandle);

            pickOrder = gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, scPickOrder.FieldName).ToString();
            pickedUp = gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, scPicked.FieldName).ToString();
            stopOrder = gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, scStopOrder.FieldName).ToString();

            if (HBConstant.NO.Equals(pickOrder) && HBConstant.NO.Equals(pickedUp) && HBConstant.NO.Equals(stopOrder))
            {
                btnPickOrder.Enabled = true;
            }
            else btnPickOrder.Enabled = false;

            if (HBConstant.NO.Equals(stopOrder) && HBConstant.NO.Equals(gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, scDeliveryOrder.FieldName).ToString()))
                btnStop.Enabled = true;
            else btnStop.Enabled = false;
        }

        private void gridViewOrder_DoubleClick(object sender, System.EventArgs e)
        {
            if (gridViewOrder.RowCount <= 0) return;

            string ord_no = gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, "ord_no").ToString();
            string pick_ord_yn = gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, "pick_ord_yn").ToString();

            if (HBConstant.NO.Equals(pick_ord_yn)) return;

            COM.MainUtils.SetParameter(ord_no, pick_ord_yn, String.Empty, String.Empty, String.Empty);
            COM.MainUtils.OpenTab("SOD", "SOD_Pickup");
            COM.MainUtils.ResetParameter();
        }

        // If Order is finished, change background of row to Gray
        private void gridViewOrder_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (gridViewOrder.RowCount <= 0 || e.RowHandle < 0) return;

            if (gridViewOrder.GetRowCellValue(e.RowHandle, "pick_ord_yn").ToString() == "N" &&
                gridViewOrder.GetRowCellValue(e.RowHandle, "pick_yn").ToString() == "N" &&
                gridViewOrder.GetRowCellValue(e.RowHandle, "delv_ord_yn").ToString() == "N" &&
                gridViewOrder.GetRowCellValue(e.RowHandle, "pick_yn").ToString() == "N" &&
                gridViewOrder.GetRowCellValue(e.RowHandle, "stop_yn").ToString() == "N" && e.Appearance.BackColor != Color.LightGreen)
            {
                e.Appearance.BackColor = Color.LightGreen;
            }
            else if (gridViewOrder.GetRowCellValue(e.RowHandle, "pick_ord_yn").ToString() == "Y" &&
                gridViewOrder.GetRowCellValue(e.RowHandle, "delv_yn").ToString() == "N" &&
                gridViewOrder.GetRowCellValue(e.RowHandle, "stop_yn").ToString() == "N" && e.Appearance.BackColor != Color.LightCoral )
            {
                e.Appearance.BackColor = Color.LightCoral;

            }
            else if (gridViewOrder.GetRowCellValue(e.RowHandle, "delv_ord_yn").ToString() == "Y" &&
               gridViewOrder.GetRowCellValue(e.RowHandle, "delv_yn").ToString() == "Y" &&
               gridViewOrder.GetRowCellValue(e.RowHandle, "stop_yn").ToString() == "N" && e.Appearance.BackColor != Color.Gray )
            {
                e.Appearance.BackColor = Color.Gray;

            }
            else if (gridViewOrder.GetRowCellValue(e.RowHandle, "stop_yn").ToString() == "Y" && e.Appearance.BackColor != Color.White )
            {
                e.Appearance.BackColor = Color.White;
                e.Appearance.ForeColor = Color.Red;
            }
            e.HighPriority = true;
        }

        private void gridViewOrder_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (gridViewOrder.RowCount <= 0 || e.RowHandle < 0) return;

            if (gridViewOrder.GetRowCellValue(e.RowHandle, "stop_yn").ToString() == "Y" && e.Appearance.ForeColor != Color.Red)
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }

        private void gridViewOrderDetail_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (gridViewOrderDetail.RowCount <= 0 || e.RowHandle < 0) return;

            //if (gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, "pick_ord_yn").ToString() == "Y" &&
            //    gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, "pick_yn").ToString() == "Y" &&
            //    gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, "delv_ord_yn").ToString() == "N" &&
            //    gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, "stop_yn").ToString() == "N" && e.Appearance.BackColor != Color.LightGreen)
            //{
            //    e.Appearance.BackColor = Color.LightGreen;
            //}
            //else if (gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, "delv_ord_yn").ToString() == "Y" &&
            //    gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, "delv_yn").ToString() == "N" &&
            //    gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, "stop_yn").ToString() == "N" && e.Appearance.BackColor != Color.LightCoral )
            //{
            //    e.Appearance.BackColor = Color.LightCoral;
            //
            //}
            //else if (gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, "delv_ord_yn").ToString() == "Y" &&
            //   gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, "delv_yn").ToString() == "Y" &&
            //   gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, "stop_yn").ToString() == "N" && e.Appearance.BackColor != Color.Gray )
            //{
            //    e.Appearance.BackColor = Color.Gray;
            //
            //}
            //else if (gridViewOrder.GetRowCellValue(gridViewOrder.FocusedRowHandle, "stop_yn").ToString() == "Y" && e.Appearance.BackColor != Color.White )
            //{
            //    e.Appearance.BackColor = Color.White;
            //    e.Appearance.ForeColor = Color.Red;
            //}
            //e.HighPriority = true;
        }

        void SearchOrderDetail(int row)
        {
            if (row < 0)
            {
                gridOrderDetail.DataSource = null;
                return;
            }

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT A.ord_seq, A.ord_dtl_id, A.prod_cd, B.prod_nm_ko, B.prod_nm_en, ");
            sql.Append(" B.prod_nm, A.unit, A.ord_qty, A.unit_price, ");
            sql.Append(" A.unit_sale_price, A.unit_delv_price");
            sql.Append(" FROM " + HBConstant.TB_SO_ORDER_DTL + " A LEFT JOIN " + HBConstant.TB_MA_PRODUCT + " B");
            sql.Append(" ON A.prod_cd = B.prod_cd ");
            sql.Append(" WHERE A.ord_id = #{ord_id}  ");
            sql.Append(" AND A.ord_no = #{ord_no} ");

            action.text = sql.ToString();
            action.param.Add("ord_id",gridViewOrder.GetRowCellValue(row, "ord_id"));
            action.param.Add("ord_no", gridViewOrder.GetRowCellValue(row, "ord_no"));

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            gridOrderDetail.DataSource = ds.Tables[0];
        }

        // Pick Order Click Event
        private void btnPickOrder_Click(object sender, System.EventArgs e)
        {
            if (gridViewOrder.RowCount <= 0)
            {
                return;
            }

            int row = gridViewOrder.FocusedRowHandle;

            // TODO Condition is not unnecessary
            // Order are request Pickup
            if (HBConstant.NO.Equals((string)gridViewOrder.GetRowCellValue(row, "pick_ord_yn")) && HBConstant.NO.Equals((string)gridViewOrder.GetRowCellValue(row, "pick_yn")))
            {
                JsonRequest request = new JsonRequest();
                StringBuilder sql = new StringBuilder();

                // Update Order
                ProcAction updateOrder = request.NewAction();
                updateOrder.proc = WebUtil.Values.PROC_SQL;

                sql.Append("UPDATE " + HBConstant.TB_SO_ORDER);
                sql.Append(" SET pick_ord_yn = #{pick_ord_yn}, up_id = #{up_id}, up_dt = CURRENT_TIMESTAMP");
                sql.Append(" WHERE ord_id = #{ord_id} AND ord_no = #{ord_no}");

                updateOrder.text = sql.ToString();
                updateOrder.param.Add("pick_ord_yn", "Y");
                updateOrder.param.Add(HBConstant.C_UP_ID, COM.UserInfo.UserID);
                updateOrder.param.Add("ord_id", gridViewOrder.GetRowCellValue(row, "ord_id"));
                updateOrder.param.Add("ord_no", gridViewOrder.GetRowCellValue(row, "ord_no"));

                // Create Pick Order
                sql.Clear();
                string pick_id = gridViewOrder.GetRowCellValue(row, "ord_id").ToString();
                string pick_no = getNextPickNo();

                ProcAction insertPick = request.NewAction();
                insertPick.proc = WebUtil.Values.PROC_SQL;

                sql.Append("INSERT INTO " + HBConstant.TB_SO_PICK);
                sql.Append(" (pick_id, pick_no, ord_id, ord_no, pick_try, loc_cd, pick_sts, in_id, in_dt)");
                sql.Append(" VALUES(#{pick_id}, #{pick_no}, #{ord_id}, #{ord_no}, #{pick_try}, #{loc_cd}, #{pick_sts}, #{in_id}, CURRENT_TIMESTAMP)");

                insertPick.text = sql.ToString();
                insertPick.param.Add("pick_id", pick_id);
                insertPick.param.Add("pick_no", pick_no);
                insertPick.param.Add("ord_id", gridViewOrder.GetRowCellValue(row, "ord_id"));
                insertPick.param.Add("ord_no", gridViewOrder.GetRowCellValue(row, "ord_no"));
                insertPick.param.Add("pick_try", 1);
                insertPick.param.Add("loc_cd", gridViewOrder.GetRowCellValue(row, "loc_cd"));
                insertPick.param.Add("pick_sts", "ready");
                insertPick.param.Add(HBConstant.C_IN_ID, COM.UserInfo.UserID);

                //Create Pick Order Detail
                sql.Clear();
                ProcAction insertPickDtl = request.NewAction();
                insertPickDtl.proc = WebUtil.Values.PROC_SQL;

                sql.Append("INSERT INTO " + HBConstant.TB_SO_PICK_DTL);
                sql.Append(" (pick_id, pick_no, pick_seq, ord_id, ord_no, ord_dtl_id, ord_seq, loc_cd, prod_cd, prod_nm, unit, ord_qty, pick_qty, remain_qty, in_id, in_dt)");
                sql.Append(" VALUES ");
                int orderDtlCount = gridViewOrderDetail.DataRowCount;
                for (int i = 0; i < orderDtlCount ; i++)
                {
                    sql.Append(" (#{pick_id},");
                    sql.Append(" #{pick_no},");
                    sql.Append(" '" + gridViewOrderDetail.GetRowCellValue(i, "ord_seq") + "',");            //pick_seq
                    sql.Append(" #{ord_id},");
                    sql.Append(" #{ord_no},");
                    sql.Append(" '" + gridViewOrderDetail.GetRowCellValue(i, "ord_dtl_id") + "',");         //ord_dtl_id
                    sql.Append(" '" + gridViewOrderDetail.GetRowCellValue(i, "ord_seq") + "',");            //ord_seq
                    sql.Append(" #{loc_cd},");
                    sql.Append(" '" + gridViewOrderDetail.GetRowCellValue(i, "prod_cd") + "',");            //prod_cd
                    sql.Append(" '" + gridViewOrderDetail.GetRowCellValue(i, "prod_nm") + "',");            //prod_nm
                    sql.Append(" '" + gridViewOrderDetail.GetRowCellValue(i, "unit") + "',");               //unit
                    sql.Append(" '" + gridViewOrderDetail.GetRowCellValue(i, "ord_qty") + "',");            //ord_qty
                    sql.Append(" #{pick_qty},");
                    sql.Append(" '" + gridViewOrderDetail.GetRowCellValue(i, "ord_qty") + "',");            //remain_qty
                    sql.Append(" #{in_id}, CURRENT_TIMESTAMP)");

                    if (i < orderDtlCount - 1) sql.Append(",");
                }

                insertPickDtl.text = sql.ToString();
                insertPickDtl.param.Add("pick_id", pick_id);
                insertPickDtl.param.Add("pick_no", pick_no);
                insertPickDtl.param.Add("ord_id", gridViewOrder.GetRowCellValue(row, "ord_id"));
                insertPickDtl.param.Add("ord_no", gridViewOrder.GetRowCellValue(row, "ord_no"));
                insertPickDtl.param.Add("loc_cd", gridViewOrder.GetRowCellValue(row, "loc_cd"));
                insertPickDtl.param.Add("pick_qty", "0");
                insertPickDtl.param.Add(HBConstant.C_IN_ID, COM.UserInfo.UserID);

                /*
                ProcAction logAction = request.NewAction();
                logAction.proc = WebUtil.Values.PROC_SQL;
                sql.Clear();
                sql.Append("insert into tb_log_wms(ord_no, log_type, store_cd, pos_no, sale_dt, sale_tm, tran_no, in_dt, in_id) ");
                sql.Append("values(#{ord_no}, #{log_type}, #{store_cd}, #{pos_no}, date_format(current_timestamp, '%Y%m%d'), date_format(current_timestamp, '%H%i%S'), get_next_tran_no2(#{store_cd}, #{pos_no}, null), current_timestamp, #{in_id}) ");
                logAction.text = sql.ToString();
                logAction.param.Add("ord_no", gridViewOrder.GetRowCellValue(row, "ord_no"));
                logAction.param.Add("log_type", "order");
                logAction.param.Add("store_cd", COM.UserInfo.StoreCd);
                logAction.param.Add("pos_no", COM.UserInfo.PosNo);
                logAction.param.Add("in_id", COM.UserInfo.UserID);

                ProcAction selectAction = request.NewAction();
                selectAction.proc = WebUtil.Values.PROC_SQL;
                selectAction.table = "delv";
                sql.Clear();
                sql.Append("select date_format(a.in_dt, '%Y%m%d%H%i%S') open_dt, a.pay_info, a.point_no, a.full_name, c.purchase_info, e.card_no, ");
                sql.Append("    a.price_total, a.price_delv, a.price_real, a.price_point, a.price_card, a.price_event_point, a.price_coupon ");
                sql.Append("from tb_so_order a ");
                sql.Append("    left join kmarket.product_orders c on a.ord_no = concat(c.id, '') ");
                sql.Append("    left join kmarket.market_card_histories d on c.id = d.order_id ");
                sql.Append("    left join kmarket.market_cards e on d.card_id = e.id ");
                sql.Append("where a.ord_no = #{ord_no}  ");
                selectAction.text = sql.ToString();
                selectAction.param.Add("ord_no", gridViewOrder.GetRowCellValue(row, "ord_no"));

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
                selectLogAction.param.Add("ord_no", gridViewOrder.GetRowCellValue(row, "ord_no"));

                ProcAction itemAction = request.NewAction();
                itemAction.proc = WebUtil.Values.PROC_SQL;
                itemAction.table = "item";
                sql.Clear();
                sql.Append("select a.prod_cd plu_cd, @RANKT := @RANK + 1 item_seq, c.ex_cd item_cd, c.vndr_cd, concat(c.prod_nm, ' / ', c.prod_nm_ko) plu_nm, ");
                sql.Append("	a.ord_qty sale_qty, a.ord_qty * a.unit_sale_price tot_amt, a.unit_sale_price sale_prc, a.ord_qty * a.unit_price tot_unit, a.unit_price ");
                sql.Append("from tb_so_order_dtl a ");
                sql.Append("	inner join (SELECT @RANK := 0) b ");
                sql.Append("    left join tb_ma_product c on a.prod_cd = c.prod_cd ");
                sql.Append("where a.ord_no = #{ord_no} ");
                sql.Append("  and a.ord_qty > 0 ");
                sql.Append("order by a.ord_seq asc ");
                itemAction.text = sql.ToString();
                itemAction.param.Add("ord_no", gridViewOrder.GetRowCellValue(row, "ord_no"));
                 */

                // Update shopping mall order status
                ProcAction updateShoppingMall = request.NewAction();

                if (gridViewOrder.GetRowCellValue(row, "delv_tp").ToString() == "D")
                {
                    updateShoppingMall = HBConstant.UpdateOrder(updateShoppingMall, gridViewOrder.GetRowCellValue(row, "ord_no").ToString(), HBConstant.STS_PICKING_D);
                }
                else if (gridViewOrder.GetRowCellValue(row, "delv_tp").ToString() == "P")
                {
                    updateShoppingMall = HBConstant.UpdateOrder(updateShoppingMall, gridViewOrder.GetRowCellValue(row, "ord_no").ToString(), HBConstant.STS_PICKING_P);
                }

                WebClient client = new WebClient();
                DataSet ds = client.Execute(request);

                if (client.check)
                {
                    //XtraMessageBox.Show("피킹 성공.", "성공");
                    //Search();
                    gridViewOrder.SetRowCellValue(row, "pick_ord_yn", "Y");
                    gridViewOrder.RefreshData();
                    gridViewOrderDetail.RefreshData();
                    gridViewOrder.FocusedRowHandle = row;
                    XtraMessageBox.Show("Tạo đơn lấy hàng thành công.", "Thông báo");
                    btnPickOrder.Enabled = false;













                    /*
                    DataTable dt = ds.Tables["delv"];
                    DataTable dtLog = ds.Tables["log"];
                    DataTable dtItem = ds.Tables["item"];

                    GetAvailPoint(dt, dtLog);
                    double priceTotal = Convert.ToDouble(dt.Rows[0]["price_total"].ToString());
                    double priceReal = Convert.ToDouble(dt.Rows[0]["price_delv"].ToString());
                    double pricePoint = Convert.ToDouble(dt.Rows[0]["price_real"].ToString());
                    double priceEventPoint = Convert.ToDouble(dt.Rows[0]["price_point"].ToString());
                    double priceCard = Convert.ToDouble(dt.Rows[0]["price_card"].ToString());
                    double priceCoupon = Convert.ToDouble(dt.Rows[0]["price_event_point"].ToString());
                    double priceDelv = Convert.ToDouble(dt.Rows[0]["price_coupon"].ToString());
                    double priceEventDc = priceTotal + priceDelv - priceReal - pricePoint - priceCard - priceEventPoint - priceCoupon;


                    double priceTotUnit = 0;
                    double priceTotSaleUnit = 0;
                    for (int i = 0; i < dtItem.Rows.Count; i++)
                    {
                        priceTotUnit += Convert.ToDouble(dtItem.Rows[i]["tot_unit"].ToString());
                        priceTotSaleUnit += Convert.ToDouble(dtItem.Rows[i]["tot_amt"].ToString());
                    }

                    double priceDc = priceTotUnit - priceTotSaleUnit;

                    double priceMain = priceTotSaleUnit + priceDelv - pricePoint - priceEventPoint - priceCard - priceCoupon;

                    string creditInfoJson = null;
                    if (dt.Rows[0]["purchase_info"] != null && dt.Rows[0]["purchase_info"] != DBNull.Value)
                    {
                        creditInfoJson = dt.Rows[0]["purchase_info"].ToString();
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
                    trData.Add("TRAN_FG", "0");
                    trData.Add("TRANQ_FG", "0");
                    trData.Add("SAVE_FG", "");
                    trData.Add("ORG_DT", dtLog.Rows[0]["sale_dt"].ToString());
                    trData.Add("ORG_TM", dtLog.Rows[0]["sale_tm"].ToString());
                    trData.Add("ORG_POS_NO", COM.UserInfo.PosNo);
                    trData.Add("ORG_TRAN_NO", dtLog.Rows[0]["tran_no"].ToString());
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
                    trData.Add("RESON_CD", "");
                    trData.Add("ORG_CASHIER_ID", "A");
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
                    trData.Add("DC_AMT", priceDc);
                    trData.Add("TOT_AMT", priceTotSaleUnit);
                    JObject trTranSales = new JObject();
                    trData.Add("TR_TRAN_SALES", trTranSales);
                    JArray trItemList = new JArray();
                    trTranSales.Add("TR_ITEM_LIST", trItemList);



                    double point = 0;
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
                        item.Add("VNDR_CD", dtItem.Rows[i]["vndr_cd"].ToString());    // 모름
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
                        if (custCd != "99999999" && dt.Rows[0]["point_no"] != null && dt.Rows[0]["point_no"] != DBNull.Value && dt.Rows[0]["point_no"] != "null" && dt.Rows[0]["point_no"].ToString() != "")
                        {
                            double itemPoint = Math.Floor(Convert.ToDouble(dtItem.Rows[i]["tot_amt"].ToString()) / 100);
                            point += itemPoint;
                            item.Add("POINT_APP_AMT", itemPoint);
                        }
                        else
                        {
                            item.Add("POINT_APP_AMT", 0.0);
                        }
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
                        //item.Add("Returntotal", Convert.ToDouble(dtItem.Rows[i]["tot_amt"].ToString()));
                        item.Add("DATA_STATE", "3");
                    }

                    if (priceDelv > 0)
                    {
                        int i = dtItem.Rows.Count;

                        JObject item = new JObject();
                        trItemList.Add(item);
                        item.Add("PLU_CD", "T0000000");
                        item.Add("ITEM_SEQ", i + 1);
                        item.Add("ITEM_CD", "T0000000");
                        item.Add("CLASS_CD", "");
                        item.Add("BTL_CD", "");
                        item.Add("WEIGHT_CD", "");
                        item.Add("SALE_QTY", 1);
                        item.Add("TOT_AMT", priceDelv);
                        item.Add("InclusionAddTaxToDiscount", 0.0);
                        item.Add("CURR_SALE_PRC", priceDelv);
                        item.Add("ORG_SALE_PRC", priceDelv);
                        item.Add("NOR_SALE_PRC", priceDelv);
                        item.Add("NEW_PRC_FG", "0");
                        item.Add("ITEM_FG", "0");
                        item.Add("CANCEL_FG", "1");
                        item.Add("PLU_NM", "배달비");
                        item.Add("DC_FG", "02");
                        item.Add("DC_AMT", 0);
                        item.Add("DC_VAL", 0);
                        item.Add("DC_REASON", "");
                        item.Add("ENURI_PER", 0.0);
                        item.Add("ENURI_AMT", 0.0);
                        item.Add("BOTTLE_PRC", 0.0);
                        item.Add("PBOX_PRC", 0.0);
                        item.Add("PBOX_CD", "");
                        item.Add("GREEN_PNT", 0.0);
                        item.Add("VNDR_CD", "");    // 모름
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
                        item.Add("CalcPrice", priceDelv);
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
                        item.Add("ITEMFILLER1", "T0000000");
                        item.Add("OFFERPLUPRTFG", "");
                        item.Add("OFFER_PLU_PRT_MARK", "");
                        item.Add("DISCOUNT_TYPE", "");
                        item.Add("EXPIRATION_DATE", "");
                        item.Add("PURCHASE_CAP_OVER_FG", false);
                        item.Add("OIL_AMT", 0.0);
                        item.Add("SCALE_FLAG", false);
                        item.Add("GOODS_RATE_CD", "00");
                        item.Add("itemWonAmt", 0.0);
                        item.Add("Subtotal", priceDelv);
                        item.Add("TaxSubtotal", priceDelv);
                        item.Add("GreenPntSum", 0.0);
                        item.Add("GreenSpecialPntSum", 0.0);
                        item.Add("DiscountTotal", 0);
                        item.Add("TAX_AMT", 0);
                        item.Add("LOTTE_CARD_VOUCHER", "");
                        item.Add("POINT_RESERVE_RATE", 1.0);
                        item.Add("SALE_EVENT_DIV", "1");
                        item.Add("SALE_EVENT_NO", "");
                        item.Add("SALE_PRICE", priceDelv);
                        item.Add("GROUP_EVENT_DIV", "1");
                        item.Add("GROUP_EVENT_NO", "");
                        item.Add("GROUP_PRICE_CD", "00");
                        item.Add("POINT_APP_AMT", 0.0);
                        item.Add("DEAL_TIME", dtLog.Rows[0]["sale_tm"].ToString());
                        JObject groupCdHash = new JObject();
                        item.Add("groupCdHash", groupCdHash);
                        groupCdHash.Add("00", priceDelv);
                        groupCdHash.Add("01", priceDelv);
                        groupCdHash.Add("02", priceDelv);
                        groupCdHash.Add("03", priceDelv);
                        groupCdHash.Add("04", priceDelv);
                        groupCdHash.Add("05", priceDelv);
                        groupCdHash.Add("06", priceDelv);
                        groupCdHash.Add("07", priceDelv);
                        groupCdHash.Add("08", priceDelv);
                        groupCdHash.Add("09", priceDelv);
                        item.Add("GOODS_REGI_FG", "0");
                        item.Add("GOODS_REASON_DTL", null);
                        //item.Add("Returntotal", Convert.ToDouble(dtItem.Rows[i]["tot_amt"].ToString()));
                        item.Add("DATA_STATE", "3");
                    }


                    JArray trTenderList = new JArray();
                    trTranSales.Add("TR_TENDER_LIST", trTenderList);

                    int seq = 0;
                    if (priceMain > 0)
                    {
                        if (dt.Rows[0]["pay_info"].ToString() == "COD")
                        {
                            seq++;
                            JObject tender = new JObject();
                            trTenderList.Add(tender);
                            tender.Add("TENDER_SEQ", seq);
                            tender.Add("TRAN_FG", "");
                            tender.Add("GOODS_TRAN_FG", "0");
                            tender.Add("RECEIVE_AMOUNT", priceMain);
                            tender.Add("SUBTOTAL_AMOUNT", priceMain);
                            tender.Add("TENDER_NM", "");
                            tender.Add("TENDER_FG", "CA01");
                            JArray cashList = new JArray();
                            tender.Add("TR_TENDER_CASH", cashList);

                            JObject cash = new JObject();
                            cashList.Add(cash);
                            cash.Add("TENDER_SEQ", seq);
                            cash.Add("CASH_FG", "CA01");
                            cash.Add("RCV_AMT", priceMain);
                            cash.Add("PAY_AMT", priceMain);
                            cash.Add("CHG_AMT", 0);

                        }
                        else
                        {
                            seq++;
                            JObject tender = new JObject();
                            trTenderList.Add(tender);
                            tender.Add("TENDER_SEQ", seq);
                            tender.Add("TRAN_FG", "");
                            tender.Add("GOODS_TRAN_FG", "0");
                            tender.Add("RECEIVE_AMOUNT", priceMain);
                            tender.Add("SUBTOTAL_AMOUNT", priceMain);
                            tender.Add("TENDER_NM", "");
                            tender.Add("TENDER_FG", "01");

                            JArray creditList = new JArray();
                            tender.Add("TR_TENDER_CREDIT", creditList);


                            JObject jo = JObject.Parse(creditInfoJson);

                            string merTrxId = jo["merTrxId"].ToString();
                            string applyNo = merTrxId.Substring(23, merTrxId.Length - 23);


                            JObject credit = new JObject();
                            creditList.Add(credit);
                            credit.Add("TENDER_SEQ", seq);
                            credit.Add("APPLY_FG", "02");
                            credit.Add("APPLY_NO", applyNo);
                            credit.Add("CAI_INFO", "");
                            credit.Add("DC_AMT", 0.0);
                            credit.Add("CREIDT_AMT", priceMain);
                            credit.Add("APPLY_DT", jo["transDt"].ToString());
                            credit.Add("APPLY_TM", jo["transTm"].ToString());
                            credit.Add("TRAN_FG", "1");
                            credit.Add("BANK_NO", "");
                            credit.Add("CMP_CD", "");
                            credit.Add("ISU_COM_NO", "");
                            credit.Add("CARD_COMP_NAME", "기타카드");
                            credit.Add("CARD_TYPE_NAME", "MANUAL");
                            credit.Add("INPUT_FG", "8");    //IC
                            credit.Add("CARD_FG", "");
                            credit.Add("CARD_NO", jo["cardNo"].ToString());
                            credit.Add("CARD_NO_MASK", "");
                            credit.Add("VALID_DATE", "");
                            credit.Add("PSS_NO", "");
                            credit.Add("HALBU_FG", "01");
                            credit.Add("HALBU_MONTH", "00");
                            credit.Add("AFFILIATE_FG", "");
                            credit.Add("VAN_ID", "");
                            credit.Add("UNIQUE_NO", "");
                            credit.Add("NO_SIGN_FG", "1");
                            credit.Add("NO_SIGN_AMT", 9999999999.0);
                            credit.Add("MB_TYPE", "");
                            credit.Add("MC_VM", "");
                            credit.Add("MB_FULLCHIP_DATA", null);
                            credit.Add("INTERSTFREE_FG", "0");
                            credit.Add("CARD_GBN1", "");
                            credit.Add("CARD_GBN2", "");
                            credit.Add("ENTRY_MODE", "");
                            credit.Add("NATION_CD", "");
                            credit.Add("PUBLIC_SERVANT_FG", "");
                            credit.Add("CUST_CARD_ID", "");
                            credit.Add("OTC", "");
                            credit.Add("LPAY_APP_FG", "00");
                            credit.Add("HAND_PAY_FG", "0");
                            credit.Add("TR_TENDER_CREDIT_DIAPERLIST", new JArray());
                        }

                    }
                    if (pricePoint > 0)
                    {
                        seq++;
                        JObject tender = new JObject();
                        trTenderList.Add(tender);
                        tender.Add("TENDER_SEQ", seq);
                        tender.Add("TRAN_FG", "");
                        tender.Add("GOODS_TRAN_FG", "0");
                        tender.Add("RECEIVE_AMOUNT", pricePoint);
                        tender.Add("SUBTOTAL_AMOUNT", pricePoint);
                        JArray cashList = new JArray();
                        tender.Add("TR_TENDER_CASH", cashList);
                        tender.Add("TENDER_FG", "PO01");
                        tender.Add("TENDER_NM", "");
                    }
                    if (priceCard > 0)
                    {
                        seq++;
                        JObject tender = new JObject();
                        trTenderList.Add(tender);
                        tender.Add("TENDER_SEQ", seq);
                        tender.Add("TRAN_FG", "");
                        tender.Add("GOODS_TRAN_FG", "0");
                        tender.Add("RECEIVE_AMOUNT", priceCard);
                        tender.Add("SUBTOTAL_AMOUNT", priceCard);
                        tender.Add("TENDER_FG", "04");
                        tender.Add("TENDER_NM", "");
                        JArray cardList = new JArray();
                        tender.Add("TR_TENDER_GIFT_LIST", cardList);
                        JObject card = new JObject();
                        cardList.Add(card);
                        card.Add("STR_CD", COM.UserInfo.StoreCd);
                        card.Add("SALE_DT", dtLog.Rows[0]["sale_dt"].ToString());
                        card.Add("POS_NO", COM.UserInfo.PosNo);
                        card.Add("TRAN_NO", dtLog.Rows[0]["tran_no"].ToString());
                        card.Add("TENDER_SEQ", seq);
                        card.Add("GIFT_FG", "01");
                        card.Add("TDR_CD", "VO02");
                        card.Add("INPUT_FG", "");
                        card.Add("GIFT_AMT", priceCard);
                        card.Add("CHG_FG", "");
                        card.Add("CHG_AMT", 0.0);
                        card.Add("GIFT_STAT", "");
                        card.Add("GIFT_TYPE_LANG_WORD", "상품권");
                        JObject detail = new JObject();
                        card.Add("TR_TENDER_GIFT_DETAIL", detail);
                        detail.Add("TENDER_SEQ", 1);
                        detail.Add("GIFT_NO", dt.Rows[0]["card_no"].ToString());
                        detail.Add("GIFT_CNT", 1);
                        detail.Add("LOTTE_GIFT_RETRIEVD_YN", "");
                        detail.Add("APPROVE_NO", "");
                        detail.Add("GIFT_AMT", priceCard);
                        detail.Add("GCARD_DIV", "GUSE");

                    }
                    if (priceCoupon > 0)
                    {
                        seq++;
                        JObject tender = new JObject();
                        trTenderList.Add(tender);
                        tender.Add("TENDER_SEQ", seq);
                        tender.Add("TRAN_FG", "");
                        tender.Add("GOODS_TRAN_FG", "0");
                        tender.Add("RECEIVE_AMOUNT", priceCoupon);
                        tender.Add("SUBTOTAL_AMOUNT", priceCoupon);
                        JArray cashList = new JArray();
                        tender.Add("TR_TENDER_CASH", cashList);
                        tender.Add("TENDER_FG", "CP");
                        tender.Add("TENDER_NM", "");
                    }

                    JObject trCashReceipt = new JObject();
                    trTranSales.Add("TR_CASHRECEIPT", trCashReceipt);
                    trCashReceipt.Add("NET_AMT", priceMain);
                    trCashReceipt.Add("TAX_AMT", 0.0);
                    trCashReceipt.Add("SVC_AMT", 0.0);
                    trCashReceipt.Add("TOT_AMT", priceMain);
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

                    if (custCd != "99999999" && dt.Rows[0]["point_no"] != null && dt.Rows[0]["point_no"] != DBNull.Value && dt.Rows[0]["point_no"] != "null" && dt.Rows[0]["point_no"].ToString() != "" && priceMain > 0)
                    {
                        JObject trSavePoint = new JObject();
                        trTranSales.Add("TR_SAVE_POINT", trSavePoint);
                        trSavePoint.Add("HOST_STAT", "");
                        trSavePoint.Add("INPUT_FG", "3");
                        trSavePoint.Add("CARD_NO", dt.Rows[0]["point_no"].ToString());
                        trSavePoint.Add("CARD_NO_MASK", "");    // 모름
                        trSavePoint.Add("CUST_NO", ""); // 모름
                        trSavePoint.Add("CUST_FG", "");
                        trSavePoint.Add("CUST_FG2", "");
                        trSavePoint.Add("PAY_CARD_NO", "");
                        trSavePoint.Add("AFFILATE_NO", "");
                        trSavePoint.Add("PNT_FG", "2");
                        trSavePoint.Add("APPLY_NO", "");
                        trSavePoint.Add("APPLY_DT", dtLog.Rows[0]["sale_dt"].ToString());
                        trSavePoint.Add("APPLY_TM", dtLog.Rows[0]["sale_tm"].ToString());
                        trSavePoint.Add("TOT_AMT", priceMain);
                        trSavePoint.Add("PNT_USE_FG", "0");
                        trSavePoint.Add("TRAN_RESON", "200");
                        trSavePoint.Add("PNT_SAVE_FG", "1");
                        trSavePoint.Add("BF_PNT", availPoint);
                        trSavePoint.Add("SAVE_PNT", point);
                        trSavePoint.Add("TOT_PNT", availPoint + point);
                        trSavePoint.Add("AREMAIN_AMT", availPoint);
                        trSavePoint.Add("PAYABLE_AMT", availPoint);
                        trSavePoint.Add("BAG_PAY_PNT", 0);
                        trSavePoint.Add("DC_AMT", 0);
                        trSavePoint.Add("CASHBILL_AUTO_FG", "");
                        trSavePoint.Add("START_PNT", 0);
                        trSavePoint.Add("BIRTH_PNT", 0);
                        trSavePoint.Add("WED_PNT", 0);
                        trSavePoint.Add("EVT_PNT_PART", 0);
                        trSavePoint.Add("EVT_PNT_OS", 0);
                        trSavePoint.Add("CPN_NO", "");
                        trSavePoint.Add("PNT_SEND_FG", "1");
                        trSavePoint.Add("ORG_APPLY_NO", "");
                        trSavePoint.Add("ORG_APPLY_DT", "");
                        trSavePoint.Add("TRAN_NO", dtLog.Rows[0]["tran_no"].ToString());
                        trSavePoint.Add("CARD_FG", "");
                        trSavePoint.Add("TAXBILL_PRT_FG", "");
                        trSavePoint.Add("CHANGE_PNT", 0.0);
                        trSavePoint.Add("STR_CUST_NO", custCd);
                        trSavePoint.Add("ONLINE_FG", "0");
                        trSavePoint.Add("OFFLINE_FIND_FG", "0");
                        trSavePoint.Add("POINT_SAVEYN_FG", "1");
                        trSavePoint.Add("TYPE", "");
                        trSavePoint.Add("CUST_VALI_FG", "");
                        trSavePoint.Add("CUST_TYP_FG", "");
                        trSavePoint.Add("VIC_GRADE_FG", "");
                        trSavePoint.Add("VIC_GRADE_NM", "");
                        trSavePoint.Add("VALI_ST_DY", "");
                        trSavePoint.Add("VALI_END_DY", "");
                        trSavePoint.Add("VALI_ALERT_FG", "");
                        trSavePoint.Add("VALI_ALERT_MSG", "");
                        trSavePoint.Add("BMAN_NO", "");
                        trSavePoint.Add("BMAN_NM", "");
                        trSavePoint.Add("CEO_NM", "");
                        trSavePoint.Add("BMAN_ADDR", "");
                        trSavePoint.Add("BMAN_CD", "");
                        trSavePoint.Add("BMAN_TY", "");
                        trSavePoint.Add("BMAN_EMAIL", "");
                        trSavePoint.Add("ETAX_FG", "");
                        trSavePoint.Add("PLU_CD", "");
                        trSavePoint.Add("PLU_PRC", priceMain);
                        trSavePoint.Add("FIRST_PNT_FG", "");
                        trSavePoint.Add("BIRTH_PNT_FG", "");
                        trSavePoint.Add("INFANT_FG", "");
                        trSavePoint.Add("ETCFG1", "");
                        trSavePoint.Add("ETCFG2", "");
                        trSavePoint.Add("ETCFG3", "");
                        trSavePoint.Add("ETCMSG1", "");
                        trSavePoint.Add("ETCMSG2", "");
                        trSavePoint.Add("ORG_RCPT", "");
                        trSavePoint.Add("SAVE_AMT", point);
                        trSavePoint.Add("CHAIN_APPRO_NO", "");
                        trSavePoint.Add("CUST_PLU_CD", "0");
                        trSavePoint.Add("RETURN_FG", null);
                        trSavePoint.Add("LPAY_FG", "0");
                        trSavePoint.Add("CUST_NAME", dt.Rows[0]["full_name"].ToString());
                        trSavePoint.Add("LEVEL", "00");
                        trSavePoint.Add("LEVEL_NAME", "00");
                        trSavePoint.Add("MARTINFANT_FG", "");
                        trSavePoint.Add("VIC_CUST_NO", "");
                        trSavePoint.Add("CUST_TYP_NM", "");
                        trSavePoint.Add("CREDIT_TRADE_YN", "N");
                        trSavePoint.Add("LOAN_TRADE_YN", "N");
                        trSavePoint.Add("LOAN_AMT", "0");
                        trSavePoint.Add("MISU_AMT", "0");
                        trSavePoint.Add("DEAL_LIMIT_YN", "N");
                        trSavePoint.Add("DEAL_LIMIT_AMT", "0");
                        trSavePoint.Add("DEAL_AMT", "0");
                        trSavePoint.Add("CUST_SECTOR", "P");
                        trSavePoint.Add("SONATA_CD", "");
                    }

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

















                    COM.PrintFormats.PrintPickOrder(gridViewOrder.GetRowCellValue(row, "ord_no").ToString());

                    //if (COM.UserInfo.LocCode == "0") COM.EmailHelper.SendEmail(gridViewOrder.GetRowCellValue(row, "ord_no").ToString());
                }
                else
                {
                    //XtraMessageBox.Show("피킹에 실패: " + client.message, "실패");
                    XtraMessageBox.Show("Có lỗi xảy ra: \n" + client.message, "Lỗi");
                }

            }
            // TODO Order is stop, update pickup status
            else
            {
                //XtraMessageBox.Show("이 주문은 이미 선택되었습니다.", "성공");
                XtraMessageBox.Show("Đơn hàng này đã được tạo đơn lấy hàng.", "Thông báo");
            }
        }

        private string getNextPickNo()
        {
            string pickNo = String.Empty;

            JsonRequest request = new JsonRequest();
            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            action.text = " SELECT get_next_no(#{p_prefix}, #{p_no_dt}) AS pick_no";
            action.param.Add("p_prefix", HBConstant.F_PICK_NO_PREFIX);
            action.param.Add("p_no_dt", DateTime.Now.ToString("yyyyMMdd"));

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                pickNo = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }

            return pickNo;
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
                    //XtraMessageBox.Show("Mã barcode phải là mã của Hóa đơn lấy hàng hoặc Hóa đơn giao hàng.", "Thông báo");
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

        

        private void btnStop_HbClick(object sender, EventArgs e)
        {
            if (gridViewOrder.RowCount <= 0)
            {
                return;
            }

            int row = gridViewOrder.FocusedRowHandle;
            StringBuilder query = new StringBuilder();

            popCancel cancel = new popCancel(gridViewOrder.GetRowCellValue(row, "ord_no").ToString());
            cancel.ShowDialog();
            cancel.Dispose();

            string stop_reason = String.Empty;

            //if (XtraMessageBox.Show("이 주문을 정말로 취소 하시겠습니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //if (XtraMessageBox.Show("Bạn có thực sự muốn hủy đơn hàng này không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            if (cancel.DialogResult == DialogResult.OK)
            {
                stop_reason = cancel.stop_reason;

                string msg = COM.CommonUtils.cancelPayment(Convert.ToInt32(gridViewOrder.GetRowCellValue(row, "ord_no").ToString()));
                if (msg != null)
                {
                    XtraMessageBox.Show(msg, "Payment Cancel Error");
                    return;
                }

                JsonRequest request = new JsonRequest();

                // Update order stop flag
                ProcAction updateOrder = request.NewAction();
                updateOrder.proc = WebUtil.Values.PROC_SQL;

                query.Append(" UPDATE hanbibase.tb_so_order");
                query.Append(" SET stop_yn = 'Y', ");
                query.Append(" stop_reason = #{stop_reason}, ");
                query.Append(" up_id = #{up_id}, ");
                query.Append(" up_dt = CURRENT_TIMESTAMP ");
                query.Append(" WHERE ord_id = #{ord_id} AND ord_no = #{ord_no} ");

                updateOrder.text = query.ToString();
                updateOrder.param.Add("stop_reason", stop_reason);
                updateOrder.param.Add("up_id", COM.UserInfo.UserID);
                updateOrder.param.Add("ord_id", gridViewOrder.GetRowCellValue(row, "ord_id").ToString());
                updateOrder.param.Add("ord_no", gridViewOrder.GetRowCellValue(row, "ord_no").ToString());

                // Update shopping mall order status
                query.Clear();
                ProcAction updateShoppingMallOrder = request.NewAction();
                updateShoppingMallOrder = HBConstant.UpdateOrder(updateShoppingMallOrder, gridViewOrder.GetRowCellValue(row, "ord_no").ToString(), HBConstant.STS_CANCEL, stop_reason);

                WebClient client = new WebClient();
                DataSet ds = client.Execute(request);

                if (client.check)
                {
                    gridViewOrder.SetRowCellValue(row, "stop_yn", "Y");
                    gridViewOrder.SetRowCellValue(row, "stop_reason", stop_reason);
                    gridViewOrder.RefreshData();

                    XtraMessageBox.Show("Hủy đơn hàng thành công.", "Thông báo");
                    btnStop.Enabled = false;

                }
                else
                {
                    //XtraMessageBox.Show("피킹에 실패: " + client.message, "실패");
                    XtraMessageBox.Show("Có lỗi xảy ra: \n" + client.message, "Lỗi");
                }
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
            irtHeader.Add("WCC", "T002");
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
