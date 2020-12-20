using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

namespace COM
{
    public class COM_QlightST45
    {
        //x86
        [DllImport("QUvc_dll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Usb_Qu_write(byte Q_index, byte Q_type, byte[] pQ_data);
        [DllImport("QUvc_dll.dll")]
        public static extern void Usb_Qu_Open();
        [DllImport("QUvc_dll.dll")]
        public static extern void Usb_Qu_Close();
        [DllImport("QUvc_dll.dll")]
        public static extern int Usb_Qu_Getstate();

        public readonly byte LAMP_OFF = 0;
        public readonly byte LAMP_ON = 1;
        public readonly byte LAMP_BLINK = 2;
        const byte C_LAMP_NOT = 100;  // Don't care  // Do not change before state

        public readonly byte SOUND_OFF = 0;
        public readonly byte SOUND_TYPE_1 = 1;
        public readonly byte SOUND_TYPE_2 = 2;
        public readonly byte SOUND_TYPE_3 = 3;
        public readonly byte SOUND_TYPE_4 = 4;
        public readonly byte SOUND_TYPE_5 = 5;

        public readonly byte INDEX_LAMP_1 = 0;
        public readonly byte INDEX_LAMP_2 = 1;
        public readonly byte INDEX_LAMP_3 = 2;
        public readonly byte INDEX_LAMP_4 = 3;

        string path;
        StreamWriter write;

        public bool bolx64 { get; private set; }
        public bool lamp1 { get; private set; }
        public bool lamp2 { get; private set; }
        public bool lamp3 { get; private set; }
        public bool lamp4 { get; private set; }
        public int autoOffAfter { get; set; }             // waiting and then auto off - milliseconds

        private byte defaultLamp;

        public COM_QlightST45()
        {
            bolx64 = System.Environment.Is64BitOperatingSystem;

            path = Directory.GetCurrentDirectory() + "\\" + "Lamp_QlightST45.txt";
            if (!File.Exists(path))
            {
                write = File.CreateText(path);
                write.Close();
            }

            GetLampStatus();
            defaultLamp = INDEX_LAMP_1;

            if (!lamp1 && lamp2)
            {
                defaultLamp = INDEX_LAMP_2;
            }
            else if (!lamp1 && lamp3)
            {
                defaultLamp = INDEX_LAMP_3;
            }
            else if (!lamp1 && lamp4)
            {
                defaultLamp = INDEX_LAMP_4;
            }
        }

        /*
         * Write logs to ./OUTPUT/logAlarm.txt
         */
        private void WriteLampLogs(string str_log)
        {
            write = File.AppendText(path);
            write.WriteLine(DateTime.Now.ToString() + ": " + str_log);
            write.Close();
        }

        /*
         * - You can connect up to a maximum of 4 USB Tower lights per PC
         * - Must be controlled by selecting Index0 - Index3 for controlling the USB tower light. The default is set to Index0
         */
        public void GetLampStatus()
        {
            int state;
            string str_State;

            lamp1 = false;
            lamp2 = false;
            lamp3 = false;
            lamp4 = false;

            state = Usb_Qu_Getstate();
            str_State = " Read Connect Usb  -->  ";

            // Check state of Lamp 1
            if ((state & 0x01) == 1)                        // Index0(0)
            {
                str_State += "Lamp 1: connected; ";
                lamp1 = true;
            }
            else str_State += "Lamp 1: disconnected; ";     // Index0(X)

            // Check state of Lamp 2
            if ((state & 0x02) == 2)                        // Index1(0)
            {
                str_State += "Lamp 2: connected; ";
                lamp2 = true;
            }
            else str_State += "Lamp 2: disconnected; ";     // Index1(X)

            // Check state of Lamp 3
            if ((state & 0x04) == 4)                        // Index2(0)
            {
                str_State += "Lamp 3: connected; ";
                lamp3 = true;
            }
            else str_State += "Lamp 3: disconnected; ";     // Index2(X)

            // Check state of Lamp 4
            if ((state & 0x08) == 8)                        // Index3(0)
            {
                str_State += "Lamp 4: connected. ";
                lamp4 = true;
            }
            else str_State += "Lamp 4: disconnected. ";     // Index3(X)

            WriteLampLogs(str_State);
        }

        /*
         * byte index   : 0 Lamp1, 1 Lamp2, 2 Lamp3, 3 Lamp4
         * byte red     : Off 0, On 1, Blink 2
         * byte amber   : Off 0, On 1, Blink 2
         * byte green   : Off 0, On 1, Blink 2
         * byte blue    : Off 0, On 1, Blink 2    
         * byte white   : Off 0, On 1, Blink 2
         * byte sound   : Off 0, type 1, type 2, type 3, type 4, type 5
         */
        private bool SetLamp(byte index, byte red, byte amber, byte green, byte blue, byte white, byte sound)
        {
            bool bolLamp = false;
            byte[] lamp = new byte[6];

            lamp[0] = red;
            lamp[1] = amber;
            lamp[2] = green;
            lamp[3] = blue;
            lamp[4] = white;
            lamp[5] = sound; // sound select

            bolLamp = Usb_Qu_write(index, 0, lamp);
            return bolLamp;
        }

        // Set Lamp On
        /* index: index bus of Alarms
         *          0: for the first Alarm
         *          ~
         *          3: for the fourth Alarm
         * red: control value for red light
         *          0: Off
         *          1: On
         *          2: Blink
         * amber, green, blue, white: the same like red
         * sound: control sound type
         *          0: Off
         *          1: Type 1 - beep interrupted
         *          2: Type 2 - big beep and 1 small beep interrupted
         *          3: Type 3 - big beep and 1 small beep interrupted
         *          4: Type 4 - 2 beeps interrupted
         *          5: Type 5 - beep continuously
         */
        public async void SetLampOn(byte index, byte red, byte amber, byte green, byte blue, byte white, byte sound)
        {
            bool bolLamp = false;

            if (sound < 0 || sound > 5) sound = 0;
            bolLamp = SetLamp(index, red, amber, green, blue, white, sound);

            if (bolLamp) WriteLampLogs("Set Lamp " + ((index + 1).ToString()) + " success.");
            else WriteLampLogs("Set Lamp " + ((index + 1).ToString()) + " error.");

            if (autoOffAfter > 0)
            {
                await Task.Delay(autoOffAfter);
                SetLampOff(index);
                WriteLampLogs("Lamp " + ((index + 1).ToString()) + " auto off." + System.Environment.NewLine);
            }
        }

        // Set Lamp Off
        public void SetLampOff(byte index)
        {
            if (index == INDEX_LAMP_1 && lamp1) 
                SetLamp(INDEX_LAMP_1, LAMP_OFF, LAMP_OFF, LAMP_OFF, LAMP_OFF, LAMP_OFF, SOUND_OFF);
            else if (index == INDEX_LAMP_2 && lamp2)
                SetLamp(INDEX_LAMP_2, LAMP_OFF, LAMP_OFF, LAMP_OFF, LAMP_OFF, LAMP_OFF, SOUND_OFF);
            else if (index == INDEX_LAMP_3 && lamp3)
                SetLamp(INDEX_LAMP_3, LAMP_OFF, LAMP_OFF, LAMP_OFF, LAMP_OFF, LAMP_OFF, SOUND_OFF);
            else SetLamp(INDEX_LAMP_4, LAMP_OFF, LAMP_OFF, LAMP_OFF, LAMP_OFF, LAMP_OFF, SOUND_OFF);

            WriteLampLogs("Set Lamp " + ((index + 1).ToString()) + " off." + System.Environment.NewLine);

        }

        // Set All Lamp Off
        public void SetLampOff()
        {
            for (int i = 0; i<= INDEX_LAMP_4; i++)
            {
                byte index = byte.Parse(i.ToString());
                SetLamp(index, LAMP_OFF, LAMP_OFF, LAMP_OFF, LAMP_OFF, LAMP_OFF, SOUND_OFF);
            }

            WriteLampLogs("Set all Lamp off." + System.Environment.NewLine);
        }

        // Control Green light
        public async void SetGreenLight(byte green, byte sound)
        {
            bool bolLamp = false;

            if (LAMP_ON != green && LAMP_BLINK != green) green = LAMP_OFF;
            if (sound < 0 || sound > 5) sound = 0;

            bolLamp = SetLamp(defaultLamp, LAMP_OFF, LAMP_OFF, green, LAMP_OFF, LAMP_OFF, sound);

            if (bolLamp) WriteLampLogs("Set Lamp " + ((defaultLamp + 1).ToString()) + " success.");
            else WriteLampLogs("Set Lamp " + ((defaultLamp + 1).ToString()) + " error.");

            if (autoOffAfter > 0)
            {
                await Task.Delay(autoOffAfter);
                SetLampOff(defaultLamp);
                WriteLampLogs("Lamp " + ((defaultLamp + 1).ToString()) + " auto off." + System.Environment.NewLine);
            }
        }

        // Control Amber light
        public async void SetAmberLight(byte amber, byte sound)
        {
            bool bolLamp = false;

            if (LAMP_ON != amber && LAMP_BLINK != amber) amber = LAMP_OFF;
            if (sound < 0 || sound > 5) sound = 0;

            bolLamp = SetLamp(defaultLamp, LAMP_OFF, amber, LAMP_OFF, LAMP_OFF, LAMP_OFF, sound);

            if (bolLamp) WriteLampLogs("Set Lamp " + ((defaultLamp + 1).ToString()) + " success.");
            else WriteLampLogs("Set Lamp " + ((defaultLamp + 1).ToString()) + " error.");

            if (autoOffAfter > 0)
            {
                await Task.Delay(autoOffAfter);
                SetLampOff(defaultLamp);
                WriteLampLogs("Lamp " + ((defaultLamp + 1).ToString()) + " auto off." + System.Environment.NewLine);
            }
        }

        // Control Red light
        public async void SetRedLight(byte red, byte sound)
        {
            bool bolLamp = false;

            if (LAMP_ON != red && LAMP_BLINK != red) red = LAMP_OFF;
            if (sound < 0 || sound > 5) sound = 0;

            bolLamp = SetLamp(defaultLamp, red, LAMP_OFF, LAMP_OFF, LAMP_OFF, LAMP_OFF, sound);

            if (bolLamp) WriteLampLogs("Set Lamp " + ((defaultLamp + 1).ToString()) + " success.");
            else WriteLampLogs("Set Lamp " + ((defaultLamp + 1).ToString()) + " error.");

            if (autoOffAfter > 0)
            {
                await Task.Delay(autoOffAfter);
                SetLampOff(defaultLamp);
                WriteLampLogs("Lamp " + ((defaultLamp + 1).ToString()) + " auto off." + System.Environment.NewLine);
            }
        }

    }
}
