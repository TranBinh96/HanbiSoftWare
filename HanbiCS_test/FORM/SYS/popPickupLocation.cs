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
using HanbiControl;

namespace SYS
{
    public partial class popPickupLocation : DevExpress.XtraEditors.XtraForm
    {
        HbPopupEditH popLocation = null;
        DevExpress.XtraGrid.Views.Grid.GridView gridViewUser = null;

        bool bolLocCd = false;

        public popPickupLocation(HbPopupEditH popPopup)
        {
            this.popLocation = popPopup;

            InitializeComponent();
            this.LookAndFeel.SkinName = CommonUtil.AccessDB.GetConfig("skin");

            InitGrid();

            scSearch.Text = popPopup.Text;
            if (popPopup.FieldName == "loc_cd")
            {
                bolLocCd = true;
            }
            // Load pickup Location
            Find();

            string skin = CommonUtil.AccessDB.GetConfig("skin");
            this.LookAndFeel.SkinName = skin;

            string lang = CommonUtil.AccessDB.GetConfig("lang");

            if (lang == "ko") this.Text = "짐을 싣는 곳";
            else if (lang == "vi") this.Text = "Thông tin cửa hàng";
            else this.Text = "Pickup Location";
            this.Refresh();
        }

        public popPickupLocation(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            string skin = CommonUtil.AccessDB.GetConfig("skin");
            this.LookAndFeel.SkinName = skin;

            this.gridViewUser = gridView;

            InitializeComponent();
            InitGrid();
            bolLocCd = true;

            object value = gridView.GetFocusedRowCellValue(gridView.FocusedColumn);
            if (value == null || value == System.DBNull.Value)
            {
                scSearch.Text = "";
            }
            else
            {
                scSearch.Text = (string)value;
            }

            // Load Pickup Location of User
            Find();
            
        }

        void InitGrid()
        {
            HanbiControl.GridOption option = new GridOption();
            option.SetNumberColInfo(false, false, true, true, false, false, 1, "loc_cd", "loc_cd", 100, GridOption.Align.center, 0, true, GridOption.SumType.sum);
            option.SetTextColInfo(false, true, true, true, false, false, 1, "loc_nm", "loc_nm", 200, GridOption.Align.left);
            option.SetNumberColInfo(false, true, true, true, false, false, 3, "loc_post_cd", "loc_post_cd", 80, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            option.SetTextColInfo(false, true, true, true, false, false, 4, "loc_addr", "loc_addr", 360, GridOption.Align.left);
            option.SetTextColInfo(false, true, true, true, false, false, 4, "loc_addr_dtl", "loc_addr_dtl", 360, GridOption.Align.left);

            option.Apply(gridViewPickupLocation);
        }

        DataTable Search(string text)
        {
            WebUtil.JsonRequest request = new WebUtil.JsonRequest();

            WebUtil.ProcAction action = request.NewAction();
            StringBuilder sql = new StringBuilder();

            int search_cd;
            bool isNumber = int.TryParse(text, out search_cd);

            action.proc = "sql";

            sql.Append("SELECT loc_cd, loc_nm, CAST(IFNULL(loc_post_cd, 0) AS DECIMAL) AS loc_post_cd, IFNULL(loc_addr, '') AS loc_addr, IFNULL(loc_addr_dtl, '') AS loc_addr_dtl");
            sql.Append(" FROM " + SYS.HBConstant.TB_MA_PICKUP_LOC);

            // The first time, we will finding with loc_cd
            // The next time, find with post cod or loc_cd, loc_nm, addr like searching string
            if (bolLocCd && !String.IsNullOrEmpty(text))
            {
                sql.Append(" WHERE loc_cd = #{loc_cd} ");
                action.param.Add("loc_cd", text);
            }
            else if (isNumber)
            {
                sql.Append(" WHERE loc_cd like concat('%', #{search_cd}, '%') ");
                sql.Append(" OR loc_post_cd like concat('%', #{search_cd}, '%') ");
                action.param.Add("search_cd", search_cd);
            }
            else
            {
                sql.Append(" WHERE loc_nm like concat('%', #{loc_nm}, '%') ");
                sql.Append(" OR (loc_addr IS NULL OR loc_addr like concat('%', #{loc_nm}, '%')) ");
                sql.Append(" OR (loc_addr_dtl IS NULL OR loc_addr_dtl like concat('%', #{loc_nm}, '%')) ");
                action.param.Add("loc_nm", text);

            }
            bolLocCd = false;

            sql.Append(" ORDER BY loc_cd ASC ");

            action.text = sql.ToString();
            

            WebUtil.WebClient client = new WebUtil.WebClient();
            DataSet ds = client.Execute(request);

            if (client.check && ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public void Find()
        {
            DataTable dt = Search(scSearch.Text);

            if (dt != null)
            {
                gridPickupLocation.DataSource = dt;
                if (gridViewPickupLocation.RowCount > 0)
                {
                    gridViewPickupLocation.FocusedRowHandle = 0;
                }
            }
            else
            {
                this.ShowDialog();
            }
        }

        private void btnSearch_HbClick(object sender, EventArgs e)
        {
            DataTable dt = Search(scSearch.Text);
            gridPickupLocation.DataSource = dt;
            if (gridViewPickupLocation.RowCount > 0)
            {
                gridViewPickupLocation.FocusedRowHandle = 0;
            }
        }

        private void btnConfirm_HbClick(object sender, EventArgs e)
        {
            if (gridViewPickupLocation.RowCount > 0)
            {
                Confirm();
            }
            //else if (XtraMessageBox.Show("사용자의 픽업 위치가 지워 집니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
            else if (XtraMessageBox.Show("Vị trí cừa hàng của bạn sẽ bị xóa?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                popLocation.Text = String.Empty;
            }
            else
            {
                return;
            }

            this.Close();
            this.Dispose();
        }

        void gridViewPickupLocation_DoubleClick(object sender, System.EventArgs e)
        {
            Confirm();

            this.Close();
            this.Dispose();
        }

        void Confirm()
        {
            if (gridViewUser != null)
            {
                gridViewUser.SetFocusedRowCellValue(gridViewUser.FocusedColumn, gridViewPickupLocation.GetFocusedRowCellValue("loc_cd").ToString());
            }
            else if (popLocation.FieldName == "loc_cd")
            {
                popLocation.Text = gridViewPickupLocation.GetFocusedRowCellValue("loc_cd").ToString();
            }
            else
            {
                popLocation.Text = gridViewPickupLocation.GetFocusedRowCellValue("loc_nm").ToString();
            }
        }

        private void scSearch_HbKeyDownPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_HbClick(sender, e);
            }
        }
    }
}