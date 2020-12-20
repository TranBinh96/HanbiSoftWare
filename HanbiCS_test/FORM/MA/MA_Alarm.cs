using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO;
using DevExpress.XtraEditors;
using System.Threading;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using COM;


namespace MA
{
    public partial class MA_Alarm : DevExpress.XtraEditors.XtraUserControl
    {

        COM.COM_HanNux Alarm;

        public MA_Alarm()
        {
            InitializeComponent();

            etPort.Text = "30001";


            InitCheckBox();

            //Alarm = new COM.COM_QlightST45();
            Alarm = new COM.COM_HanNux();

        }

        void InitCheckBox()
        {
            txtRed.ProcAction.proc = WebUtil.Values.PROC_SQL;
            txtRed.ProcAction.text = "SELECT cd value, cd_nm name FROM tb_sys_code WHERE grp_cd = 'ALARM' ORDER BY value ASC";
            txtRed.SetDataByProcAction();

            txtAmber.ProcAction.proc = WebUtil.Values.PROC_SQL;
            txtAmber.ProcAction.text = "SELECT cd value, cd_nm name FROM tb_sys_code WHERE grp_cd = 'ALARM' ORDER BY value ASC";
            txtAmber.SetDataByProcAction();

            txtGreen.ProcAction.proc = WebUtil.Values.PROC_SQL;
            txtGreen.ProcAction.text = "SELECT cd value, cd_nm name FROM tb_sys_code WHERE grp_cd = 'ALARM' ORDER BY value ASC";
            txtGreen.SetDataByProcAction();
        }

        private void btnGet_HbClick(object sender, EventArgs e)
        {
            Alarm.GetLampStatus();
        }

        private async void btnSet_HbClick(object sender, EventArgs e)
        {
            // QlightST45
            //byte red, amber, green, sound;
            //int soundValue;

            //// Red
            //red = byte.Parse(txtRed.Value.ToString());

            //// Amber
            //amber = byte.Parse(txtAmber.Value.ToString());

            //// Green
            //green = byte.Parse(txtGreen.Value.ToString());

            //soundValue = int.Parse(txtSound.Text);
            //sound = byte.Parse(soundValue.ToString());

            //Alarm.autoOffAfter = 5000;
            //Alarm.SetLampOn(Alarm.INDEX_LAMP_1, red, amber, green, Alarm.LAMP_OFF, Alarm.LAMP_OFF, sound);

            // Hanyoung Nux
            int green, amber, red, sound;

            Alarm.autoOffAfter = 5000;
            sound = int.Parse(txtSound.Value.ToString());
            //red = int.Parse(txtRed.Value.ToString());
            //amber = int.Parse(txtAmber.Value.ToString());
            //green = int.Parse(txtGreen.Value.ToString());
            //
            //if (sound > 0)
            //{
            //    Alarm.SetSound(sound);
            //    await Task.Delay(Alarm.autoOffAfter);
            //}
            //if (red > 0)
            //{
            //    Alarm.SetRedLight(red);
            //    await Task.Delay(Alarm.autoOffAfter);
            //}
            //
            //if (amber > 0)
            //{
            //    Alarm.SetAmberLight(amber);
            //    await Task.Delay(Alarm.autoOffAfter);
            //}
            //
            //if (green > 0)
            //{
            //    Alarm.SetGreenLight(green);
            //}

            if (sound == 1) Alarm.SetLampLevel1();
            else if (sound == 2) Alarm.SetLampLevel2();
            else Alarm.SetLampLevel3();
        }

        private void btnRequest_HbClick(object sender, EventArgs e)
        {
            WmsSocket socket = new WmsSocket();
            JObject json = socket.Connect(Convert.ToInt32(etPort.Text), JsonConvert.DeserializeObject<JObject>(etRequest.Text));

            JObject IRT_MODEL = (JObject)json["IRT_MODEL"];
            JObject IRT_HEADER = (JObject)IRT_MODEL["IRT_HEADER"];
            JObject CUST_REQ = (JObject)IRT_MODEL["CUST_REQ"];
            JArray CUST_INFO_LIST = (JArray)CUST_REQ["CUST_INFO_LIST"];
            JObject CUST_INFO_LIST0 = (JObject)CUST_INFO_LIST[0];
        }
    }
}
