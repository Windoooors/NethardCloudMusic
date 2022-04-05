using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Setchin.NethardMusic.Collections;

namespace Setchin.NethardMusic
{
    public partial class ApiOperator
    {
        public User Login(string number, string password)
        {
            string md5Password = Md5Computing.Compute(password);

            string content = Get("login/cellphone", new { Phone = number, Md5Password = md5Password });
            var dto = JsonConvert.DeserializeObject<UserDto>(content);

            return _user = new User(dto.Profile.UserId, dto.Profile.Nickname);
        }

        private class UserDto
        {
            [JsonProperty("profile")]
            public ProfileInfo Profile;

            public class ProfileInfo
            {
                [JsonProperty("nickname")]
                public string Nickname;

                [JsonProperty("userId")]
                public long UserId;
            }
        }
    }

    public partial class ApiOperator
    {
        private readonly CookieContainer _cookie = new CookieContainer();
        private readonly string _baseUrl;

        private User _user;

        public string BaseUrl { get { return _baseUrl; } }

        public User User { get { return _user; } }

        public ApiOperator(string baseUrl)
        {
            if (baseUrl == null)
            {
                throw new ArgumentNullException("baseUrl");
            }

            _baseUrl = baseUrl;
        }

        public string Post(string path, object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            string postableContent = ToUriQueryString(content);
            return PostCore(new UriBuilder(_baseUrl) { Path = path }.Uri.AbsoluteUri, postableContent);
        }

        public string Get(string path, object content)
        {
            string query = content == null ? null : ToUriQueryString(content);
            return GetCore(new UriBuilder(_baseUrl) { Path = path, Query = query }.Uri.AbsoluteUri);
        }

        private static string ToUriQueryString(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            return string.Join("&", obj.GetType().GetProperties().Select(prop =>
                {
                    object value = prop.GetValue(obj, null);
                    return Uri.EscapeDataString(ToUnderScoreCase(prop.Name)) + "=" + Uri.EscapeDataString(value == null ? "null" : value.ToString());
                }).ToArray());
        }

        private static string ToUnderScoreCase(string str)
        {
            var builder = new StringBuilder();

            foreach (char c in str)
            {
                if (char.IsUpper(c))
                {
                    builder.Append('_');
                    builder.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    builder.Append(c);
                }
            }

            if (builder[0] == '_')
            {
                builder.Remove(0, 1);
            }

            return builder.ToString();
        }

        public Stream GetAudioStream(string url) 
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = _cookie;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0;)";

            var response = (HttpWebResponse)request.GetResponse();

            return response.GetResponseStream();
        }

        private string PostCore(string url, string content)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.CookieContainer = _cookie;
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0;)";

            byte[] data = Encoding.UTF8.GetBytes(content);
            request.ContentLength = data.Length;

            using (var reqStream = request.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            string result;
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

        private string GetCore(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = _cookie;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0;)";

            var response = (HttpWebResponse)request.GetResponse();

            string result;
            using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
