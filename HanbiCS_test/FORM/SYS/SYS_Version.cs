using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;
using System.Net.Http;
using Tamir.SharpSsh;
using Tamir.Streams;

namespace SYS
{
    public partial class SYS_Version : DevExpress.XtraEditors.XtraUserControl
    {
        private string[] sftpUrl;
        private string[] sftpPort;
        private string[] sftpId;
        private string[] sftpPw;
        private string[] sftpDir;

        public SYS_Version()
        {
            InitializeComponent();

            InitGrid();

            sftpUrl = System.Configuration.ConfigurationSettings.AppSettings["versionSftpUrl"].Split(';');
            sftpPort = System.Configuration.ConfigurationSettings.AppSettings["versionSftpPort"].Split(';');
            sftpId = System.Configuration.ConfigurationSettings.AppSettings["versionSftpId"].Split(';');
            sftpPw = System.Configuration.ConfigurationSettings.AppSettings["versionSftpPw"].Split(';');
            sftpDir = System.Configuration.ConfigurationSettings.AppSettings["versionSftpDir"].Split(';');

            SearchLocal();
            SearchServer();

            
        }

        public void InitGrid() {
            HanbiControl.GridOption option1 = new HanbiControl.GridOption();
            option1.GridID = "SYS_Version_1";
            option1.Apply(gridView1);

            HanbiControl.GridOption option2 = new HanbiControl.GridOption();
            option2.GridID = "SYS_Version_2";
            option2.Apply(gridView2);
        }

        public void SearchLocal()
        {
            var assemblyPath = Assembly.GetEntryAssembly().Location;
            var assemblyDirectory = Path.GetDirectoryName(assemblyPath) + @"\";
            etLocalDir.Text = assemblyDirectory;

            DataTable dt = new DataTable();
            dt.Columns.Add("file_nm");
            dt.Columns.Add("up_dt");
            dt.Columns.Add("file_path");

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(assemblyDirectory);
            foreach (System.IO.FileInfo file in di.GetFiles())
            {
                DataRow dr = dt.NewRow();
                dr["file_nm"] = file.Name;
                dr["up_dt"] = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                dr["file_path"] = file.FullName;
                dt.Rows.Add(dr);
            }

            gridControl2.DataSource = dt;
        }

        public void SearchServer()
        {
            WebUtil.JsonRequest request = new WebUtil.JsonRequest();

            WebUtil.ProcAction action = request.NewAction();
            action.proc = "sql";
            action.text = "select * from tb_sys_version order by file_nm asc";

            WebUtil.WebClient client = new WebUtil.WebClient();
            DataSet ds = client.Execute(request);

            gridControl1.DataSource = ds.Tables[0];
        }

        public int SearchVersion(string fileName)
        {
            WebUtil.JsonRequest request = new WebUtil.JsonRequest();

            WebUtil.ProcAction action = request.NewAction();
            action.proc = "sql";
            action.text = "select * from tb_sys_version where file_nm = #{file_nm}";
            action.param.Add("file_nm", fileName);

            WebUtil.WebClient client = new WebUtil.WebClient();
            DataSet ds = client.Execute(request);

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["file_ver"].ToString());
            }
        }

        private async void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = gridView2;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                string fileName = gridView2.GetRowCellValue(info.RowHandle, "file_nm").ToString();
                string filePath = gridView2.GetRowCellValue(info.RowHandle, "file_path").ToString();
                var uri = new Uri(System.Configuration.ConfigurationSettings.AppSettings["apiServerVersionUrl"]);

                //CommonUtil.Progress.OpenProgress(this);

                try
                {
                    for (int i = 0; i < sftpUrl.Length; i++)
                    {
                        Sftp oSftp = new Sftp(sftpUrl[i], sftpId[i], sftpPw[i]);
                        oSftp.Connect(Convert.ToInt32(sftpPort[i]));
                        oSftp.Put(filePath, sftpDir[i] + "/" + fileName);
                        oSftp.Close();
                    }

                    int version = SearchVersion(fileName);

                    WebUtil.JsonRequest request = new WebUtil.JsonRequest();

                    WebUtil.ProcAction action = request.NewAction();
                    action.proc = "sql";
                    if (version == -1)
                    {
                        action.text = "insert into tb_sys_version(file_nm, file_ver, in_dt, up_dt) values(#{file_nm}, 1, now(), now())";
                    }
                    else
                    {
                        action.text = "update tb_sys_version set file_ver = #{file_ver}, up_dt = now() where file_nm = #{file_nm}";
                        action.param.Add("file_ver", version + 1);
                    }
                    action.param.Add("file_nm", fileName);

                    WebUtil.WebClient client = new WebUtil.WebClient();
                    DataSet ds = client.Execute(request);

                    SearchServer();
                }
                catch (Exception err)
                {
                    throw new Exception(err.ToString());
                }
                finally
                {
                    //CommonUtil.Progress.CloseProgress(this);
                }




                //byte[] data;
                //ByteArrayContent bytes;

                //MultipartFormDataContent multiForm = new MultipartFormDataContent();

                //try
                //{

                //    FileInfo fileinfo = new FileInfo(filePath);

                //    using (var client = new HttpClient())
                //    {
                //        using (var br = new BinaryReader(fileinfo.OpenRead()))
                //        {
                //            data = br.ReadBytes((int)fileinfo.OpenRead().Length);
                //        }

                //        bytes = new ByteArrayContent(data);
                //        multiForm.Add(bytes, "file_nm", fileName);

                //        var res = await client.PostAsync(uri, multiForm);
                //    }
                    

                //    SearchServer();
                //}
                //catch (Exception err)
                //{
                //    throw new Exception(err.ToString());
                //}
                //finally
                //{
                //    CommonUtil.Progress.CloseProgress(this);
                //}
            }  
        }
    }
}
