using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;
using WebUtil;
using DevExpress.XtraEditors;

namespace SYS
{
    public static class HBConstant
    {
        public const String C_IN_ID = "in_id";
        public const String C_UP_ID = "up_id";

        public const String C_START_DATE = "start_date";
        public const String C_END_DATE = "end_date"; 

        public const String TB_SYS_TEXT = "tb_sys_text";
        public const String TB_SYS_CODE = "tb_sys_code";
        public const String TB_SYS_CODE_GRP = "tb_sys_code_grp";
        public const String TB_SYS_USER = "tb_sys_user";
        public const String TB_MA_PRODUCT = "tb_ma_product";
        public const String TB_MA_PICKUP_LOC = "tb_ma_pickup_loc";

        public const String TB_SO_ORDER = "tb_so_order";
        public const String F_ORD_NO_PREFIX = "OD";
        public const String TB_SO_ORDER_DTL = "tb_so_order_dtl";

        public const String TB_SO_PICK = "tb_so_pick";
        public const String F_PICK_NO_PREFIX = "PI";
        public const String TB_SO_PICK_DTL = "tb_so_pick_dtl";

        public const String TB_SO_DELV = "tb_so_delv";
        public const String F_DELV_NO_PREFIX = "DL";
        public const String TB_SO_DELV_DTL = "tb_so_delv_dtl";

        public const String TB_SO_RETURN = "tb_so_return";
        public const String F_RETURN_NO_PREFIX = "RE";
        public const String TB_SO_RETURN_DTL = "tb_so_return_dtl";

        public const String MORE_THAN = ">";
        public const String LESS_THAN = "<";
        public const String EQUAL = "=";

        public const int NORMAL = 0;
        public const int ERR1 = 1;

        public const String YES = "Y";
        public const String NO = "N";

        // kmarket
        public const String PRODUCT_ORDER = "kmarket.product_orders";
        public const String STS_ORDERED = "O";
        public const String STS_PICKING_D = "P1";
        public const String STS_PICKING_P = "P2";
        public const String STS_DELIVERY_D = "D1";
        public const String STS_DELIVERY_P = "D2";
        public const String STS_DELIVERED = "R";
        public const String STS_CANCEL = "C";

        public const String ROLE_APPLICATION = "1";
        public const String ROLE_ADMINISTRATOR = "2";
        public const String ROLE_SYSTEM = "3";


        //Is that ID has exist in the Table?
        public static int checkExistID(string tableName, string columnName, string value)
        {
            JsonRequest request = new JsonRequest();
            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT " + columnName);
            sql.Append(" FROM " + tableName);
            sql.Append(" WHERE " + columnName +" = #{"+ columnName + "}");

            action.text = sql.ToString();
            action.param.Add(columnName, value);

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (ds.Tables.Count >= 0 && ds.Tables[0].Rows.Count > 0)
            {
                return HBConstant.ERR1;
            }

            return HBConstant.NORMAL;
        }

        /*
         * Check product code (barcode of products) format and value
         * return: true - it is barcode value
         *       : false - it is not barcode value
         */
        public static bool CheckProductCode(string prod_cd)
        {
            bool chk = false;

            if (prod_cd != (new Regex("[^0-9]")).Replace(prod_cd, ""))
            {
                // Is not numeric
                return chk;
            }

            switch (prod_cd.Length)
            {
                case 8:
                    prod_cd = "000000" + prod_cd;
                    break;
                case 12:
                    prod_cd = "00" + prod_cd;
                    break;
                case 13:
                    prod_cd = "0" + prod_cd;
                    break;
                case 14:
                    break;
                default:
                    // Wrong number of digits
                    return chk;
            }

            // Calculate check digit
            int[] a = new int[13];
            a[0] = int.Parse(prod_cd[0].ToString()) * 3;
            a[1] = int.Parse(prod_cd[1].ToString());
            a[2] = int.Parse(prod_cd[2].ToString()) * 3;
            a[3] = int.Parse(prod_cd[3].ToString());
            a[4] = int.Parse(prod_cd[4].ToString()) * 3;
            a[5] = int.Parse(prod_cd[5].ToString());
            a[6] = int.Parse(prod_cd[6].ToString()) * 3;
            a[7] = int.Parse(prod_cd[7].ToString());
            a[8] = int.Parse(prod_cd[8].ToString()) * 3;
            a[9] = int.Parse(prod_cd[9].ToString());
            a[10] = int.Parse(prod_cd[10].ToString()) * 3;
            a[11] = int.Parse(prod_cd[11].ToString());
            a[12] = int.Parse(prod_cd[12].ToString()) * 3;
            int sum = a[0] + a[1] + a[2] + a[3] + a[4] + a[5] + a[6] + a[7] + a[8] + a[9] + a[10] + a[11] + a[12];
            int check = (10 - (sum % 10)) % 10;
            // evaluate check digit
            int last = int.Parse(prod_cd[13].ToString());
            if (check == last) chk = true;

            return chk;
        }

        // Update Order status when picking in Siren
        public static ProcAction UpdateOrder(ProcAction action, string ordNo, string status, string cancelReason = "cancel")
        {
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE " + PRODUCT_ORDER);
            sql.Append(" SET status = #{status}, ");
            sql.Append(" updated_at = CURRENT_TIMESTAMP");

            if (STS_CANCEL.Equals(status))
            {
                sql.Append(", cancel_date = CURRENT_TIMESTAMP, ");
                sql.Append(" cancel_reason = #{cancel_reason} ");

                sql.Append(", if_cancel_yn = 'Y', ");
                sql.Append(" if_cancel_date = CURRENT_TIMESTAMP ");

                action.param.Add("cancel_reason", cancelReason);
            }

            sql.Append(" WHERE id = #{id}");

            action.text = sql.ToString();
            action.param.Add("status", status);
            action.param.Add("id", ordNo);

            return action;
        }
    }
}
