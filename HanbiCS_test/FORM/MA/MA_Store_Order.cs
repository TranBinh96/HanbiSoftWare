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
using Excel = Microsoft.Office.Interop.Excel;

namespace MA
{
    public partial class MA_Store_Order : DevExpress.XtraEditors.XtraUserControl
    {
        private string strLocCode = String.Empty;
        public MA_Store_Order()
        {
            InitializeComponent();

            InitSearch();
            initGrid();
            initGridDTL();

            Search();
        }

        private void InitSearch()
        {
            if (COM.UserInfo.RoleID == "1")
            {
                scLocation.Text = COM.UserInfo.LocName;
            }
            else
            {
                scLocation.Text = String.Empty;
            }

            DateTime som = DateTime.Today;
            scStartDate.Value = som.ToString("yyyy-MM-dd");
            scEndDate.Value = som.ToString("yyyy-MM-dd");

        }

        private void initGrid()
        {
            GridOption gridOption = new GridOption();
            gridOption.SetTextColInfo(false, true, true, true, true, false, 1, "loc_cd", "loc_cd", 100, GridOption.Align.right);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 2, "loc_nm", "loc_nm", 250, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 3, "loc_addr", "loc_addr", 450, GridOption.Align.left);

            // Light red
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 4, "total_amt_real", "total_amt_real", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 5, "total_amt_payment", "total_amt_payment", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 6, "total_amt_return", "total_amt_return", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 7, "total_amt_gap", "total_amt_gap", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            // Light Blue
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 8, "total_amt_delv", "total_amt_delv", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 9, "total_amt_dc", "total_amt_dc", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 10, "total_amt_point", "total_amt_point", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 11, "total_amt_voucher", "total_amt_voucher", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 12, "total_amt", "total_amt", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            // Light Green
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 13, "total_amt_card", "total_amt_card", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 14, "total_amt_atm", "total_amt_atm", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 15, "total_amt_cod", "total_amt_cod", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.Apply(grd_view_store);
        }

        private void initGridDTL()
        {

            GridOption gridOption = new GridOption();
            gridOption.SetTextColInfo(false, true, true, true, true, false, 1, "loc_cd", "loc_cd", 100, GridOption.Align.right);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 2, "ord_no", "ord_no", 120, GridOption.Align.left);

            // Customer Information
            gridOption.SetTextColInfo(false, true, true, true, true, false, 3, "cust_id", "cust_id", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 4, "full_name", "full_name", 250, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 5, "mobile_no", "mobile_no", 100, GridOption.Align.left);

