using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Security.Cryptography;
using System.IO;
using System.Data;
using WebUtil;


namespace COM
{
    public class CommonUtils
    {
        public static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string SHA256Encrypt(string data)
        {
            SHA256 sha = new SHA256Managed ();
            byte[] hash = sha.ComputeHash (Encoding.ASCII.GetBytes (data));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hash) {
                stringBuilder.AppendFormat ("{0:x2}", b);
            }
            return stringBuilder.ToString();

        }

        public static string RemoveVietnameseChar(string text)
        {
            if (String.IsNullOrEmpty(text)) return text;

            List<string> nonUnicode = new List<string>()
            {
                "a", 
                "A",
                "d",
                "D",
                "e",
                "E",
                "i",
                "I",
                "o",
                "O",
                "u",
                "U",
                "y",
                "Y"};

            List<string[]> unicode = new List<string[]>()
            {
                new string[] {"á","à","ả","ã","ạ","ă","ắ","ặ","ằ","ẳ","ẵ","â","ấ","ầ","ẩ","ẫ","ậ"},
                new string[] {"Á","À","Ả","Ã","Ạ","Ă","Ắ","Ặ","Ằ","Ẳ","Ẵ","Â","Ấ","Ầ","Ẩ","Ẫ","Ậ"},
                new string[] {"đ"},
                new string[] {"Đ"},
                new string[] {"é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ"},
                new string[] {"É","È","Ẻ","Ẽ","Ẹ","Ê","Ế","Ề","Ể","Ễ","Ệ"},
                new string[] {"í","ì","ỉ","ĩ","ị"},
                new string[] {"Í","Ì","Ỉ","Ĩ","Ị"},
                new string[] {"ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ"},
                new string[] {"Ó","Ò","Ỏ","Õ","Ọ","Ô","Ố","Ồ","Ổ","Ỗ","Ộ","Ơ","Ớ","Ờ","Ở","Ỡ","Ợ"},
                new string[] {"ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự"},
                new string[] {"Ú","Ù","Ủ","Ũ","Ụ","Ư","Ứ","Ừ","Ử","Ữ","Ự"},
                new string[] {"ý","ỳ","ỷ","ỹ","ỵ"},
                new string[] {"Ý","Ỳ","Ỷ","Ỹ","Ỵ"}
            };

            for (int i = 0; i < nonUnicode.Count; i++)
            {
                string nonUni = nonUnicode[i];
                string[] uni = unicode[i];
                for (int j = 0; j < uni.Length; j++)
                {
                    text = text.Replace(uni[j], nonUni);
                }
            }
            return text;

        }

        public static string cancelPayment(int ordId)
        {
            JsonRequest jsonRequest = new JsonRequest();

            // Update order stop flag
            ProcAction selectOrder = jsonRequest.NewAction();
            selectOrder.proc = WebUtil.Values.PROC_SQL;
            StringBuilder query = new StringBuilder();
            query.Append(" select id, purchase_info ");
            query.Append(" from kmarket.product_orders ");
            query.Append(" where id = #{ord_id} ");

            selectOrder.text = query.ToString();
            selectOrder.param.Add("ord_id", ordId);

            WebClient client = new WebClient();
            DataSet ds = client.Execute(jsonRequest);

            if (!client.check || ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return "Order ID Error";
            }

            object purchaseInfo = ds.Tables[0].Rows[0]["purchase_info"];
            if (purchaseInfo == DBNull.Value || purchaseInfo == "" || purchaseInfo == null)
            {
                return null;
            }

            try
            {
                // 요청을 보내는 URI
                string strUri = System.Configuration.ConfigurationSettings.AppSettings["cancelPaymentUrl"];

                // POST, GET 보낼 데이터 입력
                StringBuilder dataParams = new StringBuilder();
                dataParams.Append("order_id=" + ordId);

                // 요청 String -> 요청 Byte 변환
                byte[] byteDataParams = UTF8Encoding.UTF8.GetBytes(dataParams.ToString());

                /* POST */
                // HttpWebRequest 객체 생성, 설정
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(strUri);
                request.Method = "POST";    // 기본값 "GET"
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteDataParams.Length;

                // 요청 Byte -> 요청 Stream 변환
                Stream stDataParams = request.GetRequestStream();
                stDataParams.Write(byteDataParams, 0, byteDataParams.Length);
                stDataParams.Close();

                // 요청, 응답 받기
                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return null;
                }
                else if ((int)response.StatusCode == 101)
                {
                    return "Order ID Error";
                }
                else if ((int)response.StatusCode == 102)
                {
                    return "Status Error";
                }
                else if ((int)response.StatusCode == 103)
                {
                    return "Refund Error!";
                }
                else
                {
                    return "Server Error!";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            
        }
    }
}
