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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebUtil;
using HanbiControl;

namespace SOD
{
    public partial class popRefund : DevExpress.XtraEditors.XtraForm
    {
        DevExpress.XtraGrid.Views.Grid.GridView gridView;
        DevExpress.XtraGrid.Views.Grid.GridView gridViewDetail;

        double priceTotal, pricePoint, priceCard, priceEventPoint, priceCoupon, priceReal;

        double retTotal = 0;
        double retDelv = 0;
        double retReal = 0;

        public popRefund(DevExpress.XtraGrid.Views.Grid.GridView gridView, DevExpress.XtraGrid.Views.Grid.GridView gridViewDetail, string ordNo)
        {
            InitializeComponent();
            this.LookAndFeel.SkinName = CommonUtil.AccessDB.GetConfig("skin");

            string lang = CommonUtil.AccessDB.GetConfig("lang");
            if (!String.IsNullOrEmpty(lang) && lang == "vi")
            {
                this.Text = "Trả hàng/Hoàn tiền";
                radioButton1.Text = "Sản phẩm không đúng.";
                radioButton2.Text = "Bị khách hàng từ chối.";
                radioButton3.Text = "Lỗi bảo quản sản phẩm (côn trùng ăn, ...)";
                radioButton4.Text = "Sản phẩm bị hết hạn.";
                radioButton5.Text = "Bị hư hại khi giao hàng.";
            }
            else if (!String.IsNullOrEmpty(lang) && lang == "ko")
            {
                this.Text = "반품 / 환불";
                radioButton1.Text = "피킹 제품이 올바르지 않습니다";
                radioButton2.Text = "고객이 거부 함";
                radioButton3.Text = "제품 보관 오류 (곤충 먹기 등)";
                radioButton4.Text = "만료 된 제품";
                radioButton5.Text = "배송시 파손";
            }
            else
            {
                this.Text = "Return / Refund";
                radioButton1.Text = "Picking products are not correct.";
                radioButton2.Text = "Rejected by customer.";
                radioButton3.Text = "Products storage error (insect eating, etc.)";
                radioButton4.Text = "Expired products.";
                radioButton5.Text = "Broken on delivery.";
            }
            radioButton1.Select();
            radioGroup.BackColor = this.BackColor;

            this.Refresh();
            
            this.gridView = gridView;
            this.gridViewDetail = gridViewDetail;


            etOrdNo.Text = ordNo;

            priceTotal = Double.Parse(gridView.GetFocusedRowCellValue("recv_price_total").ToString());
            pricePoint = Double.Parse(gridView.GetFocusedRowCellValue("recv_price_point").ToString());
            priceCard = Double.Parse(gridView.GetFocusedRowCellValue("recv_price_card").ToString());
            priceEventPoint = Double.Parse(gridView.GetFocusedRowCellValue("recv_price_event_point").ToString()); ;
            priceCoupon = Double.Parse(gridView.GetFocusedRowCellValue("recv_price_coupon").ToString()); 

            priceReal = Double.Parse(gridView.GetFocusedRowCellValue("recv_price_real").ToString());

            

            if (gridView.GetFocusedRowCellValue("ret_tp").ToString() == "total")
            {
                retTotal = priceTotal;
                retReal = priceReal;

            } else CalcReturnPrice();

            etRetPriceTotal.Value = Convert.ToDecimal(retTotal);
            etRetPriceReal.Value = Convert.ToDecimal(retReal);
            

            btnRefundOrder.Focus();
        }

