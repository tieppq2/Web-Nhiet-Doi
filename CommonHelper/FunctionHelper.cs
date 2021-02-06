using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace CommonHelper
{
    public static class FunctionHelper
    {
        public static String frame_linkyoutobe(String _input)
        {

            return _input.Replace("watch?v=", "embed/");
        }
        public static String frame_avata(String _input)
        {
            try
            {

                String _imp = "{0,1}v=";
                String _imp2 = @"&";
                String[] tmp;

                String _avata = _input.Replace("https://www.youtube.com/watch?v=", "");
                tmp = Regex.Split(_avata, _imp2);

                _avata = tmp[0];


                return "https://i.ytimg.com/vi/" + _avata.Trim() + "/0.jpg";
            }
            catch
            {
                return "";
            }
        }
        public static String getLink(String type, String title, String id)
        {
            /*
             type: 2 -tin, 1 - vanban - 3 thong bao            */


            if (type == "2")
            {
                return "./" + _genLinkRewrite(title) + "-c2" + id + ".html";
            }
            if (type == "1")
            {
                return "./document-" + _genLinkRewrite(title) + "-c2" + id + ".html";
            }
            if (type == "3")
            {
                return "./notification-" + _genLinkRewrite(title) + "-c2" + id + ".html";
            }
            if (type == "4")
            {//lich-truc-hang-ngay-c2([0-9]+).html
                return "./lich-truc-hang-ngay-c2" + id + ".html";
            }
            if (type == "4")
            {
                return "./top-pic-" + _genLinkRewrite(title) + "-c2" + id + ".html";
            }
            String Link = type.ToString() + "-" + _genLinkRewrite(title) + "-" + id + ".html";
            return Link;
        }


        public static String getLinklike(String type, String title, String id)
        {
            /*
             type: 2 -tin, 1 - vanban - 3 thong bao
             */
            if (type == "2")
            {
                return "http://zigk.xyz/" + _genLinkRewrite(title) + "-c2" + id + ".html";
            }

            String Link = "http://zigk.xyz/" + _genLinkRewrite(title) + "-" + id + ".html";
            return Link;
        }
        public static String getLinkdm(String title, String id, int page)
        {
          
                return "./chuyen-muc-" + _genLinkRewrite(title) + "-c2" + id + "-"+page+".html";
          
        }
        public static String getLinkuser(String title, String id, int page)
        {

            return "./username-" + _genLinkRewrite(title) + "-c2" + id + "-" + page + ".html";

        }
        public static String getLinktoppic(String title, String id, int page)
        {

            return "./top-pic-" + _genLinkRewrite(title) + "-c2" + id + "-" + page + ".html";

        }
        public static String GetUrlImage(String type, String url)
        {
            return url;
        }
        public static String _genLinkRewrite(String _input)
        {
            String tmp = "";
            try
            {
                tmp = UnicodeToPlain(_input).ToLower();
                tmp = tmp.Replace(@" ", "-");
                tmp = Regex.Replace(tmp, @"[^A-Za-z0-9-]+", "");
                tmp = tmp.Replace(@"---", "-");
                tmp = tmp.Replace(@"--", "-");
                tmp = tmp.Trim('-');
            }
            catch { }
            return tmp;
        }
        public static String UnicodeToPlain(String strEncode)
        {
            int p1, p2;
            string oStr;
            p2 = strEncode.Length;
            oStr = "";
            for (p1 = 0; p1 < p2; p1++)
            {
                switch (strEncode.Substring(p1, 1))
                {
                    case "à":
                    case "á":
                    case "ạ":
                    case "ả":
                    case "ã":
                    case "ă":
                    case "ằ":
                    case "ắ":
                    case "ẳ":
                    case "ặ":
                    case "ẵ":
                    case "â":
                    case "ầ":
                    case "ấ":
                    case "ẩ":
                    case "ẫ":
                    case "ậ":
                        oStr += "a"; break;
                    case "À":
                    case "Á":
                    case "Ạ":
                    case "Ả":
                    case "Ã":
                    case "Ă":
                    case "Ằ":
                    case "Ắ":
                    case "Ẳ":
                    case "Ặ":
                    case "Ẵ":
                    case "Â":
                    case "Ầ":
                    case "Ấ":
                    case "Ẩ":
                    case "Ẫ":
                    case "Ậ":
                        oStr = oStr + "A"; break;
                    case "è":
                    case "é":
                    case "ẹ":
                    case "ẻ":
                    case "ẽ":
                    case "ê":
                    case "ề":
                    case "ế":
                    case "ể":
                    case "ệ":
                    case "ễ":
                        oStr = oStr + "e"; break;
                    case "È":
                    case "É":
                    case "Ẹ":
                    case "Ẻ":
                    case "Ẽ":
                    case "Ê":
                    case "Ề":
                    case "Ế":
                    case "Ể":
                    case "Ệ":
                    case "Ễ":
                        oStr = oStr + "E"; break;
                    case "ò":
                    case "ó":
                    case "ọ":
                    case "ỏ":
                    case "õ":
                    case "ơ":
                    case "ờ":
                    case "ớ":
                    case "ở":
                    case "ợ":
                    case "ỡ":
                    case "ô":
                    case "ồ":
                    case "ố":
                    case "ổ":
                    case "ộ":
                    case "ỗ":
                        oStr = oStr + "o"; break;
                    case "Ò":
                    case "Ó":
                    case "Ọ":
                    case "Ỏ":
                    case "Õ":
                    case "Ơ":
                    case "Ờ":
                    case "Ớ":
                    case "Ở":
                    case "Ợ":
                    case "Ỡ":
                    case "Ô":
                    case "Ồ":
                    case "Ố":
                    case "Ổ":
                    case "Ộ":
                    case "Ỗ":
                        oStr = oStr + "O"; break;
                    case "ù":
                    case "ú":
                    case "ụ":
                    case "ủ":
                    case "ũ":
                    case "ư":
                    case "ừ":
                    case "ứ":
                    case "ử":
                    case "ự":
                    case "ữ":
                        oStr = oStr + "u"; break;
                    case "Ù":
                    case "Ú":
                    case "Ụ":
                    case "Ủ":
                    case "Ũ":
                    case "Ư":
                    case "Ừ":
                    case "Ứ":
                    case "Ử":
                    case "Ự":
                    case "Ữ":
                        oStr = oStr + "U"; break;
                    case "ỳ":
                    case "ý":
                    case "ỵ":
                    case "ỷ":
                    case "ỹ":
                        oStr = oStr + "y"; break;
                    case "Ỳ":
                    case "Ý":
                    case "Ỵ":
                    case "Ỷ":
                    case "Ỹ":
                        oStr = oStr + "Y"; break;
                    case "ì":
                    case "í":
                    case "ị":
                    case "ỉ":
                    case "ĩ":
                        oStr = oStr + "i"; break;
                    case "Ì":
                    case "Í":
                    case "Ị":
                    case "Ỉ":
                    case "Ĩ":
                        oStr = oStr + "I"; break;
                    case "đ": oStr = oStr + "d"; break;
                    case "Đ": oStr = oStr + "D"; break;
                    default:
                        oStr += strEncode.Substring(p1, 1); break;
                }
            }
            return oStr.ToLower().Replace("&", "va");
        }
        public static String getTimePublish(String input)
        {
            String _timeout = "";
            try
            {
                _timeout = Convert.ToDateTime(input).ToShortDateString();
            }
            catch
            {
                _timeout = DateTime.Now.ToShortDateString();
            }

            return _timeout;
        }
        public static string GetValueInt(string name, string defaultValue)
        {
            string res = GetValue(name, defaultValue);
            return ValidateInt(res, defaultValue);
        }
        public static string GetValue(string name, string defaultValue)
        {
            string res = (HttpContext.Current.Request.QueryString[name] == null ? defaultValue : HttpContext.Current.Request.QueryString[name]);
            res = ValidateXSS(res);
            res = KillChars(res);
            return res;
        }
        public static string ValidateXSS(string strWords)
        {
            StringBuilder sb = new StringBuilder(HttpUtility.HtmlEncode(strWords));
            string[] badChars = { "&lt;", "&gt;", "script", "iframe", "&#62", "&#60", "&#59", "&#47", "&#41", "&#40", "&#39", "&#38", "&#35", "&#34" };
            string newChars = sb.ToString();
            foreach (string str in badChars)
            {
                //newChars = newChars.Replace(str, "");
                newChars = Regex.Replace(newChars, str, "", RegexOptions.IgnoreCase);
            }

            return newChars;
        }
        public static string ValidateInt(string input, string defaultValue)
        {
            if (input == null)
                return defaultValue;
            Regex objNotWholePattern = new Regex("[^0-9]");
            if (!objNotWholePattern.IsMatch(input) && (input != ""))
                return input;
            else
                return defaultValue;
        }
        public static string KillChars(string strWords)
        {
            string[] badChars = { "xp_", ";", "--", "<", ">", "script", "iframe", "delete", "drop", "exec", "insert", "'" };
            string newChars = strWords;
            foreach (string str in badChars)
            {
                //newChars = newChars.Replace(str, "");
                newChars = Regex.Replace(newChars, str, "", RegexOptions.IgnoreCase);
            }
            newChars = newChars.Replace("[", "");

            return newChars;
        }
    }
}
