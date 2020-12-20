using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Data;
using DevExpress.XtraEditors;
using WebUtil;
using CommonUtil;

namespace COM
{
    public class EmailHelper
    {
        private static string smtpServer { get;  set; }
        private static int smtpPort { get; set; }
        private static string credentialUsername { get; set; }
        private static string credentialPassword { get; set; }

        public static void SettingEmailHelper(string server = "smtp.gmail.com", int port = 587,
            string username = "hanbitest@gmail.com", string password = "hanbi2088")
        {
            smtpServer = server;
            smtpPort = port;
            credentialUsername = username;
            credentialPassword = password;

        }

        public static bool SendEmail(string ord_no)
        {
            bool sendStatus = false;
            SettingEmailHelper();

            if (String.IsNullOrEmpty(ord_no) || UserInfo.LocCode != "0") return false;

            // Get detail order and suppliers
            JsonRequest request = new JsonRequest();
            StringBuilder sql = new StringBuilder();

            ProcAction getProducts = request.NewAction();
            getProducts.proc = WebUtil.Values.PROC_SQL;
            sql.Append(" SELECT A.ord_no, A.full_name, A.email, A.mobile_no, A.tel_no, DATE_FORMAT(A.ord_dt, '%Y-%m-%d %T') ord_dt, DATE_FORMAT(A.delv_dt, '%Y-%m-%d %H:%i') delv_dt,");
            sql.Append(" A.pay_tp, A.pay_info, A.ship_addr, A.ship_addr_dtl, ");
            sql.Append(" A.price_real, A.price_delv, (A.price_total + A.price_delv - A.price_real - A.price_point - A.price_card - A.price_event_point - A.price_coupon) AS price_dc, A.price_point, A.price_card, A.price_event_point, A.price_coupon, A.price_total, A.price_cancel,");
            sql.Append(" B.prod_cd, C.title prod_nm_ko, C.title_vi prod_nm, C.main_img, B.ord_qty, B.unit_price, B.unit_sale_price, B.unit_delv_price,");
            sql.Append(" C.supplier_code, D.supplier_nm, D.addr supplier_addr, D.tel_no supplier_tel_no, D.email supplier_email");
            sql.Append(" FROM hanbibase.tb_so_order A LEFT JOIN hanbibase.tb_so_order_dtl B on A.ord_no = B.ord_no AND A.ord_id =  B.ord_id");
            sql.Append(" LEFT JOIN kmarket.products C ON B.prod_cd = C.p_code collate utf8mb4_general_ci");
            sql.Append(" LEFT JOIN kmarket.suppliers D ON C.supplier_code = D.supplier_code");
            sql.Append(" WHERE A.loc_cd = #{loc_cd}");
            sql.Append(" AND A.ord_no = #{ord_no}");

            getProducts.text = sql.ToString();
            getProducts.param.Add("loc_cd", UserInfo.LocCode);
            getProducts.param.Add("ord_no", ord_no);

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (!client.check)
            {
                XtraMessageBox.Show(client.message, "Lỗi");
                return false;
            }

            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0) return false;

            // Check suppliers
            Dictionary<string, string> listSuppliers = new Dictionary<string, string>();
            string supplierCode;
            string supplierEmail;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                supplierCode = dt.Rows[i]["supplier_code"].ToString();
                supplierEmail = dt.Rows[i]["supplier_email"].ToString();
                if (!String.IsNullOrEmpty(supplierCode) && !String.IsNullOrEmpty(supplierEmail) && !listSuppliers.ContainsKey(supplierCode))
                {
                    listSuppliers.Add(supplierCode, supplierEmail);
                }
            }

            if (listSuppliers.Count == 0)
            {
                //XtraMessageBox.Show("No product which need to send email to the Supplier.", "Info");
                XtraMessageBox.Show("Không có sản phẩm nào cần gửi email cho Nhà cung cấp.", "Thông báo");
                return true;
            }

