using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WebUtil;
using HanbiControl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SYS;

namespace SOD
{
    public partial class popDeliveryFinish : DevExpress.XtraEditors.XtraForm
    {
        DevExpress.XtraGrid.Views.Grid.GridView gridView;

        public popDeliveryFinish(DevExpress.XtraGrid.Views.Grid.GridView gridView, string ordNo, string payTp, double priceTotal, double pricePoint, double priceCard, double priceEventPoint, double priceCoupon, double priceAll, double priceDelv, double priceReal)
        {
            InitializeComponent();
            this.LookAndFeel.SkinName = CommonUtil.AccessDB.GetConfig("skin");
            string lang = CommonUtil.AccessDB.GetConfig("lang");
            if (lang == "ko") this.Text = "배달 / 픽업";
            else if (lang == "vi") this.Text = "Giao hàng / Nhận hàng";
            else this.Text = "Delivery/Pickup";
            this.Refresh();

            etOrdNo.Text = ordNo;
            if (lang == "ko") etPayTp.Text = payTp == "online" ? "비자 카드" : "현금";
            else if (lang == "vi") etPayTp.Text = payTp == "online" ? "Thẻ VISA" : "Tiền mặt";
            else etPayTp.Text = payTp == "online" ? "VISA Card" : "Cash";


            etPriceTotal.Value = Convert.ToDecimal(priceTotal);
            etPricePoint.Value = Convert.ToDecimal(pricePoint);
            etPriceCard.Value = Convert.ToDecimal(priceCard);
            etPriceEventPoint.Value = Convert.ToDecimal(priceEventPoint);
            etPriceCoupon.Value = Convert.ToDecimal(priceCoupon);
            etPriceAll.Value = Convert.ToDecimal(priceAll);
            etPriceDelv.Value = Convert.ToDecimal(priceDelv);
            etPriceReal.Value = Convert.ToDecimal(priceReal);

            etPriceDC.Value = Convert.ToDecimal(priceTotal + priceDelv - priceReal - pricePoint - priceCard - priceEventPoint - priceCoupon);

            if (payTp == "online")
            {
                etRecvPriceAll.Value = Convert.ToDecimal(0);
                etRecvPriceReal.Value = Convert.ToDecimal(0);
            }
            else if (payTp == "offline")
            {
                etRecvPriceAll.Value = Convert.ToDecimal(priceReal);
                etRecvPriceReal.Value = Convert.ToDecimal(priceReal);
            }
            
            this.gridView = gridView;

            btnFinishOrder.Focus();
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

        private void hbSimpleButton1_HbClick(object sender, EventArgs e)
        {
            double recvPriceTotal = Convert.ToDouble(etRecvPriceAll.Text);
            double recvPriceFinal = Convert.ToDouble(etRecvPriceReal.Text);

            // Final price received from shipper is difference with total final price of order
            if ((recvPriceTotal < 0 || recvPriceFinal < 0) || (recvPriceFinal != recvPriceTotal))
            {
                //MessageBox.Show("Order Total price and Final price that received from shipper is differences");
                MessageBox.Show("Tổng giá trị đơn hàng và giá trị thực tế nhận từ nhân viên giao hàng đang khác nhau.", "Thông báo");
                etRecvPriceReal.Focus();
                return;
            }


            JsonRequest request = new JsonRequest();

            StringBuilder sql = new StringBuilder();

            ProcAction delvAction = request.NewAction();
            delvAction.proc = WebUtil.Values.PROC_SQL;
            sql.Append("update tb_so_delv set delv_yn = 'Y', up_id = #{up_id}, up_dt = current_timestamp, ");
            sql.Append(" recv_price_total = #{recv_price_total}, recv_price_real = #{recv_price_real} ");
            sql.Append(" WHERE ord_no = #{ord_no} ");
            delvAction.text = sql.ToString();
            delvAction.param.Add("up_id", COM.UserInfo.UserID);
            delvAction.param.Add("ord_no", etOrdNo.Text);
            delvAction.param.Add("recv_price_total", etRecvPriceAll.Value);
            delvAction.param.Add("recv_price_real", etRecvPriceReal.Value);
            delvAction.param.Add("store_cd", COM.UserInfo.StoreCd);
            delvAction.param.Add("pos_no", COM.UserInfo.PosNo);

            ProcAction logAction = request.NewAction();
            logAction.proc = WebUtil.Values.PROC_SQL;
            sql.Clear();
            sql.Append("insert into tb_log_wms(ord_no, log_type, store_cd, pos_no, sale_dt, sale_tm, tran_no, in_dt, in_id) ");
            sql.Append("values(#{ord_no}, #{log_type}, #{store_cd}, #{pos_no}, date_format(current_timestamp, '%Y%m%d'), date_format(current_timestamp, '%H%i%S'), get_next_tran_no2(#{store_cd}, #{pos_no}, null), current_timestamp, #{in_id}) ");
            logAction.text = sql.ToString();
            logAction.param.Add("ord_no", etOrdNo.Text);
            logAction.param.Add("log_type", "order");
            logAction.param.Add("store_cd", COM.UserInfo.StoreCd);
            logAction.param.Add("pos_no", COM.UserInfo.PosNo);
            logAction.param.Add("in_id", COM.UserInfo.UserID);

            ProcAction ordAction = request.NewAction();
            ordAction.proc = WebUtil.Values.PROC_SQL;
            sql.Clear();
            sql.Append("update tb_so_order set delv_yn = 'Y', up_id = #{up_id}, up_dt = current_timestamp ");
            sql.Append(" WHERE ord_no = #{ord_no}  ");
            ordAction.text = sql.ToString();
            ordAction.param.Add("up_id", COM.UserInfo.UserID);
            ordAction.param.Add("ord_no", etOrdNo.Text);

            ProcAction selectAction = request.NewAction();
            selectAction.proc = WebUtil.Values.PROC_SQL;
            selectAction.table = "delv";
            sql.Clear();
            sql.Append("select a.sale_dt, a.sale_tm, a.tran_no, date_format(a.in_dt, '%Y%m%d%H%i%S') open_dt, a.pay_info, b.point_no, b.full_name, c.purchase_info, e.card_no ");
            sql.Append("from tb_so_delv a ");
            sql.Append("    left join tb_so_order b on a.ord_no = b.ord_no ");
            sql.Append("    left join kmarket.product_orders c on a.ord_no = concat(c.id, '') ");
            sql.Append("    left join kmarket.market_card_histories d on c.id = d.order_id ");
            sql.Append("    left join kmarket.market_cards e on d.card_id = e.id ");
            sql.Append("where a.ord_no = #{ord_no}  ");
            selectAction.text = sql.ToString();
            selectAction.param.Add("ord_no", etOrdNo.Text);

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
            selectLogAction.param.Add("ord_no", etOrdNo.Text);

            ProcAction itemAction = request.NewAction();
            itemAction.proc = WebUtil.Values.PROC_SQL;
            itemAction.table = "item";
            sql.Clear();
            sql.Append("select a.prod_cd plu_cd, @RANKT := @RANK + 1 item_seq, c.ex_cd item_cd, c.vndr_cd, concat(c.prod_nm, ' / ', c.prod_nm_ko) plu_nm, ");
            sql.Append("	a.pick_qty sale_qty, a.pick_qty * a.unit_sale_price tot_amt, a.unit_sale_price sale_prc, a.pick_qty * a.unit_price tot_unit, a.unit_price ");
            sql.Append("from tb_so_delv_dtl a ");
            sql.Append("	inner join (SELECT @RANK := 0) b ");
            sql.Append("    left join tb_ma_product c on a.prod_cd = c.prod_cd ");
            sql.Append("where a.ord_no = #{ord_no} ");
            sql.Append("  and a.pick_qty > 0 ");
            sql.Append("order by a.ord_seq asc ");
            itemAction.text = sql.ToString();
            itemAction.param.Add("ord_no", etOrdNo.Text);

            // Update shopping mall order status
            ProcAction updateShoppingMall = request.NewAction();
            updateShoppingMall = HBConstant.UpdateOrder(updateShoppingMall, etOrdNo.Text, HBConstant.STS_DELIVERED);

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (client.check)
            {
                gridView.SetFocusedRowCellValue("delv_yn", "Y");
                gridView.RefreshData();

                DataTable dt = ds.Tables["delv"];
                DataTable dtLog = ds.Tables["log"];
                DataTable dtItem = ds.Tables["item"];

                GetAvailPoint(dt, dtLog);
                double priceTotal = Convert.ToDouble(etPriceTotal.Value.ToString());
                double priceReal = Convert.ToDouble(etPriceReal.Value.ToString());
                double pricePoint = Convert.ToDouble(etPricePoint.Value.ToString());
                double priceEventPoint = Convert.ToDouble(etPriceEventPoint.Value.ToString()); 
                double priceCard = Convert.ToDouble(etPriceCard.Value.ToString()); 
                double priceCoupon = Convert.ToDouble(etPriceCoupon.Value.ToString());
                double priceDelv = Convert.ToDouble(etPriceDelv.Value.ToString());
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
                if(priceMain > 0) {
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
                //if (priceAll > 0)
                //{
                //    seq++;
                //    JObject tender = new JObject();
                //    trTenderList.Add(tender);
                //    tender.Add("TENDER_SEQ", seq);
                //    tender.Add("TRAN_FG", "");
                //    tender.Add("GOODS_TRAN_FG", "0");
                //    tender.Add("RECEIVE_AMOUNT", priceAll);
                //    tender.Add("SUBTOTAL_AMOUNT", priceAll);
                //    JArray cashList = new JArray();
                //    tender.Add("TR_TENDER_CASH", cashList);
                //    if (dt.Rows[0]["pay_info"].ToString() == "COD")
                //    {
                //        tender.Add("TENDER_FG", "CA01");
                //        JObject cash = new JObject();
                //        cashList.Add(cash);
                //        cash.Add("TENDER_SEQ", 1);
                //        cash.Add("CASH_FG", "CA01");
                //        cash.Add("RCV_AMT", priceAll);
                //        cash.Add("PAY_AMT", priceAll);
                //        cash.Add("CHG_AMT", 0);
                //    }
                //    else
                //    {
                //        tender.Add("TENDER_FG", "01");
                //    }
                //    tender.Add("TENDER_NM", "");
                //}
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
                    //card.Add("STR_CD", COM.UserInfo.StoreCd);
                    //card.Add("SALE_DT", dtLog.Rows[0]["sale_dt"].ToString());
                    //card.Add("POS_NO", COM.UserInfo.PosNo);
                    //card.Add("TRAN_NO", dtLog.Rows[0]["tran_no"].ToString());
                    card.Add("TENDER_SEQ", seq);
                    card.Add("GIFT_FG", "01");
                    card.Add("TDR_CD", "VO01");
                    card.Add("INPUT_FG", "");
                    card.Add("GIFT_AMT", priceCard);
                    card.Add("CHG_FG", "");
                    card.Add("CHG_AMT", 0.0);
                    card.Add("GIFT_STAT", "");
                    card.Add("GIFT_TYPE_LANG_WORD", "전자상품권");
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


                this.Close();
            }
            else
            {
                MessageBox.Show(client.message);
            }
        }

        
    }
}