            //Payment and Shipping Infor
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "delv_tp", "delv_tp", 50, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 6, "delv_nm", "delv_nm", 120, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "pay_tp", "pay_tp", 100, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 7, "pay_nm", "pay_nm", 100, GridOption.Align.center);
            // Price
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 8, "total_amt_real", "price_real", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 9, "total_amt_delv", "price_delv", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 10, "price_dc", "price_dc", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 11, "price_point", "price_point", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 12, "price_card", "price_card", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 13, "price_event_point", "price_event_point", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 14, "price_coupon", "price_coupon", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 15, "price_total", "price_total", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 16, "price_cancel", "price_cancel", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 17, "total_amt_return", "ret_price_real", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            gridOption.Apply(grd_view_ord);
        }

        #region Search
        void Search()
        {
            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();
            sql.Append(" CALL hanbibase.get_statistic(#{loc_cd}, #{start_date}, #{end_date})");

            getLocCode();
            if (COM.UserInfo.RoleID == "1")
            {
                action.param.Add("loc_cd", COM.UserInfo.LocCode);
            }
            else if (String.IsNullOrEmpty(scLocation.Text) || String.IsNullOrEmpty(strLocCode))
            {
                sql.Clear();
                sql.Append(" CALL hanbibase.get_statistic(NULL, #{start_date}, #{end_date})");
            }
            else
            {
                action.param.Add("loc_cd", strLocCode);
            }

            if (scStartDate.DateTime > scEndDate.DateTime)
            {
                DateTime som = DateTime.Today;
                scStartDate.Value = som.ToString("yyyy-MM-dd");
                scEndDate.Value = som.ToString("yyyy-MM-dd");
            }

            action.param.Add(scStartDate.FieldName, scStartDate.DateTime);
            action.param.Add(scEndDate.FieldName, scEndDate.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59));

            action.text = sql.ToString();

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            grd_store.DataSource = ds.Tables[0];
            grd_view_store.RefreshData();
        }

        void SearchDTL(int row)
        {
            if (row < 0)
            {
                grd_order.DataSource = null;
                return;
            }

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT A.loc_cd, A.ord_no, A.cust_id, A.full_name, A.mobile_no,");
            sql.Append(" A.delv_tp, D.delv_nm, A.pay_tp, C.pay_nm,");
            sql.Append(" A.price_total, A.price_delv, A.price_point, A.price_card, A.price_real, A.price_event_point, A.price_coupon, A.price_cancel, E.ret_price_real,");
            sql.Append(" (A.price_total + A.price_delv - A.price_real - A.price_point - A.price_card - A.price_event_point - A.price_coupon) AS price_dc");    // price_dc
            sql.Append(" FROM " + SYS.HBConstant.TB_SO_ORDER + " A LEFT JOIN " + SYS.HBConstant.TB_MA_PICKUP_LOC + " B ON A.loc_cd = B.loc_cd ");
            sql.Append(" LEFT JOIN (SELECT cd as pay_tp, cd_nm as pay_nm FROM tb_sys_code WHERE grp_cd = 'PAY_TP') C ON A.pay_tp = C.pay_tp ");
            sql.Append(" LEFT JOIN (SELECT cd as delv_tp, cd_nm as delv_nm FROM tb_sys_code WHERE grp_cd = 'DELV_TP') D ON A.delv_tp = D.delv_tp ");
            sql.Append(" LEFT JOIN hanbibase.tb_so_return E ON A.ord_no = E.ord_no AND A.ord_id = E.ord_id ");

            if (scStartDate.DateTime > scEndDate.DateTime)
            {
                DateTime som = DateTime.Today;
                scStartDate.Value = som.ToString("yyyy-MM-dd");
                scEndDate.Value = som.ToString("yyyy-MM-dd");
            }

            sql.Append(" WHERE (A.up_dt BETWEEN #{start_date} AND #{end_date})");
            action.param.Add(scStartDate.FieldName, scStartDate.DateTime);
            action.param.Add(scEndDate.FieldName, scEndDate.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59));

            sql.Append(" AND (A.loc_cd = #{loc_nm}) ");
            sql.Append(" AND (A.delv_yn = 'Y') ");
            sql.Append(" ORDER BY A.ord_no ");

            action.text = sql.ToString();
            action.param.Add(scLocation.FieldName, grd_view_store.GetRowCellValue(row, "loc_cd"));

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            grd_order.DataSource = ds.Tables[0];
            grd_view_ord.RefreshData();
        }
        #endregion

        private void grd_view_store_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0 || e.FocusedRowHandle >= grd_view_store.RowCount) return;
            SearchDTL(e.FocusedRowHandle);
        }

        private void grd_view_store_DataSourceChanged(object sender, EventArgs e)
        {
            if (grd_view_store.RowCount > 0)
            {
                grd_view_store.FocusedRowHandle = 0;
            }
            else
            {
                grd_order.DataSource = null;
            }
        }

        private void getLocCode()
        {
            if (String.IsNullOrEmpty(scLocation.Text)) return;

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT loc_cd, loc_nm");
            sql.Append(" FROM " + SYS.HBConstant.TB_MA_PICKUP_LOC);
            sql.Append(" WHERE loc_nm = #{loc_nm} ");
            sql.Append(" ORDER BY loc_cd ASC ");

            action.text = sql.ToString();
            action.param.Add(scLocation.FieldName, scLocation.Text);

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (client.check)
            {
                strLocCode = ds.Tables[0].Rows[0]["loc_cd"].ToString();
            }
            else
            {
                strLocCode = String.Empty;
            }
        }

        private void grd_view_store_DoubleClick(object sender, EventArgs e)
        {
            if (grd_view_store.RowCount < 0) return;
            scLocation.Text = grd_view_store.GetRowCellValue(grd_view_store.FocusedRowHandle, "loc_nm").ToString();
            Search();
        }

        private void btnExport_HbClick(object sender, EventArgs e)
        {
            if (grd_view_store.RowCount < 0 || grd_view_store.FocusedRowHandle < 0) return;

            int selRow = grd_view_store.FocusedRowHandle;

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;

            xlApp = new Excel.Application();
            xlApp.Visible = false;
            xlApp.DisplayAlerts = false;

            xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
            for (int i = 0; i < grd_view_store.RowCount; i++)
            {
                grd_view_store.FocusedRowHandle = i;
                ExportExcel(i, xlWorkBook);
            }
            grd_view_store.FocusedRowHandle = selRow;

            xlWorkBook.Worksheets[1].Activate();
            xlApp.Visible = true;
            xlApp.DisplayAlerts = true; 
        }


        private void ExportExcel(int selRow, Excel.Workbook xlWorkBook)
        {

            Excel.Worksheet xlMarketSheet;
            if (selRow == 0)
                xlMarketSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.ActiveSheet;
            else
                xlMarketSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(After: xlWorkBook.Sheets[xlWorkBook.Sheets.Count]);
            xlMarketSheet.Name = grd_view_store.GetRowCellValue(selRow, "loc_nm").ToString();

            xlMarketSheet.Cells[1, 2].Value = "Nhân viên: ";
            xlMarketSheet.Cells[1, 3].Value = COM.UserInfo.UserName;
            xlMarketSheet.Cells[2, 2].Value = "Cửa hàng: ";
            xlMarketSheet.Cells[2, 3].Value = grd_view_store.GetRowCellValue(selRow, "loc_nm").ToString();
            xlMarketSheet.Cells[3, 2].Value = "Ngày thực hiện: ";
            xlMarketSheet.Cells[3, 3].Value = scStartDate.DateTime + " - " + scEndDate.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59);

            // Export Market information
            Excel.Range marketHeader = xlMarketSheet.Range[xlMarketSheet.Cells[5, 1], xlMarketSheet.Cells[5, 15]];
            marketHeader.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            marketHeader.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            marketHeader.Font.Bold = true;
            marketHeader.Cells[1, 1].Value = "Mã cửa hàng";
            marketHeader.Cells[1, 2].Value = "Tên cửa hàng";
            marketHeader.Cells[1, 3].Value = "Địa chỉ";

            marketHeader.Cells[1, 4].Value = "Tổng Tiền";
            marketHeader.Cells[1, 5].Value = "Số tiền thanh toán";
            marketHeader.Cells[1, 6].Value = "Số tiền hoàn trả";
            marketHeader.Cells[1, 7].Value = "GAP";

            marketHeader.Cells[1, 8].Value = "Phí giao hàng";
            marketHeader.Cells[1, 9].Value = "Giảm giá";
            marketHeader.Cells[1, 10].Value = "Điểm đã sử dụng";
            marketHeader.Cells[1, 11].Value = "Voucher đã sử dụng";
            marketHeader.Cells[1, 12].Value = "Tổng ban đầu";

            marketHeader.Cells[1, 13].Value = "Thẻ";
            marketHeader.Cells[1, 14].Value = "ATM";
            marketHeader.Cells[1, 15].Value = "COD";

            Excel.Range marketData = xlMarketSheet.Range[xlMarketSheet.Cells[6, 1], xlMarketSheet.Cells[6, 15]];
            marketData.Cells[1, 1].Value = grd_view_store.GetRowCellValue(selRow, "loc_cd").ToString();
            marketData.Cells[1, 2].Value = grd_view_store.GetRowCellValue(selRow, "loc_nm").ToString();
            marketData.Cells[1, 3].Value = grd_view_store.GetRowCellValue(selRow, "loc_addr").ToString();
            marketData.Cells[1, 4].Value = grd_view_store.GetRowCellValue(selRow, "total_amt_real").ToString();
            marketData.Cells[1, 5].Value = grd_view_store.GetRowCellValue(selRow, "total_amt_payment").ToString();
            marketData.Cells[1, 6].Value = grd_view_store.GetRowCellValue(selRow, "total_amt_return").ToString();
            marketData.Cells[1, 7].Value = grd_view_store.GetRowCellValue(selRow, "total_amt_gap").ToString();

            marketData.Cells[1, 8].Value = grd_view_store.GetRowCellValue(selRow, "total_amt_delv").ToString();
            marketData.Cells[1, 9].Value = grd_view_store.GetRowCellValue(selRow, "total_amt_dc").ToString();
            marketData.Cells[1, 10].Value = grd_view_store.GetRowCellValue(selRow, "total_amt_point").ToString();
            marketData.Cells[1, 11].Value = grd_view_store.GetRowCellValue(selRow, "total_amt_voucher").ToString();
            marketData.Cells[1, 12].Value = grd_view_store.GetRowCellValue(selRow, "total_amt").ToString();

            marketData.Cells[1, 13].Value = grd_view_store.GetRowCellValue(selRow, "total_amt_card").ToString();
            marketData.Cells[1, 14].Value = grd_view_store.GetRowCellValue(selRow, "total_amt_atm").ToString();
            marketData.Cells[1, 15].Value = grd_view_store.GetRowCellValue(selRow, "total_amt_cod").ToString();

            Excel.Range formatRange = xlMarketSheet.Range[xlMarketSheet.Cells[6, 4], xlMarketSheet.Cells[6, 15]];
            formatRange.NumberFormat = "#,##0";
            formatRange = xlMarketSheet.Range[xlMarketSheet.Cells[6, 4], xlMarketSheet.Cells[6, 7]];
            formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightCoral);
            formatRange = xlMarketSheet.Range[xlMarketSheet.Cells[6, 8], xlMarketSheet.Cells[6, 12]];
            formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue);
            formatRange = xlMarketSheet.Range[xlMarketSheet.Cells[6, 12], xlMarketSheet.Cells[6, 15]];
            formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

             //Export Details
            int startRow = 9;
            int setRow = startRow;
            Excel.Range itemHeader = xlMarketSheet.Range[xlMarketSheet.Cells[startRow, 1], xlMarketSheet.Cells[startRow, 16]];
            itemHeader.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            itemHeader.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            itemHeader.Font.Bold = true;
            itemHeader.Cells[1, 1].Value = "Mã đơn hàng";
            itemHeader.Cells[1, 2].Value = "Mã khách hàng";
            itemHeader.Cells[1, 3].Value = "Tên khách hàng";
            itemHeader.Cells[1, 4].Value = "Số điện thoại";
            itemHeader.Cells[1, 5].Value = "Hình thức nhận hàng";
            itemHeader.Cells[1, 6].Value = "Phương thức thanh toán";
            itemHeader.Cells[1, 7].Value = "Giá thanh toán";
            itemHeader.Cells[1, 8].Value = "Phí giao hàng";
            itemHeader.Cells[1, 9].Value = "Giảm giá";
            itemHeader.Cells[1, 10].Value = "Điểm sử dụng";
            itemHeader.Cells[1, 11].Value = "Voucher sử dụng";
            itemHeader.Cells[1, 12].Value = "Điểm sự kiện";
            itemHeader.Cells[1, 13].Value = "Coupon sử dụng";
            itemHeader.Cells[1, 14].Value = "Giá sản phẩm";
            itemHeader.Cells[1, 15].Value = "Sản phẩm đã hủy";
            itemHeader.Cells[1, 16].Value = "Hoàn tiền";

            startRow = startRow + 1;

            formatRange = xlMarketSheet.Range[xlMarketSheet.Cells[startRow, 1], xlMarketSheet.Cells[10000, 4]];
            formatRange.NumberFormat = "@";

            for (int i = 0; i < grd_view_ord.RowCount; i++)
            {
                setRow = startRow + i;
                xlMarketSheet.Cells[setRow, 1].Value = grd_view_ord.GetRowCellValue(i, "ord_no").ToString();
                xlMarketSheet.Cells[setRow, 2].Value = grd_view_ord.GetRowCellValue(i, "cust_id").ToString();
                xlMarketSheet.Cells[setRow, 3].Value = grd_view_ord.GetRowCellValue(i, "full_name").ToString();
                xlMarketSheet.Cells[setRow, 4].Value = grd_view_ord.GetRowCellValue(i, "mobile_no").ToString();
                xlMarketSheet.Cells[setRow, 5].Value = grd_view_ord.GetRowCellValue(i, "delv_nm").ToString();
                xlMarketSheet.Cells[setRow, 6].Value = grd_view_ord.GetRowCellValue(i, "pay_nm").ToString();
                xlMarketSheet.Cells[setRow, 7].Value = grd_view_ord.GetRowCellValue(i, "price_real").ToString();
                xlMarketSheet.Cells[setRow, 8].Value = grd_view_ord.GetRowCellValue(i, "price_delv").ToString();
                xlMarketSheet.Cells[setRow, 9].Value = grd_view_ord.GetRowCellValue(i, "price_dc").ToString();
                xlMarketSheet.Cells[setRow, 10].Value = grd_view_ord.GetRowCellValue(i, "price_point").ToString();
                xlMarketSheet.Cells[setRow, 11].Value = grd_view_ord.GetRowCellValue(i, "price_card").ToString();
                xlMarketSheet.Cells[setRow, 12].Value = grd_view_ord.GetRowCellValue(i, "price_event_point").ToString();
                xlMarketSheet.Cells[setRow, 13].Value = grd_view_ord.GetRowCellValue(i, "price_coupon").ToString();
                xlMarketSheet.Cells[setRow, 14].Value = grd_view_ord.GetRowCellValue(i, "price_total").ToString();
                xlMarketSheet.Cells[setRow, 15].Value = grd_view_ord.GetRowCellValue(i, "price_cancel").ToString();
                xlMarketSheet.Cells[setRow, 16].Value = grd_view_ord.GetRowCellValue(i, "ret_price_real").ToString();
            }

            formatRange = xlMarketSheet.Range[xlMarketSheet.Cells[startRow, 7], xlMarketSheet.Cells[setRow, 16]];
            formatRange.NumberFormat = "#,##0";

            xlMarketSheet.UsedRange.Columns.AutoFit();
        }

        private void grd_view_store_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column == grd_view_store.Columns["total_amt_real"] ||
                e.Column == grd_view_store.Columns["total_amt_payment"] ||
                e.Column == grd_view_store.Columns["total_amt_return"] ||
                e.Column == grd_view_store.Columns["total_amt_gap"])
            {
                e.Appearance.BackColor = Color.LightCoral;
            }
            else if (e.Column == grd_view_store.Columns["total_amt_delv"] ||
              e.Column == grd_view_store.Columns["total_amt_dc"] ||
              e.Column == grd_view_store.Columns["total_amt_point"] ||
              e.Column == grd_view_store.Columns["total_amt_voucher"] ||
              e.Column == grd_view_store.Columns["total_amt"])
            {
                e.Appearance.BackColor = Color.LightBlue;
            }
            else if (e.Column == grd_view_store.Columns["total_amt_card"] ||
                e.Column == grd_view_store.Columns["total_amt_atm"] ||
                e.Column == grd_view_store.Columns["total_amt_cod"])
            {
                e.Appearance.BackColor = Color.LightGreen;
            }
        }

        void Print()
        {
            if (grd_view_store.RowCount < 0 || grd_view_store.FocusedRowHandle < 0) return;

            string startDate = scStartDate.DateTime.ToString();
            string endDate = scEndDate.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59).ToString();

            COM.PrintFormats.PrintDailyFinish(grd_view_store, startDate, endDate);
        }
    }
}
