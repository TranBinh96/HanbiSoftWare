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
using WebUtil;
using HanbiControl;
using CommonUtil;
using System.Globalization;

namespace COM
{
    public partial class COM_Home : DevExpress.XtraEditors.XtraUserControl
    {
        int intNew, intPicking, intDelivering, intWaiting, intCompleted, intTotal;

        string strStatus = String.Empty;
        const string C_NEW = "New";
        const string C_PICKING = "Picking";
        const string C_DELIVERING = "Delivering";
        const string C_WAITING = "Waiting";

        public COM_Home()
        {
            InitializeComponent();

            //Search();
        }

        public void Search()
        {
            return;
            GetSummary();
            if(String.IsNullOrEmpty(strStatus)) DisplayOrders(C_NEW);
            else DisplayOrders(strStatus);
        }

        private void GetSummary()
        {
            intNew = 0;
            intPicking = 0;
            intDelivering = 0;
            intWaiting = 0;
            intCompleted = 0;
            intTotal = 0;

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;
            action.text = "CALL get_summary(#{loc_cd}); ";
            action.param.Add("loc_cd", COM.UserInfo.LocCode);

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0 || dt.Rows.Count > 1) return;

            intNew = int.Parse(dt.Rows[0]["new"].ToString());
            labelNew.Text = intNew.ToString();

            intPicking = int.Parse(dt.Rows[0]["picking"].ToString());
            labelPicking.Text = intPicking.ToString();

            intDelivering = int.Parse(dt.Rows[0]["delivering"].ToString());
            labelDelivering.Text = intDelivering.ToString();

            intWaiting = int.Parse(dt.Rows[0]["waiting"].ToString());
            labelWaiting.Text = intWaiting.ToString();

            intCompleted = int.Parse(dt.Rows[0]["completed"].ToString());
            intTotal = int.Parse(dt.Rows[0]["total"].ToString());
            string lang = AccessDB.GetConfig("lang");
            if (lang == null || lang == "") lang = "ko";

            switch (lang)
            {
                case "ko":
                    labelSummary.Text = String.Concat("총 주문 : ", intCompleted, "/", intTotal, " 건");
                    break;
                case "en":
                    labelSummary.Text = String.Concat("Total orders: ", intCompleted, "/", intTotal, " cases");
                    break;
                case "vi":
                    labelSummary.Text = String.Concat("Tổng đơn hàng: ", intCompleted, "/", intTotal, " đơn");
                    break;
            }
        }

        private void btnNew_HbClick(object sender, System.EventArgs e)
        {
            //DisplayOrders(C_NEW);
        }

        private void btnPicking_HbClick(object sender, System.EventArgs e)
        {
            //DisplayOrders(C_PICKING);
        }

        private void btnDelivering_HbClick(object sender, System.EventArgs e)
        {
            //DisplayOrders(C_DELIVERING);
        }

        private void btnWaiting_HbClick(object sender, System.EventArgs e)
        {
            //DisplayOrders(C_WAITING);
        }

