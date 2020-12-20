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
using HanbiControl;

namespace SYS
{
    public partial class SYS_Grid : DevExpress.XtraEditors.XtraUserControl
    {
        public SYS_Grid()
        {
            InitializeComponent();

            InitGrid();

            Search();
        }

        private void InitGrid()
        {
            GridOption gridOption1 = new GridOption();
            gridOption1.SetTextColInfo(false, true, true, true, false, false, 1, "grid_id", "grid_id", 80, GridOption.Align.center);
            gridOption1.SetTextColInfo(false, true, true, true, false, false, 2, "dll_name", "dll_name", 80, GridOption.Align.left);
            gridOption1.SetTextColInfo(false, true, true, true, false, false, 3, "class_name", "class_name", 80, GridOption.Align.left);
            gridOption1.SetTextColInfo(false, true, true, true, false, false, 4, "grid_name", "grid_name", 200, GridOption.Align.left);
            gridOption1.SetTextColInfo(false, true, true, true, false, false, 5, "grid_desc", "grid_desc", 200, GridOption.Align.left);
            gridOption1.SetTextColInfo(false, true, true, true, false, false, 6, "iud_flag", "iud_flag", 60, GridOption.Align.left);
            gridOption1.SetConnectedControls(new HbControl[] { 
                etGridId, etDllName, etClassName, etGridName, etGridDesc
            });
            gridOption1.Apply(gridView1);


            Dictionary<string, object> dic = null;

            GridOption gridOption2 = new GridOption();
            gridOption2.SetNumberColInfo(false, false, false, true, false, false, 1, "col_id", "col_id", 80, GridOption.Align.center, 0, false, GridOption.SumType.none);
            WebUtil.ProcAction colTypeAction = new WebUtil.ProcAction();
            colTypeAction.proc = WebUtil.Values.PROC_SQL;
            colTypeAction.text = "select cd value, cd_nm name from tb_sys_code where grp_cd = 'GRID_COL_TYPE' order by sort_seq";
            gridOption2.SetComboBoxColInfo(true, true, false, true, false, false, 2, "col_type", "col_type", 60, GridOption.Align.center, false, 0, "", colTypeAction);
            gridOption2.SetNumberColInfo(true, true, false, true, false, false, 3, "col_idx", "col_idx", 60, GridOption.Align.center, 0, false, GridOption.SumType.none);
            gridOption2.SetTextColInfo(true, true, false, true, false, false, 4, "col_text_id", "col_text_id", 80, GridOption.Align.left);
            gridOption2.SetTextColInfo(false, true, false, true, false, false, 5, "col_text", "col_text", 200, GridOption.Align.left);
            gridOption2.SetTextColInfo(true, true, false, true, false, false, 6, "field_name", "field_name", 80, GridOption.Align.left);
            gridOption2.SetNumberColInfo(true, true, false, true, false, false, 7, "col_width", "col_width", 60, GridOption.Align.center, 0, false, GridOption.SumType.none);
            List<Dictionary<string, object>> listAlign = new List<Dictionary<string,object>>();
            for (int i = 0; i < Enum.GetNames(typeof(GridOption.Align)).Length; i++)
            {
                dic = new Dictionary<string, object>();
                dic["value"] = (int)Enum.GetValues(typeof(GridOption.Align)).GetValue(i);
                dic["name"] = Enum.GetNames(typeof(GridOption.Align))[i];
                listAlign.Add(dic);
            }
            gridOption2.SetComboBoxColInfo(true, true, false, true, false, false, 8, "col_align", "col_align", 60, GridOption.Align.center, false, 0, "", listAlign);
            gridOption2.SetCheckBoxColInfo(true, true, false, true, false, false, 9, "mandatory_yn", "mandatory_yn", 60, "Y", "N", "N", false);
            gridOption2.SetCheckBoxColInfo(true, true, false, true, false, false, 10, "visible_yn", "visible_yn", 60, "Y", "N", "N", false);
            gridOption2.SetCheckBoxColInfo(true, true, false, true, false, false, 11, "readonly_yn", "readonly_yn", 60, "Y", "N", "N", false);
            gridOption2.SetCheckBoxColInfo(true, true, false, true, false, false, 12, "allow_focus_yn", "allow_focus_yn", 60, "Y", "N", "N", false);
            gridOption2.SetCheckBoxColInfo(true, true, false, true, false, false, 13, "sort_yn", "sort_yn", 60, "Y", "N", "N", false);
            gridOption2.SetCheckBoxColInfo(true, true, false, true, false, false, 14, "filter_yn", "filter_yn", 60, "Y", "N", "N", false);
            gridOption2.SetNumberColInfo(false, true, false, true, false, false, 15, "col_decimal_places", "decimal_places", 60, GridOption.Align.center, 0, false, GridOption.SumType.none);
            gridOption2.SetCheckBoxColInfo(false, true, false, true, false, false, 16, "col_sub_total", "sub_total", 60, "Y", "N", "N", false);
            List<Dictionary<string, object>> listSumType = new List<Dictionary<string, object>>();
            for (int i = 0; i < Enum.GetNames(typeof(GridOption.SumType)).Length; i++)
            {
                dic = new Dictionary<string, object>();
                dic["value"] = (int)Enum.GetValues(typeof(GridOption.SumType)).GetValue(i);
                dic["name"] = Enum.GetNames(typeof(GridOption.SumType))[i];
                listSumType.Add(dic);
            }
            gridOption2.SetComboBoxColInfo(false, true, false, true, false, false, 17, "col_sum_type", "sum_type", 60, GridOption.Align.center, false, 0, "", listSumType);
            gridOption2.SetTextColInfo(false, true, false, true, false, false, 18, "col_value_checked", "value_checked", 60, GridOption.Align.left);
            gridOption2.SetTextColInfo(false, true, false, true, false, false, 19, "col_value_unchecked", "value_unchecked", 60, GridOption.Align.left);
            gridOption2.SetCheckBoxColInfo(false, true, false, true, false, false, 20, "col_header_checkbox", "header_checkbox", 60, "Y", "N", "N", false);
            gridOption2.SetTextColInfo(false, false, false, true, false, false, 21, "col_mask", "mask", 100, GridOption.Align.center);
            gridOption2.SetCheckBoxColInfo(false, true, false, true, false, false, 22, "col_default_row", "default_row", 60, "Y", "N", "N", false);
            gridOption2.SetTextColInfo(false, true, false, true, false, false, 23, "col_default_row_value", "default_row_value", 60, GridOption.Align.left);
            gridOption2.SetTextColInfo(false, true, false, true, false, false, 24, "col_default_row_name", "default_row_name", 60, GridOption.Align.left);
            List<Dictionary<string, object>> listActionProc = new List<Dictionary<string, object>>();
            dic = new Dictionary<string, object>();
            dic["value"] = "sql";
            dic["name"] = "SQL";
            listActionProc.Add(dic);
            dic = new Dictionary<string, object>();
            dic["value"] = "proc";
            dic["name"] = "Procedure";
            listActionProc.Add(dic);
            gridOption2.SetComboBoxColInfo(false, true, false, true, false, false, 25, "col_action_proc", "action_proc", 60, GridOption.Align.center, true, "", "None", listActionProc);
            gridOption2.SetTextColInfo(false, true, false, true, false, false, 26, "col_action_text", "action_text", 200, GridOption.Align.left);
            gridOption2.SetTextColInfo(false, true, false, true, false, false, 27, "col_action_param", "action_param", 200, GridOption.Align.left);
            gridOption2.SetTextColInfo(false, true, false, true, false, false, 28, "dll_name", "dll_name", 80, GridOption.Align.left);
            gridOption2.SetTextColInfo(false, true, false, true, false, false, 29, "class_name", "class_name", 80, GridOption.Align.left);
            gridOption2.Apply(gridView2);
        }