        void CalcReturnPrice()
        {
            if (gridViewDetail.RowCount < 0) return;

            int totalProduct = 0;
            int totalReturnProduct = 0;

            int returnProduct;
            int unitPrice;
            int unitSalePrice;
            int unitDelvPrice;

            retTotal = 0;
            retReal = 0;
            retDelv = 0;

            for (int i = 0; i < gridViewDetail.RowCount; i++)
            {
                returnProduct = 0;
                unitPrice = 0;
                unitSalePrice = 0;
                unitDelvPrice = 0;

                totalProduct += int.Parse(gridViewDetail.GetRowCellValue(i, "ord_qty").ToString());

                returnProduct = int.Parse(gridViewDetail.GetRowCellValue(i, "ret_qty").ToString());

                totalReturnProduct += returnProduct;

                unitPrice = int.Parse(gridViewDetail.GetRowCellValue(i, "unit_price").ToString());
                unitSalePrice = int.Parse(gridViewDetail.GetRowCellValue(i, "unit_sale_price").ToString());
                unitDelvPrice = int.Parse(gridViewDetail.GetRowCellValue(i, "unit_delv_price").ToString());

                retTotal += returnProduct * unitSalePrice;
                retDelv += returnProduct * unitDelvPrice;

            }

            retReal = retTotal;

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
            irtHeader.Add("WCC", "T003");
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


        private void btnRefundOrder_HbClick(object sender, EventArgs e)
        {
            JsonRequest request = new JsonRequest();

            StringBuilder sql = new StringBuilder();

            ProcAction retAction = request.NewAction();
            retAction.proc = WebUtil.Values.PROC_SQL;
            sql.Append("update tb_so_return set ret_yn = 'Y', up_id = #{up_id}, up_dt = current_timestamp, ");
            sql.Append(" ret_price_total = #{ret_price_total}, ret_price_real = #{ret_price_real},");
            sql.Append(" ret_reason = #{ret_reason} ");
            sql.Append(" WHERE ord_no = #{ord_no} ");
            retAction.text = sql.ToString();
            retAction.param.Add("up_id", COM.UserInfo.UserID);
            retAction.param.Add("ord_no", etOrdNo.Text);
            retAction.param.Add("ret_price_total", etRetPriceTotal.Value);
            retAction.param.Add("ret_price_real", etRetPriceReal.Value);
            retAction.param.Add("ret_reason", etRetReason.Text);
            retAction.param.Add("store_cd", COM.UserInfo.StoreCd);
            retAction.param.Add("pos_no", COM.UserInfo.PosNo);

            ProcAction logAction = request.NewAction();
            logAction.proc = WebUtil.Values.PROC_SQL;
            sql.Clear();
            sql.Append("insert into tb_log_wms(ord_no, log_type, store_cd, pos_no, sale_dt, sale_tm, tran_no, in_dt, in_id) ");
            sql.Append("values(#{ord_no}, #{log_type}, #{store_cd}, #{pos_no}, date_format(current_timestamp, '%Y%m%d'), date_format(current_timestamp, '%H%i%S'), get_next_tran_no2(#{store_cd}, #{pos_no}, null), current_timestamp, #{in_id}) ");
            logAction.text = sql.ToString();
            logAction.param.Add("ord_no", etOrdNo.Text);
            logAction.param.Add("log_type", "return");
            logAction.param.Add("store_cd", COM.UserInfo.StoreCd);
            logAction.param.Add("pos_no", COM.UserInfo.PosNo);
            logAction.param.Add("in_id", COM.UserInfo.UserID);


            ProcAction ordAction = request.NewAction();
            ordAction.proc = WebUtil.Values.PROC_SQL;
            sql.Clear();
            sql.Append("update tb_so_order set ret_yn = 'Y', up_id = #{up_id}, up_dt = current_timestamp ");
            sql.Append(" WHERE ord_no = #{ord_no}  ");
            ordAction.text = sql.ToString();
            ordAction.param.Add("up_id", COM.UserInfo.UserID);
            ordAction.param.Add("ord_no", etOrdNo.Text);

            ProcAction selectAction = request.NewAction();
            selectAction.proc = WebUtil.Values.PROC_SQL;
            selectAction.table = "ret";
            sql.Clear();
            sql.Append("select a.sale_dt, a.sale_tm, a.tran_no, date_format(a.in_dt, '%Y%m%d%H%i%S') open_dt, a.pay_info, b.point_no, b.full_name ");
            sql.Append("from tb_so_return a ");
            sql.Append("    left join tb_so_order b on a.ord_no = b.ord_no ");
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
            sql.Append("	a.ret_qty sale_qty, a.ret_qty * a.unit_sale_price tot_amt, a.unit_sale_price sale_prc, a.ret_qty * a.unit_price tot_unit, a.unit_price ");
            sql.Append("from tb_so_return_dtl a ");
            sql.Append("	inner join (SELECT @RANK := 0) b ");
            sql.Append("    left join tb_ma_product c on a.prod_cd = c.prod_cd ");
            sql.Append("where a.ord_no = #{ord_no} ");
            sql.Append("  and a.ret_qty > 0 ");
            sql.Append("order by a.ord_seq asc ");
            itemAction.text = sql.ToString();
            itemAction.param.Add("ord_no", etOrdNo.Text);

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (client.check)
            {
                gridView.SetFocusedRowCellValue("ret_yn", "Y");
                gridView.SetFocusedRowCellValue("ret_reason", etRetReason.Text);
                gridView.RefreshData();

                DataTable dt = ds.Tables["ret"];
                DataTable dtLog = ds.Tables["log"];
                DataTable dtItem = ds.Tables["item"];

                GetAvailPoint(dt, dtLog);
                //double priceTotal = Convert.ToDouble(this.priceTotal);
                //double pricePoint = Convert.ToDouble(this.pricePoint);
                //double priceCard = Convert.ToDouble(this.priceCard);
                //double priceCoupon = Convert.ToDouble(this.priceCoupon);
                //double priceDc = pricePoint + priceCard + priceCoupon;
                //double priceAll = priceTotal - priceDc;

                double priceTotUnit = 0;
                double priceTotSaleUnit = 0;
                for (int i = 0; i < dtItem.Rows.Count; i++)
                {
                    priceTotUnit += Convert.ToDouble(dtItem.Rows[i]["tot_unit"].ToString());
                    priceTotSaleUnit += Convert.ToDouble(dtItem.Rows[i]["tot_amt"].ToString());
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
                trData.Add("TRAN_FG", "2");     //반품
                trData.Add("TRANQ_FG", "0");    //수동반품
                trData.Add("SAVE_FG", "");
                //trData.Add("ORG_DT", dt.Rows[0]["sale_dt"].ToString());
                //trData.Add("ORG_TM", dt.Rows[0]["sale_tm"].ToString());
                //trData.Add("ORG_POS_NO", COM.UserInfo.PosNo);
                //trData.Add("ORG_TRAN_NO", dt.Rows[0]["tran_no"].ToString());
                //trData.Add("ORG_DT", dtLog.Rows[0]["sale_dt"].ToString());
                //trData.Add("ORG_TM", dtLog.Rows[0]["sale_tm"].ToString());
                //trData.Add("ORG_POS_NO", COM.UserInfo.PosNo);
                //trData.Add("ORG_TRAN_NO", dtLog.Rows[0]["tran_no"].ToString());
                trData.Add("ORG_DT", "");
                trData.Add("ORG_TM", "");
                trData.Add("ORG_POS_NO", "");
                trData.Add("ORG_TRAN_NO", "");
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
                trData.Add("RESON_CD", "3");   //기타사유
                trData.Add("ORG_CASHIER_ID", "");
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
                trData.Add("DC_AMT", priceTotUnit - priceTotSaleUnit);
                trData.Add("TOT_AMT", priceTotSaleUnit);
                JObject trTranSales = new JObject();
                trData.Add("TR_TRAN_SALES", trTranSales);
                JArray trItemList = new JArray();
                trTranSales.Add("TR_ITEM_LIST", trItemList);

                
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
                    item.Add("VNDR_CD", dtItem.Rows[i]["vndr_cd"].ToString()); 
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
                    item.Add("POINT_APP_AMT", 0.0);
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
                    item.Add("Returntotal", saleTotal);
                    item.Add("DATA_STATE", "3");
                }

                JArray trTenderList = new JArray();
                trTranSales.Add("TR_TENDER_LIST", trTenderList);

                int seq = 0;
                if (priceTotSaleUnit > 0)
                {
                    seq++;
                    JObject tender = new JObject();
                    trTenderList.Add(tender);
                    tender.Add("TENDER_SEQ", seq);
                    tender.Add("TRAN_FG", "");
                    tender.Add("GOODS_TRAN_FG", "1");
                    tender.Add("RECEIVE_AMOUNT", priceTotSaleUnit);
                    tender.Add("SUBTOTAL_AMOUNT", priceTotSaleUnit);
                    JArray cashList = new JArray();
                    tender.Add("TR_TENDER_CASH", cashList);
                    tender.Add("TENDER_FG", "CA01");
                    JObject cash = new JObject();
                    cashList.Add(cash);
                    cash.Add("TENDER_SEQ", 1);
                    cash.Add("CASH_FG", "CA01");
                    cash.Add("RCV_AMT", priceTotSaleUnit);
                    cash.Add("PAY_AMT", priceTotSaleUnit);
                    cash.Add("CHG_AMT", 0);
                    tender.Add("TENDER_NM", "");
                }

                JObject trCashReceipt = new JObject();
                trTranSales.Add("TR_CASHRECEIPT", trCashReceipt);
                trCashReceipt.Add("NET_AMT", priceTotSaleUnit);
                trCashReceipt.Add("TAX_AMT", 0.0);
                trCashReceipt.Add("SVC_AMT", 0.0);
                trCashReceipt.Add("TOT_AMT", priceTotSaleUnit);
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
                //MessageBox.Show(client.message);
                XtraMessageBox.Show("Có lỗi xảy ra: \n" + client.message, "Lỗi");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) etRetReason.Text = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) etRetReason.Text = radioButton2.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked) etRetReason.Text = radioButton3.Text;

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked) etRetReason.Text = radioButton4.Text;

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked) etRetReason.Text = radioButton5.Text;
        }

        
    }
}