        private void DisplayOrders(string status)
        {
            strStatus = status;
            if (gridDashboard.DataSource != null) gridDashboard.DataSource = null;
            InitGridOrders(status);

            JsonRequest request = new JsonRequest();
            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT A.ord_no, A.cust_id, A.full_name, A.mobile_no, A.tel_no,");
            sql.Append(" A.pay_tp, C.pay_nm, A.ship_addr, A.price_total, DATE_FORMAT(A.up_dt, '%Y-%m-%d') AS up_dt, DATE_FORMAT(A.in_dt, '%Y-%m-%d') AS in_dt,");
            switch (strStatus)
            {
                case C_NEW:
                    sql.Append(" 'New' AS ord_status");
                    break;
                case C_PICKING:
                    sql.Append(" D.pick_no, D.pick_sts, E.pick_sts_nm");
                    break;
                case C_DELIVERING:
                    sql.Append(" D.delv_no, 'Delivering' AS ord_status");
                    break;
                case C_WAITING:
                    sql.Append(" 'Waiting' AS ord_status");
                    break;
            }

            sql.Append(" , CASE ");
            sql.Append("  WHEN TIMEDIFF(NOW(), A.up_dt) <= #{time_level_2} THEN \"1\" ");
            sql.Append("  WHEN TIMEDIFF(NOW(), A.up_dt) > #{time_level_2} AND TIMEDIFF(NOW(), A.up_dt) <= #{time_level_3} THEN \"2\"");
            sql.Append("  WHEN TIMEDIFF(NOW(), A.up_dt) > #{time_level_3} THEN \"3\"");
            sql.Append(" END AS ord_level");

            sql.Append(" FROM tb_so_order A LEFT JOIN tb_ma_pickup_loc B ON A.loc_cd = B.loc_cd");
            sql.Append(" LEFT JOIN (SELECT cd as pay_tp, cd_nm as pay_nm FROM tb_sys_code WHERE grp_cd = 'PAY_TP') C ON A.pay_tp = C.pay_tp");

            switch (strStatus)
            {
                case C_NEW:
                    sql.Append(" WHERE A.pick_ord_yn ='N' AND A.pick_yn = 'N' AND A.delv_ord_yn = 'N' AND A.delv_yn = 'N' AND A.stop_yn = 'N'");
                    break;
                case C_PICKING:
                    sql.Append(" LEFT JOIN tb_so_pick D ON A.ord_id = D.ord_id AND A.ord_no = D.ord_no");
                    sql.Append(" LEFT JOIN (SELECT cd as pick_cd, cd_nm as pick_sts_nm FROM tb_sys_code WHERE grp_cd = 'PICKUP_STATUS') E ON D.pick_sts = E.pick_cd");
                    sql.Append(" WHERE A.pick_ord_yn ='Y' AND A.pick_yn = 'N' AND A.delv_ord_yn = 'N' AND A.delv_yn = 'N' AND A.stop_yn = 'N'");
                    break;
                case C_DELIVERING:
                    sql.Append(" LEFT JOIN tb_so_delv D ON A.ord_id = D.ord_id AND A.ord_no = D.ord_no");
                    sql.Append(" WHERE A.pick_ord_yn ='Y' AND A.pick_yn = 'Y' AND A.delv_ord_yn = 'Y' AND A.delv_yn = 'N' AND A.stop_yn = 'N'");
                    break;
                case C_WAITING:
                    sql.Append(" WHERE A.pick_ord_yn ='Y' AND A.pick_yn = 'Y' AND A.delv_yn = 'N' AND A.stop_yn = 'N'");
                    break;
            }

            if (!String.IsNullOrEmpty(COM.UserInfo.LocCode))
            {
                sql.Append(" AND A.loc_cd = #{loc_cd}");
                action.param.Add("loc_cd", COM.UserInfo.LocCode);
            }
            action.param.Add("time_level_2", "00:03:00");
            action.param.Add("time_level_3", "00:05:00");

            sql.Append(" ORDER BY in_dt asc");

            action.text = sql.ToString();

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            gridDashboard.DataSource = ds.Tables[0];
            gridDashboard.Refresh();

            switch (status)
            {
                case C_NEW:
                    // Update New numbers
                    if (ds.Tables[0].Rows.Count != intNew)
                    {
                        intNew = ds.Tables[0].Rows.Count;
                        labelNew.Text = intNew.ToString();
                    }
                    break;
                case C_PICKING:
                    // Update Picking numbers
                    if (ds.Tables[0].Rows.Count != intPicking)
                    {
                        intPicking = ds.Tables[0].Rows.Count;
                        labelPicking.Text = intPicking.ToString();
                    }
                    break;
                case C_DELIVERING:
                    // Update Delivering numbers
                    if (ds.Tables[0].Rows.Count != intDelivering)
                    {
                        intDelivering = ds.Tables[0].Rows.Count;
                        labelDelivering.Text = intDelivering.ToString();
                    }
                    break;
                case C_WAITING:
                    // Update Waiting numbers
                    if (ds.Tables[0].Rows.Count != intDelivering)
                    {
                        intWaiting = ds.Tables[0].Rows.Count;
                        labelWaiting.Text = intWaiting.ToString();
                    }
                    break;
            }
        }

        private void InitGridOrders(string status)
        {
            GridOption gridOption = new GridOption();
            gridOption.SetTextColInfo(false, true, true, true, true, false, 1, "ord_no", "ord_no", 120, GridOption.Align.left);

            switch (status)
            {
                case C_PICKING:
                    gridOption.SetTextColInfo(false, true, true, true, true, false, 2, "pick_no", "pick_no", 120, GridOption.Align.left);
                    break;
                case C_DELIVERING:
                    gridOption.SetTextColInfo(false, true, true, true, true, false, 2, "delv_no", "delv_no", 120, GridOption.Align.left);
                    break;
            }
            // Customer Information
            gridOption.SetTextColInfo(false, true, true, true, true, false, 3, "full_name", "full_name", 200, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 4, "mobile_no", "mobile_no", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 5, "tel_no", "tel_no", 100, GridOption.Align.left);

            //Payment and Shipping Infor
            gridOption.SetTextColInfo(false, true, true, true, false, false, 6, "pay_nm", "pay_nm", 100, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 7, "ship_addr", "ship_addr", 300, GridOption.Align.left);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 8, "price_total", "price_total", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            gridOption.SetTextColInfo(false, true, true, true, true, false, 9, "up_dt", "up_dt", 100, GridOption.Align.center);
            
            if (status == C_PICKING)
            {
                gridOption.SetTextColInfo(false, true, true, true, false, false, 10, "pick_sts_nm", "pick_sts_nm", 100, GridOption.Align.center);
            } else gridOption.SetTextColInfo(false, true, true, true, false, false, 10, "ord_status", "ord_status", 100, GridOption.Align.center);

            gridOption.SetTextColInfo(false, true, true, true, true, false, -1, "ord_level", "ord_level", 100, GridOption.Align.center);

            gridOption.Apply(gridViewDashboard);
        }

