using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace COM
{
    public class PrintFormats
    {
        public static void PrintDelivery(string ordNo)
        {

            JsonRequest request = new JsonRequest();

            ProcAction headerAction = request.NewAction();
            headerAction.proc = WebUtil.Values.PROC_SQL;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT A.delv_id, A.delv_no, A.ord_id, A.ord_no, A.loc_cd,");
            sql.Append(" B.loc_nm, A.cust_id, A.full_name, DATE_FORMAT(A.ord_dt, '%Y-%m-%d %T') ord_dt, A.email, A.mobile_no,");
            sql.Append(" A.tel_no, A.delv_tp, D.delv_nm, DATE_FORMAT(A.delv_dt, '%Y-%m-%d %H:%i') delv_dt, A.pay_tp, C.pay_nm, A.pay_info, A.ship_post_cd,");
            sql.Append(" A.ship_addr, A.ship_addr_dtl, A.price_total, A.price_delv, A.price_point, A.price_card, A.price_real, A.price_cancel,");
            sql.Append(" (A.price_total + A.price_delv - A.price_real - A.price_point - A.price_card - A.price_event_point - A.price_coupon) AS price_dc,");       // price_dc
            sql.Append(" A.delv_yn");
            sql.Append(" FROM tb_so_delv A");
            sql.Append(" LEFT JOIN tb_ma_pickup_loc B ON A.loc_cd = B.loc_cd ");
            sql.Append(" LEFT JOIN (SELECT cd as pay_tp, cd_nm as pay_nm FROM tb_sys_code WHERE grp_cd = 'PAY_TP') C ON A.pay_tp = C.pay_tp ");
            sql.Append(" LEFT JOIN (SELECT cd as delv_tp, cd_nm as delv_nm FROM tb_sys_code WHERE grp_cd = 'DELV_TP') D ON A.delv_tp = D.delv_tp ");
            sql.Append(" WHERE A.ord_no = #{ord_no}");
            headerAction.text = sql.ToString();
            headerAction.param.Add("ord_no", ordNo);

            ProcAction detailAction = request.NewAction();
            detailAction.proc = WebUtil.Values.PROC_SQL;
            sql.Clear();
            sql.Append("SELECT A.delv_dtl_id, A.delv_id, A.delv_no, A.delv_seq, A.prod_cd,");
            sql.Append(" B.prod_nm_ko, B.prod_nm_en, B.prod_nm, A.unit, A.ord_qty, A.pick_qty,");
            sql.Append(" A.unit_price, A.unit_sale_price, A.unit_delv_price");
            sql.Append(" FROM tb_so_delv_dtl A ");
            sql.Append(" LEFT JOIN tb_ma_product B ON A.prod_cd = B.prod_cd ");
            sql.Append(" WHERE A.ord_no = #{ord_no}");
            sql.Append(" ORDER BY A.ord_dtl_id");
            detailAction.text = sql.ToString();
            detailAction.param.Add("ord_no", ordNo);

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            DataTable dtHeader = ds.Tables[0];
            DataTable dtDtl = ds.Tables[1];

            string delvType = dtHeader.Rows[0]["delv_tp"].ToString();
            string payType = dtHeader.Rows[0]["pay_tp"].ToString();
            double priceTotal = Double.Parse(dtHeader.Rows[0]["price_total"].ToString());
            string strPriceTotal = priceTotal == 0 ? "0" : String.Format("{0:#,###}", priceTotal);
            double pricePoint = Double.Parse(dtHeader.Rows[0]["price_point"].ToString());
            string strPricePoint = pricePoint == 0 ? "0" : String.Format("{0:#,###}", pricePoint);
            double priceCard = Double.Parse(dtHeader.Rows[0]["price_card"].ToString());
            string strPriceCard = priceCard == 0 ? "0" : String.Format("{0:#,###}", priceCard);
            double priceCoupon = 0;
            string strPriceCoupon = priceCoupon == 0 ? "0" : String.Format("{0:#,###}", priceCoupon);
            double priceDelv = Double.Parse(dtHeader.Rows[0]["price_delv"].ToString());
            string strPriceDelv = priceDelv == 0 ? "0" : String.Format("{0:#,###}", priceDelv);
            double priceReal = Double.Parse(dtHeader.Rows[0]["price_real"].ToString());
            string strPriceReal = priceReal == 0 ? "0" : String.Format("{0:#,###}", priceReal);
            double priceAll = priceReal - priceDelv;
            string strPriceAlll = priceAll == 0 ? "0" : String.Format("{0:#,###}", priceAll);

            double priceCancel = Double.Parse(dtHeader.Rows[0]["price_cancel"].ToString());
            string strPriceCancel = priceCancel == 0 ? "0" : String.Format("{0:#,###}", priceCancel);
            double priceDC = Double.Parse(dtHeader.Rows[0]["price_dc"].ToString());
            string strPriceDC = priceDC == 0 ? "0" : String.Format("{0:#,###}", priceDC);

            PrintDocument doc = new PrintDocument();
            doc.PrinterSettings.PrinterName = COM.RawPrinterHelper.printerName;
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);

            try
            {
                string str = "";

                if (delvType == "D")
                {
                    str = "Hoa don (Khach hang luu tru)\n";
                    str += "영수증(고객보관용)\n";
                }
                else
                {
                    str = "Bien lai don dat hang (Khach hang luu tru)\n";
                    str += "픽업 주문 영수증(고객보관용)\n";
                }
                str += "------------------------------------------\n";
                str += "Cua hang/매장명 : " + COM.CommonUtils.RemoveDiacritics(COM.UserInfo.LocName) + "\n";
                str += "Dia chi/매장 주소 : " + COM.CommonUtils.RemoveDiacritics(COM.UserInfo.LocAddr) + "\n";
                str += "SDT cua hang/매장 전화 : " + COM.CommonUtils.RemoveDiacritics(COM.UserInfo.LocTelNo) + "\n";
                str += "------------------------------------------\n";
                str += "Ma sp              So luong       Gia tien\n";
                str += "------------------------------------------\n";

                for (int i = 0; i < dtDtl.Rows.Count; i++)
                {
                    string procNmKo = COM.CommonUtils.RemoveDiacritics(dtDtl.Rows[i]["prod_nm_ko"].ToString());
                    str += procNmKo + "\n";
                    string procNm = COM.CommonUtils.RemoveDiacritics(dtDtl.Rows[i]["prod_nm"].ToString());
                    str += procNm + "\n";
                    string prodCd = dtDtl.Rows[i]["prod_cd"].ToString();
                    //double qty = Double.Parse(dtDtl.Rows[i]["ord_qty"].ToString());
                    double qty = Double.Parse(dtDtl.Rows[i]["pick_qty"].ToString());
                    string ordQty = String.Format("{0:#,###}", qty);
                    double amt = Double.Parse(dtDtl.Rows[i]["unit_sale_price"].ToString());
                    string sumAmt = String.Format("{0:#,###}", (amt * qty));

                    str += prodCd.PadRight(17, ' ') + ordQty.PadLeft(10, ' ') + sumAmt.PadLeft(15, ' ') + "\n";
                }
                str += "------------------------------------------\n";
                str += "So tien sp/상품금액 : " + strPriceTotal.PadLeft(20, ' ') + "\n";
                if (strPriceDC != "0")
                    str += "Giam gia/할인 : " + strPriceDC.PadLeft(26, ' ') + "\n";
                if(strPricePoint != "0")
                    str += "Giam bang diem/포인트 : " + strPricePoint.PadLeft(18, ' ') + "\n";
                if (strPriceCard != "0")
                str += "Giam bang voucher/상품권 : " + strPriceCard.PadLeft(15, ' ') + "\n";
                if (strPriceCoupon != "0")
                str += "Giam gia coupon/쿠폰 : " + strPriceCoupon.PadLeft(19, ' ') + "\n";
                str += "Tong so tien tt/총결제금액 : " + strPriceAlll.PadLeft(13, ' ') + "\n";
                if (strPriceDelv != "0")
                str += "Phi van chuyen/배달비 : " + strPriceDelv.PadLeft(18, ' ') + "\n";
                str += "So tien tt cuoi cung/합계 : " + strPriceReal.PadLeft(14, ' ') + "\n";
                if(strPriceCancel != "0")
                    str += "So tien tra lai KH/고객 반환 : " + strPriceCancel.PadLeft(11, ' ') + "\n";
                if(payType == "offline")
                    str += "Thanh toan khong thanh cong/결제 미완료\n";
                else
                    str += "Thanh toan thanh cong/결제 완료\n";
                str += "------------------------------------------\n";
                str += "■ Thong tin giao hang\n";
                str += "Phuong thuc tt/결제수단 : " + (dtHeader.Rows[0]["pay_info"].ToString() == "COD"? "Tien mat" : "The VISA") + "\n";
                str += "So don hang/주문번호 : " + ordNo + "\n";
                str += "Thoi gian dat/주문 : " + dtHeader.Rows[0]["ord_dt"].ToString() + "\n";
                str += "Nguoi nhan hang/수취인 : " + COM.CommonUtils.RemoveDiacritics(dtHeader.Rows[0]["full_name"].ToString()) + "\n";
                str += "So dien thoai/전화 번호 : " + dtHeader.Rows[0]["mobile_no"].ToString() + "\n";
                str += "Thoi gian giao/배송시간 : " + dtHeader.Rows[0]["delv_dt"].ToString() + "\n";
                str += "Dia chi/주소 : " + COM.CommonUtils.RemoveVietnameseChar(COM.CommonUtils.RemoveDiacritics(dtHeader.Rows[0]["ship_addr"].ToString())) + "\n";
                str += COM.CommonUtils.RemoveVietnameseChar(COM.CommonUtils.RemoveDiacritics(dtHeader.Rows[0]["ship_addr_dtl"].ToString())) + "\n";
                str += "                                                                                                                  \n";
                //str += "                                                                                                                  \n";
                COM.RawPrinterHelper.SendStringToPrinter(COM.RawPrinterHelper.printerName, str);
                COM.RawPrinterHelper.PrintBarcode("&"+ordNo);
                doc.Print();


                if (delvType == "D")
                {
                    str = "Hoa don (Nha cung cap luu tru)\n";
                    str += "영수증(공급사보관용)\n";
                }
                else
                {
                    str = "Bien lai don hang pickup (Nha cung cap luu tru)\n";
                    str += "픽업 주문 영수증(공급사보관용)\n";
                }
                str += "------------------------------------------\n";
                str += "Cua hang/매장명 : " + COM.CommonUtils.RemoveDiacritics(COM.UserInfo.LocName) + "\n";
                str += "Dia chi/매장 주소 : " + COM.CommonUtils.RemoveDiacritics(COM.UserInfo.LocAddr) + "\n";
                str += "SDT cua hang/매장 전화 : " + COM.CommonUtils.RemoveDiacritics(COM.UserInfo.LocTelNo) + "\n";
                str += "------------------------------------------\n";
                str += "Ma sp              So luong       Gia tien\n";
                str += "------------------------------------------\n";

                for (int i = 0; i < dtDtl.Rows.Count; i++)
                {
                    string procNmKo = COM.CommonUtils.RemoveDiacritics(dtDtl.Rows[i]["prod_nm_ko"].ToString());
                    str += procNmKo + "\n";
                    string procNm = COM.CommonUtils.RemoveDiacritics(dtDtl.Rows[i]["prod_nm"].ToString());
                    str += procNm + "\n";
                    string prodCd = dtDtl.Rows[i]["prod_cd"].ToString();
                    //double qty = Double.Parse(dtDtl.Rows[i]["ord_qty"].ToString());
                    double qty = Double.Parse(dtDtl.Rows[i]["pick_qty"].ToString());
                    string ordQty = String.Format("{0:#,###}", qty);
                    double amt = Double.Parse(dtDtl.Rows[i]["unit_sale_price"].ToString());
                    string sumAmt = String.Format("{0:#,###}", (amt * qty));

                    str += prodCd.PadRight(17, ' ') + ordQty.PadLeft(10, ' ') + sumAmt.PadLeft(15, ' ') + "\n";
                }
                str += "------------------------------------------\n";
                str += "So tien sp/상품금액 : " + strPriceTotal.PadLeft(20, ' ') + "\n";
                if (strPriceDC != "0")
                    str += "Giam gia/할인 : " + strPriceDC.PadLeft(26, ' ') + "\n";
                if (strPricePoint != "0")
                    str += "Giam bang diem/포인트 : " + strPricePoint.PadLeft(18, ' ') + "\n";
                if (strPriceCard != "0")
                    str += "Giam bang voucher/상품권 : " + strPriceCard.PadLeft(15, ' ') + "\n";
                if (strPriceCoupon != "0")
                    str += "Giam gia coupon/쿠폰 : " + strPriceCoupon.PadLeft(19, ' ') + "\n";
                str += "Tong so tien tt/총결제금액 : " + strPriceAlll.PadLeft(13, ' ') + "\n";
                if (strPriceDelv != "0")
                    str += "Phi van chuyen/배달비 : " + strPriceDelv.PadLeft(18, ' ') + "\n";
                str += "So tien tt cuoi cung/합계 : " + strPriceReal.PadLeft(14, ' ') + "\n"; 
                if (strPriceCancel != "0")
                    str += "So tien tra lai KH/고객 반환 : " + strPriceCancel.PadLeft(11, ' ') + "\n";
                if (payType == "offline")
                    str += "Thanh toan khong thanh cong/결제 미완료\n";
                else
                    str += "Thanh toan thanh cong/결제 완료\n";
                str += "------------------------------------------\n";
                str += "■ Thong tin giao hang\n";
                str += "Phuong thuc tt/결제수단 : " + (dtHeader.Rows[0]["pay_info"].ToString() == "COD" ? "Tien mat" : "The VISA") + "\n";
                str += "So don hang/주문번호 : " + ordNo + "\n";
                str += "Ngay gio dat/주문 : " + dtHeader.Rows[0]["ord_dt"].ToString() + "\n";
                str += "Nguoi nhan hang/수취인 : " + COM.CommonUtils.RemoveDiacritics(dtHeader.Rows[0]["full_name"].ToString()) + "\n";
                str += "So dien thoai/전화 번호 : " + dtHeader.Rows[0]["mobile_no"].ToString() + "\n";
                str += "Thoi gian giao/배송시간 : " + dtHeader.Rows[0]["delv_dt"].ToString() + "\n";
                str += "Dia chi/주소 : " + COM.CommonUtils.RemoveVietnameseChar(COM.CommonUtils.RemoveDiacritics(dtHeader.Rows[0]["ship_addr"].ToString())) + "\n";
                str += COM.CommonUtils.RemoveVietnameseChar(COM.CommonUtils.RemoveDiacritics(dtHeader.Rows[0]["ship_addr_dtl"].ToString())) + "\n";
                str += "                                                                                                                  \n";
                //str += "                                                                                                                  \n";
                COM.RawPrinterHelper.SendStringToPrinter(COM.RawPrinterHelper.printerName, str);
                COM.RawPrinterHelper.PrintBarcode("&" + ordNo);
                doc.Print();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Print Receipt");
            }
        }


        static void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Font printFont = new Font("Code128", 20);

            Point pin = new Point(10, 10);

            e.Graphics.DrawImage(Properties.Resources.logo_xl, pin);
        }

        public static void PrintPickOrder(string ordNo)
        {

            JsonRequest request = new JsonRequest();

            ProcAction headerAction = request.NewAction();
            headerAction.proc = WebUtil.Values.PROC_SQL;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT A.ord_id, A.ord_no, A.loc_cd,");
            sql.Append(" B.loc_nm, A.cust_id, A.full_name, DATE_FORMAT(A.ord_dt, '%Y-%m-%d %T') ord_dt, A.email, A.mobile_no,");
            sql.Append(" A.tel_no, A.delv_tp, D.delv_nm, DATE_FORMAT(A.delv_dt, '%Y-%m-%d %T') delv_dt, A.pay_tp, C.pay_nm, A.pay_info, A.ship_post_cd,");
            sql.Append(" A.ship_addr, A.ship_addr_dtl, A.price_total, A.price_delv, A.price_point, A.price_card, A.price_real,");
            sql.Append(" A.delv_yn");
            sql.Append(" FROM tb_so_order A");
            sql.Append(" LEFT JOIN tb_ma_pickup_loc B ON A.loc_cd = B.loc_cd ");
            sql.Append(" LEFT JOIN (SELECT cd as pay_tp, cd_nm as pay_nm FROM tb_sys_code WHERE grp_cd = 'PAY_TP') C ON A.pay_tp = C.pay_tp ");
            sql.Append(" LEFT JOIN (SELECT cd as delv_tp, cd_nm as delv_nm FROM tb_sys_code WHERE grp_cd = 'DELV_TP') D ON A.delv_tp = D.delv_tp ");
            sql.Append(" WHERE A.ord_no = #{ord_no}");
            headerAction.text = sql.ToString();
            headerAction.param.Add("ord_no", ordNo);

            ProcAction detailAction = request.NewAction();
            detailAction.proc = WebUtil.Values.PROC_SQL;
            sql.Clear();
            sql.Append("SELECT A.pick_dtl_id, A.pick_id, A.pick_no, A.pick_seq, A.prod_cd,");
            sql.Append(" B.prod_nm_ko, B.prod_nm_en, B.prod_nm, A.unit, A.ord_qty, ");
            sql.Append(" C.unit_price, C.unit_sale_price, C.unit_delv_price");
            sql.Append(" FROM tb_so_pick_dtl A ");
            sql.Append(" LEFT JOIN tb_ma_product B ON A.prod_cd = B.prod_cd ");
            sql.Append(" LEFT JOIN tb_so_order_dtl C ON A.ord_id = C.ord_id and A.ord_dtl_id = C.ord_dtl_id ");
            sql.Append(" WHERE A.ord_no = #{ord_no}");
            sql.Append(" ORDER BY A.ord_dtl_id");
            detailAction.text = sql.ToString();
            detailAction.param.Add("ord_no", ordNo);

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (!client.check)
            {
                MessageBox.Show(client.message);
            }

            DataTable dtHeader = ds.Tables[0];
            DataTable dtDtl = ds.Tables[1];

            PrintDocument doc = new PrintDocument();
            doc.PrinterSettings.PrinterName = COM.RawPrinterHelper.printerName;
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);

            try
            {
                string str = "";

                str = "Don hang picking/피킹주문서\n";
                str += "So don hang/주문번호 : " + ordNo + "\n";
                str += "------------------------------------------\n";
                str += "Ten cua hang/매장명 : " + COM.CommonUtils.RemoveDiacritics(COM.UserInfo.LocName) + "\n";
                str += "Dia chi/주소 : " + COM.CommonUtils.RemoveDiacritics(COM.UserInfo.LocAddr) + "\n";
                str += "So dien thoai/전화번호 : " + COM.CommonUtils.RemoveDiacritics(COM.UserInfo.LocTelNo) + "\n";
                str += "------------------------------------------\n";
                str += "Code sp            So luong       Gia tien\n";
                str += "------------------------------------------\n";

                for (int i = 0; i < dtDtl.Rows.Count; i++)
                {
                    string procNmKo = COM.CommonUtils.RemoveDiacritics(dtDtl.Rows[i]["prod_nm_ko"].ToString());
                    str += procNmKo + "\n";
                    string procNm = COM.CommonUtils.RemoveDiacritics(dtDtl.Rows[i]["prod_nm"].ToString());
                    str += procNm + "\n";
                    string prodCd = dtDtl.Rows[i]["prod_cd"].ToString();
                    double qty = Double.Parse(dtDtl.Rows[i]["ord_qty"].ToString());
                    string ordQty = String.Format("{0:#,###}", qty);
                    double amt = Double.Parse(dtDtl.Rows[i]["unit_sale_price"].ToString());
                    string sumAmt = String.Format("{0:#,###}", (amt * qty));

                    str += prodCd.PadRight(17, ' ') + ordQty.PadLeft(10, ' ') + sumAmt.PadLeft(15, ' ') + "\n";
                }
                str += "------------------------------------------\n";
                str += "                                                                                                                  \n";
                //str += "                                                                                                                  \n";
                COM.RawPrinterHelper.SendStringToPrinter(COM.RawPrinterHelper.printerName, str);
                COM.RawPrinterHelper.PrintBarcode("#" + ordNo);
                doc.Print();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Print Pick Order Paper");
            }
        }

        public static void PrintDailyFinish(DevExpress.XtraGrid.Views.Grid.GridView gridView, string startDate, string endDate)
        {
            int selRow = gridView.FocusedRowHandle;
            string locCd = gridView.GetRowCellValue(selRow, "loc_cd").ToString();
            string locNm = gridView.GetRowCellValue(selRow, "loc_nm").ToString();
            string startTime = startDate;
            string endTime = endDate;
            string openTime = String.Empty;
            string closeTime = String.Empty;
            string storeCd = String.Empty;

            // Get market infor
            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT id, title, open_at, close_at, store_cd, pos_no FROM kmarket.markets ");
            sql.Append(" WHERE id = #{loc_cd} ");

            action.param.Add("loc_cd", locCd);

            action.text = sql.ToString();

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (client.check)
            {
                DataTable dt = ds.Tables[0];
                openTime = dt.Rows[0]["open_at"].ToString();
                closeTime = dt.Rows[0]["close_at"].ToString();
                storeCd = dt.Rows[0]["store_cd"].ToString();
            }
            else
            {
                MessageBox.Show(client.message, "Lỗi");
                return;
            }

            double totalAmount = Double.Parse(gridView.GetRowCellValue(selRow, "total_amt_real").ToString());
            double paymentAmount = Double.Parse(gridView.GetRowCellValue(selRow, "total_amt_payment").ToString());
            double returnAmount = Double.Parse(gridView.GetRowCellValue(selRow, "total_amt_return").ToString());
            double gapAmount = Double.Parse(gridView.GetRowCellValue(selRow, "total_amt_gap").ToString());

            double delvAmount = Double.Parse(gridView.GetRowCellValue(selRow, "total_amt_delv").ToString());
            double dcAmount = Double.Parse(gridView.GetRowCellValue(selRow, "total_amt_dc").ToString());
            double pointAmount = Double.Parse(gridView.GetRowCellValue(selRow, "total_amt_point").ToString());
            double voucherAmount = Double.Parse(gridView.GetRowCellValue(selRow, "total_amt_voucher").ToString());
            double couponAmount = 0;
            double eventPointAmount = 0;
            double productAmount = Double.Parse(gridView.GetRowCellValue(selRow, "total_amt").ToString());

            double cardAmount = Double.Parse(gridView.GetRowCellValue(selRow, "total_amt_card").ToString());
            double atmAmount = Double.Parse(gridView.GetRowCellValue(selRow, "total_amt_atm").ToString());
            double codAmount = Double.Parse(gridView.GetRowCellValue(selRow, "total_amt_cod").ToString());

            double itemAmount = productAmount + delvAmount;
            string strItemAmount = itemAmount == 0 ? "0" : String.Format("{0:#,###}", itemAmount);
            string strItemReturn = returnAmount == 0 ? "0" : String.Format("{0:#,###}", returnAmount);
            double totalPay = itemAmount - returnAmount;
            string strItemTotal = totalPay == 0 ? "0" : String.Format("{0:#,###}", totalPay);

            double cashAmount = codAmount;
            double creditCardAmount = atmAmount + cardAmount;
            if (returnAmount > 0 && cashAmount > returnAmount) cashAmount = cashAmount - returnAmount;
            else if (returnAmount > 0 && creditCardAmount > returnAmount) creditCardAmount = creditCardAmount - returnAmount;

            string strCash = cashAmount == 0 ? "0" : String.Format("{0:#,###}", cashAmount);
            string strCard = creditCardAmount == 0 ? "0" : String.Format("{0:#,###}", creditCardAmount);
            string strDelv = delvAmount == 0 ? "0" : String.Format("{0:#,###}", delvAmount);
            string strDc = dcAmount == 0 ? "0" : String.Format("{0:#,###}", dcAmount);
            string strPoint = pointAmount == 0 ? "0" : String.Format("{0:#,###}", pointAmount);
            string strVoucher = voucherAmount == 0 ? "0" : String.Format("{0:#,###}", voucherAmount);
            double etc = dcAmount + couponAmount + eventPointAmount;
            string strEtc = etc == 0 ? "0" : String.Format("{0:#,###}", etc);

            double total = cashAmount + creditCardAmount + pointAmount + voucherAmount + etc;
            string strTotal = total == 0 ? "0" : String.Format("{0:#,###}", total);
            double gap = totalPay - total;
            string strGap = gap == 0 ? "0" : String.Format("{0:#,###}", gap);

            PrintDocument doc = new PrintDocument();
            doc.PrinterSettings.PrinterName = COM.RawPrinterHelper.printerName;
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);

            try
            {
                string str = "";

                str = "[" + storeCd + "] " + locNm + "\n";
                str += "OPEN: " + openTime + " - " + closeTime + "\n";
                str += "TIME: " + startDate + " - " + endDate + "\n";
                str += "[DATE]: " + DateTime.Now.ToString() + "\n";
                str += "==========================================\n";
                str += "[ITEM SALE INFO]\n";
                str += "  Item Amount : " + strItemAmount.PadLeft(26, ' ') + "\n";
                str += "------------------------------------------\n";
                str += "[ITEM RETURN INFO]\n";
                str += "  Item Amount : " + strItemReturn.PadLeft(26, ' ') + "\n";
                str += "------------------------------------------\n";
                str += "  ITEM TOTAL : " + strItemTotal.PadLeft(27, ' ') + "\n";
                str += "==========================================\n";
                str += "[PAYMENT INFO]\n";
                str += "  Cash : " + strCash.PadLeft(33, ' ') + "\n";
                str += "  Card : " + strCard.PadLeft(33, ' ') + "\n";
                str += "  Point Use : " + strPoint.PadLeft(28, ' ') + "\n";
                str += "  Gift Card : " + strVoucher.PadLeft(28, ' ') + "\n";
                str += "  Etc : " + strEtc.PadLeft(34, ' ') + "\n";
                str += "------------------------------------------\n";
                str += "  Amount of Pay : " + strTotal.PadLeft(24, ' ') + "\n";
                //str += "  Over Pay : " + strGap.PadLeft(29, ' ') + "\n";
                str += "\n";
                COM.RawPrinterHelper.SendStringToPrinter(COM.RawPrinterHelper.printerName, str);
                doc.Print();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Print Pick Order Paper");
            }
        }
    }
}
