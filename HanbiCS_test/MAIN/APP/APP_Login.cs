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

namespace APP
{
    public partial class APP_Login : DevExpress.XtraEditors.XtraUserControl
    {
        public APP_Login()
        {
            InitializeComponent();
        }

        private void APP_Login_Load(object sender, EventArgs e)
        {
            initControls();
        }

        private void initControls()
        {
            Main mainForm = (Main)this.Parent;

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
            cbLang.Value = mainForm.lang;
            cbLang.HbTextChanged += new HanbiControl.clsControl.ChangeTextEventHandler(cbLang_HbTextChanged);

            string saveLoginInfo = CommonUtil.AccessDB.GetConfig("login_info_save");
            if (saveLoginInfo == null || saveLoginInfo == "")
            {
                saveLoginInfo = "N";
                CommonUtil.AccessDB.SetConfig("login_info_save", "N");
            }
            chkLoginInfoSave.Value = saveLoginInfo;

            if (saveLoginInfo == "Y")
            {
                string userId = CommonUtil.AccessDB.GetConfig("user_id");
                if (userId == null)
                    userId = "";
                string userPw = CommonUtil.AccessDB.GetConfig("user_pw");
                if (userPw == null)
                    userPw = "";
                if (userPw != "")
                {
                    userPw = CommonUtil.Converter.Decrypt(userPw);
                }
                etId.Text = userId;
                etPw.Text = userPw;
            }
        }

        private void APP_Login_Resize(object sender, EventArgs e)
        {
            grpLogin.Left = (this.ClientSize.Width - grpLogin.Width) / 2;
            grpLogin.Top = (this.ClientSize.Height - grpLogin.Height) / 2;
        }

        private void btnLogin_HbClick(object sender, EventArgs e)
        {
            Search();
        }

        void Search()
        {
            WebUtil.JsonRequest request = new WebUtil.JsonRequest();

            WebUtil.ProcAction action = request.NewAction();
            action.proc = "sql";
            //action.text = "select a.user_id, a.user_nm, a.loc_cd, ifnull(b.loc_nm, '') loc_nm, ifnull(b.loc_addr, '') loc_addr, ifnull(b.tel_no, '') tel_no, b.store_cd, b.pos_no ";
            action.text = "select a.user_id, a.user_nm, a.loc_cd, ifnull(b.loc_nm, '') loc_nm, ifnull(b.loc_addr, '') loc_addr, ifnull(b.tel_no, '') tel_no, b.store_cd, b.pos_no, ifnull(a.role_id, '') role_id ";
            action.text += "from tb_sys_user a ";
            action.text += "	left join tb_ma_pickup_loc b on a.loc_cd = b.loc_cd ";
            //action.text += "where a.use_yn = 'Y' and a.user_id = #{user_id} and CAST(FROM_BASE64(a.user_pw) AS CHAR CHARACTER SET utf8) = #{user_pw}";
            action.text += "where a.use_yn = 'Y' and a.user_id = #{user_id} and a.user_pw = #{user_pw}";
            //action.text += "where a.use_yn = 'Y' and a.user_id = #{user_id}";
            action.param.Add("user_id", etId.Text);
            action.param.Add("user_pw", COM.AES256.AESEncrypt256(etPw.Text));

            WebUtil.WebClient client = new WebUtil.WebClient();
            DataSet ds = client.Execute(request);

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                //XtraMessageBox.Show("Login Failed...");
                XtraMessageBox.Show("Đăng nhập thất bại.", "Lỗi");
                etId.Focus();
            }
            else
            {
                DataTable dt = ds.Tables[0];
                COM.UserInfo.UserID = dt.Rows[0]["user_id"].ToString();
                COM.UserInfo.UserName = dt.Rows[0]["user_nm"].ToString();
                COM.UserInfo.LocCode = dt.Rows[0]["loc_cd"].ToString();
                COM.UserInfo.LocName = dt.Rows[0]["loc_nm"].ToString();
                COM.UserInfo.LocAddr = dt.Rows[0]["loc_addr"].ToString();
                COM.UserInfo.LocTelNo = dt.Rows[0]["tel_no"].ToString();
                COM.UserInfo.StoreCd = dt.Rows[0]["store_cd"].ToString();
                COM.UserInfo.PosNo = dt.Rows[0]["pos_no"].ToString();
                //COM.UserInfo.StoreCd = "9999";
                //COM.UserInfo.PosNo = "9000";
                COM.UserInfo.RoleID = dt.Rows[0]["role_id"].ToString();

                if (chkLoginInfoSave.Checked && COM.UserInfo.RoleID == "0" )
                {
                    CommonUtil.AccessDB.SetConfig("login_info_save", "Y");
                    CommonUtil.AccessDB.SetConfig("user_id", etId.Text);
                    CommonUtil.AccessDB.SetConfig("user_pw", CommonUtil.Converter.Encrypt(etPw.Text));
                    CommonUtil.AccessDB.SetConfig("if_flag", "Y");
                    CommonUtil.AccessDB.SetConfig("cancel_flag", "Y");
                }
                else
                {
                    CommonUtil.AccessDB.SetConfig("login_info_save", chkLoginInfoSave.Checked? "Y" : "N");
                    CommonUtil.AccessDB.SetConfig("user_id", chkLoginInfoSave.Checked ? etId.Text : "");
                    CommonUtil.AccessDB.SetConfig("user_pw", chkLoginInfoSave.Checked ? CommonUtil.Converter.Encrypt(etPw.Text) : "");
                    CommonUtil.AccessDB.SetConfig("if_flag", "N");
                    CommonUtil.AccessDB.SetConfig("cancel_flag", "N");
                }

                Main mainForm = (Main)this.Parent;
                mainForm.AfterLogin();

                this.Dispose();
            }
        }

        public void cbLang_HbTextChanged(object setnder, EventArgs e)
        {
            Main mainForm = (Main)this.Parent;
            mainForm.SetLang(cbLang.Value as string);
        }

        
    }
}