        void Search()
        {
            WebUtil.JsonRequest request = new WebUtil.JsonRequest();

            WebUtil.ProcAction action1 = request.NewAction();
            action1.proc = WebUtil.Values.PROC_SQL;
            action1.text = "select *, '' iud_flag from tb_sys_grid where concat(grid_id, grid_name, dll_name, class_name) like concat('%', #{find}, '%') ";
            action1.param.Add("find", scFind.Text);

            WebUtil.WebClient client = new WebUtil.WebClient();

            DataSet ds = client.Execute(request);

            gridControl1.DataSource = ds.Tables[0];

        }

        void SearchDetail(int row)
        {
            if (row < 0)
            {
                gridControl2.DataSource = null;
                return;
            }

            WebUtil.JsonRequest request = new WebUtil.JsonRequest();

            WebUtil.ProcAction action1 = request.NewAction();
            action1.proc = WebUtil.Values.PROC_SQL;
            action1.text = "select *, '' col_text from tb_sys_grid_col where grid_id = #{grid_id} order by col_idx asc";
            action1.param.Add("grid_id", gridView1.GetRowCellValue(row, "grid_id"));

            WebUtil.WebClient client = new WebUtil.WebClient();

            DataSet ds = client.Execute(request);

            gridControl2.DataSource = ds.Tables[0];

            for (int i = 0; i < gridView2.RowCount; i++)
            {
                string text_id = (string)gridView2.GetRowCellValue(i, "col_text_id");
                if (text_id != null && text_id != "")
                {
                    Dictionary<string, string> dic = CommonUtil.AccessDB.GetTextDictionary(text_id);

                    if (dic == null || dic.Count == 0)
                    {
                        gridView2.SetRowCellValue(i, "col_text", "{\"ko\":\"\",\"en\":\"\",\"vi\":\"\"}");
                    }
                    else
                    {
                        gridView2.SetRowCellValue(i, "col_text", CommonUtil.Converter.GetNameJson(dic));
                    }
                }
            }
        }

