using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace COM
{
    public class COM_HanNux
    {

        public struct USB_INPUT     // UIO 입력 패킷으로부터 데이타를 얻기 위한 구조체 
        {
            public int ProductID;   // 장치 ID 
            public Byte Status;     // 패킷 수신 상태값  0=입력 변화에 의한 수신, 1=데이타 재전송 요구에 의한 수신 
            public Byte Button;     // 입력 버턴값
            public Byte Output;     // USB 장치의 입출력 상태값
            public Byte Mask;       // 포트의 입출력 설정값. bit값이 '0'이면 출력, '1'이면 입력
        };

        [DllImport("uio.dll")]
        private static extern int usb_io_init(int pID);
        [DllImport("uio.dll")]
        private static extern void set_usb_events(int hWnd);
        [DllImport("uio.dll")]
        private static extern void get_usb_input(int lParam, ref USB_INPUT uInput);
        [DllImport("uio.dll")]
        private static extern bool usb_io_output(int pID, int cmd, int io1, int io2, int io3, int io4);
        [DllImport("uio.dll")]
        private static extern bool usb_io_reset(int pID);
        [DllImport("uio.dll")]
        private static extern bool usb_in_request(int pID);

        private const int GREEN_ON = 4;
        private const int GREEN_OFF = -4;

        private const int AMBER_ON = 3;
        private const int AMBER_OFF = -3;

        private const int RED_ON = 2;
        private const int RED_OFF = -2;

        private const int SOUND_ON = 1;
        private const int SOUND_OFF = -1;

        public const int LAMP_OFF = 0;
        public const int LAMP_ON = 1;
        public const int LAMP_BLINK = 2;

        public readonly int OFF = 0;
        public readonly int ON = 1;
        public readonly int BLINK = 2;

        public readonly int DEFAULT_BLINK_HIGHT_LOW = 5;
        public readonly int DEFAULT_BLINK_TIME = 5;

        public int blinkHightLow { get; set; }
        public int blinkTime { get; set; }

        string[] supportLampID = new string[]{ "261", "262", "263", "264", "265",
            "266", "267", "268", "269", "281", "282", "283", "284", "285", "286", "287", "288", "289"
        };
        int numberOfSupportLamp;

        int defaultLamp;
        bool isPlugin = false;

        string path;
        StreamWriter write;

        public int autoOffAfter { get; set; }             // waiting and then auto off - milliseconds
        private bool bolWriteLog = false;

        public COM_HanNux()
        {
            path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + "Lamp_HanyoungNux.txt";
            if (!File.Exists(path))
            {
                write = File.CreateText(path);
                write.Close();
            }

            numberOfSupportLamp = supportLampID.Length;
            GetLampStatus();

            // Setting blink info
            if (isPlugin)
            {
                blinkHightLow = DEFAULT_BLINK_HIGHT_LOW;
                blinkTime = DEFAULT_BLINK_TIME;
            }
        }

        /*
         * Write logs to ./OUTPUT/logAlarm.txt
         */
        private void WriteLampLogs(string str_log)
        {
            if (!bolWriteLog) return;
            write = File.AppendText(path);
            write.WriteLine(DateTime.Now.ToString() + ": " + str_log);
            write.Close();
        }

        public void GetLampStatus()
        {
            int index;
            int lampIndex;
            for (int i = 0; i < numberOfSupportLamp; i++)
            {
                index = 0;
                lampIndex = 0;
                lampIndex = Convert.ToInt32(supportLampID[i], 16);
                index = usb_io_init(lampIndex);

                if (index == 0) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", lampIndex), " not found."));
                else if (index == 0xffff) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", lampIndex), " 0xFFFF = Access denide"));
                else if (index == lampIndex)
                {
                    WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", lampIndex), " is pluging."));
                    defaultLamp = lampIndex;
                    isPlugin = true;
                    break;
                }
            }
        }

        public async void SetGreenLight(int green)
        {

            bool result = false;
            if (!isPlugin) return;
            if (LAMP_ON != green && LAMP_BLINK != green) green = LAMP_OFF;

            int blink = 0;

            switch (green)
            {
                case LAMP_ON:
                    result = usb_io_output(defaultLamp, 0, GREEN_ON, 0, 0, 0);
                    
                    if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green is on."));
                    else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green can't on."));
                    break;
                case LAMP_BLINK:
                    blink = Convert.ToInt32(blinkHightLow.ToString(), 10) * 16 + Convert.ToInt32(blinkTime.ToString(), 10);
                    result = usb_io_output(defaultLamp, blink, GREEN_ON, 0, 0, 0);

                    if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green is blink."));
                    else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green can't blink."));
                    break;
                case LAMP_OFF:
                    result = usb_io_output(defaultLamp, 0, GREEN_OFF, 0, 0, 0);
                    if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green is off."));
                    else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green can't off."));
                    break;
            }

            if (autoOffAfter > 0)
            {
                await Task.Delay(autoOffAfter);
                result = usb_io_output(defaultLamp, 0, GREEN_OFF, 0, 0, 0);
                WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green auto off.", System.Environment.NewLine));
            }
        }

        public async void SetAmberLight(int amber)
        {
            bool result = false;
            if (!isPlugin) return;
            if (LAMP_ON != amber && LAMP_BLINK != amber) amber = LAMP_OFF;

            int blink = 0;

            switch (amber)
            {
                case LAMP_ON:
                    result = usb_io_output(defaultLamp, 0, AMBER_ON, 0, 0, 0);

                    if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green is on."));
                    else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green can't on."));
                    break;
                case LAMP_BLINK:
                    blink = Convert.ToInt32(blinkHightLow.ToString(), 10) * 16 + Convert.ToInt32(blinkTime.ToString(), 10);
                    result = usb_io_output(defaultLamp, blink, AMBER_ON, 0, 0, 0);

                    if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green is blink."));
                    else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green can't blink."));
                    break;
                case LAMP_OFF:
                    result = usb_io_output(defaultLamp, 0, AMBER_OFF, 0, 0, 0);
                    if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green is off."));
                    else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green can't off."));
                    break;
            }

            if (autoOffAfter > 0)
            {
                await Task.Delay(autoOffAfter);
                result = usb_io_output(defaultLamp, 0, AMBER_OFF, 0, 0, 0);
                WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green auto off.", System.Environment.NewLine));
            }
        }

        public async void SetRedLight(int red)
        {
            bool result = false;
            if (!isPlugin) return;
            if (LAMP_ON != red && LAMP_BLINK != red) red = LAMP_OFF;

            int blink = 0;

            switch (red)
            {
                case LAMP_ON:
                    result = usb_io_output(defaultLamp, 0, RED_ON, 0, 0, 0);

                    if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green is on."));
                    else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green can't on."));
                    break;
                case LAMP_BLINK:
                    blink = Convert.ToInt32(blinkHightLow.ToString(), 10) * 16 + Convert.ToInt32(blinkTime.ToString(), 10);
                    result = usb_io_output(defaultLamp, blink, RED_ON, 0, 0, 0);

                    if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green is blink."));
                    else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green can't blink."));
                    break;
                case LAMP_OFF:
                    result = usb_io_output(defaultLamp, 0, RED_OFF, 0, 0, 0);
                    if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green is off."));
                    else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green can't off."));
                    break;
            }

            if (autoOffAfter > 0)
            {
                await Task.Delay(autoOffAfter);
                result = usb_io_output(defaultLamp, 0, RED_OFF, 0, 0, 0);
                WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green auto off.", System.Environment.NewLine));
            }
        }

        public async void SetSound(int sound)
        {
            bool result = false;
            if (!isPlugin) return;
            if (sound > LAMP_BLINK)
            {
                blinkHightLow = sound;
                blinkTime = sound;
                sound = LAMP_BLINK;
            }

            int blink = 0;

            switch (sound)
            {
                case LAMP_ON:
                    result = usb_io_output(defaultLamp, 0, SOUND_ON, 0, 0, 0);

                    if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green is on."));
                    else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green can't on."));
                    break;
                case LAMP_BLINK:
                    blink = Convert.ToInt32(blinkHightLow.ToString(), 10) * 16 + Convert.ToInt32(blinkTime.ToString(), 10);
                    result = usb_io_output(defaultLamp, blink, SOUND_ON, 0, 0, 0);
                    blinkHightLow = DEFAULT_BLINK_HIGHT_LOW;
                    blinkTime = DEFAULT_BLINK_TIME;
                    if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green is blink."));
                    else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green can't blink."));
                    break;
                case LAMP_OFF:
                    result = usb_io_output(defaultLamp, 0, SOUND_OFF, 0, 0, 0);
                    if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green is off."));
                    else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green can't off."));
                    break;
            }

            if (autoOffAfter > 0)
            {
                await Task.Delay(autoOffAfter);
                result = usb_io_output(defaultLamp, 0, SOUND_OFF, 0, 0, 0);
                WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green auto off.", System.Environment.NewLine));
            }
        }

        public void SetLampOff()
        {
            bool result = false;

            if (isPlugin && supportLampID.Contains(defaultLamp.ToString()))
            {
                // Turn Green off
                result = usb_io_output(defaultLamp, 0, GREEN_OFF, 0, 0, 0);

                if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green is off."));
                else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Green can't off."));

                // Turn Amber off
                result = usb_io_output(defaultLamp, 0, AMBER_OFF, 0, 0, 0);

                if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Amber is off."));
                else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Amber can't off."));

                // Turn Red off
                result = usb_io_output(defaultLamp, 0, RED_OFF, 0, 0, 0);

                if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Red is off."));
                else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Red can't off."));

                //Turn Sound off
                result = usb_io_output(defaultLamp, 0, SOUND_OFF, 0, 0, 0);

                if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Sound is off."));
                else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Sound can't off."));
            }
        }

        public void SetLampLevel1()
        {
            bolWriteLog = false;
            autoOffAfter = 2000;
            SetSound(10);
            SetGreenLight(ON);
        }

        public void SetLampLevel2()
        {
            bolWriteLog = false;
            autoOffAfter = 5000;
            SetSound(5);
            SetAmberLight(BLINK);
        }

        public void SetLampLevel3()
        {
            bolWriteLog = false;
            autoOffAfter = 5000;
            SetSound(ON);
            SetRedLight(BLINK);
        }

        public void ResetLamp()
        {
            bool result;

            result = usb_io_reset(defaultLamp);

            if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Reset is success."));
            else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Reset is not success."));
        }

        public bool RequestLamp()
        {
            bool result;
            result = usb_in_request(defaultLamp);

            if (result) WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Could be setting."));
            else WriteLampLogs(string.Concat("Lamp", string.Format("0x{0:x}", defaultLamp), ": Could not be setting."));

            return result;

        }
    }
}
