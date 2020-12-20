using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HanbiControl;
using WebUtil;
using SYS;

namespace SOD
{
    public partial class SOD_Return : DevExpress.XtraEditors.XtraUserControl
    {

        bool bolCellChanging = false;
        int ord_qty, ret_qty, remain_qty, cancel_qty;
        string ret_yn;

        string ret_no, ord_no;
        private int currentSelected = 0;

        public string ordNo { get; set; }
        public string pickOrdYn { get; set; }
        public string pickYn { get; set; }
        public string delvOrdYn { get; set; }
        public string delvYn { get; set; }

        public SOD_Return()
        {
            InitializeComponent();
            InitGridReturn();
            InitGridReturnDetail();

            InitSearchForm();
            InitSearchDate(COM.MainUtils.searchDate);
            Search();
        }

        public SOD_Return(string ord_no)
        {
            this.ordNo = ord_no;
            InitializeComponent();
            InitGridReturn();
            InitGridReturnDetail();
            InitSearchForm();
            InitSearchDate(COM.MainUtils.searchDate);

            Search();
            this.ordNo = String.Empty;
        }

        void InitFromDoubleClick()
        {
            InitSearchDate(COM.MainUtils.searchDate);
            Search();

            this.ordNo = String.Empty;
        }

        private void InitSearchForm()
        {
            scPickupLocation.Text = COM.UserInfo.LocName;

            scReturnType.ProcAction.proc = WebUtil.Values.PROC_SQL;
            scReturnType.ProcAction.text = "SELECT cd value, cd_nm name FROM tb_sys_code WHERE grp_cd = 'RET_TP' UNION SELECT '' value, '' name ORDER BY value ASC";
            scReturnType.SetDataByProcAction();

            scReturned.ProcAction.proc = WebUtil.Values.PROC_SQL;
            scReturned.ProcAction.text = "SELECT cd value, cd_nm name FROM tb_sys_code WHERE grp_cd = 'ORDER_STATUS' UNION SELECT '' value, '' name ORDER BY value ASC";
            scReturned.SetDataByProcAction();

            DateTime som = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            scStartDate.Value = som.ToString("yyyy-MM-dd");
            scEndDate.Value = som.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
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

        private void InitGridReturn()
        {
            GridOption gridOption = new GridOption();
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 1, "ret_id", "ret_id", 80, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 2, "ret_no", "ret_no", 120, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 3, "ord_no", "ord_no", 120, GridOption.Align.left);
            gridOption.SetPopupColInfo(false, true, true, true, false, false, -1, "loc_cd", "loc_cd", 100, GridOption.Align.left, "SYS", "popPickupLocation");
            gridOption.SetTextColInfo(false, true, true, true, false, false, 4, "loc_nm", "loc_nm", 150, GridOption.Align.left);

            // Customer Information
            gridOption.SetTextColInfo(false, true, true, true, true, false, 5, "cust_id", "cust_id", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 6, "full_name", "full_name", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 7, "mobile_no", "mobile_no", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "tel_no", "tel_no", 100, GridOption.Align.left);

            //Payment and Shipping Infor
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "delv_tp", "delv_tp", 80, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 9, "delv_nm", "delv_nm", 80, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "pay_tp", "pay_tp", 100, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 10, "pay_nm", "pay_nm", 100, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 11, "pay_info", "pay_info", 250, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 12, "ship_addr", "ship_addr", 300, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 13, "ship_addr_dtl", "ship_addr_dtl", 300, GridOption.Align.left);

            gridOption.SetTextColInfo(false, true, true, true, false, false, 14, "ord_dt", "ord_dt", 170, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 15, "delv_dt", "delv_dt", 170, GridOption.Align.left);

            // Price

