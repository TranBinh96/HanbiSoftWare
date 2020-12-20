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
using WebUtil;
using HanbiControl;

namespace SYS
{
    public partial class SYS_User : DevExpress.XtraEditors.XtraUserControl
    {
        private bool bolNewUser = false;
        public SYS_User()
        {
            InitializeComponent();
            InitGrid();
            InitSearch();
            
            Search();
        }

        private void InitGrid()
        {
            GridOption gridOption = new GridOption();
            gridOption.SetTextColInfo(false, true, true, true, false, false, 1, "user_id", "user_id", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 2, "user_nm", "user_nm", 200, GridOption.Align.left);
            gridOption.SetTextColInfo(false, false, true, true, false, false, -1, "user_pw", "user_pw", 100, GridOption.Align.left);
            gridOption.SetPopupColInfo(false, true, true, true, false, false, -1, "loc_cd", "loc_cd", 200, GridOption.Align.left, "SYS", "popPickupLocation");
            gridOption.SetTextColInfo(false, true, true, true, false, false, 3, "loc_nm", "loc_nm", 200, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "role_id", "role_id", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 4, "role_nm", "role_nm", 200, GridOption.Align.left);
            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 5, "use_yn", "use_yn", 40, "Y", "N", "N", true);
            gridOption.SetConnectedControls(new HbControl[] { 
                txtUserID, txtUserName, txtPassword, popLocation, cbRole, chkUse
            });
            gridOption.Apply(gridViewUser);
        }

