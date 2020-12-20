using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM
{
    public class UserInfo
    {
        public static string UserID = "";
        public static string UserName = "";
        public static string LocCode = "";
        public static string LocName = "";
        public static string LocAddr = "";
        public static string LocTelNo = "";
        public static string StoreCd = "";
        public static string PosNo = "";
        public static string RoleID = "";

        public static void Clear()
        {
            UserID = "";
            UserName = "";
            LocCode = "";
            LocName = "";
            LocAddr = "";
            LocTelNo = "";
            StoreCd = "";
            PosNo = "";
            RoleID = "";
        }
    }
}
