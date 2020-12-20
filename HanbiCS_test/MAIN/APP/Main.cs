using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraNavBar;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using WebUtil;
using CommonUtil;
using HanbiControl;
using System.Data.OleDb;
using System.Globalization;
using System.Threading;
using System.Configuration;
using COM;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace APP
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public string lang = "";
        public string skin = "";

        private APP_Login loginForm = null;

        System.Timers.Timer orderRecTimer;
        System.Timers.Timer orderStatusTimer;
        System.Timers.Timer cancelRecTimer;
        System.Timers.Timer checkVersionTimer;
        bool bolNewVersion = false;

        int alarmLevel = 0;
        bool bolFirst = true;
        COM.COM_HanNux Alarm;
        delegate void orderRecTimerEventFiredDelegate();
        delegate void SafeCallDelegate();

        DataTable dtServer;
        bool checkConnection = true;

        public Main()
        {
            COM.UserInfo.UserID = "system";
            COM.UserInfo.UserName = "시스템유저";


            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["AppPath"].Value = Application.StartupPath;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            AccessDB.Init();

            AccessDB.SetConfig("APP_path", Application.StartupPath);

            lang = AccessDB.GetConfig("lang");
            if (lang == null || lang == "")
            {
                lang = "ko";
                AccessDB.SetConfig("lang", lang);
            }
            string culture = CommonUtil.Converter.GetResource("culture_" + lang);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);


            InitializeComponent();

            SetOrderRecTimer();
            SetOrderStatusTimer();
            SetCancelRecTimer();

            barMain.Visible = false;
            barStatus.Visible = false;
            nav.Visible = false;

            SetCheckVersionRecTimer();
            List<string> downList = CheckUpdate();
            if (downList != null && downList.Count > 0)
            {
                APP_Version versionForm = new APP_Version();
                versionForm.Visible = false;
                this.Controls.Add(versionForm);
                versionForm.Dock = DockStyle.Fill;
                versionForm.BringToFront();
                versionForm.Visible = true;
                bool isAppChanged = versionForm.RunUpdate(downList);
                CommonUtil.AccessDB.SetVersion(dtServer);

                if (isAppChanged)
                {
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    this.Close();
                    return;
                }
            }

            APP_Login loginForm = new APP_Login();
            loginForm.Visible = false;
            this.Controls.Add(loginForm);
            loginForm.Dock = DockStyle.Fill;
            loginForm.BringToFront();
            loginForm.Visible = true;

            initSkin();

            initControls();

            RefreshMenu();

            COM.MainUtils.tabControl = this.tabControl;
            COM.MainUtils.bolConfirmMessage = true;
            Alarm = new COM.COM_HanNux();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Version versionForm = new Version();
            //versionForm.ShowDialog();
        }

        void SetOrderRecTimer()
        {
            //etInterface.Checked = false;
            orderRecTimer = new System.Timers.Timer();
            orderRecTimer.Interval = 1000;
            orderRecTimer.Elapsed += new System.Timers.ElapsedEventHandler(OrderRecTimerElapsed);
        }

        
        void OrderRecTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            orderRecTimer.Interval = 10 * 1000;

            JsonRequest request = new JsonRequest();

            ProcAction searchAction = request.NewAction();
            searchAction.proc = "sql";
            searchAction.text = "select CAST(id as char(20)) ord_no from kmarket.product_orders where status = 'O' and created_at is not null and if_order_yn = 'N' and CAST(market_id as char(20)) = #{loc_cd} order by id asc";
            searchAction.param.Add("loc_cd", COM.UserInfo.LocCode);

            ProcAction orderMoveAction = request.NewAction();
            orderMoveAction.proc = "sql";
            orderMoveAction.text = "insert into hanbibase.tb_so_order( ";
            orderMoveAction.text += "	ord_no, loc_cd, cust_id, full_name, ord_dt, delv_dt, email, mobile_no, tel_no, point_no, ";
            orderMoveAction.text += "    delv_tp, pay_tp, pay_info, ship_post_cd, ship_addr, ship_addr_dtl, ";
            orderMoveAction.text += "    price_total, price_delv, price_real, price_point, price_card, price_event_point, price_coupon, in_id, in_dt, up_id, up_dt) ";
            orderMoveAction.text += "SELECT CAST(a.id as char(20)) ord_no, CAST(a.market_id as char(20)) loc_cd, c.userid cust_id, a.recv_name full_name, ";
            //orderMoveAction.text += "	a.created_at ord_dt, a.send_date delv_dt, c.email, c.phone mobile_no, '' tel_no, point_no, ";
            orderMoveAction.text += "	a.created_at ord_dt, a.send_date delv_dt, c.email, a.recv_phone mobile_no, c.phone tel_no, point_no, ";
            //orderMoveAction.text += "    a.d_type delv_tp, case when a.purchase_type = 'C' then 'offline' else 'online' end pay_tp, e.cd_nm pay_info, '' ship_post_cd, a.recv_addr ship_addr, '' ship_addr_dtl, ";
            orderMoveAction.text += "    a.d_type delv_tp, case when a.purchase_type = 'C' then 'offline' else 'online' end pay_tp, e.cd_nm pay_info, '' ship_post_cd, a.recv_addr ship_addr, a.recv_addr_detail ship_addr_dtl, ";
            orderMoveAction.text += "    a.price_total, a.price_delivery price_delv, a.price_real, a.price_point, a.price_card, a.price_event_point, a.price_coupon, #{user_id}, now(), #{user_id}, now() ";
            orderMoveAction.text += "FROM kmarket.product_orders a ";
            orderMoveAction.text += "	left join kmarket.users c on a.user_id = c.id ";
            orderMoveAction.text += "   left join kmarket.sys_codes e on e.grp_cd = 'purchase_type' and a.purchase_type = e.cd ";
            orderMoveAction.text += "   left join kmarket.user_point_cards d on c.point_card_id  = d.id ";
            orderMoveAction.text += "where a.status = 'O' ";
            orderMoveAction.text += "	and a.created_at is not null ";
            orderMoveAction.text += "   and a.if_order_yn = 'N' ";
            orderMoveAction.text += "   and CAST(a.market_id as char(20)) = #{loc_cd} ";
            orderMoveAction.text += "order by a.id ";
            orderMoveAction.param.Add("user_id", COM.UserInfo.UserID);
            orderMoveAction.param.Add("loc_cd", COM.UserInfo.LocCode);

            ProcAction dtlMoveAction = request.NewAction();
            dtlMoveAction.proc = "sql";
            dtlMoveAction.text = "insert into tb_so_order_dtl(ord_id, ord_no, ord_seq, loc_cd, prod_cd, prod_nm, unit, ord_qty, unit_price, unit_sale_price, unit_delv_price, in_id, in_dt, up_id, up_dt) ";
            dtlMoveAction.text += "select (select ord_id from tb_so_order where ord_no = CAST(b.order_id as char(20))) ord_id, CAST(b.order_id as char(20)) ord_no, b.id ord_seq, ";
	        dtlMoveAction.text += "    CAST(a.market_id as char(20)) loc_cd, e.p_code prod_cd, b.product_name prod_nm, '' unit, ";
            dtlMoveAction.text += "    b.product_cnt ord_qty, b.price unit_price, b.sale_price unit_sale_price, b.delivery_price unit_delv_price, #{user_id}, now(), #{user_id}, now() ";
            dtlMoveAction.text += "from kmarket.product_orders a ";
	        dtlMoveAction.text += "    inner join kmarket.product_order_details b on a.id = b.order_id ";
            dtlMoveAction.text += "    left join kmarket.sys_codes d on d.grp_cd = 'purchase_type' and a.purchase_type = d.cd ";
            dtlMoveAction.text += "    left join kmarket.products e on b.product_id = e.id ";
            dtlMoveAction.text += "where a.status = 'O' and a.created_at is not null and a.if_order_yn = 'N' ";
            dtlMoveAction.text += "   and CAST(a.market_id as char(20)) = #{loc_cd} ";
            dtlMoveAction.text += "order by a.id, b.id ";
            dtlMoveAction.param.Add("user_id", COM.UserInfo.UserID);
            dtlMoveAction.param.Add("loc_cd", COM.UserInfo.LocCode);

            ProcAction updateAction = request.NewAction();
            updateAction.proc = "sql";
            updateAction.text = "update kmarket.product_orders set if_order_yn = 'Y', if_order_date = now() where status = 'O' and created_at is not null and if_order_yn = 'N' and CAST(market_id as char(20)) = #{loc_cd} ";
            updateAction.param.Add("loc_cd", COM.UserInfo.LocCode);

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (!client.check)
            {
                XtraMessageBox.Show(client.message, "Lỗi");
                return;
            }

            DataTable dt = ds.Tables[0];

            //if (CheckAlarmLevel(3))
            //{
            //    Alarm.SetLampLevel3();
            //    return;
            //}
            //else if (CheckAlarmLevel(2))
            //{
            //    Alarm.SetLampLevel2();
            //    return;
            //}

            if (dt.Rows.Count == 0) return;

            BeginInvoke(new orderRecTimerEventFiredDelegate(OrderRecTimerHandleUI));
        }

        private bool CheckAlarmLevel(int timeCase)
        {
            try
            {

                JsonRequest check = new JsonRequest();

                ProcAction checkAction = check.NewAction();

                checkAction.proc = "sql";
                checkAction.text = "select count(ord_no) as alarm_level from hanbibase.tb_so_order";
                checkAction.text += " where pick_ord_yn = 'N' and pick_yn = 'N' and delv_ord_yn = 'N' and delv_yn = 'N' and stop_yn = 'N' ";
                checkAction.text += " and TIMEDIFF(NOW(), up_dt) > #{time}";
                checkAction.text += " and loc_cd = #{loc_cd}";

                if (timeCase == 2) checkAction.param.Add("time", "00:03:00");
                else if (timeCase == 3) checkAction.param.Add("time", "00:05:00");
                else return false;

                checkAction.param.Add("loc_cd", COM.UserInfo.LocCode);

                WebClient clientCheck = new WebClient();
                DataSet dsCheck = clientCheck.Execute(check);

                if (!clientCheck.check)
                {
                    XtraMessageBox.Show(clientCheck.message, "Lỗi");
                    return false;
                }

                DataTable dt = dsCheck.Tables[0];
                if (dt.Rows.Count == 1)
                {
                    int level = 0;
                    if (int.TryParse(dt.Rows[0]["alarm_level"].ToString(), out level))
                    {
                        if (level > 0) return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                if (checkConnection)
                {
                    checkConnection = false;
                    //XtraMessageBox.Show("Has problem with the connection. \n Please check your Internet connection first.", "Lỗi");
                    XtraMessageBox.Show("Có vấn đề với kết nối. \nHãy kiểm tra lại kết nối Internet hiện tại trước tiên.", "Lỗi");
                }
                return false;
            }

        }
        private void OrderRecTimerHandleUI()
        {
            // TODO Ring alarm
            Alarm.GetLampStatus();
            Alarm.SetLampLevel1();
            //XtraMessageBox.Show("You have new orders.");

            // Search dashboard again
            RefreshDashboard();
            RefreshOrder();

            MaximumWindows();

        }

        private void SetOrderStatusTimer()
        {
            orderStatusTimer = new System.Timers.Timer();
            alarmLevel = 1;
            orderStatusTimer.Interval = 1000;
            orderStatusTimer.Elapsed += new System.Timers.ElapsedEventHandler(OrderStatusTimerElapsed);
            orderStatusTimer.AutoReset = true;
            orderStatusTimer.Start();
        }

        private void ResetOrderStatusTimer()
        {
            if (orderStatusTimer != null) orderStatusTimer.Stop();
            orderStatusTimer = null;
            bolFirst = true;
        }

        private void OrderStatusTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
             orderStatusTimer.Interval = 3 * 60 * 1000;

            if (CheckAlarmLevel(3))
            {
                alarmLevel = 3;
                if (!bolFirst) Alarm.SetLampLevel3();
                orderStatusTimer.Interval = 2 * 60 * 1000;
            }
            else if (CheckAlarmLevel(2))
            {
                alarmLevel = 2;
                if (!bolFirst) Alarm.SetLampLevel2();
                orderStatusTimer.Interval = 2 * 60 * 1000;
            }
            else
            {
                alarmLevel = 1;
                orderStatusTimer.Interval = 3 * 60 * 1000;
            }

            bolFirst = false;
        }

        List<string> CheckUpdate()
        {
            var assemblyPath = Assembly.GetEntryAssembly().Location;
            var assemblyDirectory = Path.GetDirectoryName(assemblyPath);

            if (assemblyDirectory.EndsWith(@"\Debug") || assemblyDirectory.EndsWith(@"\Release") || assemblyDirectory.EndsWith(@"\OUTPUT"))
            {
                return null;
            }

            DataTable dtLocal = AccessDB.GetVersion();
            dtServer = SearchVersion();

            List<string> downList = new List<string>();

            for (int i = 0; i < dtServer.Rows.Count; i++)
            {
                string serverFileNm = dtServer.Rows[i]["file_nm"].ToString();
                int serverFileVer = (int)dtServer.Rows[i]["file_ver"];
                bool bFind = false;
                for (int j = 0; j < dtLocal.Rows.Count; j++)
                {
                    string localFileNm = dtLocal.Rows[j]["file_nm"].ToString();
                    int localFileVer = (int)dtLocal.Rows[j]["file_ver"];

                    if (serverFileNm == localFileNm)
                    {
                        bFind = true;
                        if (serverFileVer != localFileVer)
                        {
                            downList.Add(serverFileNm);
                        }
                        break;
                    }
                }
                if (!bFind) {
                    downList.Add(serverFileNm);
                }
            }

            return downList;
        }

        public void AfterLogin()
        {
            ClearTap();
            RefreshMenu();

            lblUserName.Text = COM.UserInfo.UserName;
            lblLocName.Text = COM.UserInfo.LocName;
            etInterface.Checked = CommonUtil.AccessDB.GetConfig("if_flag") == "Y" ? true : false;
            etCancelSync.Checked = CommonUtil.AccessDB.GetConfig("cancel_flag") == "Y" ? true : false;

            this.Text = "K-Mart Siren Order Program : " + COM.UserInfo.LocName + ", " + COM.UserInfo.UserName;
            
            barMain.Visible = true;
            barStatus.Visible = true;
            nav.Visible = true;

            loginForm = null;

            

        }

        private void btnLogout_HbClick(object sender, EventArgs e)
        {
            //if (XtraMessageBox.Show("Do you want to Logout?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            if (XtraMessageBox.Show("Bạn có muốn đăng xuất hay không?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                COM.UserInfo.Clear();

                CommonUtil.AccessDB.SetConfig("login_info_save", "N");
                CommonUtil.AccessDB.SetConfig("user_id", "");
                CommonUtil.AccessDB.SetConfig("user_pw", "");

                CommonUtil.AccessDB.SetConfig("if_flag", "N");
                CommonUtil.AccessDB.SetConfig("cancel_flag", "N");
                etInterface.Checked = false;
                etCancelSync.Checked = false;

                barMain.Visible = false;
                barStatus.Visible = false;
                nav.Visible = false;

                loginForm = new APP_Login();
                loginForm.Visible = false;
                this.Controls.Add(loginForm);
                loginForm.Dock = DockStyle.Fill;
                loginForm.BringToFront();
                loginForm.Visible = true;
            }
        }

        DataTable SearchVersion()
        {
            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = "sql";
            action.text = "select * from tb_sys_version";

            WebUtil.WebClient client = new WebUtil.WebClient();
            DataSet ds = client.Execute(request);

            return ds.Tables[0];
        }

        private void updateTextDictionary()
        {
            DataTable dtLocal = AccessDB.GetTextDictionaryUpdateDataTable();
            if(dtLocal.Rows.Count == 0) {
                return;
            }

            JsonRequest request = new JsonRequest();

            for (int i = 0; i < dtLocal.Rows.Count; i++)
            {
                ProcAction deleteAction = request.NewAction();
                deleteAction.proc = "sql";
                deleteAction.text = "delete from tb_sys_text where id = #{id}";
                deleteAction.param.Add("id", dtLocal.Rows[i]["id"]);

                ProcAction insertAction = request.NewAction();
                insertAction.proc = "sql";
                insertAction.text = "insert into tb_sys_text(id, ko, en, vi) values(#{id}, #{ko}, #{en}, #{vi})";
                insertAction.param.Add("id", dtLocal.Rows[i]["id"]);
                insertAction.param.Add("ko", dtLocal.Rows[i]["ko"]);
                insertAction.param.Add("en", dtLocal.Rows[i]["en"]);
                insertAction.param.Add("vi", dtLocal.Rows[i]["vi"]);
            }

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

        }

        private void syncTextDictionnary()
        {
            JsonRequest request = new JsonRequest();

            ProcAction action1 = request.NewAction();
            action1.proc = "sql";
            action1.text = "select * from tb_sys_text";

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            DataTable dtDB = ds.Tables[0];

            AccessDB.SetTextDictionaryDataTable(dtDB);
        }

        private void initSkin()
        {
            skin = AccessDB.GetConfig("skin");
            if (skin == null || skin == "")
            {
                skin = "DevExpress Style";
                AccessDB.SetConfig("skin", skin);
            }
            this.LookAndFeel.SkinName = skin;

            barAndDockingController1.LookAndFeel.SkinName = skin;
            nav.LookAndFeel.SkinName = skin;
        }


        private void initControls()
        {
            string[] langs = CommonUtil.Converter.GetResource("languages").Split(',');
            List<Dictionary<string, object>> langList = new List<Dictionary<string, object>>();
            foreach (string lang in langs)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["value"] = lang;
                dic["name"] = CommonUtil.Converter.GetResource(lang);
                langList.Add(dic);
            }
            cbLang.DictionaryList = langList;
            cbLang.Value = this.lang;
            cbLang.HbTextChanged += new HanbiControl.clsControl.ChangeTextEventHandler(this.cbLang_HbTextChanged);

            List<Dictionary<string, object>> skinList = new List<Dictionary<string, object>>();
            foreach(DevExpress.Skins.SkinContainer skinContainer in DevExpress.Skins.SkinManager.Default.Skins) {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["value"] = skinContainer.SkinName;
                dic["name"] = skinContainer.SkinName;
                skinList.Add(dic);
            }
            cbSkin.DictionaryList = skinList;
            cbSkin.Value = skin;
            cbSkin.HbTextChanged += new HanbiControl.clsControl.ChangeTextEventHandler(this.cbSkin_HbTextChanged);


            //ProcAction actionSkin = new ProcAction();
            //actionSkin.proc = WebUtil.Values.PROC_SQL;
            //actionSkin.text = "select cd value, cd_nm name from tb_sys_code where grp_cd = 'skin' order by sort_seq asc";
            //cbSkin.ProcAction = actionSkin;
            //cbSkin.SetDataByProcAction();

        }


        private void RefreshMenu() {
            try
            {
                JsonRequest request = new JsonRequest();

                ProcAction action1 = request.NewAction();
                action1.proc = "sql";
                //action1.text = "WITH RECURSIVE CTE AS ( ";
                //action1.text += "    SELECT * ";
                //action1.text += "	FROM hanbibase.tb_sys_menu ";
                //action1.text += "	WHERE  menu_type = 'root' and use_yn = 'Y' ";
                //action1.text += "	UNION ALL ";
                //action1.text += "	SELECT a.* ";
                //action1.text += "	FROM hanbibase.tb_sys_menu a ";
                //action1.text += "		INNER JOIN CTE b ON a.parent_id = b.menu_id where a.use_yn = 'Y' ";
                //action1.text += ") ";
                //action1.text += "SELECT * FROM CTE";
                action1.table = "0";
                action1.text = "select  * ";
                action1.text += "from    (select * from hanbibase.tb_sys_menu where parent_id <= #{role_id} and use_yn = 'Y'";
                action1.text += "         order by parent_id, menu_id) products_sorted, ";
                action1.text += "        (select @pv := '1') initialisation ";
                action1.text += "where   find_in_set(parent_id, @pv) >= 0 ";
                action1.text += "and     @pv := concat(@pv, ',', menu_id) ";

                // Get menu base on Role ID
                if (String.IsNullOrEmpty(COM.UserInfo.RoleID) || (!String.IsNullOrEmpty(COM.UserInfo.RoleID) && COM.UserInfo.RoleID == "3"))
                {
                    // Role Admin
                    action1.param.Add("role_id", "2");
                }
                else if (!String.IsNullOrEmpty(COM.UserInfo.RoleID) && COM.UserInfo.RoleID == "2")
                {
                    // Role Office Manager
                    action1.param.Add("role_id", "1");
                }
                else if (!String.IsNullOrEmpty(COM.UserInfo.RoleID) && COM.UserInfo.RoleID == "1")
                {
                    // Role K-market Manager
                    action1.param.Add("role_id", "1");
                }
                else
                {
                    // Role K-market User
                    action1.param.Add("role_id", "0");
                }

                WebClient client = new WebClient();
                DataSet ds = client.Execute(request);

                if (ds == null)
                {
                    return;
                }

                DataTable dt = ds.Tables["0"];

                ClearMenu();

                barManager1.BeginUpdate();
                barManager1.MainMenu.BeginUpdate();
                bool appUser = false;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string type = dt.Rows[i]["menu_type"].ToString();
                    int depth = (int)dt.Rows[i]["depth"];

                    if (type == "root")
                    {

                        continue;
                    }

                    TreeList treeList = null;
                    if (dt.Rows[i]["menu_group"].ToString() == "admin")
                    {
                        treeList = treeAdmin;
                    }
                    else if (dt.Rows[i]["menu_group"].ToString() == "system")
                    {
                        treeList = treeSystem;
                    }
                    else
                    {
                        treeList = treeApp;
                    }

                    if (type == "menu")
                    {
                        MenuTabInfo info = new MenuTabInfo();
                        info.menuId = (int)dt.Rows[i]["menu_id"];
                        info.menuText = CommonUtil.Converter.GetNameDictionary(dt.Rows[i]["menu_name"].ToString());
                        info.dllName = dt.Rows[i]["dll_name"] as string;
                        info.className = dt.Rows[i]["class_name"] as string;
                        info.haveClose = dt.Rows[i]["close_yn"].ToString() == "Y" ? true : false;
                        info.canOpen = dt.Rows[i]["open_yn"].ToString() == "Y" ? true : false;
                        info.type = dt.Rows[i]["menu_type"] as string;

                        if (!info.haveClose)
                        {
                            OpenMenuTap(info);
                        }

                        if (dt.Rows[i]["menu_group"].ToString() == "app" && COM.UserInfo.RoleID == "0")
                        {
                            OpenMenuTap(info);
                            appUser = true;
                        }

                        //K-market Manager
                        if (!String.IsNullOrEmpty(COM.UserInfo.RoleID) && COM.UserInfo.RoleID == "1" &&
                            dt.Rows[i]["menu_group"].ToString() == "admin" && (info.className != "MA_Store_Order" && info.className != "MA_Store_Item" && info.className != "MA_Report_General")) 
                            continue;
                        else if (!String.IsNullOrEmpty(COM.UserInfo.RoleID) && COM.UserInfo.RoleID == "1" && COM.UserInfo.LocCode != "0" &&
                            dt.Rows[i]["menu_group"].ToString() == "admin" && (info.className == "MA_Store_Order" || info.className == "MA_Store_Item" || info.className == "MA_Report_General"))
                        {
                            OpenMenuTap(info);
                            appUser = true;
                        } else if(!String.IsNullOrEmpty(COM.UserInfo.RoleID) && (COM.UserInfo.RoleID == "1" || COM.UserInfo.RoleID == "2") && COM.UserInfo.LocCode == "0" &&
                            dt.Rows[i]["menu_group"].ToString() == "admin" && (info.className == "MA_Supplier_Order"))
                        {
                            OpenMenuTap(info);
                            appUser = true;
                        }

                        // 메인 메뉴 추가
                        BarSubItem item = new BarSubItem();
                        item.ItemAppearance.SetFont(new System.Drawing.Font("맑은 고딕", 9F));
                        item.ItemInMenuAppearance.SetFont(new System.Drawing.Font("맑은 고딕", 9F));
                        item.Id = info.menuId;
                        if (info.menuText.ContainsKey(lang))
                        {
                            item.Caption = info.menuText[lang];
                        }
                        else
                        {
                            item.Caption = "";
                        }
                        item.Name = "barItem" + info.menuId;
                        item.Tag = info;
                        item.Visibility = BarItemVisibility.Always;
                        if (info.canOpen)
                        {
                            item.ItemClick += new ItemClickEventHandler(this.barSubItem_ItemClick);
                        }

                        int parentId = (int)dt.Rows[i]["parent_id"];

                        barManager1.Items.Add(item);

                        if (depth == 1)
                        {
                            barMain.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(item));
                            barMain.AddItem(item);
                        }
                        else
                        {
                            for (int j = 0; j < barManager1.Items.Count; j++)
                            {
                                if (barManager1.Items[j].Id == parentId)
                                {
                                    MenuTabInfo itemInfo = barManager1.Items[j].Tag as MenuTabInfo;
                                    if (barManager1.Items[j].Tag != null && itemInfo.type == "menu")
                                    {
                                        BarSubItem parentItem = barManager1.Items[j] as BarSubItem;
                                        parentItem.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(item));
                                        break;
                                    }

                                }
                            }
                        }


                        // 네비 메뉴 추가
                        if (depth == 1)
                        {
                            treeList.BeginUnboundLoad();

                            string menuName;
                            if (info.menuText.ContainsKey(lang))
                            {
                                menuName = info.menuText[lang];
                            }
                            else
                            {
                                menuName = "";
                            }


                            TreeListNode node = treeList.AppendNode(
                                new object[] { menuName, info.menuId },
                                null);
                            node.Tag = info;

                            treeList.EndUnboundLoad();

                        }
                        else
                        {
                            for (int j = 0; j < nav.Controls.Count; j++)
                            {
                                TreeListNode parentNode = treeList.FindNodeByFieldValue("id", parentId);
                                if (parentNode != null)
                                {
                                    treeList.BeginUnboundLoad();
                                    string menuName;
                                    if (info.menuText.ContainsKey(lang))
                                    {
                                        menuName = info.menuText[lang];
                                    }
                                    else
                                    {
                                        menuName = "";
                                    }

                                    TreeListNode node = treeList.AppendNode(
                                        new object[] { menuName, info.menuId },
                                        parentNode);
                                    node.Tag = info;

                                    treeList.EndUnboundLoad();

                                    break;
                                }
                            }
                        }

                    }
                }
                barManager1.MainMenu.EndUpdate();
                barManager1.EndUpdate();

                this.Refresh();

                if (appUser)
                {
                    // Focus Home
                    foreach (XtraTabPage page in tabControl.TabPages)
                    {
                        MenuTabInfo curInfo = page.Tag as MenuTabInfo;
                        if (curInfo == null) continue;
                        if (curInfo.form.Name == "COM_Home")
                        {
                            tabControl.SelectedTabPage = page;
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                checkConnection = false;
                //XtraMessageBox.Show("Has problem with the connection. \n Please check your Internet connection first.", "Lỗi");
                XtraMessageBox.Show("Có vấn đề với kết nối. \n Hãy kiểm tra lại kết nối Internet hiện tại trước tiên.", "Lỗi");
            }
        }

        private void ClearMenu()
        {
            for (int i = barManager1.Items.Count - 1; i >= 0; i--)
            {
                if (barManager1.Items[i].Tag != null && barManager1.Items[i].Tag.ToString() == "menu")
                {
                    barManager1.Items.RemoveAt(i);
                }
            }

            treeApp.Nodes.Clear();
            treeAdmin.Nodes.Clear();
            treeSystem.Nodes.Clear();
            barMain.ClearLinks();

            for (int i = barMain.LinksPersistInfo.Count - 1; i >= 0; i--)
            {
                barMain.LinksPersistInfo.Remove(barMain.LinksPersistInfo[i]);
            }

        }

        private void ClearTap()
        {
            tabControl.TabPages.Clear();
        }

        private void MenuPageHide()
        {
            //adminPage.Visible = false;
            navGrpAdmin.Visible = false;
        }

        

        private void barSubItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BarSubItem subMenu = e.Item as BarSubItem;
            if (subMenu != null)
            {
                if (COM.MainUtils.tabControl != null ) this.tabControl = COM.MainUtils.tabControl;
                MenuTabInfo info = subMenu.Tag as MenuTabInfo;
                OpenMenuTap(info);
                COM.MainUtils.tabControl = this.tabControl;
            }
        }

        public void OpenMenuTap(MenuTabInfo info)
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
                    if (info.form != null && (info.form.Name == "COM_Home" || info.form.Name == "SOD_Order" || info.form.Name == "SOD_Pickup" || info.form.Name == "SOD_Delivery"))
                    {
                        RefreshDashboard();
                        RefreshOrder();
                    }
                    return;
                }
            }

            if (!info.canOpen)
            {
                return;
            }

            //stsClassName.Caption = info.dllName + "." + info.className;

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

                XtraUserControl form = Activator.CreateInstance(type) as XtraUserControl;
                info.form = form;
                form.Tag = info;
                form.Visible = false;

                ChangePublicButtonEnabled(info);

                page.Controls.Add(form);
                form.Dock = DockStyle.Fill;
                
                form.Visible = true;
                if (form.Name == "COM_Home" || form.Name == "SOD_Order" || form.Name == "SOD_Pickup" || form.Name == "SOD_Delivery" || form.Name == "SOD_Return") form.Focus();
            }
            catch (Exception err)
            {

            }

        }

        void ChangePublicButtonEnabled(MenuTabInfo info)
        {
            try
            {

                XtraUserControl form = info.form;

                MethodInfo mInfo = null;

                mInfo = form.GetType().GetMethod("Search", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
                if (mInfo == null)
                    btnSearch.Enabled = false;
                else
                    btnSearch.Enabled = true;

                mInfo = form.GetType().GetMethod("New", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
                if (mInfo == null)
                    btnNew.Enabled = false;
                else
                    btnNew.Enabled = true;

                mInfo = form.GetType().GetMethod("Save", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
                if (mInfo == null)
                    btnSave.Enabled = false;
                else
                    btnSave.Enabled = true;

                mInfo = form.GetType().GetMethod("Delete", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
                if (mInfo == null)
                    btnDelete.Enabled = false;
                else
                    btnDelete.Enabled = true;

                mInfo = form.GetType().GetMethod("Copy", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
                if (mInfo == null)
                    btnCopy.Enabled = false;
                else
                    btnCopy.Enabled = true;

                mInfo = form.GetType().GetMethod("Print", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
                if (mInfo == null)
                    btnPrint.Enabled = false;
                else
                    btnPrint.Enabled = true;
            }
            catch
            {
                return;
            }
        }

        private void tabControl_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (e.Page == null)
            {
                return;
            }
            MenuTabInfo info = e.Page.Tag as MenuTabInfo;
            ChangePublicButtonEnabled(info);
            if (info.form != null && (info.form.Name == "COM_Home" || info.form.Name == "SOD_Order" || info.form.Name == "SOD_Pickup" || info.form.Name == "SOD_Delivery" || info.form.Name == "SOD_Return")) info.form.Focus();
            if (info.form != null && (info.form.Name == "COM_Home" || info.form.Name == "SOD_Order" || info.form.Name == "SOD_Pickup" || info.form.Name == "SOD_Delivery"))
            {
                RefreshDashboard();
                RefreshOrder();
            }
            
        }

        private void tree_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void tree_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null) return;
            if(COM.MainUtils.tabControl != null) this.tabControl = COM.MainUtils.tabControl;
            MenuTabInfo info = e.Node.Tag as MenuTabInfo;
            OpenMenuTap(info);

            COM.MainUtils.tabControl = this.tabControl;
        }

        public void cbLang_HbTextChanged(object setnder, EventArgs e)
        {
            lang = cbLang.Value as string;
            AccessDB.SetConfig("lang", lang);

            string culture = CommonUtil.Converter.GetResource("culture_" + lang);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);

            for (int i = 0; i < barManager1.Items.Count; i++)
            {
                MenuTabInfo itemInfo = barManager1.Items[i].Tag as MenuTabInfo;
                if (barManager1.Items[i].Tag != null && itemInfo.type == "menu")
                {
                    BarSubItem item = barManager1.Items[i] as BarSubItem;
                    try
                    {
                        item.Caption = itemInfo.menuText[lang];
                    }
                    catch (Exception err)
                    {
                        item.Caption = "";
                    }
                    
                }
            }

            treeApp.BeginUnboundLoad();
            ChangeTreeNodeLang(treeApp.Nodes);
            treeApp.EndUnboundLoad();

            treeAdmin.BeginUnboundLoad();
            ChangeTreeNodeLang(treeAdmin.Nodes);
            treeAdmin.EndUnboundLoad();

            treeSystem.BeginUnboundLoad();
            ChangeTreeNodeLang(treeSystem.Nodes);
            treeSystem.EndUnboundLoad();

            Control.ControlCollection conColl = this.Controls;
            ChangeControlLang(conColl);
        }

        public void SetLang(string lang) {
            cbLang.Value = lang;
        }


        private void ChangeTreeNodeLang(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    ChangeTreeNodeLang(node.Nodes);
                }

                MenuTabInfo info = node.Tag as MenuTabInfo;

                node.SetValue("name", info.menuText[lang]);
            }
        }

        

        private void ChangeControlLang(Control.ControlCollection conColl)
        {
            foreach (Control con in conColl)
            {
                if (con.Controls.Count > 0)
                {
                    ChangeControlLang(con.Controls);
                }

                if (con is HbControl)
                {
                    ((HbControl)con).TextSync();
                }
                else if (con is DevExpress.XtraGrid.GridControl)
                {
                    DevExpress.XtraGrid.GridControl gridControl = con as DevExpress.XtraGrid.GridControl;
                    DevExpress.XtraGrid.Views.Grid.GridView gridView = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                    GridOption option = gridView.Tag as GridOption;
                    if (option != null)
                    {
                        option.ChangeLanguage(lang);
                    }
                }
            }
        }

        private void cbSkin_HbTextChanged(object setnder, EventArgs e)
        {
            skin = cbSkin.Value as string;
            AccessDB.SetConfig("skin", skin);

            this.LookAndFeel.SkinName = skin;
            barAndDockingController1.LookAndFeel.SkinName = skin;
            nav.LookAndFeel.SkinName = skin;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            XtraTabPage page = tabControl.SelectedTabPage;
            if (page == null) return;

            MenuTabInfo info = page.Tag as MenuTabInfo;
            if (info == null) return;
            
            XtraUserControl form = info.form;
            if (form == null) return;

            MethodInfo mInfo = null;

            mInfo = form.GetType().GetMethod("Search", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
            if (mInfo != null) {
                mInfo.Invoke(form, null);
            }
            if (form.Name == "COM_Home" || form.Name == "SOD_Order" || form.Name == "SOD_Pickup" || form.Name == "SOD_Delivery" || form.Name == "SOD_Return") form.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            XtraTabPage page = tabControl.SelectedTabPage;
            if (page == null) return;

            MenuTabInfo info = page.Tag as MenuTabInfo;
            if (info == null) return;

            XtraUserControl form = info.form;
            if (form == null) return;

            MethodInfo mInfo = null;

            mInfo = form.GetType().GetMethod("New", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
            if (mInfo != null)
            {
                mInfo.Invoke(form, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            XtraTabPage page = tabControl.SelectedTabPage;
            if (page == null) return;

            MenuTabInfo info = page.Tag as MenuTabInfo;
            if (info == null) return;

            XtraUserControl form = info.form;
            if (form == null) return;

            MethodInfo mInfo = null;

            mInfo = form.GetType().GetMethod("Save", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
            if (mInfo != null)
            {
                mInfo.Invoke(form, null);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            XtraTabPage page = tabControl.SelectedTabPage;
            if (page == null) return;

            MenuTabInfo info = page.Tag as MenuTabInfo;
            if (info == null) return;

            XtraUserControl form = info.form;
            if (form == null) return;

            MethodInfo mInfo = null;

            mInfo = form.GetType().GetMethod("Delete", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
            if (mInfo != null)
            {
                mInfo.Invoke(form, null);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            XtraTabPage page = tabControl.SelectedTabPage;
            if (page == null) return;

            MenuTabInfo info = page.Tag as MenuTabInfo;
            if (info == null) return;

            XtraUserControl form = info.form;
            if (form == null) return;

            MethodInfo mInfo = null;

            mInfo = form.GetType().GetMethod("Copy", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
            if (mInfo != null)
            {
                mInfo.Invoke(form, null);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            XtraTabPage page = tabControl.SelectedTabPage;
            if (page == null) return;

            MenuTabInfo info = page.Tag as MenuTabInfo;
            if (info == null) return;

            XtraUserControl form = info.form;
            if (form == null) return;

            MethodInfo mInfo = null;

            mInfo = form.GetType().GetMethod("Print", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
            if (mInfo != null)
            {
                mInfo.Invoke(form, null);
                if (form.Name == "COM_Home" || form.Name == "SOD_Order" || form.Name == "SOD_Pickup" || form.Name == "SOD_Delivery" || form.Name == "SOD_Return") form.Focus();
            }
        }

        private void tabControl_CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            XtraTabPage page = arg.Page as XtraTabPage;
            tabControl.TabPages.Remove(page);
            (arg.Page as XtraTabPage).PageVisible = false;
        }

        private void etInterface_HbCheckedChanged(object sender, EventArgs e)
        {
            if (etInterface.Checked)
            {
                orderRecTimer.Interval = 1000;
                orderRecTimer.Start();
            }
            else
            {
                orderRecTimer.Stop();
            }
        }

        private void RefreshDashboard()
        {
            // Search dashboard again
            XtraTabPage page = tabControl.SelectedTabPage;
            if (page == null) return;

            MenuTabInfo info = page.Tag as MenuTabInfo;
            if (info == null) return;
            if (info.className != "COM_Home") return;

            XtraUserControl form = info.form;
            if (form == null) return;

            MethodInfo mInfo = null;
            mInfo = form.GetType().GetMethod("Search", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
            if (mInfo != null)
            {
                mInfo.Invoke(form, null);
            }
            form.Focus();
        }

        private void RefreshOrder()
        {
            XtraTabPage page = tabControl.SelectedTabPage;
            if (page == null) return;

            MenuTabInfo curInfo = page.Tag as MenuTabInfo;
            if (curInfo == null) return;
            if (curInfo.className == "SOD_Order" || curInfo.className == "SOD_Pickup" || curInfo.className == "SOD_Delivery")
            {

                XtraUserControl form = curInfo.form;
                if (form == null) return;

                MethodInfo mInfo = null;
                mInfo = form.GetType().GetMethod("Research", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null);
                if (mInfo != null)
                {
                    mInfo.Invoke(form, null);
                }
                form.Focus();
            }

        }

        // Sync cancel order make from shopping mall
        private void etCancelSync_HbCheckedChanged(object sender, EventArgs e)
        {
            if (etCancelSync.Checked)
            {
                cancelRecTimer.Interval = 1000;
                cancelRecTimer.Start();
            }
            else
            {
                cancelRecTimer.Stop();
            }
        }

        private void SetCancelRecTimer()
        {
            cancelRecTimer = new System.Timers.Timer();
            cancelRecTimer.Interval = 1000;
            cancelRecTimer.Elapsed += new System.Timers.ElapsedEventHandler(CancelRecTimerElapsed);
        }


        private void CancelRecTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            cancelRecTimer.Interval = 10 * 1000;
            StringBuilder query = new StringBuilder();

            WebClient client = new WebClient();
            JsonRequest checkCancelOrder = new JsonRequest();

            ProcAction searchCancel = checkCancelOrder.NewAction();
            searchCancel.proc = "sql";
            query.Append(" SELECT A.id, A.market_id, A.`status`, A.if_cancel_yn, A.if_cancel_date, ");
            query.Append(" B.pick_ord_yn, B.pick_yn, B.delv_ord_yn, B.delv_yn, B.stop_yn ");
            query.Append(" FROM kmarket.product_orders A ");
            query.Append(" INNER JOIN hanbibase.tb_so_order B on A.id = B.ord_no and A.market_id = B.loc_cd ");
            query.Append(" WHERE (A.status = 'C1' OR A.status = 'C2') AND A.if_order_yn = 'Y'");
            query.Append(" AND A.if_cancel_yn = 'N' ");
            query.Append(" AND B.delv_yn = 'N' AND B.stop_yn = 'N'");
            query.Append(" AND CAST(A.market_id as char(20)) = #{loc_cd}");

            searchCancel.text = query.ToString();
            searchCancel.table = "cancel";
            searchCancel.param.Add("loc_cd", COM.UserInfo.LocCode);

            DataSet ds = client.Execute(checkCancelOrder);
            if (!client.check || ds == null) return;

            DataTable cancelTable = ds.Tables["cancel"];
            if (cancelTable.Rows.Count <= 0) return;
            JsonRequest syncOrder = new JsonRequest();

            StringBuilder queryHanbibase = new StringBuilder();
            StringBuilder queryKmarket = new StringBuilder();
            string syncOrderNo = String.Empty;
            int countSyncCancel = 0;

            for (countSyncCancel = 0; countSyncCancel < cancelTable.Rows.Count; countSyncCancel++)
            {
                if (cancelTable.Rows[countSyncCancel]["status"].ToString() == "C1")
                {
                    string msg = COM.CommonUtils.cancelPayment(Convert.ToInt32(cancelTable.Rows[countSyncCancel]["id"].ToString()));
                    if (msg != null)
                    {
                        continue;
                    }
                }

                syncOrderNo = cancelTable.Rows[countSyncCancel]["id"].ToString();

                ProcAction updateHanbibase = syncOrder.NewAction();
                updateHanbibase.proc = "sql";
                ProcAction updateKmarket = syncOrder.NewAction();
                updateKmarket.proc = "sql";

                queryHanbibase.Clear();
                queryKmarket.Clear();
                // Update hanbibase.tb_so_order
                queryHanbibase.Append(" UPDATE hanbibase.tb_so_order ");
                queryHanbibase.Append(" SET stop_yn = #{stop_yn}, stop_reason = #{stop_reason},");
                queryHanbibase.Append(" up_dt = CURRENT_TIMESTAMP,");
                queryHanbibase.Append(" up_id = #{up_id}");
                queryHanbibase.Append(" WHERE ord_no = #{ord_no}");
                queryHanbibase.Append(" AND loc_cd = #{loc_cd} ");

                // Update kmarket.product_orders
                queryKmarket.Append(" UPDATE kmarket.product_orders ");
                queryKmarket.Append(" SET `status` = #{status}, updated_at = CURRENT_TIMESTAMP,");
                queryKmarket.Append(" if_cancel_yn = #{stop_yn}, if_cancel_date = CURRENT_TIMESTAMP");
                queryKmarket.Append(" WHERE id = #{ord_no} ");


                updateHanbibase.text = queryHanbibase.ToString();
                updateHanbibase.param.Add("stop_yn", "Y");
                updateHanbibase.param.Add("stop_reason", "Cancel by Customer");
                updateHanbibase.param.Add("up_id", COM.UserInfo.UserID);
                updateHanbibase.param.Add("ord_no", syncOrderNo);
                updateHanbibase.param.Add("loc_cd", COM.UserInfo.LocCode);

                updateKmarket.text = queryKmarket.ToString();
                updateKmarket.param.Add("status", "C");
                updateKmarket.param.Add("stop_yn", "Y");
                updateKmarket.param.Add("ord_no", syncOrderNo);
            }
            if (countSyncCancel > 0)
            {

                client = new WebClient();
                ds = client.Execute(syncOrder);

                if (client.check)
                {
                    // Sync Success
                    Alarm.SetLampLevel2();

                    //XtraMessageBox.Show(" Have " + countSyncCancel + " order has been canceled by customer. Please refresh order information.", "Thông báo");
                    XtraMessageBox.Show(" Có " + countSyncCancel + " đơn hàng được hủy bởi khách hàng.\n Hãy làm mới lại danh sách đặt hàng, lấy hàng, giao hàng.", "Thông báo");

                    BeginInvoke(new SafeCallDelegate(RefreshDashboard));
                    BeginInvoke(new SafeCallDelegate(RefreshOrder));
                }
                else
                {
                    XtraMessageBox.Show(client.message, "Lỗi");
                    return;
                }
            }
        }

        private void SetCheckVersionRecTimer()
        {
            checkVersionTimer = new System.Timers.Timer();
            checkVersionTimer.Interval = 10 * 60 *1000;               // Default 10 mins
            checkVersionTimer.Elapsed += new System.Timers.ElapsedEventHandler(CheckVersionTimerElapsed);
            checkVersionTimer.Start();
        }

        private void StopCheckVersionRecTimer()
        {
            if (checkVersionTimer != null) checkVersionTimer.Stop();

        }

        private void CheckVersionTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            checkVersionTimer.Interval = 10 * 60 * 1000;

            List<string> downList = CheckUpdate();
            if (downList != null && downList.Count > 0 )
            {
                APP_Version versionForm = new APP_Version();
                versionForm.Visible = false;
                this.Controls.Add(versionForm);
                versionForm.Dock = DockStyle.Fill;
                versionForm.BringToFront();
                versionForm.Visible = true;
                bool isAppChanged = versionForm.RunUpdate(downList);
                CommonUtil.AccessDB.SetVersion(dtServer);

                if (isAppChanged)
                {
                    bolNewVersion = true;
                }
            }

            //if (XtraMessageBox.Show(" This application have new version. Do you want to update and restart this application?", "확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
            if (bolNewVersion && XtraMessageBox.Show("Ứng dụng đã có bản cập nhật mới. \nBạn có muốn cập nhật và khởi động lại ứng dụng không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                bolNewVersion = false;
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                Application.Exit();
                return;
            }
        }

        private const int SW_MAXIMIZE = 3;
        private const int SW_MINIMIZE = 6;

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        private void MaximumWindows()
        {
            IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
            if (handle == IntPtr.Zero) return;
            ShowWindow(handle, SW_MAXIMIZE);
            SetForegroundWindow(handle);
        }
    }
}