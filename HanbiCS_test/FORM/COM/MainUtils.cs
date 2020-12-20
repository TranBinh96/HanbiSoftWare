using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WebUtil;
using CommonUtil;
using HanbiControl;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.XtraTab;
using DevExpress.XtraEditors;

namespace COM
{
    public class MainUtils
    {
        public static XtraTabControl tabControl { get; set; }

        // Parameters
        public static string ord_no { get; set; }
        public static string pick_ord_yn { get; set; }
        public static string pick_yn { get; set; }
        public static string delv_ord_yn { get; set; }
        public static string delv_yn { get; set; }

        public static string searchDate { get; set; }

        public static bool bolConfirmMessage { get; set; }

        public static void OpenTab(string dllName, string className, bool finishDelivery = false)
        {
            if (String.IsNullOrEmpty(dllName) || String.IsNullOrEmpty(className)) return;

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = "sql";
            action.text = "SELECT menu_id, menu_name, dll_name, class_name, close_yn, open_yn, menu_type";
            action.text += " FROM tb_sys_menu ";
            action.text += " WHERE dll_name = #{dll_name} AND class_name = #{class_name}";
            action.table = "0";

            action.param.Add("dll_name", dllName);
            action.param.Add("class_name", className);

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (ds == null)
            {
                return;
            }

            DataTable dt = ds.Tables["0"];

            MenuTabInfo info = new MenuTabInfo();
            if (dt.Rows.Count == 1)
            {
                info.menuId = (int)dt.Rows[0]["menu_id"];
                info.menuText = CommonUtil.Converter.GetNameDictionary(dt.Rows[0]["menu_name"].ToString());
                info.dllName = dt.Rows[0]["dll_name"] as string;
                info.className = dt.Rows[0]["class_name"] as string;
                info.haveClose = dt.Rows[0]["close_yn"].ToString() == "Y" ? true : false;
                info.canOpen = dt.Rows[0]["open_yn"].ToString() == "Y" ? true : false;
                info.type = dt.Rows[0]["menu_type"] as string;

                OpenMenuTap(info, finishDelivery);
            }
        }

