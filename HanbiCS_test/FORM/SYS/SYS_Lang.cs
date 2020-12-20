using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using WebUtil;
using HanbiControl;

namespace SYS
{
    public partial class SYS_Lang : DevExpress.XtraEditors.XtraUserControl
    {

        private bool bolNewFlag = false;
        public SYS_Lang()
        {
            InitializeComponent();

            InitGrid();
            Search();
        }

        private void InitGrid()
        {
            GridOption gridOption = new GridOption();
            gridOption.SetTextColInfo(false, true, true, true, false, false, 1, "ID", "id", 150, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 2, "KO", "ko", 170, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 3, "EN", "en", 170, GridOption.Align.left);
            gridOption.SetTextColInfo(false, true, true, true, false, false, 4, "VI", "vi", 250, GridOption.Align.left);
            gridOption.SetConnectedControls(new HbControl[] { 
                etID, etKO, etEN, etVI
            });
            gridOption.Apply(gridViewLang);
        }

        void Search()
        {

            //Make ID filed is readOnly
            etID.ReadOnly = true;
            bolNewFlag = false;

            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT id, ko, en, vi ");
            sql.Append(" FROM " + HBConstant.TB_SYS_TEXT);
            sql.Append(" WHERE id like concat('%', #{text}, '%') OR ko like concat('%', #{text}, '%') ");
            sql.Append("    OR en like concat('%', #{text}, '%') OR vi like concat('%', #{text}, '%') ");
            sql.Append("    ORDER BY id ASC ");
            action.text = sql.ToString();
            action.param.Add(scText.FieldName, scText.Text);

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            gridLang.DataSource = ds.Tables[0];

        }

        void Save()
        {
            JsonRequest request = new JsonRequest();

            ProcAction action = request.NewAction();
            action.proc = WebUtil.Values.PROC_SQL;

            StringBuilder sql = new StringBuilder();

            //Update text
            if (!bolNewFlag)
            {
                sql.Append(" UPDATE " + HBConstant.TB_SYS_TEXT);
                sql.Append(" SET ko = #{ko}, en = #{en}, vi = #{vi}");
                sql.Append(" WHERE id = #{id}");
                action.text = sql.ToString();

                action.param.Add(etKO.FieldName, etKO.Text);
                action.param.Add(etEN.FieldName, etEN.Text);
                action.param.Add(etVI.FieldName, etVI.Text);
                action.param.Add(etID.FieldName, etID.Text);
            }
            // New Text
            else
            {               
                if (string.IsNullOrEmpty(etID.Text) || HBConstant.checkExistID(HBConstant.TB_SYS_TEXT, etID.FieldName, etID.Text) != HBConstant.NORMAL)
                {
                    //XtraMessageBox.Show("이미 존재하거나 비어있는 ID.", "성공");
                    XtraMessageBox.Show("Id đang trống hoặc đã tồn tại.", "Lỗi");
                    return;
                }

                sql.Append("INSERT INTO " + HBConstant.TB_SYS_TEXT + " (id, ko, en, vi)");
                sql.Append(" VALUES (#{id}, #{ko}, #{en}, #{vi}) ");
                action.text = sql.ToString();

                action.param.Add(etID.FieldName, etID.Text);
                action.param.Add(etKO.FieldName, etKO.Text);
                action.param.Add(etEN.FieldName, etEN.Text);
                action.param.Add(etVI.FieldName, etVI.Text);
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
            etID.ReadOnly = false;

            if (!bolNewFlag)
            {
                gridViewLang.AddNewRow();
                bolNewFlag = true;
            }
            else
            {
                string[] newdat = { etID.Text, etKO.Text, etEN.Text, etVI.Text };
                gridViewLang.FocusedRowHandle = gridViewLang.RowCount - 1;

                etID.Text = newdat[0];
                etKO.Text = newdat[1];
                etEN.Text = newdat[2];
                etVI.Text = newdat[3];
            }
        }

        void Delete()
        {

            if (gridViewLang.RowCount == 0) return;

            if (bolNewFlag)
            {
                gridViewLang.DeleteRow(gridViewLang.FocusedRowHandle);
                bolNewFlag = false;
                return;
            }

            //if (XtraMessageBox.Show("정말로 삭제 하시겠습니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.OK)
            if (XtraMessageBox.Show("Bạn có thực sự muốn xóa không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                JsonRequest request = new JsonRequest();
                ProcAction action = request.NewAction();
                action.proc = WebUtil.Values.PROC_SQL;

                StringBuilder sql = new StringBuilder();

                sql.Append("DELETE FROM " + HBConstant.TB_SYS_TEXT);
                sql.Append(" WHERE id = #{id}");

                action.text = sql.ToString();
                action.param.Add(etID.FieldName, etID.Text);

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

        void Copy()
        {
            //Make ID filed is readOnly
            etID.ReadOnly = false;
            string[] newdat = {etKO.Text, etEN.Text, etVI.Text };

            if (!bolNewFlag)
            {
                gridViewLang.AddNewRow();
                bolNewFlag = true;
            }
            else
            {
                gridViewLang.FocusedRowHandle = gridViewLang.RowCount - 1;
            }

            etKO.Text = newdat[1];
            etEN.Text = newdat[2];
            etVI.Text = newdat[3];

        }

        private void gridViewLang_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridViewLang.SetRowCellValue(e.RowHandle, etID.FieldName, etID.DefaultText);
            gridViewLang.SetRowCellValue(e.RowHandle, etKO.FieldName, etKO.DefaultText);
            gridViewLang.SetRowCellValue(e.RowHandle, etEN.FieldName, etEN.DefaultText);
            gridViewLang.SetRowCellValue(e.RowHandle, etVI.FieldName, etVI.DefaultText);
        }
    }
}
