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
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using WebUtil;

namespace SYS
{
    public partial class SYS_Menu : DevExpress.XtraEditors.XtraUserControl
    {
        int maxId = 0;

        public SYS_Menu()
        {
            InitializeComponent();

            InitControl();

            Search();
        }

        void InitControl()
        {
            etMenuType.ProcAction.proc = "sql";
            etMenuType.ProcAction.text = "select cd value, cd_nm name from tb_sys_code where grp_cd = 'MENU_TYPE' order by sort_seq";
            etMenuType.SetDataByProcAction();

            etMenuGroup.ProcAction.proc = "sql";
            etMenuGroup.ProcAction.text = "select cd value, cd_nm name from tb_sys_code where grp_cd = 'MENU_GROUP' order by sort_seq";
            etMenuGroup.SetDataByProcAction();
        }

        void Search()
        {
            treeList1.ClearNodes();

            JsonRequest request = new JsonRequest();

            ProcAction action1 = request.NewAction();
            action1.proc = "sql";
            //action1.text = "WITH RECURSIVE CTE AS ( ";
            //action1.text += "    SELECT * ";
            //action1.text += "	FROM hanbibase.tb_sys_menu ";
            //action1.text += "	WHERE menu_type = 'root' ";
            //action1.text += "	UNION ALL ";
            //action1.text += "	SELECT a.* ";
            //action1.text += "	FROM hanbibase.tb_sys_menu a ";
            //action1.text += "		INNER JOIN CTE b ON a.parent_id = b.menu_id ";
            //action1.text += ") ";
            //action1.text += "SELECT * FROM CTE";

            //action1.text = "select  * ";
            //action1.text += "from    (select * from hanbibase.tb_sys_menu ";
            //action1.text += "         order by parent_id, menu_id) products_sorted, ";
            //action1.text += "        (select @pv := '1') initialisation ";
            //action1.text += "where   find_in_set(parent_id, @pv) >= 0 ";
            //action1.text += "and     @pv := concat(@pv, ',', menu_id) ";

            action1.text = "select * from tb_sys_menu A left join ";
            action1.text += " (select * from tb_sys_menu where menu_type = 'root' and use_yn = 'Y') B on A.parent_id = B.parent_id";
            action1.text += " where A.use_yn = 'Y' order by A.parent_id, A.menu_id asc";

            WebClient client = new WebClient();
            DataSet ds = client.Execute(request);

            DataTable dt = ds.Tables[0];

            treeList1.BeginUnboundLoad();

            for (int i = 0; i < dt.Rows.Count; i++) { 
                MenuNodeTag tag = new MenuNodeTag();
                tag.stat = "";
                tag.menu_id = dt.Rows[i]["menu_id"].ToString();
                int id = Convert.ToInt32(tag.menu_id);
                if (maxId < id)
                {
                    maxId = id;
                }
                tag.parent_id = dt.Rows[i]["parent_id"] == System.DBNull.Value ? "" : dt.Rows[i]["parent_id"].ToString();
                tag.menu_name = (string)dt.Rows[i]["menu_name"];
                tag.menu_type = (string)dt.Rows[i]["menu_type"];
                tag.sort = (int)dt.Rows[i]["sort"];
                tag.dll_name = dt.Rows[i]["dll_name"] == System.DBNull.Value ? "" : dt.Rows[i]["dll_name"].ToString();
                tag.class_name = dt.Rows[i]["class_name"] == System.DBNull.Value ? "" : dt.Rows[i]["class_name"].ToString();
                tag.use_yn = (string)dt.Rows[i]["use_yn"];
                tag.depth = (int)dt.Rows[i]["depth"];
                tag.menu_group = (string)dt.Rows[i]["menu_group"];
                tag.close_yn = (string)dt.Rows[i]["close_yn"];
                tag.open_yn = (string)dt.Rows[i]["open_yn"];

                Dictionary<string, string> dic = CommonUtil.Converter.GetNameDictionary(tag.menu_name);

                TreeListNode parentNode = treeList1.FindNodeByFieldValue("id", tag.parent_id);

                TreeListNode node = treeList1.AppendNode(
                    new object[] { tag.menu_id, dic["ko"], dic["en"], dic["vi"], tag.use_yn },
                    parentNode, tag);
            }

            treeList1.EndUnboundLoad();

            treeList1.ExpandAll();

            if (treeList1.Nodes.Count > 0)
            {
                treeList1.FocusedNode = treeList1.Nodes[0];
            }
        }