        private static void OpenMenuTap(MenuTabInfo info, bool finishDelivery = false)
        {
            if (info == null) return;

            foreach (XtraTabPage page in tabControl.TabPages)
            {
                MenuTabInfo curInfo = page.Tag as MenuTabInfo;
                if (curInfo == null) continue;
                if (curInfo.menuId == info.menuId)
                {
                    tabControl.SelectedTabPage = page;
                    if (curInfo.form != null && (curInfo.form.Name == "COM_Home" || curInfo.form.Name == "SOD_Order" || curInfo.form.Name == "SOD_Pickup" || curInfo.form.Name == "SOD_Delivery" || curInfo.form.Name == "SOD_Return")) curInfo.form.Focus();

                    XtraUserControl form = curInfo.form;
                    if (form == null) return;

                    MethodInfo mInfo = null;
                    if (!String.IsNullOrEmpty(ord_no)) 
                    {
                        PropertyInfo ordNo = form.GetType().GetProperty("ordNo");
                        ordNo.SetValue(form, ord_no);

                        if (curInfo.form.Name == "SOD_Delivery" && finishDelivery)
                        {
                            bolConfirmMessage = true;
                            mInfo = form.GetType().GetMethod("InitFromDoubleClickAndHandle", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
                        }
                        else mInfo = form.GetType().GetMethod("InitFromDoubleClick", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);

                        ord_no = String.Empty;
                         
                    }
                    else if (!(String.IsNullOrEmpty(pick_ord_yn) && String.IsNullOrEmpty(pick_yn)
                      && String.IsNullOrEmpty(delv_ord_yn) && String.IsNullOrEmpty(delv_yn)))
                    {
                        PropertyInfo pickOrdYn = form.GetType().GetProperty("pickOrdYn");
                        pickOrdYn.SetValue(form, pick_ord_yn);
                        PropertyInfo pickYn = form.GetType().GetProperty("pickYn");
                        pickYn.SetValue(form, pick_yn);
                        PropertyInfo delvOrdYn = form.GetType().GetProperty("delvOrdYn");
                        delvOrdYn.SetValue(form, delv_ord_yn);
                        PropertyInfo delvYn = form.GetType().GetProperty("delvYn");
                        delvYn.SetValue(form, delv_yn);

                        mInfo = form.GetType().GetMethod("InitFromDoubleClick", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);

                    }
                    else
                    {
                        mInfo = form.GetType().GetMethod("Search", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
                        
                    }

                    if (mInfo != null)
                    {
                        mInfo.Invoke(form, null);
                    }
                    return;
                }
            }

            if (!info.canOpen)
            {
                return;
            }

            try
            {

                XtraTabPage page = new XtraTabPage();
                page.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
                page.Text = info.menuText[AccessDB.GetConfig("lang")];
                page.Tag = info;
                page.Font = new System.Drawing.Font("맑은 고딕", 9F);
                page.Appearance.Header.Font = new System.Drawing.Font("맑은 고딕", 9F);
                page.Appearance.HeaderActive.Font = new System.Drawing.Font(page.Font.FontFamily.Name, page.Font.Size, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                page.Appearance.HeaderDisabled.Font = new System.Drawing.Font("맑은 고딕", 9F);
                page.Appearance.HeaderHotTracked.Font = new System.Drawing.Font("맑은 고딕", 9F);
                page.Appearance.PageClient.Font = new System.Drawing.Font("맑은 고딕", 9F);
                page.ShowCloseButton = info.haveClose ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;


                tabControl.TabPages.Add(page);
                tabControl.SelectedTabPage = page;

                string dllPath = Application.StartupPath + @"\" + info.dllName + @".dll";
                Type type = null;
                try
                {
                    Assembly asm = Assembly.LoadFrom(dllPath);
                    type = asm.GetType(info.dllName + "." + info.className);
                }
                catch (Exception er)
                {
                    type = null;
                }

                if (type == null)
                {
                    return;
                }

                XtraUserControl form = null;
                bolConfirmMessage = true;

                if (!String.IsNullOrEmpty(ord_no)) 
                { 
                    form = Activator.CreateInstance(type, ord_no) as XtraUserControl;
                    ord_no = String.Empty;

                } else if (!(String.IsNullOrEmpty(pick_ord_yn) && String.IsNullOrEmpty(pick_yn)
                    && String.IsNullOrEmpty(delv_ord_yn) && String.IsNullOrEmpty(delv_yn)))
                {
                    form = Activator.CreateInstance(type, pick_ord_yn, pick_yn, delv_ord_yn, delv_yn) as XtraUserControl;
                }
                else 
                { 
                    form = Activator.CreateInstance(type) as XtraUserControl;
                }

                if (form == null) return;
                info.form = form;
                form.Tag = info;
                form.Visible = false;


                page.Controls.Add(form);
                form.Dock = DockStyle.Fill;

                form.Visible = true;
                if (form.Name == "COM_Home" || form.Name == "SOD_Order" || form.Name == "SOD_Pickup" || form.Name == "SOD_Delivery" || form.Name == "SOD_Return") form.Focus();

                //MethodInfo mInfo = null;
                //if (!String.IsNullOrEmpty(ord_no))
                //{
                //    PropertyInfo ordNo = form.GetType().GetProperty("ordNo");
                //    ordNo.SetValue(form, ord_no);
                //
                //    if (form.Name == "SOD_Delivery" && finishDelivery) mInfo = form.GetType().GetMethod("InitFromDoubleClickAndHandle", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
                //    else mInfo = form.GetType().GetMethod("InitFromDoubleClick", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
                //    ord_no = String.Empty;
                //
                //}
                //else if (!(String.IsNullOrEmpty(pick_ord_yn) && String.IsNullOrEmpty(pick_yn)
                //  && String.IsNullOrEmpty(delv_ord_yn) && String.IsNullOrEmpty(delv_yn)))
                //{
                //    PropertyInfo pickOrdYn = form.GetType().GetProperty("pickOrdYn");
                //    pickOrdYn.SetValue(form, pick_ord_yn);
                //    PropertyInfo pickYn = form.GetType().GetProperty("pickYn");
                //    pickYn.SetValue(form, pick_yn);
                //    PropertyInfo delvOrdYn = form.GetType().GetProperty("delvOrdYn");
                //    delvOrdYn.SetValue(form, delv_ord_yn);
                //    PropertyInfo delvYn = form.GetType().GetProperty("delvYn");
                //    delvYn.SetValue(form, delv_yn);
                //
                //    mInfo = form.GetType().GetMethod("InitFromDoubleClick", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
                //
                //}
                //else
                //{
                //    mInfo = form.GetType().GetMethod("Search", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
                //
                //}
                //
                //if (mInfo != null)
                //{
                //    mInfo.Invoke(form, null);
                //}

            }
            catch (Exception err)
            {

            }
        }

        public static void SetParameter(string ord_no, string pick_ord_yn, string pick_yn, string delv_ord_yn, string delv_yn)
        {
            MainUtils.ord_no = ord_no;
            MainUtils.pick_ord_yn = pick_ord_yn;
            MainUtils.pick_yn = pick_yn;
            MainUtils.delv_ord_yn = delv_ord_yn;
            MainUtils.delv_yn = delv_yn;
        }

        public static void ResetParameter()
        {
            MainUtils.ord_no = String.Empty;
            MainUtils.pick_ord_yn = String.Empty;
            MainUtils.pick_yn = String.Empty;
            MainUtils.delv_ord_yn = String.Empty;
            MainUtils.delv_yn = String.Empty;
        }

        public static void SetSearchDate(string date)
        {
            searchDate = date;
        }

        public static void ResetSearchDate()
        {
            searchDate = DateTime.Today.ToString("yyyy-MM-dd");
        }

        /*
         * flagOrder:
         *              1: Orders
         *              2: Picking
         *              3: Delivering
         * 
         */
        public static bool CheckOrders(string flagOrder)
        {
            bool result = false;

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = "sql";
            action.text = "SELECT A.ord_no, B.pick_no, C.delv_no, A.pick_ord_yn, A.pick_yn,";
            action.text += " A.delv_ord_yn, A.delv_yn, A.stop_yn, B.pick_sts, C.delv_yn";
            action.text += " FROM tb_so_order A LEFT JOIN tb_so_pick B ON A.ord_no = B.ord_no ";
            action.text += " LEFT JOIN tb_so_delv C ON A.ord_no = C.ord_no AND A.delv_yn = C.delv_yn";
            action.text += " WHERE A.ord_no = #{ord_no}";
            action.table = "0";

            action.param.Add("ord_no", ord_no);

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (ds == null) return result;

            DataTable dt = ds.Tables["0"];
            if (dt.Rows.Count != 1)  return result;

            string pickOrdYn = dt.Rows[0]["pick_ord_yn"].ToString();
            string pickYn = dt.Rows[0]["pick_yn"].ToString();
            string delvOrdYn = dt.Rows[0]["delv_ord_yn"].ToString();
            string delvYn = dt.Rows[0]["delv_yn"].ToString();
            string stopYn = dt.Rows[0]["pick_ord_yn"].ToString();
            string pickSts = dt.Rows[0]["pick_sts"].ToString();
            string pickNo = dt.Rows[0]["pick_no"].ToString();
            string delvNo = dt.Rows[0]["delv_no"].ToString();

            switch (flagOrder)
            {
                case "1":
                    // Orders have not been picked
                    break;
                case "2":
                    // Picking is already to finished
                    if (pickYn == "Y" && pickSts == "done" && delvOrdYn == "N" && stopYn == "N")
                    {
                        if (XtraMessageBox.Show("Đơn lấy hàng " + pickNo + " đã hoàn thành. \nBạn có muốn thực hiện giao hàng cho đơn đặt hàng này không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            if (MakeDelivery())
                            {
                                result = true;
                            }
                        }
                    }
                    break;
                case "3":
                    // Delivering is already to finished
                    if (delvOrdYn == "Y" && delvYn == "N" && stopYn == "N")
                    {
                        if (XtraMessageBox.Show("Đơn giao hàng " + delvNo + " chưa hoàn thành. \nBạn có muốn đánh dấu là đã giao hàng thành công hay không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            result = true;
                        }
                    }
                    break;
            };

            return result;
        }

        private static bool MakeDelivery()
        {
             string delvNo = getNextNo("DL");

             if (String.IsNullOrEmpty(delvNo))
             {
                 return false;
             }

             JsonRequest request = new JsonRequest();
             StringBuilder sql = new StringBuilder();

             // Update Order
             ProcAction updateOrder = request.NewAction();
             updateOrder.proc = WebUtil.Values.PROC_SQL;

             sql.Append("UPDATE tb_so_order");
             sql.Append(" SET delv_ord_yn = #{delv_ord_yn}, up_id = #{up_id}, up_dt = CURRENT_TIMESTAMP");
             sql.Append(" WHERE ord_no = #{ord_no}");

             updateOrder.text = sql.ToString();
             updateOrder.param.Add("delv_ord_yn", "Y");
             updateOrder.param.Add("up_id", COM.UserInfo.UserID);
             updateOrder.param.Add("ord_no", ord_no);

             // Create Delivery
             ProcAction insertDelv = request.NewAction();
             insertDelv.proc = WebUtil.Values.PROC_SQL;

             sql.Clear();
             sql.Append("INSERT INTO tb_so_delv");
             sql.Append(" (delv_id, delv_no, ord_id, ord_no, loc_cd,");
             sql.Append(" cust_id, full_name, email, mobile_no, tel_no,");
             sql.Append(" ord_dt, delv_dt, delv_tp, pay_tp, pay_info, ship_post_cd, ship_addr, ship_addr_dtl,");
             sql.Append(" price_total, price_delv, price_point, price_card, price_real, delv_yn, in_id, in_dt)");

             sql.Append(" SELECT ord_id, #{delv_no}, ord_id, #{ord_no}, loc_cd,");
             sql.Append(" cust_id, full_name, email, mobile_no, tel_no,");
             sql.Append(" ord_dt, delv_dt, delv_tp, pay_tp, pay_info, ship_post_cd, ship_addr, ship_addr_dtl, ");
             sql.Append(" price_total, price_delv, price_point, price_card, price_real, delv_yn, #{in_id}, CURRENT_TIMESTAMP");
             sql.Append(" FROM tb_so_order WHERE ord_no = #{ord_no}");

             insertDelv.text = sql.ToString();
             insertDelv.param.Add("delv_no", delvNo);                                                    // delv_no
             insertDelv.param.Add("ord_no", ord_no);                                                     // ord_no
             insertDelv.param.Add("in_id", COM.UserInfo.UserID);                                         // in_id

             // Create Delivery detail
             ProcAction insertDelvDtl = request.NewAction();
             insertDelvDtl.proc = WebUtil.Values.PROC_SQL;

             sql.Clear();
             sql.Append("INSERT INTO tb_so_delv_dtl");
             sql.Append(" (delv_id, delv_no, delv_seq, ord_dtl_id, ord_id,");
             sql.Append(" ord_no, ord_seq, loc_cd, prod_cd, prod_nm,");
             sql.Append(" unit, ord_qty, unit_price, unit_sale_price,");
             sql.Append(" unit_delv_price, in_id, in_dt)");
             sql.Append(" SELECT ord_id, #{delv_no}, ord_seq, ord_dtl_id, ord_id,");
             sql.Append(" ord_no, ord_seq, loc_cd, prod_cd, prod_nm,");
             sql.Append(" unit, ord_qty, unit_price, unit_sale_price,");
             sql.Append(" unit_delv_price, #{in_id}, CURRENT_TIMESTAMP");
             sql.Append(" FROM tb_so_order_dtl WHERE ord_no = #{ord_no}");

             insertDelvDtl.text = sql.ToString();
             insertDelvDtl.param.Add("delv_no", delvNo);                                          // delv_no
             insertDelvDtl.param.Add("in_id", COM.UserInfo.UserID);                               // in_id
             insertDelvDtl.param.Add("ord_no", ord_no);

             WebClient client = new WebClient();
             DataSet ds = client.Execute(request);

             if (client.check)
             {
                 //XtraMessageBox.Show("피킹 성공.", "성공");
                 //XtraMessageBox.Show("Sẵn sàng giao hàng.", "Thông báo");

                 COM.PrintFormats.PrintDelivery(ord_no);
                 return true;
             }
             else
             {
                 //XtraMessageBox.Show("피킹에 실패: " + client.message, "실패");
                 XtraMessageBox.Show("Có lỗi xảy ra: \n" + client.message, "Lỗi");
             }

             return false;
        }

        private static string getNextNo(string prefix)
        {
            string nextNo = String.Empty;

            JsonRequest request = new JsonRequest();
            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            action.text = " SELECT get_next_no(#{p_prefix}, #{p_no_dt}) AS next_no";
            action.param.Add("p_prefix", prefix);
            action.param.Add("p_no_dt", DateTime.Now.ToString("yyyyMMdd"));

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                nextNo = ds.Tables[0].Rows[0]["next_no"].ToString();
            }

            return nextNo;
        }

    }

    public class MenuTabInfo
    {
        public int menuId;
        public Dictionary<string, string> menuText;
        public XtraUserControl form;
        public string dllName;
        public string className;
        public bool haveClose;
        public bool canOpen;
        public string type;
    }
}
