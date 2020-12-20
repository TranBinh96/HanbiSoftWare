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

namespace COM
{
    public partial class popPopup : DevExpress.XtraEditors.XtraForm
    {
        HanbiControl.HbPopupEditH etPopup = null;
        HanbiControl.HbTextEditH etKo = null;
        HanbiControl.HbTextEditH etEn = null;
        HanbiControl.HbTextEditH etVi = null;

        DevExpress.XtraGrid.Views.Grid.GridView gridView = null;


        public popPopup(HanbiControl.HbPopupEditH etPopup, HanbiControl.HbTextEditH etKo, HanbiControl.HbTextEditH etEn, HanbiControl.HbTextEditH etVi)
        {
            this.etPopup = etPopup;
            this.etKo = etKo;
            this.etEn = etEn;
            this.etVi = etVi;

            InitializeComponent();

            etFind.Text = etPopup.Text;

            string skin = CommonUtil.AccessDB.GetConfig("skin");
            this.LookAndFeel.SkinName = skin;

            string lang = CommonUtil.AccessDB.GetConfig("lang");
            this.Text = CommonUtil.AccessDB.GetTextDictionary("popup")[lang];
        }

        public popPopup(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            string skin = CommonUtil.AccessDB.GetConfig("skin");
            this.LookAndFeel.SkinName = skin;

            this.gridView = gridView;

            InitializeComponent();

            object value = gridView.GetFocusedRowCellValue(gridView.FocusedColumn);
            if (value == null || value == System.DBNull.Value)
            {
                etFind.Text = "";
            }
            else
            {
                etFind.Text = (string)value;
            }
            
        }

        void InitGrid()
        {
            HanbiControl.GridOption option = new HanbiControl.GridOption();
            option.GridID = "popPopup";
            option.Apply(gridView1);
        }

        DataTable Search(string text)
        {
            WebUtil.JsonRequest request = new WebUtil.JsonRequest();

            WebUtil.ProcAction action = request.NewAction();
            action.proc = "sql";
            action.text = "select * from tb_sys_text where concat(id, ko, en, vi) like concat('%', #{text}, '%')";
            action.param.Add("text", text);

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
            string text = etFind.Text;

            if (text == null || text == "")
            {
                this.ShowDialog();
                return;
            }

            DataTable dt = Search(text);

            if (dt != null && dt.Rows.Count == 1)
            {
                if (gridView != null)
                {
                    gridView.SetFocusedRowCellValue(gridView.FocusedColumn, dt.Rows[0]["id"].ToString());
                    gridView.SetFocusedRowCellValue("ko", (string)dt.Rows[0]["ko"]);
                    gridView.SetFocusedRowCellValue("en", (string)dt.Rows[0]["en"]);
                    gridView.SetFocusedRowCellValue("vi", (string)dt.Rows[0]["vi"]);
                }
                else
                {
                    etPopup.Text = dt.Rows[0]["id"].ToString();
                    etKo.Text = (string)dt.Rows[0]["ko"];
                    etEn.Text = (string)dt.Rows[0]["en"];
                    etVi.Text = (string)dt.Rows[0]["vi"];
                }
                
            }
            else
            {
                this.ShowDialog();
            }
        }

        private void popPopupEditor_VisibleChanged(object sender, EventArgs e)
        {
            DataTable dt = Search(etFind.Text);
            gridControl1.DataSource = dt;
            if (gridView1.RowCount > 0)
            {
                gridView1.FocusedRowHandle = 0;
            }
        }

        private void btnSearch_HbClick(object sender, EventArgs e)
        {
            DataTable dt = Search(etFind.Text);
            gridControl1.DataSource = dt;
            if (gridView1.RowCount > 0)
            {
                gridView1.FocusedRowHandle = 0;
            }
        }

        private void btnConfirm_HbClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                this.Close();
                this.Dispose();
                return;
            }

            if (gridView != null)
            {
                gridView.SetFocusedRowCellValue(gridView.FocusedColumn, gridView1.GetFocusedRowCellValue("id").ToString());
                gridView.SetFocusedRowCellValue("ko", (string)gridView1.GetFocusedRowCellValue("ko"));
                gridView.SetFocusedRowCellValue("en", (string)gridView1.GetFocusedRowCellValue("en"));
                gridView.SetFocusedRowCellValue("vi", (string)gridView1.GetFocusedRowCellValue("vi"));
            }
            else
            {
                etPopup.Text = gridView1.GetFocusedRowCellValue("id").ToString();
                etKo.Text = (string)gridView1.GetFocusedRowCellValue("ko");
                etEn.Text = (string)gridView1.GetFocusedRowCellValue("en");
                etVi.Text = (string)gridView1.GetFocusedRowCellValue("vi");
            }

            this.Close();
            this.Dispose();
        }
    }
}