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

namespace MA
{
    public partial class MA_PickupLocation : DevExpress.XtraEditors.XtraUserControl
    {
        private bool bolNewPickupLoc = false;
        public MA_PickupLocation()
        {
            InitializeComponent();

            InitGrid();

            Search();
        }

        private void InitGrid()
        {
            GridOption gridOption = new GridOption();
            gridOption.SetTextColInfo(false, true, true, true, false, false, 1, "loc_cd", "loc_cd", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 2, "loc_nm", "loc_nm", 150, GridOption.Align.left);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 3, "loc_post_cd", "loc_post_cd", 100, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 4, "loc_addr", "loc_addr", 250, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 5, "loc_addr_dtl", "loc_addr_dtl", 250, GridOption.Align.left);

            gridOption.SetConnectedControls(new HbControl[] { 
                txtLocCd, txtLocName, txtPostCode, txtAddress, txtAddressDetail
            });
            gridOption.Apply(gridViewPickupLoc);
        }

        private void gridViewCodeGroup_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridViewPickupLoc.SetRowCellValue(e.RowHandle, txtLocCd.FieldName, txtLocCd.DefaultText);
            gridViewPickupLoc.SetRowCellValue(e.RowHandle, txtLocName.FieldName, txtLocName.DefaultText);
            gridViewPickupLoc.SetRowCellValue(e.RowHandle, txtPostCode.FieldName, txtPostCode.DefaultValue);
            gridViewPickupLoc.SetRowCellValue(e.RowHandle, txtAddress.FieldName, txtAddress.DefaultText);
            gridViewPickupLoc.SetRowCellValue(e.RowHandle, txtAddressDetail.FieldName, txtAddressDetail.DefaultText);
        }

        void Search()
        {
            // Make Location CD is ReadOnly
            txtLocCd.ReadOnly = true;
            bolNewPickupLoc = false;

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT loc_cd, loc_nm, CAST(IFNULL(loc_post_cd, 0) AS DECIMAL) AS loc_post_cd, IFNULL(loc_addr, '') AS loc_addr, IFNULL(loc_addr_dtl, '') AS loc_addr_dtl");
            sql.Append(" FROM " + SYS.HBConstant.TB_MA_PICKUP_LOC);
            sql.Append(" WHERE loc_nm like concat('%', #{loc_nm}, '%') ");
            if (Decimal.Parse(scPostCode.Text) != 0)
            {
                sql.Append(" AND ( loc_post_cd IS NULL OR loc_post_cd like concat('%', #{loc_post_cd}, '%')) ");
            }
            sql.Append(" AND ( loc_addr IS NULL OR loc_addr like concat('%', #{loc_addr}, '%') OR ");
            sql.Append(" loc_addr_dtl IS NULL OR loc_addr_dtl like concat('%', #{loc_addr}, '%'))");
            sql.Append(" ORDER BY loc_cd ASC ");

            action.text = sql.ToString();
            action.param.Add(scLocName.FieldName, scLocName.Text);
            if (Decimal.Parse(txtPostCode.Text) != 0)
            {
                action.param.Add(scPostCode.FieldName, scPostCode.Text);
            }
            action.param.Add(scAddress.FieldName, scAddress.Text);

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            gridPickupLoc.DataSource = ds.Tables[0];

        }

        void New()
        {
            //Make ID filed is readOnly
            txtLocCd.ReadOnly = false;

            if (!bolNewPickupLoc)
            {
                gridViewPickupLoc.AddNewRow();
                bolNewPickupLoc = true;
            }
            else
            {
                string[] newdat = { txtLocCd.Text, txtLocName.Text, txtPostCode.Text, txtAddress.Text, txtAddressDetail.Text };
                gridViewPickupLoc.FocusedRowHandle = gridViewPickupLoc.RowCount - 1;

                txtLocCd.Text = newdat[0];
                txtLocName.Text = newdat[1];
                txtPostCode.Text = newdat[2];
                txtAddress.Text = newdat[3];
                txtAddressDetail.Text = newdat[4];
            }
        }

        void Save()
        {
            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();

            // Insert new Pickup Location
            if (bolNewPickupLoc)
            {
                if (String.IsNullOrEmpty(txtLocCd.Text) || SYS.HBConstant.checkExistID(SYS.HBConstant.TB_MA_PICKUP_LOC, txtLocCd.FieldName, txtLocCd.Text) != SYS.HBConstant.NORMAL)
                {
                    //XtraMessageBox.Show("이미 존재하거나 비어있는 ID.", "성공");
                    XtraMessageBox.Show("Mã cửa hàng đang trống hoặc đã tồn tại.", "Lỗi");
                    return;
                }

                sql.Append("INSERT INTO " + SYS.HBConstant.TB_MA_PICKUP_LOC);
                sql.Append(" ( loc_cd, loc_nm, loc_post_cd, loc_addr, loc_addr_dtl, in_id, in_dt)");
                sql.Append(" VALUES (#{loc_cd}, #{loc_nm}, #{loc_post_cd}, #{loc_addr}, #{loc_addr_dtl}, #{in_id}, CURRENT_TIMESTAMP)");

                action.text = sql.ToString();
                action.param.Add(txtLocCd.FieldName, txtLocCd.Text);
                action.param.Add(txtLocName.FieldName, txtLocName.Text);
                action.param.Add(txtPostCode.FieldName, txtPostCode.Text);
                action.param.Add(txtAddress.FieldName, txtAddress.Text);
                action.param.Add(txtAddressDetail.FieldName, txtAddressDetail.Text);
                action.param.Add(SYS.HBConstant.C_IN_ID, COM.UserInfo.UserID);
            }
            //Update Pickup Location
            else
            {
                sql.Append("UPDATE " + SYS.HBConstant.TB_MA_PICKUP_LOC);
                sql.Append(" SET loc_nm = #{loc_nm}, loc_post_cd = #{loc_post_cd}, loc_addr = #{loc_addr}, loc_addr_dtl = #{loc_addr_dtl},");
                sql.Append(" up_id = #{up_id}, up_dt = CURRENT_TIMESTAMP ");
                sql.Append(" WHERE loc_cd = #{loc_cd}");

                action.text = sql.ToString();
                action.param.Add(txtLocName.FieldName, txtLocName.Text);
                action.param.Add(txtPostCode.FieldName, txtPostCode.Text);
                action.param.Add(txtAddress.FieldName, txtAddress.Text);
                action.param.Add(txtAddressDetail.FieldName, txtAddressDetail.Text);
                action.param.Add(SYS.HBConstant.C_UP_ID, COM.UserInfo.UserID);
                action.param.Add(txtLocCd.FieldName, txtLocCd.Text);
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
            if (gridViewPickupLoc.RowCount == 0) return;

            if (bolNewPickupLoc)
            {
                gridViewPickupLoc.DeleteRow(gridViewPickupLoc.FocusedRowHandle);
                bolNewPickupLoc = false;
                return;
            }

            //if (XtraMessageBox.Show("정말로 삭제 하시겠습니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
            if (XtraMessageBox.Show("Bạn có thực sự muốn xóa không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                JsonRequest request = new JsonRequest();
                ProcAction action = request.NewAction();
                action.proc = WebUtil.Values.PROC_SQL;

                StringBuilder sql = new StringBuilder();

                sql.Append("DELETE FROM " + SYS.HBConstant.TB_MA_PICKUP_LOC);
                sql.Append(" WHERE loc_cd = #{loc_cd}");

                action.text = sql.ToString();
                action.param.Add(txtLocCd.FieldName, txtLocCd.Text);

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
