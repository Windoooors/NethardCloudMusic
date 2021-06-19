using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace NetHard_Music
{
    class Request
    {
        public static string Post(string url, string content, CookieContainer cookie)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.CookieContainer = cookie;
            req.ContentType = "application/x-www-form-urlencoded";
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0;)";
            byte[] data = Encoding.UTF8.GetBytes(content);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        public static string Get(string url, CookieContainer cookie)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.CookieContainer = cookie;
            myRequest.Method = "GET";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0;)";
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
        }

        public static CookieContainer Cookie(string url)
        {
            CookieContainer cookies = new CookieContainer();
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myHttpWebRequest.Timeout = 20 * 1000; //连接超时  
            myHttpWebRequest.Accept = "*/*";
            myHttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0;)";
            myHttpWebRequest.CookieContainer = new CookieContainer(); //暂存到新实例</span>  
            myHttpWebRequest.GetResponse().Close();
            cookies = myHttpWebRequest.CookieContainer; //保存cookies</span>  
            return cookies;
        }
    }
}