        void New()
        {
            int id = ++maxId;

            TreeListNode parentNode = treeList1.FocusedNode;
            MenuNodeTag parentTag = parentNode.Tag as MenuNodeTag;

            MenuNodeTag tag = new MenuNodeTag();
            tag.stat = "";
            tag.menu_id = id.ToString();
            tag.parent_id = parentTag.menu_id;
            tag.menu_name = "{\"ko\":\"\",\"en\":\"\",\"vi\":\"\"}";
            tag.menu_type = "menu";
            tag.sort = parentNode.Nodes.Count + 1;
            tag.dll_name = "";
            tag.class_name = "";
            tag.use_yn = "Y";
            tag.depth = parentTag.depth + 1;
            tag.menu_group = parentTag.menu_group;
            tag.close_yn = "Y";
            tag.open_yn = "Y";

            Dictionary<string, string> dic = CommonUtil.Converter.GetNameDictionary(tag.menu_name);

            treeList1.BeginUnboundLoad();
            TreeListNode newNode = treeList1.AppendNode(
                new object[] { tag.menu_id, dic["ko"], dic["en"], dic["vi"], tag.use_yn },
                parentNode, tag);
            treeList1.EndUnboundLoad();

            treeList1.FocusedNode = newNode;
        }

        void Delete()
        {
            TreeListNode node = treeList1.FocusedNode;
            if (node == null)
            {
                //XtraMessageBox.Show("No Data Exists...");
                XtraMessageBox.Show("Không có dữ liệu nào tồn tại.", "Lỗi");
                return;
            }

            MenuNodeTag tag = node.Tag as MenuNodeTag;
            if (tag.menu_type == "root")
            {
                //XtraMessageBox.Show("Cannot Remove Root Menu");
                XtraMessageBox.Show("Không thể xóa menu gốc.", "Lỗi");
                return;
            }

            treeList1.DeleteNode(node);

        }

        void Save()
        {
            JsonRequest request = new JsonRequest();

            ProcAction actionDelete = request.NewAction();
            actionDelete.proc = "sql";
            actionDelete.text = "delete from tb_sys_menu where menu_type != 'root'";

            Operation operation = new Operation(request.request);
            treeList1.NodesIterator.DoOperation(operation);
            request.request = operation.List;

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
                Console.WriteLine(client.message);
                //XtraMessageBox.Show("저장 실패: " + client.message, "실패");
                XtraMessageBox.Show("Có lỗi xảy ra: \n" + client.message, "Lỗi");
            }
        }




        private void treeList1_AfterDragNode(object sender, NodeEventArgs e)
        {
            TreeListNode curNode = e.Node;
            MenuNodeTag curTag = curNode.Tag as MenuNodeTag;
            if (curTag.menu_type == "root") return;

            TreeListNode parentNode = curNode.ParentNode;
            MenuNodeTag parentTag = parentNode.Tag as MenuNodeTag;

            treeList1.BeginUnboundLoad();

            if (parentTag.use_yn == "N")
            {
                curNode.SetValue("id", "N");
                curTag.use_yn = "N";
            }
            curTag.parent_id = parentTag.menu_id;
            curTag.menu_group = parentTag.menu_group;
            curTag.depth = parentTag.depth + 1;
            for(int i=0; i<parentNode.Nodes.Count; i++) {
                TreeListNode node = parentNode.Nodes[i];
                MenuNodeTag tag = node.Tag as MenuNodeTag;
                tag.sort = i + 1;
            }

            SetForms(curTag);

            treeList1.EndUnboundLoad();
        }

        private void treeList1_DragOver(object sender, DragEventArgs e)
        {
            DXDragEventArgs args = treeList1.GetDXDragEventArgs(e);
            MenuNodeTag curTag = args.Node.Tag as MenuNodeTag;

            MenuNodeTag targetTag = null;
            if (args.TargetNode != null)
            {
                targetTag = args.TargetNode.Tag as MenuNodeTag;
            }

            if (curTag.menu_type == "root" || args.TargetNode == null)
            {
                e.Effect = System.Windows.Forms.DragDropEffects.None;  
            }
            else if (targetTag.menu_type == "root" && args.DragInsertPosition != DragInsertPosition.AsChild) 
            {
                e.Effect = System.Windows.Forms.DragDropEffects.None;  
            }
            else
            {
                e.Effect = System.Windows.Forms.DragDropEffects.Move;  
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null) return;

            MenuNodeTag tag = e.Node.Tag as MenuNodeTag;

            if (tag == null) return;

            SetForms(tag);
        }

        void SetForms(MenuNodeTag tag)
        {
            etClassName.Text = tag.class_name;
            etCloseYn.Value = tag.close_yn;
            etDepth.Value = tag.depth;
            etDllName.Text = tag.dll_name;
            etMenuGroup.Value = tag.menu_group;
            etMenuId.Text = tag.menu_id;
            etMenuName.Text = tag.menu_name;
            etMenuType.Value = tag.menu_type;
            etOpenYn.Value = tag.open_yn;
            etParentId.Text = tag.parent_id;
            etUseYn.Value = tag.use_yn;
            etSort.Value = tag.sort;

            if (tag.menu_type == "root")
            {
                etClassName.ReadOnly = true;
                etCloseYn.ReadOnly = true;
                etDllName.ReadOnly = true;
                etMenuName.ReadOnly = true;
                etOpenYn.ReadOnly = true;
                etUseYn.ReadOnly = true;
            }
            else
            {
                etClassName.ReadOnly = false;
                etCloseYn.ReadOnly = false;
                etDllName.ReadOnly = false;
                etMenuName.ReadOnly = false;
                etOpenYn.ReadOnly = false;
                etUseYn.ReadOnly = false;
            }

        }