            //gridOption.SetNumberColInfo(false, true, true, true, false, false, 16, "price_total", "price_total", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            //gridOption.SetNumberColInfo(false, true, true, true, false, false, 17, "price_delv", "price_delv", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            //gridOption.SetNumberColInfo(false, true, true, true, false, false, 18, "price_point", "price_point", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            //gridOption.SetNumberColInfo(false, true, true, true, false, false, 19, "price_card", "price_card", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            //gridOption.SetNumberColInfo(false, true, true, true, false, false, 20, "price_real", "price_real", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            gridOption.SetNumberColInfo(false, true, true, true, false, false, 16, "recv_price_total", "recv_price_total", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            //gridOption.SetNumberColInfo(false, true, true, true, false, false, 17, "recv_price_delv", "recv_price_delv", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 18, "recv_price_real", "recv_price_real", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            //gridOption.SetNumberColInfo(false, true, true, true, false, false, 19, "recv_price_point", "recv_price_point", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            //gridOption.SetNumberColInfo(false, true, true, true, false, false, 20, "recv_price_card", "recv_price_card", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            //gridOption.SetNumberColInfo(false, true, true, true, false, false, 21, "ret_price_event_point", "ret_price_event_point", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            //gridOption.SetNumberColInfo(false, true, true, true, false, false, 22, "recv_price_coupon", "recv_price_coupon", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            //gridOption.SetNumberColInfo(false, true, true, true, false, false, 16, "ret_price_total", "ret_price_total", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            //gridOption.SetNumberColInfo(false, true, true, true, false, false, 17, "ret_price_delv", "ret_price_delv", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            //gridOption.SetNumberColInfo(false, true, true, true, false, false, 18, "ret_price_real", "ret_price_real", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            //gridOption.SetNumberColInfo(false, true, true, true, false, false, 19, "ret_price_point", "ret_price_point", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            //gridOption.SetNumberColInfo(false, true, true, true, false, false, 20, "ret_price_card", "ret_price_card", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            //gridOption.SetNumberColInfo(false, true, true, true, false, false, 21, "ret_price_coupon", "ret_price_coupon", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            // Status of Return
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "ret_tp", "ret_tp", 80, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 23, "ret_tp_nm", "ret_tp_nm", 80, GridOption.Align.center);
            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 24, "ret_yn", "ret_yn", 80, "Y", "N", "N", true);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 25, "ret_dt", "ret_dt", 170, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 26, "ret_reason", "ret_reason", 200, GridOption.Align.left);

            gridOption.Apply(gridViewReturn);
        }

        private void InitGridReturnDetail()
        {
            GridOption gridOption = new GridOption();
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 1, "ret_seq", "ret_seq", 50, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, false, true, true, false, false, -1, "ret_dtl_id", "ret_dtl_id", 50, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "ret_id", "ret_id", 80, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "ret_no", "ret_no", 120, GridOption.Align.left);
            //Product
            gridOption.SetTextColInfo(false, false, true, true, true, false, 2, "prod_cd", "prod_cd", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, false, true, true, false, false, 3, "prod_nm_ko", "prod_nm_ko", 200, GridOption.Align.left);
            //gridOption.SetTextColInfo(false, false, true, true, false, false, 4, "prod_nm_en", "prod_nm_en", 200, GridOption.Align.left);
            gridOption.SetTextColInfo(false, false, true, true, false, false, 5, "prod_nm", "prod_nm", 200, GridOption.Align.left);
            //gridOption.SetTextColInfo(false, false, true, true, false, false, 6, "unit", "unit", 100, GridOption.Align.center);

            gridOption.SetNumberColInfo(false, true, true, true, false, false, 7, "ord_qty", "ord_qty", 100, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 8, "pick_qty", "pick_qty", 100, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, false, true, false, false, 9, "ret_qty", "ret_qty", 100, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 10, "remain_qty", "remain_qty", 100, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 11, "cancel_qty", "cancel_qty", 100, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 12, "unit_price", "unit_price", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 13, "unit_sale_price", "unit_sale_price", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 14, "unit_delv_price", "unit_delv_price", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            gridOption.Apply(gridViewReturnDetail);
        }


        void Search()
        {
            if (!String.IsNullOrEmpty(ret_no))
            {

                //if (XtraMessageBox.Show("주문 번호를 받으려고합니다: " + ret_no + ". 멈추시겠습니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
                if (XtraMessageBox.Show("Đơn hàng: " + ret_no + " đang được xử lý. \nBạn có muốn tìm kiếm lại hay không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    ret_no = String.Empty;
                }
                else
                {
                    gridViewReturn.FocusedRowHandle = currentSelected;
                    return;
                }
            }

            bolCellChanging = false;
            btnRefund.Enabled = false;

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT A.ret_id, A.ret_no, A.ord_id, A.ord_no, A.loc_cd,");
            sql.Append(" B.loc_nm, A.cust_id, A.full_name, A.mobile_no,");
            sql.Append(" A.tel_no, A.delv_tp, D.delv_nm, A.pay_tp, C.pay_nm,");
            sql.Append(" A.pay_info, A.ship_addr, A.ship_addr_dtl, DATE_FORMAT(A.ord_dt, '%Y-%m-%d %T') ord_dt, DATE_FORMAT(A.delv_dt, '%Y-%m-%d %T') delv_dt,");

            sql.Append(" F.price_total, F.price_delv, F.price_real, F.price_point, F.price_card, F.price_event_point, F.price_coupon,");
            sql.Append(" F.recv_price_total, F.recv_price_delv, F.recv_price_real, F.recv_price_point, F.recv_price_card, F.recv_price_event_point, F.recv_price_coupon,");
            sql.Append(" A.ret_price_total, A.ret_price_delv, A.ret_price_real, A.ret_price_point, A.ret_price_card, A.ret_price_event_point, A.ret_price_coupon,");

            sql.Append(" A.ret_tp, E.ret_tp_nm, A.ret_yn, DATE_FORMAT(A.ret_dt, '%Y-%m-%d %T') ret_dt, A.ret_reason");
            sql.Append(" FROM " + HBConstant.TB_SO_RETURN + " A");
            sql.Append(" LEFT JOIN " + HBConstant.TB_MA_PICKUP_LOC + " B ON A.loc_cd = B.loc_cd ");
            sql.Append(" LEFT JOIN (SELECT cd as pay_tp, cd_nm as pay_nm FROM tb_sys_code WHERE grp_cd = 'PAY_TP') C ON A.pay_tp = C.pay_tp ");
            sql.Append(" LEFT JOIN (SELECT cd as delv_tp, cd_nm as delv_nm FROM tb_sys_code WHERE grp_cd = 'DELV_TP') D ON A.delv_tp = D.delv_tp ");
            sql.Append(" LEFT JOIN (SELECT cd as ret_tp, cd_nm as ret_tp_nm FROM tb_sys_code WHERE grp_cd = 'RET_TP') E ON A.ret_tp = E.ret_tp ");

            // Right join with tb_so_order
            sql.Append(" LEFT JOIN " + HBConstant.TB_SO_DELV + " F ON A.ord_id = F.ord_id AND A.ord_no = F.ord_no");

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

            // Searching with Return Type
            if (!String.IsNullOrEmpty(scReturnType.Value.ToString()))
            {
                sql.Append(" AND A.ret_tp = #{ret_tp}");
                action.param.Add(scReturnType.FieldName, scReturnType.Value);
            }

            // Searching with Return Status
            if (!String.IsNullOrEmpty(scReturned.Value.ToString())){
                sql.Append(" AND A.ret_yn = #{ret_yn}");
                action.param.Add(scReturned.FieldName, scReturned.Value);
            }

            // TODO Search with date of Order
            if (scStartDate.DateTime <= scEndDate.DateTime)
            {
                sql.Append(" AND (A.ret_dt BETWEEN #{start_date} AND #{end_date})");
                action.param.Add(scStartDate.FieldName, scStartDate.DateTime);
                action.param.Add(scEndDate.FieldName, scEndDate.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59));
            }

            sql.Append(" ORDER BY A.ret_yn, A.ret_id ASC ");

            action.text = sql.ToString();

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            gridReturn.DataSource = ds.Tables[0];

            gridViewReturn.RefreshData();
            if (!String.IsNullOrEmpty(ordNo)) ChoiceOrd();
        }

        private void ChoiceOrd()
        {

            for (int i = 0; i < gridViewReturn.RowCount; i++)
            {
                if (gridViewReturn.GetRowCellValue(i, "ord_no").ToString() == this.ordNo)
                {
                    gridViewReturn.FocusedRowHandle = i;
                    break;
                }
            }

            this.ordNo = String.Empty;
        }

        private void gridViewReturn_DataSourceChanged(object sender, System.EventArgs e)
        {

            if (gridViewReturn.RowCount > 0)
            {
                gridViewReturn.FocusedRowHandle = 0;
            }
            else
            {
                gridReturnDetail.DataSource = null;
            }
        }

        private void gridViewReturn_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0 || e.FocusedRowHandle >= gridViewReturn.RowCount) return;

            if (!String.IsNullOrEmpty(ret_no) && ret_no != gridViewReturn.GetRowCellValue(e.FocusedRowHandle, "ret_no").ToString())
            {

                //if (XtraMessageBox.Show("주문 번호를 받으려고합니다: " + ret_no + ". 멈추시겠습니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
                if (XtraMessageBox.Show("Đơn hàng: " + ret_no + " đang được xử lý. Bạn có muốn thay đổi hay không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    ret_no = String.Empty;
                }
                else
                {
                    gridViewReturn.FocusedRowHandle = currentSelected;
                    return;
                }
            }

            currentSelected = e.FocusedRowHandle;

            SearchReturnDetail(e.FocusedRowHandle);
            ret_yn = gridViewReturn.GetRowCellValue(e.FocusedRowHandle, "ret_yn").ToString();

            if (ret_yn == "N") btnRefund.Enabled = true;
            else btnRefund.Enabled = false;
        }

        private void gridViewReturn_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (gridViewReturn.RowCount <= 0 || e.RowHandle < 0) return;

            if (gridViewReturn.GetRowCellValue(e.RowHandle, "ret_yn").ToString() == "Y" && e.Appearance.BackColor != Color.Gray)
            {
                e.Appearance.BackColor = Color.Gray;
            }

            e.HighPriority = true;
        }

        private void gridViewReturn_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            string returnReason;
            int selRow = gridViewReturn.FocusedRowHandle;
            if (e.Column.FieldName != "ret_reason") return;

            returnReason = gridViewReturn.GetRowCellValue(selRow, "ret_reason").ToString();

            // Update return reason on return table

            JsonRequest request = new JsonRequest();
            StringBuilder sql = new StringBuilder();

            ProcAction updateReturn = request.NewAction();
            updateReturn.proc = WebUtil.Values.PROC_SQL;

            sql.Append("UPDATE " + HBConstant.TB_SO_RETURN);
            sql.Append(" SET ret_reason = #{ret_reason}, up_id = #{up_id}, up_dt = CURRENT_TIMESTAMP");
            sql.Append(" WHERE ret_id = #{ret_id} AND ret_no = #{ret_no}");

            updateReturn.text = sql.ToString();
            updateReturn.param.Add("ret_reason", returnReason);
            updateReturn.param.Add(HBConstant.C_UP_ID, COM.UserInfo.UserID);
            updateReturn.param.Add("ret_id", gridViewReturn.GetRowCellValue(selRow, "ret_id"));
            updateReturn.param.Add("ret_no", gridViewReturn.GetRowCellValue(selRow, "ret_no"));

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);
            if (client.check)
            {
                gridViewReturn.RefreshData();
                SearchReturnDetail(selRow);
            }
            else
            {
                //XtraMessageBox.Show("픽업 주문 업데이트 실패 : " + client.message, "실패");
                XtraMessageBox.Show("Có lỗi xảy ra: \n" + client.message, "Lỗi");
            }
            bolCellChanging = false;
        }

        private void gridViewReturnDetail_DataSourceChanged(object sender, System.EventArgs e)
        {
            if (gridViewReturnDetail.RowCount > 0)
            {
                gridViewReturnDetail.FocusedRowHandle = 0;
            }
        }

        private void gridViewReturnDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int selRow = gridViewReturnDetail.FocusedRowHandle;
            if (selRow < 0 || selRow >= gridViewReturnDetail.RowCount) return;

            if (!(int.TryParse(gridViewReturnDetail.GetRowCellValue(selRow, "ord_qty").ToString(), out ord_qty) &&
                int.TryParse(gridViewReturnDetail.GetRowCellValue(selRow, "ret_qty").ToString(), out ret_qty) &&
                int.TryParse(gridViewReturnDetail.GetRowCellValue(selRow, "remain_qty").ToString(), out remain_qty) &&
                int.TryParse(gridViewReturnDetail.GetRowCellValue(selRow, "cancel_qty").ToString(), out cancel_qty))) return;

            ord_qty = int.Parse(gridViewReturnDetail.GetRowCellValue(selRow, "ord_qty").ToString());
            ret_qty = int.Parse(gridViewReturnDetail.GetRowCellValue(selRow, "ret_qty").ToString());
            remain_qty = int.Parse(gridViewReturnDetail.GetRowCellValue(selRow, "remain_qty").ToString());
            cancel_qty = int.Parse(gridViewReturnDetail.GetRowCellValue(selRow, "cancel_qty").ToString());
        }

        private void gridViewReturnDetail_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            bolCellChanging = true;
        }

        private void gridViewReturnDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int tmp_return_qty = 0;
            int tmp_remain_qty = 0;           //Calculation pickup quantity after update
            int selRow = gridViewReturnDetail.FocusedRowHandle;
            bool bolPickDone = false;
            int chkOrderQty, chkReturnQty, chkRemainQty, chkCancelQty;

            ret_yn = gridViewReturn.GetRowCellValue(gridViewReturn.FocusedRowHandle, "ret_yn").ToString();

            if (ret_yn == "Y" || e.Column.FieldName != "ret_qty")
            {
                gridViewReturnDetail.CancelUpdateCurrentRow();

                bolCellChanging = false;
                return;
            }

            if (!String.IsNullOrEmpty(e.Value.ToString()) && !e.Value.ToString().StartsWith("-") && int.TryParse(e.Value.ToString(), out tmp_return_qty))
            {
                tmp_return_qty = int.Parse(e.Value.ToString());
                tmp_remain_qty = ord_qty - tmp_return_qty - cancel_qty;

                // Pickup quantity are not change
                if (tmp_return_qty == ret_qty)
                {
                    //XtraMessageBox.Show("픽업 수량은 변경되지 않습니다.", "성공");
                    XtraMessageBox.Show("Số lượng trả hàng không thay đổi.", "Thông báo");
                    bolCellChanging = false;
                    return;
                }
            }
            else
            {
                //XtraMessageBox.Show("픽업 수량은 0과 주문 수량 사이 여야합니다.", "성공");
                XtraMessageBox.Show("Số lượng trả hàng phải lớn hơn 0 và nhỏ hơn số lượng đặt hàng.", "Thông báo");
                //gridViewPickupDetail.SetRowCellValue(selRow, STR_PICK_QTY, pick_qty);
                gridViewReturnDetail.CancelUpdateCurrentRow();
                bolCellChanging = false;
                return;
            }

            // Pickup quantity > order quantity
            if ((tmp_return_qty + cancel_qty) > ord_qty || tmp_remain_qty < 0)
            {
                //if (XtraMessageBox.Show("픽업 수량이 주문 수량보다 큽니다. 그들 모두를 선택?", "확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
                if (XtraMessageBox.Show("Số lượng trả hàng đang lớn hơn số lượng đặt hàng. \nBạn có muốn cập nhật lại thành số lượng đặt hàng không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    tmp_return_qty = ord_qty;
                    tmp_remain_qty = 0;
                    bolPickDone = true;
                    //gridViewPickupDetail.SetRowCellValue(selRow, STR_PICK_QTY, ord_qty);
                    //gridViewPickupDetail.SetRowCellValue(selRow, STR_REMAIN_QTY, 0);
                }
                else
                {
                    //XtraMessageBox.Show("픽업 수량은 0과 주문 수량 사이 여야합니다.", "성공");
                    XtraMessageBox.Show("Số lượng trả hàng phải lớn hơn 0 và nhỏ hơn số lượng đặt hàng.", "Thông báo");
                    gridViewReturnDetail.CancelUpdateCurrentRow();
                    bolCellChanging = false;
                    return;
                }
            }
            // Order quantity is equal to pickup quantity: Update status of pickup to done
            else if (ord_qty == (tmp_return_qty + cancel_qty))
            {
                bolPickDone = true;
            }
            // Order quantity is still greater than pickup quantity: Update status of pickup to retry
            else
            {
                bolPickDone = false;
            }

            ret_no = gridViewReturn.GetRowCellValue(gridViewReturn.FocusedRowHandle, "ret_no").ToString();
            ord_no = gridViewReturn.GetRowCellValue(gridViewReturn.FocusedRowHandle, "ord_no").ToString();

            // Update Pickup detail
            JsonRequest request = new JsonRequest();
            StringBuilder sql = new StringBuilder();

            ProcAction updateReturnDetail = request.NewAction();
            updateReturnDetail.proc = WebUtil.Values.PROC_SQL;

            sql.Append("UPDATE " + HBConstant.TB_SO_RETURN_DTL);
            sql.Append(" SET ret_qty = #{ret_qty}, remain_qty = #{remain_qty}, up_id = #{up_id}, up_dt = CURRENT_TIMESTAMP");
            sql.Append(" WHERE ret_dtl_id = #{ret_dtl_id} AND ret_id = #{ret_id} AND ret_no = #{ret_no}");

            updateReturnDetail.text = sql.ToString();
            updateReturnDetail.param.Add("ret_qty", tmp_return_qty);
            updateReturnDetail.param.Add("remain_qty", tmp_remain_qty);
            updateReturnDetail.param.Add(HBConstant.C_UP_ID, COM.UserInfo.UserID);
            updateReturnDetail.param.Add("ret_dtl_id", gridViewReturnDetail.GetRowCellValue(selRow, "ret_dtl_id"));
            updateReturnDetail.param.Add("ret_id", gridViewReturnDetail.GetRowCellValue(selRow, "ret_id"));
            updateReturnDetail.param.Add("ret_no", gridViewReturnDetail.GetRowCellValue(selRow, "ret_no"));

            // If current pickup is done, check other pickups
            if (bolPickDone && gridViewReturnDetail.RowCount > 1)
            {
                for (int i = 0; i < gridViewReturnDetail.RowCount; i++)
                {
                    chkOrderQty = int.Parse(gridViewReturnDetail.GetRowCellValue(i, "ord_qty").ToString());
                    chkReturnQty = int.Parse(gridViewReturnDetail.GetRowCellValue(i, "ret_qty").ToString());
                    chkRemainQty = int.Parse(gridViewReturnDetail.GetRowCellValue(i, "remain_qty").ToString());
                    chkCancelQty = int.Parse(gridViewReturnDetail.GetRowCellValue(i, "cancel_qty").ToString());
                    if (i != selRow && (chkOrderQty != (chkReturnQty + chkCancelQty) || chkRemainQty != 0))
                    {
                        bolPickDone = false;
                        break;
                    }
                }
            }

            // Update type when return all products of Return
            ProcAction updateReturn = request.NewAction();
            updateReturn.proc = WebUtil.Values.PROC_SQL;
            sql.Clear();

            sql.Append("UPDATE " + HBConstant.TB_SO_RETURN);
            sql.Append(" SET ret_tp = #{ret_tp}, up_id = #{up_id}, up_dt = CURRENT_TIMESTAMP");
            sql.Append(" WHERE ret_id = #{ret_id} AND ret_no = #{ret_no}");

            updateReturn.text = sql.ToString();
            if (bolPickDone)
            {
                updateReturn.param.Add("ret_tp", "total");
            }
            else
            {
                updateReturn.param.Add("ret_tp", "part");
            }
            updateReturn.param.Add(HBConstant.C_UP_ID, COM.UserInfo.UserID);
            updateReturn.param.Add("ret_id", gridViewReturnDetail.GetRowCellValue(selRow, "ret_id"));
            updateReturn.param.Add("ret_no", gridViewReturnDetail.GetRowCellValue(selRow, "ret_no"));

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);
            if (client.check)
            {
                // TODO Message
                //XtraMessageBox.Show("픽업 주문이 업데이트되었습니다.", "성공");
                int selReturn = gridViewReturn.FocusedRowHandle;
                if (bolPickDone)
                {
                    gridViewReturn.SetRowCellValue(selReturn, "ret_tp", "total");
                    gridViewReturn.SetRowCellValue(selReturn, "ret_tp_nm", "Total");
                    ord_no = String.Empty;
                    ret_no = String.Empty;
                }
                else
                {
                    gridViewReturn.SetRowCellValue(selReturn, "ret_tp", "part");
                    gridViewReturn.SetRowCellValue(selReturn, "ret_tp_nm", "Part");
                }

                gridViewReturn.RefreshData();
                gridViewReturnDetail.RefreshData();
                SearchReturnDetail(selReturn);
            }
            else
            {
                //XtraMessageBox.Show("픽업 주문 업데이트 실패 : " + client.message, "실패");
                XtraMessageBox.Show("Có lỗi xảy ra: \n" + client.message, "Lỗi");
                gridViewReturnDetail.CancelUpdateCurrentRow();
            }

            bolCellChanging = false;
        }

        void SearchReturnDetail(int row)
        {
            if (row < 0)
            {
                gridReturnDetail.DataSource = null;
                return;
            }

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT A.ret_dtl_id, A.ret_id, A.ret_no, A.ret_seq, A.prod_cd,");
            sql.Append(" B.prod_nm_ko, B.prod_nm_en, B.prod_nm, A.unit, A.ord_qty, ");
            sql.Append(" A.pick_qty, A.ret_qty, A.remain_qty, A.cancel_qty,");
            sql.Append(" A.unit_price, A.unit_sale_price, A.unit_delv_price");
            sql.Append(" FROM " + HBConstant.TB_SO_RETURN_DTL + " A ");
            sql.Append(" LEFT JOIN " + HBConstant.TB_MA_PRODUCT + " B ON A.prod_cd = B.prod_cd ");
            sql.Append(" WHERE A.ret_id = #{ret_id}  ");
            sql.Append(" AND A.ret_no = #{ret_no} ");

            action.text = sql.ToString();
            action.param.Add("ret_id", gridViewReturn.GetRowCellValue(row, "ret_id"));
            action.param.Add("ret_no", gridViewReturn.GetRowCellValue(row, "ret_no"));

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            gridReturnDetail.DataSource = ds.Tables[0];
        }

        private void gridViewReturnDetail_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            int returnQty = 0;
            int ordQty = 0;
            int cancelQty = 0;

            if (gridViewReturnDetail.RowCount <= 0 || e.RowHandle < 0) return;

            if (int.TryParse(gridViewReturnDetail.GetRowCellValue(e.RowHandle, "ord_qty").ToString(), out ordQty) &&
                int.TryParse(gridViewReturnDetail.GetRowCellValue(e.RowHandle, "ret_qty").ToString(), out returnQty) &&
                int.TryParse(gridViewReturnDetail.GetRowCellValue(e.RowHandle, "cancel_qty").ToString(), out cancelQty) &&
                ordQty == (returnQty + cancelQty) && e.Appearance.BackColor != Color.LightGreen)
            {
                e.Appearance.BackColor = Color.LightGreen;
            }
            e.HighPriority = true;
        }

        private void btnRefund_HbClick(object sender, EventArgs e)
        {
            if (gridViewReturn.RowCount <= 0)
            {
                return;
            }
            if (gridViewReturn.GetFocusedRowCellValue("ret_yn").ToString() == "Y")
            {
                //MessageBox.Show("Already Finished...");
                MessageBox.Show("Đơn hàng đã hoàn tiền thành công.", "Thông báo");
                return;
            }

            string ordNo = gridViewReturn.GetFocusedRowCellValue("ord_no").ToString();

            popRefund dialog = new popRefund(gridViewReturn, gridViewReturnDetail, ordNo);
            dialog.ShowDialog();

            if (gridViewReturn.GetRowCellValue(gridViewReturn.FocusedRowHandle, "ret_yn").ToString() == "N") btnRefund.Enabled = true;
            else
            {
                btnRefund.Enabled = false;
                ret_no = String.Empty;
            }

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

                    if (_barcode.Length > 2 && _barcode.Contains(string.Concat((char)Keys.ShiftKey, "3")))
                    {
                        int position = _barcode.IndexOf(string.Concat((char)Keys.ShiftKey, "3"));
                        ordNo = _barcode.Substring(position + 2, _barcode.Length - (2 + position));
                    }

                    // Focus Picking, what matching with ord_no
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

                    //XtraMessageBox.Show(_barcode);
                    // Process [ickup a products
                    if (ret_yn == "Y" )
                    {
                        //XtraMessageBox.Show("Return is already done or cancel.", "Warning");
                        XtraMessageBox.Show("Đơn hàng này đã hoàn trả.", "Thông báo");
                        _barcode = "";
                        return false;
                    }

                    bool isProduct = false;
                    int row = 0;
                    string prodcutCode;
                    string productName;
                    int retQty, ordQty, cancelQty;
                    int i = 0;
                    while (!isProduct && i < gridViewReturnDetail.DataRowCount)
                    {
                        prodcutCode = gridViewReturnDetail.GetRowCellValue(i, "prod_cd").ToString();

                        retQty = int.Parse(gridViewReturnDetail.GetRowCellValue(i, "ret_qty").ToString());
                        ordQty = int.Parse(gridViewReturnDetail.GetRowCellValue(i, "ord_qty").ToString());
                        cancelQty = int.Parse(gridViewReturnDetail.GetRowCellValue(i, "cancel_qty").ToString());

                        if ((prodcutCode == _barcode || prodcutCode.Contains(_barcode)) && (retQty + cancelQty) < ordQty)
                        {
                            isProduct = true;
                        }
                        row = i;

                        i++;
                    }

                    if (isProduct)
                    {
                        gridViewReturnDetail.FocusedRowHandle = row;
                        productName = gridViewReturnDetail.GetRowCellValue(row, "prod_nm").ToString();

                        retQty = int.Parse(gridViewReturnDetail.GetRowCellValue(row, "ret_qty").ToString());
                        cancelQty = int.Parse(gridViewReturnDetail.GetRowCellValue(row, "cancel_qty").ToString());
                        if (retQty == ret_qty && (retQty + cancelQty) < ord_qty)
                        {
                            retQty = retQty + 1;

                            gridViewReturnDetail.SetRowCellValue(row, "ret_qty", retQty);

                        }
                        else
                        {
                            //XtraMessageBox.Show("The picking of there product was completed", "Warning");
                            XtraMessageBox.Show("Sản phẩm này đã được hoàn thành.", "Thông báo");
                        }

                        gridViewReturnDetail.FocusedRowHandle = row;

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
    }
}