            try
            {
                SmtpClient mailclient = new SmtpClient(smtpServer, smtpPort);
                mailclient.EnableSsl = true;
                mailclient.Credentials = new System.Net.NetworkCredential(credentialUsername, credentialPassword);

                MailMessage message;
                foreach (string key in listSuppliers.Keys)
                {
                    supplierCode = String.Empty;
                    supplierEmail = String.Empty;

                    supplierCode = key;
                    supplierEmail = listSuppliers[supplierCode];
                    message = new MailMessage(credentialUsername, supplierEmail);

                    message.Subject = "[K-MARKET] Đơn đặt hàng số " + ord_no;
                    message.Body = BuildEmail(dt, supplierCode, listSuppliers.Count).ToString();

                    message.IsBodyHtml = true;

                    mailclient.Send(message);
                }
                sendStatus = true;
            }
            catch (Exception ex)
             {
                sendStatus = false;
                XtraMessageBox.Show(ex.Message, "Thông báo");
            }

            if (sendStatus)
                XtraMessageBox.Show("Đã gửi email thông báo về đơn hàng cho Nhà cung cấp.", "Thông báo");
             return sendStatus;
        }

        private static StringBuilder BuildEmail(DataTable dt, string supplierCode, int numberSupplier)
        {
            StringBuilder email = new StringBuilder();

            // 
            email.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"background-color:#f5f5f5;padding-top:60px;color:#424242;font-size:14px\"><tbody><tr>");
            email.Append(" <td>");
            email.Append(" <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"background-color:#fff;width:600px;max-width:600px;margin:0 auto\">");
            email.Append(" <tbody><tr>");
            
            //Logo
            email.Append(" <td height=\"116\" style=\"width:100%;text-align:center\">");
            email.Append(" <img src=\"http://kmarketvina.com/images/logo_h.png\" alt=\"kmarketvina_logo\">");
            email.Append(" </td></tr>");

            // First image
            email.Append(" <tr>");
            email.Append(" <td align=\"center\" height=\"200\" style=\"width:100%;background-image:url('http://kmarketvina.com/images/img_aboutUs_02_01.png');background-size:100%;background-repeat:no-repeat;font-size:24px;color:white;font-weight:bold;padding:0 82px\"></td>");
            email.Append(" </tr>");

            // Get order details
            string code;
            string supplierName = String.Empty;

            string ordNo = String.Empty;
            string custName = String.Empty;
            string ordDate = String.Empty;
            string shipDate = String.Empty;
            string custMobileNo = String.Empty;
            string custTelNo = String.Empty;
            string custEmail = String.Empty;
            string custAddr = String.Empty;
            string custAddrDtl = String.Empty;

            double priceTotal = 0;
            string strPriceTotal = String.Empty;
            double priceDc = 0;
            string strPriceDC = String.Empty;
            double pricePoint = 0;
            string strPricePoint = String.Empty;
            double priceCard = 0;
            string strPriceCard = String.Empty;
            double priceCoupon = 0;
            string strPriceCoupon = String.Empty;
            double priceEventPoint = 0;
            string strPriceEventPoint = String.Empty;
            double priceAll = 0;
            string strPriceAll = String.Empty;
            double priceDelv = 0;
            string strPriceDelv = String.Empty;
            double priceReal = 0;
            string strPriceReal = String.Empty;
            double priceCancel = 0;
            string strPriceCancel = String.Empty;
            string payTp = String.Empty;
            string payStatus = String.Empty;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                code = dt.Rows[i]["supplier_code"].ToString();
                if (supplierCode == code)
                {
                    supplierName = dt.Rows[i]["supplier_nm"].ToString();

                    ordNo = dt.Rows[i]["ord_no"].ToString();
                    custName = dt.Rows[i]["full_name"].ToString();
                    ordDate = dt.Rows[i]["ord_dt"].ToString();
                    shipDate = dt.Rows[i]["delv_dt"].ToString();
                    custMobileNo = dt.Rows[i]["mobile_no"].ToString();
                    custTelNo = dt.Rows[i]["tel_no"].ToString();
                    custAddr = dt.Rows[i]["ship_addr"].ToString();
                    custAddrDtl = dt.Rows[i]["ship_addr_dtl"].ToString();
                    payTp = dt.Rows[i]["pay_info"].ToString();
                    payStatus = dt.Rows[i]["pay_tp"].ToString();
                    if (payStatus == "online" && (payTp == "ATM" || payTp == "CARD")) 
                    {
                        payTp = " Thẻ VISA";
                        payStatus = "Đã thanh toán thành công.";
                    }
                    else 
                    {
                        payTp = "Tiền mặt";
                        payStatus = "Chưa thanh toán.";
                    }

                    // price
                    priceTotal = Double.Parse(dt.Rows[i]["price_total"].ToString());
                    strPriceTotal = priceTotal == 0 ? "0" : String.Format("{0:#,###}", priceTotal);
                    priceDc = Double.Parse(dt.Rows[i]["price_dc"].ToString());
                    strPriceDC = priceDc == 0 ? "0" : String.Format("{0:#,###}", priceDc);
                    pricePoint = Double.Parse(dt.Rows[i]["price_point"].ToString());
                    strPricePoint = pricePoint == 0 ? "0" : String.Format("{0:#,###}", pricePoint);
                    priceCard = Double.Parse(dt.Rows[i]["price_card"].ToString());
                    strPriceCard = priceCard == 0 ? "0" : String.Format("{0:#,###}", priceCard);
                    priceEventPoint = Double.Parse(dt.Rows[i]["price_event_point"].ToString());
                    strPriceEventPoint = priceEventPoint == 0 ? "0" : String.Format("{0:#,###}", priceEventPoint);
                    priceCoupon = Double.Parse(dt.Rows[i]["price_coupon"].ToString());
                    strPriceCoupon = priceCoupon == 0 ? "0" : String.Format("{0:#,###}", priceCoupon);
                    priceDelv = Double.Parse(dt.Rows[i]["price_delv"].ToString());
                    strPriceDelv = priceDelv == 0 ? "0" : String.Format("{0:#,###}", priceDelv);
                    priceReal = Double.Parse(dt.Rows[i]["price_real"].ToString());
                    strPriceReal = priceReal == 0 ? "0" : String.Format("{0:#,###}", priceReal);
                    priceAll = priceReal - priceDelv;
                    strPriceAll = priceAll == 0 ? "0" : String.Format("{0:#,###}", priceAll);
                    priceCancel = Double.Parse(dt.Rows[i]["price_cancel"].ToString());
                    strPriceCancel = priceCancel == 0 ? "0" : String.Format("{0:#,###}", priceCancel);

                    break;
                }
            }

            // Email content
            email.Append(" <tr>");
            email.Append(" <td style=\"padding:30px 50px 50px\">");
            email.Append(" <div style=\"margin-bottom:20px\">");
            email.Append(" <span style=\"font-size:18px;font-weight:bold;color:#333\">Gửi nhà cung cấp " + supplierName + ",</span>");
            email.Append(" </div>");
            email.Append(" <p style=\"margin:0;margin-bottom:30px\">Đây là email tự động - thông báo về đơn đặt hàng sản phẩm của các bạn thông qua hệ thống bán hàng của chúng tôi với nội dung chi tiết như dưới đây.</p>");
            // Table email
            email.Append(" <div style=\"border:1px solid #e0e0e0;padding:24px 20px 30px\">");
            email.Append(" <div style=\"margin-bottom:20px;font-size:18px;font-weight:bold;\"><span>Mã đơn hàng:</span>&nbsp; " + ordNo + " </div>");
            email.Append(" <table style=\"width:100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
            email.Append(" <tbody>");
            // Customer info
            email.Append(" <tr>");
            email.Append(" <td colspan=\"2\">");
            email.Append(" <div style=\"border-top:1px solid #e0e0e0;margin-top:16px\"> </div>");
            email.Append(" <h3 style=\"margin:16px 0 9px\">Thông tin khách hàng</h3>");
            email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span>- Tên khách hàng&nbsp;</span><span style=\"padding-left:27px;font-weight:bold;\">:&nbsp; " + custName + "</span></p>");
            email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span>- Thời gian đặt hàng&nbsp;</span><span style=\"padding-left:9px;font-weight:bold;\">:&nbsp; " + ordDate +"</span></p>");
            email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span>- Thời gian giao hàng&nbsp;</span><span style=\"padding-left:2px;font-weight:bold;\">:&nbsp; " + shipDate +"</span></p>");
            email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span>- Số điện thoại&nbsp;</span><span style=\"padding-left:44px;font-weight:bold;\">:&nbsp; " + custMobileNo + "&nbsp;&nbsp;&nbsp;&nbsp;" + custTelNo + "</span></p>");
            email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span>- E mail&nbsp;</span><span style=\"padding-left:87px;font-weight:bold;\">:&nbsp; " + custEmail + "</span></p>");
            email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span>- Địa chỉ&nbsp;</span><span style=\"padding-left:82px;font-weight:bold;\">:&nbsp;</span> " + custAddr + "</p>");
            email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span style=\"padding-left:147px;\"> " + custAddrDtl + "</span></p>");
            email.Append(" <div style=\"border-top:1px solid #e0e0e0;margin-top:16px; margin-bottom: 20px;\"> </div>");
            email.Append(" </td>");
            email.Append(" </tr>");

            // Product info
            string strProdImg = String.Empty;
            string strProdCode = String.Empty;
            string strProdNameVi = String.Empty;
            string strProdNameKo = String.Empty;
            double ordQty = 0;
            string strOrdQty = String.Empty;
            double salePrice = 0;
            string strSalePrice = String.Empty;
            double delvPrice = 0;

            double calPriceProduct = 0;
            double calPriceAll = 0;
            double calPriceDelv = 0;
            double calPriceReal = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                code = dt.Rows[i]["supplier_code"].ToString();
                if (supplierCode == code)
                {
                    if (i > 0) 
                    email.Append(" <tr><td colspan=\"2\" style=\"padding-top: 30px;\"></td></tr>");

                    strProdImg = dt.Rows[i]["main_img"].ToString();
                    strProdCode = dt.Rows[i]["prod_cd"].ToString();
                    strProdNameVi = dt.Rows[i]["prod_nm"].ToString();
                    strProdNameKo = dt.Rows[i]["prod_nm_ko"].ToString();
                    ordQty = Double.Parse(dt.Rows[i]["ord_qty"].ToString());
                    strOrdQty = String.Format("{0:#,###}", ordQty);
                    salePrice = Double.Parse(dt.Rows[i]["unit_sale_price"].ToString());
                    strSalePrice = String.Format("{0:#,###}", salePrice);
                    delvPrice = Double.Parse(dt.Rows[i]["unit_delv_price"].ToString());

                    calPriceProduct = calPriceProduct + ordQty * salePrice;
                    calPriceDelv = calPriceDelv + ordQty * delvPrice;

                    email.Append(" <tr>");
                    email.Append(" <td style=\"padding-right:20px;vertical-align:top\">");
                    email.Append(" <img src=\"http://kmarketvina.com/api/download?size=small&f=" + strProdImg + "\" alt=\"\" style=\"width:130px;height:130px;border-radius:2px\">");
                    email.Append(" </td>");
                    email.Append(" <td style=\"width:320px\">");
                    email.Append(" <p style=\"width:320px;font-size:18px;font-weight:bold;margin:0;margin-bottom:8px;\">"+ strProdNameKo + "</p>");
                    email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29;width:320px\">" + strProdNameVi + "</p>");
                    email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29;width:320px\"><span>Mã SP&nbsp;</span><span style=\"padding-left:20px;\">:&nbsp;</span><span style=\"font-weight:bold;\"> " + strProdCode + " </span></p>");
                    email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29;width:320px\"><span>Đơn giá&nbsp;</span><span style=\"padding-left:12px;\">:&nbsp; " + strSalePrice + " </span></p>");
                    email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29;width:320px\"><span>Số lượng&nbsp;</span><span style=\"padding-left:4px;\">:&nbsp;</span><span style=\"font-weight:bold;\"> " + strOrdQty + " </span></p>");
                    email.Append(" </td>");
                    email.Append(" </tr>");
                }
            }

            if (numberSupplier >= 1)
            {
                priceTotal = calPriceProduct;
                strPriceTotal = priceTotal == 0 ? "0" : String.Format("{0:#,###}", priceTotal);

                priceDc = priceDc / numberSupplier;
                strPriceDC = priceDc == 0 ? "0" : String.Format("{0:#,###}", priceDc);

                pricePoint = pricePoint / numberSupplier;
                strPricePoint = pricePoint == 0 ? "0" : String.Format("{0:#,###}", pricePoint);

                priceCard = priceCard / numberSupplier;
                strPriceCard = priceCard == 0 ? "0" : String.Format("{0:#,###}", priceCard);

                priceEventPoint = priceEventPoint / numberSupplier;
                strPriceEventPoint = priceEventPoint == 0 ? "0" : String.Format("{0:#,###}", priceEventPoint);

                priceCoupon = priceCoupon / numberSupplier;
                strPriceCoupon = priceCoupon == 0 ? "0" : String.Format("{0:#,###}", priceCoupon);

                if (calPriceDelv == 0)
                {
                    priceDelv = priceDelv / numberSupplier;
                    strPriceDelv = priceDelv == 0 ? "0" : String.Format("{0:#,###}", priceDelv);
                }
                // TODO Cal delivery fee

                priceAll = priceTotal - priceDc - pricePoint - priceCard - priceEventPoint - priceCoupon;
                strPriceAll = priceAll == 0 ? "0" : String.Format("{0:#,###}", priceAll);

                priceReal = priceAll + priceDelv;
                strPriceReal = priceReal == 0 ? "0" : String.Format("{0:#,###}", priceReal);
            }

            // Payment info
            email.Append(" <tr>");
            email.Append(" <td colspan=\"2\">");
            email.Append(" <div style=\"border-top:1px solid #e0e0e0;margin-top:16px\"> </div>");
            email.Append(" <h3 style=\"margin:16px 0 9px\">Thông tin thanh toán (vnd)</h3>");
            email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span>- Tổng giá sản phẩm&nbsp;</span><span style=\"padding-left:48px;\">:&nbsp; " + strPriceTotal + " </span></p>");
            if (priceDc > 0)
                email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span>- Giảm giá&nbsp;</span><span style=\"padding-left:111px;\">:&nbsp; " + strPriceDC + " </span></p>");
            if (pricePoint > 0)
                email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span>- Sử dụng điểm&nbsp;</span><span style=\"padding-left:80px;\">:&nbsp; " + strPricePoint + " </span></p>");
            if (priceCard > 0 )
                email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span>- Sử dụng voucher&nbsp;</span><span style=\"padding-left:60px;\">:&nbsp; " + strPriceCard + " </span></p>");
            if (priceEventPoint > 0)
                email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span>- Điểm sự kiện&nbsp;</span><span style=\"padding-left:83px;\">:&nbsp; " + strPriceEventPoint + " </span></p>");
            if (priceCoupon > 0 )
                email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span>- Sử dụng coupon&nbsp;</span><span style=\"padding-left:65px;\">:&nbsp; " + strPriceCoupon + " </span></p>");
            email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span>- Tổng thanh toán&nbsp;</span><span style=\"padding-left:64px;\">:&nbsp; " + strPriceAll + " </span></p>");
            if (priceDelv > 0)
                email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span>- Tổng phí giao hàng&nbsp;</span><span style=\"padding-left:45px;\">:&nbsp; " + strPriceDelv + " </span></p>");
            email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29;font-weight:bold;\"><span>- Thanh toán cuối cùng&nbsp;</span><span style=\"padding-left:29px;\">:&nbsp; " + strPriceReal + " </span></p>");
            email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29;font-weight:bold;\"><span>- Phương thức thanh toán&nbsp;</span><span style=\"padding-left:12px;\">:&nbsp; " + payTp + " </span></p>");
            email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29;font-weight:bold;\"><span>- Trạng thái thanh toán&nbsp;</span><span style=\"padding-left:29px;\">:&nbsp; " + payStatus + " </span></p>");
            if (priceCancel > 0 && payTp == "Thẻ VISA")
                email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29;font-weight:bold;\"><span>- Trả lại khách hàng&nbsp;</span><span style=\"padding-left:51px;\">:&nbsp; 1,000,000 </span></p>");
            email.Append(" <div style=\"border-top:1px solid #e0e0e0;margin-top:16px\"> </div>");
            email.Append(" <h3 style=\"margin:16px 0 9px\">Thông tin cửa hàng</h3>");
            email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span>- Tên cửa hàng&nbsp;</span><span style=\"padding-left:41px;\">:&nbsp; K-market Office </span></p>");
            email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span>- SĐT cửa hàng&nbsp;</span><span style=\"padding-left:37px;\">:&nbsp; " + UserInfo.LocTelNo + " </span></p>");
            email.Append(" <p style=\"margin:0;margin-bottom:6px;line-height:1.29\"><span>- Nhân viên bán hàng&nbsp;</span><span style=\"padding-left:0px;\">:&nbsp; " + UserInfo.UserName + " </span></p>");
            email.Append(" </td>");
            email.Append(" </tr>");
            email.Append(" </tbody></table>");
            email.Append(" </div>");
            email.Append(" </td>");
            email.Append(" </tr>");

            // Footer
            email.Append(" <tr>");
            email.Append(" <td style=\"background:#f5f5f5\">");
            email.Append(" <div style=\"background-color:#f5f5f5\">");
            email.Append(" <div style=\"text-align:center\">");
            email.Append(" <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\" style=\"background-color:#f5f5f5;border-collapse:collapse;margin-top:30px;margin-bottom:30px;font-size:14px;border-radius:6px\">");
            email.Append(" <tbody><tr style=\"font-size:12px;line-height:18px;color:#999\">");
            email.Append(" <td style=\"width:500px;text-align:center;padding-bottom:16px\">");
            email.Append(" <p style=\"margin:0\">Liên hệ với chúng tôi!</p>");
            email.Append(" <p style=\"margin:0\">Website: <a style=\"text-decoration:none;color:#0651cf\" href=\"http://kmarketvina.com/\" target=\"_blank\" data-saferedirecturl=\"http://kmarketvina.com/\">www.kmarketvina.com</a></p>");
            email.Append(" <p style=\"margin:0\">Hotline: <a a style=\"text-decoration:none;color:#0651cf\" href=\"callto:0382646759\" >038 264 6759</a> (Thứ 2 - Thứ 7 | 8:30 - 17:30)</p>");
            email.Append(" <p style=\"margin:0\">Email: <a a style=\"text-decoration:none;color:#0651cf\" href=\"mailto:linhnm.it@k-market.vn\" >linhnm.it@k-market.vn</a></p>");
            email.Append(" <p style=\"margin:0\">Zalo: <a a style=\"text-decoration:none;color:#0651cf\" href=\"callto:0967286259\" >0967 286 259 </a></p>");
            email.Append(" <p style=\"margin:0\">Kakao Talk: <a a style=\"text-decoration:none;color:#0651cf\" href=\"\" >linhnm166</a></p>");
            email.Append(" </td>");
            email.Append(" </tr>");
            email.Append(" <tr><td style=\"height:1px;background-color:#ddd\"></td></tr>");
            email.Append(" <tr style=\"font-size:12px;line-height:18px;color:#999\">");
            email.Append(" <td style=\"text-align:center;padding-top:16px\">");
            email.Append(" <p style=\"margin:0\">If you have received this communication in error, please do not forward its contents; notify the sender and delete it and any attachments. This message may contain information that is confidential and legally privileged. Unless you are the addressee, you may not use, copy or disclose to anyone this message or any information contained within.</p>");
            email.Append(" <p style=\"margin:0;margin-top:20px;font-size:12px;line-height:1;text-align:center;color:#999\">©2020 K&K Global Trading Co.,LTD. All Rights Reserved.</p>");
            email.Append(" </td>");
            email.Append(" </tr>");
            email.Append(" </tbody></table>");
            email.Append(" </div>");
            email.Append(" </div>");
            email.Append(" </td>");
            email.Append(" </tr>");
            email.Append(" </tbody></table>");
            email.Append(" </td>");
            email.Append(" </tr>");
            email.Append(" </tbody></table>");

            return email;
        }
    }
}
