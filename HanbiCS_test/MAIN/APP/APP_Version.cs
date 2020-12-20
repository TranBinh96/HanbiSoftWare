using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using DevExpress.XtraEditors;
using CommonUtil;
using WebUtil;
using System.Threading;

namespace APP
{
    public partial class APP_Version : DevExpress.XtraEditors.XtraUserControl
    {
        public APP_Version()
        {
            InitializeComponent();
        }

        private void APP_Version_Resize(object sender, EventArgs e)
        {
            grpVersion.Left = (this.ClientSize.Width - grpVersion.Width) / 2;
            grpVersion.Top = (this.ClientSize.Height - grpVersion.Height) / 2;
        }


        public bool RunUpdate(List<string> downList)
        {
            var assemblyPath = Assembly.GetEntryAssembly().Location;
            var assemblyDirectory = Path.GetDirectoryName(assemblyPath);

            string appExeName = Path.GetFileName(Assembly.GetEntryAssembly().Location);
            string baseUrl = System.Configuration.ConfigurationSettings.AppSettings["apiServerVersionUrl"];

            System.Net.WebClient wc = new System.Net.WebClient();

            lblText.Text = "Start program update...";
            pbTotal.Properties.Step = 1;
            pbTotal.Properties.PercentView = true;
            pbTotal.Properties.Maximum = downList.Count;
            pbTotal.Properties.Minimum = 0;

            bool isAppChanged = false;
            for (int i = 0; i < downList.Count; i++)
            {
                

                string fileName = downList[i];

                lblText.Text = "Downloading files ( " + (i + 1) + " / " + downList.Count + " ) : " + fileName;

                string filePath = assemblyDirectory + @"\" + downList[i];

                if (appExeName == fileName)
                {
                    ReplaceData(filePath, fileName, "APP.userdata");
                    isAppChanged = true;
                }
                else if ("COM.dll" == fileName)
                {
                    ReplaceData(filePath, fileName, "COM.userdata");
                    isAppChanged = true;
                }
                else if ("CommonUtil.dll" == fileName)
                {
                    ReplaceData(filePath, fileName, "CommonUtil.userdata");
                    isAppChanged = true;
                }
                else if ("WebUtil.dll" == fileName)
                {
                    ReplaceData(filePath, fileName, "WebUtil.userdata");
                    isAppChanged = true;
                }
                else if ("HanbiControl.dll" == fileName)
                {
                    ReplaceData(filePath, fileName, "HanbiControl.userdata");
                    isAppChanged = true;
                }
                else if ("Interop.ADOX.dll" == fileName)
                {
                    ReplaceData(filePath, fileName, "Interop.ADOX.userdata");
                    isAppChanged = true;
                }
                else if ("Newtonsoft.Json.dll" == fileName)
                {
                    ReplaceData(filePath, fileName, "Newtonsoft.Json.userdata");
                    isAppChanged = true;
                }
                //else if ("WebUtil.dll" == fileName)
                //{
                //    ReplaceData(filePath, fileName, "WebUtil.userdata");
                //    isAppChanged = true;
                //}
                //else if ("WebUtil.dll" == fileName)
                //{
                //    ReplaceData(filePath, fileName, "WebUtil.userdata");
                //    isAppChanged = true;
                //}
                //else if ("WebUtil.dll" == fileName)
                //{
                //    ReplaceData(filePath, fileName, "WebUtil.userdata");
                //    isAppChanged = true;
                //}
                

                try
                {
                    wc.DownloadFile(new Uri(baseUrl + "/" + fileName), filePath);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    throw err;
                }
                //finally
                //{
                //    wc.Dispose();
                //}

                pbTotal.PerformStep();
                pbTotal.Update();
            }

            lblText.Text = "Update Finished...";

            this.Hide();
            return isAppChanged;
        }


        

        void ReplaceData(string oriFilePath, string oriFileName, string toFileName)
        {
            string newName = oriFilePath.Replace(oriFileName, toFileName);

            if (File.Exists(newName))
            {
                File.Delete(newName);
            }

            if (File.Exists(oriFilePath))
            {
                File.Move(oriFilePath, newName);
            }
        }
    }
}
