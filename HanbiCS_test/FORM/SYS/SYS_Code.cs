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
    public partial class SYS_Code : DevExpress.XtraEditors.XtraUserControl
    {

        bool bolNewGroup = false;
        bool bolNewCode = false;

        public SYS_Code()
        {
            InitializeComponent();

            InitGridCodeGroup();
            InitGridCode();

            Search();
        }

        private void InitGridCodeGroup()
        {
            GridOption gridOption = new GridOption();
            gridOption.SetTextColInfo(false, true, true, true, false, false, 1, "grp_cd", "grp_cd", 140, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 2, "grp_nm", "grp_nm", 200, GridOption.Align.left);
            gridOption.SetCheckBoxColInfo(false, false, true, true, false, false, -1, "sys_yn", "sys_yn", 40, "Y", "N", "N", true);
            gridOption.SetCheckBoxColInfo(false, true, true, true, false, false, 3, "use_yn", "use_yn", 40, "Y", "N", "N", true);
            gridOption.SetTextColInfo(false, true, true, true, false, false, -1, "remark", "remark", 100, GridOption.Align.left);
            gridOption.SetConnectedControls(new HbControl[] { 
                txtGroupId, txtGroupName, chkSys, chkUse, txtRemark
            });
            gridOption.Apply(gridViewCodeGroup);
        }

        private void gridViewCodeGroup_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridViewCodeGroup.SetRowCellValue(e.RowHandle, txtGroupId.FieldName, txtGroupId.DefaultText);
            gridViewCodeGroup.SetRowCellValue(e.RowHandle, txtGroupName.FieldName, txtGroupName.DefaultText);
            gridViewCodeGroup.SetRowCellValue(e.RowHandle, chkSys.FieldName, chkSys.Value);
            gridViewCodeGroup.SetRowCellValue(e.RowHandle, chkUse.FieldName, chkUse.Value);
            gridViewCodeGroup.SetRowCellValue(e.RowHandle, txtRemark.FieldName, txtRemark.DefaultText);
        }

        private void InitGridCode()
        {
            GridOption gridOption = new GridOption();
            gridOption.SetTextColInfo(false, true, false, true, false, false, 1, "cd", "cd", 200, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, false, true, false, false, 2, "cd_nm", "cd_nm", 200, GridOption.Align.left);


            gridOption.SetTextColInfo(false, false, true, true, false, false, -1, "grp_cd", "grp_cd", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 3, "grp_nm", "grp_nm", 200, GridOption.Align.left);

            gridOption.SetNumberColInfo(false, true, false, true, false, false, 4, "sort_seq", "sort_seq", 50, GridOption.Align.right, 0, true, GridOption.SumType.sum);
            //gridOption.SetConnectedControls(new HbControl[] { 
            //    etID, etKO, etEN, etVI
            //});
            gridOption.Apply(gridViewCode);
        }

        private void gridViewCode_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridViewCode.SetRowCellValue(e.RowHandle, "cd", String.Empty);
            gridViewCode.SetRowCellValue(e.RowHandle, "cd_nm", String.Empty);
            gridViewCode.SetRowCellValue(e.RowHandle, "grp_cd", txtGroupId.Text);
            gridViewCode.SetRowCellValue(e.RowHandle, "grp_nm", txtGroupName.Text);
            gridViewCode.SetRowCellValue(e.RowHandle, "sort_seq", gridViewCode.RowCount);
        }

        void Search()
        {

            //Make ID filed is readOnly
            txtGroupId.ReadOnly = true;
            bolNewGroup = false;

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT grp_cd, grp_nm, sys_yn, use_yn, remark ");
            sql.Append(" FROM " + HBConstant.TB_SYS_CODE_GRP);
            sql.Append("    ORDER BY grp_cd ASC ");

            action.text = sql.ToString();

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            gridCodeGroup.DataSource = ds.Tables[0];

        }

        void gridViewCodeGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;
            RefreshCode(e.FocusedRowHandle);
        }

        private void gridViewCodeGroup_DataSourceChanged(object sender, EventArgs e)
        {
            if (gridViewCodeGroup.RowCount > 0)
            {
                gridViewCodeGroup.FocusedRowHandle = 0;
            }
            else
            {
                gridCode.DataSource = null;
            }
        }
        
        void RefreshCode(int row)
        {
            bolNewCode = false;

            if (row < 0)
            {
                gridCode.DataSource = null;
                return;
            }

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT A.cd, A.cd_nm, A.grp_cd, B.grp_nm, A.sort_seq ");
            sql.Append(" FROM " + HBConstant.TB_SYS_CODE + " A LEFT JOIN " + HBConstant.TB_SYS_CODE_GRP + " B ");
            sql.Append(" ON A.grp_cd = B.grp_cd ");
            sql.Append(" WHERE A.grp_cd = #{grp_cd} ");
            sql.Append(" ORDER BY A.sort_seq ASC ");

            action.text = sql.ToString();
            action.param.Add(txtGroupId.FieldName, gridViewCodeGroup.GetRowCellValue(row, txtGroupId.FieldName));

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            gridCode.DataSource = ds.Tables[0];

        }

        void Save()
        {
            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();

            // New Group
            if (bolNewGroup)
            {
                if (String.IsNullOrEmpty(txtGroupId.Text) || HBConstant.checkExistID(HBConstant.TB_SYS_CODE_GRP, txtGroupId.FieldName, txtGroupId.Text) != HBConstant.NORMAL)
                {
                    //XtraMessageBox.Show("이미 존재하거나 비어있는 ID.", "성공");
                    XtraMessageBox.Show("Mã nhóm đang trống hoặc đã tồn tại.", "Lỗi");
                    return;
                }

                sql.Append("INSERT INTO " + HBConstant.TB_SYS_CODE_GRP);
                sql.Append("(grp_cd, grp_nm, sys_yn, use_yn, remark)");
                sql.Append(" VALUES (#{grp_cd}, #{grp_nm}, #{sys_yn}, #{use_yn}, #{remark}) ");

                action.text = sql.ToString();
                action.param.Add(txtGroupId.FieldName, txtGroupId.Text);
                action.param.Add(txtGroupName.FieldName, txtGroupName.Text);
                action.param.Add(chkSys.FieldName, chkSys.Value);
                action.param.Add(chkUse.FieldName, chkUse.Value);
                action.param.Add(txtRemark.FieldName, txtRemark.Text);
            }
            //Update Group
            else
            {
                sql.Append("UPDATE " + HBConstant.TB_SYS_CODE_GRP);
                sql.Append(" SET grp_nm = #{grp_nm}, sys_yn = #{sys_yn}, use_yn = #{use_yn}, remark = #{remark} ");
                sql.Append("WHERE grp_cd = #{grp_cd}");

                action.text = sql.ToString();
                action.param.Add(txtGroupName.FieldName, txtGroupName.Text);
                action.param.Add(chkSys.FieldName, chkSys.Value);
                action.param.Add(chkUse.FieldName, chkUse.Value);
                action.param.Add(txtRemark.FieldName, txtRemark.Text);
                action.param.Add(txtGroupId.FieldName, txtGroupId.Text);
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

        void New()
        {
            //Make ID filed is readOnly
            txtGroupId.ReadOnly = false;

            if (bolNewCode)
            {
                //XtraMessageBox.Show("새 코드를 저장하십시오.", "성공");
                XtraMessageBox.Show("Một mã mới đang được thêm, hãy thực hiện lưu mã.", "Thông báo");
                return;
            }

            if (!bolNewGroup)
            {
                gridViewCodeGroup.AddNewRow();
                bolNewGroup = true;
            }
            else
            {
                string[] newdat = { txtGroupId.Text, txtGroupName.Text, chkSys.Value, chkUse.Value, txtRemark.Text };
                gridViewCodeGroup.FocusedRowHandle = gridViewCodeGroup.RowCount - 1;

                txtGroupId.Text     = newdat[0];
                txtGroupName.Text   = newdat[1];
                chkSys.Value        = newdat[2];
                chkUse.Value        = newdat[3];
                txtRemark.Text      = newdat[4];
            }
        }

        void Delete()
        {
            if (gridViewCodeGroup.RowCount == 0) return;

            if (bolNewGroup)
            {
                gridViewCodeGroup.DeleteRow(gridViewCodeGroup.FocusedRowHandle);
                bolNewGroup = false;
                return;
            }

            //if (XtraMessageBox.Show("정말로 삭제 하시겠습니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
            if (XtraMessageBox.Show("Bạn có thực sự muốn xóa không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                JsonRequest request = new JsonRequest();
                StringBuilder sql = new StringBuilder();

                ProcAction deleteCode = request.NewAction();
                deleteCode.proc = WebUtil.Values.PROC_SQL;

                sql.Append("DELETE FROM " + HBConstant.TB_SYS_CODE);
                sql.Append(" WHERE grp_cd = #{grp_cd}");

                deleteCode.text = sql.ToString();
                deleteCode.param.Add(txtGroupId.FieldName, txtGroupId.Text);

                ProcAction deleteGroup = request.NewAction();
                deleteGroup.proc = WebUtil.Values.PROC_SQL;

                sql.Clear();
                sql.Append("DELETE FROM " + HBConstant.TB_SYS_CODE_GRP);
                sql.Append(" WHERE grp_cd = #{grp_cd}");

                deleteGroup.text = sql.ToString();
                deleteGroup.param.Add(txtGroupId.FieldName, txtGroupId.Text);

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

        void btnNewCode_Click(object sender, System.EventArgs e)
        {
            if (bolNewGroup)
            {
                //XtraMessageBox.Show("새 코드 그룹을 저장하십시오.", "성공");
                XtraMessageBox.Show("Một nhóm mới đang được thêm, hãy thực hiện lưu nhóm.", "Thông báo");
                return;
            }

            if (!bolNewCode)
            {
                gridViewCode.AddNewRow();
                bolNewCode = true;

            }
            else
            {
                gridViewCode.FocusedRowHandle = gridViewCodeGroup.RowCount - 1;
            }
        }

        void btnSaveCode_Click(object sender, System.EventArgs e)
        {
            if (bolNewGroup)
            {
                //XtraMessageBox.Show("새 코드 그룹을 저장하십시오.", "성공");
                XtraMessageBox.Show("Một nhóm mới đang được thêm, hãy thực hiện lưu nhóm.", "Thông báo");
                btnSaveCode.Focus();
                return;
            }

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();
            DataRowView row;
            string cd = String.Empty;
            string cd_nm = String.Empty;
            string  grp_cd = String.Empty;
            int sort_seq = 0;

            if (gridViewCode.GetSelectedRows().Length > 0)
            {
                row = (DataRowView)gridViewCode.GetRow(gridViewCode.GetSelectedRows()[0]);
                cd = row.Row[0].ToString();
                grp_cd = txtGroupId.Text;
                cd_nm = row.Row[1].ToString();
                sort_seq = int.Parse(row.Row[4].ToString());
            }

            // Insert new code
            if (bolNewCode)
            {
                if (String.IsNullOrEmpty(cd) || HBConstant.checkExistID(HBConstant.TB_SYS_CODE, "cd", cd) != HBConstant.NORMAL)
                {
                    //XtraMessageBox.Show("이미 존재하거나 비어있는 ID.", "성공");
                    XtraMessageBox.Show("Mã đang trống hoặc đã tồn tại.", "Lỗi");
                    return;
                }

                sql.Append("INSERT INTO " + HBConstant.TB_SYS_CODE);
                sql.Append(" (cd, grp_cd, cd_nm, sort_seq) ");
                sql.Append(" VALUES (#{cd}, #{grp_cd}, #{cd_nm}, #{sort_seq})");

                action.text = sql.ToString();
                action.param.Add("cd", cd);
                action.param.Add("grp_cd", grp_cd);
                action.param.Add("cd_nm", cd_nm);
                action.param.Add("sort_seq", sort_seq);
            }
            // Update code
            else
            {
                sql.Append("UPDATE " + HBConstant.TB_SYS_CODE);
                sql.Append(" SET cd_nm = #{cd_nm}, sort_seq = #{sort_seq}");
                sql.Append(" WHERE cd = #{cd}");

                action.text = sql.ToString();
                action.param.Add("cd_nm", cd_nm);
                action.param.Add("sort_seq", sort_seq);
                action.param.Add("cd", cd);
            }

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            if (client.check)
            {
                //XtraMessageBox.Show("저장 했습니다.", "성공");
                XtraMessageBox.Show("Lưu thành công.", "Thông báo");
                RefreshCode((int) gridViewCodeGroup.GetSelectedRows()[0]);
            }
            else
            {
                //XtraMessageBox.Show("저장 실패: " + client.message, "실패");
                XtraMessageBox.Show("Có lỗi xảy ra: \n" + client.message, "Lỗi");
            }

        }

        void btnDeleteCode_Click(object sender, System.EventArgs e)
        {
            if (bolNewGroup)
            {
                //XtraMessageBox.Show("새 코드 그룹을 저장하십시오.", "성공");
                XtraMessageBox.Show("Một nhóm mới đang được thêm, hãy thực hiện lưu nhóm.", "Thông báo");
                return;
            }

            if (gridViewCode.RowCount == 0) return;

            if (bolNewCode)
            {
                gridViewCode.DeleteRow(gridViewCode.FocusedRowHandle);
                bolNewCode = false;
                return;
            }

            //if (XtraMessageBox.Show("정말로 삭제 하시겠습니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
            if (XtraMessageBox.Show("Bạn có thực sự muốn xóa không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                JsonRequest request = new JsonRequest();
                ProcAction action = request.NewAction();
                action.proc = WebUtil.Values.PROC_SQL;

                StringBuilder sql = new StringBuilder();
                DataRowView row;
                string cd = String.Empty;
                string grp_cd = String.Empty;

                if (gridViewCode.GetSelectedRows().Length > 0)
                {
                    row = (DataRowView)gridViewCode.GetRow(gridViewCode.GetSelectedRows()[0]);
                    cd = row.Row[0].ToString();
                    grp_cd = txtGroupId.Text;
                }

                sql.Append("DELETE FROM " + HBConstant.TB_SYS_CODE);
                sql.Append(" WHERE cd = #{cd} and grp_cd = #{grp_cd}");

                action.text = sql.ToString();
                action.param.Add("cd", cd);
                action.param.Add("grp_cd", grp_cd);

                WebClient client = new WebClient();
                DataSet ds = client.Execute(request);

                if (client.check)
                {
                    //XtraMessageBox.Show("삭제 했습니다.", "성공");
                    XtraMessageBox.Show("Xóa thành công.", "Thông báo");
                    RefreshCode((int)gridViewCodeGroup.GetSelectedRows()[0]);
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
