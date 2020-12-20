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
using CommonUtil;
using HanbiControl;

namespace MA
{
    public partial class MA_Product : DevExpress.XtraEditors.XtraUserControl
    {
        bool bolNewProduct = false;

        public MA_Product()
        {
            InitializeComponent();

            InitGrid();
            InitSearch();

            Search();

        }

        private void InitGrid()
        {
            GridOption gridOption = new GridOption();
            gridOption.SetImageColInfo(false, true, true, true, true, false, 1, "img", "img", 100, GridOption.Align.center, gridViewProduct, 50);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 2, "prod_cd", "prod_cd", 100, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 3, "prod_nm_ko", "prod_nm_ko", 170, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 4, "prod_nm_en", "prod_nm_en", 170, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, true, false, 5, "prod_nm", "prod_nm", 170, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 6, "desc", "desc", 200, GridOption.Align.left);
            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 7, "vat_tp", "vat_tp", 40, "Y", "N", "N", true);
            gridOption.SetTextColInfo(false, false, true, true, false, false, 8, "unit", "unit", 100, GridOption.Align.left);
            gridOption.SetNumberColInfo(false, true, true, true, false, false, 9, "unit_price", "unit_price", 100, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            
            gridOption.SetConnectedControls(new HbControl[] { 
                txtProductId, txtProductNameKo, txtProductNameEn, txtProductName, txtDesc, chkVat, txtUnit, txtUnitPrice
            });
            gridOption.Apply(gridViewProduct);
        }

