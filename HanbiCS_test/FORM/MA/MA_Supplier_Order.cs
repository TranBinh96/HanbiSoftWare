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
    public partial class MA_Supplier_Order : DevExpress.XtraEditors.XtraUserControl
    {
        public MA_Supplier_Order()
        {
            InitializeComponent();

            InitSearch();
            initGrid();
            initGridDTL();

            Search();
        }

        private void InitSearch()
        { 

            DateTime som = DateTime.Today;
            scStartDate.Value = som.ToString("yyyy-MM-dd");
            scEndDate.Value = som.ToString("yyyy-MM-dd");

            scSupplier.ProcAction.proc = WebUtil.Values.PROC_SQL;
            scSupplier.ProcAction.text = "SELECT supplier_code value, supplier_nm name FROM kmarket.suppliers WHERE use_yn = 'Y' UNION SELECT '' value, 'All' name  ORDER BY name ASC";
            scSupplier.SetDataByProcAction();
        }

        private void initGrid()
        {
            GridOption gridOption = new GridOption();
            gridOption.SetTextColInfo(false, true, true, true, true, false, 1, "supplier_code", "supplier_code", 100, GridOption.Align.right);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 2, "supplier_nm", "supplier_nm", 250, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 3, "supplier_addr", "supplier_addr", 450, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 4, "supplier_tel_no", "supplier_tel_no", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 5, "supplier_email", "supplier_email", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 6, "supplier_manager_nm", "supplier_manager_nm", 250, GridOption.Align.left);

            // Light red
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 7, "total_amt_real", "total_amt_real", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 8, "total_amt_payment", "total_amt_payment", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 9, "total_amt_return", "total_amt_return", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 10, "total_amt_gap", "total_amt_gap", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            // Light Blue
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 11, "total_amt_delv", "total_amt_delv", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 12, "total_amt_dc", "total_amt_dc", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 13, "total_amt_point", "total_amt_point", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 14, "total_amt_voucher", "total_amt_voucher", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 15, "total_amt", "total_amt", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            // Light Green
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 16, "total_amt_card", "total_amt_card", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 17, "total_amt_atm", "total_amt_atm", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, true, false, 18, "total_amt_cod", "total_amt_cod", 150, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.Apply(grd_view_supplier);
        }

        private void initGridDTL()
        {

            GridOption gridOption = new GridOption();
            gridOption.SetTextColInfo(false, true, true, true, true, false, 1, "ord_no", "ord_no", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 2, "cust_id", "cust_id", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 3, "full_name", "full_name", 250, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 4, "mobile_no", "mobile_no", 100, GridOption.Align.left);

            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "price_real", "price_real", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "price_delv", "price_delv", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "price_dc", "price_dc", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "price_point", "price_point", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "price_card", "price_card", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "price_event_point", "price_event_point", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, -1, "price_coupon", "price_coupon", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);

            gridOption.SetTextColInfo(false, true, true, true, true, false, -1, "pay_tp", "pay_tp", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, -1, "pay_info", "pay_info", 100, GridOption.Align.left);

            gridOption.SetTextColInfo(false, true, true, true, true, false, 11, "prod_cd", "prod_cd", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 12, "prod_nm_ko", "prod_nm_ko", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 13, "prod_nm", "prod_nm", 150, GridOption.Align.left);

            gridOption.SetNumberColInfo(false, true, true, true, false, false, 14, "ord_qty", "ord_qty", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 15, "unit_price", "unit_price", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 16, "unit_sale_price", "unit_sale_price", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 17, "price_total", "price_total", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 18, "ret_qty", "ret_qty", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 19, "total_amt_return", "total_amt_return", 120, GridOption.Align.right, 0, true, GridOption.SumType.sum);


            gridOption.Apply(grd_view_order);
        }

        #region Search
        void Search()
        {
            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();
            sql.Append(" CALL hanbibase.get_supplier(#{supplier_code}, #{start_date}, #{end_date})");

            if (String.IsNullOrEmpty(scSupplier.Value.ToString()))
            {
                sql.Clear();
                sql.Append(" CALL hanbibase.get_supplier(NULL, #{start_date}, #{end_date})");
            }
            else
            {
                action.param.Add(scSupplier.FieldName, scSupplier.Value);
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

            if (ds == null)
            {
                grd_supplier.DataSource = null;
                return;
            }

            grd_supplier.DataSource = ds.Tables[0];

            for (int i = 0; i < grd_view_supplier.RowCount; i++)
            {
                grd_view_supplier.FocusedRowHandle = i;

            }
            grd_view_supplier.FocusedRowHandle = 0;
            grd_view_supplier.RefreshData();
        }

        void SearchDTL(int row)
        {
            if (row < 0)
            {
                grd_order.DataSource = null;
                return;
            }

            string supplierCode = grd_view_supplier.GetRowCellValue(row, "supplier_code").ToString();
            if (String.IsNullOrEmpty(supplierCode)) return;

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();

            sql.Append(" CALL hanbibase.get_supplier_dtl(#{supplier_code},#{start_date}, #{end_date})");

            if (scStartDate.DateTime > scEndDate.DateTime)
            {
                DateTime som = DateTime.Today;
                scStartDate.Value = som.ToString("yyyy-MM-dd");
                scEndDate.Value = som.ToString("yyyy-MM-dd");
            }

            action.param.Add("supplier_code", supplierCode);
            action.param.Add(scStartDate.FieldName, scStartDate.DateTime);
            action.param.Add(scEndDate.FieldName, scEndDate.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59));


            action.text = sql.ToString();
            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            grd_order.DataSource = ds.Tables[0];
            grd_view_order.RefreshData();
             
        }
        #endregion




        private void grd_view_supplier_DataSourceChanged(object sender, EventArgs e)
        {
            if (grd_view_supplier.RowCount > 0)
            {
                grd_view_supplier.FocusedRowHandle = 0;
            }
            else
            {
                grd_order.DataSource = null;
            }
        }

        private void grd_view_supplier_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0 || e.FocusedRowHandle >= grd_view_supplier.RowCount) return;
            SearchDTL(e.FocusedRowHandle);

            if (grd_view_order.RowCount <= 0) return;

            
            double total_real = 0;
            double total_product = 0;
            double total_online = 0;
            double total_offline = 0;
            double total_payment = 0;
            double total_return = 0;
            double total_gap = 0;

            double total_delv = 0;
            double total_dc = 0;
            double total_point = 0;
            double total_voucher = 0;
            double total_event_point = 0;
            double total_coupon = 0;

            double total_atm = 0;
            double total_card = 0;
            double total_cod = 0;

            string ordNo = String.Empty;
            string chkOrdNo = String.Empty;
            for (int i = 0; i < grd_view_order.RowCount; i++)
            {
                //total_product = total_product + Double.Parse(grd_view_order.GetRowCellValue(i, "price_total").ToString());
                chkOrdNo = grd_view_order.GetRowCellValue(i, "ord_no").ToString();

                double tmp_product = Double.Parse(grd_view_order.GetRowCellValue(i, "price_total").ToString());
                double tmp_dc = 0;
                double tmp_point = 0;
                double tmp_voucher = 0;
                double tmp_delv = 0;
                double tmp_return = Double.Parse(grd_view_order.GetRowCellValue(i, "total_amt_return").ToString());
                double tmp_real = 0;

                if (ordNo != chkOrdNo)
                {
                    ordNo = chkOrdNo;
                    tmp_dc = 0;
                    tmp_point = 0;
                    tmp_voucher = 0;
                    tmp_delv = 0;
                    tmp_real = 0;

                    JsonRequest request = new JsonRequest();

                    ProcAction action = request.NewAction();
                    action.proc = WebUtil.Values.PROC_SQL;

                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT  IFNULL(COUNT(D.supplier_code), 1) AS number_supplier");
                    sql.Append(" FROM hanbibase.tb_so_order A LEFT JOIN hanbibase.tb_so_order_dtl B on A.ord_no = B.ord_no AND A.ord_id =  B.ord_id");
                    sql.Append(" LEFT JOIN kmarket.products C ON B.prod_cd = C.p_code collate utf8mb4_general_ci");
                    sql.Append(" LEFT JOIN kmarket.suppliers D ON C.supplier_code = D.supplier_code");
                    sql.Append(" WHERE A.ord_no = #{ord_no} AND A.stop_yn = 'N';");

                    action.text = sql.ToString();
                    action.param.Add("ord_no", ordNo);

                    WebClient client = new WebClient();
                    DataSet ds = client.Execute(request);

                    double count = Double.Parse(ds.Tables[0].Rows[0]["number_supplier"].ToString());

                    tmp_dc = Double.Parse(grd_view_order.GetRowCellValue(i, "price_dc").ToString()) / count;
                    tmp_point = Double.Parse(grd_view_order.GetRowCellValue(i, "price_point").ToString()) / count;
                    tmp_voucher = Double.Parse(grd_view_order.GetRowCellValue(i, "price_card").ToString()) / count;
                    tmp_delv = Double.Parse(grd_view_order.GetRowCellValue(i, "price_delv").ToString()) / count;

                    total_dc = total_dc + tmp_dc;
                    total_point = total_point + tmp_point;
                    total_voucher = total_voucher + tmp_voucher;
                    total_delv = total_delv + tmp_delv;
                    tmp_real = tmp_product - tmp_dc - tmp_point - tmp_voucher + tmp_delv;
                }
                else
                {
                    tmp_real = tmp_product;
                }
                total_product = total_product + tmp_product;
                total_return = total_return + tmp_return;
                total_real = total_real + tmp_real;

                if (grd_view_order.GetRowCellValue(i, "pay_tp").ToString() == "offline")
                {
                    total_offline = total_offline + tmp_real;
                }
                if (grd_view_order.GetRowCellValue(i, "pay_tp").ToString() == "online")
                {
                    total_online = total_online + tmp_real;
                }
                if (grd_view_order.GetRowCellValue(i, "pay_info").ToString() == "CARD")
                {
                    total_card = total_card + tmp_real;
                }
                if (grd_view_order.GetRowCellValue(i, "pay_info").ToString() == "ATM")
                {
                    total_atm = total_atm + tmp_real;
                }
                if (grd_view_order.GetRowCellValue(i, "pay_info").ToString() == "COD")
                {
                    total_cod = total_cod + tmp_real;
                }
            }

            grd_view_supplier.SetRowCellValue(e.FocusedRowHandle, "total_amt_real", total_real);
            grd_view_supplier.SetRowCellValue(e.FocusedRowHandle, "total_amt_payment", total_online + total_offline);
            grd_view_supplier.SetRowCellValue(e.FocusedRowHandle, "total_amt_return", total_return);
            grd_view_supplier.SetRowCellValue(e.FocusedRowHandle, "total_amt_gap", total_real - (total_online + total_offline));
            grd_view_supplier.SetRowCellValue(e.FocusedRowHandle, "total_amt_delv", total_delv);
            grd_view_supplier.SetRowCellValue(e.FocusedRowHandle, "total_amt_dc", total_dc);
            grd_view_supplier.SetRowCellValue(e.FocusedRowHandle, "total_amt_voucher", total_voucher);
            grd_view_supplier.SetRowCellValue(e.FocusedRowHandle, "total_amt", total_product);
            grd_view_supplier.SetRowCellValue(e.FocusedRowHandle, "total_amt_card", total_card);
            grd_view_supplier.SetRowCellValue(e.FocusedRowHandle, "total_amt_atm", total_atm);
            grd_view_supplier.SetRowCellValue(e.FocusedRowHandle, "total_amt_cod", total_cod);
            grd_view_order.RefreshData();
        }

        private void grd_view_supplier_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

            if (e.Column == grd_view_supplier.Columns["total_amt_real"] ||
                e.Column == grd_view_supplier.Columns["total_amt_payment"] ||
                e.Column == grd_view_supplier.Columns["total_amt_return"] ||
                e.Column == grd_view_supplier.Columns["total_amt_gap"])
            {
                e.Appearance.BackColor = Color.LightCoral;
            }
            else if (e.Column == grd_view_supplier.Columns["total_amt_delv"] ||
              e.Column == grd_view_supplier.Columns["total_amt_dc"] ||
              e.Column == grd_view_supplier.Columns["total_amt_point"] ||
              e.Column == grd_view_supplier.Columns["total_amt_voucher"] ||
              e.Column == grd_view_supplier.Columns["total_amt"])
            {
                e.Appearance.BackColor = Color.LightBlue;
            }
            else if (e.Column == grd_view_supplier.Columns["total_amt_card"] ||
                e.Column == grd_view_supplier.Columns["total_amt_atm"] ||
                e.Column == grd_view_supplier.Columns["total_amt_cod"])
            {
                e.Appearance.BackColor = Color.LightGreen;
            }
        }

        private void btnExport_HbClick(object sender, EventArgs e)
        {
            if (grd_view_supplier.RowCount < 0 || grd_view_supplier.FocusedRowHandle < 0) return;

            int selRow = grd_view_supplier.FocusedRowHandle;

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;

            xlApp = new Excel.Application();
            xlApp.Visible = false;
            xlApp.DisplayAlerts = false;

            xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
            for (int i = 0; i < grd_view_supplier.RowCount; i++)
            {
                grd_view_supplier.FocusedRowHandle = i;
                ExportExcel(i, xlWorkBook);
            }
            grd_view_supplier.FocusedRowHandle = selRow;

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
            xlMarketSheet.Name = grd_view_supplier.GetRowCellValue(selRow, "supplier_nm").ToString();

            xlMarketSheet.Cells[1, 2].Value = "Nhân viên: ";
            xlMarketSheet.Cells[1, 3].Value = COM.UserInfo.UserName;
            xlMarketSheet.Cells[2, 2].Value = "Ngày thực hiện: ";
            xlMarketSheet.Cells[2, 3].Value = scStartDate.DateTime + " - " + scEndDate.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59);

            // Export Market information
            Excel.Range marketHeader = xlMarketSheet.Range[xlMarketSheet.Cells[5, 1], xlMarketSheet.Cells[5, 18]];
            marketHeader.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            marketHeader.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            marketHeader.Font.Bold = true;
            marketHeader.Cells[1, 1].Value = "Mã nhà cung cấp";
            marketHeader.Cells[1, 2].Value = "Tên nhà cung cấp";
            marketHeader.Cells[1, 3].Value = "Địa chỉ";
            marketHeader.Cells[1, 4].Value = "Liên hệ";
            marketHeader.Cells[1, 5].Value = "Email";
            marketHeader.Cells[1, 6].Value = "Người quản lý";

            marketHeader.Cells[1, 7].Value = "Tổng Tiền";
            marketHeader.Cells[1, 8].Value = "Số tiền thanh toán";
            marketHeader.Cells[1, 9].Value = "Số tiền hoàn trả";
            marketHeader.Cells[1, 10].Value = "GAP";

            marketHeader.Cells[1, 11].Value = "Phí giao hàng";
            marketHeader.Cells[1, 12].Value = "Giảm giá";
            marketHeader.Cells[1, 13].Value = "Điểm đã sử dụng";
            marketHeader.Cells[1, 14].Value = "Voucher đã sử dụng";
            marketHeader.Cells[1, 15].Value = "Tổng ban đầu";

            marketHeader.Cells[1, 16].Value = "Thẻ";
            marketHeader.Cells[1, 17].Value = "ATM";
            marketHeader.Cells[1, 18].Value = "COD";

            Excel.Range formatRange = xlMarketSheet.Range[xlMarketSheet.Cells[6, 7], xlMarketSheet.Cells[6, 18]];
            formatRange.NumberFormat = "#,##0";
            formatRange = xlMarketSheet.Range[xlMarketSheet.Cells[6, 1], xlMarketSheet.Cells[6, 6]];
            formatRange.NumberFormat = "@";


            Excel.Range marketData = xlMarketSheet.Range[xlMarketSheet.Cells[6, 1], xlMarketSheet.Cells[6, 15]];
            marketData.Cells[1, 1].Value = grd_view_supplier.GetRowCellValue(selRow, "supplier_code").ToString();
            marketData.Cells[1, 2].Value = grd_view_supplier.GetRowCellValue(selRow, "supplier_nm").ToString();
            marketData.Cells[1, 3].Value = grd_view_supplier.GetRowCellValue(selRow, "supplier_addr").ToString();
            marketData.Cells[1, 4].Value = grd_view_supplier.GetRowCellValue(selRow, "supplier_tel_no").ToString();
            marketData.Cells[1, 5].Value = grd_view_supplier.GetRowCellValue(selRow, "supplier_email").ToString();
            marketData.Cells[1, 6].Value = grd_view_supplier.GetRowCellValue(selRow, "supplier_manager_nm").ToString();

            marketData.Cells[1, 7].Value = grd_view_supplier.GetRowCellValue(selRow, "total_amt_real").ToString();
            marketData.Cells[1, 8].Value = grd_view_supplier.GetRowCellValue(selRow, "total_amt_payment").ToString();
            marketData.Cells[1, 9].Value = grd_view_supplier.GetRowCellValue(selRow, "total_amt_return").ToString();
            marketData.Cells[1, 10].Value = grd_view_supplier.GetRowCellValue(selRow, "total_amt_gap").ToString();

            marketData.Cells[1, 11].Value = grd_view_supplier.GetRowCellValue(selRow, "total_amt_delv").ToString();
            marketData.Cells[1, 12].Value = grd_view_supplier.GetRowCellValue(selRow, "total_amt_dc").ToString();
            marketData.Cells[1, 13].Value = grd_view_supplier.GetRowCellValue(selRow, "total_amt_point").ToString();
            marketData.Cells[1, 14].Value = grd_view_supplier.GetRowCellValue(selRow, "total_amt_voucher").ToString();
            marketData.Cells[1, 15].Value = grd_view_supplier.GetRowCellValue(selRow, "total_amt").ToString();

            marketData.Cells[1, 16].Value = grd_view_supplier.GetRowCellValue(selRow, "total_amt_card").ToString();
            marketData.Cells[1, 17].Value = grd_view_supplier.GetRowCellValue(selRow, "total_amt_atm").ToString();
            marketData.Cells[1, 18].Value = grd_view_supplier.GetRowCellValue(selRow, "total_amt_cod").ToString();



            formatRange = xlMarketSheet.Range[xlMarketSheet.Cells[6, 7], xlMarketSheet.Cells[6, 10]];
            formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightCoral);
            formatRange = xlMarketSheet.Range[xlMarketSheet.Cells[6, 11], xlMarketSheet.Cells[6, 15]];
            formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue);
            formatRange = xlMarketSheet.Range[xlMarketSheet.Cells[6, 16], xlMarketSheet.Cells[6, 18]];
            formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

            // Export Details
            int startRow = 9;
            int setRow = startRow;
            Excel.Range itemHeader = xlMarketSheet.Range[xlMarketSheet.Cells[startRow, 1], xlMarketSheet.Cells[startRow, 13]];
            itemHeader.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
            itemHeader.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            itemHeader.Font.Bold = true;
            itemHeader.Cells[1, 1].Value = "Số đặt hàng";
            itemHeader.Cells[1, 2].Value = "ID khách hàng";
            itemHeader.Cells[1, 3].Value = "Tên khách hàng";
            itemHeader.Cells[1, 4].Value = "Số di động";
            itemHeader.Cells[1, 5].Value = "Mã sản phẩm";
            itemHeader.Cells[1, 6].Value = "Tên sản phẩm (ko)";
            itemHeader.Cells[1, 7].Value = "Tên sản phẩm (vi)";
            itemHeader.Cells[1, 8].Value = "Số lượng đặt hàng";
            itemHeader.Cells[1, 9].Value = "Đơn giá";
            itemHeader.Cells[1, 10].Value = "Đơn giá bán";
            itemHeader.Cells[1, 11].Value = "Tổng giá sản phẩm";
            itemHeader.Cells[1, 12].Value = "Số lượng trả hàng";
            itemHeader.Cells[1, 13].Value = "Tổng trả hàng";

            startRow = startRow + 1;

            formatRange = xlMarketSheet.Range[xlMarketSheet.Cells[startRow, 1], xlMarketSheet.Cells[10000, 7]];
            formatRange.NumberFormat = "@";

            for (int i = 0; i < grd_view_order.RowCount; i++)
            {
                setRow = startRow + i;
                xlMarketSheet.Cells[setRow, 1].Value = grd_view_order.GetRowCellValue(i, "ord_no").ToString();
                xlMarketSheet.Cells[setRow, 2].Value = grd_view_order.GetRowCellValue(i, "cust_id").ToString();
                xlMarketSheet.Cells[setRow, 3].Value = grd_view_order.GetRowCellValue(i, "full_name").ToString();
                xlMarketSheet.Cells[setRow, 4].Value = grd_view_order.GetRowCellValue(i, "mobile_no").ToString();
                xlMarketSheet.Cells[setRow, 5].Value = grd_view_order.GetRowCellValue(i, "prod_cd").ToString();
                xlMarketSheet.Cells[setRow, 6].Value = grd_view_order.GetRowCellValue(i, "prod_nm_ko").ToString();
                xlMarketSheet.Cells[setRow, 7].Value = grd_view_order.GetRowCellValue(i, "prod_nm").ToString();
                xlMarketSheet.Cells[setRow, 8].Value = grd_view_order.GetRowCellValue(i, "ord_qty").ToString();
                xlMarketSheet.Cells[setRow, 9].Value = grd_view_order.GetRowCellValue(i, "unit_price").ToString();
                xlMarketSheet.Cells[setRow, 10].Value = grd_view_order.GetRowCellValue(i, "unit_sale_price").ToString();
                xlMarketSheet.Cells[setRow, 11].Value = grd_view_order.GetRowCellValue(i, "price_total").ToString();
                xlMarketSheet.Cells[setRow, 12].Value = grd_view_order.GetRowCellValue(i, "ret_qty").ToString();
                xlMarketSheet.Cells[setRow, 13].Value = grd_view_order.GetRowCellValue(i, "total_amt_return").ToString();
            }

            formatRange = xlMarketSheet.Range[xlMarketSheet.Cells[startRow, 8], xlMarketSheet.Cells[setRow, 13]];
            formatRange.NumberFormat = "#,##0";

            xlMarketSheet.UsedRange.Columns.AutoFit();
        }

        private void grd_view_supplier_DoubleClick(object sender, EventArgs e)
        {
            if (grd_view_supplier.RowCount < 0) return;
            scSupplier.Value = grd_view_supplier.GetRowCellValue(grd_view_supplier.FocusedRowHandle, "supplier_code").ToString();
            Search();
        }

    }
}