        private void labelNew_Click(object sender, System.EventArgs e)
        {
            //DisplayOrders(C_NEW);
        }

        private void labelPicking_Click(object sender, System.EventArgs e)
        {
            //DisplayOrders(C_PICKING);
        }

        private void labelDelivering_Click(object sender, System.EventArgs e)
        {
            //DisplayOrders(C_DELIVERING);
        }

        private void labelWaiting_Click(object sender, System.EventArgs e)
        {
            //DisplayOrders(C_WAITING);
        }

        private void labelNew_DoubleClick(object sender, System.EventArgs e)
        {
            //DisplayOrders(C_NEW);
            //MainUtils.SetParameter(String.Empty, "N", "N", "N", "N");
            //SetDateWhenClickLabel();
            //MainUtils.OpenTab("SOD", "SOD_Order");
            //MainUtils.ResetParameter();
        }

        private void labelPicking_DoubleClick(object sender, System.EventArgs e)
        {
            //DisplayOrders(C_PICKING);
            //MainUtils.SetParameter(String.Empty, "Y", "N", "N", "N");
            //SetDateWhenClickLabel();
            //MainUtils.OpenTab("SOD", "SOD_Pickup");
            //MainUtils.ResetParameter();
        }

        private void labelDelivering_DoubleClick(object sender, System.EventArgs e)
        {
            //DisplayOrders(C_DELIVERING);
            //MainUtils.SetParameter(String.Empty, "Y", "Y", "Y", "N");
            //SetDateWhenClickLabel();
            //MainUtils.OpenTab("SOD", "SOD_Delivery");
            //MainUtils.ResetParameter();
        }

        private void labelWaiting_DoubleClick(object sender, System.EventArgs e)
        {
            //DisplayOrders(C_WAITING);
            //MainUtils.SetParameter(String.Empty, "Y", "Y", String.Empty, "N");
            //SetDateWhenClickLabel();
            //MainUtils.OpenTab("SOD", "SOD_Pickup");
            //MainUtils.ResetParameter();
        }

        private void SetDateWhenClickLabel()
        {
            if (gridViewDashboard.RowCount > 0)
            {
                string date = gridViewDashboard.GetRowCellValue(0, "in_dt").ToString();
                MainUtils.SetSearchDate(date);
            }
            else
            {
                MainUtils.SetSearchDate(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).ToString("yyyy-MM-dd"));
            }
        }

        private void gridViewDashboard_DoubleClick(object sender, System.EventArgs e)
        {
            return;
            if (gridViewDashboard.RowCount <= 0) return;

            string ord_no = gridViewDashboard.GetRowCellValue(gridViewDashboard.FocusedRowHandle, "ord_no").ToString();
            MainUtils.SetParameter(ord_no, String.Empty, String.Empty, String.Empty, String.Empty);

            string date = gridViewDashboard.GetRowCellValue(gridViewDashboard.FocusedRowHandle, "in_dt").ToString();
            MainUtils.SetSearchDate(date);

            switch (strStatus)
            {
                case C_NEW:
                    MainUtils.OpenTab("SOD", "SOD_Order");
                    break;
                case C_PICKING:
                    MainUtils.OpenTab("SOD", "SOD_Pickup");
                    break;
                case C_DELIVERING:
                    MainUtils.OpenTab("SOD", "SOD_Delivery");
                    break;
                case C_WAITING:
                    MainUtils.OpenTab("SOD", "SOD_Pickup");
                    break;
            }

            MainUtils.ResetParameter();
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
                    MainUtils.bolConfirmMessage = false;
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

        private void gridViewDashboard_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (gridViewDashboard.RowCount <= 0 || e.RowHandle < 0 || strStatus != C_NEW) return;
        
            string time_level = gridViewDashboard.GetRowCellValue(e.RowHandle, "ord_level").ToString();
            int new_level = 0;

            if (!int.TryParse(time_level, out new_level)) return;
            new_level = int.Parse(time_level);

            if (strStatus == C_NEW && new_level == 1 && e.Appearance.BackColor != Color.Green)
            {
                e.Appearance.BackColor = Color.Green;
            }
            else if (strStatus == C_NEW && new_level == 2 && e.Appearance.BackColor != Color.Yellow)
            {
                e.Appearance.BackColor = Color.Yellow;
            }
            else if (strStatus == C_NEW && new_level == 3 && e.Appearance.BackColor != Color.Red)
            {
                e.Appearance.BackColor = Color.Red;
            }

            e.HighPriority = true;
        }
    }
}