        private void gridViewCodeGroup_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridViewProduct.SetRowCellValue(e.RowHandle, txtProductId.FieldName, txtProductId.DefaultText);
            gridViewProduct.SetRowCellValue(e.RowHandle, txtProductNameEn.FieldName, txtProductNameEn.DefaultText);
            gridViewProduct.SetRowCellValue(e.RowHandle, txtDesc.FieldName, txtDesc.DefaultText);
            gridViewProduct.SetRowCellValue(e.RowHandle, chkVat.FieldName, chkVat.DefaultChecked);
            gridViewProduct.SetRowCellValue(e.RowHandle, txtUnit.FieldName, txtUnit.DefaultText);
            gridViewProduct.SetRowCellValue(e.RowHandle, txtUnitPrice.FieldName, txtUnitPrice.DefaultValue);
        }

        private void InitSearch()
        {
            scComparison.ProcAction.proc = WebUtil.Values.PROC_SQL;
            scComparison.ProcAction.text = "SELECT cd value, cd_nm name FROM tb_sys_code WHERE grp_cd = 'COMPARISON' ORDER BY sort_seq ASC";
            scComparison.SetDataByProcAction();
        }

        void Search()
        {
            //Set product ID is ReadOnly
            txtProductId.ReadOnly = true;
            bolNewProduct = false;

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT 'https://img.gqkorea.co.kr/gq/2019/12/style_5df32be8c39b6.jpg' img, prod_cd, prod_nm_ko, prod_nm_en, prod_nm, IFNULL(`desc`, '') as `desc`, ");
            sql.Append(" vat_tp, unit, unit_price");
            sql.Append(" FROM " + SYS.HBConstant.TB_MA_PRODUCT);
            sql.Append(" WHERE (prod_nm like concat('%', #{prod_nm}, '%') ");
            sql.Append(" OR prod_nm_ko like concat('%', #{prod_nm}, '%') ");
            sql.Append(" OR prod_nm_en like concat('%', #{prod_nm}, '%')) ");
            sql.Append(" AND ( `desc` IS NULL OR `desc` like concat('%', #{desc}, '%')) ");
            sql.Append(" AND unit like concat('%', #{unit}, '%') ");

            switch (scComparison.Value.ToString())
            {
                case SYS.HBConstant.MORE_THAN:
                    sql.Append(" AND (unit_price is NULL OR unit_price > #{unit_price}) ");
                    break;
                case SYS.HBConstant.LESS_THAN:
                    sql.Append(" AND (unit_price is NULL OR unit_price < #{unit_price}) ");
                    break;
                case SYS.HBConstant.EQUAL:
                    sql.Append(" AND (unit_price is NULL OR unit_price = #{unit_price}) ");
                    break;
            }

            sql.Append(" ORDER BY prod_cd ASC limit 50");

            action.text = sql.ToString();
            action.param.Add(scProductName.FieldName, scProductName.Text.Trim());
            action.param.Add(scProductDesc.FieldName, scProductDesc.Text);
            action.param.Add(scUnit.FieldName, scUnit.Text);
            action.param.Add(scUnitPrice.FieldName, Decimal.Parse(txtUnitPrice.Text));

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            gridProduct.DataSource = ds.Tables[0];
            gridViewProduct.RefreshData();
        }

        void New()
        {
            //Make ID filed is readOnly
            txtProductId.ReadOnly = false;
            txtProductId.Focus();

            if (!bolNewProduct)
            {
                gridViewProduct.AddNewRow();
                bolNewProduct = true;
            }
            else
            {
                string[] newdat = { txtProductId.Text, txtProductNameEn.Text, txtDesc.Text, chkVat.Value, txtUnit.Text, txtUnitPrice.Text };
                gridViewProduct.FocusedRowHandle = gridViewProduct.RowCount - 1;

                txtProductId.Text = newdat[0];
                txtProductNameEn.Text = newdat[1];
                txtDesc.Text = newdat[2];
                chkVat.Value = newdat[3];
                txtUnit.Text = newdat[4];
                txtUnitPrice.Text = newdat[5];
            }
        }

        void Save()
        {
            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();

            // Insert new product
            if (bolNewProduct)
            {
                if (String.IsNullOrEmpty(txtProductId.Text) || SYS.HBConstant.checkExistID(SYS.HBConstant.TB_MA_PRODUCT, txtProductId.FieldName, txtProductId.Text) != SYS.HBConstant.NORMAL)
                {
                    //XtraMessageBox.Show("제품 코드가 잘못되었거나 존재합니다.", "성공");
                    XtraMessageBox.Show("Mã sản phẩm không chính xác hoặc đã tồn tại.", "Lỗi");
                    return;
                }

                sql.Append("INSERT INTO " + SYS.HBConstant.TB_MA_PRODUCT);
                sql.Append(" (prod_cd, prod_nm_ko, prod_nm_en, prod_nm, `desc`, vat_tp, unit, unit_price, in_id, in_dt) ");
                sql.Append(" VALUES (#{prod_cd}, #{prod_nm_ko}, #{prod_nm_en}, #{prod_nm}, #{desc}, #{vat_tp}, #{unit}, #{unit_price}, #{in_id}, CURRENT_TIMESTAMP)");

                action.text = sql.ToString();
                action.param.Add(txtProductId.FieldName, txtProductId.Text);
                action.param.Add(txtProductNameKo.FieldName, txtProductNameKo.Text);
                action.param.Add(txtProductNameEn.FieldName, txtProductNameEn.Text);
                action.param.Add(txtProductName.FieldName, txtProductName.Text);
                action.param.Add(txtDesc.FieldName, txtDesc.Text);
                action.param.Add(chkVat.FieldName, chkVat.Value);
                action.param.Add(txtUnit.FieldName, txtUnit.Text);
                action.param.Add(txtUnitPrice.FieldName, txtUnitPrice.Text);
                action.param.Add(SYS.HBConstant.C_IN_ID, COM.UserInfo.UserID);
            }
            // Update product
            else
            {
                sql.Append("UPDATE " + SYS.HBConstant.TB_MA_PRODUCT);
                sql.Append(" SET prod_nm_ko = #{prod_nm_ko}, prod_nm_en = #{prod_nm_en}, prod_nm = #{prod_nm},");
                sql.Append(" `desc` = #{desc}, vat_tp = #{vat_tp}, unit = #{unit},");
                sql.Append(" unit_price = #{unit_price}, up_id = #{up_id}, up_dt = CURRENT_TIMESTAMP ");
                sql.Append(" WHERE prod_cd = #{prod_cd}");

                action.text = sql.ToString();
                action.param.Add(txtProductNameKo.FieldName, txtProductNameKo.Text);
                action.param.Add(txtProductNameEn.FieldName, txtProductNameEn.Text);
                action.param.Add(txtProductName.FieldName, txtProductName.Text);
                action.param.Add(txtDesc.FieldName, txtDesc.Text);
                action.param.Add(chkVat.FieldName, chkVat.Value);
                action.param.Add(txtUnit.FieldName, txtUnit.Text);
                action.param.Add(txtUnitPrice.FieldName, txtUnitPrice.Text);
                action.param.Add(SYS.HBConstant.C_UP_ID, COM.UserInfo.UserID);
                action.param.Add(txtProductId.FieldName, txtProductId.Text);
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
            if (gridViewProduct.RowCount == 0) return;

            if (bolNewProduct)
            {
                gridViewProduct.DeleteRow(gridViewProduct.FocusedRowHandle);
                bolNewProduct = false;
                return;
            }

            //if (XtraMessageBox.Show("정말로 삭제 하시겠습니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
            if (XtraMessageBox.Show("Bạn có thực sự muốn xóa không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                JsonRequest request = new JsonRequest();
                ProcAction action = request.NewAction();
                action.proc = WebUtil.Values.PROC_SQL;

                StringBuilder sql = new StringBuilder();

                sql.Append("DELETE FROM " + SYS.HBConstant.TB_MA_PRODUCT);
                sql.Append(" WHERE prod_cd = #{prod_cd}");

                action.text = sql.ToString();
                action.param.Add(txtProductId.FieldName, txtProductId.Text);

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