        void New()
        {
            gridView1.AddNewRow();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;
            //etGridId.ReadOnly = false;
        }

        void Save()
        {
            if (gridView1.RowCount == 0) return;

            if (etGridId.Text == "")
            {
                //XtraMessageBox.Show("그리드ID는 필수입력입니다.", "경고");
                XtraMessageBox.Show("Id của bảng đang để trống.", "Thông báo");
                return;
            }

            WebUtil.JsonRequest request = new WebUtil.JsonRequest();

            string iudFlag = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "iud_flag").ToString();
            if (iudFlag == "I")
            {
                WebUtil.ProcAction gridAction = request.NewAction();
                gridAction.proc = WebUtil.Values.PROC_SQL;
                gridAction.text = "insert into tb_sys_grid(grid_id, dll_name, class_name, grid_name, grid_desc, in_id, up_id) ";
                gridAction.text += "values(#{grid_id}, #{dll_name}, #{class_name}, #{grid_name}, #{grid_desc}, #{user_id}, #{user_id})";
                gridAction.param.Add("grid_id", etGridId.Text);
                gridAction.param.Add("dll_name", etDllName.Text);
                gridAction.param.Add("class_name", etClassName.Text);
                gridAction.param.Add("grid_name", etGridName.Text);
                gridAction.param.Add("grid_desc", etGridDesc.Text);
                gridAction.param.Add("user_id", COM.UserInfo.UserID);
            }
            else
            {
                WebUtil.ProcAction gridAction = request.NewAction();
                gridAction.proc = WebUtil.Values.PROC_SQL;
                gridAction.text = "update tb_sys_grid set dll_name = #{dll_name}, class_name = #{class_name}, grid_name = #{grid_name}, ";
                gridAction.text += "grid_desc = #{grid_desc}, up_id = #{user_id} where grid_id = #{grid_id}";
                gridAction.param.Add("grid_id", etGridId.Text);
                gridAction.param.Add("dll_name", etDllName.Text);
                gridAction.param.Add("class_name", etClassName.Text);
                gridAction.param.Add("grid_name", etGridName.Text);
                gridAction.param.Add("grid_desc", etGridDesc.Text);
                gridAction.param.Add("user_id", COM.UserInfo.UserID);
            }

            WebUtil.ProcAction deleteAction = request.NewAction();
            deleteAction.proc = WebUtil.Values.PROC_SQL;
            deleteAction.text = "delete from tb_sys_grid_col where grid_id = #{grid_id} ";
            deleteAction.param.Add("grid_id", etGridId.Text);