        private void etMenuName_HbTextChanged(object setnder, EventArgs e)
        {
            TreeListNode node = treeList1.FocusedNode;
            MenuNodeTag tag = node.Tag as MenuNodeTag;
            if (tag == null) return;

            try
            {
                Dictionary<string, string> dic = CommonUtil.Converter.GetNameDictionary(etMenuName.Text);
                tag.menu_name = etMenuName.Text;
                node.SetValue("ko", dic["ko"]);
                node.SetValue("en", dic["en"]);
                node.SetValue("vi", dic["vi"]);
            } 
            catch(Exception err) 
            {
                //XtraMessageBox.Show("Json 형식이 아니거나 데이터가 부족합니다.");
                XtraMessageBox.Show("Tên menu không ở định dạng Json hoặc nhập không đủ dữ liệu.", "Lỗi");
                etMenuName.Text = tag.menu_name;
            }
        }

        private void etDllName_HbTextChanged(object setnder, EventArgs e)
        {
            TreeListNode node = treeList1.FocusedNode;
            MenuNodeTag tag = node.Tag as MenuNodeTag;

            tag.dll_name = etDllName.Text;
        }

        private void etClassName_HbTextChanged(object setnder, EventArgs e)
        {
            TreeListNode node = treeList1.FocusedNode;
            MenuNodeTag tag = node.Tag as MenuNodeTag;

            tag.class_name = etClassName.Text;
        }

        private void etOpenYn_HbCheckedChanged(object sender, EventArgs e)
        {
            TreeListNode node = treeList1.FocusedNode;
            MenuNodeTag tag = node.Tag as MenuNodeTag;

            tag.open_yn = etOpenYn.Value;
        }

        private void etCloseYn_HbCheckedChanged(object sender, EventArgs e)
        {
            TreeListNode node = treeList1.FocusedNode;
            MenuNodeTag tag = node.Tag as MenuNodeTag;

            tag.close_yn = etCloseYn.Value;
        }

        private void etUseYn_FontChanged(object sender, EventArgs e)
        {
            TreeListNode node = treeList1.FocusedNode;
            MenuNodeTag tag = node.Tag as MenuNodeTag;
            TreeListNode parentNode = node.ParentNode;
            MenuNodeTag parentTag = parentNode.Tag as MenuNodeTag;

            string value = etUseYn.Value;
            if (value == "Y" && parentTag.use_yn == "N")
            {
                //XtraMessageBox.Show("상위 메뉴를 사용할 수 없습니다.");
                XtraMessageBox.Show("Menu cha không khả dụng.","Lỗi");
                etUseYn.Value = "N";
                return;
            }

            tag.use_yn = etUseYn.Value;
            node.SetValue("use_yn", tag.use_yn);
        }


    }

    public class MenuNodeTag
    {
        public string stat;
        public string menu_id;
        public string parent_id;
        public string menu_name;
        public string menu_type;
        public int sort;
        public string dll_name;
        public string class_name;
        public string use_yn;
        public int depth;
        public string menu_group;
        public string close_yn;
        public string open_yn;
    }

    class Operation : TreeListOperation
    {
        private List<ProcAction> list;

        public Operation(List<ProcAction> list)
        {
            this.list = list;
        }
        public override void Execute(TreeListNode node)
        {
            MenuNodeTag tag = node.Tag as MenuNodeTag;

            if (tag.menu_type == "root") return;

            ProcAction action = new ProcAction();
            action.proc = "sql";
            action.text = "insert into tb_sys_menu(menu_id, parent_id, menu_name, menu_type, sort, dll_name, class_name, use_yn, depth, menu_group, close_yn, open_yn, in_id, up_id) ";
            action.text += "values(#{menu_id}, #{parent_id}, #{menu_name}, #{menu_type}, #{sort}, #{dll_name}, #{class_name}, #{use_yn}, #{depth}, #{menu_group}, #{close_yn}, #{open_yn}, #{in_id}, #{up_id})";
            action.param.Add("menu_id", Convert.ToInt32(tag.menu_id));
            action.param.Add("parent_id", Convert.ToInt32(tag.parent_id));
            action.param.Add("menu_name", tag.menu_name);
            action.param.Add("menu_type", tag.menu_type);
            action.param.Add("sort", tag.sort);
            action.param.Add("dll_name", tag.dll_name);
            action.param.Add("class_name", tag.class_name);
            action.param.Add("use_yn", tag.use_yn);
            action.param.Add("depth", tag.depth);
            action.param.Add("menu_group", tag.menu_group);
            action.param.Add("close_yn", tag.close_yn);
            action.param.Add("open_yn", tag.open_yn);
            action.param.Add("in_id", COM.UserInfo.UserID);
            action.param.Add("up_id", COM.UserInfo.UserID);

            list.Add(action);
        }
        public List<ProcAction> List
        {
            get { return list; }
        }
    }
}
