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
    public partial class MA_Report_General : DevExpress.XtraEditors.XtraUserControl
    {
        private string strLocCode = String.Empty;
        public MA_Report_General()
        {
            InitializeComponent();

            InitSearch();
            initGrid();

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
            gridOption.SetTextColInfo(false, true, true, true, true, false, 2, "loc_nm", "loc_nm", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, -1, "loc_addr", "loc_addr", 450, GridOption.Align.left);

            gridOption.SetTextColInfo(false, true, true, true, true, false, 4, "ord_no", "ord_no", 80, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, -1, "cust_id", "cust_id", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 6, "full_name", "full_name", 200, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 7, "mobile_no", "mobile_no", 100, GridOption.Align.left);
            //Payment and Shipping Infor
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "delv_tp", "delv_tp", 50, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 8, "delv_nm", "delv_nm", 120, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "pay_tp", "pay_tp", 100, GridOption.Align.center);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 9, "pay_nm", "pay_nm", 100, GridOption.Align.center);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 10, "price_real", "price_real", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 11, "price_dc", "price_dc", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 12, "price_delv", "price_delv", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 13, "price_point", "price_point", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 14, "price_card", "price_card", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 15, "price_event_point", "price_event_point", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 16, "price_coupon", "price_coupon", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 17, "price_total", "price_total", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 18, "price_cancel", "price_cancel", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 19, "total_amt_return", "ret_price_real", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            // Product
            gridOption.SetTextColInfo(false, true, true, true, true, false, 20, "prod_cd", "prod_cd", 110, GridOption.Align.left);
            gridOption.SetTextColInfo(false, false, true, true, false, false, 21, "prod_nm_ko", "prod_nm_ko", 250, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 22, "prod_nm", "prod_nm", 250, GridOption.Align.left);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 23, "ord_qty", "ord_qty", 100, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 24, "unit_price", "unit_price", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 25, "unit_sale_price", "unit_sale_price", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 26, "unit_delv_price", "unit_delv_price", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.Apply(gridViewReport);
        }
        
        #region Search
        /// <summary>
        /// 
        /// </summary>
        void Search()
        {
            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT A.loc_cd, F.loc_nm, F.loc_addr, A.ord_no, A.cust_id, A.full_name, A.mobile_no,");
            sql.Append(" A.delv_tp, D.delv_nm, A.pay_tp, C.pay_nm,");
            sql.Append(" A.price_total, A.price_delv, A.price_point, A.price_card, A.price_real, A.price_event_point, A.price_coupon, A.price_cancel, G.ret_price_real,");
            sql.Append(" (A.price_total + A.price_delv - A.price_real - A.price_point - A.price_card - A.price_event_point - A.price_coupon) AS price_dc,");    // price_dc
            sql.Append(" B.prod_cd, E.prod_nm_ko, E.prod_nm, E.unit,");
            sql.Append(" B.ord_qty, B.unit_price , B.unit_sale_price, B.unit_delv_price");
            sql.Append(" FROM hanbibase.tb_so_order A");
            sql.Append(" LEFT JOIN hanbibase.tb_so_order_dtl B ON A.ord_no = B.ord_no AND A.ord_id = B.ord_id");
            sql.Append(" LEFT JOIN (SELECT cd as pay_tp, cd_nm as pay_nm FROM hanbibase.tb_sys_code WHERE grp_cd = 'PAY_TP') C ON A.pay_tp = C.pay_tp ");
            sql.Append(" LEFT JOIN (SELECT cd as delv_tp, cd_nm as delv_nm FROM hanbibase.tb_sys_code WHERE grp_cd = 'DELV_TP') D ON A.delv_tp = D.delv_tp");
            sql.Append(" LEFT JOIN hanbibase.tb_ma_product E ON B.prod_cd = E.prod_cd ");
            sql.Append(" LEFT JOIN hanbibase.tb_ma_pickup_loc F ON A.loc_cd = F.loc_cd ");
            sql.Append(" LEFT JOIN hanbibase.tb_so_return G ON A.ord_no = G.ord_no AND A.ord_id = G.ord_id ");

            sql.Append(" WHERE (A.up_dt BETWEEN #{start_date} AND #{end_date}) ");
            sql.Append(" AND A.delv_yn = 'Y'");

            getLocCode();
            if (COM.UserInfo.RoleID == "1")
            {
                sql.Append(" AND A.loc_cd = #{loc_cd}");
                action.param.Add("loc_cd", COM.UserInfo.LocCode);
            }
            else if (!String.IsNullOrEmpty(scLocation.Text) && !String.IsNullOrEmpty(strLocCode))
            {
                sql.Append(" AND A.loc_cd = #{loc_cd}");
                action.param.Add("loc_cd", strLocCode);
            }
            else

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

            gridReport.DataSource = ds.Tables[0];
            gridViewReport.RefreshData();
        }

        #endregion

        private void gridViewReport_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;
        }

        private void gridViewReport_DataSourceChanged(object sender, EventArgs e)
        {
            if (gridViewReport.RowCount > 0)
            {
                btnExport.Enabled = true;
                gridViewReport.FocusedRowHandle = 0;
            }
            else
            {
                btnExport.Enabled = false;
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

        private void ExportExcel(Excel.Workbook xlWorkBook)
        {

            Excel.Worksheet xlMarketSheet;
            xlMarketSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.ActiveSheet;

            xlMarketSheet.Cells[1, 2].Value = "Nhân viên: ";
            xlMarketSheet.Cells[1, 3].Value = COM.UserInfo.UserName;
            xlMarketSheet.Cells[2, 2].Value = "Cửa hàng: ";
            xlMarketSheet.Cells[2, 3].Value = COM.UserInfo.LocName;
            xlMarketSheet.Cells[3, 2].Value = "Ngày thực hiện: ";
            xlMarketSheet.Cells[3, 3].Value = scStartDate.DateTime + " - " + scEndDate.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59);

            // Export Market information
            Excel.Range marketHeader = xlMarketSheet.Range[xlMarketSheet.Cells[5, 1], xlMarketSheet.Cells[5, 26]];
            marketHeader.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            marketHeader.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            marketHeader.Font.Bold = true;
            marketHeader.Cells[1, 1].Value = "Mã cửa hàng";
            marketHeader.Cells[1, 2].Value = "Tên cửa hàng";
            marketHeader.Cells[1, 3].Value = "Địa chỉ cửa hàng";

            marketHeader.Cells[1, 4].Value = "Mã đơn hàng";
            marketHeader.Cells[1, 5].Value = "ID Khách hàng";
            marketHeader.Cells[1, 6].Value = "Tên khách hàng";
            marketHeader.Cells[1, 7].Value = "Số điện thoại";
            marketHeader.Cells[1, 8].Value = "Hình thức nhận hàng";
            marketHeader.Cells[1, 9].Value = "Phương thức thanh toán";
            marketHeader.Cells[1, 10].Value = "Giá thanh toán";
            marketHeader.Cells[1, 11].Value = "Giảm giá";
            marketHeader.Cells[1, 12].Value = "Phí giao hàng";
            marketHeader.Cells[1, 13].Value = "Điểm sử dụng";
            marketHeader.Cells[1, 14].Value = "Voucher sử dụng";
            marketHeader.Cells[1, 15].Value = "Điểm sự kiện";
            marketHeader.Cells[1, 16].Value = "Coupon sử dụng";
            marketHeader.Cells[1, 17].Value = "Giá sản phẩm";
            marketHeader.Cells[1, 18].Value = "Sản phẩm đã hủy";
            marketHeader.Cells[1, 19].Value = "Hoàn tiền";

            marketHeader.Cells[1, 20].Value = "Mã sản phẩm";
            marketHeader.Cells[1, 21].Value = "Tên sản phẩm (ko)";
            marketHeader.Cells[1, 22].Value = "Tên sản phẩm (vi)";
            marketHeader.Cells[1, 23].Value = "Số lượng";
            marketHeader.Cells[1, 24].Value = "Đơn giá";
            marketHeader.Cells[1, 25].Value = "Đơn giá bán";
            marketHeader.Cells[1, 26].Value = "Đơn giá giao hàng";

            Excel.Range formatRange = xlMarketSheet.Range[xlMarketSheet.Cells[6, 3], xlMarketSheet.Cells[10000, 7]];
            formatRange.NumberFormat = "@";

            formatRange = xlMarketSheet.Range[xlMarketSheet.Cells[6, 18], xlMarketSheet.Cells[10000, 18]];
            formatRange.NumberFormat = "@";

            int startRow = 6;
            int setRow = startRow;
            for (int i = 0; i < gridViewReport.RowCount; i++)
            {
                setRow = startRow + i;
                xlMarketSheet.Cells[setRow, 1].Value = gridViewReport.GetRowCellValue(i, "loc_cd").ToString();
                xlMarketSheet.Cells[setRow, 2].Value = gridViewReport.GetRowCellValue(i, "loc_nm").ToString();
                xlMarketSheet.Cells[setRow, 3].Value = gridViewReport.GetRowCellValue(i, "loc_addr").ToString();

                xlMarketSheet.Cells[setRow, 4].Value = gridViewReport.GetRowCellValue(i, "ord_no").ToString();
                xlMarketSheet.Cells[setRow, 5].Value = gridViewReport.GetRowCellValue(i, "cust_id").ToString();
                xlMarketSheet.Cells[setRow, 6].Value = gridViewReport.GetRowCellValue(i, "full_name").ToString();
                xlMarketSheet.Cells[setRow, 7].Value = gridViewReport.GetRowCellValue(i, "mobile_no").ToString();
                xlMarketSheet.Cells[setRow, 8].Value = gridViewReport.GetRowCellValue(i, "delv_nm").ToString();
                xlMarketSheet.Cells[setRow, 9].Value = gridViewReport.GetRowCellValue(i, "pay_nm").ToString();
                xlMarketSheet.Cells[setRow, 10].Value = gridViewReport.GetRowCellValue(i, "price_real").ToString();
                xlMarketSheet.Cells[setRow, 11].Value = gridViewReport.GetRowCellValue(i, "price_dc").ToString();
                xlMarketSheet.Cells[setRow, 12].Value = gridViewReport.GetRowCellValue(i, "price_delv").ToString();
                xlMarketSheet.Cells[setRow, 13].Value = gridViewReport.GetRowCellValue(i, "price_point").ToString();
                xlMarketSheet.Cells[setRow, 14].Value = gridViewReport.GetRowCellValue(i, "price_card").ToString();
                xlMarketSheet.Cells[setRow, 15].Value = gridViewReport.GetRowCellValue(i, "price_event_point").ToString();
                xlMarketSheet.Cells[setRow, 16].Value = gridViewReport.GetRowCellValue(i, "price_coupon").ToString();
                xlMarketSheet.Cells[setRow, 17].Value = gridViewReport.GetRowCellValue(i, "price_total").ToString();
                xlMarketSheet.Cells[setRow, 18].Value = gridViewReport.GetRowCellValue(i, "price_cancel").ToString();
                xlMarketSheet.Cells[setRow, 19].Value = gridViewReport.GetRowCellValue(i, "ret_price_real").ToString();

                xlMarketSheet.Cells[setRow, 20].Value = gridViewReport.GetRowCellValue(i, "prod_cd").ToString();
                xlMarketSheet.Cells[setRow, 21].Value = gridViewReport.GetRowCellValue(i, "prod_nm_ko").ToString();
                xlMarketSheet.Cells[setRow, 22].Value = gridViewReport.GetRowCellValue(i, "prod_nm").ToString();
                xlMarketSheet.Cells[setRow, 23].Value = gridViewReport.GetRowCellValue(i, "ord_qty").ToString();
                xlMarketSheet.Cells[setRow, 24].Value = gridViewReport.GetRowCellValue(i, "unit_price").ToString();
                xlMarketSheet.Cells[setRow, 25].Value = gridViewReport.GetRowCellValue(i, "unit_sale_price").ToString();
                xlMarketSheet.Cells[setRow, 26].Value = gridViewReport.GetRowCellValue(i, "unit_delv_price").ToString();
            }

            formatRange = xlMarketSheet.Range[xlMarketSheet.Cells[startRow, 10], xlMarketSheet.Cells[setRow, 19]];
            formatRange.NumberFormat = "#,##0";

            formatRange = xlMarketSheet.Range[xlMarketSheet.Cells[startRow, 23], xlMarketSheet.Cells[setRow, 26]];
            formatRange.NumberFormat = "#,##0";

            xlMarketSheet.UsedRange.Columns.AutoFit();
        }

        private void grd_view_store_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column == gridViewReport.Columns["total_amt_real"] ||
                e.Column == gridViewReport.Columns["total_amt_payment"] ||
                e.Column == gridViewReport.Columns["total_amt_gap"])
            {
                e.Appearance.BackColor = Color.LightCoral;
            }
            else if (e.Column == gridViewReport.Columns["total_amt_delv"] ||
              e.Column == gridViewReport.Columns["total_amt_point"] ||
              e.Column == gridViewReport.Columns["total_amt_voucher"] ||
              e.Column == gridViewReport.Columns["total_amt"])
            {
                e.Appearance.BackColor = Color.LightBlue;
            }
            else if (e.Column == gridViewReport.Columns["total_amt_card"] ||
                e.Column == gridViewReport.Columns["total_amt_atm"] ||
                e.Column == gridViewReport.Columns["total_amt_cod"] )
            {
                e.Appearance.BackColor = Color.LightGreen;
            }
        }

        private void btnExport_HbClick(object sender, EventArgs e)
        {
            if (gridViewReport.RowCount < 0 || gridViewReport.FocusedRowHandle < 0) return;

            int selRow = gridViewReport.FocusedRowHandle;

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;

            xlApp = new Excel.Application();
            xlApp.Visible = false;
            xlApp.DisplayAlerts = false;

            xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
            ExportExcel(xlWorkBook);

            xlWorkBook.Worksheets[1].Activate();
            xlApp.Visible = true;
            xlApp.DisplayAlerts = true; 
        }

        private void gridViewReport_DoubleClick(object sender, EventArgs e)
        {
            if (gridViewReport.RowCount < 0) return;
            scLocation.Text = gridViewReport.GetRowCellValue(gridViewReport.FocusedRowHandle, "loc_nm").ToString();
            Search();
        }
    }
}