            for (int i = 0; i < gridView2.RowCount; i++)
            {
                WebUtil.ProcAction colAction = request.NewAction();
                colAction.proc = WebUtil.Values.PROC_SQL;
                colAction.text = "insert into tb_sys_grid_col(grid_id, in_id, up_id, mandatory_yn, visible_yn, ";
                colAction.text += "readonly_yn, allow_focus_yn, sort_yn, filter_yn, col_idx, col_text_id, field_name, col_width, col_align, ";
                colAction.text += "decimal_places, sub_total, sum_type, value_checked, value_unchecked, header_checkbox, mask, default_row, ";
                colAction.text += "default_row_value, default_row_name, action_proc, action_text, action_param, col_type, dll_name, class_name) ";
                colAction.text += "values(#{grid_id}, #{user_id}, #{user_id}, #{mandatory_yn}, #{visible_yn}, #{readonly_yn}, ";
                colAction.text += "#{allow_focus_yn}, #{sort_yn}, #{filter_yn}, #{col_idx}, #{col_text_id}, #{field_name}, #{col_width}, ";
                colAction.text += "#{col_align}, #{decimal_places}, #{sub_total}, #{sum_type}, #{value_checked}, #{value_unchecked}, ";
                colAction.text += "#{header_checkbox}, #{mask}, #{default_row}, #{default_row_value}, #{default_row_name}, #{action_proc}, ";
                colAction.text += "#{action_text}, #{action_param}, #{col_type}, #{dll_name}, #{class_name})";
                colAction.param.Add("grid_id", etGridId.Text);
                colAction.param.Add("user_id", COM.UserInfo.UserID);
                colAction.param.Add("mandatory_yn", gridView2.GetRowCellValue(i, "mandatory_yn"));
                colAction.param.Add("visible_yn", gridView2.GetRowCellValue(i, "visible_yn"));
                colAction.param.Add("readonly_yn", gridView2.GetRowCellValue(i, "readonly_yn"));
                colAction.param.Add("allow_focus_yn", gridView2.GetRowCellValue(i, "allow_focus_yn"));
                colAction.param.Add("sort_yn", gridView2.GetRowCellValue(i, "sort_yn"));
                colAction.param.Add("filter_yn", gridView2.GetRowCellValue(i, "filter_yn"));
                colAction.param.Add("col_idx", gridView2.GetRowCellValue(i, "col_idx"));
                colAction.param.Add("col_text_id", gridView2.GetRowCellValue(i, "col_text_id"));
                colAction.param.Add("field_name", gridView2.GetRowCellValue(i, "field_name"));
                colAction.param.Add("col_width", gridView2.GetRowCellValue(i, "col_width"));
                colAction.param.Add("col_align", gridView2.GetRowCellValue(i, "col_align"));
                colAction.param.Add("decimal_places", gridView2.GetRowCellValue(i, "decimal_places"));
                colAction.param.Add("sub_total", gridView2.GetRowCellValue(i, "sub_total"));
                colAction.param.Add("sum_type", gridView2.GetRowCellValue(i, "sum_type"));
                colAction.param.Add("value_checked", gridView2.GetRowCellValue(i, "value_checked"));
                colAction.param.Add("value_unchecked", gridView2.GetRowCellValue(i, "value_unchecked"));
                colAction.param.Add("header_checkbox", gridView2.GetRowCellValue(i, "header_checkbox"));
                colAction.param.Add("mask", gridView2.GetRowCellValue(i, "mask"));
                colAction.param.Add("default_row", gridView2.GetRowCellValue(i, "default_row"));
                colAction.param.Add("default_row_value", gridView2.GetRowCellValue(i, "default_row_value"));
                colAction.param.Add("default_row_name", gridView2.GetRowCellValue(i, "default_row_name"));
                colAction.param.Add("action_proc", gridView2.GetRowCellValue(i, "action_proc"));
                colAction.param.Add("action_text", gridView2.GetRowCellValue(i, "action_text"));
                colAction.param.Add("action_param", gridView2.GetRowCellValue(i, "action_param"));
                colAction.param.Add("col_type", gridView2.GetRowCellValue(i, "col_type"));
                colAction.param.Add("dll_name", gridView2.GetRowCellValue(i, "dll_name"));
                colAction.param.Add("class_name", gridView2.GetRowCellValue(i, "class_name"));
            }
            