        private void gridViewCodeGroup_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridViewUser.SetRowCellValue(e.RowHandle, txtUserID.FieldName, txtUserID.DefaultText);
            gridViewUser.SetRowCellValue(e.RowHandle, txtUserName.FieldName, txtUserName.DefaultText);
            gridViewUser.SetRowCellValue(e.RowHandle, txtPassword.FieldName, txtPassword.Text);
            gridViewUser.SetRowCellValue(e.RowHandle, popLocation.FieldName, popLocation.Text);
            gridViewUser.SetRowCellValue(e.RowHandle, cbRole.FieldName, cbRole.Value);
            gridViewUser.SetRowCellValue(e.RowHandle, chkUse.FieldName, chkUse.Value);
        }

        private void InitSearch()
        {
            scRole.ProcAction.proc = WebUtil.Values.PROC_SQL;
            scRole.ProcAction.text = "SELECT role_id value, role_nm name FROM tb_sys_role WHERE use_yn = 'Y' UNION SELECT '' value, '' name ORDER BY value ASC";
            scRole.SetDataByProcAction();

            cbRole.ProcAction.proc = WebUtil.Values.PROC_SQL;
            cbRole.ProcAction.text = "SELECT role_id value, role_nm name FROM tb_sys_role WHERE use_yn = 'Y' ORDER BY role_id ASC";
            cbRole.SetDataByProcAction();
        }

        void Search()
        {
            //Set user ID is ReadOnly
            txtUserID.ReadOnly = true;
            //TODO Permission to change Password
            //if (String.IsNullOrEmpty(COM.UserInfo.UserID) && COM.UserInfo.UserID == txtUserID.Text)
                if (String.IsNullOrEmpty(COM.UserInfo.UserID) && COM.UserInfo.UserID != txtUserID.Text)
            {
                txtPassword.ReadOnly = true;
            }
            bolNewUser = false;

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();
            //sql.Append("SELECT A.user_id, A.user_nm, CAST(FROM_BASE64(A.user_pw) AS CHAR CHARACTER SET utf8) as user_pw, A.loc_cd, B.loc_nm, A.use_yn ");
            sql.Append("SELECT A.user_id, A.user_nm, A.user_pw, A.loc_cd, B.loc_nm, A.use_yn, A.role_id, C.role_nm ");
            sql.Append(" FROM " + HBConstant.TB_SYS_USER + " A LEFT JOIN " + HBConstant.TB_MA_PICKUP_LOC + " B ");
            sql.Append(" ON A.loc_cd = B.loc_cd ");
            sql.Append(" LEFT JOIN tb_sys_role C ON A.role_id = C.role_id ");
            sql.Append(" WHERE A.user_nm like concat('%', #{user_nm}, '%') ");

            if (!String.IsNullOrEmpty(scLocation.Text))
            {
                sql.Append(" AND B.loc_nm like concat('%', #{loc_nm}, '%')");
            }

            if (!String.IsNullOrEmpty(scRole.Value.ToString()))
            {
                sql.Append(" AND A.role_id = #{role_id}");
                action.param.Add(scRole.FieldName, scRole.Value);
            }
            sql.Append("    ORDER BY user_id ASC ");

            action.text = sql.ToString();
            action.param.Add(scUserName.FieldName, scUserName.Text);
            action.param.Add(scLocation.FieldName, scLocation.Text);

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            DataTable dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        string pw = COM.AES256.AESDecrypt256(dt.Rows[i]["user_pw"].ToString());
                        dt.Rows[i]["user_pw"] = pw;
                    }
                    catch (Exception err)
                    {
                        dt.Rows[i]["user_pw"] = "";
                    }
                    

                }
            }


            gridUser.DataSource = dt;
        }

        void New()
        {
            //Make ID filed is readOnly
            txtUserID.ReadOnly = false;
            txtPassword.ReadOnly = false;
            cbRole.Value = HBConstant.ROLE_APPLICATION;

            if (!bolNewUser)
            {
                gridViewUser.AddNewRow();
                bolNewUser = true;
            }
            else
            {
                string[] newdat = { txtUserID.Text, txtUserName.Text, txtPassword.Text, popLocation.Text, chkUse.Value, cbRole.Value.ToString()};
                gridViewUser.FocusedRowHandle = gridViewUser.RowCount - 1;

                txtUserID.Text = newdat[0];
                txtUserName.Text = newdat[1];
                txtPassword.Text = newdat[2];
                popLocation.Text = newdat[3];
                chkUse.Value = newdat[4];
                cbRole.Value = newdat[5];
            }
        }

        void Save()
        {
            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();

            // Insert New User
            if (bolNewUser)
            {
                if (String.IsNullOrEmpty(txtUserID.Text) || HBConstant.checkExistID(HBConstant.TB_SYS_USER, txtUserID.FieldName, txtUserID.Text) != HBConstant.NORMAL)
                {
                    //XtraMessageBox.Show("이미 존재하거나 비어있는 ID.", "성공");
                    XtraMessageBox.Show("Mã người dùng đang trống hoặc đã tồn tại", "Lỗi");
                    return;
                }

                sql.Append(" INSERT INTO " + HBConstant.TB_SYS_USER);
                sql.Append(" (user_id, user_nm, user_pw, loc_cd, role_id, use_yn, in_id, in_dt)");
                //sql.Append(" VALUES (#{user_id}, #{user_nm}, TO_BASE64(#{user_pw}), #{loc_cd}, #{use_yn}, #{in_id}, CURRENT_TIMESTAMP)");
                sql.Append(" VALUES (#{user_id}, #{user_nm}, #{user_pw}, #{loc_cd}, #{role_id}, #{use_yn}, #{in_id}, CURRENT_TIMESTAMP)");

                action.text = sql.ToString();
                
                action.param.Add(txtUserID.FieldName, txtUserID.Text);
                action.param.Add(txtUserName.FieldName, txtUserName.Text);
                action.param.Add(txtPassword.FieldName, COM.AES256.AESEncrypt256(txtPassword.Text));

                action.param.Add(popLocation.FieldName, popLocation.Text);
                action.param.Add(cbRole.FieldName, cbRole.Value);
                action.param.Add(chkUse.FieldName, chkUse.Value);
                action.param.Add(HBConstant.C_IN_ID, COM.UserInfo.UserID);

            }
                //Update User
            else
            {
                sql.Append("UPDATE " + HBConstant.TB_SYS_USER);
                //sql.Append(" SET user_nm = #{user_nm}, user_pw = TO_BASE64(#{user_pw}), loc_cd = #{loc_cd}, use_yn = #{use_yn}, up_id = #{up_id}, up_dt = CURRENT_TIMESTAMP ");
                sql.Append(" SET user_nm = #{user_nm}, user_pw = #{user_pw}, loc_cd = #{loc_cd}, role_id = #{role_id}, use_yn = #{use_yn}, up_id = #{up_id}, up_dt = CURRENT_TIMESTAMP ");
                sql.Append(" WHERE user_id = #{user_id}");

                action.text = sql.ToString();
                action.param.Add(txtUserName.FieldName, txtUserName.Text);
                action.param.Add(txtPassword.FieldName, COM.AES256.AESEncrypt256(txtPassword.Text));

                action.param.Add(popLocation.FieldName, popLocation.Text);
                action.param.Add(cbRole.FieldName, cbRole.Value);
                action.param.Add(chkUse.FieldName, chkUse.Value);
                action.param.Add(HBConstant.C_UP_ID, COM.UserInfo.UserID);
                action.param.Add(txtUserID.FieldName, txtUserID.Text);
            }

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (client.check)
            {
                //XtraMessageBox.Show("저장 했습니다.", "성공");
                XtraMessageBox.Show("Lưu thành công.", "Thông báo");
                Search();
            }
            else
            {
                //XtraMessageBox.Show("저장 실패: " + client.message, "실패");
                XtraMessageBox.Show("Có lỗi xảy ra: \n" + client.message, "Lỗi");
            }
        }

        void Delete()
        {
            if (gridViewUser.RowCount == 0) return;

            if (bolNewUser)
            {
                gridViewUser.DeleteRow(gridViewUser.FocusedRowHandle);
                bolNewUser = false;
                return;
            }

            //if (XtraMessageBox.Show("정말로 삭제 하시겠습니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
            if (XtraMessageBox.Show("Bạn có thực sự muốn xóa không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                JsonRequest request = new JsonRequest();
                ProcAction action = request.NewAction();
                action.proc = WebUtil.Values.PROC_SQL;

                StringBuilder sql = new StringBuilder();

                sql.Append("DELETE FROM " + HBConstant.TB_SYS_USER);
                sql.Append(" WHERE user_id = #{user_id}");

                action.text = sql.ToString();
                action.param.Add(txtUserID.FieldName, txtUserID.Text);

                WebClient client = new WebClient();
                DataSet ds = client.Execute(request);

                if (client.check)
                {
                    //XtraMessageBox.Show("삭제 했습니다.", "성공");
                    XtraMessageBox.Show("Xóa thành công.", "Thông báo");
                    Search();
                }
                else
                {
                    //XtraMessageBox.Show("삭제 실패: " + client.message, "실패");
                    XtraMessageBox.Show("Có lỗi xảy ra: \n" + client.message, "Lỗi");
                }
            }
        }

    }
}