            WebUtil.WebClient client = new WebUtil.WebClient();

            DataSet ds = client.Execute(request);

            if (client.check)
            {
                //XtraMessageBox.Show("저장 했습니다.", "성공");
                XtraMessageBox.Show("Lưu thành công.", "Thông báo");
                Search();
            }
            else
            {
                Console.WriteLine(client.message);
                //XtraMessageBox.Show("저장 실패: " + client.message, "실패");
                XtraMessageBox.Show("Có lỗi xảy ra: \n" + client.message, "Lỗi");
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;

            string iudFg = gridView1.GetRowCellValue(e.FocusedRowHandle, "iud_flag") as string;
            if (iudFg != null && iudFg == "I")
            {
                etGridId.ReadOnly = false;
            }
            else
            {
                etGridId.ReadOnly = true;
            }
            
            SearchDetail(e.FocusedRowHandle);
        }

        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                gridView1.FocusedRowHandle = 0;
            }
            else
            {
                gridControl2.DataSource = null;
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, "grid_id", "");
            gridView1.SetRowCellValue(e.RowHandle, "dll_name", "");
            gridView1.SetRowCellValue(e.RowHandle, "class_name", "");
            gridView1.SetRowCellValue(e.RowHandle, "grid_name", "");
            gridView1.SetRowCellValue(e.RowHandle, "grid_desc", "");
            gridView1.SetRowCellValue(e.RowHandle, "iud_flag", "I");

        }


        private void gridView2_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView2.SetRowCellValue(e.RowHandle, "col_id", 0);
            gridView2.SetRowCellValue(e.RowHandle, "col_type", "text");
            gridView2.SetRowCellValue(e.RowHandle, "col_idx", gridView2.RowCount);
            gridView2.SetRowCellValue(e.RowHandle, "col_text_id", "");
            gridView2.SetRowCellValue(e.RowHandle, "col_text", "");
            gridView2.SetRowCellValue(e.RowHandle, "field_name", "");
            gridView2.SetRowCellValue(e.RowHandle, "col_width", 80);
            gridView2.SetRowCellValue(e.RowHandle, "col_align", (int)GridOption.Align.left);
            gridView2.SetRowCellValue(e.RowHandle, "mandatory_yn", "N");
            gridView2.SetRowCellValue(e.RowHandle, "visible_yn", "Y");
            gridView2.SetRowCellValue(e.RowHandle, "readonly_yn", "N");
            gridView2.SetRowCellValue(e.RowHandle, "allow_focus_yn", "Y");
            gridView2.SetRowCellValue(e.RowHandle, "sort_yn", "Y");
            gridView2.SetRowCellValue(e.RowHandle, "filter_yn", "Y");
            gridView2.SetRowCellValue(e.RowHandle, "decimal_places", 0);
            gridView2.SetRowCellValue(e.RowHandle, "sub_total", "N");
            gridView2.SetRowCellValue(e.RowHandle, "sum_type", (int)GridOption.SumType.none);
            gridView2.SetRowCellValue(e.RowHandle, "value_checked", "Y");
            gridView2.SetRowCellValue(e.RowHandle, "value_unchecked", "N");
            gridView2.SetRowCellValue(e.RowHandle, "header_checkbox", "N");
            gridView2.SetRowCellValue(e.RowHandle, "mask", "yyyy-MM-dd");
            gridView2.SetRowCellValue(e.RowHandle, "default_row", "N");
            gridView2.SetRowCellValue(e.RowHandle, "default_row_value", "");
            gridView2.SetRowCellValue(e.RowHandle, "default_row_name", "");
            gridView2.SetRowCellValue(e.RowHandle, "action_proc", "");
            gridView2.SetRowCellValue(e.RowHandle, "action_text", "");
            gridView2.SetRowCellValue(e.RowHandle, "action_param", "{}");
            gridView2.SetRowCellValue(e.RowHandle, "dll_name", "");
            gridView2.SetRowCellValue(e.RowHandle, "class_name", "");
        }

        private void btnAddRow_HbClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;

            gridView2.AddNewRow();

            for (int i = 0; i < gridView2.RowCount; i++)
            {
                gridView2.SetRowCellValue(i, "col_idx", i + 1);
            }
        }

        private void btnDeleteRow_HbClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;
            if (gridView2.FocusedRowHandle < 0) return;

            gridView2.DeleteRow(gridView2.FocusedRowHandle);

            for (int i = 0; i < gridView2.RowCount; i++)
            {
                gridView2.SetRowCellValue(i, "col_idx", i + 1);
            }
        }

        private void btnMoveUp_HbClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;
            if (gridView2.FocusedRowHandle < 0) return;

            int row = gridView2.FocusedRowHandle;
            if (row == 0) return;

            DataRow focusedRow = gridView2.GetDataRow(row);
            DataRow targetRow = gridView2.GetDataRow(row - 1);
            
            object[] temp = targetRow.ItemArray;
            targetRow.ItemArray = focusedRow.ItemArray;
            focusedRow.ItemArray = temp;

            for (int i = 0; i < gridView2.RowCount; i++)
            {
                gridView2.SetRowCellValue(i, "col_idx", i + 1);
            }

            gridView2.FocusedRowHandle = row - 1;

        }

        private void btnMoveDown_HbClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;
            if (gridView2.FocusedRowHandle < 0) return;

            int row = gridView2.FocusedRowHandle;
            if (row >= gridView2.RowCount - 1) return;

            DataRow focusedRow = gridView2.GetDataRow(row);
            DataRow targetRow = gridView2.GetDataRow(row + 1);

            object[] temp = targetRow.ItemArray;
            targetRow.ItemArray = focusedRow.ItemArray;
            focusedRow.ItemArray = temp;

            for (int i = 0; i < gridView2.RowCount; i++)
            {
                gridView2.SetRowCellValue(i, "col_idx", i + 1);
            }

            gridView2.FocusedRowHandle = row + 1;
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "col_text_id")
            {
                if (e.Value == null || e.Value.ToString() == "")
                {
                    gridView2.SetRowCellValue(e.RowHandle, "col_text", "");
                    return;
                }

                Dictionary<string, string> dic = CommonUtil.AccessDB.GetTextDictionary((string)e.Value);

                if (dic == null || dic.Count == 0)
                {
                    gridView2.SetRowCellValue(e.RowHandle, "col_text", "{\"ko\":\"\",\"en\":\"\",\"vi\":\"\"}");
                }
                else
                {
                    gridView2.SetRowCellValue(e.RowHandle, "col_text", CommonUtil.Converter.GetNameJson(dic));
                }
            }

            else if (e.Column.FieldName == "col_text")
            {
                string text_id = (string)gridView2.GetRowCellValue(e.RowHandle, "col_text_id");

                if (text_id != null && text_id != "" && e.Value != null && e.Value.ToString() != "" && e.Value.ToString() != "null" && e.Value.ToString() != "{}")
                {
                    if (text_id != null && text_id != "")
                    {
                        Dictionary<string, string> dic = CommonUtil.Converter.GetNameDictionary(e.Value.ToString());
                        if (dic == null || dic.Count == 0)
                            return;

                        dic["id"] = text_id;

                        CommonUtil.AccessDB.SetTextDictionary(dic);
                    }
                }
            }

            else if (e.Column.FieldName == "col_type")
            {
                string colType = (string)e.Value;
                if (colType == "text" || colType == "popup")
                {
                    gridView2.SetRowCellValue(e.RowHandle, "col_align", (int)GridOption.Align.left);
                }
                else if (colType == "number")
                {
                    gridView2.SetRowCellValue(e.RowHandle, "col_align", (int)GridOption.Align.right);
                }
                else if (colType == "checkbox" || colType == "date")
                {
                    gridView2.SetRowCellValue(e.RowHandle, "col_align", (int)GridOption.Align.center);
                }
                else if (colType == "combobox")
                {
                    gridView2.SetRowCellValue(e.RowHandle, "col_align", (int)GridOption.Align.center);
                    gridView2.SetRowCellValue(e.RowHandle, "action_proc", "sql");
                }
            }
        }

        

        
    }
}
